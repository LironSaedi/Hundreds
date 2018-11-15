using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LironHundreds
{
    class Ball : Sprite
    {
        public Vector2 Speed;
        public int Score;
        public bool IsGrowing; //optional        

        //rectangle represents hitbox
        //rectnagle is a class: x, y, width, height



        public Ball(Texture2D image, Vector2 position, Color color, Vector2 speed)
            : base(position, color, image)
        {
            this.Speed = speed;
            Score = 0;
            IsGrowing = false;
            Hitbox = new CircleCollider(Texture.Width * Scale / 2, Position + new Vector2(Texture.Width * Scale / 2, Texture.Height * Scale / 2));
        }

        public Ball(Texture2D image, Vector2 position, Color color, Vector2 speed, float scale)
            : base(position, color, image, scale)
        {
            this.Speed = speed;
            Score = 0;
            IsGrowing = false;
            Hitbox = new CircleCollider(Texture.Width * Scale / 2, Position + new Vector2(Texture.Width * Scale / 2, Texture.Height * Scale / 2));
        }

        private void Grow()
        {
            Score++;
            Scale *= 1.01f;
            IsGrowing = true;
        }

        public void Update(GameTime time, Viewport port, MouseState ms)
        {
            IsGrowing = false;

            Position += Speed * time.ElapsedGameTime.Milliseconds;

            // HitBox.X = (int)this.position.X;
            //HitBox.Y = (int)this.position.Y;

            // = new CircleCollider(center position of object, width of the texture to act as the radius)
            Hitbox = new CircleCollider(Texture.Width * Scale / 2, Position + new Vector2(Texture.Width * Scale / 2, Texture.Height * Scale / 2));

            if (Hitbox.ContainsPoint(ms.X, ms.Y))
            {
                Grow();
            }
            
            if (Position.X < 0)
            {
                Speed.X = Math.Abs(Speed.X);
            }
            else if (Position.X + Texture.Width * Scale > port.Width)
            {
                Speed.X = -Math.Abs(Speed.X);
            }
            if (Position.Y < 0)
            {
                Speed.Y = Math.Abs(Speed.Y);
            }
            else if (Position.Y + Texture.Height * Scale > port.Height)
            {
                Speed.Y = -Math.Abs(Speed.Y);

            }
            if (IsGrowing)
            {
                Tint = Color.Red;
            }
            else
            {
                Tint = Color.White;
            }
        }

        public void Draw(SpriteBatch batch, SpriteFont font)
        {
            base.Draw(batch);

            //draw the score here
            //add half the image width (scaled) and half the image height (scaled)
            batch.DrawString(font, $"{Score}", Position + new Vector2(Texture.Width * Scale / 2, Texture.Height * Scale / 2), Color.Blue);
            
        }
    }
}
