using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calistenia.Models.Enum;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Calistenia.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;




namespace Calistenia.Models
{

    public class Treino
    {
        public int Id { get; set; }

        public string Nome { get; set; }=string.Empty;

        public string Descricao { get; set; }=string.Empty;

        public string Tipo { get; set; }=string.Empty;

        public List<RepSerie>? RepSeries{get; set;}
        public int Rep_1 { get; set; }
        public int? Rep_2 { get; set; }
        public int? Rep_3 { get; set; }
        public int? Rep_4 { get; set; }
        public int? Rep_5 { get; set; }
        public int? Rep_6 { get; set; }
        public int? Rep_7 { get; set; }
        public int? Rep_8 { get; set; }
        public int? Rep_9 { get; set; }
        public int? Rep_10 { get; set; }

        [JsonIgnore]
        public Usuario?  Usuario { get; set; }
        
        
    }

}