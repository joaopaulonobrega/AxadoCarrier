using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AxadoCarrier.Util.Enum;

namespace AxadoCarrier.Domain.Entities.Registers
{
    [Table("TbCad_Carrier")]
    public class Carrier 
    {
        [Column("cCarrier")]
        public int Id { get; set; }

        public PersonTypeEnum Tipo { get; set; }

        public string CpfCnpj { get; set; }

        public string NomeRazao { get; set; }

        public string RgIe { get; set; }

        public string Endereco { get; set; }

        public string Numero { get; set; }

        public string Bairro { get; set; }

        public string Complemento { get; set; }

        public string CEP { get; set; }

        public string Cidade { get; set; }

        public string UF { get; set; }

        public string Contato { get; set; }

        public string Telefone { get; set; }

        public string Celular { get; set; }

        public string Email { get; set; }

        public string Site { get; set; }

        public bool Ativa { get; set; }
        
        public int cClassificacao { get; set; }
        [ForeignKey("cClassificacao")]
        public virtual Rating Classificacao { get; set; }
    }
}
