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
using BackEnd;

namespace CatanTool.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            Visualiser visualiser = new Visualiser();
            Map map = new Map(EnumMapType.small);
            //List<ITile> tiles = map.createtiles(EnumMapType.small);
            /*
            List<ITile> tiles = map.CreateHarbourTiles();
            tiles.AddRange(map.CreateSeaTiles());*/
            List<ITile> result = new List<ITile>();
            result = map.tiles;
            Playboard pb = new Playboard(visualiser.DrawMap(result));
            
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
