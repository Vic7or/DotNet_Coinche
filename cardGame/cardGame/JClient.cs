using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cardGame
{
    class JClient
    {
        public String   name { get; set; }
        public Hand     hand { get; set; }
        public int      score { get; set; }
        public Card     lastPlay { get; set; }
    }
}
