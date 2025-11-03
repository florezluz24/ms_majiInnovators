using Microsoft.EntityFrameworkCore;
using ms_majiInnovator.Modelos;
using ms_majiInnovator.Persistencia;

namespace ms_majiInnovator.Repositorios
{
    public class RepositorioUsuario
    {
        private readonly ModeladoTablas _contexto;

        public RepositorioUsuario(ModeladoTablas contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Usuario>> ObtenerTodosAsync()
        {
            List<Usuario> usuarios = await _contexto.Usuarios.ToListAsync();
            return usuarios;
        }

        public async Task<Usuario> AgregarAsync(Usuario usuario)
        {
            await _contexto.Usuarios.AddAsync(usuario);
            await _contexto.SaveChangesAsync();
            return usuario;
        }

        public async Task<List<Usuario>> ObtenerConFiltroAsync(Func<Usuario, bool> filtro)
        {
            List<Usuario> usuarios = await _contexto.Usuarios.ToListAsync();
            List<Usuario> usuariosFiltrados = usuarios.Where(filtro).ToList();
            return usuariosFiltrados;
        }

        public async Task<bool> EliminarAsync(Usuario usuario)
        {
            _contexto.Usuarios.Remove(usuario);
            int registrosAfectados = await _contexto.SaveChangesAsync();
            bool eliminado = registrosAfectados > 0;
            return eliminado;
        }

        public async Task<Usuario> ModificarAsync(Usuario usuario)
        {
            _contexto.Usuarios.Update(usuario);
            await _contexto.SaveChangesAsync();
            return usuario;
        }
    }
}
