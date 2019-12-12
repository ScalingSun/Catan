using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd
{
    public class TileTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(TileType));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            //sea
            if (jo["Resource"]["TypeSort"].Value<int>() == (int)EnumCoordinateType.Sea)
                return jo.ToObject<WaterTileType>(serializer);
            //land
            if (jo["Resource"]["TypeSort"].Value<int>() == (int)EnumCoordinateType.Land)
                return jo.ToObject<LandTileType>(serializer);
            //harbour
            if (jo["Resource"]["TypeSort"].Value<int>() == (int)EnumCoordinateType.Harbour)
                return jo.ToObject<HarbourTileType>(serializer);

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
