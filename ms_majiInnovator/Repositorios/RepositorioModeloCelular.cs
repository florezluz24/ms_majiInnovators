using Microsoft.EntityFrameworkCore;
using ms_majiInnovator.Modelos;
using ms_majiInnovator.Persistencia;

namespace ms_majiInnovator.Repositorios
{
    public class RepositorioModeloCelular
    {
        private readonly ModeladoTablas _contexto;

        public RepositorioModeloCelular(ModeladoTablas contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<ModeloCelular>> ObtenerTodosAsync()
        {
            List<ModeloCelular> modelos = await _contexto.ModelosCelular.ToListAsync();
            return modelos;
        }

        public async Task<ModeloCelular> AgregarAsync(ModeloCelular modelo)
        {
            await _contexto.ModelosCelular.AddAsync(modelo);
            await _contexto.SaveChangesAsync();
            return modelo;
        }

        public async Task<List<ModeloCelular>> ObtenerConFiltroAsync(Func<ModeloCelular, bool> filtro)
        {
            List<ModeloCelular> modelos = await _contexto.ModelosCelular.ToListAsync();
            List<ModeloCelular> modelosFiltrados = modelos.Where(filtro).ToList();
            return modelosFiltrados;
        }

        public async Task<bool> EliminarAsync(ModeloCelular modelo)
        {
            _contexto.ModelosCelular.Remove(modelo);
            int registrosAfectados = await _contexto.SaveChangesAsync();
            bool eliminado = registrosAfectados > 0;
            return eliminado;
        }

        public async Task<ModeloCelular> ModificarAsync(ModeloCelular modelo)
        {
            _contexto.ModelosCelular.Update(modelo);
            await _contexto.SaveChangesAsync();
            return modelo;
        }

        public async Task<List<ModeloCelular>> ObtenerConMarcaAsync()
        {
            List<ModeloCelular> modelosConMarca = await _contexto.ModelosCelular
                .Include(m => m.Marca)
                .ToListAsync();
            return modelosConMarca;
        }

        public async Task<ModeloCelular?> ObtenerPorIdConMarcaAsync(int id)
        {
            ModeloCelular? modeloConMarca = await _contexto.ModelosCelular
                .Include(m => m.Marca)
                .FirstOrDefaultAsync(m => m.Id == id);
            return modeloConMarca;
        }

        public async Task<List<ModeloCelular>> ObtenerDisponiblesConMarcaAsync()
        {
            List<ModeloCelular> modelosDisponiblesConMarca = await _contexto.ModelosCelular
                .Where(m => m.Disponible)
                .Include(m => m.Marca)
                .ToListAsync();
            return modelosDisponiblesConMarca;
        }

        public async Task<List<ModeloCelular>> ObtenerPorMarcaIdAsync(int marcaId)
        {
            List<ModeloCelular> modelosPorMarca = await _contexto.ModelosCelular
                .Where(m => m.MarcaId == marcaId)
                .Include(m => m.Marca)
                .ToListAsync();
            return modelosPorMarca;
        }
    }
}

