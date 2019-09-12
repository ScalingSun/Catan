using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CatanTool.Models;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace CatanTool.Controllers
{
    public class HomeController : Controller
    {
        public Point[] ChangeHexagonPoint(int xMove, int yMove, Point[] original)
        {
            for (int i=0; i<original.Length; i++)
            {
                original[i] = new Point(original[i].X + xMove, original[i].Y + yMove);
            }

            return original;
        }

        public IActionResult Index()
        {
            Bitmap drawing = new Bitmap(1000, 1000);
            using (Graphics graphic = Graphics.FromImage(drawing))
            {
                graphic.Clear(Color.Azure);

                Pen linePen = new Pen(Brushes.Black, 2f);

                Point[] hexagonTemplate = new Point[]
                {
                    new Point(80, 0),
                    new Point(160, 40),
                    new Point(160, 140),
                    new Point(80, 180),
                    new Point(0, 140),
                    new Point(0, 40),
                    new Point(80, 0)
                };

                Point[] points = hexagonTemplate;
                points = ChangeHexagonPoint(200, 10, points);

                for (int i=0; i<4; i++)
                {
                    graphic.DrawLines(linePen, hexagonTemplate);
                    points = ChangeHexagonPoint(160, 0, points);
                }
                points = ChangeHexagonPoint(-160 * 4 -80, 140, points);
                for (int i=0; i<5; i++)
                {
                    graphic.DrawLines(linePen, hexagonTemplate);
                    points = ChangeHexagonPoint(160, 0, points);
                }
            }

            string data = "data:image/bmp;base64,";
            using (MemoryStream stream = new MemoryStream())
            {
                drawing.Save(stream, ImageFormat.Bmp);
                byte[] byteData = stream.ToArray();
                data += Convert.ToBase64String(byteData);
            }

            PlayBoard pb = new PlayBoard();
            pb.Data = data;

            return View(pb);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
