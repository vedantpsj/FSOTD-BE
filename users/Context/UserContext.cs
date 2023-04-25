using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using User.Entities;

namespace User.Context {

  public class UserContext
    : DbContext {
      public UserContext(DbContextOptions options): base(options) {}

      public DbSet < UserEntity > Users {
        get;
        set;
      }
    }
}