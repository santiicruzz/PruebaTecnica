using System;
using System.Collections.Generic;

namespace Back.Data;

public partial class Producto
{
    public int? Id { get; set; }

    public string? Titulo { get; set; }

    public double? Precio { get; set; }

    public string? Descripcion { get; set; }

    public string? Categoria { get; set; }

    public string? Imagen { get; set; }

    public decimal? Calificacion { get; set; }

    public int? TotalCalificaciones { get; set; }
}
