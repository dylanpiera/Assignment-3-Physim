using Microsoft.Xna.Framework;
using System;

namespace Opdracht3_Steering {
    class PlayingState : GameObjectList {
        public PlayingState()
            : base() {
            SpriteGameObject background = new SpriteGameObject("blue_stars");
            this.Add(background);

            Target ball = new Target("PurpleSoftColorBall", new Vector2(600, 400), 0.5f);
            this.Add(ball);

            SpaceShip ship = new SpaceShip("blueship3", new Vector2(600, 400), 1f, 0.2f, 7f, 150f, 1f);
            this.Add(ship);
        }

        public override void Update(GameTime gameTime) {
            base.Update(gameTime);
        }
    }
}