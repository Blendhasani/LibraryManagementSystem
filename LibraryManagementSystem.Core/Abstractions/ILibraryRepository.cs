using LibraryManagementSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Core.Abstractions
{
	public interface ILibraryRepository
	{
		List<Book> Books { get; }
		void Add(Book book);
	}
}
