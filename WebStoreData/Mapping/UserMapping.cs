using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using WebStoreData.Models;

namespace WebStoreData.Mapping
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            ToTable("User");
            HasKey(i => new {i.UserId});

            Property(i => i.UserId).HasColumnName("UserId");
            Property(i => i.FirstName).HasColumnName("FirstName");
            Property(i => i.LastName).HasColumnName("LastName");
            Property(i => i.Password).HasColumnName("Password");
            Property(i => i.Email).HasColumnName("Email");


        }
    }
}
