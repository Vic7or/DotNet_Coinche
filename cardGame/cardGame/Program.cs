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
            CoincheServer server = new CoincheServer();

            server.Run();
           /* Player[] clients = new Player[4];
            Deck deck = new Deck();
            clients[0] = new Player();
            clients[1] = new Player();
            clients[2] = new Player();
            clients[3] = new Player();
            deck.Distrib(clients);
            for (int i = 0; i < 4; ++i)
                clients[i].Hand.Show();
            while (true);
            return;*/

        }
    }
}
