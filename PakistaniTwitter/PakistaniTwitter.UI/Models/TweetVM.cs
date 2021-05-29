using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PakistaniTwitter.Models;

namespace PakistaniTwitter.Models
{
    public class TweetVM
    {
        public List<Tweets_PakistaniTwitter> Tweets { get; set; }

        public int NoOfTweets { get; set; }

        public int Following { get; set; }

        public int Followers { get; set; }


    }
}