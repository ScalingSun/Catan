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
        private Map map;
        public Visualiser(Map map)
        {
            this.map = map;
        }

        private readonly Point[] BaseHexagonPoints = new Point[]
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
        private readonly int xMove = 120;
        private readonly int yMove = 105;

        /// <summary>
        /// Draw all tiles onto a bitmap image.
        /// </summary>
        /// <returns>The map image as a string of bytes.</returns>
        public string DrawMap(int topJunctionAmount)
        {
            Bitmap drawing = new Bitmap(1025, 1000);
            using (Graphics graphic = Graphics.FromImage(drawing))
            {
                graphic.Clear(Color.DarkCyan);
            }

            foreach (ITile tile in map.tiles)
            {
                DrawHex(tile, drawing);
            }

            foreach(Junction junction in map.GetTopJunctions(topJunctionAmount))
            {
                DrawJunction(junction, drawing);
            }

            return BitmapToByteString(drawing);
        }

        private void DrawJunction(Junction junction, Bitmap drawing)
        {
            Point[] tile0Points = GetTileCoordinates(junction.ThreeTiles[0], drawing);
            Point[] tile1Points = GetTileCoordinates(junction.ThreeTiles[1], drawing);
            Point[] tile2Points = GetTileCoordinates(junction.ThreeTiles[2], drawing);

            foreach(Point point0 in tile0Points)
            {
                foreach (Point point1 in tile1Points)
                {
                    foreach (Point point2 in tile2Points)
                    {
                        if (point0.X == point1.X && point0.X == point2.X && point0.Y == point1.Y && point0.Y == point2.Y)
                        {
                            using (Graphics graphic = Graphics.FromImage(drawing))
                            {
                                graphic.FillEllipse(Brushes.White, point0.X - 10, point0.Y - 10, 20, 20);
                                graphic.DrawEllipse(new Pen(Color.Black, 2f), point0.X - 10, point0.Y - 10, 20, 20);
                            }
                        }
                    }
                }
            }
        }

        private Point[] GetTileCoordinates(ITile tile, Bitmap drawing)
        {
            Point[] hexagonPoints = new Point[]
            {
                new Point(60, 0),
                new Point(120, 30),
                new Point(120, 105),
                new Point(60, 135),
                new Point(0, 105),
                new Point(0, 30),
                new Point(60, 0)
            }; ;

            // Change the starting point of the map according to an amount of pixels.
            hexagonPoints = ChangeMapStartPoint(drawing.Height, drawing.Width, hexagonPoints);

            // Change position of where the hexagon will be drawn, according to a tile's coordinates.
            hexagonPoints = ChangeHexagonPoint(tile.Coordinate.Yaxis, tile.Coordinate.Xaxis, yMove, xMove, hexagonPoints);

            return hexagonPoints;
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

            // Change the starting point of the map according to an amount of pixels.
            hexagonPoints = ChangeMapStartPoint(drawing.Height, drawing.Width, hexagonPoints);

            // Change position of where the hexagon will be drawn, according to a tile's coordinates.
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
                    if (landTile.Value != 7)
                    {
                        graphic.DrawString(landTile.Value.ToString(), new Font("Arial", 20f, FontStyle.Bold), Brushes.Black, new Point(hexagonPoints[0].X - 10, hexagonPoints[1].Y - 10 + (hexagonPoints[2].Y - hexagonPoints[1].Y) / 2));
                    }
                }

                if (tile is HarbourTile)
                {
                    fillColour = GetResourceBrush(tile.Resource.Type);
                    int ellipseDiameter = 50; 
                    int ellipseX = hexagonPoints[0].X - ellipseDiameter/2;
                    int ellipseY = hexagonPoints[1].Y + (hexagonPoints[2].Y - hexagonPoints[1].Y) / 2 - ellipseDiameter / 2;

                    graphic.FillEllipse(fillColour, ellipseX, ellipseY, ellipseDiameter, ellipseDiameter);
                    graphic.DrawEllipse(linePen, ellipseX, ellipseY, ellipseDiameter, ellipseDiameter);

                    DrawHarbourLine(graphic, tile, xMove, yMove, hexagonPoints);
                }
            }
        }

        private void DrawHarbourLine(Graphics graphic, ITile tile, int xMove, int yMove, Point[] hexagonPoints)
        {
            Point[] linePoints = GetLinePoints(tile, hexagonPoints);
            
            graphic.DrawLine(new Pen(Color.White, 15f), linePoints[0], linePoints[1]);
        }

        private Point[] GetLinePoints(ITile tile, Point[] hexagonPoints)
        {
            Point[] points = new Point[2];

            if (tile.Coordinate.Direction == EnumHarbourDirection.topright)
            {
                points[0] = hexagonPoints[0];
                points[1] = hexagonPoints[1];
            }
            if (tile.Coordinate.Direction == EnumHarbourDirection.right)
            {
                points[0] = hexagonPoints[1];
                points[1] = hexagonPoints[2];
            }
            if (tile.Coordinate.Direction == EnumHarbourDirection.downright)
            {
                points[0] = hexagonPoints[2];
                points[1] = hexagonPoints[3];
            }
            if (tile.Coordinate.Direction == EnumHarbourDirection.downleft)
            {
                points[0] = hexagonPoints[3];
                points[1] = hexagonPoints[4];
            }
            if (tile.Coordinate.Direction == EnumHarbourDirection.left)
            {
                points[0] = hexagonPoints[4];
                points[1] = hexagonPoints[5];
            }
            if (tile.Coordinate.Direction == EnumHarbourDirection.topleft)
            {
                points[0] = hexagonPoints[5];
                points[1] = hexagonPoints[6];
            }
            return points;
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
        private Point[] ChangeMapStartPoint(int graphicsHeight, int graphicsWidth, Point[] hexagonPoints)
        {
            int yDistance = hexagonPoints[4].Y - hexagonPoints[0].Y;
            int xPixels = 0;
            int yPixels = 0;

            if (map.maptype == EnumMapType.small)
            {
                xPixels = graphicsWidth - xMove * 7;
                yPixels = graphicsHeight - yDistance * 7;
            }
            else if (map.maptype == EnumMapType.big)
            {
                xPixels = graphicsWidth - xMove * 8;
                yPixels = graphicsHeight - yDistance * 9;
            }

            xPixels += xPixels / 2;
            yPixels -= yPixels / 2 + hexagonPoints[1].Y;

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
