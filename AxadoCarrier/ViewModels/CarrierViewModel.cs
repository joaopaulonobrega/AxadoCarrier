using AxadoCarrier.Domain.Entities.Registers;
using AxadoCarrier.Util.Enum;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AxadoCarrier.ViewModels
{
    public class CarrierViewModel
    {
        public int Id { get; set; }

        public PersonTypeEnum Tipo { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name ="CPF/CNPJ")]
        public string CpfCnpj { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Nome/Razão")]
        public string NomeRazao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Rg/Inscrição Estadual")]
        public string RgIe { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Display(Name = "Número")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Bairro { get; set; }

        public string Complemento { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string UF { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Contato { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage ="Email inválido!")]
        public string Email { get; set; }

        public string Site { get; set; }

        public bool Ativa { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Classificação")]
        public int cClassificacao { get; set; }

        public virtual Rating Classificacao { get; set; }
    }
}