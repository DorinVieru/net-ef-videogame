using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    [Table("games")]
    [Index(nameof(GameId), IsUnique = true)]
    public class Games
    {
        [Key] int GameId { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        [Column("release_date")]
        public string ReleaseDate { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("update_at")]
        public DateTime UpdatedAt { get; set; }
        List<SoftwareHouse>? SoftwareHouseList { get; set; } // N-N con tabella SoftwareHouse

        // Costruttore vuoto
        public Games() { }

        // COSTRUTTORE
        public Games(string name, string overview, string releaseDate, DateTime createdAt, DateTime updatedAt)
        {
            this.Name = name;
            this.Overview = overview;
            this.ReleaseDate = releaseDate;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
        }

        public override string ToString()
        {
            return $"- ID: {GameId} \n- Nome: {Name} \n- Descrizione: {Overview} \n- Data di rilascio {ReleaseDate} \n- Creato il: {CreatedAt} \n-Aggiornato il: {UpdatedAt}";
        }
    }

}
