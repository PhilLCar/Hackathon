using System;
using System.Collections.Generic;

namespace HackathonTest.Entities;

public partial class Access
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<FormAccess> FormAccesses { get; set; } = new List<FormAccess>();
}
