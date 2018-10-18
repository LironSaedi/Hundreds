using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        public Ball(Texture2D image, Vector2 position, Color color, Vector2 speed)
            : base(position, color, image)
        {
            this.Speed = speed;
            Score = 0;
            IsGrowing = false;
        }

        public Ball(Texture2D image, Vector2 position, Color color, Vector2 speed, float scale)
            : base(position, color, image, scale)
        {
            this.Speed = speed;
            Score = 0;
            IsGrowing = false;
        }

        public void Update(GameTime time, Viewport port)
        {
            Position += Speed * time.ElapsedGameTime.Milliseconds;

            //HitBox.X = (int)this.position.X;
            //HitBox.Y = (int)this.position.Y;

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
            base.Draw(batch); //draws the ball
            //draw the score here
        }

    }
}
