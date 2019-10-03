using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CatanTool.Models
{
    public enum TEMPResourceEnum
    {
        Desert = -2,
        Ocean = -1,
        Clay = 0,
        Coal = 1,
        Wood = 2,
        Grain = 3,
        Sheep = 4
    }

    public class Visualiser
    {
        public string Data { get; set; }

        // Test list of tiles for visualiser.
        private List<Tile> Tiles = new List<Tile>
        {
            new Tile(0,0, TEMPResourceEnum.Ocean), new Tile(0,1, TEMPResourceEnum.Ocean),
            new Tile(0,2, TEMPResourceEnum.Ocean), new Tile(0,3, TEMPResourceEnum.Ocean),

            new Tile(1,0, TEMPResourceEnum.Ocean),
            new Tile(1,1), new Tile(1,2), new Tile(1,3),
            new Tile(1,4, TEMPResourceEnum.Ocean),

            new Tile(2,0, TEMPResourceEnum.Ocean),
            new Tile(2,1), new Tile(2,2), new Tile(2,3), new Tile(2,4),
            new Tile(2,5, TEMPResourceEnum.Ocean),

            new Tile(3,0, TEMPResourceEnum.Ocean),
            new Tile(3,1), new Tile(3,2), new Tile(3,3, TEMPResourceEnum.Desert), new Tile(3,4), new Tile(3,5),
            new Tile(3,6, TEMPResourceEnum.Ocean),

            new Tile(4,1, TEMPResourceEnum.Ocean),
            new Tile(4,2), new Tile(4,3), new Tile(4,4), new Tile(4,5),
            new Tile(4,6, TEMPResourceEnum.Ocean),

            new Tile(5,2, TEMPResourceEnum.Ocean),
            new Tile(5,3), new Tile(5,4), new Tile(5,5),
            new Tile(5,6, TEMPResourceEnum.Ocean),

            new Tile(6,3, TEMPResourceEnum.Ocean), new Tile(6,4, TEMPResourceEnum.Ocean),
            new Tile(6,5, TEMPResourceEnum.Ocean), new Tile(6,6, TEMPResourceEnum.Ocean)
        };

        /// <summary>
        /// Draw all tiles onto a bitmap image.
        /// </summary>
        /// <returns>The map image as a string of bytes.</returns>
        public string DrawMap()
        {
            Bitmap drawing = new Bitmap(1000, 1000);
            using (Graphics graphic = Graphics.FromImage(drawing))
            {
                graphic.Clear(Color.DarkCyan);
            }

            foreach (Tile tile in Tiles)
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
        private void DrawHex(Tile tile, Bitmap drawing)
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
            hexagonPoints = ChangeHexagonPoint(tile.Y, tile.X, yMove, xMove, hexagonPoints);

            // Set colour of the fill and lines.
            Brush fillColour = TEMPGetResourceBrush(tile.Resource);
            Pen linePen = new Pen(Brushes.Black, 2f);

            // Draw the hexagon.
            using (Graphics graphic = Graphics.FromImage(drawing))
            {
                graphic.FillPolygon(fillColour, hexagonPoints);
                graphic.DrawLines(linePen, hexagonPoints);
                graphic.DrawString(tile.Value.ToString(), new Font("Arial", 20f, FontStyle.Bold), Brushes.Black, new Point(xMove / 2 + drawing.Width / 2 - 2 * yMove + xMove * tile.X - xMove / 2 * tile.Y - 10, 10 + yMove / 2 + yMove * tile.Y));
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

        // THIS METHOD IS ONLY FOR THE VISUAL DEMONSTRATION.
        // Remove this when tiles are being generated properly.
        private Brush TEMPGetResourceBrush(TEMPResourceEnum resource)
        {
            if (resource == TEMPResourceEnum.Clay)
            {
                return Brushes.SandyBrown;
            }
            if (resource == TEMPResourceEnum.Coal)
            {
                return Brushes.DarkGray;
            }
            if (resource == TEMPResourceEnum.Desert)
            {
                return Brushes.LightSalmon;
            }
            if (resource == TEMPResourceEnum.Grain)
            {
                return Brushes.Yellow;
            }
            if (resource == TEMPResourceEnum.Ocean)
            {
                return Brushes.Cyan;
            }
            if (resource == TEMPResourceEnum.Sheep)
            {
                return Brushes.LawnGreen;
            }
            if (resource == TEMPResourceEnum.Wood)
            {
                return Brushes.DarkGreen;
            }

            return Brushes.Magenta;
        }
    }
}
