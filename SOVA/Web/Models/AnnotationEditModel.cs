﻿using System;
using System.Collections;


namespace Web.Models
{
    public class AnnotationEditModel
    {
        public string Url { get; set; }
        public string Body { get; set; }
        public int MarkingStart { get; set; }
        public int MarkingEnd { get; set; }
        public int? PostId { get; set; }
        public int? CommentId { get; set; }
        public int SearchUserId { get; set; }

        /*
        public virtual PostModel Post { get; set; }

        public virtual CommentModel Comment { get; set; }

        public virtual SearchUserModel SearchUser { get; set; }
        */
    }
}