using System;
using System.Collections.Generic;

namespace HackathonTest.Entities;

public partial class Member
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public virtual ICollection<MemberField> MemberFields { get; set; } = new List<MemberField>();

    public virtual ICollection<TransactionOwner> TransactionOwners { get; set; } = new List<TransactionOwner>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
