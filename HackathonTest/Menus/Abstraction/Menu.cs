using HackathonTest.Database;
using HackathonTest.Entities.Interface;
using HackathonTest.Menus.Interface;

namespace HackathonTest.Menus.Abstraction;

internal abstract class Menu<TNameable> : IMenu<TNameable> where TNameable : class, INameable, new()
{
  public abstract char Tag { get; }

  public bool Host()
  {
    bool exit = false;

    while (!exit)
    { 
      Console.Clear();

      Console.WriteLine($"{GetType().Name.ToUpper()} MENU:\n");
      Console.WriteLine("Chose from the following options:");
      Console.WriteLine("  (c) Create");
      Console.WriteLine("  (r) Read");
      Console.WriteLine("  (u) Update");
      Console.WriteLine("  (d) Delete");
      Console.WriteLine("  (h) Home");
      Console.WriteLine("  (q) Quit");

      switch (Console.ReadKey().KeyChar)
      {
        case 'c':
          CreateMenu();
          break;
        case 'r':
          ReadMenu();
          break;
        case 'u':
          UpdateMenu();
          break;
        case 'd':
          DeleteMenu();
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

  private void CreateMenu()
  {
    Console.Clear();
    Console.Write("Name: ");

    string? name = Console.ReadLine();

    if (name != null && name != "")
    {
      if (Create(name) != null)
      {
        Console.WriteLine("Successfully created record");
      }
      else
      {
        Console.WriteLine("Create failed");
      }

      IMenu.Hold();
    }
  }

  private void ReadMenu()
  {
    Console.Clear();

    foreach (TNameable nameable in Read())
    {
      Console.WriteLine($"  {nameable.Name}");
    }

    IMenu.Hold();
  }

  private void UpdateMenu()
  {
    Console.Clear();
    Console.Write("Old Name: ");

    string? old = Console.ReadLine();

    if (old != null && old != "")
    {
      Console.Write("New Name: ");

      string? name = Console.ReadLine();

      if (name != null && name != "" && name != old)
      {
        if (Update(old, name))
        {
          Console.WriteLine("Successfully update record");
        }
        else
        {
          Console.WriteLine("Update failed");
        }
    
        IMenu.Hold();
      }
    }
  }

  private void DeleteMenu()
  {
    Console.Clear();
    Console.Write("Name: ");

    string? name = Console.ReadLine();

    if (name != null && name != "")
    {
      if (Delete(name))
      {
        Console.WriteLine("Successfully deleted record");
      }
      else
      {
        Console.WriteLine("Delete failed");
      }

      IMenu.Hold();
    }
  }

  public TNameable? Create(string name)
  {
    using HackathonTestContext context = new();

    TNameable? nameable = context.Set<TNameable>().SingleOrDefault(n => n.Name == name);

    if (nameable == null)
    {
      nameable = new()
      {
        Name = name
      };

      context.Add(nameable);
      context.SaveChanges();
    }

    return nameable;
  }

  public bool Delete(string name)
  {
    using HackathonTestContext context = new();

    TNameable? nameable = context.Set<TNameable>().SingleOrDefault(n => n.Name == name);

    if (nameable != null)
    {
      context.Remove(nameable);

      context.SaveChanges();
    }

    return nameable != null;
  }

  public IEnumerable<TNameable> Read()
  {
    using HackathonTestContext context = new();

    return context.Set<TNameable>().ToList();
  }

  public bool Update(string oldname, string newname)
  {
    using HackathonTestContext context = new();
    
    TNameable? nameable = context.Set<TNameable>().SingleOrDefault(n => n.Name == oldname);

    if (nameable != null)
    {
      nameable.Name = newname;

      context.SaveChanges();
    }

    return nameable != null;
  }
}
