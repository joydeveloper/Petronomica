using SharedServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petronomica.Models
{
    public class ConfirmEmail : EmailType
    {
        public ConfirmEmail(string emailto,string message)
        {
            Name = "Поддержка пользователей";
            From = "development@petronomica.ru";
            To = emailto;
            Subject = "Регистрация";
            Message = message;
            Password = "Toster12";
        }

    }
}
