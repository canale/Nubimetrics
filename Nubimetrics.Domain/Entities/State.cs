using System;

namespace Nubimetrics.Domain.Entities
{
    public class State : Entity<string>
    {
        public string Name { get; }

        public State(string id, string name ):base(id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException($"'{nameof(id)}' can't be null nor empty.", nameof(id));
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"'{nameof(name)}' can't be null nor empty.", nameof(name));
            }

            Name = name;
        }
    }
}
