using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiApiNetCore.WebSocketManager;
using Newtonsoft.Json;
using FaxiApiNetCore.Dtos;
using ApiDomain.Interfaces.Domain.Services;
using AutoMapper;
using ApiDomain.Entities;
using System.Diagnostics;
using ApiDomain.Services;
using ApiInfraestructure.Data.Contexts;
using System.Data.Entity.Core.Objects;
using NuGet.Frameworks;
//using Nest;
using System.Device.Location;

namespace ApiApiNetCore.Socket
{
    public class ChatConnection : WebSocketConnection
    {
        //private readonly IVehiculoPosicionDomainService _vehiculoPosicionService;
        //private readonly IMapper _mapper;
        private readonly PostgresDbContext _context;
        public ChatConnection(WebSocketHandler handler, PostgresDbContext context) : base(handler)
        {
            //_vehiculoPosicionService = new  VehiculoPosicionService;
            _context = context;
        }

        public string SocketId { get; set; }

        public override async Task ReceiveAsync(string message)
        {
            var receiveMessage = JsonConvert.DeserializeObject<ReceiveMessage>(message);
            Debug.WriteLine("Received socket signal");
            var messageType = receiveMessage.Type;
            if(messageType == "chat")
            {
                Debug.WriteLine("New Message");
                var receivers = Handler.Connections.FindAll(m => ((ChatConnection)m).SocketId == receiveMessage.ReceiverId);

                if (receivers.Count != 0)
                {
                    receivers.ForEach(async delegate (WebSocketConnection receiver)
                    {
                        var sendMessage = JsonConvert.SerializeObject(new SendMessage
                        {
                            Sender = SocketId,
                            Type = "chat",
                            Message = receiveMessage.Message
                        });
                        var chatRecevier = (ChatConnection)receiver;
                        await chatRecevier.SendMessageAsync(sendMessage);
                    });
                }
                else
                {
                    var sendMessage = JsonConvert.SerializeObject(new SendMessage
                    {
                        Sender = SocketId,
                        Type = "SocketError",
                        Message = "Can not seed to " + receiveMessage.ReceiverId
                    });

                    await SendMessageAsync(sendMessage);
                }
            }
            else if(messageType == "gps")           // Socket module for GPS location update.
            {
                /*
                 * GPS location data will be read from socket data as Location1
                 * Location1 in socket data will be saved to VehiculoPosicion 
                 */
                Debug.WriteLine("GPS update");
                if (receiveMessage.Location1 != null)
                {
                    try
                    {
                        //Debug.WriteLine("GPS update");
                        if (_context.VehiculoPosicion.Count<VehiculoPosicion>(s => s.IdCuentaUsuario == Int32.Parse(SocketId)) > 0)
                        {
                            Debug.WriteLine("GPS position Update");
                            var entity = _context.VehiculoPosicion.Where(s => s.IdCuentaUsuario == Int32.Parse(SocketId)).First<VehiculoPosicion>();
                            entity.Latitud = receiveMessage.Location1.Latitud;
                            entity.Longitud = receiveMessage.Location1.Longitud;
                            entity.UltimaActualizacion = DateTime.Now;
                            _context.Update<VehiculoPosicion>(entity);
                        }
                        else
                        {
                            //Debug.WriteLine("GPS position Add");
                            var entity = new VehiculoPosicion
                            {
                                IdCuentaUsuario = Int32.Parse(SocketId),
                                Latitud = receiveMessage.Location1.Latitud,
                                Longitud = receiveMessage.Location1.Longitud,
                                UltimaActualizacion = DateTime.Now
                            };
                            //entity.UltimaActualizacion = DateTime.Now;
                            _context.VehiculoPosicion.Add(entity);
                        }
                        
                        _context.SaveChanges();
                    } catch (Exception e)
                    {
                        Console.WriteLine("---------Exception--------");
                        Console.WriteLine(e.Message);
                        Console.WriteLine("-----Trace----");
                        Console.WriteLine(e.StackTrace);
                        Console.WriteLine("-----End----");
                    }
                }
            }
            else if(messageType == "new_trip")      // Socket module for New Trip Request
            {
                /*
                 * New socket request will be requested with socket data
                 * Location1: from place
                 * Location2: to place
                 * Status: should be 1 when new trip
                 */
                 /* This new socket data will trigger new trip to drivers in 10km*/
                 /* Making New Viaje data */
                Debug.WriteLine("New Trip Request");
                var userioEntity = _context.CuentasUsuario.Where(s => s.Id == Int32.Parse(SocketId)).First<CuentaUsuario>();
                if(userioEntity == null)
                {
                    Debug.WriteLine("User does not exist");
                    return;
                }
                var eStatusViajeEntity = _context.EstatusViajes.Where(s => s.Id == receiveMessage.Status).First<EstatusViaje>();
                var viajeEntity = new Viaje
                {
                    LatitudOrigen = receiveMessage.Location1.Latitud.ToString(),
                    LongitudOrigen = receiveMessage.Location1.Longitud.ToString(),
                    LatitudDestino = receiveMessage.Location2.Latitud.ToString(),
                    LongitudDestino = receiveMessage.Location2.Longitud.ToString(),
                    EstatusViajeId = receiveMessage.Status,
                    FechaAlta = DateTime.Now,
                    UltimaModificacion = DateTime.Now,
                    EstatusViaje = eStatusViajeEntity
                };
                _context.Viajes.Add(viajeEntity);
                _context.SaveChanges();
                Debug.WriteLine("viajeId: " + viajeEntity.Id.ToString());

                var viajesClienteEntity = new ViajeUsuario
                {
                    ClienteId = (int)userioEntity.Id,
                    ViajeId = (int)viajeEntity.Id,
                    FechaAlta = DateTime.Now
                };
                _context.ViajesUsuarios.Add(viajesClienteEntity);
                _context.SaveChanges();
                Debug.WriteLine("viajeId: " + viajeEntity.Id.ToString() + "clienteId: " + viajesClienteEntity.Id.ToString());

                // Finding and Sending requests to drivers in 10km
                var activeUsuarioEntities = _context.CuentasUsuario.Where<CuentaUsuario>(s => s.EnServicio == true && s.IdTipoCuenta == 1);
                int requestedDriverCnt = 0;
                foreach(var entity in activeUsuarioEntities)
                {
                    if(requestedDriverCnt == 10)
                    {
                        break;
                    }
                    var viajeConductor = _context.ViajesConductores.Where(s => s.IdConductor == entity.Id).Last<ViajeConductor>();
                    if(viajeConductor.Viaje.EstatusViajeId == 1)
                    {
                        var driverPositionEntity = _context.VehiculoPosicion.Where(s => s.IdCuentaUsuario == entity.Id).First<VehiculoPosicion>();

                        GeoCoordinate clientPosition = new GeoCoordinate(double.Parse(viajeEntity.LatitudOrigen), double.Parse(viajeEntity.LongitudOrigen));
                        GeoCoordinate driverPosition = new GeoCoordinate(driverPositionEntity.Latitud, driverPositionEntity.Longitud);
                        double distance = clientPosition.GetDistanceTo(driverPosition);
                        if(distance < 10000)
                        {
                            var receivers = Handler.Connections.FindAll(m => ((ChatConnection)m).SocketId == entity.Id.ToString());

                            if (receivers.Count != 0)
                            {
                                requestedDriverCnt++;
                                receivers.ForEach(async delegate (WebSocketConnection receiver)
                                {

                                    var sendMessage = JsonConvert.SerializeObject(new SendMessage
                                    {
                                        Sender = SocketId,
                                        Type = "new_trip_request",
                                        TripData = new NewTripRequest
                                        {
                                            PassengerName = userioEntity.Usuario.Nombre,
                                            ViajeId = (int)viajeEntity.Id,
                                            From = new CoordinateData
                                            {
                                                Latitud = double.Parse(viajeEntity.LatitudOrigen),
                                                Longitud = double.Parse(viajeEntity.LongitudOrigen)
                                            },
                                            To = new CoordinateData
                                            {
                                                Latitud = double.Parse(viajeEntity.LatitudDestino),
                                                Longitud = double.Parse(viajeEntity.LongitudDestino)
                                            }
                                        }
                                    });
                                    var chatRecevier = (ChatConnection)receiver;
                                    await chatRecevier.SendMessageAsync(sendMessage);
                                });
                            }
                            else
                            {
                                var sendMessage = JsonConvert.SerializeObject(new SendMessage
                                {
                                    Sender = SocketId,
                                    Type = "SocketError",
                                    Message = "Can not send new request"
                                });

                                await SendMessageAsync(sendMessage);
                            }
                        }
                    }
                }
            }
            else if (messageType == "accept_trip")      // Socket Module for accepting new trip for driver
            {
                /* 
                 * Acception new trip will be triggered by conductor
                 * It will change viaje status to 2
                 * and will add data to ViajesConductor table
                 */
                var viajeConductor = new ViajeConductor
                {
                    IdConductor = int.Parse(SocketId),
                    IdViaje = receiveMessage.ConductorData.IdViaje,
                    FechaAlta = DateTime.Now
                };
                _context.ViajesConductores.Add(viajeConductor);
                _context.SaveChanges();
                var viajeEntity = _context.Viajes.Where(s => s.Id == receiveMessage.ConductorData.IdViaje).First<Viaje>();
                viajeEntity.EstatusViajeId = 2;
                _context.Update<Viaje>(viajeEntity);
                _context.SaveChanges();
            }
            else if (messageType =="status_trip_change")                // this socket is called when trip is canceled
            {
                /* 
                 * This module is for changing status of Viaje
                 * related to cat_estatus_viajes
                 * Will be called when trip is canceled
                 * Status in SocketData will include changed status data
                 * Status can be
                 * 5: Cancelado Cliente
                 * 6: Canceloado Conductor
                 */
                var viajeEntity = _context.Viajes.Where(s => s.Id == receiveMessage.ConductorData.IdViaje).First<Viaje>();
                viajeEntity.EstatusViajeId = receiveMessage.Status;
                _context.Update<Viaje>(viajeEntity);
                _context.SaveChanges();
            }
            else if (messageType == "finish_trip")      // Socket Module for finish trip
            {
                /* 
                 * This module will be called when trip is finished
                 * Finishing trip will call socket with distance and Tarifa
                 * This data will be saved to ViajeConductor 
                 * and also will change viaje status to Finish(4)
                 */
                var viajeConductor = _context.ViajesConductores.Where(s => s.Id == receiveMessage.ConductorData.Id).First<ViajeConductor>();
                viajeConductor.KmRecorridos = receiveMessage.ConductorData.KmRecorridos;
                viajeConductor.Tarifa = receiveMessage.ConductorData.Tarifa;
                _context.Update<ViajeConductor>(viajeConductor);
                _context.SaveChanges();

                var viajeEntity = _context.Viajes.Where(s => s.Id == receiveMessage.ConductorData.IdViaje).First<Viaje>();
                viajeEntity.EstatusViajeId = 4;
                _context.Update<Viaje>(viajeEntity);
                _context.SaveChanges();
            }
            else if (messageType == "get_nearby_drivers")
            {
                /*
                 * This module is for Getting NearBy drivers on Map View in client side
                 * Client Socket will request data with 
                 * Type: "get_nearby_drivers"
                 * Location1: { Latitud: xxx, Longitud: xxx}
                 * Module will retrieve socket data with nearest 10 drivers in 10km
                 * with Type: "
                 *   Type = "near_by_drivers",
                 *   NearByDrivers = driverList
                 *   NearByDrivers is Array for Driver Data with {Id and Location{Latitud: xxx, Longitud: yyy}}
                 */
                var activeUsuarioEntities = _context.CuentasUsuario.Where<CuentaUsuario>(s => s.EnServicio == true && s.IdTipoCuenta == 1);
                int requestedDriverCnt = 0;
                List<DriverLocation> driverList = new List<DriverLocation>();
                // Finding List of drivers in 10km
                foreach (var entity in activeUsuarioEntities)
                {
                    if (requestedDriverCnt == 10)
                    {
                        break;
                    }
                    var viajeConductor = _context.ViajesConductores.Where(s => s.IdConductor == entity.Id).Last<ViajeConductor>();
                    if (viajeConductor.Viaje.EstatusViajeId == 1)
                    {
                        var driverPositionEntity = _context.VehiculoPosicion.Where(s => s.IdCuentaUsuario == entity.Id).First<VehiculoPosicion>();

                        GeoCoordinate clientPosition = new GeoCoordinate(double.Parse(receiveMessage.Location1.Latitud.ToString()), double.Parse(receiveMessage.Location1.Longitud.ToString()));
                        GeoCoordinate driverPosition = new GeoCoordinate(driverPositionEntity.Latitud, driverPositionEntity.Longitud);
                        double distance = clientPosition.GetDistanceTo(driverPosition);
                        if (distance < 10000)
                        {
                            // Add Driver Data to List Wit Coordinate Data
                            driverList.Add(
                                new DriverLocation
                                {
                                    Id = (int)entity.Id,
                                    Location = new CoordinateData
                                    {
                                        Latitud = driverPositionEntity.Latitud,
                                        Longitud = driverPositionEntity.Longitud
                                    }
                                }
                            );
                        }
                    }
                }
                var sendMessage = JsonConvert.SerializeObject(new SendMessage
                {
                    Sender = SocketId,
                    Type = "near_by_drivers",
                    NearByDrivers = driverList
                });
                //var chatRecevier = (ChatConnection)receiver;
                await SendMessageAsync(sendMessage);
            }
        }

