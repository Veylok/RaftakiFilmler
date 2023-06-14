using System;
using System.Collections.Generic;

namespace ServicesV7.DBModels;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;
}
