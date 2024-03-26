using System.ComponentModel.DataAnnotations;

namespace App.Models;

public class Departamento
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo obligatorio"), MinLength(2)]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    public string Color { get; set; }

}
