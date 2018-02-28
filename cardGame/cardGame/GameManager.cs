using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace cardGame
{
    class GameManager
    {
        private List<Card> stack = new List<Card>();
        private Deck deck = new Deck();
        public List<Player> players = new List<Player>();
        private Boolean alive = false;
        private int turn;

        public GameManager()
        {
        }

        public void Run()
        {
            int client_index;
            Console.WriteLine("GameManager is running.");
            turn = 0;
            deck.Distrib(players);
            alive = true;
            while (alive)
            {
                if (CheckIfSomeoneWon())
                {
                    if (AskForReplay())
                    {
                        Run();
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
                                players[turn].Hand.TakeStack(stack);
                            else
                                players[client_index].Hand.TakeStack(stack);
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

        private bool CheckIfSomeoneWon()
        {
            for (int i = 0; i < 4; ++i)
            {
                if (players[i].Hand.getCards().Count == 0)
                {
                    players[i].Score += 1;
                    return true;
                }
            }
            return false;
        }

        internal void Leaver(Socket current)
        {
            alive = false;
            for (int i = 0; i < players.Count; ++i)
                if (players[i].Socket.RemoteEndPoint.Equals(current.RemoteEndPoint))
                {
                    if (players[i].Name != null)
                        Console.WriteLine(players[i].Name + "has left.");
                    else
                        Console.WriteLine("Someone has left.");
                    players.Remove(players[i]);
                }
        }
    }
}
