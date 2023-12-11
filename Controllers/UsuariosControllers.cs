using Calistenia.Data;
using Microsoft.AspNetCore.Mvc;
using Calistenia.Models;
using Microsoft.EntityFrameworkCore;
using Calistenia.Utils;

namespace Calistenia.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _context;

        public UsuariosController (DataContext context)
        {
            _context = context;
        }

        public async Task<bool> UsuaroExistente(string username)
        {
            if (await _context.TB_USUARIO.AnyAsync(x => x.Username.ToLower() == username.ToLower()))
            {
                return  true;
            }
            return false;
        }

        [HttpPost("Registarar")]
        public async Task<ActionResult> RegisrarUsuario(Usuario user)
        {
            try
            {
                if ( await UsuaroExistente(user.Username))
                    throw new System.Exception("Nome de Usuario ja existe");

                Criptografia.CriarPasswordHash(user.PasswordString, out byte[] hash, out byte[] salt);
                user.PasswordString =string.Empty;
                user.PasswordHash = hash;
                user.PasswordSalt = salt;
                await _context.TB_USUARIO.AddAsync(user);
                await _context.SaveChangesAsync();
                
                return Ok(user.Id);
            }
            catch   (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost("Autenticar")]
        public async Task<IActionResult> AutenticarUsuario(Usuario credenciais)
        {
            try
            {

                Usuario? usuario = await _context.TB_USUARIO
                    .FirstOrDefaultAsync(x => x.Username.ToLower().Equals(credenciais.Username.ToLower()));

                if (usuario == null)
                    throw new System.Exception("Usuario não encontrado.");
                else if(!Criptografia.VerificarPasswordHash(credenciais.PasswordString, usuario.PasswordHash, usuario.PasswordSalt))
                {throw new System.Exception("Senha incorreta.");}
                else 
                {
                    return Ok(usuario);
                }

            }
            catch   (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}