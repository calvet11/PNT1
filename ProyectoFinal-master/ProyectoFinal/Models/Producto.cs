using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe agregar un nombre")]
        [Display(Name ="Nombre del producto: ")]
        public string NombreProducto { get; set; }
        
        [Required(ErrorMessage = "Debe agregar un precio")]
        [Display(Name = "Precio por kilo: ")]
        [Range(1, double.MaxValue, ErrorMessage = "Ingrese un precio válido")]
        public double Precio { get; set; }


    }
}
