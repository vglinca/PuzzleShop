using System;

namespace PuzzleShop.Core.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string msg) : base(msg)
        {
        }
    }
}