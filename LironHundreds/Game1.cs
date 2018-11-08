using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace LironHundreds
{
    public class Game1 : Game
    {

        public static Texture2D pixel;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        List<Ball> multipleBalls = new List<Ball>();
        SpriteFont scoreFont;
        Sprite background;
        Random random = new Random();
        int totalScore = 0;
        Vector2 tempSpeed;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
        }

        protected override void Initialize()
        {
            base.Initialize();
            IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData(new Color[] { Color.White });

            background = new Sprite(new Vector2(0, 0), Color.White, Content.Load<Texture2D>("AlexBackground"));

            //create all ball objects

            //  background = new Sprite(Vector2.Zero), Color.White, )
            multipleBalls.Add(new Ball(Content.Load<Texture2D>("Alex the Pear(Better Version)"), new Vector2(865), Color.White, new Vector2(0.25f, 0.25f)));
            multipleBalls.Add(new Ball(Content.Load<Texture2D>("adult-apple-costume"), new Vector2(1500), Color.White, new Vector2(0.25f, 0.25f), 0.05f));
            multipleBalls.Add(new Ball(Content.Load<Texture2D>("pineapple with Alex"), new Vector2(254), Color.White, new Vector2(0.20f, 0.20f), 0.50f));
            multipleBalls.Add(new Ball(Content.Load<Texture2D>("KiwiMan"), new Vector2(458), Color.White, new Vector2(0.5f, 0.5f), 0.75f));
            multipleBalls.Add(new Ball(Content.Load<Texture2D>("halloween__adult-annoying-orange-costume"), new Vector2(100), Color.White, new Vector2(1, 1), 0.0755f));
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            //update positions
            for (int i = 0; i < multipleBalls.Count; i++)
            {
                multipleBalls[i].Update(gameTime, GraphicsDevice.Viewport);
            }

            //check collisions
            for (int i = 0; i < multipleBalls.Count; i++)
            {
                for (int j = i + 1; j < multipleBalls.Count; j++)
                {
                    if (multipleBalls[j].Hitbox.Intersects(multipleBalls[i].Hitbox))
                    {


                        tempSpeed = multipleBalls[i].Speed;

                        multipleBalls[i].Speed = multipleBalls[j].Speed;
                        multipleBalls[j].Speed = tempSpeed;


                    }
                }
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            background.Draw(spriteBatch, GraphicsDevice.Viewport.Bounds);
            for (int i = 0; i < multipleBalls.Count; i++)
            {
                multipleBalls[i].DrawHitbox(spriteBatch, createCircleText((int)(multipleBalls[i].Hitbox.Radius * multipleBalls[i].Scale)));
            }
            //draw all ball objects

            spriteBatch.End();
            base.Draw(gameTime);
        }

        //Magic Code By Ryan
        Texture2D createCircleText(int radius)
        {
            Texture2D texture = new Texture2D(GraphicsDevice, radius, radius);
            Color[] colorData = new Color[radius * radius];

            float diam = radius / 2f;
            float diamsq = diam * diam;

            for (int x = 0; x < radius; x++)
            {
                for (int y = 0; y < radius; y++)
                {
                    int index = x * radius + y;
                    Vector2 pos = new Vector2(x - diam, y - diam);
                    if (pos.LengthSquared() <= diamsq)
                    {
                        colorData[index] = Color.White;
                    }
                    else
                    {
                        colorData[index] = Color.Transparent;
                    }
                }
            }

            texture.SetData(colorData);
            return texture;
        }
    }
}
