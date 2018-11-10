using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace LironHundreds
{
    public class Game1 : Game
    {
        Random gen = new Random();


        public static Texture2D pixel;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        List<Ball> multipleBalls = new List<Ball>();
        SpriteFont scoreFont;
        Sprite background;
        Random random = new Random();
        int totalScore = 0;
        Vector2 tempSpeed;
        bool paused = false;

        Rectangle Screen;


        //create array of images

        Texture2D[] ballImages = new Texture2D[5];

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
            Screen = GraphicsDevice.Viewport.Bounds;
            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData(new Color[] { Color.White });

            background = new Sprite(new Vector2(0, 0), Color.White, Content.Load<Texture2D>("AlexBackground"));

            ballImages[0] = Content.Load<Texture2D>("Alex the Pear(Better Version)");
            ballImages[1] = Content.Load<Texture2D>("adult-apple-costume");
            ballImages[2] = Content.Load<Texture2D>("pineapple with Alex");
            ballImages[3] = Content.Load<Texture2D>("KiwiMan");
            ballImages[4] = Content.Load<Texture2D>("halloween__adult-annoying-orange-costume");

            SpawnBalls(5);


        }

        public void SpawnBalls(int numberOfBalls)
        {
            multipleBalls.Clear();
           
            //for loop that runs numberOfBalls many times
            //add a random ball, with a random image from the ballImages array
            for (int i = 0; i < numberOfBalls; i++)
            {
                int num = gen.Next(ballImages.Length);
                multipleBalls.Add(new Ball(ballImages[num], new Vector2(gen.Next(0, Screen.Width),gen.Next(0, Screen.Height)), Color.White, new Vector2((float)(gen.NextDouble() * gen.Next(1, 2)))));
            }

        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            MouseState ms = Mouse.GetState();
            KeyboardState ks = Keyboard.GetState();
            if (paused == false)
            {
                for (int i = 0; i < multipleBalls.Count; i++)
                {
                    //update positions
                    multipleBalls[i].Update(gameTime, GraphicsDevice.Viewport, ms);
                }

                //check collisions
                for (int i = 0; i < multipleBalls.Count; i++)
                {
                    for (int j = i + 1; j < multipleBalls.Count; j++)
                    {
                        if (multipleBalls[j].Hitbox.Intersects(multipleBalls[i].Hitbox))
                        {
                            if (multipleBalls[i].IsGrowing || multipleBalls[j].IsGrowing)
                            {
                                paused = true;
                            }

                            tempSpeed = multipleBalls[i].Speed;

                            multipleBalls[i].Speed = multipleBalls[j].Speed;
                            multipleBalls[j].Speed = tempSpeed;
                        }
                    }
                }
            }
            else
            {
                if (ks.IsKeyDown(Keys.CapsLock))
                {
                    SpawnBalls(5);
                    paused = false;

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
                multipleBalls[i].Draw(spriteBatch);
            }
            //draw all ball objects

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
