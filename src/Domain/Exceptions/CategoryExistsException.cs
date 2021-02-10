using System;

using prooram.Domain.Common;

namespace prooram.Domain.Exceptions
{
    public class CategoryExistsException : Exception
    {
        public CategoryExistsException(string categoryName) : base($"CategoryName : \"{categoryName}\" already created.")
        { }


    }
}


