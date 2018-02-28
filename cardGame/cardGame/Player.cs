using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace cardGame
{
    class Player
    {
        public Player(Socket socket)
        {
            Socket = socket;
            Name = null;
            Hand = null;
            Score = 0;
            LastPlay = null;
        }
        public String Name { get; set; }
        public Hand Hand { get; set; }
        public int Score { get; set; }
        public Card LastPlay { get; set; }
        public Socket Socket { get; set; }
    }
}
