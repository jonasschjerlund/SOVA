﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class CommentModel
    {
        public string Url { get; set; }
        public int Score { get; set; }
        public string Body { get; set; }
        public DateTime CreateDate { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
    }
}