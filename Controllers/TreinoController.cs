using Calistenia.Data;
using Calistenia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Calistenia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TreinoControllers : ControllerBase
    {
        private readonly DataContext _context;

        public TreinoControllers(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try 
            {
                List<Treino> tr = await _context.TB_TREINOS.ToListAsync();

                return Ok(tr);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTreino(int id )
        {
            try
            {   
                Treino tr = await _context.TB_TREINOS.FirstOrDefaultAsync(e => e.Id == id);

                return Ok(tr);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTr(int id)
        {
            try
            {
               Treino tr = await _context.TB_TREINOS.FirstOrDefaultAsync(e => e.Id == id);
                    _context.TB_TREINOS.Remove(tr);

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
