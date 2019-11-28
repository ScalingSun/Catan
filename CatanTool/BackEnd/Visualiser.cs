using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd
{
    public class Visualiser
    {
        public string Data { get; set; }

        /// <summary>
        /// Draw all tiles onto a bitmap image.
        /// </summary>
        /// <returns>The map image as a string of bytes.</returns>
        public string DrawMap(IEnumerable<ITile> tiles)
        {
            Bitmap drawing = new Bitmap(1000, 1000);
            using (Graphics graphic = Graphics.FromImage(drawing))
            {
                graphic.Clear(Color.DarkCyan);
            }

            foreach (ITile tile in tiles)
            {
                DrawHex(tile, drawing);
            }

            return BitmapToByteString(drawing);
        }

        /// <summary>
        /// Draw a tile onto the map.
        /// </summary>
        /// <param name="tile">The tile that is being drawn.</param>
        /// <param name="drawing">The map the tile is being drawn on.</param>
        private void DrawHex(ITile tile, Bitmap drawing)
        {
            if (tile.Resource.TypeSort == EnumTypeSort.Sea)
            {

            }
            // Base points for a hexagon.
            Point[] hexagonPoints = new Point[]
                {
                    new Point(60, 0),
                    new Point(120, 30),
                    new Point(120, 105),
                    new Point(60, 135),
                    new Point(0, 105),
                    new Point(0, 30),
                    new Point(60, 0)
                };

            // Translation lengths for new hexagons
            const int xMove = 120;
            const int yMove = 105;

            // Change the starting point of the map according to an amount of pixels.
            hexagonPoints = ChangeMapStartPoint(10, drawing.Width / 2 - 2 * yMove, hexagonPoints);

            // Change position of where the hexagon will be drawn, according to a tile's coordinates.
            if (tile.Coordinate == null)
            {

            }
            hexagonPoints = ChangeHexagonPoint(tile.Coordinate.Yaxis, tile.Coordinate.Xaxis, yMove, xMove, hexagonPoints);

            // Set colour of the fill and lines.
            Brush fillColour = GetResourceBrush(tile.Resource.Type);
            Pen linePen = new Pen(Brushes.Black, 2f);

            // Draw the hexagon.
            using (Graphics graphic = Graphics.FromImage(drawing))
            {
                if (tile is HarbourTile)
                {
                    fillColour = GetResourceBrush(EnumType.Water);
                }

                graphic.FillPolygon(fillColour, hexagonPoints);
                graphic.DrawLines(linePen, hexagonPoints);

                // If the tile is a LandTile, draw a number on top of it.
                if (tile is LandTile landTile)
                {
                    if (landTile.Value == 7)
                    {
                        graphic.DrawString("", new Font("Arial", 20f, FontStyle.Bold), Brushes.Black, new Point(xMove / 2 + drawing.Width / 2 - 2 * yMove + xMove * tile.Coordinate.Xaxis - xMove / 2 * tile.Coordinate.Yaxis - 10, 10 + yMove / 2 + yMove * tile.Coordinate.Yaxis));
                    }
                    else
                    {
                        graphic.DrawString(landTile.Value.ToString(), new Font("Arial", 20f, FontStyle.Bold), Brushes.Black, new Point(xMove / 2 + drawing.Width / 2 - 2 * yMove + xMove * tile.Coordinate.Xaxis - xMove / 2 * tile.Coordinate.Yaxis - 10, 10 + yMove / 2 + yMove * tile.Coordinate.Yaxis));
                    }
                }

                if (tile is HarbourTile)
                {
                    fillColour = GetResourceBrush(tile.Resource.Type);
                    graphic.FillEllipse(fillColour, xMove / 2 + drawing.Width / 2 - 2 * yMove + xMove * tile.Coordinate.Xaxis - xMove / 2 * tile.Coordinate.Yaxis - 25, yMove / 2 + yMove * tile.Coordinate.Yaxis, 50, 50);
                    graphic.DrawEllipse(linePen, xMove / 2 + drawing.Width / 2 - 2 * yMove + xMove * tile.Coordinate.Xaxis - xMove / 2 * tile.Coordinate.Yaxis - 25, yMove / 2 + yMove * tile.Coordinate.Yaxis, 50, 50);
                }
            }
        }

        /// <summary>
        /// Change the position the hexagon is drawn at according to certain coordinates.
        /// </summary>
        /// <param name="y">The y coordinate the hexagon is drawn at.</param>
        /// <param name="x">The x coordinate the hexagon is drawn at.</param>
        /// <param name="yMove">The vertical length between hexagon tiles.</param>
        /// <param name="xMove">The horizontal length between hexagon tiles.</param>
        /// <param name="hexagonPoints">The base hexagon points.</param>
        /// <returns>The moved points of a hexagon.</returns>
        private Point[] ChangeHexagonPoint(int y, int x, int yMove, int xMove, Point[] hexagonPoints)
        {
            for (int i = 0; i < hexagonPoints.Length; i++)
            {
                hexagonPoints[i] = new Point(hexagonPoints[i].X + x * xMove - (xMove / 2 * y), hexagonPoints[i].Y + yMove * y);
            }

            return hexagonPoints;
        }

        /// <summary>
        /// Change the starting point of the map according to an amount of pixels
        /// </summary>
        /// <param name="yPixels">The vertical translation of the starting point.</param>
        /// <param name="xPixels">The horizontal translation of the starting point.</param>
        /// <param name="hexagonPoints">The base array of hexagon points.</param>
        /// <returns>The array of translated points of a hexagon.</returns>
        private Point[] ChangeMapStartPoint(int yPixels, int xPixels, Point[] hexagonPoints)
        {
            for (int i = 0; i < hexagonPoints.Length; i++)
            {
                hexagonPoints[i] = new Point(hexagonPoints[i].X + xPixels, hexagonPoints[i].Y + yPixels);
            }

            return hexagonPoints;
        }

        /// <summary>
        /// Convert a bitmap image to a string of bytes.
        /// </summary>
        /// <param name="bitmap">The image to be converted.</param>
        /// <returns>The image converted to a string of bytes.</returns>
        private string BitmapToByteString(Bitmap bitmap)
        {
            string data = "data:image/bmp;base64,";
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Bmp);
                byte[] byteData = stream.ToArray();
                data += Convert.ToBase64String(byteData);
            }
            return data;
        }

        /// <summary>
        /// Get the colour for a certain resource.
        /// </summary>
        /// <param name="resource">A resource that you need a colour of.</param>
        /// <returns>The colour that belongs to a resource.</returns>
        private Brush GetResourceBrush(EnumType resource)
        {
            if (resource == EnumType.Stone || resource == EnumType.TwoStoneHarbour)
            {
                return Brushes.SandyBrown;
            }
            if (resource == EnumType.Ore || resource == EnumType.TwoOreHarbour)
            {
                return Brushes.DarkGray;
            }
            if (resource == EnumType.Desert)
            {
                return Brushes.Khaki;
            }
            if (resource == EnumType.Wheat || resource == EnumType.TwoWheatHarbour)
            {
                return Brushes.Yellow;
            }
            if (resource == EnumType.Water)
            {
                return Brushes.LightSeaGreen;
            }
            if (resource == EnumType.Meadow || resource == EnumType.TwoMeadowHarbour)
            {
                return Brushes.LawnGreen;
            }
            if (resource == EnumType.Wood || resource == EnumType.TwoWoodHarbour)
            {
                return Brushes.DarkGreen;
            }

            return Brushes.Magenta;
        }
    }
}
