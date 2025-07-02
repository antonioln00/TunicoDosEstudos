using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TunicoDosEstudos.Interface;
using TunicoDosEstudos.Interface.Repositories;
using TunicoDosEstudos.Models;
using TunicoDosEstudos.Services;

namespace TunicoDosEstudos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController(IRepositoryUsuario repositoryUsuario) : ControllerBase
    {
        private readonly IRepositoryUsuario _repositoryUsuario = repositoryUsuario;

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> ObterUsuarioPorId(Guid id)
        {
            try
            {
                var usuario = await _repositoryUsuario.GetByIdAsync(id);
                if (usuario == null)
                    return NotFound();

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro intero: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CriarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                usuario.Senha = SenhaHash.Hash(usuario.Senha);
                await _repositoryUsuario.AddAsync(usuario);
                bool saveChanges = await _repositoryUsuario.SaveChangesAsync();

                if (!saveChanges)
                    return BadRequest("Erro ao salvar no banco de dados.");

                return CreatedAtAction(nameof(ObterUsuarioPorId), new { id = usuario.Id }, usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro intero: {ex.Message}");
            }
        }
    }
}