using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogBsa.Domain.Entity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BlogBsa.Domain.ViewModels.Roles
{
    public class ChangeRoleViewModel
    {
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public List<IdentityRole> AllRoles { get; set; }
        public IList<string> UserRoles { get; set; }
        public ChangeRoleViewModel()
        {
            AllRoles = new List<IdentityRole>();
            UserRoles = new List<string>();
        }
    }
}
