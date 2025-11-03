using Microsoft.EntityFrameworkCore;
using ms_majiInnovator.Modelos;
using ms_majiInnovator.Persistencia;

namespace ms_majiInnovator.Repositorios
{
    public class RepositorioMarcaCelular
    {
        private readonly ModeladoTablas _contexto;

        public RepositorioMarcaCelular(ModeladoTablas contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<MarcaCelular>> ObtenerTodosAsync()
        {
            List<MarcaCelular> marcas = await _contexto.MarcasCelular.ToListAsync();
            return marcas;
        }

        public async Task<MarcaCelular> AgregarAsync(MarcaCelular marca)
        {
            await _contexto.MarcasCelular.AddAsync(marca);
            await _contexto.SaveChangesAsync();
            return marca;
        }

        public async Task<List<MarcaCelular>> ObtenerConFiltroAsync(Func<MarcaCelular, bool> filtro)
        {
            List<MarcaCelular> marcas = await _contexto.MarcasCelular.ToListAsync();
            List<MarcaCelular> marcasFiltradas = marcas.Where(filtro).ToList();
            return marcasFiltradas;
        }

        public async Task<bool> EliminarAsync(MarcaCelular marca)
        {
            _contexto.MarcasCelular.Remove(marca);
            int registrosAfectados = await _contexto.SaveChangesAsync();
            bool eliminado = registrosAfectados > 0;
            return eliminado;
        }

        public async Task<MarcaCelular> ModificarAsync(MarcaCelular marca)
        {
            _contexto.MarcasCelular.Update(marca);
            await _contexto.SaveChangesAsync();
            return marca;
        }

        public async Task<List<MarcaCelular>> ObtenerConModelosAsync()
        {
            List<MarcaCelular> marcasConModelos = await _contexto.MarcasCelular
                .Include(m => m.Modelos)
                .ThenInclude(m => m.Caracteristicas)
                .ToListAsync();
            return marcasConModelos;
        }       
    }
}

