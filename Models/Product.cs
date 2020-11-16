using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace DotNETMVCProject.Models
{
    public class Product
    {
        public String _id { get; set; }
        public String Id { get; set; }
        public DateTime CreationDate { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public decimal Price { get; set; }
        public String UrlImage { get; set; }
    }
}