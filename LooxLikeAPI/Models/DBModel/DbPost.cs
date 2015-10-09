using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LooxLikeAPI.Models.DBModel
{
    public class DbPost
    {
        public long Id { get; set; }
        public string ItemId { get; set; }
        public string Text { get; set; }
        public long UserId { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime Timestamp { get; set; }
    }
}