using caresoft_core.Models;

namespace caresoft_core.Services.Interfaces;

public interface IUsuarioService
{
    public Task<List<UsuarioDto>> GetUsuariosListAsync(string? usuarioCodigo, string? documento, string? genero, DateTime? fechaNacimiento, string? rol);
    public Task<int> AddUsuarioPacienteAsync(UsuarioDto usuario);
    public Task<int> AddUsuarioPersonalAsync(UsuarioDto usuario);
    public Task<int> AddUsuarioMedicoAsync(UsuarioDto usuario);
    public Task<int> UpdateUsuarioAsync(UsuarioDto usuario);
    public Task<int> DeleteUsuarioAsync(string codigoOdocumento);
}