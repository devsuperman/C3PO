﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Models;

public class Tarea
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


    [InverseProperty("TareasHijas")]
    public List<Tarea> TareasPais { get; set; } = new List<Tarea>();

    [InverseProperty("TareasPais")]
    public List<Tarea> TareasHijas { get; set; } = new List<Tarea>();
    public string Color { get; internal set; }

    public void Atualizar(string titulo, string responsable, DateTimeOffset inicio, DateTimeOffset fim, string color)
    {
        this.Titulo = titulo;
        this.Responsable = responsable;
        this.Inicio = inicio;
        this.Fim = fim;
        this.Color = color;
    }

    public void AtribuirTareasDependentes(List<Tarea> listadoTareas)
    {
        this.TareasPais.Clear();
        this.TareasPais.AddRange(listadoTareas);
    }
}
