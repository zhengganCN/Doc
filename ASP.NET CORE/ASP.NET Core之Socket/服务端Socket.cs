using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketDemo
{
    class ServerSocket
    {
        private readonly string _server = "127.0.0.1";
        private readonly int _port = 11100;
        private readonly Socket _socket = null;
        public ServerSocket(string server, int port)
        {
            _server=server;
            _port=port;
        }

        public bool Listen()
        {
            try
            {
                _socket=new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ip = IPAddress.Parse(_server);
                IPEndPoint iPEndPoint = new IPEndPoint(ip, _port);
                _socket.Bind(iPEndPoint);
                _socket.Listen(10);
                Console.WriteLine("启动监听{0}成功", _socket.LocalEndPoint.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }

        ~ServerSocket()
        {
            _socket.Close();
        }

        public bool SocketSendReceiveData(byte[] sendDataout, byte[] receiveData)
        {
            receiveData = null;
            try
            {
                while (true)
                {
                    Socket clientSocket = _socket.Accept();
                    int bytes = 0;
                    int num = 0;
                    List<byte> dataBuffer = new List<byte>();
                    byte[] buffer = new byte[1024];
                    do
                    {
                        try
                        {
                            bytes = clientSocket.Receive(buffer, buffer.Length, SocketFlags.None);
                            dataBuffer.AddRange(buffer);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                            break;
                        }
                    }
                    while (bytes == dataBuffer.Count);
                    clientSocket.Send(sendData, sendData.Length, SocketFlags.None);
                    receiveData = dataBuffer.ToArray();
                    Console.WriteLine(Encoding.UTF8.GetString(receiveData));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public void Close()
        {
            _socket.Close();
        }
    }
}
