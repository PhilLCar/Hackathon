using HackathonTest.Database;
using HackathonTest.Entities;

namespace HackathonTest.API;

internal static class Forms
{
  public static Form Create(string name, string? description = null)
  {
    using HackathonTestContext context = new();

    Form form = new()
    {
      Name        = name,
      Description = description,
    };

    context.Add(form);
    context.SaveChanges();

    return form;
  }

  public static bool AddSection(Form form, string name)
  {
    using HackathonTestContext context = new();

    context.Attach(form);

    bool success = context.FormSections.Add(new() { Name = name }) != null;

    context.SaveChanges();
    
    return success;
  }

  public static bool RemoveSection(Form form, string name)
  {
    using HackathonTestContext context = new();

    context.Attach(form);

    bool success = context.FormSections.Remove(form.FormSections.Single(f => f.Name == name)) != null;

    context.SaveChanges();

    return success;
  }

  public static bool AddAccess(Form form, int accessId, int accessTypeId)
  {
    using HackathonTestContext context = new();

    context.Attach(form);

    bool success = context.FormAccesses.Add(new() { AccessId = accessId, AccessTypeId = accessTypeId }) != null;

    context.SaveChanges();
    
    return success;
  }

  public static bool RemoveAccess(Form form, int formAccessId)
  {
    using HackathonTestContext context = new();

    context.Attach(form);

    bool success = context.FormAccesses.Remove(form.FormAccesses.Single(a => a.Id == formAccessId)) != null;

    context.SaveChanges();

    return success;
  }

  public static bool Delete(Form form)
  {
    using HackathonTestContext context = new();

    context.Attach(form);

    bool success = context.Remove(form) != null;

    context.SaveChanges();

    return success;
  }
}
