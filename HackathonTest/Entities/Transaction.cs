using System;
using System.Collections.Generic;

namespace HackathonTest.Entities;

public partial class Transaction
{
    public int Id { get; set; }

    public int FormId { get; set; }

    public int CreatedById { get; set; }

    public DateTime CreatedOn { get; set; }

    public bool Done { get; set; }

    public virtual Member CreatedBy { get; set; } = null!;

    public virtual Form Form { get; set; } = null!;

    public virtual ICollection<TransactionField> TransactionFields { get; set; } = new List<TransactionField>();

    public virtual ICollection<TransactionInput> TransactionInputs { get; set; } = new List<TransactionInput>();

    public virtual ICollection<TransactionOwner> TransactionOwners { get; set; } = new List<TransactionOwner>();
}
