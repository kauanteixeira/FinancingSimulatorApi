using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using SimuladorFinanciamentoApi.Data;
using SimuladorFinanciamentoApi.DTOs;
using SimuladorFinanciamentoApi.Models;

namespace SimuladorFinanciamentoApi.Services
{
    public class UsuarioService
    {
        private readonly AppDbContext _context;
        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UsuarioResponseDto> CriarUsuario(CriarUsuarioDto dto)
        {
            var usuario = new Usuario
            {
                Nome = dto.Nome,
                Email = dto.Email,
                SenhaHash = dto.Senha
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return new UsuarioResponseDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email
            };
        }

        public async Task<List<UsuarioResponseDto>> ListarUsuarios()
        {
            return await _context.Usuarios
                .Select(u => new UsuarioResponseDto
                {
                    Id = u.Id,
                    Nome = u.Nome,
                    Email = u.Email
                })
                .ToListAsync();
        }
    }
}
