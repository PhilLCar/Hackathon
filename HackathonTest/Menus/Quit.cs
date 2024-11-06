using HackathonTest.Menus.Interface;

namespace HackathonTest.Menus;

internal class Quit : IMenu
{
  public char Tag { get; } = 'q';

  public bool Host()
  {
    return false;
  }
}
