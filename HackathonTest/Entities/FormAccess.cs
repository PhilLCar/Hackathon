using System;
using System.Collections.Generic;

namespace HackathonTest.Entities;

public partial class FormAccess
{
    public int Id { get; set; }

    public int FormId { get; set; }

    public int AccessId { get; set; }

    public int AccessTypeId { get; set; }

    public virtual Access Access { get; set; } = null!;

    public virtual AccessType AccessType { get; set; } = null!;

    public virtual Form Form { get; set; } = null!;
}
