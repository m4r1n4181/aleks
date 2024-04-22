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
    public class ApartmanRepository
    {
        private const string FilePath = "../../../Resources/Data/apartmani.csv";
        private readonly Serializer<Apartman> _serializer;
        public Dictionary<string, Apartman> Apartmani { get; set; }

        public ApartmanRepository()
        {
            _serializer = new Serializer<Apartman>();
            Apartmani = _serializer.FromCSV(FilePath).ToDictionary(apartman => apartman.Id.ToString());
        }

        public Apartman GetById(string id)
        {
            Apartmani = _serializer.FromCSV(FilePath).ToDictionary(apartman => apartman.Id.ToString());
            if (Apartmani.TryGetValue(id, out Apartman apartman))
            {
                return apartman;
            }
            return null;
        }





        public Apartman Save(Apartman apartman)
        {
            apartman.Id = NextId();
            Apartmani[apartman.Id.ToString()] = apartman;
            _serializer.ToCSV(FilePath, Apartmani.Values.ToList());
            return apartman;
        }

        public int NextId()
        {
            if (Apartmani.Count < 1)
            {
                return 1;
            }
            return Apartmani.Values.Max(a => a.Id) + 1;
        }

        public void Delete(Apartman apartman)
        {
            Apartmani.Remove(apartman.Id.ToString());
            _serializer.ToCSV(FilePath, Apartmani.Values.ToList());
        }

        public Apartman Update(Apartman apartman)
        {
            Apartmani[apartman.Id.ToString()] = apartman;
            _serializer.ToCSV(FilePath, Apartmani.Values.ToList());
            return apartman;
        }

        public List<Apartman> GetAll()
        {
            return Apartmani.Values.ToList();
        }

        public Dictionary<string, Apartman> SearchApartman(ApartmanSearchParamsDTO searchParams)
        {
            var filteredApartmani = new Dictionary<string, Apartman>(Apartmani);

            if (searchParams.BrojSoba != 0 && searchParams.MaxGosti != 0)
            {
                filteredApartmani = filteredApartmani.Where(apartman =>
                    apartman.Value.BrojSoba == searchParams.BrojSoba && apartman.Value.MaxGosti == searchParams.MaxGosti)
                    .ToDictionary(apartman => apartman.Key, apartman => apartman.Value);
            }
            else if (searchParams.BrojSoba != 0)
            {
                filteredApartmani = filteredApartmani.Where(apartman => apartman.Value.BrojSoba == searchParams.BrojSoba)
                    .ToDictionary(apartman => apartman.Key, apartman => apartman.Value);
            }
            else if (searchParams.MaxGosti != 0)
            {
                filteredApartmani = filteredApartmani.Where(apartman => apartman.Value.MaxGosti == searchParams.MaxGosti)
                    .ToDictionary(apartman => apartman.Key, apartman => apartman.Value);
            }

            return filteredApartmani;
        }

    }
}
