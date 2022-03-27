using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamAPI.Models
{
    public class Campos
    {
        [Key]

        [Column("id_campo")]
        public int IdCampo { get; set; }
        [Column("id_encuesta")]
        public int IdEncuesta { get; set; }
        [ForeignKey("IdEncuesta")]
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Encuestas Encuestas { get; set; }
        public string Nombre { get; set; }
        public string Titulo { get; set; }//1: requerido, 2: no requerido
        public int Requerido { get; set; }//1: texto, 2: numero, 3: fecha
        public int tipo { get; set; }
    }
}
