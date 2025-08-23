namespace ms_majiInnovator.Encuestas
{
    public class Encuesta
    {
        public string Pregunta { get; set; }

        public List<string> Respuestas { get; set; }

    }

    public class ModeladoEncuesta
    {
        public List<Encuesta> Modelado { get; set; } = [];

        public ModeladoEncuesta()
        {

            Modelado.Add(new Encuesta()
            {
                Pregunta = "¿Cuál es tu edad?",
                Respuestas = [
                     "18 – 25 años",
                     "26 – 35 años",
                     "36 – 45 años",
                     "Más de 45 años"

                ]
            });

            Modelado.Add(new Encuesta()
            {
                Pregunta = "¿Cuál es tu género?",
                Respuestas = [
                    "Masculino",
                    "Femenino",
                    "Prefiero no decirlo"
                ]
            });

            Modelado.Add(new Encuesta()
            {
                Pregunta = "¿Cuál es tu nivel de ingresos mensual?",
                Respuestas = [
                     "Menos de $1.000.000",
                     "$1.000.000 – $2.000.000",
                     "$2.000.001 – $4.000.000",
                     "Más de $4.000.000"
                ]
            });
        }
    }
}
