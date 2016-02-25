using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AxadoCarrier.Domain.Entities.Registers
{
    [Table("TbCad_Rating")]
    public class Rating 
    {
        [Column("cRating")]
        public int Id { get; set; }

        public string Descricao { get; set; }
    }
}
