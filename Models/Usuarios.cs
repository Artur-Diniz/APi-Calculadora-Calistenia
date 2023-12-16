using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using Calistenia.Models.Enum;
using Calistenia.Models;
using System.ComponentModel.DataAnnotations;

namespace Calistenia
{
        [Table("TB_USUARIO")]
     public class Usuario
    {
        [Key]
        [Column("Id")]
        public int? Id { get; set; }

        [Column("U_Name")]
        public string Username { get; set; }=string.Empty;

        [Column("PassWord_H")]

        public byte[]? PasswordHash { get; set; }


        [Column("PassWord_S")]

        public byte[]? PasswordSalt { get; set; }

        public byte[]? Foto { get; set; }


        [Column("Latitude")]

        public double? Latitude { get; set; }


        [Column("Longitude")]
        public double? Longitude { get; set; }

        [Column("Dt_Acesso")]
        public DateTime? DataAcesso { get; set; }

        [NotMapped]
        public string PasswordString { get; set; }=string.Empty;

        [NotMapped]
        public List<Treino>? Treinos { get; set; }


        [Column("Perfil")]
        public string Perfil { get; set; }=string.Empty;

        [Column("Email")]
        public string Email { get; set; }=string.Empty;
    }
}
