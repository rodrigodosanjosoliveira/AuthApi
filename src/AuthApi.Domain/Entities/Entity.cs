using System;

namespace AuthApi.Domain.Entities
{
    public abstract class Entity
    {
        protected Entity(Guid id)
        {
            Id = id;
            DateCreated = DateTime.Now;
        }
        public Guid Id { get; private set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }


}
