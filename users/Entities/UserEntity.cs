    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;
    using System.Net.Mail;

    namespace User.Entities {

      [Table("user")]
      [Index(nameof(email), IsUnique = true)]
      [Index(nameof(username), IsUnique = true)]
      public class UserEntity {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id {
          get;
          set;
        }

        [Required]
        public string username {
          get;
          set;
        }

        [Required]
        public string email {
          get;
          set;
        }

        public string ? street {
          get;
          set;
        }

        public string ? city {
          get;
          set;
        }

        public string ? countryCode {
          get;
          set;
        }

        public int ? postalCode {
          get;
          set;
        }
      }
    }