﻿namespace Library.Client.Core.Commands
{
    using Models;
    using Utilities;

    public class HelpCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(0, inputArgs);

            AuthenticationManager.Authorize();

            User currentUser = AuthenticationManager.GetCurrentUser();

            if (currentUser.Role == Role.Admin)
            {
                return "Login - Register to our system\nLogout - Log out of our system\nDelete - Delete current user\nDeleteAuthor - Delete (Author First Name , Author Last Name)\nAddBook - Add a book you’ve read(Book name, Author, Genre)\nModifyUser - Change current user Password or Borntown\nModifyAuthor - Modify old(Author First Name , Author Last Name) (New Author First Name, New Author Last Name)\nClear - Clear screen\nShowAllUsers - Shows all users in our system\nExportToJson - Structure data (Users, UsersWithTheirBooks, BooksWithTheirAuthor)\nAddTown - Add hometown(town country)\nChangeRole - Change user rights";
            }
            else if (currentUser.Role == Role.User)
            {
                return "Login - Register to our system\nLogout - Log out of our system\nDelete - Delete current user\nAddBook - Add a book you’ve read(Book name, Author, Genre)\nModifyUser - Change current user Password or Hometown\nClear - Clear screen\n";
            }
            return "";
        }
    }
}