using System;

namespace BaseDemo.Models {
    public abstract class BaseEntity {
        public string Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        protected BaseEntity() {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedAt = DateTime.Now;
        }
    }
}