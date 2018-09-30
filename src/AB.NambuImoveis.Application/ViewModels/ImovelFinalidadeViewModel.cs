using AB.NambuImoveis.Application.ViewModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Application.ViewModels
{
    public class ImovelFinalidadeViewModel
    {
        public ImovelFinalidadeViewModel()
        {
            Id = Guid.NewGuid();
            ImovelTipos = new List<ImovelTipoViewModel>();
        }
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Escolha o campo Descrição")]
        [DisplayName("Descrição")]
        public Enum_ImovelFinalidade Descricao { get; set; }

        public ICollection<ImovelTipoViewModel> ImovelTipos { get; set; }
    }
}
