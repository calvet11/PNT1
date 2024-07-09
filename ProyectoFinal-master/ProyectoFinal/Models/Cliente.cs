using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProyectoFinal.Models
{
    public class Cliente
    {//aca solo cambio atributos, y hago la migration
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Nombre Completo:")]
        [Required(ErrorMessage = "Ingrese un nombre valido")]
        public String NombreCompleto { get; set; }
        [Display(Name = "Dni del Cliente: ")]
        [Required(ErrorMessage = "Ingrese un dni")]
        [Range(5000000, 100000000, ErrorMessage ="Ingrese un dni válido")]
        public int Dni { get; set; }
        [Display(Name = "Mail: ")]
        [EmailAddress]
        [Required(ErrorMessage = "Ingrese un mail valido")]
        public String Mail { get; set; }
        
        [Display(Name = "Fecha de creacion: ")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;



    }
}
