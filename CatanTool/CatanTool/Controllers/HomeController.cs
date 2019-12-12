using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CatanTool.Models;
using BackEnd;
//using Microsoft.AspNetCore.Mvc.NewtonsoftJson
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System;
using Microsoft.AspNetCore.Http;

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
            //var obj = result;
            //var serializer = new JsonSerializer();
            //serializer.Serialize(new JsonTextWriter(new StringWriter()), obj);
            //serializer.ContractResolver.
            //var indented = Formatting.Indented;
            //var settings = new JsonSerializerSettings()
            //{
            //    TypeNameHandling = TypeNameHandling.All
            //};
            //var json = JsonConvert.SerializeObject(obj, indented, settings);

            //var json = new WebClient().DownloadString("url");
            //System.IO.File.WriteAllText(@"C:\Users\Mike\Documents\test\oof.json", json);
            var json = JsonConvert.SerializeObject(result);
            ViewBag.ExportJsonString = json;
            return View(pb);
        }

        //public IActionResult ImportMap()
        //{
            
        //}

        public IActionResult ImportMap()
        {
            
            return View("Index");
        }

        [HttpPost]
        public ActionResult ImportData()
        {

            Map map = new Map(EnumMapType.small);
            map.FindAllJunctions();

            var files = Request.Form.Files;

            string fileContent = null;

            using (var reader = new StreamReader(files[0].OpenReadStream()))
            {
                fileContent = reader.ReadToEnd();
            }
            string result = JsonConvert.DeserializeObject(fileContent).ToString();

            JsonConverter[] converters = { new TileConverter(), new TileTypeConverter() };
            
            List<ITile> importedTiles = JsonConvert.DeserializeObject<List<ITile>>(result, new JsonSerializerSettings() { Converters = converters });

            Visualiser visualiser = new Visualiser();
            Playboard pb = new Playboard(visualiser.DrawMap(importedTiles), map.GetTopJunctions(topJunctionAmount));

            return View("Index", pb);
        }

        public IActionResult ABCmethod()
        {
            Visualiser visualiser = new Visualiser();
            Map map = new Map(EnumMapType.small);
            map.tiles = map.createABCTiles();
            map.FindAllJunctions();

            Playboard pb = new Playboard(visualiser.DrawMap(map.tiles), map.GetTopJunctions(topJunctionAmount));

            var json = JsonConvert.SerializeObject(map.tiles);
            ViewBag.ExportJsonString = json;

            return View("Index", pb);
        }
        public IActionResult OreForWoolMethod()
        {
            Visualiser visualiser = new Visualiser();
            Map map = new Map(EnumMapType.small);
            map.tiles = map.createOreForWoolTiles();
            map.FindAllJunctions();

            Playboard pb = new Playboard(visualiser.DrawMap(map.tiles), map.GetTopJunctions(topJunctionAmount));

            var json = JsonConvert.SerializeObject(map.tiles);
            ViewBag.ExportJsonString = json;

            return View("Index", pb);
        }
        public IActionResult BigMap()
        {
            Visualiser visualiser = new Visualiser();
            Map map = new Map(EnumMapType.big);
            map.FindAllJunctions();

            Playboard pb = new Playboard(visualiser.DrawMap(map.tiles), map.GetTopJunctions(topJunctionAmount));

            var json = JsonConvert.SerializeObject(map.tiles);
            ViewBag.ExportJsonString = json;

            return View("Index", pb);
        }
    }
}
