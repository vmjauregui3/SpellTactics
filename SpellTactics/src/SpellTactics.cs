using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace SpellTactics
{
    public class SpellTactics : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private static int gameHeight;
        public static int GameHeight
        {
            get { return gameHeight; }
        }
        private static int gameWidth;
        public static int GameWidth
        {
            get { return gameWidth; }
        }
        private static Vector2 gameOrigin;
        public static Vector2 GameOrigin
        {
            get { return gameOrigin; }
        }


        public User User;

        private World world;

        public bool paused = false;

        public static Random rand = new Random();

        public static ContentManager STContent;

        public static System.Globalization.CultureInfo Culture = new System.Globalization.CultureInfo("en-US");

        public SpellTactics()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            gameWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            gameHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            gameOrigin = new Vector2(gameWidth / 2, gameHeight / 2);

            graphics.PreferredBackBufferWidth = gameWidth;
            graphics.PreferredBackBufferHeight = gameHeight;

            graphics.IsFullScreen = true;

            graphics.ApplyChanges();

            base.Initialize();

            STContent = new ContentManager(Content.ServiceProvider, "Content");

            User = new User(0);
            world = new World(User);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            InputManager.Instance.Update(gameTime);
            MCursor.Instance.Update();

            if (InputManager.Instance.KeyPressed(Keys.Escape))
            {
                paused = !paused;
                IsMouseVisible = !IsMouseVisible;
            } // Exit();


            if (paused)
            {
                if (InputManager.Instance.KeyPressed(Keys.Delete))
                { Exit(); }
            }
            else
            {
                // TODO: Add your update logic here
                world.Update(gameTime);
            }
            MCursor.Instance.UpdateOld();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(transformMatrix: Camera.Instance.Transform);
            world.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}