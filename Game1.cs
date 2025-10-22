using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace _4U_Topic_1____Monogame_Assignment
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D backgroundTexture, dragonTexture, castleTexture, donkeyTexture, rectangleTexture;

        Rectangle window, dragonRect, castleRect, donkeyRect, backgroundRect, dragonPositionRect;

        Vector2 dragonPosition;
        float dragon_x, dragonXPosition;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;

            window = new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            
            backgroundRect = window;
            dragonRect = new Rectangle(100, 300, 200, 150);
            castleRect = new Rectangle(80, 60, 700, 800);
            donkeyRect = new Rectangle(300, 400, 150, 100);
            dragonPositionRect = new Rectangle(dragonRect.X, dragonRect.Y, dragonRect.Width + 100, dragonRect.Height +110);
            dragonPosition = new Vector2(dragonRect.X, dragonRect.Y);


            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);


            backgroundTexture = Content.Load<Texture2D>("Images/oceanBg");
            dragonTexture = Content.Load<Texture2D>("Images/ladyDragon");
            castleTexture = Content.Load<Texture2D>("Images/castleImage");
            donkeyTexture = Content.Load<Texture2D>("Images/donkey");
            rectangleTexture = Content.Load<Texture2D>("Images/rectangle");


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            //Dragon Movement Logic

            dragonXPosition += 1f;


            dragonPosition.X += 0.1f; //10 + MathF.Sin(dragon_x) * 0.5f;
            dragonPosition.Y = MathF.SinCos(dragonPosition.X).Cos * 5 + window.Height / 2;// 30 -  MathF.Sin(dragonPosition.X) * 5 + window.Height / 2;

            dragonPositionRect.Location = dragonPosition.ToPoint();

            this.Window.Title = "Dragon X Position: " + dragonPositionRect.Y;

            if (dragonPositionRect.Left > window.Width)
            {
                dragonPosition.X = window.X - dragonPositionRect.Width;
                dragonPositionRect.Location = dragonPosition.ToPoint();

            }




            //dragonPositionRect.X = MathF.Sin(dragon_x) * 0.5f + dragonXPosition;


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            
            _spriteBatch.Draw(backgroundTexture, window, Color.White);
            _spriteBatch.Draw(castleTexture, castleRect, Color.White);
            _spriteBatch.Draw(dragonTexture, 
                dragonPosition,
                null,
                Color.White,
                0,
                Vector2.Zero,
                0.4f,
                0,
                1
                );

            _spriteBatch.Draw(rectangleTexture, dragonPositionRect, Color.White*0.5f);

            _spriteBatch.Draw(donkeyTexture, donkeyRect, Color.White);



            _spriteBatch.End();




            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
