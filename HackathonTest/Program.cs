using HackathonTest.Menus.Interface;

bool quit = false;

while (!quit) {
  Console.WriteLine("HOME:\n");
  Console.WriteLine("Chose from the following options:");

  foreach ((char tag, string name) in MenuFactory.GetInfo())
  {
    Console.WriteLine($"  ({tag}) {name}");
  }

  if (MenuFactory.GetMenu(Console.ReadKey().KeyChar) is IMenu menu)
  {
    quit = !menu.Host();
  }
  else
  {
    Console.WriteLine("This option isn't supported! Press any key to continue...");
    Console.ReadKey();
  }

  Console.Clear();
}