﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Realight_Website.Models
{
	public class Room
	{
        //Set RoomID (int) !null auto generated by db
        [Display(Name = "RoomID")]
        public string RoomID { get; set; }

        //Set Room Code
        [Display(Name = "Room Code")]
        [Range(0, 9999)]
        public string? code { get; set; }

        //Set Title max char 50 !null
        [Display(Name = "Room Name")]
        [MaxLength(24, ErrorMessage = "Invalid Name!")]
        [Required]
        public string name { get; set; }

        //Set ImgUrl
        [Display(Name = "ImgURL")]
        [Range(0, 9999)]
        public string? imgURL { get; set; }

        //Set ImgUrl
        [Display(Name = "Map URL")]
        [Range(0, 9999)]
        public string? mapURL { get; set; }

        //Set player Count
        [Display(Name = "Player Count")]
        [Range(0, 9999)]
        public string? playerCount { get; set; }

        [Display(Name = "Room Interest Tags")]
        public List<string> interestTag { get; set; }

        [Display(Name = "Owner Name")]
        [MaxLength(24, ErrorMessage = "Invalid Name!")]
        [Required]
        public string ownername { get; set; }

        [Display(Name = "Language")]
        [Range(0, 9999)]
        public string? language { get; set; }

        [Display(Name = "age rating")]
        [Range(0, 9999)]
        public string? age { get; set; }

        [Display(Name = "room description")]
        [Range(0, 9999)]
        public string? description { get; set; }

    }
}
