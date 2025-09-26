namespace ms_majiInnovator.Encuestas
{
    /// <summary>
    /// Modelo que representa una pregunta de encuesta con sus opciones de respuesta
    /// </summary>
    public class Encuesta
    {
        /// <summary>
        /// Texto de la pregunta de la encuesta
        /// </summary>
        public string Pregunta { get; set; }

        /// <summary>
        /// Lista de opciones de respuesta disponibles para la pregunta
        /// </summary>
        public List<string> Respuestas { get; set; }
    }

    /// <summary>
    /// Clase que contiene el modelo predefinido de encuestas del sistema
    /// Incluye 12 preguntas sobre satisfacción del cliente y características del producto
    /// </summary>
    /// <remarks>
    /// Esta clase proporciona un conjunto estático de preguntas de encuesta organizadas en 4 secciones:
    /// 1. Datos demográficos (edad, género, ingresos)
    /// 2. Preferencias del producto (aspectos a mejorar, características)
    /// 3. Uso del producto (tipo, tiempo, frecuencia)
    /// 4. Satisfacción del cliente (general, diseño, precio)
    /// </remarks>
    public class ModeladoEncuesta
    {
        /// <summary>
        /// Lista de encuestas predefinidas del sistema
        /// </summary>
        public List<Encuesta> Modelado { get; set; } = [];

        /// <summary>
        /// Constructor que inicializa las encuestas predefinidas
        /// </summary>
        public ModeladoEncuesta()
        {
            // === SECCIÓN 1: DATOS DEMOGRÁFICOS ===
            
            // Pregunta 1: Edad
            Modelado.Add(new Encuesta()
            {
                Pregunta = "¿Cuál es tu edad?",
                Respuestas = [
                    "Menos de 18 años",
                    "18 – 25 años",
                    "26 – 35 años",
                    "36 – 45 años",
                    "Más de 45 años"
                ]
            });

            // Pregunta 2: Género
            Modelado.Add(new Encuesta()
            {
                Pregunta = "¿Cuál es tu género?",
                Respuestas = [
                    "Femenino",
                    "Masculino",
                    "Prefiero no decirlo"
                ]
            });

            // Pregunta 3: Ingresos
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

            // === SECCIÓN 2: PREFERENCIAS DEL PRODUCTO ===
            
            // Pregunta 4: Aspectos a mejorar
            Modelado.Add(new Encuesta()
            {
                Pregunta = "¿Qué aspectos del producto te gustaría mejorar? (puedes marcar varias)",
                Respuestas = [
                    "Diseño",
                    "Funcionalidad",
                    "Durabilidad",
                    "Precio"
                ]
            });

            // Pregunta 5: Características adicionales
            Modelado.Add(new Encuesta()
            {
                Pregunta = "¿Qué características adicionales te gustaría que se incluyeran en futuros productos?",
                Respuestas = [
                    "Mayor capacidad de almacenamiento",
                    "Mejor batería",
                    "Nuevas funciones de seguridad",
                    "Mejor diseño estético"
                ]
            });

            // Pregunta 6: Características valoradas
            Modelado.Add(new Encuesta()
            {
                Pregunta = "¿Qué características del producto valoras más al momento de usarlo?",
                Respuestas = [
                    "Cámara",
                    "Memoria (almacenamiento)",
                    "Velocidad de procesamiento",
                    "Duración de la batería",
                    "Tamaño y resolución de la pantalla",
                    "Conectividad (WiFi, 5G, Bluetooth)"
                ]
            });

            // === SECCIÓN 3: USO DEL PRODUCTO ===
            
            // Pregunta 7: Tipo de producto
            Modelado.Add(new Encuesta()
            {
                Pregunta = "¿Qué producto de MAJI Innovators S.A.S usas?",
                Respuestas = [
                    "Tablet",
                    "Smartphone"
                ]
            });

            // Pregunta 8: Tiempo de uso
            Modelado.Add(new Encuesta()
            {
                Pregunta = "¿Cuánto tiempo has tenido este producto?",
                Respuestas = [
                    "Menos de 6 meses",
                    "6 meses – 1 año",
                    "1 – 2 años",
                    "Más de 2 años"
                ]
            });

            // Pregunta 9: Frecuencia de uso
            Modelado.Add(new Encuesta()
            {
                Pregunta = "¿Con qué frecuencia usas este producto?",
                Respuestas = [
                    "Varias veces al día",
                    "Una vez al día",
                    "Varias veces a la semana",
                    "Rara vez"
                ]
            });

            // === SECCIÓN 4: SATISFACCIÓN DEL CLIENTE ===
            
            // Pregunta 10: Satisfacción general
            Modelado.Add(new Encuesta()
            {
                Pregunta = "¿Cómo calificarías tu satisfacción general con el producto?",
                Respuestas = [
                    "Muy insatisfecho",
                    "Insatisfecho",
                    "Neutral",
                    "Satisfecho",
                    "Muy satisfecho"
                ]
            });

            // Pregunta 11: Satisfacción con diseño
            Modelado.Add(new Encuesta()
            {
                Pregunta = "¿Qué tan satisfecho estás con el diseño del producto?",
                Respuestas = [
                    "Muy insatisfecho",
                    "Insatisfecho",
                    "Neutral",
                    "Satisfecho",
                    "Muy satisfecho"
                ]
            });

            // Pregunta 12: Satisfacción con precio
            Modelado.Add(new Encuesta()
            {
                Pregunta = "¿Qué tan satisfecho estás con el precio del producto?",
                Respuestas = [
                    "Muy insatisfecho",
                    "Insatisfecho",
                    "Neutral",
                    "Satisfecho",
                    "Muy satisfecho"
                ]
            });
        }
    }
}
