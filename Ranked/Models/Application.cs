using System;
using System.Collections.Generic;

namespace Ranked.Models;

public partial class Application
{
    public uint Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid Guid { get; set; }

    public virtual ICollection<UserApplication> UserApplications { get; set; } = new List<UserApplication>();
}
