using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            JClient[] clients = new JClient[4];
            Deck deck = new Deck();
            clients[0] = new JClient();
            clients[1] = new JClient();
            clients[2] = new JClient();
            clients[3] = new JClient();
            deck.distrib(clients);
            for (int i = 0; i < 4; ++i)
                clients[i].hand.Show();
            while (true);
            return;
        }
    }
}
