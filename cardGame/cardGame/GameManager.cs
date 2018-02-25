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
            int client_index;
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
                    if (stack.Count == 0)
                        AskCurrentPlayerToPlayVisibleCard();
                    else
                    {
                        AskCurrentPlayerToPlayHiddenCard();
                        if ((client_index = AskEachOtherPlayersToDenonce()) > -1)
                        {
                            // Check the assertion
                            if (IsCurrentPlayerLying())
                                clients[turn].hand.TakeStack(stack);
                            else
                                clients[client_index].hand.TakeStack(stack);
                        }
                    }
                    ChangeTurn();
                }
            }
        }

        private bool IsCurrentPlayerLying()
        {
            throw new NotImplementedException();
        }

        private void ChangeTurn()
        {
            if (++turn > 3)
                turn = 0;
        }

        private int AskEachOtherPlayersToDenonce() // return index of the client who denonces the current player
        {
            throw new NotImplementedException();
        }

        private void AskCurrentPlayerToPlayHiddenCard()
        {
            throw new NotImplementedException();
        }

        private void AskCurrentPlayerToPlayVisibleCard()
        {
            throw new NotImplementedException();
        }

        private bool AskForReplay()
        {
            throw new NotImplementedException();
        }

        private bool checkIfSomeoneWon()
        {
            for (int i = 0; i < 4; ++i)
            {
                if (clients[i].hand.getCards().Count == 0)
                    return true;
            }
            return false;
        }
    }
}
