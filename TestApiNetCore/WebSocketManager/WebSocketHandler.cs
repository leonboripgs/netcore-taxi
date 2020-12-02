﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApiApiNetCore.WebSocketManager
{
    public abstract class WebSocketHandler
    {
        protected abstract int BufferSize { get; }

        private List<WebSocketConnection> _connections = new List<WebSocketConnection>();

        public List<WebSocketConnection> Connections { get => _connections; }

        public async Task ListenConnection(WebSocketConnection connection)
        {
            var buffer = new byte[BufferSize];
            Debug.WriteLine("Listening socket packets");
            try
            {
                while (connection.WebSocket.State == WebSocketState.Open)
                {
                    //connection.WebSocket.
                    //if (this.Connections.Exists(x => x.WebSocket == connection.WebSocket))
                    //{
                    //    Debug.WriteLine("already connected");
                    //}
                    //.FirstOrDefault(m => ((ChatConnection)m).SocketId == receiveMessage.ReceiverId)
                    var result = await connection.WebSocket.ReceiveAsync(
                        buffer: new ArraySegment<byte>(buffer),
                        cancellationToken: CancellationToken.None);

                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        var message = Encoding.UTF8.GetString(buffer, 0, result.Count);

                        await connection.ReceiveAsync(message);
                    }
                    else if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await OnDisconnected(connection);
                    }
                }
            } catch(Exception e)
            {
                Console.WriteLine("---------Exception--------");
                Console.WriteLine(e.Message);
                Console.WriteLine("-----Trace----");
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("-----End----");
            }
        }

        public virtual async Task OnDisconnected(WebSocketConnection connection)
        {
            Console.WriteLine("Socket disconnect");
            if (connection != null)
            {
                _connections.Remove(connection);

                await connection.WebSocket.CloseAsync(
                    closeStatus: WebSocketCloseStatus.NormalClosure,
                    statusDescription: "Closed by the WebSocketHandler",
                    cancellationToken: CancellationToken.None);
            }
        }

        public abstract Task<WebSocketConnection> OnConnected(HttpContext context);
    }
}
