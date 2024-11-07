using HackathonTest.Database;
using HackathonTest.Entities;
using HackathonTest.Menus.Abstraction;
using HackathonTest.Menus.Interface;

namespace HackathonTest.Menus;

internal class FormSections : SelectMenu<Form>, IMenu
{
  public override char Tag { get; } = 's';

  protected override string DisplaySelect()
  {
    using HackathonTestContext context = new();

    return $"{_selected!.Name}";
  }

  protected override void SelectMenu()
  {
    _selected = IMenu.Select<Form>();
  }

  protected override void AddMenu()
  {
    if (_selected != null)
    {
      using HackathonTestContext context = new();

      Console.Clear();
      Console.WriteLine("Current Sections in Form are:");

      foreach (FormSection section in context.FormSections.Where(fs => fs.FormId == _selected.Id))
      {
        Console.WriteLine($"  {section.Name}");
      }

      if (!IMenu.Hold("Press enter to add a new Section..."))
      {
        Console.Write("Chose a name for the new Section: ");

        string? name = Console.ReadLine();

        if (name != null && name != "")
        {
          FormSection formSection = new()
          {
            Name   = name,
            FormId = _selected.Id,
          };

          context.Add(formSection);
          context.SaveChanges();
        }
      }
    }
  }

  protected override void RemoveMenu()
  {

  }
}
