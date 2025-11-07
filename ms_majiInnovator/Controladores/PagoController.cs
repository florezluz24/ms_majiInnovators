using Microsoft.AspNetCore.Mvc;
using ms_majiInnovator.DTOs;
using ms_majiInnovator.Modelos;
using ms_majiInnovator.Repositorios;

namespace ms_majiInnovator.Controladores
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagoController : ControllerBase
    {
        private readonly RepositorioPago _repositorioPago;
        private readonly RepositorioUsuario _repositorioUsuario;

        public PagoController(RepositorioPago repositorioPago, RepositorioUsuario repositorioUsuario)
        {
            _repositorioPago = repositorioPago;
            _repositorioUsuario = repositorioUsuario;
        }

        [HttpPost]
        public async Task<ActionResult<PagoRespuestaDTO>> Crear(PagoDTO pagoDTO)
        {
            pagoDTO.UltimosCuatroDigitosTarjeta = pagoDTO.UltimosCuatroDigitosTarjeta.Trim();

            if (pagoDTO.UsuarioId <= 0)
            {
                return BadRequest("UsuarioId es obligatorio y debe ser mayor a cero");
            }

            List<Usuario> usuarios = await _repositorioUsuario.ObtenerConFiltroAsync(u => u.Id == pagoDTO.UsuarioId);
            Usuario? usuario = usuarios.FirstOrDefault();
            if (usuario == null)
            {
                return BadRequest("Usuario no encontrado");
            }

            if (pagoDTO.Valor <= 0)
            {
                return BadRequest("El valor del pago debe ser mayor a cero");
            }

            if (string.IsNullOrWhiteSpace(pagoDTO.UltimosCuatroDigitosTarjeta))
            {
                return BadRequest("Los últimos cuatro dígitos de la tarjeta son obligatorios");
            }

            if (pagoDTO.UltimosCuatroDigitosTarjeta.Length != 4)
            {
                return BadRequest("Los últimos cuatro dígitos de la tarjeta deben ser exactamente 4 caracteres");
            }

            bool esNumero = int.TryParse(pagoDTO.UltimosCuatroDigitosTarjeta, out int resultado);
            if (!esNumero)
            {
                return BadRequest("Los últimos cuatro dígitos de la tarjeta deben ser numéricos");
            }

            if (string.IsNullOrWhiteSpace(pagoDTO.Estado))
            {
                pagoDTO.Estado = "Completado";
            }

            Pago pago = new Pago(
                pagoDTO.UsuarioId,
                pagoDTO.Valor,
                pagoDTO.UltimosCuatroDigitosTarjeta,
                pagoDTO.Estado
            );

            Pago pagoCreado = await _repositorioPago.AgregarAsync(pago);

            PagoRespuestaDTO pagoRespuesta = new PagoRespuestaDTO
            {
                Id = pagoCreado.Id,
                UsuarioId = pagoCreado.UsuarioId,
                Valor = pagoCreado.Valor,
                UltimosCuatroDigitosTarjeta = pagoCreado.UltimosCuatroDigitosTarjeta,
                FechaPago = pagoCreado.FechaPago,
                Estado = pagoCreado.Estado
            };

            return Created(string.Empty, pagoRespuesta);
        }
    }
}

