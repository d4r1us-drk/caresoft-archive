﻿using System;
using System.Collections.Generic;

namespace caresoft_integration.Models;

public partial class MetodoPago
{
    public uint IdMetodoPago { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Factura> FacturaCodigos { get; set; } = new List<Factura>();
}
