using System.Collections.Generic;

namespace ExamFront.Models
{
    public class Encuesta
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public List<Pregunta> preguntas { get; set; }

    }
}
