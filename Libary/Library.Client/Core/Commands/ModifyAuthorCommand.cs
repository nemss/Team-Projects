using Library.Client.Utilities;
using Library.Data;
using Library.Models;
using System;
using System.Linq;

namespace Library.Client.Core.Commands
{
    public class ModifyAuthorCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(5, inputArgs);

            string propType = inputArgs[0];
            string authorFirstName = inputArgs[1];
            string authorLastName = inputArgs[2];

            string newAuthorFirstName = inputArgs[3];
            string newAuthorLastName = inputArgs[4];

            AuthenticationManager.Authorize();

            User currentUser = AuthenticationManager.GetCurrentUser();

            return ModifyAuthor(currentUser, propType, authorFirstName, authorLastName, newAuthorFirstName, newAuthorLastName);
        }

        private static string ModifyAuthor(User currentUser, string propType, string authorFirstName, string authorLastName, string newAuthorFirstName, string newAuthorLastName)
        {
            using (var context = new LibraryContext())
            {
                Author author = context.Authors.FirstOrDefault(a => a.FirstName == authorFirstName && a.LastName == authorLastName);
                if (currentUser.Role == Role.Admin)
                {
                    if (propType == "Modify")
                    {
                        author.FirstName = newAuthorFirstName;
                        author.LastName = newAuthorLastName;
                        context.SaveChanges();
                        return $"Author {authorFirstName} {authorLastName} was modified to {newAuthorFirstName} {newAuthorLastName} successfully!";
                    }
                    else
                    {
                        throw new ArgumentException(string.Format(Constants.ErrorMessages.InvalidCommand, propType));
                    }
                }
                else
                {
                    return "You have no rights!";
                }
            }
        }
    }
}