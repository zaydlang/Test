using System;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;


namespace Nez.ConversionTypes
{
    public class ConversionTypeColor
    {
        [XmlAttribute] [JsonProperty] public float red;

        [XmlAttribute] [JsonProperty] public float green;

        [XmlAttribute] [JsonProperty] public float blue;

        [XmlAttribute] [JsonProperty] public float alpha;


        public static implicit operator Color(ConversionTypeColor obj)
        {
            return new Color(obj.red, obj.green, obj.blue, obj.alpha);
        }

        public static implicit operator ConversionTypeColor(Color obj)
        {
            return new ConversionTypeColor()
            {
                red = obj.R,
                green = obj.G,
                blue = obj.B,
                alpha = obj.A
            };
        }
    }
}