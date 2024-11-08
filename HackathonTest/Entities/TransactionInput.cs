using System;
using System.Collections.Generic;

namespace HackathonTest.Entities;

public partial class TransactionInput
{
    public int Id { get; set; }

    public int TransactionId { get; set; }

    public int FormInputId { get; set; }

    public string? Value { get; set; }

    public virtual FormInput FormInput { get; set; } = null!;

    public virtual Transaction Transaction { get; set; } = null!;
}
