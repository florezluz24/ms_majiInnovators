using Microsoft.EntityFrameworkCore;
using ms_majiInnovator.Modelos;
using ms_majiInnovator.Persistencia;

namespace ms_majiInnovator.Repositorios
{
    public class RepositorioPago
    {
        private readonly ModeladoTablas _contexto;

        public RepositorioPago(ModeladoTablas contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Pago>> ObtenerTodosAsync()
        {
            List<Pago> pagos = await _contexto.Pagos
                .Include(p => p.Usuario)
                .ToListAsync();
            return pagos;
        }

        public async Task<Pago> AgregarAsync(Pago pago)
        {
            await _contexto.Pagos.AddAsync(pago);
            await _contexto.SaveChangesAsync();
            return pago;
        }

        public async Task<List<Pago>> ObtenerConFiltroAsync(Func<Pago, bool> filtro)
        {
            List<Pago> pagos = await _contexto.Pagos
                .Include(p => p.Usuario)
                .ToListAsync();
            List<Pago> pagosFiltrados = pagos.Where(filtro).ToList();
            return pagosFiltrados;
        }

        public async Task<List<Pago>> ObtenerPorUsuarioIdAsync(int usuarioId)
        {
            List<Pago> pagos = await _contexto.Pagos
                .Include(p => p.Usuario)
                .Where(p => p.UsuarioId == usuarioId)
                .OrderByDescending(p => p.FechaPago)
                .ToListAsync();
            return pagos;
        }

        public async Task<bool> EliminarAsync(Pago pago)
        {
            _contexto.Pagos.Remove(pago);
            int registrosAfectados = await _contexto.SaveChangesAsync();
            bool eliminado = registrosAfectados > 0;
            return eliminado;
        }

        public async Task<Pago> ModificarAsync(Pago pago)
        {
            _contexto.Pagos.Update(pago);
            await _contexto.SaveChangesAsync();
            return pago;
        }
    }
}

