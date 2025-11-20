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

		public void AddBook(string title, string author)
		{
			if (string.IsNullOrWhiteSpace(title))
				throw new ArgumentException("Title cannot be empty.");

			_books.Add(new Book { Title = title, Author = author, IsAvailable = true });
		}

		public List<Book> GetAllBooks() => _books;


		public void BorrowBook(string title)
		{
			// not implemented yet
		}

		public void ReturnBook(string title)
		{
			// not implemented yet
		}
	}
}
