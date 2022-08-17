using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Data
{
    public class ModelInput
    {
        [LoadColumn(0)] public float ProdIDA { get; set; }
        [LoadColumn(1)] public float ProdIDB { get; set; }
    }
}
