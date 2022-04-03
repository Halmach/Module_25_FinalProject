using e_library.BLL;
using e_library.BLL.Models;
using System;

namespace e_library
{
    internal class Program
    {
       // public static LibraryServices libraryServices = new LibraryServices();
        static void Main(string[] args)
        {
            LibraryServices libraryServices = new LibraryServices();
            while (true)
            {
                //try
                //{
                    Console.WriteLine("1 - Добавить пользователя");
                    Console.WriteLine("2 - Добавить книгу");
                    Console.WriteLine("3 - Выдать книгу пользователю");
                    Console.WriteLine("4 - Добавить книжный жанр");
                    Console.WriteLine("5 - Добавить автора");
                    Console.WriteLine("6 - Получить список книг определенного жанра");
                    Console.WriteLine("15 - Выйти из программы");

                    switch (Console.ReadLine().Trim().ToLower())
                    {
                        case "1":
                            {
                                UserRegistrationData userRegistrationData = new UserRegistrationData();

                                Console.WriteLine("Введите имя пользователя:");
                                userRegistrationData.Name = Console.ReadLine().Trim();

                                Console.WriteLine("Введите email пользователя:");
                                userRegistrationData.Email = Console.ReadLine().Trim();

                                if (!libraryServices.AddUser(userRegistrationData))
                                    throw new Exception("Ошибка регистрации пользователя");

                                break;
                            }
                        case "2":
                            {
                                BookAdditionData bookAdditionData = new BookAdditionData();

                                Console.WriteLine("Введите наименование книги:");
                                bookAdditionData.Title = Console.ReadLine().Trim();

                                Console.WriteLine("Введите описание книги:");
                                bookAdditionData.Description = Console.ReadLine().Trim();

                                Console.WriteLine("Введите год выпуска книги:");
                                bookAdditionData.ReleaseYser = Convert.ToInt32(Console.ReadLine().Trim());


                                Console.WriteLine("Введите id автора:");
                                bookAdditionData.AuthorId = Convert.ToInt32(Console.ReadLine().Trim());


                                Console.WriteLine("Введите id жанра:");
                                bookAdditionData.GenreId = Convert.ToInt32(Console.ReadLine().Trim());

                                if (!libraryServices.AddBook(bookAdditionData))
                                    throw new Exception("Ошибка при добавлении книги");

                                break;
                            }
                        case "3":
                            {
                                Console.WriteLine("Введите ID пользователя:");
                                var UserID = Convert.ToInt32(Console.ReadLine().Trim());

                                Console.WriteLine("Введите ID книги:");
                                var BookID = Convert.ToInt32(Console.ReadLine().Trim());

                                if (!libraryServices.AddIssuedBook(UserID, BookID))
                                    throw new Exception("Ошибка выдачи книги поьзователю");

                                break;
                            }
                        case "4":
                            {
                                Console.WriteLine("Введите Название жанра:");
                                var genreName = Console.ReadLine().Trim().ToLower();

                                if (!libraryServices.AddGenre(genreName))
                                    throw new Exception("Ошибка добавления жанра");

                                break;
                            }
                        case "5":
                            {
                                Console.WriteLine("Введите фамилию автора:");
                                var surName = Console.ReadLine().Trim();

                                Console.WriteLine("Введите имя автора:");
                                var name = Console.ReadLine().Trim();

                                if (!libraryServices.AddAuthor(surName,name))
                                    throw new Exception("Ошибка добавления автора");

                                break;
                            }
                        case "6":
                            {
                                Console.WriteLine("Введите жанр:");
                                var genreName = Console.ReadLine().Trim().ToLower();

                                Console.WriteLine("Введите с какого по какой год выпущены книги:");
                                var yearFrom = Convert.ToInt32(Console.ReadLine().Trim());
                                var yearTo = Convert.ToInt32(Console.ReadLine().Trim());

                                var result =  libraryServices.GetBooksByGenreAndYears(genreName,yearFrom,yearTo);

                                foreach (var item in result)
                                {
                                    Console.Write(item.ID);
                                    Console.Write("\t");
                                    Console.Write(item.Title);
                                    Console.Write("\t");
                                    Console.Write(item.Description);
                                    Console.Write("\t");
                                    Console.Write(item.ReleaseYser);
                                    Console.Write("\t");
                                    Console.Write(item.Genre);
                                    Console.Write("\t");
                                    Console.Write(item.AuthorSurName + " " + item.AuthorName);
                            }
                            Console.WriteLine();
                                break;
                            }
                        case "15":
                            {
                                return;
                            }
                    }
                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine(e.Message);
                //}
               
            }
        }
    }
}

