using System;
using System.Collections.Generic;

namespace Ranked.Models;

public partial class User
{
    public uint Id { get; set; }

    public string Identifier { get; set; } = null!;
}
