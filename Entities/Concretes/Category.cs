﻿using System;
using Core.Entities;

namespace Entities.Concretes
{
	public class Category : Entity<int>
	{
        public string Name{ get; set; }

<<<<<<< v1
        public ICollection <CourseCategory> CourseCategories { get; set; }
=======
>>>>>>> master
    }
}

