using System;
using System.Collections.Generic;
using System.Text;

namespace Killerapp2.Domain
{
    public class Product
    {
        public string ID { get; set; }
        public string Naam { get; set; }
        public string Price { get; set; }
        public string Omschrijving { get; set; }
        public string CategoryID { get; set; }
        public string ProductAfbeeldingID { get; set; }
        public string Path { get; set; }

        public Product ()
        {

        }
    }
}
