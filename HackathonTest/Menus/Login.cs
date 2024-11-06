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

  public void SubmitForm(Form form)
  {
    using HackathonTestContext context = new();

    Transaction transaction = new()
    {
      FormId = form.Id,
      CreatedById = _member!.Id
    };

    context.Add(transaction);
    context.SaveChanges();

    TransactionOwner owner = new()
    {
      TransactionId = transaction.Id,
      FormSectionId = form.FormSections.First().Id,
      OwnerId = _member!.Id
    };

    context.Add(owner);
    context.SaveChanges();

    CompleteTransaction(owner);
  }

  public void CompleteTransaction(TransactionOwner owner)
  {
    using HackathonTestContext context = new();

  }

  public List<Transaction> CurrentForms()
  {
    if (_member != null)
    { 
      using HackathonTestContext context = new();

      return context.TransactionOwners.Where(t => t.OwnerId == _member.Id).Select(t => t.Transaction).ToList();
    }

    return new();
  }

  public List<Transaction> CompletedForms()
  {
    if (_member != null)
    { 
      using HackathonTestContext context = new();

      return context.Transactions.Where(t => t.CreatedById == _member.Id && t.Done).ToList();
    }

    return new();
  }

  public List<Transaction> SubmittedForms()
  {
    if (_member != null)
    { 
      using HackathonTestContext context = new();

      return context.Transactions.Where(t => t.CreatedById == _member.Id && !t.Done).ToList();
    }

    return new();
  }
}
