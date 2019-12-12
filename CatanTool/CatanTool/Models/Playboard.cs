using BackEnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatanTool.Models
{
    public class Playboard
    {
        public string Data { get; private set; }
        public IReadOnlyList<Junction> TopJunctions { get; }

        public Playboard(string data, IReadOnlyList<Junction> topJunctions)
        {
            Data = data;
            TopJunctions = topJunctions;
        }
    }
}
