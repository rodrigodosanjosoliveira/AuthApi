using System;

namespace AuthApi.Domain.Entities
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.Now;
        }
        public Guid Id { get; private set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }


}
