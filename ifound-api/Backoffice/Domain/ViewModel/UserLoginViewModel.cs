using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ifound_api.Backoffice.Domain.ViewModel
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Username é obrigatório")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password é obrigatório")]
        public string Password { get; set; }
    }
}
