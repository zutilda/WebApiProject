using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiProject.Models
{
    public class UsersModel
    {
        public UsersModel(Users user)
        {
            id_user = user.id_user;
            login = user.login;
            password = user.password;
            name = user.name;
            surname = user.surname;
            patronymic = user.patronymic;
            age = user.age;
        }
        public int id_user { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string patronymic { get; set; }
        public int age { get; set; }
    }
}