namespace ExamAPI.Models
{
    public class CamposRequest
    {
        public string Nombre { get; set; }
        public string Titulo { get; set; }//1: requerido, 2: no requerido
        public int Requerido { get; set; }//1: texto, 2: numero, 3: fecha
        public int tipo { get; set; }
    }
}
