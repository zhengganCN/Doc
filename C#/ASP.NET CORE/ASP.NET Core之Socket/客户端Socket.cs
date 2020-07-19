using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace ClientSocket
{
    class ClientSocket
    {
        private readonly string _server;
        private readonly int _port;
        private readonly Socket _socket;
        public ClientSocket(string server, int port)
        {
            _server = server;
            _port = port;
        }

        ~ClientSocket()
        {
            _socket.Close();
        }

        private bool ConnectSocket()
        {
            try
            {
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _socket.Connect(_server, _port);
                Console.WriteLine(_server + ":" + _port + " " + _socket.Connected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            return _socket.Connected;
        }
        
        public bool SocketSendReceiveData()
        {
            if (!ConnectSocket())
            {
                return false;
            }
            try
            {
                _socket.Send(data, data.Length, SocketFlags.None);
                int bytes = 0;
                List<byte> dataBuffer = new List<byte>();
                byte[] buffer = new byte[1024];
                do
                {
                    bytes = _socket.Receive(buffer, buffer.Length, SocketFlags.None);
                    dataBuffer.AddRange(buffer);
                }
                while (bytes > 0);
                Console.WriteLine(dataBuffer.ToArray().ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }

        public void Close()
        {
            _socket.Close();
        }
    }
}
