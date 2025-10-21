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

        Rectangle window, dragonRect, castleRect, donkeyRect, backgroundRect, rectangleRect;

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
            rectangleRect = dragonRect;



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

            dragon_x += 0.05f;
            dragonXPosition += 0.4f;

            rectangleRect.X = 30 + (int)(MathF.Sin(dragon_x) * 0.5f + dragonXPosition);
            rectangleRect.Y = (int)MathF.SinCos(dragon_x).Cos * 5 + window.Height / 2;

            if (dragonXPosition > window.Width + 100)
            {
                dragonXPosition = -200;
            }



            //rectangleRect.X = MathF.Sin(dragon_x) * 0.5f + dragonXPosition;


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
                new Vector2(MathF.Sin(dragon_x) * 0.5f + dragonXPosition, MathF.SinCos(dragon_x).Cos * 5 + window.Height / 2),
                null,
                Color.White,
                0,
                Vector2.Zero,
                0.4f,
                0,
                1
                );

            _spriteBatch.Draw(rectangleTexture, rectangleRect, Color.White*0.5f);

            _spriteBatch.Draw(donkeyTexture, donkeyRect, Color.White);



            _spriteBatch.End();




            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
