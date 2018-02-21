using System;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using Nez.ECS.Components.Renderables.Particles;
using Nez.PipelineRuntime.FufParticleCreator;

namespace Nez.PipelineImporter.FufParticle
{
    [ContentTypeWriter]
    public class FufParticleCreatorWriter : ContentTypeWriter<FufParticleEmitterProcessorResult>
    {
        protected override void Write(ContentWriter writer, FufParticleEmitterProcessorResult value)
        {
            try
            {
                FufParticleCreatorProcessor.logger.LogMessage("Writing out FufParticleCreator asset");
                
                writer.Write(value.emitterConfig.LaunchAngle.min);
                writer.Write(value.emitterConfig.LaunchAngle.max);
            
                writer.Write(value.emitterConfig.Speed.min);
                writer.Write(value.emitterConfig.Speed.max);
            
                writer.Write(value.emitterConfig.Life.min);
                writer.Write(value.emitterConfig.Life.max);
                
                writer.Write(value.emitterConfig.Color.start.min);
                writer.Write(value.emitterConfig.Color.start.max);
                writer.Write(value.emitterConfig.Color.end.min);
                writer.Write(value.emitterConfig.Color.end.max);
            
                writer.Write(value.emitterConfig.Alpha.start.min);
                writer.Write(value.emitterConfig.Alpha.start.min);
                writer.Write(value.emitterConfig.Alpha.end.min);
                writer.Write(value.emitterConfig.Alpha.end.max);
            
                writer.Write(value.emitterConfig.Scale.start.min);
                writer.Write(value.emitterConfig.Scale.start.min);
                writer.Write(value.emitterConfig.Scale.end.min);
                writer.Write(value.emitterConfig.Scale.end.max);
                
                writer.Write(value.emitterConfig.Offset.min);
                writer.Write(value.emitterConfig.Offset.max);
            
                writer.Write(value.emitterConfig.ParticleAngle.min);
                writer.Write(value.emitterConfig.ParticleAngle.max);
                
                // write out texture data
                FufParticleCreatorProcessor.logger.LogMessage($"Writing texture: {value.texture}");
                writer.WriteObject(value.texture);
            }
            catch (NullReferenceException e)
            {
                FufParticleCreatorProcessor.logger.LogImportantMessage(e.ToString());
                throw;
            }
        }
        
        public override string GetRuntimeType(TargetPlatform targetPlatform)
        {
            return typeof(FufParticleCreatorConfig).AssemblyQualifiedName;
        }
        
        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            // This is the full namespace path and class name of the reader, along with the assembly name which is the project name by default.
            return typeof(FufParticleCreatorConfigReader).AssemblyQualifiedName;
        }
    }
}