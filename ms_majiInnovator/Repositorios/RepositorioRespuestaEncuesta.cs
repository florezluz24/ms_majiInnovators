using Microsoft.EntityFrameworkCore;
using ms_majiInnovator.Modelos;
using ms_majiInnovator.Persistencia;

namespace ms_majiInnovator.Repositorios
{
    public class RepositorioRespuestaEncuesta
    {
        private readonly ModeladoTablas _contexto;

        public RepositorioRespuestaEncuesta(ModeladoTablas contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<RespuestaEncuesta>> ObtenerTodosAsync()
        {
            List<RespuestaEncuesta> respuestas = await _contexto.RespuestasEncuesta.ToListAsync();
            return respuestas;
        }

        public async Task<RespuestaEncuesta> AgregarAsync(RespuestaEncuesta respuesta)
        {
            await _contexto.RespuestasEncuesta.AddAsync(respuesta);
            await _contexto.SaveChangesAsync();
            return respuesta;
        }

        public async Task<List<RespuestaEncuesta>> ObtenerConFiltroAsync(Func<RespuestaEncuesta, bool> filtro)
        {
            List<RespuestaEncuesta> respuestas = await _contexto.RespuestasEncuesta.ToListAsync();
            List<RespuestaEncuesta> respuestasFiltradas = respuestas.Where(filtro).ToList();
            return respuestasFiltradas;
        }

        public async Task<bool> EliminarAsync(RespuestaEncuesta respuesta)
        {
            _contexto.RespuestasEncuesta.Remove(respuesta);
            int registrosAfectados = await _contexto.SaveChangesAsync();
            bool eliminado = registrosAfectados > 0;
            return eliminado;
        }

        public async Task<RespuestaEncuesta> ModificarAsync(RespuestaEncuesta respuesta)
        {
            _contexto.RespuestasEncuesta.Update(respuesta);
            await _contexto.SaveChangesAsync();
            return respuesta;
        }
    }
}
