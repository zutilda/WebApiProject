using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiProject
{
    public class PasswordShifr
    {
        public static string Shifr(string password)
        {
            string shifrPassword = "";
            for (int i = 0; i < password.Length; i++)
            {
                shifrPassword+= (char)(password[i] + 1);
            }
            return shifrPassword;
        }
        public static string DeShifr(string password)
        {
            string deShifrPassword = "";
            for (int i = 0; i < password.Length; i++)
            {
                deShifrPassword += (char)(password[i] - 1);
            }
            return deShifrPassword;
        }
    }
}