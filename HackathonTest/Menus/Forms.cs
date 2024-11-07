using HackathonTest.Entities;
using HackathonTest.Menus.Abstraction;

namespace HackathonTest.Menus;

internal class Forms : CrudMenu<Form>
{
  public override char Tag { get; } = 'f';
}
