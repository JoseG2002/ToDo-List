using System;
using System.Collections.Generic;

namespace ToDoListAPI.Data.Models;

public partial class Status
{
    public int Id { get; set; }

    public string StatusTask { get; set; } = null!;

    public virtual ICollection<Tasks> Tasks { get; } = new List<Tasks>();
}
