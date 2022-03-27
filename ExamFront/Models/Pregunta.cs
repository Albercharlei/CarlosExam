namespace ExamFront.Models
{
    public class Pregunta
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string titulo { get; set; }
        public int requerido { get; set; }//1: requerido, 2: no requerido
        public int tipo { get; set; }//1: texto, 2: numero, 3: fecha
    }
}
