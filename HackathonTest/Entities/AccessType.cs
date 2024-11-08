using System;
using System.Collections.Generic;

namespace HackathonTest.Entities;

public partial class AccessType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<AccessGrant> AccessGrants { get; set; } = new List<AccessGrant>();

    public virtual ICollection<FormAccess> FormAccesses { get; set; } = new List<FormAccess>();
}
