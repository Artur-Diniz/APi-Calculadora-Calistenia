using Calistenia.Data;
using Calistenia.Models;
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
                RepSerie? rep = await _context.TB_REPSERIE
                .Include(tr => tr.Treinos)
                .FirstOrDefaultAsync(e => e.Id == id);

                Exercicio? exercicio = await _context
                    .TB_EXERCICIO
                    .FirstOrDefaultAsync(ex => ex.Id == rep.exercicioId);



                if( rep.Id == null)
                    throw  new Exception(" Valor Id não encontrado");

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
                List<RepSerie> rep = await _context.TB_REPSERIE
                .Include(ex => ex.Exercicios)
                .Include(tr => tr.Treinos)
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

                RepSerie p = await _context
                    .TB_REPSERIE
                    .Include(ex => ex.Exercicios)
                    .FirstOrDefaultAsync(p => p.Id == serie.exercicioId);

                Exercicio exercicio = await _context.TB_EXERCICIO
                    .FirstOrDefaultAsync(e => e.Id == p.exercicioId);

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
    }
}
