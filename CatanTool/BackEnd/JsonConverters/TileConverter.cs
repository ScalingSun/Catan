using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public class TileConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(ITile));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            //sea
            if (jo["Coordinate"]["CoordinateType"].Value<int>() == (int)EnumCoordinateType.Sea)
                return jo.ToObject<WaterTile>(serializer);
            //land
            if (jo["Coordinate"]["CoordinateType"].Value<int>() == (int)EnumCoordinateType.Land)
                return jo.ToObject<LandTile>(serializer);
            //harbour
            if (jo["Coordinate"]["CoordinateType"].Value<int>() == (int)EnumCoordinateType.Harbour)
                return jo.ToObject<HarbourTile>(serializer);
            return null;
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
