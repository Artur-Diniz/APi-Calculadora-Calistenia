using System.Text.Json.Serialization;
using Calistenia.Models.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calistenia.Models
{

    public class Exercicio
    {   
        [Key]
        public int Id { get; set; }
        public string  Nome { get; set; }=string.Empty;
        public string Descricao { get; set; }=string.Empty;
        public Dificuldade dificuldade { get; set; }
        public string Tipo { get; set; }=string.Empty;

        public string  Modo { get; set; }=string.Empty;

        public Musculo GpMuscular_1 { get; set; }
        public Musculo GpMuscular_2 { get; set; }
        public Musculo GpMuscular_3 { get; set; }
        public Musculo GpMuscular_4 { get; set; }

        [JsonIgnore]
        [NotMapped]
        public List<RepSerie>? RepSeries { get; set; }



        public string?  Exercicio_Facilitado { get; set; }=string.Empty;

        public static implicit operator Exercicio?(RepSerie? v)
        {
            throw new NotImplementedException();
        }
    }

}