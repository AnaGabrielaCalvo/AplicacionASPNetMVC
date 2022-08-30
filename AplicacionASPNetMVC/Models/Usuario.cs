using System.ComponentModel.DataAnnotations;

namespace AplicacionASPNetMVC.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }
        
        [Display(Name ="Teléfono")]
        [Required(ErrorMessage = "El teléfono es requerido")]
        public string Telefono { get; set;}
        [Required(ErrorMessage = "El celular es requerido")]
        public string Celular {get; set;}
        [Required(ErrorMessage = "El email es requerido")] 
        public string Email {get; set;}
        
    }
}
