using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Nez.ECS.Components.Renderables.Particles {
    public class FufParticleEmitter : RenderableComponent, IUpdatable {
        public override RectangleF bounds {
            get { return _bounds; }
        }

        private Vector2 rootPosition => entity.transform.position + _localOffset;
        private List<FufParticle> _particles;
        public FufParticleCreatorConfig emitterConfig;
        public bool emitting = true;
        public bool playing = false;
        public float frequency = 0;
        public bool simulateInWorldSpace = true;

        private float _emitCounter = 0;
        private int _maxParticles;

        public FufParticleEmitter(FufParticleCreatorConfig emitterConfig, int maxParticles = 200,
            bool startEmitting = true) {
            this.emitterConfig = emitterConfig;
            _particles = new List<FufParticle>(maxParticles);
            Pool<FufParticle>.warmCache(maxParticles);
            _maxParticles = maxParticles;
            emitting = startEmitting;

            emitterInit();
        }

        private void emitterInit() {
            var blendState = new BlendState();
            blendState.ColorSourceBlend = blendState.AlphaSourceBlend = Blend.SourceAlpha;
            blendState.ColorDestinationBlend = blendState.AlphaDestinationBlend = Blend.One;
            material = new Material(blendState);
        }

        public override void onAddedToEntity() {
            base.onAddedToEntity();
            if (emitting) {
                playing = true;
            }
        }

        public void play(float frequency = 20f) {
            playing = true;
            emitting = true;
            this.frequency = frequency;

            _emitCounter = 0;
        }

        public void stop() {
            playing = false;
            emitting = false;

            _emitCounter = 0;
        }

        public void pause() {
            emitting = false;
        }

        public void resume() {
            emitting = true;
        }

        public void emit(int count) {
            for (var i = 0; i < count; i++) {
                addParticle(rootPosition);
            }
        }

        public void update() {
            if (!playing) return;

            if (frequency > 0) {
                var emitTime = 1f / frequency;

                if (emitting) {
                    if (_particles.Count < _maxParticles) {
                        _emitCounter += Time.deltaTime;
                    }

                    while (_particles.Count < _maxParticles && _emitCounter > emitTime) {
                        addParticle(rootPosition);
                        _emitCounter -= emitTime;
                    }
                }
            }

            var boundsMin = new Vector2(float.MaxValue, float.MaxValue);
            var boundsMax = new Vector2(float.MinValue, float.MinValue);
            var maxParticleScale = 0f;

            // update particles
            for (var i = _particles.Count - 1; i >= 0; i--) {
                var particle = _particles[i];

                // if update is true, particle is done
                if (particle.update()) {
                    Pool<FufParticle>.free(particle);
                    _particles.RemoveAt(i);
                } else {
                    var pos = particle.position + (simulateInWorldSpace ? particle.spawnPosition : rootPosition);
                    Vector2.Min(ref boundsMin, ref pos, out boundsMin);
                    Vector2.Max(ref boundsMax, ref pos, out boundsMax);
                    maxParticleScale = Math.Max(maxParticleScale, particle.scale);
                }
            }

            _bounds.location = boundsMin;
            _bounds.width = boundsMax.X - boundsMin.X;
            _bounds.height = boundsMax.Y - boundsMin.Y;

            _bounds.inflate(emitterConfig.subtexture.sourceRect.Width * maxParticleScale,
                emitterConfig.subtexture.sourceRect.Height * maxParticleScale);
        }

        public override void render(Graphics graphics, Camera camera) {
            for (var i = 0; i < _particles.Count; i++) {
                var particle = _particles[i];
                var referencePosition = simulateInWorldSpace ? particle.spawnPosition : rootPosition;
                graphics.batcher.draw(emitterConfig.subtexture, referencePosition + particle.position, particle.color,
                    particle.rotation, emitterConfig.subtexture.center, particle.scale, SpriteEffects.None, layerDepth);
            }
        }

        protected void addParticle(Vector2 spawnPosition) {
            var particle = Pool<FufParticle>.obtain();
            particle.initialize(emitterConfig, spawnPosition);
            _particles.Add(particle);
        }
    }
}