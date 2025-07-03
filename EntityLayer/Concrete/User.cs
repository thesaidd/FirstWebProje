using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String UserName { get; set; }
        public String Mail { get; set; }
        public String Password { get; set; }
        public String ImageUrl { get; set; }
        public bool Status { get; set; }
        public List<UserMessage> UserMessages { get; set; }
    }
}
