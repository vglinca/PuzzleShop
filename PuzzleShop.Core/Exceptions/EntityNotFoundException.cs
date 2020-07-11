using System;

namespace PuzzleShop.Core.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message) : base(message)
        {}
        public EntityNotFoundException(Type entityType, long id) : 
            base($"Entity of type { entityType.Name } with id: { id } not found")
        {}
        public EntityNotFoundException(Type entityType) : base($"Entity of type { entityType.Name } not found")
        {}
        public static EntityNotFoundException OfType<T>(long id)
        {
            return new EntityNotFoundException(typeof(T), id);
        }
        public static EntityNotFoundException OfType<T>()
        {
            return new EntityNotFoundException(typeof(T));
        }
    }
}