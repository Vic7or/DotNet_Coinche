using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace cardGame
{
    class CoincheServer
    {
        private static readonly Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static readonly List<Socket> clientSockets = new List<Socket>();
        private const int BUFFER_SIZE = 2048;
        private const int PORT = 100;
        private static readonly byte[] buffer = new byte[BUFFER_SIZE];
        private static GameManager gameManager = new GameManager();
        private static Thread gmThread = new Thread(gameManager.Run);


        public bool Run()
        {
            Console.Title = "Server";
            SetupServer();
            Console.ReadLine();
            CloseAllSockets();
            return true;
        }

        public static void SetupServer()
        {
            Console.WriteLine("Setting up server...");
            serverSocket.Bind(new System.Net.IPEndPoint(IPAddress.Any, PORT));
            serverSocket.Listen(0);
            serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
            Console.WriteLine("Server setup complete");
        }

        public static void CloseAllSockets()
        {
            foreach (Player player in gameManager.players)
            {
                player.Socket.Shutdown(SocketShutdown.Both);
                player.Socket.Close();
            }

            serverSocket.Close();
        }

        public static void AcceptCallback(IAsyncResult AR)
        {
            Socket socket;

            try
            {
                socket = serverSocket.EndAccept(AR);
                if (gameManager.players.Count < 4)
                {
                    gameManager.players.Add(new Player(socket));
                    socket.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
                    serverSocket.BeginAccept(AcceptCallback, null);
                    Console.WriteLine("Client connected, waiting for request...");
                   /* if (gameManager.players.Count == 4)
                    {
                        gmThread.IsBackground = false;
                        gmThread.Start();
                    }*/
                }
                else
                {
                    Console.WriteLine("Client rejected : already 4 players connected.");
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                }
            }
            catch (ObjectDisposedException)
            {
                return;
            }
        }

        public static void ReceiveCallback(IAsyncResult AR)
        {
            Socket current = (Socket)AR.AsyncState;
            int received;

            try
            {
                received = current.EndReceive(AR);
            }
            catch (SocketException e)
            {
                Console.WriteLine("Client forcefully disconnected");
                Console.WriteLine(e.Message);
                if (current != null)
                {
                    gameManager.Leaver(current);
                    current.Close();
                }
                return;
            }

            byte[] recBuf = new byte[received];
            Array.Copy(buffer, recBuf, received);
            
            string text = Encoding.ASCII.GetString(recBuf);
            
            if (text.ToLower() == "exit")
            {
                current.Shutdown(SocketShutdown.Both);
                current.Close();
                Console.WriteLine("Client disconnected");
                return;
            }
            else
            {
                byte[] data = Encoding.ASCII.GetBytes("your text is: " + text);
                current.Send(data);
                current.Send(data);
            }
            current.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, new AsyncCallback(ReceiveCallback), current);
        }
    }
}