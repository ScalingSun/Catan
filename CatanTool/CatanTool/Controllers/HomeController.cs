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
            List<ITile> result = new List<ITile>();
            result = map.tiles;
            Playboard pb = new Playboard(visualiser.DrawMap(result));
            
            return View(pb);
        }
        public IActionResult ABCmethod()
        {
            Visualiser visualiser = new Visualiser();
            Map map = new Map(EnumMapType.small);
            List<ITile> result = new List<ITile>();
            result.AddRange(map.createABCTiles());
            Playboard pb = new Playboard(visualiser.DrawMap(result));
            return View(pb);
        }
        public IActionResult OreForWoolMethod()
        {
            Visualiser visualiser = new Visualiser();
            Map map = new Map(EnumMapType.small);
            List<ITile> result = new List<ITile>();
            result.AddRange(map.createOreForWoolTiles());
            Playboard pb = new Playboard(visualiser.DrawMap(result));
            return View(pb);
        }
        public IActionResult BigMap()
        {
            Visualiser visualiser = new Visualiser();
            Map map = new Map(EnumMapType.big);
            List<ITile> result = new List<ITile>();
            result = map.tiles;
            Playboard pb = new Playboard(visualiser.DrawMap(result));

            return View(pb);
        }
    }
}
