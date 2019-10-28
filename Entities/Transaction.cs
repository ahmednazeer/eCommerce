using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce_App.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
    }
}