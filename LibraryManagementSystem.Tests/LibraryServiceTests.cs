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
		[Fact]
		public void BorrowBook_ShouldThrow_WhenBookAlreadyBorrowed()
		{
			var service = new LibraryService();
			service.AddBook("Dune", "Frank Herbert");
			service.BorrowBook("Dune");

			Assert.Throws<InvalidOperationException>(() => service.BorrowBook("Dune"));
		}

		[Fact]
		public void ReturnBook_ShouldMarkBookAsAvailable_WhenBookWasBorrowed()
		{
			var service = new LibraryService();
			service.AddBook("Dune", "Frank Herbert");

			service.BorrowBook("Dune");
			service.ReturnBook("Dune");

			var book = service.GetAllBooks().First(b => b.Title == "Dune");
			Assert.True(book.IsAvailable);
		}

		[Fact]
		public void ReturnBook_ShouldThrow_WhenTitleIsEmpty()
		{
			var service = new LibraryService();
			Assert.Throws<ArgumentException>(() => service.ReturnBook(""));
		}

		[Fact]
		public void ReturnBook_ShouldThrow_WhenBookDoesNotExist()
		{
			var service = new LibraryService();
			Assert.Throws<InvalidOperationException>(() => service.ReturnBook("Unknown Book"));
		}

		[Fact]
		public void ReturnBook_ShouldThrow_WhenBookIsAlreadyAvailable()
		{
			var service = new LibraryService();
			service.AddBook("Dune", "Frank Herbert");

			// Book was never borrowed it is already available
			Assert.Throws<InvalidOperationException>(() => service.ReturnBook("Dune"));
		}


		[Fact]
		public void AddBook_ShouldThrow_WhenTitleIsEmpty()
		{
			var service = new LibraryService();
			Assert.Throws<ArgumentException>(() => service.AddBook("", "Unknown")); // passes
		}
	}
}
