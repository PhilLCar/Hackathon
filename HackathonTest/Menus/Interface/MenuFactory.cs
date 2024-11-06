using System.Reflection;

namespace HackathonTest.Menus.Interface;

internal static class MenuFactory
{
  private static IEnumerable<Type> Menus => Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsClass && !t.IsAbstract && typeof(IMenu).IsAssignableFrom(t));

  public static IMenu? GetMenu(char tag)
  {
    IMenu? menu = null;

    foreach (Type t in Menus)
    {
      if (Activator.CreateInstance(t) is IMenu potential && potential.Tag == tag)
      {
        menu = potential;
        break;
      }
    }

    return menu;
  }

  public static IReadOnlyCollection<(char Tag, string Name)> GetInfo()
  {
    List<(char Tag, string Name)> menus = [];

    foreach (Type t in Menus)
    {
      if (Activator.CreateInstance(t) is IMenu menu)
      {
        menus.Add((menu.Tag, t.Name));
      }
    }

    return menus;
  }
}
