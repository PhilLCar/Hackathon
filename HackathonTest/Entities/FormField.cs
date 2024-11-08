using System;
using System.Collections.Generic;

namespace HackathonTest.Entities;

public partial class FormField
{
    public int Id { get; set; }

    public int FieldId { get; set; }

    public int FormSectionId { get; set; }

    public string Name { get; set; } = null!;

    public bool Mandatory { get; set; }

    public virtual Field Field { get; set; } = null!;

    public virtual FormSection FormSection { get; set; } = null!;

    public virtual ICollection<TransactionField> TransactionFields { get; set; } = new List<TransactionField>();
}
