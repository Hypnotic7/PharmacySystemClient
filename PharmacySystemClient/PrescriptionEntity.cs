﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystemClient
{
    class PrescriptionEntity
    {
        public string PrescriptionId { get; set; }
        public string CustomerName { get; set; }
        public string GpName { get; set; }
        public string Products { get; set; }
    }
}
