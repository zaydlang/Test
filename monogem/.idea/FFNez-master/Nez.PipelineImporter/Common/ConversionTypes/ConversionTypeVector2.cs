using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;


namespace Nez.ConversionTypes
{
    public class ConversionTypeVector2
    {
        [XmlAttribute] [JsonProperty] public float x;

        [XmlAttribute] [JsonProperty] public float y;


        public static implicit operator Vector2(ConversionTypeVector2 pdvec)
        {
            return new Vector2(pdvec.x, pdvec.y);
        }
    }
}