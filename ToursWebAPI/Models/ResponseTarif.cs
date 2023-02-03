using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToursWebAPI.Entities;
using ToursWebAPI.Controllers;
using ToursWebAPI;

namespace ToursWebAPI.Models
{
    public class ResponseTarif
    {
        public ResponseTarif(Tarif tarif) 
        {
            ID = tarif.IDTarif;
            Name = tarif.TarifName;
            Price = tarif.Price;
            Internet = tarif.Internet; 
            IDCountry = tarif.IDCountry;
        }  
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public double Internet { get; set; }
        public int? IDCountry { get; set; }
    }
}