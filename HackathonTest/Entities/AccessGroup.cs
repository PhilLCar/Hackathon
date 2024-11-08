using System;
using System.Collections.Generic;

namespace HackathonTest.Entities;

public partial class AccessGroup
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<AccessGrant> AccessGrants { get; set; } = new List<AccessGrant>();
}
