//using HackathonTest.Menus.Interface;

using HackathonTest.API;
using HackathonTest.Database;
using HackathonTest.Entities;

bool quit = false;

Member? me;

void Switch()
{
  Console.WriteLine("Press any key to continue");
  Console.ReadKey();
  Console.Clear();
}

string Input(string prompt)
{
  Console.Write(prompt + ": ");

  return Console.ReadLine() ?? "";
}


void ListForms()
{
  Form[] forms = Forms.ReadAll();

  for (int i = 0; i < forms.Length; i++)
  {
    Console.WriteLine(forms[i].Name);
  }

  Switch();
}

void FillForm()
{
  string formName = Input("Enter the form name you want to fill");

  if (Forms.Read(formName) is Form form && me != null)
  {
    using HackathonTestContext context = new();

    Transaction current = Transactions.Create(form, me);

    context.Attach(me);
    context.Attach(current);

    foreach (FormField formField in context.FormFields.Where(f => f.FormSectionId == current.TransactionOwners.OrderBy(o => o.Id).Last().FormSectionId))
    {
      TransactionField? transactionField = current.TransactionFields.SingleOrDefault(t => t.FormFieldId == formField.Id);

      if (transactionField == null)
      {
        transactionField = new TransactionField()
        {
          TransactionId = current.Id,
          FormFieldId   = formField.Id,
        };

        context.Add(transactionField);
        context.SaveChanges();
      }

      MemberField? defaultValue = me.MemberFields.SingleOrDefault(mf => mf.FieldId == formField.FieldId);

      string value = Input($"Enter a value for {formField.Name}{(defaultValue != null ? $" (default: {defaultValue.Value})" : "")}");

      if (value != "")
      {
        if (defaultValue != null)
        {
          defaultValue.Value = value;
        }
        else
        {
          defaultValue = new()
          {
            FieldId = formField.FieldId
          };

          me.MemberFields.Add(defaultValue);
        }

        context.SaveChanges();
      }
      else if (defaultValue != null)
      {
        transactionField.Value = defaultValue.Value;
      }
    }
  }
}

while (!quit) {
  Console.WriteLine("HOME:\n");
  Console.WriteLine("Chose from the following options:");
  Console.WriteLine("  (l) List all available forms");

  char option = Console.ReadKey().KeyChar;

  switch (option)
  {
    case 'l':
      ListForms();
      break;
  }

  Console.Clear();
}