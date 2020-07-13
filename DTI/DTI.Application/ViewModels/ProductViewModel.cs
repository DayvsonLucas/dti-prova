using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTI.Application.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo Nome precisa ser fornecido")]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo Quantidade precisa ser fornecido")]
        [DisplayName("Quantidade")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "O campo Valor Unitário precisa ser fornecido")]
        [DisplayName("Valor Unitário")]
        public decimal UnitaryValue { get; set; }
    }
}
