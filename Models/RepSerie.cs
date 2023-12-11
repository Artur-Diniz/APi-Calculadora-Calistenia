using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calistenia.Models.Enum;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Calistenia.Models;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Calistenia.Models
{
    public class RepSerie
    {   
        [Key]
        public int Id { get; set; }
        public int Repeticao { get; set; }
        public int Serie { get; set; }

        public Exercicio? Exercicios { get; set; }
        public int exercicioId { get; set; }
    

        public Treino Treinos {get; set;}
        public int treinoId { get; set; }

    }
    }