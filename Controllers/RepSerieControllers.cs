using Calistenia.Data;
using Calistenia.Models;
using Calistenia.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Calistenia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RepSerieControllers : ControllerBase
    {
        private readonly DataContext _context;

        public RepSerieControllers(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRepSerie(int id)
        {
            try
            {
                RepSerie? rep = await _context
                    .TB_REPSERIE
                    .Include(tr => tr.Treinos)
                    .FirstOrDefaultAsync(e => e.Id == id);

                Exercicio? exercicio = await _context
                    .TB_EXERCICIO
                    .FirstOrDefaultAsync(ex => ex.Id == rep.exercicioId);

                if (rep.Id == null)
                    throw new Exception(" Valor Id não encontrado");

                return Ok(rep);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<RepSerie> rep = await _context
                    .TB_REPSERIE
                    .Include(ex => ex.Exercicios)
                    .ToListAsync();

                return Ok(rep);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(RepSerie serie)
        {
            try
            {
                if (serie.Repeticao <= 0)
                {
                    throw new Exception(" o numeros de repetições deve ser ao menos 1");
                }
                if (serie.Serie <= 0)
                {
                    throw new Exception(" o numeros de Serie deve ser ao menos 1");
                }
                if (serie.treinoId == null)
                {
                    throw new Exception(" não foi encontrado Treino com esse Id");
                }

                RepSerie? p = await _context
                    .TB_REPSERIE
                    .Include(ex => ex.Exercicios)
                    .FirstOrDefaultAsync(p => p.Id == serie.exercicioId);

                Exercicio? exercicio = await _context
                    .TB_EXERCICIO
                    .FirstOrDefaultAsync(e => e.Id == p.exercicioId);

                Treino? treino = await _context
                    .TB_TREINOS
                    .FirstOrDefaultAsync(tr => tr.Id == serie.treinoId);
                if (p.exercicioId == null)
                {
                    throw new Exception(" não existe Exercicio com esse ID");
                }

                await _context.TB_REPSERIE.AddAsync(serie);
                await _context.SaveChangesAsync();

                return Ok(serie);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepSerie(RepSerie repAlterado)
        {
            try
            {
                if (repAlterado.Repeticao <= 0)
                {
                    throw new Exception(" o numeros de repetições deve ser ao menos 1");
                }
                if (repAlterado.Serie <= 0)
                {
                    throw new Exception(" o numeros de Serie deve ser ao menos 1");
                }

                _context.TB_REPSERIE.Update(repAlterado);
                int linhasafetadas = await _context.SaveChangesAsync();

                return Ok(linhasafetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepSerie(int id)
        {
            try
            {
                RepSerie rep = await _context.TB_REPSERIE.FirstOrDefaultAsync(e => e.Id == id);
                _context.TB_REPSERIE.Remove(rep);

                int linhasafetadas = await _context.SaveChangesAsync();

                return Ok(linhasafetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("GerarExercicio/{Exid}")]
        public async Task<IActionResult> GerarRepSerie(int Exid, RepSerie treino)
        {
            try
            {
                Random rnd = new Random();
                RepSerie repSerie = new RepSerie();

                Exercicio ex =
                    await _context.TB_EXERCICIO.FirstOrDefaultAsync(e => e.Id == Exid)
                    ?? throw new Exception(" não foi encontrado Exercicio com esse Id");

                repSerie.exercicioId = Exid;
                repSerie.treinoId = treino.Id;

                if (treino.treinoId == null)
                {
                    throw new Exception(" não foi encontrado Treino com esse Id");
                }

                // AQUI DEFINE A QUANTIDADE DE REPETICAO
                if (
                    ex.dificuldade == Dificuldade.Facil
                    || ex.dificuldade == Dificuldade.Simplificada
                )
                {
                    int r = rnd.Next(8, 15);
                    repSerie.Repeticao = r;
                }
                else if (ex.dificuldade == Dificuldade.Moderado)
                {
                    int r = rnd.Next(6, 12);
                    repSerie.Repeticao = r;
                }
                else if (
                    ex.dificuldade == Dificuldade.Complexo
                    || ex.dificuldade == Dificuldade.Epicos
                )
                {
                    int r = rnd.Next(4, 10);
                    repSerie.Repeticao = r;
                }

                //AQUI É DEFINIDO A QUANTIDADE DE SERIE
                if (
                    ex.dificuldade == Dificuldade.Simplificada
                    || ex.dificuldade == Dificuldade.Facil
                    || ex.dificuldade == Dificuldade.Moderado
                )
                {
                    repSerie.Serie = rnd.Next(2, 5);
                }
                else
                {
                    repSerie.Serie = rnd.Next(1, 3);
                }

                treino.Serie = repSerie.Serie;
                treino.Repeticao = repSerie.Repeticao;
                treino.exercicioId = repSerie.exercicioId;
                treino.treinoId = treino.treinoId;

                await _context.TB_REPSERIE.AddAsync(treino);

                RepSerie? ex_tr = await _context
                    .TB_REPSERIE
                    .FirstOrDefaultAsync(
                        e =>
                            e.exercicioId == repSerie.exercicioId || e.treinoId == repSerie.treinoId
                    );

                if (ex_tr != null)
                {
                    throw new Exception(
                        "Ja existe esse exercicio nesse treino, escolha outro exercicío para adicionar nesse treino "
                    );
                }
                await _context.SaveChangesAsync();

                Treino? t = await _context
                    .TB_TREINOS
                    .FirstOrDefaultAsync(t => t.Id == treino.treinoId);

                int? a =
                    treino.Id ?? throw new Exception(" você errou essa linha de codigo seu macaco");

                if (
                    t.Rep_2 != null
                    && t.Rep_3 != null
                    && t.Rep_4 != null
                    && t.Rep_5 != null
                    && t.Rep_6 != null
                    && t.Rep_7 != null
                    && t.Rep_8 != null
                    && t.Rep_9 != null
                    && t.Rep_10 != null
                )
                    throw new Exception("  não pode mais adicionar Exercicios a esse treino ");

                if (t.Rep_2 == null)
                    t.Rep_2 = (int)a;
                else if (t.Rep_3 == null)
                    t.Rep_3 = (int)a;
                else if (t.Rep_4 == null)
                    t.Rep_4 = (int)a;
                else if (t.Rep_5 == null)
                    t.Rep_5 = (int)a;
                else if (t.Rep_6 == null)
                    t.Rep_6 = (int)a;
                else if (t.Rep_7 == null)
                    t.Rep_7 = (int)a;
                else if (t.Rep_8 == null)
                    t.Rep_8 = (int)a;
                else if (t.Rep_9 == null)
                    t.Rep_9 = (int)a;
                else
                    t.Rep_10 ??= (int)a;

                t.Tipo = t.Tipo;
                t.Nome = t.Nome;
                t.Descricao = t.Descricao;

                _context.TB_TREINOS.Update(t);

                await _context.SaveChangesAsync();

                return Ok(repSerie);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
