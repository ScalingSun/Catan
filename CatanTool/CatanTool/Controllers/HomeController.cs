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
            List<ITile> tiles = new List<ITile>()
            {
                new WaterTile(0,0,EnumTileType.Sea), new HarbourTile(1,0,EnumTileType.TwoMeadowHarbour), new WaterTile(2,0,EnumTileType.Sea), new WaterTile(3,0,EnumTileType.Sea),
                new WaterTile(0,1,EnumTileType.Sea), new LandTile(1,1,EnumTileType.Wood, 2), new LandTile(2,1,EnumTileType.Wood, 2), new LandTile(3,1,EnumTileType.Meadow, 8), new WaterTile(4,1,EnumTileType.Sea)
            };

            Playboard pb = new Playboard(visualiser.DrawMap(tiles));
            
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
