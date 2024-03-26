using System.ComponentModel.DataAnnotations;

namespace App.ViewModels;

public class FormTarea
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo obligatorio"), MinLength(3)]
    [Display(Name = "Título")]
    public string Titulo { get; set; } = string.Empty;


    [Required(ErrorMessage = "Campo obligatorio"), MinLength(3)]
    [Display(Name = "Responsable")]
    public string Responsable { get; set; } = string.Empty;


    [Required(ErrorMessage = "Campo obligatorio"), DataType(DataType.Date)]
    public DateTimeOffset Inicio { get; set; } = DateTimeOffset.Now;


    [Required(ErrorMessage = "Campo obligatorio"), DataType(DataType.Date)]
    public DateTimeOffset Fim { get; set; } = DateTimeOffset.Now;

    [Required(ErrorMessage = "Campo obligatorio")]
    public string Color { get; set; }

    [Display(Name = "Tareas Dependentes")]
    public List<int> TareasDependentes { get; set; } = new List<int>();
}
