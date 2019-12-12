using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CatanTool.Models;
using BackEnd;
//using Microsoft.AspNetCore.Mvc.NewtonsoftJson
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System;

namespace CatanTool.Controllers
{
    public class HomeController : Controller
    {
        private int topJunctionAmount = 3;

        public IActionResult Index()
        {
            Visualiser visualiser = new Visualiser();
            Map map = new Map(EnumMapType.small);
            map.FindAllJunctions();

            Playboard pb = new Playboard(visualiser.DrawMap(map.tiles), map.GetTopJunctions(topJunctionAmount));
            List<ITile> result = map.tiles;
            Playboard pb = new Playboard(visualiser.DrawMap(result));
            var obj = result;
            //var serializer = new JsonSerializer();
            //serializer.Serialize(new JsonTextWriter(new StringWriter()), obj);
            //serializer.ContractResolver.
            var json = JsonConvert.SerializeObject(obj);
            //var json = new WebClient().DownloadString("url");
            //System.IO.File.WriteAllText(@"C:\Users\Mike\Documents\test\oof.json", json);
            ViewBag.ExportJsonString = json;
            return View(pb);
        }

        public IActionResult bruh()
        {
            Map map = new Map(EnumMapType.small);
            List<ITile> result = new List<ITile>();
            result = map.tiles;
            var obj = result;
            string json = JsonConvert.SerializeObject(obj);
            //System.IO.File.WriteAllText(@"C:\Users\Mike\Documents\test\oof.json", json);
            //return View("Index");
            // Create a string array with the lines of text
            //string[] lines = { json };

            //// Set a variable to the Documents path.
            //string docPath =
            //  Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            //// Write the string array to a new file named "WriteLines.txt".
            //using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "ooF.txt")))
            //{
            //    foreach (string line in lines)
            //        outputFile.WriteLine(line);
            //}
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter writer = new StreamWriter(Path.Combine(docPath, "ooF.txt")))
            {
                writer.Write(json);
            }
            return View("Index");
        }

        public IActionResult ABCmethod()
        {
            Visualiser visualiser = new Visualiser();
            Map map = new Map(EnumMapType.small);
            map.tiles = map.createABCTiles();
            map.FindAllJunctions();

            Playboard pb = new Playboard(visualiser.DrawMap(map.tiles), map.GetTopJunctions(topJunctionAmount));

            return View("Index", pb);
        }
        public IActionResult OreForWoolMethod()
        {
            Visualiser visualiser = new Visualiser();
            Map map = new Map(EnumMapType.small);
            map.tiles = map.createOreForWoolTiles();
            map.FindAllJunctions();

            Playboard pb = new Playboard(visualiser.DrawMap(map.tiles), map.GetTopJunctions(topJunctionAmount));

            return View("Index", pb);
        }
        public IActionResult BigMap()
        {
            Visualiser visualiser = new Visualiser();
            Map map = new Map(EnumMapType.big);
            map.FindAllJunctions();

            Playboard pb = new Playboard(visualiser.DrawMap(map.tiles), map.GetTopJunctions(topJunctionAmount));

            return View("Index", pb);
        }
    }
}
