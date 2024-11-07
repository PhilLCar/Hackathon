using HackathonTest.Entities;
using HackathonTest.Menus.Abstraction;

namespace HackathonTest.Menus;

internal class Fields : CrudMenu<Field>
{
  public override char Tag { get; } = 'd';
}
