using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public class Junction
    {
        public List<ITile> ThreeTiles { get; private set; }  
        public int Score { get; private set;
        }
        public Junction(List<ITile> ThreeTiles)
        {
            this.ThreeTiles = ThreeTiles;
            CalculateScore();
        }

        public void CalculateScore()
        {
            int totalScore = 0;
            
            foreach(ITile tile in ThreeTiles)
            {
                ILandTile landTile = tile as ILandTile;

                if (landTile == null)
                {
                    continue;
                }

                if (landTile.Value <= 6)
                {
                    totalScore += MapInt(landTile.Value, 2, 6, 1, 5);
                }
                else if (landTile.Value >= 8)
                {
                    totalScore += MapInt(landTile.Value, 8, 12, 5, 1);
                }
            }

            Score = totalScore;
        }

        private int MapInt(int value, int valueMinimum, int valueMaximum, int outMinimum, int outMaximum)
        {
            return (value - valueMinimum) * (outMaximum - outMinimum) / (valueMaximum - valueMinimum) + outMinimum;
        }

        public override string ToString()
        {
            string output = $"Junction score: {Score} (";

            foreach(ITile tile in ThreeTiles)
            {
                ILandTile landTile = tile as ILandTile;

                if (landTile == null)
                {
                    output += "Sea, ";
                    break;
                }

                output += $"{tile.Resource.Type.ToString()} {landTile.Value}, ";
            }

            output += ")";

            return output;
        }
    }
}
