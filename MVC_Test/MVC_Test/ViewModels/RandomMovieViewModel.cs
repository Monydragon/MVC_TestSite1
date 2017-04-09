using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Test.Models;

namespace MVC_Test.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}