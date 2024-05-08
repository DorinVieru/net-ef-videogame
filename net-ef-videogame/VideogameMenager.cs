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

            using SqlConnection connessioneSql = new SqlConnection(STRINGA_DI_CONNESSIONE);

            try
            {
                connessioneSql.Open();

                string query = @$"INSERT INTO {NOME_DATABASE} (name, overview, release_date, created_at, updated_at, software_house_id) 
                             VALUES (@name, @overview, @releaseDate, @creation, @update, @softwareHouseID)";

                using SqlCommand cmd = new SqlCommand(query, connessioneSql);
                cmd.Parameters.Add(new SqlParameter("@name", name));
                cmd.Parameters.Add(new SqlParameter("@overview", overview));
                cmd.Parameters.Add(new SqlParameter("@releaseDate", releaseDate));
                cmd.Parameters.Add(new SqlParameter("@creation", createdAt));
                cmd.Parameters.Add(new SqlParameter("@update", updatedAt));
                cmd.Parameters.Add(new SqlParameter("@softwareHouseID", softwareHouseId));

                cmd.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                Console.Write(error.ToString());
            }
        }

        // FUNCTION PER TROVARE UN VIDEOGAME TRAMITE L'ID
        public Games GetVideogameById(int id)
        {
            using SqlConnection connessioneSql = new SqlConnection(STRINGA_DI_CONNESSIONE);

            string query = @$"SELECT * FROM {NOME_DATABASE} 
                              WHERE id = @Id";
            SqlCommand command = new SqlCommand(query, connessioneSql);
            command.Parameters.AddWithValue("@Id", id);

            connessioneSql.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new Games
                (
                    name: reader["name"].ToString(),
                    overview: reader["overview"].ToString(),
                    releaseDate: reader["release_date"].ToString(),
                    createdAt: (DateTime)reader["created_at"],
                    updatedAt: (DateTime)reader["updated_at"],
                    softwareHouseId: Convert.ToInt32(reader["software_house_id"])
                );
            }
            else
            {
                return null;
            }
        }

        // FUNCTION PER TROVARE UN VIDEOGAME IN BASE AL SUO NOME O PARTE DI ESSO
        public List<Games> GetVideogamesByName(string searchGame)
        {
            List<Games> videogames = new List<Games>();

            using SqlConnection connessioneSql = new SqlConnection(STRINGA_DI_CONNESSIONE);

            string query = @$"SELECT * FROM {NOME_DATABASE} 
                                  WHERE name LIKE @SearchGame";
            SqlCommand command = new SqlCommand(query, connessioneSql);
            command.Parameters.AddWithValue("@SearchGame", "%" + searchGame + "%");

            connessioneSql.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                videogames.Add(new Games
                (
                    name: reader["name"].ToString(),
                    overview: reader["overview"].ToString(),
                    releaseDate: reader["release_date"].ToString(),
                    createdAt: (DateTime)reader["created_at"],
                    updatedAt: (DateTime)reader["updated_at"],
                    softwareHouseId: Convert.ToInt32(reader["software_house_id"])
                ));
            }

            return videogames;
        }

        // FUNCTION PER CANCELLARE UN VIDEOGIOCO
        public void DeleteVideogame(int id)
        {
            using SqlConnection connessioneSql = new SqlConnection(STRINGA_DI_CONNESSIONE);

            string query = @$"DELETE FROM {NOME_DATABASE} 
                                WHERE id = @Id";
            SqlCommand command = new SqlCommand(query, connessioneSql);
            command.Parameters.AddWithValue("@Id", id);

            connessioneSql.Open();
            int affectedRows = command.ExecuteNonQuery();

            if (affectedRows == 0)
            {
                throw new Exception("Il videogioco specificato non esiste.");
            }
        }

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
