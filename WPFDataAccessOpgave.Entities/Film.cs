using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDataAccessOpgave.Entities
{
    public class Film
    {
        private int id;
        private string titel;
        private string land;
        private int year;
        private string genre;
        private int oscars;

        public Film()
        {
        }

        public Film(int id, string titel, string land, int year, string genre, int oscars)
        {
            Id = id;
            Titel = titel;
            Land = land;
            Year = year;
            Genre = genre;
            Oscars = oscars;
        }

        public int Id { get; set; }
        public string Titel { get; set; }
        public string Land { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public int Oscars { get; set; }
    }
}
