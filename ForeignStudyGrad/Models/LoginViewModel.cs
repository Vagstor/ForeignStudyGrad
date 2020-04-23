using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignStudyGrad.Models
{
    public class LoginViewModel
    {
        public UserLogModel user { get; set; }
    }
    public class UserLogModel
    {
        [Required(ErrorMessage = "Не указан логин/email")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
