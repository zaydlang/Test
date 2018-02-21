using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using Nez.ConversionTypes;

namespace Nez.PipelineImporter.FufParticle
{
    public class FufParticleCreatorEmitterConfig
    {
        [JsonProperty("texture")]
        public string Texture { get; set; }

        [JsonProperty("launchAngle")]
        public ValueBounds<float> LaunchAngle { get; set; } = new ValueBounds<float>(270);

        [JsonProperty("particleAngle")]
        public ValueBounds<float> ParticleAngle { get; set; } = new ValueBounds<float>(0);

        [JsonProperty("color")]
        public StartEndValueBounds<ConversionTypeColor> Color { get; set; } =
            new StartEndValueBounds<ConversionTypeColor>(Microsoft.Xna.Framework.Color.White);

        [JsonProperty("alpha")]
        public StartEndValueBounds<float> Alpha { get; set; } = new StartEndValueBounds<float>(1.0f);

        [JsonProperty("life")]
        public ValueBounds<float> Life { get; set; } = new ValueBounds<float>(1.0f);

        [JsonProperty("scale")]
        public StartEndValueBounds<float> Scale { get; set; } = new StartEndValueBounds<float>(1.0f);

        [JsonProperty("offset")]
        public ValueBounds<ConversionTypeVector2> Offset { get; set; } = new ValueBounds<ConversionTypeVector2>();

        [JsonProperty("speed")]
        public ValueBounds<float> Speed { get; set; } = new ValueBounds<float>(100f);
    }
}