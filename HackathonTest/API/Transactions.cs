using HackathonTest.Database;
using HackathonTest.Entities;

namespace HackathonTest.API;

internal static class Transactions
{
  public static Transaction Create(Form form, Member creator)
  {
    using HackathonTestContext context = new();

    Transaction transaction = new()
    {
      FormId      = form.Id,
      CreatedById = creator.Id
    };

    context.Add(transaction);
    context.SaveChanges();

    TransactionOwners.Create(creator, transaction, form.FormSections.First());

    return transaction;
  }
}
