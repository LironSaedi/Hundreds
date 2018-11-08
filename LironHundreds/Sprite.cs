using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LironHundreds
{
    class Sprite
    {
        public Vector2 Position;
        protected Color Tint;
        public Texture2D Texture;
        public float Scale = 1;

        public CircleCollider Hitbox; //CircleCollider here

        public Sprite(Vector2 position, Color tint, Texture2D texture)
        {
            this.Position = position;
            this.Texture = texture;
            this.Tint = tint;
        }

        public Sprite(Vector2 position, Color tint, Texture2D texture, float scale)
            : this(position, tint, texture)
        {
            this.Scale = scale;
        }

        public virtual void Draw(SpriteBatch batch)
        {
            batch.Draw(Texture, Position, null, Tint, 0, Vector2.Zero, Scale, SpriteEffects.None, 0);
        }

        public virtual void Draw(SpriteBatch batch, Rectangle bounds)
        {
            batch.Draw(Texture, bounds, Tint);
        }
    }
}
