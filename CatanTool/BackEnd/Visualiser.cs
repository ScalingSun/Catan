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
            hexagonPoints = ChangeHexagonPoint(tile.Yaxis, tile.Xaxis, yMove, xMove, hexagonPoints);

            // Set colour of the fill and lines.
            Brush fillColour = GetResourceBrush(tile.Resource);
            Pen linePen = new Pen(Brushes.Black, 2f);

            // Draw the hexagon.
            using (Graphics graphic = Graphics.FromImage(drawing))
            {
                graphic.FillPolygon(fillColour, hexagonPoints);
                graphic.DrawLines(linePen, hexagonPoints);

                if (tile is LandTile landTile)
                {
                    graphic.DrawString(landTile.Value.ToString(), new Font("Arial", 20f, FontStyle.Bold), Brushes.Black, new Point(xMove / 2 + drawing.Width / 2 - 2 * yMove + xMove * tile.Xaxis - xMove / 2 * tile.Yaxis - 10, 10 + yMove / 2 + yMove * tile.Yaxis));
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
        private Brush GetResourceBrush(EnumTileType resource)
        {
            if (resource == EnumTileType.Stone)
            {
                return Brushes.SandyBrown;
            }
            if (resource == EnumTileType.Ore)
            {
                return Brushes.DarkGray;
            }
            if (resource == EnumTileType.Desert)
            {
                return Brushes.LightSalmon;
            }
            if (resource == EnumTileType.Wheat)
            {
                return Brushes.Yellow;
            }
            if (resource == EnumTileType.Sea)
            {
                return Brushes.Cyan;
            }
            if (resource == EnumTileType.Meadow)
            {
                return Brushes.LawnGreen;
            }
            if (resource == EnumTileType.Wood)
            {
                return Brushes.DarkGreen;
            }

            return Brushes.Magenta;
        }
    }
}
