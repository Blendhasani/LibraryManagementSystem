using LibraryManagementSystem.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Tests
{
	public class LibraryServiceTests
	{
		[Fact]
		public void AddBook_ShouldIncreaseBookCount()
		{
			var service = new LibraryService();

			service.AddBook("1984", "George Orwell");
			var books = service.GetAllBooks();

			Assert.Single(books); // passes 
		}

		[Fact]
		public void BorrowBook_ShouldMarkBookAsUnavailable()
		{
			var service = new LibraryService();
			service.AddBook("Dune", "Frank Herbert");

			service.BorrowBook("Dune");
			var book = service.GetAllBooks().First();

			Assert.False(book.IsAvailable); // fails
		}

		[Fact(Skip = "ReturnBook feature scheduled for next iteration")]
		public void ReturnBook_ShouldMarkBookAsAvailable()
		{
			var service = new LibraryService();
			service.AddBook("Dune", "Frank Herbert");

			service.BorrowBook("Dune");
			service.ReturnBook("Dune");

			var book = service.GetAllBooks().First();
			Assert.True(book.IsAvailable);
		}


		[Fact]
		public void AddBook_ShouldThrow_WhenTitleIsEmpty()
		{
			var service = new LibraryService();
			Assert.Throws<ArgumentException>(() => service.AddBook("", "Unknown")); // passes
		}
	}
}
