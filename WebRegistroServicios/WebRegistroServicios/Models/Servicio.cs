using System;
using System.Collections.Generic;

namespace WebRegistroServicios.Models;

public partial class Servicio
{
    public int IdServicios { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public int? Valor { get; set; }

    public string? TipoServicios { get; set; }

    public string? Descripcion { get; set; }

    public int IdClientes { get; set; }

    public virtual Cliente IdClientesNavigation { get; set; } = null!;
}
