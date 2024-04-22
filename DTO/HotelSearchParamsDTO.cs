using BookingApp.Model;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.DTO
{
    public class HotelSearchParamsDTO
    {
        public string Sifra { get; set; }
        public string Ime { get; set; }
        public int GodinaIzgradnje { get; set; }
        public int BrojZvezdica { get; set; }
        //public Dictionary<string, Apartman> Apartmani { get; set; }
    }
}
