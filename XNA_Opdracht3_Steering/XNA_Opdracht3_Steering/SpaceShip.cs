using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Opdracht3_Steering {
    class SpaceShip : SpriteGameObject {
        protected float mass;
        private Vector2 target;
        private float rotation;

        // add maxSteering, maxSpeed and arrivingRadius

        public SpaceShip(string assetName, Vector2 position, float scale, float maxSteering, float maxSpeed, float arrivingRadius, float mass)
            : base(assetName, 1, "spaceship") {
            this.layer = 2;
            this.position = position;
            this.velocity = Vector2.Zero;
            this.mass = mass;
            this.rotation = 0;
            this.origin = new Vector2(Width / 2, Height / 2);
        }

        public override void Update(GameTime gameTime) {
            // get target
            target = GameWorld.Find("target").Position;

            // calculate steering direction

            // arriving and stopping

            // apply rotation
            if (velocity != Vector2.Zero) {
                float angle = (float)Math.Atan2(velocity.Y, velocity.X);
                rotation = angle + (float)Math.PI / 2;
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            if (!visible || sprite == null)
                return;

            spriteBatch.Draw(sprite.Sprite, this.GlobalPosition, null, Color.White,
            rotation, origin, scale, SpriteEffects.None, 0.0f);
        }

        private Vector2 Truncate(Vector2 vector, float length) {
            if (vector.LengthSquared() > length * length) {
                vector.Normalize();
                vector *= length;
            }
            return vector;
        }
    }
}