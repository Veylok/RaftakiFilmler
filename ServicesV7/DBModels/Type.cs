using System;
using System.Collections.Generic;

namespace ServicesV7.DBModels;

public partial class Type
{
    public int TypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<Film> Films { get; set; } = new List<Film>();
}
