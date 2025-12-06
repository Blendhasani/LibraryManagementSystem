using LibraryManagementSystem.Core.Abstractions;
using LibraryManagementSystem.Core.Services;

class Program
{
	static void Main()
	{
		ILibraryRepository repo = new LibraryRepository();
		var service = new LibraryService(repo);

		Console.WriteLine("=== Library Management Console ===");

		while (true)
		{
			Console.Write("\nCommand (add / borrow / return / list / exit): ");
			var cmd = Console.ReadLine()?.Trim().ToLower();

			if (cmd == "exit")
				break;

			try
			{
				switch (cmd)
				{
					case "add":
						Console.Write("Title: ");
						var title = Console.ReadLine();

						Console.Write("Author: ");
						var author = Console.ReadLine();

						service.AddBook(title, author);
						Console.WriteLine("Book added.");
						break;

					case "borrow":
						Console.Write("Title: ");
						var borrowTitle = Console.ReadLine();

						service.BorrowBook(borrowTitle);
						Console.WriteLine("Book borrowed.");
						break;

					case "return":
						Console.Write("Title: ");
						var returnTitle = Console.ReadLine();

						service.ReturnBook(returnTitle);
						Console.WriteLine("Book returned.");
						break;

					case "list":
						foreach (var b in service.GetAllBooks())
						{
							Console.WriteLine($"{b.Title} - {(b.IsAvailable ? "Available" : "Borrowed")}");
						}
						break;

					default:
						Console.WriteLine("Unknown command.");
						break;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}
		}

		Console.WriteLine("Goodbye!");
	}
}