//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PakistaniTwitter.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tweets_PakistaniTwitter
    {
        public int TweetId { get; set; }
        public string UserId { get; set; }
        public string Message { get; set; }
        public System.DateTime CreatedDate { get; set; }
    
        public virtual Users_PakistaniTwitter Users_PakistaniTwitter { get; set; }
    }
}
