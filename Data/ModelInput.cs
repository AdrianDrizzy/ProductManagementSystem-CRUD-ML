using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ML.Data;

namespace finalML.Data
{
    public class ModelInput
    {
        [LoadColumn(0)] public float ProdIDA { get; set; }
        [LoadColumn(1)] public float ProdIDB { get; set; }
    }
}
