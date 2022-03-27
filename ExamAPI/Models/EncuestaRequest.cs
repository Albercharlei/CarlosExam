using System.Collections.Generic;

namespace ExamAPI.Models
{
    public class EncuestaRequest
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public List<CamposRequest> campos { get; set; }
    }
}
