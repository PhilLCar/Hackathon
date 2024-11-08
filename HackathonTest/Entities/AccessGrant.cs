using System;
using System.Collections.Generic;

namespace HackathonTest.Entities;

public partial class AccessGrant
{
    public int Id { get; set; }

    public int GroupId { get; set; }

    public int AccessTypeId { get; set; }

    public int Uic { get; set; }

    public virtual AccessType AccessType { get; set; } = null!;

    public virtual AccessGroup Group { get; set; } = null!;
}
