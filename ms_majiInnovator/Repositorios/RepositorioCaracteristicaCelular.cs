using Microsoft.EntityFrameworkCore;
using ms_majiInnovator.Modelos;
using ms_majiInnovator.Persistencia;

namespace ms_majiInnovator.Repositorios
{
    public class RepositorioCaracteristicaCelular
    {
        private readonly ModeladoTablas _contexto;

        public RepositorioCaracteristicaCelular(ModeladoTablas contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<CaracteristicaCelular>> ObtenerTodosAsync()
        {
            List<CaracteristicaCelular> caracteristicas = await _contexto.CaracteristicasCelular.ToListAsync();
            return caracteristicas;
        }

        public async Task<CaracteristicaCelular> AgregarAsync(CaracteristicaCelular caracteristica)
        {
            await _contexto.CaracteristicasCelular.AddAsync(caracteristica);
            await _contexto.SaveChangesAsync();
            return caracteristica;
        }

        public async Task<List<CaracteristicaCelular>> ObtenerConFiltroAsync(Func<CaracteristicaCelular, bool> filtro)
        {
            List<CaracteristicaCelular> caracteristicas = await _contexto.CaracteristicasCelular.ToListAsync();
            List<CaracteristicaCelular> caracteristicasFiltradas = caracteristicas.Where(filtro).ToList();
            return caracteristicasFiltradas;
        }

        public async Task<bool> EliminarAsync(CaracteristicaCelular caracteristica)
        {
            _contexto.CaracteristicasCelular.Remove(caracteristica);
            int registrosAfectados = await _contexto.SaveChangesAsync();
            bool eliminado = registrosAfectados > 0;
            return eliminado;
        }

        public async Task<CaracteristicaCelular> ModificarAsync(CaracteristicaCelular caracteristica)
        {
            _contexto.CaracteristicasCelular.Update(caracteristica);
            await _contexto.SaveChangesAsync();
            return caracteristica;
        }

        public async Task<List<CaracteristicaCelular>> ObtenerConModeloAsync()
        {
            List<CaracteristicaCelular> caracteristicasConModelo = await _contexto.CaracteristicasCelular
                .Include(c => c.Modelo)
                .ToListAsync();
            return caracteristicasConModelo;
        }

        public async Task<CaracteristicaCelular?> ObtenerPorIdConModeloAsync(int id)
        {
            CaracteristicaCelular? caracteristicaConModelo = await _contexto.CaracteristicasCelular
                .Include(c => c.Modelo)
                .FirstOrDefaultAsync(c => c.Id == id);
            return caracteristicaConModelo;
        }

        public async Task<List<CaracteristicaCelular>> ObtenerActivasConModeloAsync()
        {
            List<CaracteristicaCelular> caracteristicasActivasConModelo = await _contexto.CaracteristicasCelular
                .Where(c => c.Activa)
                .Include(c => c.Modelo)
                .ToListAsync();
            return caracteristicasActivasConModelo;
        }

        public async Task<List<CaracteristicaCelular>> ObtenerPorModeloIdAsync(int modeloId)
        {
            List<CaracteristicaCelular> caracteristicasPorModelo = await _contexto.CaracteristicasCelular
                .Where(c => c.ModeloId == modeloId)
                .Include(c => c.Modelo)
                .OrderBy(c => c.Orden)
                .ToListAsync();
            return caracteristicasPorModelo;
        }

        public async Task<List<CaracteristicaCelular>> ObtenerPorModeloIdActivasAsync(int modeloId)
        {
            List<CaracteristicaCelular> caracteristicasPorModeloActivas = await _contexto.CaracteristicasCelular
                .Where(c => c.ModeloId == modeloId && c.Activa)
                .Include(c => c.Modelo)
                .OrderBy(c => c.Orden)
                .ToListAsync();
            return caracteristicasPorModeloActivas;
        }
    }
}

