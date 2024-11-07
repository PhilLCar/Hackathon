using HackathonTest.Database;
using HackathonTest.Entities;
using HackathonTest.Menus.Interface;

namespace HackathonTest.Menus;

internal class Login : IMenu
{
  public char Tag { get; } = 'l';

  private Member? _member = null;

  public bool Host()
  {
    throw new NotImplementedException();
  }

  public void StartForm(Form form)
  {
    using HackathonTestContext context = new();

    Transaction transaction = new()
    {
      FormId      = form.Id,
      CreatedById = _member!.Id
    };

    context.Add(transaction);
    context.SaveChanges();

    TransactionOwner owner = new()
    {
      TransactionId = transaction.Id,
      FormSectionId = form.FormSections.First().Id,
      OwnerId       = _member!.Id
    };

    context.Add(owner);
    context.SaveChanges();
  }

  public void CompleteTransaction(TransactionOwner owner, Func<FormField, TransactionField> fill)
  {
    using HackathonTestContext context = new();

    FormSection section = owner.FormSection;

    context.Entry(section).Reload();
    context.Entry(section).Collection(s => s.FormFields).Load();

    foreach (FormField f in section.FormFields)
    {
      TransactionField? tf = context.TransactionFields.SingleOrDefault(t => t.TransactionId == owner.TransactionId && f.Id == t.FormFieldId);

      if (tf == null)
      {
        tf = fill(f);

        context.Add(tf);
        context.SaveChanges();
      }
    }
  }

  public void SubmitForm(TransactionOwner owner, Func<Member> submitTo)
  {
    using HackathonTestContext context = new();

    FormSection[] sections = context.FormSections.OrderBy(s => s.Id).ToArray();

    int current = 0;

    Member member;

    for (current = 0; current < sections.Length; current++)
    {
      if (sections[current].Id == owner.FormSectionId)
      {
        break;
      }
    }

    if (current < sections.Length - 1)
    {
      // PASS UP
      member = submitTo();


    }
    else
    {
      // DONE
      context.Attach(owner);

      owner.OwnerId          = null;
      owner.Transaction.Done = true;

      context.SaveChanges();
    }
  }

  public Transaction[] CurrentForms()
  {
    if (_member != null)
    { 
      using HackathonTestContext context = new();

      return context.TransactionOwners.Where(t => t.OwnerId == _member.Id).Select(t => t.Transaction).ToArray();
    }

    return [];
  }

  public Transaction[] CompletedForms()
  {
    if (_member != null)
    { 
      using HackathonTestContext context = new();

      return context.Transactions.Where(t => t.CreatedById == _member.Id && t.Done).ToArray();
    }

    return [];
  }

  public Transaction[] SubmittedForms()
  {
    if (_member != null)
    { 
      using HackathonTestContext context = new();

      return context.Transactions.Where(t => t.CreatedById == _member.Id && !t.Done).ToArray();
    }

    return [];
  }
}