        private class CoordinateData
        {
            public double Latitud { get; set; }
            public double Longitud { get; set; }
        }
        private class ViajeConductorData
        {
            public int Id { get; set; }
            public int IdViaje { get; set; }
            public int KmRecorridos { get; set; }
            public int Tarifa { get; set; }
            public int Calificacion { get; set; }

        }
        private class ReceiveMessage
        {
            public string ReceiverId { get; set; }            // id_cuenta

            public string Type { get; set; }
            // 'chat' : normal message 
            // 'gps' : gps update message 
            // 'new_trip' : new trip request from client 
            // 'accept_trip' : conductor accepts trip

            public string Message { get; set; }

            public CoordinateData Location1 { get; set; }       // Origin Location, 
            public CoordinateData Location2 { get; set; }       // Destination Location

            public int Status { get; set; }                     // Status value
            public ViajeConductor ConductorData { get; set; }
        }
        private class NewTripRequest
        {
            public string PassengerName { get; set; }
            public int ViajeId { get; set; }
            public CoordinateData From { get; set; }
            public CoordinateData To { get; set; }
        }
        private class DriverLocation
        {
            public int Id { get; set; }
            public CoordinateData Location { get; set; }
        }
        private class SendMessage
        {
            public string Sender { get; set; }

            public string Type { get; set; }

            public string Message { get; set; }

            public NewTripRequest TripData { get; set; }

            public virtual List<DriverLocation> NearByDrivers { get; set; }         // Driver List in 10 km
        }
    }
}