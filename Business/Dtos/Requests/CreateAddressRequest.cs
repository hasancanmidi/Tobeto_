﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Requests;

public class CreateAddressRequest
{
    public int CountryId { get; set; }
    public int Cityıd { get; set; }
    public int TownId { get; set; }
    public string Description { get; set; }
}
