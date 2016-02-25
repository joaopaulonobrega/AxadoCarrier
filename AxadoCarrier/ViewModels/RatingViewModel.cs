using System.ComponentModel.DataAnnotations;

namespace AxadoCarrier.ViewModels
{
    public class RatingViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Campo obrigatório")]
        [Display(Description ="Classificação")]
        public string Descricao { get; set; }
    }
}