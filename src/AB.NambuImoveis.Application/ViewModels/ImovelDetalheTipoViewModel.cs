using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Application.ViewModels
{
    public class ImovelDetalheTipoViewModel
    {
        public ImovelDetalheTipoViewModel()
        {
            Id = Guid.NewGuid();
            ImovelDetalheBases = new List<ImovelDetalheBaseViewModel>();
        }
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Preencha o campo Descrição ")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        public virtual ICollection<ImovelDetalheBaseViewModel> ImovelDetalheBases { get; set; }
    }
}
