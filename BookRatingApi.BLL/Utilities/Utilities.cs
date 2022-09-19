using System;
using System.Collections.Generic;
using System.Text;

namespace BookRatingApi.BLL.Utilities
{
    public static class Utilities
    {
        public static string EncrpytPassword(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        public static string GenerateUserName(string FirstName, string LastName)
        {
            var UserName = FirstName + LastName.Substring(0, 1).ToUpper();
            return UserName;
        }
    }
}
