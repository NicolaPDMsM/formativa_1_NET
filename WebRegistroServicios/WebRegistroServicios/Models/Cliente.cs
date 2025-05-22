using System;
using System.Collections.Generic;

namespace WebRegistroServicios.Models;

public partial class Cliente
{
    public int IdClientes { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
}
