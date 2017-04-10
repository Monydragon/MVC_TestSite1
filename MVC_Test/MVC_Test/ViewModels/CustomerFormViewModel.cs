using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Test.Models;

namespace MVC_Test.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }

    }
}