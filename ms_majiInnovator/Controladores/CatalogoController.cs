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

        public CatalogoController(
            RepositorioMarcaCelular repositorioMarca
        )
        {
            _repositorioMarca = repositorioMarca;
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

                    modelos.Add(modeloDTO);
                }



                marcaDTO.Modelos = modelos;

                catalogoCompleto.Add(marcaDTO);
            }

            return Ok(catalogoCompleto);
        }
    }
}
