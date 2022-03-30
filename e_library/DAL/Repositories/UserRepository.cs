using e_library.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_library.DAL.Repositories
{
    public class UserRepository : BaseRepository
    {
        // Вывести всех пользователей
        public List<User> SelectAllUsers()
        {
            return db.Users.ToList();
        }

        // Выбор пользователя по id
        public User SelectUserByID(int ID)
        {
            return db.Users.Where(user => user.Id == ID).FirstOrDefault();
        }

        // Добавление пользователя в бд
        public bool AddNewUser(User user)
        {
            try
            {
                db.Users.Add(user);
            }
            catch (Exception)
            {
                return false;
            }

            db.SaveChanges();

            return true;
        }

        // Удаление пользователя из БД
        public bool DeleteUser(User user)
        {
            try
            {
                db.Users.Remove(user);
            }
            catch (Exception)
            {
                return false;
            }

            db.SaveChanges();
            
            return true;
        }

        // изменить имя пользователя по id
        public bool UpdateUserNameByID(int ID, string newName)
        {
            var user = db.Users.Where(user => user.Id == ID).FirstOrDefault();

            if (user != null) user.Name = newName;
            else return false;

            db.SaveChanges();

            return true;
        }
    }
}
