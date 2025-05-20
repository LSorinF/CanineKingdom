using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CanineKingdom.Models;

namespace CanineKingdom.Models
{
    // NOTE: Inherit from IdentityUser<int> to match your IdentityDbContext setup
    public class ApplicationUser : IdentityUser<int>
    {
        
        //public ICollection<ArticleComment> ArticleComments { get; set; }
        public int AccountNumber { get; set; }
    }
}
