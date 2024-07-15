using System;
using System.Collections.Generic;

namespace Datos.Entities;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }

    public string? Descripcion { get; set; }
}
