﻿using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Models.Hotel
{
    public abstract class BaseHotelDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double? Rating { get; set; }
        public string Adress { get; set; }
        [Required]
        [Range(1,int.MaxValue)]
        public int CountryId { get; set; }
    }
}
