using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ApiApiNetCore.WebSocketManager;
using System.Diagnostics;
using ApiInfraestructure.Data.Contexts;

namespace ApiApiNetCore.Socket
{
    public class ChatHandler : WebSocketHandler
    {
        private readonly PostgresDbContext _context;

        public ChatHandler(PostgresDbContext context)
        {
            _context = context;
        }
        protected override int BufferSize { get => 1024 * 4; }

        public override async Task<WebSocketConnection> OnConnected(HttpContext context)
        {
            var socketId = context.Request.Query["Id"];
            Console.WriteLine("ChatWebSocket Connected");
            if (!string.IsNullOrEmpty(socketId))
            {
                //var connection = Connections.FirstOrDefault(m => ((ChatConnection)m).SocketId == socketId);
                ChatConnection connection;
                //if (connection == null)
                {
                    Console.WriteLine("New Socket Connection");
                    var webSocket = await context.WebSockets.AcceptWebSocketAsync();

                    connection = new ChatConnection(this, _context)
                    {
                        SocketId = socketId,
                        WebSocket = webSocket
                    };
                    Connections.Add(connection);
                }

                return connection;
            }

            return null;
        }
    }
}
