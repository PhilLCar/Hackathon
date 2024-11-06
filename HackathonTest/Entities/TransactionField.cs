using System;
using System.Collections.Generic;

namespace HackathonTest.Entities;

public partial class TransactionField
{
    public int Id { get; set; }

    public int TransactionId { get; set; }

    public int FormFieldId { get; set; }

    public string? Value { get; set; }

    public virtual FormField FormField { get; set; } = null!;

    public virtual Transaction Transaction { get; set; } = null!;
}
