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
        private Boolean         alive = true;
        //private CoincheServer   server;

        public GameManager(/*CoincheServer _server*/)
        {
            //server = _server;
        }

        public void run()
        {
            Console.WriteLine("GameManager is running.");
        }
    }
}
