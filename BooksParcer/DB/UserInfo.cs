﻿using System;
using System.Collections.Generic;

namespace BooksParcer
{
    public partial class UserInfo
    {
        public int UserInfoId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateOnly BirthDate { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
