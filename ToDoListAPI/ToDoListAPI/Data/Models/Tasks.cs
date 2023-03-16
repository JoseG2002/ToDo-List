using System;
using System.Collections.Generic;

namespace ToDoListAPI.Data.Models;

public partial class Tasks
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public DateTime FinishDate { get; set; }

    public int IdStatus { get; set; }

    public virtual Status IdStatusNavigation { get; set; } = null!;
}
