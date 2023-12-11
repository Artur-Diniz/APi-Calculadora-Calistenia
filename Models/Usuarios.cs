using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using Calistenia.Models.Enum;
using Calistenia.Models;

namespace Calistenia
{
     public class Usuario
    {
        public int Id { get; set; }

        public string Username { get; set; }=string.Empty;

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public byte[]? Foto { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public DateTime? DataAcesso { get; set; }

        [NotMapped]
        public string PasswordString { get; set; }=string.Empty;

        public List<Treino> Treinos { get; set; }

        public string Perfil { get; set; }=string.Empty;

        public String Email { get; set; }=string.Empty;
    }
}
