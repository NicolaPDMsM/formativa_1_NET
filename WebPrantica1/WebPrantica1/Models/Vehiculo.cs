using System;
using System.Collections.Generic;

namespace WebPrantica1.Models;

public partial class Vehiculo
{
    public int IdVehiculo { get; set; }

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public DateOnly? AñoFabricacion { get; set; }

    public string? Color { get; set; }

    public int? Precio { get; set; }

    public string? Patente { get; set; }
}
