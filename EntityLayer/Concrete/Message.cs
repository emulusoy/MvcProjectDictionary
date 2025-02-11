﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EntityLayer.Concrete
{
    public class Message
    {
        [Key] 
        public int MessageID { get; set; }

        [StringLength(50)]
        public string MessageSenderMail { get; set; }
        [StringLength(50)]
        public string MessageReceiverMail { get; set; }
        [StringLength(100)]
        public string MessageSubject { get; set; }
        [AllowHtml]
        public string MessageContent { get; set; }
        public DateTime MessageDate { get; set; }

    }
}
