using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Protekaji.Models
{
    public class ExtintorModels
    {
        public int Id { get; set; }     

        [DisplayName("Marca")]       
        public string Marca { get; set; } = string.Empty;

        [DisplayName("Tipo")]
        public string Tipo { get; set; } = string.Empty;

        [DisplayName("Capacidade")]
        public string Capacidade { get; set; } = string.Empty;

        [DisplayName("Número de série")]
        public int NumeroDeSerie { get; set; }

    }
}