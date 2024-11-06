using HackathonTest.Entities.Interface;

namespace HackathonTest.Entities.Interface
{ 
  internal interface IIdentifyable
  {
    public int Id { get; }
  }
}

// Assign Interface
namespace HackathonTest.Entities
{
  public partial class Field            : IIdentifyable { }
  public partial class Form             : IIdentifyable { }
  public partial class FormField        : IIdentifyable { }
  public partial class FormSection      : IIdentifyable { }
  public partial class Member           : IIdentifyable { }
  public partial class MemberField      : IIdentifyable { }
  public partial class Transaction      : IIdentifyable { }
  public partial class TransactionField : IIdentifyable { }
  public partial class TransactionOwner : IIdentifyable { }
}