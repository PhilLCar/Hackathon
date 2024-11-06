using HackathonTest.Entities.Interface;

namespace HackathonTest.Entities.Interface
{ 
  internal interface INameable : IIdentifyable
  {
    public string Name { get; set; }
  }
}

// Assign Interface
namespace HackathonTest.Entities
{
  public partial class Field            : INameable { }
  public partial class Form             : INameable { }
  public partial class FormSection      : INameable { }
  public partial class FormField        : INameable { }
  public partial class FormInput        : INameable { }
}