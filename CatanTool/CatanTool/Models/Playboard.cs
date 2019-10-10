using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatanTool.Models
{
    public class Playboard
    {
        public string Data { get; private set; }

        public Playboard(string data)
        {
            Data = data;
        }
    }
}
