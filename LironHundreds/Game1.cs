using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace LironHundreds
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        List<Ball> multipleBalls = new List<Ball>();
        SpriteFont scoreFont;
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


            //create all ball objects


            multipleBalls.Add(new Ball(Content.Load<Texture2D>("Alex the Pear(Better Version)"), new Vector2(0), Color.White, new Vector2(3, 3)));
            multipleBalls.Add(new Ball(Content.Load<Texture2D>("adult-apple-costume"), new Vector2(125), Color.White, new Vector2(3, 3), 0.18f));
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {

            for (int i = 0; i < multipleBalls.Count; i++)
            {
                //multipleBalls[i].Update(gameTime, GraphicsDevice.Viewport);
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
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
