using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using BookingApp.Model;
using BookingApp.Repository;
using BookingApp.DTO;
using System;
using System.Diagnostics.Metrics;
using System.Windows;

namespace BookingApp.View.ViewModel
{
    public class HotelSearchViewModel : INotifyPropertyChanged
    { 

        public ObservableCollection<Hotel> Hotels { get; set; }

        private readonly HotelRepository hotelRepository;

        private string searchCriteria;
        public string SearchCriteria
        {
            get => searchCriteria;
            set
            {
                if (value != searchCriteria)
                {
                    searchCriteria = value;
                    OnPropertyChanged();
                }
            }
        }

       /* private string searchText;
        public string SearchText
        {
            get => searchText;
            set
            {
                if (value != searchText)
                {
                    searchText = value;
                    OnPropertyChanged();
                }
            }
        }*/

        private string sifra;
        public string Sifra
        {
            get => sifra;
            set
            {
                if (value != sifra)
                {
                    searchCriteria = value;
                    OnPropertyChanged();
                }
            }
        }

        private string ime;
        public string Ime
        {
            get => ime;
            set
            {
                if (value != ime)
                {
                    searchCriteria = value;
                    OnPropertyChanged();
                }
            }
        }

        private int godinaIzgradnje;
        public int GodinaIzgradnje
        {
            get => godinaIzgradnje;
            set
            {
                if (value != godinaIzgradnje)
                {
                    godinaIzgradnje = value;
                    OnPropertyChanged();
                }
            }
        }

        private int brojZvezdica;
        public int BrojZvezdica
        {
            get => brojZvezdica;
            set
            {
                if (value != brojZvezdica)
                {
                    brojZvezdica = value;
                    OnPropertyChanged();
                }
            }
        }


        public ICommand SearchCommand { get; private set; }

        public HotelSearchViewModel()
        {
            hotelRepository = new HotelRepository();
            Hotels = new ObservableCollection<Hotel>(hotelRepository.GetAll());

            SearchCommand = new RelayCommand(SearchHotels);
        }

        private void SearchHotels()
        {
            HotelSearchParamsDTO searchParams = new HotelSearchParamsDTO
            {
                Sifra = Sifra,
                Ime = Ime,
                GodinaIzgradnje = GodinaIzgradnje,
                BrojZvezdica = BrojZvezdica
            };

            Hotels.Clear();
            foreach (Hotel hotel in hotelRepository.SearchHotel(searchParams))
            {
                Hotels.Add(hotel);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
