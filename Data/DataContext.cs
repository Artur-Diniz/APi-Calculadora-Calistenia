using Calistenia.Models;
using Calistenia.Models.Enum;
using Calistenia.Utils;
using Microsoft.EntityFrameworkCore;

namespace Calistenia.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        public DbSet<Exercicio> TB_EXERCICIO { get; set; }

        public DbSet<Treino> TB_TREINOS { get; set; }
        public DbSet<RepSerie> TB_REPSERIE { get; set; }

         public DbSet<Usuario> TB_USUARIO {get; set;}

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {               

      
   
           
            base.OnModelCreating(modelBuilder);
            {
                modelBuilder
                    .Entity<Exercicio>()
                    .HasData(
                        new Exercicio()
                        {
                            Id = 1,
                            Nome = "Flexão Padrão",
                            dificuldade = Dificuldade.Facil,
                            Descricao = " ",
                            Modo = "Repetição",
                            Tipo = "PUSH",
                            GpMuscular_1 = Musculo.Peito,
                            GpMuscular_2 = Musculo.Tricips,
                            GpMuscular_3 = Musculo.Deltoide_Anterior
                        },
                        new Exercicio()
                        {
                            Id = 2,
                            Nome = "Flexão Pike",
                            dificuldade = Dificuldade.Moderado,
                            Descricao = " ",
                            Modo = "Repetição",
                            Tipo = "PUSH",
                            GpMuscular_1 = Musculo.Peito,
                            GpMuscular_2 = Musculo.Tricips,
                            GpMuscular_3 = Musculo.Deltoide_Anterior,
                            GpMuscular_4 = Musculo.Deltoide_Superior
                        },
                        new Exercicio()
                        {
                            Id = 3,
                            Nome = "Elevação de Pernas na barra",
                            dificuldade = Dificuldade.Moderado,
                            Descricao = " ",
                            Modo = "Repetição",
                            Tipo = "CORE",
                            GpMuscular_1 = Musculo.Abdomen_Superior,
                            GpMuscular_2 = Musculo.Abdomen_Inferior
                        },
                        new Exercicio()
                        {
                            Id = 4,
                            Nome = "Barra Fixa Pronada",
                            dificuldade = Dificuldade.Moderado,
                            Descricao = " ",
                            Modo = "Repetição",
                            Tipo = "PULL",
                            GpMuscular_1 = Musculo.Grande_Dorsal,
                            GpMuscular_2 = Musculo.Bicips
                        },
                        new Exercicio()
                        {
                            Id = 5,
                            Nome = "Barra Fixa Supinada",
                            dificuldade = Dificuldade.Moderado,
                            Descricao = " ",
                            Modo = "Repetição",
                            Tipo = "PULL",
                            GpMuscular_1 = Musculo.Bicips,
                            GpMuscular_2 = Musculo.Antebraco,
                            GpMuscular_3 = Musculo.Grande_Dorsal
                        },
                        new Exercicio()
                        {
                            Id = 6,
                            Nome = "Flexão Lombar",
                            dificuldade = Dificuldade.Facil,
                            Descricao = " ",
                            Modo = "Repetição",
                            Tipo = "CORE",
                            GpMuscular_1 = Musculo.Lombar
                        },
                        new Exercicio()
                        {
                            Id = 7,
                            Nome = "Prancha Lateral",
                            dificuldade = Dificuldade.Facil,
                            Descricao = " ",
                            Modo = "Repetição",
                            Tipo = "CORE",
                            GpMuscular_1 = Musculo.Abdomen_Obliquo
                        },
                        new Exercicio()
                        {
                            Id = 8,
                            Nome = "Afundos",
                            dificuldade = Dificuldade.Facil,
                            Descricao = " ",
                            Modo = "Repetição",
                            Tipo = "PERNA",
                            GpMuscular_1 = Musculo.Gluteos,
                            GpMuscular_2 = Musculo.Quadriceps
                        },
                        new Exercicio()
                        {
                            Id = 9,
                            Nome = "Elevação de Calcanhar",
                            dificuldade = Dificuldade.Facil,
                            Descricao = " ",
                            Modo = "Repetição",
                            Tipo = "PERNA",
                            GpMuscular_1 = Musculo.Panturrilha
                        }
                    );
            }
            ;

            modelBuilder
                .Entity<Exercicio>()
                .HasMany(e => e.RepSeries)
                .WithOne(e => e.Exercicios)
                .HasForeignKey(e => e.Id)
                .IsRequired();

            modelBuilder
                .Entity<Treino>()
                .HasMany(e => e.RepSeries)
                .WithOne(e => e.Treinos)
                .HasForeignKey(e => e.treinoId)
                .IsRequired()
                .HasPrincipalKey(te => te.Id);

            modelBuilder
                .Entity<Exercicio>()
                .HasMany(e => e.RepSeries)
                .WithOne(e => e.Exercicios)
                .HasForeignKey(e => e.exercicioId)
                .IsRequired();

            modelBuilder.Entity<Treino>().HasKey(tr => tr.Id);

            modelBuilder
                .Entity<RepSerie>()
                .HasData(
                    new RepSerie()
                    {
                        Id = 1,
                        Repeticao = 8,
                        Serie = 3,
                        exercicioId=9,
                        treinoId = 1
                    },
                    new RepSerie()
                    {
                        Id = 2,
                        Repeticao = 10,
                        Serie = 2,
                        exercicioId=9,
                        treinoId = 1
                    },
                    new RepSerie()
                    {
                        Id = 3,
                        Repeticao = 12,
                        Serie = 2,
                        exercicioId=9,
                        treinoId = 1
                    }
                );

            modelBuilder
                .Entity<Treino>()
                .HasData(
                    new Treino()
                    {
                        Id = 1,
                        Nome = "treino de Perna",
                        Descricao = "ta potente essa perna fibrada ai meu mano",
                        Tipo = "PERNA",
                        Rep_1=1,Rep_2=3
                       
                    }
                );

           Usuario user = new Usuario();
            Criptografia.CriarPasswordHash("123456", out byte[] hash, out byte[] salt);
                user.Id= 1;
                user.Username = "UsuarioAdmin";
                user.PasswordString = string.Empty;
                user.PasswordHash = hash;
                user.PasswordSalt = salt;
                user.Perfil = "Admin";
                user.Email = "arturdiniz06@gmail.com";
                user.Latitude = -23.5200241;
                user.Longitude = -46.596498;

                modelBuilder.Entity<Usuario>().HasData(user);


                modelBuilder.Entity<Usuario>().Property(u => u.Perfil).HasDefaultValue("Usuario");

            

        }
            
        
    }
}
