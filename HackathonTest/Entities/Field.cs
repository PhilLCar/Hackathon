using System;
using System.Collections.Generic;

namespace HackathonTest.Entities;

public partial class Field
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<FormField> FormFields { get; set; } = new List<FormField>();

    public virtual ICollection<MemberField> MemberFields { get; set; } = new List<MemberField>();
}
