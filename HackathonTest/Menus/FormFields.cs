using HackathonTest.Database;
using HackathonTest.Entities;
using HackathonTest.Menus.Abstraction;
using HackathonTest.Menus.Interface;
using Microsoft.EntityFrameworkCore;

namespace HackathonTest.Menus;

internal class FormFields : SubMenu<FormSection>, IMenu
{
  public override char Tag { get; } = 'F';

  protected override string DisplaySelect()
  {
    using HackathonTestContext context = new();

    context.Entry(_selected!).Reference(s => s.Form).Load();

    return $"{_selected!.Form.Name}:{_selected.Name}";
  }

  protected override void SelectMenu()
  {
    Form? selected = IMenu.Select<Form>();
  
    if (selected != null)
    { 
      _selected = IMenu.Select<FormSection>(s => s.FormId == selected.Id);
    }
  }

  protected override void AddMenu()
  {
    if (_selected != null)
    {
      using HackathonTestContext context = new();

      Console.Clear();
      Console.WriteLine("Current Fields in section are:");

      foreach (FormField formField in context.FormFields.Where(ff => ff.FormSectionId == _selected.Id).Include(ff => ff.Field))
      {
        Console.WriteLine($"  {formField.Name}: {formField.Field.Name}");
      }

      if (!IMenu.Hold("Press enter to add a new field..."))
      {
        Field? field = IMenu.Select<Field>();

        if (field != null)
        { 
          Console.Write("Chose a name for that field: ");

          string? name = Console.ReadLine();

          if (name != null && name != "")
          {
            FormField formField = new()
            {
              Name = name,
              FieldId = field.Id,
              FormSectionId = _selected.Id,
            };

            context.Add(formField);
            context.SaveChanges();
          }
        }
      }
    }
  }

  protected override void RemoveMenu()
  {

  }
}
