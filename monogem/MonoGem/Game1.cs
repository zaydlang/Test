using MonoGem.Scenes;
using Nez.Fuf;

namespace MonoGem {
    public class Game1 : FufCore {
        public Game1() : base(width: 640, height: 480, windowTitle: "MonoGem") { }

        protected override void Initialize() {
            base.Initialize();

            scene = new Scene1();
        }
    }
}