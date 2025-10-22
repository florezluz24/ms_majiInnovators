using Microsoft.EntityFrameworkCore;
using ms_majiInnovator.Modelos;
using ms_majiInnovator.Persistencia;

namespace ms_majiInnovator.Repositorios
{
    public class RepositorioImagenCelular
    {
        private readonly ModeladoTablas _contexto;

        public RepositorioImagenCelular(ModeladoTablas contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<ImagenCelular>> ObtenerTodosAsync()
        {
            List<ImagenCelular> imagenes = await _contexto.ImagenesCelular.ToListAsync();
            return imagenes;
        }

        public async Task<ImagenCelular> AgregarAsync(ImagenCelular imagen)
        {
            await _contexto.ImagenesCelular.AddAsync(imagen);
            await _contexto.SaveChangesAsync();
            return imagen;
        }

        public async Task<List<ImagenCelular>> ObtenerConFiltroAsync(Func<ImagenCelular, bool> filtro)
        {
            List<ImagenCelular> imagenes = await _contexto.ImagenesCelular.ToListAsync();
            List<ImagenCelular> imagenesFiltradas = imagenes.Where(filtro).ToList();
            return imagenesFiltradas;
        }

        public async Task<bool> EliminarAsync(ImagenCelular imagen)
        {
            _contexto.ImagenesCelular.Remove(imagen);
            int registrosAfectados = await _contexto.SaveChangesAsync();
            bool eliminado = registrosAfectados > 0;
            return eliminado;
        }

        public async Task<ImagenCelular> ModificarAsync(ImagenCelular imagen)
        {
            _contexto.ImagenesCelular.Update(imagen);
            await _contexto.SaveChangesAsync();
            return imagen;
        }

        public async Task<List<ImagenCelular>> ObtenerConModeloAsync()
        {
            List<ImagenCelular> imagenesConModelo = await _contexto.ImagenesCelular
                .Include(i => i.Modelo)
                .ToListAsync();
            return imagenesConModelo;
        }

        public async Task<List<ImagenCelular>> ObtenerPorModeloIdAsync(int modeloId)
        {
            List<ImagenCelular> imagenesPorModelo = await _contexto.ImagenesCelular
                .Where(i => i.ModeloId == modeloId)
                .Include(i => i.Modelo)
                .ToListAsync();
            return imagenesPorModelo;
        }
    }
}
