﻿using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class LanguageLevel : Entity<int>
{

    public string Name { get; set; }
    
    public virtual ICollection<ForeignLanguage> ForeignLanguages { get; set; }
}
