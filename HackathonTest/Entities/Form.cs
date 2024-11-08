using System;
using System.Collections.Generic;

namespace HackathonTest.Entities;

public partial class Form
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<FormAccess> FormAccesses { get; set; } = new List<FormAccess>();

    public virtual ICollection<FormSection> FormSections { get; set; } = new List<FormSection>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
