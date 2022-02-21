﻿using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class FormMovieViewModel
    {
        public Movie Movie { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

    }
}