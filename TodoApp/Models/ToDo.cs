using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Models;

public class ToDo
{
    public int Id { get; set; }
    
    [JsonProperty("libelle")]
    public string Libelle { get; set; }

    [JsonProperty("commentaire")]
    public string Commentaire { get; set; }

    [JsonProperty("statut")]
    public string Statut { get; set; }
    [JsonProperty("date_creation")]
    public DateTime DateCreation { get; set; }
    [JsonProperty("date_fin")]
    public DateTime DateFin { get; set; }
    [JsonProperty("utilisateur")]
    public int Utilisateur { get; set; }
}
