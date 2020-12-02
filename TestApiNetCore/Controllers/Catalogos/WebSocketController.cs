using System;
using System.Collections.Generic;
using FaxiApiNetCore.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

using ApiDomain.Interfaces.Domain.Services;
using Microsoft.AspNetCore.Authorization;

namespace ApiApiNetCore.Controllers.Catalogos
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]

    public class WebSocketController : ControllerBase
    {
        private readonly IHubContext<ChatHub> ChatHub;

        public readonly IPaisDomainService _service;

        public WebSocketController(IPaisDomainService service)
        {
            _service = service;
        }

        public WebSocketController(IHubContext<ChatHub> ChatHub)
        {
            this.ChatHub = ChatHub;
        }

        //Aquí parte la primera etapa del proceso.

        //Cliente crea conexion con WebSocket y paso su ID.
        // GET: api/WebSocket/1
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
           int valor = id;
            ChatHub.Clients.All.SendAsync("ReceiveMessage", "Admin", "Se conectó nuevo usuario!");
            return ("connected exitosa Cliente - WebSocket", "ID cliente: " + valor).ToString();
        }

        //Cliente Envía ID de viaje a WebSocket
        [HttpGet("Viaje/{id}")]
        public string Viaje(int id)
        {
            int valor = id;
            ChatHub.Clients.All.SendAsync("ReceiveMessage", "Admin", "Cliente envía nuevo ID de viaje!");
            return ("Cliente envía ID de viaje a WebSocket", "ID viaje: " + valor).ToString();
       }

        //WebSocket abre conexión con Conductores
        [HttpGet("Conductores")]
        public string Conductores()
        {
            ChatHub.Clients.All.SendAsync("ReceiveMessage", "Admin", "WebSocket abre conexión con conductores!");

            string valor2 = ("connected, WebSocket abre conexión con Conductores").ToString();
            return valor2;

        }

        //WebSocket envía a Conductores ID de viaje
        [HttpGet("Conductores/{id}")]
        public string Conductores(int id)
        {
            int valor = id;
            ChatHub.Clients.All.SendAsync("ReceiveMessage", "Admin", "Web Socket envía a Conductores ID de viaje");
            return ("connected, Web Socket envía a Conductores ID de viaje", "ID viaje: " + valor).ToString();
       }

        //Conductor acepta el viaje responde a WebSocket envía ID de Conductor y ID de viaje
        [HttpGet("Conductores/{ConductorId}/{ViajeId}")]
        public string Conductores(int ConductorId, int ViajeId)
        {
            int valor1 = ConductorId;
            int valor2 = ViajeId;
            ChatHub.Clients.All.SendAsync("ReceiveMessage", "Admin", "Web Socket envía ID viaje y ID conductor a otros conductores no asignados!");

            //Aquí se verifica que Viaje ID no fue asignado  otro ID Conductor.  //Esto creo que no tiene sentido. Siempre uno es el primero. El tiempo se mide en lilisegundos!!
  
            //Aquí se crea un registro en tabla "historial_viajes_conductores".


            //Tarifa y km. de viaje estan en CERO
            //Se ctualiza ESTATUS de viaje a ASIGNADO.
            return ("connected, Conductor envía su ID y ID de viaje aceptando carrera!", "ID Conductor: " + valor1.ToString(), "ID Viaje: " + valor2.ToString()).ToString();
        }

        //Aquí parte la segunda etapa del proceso.

        //WebSocket envía mensaje a Cliente y a Conductor que el viaje a sido asignado.
        [HttpGet("Conductores/{ConductorId}/{ViajeId}/{ClienteId}")]
        public string Conductores(int ConductorId, int ViajeId, int ClienteId)
        {
            int valor1 = ConductorId;
            int valor2 = ViajeId;
            int valor3 = ClienteId;
            ChatHub.Clients.All.SendAsync("ReceiveMessage", "Admin", "Web Socket envía ID viaje y ID conductor a otros conductores no asignados!");
            return ("connected, WebSocket envía ID de viaje asignado a Conductor y Cliente!", "ID Conductor: " + valor1.ToString(), "ID Viaje: " + valor2.ToString(), "ID Cliente: " + valor3.ToString()).ToString();
        }

        //WebSoket envía mensaje a los otros conductores que ID de viaje ya fue asignado a otro conductor.
        [HttpGet("Viaje/{ViajeId}/{ConductorId}")]
        public string Viaje(int ViajeId, int ConductorId)
        {
            int valor1 = ViajeId;
            int valor2 = ConductorId;
            ChatHub.Clients.All.SendAsync("ReceiveMessage", "Admin", "WebSocket envía mensaje ID de viaje y ID de conductor a otros conductores no asignados!");
            return ("connected, WebSocket envía mensaje ID de viaje y ID de conductor a otros conductores no asignados!", "ID Conductor: " + valor1.ToString(), "ID Viaje: " + valor2.ToString()).ToString();
        }

        //Aquí parte la carrera, es decir, se inicia el viaje desde la ubicación del cliente a su destino final.

        //WebSoket envía mensaje a los otros conductores que ID de viaje ya fue asignado a otro conductor.
        [HttpGet("Carrera/{ViajeId}")]
        public string Carrera(int ViajeId)
        {
            //Aquí actualizo tabla "viajes" en Estatus se pone "En proceso", código 3 de la tabla de cat_estatus_viajes
            //Se actualiza la hora de inicio de la carrera con la hora del Sistema en ese momento.
            int valor1 = ViajeId;
            DateTime valor2 = DateTime.Now;
            ChatHub.Clients.All.SendAsync("ReceiveMessage", "Admin", "Conductos informa a WebSocket la hora de inicio de viaje ID de viaje y hora.");
            return ("connected, Conductos informa a WebSocket la hora de inicio de viaje ID de viaje y hora.", "ID viaje: " + valor1.ToString(), "Hora de inicio del viaje: " + valor2.ToString()).ToString();
        }

        //WebSoket envía a cliente que viaje ha iniciado.
        [HttpGet("Iniciado/{ViajeId}/{ClienteId}")]
        public string Iniciado(int ViajeId, int ClienteId)
        {
            int valor1 = ViajeId;
            int valor2 = ClienteId;
            ChatHub.Clients.All.SendAsync("ReceiveMessage", "WebSocket envía mensaje a Cliente con ID de viaje y ID de Cliente donde se informa que viaje partió!");
            return ("connected, WebSocket envía mensaje a Cliente con ID de viaje y ID de Cliente donde se informa que viaje partió!", "ID Viaje: " + valor1.ToString(), "ID Cliente: " + valor2.ToString()).ToString();
        }

        //Conductor envía mensaje a websocket que viaje terminó.
        [HttpGet("Termindo/{ViajeId}/{ClienteId}/{ConductorId}")]
        public string Terminado(int ViajeId, int ClienteId, int ConductorId)
        {
            int valor1 = ViajeId;
            int valor2 = ClienteId;
            int valor3 = ConductorId;
            DateTime valor4 = DateTime.Now;

            //Aquí se ingresa la cantidad de km recorridos.
            //Se actualiza el estatus del viaje a "Finalizdo".
            //Hora de finalización del viaje. Se calculo en variable valor4
            //Se calcula tarifa a cobrar según distancia recorrida reprtada por el conductor.
            //Se actualiza tabla historial_viajes_conductores, con Km recorridos, según lo informado por el conductor.
            //Se envia tarifa calculada a conductor y a cliente.


            ChatHub.Clients.All.SendAsync("ReceiveMessage", "Conductor envía mensje a aviWebSocket viaje terminado, ViajeId, ClienteId,Conductor,Fecha Termino!");
            return ("connected, Conductor envía mensje a aviWebSocket viaje terminado, ViajeId, ClienteId,Conductor,Fecha Termino!", "ID Viaje: " + valor1.ToString(), "ID Cliente: " + valor2.ToString(), "ID Conductor: " + valor3.ToString(), "Hora de Término: " + valor4.ToString()).ToString();
        }

        //Conductor envía mensaje a websocket que viaje terminó.
        [HttpGet("Pagado/{ViajeId}/{ClienteId}/{ConductorId}")]
        public string Pagado(int ViajeId, int ClienteId, int ConductorId)
        {
            int valor1 = ViajeId;
            int valor2 = ClienteId;
            int valor3 = ConductorId;
         
            //Aquí se actualiza tabla viajes a "Pagado".
            //
            ChatHub.Clients.All.SendAsync("ReceiveMessage", "Conductor envía mensje a aviWebSocket viaje pagado, ViajeId, ClienteId,Conductor,Fecha Termino!");
            return ("connected, Conductor envía mensaje a WebSocket viaje Pagado, ViajeId, ClienteId,Conductor,Fecha Termino!", "ID Viaje: " + valor1.ToString(), "ID Cliente: " + valor2.ToString(), "ID Conductor: " + valor3.ToString()).ToString();

        }

        //Aquí parte la tercera y última etapa del proceso, correspondiente a finalización con incidentes.

        //Conductor envía mensaje a websocket de incidente.
        [HttpGet("Incidente/{ViajeId}/{ClienteId}/{ConductorId}")]
        public string Incidente(int ViajeId, int ClienteId, int ConductorId)
        {
            int valor1 = ViajeId;
            int valor2 = ClienteId;
            int valor3 = ConductorId;

            //Aquí se actualiza tabla estatus viajes a "Con incidente".
            ChatHub.Clients.All.SendAsync("ReceiveMessage", "Conductor envía mensaje a WebSocket viaje con incidentes, ViajeId, ClienteId,Conductor,Fecha Termino!");
            return ("connected, Conductor envía mensaje a WebSocket viaje con incidentes, ViajeId, ClienteId,Conductor,Fecha Termino!", "ID Viaje: " + valor1.ToString(), "ID Cliente: " + valor2.ToString(), "ID Conductor: " + valor3.ToString()).ToString();

        }

        //WebSocket solicita al conductor motivo incidente.
        [HttpGet("Incidenteconductor/{ViajeId}/{ClienteId}/{ConductorId}")]
        public string Incidenteconductor(int ViajeId, int ClienteId, int ConductorId)
        {
            int valor1 = ViajeId;
            int valor2 = ClienteId;
            int valor3 = ConductorId;
            
            ChatHub.Clients.All.SendAsync("ReceiveMessage", "WebSocket solicita a Conductor motivo incidente, ViajeId, ClienteId,Conductor,Fecha Termino!");
            return ("connected, WebSocket solicita a conductor motivos de incidente, ViajeId, ClienteId,Conductor,Fecha Termino!", "ID Viaje: " + valor1.ToString(), "ID Cliente: " + valor2.ToString(), "ID Conductor: " + valor3.ToString()).ToString();
        }

        //WebSocket solicita al cliente motivo incidente.
        [HttpGet("Incidentecliente/{ViajeId}/{ClienteId}/{ConductorId}")]
        public string Incidentecliente(int ViajeId, int ClienteId, int ConductorId)
        {
            int valor1 = ViajeId;
            int valor2 = ClienteId;
            int valor3 = ConductorId;

            ChatHub.Clients.All.SendAsync("ReceiveMessage", "WebSocket solicita a Cliente motivo incidente, ViajeId, ClienteId,Conductor,Fecha Termino!");
            return ("connected, WebSocket solicita a cliente motivos de incidente, ViajeId, ClienteId,Conductor,Fecha Termino!", "ID Viaje: " + valor1.ToString(), "ID Cliente: " + valor2.ToString(), "ID Conductor: " + valor3.ToString()).ToString();
        }

        //Conductor informa motivo incidente.
        [HttpGet("Motivoconductor/{ViajeId}/{ClienteId}/{ConductorId}/{motivo}")]
        public string Motivoconductor(int ViajeId, int ClienteId, int ConductorId, string motivo)
        {
            int valor1 = ViajeId;
            int valor2 = ClienteId;
            int valor3 = ConductorId;
            string valor4 = motivo;

            ChatHub.Clients.All.SendAsync("ReceiveMessage", "Conductor informa a WebSocket motivo incidente");
            return ("connected, Conductor informa motivo incidente, ViajeId, ClienteId,Conductor,Fecha Termino!", "ID Viaje: " + valor1.ToString(), "ID Cliente: " + valor2.ToString(), "ID Conductor: " + valor3.ToString(), "Motivo: " + valor4.ToString()).ToString();
        }

        //Cliente informa motivo incidente.
        [HttpGet("Motivocliente/{ViajeId}/{ClienteId}/{ConductorId}/{motivo}")]
        public string Motivocliente(int ViajeId, int ClienteId, int ConductorId, string motivo)
        {
            int valor1 = ViajeId;
            int valor2 = ClienteId;
            int valor3 = ConductorId;
            string valor4 = motivo;

            ChatHub.Clients.All.SendAsync("ReceiveMessage", "Cliente informa a WebSocket motivo incidente");
            return ("connected, Cliente informa motivo incidente, ViajeId, ClienteId,Conductor,Fecha Termino!", "ID Viaje: " + valor1.ToString(), "ID Cliente: " + valor2.ToString(), "ID Conductor: " + valor3.ToString(), "Motivo: " + valor4.ToString()).ToString();
        }

        //WebSocket actualiza "historial_viajes_conductores".
        [HttpGet("Actualiza1/{ViajeId}/{ClienteId}/{ConductorId}/{motivo}")]
        public string Actualiza1(int ViajeId, int ClienteId, int ConductorId, string motivo)
        {

            //Aquí actualizo tabla historial_viajes_conductores,  haciendo un update del motivo.

            int valor1 = ViajeId;
            int valor2 = ClienteId;
            int valor3 = ConductorId;
            string valor4 = motivo;

            ChatHub.Clients.All.SendAsync("ReceiveMessage", "WebSocket actualiza motivo incidente");
            return ("connected, WebSocket actualiza motivo incidente según conductor, ViajeId, ClienteId,Conductor,Fecha Termino!", "ID Viaje: " + valor1.ToString(), "ID Cliente: " + valor2.ToString(), "ID Conductor: " + valor3.ToString(), "Motivo: " + valor4.ToString()).ToString();
        }

        //WebSocket actualiza "historial_viajes_usuarios".
        [HttpGet("Actualiza2/{ViajeId}/{ClienteId}/{ConductorId}/{motivo}")]
        public string Actualiza2(int ViajeId, int ClienteId, int ConductorId, string motivo)
        {

            //Aquí actualizo tabla historial_viajes_usuarios,  haciendo un update del motivo.

            int valor1 = ViajeId;
            int valor2 = ClienteId;
            int valor3 = ConductorId;
            string valor4 = motivo;

            ChatHub.Clients.All.SendAsync("ReceiveMessage", "WebSocket actualiza motivo incidente");
            return ("connected, WebSocket actualiza motivo incidente según cliente, ViajeId, ClienteId,Conductor,Fecha Termino!", "ID Viaje: " + valor1.ToString(), "ID Cliente: " + valor2.ToString(), "ID Conductor: " + valor3.ToString(), "Motivo: " + valor4.ToString()).ToString();
        }
    }
}