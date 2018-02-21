using Microsoft.Xna.Framework.Content.Pipeline;

namespace Nez.PipelineImporter.FufParticle
{
    public class FufParticleCreatorContent
    {
        public ContentImporterContext context;
        public FufParticleCreatorEmitterConfig emitterConfig;
        public string path;

        public FufParticleCreatorContent(ContentImporterContext context, FufParticleCreatorEmitterConfig emitterConfig,
            string path)
        {
            this.context = context;
            this.emitterConfig = emitterConfig;
            this.path = path;
        }
    }
}