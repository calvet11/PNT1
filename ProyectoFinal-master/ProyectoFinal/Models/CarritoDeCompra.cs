using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProyectoFinal.Controllers;
using ProyectoFinal.Context;

namespace ProyectoFinal.Models
{
    public class CarritoDeCompra
    {//la anotaciones van arriba de cada atributo
        //el model es simplemente la clase con la tabla q vamos a trabajar
        [Key]//esta es la pk
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Nro de Factura")]
        public int Id { get; set; }
        
        [Display(Name = "Cliente: ")]// el display es para q se vea mas bonito el nombre
        [Required(ErrorMessage = "Seleccione un cliente")]
        public int ClienteId { get; set; }// Identificador del cliente

        [Display(Name = "Cliente: ")]
        public Cliente ?Cliente { get; set; }

        [Display(Name = "Producto: ")]
        [Required(ErrorMessage = "Seleccione un producto")]
        public int ProductoId { get; set; }

        [Display(Name = "Producto: ")]
        public Producto ?Producto { get; set; }

        [Range(1, 20)]
        [Display(Name = "Cantidad de Kg: ")]
        [Required(ErrorMessage = "Ingrese un numero del 1 al 20")]
        public int Cantidad { get; set; }

        [Display(Name = "Metodo de pago: ")]
        [Required(ErrorMessage = "Seleccione un metodo de pago")]
        public MetodoDePago MetodoDePago { get; set; }

        [Display(Name = "Total de la compra: ")]
        public double Total { get; set; }

        [Display(Name = "Fecha: ")]
        public DateTime FechaCreacion { get; set; }

        public CarritoDeCompra()
        {
           

                
                FechaCreacion = DateTime.Now;
            

        }








    }
}
