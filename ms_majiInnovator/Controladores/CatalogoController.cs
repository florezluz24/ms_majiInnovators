using Microsoft.AspNetCore.Mvc;
using ms_majiInnovator.DTOs;
using ms_majiInnovator.Modelos;
using ms_majiInnovator.Repositorios;

namespace ms_majiInnovator.Controladores
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogoController : ControllerBase
    {
        private readonly RepositorioMarcaCelular _repositorioMarca;
        private readonly RepositorioImagenCelular _repositorioImagen;

        public CatalogoController(
            RepositorioMarcaCelular repositorioMarca,
            RepositorioImagenCelular repositorioImagen
        )
        {
            _repositorioMarca = repositorioMarca;
            _repositorioImagen = repositorioImagen;
        }

        [HttpGet("completo")]
        public async Task<ActionResult<List<CatalogoCompletoDTO>>> ObtenerCatalogoCompleto()
        {
            List<MarcaCelular> marcasConModelos = await _repositorioMarca.ObtenerConModelosAsync();

            List<CatalogoCompletoDTO> catalogoCompleto = [];

            foreach (MarcaCelular marca in marcasConModelos)
            {
                CatalogoCompletoDTO marcaDTO = new()
                {
                    Id = marca.Id,
                    Nombre = marca.Nombre,
                    Descripcion = marca.Descripcion
                };

                List<ModeloCompletoDTO> modelos = [];
                foreach (ModeloCelular modelo in marca.Modelos)
                {
                    ModeloCompletoDTO modeloDTO = new()
                    {
                        Id = modelo.Id,
                        Nombre = modelo.Nombre,
                        Descripcion = modelo.Descripcion,
                        Precio = modelo.Precio,
                        Disponible = modelo.Disponible
                    };


                    List<CaracteristicaCompletaDTO> caracteristicasDto = [];
                    foreach (CaracteristicaCelular caracteristica in modelo.Caracteristicas)
                    {

                        CaracteristicaCompletaDTO caracteristicaDto = new()
                        {
                            Id = caracteristica.Id,
                            Nombre = caracteristica.Nombre,
                            Valor = caracteristica.Valor
                        };

                        caracteristicasDto.Add(caracteristicaDto);
                    }

                    modeloDTO.Caracteristicas = caracteristicasDto;

                    List<ImagenCelular> imagenesModelo = await _repositorioImagen.ObtenerPorModeloIdAsync(modelo.Id);
                    modeloDTO.PrimeraImagen = imagenesModelo.FirstOrDefault()?.RutaImagen;

                    modelos.Add(modeloDTO);
                }



                marcaDTO.Modelos = modelos;

                catalogoCompleto.Add(marcaDTO);
            }

            return Ok(catalogoCompleto);
        }

        /// <summary>
        /// Obtiene todas las imágenes de un modelo específico
        /// </summary>
        /// <param name="modeloId">ID del modelo del cual obtener las imágenes</param>
        /// <returns>Lista de imágenes del modelo</returns>
        /// <remarks>
        /// Este endpoint devuelve todas las imágenes asociadas a un modelo específico.
        /// Las imágenes incluyen la URL completa para ser mostradas en el frontend.
        /// </remarks>
        [HttpGet("imagenes/{modeloId}")]
        public async Task<ActionResult<List<ImagenDTO>>> ObtenerImagenesPorModelo(int modeloId)
        {
            try
            {
                List<ImagenCelular> imagenes = await _repositorioImagen.ObtenerPorModeloIdAsync(modeloId);

                if (imagenes.Count == 0)
                {
                    return Ok(new List<ImagenDTO>());
                }

                List<ImagenDTO> imagenesDTO = imagenes.Select(imagen => new ImagenDTO
                {
                    Id = imagen.Id,
                    RutaImagen = imagen.RutaImagen,
                    ModeloId = imagen.ModeloId,
                    NombreModelo = imagen.Modelo?.Nombre
                }).ToList();

                return Ok(imagenesDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor al obtener las imágenes");
            }
        }

        /// <summary>
        /// Obtiene todas las imágenes de todos los modelos
        /// </summary>
        /// <returns>Lista completa de todas las imágenes</returns>
        [HttpGet("imagenes")]
        public async Task<ActionResult<List<ImagenDTO>>> ObtenerTodasLasImagenes()
        {
            try
            {
                List<ImagenCelular> imagenes = await _repositorioImagen.ObtenerConModeloAsync();

                List<ImagenDTO> imagenesDTO = imagenes.Select(imagen => new ImagenDTO
                {
                    Id = imagen.Id,
                    RutaImagen = imagen.RutaImagen,
                    ModeloId = imagen.ModeloId,
                    NombreModelo = imagen.Modelo?.Nombre
                }).ToList();

                return Ok(imagenesDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor al obtener las imágenes");
            }
        }
    }
}
