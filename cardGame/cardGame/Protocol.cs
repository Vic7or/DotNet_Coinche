using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace cardGame
{
    static class Protocol
    {
        public class Message
        {
            public String Directive { get; set; }
            public Object Data { get; set; }
            public Socket Sender { get; set; }
            public Message(String directive, Object data, Socket sender)
            {
                Directive = directive;
                Data = data;
                Sender = sender;
            }
        }
        private const int TIME_OUT = 5000;
        private static List<Message> Queue = new List<Message>();
        /// <summary>
        /// HASH TO DETERMINE IF MESSAGE IS A CHAT OR GAME MESSAGE
        /// </summary>
        private const String HASH_GAME = "/[<Coinche>]/";
        private const String HASH_CHAT = "/[<Chat>]/";
        /// <summary>
        /// SERVER TO CLIENT DIRECTIVES
        /// </summary>
        public const String ASK_NAME = HASH_GAME + "AskName";
        public const String PLAY_HIDDEN_CARD = HASH_GAME + "PlayHiddenCard";
        public const String PLAY_VISIBLE_CARD = HASH_GAME + "PlayVisibleCard";
        public const String ASK_TO_DENONCE = HASH_GAME + "AskToDenonce";
        public const String WAS_LYING = HASH_GAME + "WasLying";
        public const String WAS_NOT_LYING = HASH_GAME + "WasNotLying";
        public const String HAVE_WON = HASH_GAME + "HaveWon";
        /// <summary>
        /// CLIENT TO SERVER DIRECTIVES
        /// </summary>
        public const String PLAYER_NAME = HASH_GAME + "PlayerName";
        public const String HIDDEN_CARD_PLAYED = HASH_GAME + "HiddenCardPlayed";
        public const String VISIBLE_CARD_PLAYED = HASH_GAME + "VisibleCardPlayed";
        public const String DENONCE_LIAR = HASH_GAME + "DenonceLiar";
        public const String STAY_QUIET = HASH_GAME + "StayQuiet";
        public const String CHAT_MESSAGE = HASH_CHAT + "ChatMessage";
        /// <summary>
        /// STATIC METHODS
        /// </summary>
        public static void SendMessageToPlayer(Player player, String directive, Object data)
        {
            if (directive.StartsWith(HASH_GAME) || directive.StartsWith(HASH_CHAT))
            {
                SocketAsyncEventArgs e = new SocketAsyncEventArgs();
                Message message = new Message(directive, data, player.Socket);
                string json = JsonConvert.SerializeObject(message);
                byte[] bytes = Encoding.ASCII.GetBytes(json);
                try
                {
                    player.Socket.Send(bytes);
                   // player.Socket.BeginReceive(ReceiveCallback);
                }
                catch (SocketException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }



        private static void SendMessageCallback(object sender, SocketAsyncEventArgs e)
        {
            if (e.SocketError != SocketError.Success)
                Console.WriteLine("Socket Error: " + e.SocketError.ToString());
        }
    }
}
