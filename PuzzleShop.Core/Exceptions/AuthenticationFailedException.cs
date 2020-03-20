
using System;

namespace PuzzleShop.Core.Exceptions
{
    public class AuthenticationFailedException : Exception
    {
        public AuthenticationFailedException(string msg) : base(msg)
        {
        }
    }
}