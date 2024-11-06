using System;
using System.Collections.Generic;

namespace HackathonTest.Entities;

public partial class FormSection
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int FormId { get; set; }

    public virtual Form Form { get; set; } = null!;

    public virtual ICollection<FormField> FormFields { get; set; } = new List<FormField>();

    public virtual ICollection<FormInput> FormInputs { get; set; } = new List<FormInput>();

    public virtual ICollection<TransactionOwner> TransactionOwners { get; set; } = new List<TransactionOwner>();
}
