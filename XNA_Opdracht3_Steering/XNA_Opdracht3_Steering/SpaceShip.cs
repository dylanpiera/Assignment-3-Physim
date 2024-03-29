﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Opdracht3_Steering {
    internal class SpaceShip : SpriteGameObject {
        protected float mass;
        private Vector2 target;
        private float rotation;
        private float max_force = 10;
        private float max_speed = 250;
        private float slowing_radius = 300;

        // add maxSteering, maxSpeed and arrivingRadius

        public SpaceShip(string assetName, Vector2 position, float scale, float maxSteering, float maxSpeed, float arrivingRadius, float mass)
            : base(assetName, 1, "spaceship") {
            layer = 2;
            this.position = position;
            velocity = Vector2.Zero;
            this.mass = mass;
            rotation = 0;
            origin = new Vector2(Width / 2f, Height / 2f);
        }

        public override void Update(GameTime gameTime) {
            // get target
            target = GameWorld.Find("target").Position;

            // calculate steering direction
            Vector2 desired_velocity = target - position;
            if(desired_velocity.Length() < slowing_radius)
            {
                desired_velocity = desired_velocity * max_speed * (desired_velocity.Length() / slowing_radius);
            } else
            {
                desired_velocity *= max_speed;
            }

            Vector2 steering = desired_velocity - velocity;
            
            steering = Truncate(steering, max_force);
            steering = steering / mass;
            
            velocity = Truncate(velocity + steering, max_speed);

            //Console.Out.WriteLine("Velocity: "+velocity);

            // arriving and stopping

            // apply rotation
            if (velocity != Vector2.Zero) {
                var angle = (float)Math.Atan2(velocity.Y, velocity.X);
                rotation = angle + (float)Math.PI / 2;
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            if (!visible || sprite == null)
                return;

            spriteBatch.Draw(sprite.Sprite, GlobalPosition, null, Color.White,
            rotation, origin, scale, SpriteEffects.None, 0.0f);
        }

        private Vector2 Truncate(Vector2 vector, float length) {
            if (!(vector.LengthSquared() > length*length)) return vector;
            vector.Normalize();
            vector *= length;
            return vector;
        }
    }
}