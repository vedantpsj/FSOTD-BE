using System.ComponentModel.DataAnnotations;

namespace User.Models {
  public class UserModel {
    public int id {
      get;
      set;
    }

    public string ? username {
      get;
      set;
    }

    public string ? email {
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