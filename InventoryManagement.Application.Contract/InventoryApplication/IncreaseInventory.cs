﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Contract.InventoryApplication
{
    public class IncreaseInventory
    {
        public long InventoryId { get; set; }
        public long Count { get; set; }
        public string Descreption { get; set; }
    }
}
