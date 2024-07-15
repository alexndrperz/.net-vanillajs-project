using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Datos.Entities;

public partial class Contacto
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string? Direccion { get; set; }
}
