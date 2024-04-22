using BookingApp.Model;
using BookingApp.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingApp.DTO;

namespace BookingApp.Repository
{
    public class HotelRepository
    {
        private const string FilePath = "../../../Resources/Data/hoteli.csv";
        private readonly Serializer<Hotel> _serializer;
        public List<Hotel> Hoteli { get; set; }

        public HotelRepository()
        {
            _serializer = new Serializer<Hotel>();
            Hoteli = _serializer.FromCSV(FilePath);
            
        }

        /* public Hotel GetById(int id)
         {
             Hoteli = _serializer.FromCSV(FilePath);
             return Hoteli.FirstOrDefault(hotel => hotel.Id == id);
         }*/

        /* public Hotel Save(Hotel hotel)
         {
             hotel.Id = NextId();
             Hoteli.Add(hotel);
             _serializer.ToCSV(FilePath, Hoteli);
             return hotel;
         }*/

        /*public int NextId()
        {
            if (Hoteli.Count < 1)
            {
                return 1;
            }
            return Hoteli.Max(a => a.Id) + 1;
        }*/

        public void Delete(Hotel hotel)
        {
            Hoteli.Remove(hotel);
            _serializer.ToCSV(FilePath, Hoteli);
        }


       /* public void BindApartments()
        {
            ApartmanRepository apartmanRepository = new ApartmanRepository();
            foreach (var hotel in Hoteli)
            {
                var firstApartmanKey = hotel.Apartmani.Keys.FirstOrDefault();
                if (firstApartmanKey != null)
                {
                    if (apartmanRepository.Apartmani.TryGetValue(firstApartmanKey, out Apartman apartman))
                    {
                        hotel.Apartmani[firstApartmanKey] = apartman;
                    }
                    else
                    {
                        hotel.Apartmani.Remove(firstApartmanKey);
                    }
                }
            }
        }*/

        public List<Hotel> GetAll()
        {
            Hoteli = _serializer.FromCSV(FilePath);
            //BindApartments();
            return Hoteli;
        }
    

    public List<Hotel> SearchHotel(HotelSearchParamsDTO searchParams)
        {
            var filteredHoteli = Hoteli.ToList();

            if (searchParams.Ime != null)
            {
                filteredHoteli = filteredHoteli.Where(hotel => hotel.Ime.Contains(searchParams.Ime, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (searchParams.BrojZvezdica != 0)
            {
                filteredHoteli = filteredHoteli.Where(hotel => hotel.BrojZvezdica == searchParams.BrojZvezdica)
                    .ToList();
            }

            if (searchParams.Sifra != null)
            {
                filteredHoteli = filteredHoteli.Where(hotel => hotel.Sifra == searchParams.Sifra)
                    .ToList();
            }

            if (searchParams.GodinaIzgradnje != 0)
            {
                filteredHoteli = filteredHoteli.Where(hotel => hotel.GodinaIzgradnje == searchParams.GodinaIzgradnje)
                    .ToList();
            }

            return filteredHoteli;
        }


    }
}
