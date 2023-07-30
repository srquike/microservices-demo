﻿namespace MicroservicesDemo.Domain.Common
{
    public abstract class BaseEntity<TId>
    {
        public TId? Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}