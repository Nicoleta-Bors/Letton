﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Letton.Domain.Entities.User;

namespace Letton.BusinessLogic.DBModel
{
     public class UserContext : DbContext
     {
          public UserContext() :
              base("name=LETTON") // connectionstring name define in your web.config
          {
          }

          public virtual DbSet<UDbTable> Users { get; set; }
     }
}
