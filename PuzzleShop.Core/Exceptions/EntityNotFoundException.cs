using System;

namespace PuzzleShop.Core.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string msg) : base(msg)
        {
        }
    }
}