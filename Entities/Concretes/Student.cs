﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class Student : Entity<int>
{

    public string Name { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; }


}
