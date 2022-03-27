using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamAPI.Models
{
    public class Encuestas
    {
        [Key]
        [Column("id_encuesta")]
        public int IdEncuesta { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Campos> Campos { get; set; }
    }
}
