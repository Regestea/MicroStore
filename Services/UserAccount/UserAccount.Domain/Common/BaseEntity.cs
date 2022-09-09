﻿using System.ComponentModel.DataAnnotations;

namespace UserAccount.Domain.Common
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
