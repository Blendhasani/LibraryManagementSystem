using LibraryManagementSystem.Core.Abstractions;
using LibraryManagementSystem.Core.Models;
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
		// Simple fake repository for testing
		private class FakeRepository : ILibraryRepository
		{
			public List<Book> Books { get; } = new();
			public void Add(Book book) => Books.Add(book);
		}

		[Fact]
		public void GetAllBooks_ShouldReturnAllBooks()
		{
			var repo = new LibraryRepository();
			var service = new LibraryService(repo);

			service.AddBook("Dune", "Author");
			service.AddBook("1984", "Orwell");

			var books = service.GetAllBooks();

			Assert.Equal(2, books.Count);
		}

		[Fact]
		public void AddBook_ShouldIncreaseBookCount()
		{
			var repo = new FakeRepository();
			var service = new LibraryService(repo);

			service.AddBook("1984", "George Orwell");

			Assert.Single(repo.Books);
		}

		[Fact]
		public void AddBook_ShouldThrow_WhenTitleIsEmpty()
		{
			var repo = new FakeRepository();
			var service = new LibraryService(repo);

			Assert.Throws<ArgumentException>(() => service.AddBook("", "Unknown"));
		}

		[Fact]
		public void AddBook_ShouldThrow_WhenTitleAlreadyExists()
		{
			var repo = new FakeRepository();
			var service = new LibraryService(repo);

			service.AddBook("Dune", "Author1");

			Assert.Throws<InvalidOperationException>(() => service.AddBook("Dune", "Author2"));
		}


		[Fact]
		public void BorrowBook_ShouldMarkBookAsUnavailable()
		{
			var repo = new FakeRepository();
			var service = new LibraryService(repo);

			service.AddBook("Dune", "Frank Herbert");
			service.BorrowBook("Dune");

			Assert.False(repo.Books.First().IsAvailable);
		}

		[Fact]
		public void BorrowBook_ShouldThrow_WhenBookAlreadyBorrowed()
		{
			var repo = new FakeRepository();
			var service = new LibraryService(repo);

			service.AddBook("Dune", "Frank Herbert");
			service.BorrowBook("Dune");

			Assert.Throws<InvalidOperationException>(() => service.BorrowBook("Dune"));
		}

		[Fact]
		public void BorrowBook_ShouldSkipAvailabilityCheck_WhenIgnoreIsTrue()
		{
			var repo = new FakeRepository();
			var service = new LibraryService(repo);

			service.AddBook("Dune", "Frank Herbert");

			// borrow once to make it unavailable
			service.BorrowBook("Dune");

			// borrow again, but now ignoring availability check
			service.BorrowBook("Dune", ignoreAvailability: true);

			Assert.False(repo.Books.First().IsAvailable);
		}

		[Fact]
		public void ReturnBook_ShouldMarkBookAsAvailable()
		{
			var repo = new FakeRepository();
			var service = new LibraryService(repo);

			service.AddBook("Dune", "Frank Herbert");
			service.BorrowBook("Dune");

			service.ReturnBook("Dune");

			Assert.True(repo.Books.First().IsAvailable);
		}
		[Fact]
		public void ReturnBook_ShouldThrow_WhenTitleIsWhitespace()
		{
			var repo = new FakeRepository();
			var service = new LibraryService(repo);

			Assert.Throws<ArgumentException>(() => service.ReturnBook("   "));
		}

		[Fact]
		public void ReturnBook_ShouldThrow_WhenTitleIsEmpty()
		{
			var repo = new FakeRepository();
			var service = new LibraryService(repo);

			Assert.Throws<ArgumentException>(() => service.ReturnBook(""));
		}

		[Fact]
		public void ReturnBook_ShouldThrow_WhenBookDoesNotExist()
		{
			var repo = new FakeRepository();
			var service = new LibraryService(repo);

			Assert.Throws<InvalidOperationException>(() => service.ReturnBook("Unknown"));
		}

		[Fact]
		public void ReturnBook_ShouldThrow_WhenBookIsAlreadyAvailable()
		{
			var repo = new FakeRepository();
			var service = new LibraryService(repo);

			service.AddBook("Dune", "Frank Herbert");

			Assert.Throws<InvalidOperationException>(() => service.ReturnBook("Dune"));
		}


	}
}
