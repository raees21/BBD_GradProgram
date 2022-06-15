using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerHub.ErrorAndAuthModels
{
  public class AuthenticationResponse
  {
    public string AccessToken { get; set; }
    public Guid UserId { get; set; }

    public AuthenticationResponse() { }

  }
}
