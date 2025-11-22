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
		private void ValidateBook(string title)
		{
			if (string.IsNullOrWhiteSpace(title))
				throw new ArgumentException("Title cannot be empty.");
		}

		public void AddBook(string title, string author)
		{
			ValidateBook(title);

			_books.Add(new Book
			{
				Title = title,
				Author = author,
				IsAvailable = true
			});
		}


		public List<Book> GetAllBooks() => _books;


		public void BorrowBook(string title)
		{
			var book = _books.FirstOrDefault(b => b.Title == title);

			if (book == null)
				throw new InvalidOperationException("Book not found.");

			book.IsAvailable = false;
		}

		public void ReturnBook(string title)
		{
			// not implemented yet
		}
	}
}
