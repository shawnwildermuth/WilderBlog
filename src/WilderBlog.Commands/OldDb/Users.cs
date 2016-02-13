using System;
using System.Collections.Generic;

namespace WilderBlog.Commands.OldDb
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string UserName { get; set; }
    }
}
