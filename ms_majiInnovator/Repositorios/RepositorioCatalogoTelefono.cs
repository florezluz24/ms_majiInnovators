using Microsoft.EntityFrameworkCore;
using ms_majiInnovator.Modelos;
using ms_majiInnovator.Persistencia;

namespace ms_majiInnovator.Repositorios
{
    public class RepositorioCatalogoTelefono
    {
        private readonly ModeladoTablas _contexto;

        public RepositorioCatalogoTelefono(ModeladoTablas contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<CatalogoTelefono>> ObtenerTodosAsync()
        {
            List<CatalogoTelefono> respuestas = await _contexto.CatalogoTelefono.ToListAsync();
            return respuestas;
        }

        public async Task<CatalogoTelefono> AgregarAsync(CatalogoTelefono respuesta)
        {
            await _contexto.CatalogoTelefono.AddAsync(respuesta);
            await _contexto.SaveChangesAsync();
            return respuesta;
        }

        public async Task<List<CatalogoTelefono>> ObtenerConFiltroAsync(Func<CatalogoTelefono, bool> filtro)
        {
            List<CatalogoTelefono> respuestas = await _contexto.CatalogoTelefono.ToListAsync();
            List<CatalogoTelefono> respuestasFiltradas = respuestas.Where(filtro).ToList();
            return respuestasFiltradas;
        }

        public async Task<bool> EliminarAsync(CatalogoTelefono respuesta)
        {
            _contexto.CatalogoTelefono.Remove(respuesta);
            int registrosAfectados = await _contexto.SaveChangesAsync();
            bool eliminado = registrosAfectados > 0;
            return eliminado;
        }

        public async Task<CatalogoTelefono> ModificarAsync(CatalogoTelefono respuesta)
        {
            _contexto.CatalogoTelefono.Update(respuesta);
            await _contexto.SaveChangesAsync();
            return respuesta;
        }
    }
}
