﻿// <auto-generated />
using System;
using Calistenia.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_Calistenia.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Calistenia.Models.Exercicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Exercicio_Facilitado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GpMuscular_1")
                        .HasColumnType("int");

                    b.Property<int>("GpMuscular_2")
                        .HasColumnType("int");

                    b.Property<int>("GpMuscular_3")
                        .HasColumnType("int");

                    b.Property<int>("GpMuscular_4")
                        .HasColumnType("int");

                    b.Property<string>("Modo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("dificuldade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TB_EXERCICIO", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = " ",
                            Exercicio_Facilitado = "",
                            GpMuscular_1 = 1,
                            GpMuscular_2 = 2,
                            GpMuscular_3 = 4,
                            GpMuscular_4 = 0,
                            Modo = "Repetição",
                            Nome = "Flexão Padrão",
                            Tipo = "PUSH",
                            dificuldade = 2
                        });
                });

            modelBuilder.Entity("Calistenia.Models.RepSerie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Repeticao")
                        .HasColumnType("int");

                    b.Property<int>("Serie")
                        .HasColumnType("int");

                    b.Property<int>("exercicioId")
                        .HasColumnType("int");

                    b.Property<int?>("treinoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("exercicioId");

                    b.HasIndex("treinoId");

                    b.ToTable("TB_REPSERIE", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Repeticao = 8,
                            Serie = 3,
                            exercicioId = 9,
                            treinoId = 1
                        });
                });

            modelBuilder.Entity("Calistenia.Models.Treino", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rep_1")
                        .HasColumnType("int");

                    b.Property<int?>("Rep_10")
                        .HasColumnType("int");

                    b.Property<int?>("Rep_2")
                        .HasColumnType("int");

                    b.Property<int?>("Rep_3")
                        .HasColumnType("int");

                    b.Property<int?>("Rep_4")
                        .HasColumnType("int");

                    b.Property<int?>("Rep_5")
                        .HasColumnType("int");

                    b.Property<int?>("Rep_6")
                        .HasColumnType("int");

                    b.Property<int?>("Rep_7")
                        .HasColumnType("int");

                    b.Property<int?>("Rep_8")
                        .HasColumnType("int");

                    b.Property<int?>("Rep_9")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("TB_TREINOS", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "ta potente essa perna fibrada ai meu mano",
                            Nome = "treino de Perna",
                            Rep_1 = 1,
                            Rep_2 = 3,
                            Tipo = "PERNA"
                        });
                });

            modelBuilder.Entity("Calistenia.Usuario", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<DateTime?>("DataAcesso")
                        .HasColumnType("datetime2")
                        .HasColumnName("Dt_Acesso");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<byte[]>("Foto")
                        .HasColumnType("varbinary(max)");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float")
                        .HasColumnName("Latitude");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float")
                        .HasColumnName("Longitude");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("PassWord_H");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("PassWord_S");

                    b.Property<string>("Perfil")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Usuario")
                        .HasColumnName("Perfil");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("U_Name");

                    b.HasKey("Id");

                    b.ToTable("TB_USUARIO", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "arturdiniz06@gmail.com",
                            Latitude = -23.520024100000001,
                            Longitude = -46.596497999999997,
                            PasswordHash = new byte[] { 71, 194, 34, 185, 244, 185, 174, 244, 80, 23, 177, 183, 133, 30, 156, 232, 254, 56, 56, 206, 96, 190, 195, 171, 206, 201, 0, 14, 109, 51, 45, 173, 241, 18, 185, 41, 129, 81, 54, 18, 48, 130, 110, 31, 200, 255, 139, 61, 164, 13, 67, 180, 36, 184, 249, 13, 78, 119, 93, 134, 187, 148, 160, 55 },
                            PasswordSalt = new byte[] { 167, 209, 201, 129, 211, 104, 164, 181, 188, 135, 72, 102, 221, 134, 13, 28, 249, 145, 84, 144, 120, 206, 79, 176, 132, 103, 45, 81, 178, 12, 150, 145, 246, 31, 93, 143, 112, 149, 112, 16, 89, 43, 29, 152, 63, 133, 167, 242, 29, 17, 187, 140, 72, 88, 135, 213, 63, 92, 218, 159, 179, 144, 52, 131, 232, 174, 203, 50, 237, 86, 156, 177, 111, 173, 14, 35, 194, 36, 168, 99, 76, 65, 8, 64, 90, 237, 28, 32, 153, 85, 43, 229, 177, 115, 188, 169, 211, 0, 105, 31, 93, 162, 33, 210, 162, 71, 177, 177, 202, 247, 55, 27, 155, 193, 85, 138, 132, 133, 24, 60, 186, 127, 121, 19, 241, 180, 73, 230 },
                            Perfil = "Admin",
                            Username = "UsuarioAdmin"
                        });
                });

            modelBuilder.Entity("Calistenia.Models.RepSerie", b =>
                {
                    b.HasOne("Calistenia.Models.Exercicio", "Exercicios")
                        .WithMany("RepSeries")
                        .HasForeignKey("exercicioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Calistenia.Models.Treino", "Treinos")
                        .WithMany("RepSeries")
                        .HasForeignKey("treinoId");

                    b.Navigation("Exercicios");

                    b.Navigation("Treinos");
                });

            modelBuilder.Entity("Calistenia.Models.Treino", b =>
                {
                    b.HasOne("Calistenia.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Calistenia.Models.Exercicio", b =>
                {
                    b.Navigation("RepSeries");
                });

            modelBuilder.Entity("Calistenia.Models.Treino", b =>
                {
                    b.Navigation("RepSeries");
                });
#pragma warning restore 612, 618
        }
    }
}
