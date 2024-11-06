using HackathonTest.Entities;
using HackathonTest.Menus.Abstraction;

namespace HackathonTest.Menus;

internal class Forms : Menu<Form>
{
  public override char Tag { get; } = 'f';
}
