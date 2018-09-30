using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Application.ViewModels
{
    public class ImovelTipoViewModel
    {
        public ImovelTipoViewModel()
        {
            Id = Guid.NewGuid();
            ImovelDetalheTipos = new List<ImovelDetalheTipoViewModel>();
        }
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage ="Preencha o campo Descrição")]
        [MaxLength(50)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        public ICollection<ImovelDetalheTipoViewModel> ImovelDetalheTipos { get; set; }
    }
}
