﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Realight_Website.Models
{
    public class Player
    {
        //Set PlayerID (int) !null auto generated by db
        public string id { get; set; }

        //Set name max char 24 !null
        [Display(Name = "Player Name")]
        [MaxLength(24, ErrorMessage = "Invalid Name!")]
        public string name { get; set; }

        //Set status max char 50 !null
        [Display(Name = "Status")]
        public string status { get; set; }

        //Set biography max char 150 !null
        [Display(Name = "Biography")]
        public string biography { get; set; }

        //Set language
        [Display(Name = "Languages")]
        public List<string> language { get; set; }

        //Set language
        [Display(Name = "Comments")]
        public List<string> comments { get; set; }

        [Display(Name = "Worlds")]
        public string worlds { get; set; }

        public string email { get; set; }
        public string password { get; set; }

    }
}
