﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }


        [Required]
        [Range(1, 20)]
        public int NumberInStock { get; set; }


        [Required]
        public byte GenreId { get; set; }

        public GenreDTO Genre { get; set; }

    }
}