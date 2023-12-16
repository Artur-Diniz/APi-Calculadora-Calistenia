using Calistenia.Data;
using Calistenia.Models;
using Calistenia.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Calistenia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExerciciosController : ControllerBase
    {
        private readonly DataContext _context;

        public ExerciciosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSingle(int id)
        {
            try
            {
                Exercicio e = await _context
                    .TB_EXERCICIO
                    .FirstOrDefaultAsync(eBusca => eBusca.Id == id);

                return Ok(e);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetMusculo/{gp}")]
        public async Task<IActionResult> GetGpMuscular(int gp)
        {
            try
            {
                Musculo musculo = (Musculo)gp;

                List<Exercicio> e = await _context
                    .TB_EXERCICIO
                    .Where(
                        ms =>
                            ms.GpMuscular_1 == musculo
                            || ms.GpMuscular_2 == musculo
                            || ms.GpMuscular_3 == musculo
                            || ms.GpMuscular_4 == musculo
                    )
                    .ToListAsync();

                return Ok(e);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetDificuldade/{ds}")]
        public async Task<IActionResult> GetDificuldade(int ds)
        {

            try
            {
                Dificuldade dificul = (Dificuldade)ds;

                List<Exercicio> lista = await _context.TB_EXERCICIO
                    .Where( ms => ms.dificuldade == dificul).ToListAsync();

                return Ok(ds);
            }
             catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetByNome/{nome}")]
        public async Task<IActionResult> GetByNomeAsync( string nome)
        {
            Exercicio exercicio = await _context.TB_EXERCICIO
                .FirstOrDefaultAsync(e => e.Nome.Contains(nome));


            return Ok(exercicio);
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult> Get()
        {
            try
            {
                List<Exercicio> lista = await _context.TB_EXERCICIO.ToListAsync();

                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> add(Exercicio novoEx)
        {
            try
            {
                if (novoEx.dificuldade == null)
                    return BadRequest("O Exercicio Deve conter uma Dificuldade");

                if (novoEx.Nome == null)
                    return BadRequest("O Exercico deve conter um Nome");

                if (
                    novoEx.GpMuscular_1 != novoEx.GpMuscular_2
                    && novoEx.GpMuscular_3 != novoEx.GpMuscular_4
                )
                    if (
                        novoEx.GpMuscular_1 != novoEx.GpMuscular_3
                        && novoEx.GpMuscular_2 != novoEx.GpMuscular_4
                    )
                        if (
                            novoEx.GpMuscular_1 != novoEx.GpMuscular_4
                            && novoEx.GpMuscular_2 != novoEx.GpMuscular_3
                        )
                            return Ok(novoEx);

                if (
                    novoEx.GpMuscular_2 == null
                    && novoEx.GpMuscular_3 == null
                    && novoEx.GpMuscular_4 == null
                )
                    return Ok(novoEx);

                if (novoEx.GpMuscular_1 == null)
                {
                    string mensagem = "o Grupo Muscular 1 deve ser preenchido";
                    return BadRequest(mensagem);
                }

                await _context.TB_EXERCICIO.AddAsync(novoEx);
                await _context.SaveChangesAsync();

                return Ok(novoEx.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{exAlterado}")]
        public async Task<ActionResult> Update(Exercicio exAlterado)
        {
            try
            {
                if (exAlterado.dificuldade == null)
                    return BadRequest("O Exercicio Deve conter uma Dificuldade");

                if (exAlterado.Nome == null)
                    return BadRequest("O Exercico deve conter um Nome");

                if (
                    exAlterado.GpMuscular_1 != exAlterado.GpMuscular_2
                    && exAlterado.GpMuscular_3 != exAlterado.GpMuscular_4
                )
                    if (
                        exAlterado.GpMuscular_1 != exAlterado.GpMuscular_3
                        && exAlterado.GpMuscular_2 != exAlterado.GpMuscular_4
                    )
                        if (
                            exAlterado.GpMuscular_1 != exAlterado.GpMuscular_4
                            && exAlterado.GpMuscular_2 != exAlterado.GpMuscular_3
                        )
                            return Ok(exAlterado);

                if (
                    exAlterado.GpMuscular_2 == null
                    && exAlterado.GpMuscular_3 == null
                    && exAlterado.GpMuscular_4 == null
                )
                    return Ok(exAlterado);

                if (exAlterado.GpMuscular_1 == null)
                {
                    string mensagem = "o Grupo Muscular 1 deve ser preenchido";
                    return BadRequest(mensagem);
                }

                _context.TB_EXERCICIO.Update(exAlterado);
                int linhasafetadas = await _context.SaveChangesAsync();

                return Ok(linhasafetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Exercicio eRemover = await _context
                    .TB_EXERCICIO
                    .FirstOrDefaultAsync(ex => ex.Id == id);
                _context.TB_EXERCICIO.Remove(eRemover);

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
