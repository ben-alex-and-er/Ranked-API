using System;
using System.Collections.Generic;

namespace Ranked.Models;

public partial class UserApplication
{
    public uint Id { get; set; }

    public uint UserId { get; set; }

    public uint ApplicationId { get; set; }

    public virtual Application Application { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual UserApplicationElo? UserApplicationElo { get; set; }
}
