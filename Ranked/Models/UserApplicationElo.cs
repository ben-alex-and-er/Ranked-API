using System;
using System.Collections.Generic;

namespace Ranked.Models;

public partial class UserApplicationElo
{
    public uint Id { get; set; }

    public uint UserApplicationId { get; set; }

    public uint Elo { get; set; }

    public virtual UserApplication UserApplication { get; set; } = null!;
}
