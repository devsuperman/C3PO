using System.ComponentModel.DataAnnotations;

namespace App.Models;

public class Tarea
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo obligatorio"), MinLength(3)]
    [Display(Name = "Descripcion")]
    public string Descripcion { get; set; } = string.Empty;


    [Required(ErrorMessage = "Campo obligatorio"), MinLength(3)]
    [Display(Name = "Hombre Clave")]
    public string HombreClave { get; set; } = string.Empty;


    [Required(ErrorMessage = "Campo obligatorio"), MinLength(3)]
    [Display(Name = "Teléfono")]
    public string Telefono { get; set; } = string.Empty;


    [Required(ErrorMessage = "Campo obligatorio"), DataType(DataType.Date)]
    public DateTimeOffset Inicio { get; set; } = DateTimeOffset.Now;


    [Required(ErrorMessage = "Campo obligatorio"), DataType(DataType.Date)]
    public DateTimeOffset Fim { get; set; } = DateTimeOffset.Now;
}
