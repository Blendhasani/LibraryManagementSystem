using LibraryManagementSystem.Core.Abstractions;
using LibraryManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.Services
{
	[ExcludeFromCodeCoverage]
	public class LibraryRepository : ILibraryRepository
	{
		public List<Book> Books { get; } = new();

		public void Add(Book book)
		{
			Books.Add(book);
		}
	}

}
