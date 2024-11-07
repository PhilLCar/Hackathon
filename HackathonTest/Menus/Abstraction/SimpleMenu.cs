using HackathonTest.Entities.Interface;
using HackathonTest.Menus.Interface;

namespace HackathonTest.Menus.Abstraction;

internal abstract class SimpleMenu<TSelected> : IMenu where TSelected : class, INameable, new()
{
  protected TSelected? _selected = null;

  public abstract char Tag { get; }

  protected abstract string DisplaySelect();
  protected abstract void   SelectMenu();
  protected abstract void   AddMenu();
  protected abstract void   RemoveMenu();

  public bool Host()
  {
    bool exit = false;

    while (!exit)
    {
      Console.Clear();

      if (_selected == null)
      {
        Console.WriteLine($"{GetType().Name.ToUpper()} MENU:\n");
        Console.WriteLine("Chose from the following options:");
        Console.WriteLine($"  (s) Select a {typeof(TSelected).Name}");
      }
      else
      {
        string name = GetType().Name;

        Console.WriteLine($"{name.ToUpper()} ({DisplaySelect()}) MENU:\n");
        Console.WriteLine("Chose from the following options:");
        Console.WriteLine($"  (a) Add a {name}");
        Console.WriteLine($"  (r) Remove a {name}");
      }

      Console.WriteLine("  (h) Home");
      Console.WriteLine("  (q) Quit");

      switch (Console.ReadKey().KeyChar)
      {
        case 's':
          SelectMenu();
          break;
        case 'a':
          AddMenu();
          break;
        case 'r':
          RemoveMenu();
          break;
        case 'h':
          exit = true;
          break;
        case 'q':
          return false;
      }
    }

    return exit;
  }
}
