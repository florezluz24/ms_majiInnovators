namespace ms_majiInnovator.Modelos
{
    public class ImagenCelular
    {
        public int Id { get; set; }
        public string RutaImagen { get; set; } = string.Empty;
        public int ModeloId { get; set; }
        public virtual ModeloCelular Modelo { get; set; } = null!;

        public ImagenCelular(string rutaImagen, int modeloId)
        {
            RutaImagen = rutaImagen;
            ModeloId = modeloId;
        }

        public ImagenCelular()
        {
        }
    }
}
