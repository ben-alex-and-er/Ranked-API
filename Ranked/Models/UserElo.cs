using System;
using System.Collections.Generic;

namespace Ranked.Models;

public partial class UserElo
{
    public uint Id { get; set; }

    public uint UserId { get; set; }

    public uint Elo { get; set; }

    public virtual User User { get; set; } = null!;
}
