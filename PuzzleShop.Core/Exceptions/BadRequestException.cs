using System;

namespace PuzzleShop.Core.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException()
        {
        }
        
        public BadRequestException(string msg) : base(msg)
        {
        }
    }
}