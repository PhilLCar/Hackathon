using System;
using System.Collections.Generic;

namespace HackathonTest.Entities;

public partial class MemberField
{
    public int Id { get; set; }

    public int MemberId { get; set; }

    public int FieldId { get; set; }

    public string? Value { get; set; }

    public virtual Field Field { get; set; } = null!;

    public virtual Member Member { get; set; } = null!;
}
