﻿using System;
using Core.Entities;

namespace Entities.Concretes
{
	public class Manufacturer:Entity<int>
	{
		public string ManufacturerName { get; set; }
	}
}

