using System;
using System.Collections.Generic;

namespace HackathonTest.Entities;

public partial class TransactionOwner
{
    public int Id { get; set; }

    public int TransactionId { get; set; }

    public int? OwnerId { get; set; }

    public DateTime Date { get; set; }

    public int FormSectionId { get; set; }

    public virtual FormSection FormSection { get; set; } = null!;

    public virtual Member? Owner { get; set; }

    public virtual Transaction Transaction { get; set; } = null!;
}
