using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cardGame
{
    class GameManager
    {
        private List<Card>      stack = new List<Card>();
        private Deck            deck = new Deck();
        private JClient[]       clients = new JClient[4];
        private Boolean         alive = true;
        private int             turn;
        //private CoincheServer   server;

        public GameManager(/*CoincheServer _server*/)
        {
            //server = _server;
        }

        public void run()
        {
            Console.WriteLine("GameManager is running.");
            turn = 0;
            deck.distrib(clients);
            while (alive)
            {
                if (checkIfSomeoneWon())
                {
                    if (AskForReplay())
                    {
                        run();
                        return;
                    }
                    else
                        alive = false;
                }
                else
                {
                    // tour de jeu
                }
            }
        }

        private bool AskForReplay()
        {
            throw new NotImplementedException();
        }

        private bool checkIfSomeoneWon()
        {
            throw new NotImplementedException();
        }
    }
}
