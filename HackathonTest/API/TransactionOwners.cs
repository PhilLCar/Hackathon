using HackathonTest.Database;
using HackathonTest.Entities;

namespace HackathonTest.API;

internal static class TransactionOwners
{
  public static TransactionOwner Create(Member owner, Transaction parent, FormSection section)
  {
    using HackathonTestContext context = new();

    TransactionOwner transactionOwner = new()
    {
      TransactionId = parent.Id,
      OwnerId       = owner.Id,
      FormSectionId = section.Id,
    };

    context.Add(transactionOwner);
    context.SaveChanges();

    return transactionOwner;
  }
}
