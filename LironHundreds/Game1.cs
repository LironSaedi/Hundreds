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

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1600;
            graphics.PreferredBackBufferHeight = 900;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData(new Color[] { Color.White });

            background = new Sprite(new Vector2(0, 0), Color.White, Content.Load<Texture2D>("AlexBackground"));

            //create all ball objects

            //  background = new Sprite(Vector2.Zero), Color.White, )
            multipleBalls.Add(new Ball(Content.Load<Texture2D>("Alex the Pear(Better Version)"), new Vector2(0), Color.White, new Vector2(0.25f, 0.25f)));
            multipleBalls.Add(new Ball(Content.Load<Texture2D>("adult-apple-costume"), new Vector2(125), Color.White, new Vector2(0.25f, 0.25f), 0.18f));
            multipleBalls.Add(new Ball(Content.Load<Texture2D>("pineapple with Alex"), new Vector2(300), Color.White, new Vector2(0.20f, 0.20f), 0.75f));
            multipleBalls.Add(new Ball(Content.Load<Texture2D>("KiwiMan"), new Vector2(458), Color.White, new Vector2(0.25f, 0.25f), 0.75f));
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {

            for (int i = 0; i < multipleBalls.Count; i++)
            {
                multipleBalls[i].Update(gameTime, GraphicsDevice.Viewport);
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
                multipleBalls[i].Draw(spriteBatch);
            }
            //draw all ball objects

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
