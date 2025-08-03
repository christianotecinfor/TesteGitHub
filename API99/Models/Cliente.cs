using System;
using System.Collections.Generic;

namespace API99.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public int? Idade { get; set; }

    public DateTime? DataNascimento { get; set; }
}
