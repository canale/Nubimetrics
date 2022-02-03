using System.Collections.Generic;

namespace Nubimetrics.Domain.Entities
{
    public abstract class Entity<TId>
    {
        public TId Id { get; private set; }

        public Entity(TId id)
        {
            Id = id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (Entity<TId>)obj;
            return this.Id.Equals(other.Id);
        }

        public static bool operator ==( Entity<TId> one,  Entity<TId> two)
            => one?.Equals(two) ?? false;

        public static bool operator !=( Entity<TId> one,  Entity<TId> two)
            => !(one?.Equals(two) ?? false);

        public override int GetHashCode() 
            => this.Id.GetHashCode();
    }
}
