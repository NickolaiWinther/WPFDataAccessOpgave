using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDataAccessOpgave.Entities;

namespace WPFDataAccessOpgave.Dal
{
    public class FilmRepository : BaseRepository
    {
        /// <summary>
        /// Return a single Film object by an id
        /// </summary>
        /// <param name="id">The id of the Film you want to select</param>
        /// <returns>A Film object</returns>
        public Film GetFilmById(int id)
        {
            string sql = $"SELECT * FROM Film WHERE filmid = {id}";
            return HandleData( ExecuteQuery(sql) ).FirstOrDefault();
        }

        /// <summary>
        /// Return all Films from the database
        /// </summary>
        /// <returns>A list of films</returns>
        public List<Film> GetAllFilms()
        {
            string sql = "SELECT * FROM Film";
            return HandleData( ExecuteQuery(sql) );
        }

        /// <summary>
        /// Inserts a new Film into the database
        /// </summary>
        /// <param name="film"></param>
        /// <returns></returns>
        public int Insert(Film film)
        {
            return ExecuteNonQuery($"" +
                $"INSERT INTO Film (titel, land, year, genre, oscars)" +
                $"VALUES('{film.Titel}', '{film.Land}', '{film.Year}', '{film.Genre}', '{film.Oscars}')");
        }

        /// <summary>
        /// Helper method used to convert DataTable to a list of Equipments.
        /// Returns an empty list if the parameter is null.
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        private List<Film> HandleData(DataTable dataTable)
        {
            List<Film> filmList = new List<Film>();
            
            if (dataTable is null)
                return filmList;

            foreach (DataRow row in dataTable.Rows)
            {
                Film tempFilm = new Film()
                {
                    Id =       (int)row["filmid"],
                    Titel = (string)row["titel"],
                    Land =  (string)row["land"],
                    Year =     (int)row["year"],
                    Genre = (string)row["genre"],
                    Oscars =   (int)row["oscars"]
                };
                filmList.Add(tempFilm);
            }
            return filmList;
        }
    }
}
