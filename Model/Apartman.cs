using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingApp.Serializer;

namespace BookingApp.Model
{
    public class Apartman:ISerializable
    {
        public int Id {  get; set; }
        public string Ime {  get; set; }
        public string Opis {  get; set; }
        public int BrojSoba {  get; set; }
        public int MaxGosti {  get; set; }

        public Apartman() { }
        public Apartman(int id, string ime, string opis, int brojSoba, int maxGosti)
        {
            Id = id;
            Ime = ime;
            Opis = opis;
            BrojSoba = brojSoba;
            MaxGosti = maxGosti;
        }

        public string[] ToCSV()
        {
            string[] csvValues = { Id.ToString(), Ime, Opis, BrojSoba.ToString(), MaxGosti.ToString() };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]); // ID apartmana
            Ime = values[1];
            Opis = values[2];
            BrojSoba = Convert.ToInt32(values[3]);
            MaxGosti = Convert.ToInt32(values[4]);
        }
    }
}
