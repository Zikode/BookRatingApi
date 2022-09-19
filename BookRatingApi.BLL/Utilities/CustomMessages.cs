using System;
using System.Collections.Generic;
using System.Text;

namespace BookRatingApi.BLL.Utilities
{
   public class CustomMessages
    {
        public const string ServerError = "Internal server error";

        #region LoginResponseMessages
        public const string UserNotFound = "Incorrect Username or Password";
        public const string LoginSuccess = "User logged in successfully";
        public const string LoginClientError = "Username or Password can not be empty";
        #endregion

        #region RegisterResponseMessages
        public const string UserExits = "Email provided does exist";
        public const string RegisterSuccess = "User registered in successfully";
        public const string RegisterClientError = "All fields must be filled in";
        #endregion

        #region BooksResponseMessages
        public const string NoBooksFound = "No books found";
        public const string BooksFound = "Books found";
        public const string BoosksClientError = "Please fill all mandatory fields";
        public const string BoosksInsertSuccess = "Book added succcessfully";
        public const string BoosksUpdateSuccess = "Book updated succcessfully";
        public const string FailedToUpdateBook = "Failed to update book";
        #endregion
    }
}
