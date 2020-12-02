using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaxiApiNetCore.Hubs
{
    public class ChatHub : Hub
    {
        //Tenemos varias opciones más, como son:
        //All: Todos reciben el mensaje
        //Caller: El emisor es el que recibirá el mensaje.
        //Others: Todos, exepto el emisor recibirán el mensaje.
        //Group: Todos los miembros del grupo recibirán el mensaje.
        //Client: Un conjunto de personas específicas recibirán el mensaje.
        //User: Un conjunto de usuarios registrados en la aplicación recibirán el mensaje.

        //Enviando un mensaje a todos los usuarios.
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
            _ = Task.Delay(1000);
            
        }

        //Enviando un mensaje al emisor del mensaje.
        public async Task SendMessage2(string user, string message)
        {
            await Clients.Caller.SendAsync("ReceiveMessage", user, message);

        }

        //Enviando un mensaje a un grupo.
        public async Task SendMessage3(string user, string message, string group)
        {
            await Clients.Group(group).SendAsync("ReceiveMessage", user, message);
        }
        //Para agregar un usuario a un grupo.
        //Se ejecuta cuando el usuario se conecta.
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        //Se ejecuta cuando el usuario se desconecta.
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var groups = new string[] { "chat Home", "chat sala2" };  //aquí se puede definir un arreglo que declare un arreglo de 1 a n.

            foreach(var group in groups)
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, group);
            }
            await base.OnDisconnectedAsync(exception);
        }
    }
}