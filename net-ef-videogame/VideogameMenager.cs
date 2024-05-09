using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    public class VideogameMenager
    {
        public const string STRINGA_DI_CONNESSIONE = "Data Source=localhost;Initial Catalog=db_games;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True";
        public const string NOME_DATABASE = "games";

        // FUNCTION PER INSERIRE UN NUOVO VIDEOGAME
        public static void InsertVideogame(string name, string overview, string releaseDate, DateTime createdAt, DateTime updatedAt, long softwareHouseId)
        {

            using GamesContext context = new GamesContext();

            context.Add(new Games(name, overview, releaseDate, createdAt, updatedAt, softwareHouseId));
            context.SaveChanges();

        }

        // FUNCTION PER TROVARE UN VIDEOGAME TRAMITE L'ID
        public Games GetVideogameById(long id)
        {
            try
            {
                using GamesContext context = new GamesContext();

                return context.Games.Where(x => x.GameId == id).Include(x => x.SoftwareHouse).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        // FUNCTION PER TROVARE UN VIDEOGAME IN BASE AL SUO NOME O PARTE DI ESSO
        public List<Games> GetVideogamesByName(string name)
        {
            try
            {
                using GamesContext context = new GamesContext();

                return context.Games.Where(x => x.Name.Contains(name)).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        // FUNCTION PER CANCELLARE UN VIDEOGIOCO
        public void DeleteVideogame(long id)
        {
            var game = GetVideogameById(id);
            
            if (game != null)
                return;
                
            using GamesContext context = new GamesContext();

            context.Remove(game);
            context.SaveChanges();
 
        }

        //FUNCTION PER AGGIUNGERE UNA SOFTWARE HOUSE
        public void InsertSoftwareHouse(string name, string taxId, string city, string country, DateTime createdAt, DateTime updatedAt)
        {
            using GamesContext context = new GamesContext();

            SoftwareHouse softwareHouse = new SoftwareHouse
            {
                Name = name,
                TaxId = taxId,
                City = city,
                Country = country,
                CreatedAt = createdAt,
                UpdatedAt = updatedAt
            };

            context.SoftwareHouses.Add(softwareHouse);
            context.SaveChanges();
        }

    }
}
