using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleMVC.Models
{
    public class Users
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }

    public class UserData
    {
        private static readonly List<Users> Users = new List<Users>();
        private int currentIdx=2;

        static UserData()
        {
            Users.Add(new Users { Id = 1, Email = "crivad@yahoo.com", Name = "Maria" });
            Users.Add(new Users { Id = 2, Email = "mih@yahoo.com", Name = "mih" });
        }

        public UserData()
        {
        }

        public List<Users> GetUsers()
        {
            return Users;
        }

        public Users GetUser(int id)
        {
            return Users.Find(x => x.Id == id);
        }

        public void AddUser(Users u)
        {
            u.Id = currentIdx + 1;
            currentIdx++;
            Users.Add(u);
        }
    }
}