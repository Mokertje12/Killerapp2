using System;
using System.Collections.Generic;
using System.Text;

namespace Killerapp2.Domain
{
    public class Order
    {
        public string GebruikerID { get; set; }
        public string ProductID { get; set; }
        public string Datum { get; set; }
        public string Status { get; set; }

        public Order ()
        {

        }
        public Order(string gebruikerid, string productid, string datum, string status)
        {
            GebruikerID = gebruikerid;
            ProductID = productid;
            Datum = datum;
            Status = status;
        }
    }
}
