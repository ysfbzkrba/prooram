using System;

namespace prooram.Domain.Exceptions
{
    public class CategoryExistsException : Exception
    {
        public CategoryExistsException(string categoryName) : base($"CategoryName : \"{categoryName}\" already created.")
        { }


    }
}


