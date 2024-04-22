using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingApp.Repository;
using BookingApp.Serializer;
//using ISerializable = BookingApp.Serializer.ISerializable;

namespace BookingApp.Model
{
    public class Hotel:ISerializable
    {
        // Polja klase
        //public int Id { get; set; }
        public string Sifra { get; set; }
        public string Ime { get; set; }
        public int GodinaIzgradnje { get; set; }
        //public Dictionary<string, Apartman> Apartmani { get; set; }
        public int BrojZvezdica { get; set; }
        public string JmbgVlasnika { get; set; }

        private readonly ApartmanRepository apartmanRepository;

        public Hotel()
        {
            apartmanRepository = new ApartmanRepository();
        }

        public Hotel(ApartmanRepository apartmanRepository)
        {
            this.apartmanRepository = apartmanRepository;
        }

        public Hotel(string sifra, string ime, int godinaIzgradnje, /*Dictionary<string, Apartman> apartmani,*/ int brojZvezdica, string jmbgVlasnika)
        {
            Sifra = sifra;
            Ime = ime;
            GodinaIzgradnje = godinaIzgradnje;
            //Apartmani = apartmani;
            BrojZvezdica = brojZvezdica;
            JmbgVlasnika = jmbgVlasnika;
        }



        // Konstruktor koji omogućuje inicijalizaciju polja prilikom kreiranja objekta
      /*  public Hotel(int id, string sifra, string ime, int godinaIzgradnje, Dictionary<string, Apartman> apartmani, int brojZvezdica, string jmbgVlasnika)
        {
            Id = id;
            Sifra = sifra;
            Ime = ime;
            GodinaIzgradnje = godinaIzgradnje;
            Apartmani = apartmani;
            BrojZvezdica = brojZvezdica;
            JmbgVlasnika = jmbgVlasnika;
        }*/



        public string[] ToCSV()
        {
           // string apartmaniString = string.Join(";", Apartmani.Keys);
            string[] csvValues = { /*Id.ToString(),*/ Sifra, Ime, GodinaIzgradnje.ToString(),/* apartmaniString,*/ BrojZvezdica.ToString(), JmbgVlasnika };
            return csvValues;
        }



        public void FromCSV(string[] values)
        {
            

            Sifra = values[0];
            Ime = values[1];
            GodinaIzgradnje = Convert.ToInt32(values[2]);
           /* Apartmani = new Dictionary<string, Apartman>();

            // Čitanje apartmana iz CSV-a
            string[] apartmaniInfo = parts[3].Split(';');
            foreach (string apartmanInfo in apartmaniInfo)
            {
                string[] apartmanParts = apartmanInfo.Split(':');
                string key = apartmanParts[0];
                string apartmanId = apartmanParts[1]; // Dobijamo ID apartmana
                                                      // Uzmi apartman iz apartmanRepository koristeći apartmanId
                Apartman apartman = apartmanRepository.GetById(apartmanId);
                Apartmani.Add(key, apartman);
            }*/

            BrojZvezdica = Convert.ToInt32(values[3]);
            JmbgVlasnika = values[4];
        }





    }
}
