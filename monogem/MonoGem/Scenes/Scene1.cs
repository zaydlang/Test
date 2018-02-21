using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Fuf.Physics;
using Nez.Fuf.Sprites;
using Nez.Fuf.UI;

namespace MonoGem.Scenes {
    public class Scene1 : Scene {
        public override void initialize() {
            base.initialize();

            addRenderer(new DefaultRenderer());

            clearColor = Color.DarkSlateBlue;

            var ball = createEntity("ball", new Vector2(200, 200));
            ball.addComponent<MetalBall>();

            var welcomeText = new TextComposer("welcome to fufnez", Graphics.instance.bitmapFont, 4f)
                .attach(this, new Vector2(20, 20), Color.White);
            
            var hintText = new TextComposer("try arrow keys", Graphics.instance.bitmapFont, 2f)
                .attach(this, new Vector2(20, 60), Color.LightBlue);
        }

        class MetalBall : FufSprite, IUpdatable {
            public MetalBall() : base(Core.content.Load<Texture2D>("Sprites/ball")) { }

            private float _moveAccel = 10f;
            private KinematicBody _body;

            public override void initialize() {
                base.initialize();

                _body = entity.addComponent<KinematicBody>();
                _body.maxVelocity = new Vector2(200, 200);
                _body.drag = new Vector2(80, 80);
            }

            public void update() {
                if (Input.isKeyDown(Keys.Down)) {
                    _body.velocity += new Vector2(0, _moveAccel);
                }

                if (Input.isKeyDown(Keys.Up)) {
                    _body.velocity += new Vector2(0, -_moveAccel);
                }

                if (Input.isKeyDown(Keys.Right)) {
                    _body.velocity += new Vector2(_moveAccel, 0);
                }

                if (Input.isKeyDown(Keys.Left)) {
                    _body.velocity += new Vector2(-_moveAccel, 0);
                }
            }
        }
    }
}