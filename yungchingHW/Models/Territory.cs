﻿using System;
using System.Collections.Generic;

namespace yungchingHW.Models;

public partial class Territory
{
    public string TerritoryId { get; set; } = null!;

    public string TerritoryDescription { get; set; } = null!;

    public int RegionId { get; set; }

    public virtual Region Region { get; set; } = null!;

    public virtual ICollection<Employee1> Employees { get; set; } = new List<Employee1>();
}
