using HackathonTest.Database;
using HackathonTest.Entities.Interface;

namespace HackathonTest.Menus.Interface;

internal interface IMenu
{
  public char Tag { get; }

  public bool Host();

  public static bool Hold(string message = "\nPress any key to continue...")
  {
    Console.WriteLine(message);

    return Console.ReadKey().Key == ConsoleKey.H;
  }

  public static TNameable? Select<TNameable>(Func<TNameable, bool>? filter = null) where TNameable : class, INameable, new()
  {
    using HackathonTestContext context = new();

    TNameable? selected = null;

    Console.Clear();
    Console.WriteLine($"Which {typeof(TNameable).Name} do you want to select?");

    foreach (TNameable nameable in context.Set<TNameable>())
    {
      Console.WriteLine($"  {nameable.Id}. {nameable.Name}");
    }

    Console.Write($"{typeof(TNameable).Name} Id: ");

    if (int.TryParse(Console.ReadLine(), out int nameableId))
    {
      if (filter != null)
      {
        selected = context.Set<TNameable>().Where(filter).SingleOrDefault(n => n.Id == nameableId);
      }
      else
      { 
        selected = context.Set<TNameable>().SingleOrDefault(n => n.Id == nameableId);
      }
    }

    return selected;
  }
}

internal interface IMenu<TNameable> : IMenu where TNameable : INameable
{
  public TNameable?             Create(string name);
  public IEnumerable<TNameable> Read();
  public bool                   Update(string oldname, string newname);
  public bool                   Delete(string name);
}
