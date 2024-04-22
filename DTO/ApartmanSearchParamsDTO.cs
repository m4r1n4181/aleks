using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.DTO
{
    public class ApartmanSearchParamsDTO
    {
        public string Ime { get; set; }
        public int MaxGosti {  get; set; }

        public int BrojSoba {  get; set; }
    }
}
