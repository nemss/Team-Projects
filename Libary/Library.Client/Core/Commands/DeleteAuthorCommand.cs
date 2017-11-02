using Library.Client.Utilities;
using Library.Data;
using Library.Models;
using System;
using System.Linq;

namespace Library.Client.Core.Commands
{
    public class DeleteAuthorCommand
    {
        public string Execute(string[] inputArgs)
        {
            //Check.CheckLength(2, inputArgs);

            string propType = inputArgs[0];
            string authorFirstName = inputArgs[1];
            string authorLastName = inputArgs[2];

            AuthenticationManager.Authorize();

            User currentUser = AuthenticationManager.GetCurrentUser();
            return DeleteAuthor(currentUser, propType, authorFirstName, authorLastName);
        }

        private static string DeleteAuthor(User currentUser, string propType, string authorFirstName, string authorLastName)
        {
            if (currentUser.Role == Role.Admin)
            {
                LibraryContext context = new LibraryContext();
                if (propType == "Delete")
                {
                    if (CommandHelper.IsAuthorExisting(authorFirstName, authorLastName))
                    {
                        context.Authors.FirstOrDefault(ta => ta.FirstName == authorFirstName && ta.LastName == authorLastName).IsDeleted = true;
                        context.SaveChanges();
                        return $"Author {authorFirstName} {authorLastName} was deleted successfully!";
                    }
                    else
                    {
                        throw new ArgumentException(string.Format(Constants.ErrorMessages.AuthortNotFound, authorFirstName, authorLastName));
                    }
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