using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using System;

namespace Opdracht3_Steering {
    class Target : SpriteGameObject {


        public Target(string assetName, Vector2 position, float scale)
            : base(assetName, 1, "target") {
            this.position = position;
            this.origin = new Vector2(Width / 2, Height / 2);
            this.scale = scale;
        }

        public override void HandleInput(InputHelper inputHelper) {
            if (inputHelper.MouseLeftButtonPressed()) {
                position = inputHelper.MousePosition;
            }

            base.HandleInput(inputHelper);
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);
        }
    }
}