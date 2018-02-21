using System.IO;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;

namespace Nez.PipelineImporter.FufParticle
{
    [ContentProcessor(DisplayName = "Fuf Particle Importer")]
    public class
        FufParticleCreatorProcessor : ContentProcessor<FufParticleCreatorContent, FufParticleEmitterProcessorResult>
    {
        public static ContentBuildLogger logger;

        public override FufParticleEmitterProcessorResult Process(FufParticleCreatorContent input,
            ContentProcessorContext context)
        {
            logger = context.Logger;
            var result = new FufParticleEmitterProcessorResult();

            // load texture
            if (input.emitterConfig.Texture == null)
                throw new InvalidContentException("'texture' property of emitter configuration was not found.");

            var fileDir = Path.GetDirectoryName(input.path);
            var fullPath = Path.Combine(fileDir, input.emitterConfig.Texture);
            context.Logger.LogMessage("Looking for texture file at {0}", fullPath);
            result.texture =
                context.BuildAndLoadAsset<string, Texture2DContent>(new ExternalReference<string>(fullPath),
                    "TextureProcessor");
            context.Logger.LogMessage("Texture file loaded.");

            result.emitterConfig = input.emitterConfig;

            return result;
        }
    }
}