using System;
using System.Collections.Generic;

namespace HackathonTest.Entities;

public partial class Input
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<FormInput> FormInputs { get; set; } = new List<FormInput>();
}
