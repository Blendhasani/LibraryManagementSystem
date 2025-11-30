using LibraryManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.Services
{
	public class LibraryService
	{
		private readonly List<Book> _books = new();

		//Before Refactoring
		//public void AddBook(string title, string author)
		//{
		//	if (title == null || title == "")
		//	{
		//		throw new Exception("error");
		//	}

		//	var book = new Book();
		//	book.Title = title;
		//	book.Author = author;
		//	book.IsAvailable = true;

		//	_books.Add(book);
		//}

		//After refactoring

		//Ndryshuar per demo
		//private void ValidateBook(string title)
		private void EnsureValidTitle(string title)
		{
			if (string.IsNullOrWhiteSpace(title))
				throw new ArgumentException("Title cannot be empty.");
			//validation week 4
			if (_books.Any(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase)))
				throw new InvalidOperationException("A book with this title already exists.");

		}

		// Shared lookup logic
		private Book GetBookOrThrow(string title)
		{
			var book = _books.FirstOrDefault(b =>
				b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

			if (book is null)
				throw new InvalidOperationException($"Book '{title}' not found.");

			return book;
		}


		public void AddBook(string title, string author)
		{
			EnsureValidTitle(title);

			_books.Add(new Book
			{
				Title = title,
				Author = author,
				IsAvailable = true
			});
		}


		public List<Book> GetAllBooks() => _books;


		public void BorrowBook(string title,
			bool ignoreAvailability = false //parameter i shtuar per demo
			)
		{
			var book = GetBookOrThrow(title);

			if (!ignoreAvailability)
			{
				EnsureBookCanBeBorrowed(book);
			}
			//larguar per demo
			//if (!book.IsAvailable)
			//throw new InvalidOperationException("Book is already borrowed.");
			EnsureBookCanBeBorrowed(book);

			book.IsAvailable = false;
		}

		//shtuar per demo
		private void EnsureBookCanBeBorrowed(Book book)
		{
			if (!book.IsAvailable)
				throw new InvalidOperationException("Book is already borrowed.");
		}
		public void ReturnBook(string title)
		{
			if (string.IsNullOrWhiteSpace(title))
				throw new ArgumentException("Title cannot be empty.");

			var book = _books.FirstOrDefault(b => b.Title == title);

			if (book is null)
				throw new InvalidOperationException("Book not found.");

			if (book.IsAvailable)
				throw new InvalidOperationException("Book is already returned and available.");

			book.IsAvailable = true;
		}






	}
}
