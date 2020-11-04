using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Net.Configuration;
using System.Threading;

namespace Spaceinvaders
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D pixel;
        Rectangle ball = new Rectangle(100, 100, 20, 20);
        Rectangle right_paddle = new Rectangle(310, 392, 180, 28);
        Rectangle spaceship1 = new Rectangle(330, 350, 20, 90);
        Rectangle spaceship2 = new Rectangle(450, 350, 20, 90);
        Rectangle spaceship3 = new Rectangle(385, 325, 30, 120);
        Rectangle spaceblock1 = new Rectangle(485, 390, 1, 1);
        Rectangle spaceblock2 = new Rectangle(315, 390, 1, 1);
        Rectangle spaceblock3 = new Rectangle(382, 390, 1, 1);
        Rectangle spaceblock4 = new Rectangle(418, 390, 1, 1);
        Rectangle pew1 = new Rectangle(100, 245, 10, 100);
        Rectangle pew2 = new Rectangle(100, 245, 10, 100);
        Rectangle pew3 = new Rectangle(100, -150, 10, 85);
        Rectangle pew4 = new Rectangle(100, -150, 10, 85);
        Rectangle thicc = new Rectangle(-1, 440, 1000, 1000);

        int x_speed = 5;
        int y_speed = 5;
        int y2_speed = 5;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }




        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            pixel = Content.Load<Texture2D>("pixel");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeyboardState kstate = Keyboard.GetState();
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();
            if (kstate.IsKeyDown(Keys.A))
                right_paddle.X -= 9;
            if (kstate.IsKeyDown(Keys.D))
                right_paddle.X += 9;
            if (kstate.IsKeyDown(Keys.A))
                spaceship1.X -= 9;
            if (kstate.IsKeyDown(Keys.D))
                spaceship1.X += 9;
            if (kstate.IsKeyDown(Keys.A))
                spaceship2.X -= 9;
            if (kstate.IsKeyDown(Keys.D))
                spaceship2.X += 9;
            if (kstate.IsKeyDown(Keys.A))
                spaceship3.X -= 9;
            if (kstate.IsKeyDown(Keys.D))
                spaceship3.X += 9;
            if (kstate.IsKeyDown(Keys.A))
                spaceblock1.X -= 9;
            if (kstate.IsKeyDown(Keys.D))
                spaceblock1.X += 9;
            if (kstate.IsKeyDown(Keys.A))
                spaceblock2.X -= 9;
            if (kstate.IsKeyDown(Keys.D))
                spaceblock2.X += 9;
            if (kstate.IsKeyDown(Keys.A))
                spaceblock3.X -= 9;
            if (kstate.IsKeyDown(Keys.D))
                spaceblock3.X += 9;
            if (kstate.IsKeyDown(Keys.A))
                spaceblock4.X -= 9;
            if (kstate.IsKeyDown(Keys.D))
                spaceblock4.X += 9;
            if (kstate.IsKeyDown(Keys.S))
                spaceship2.X -= 5;
            if (kstate.IsKeyDown(Keys.W))
                spaceship2.X += 5;
            if (kstate.IsKeyDown(Keys.S))
                spaceship1.X += 5;
            if (kstate.IsKeyDown(Keys.W))
                spaceship1.X -= 5;



            if (right_paddle.Y > Window.ClientBounds.Height - right_paddle.Height)
                right_paddle.Y = Window.ClientBounds.Height - right_paddle.Height;

            ball.X += x_speed;
            ball.Y += y_speed;
            if (ball.Y < 0 || ball.Y > Window.ClientBounds.Height - ball.Height)
                y_speed *= -1;
            if (ball.X < 0 || ball.X > Window.ClientBounds.Width - ball.Height)
                x_speed *= -1;

            if (ball.Intersects(right_paddle) || ball.Intersects(right_paddle))
                x_speed *= -1;
            if (ball.Intersects(spaceship1) || ball.Intersects(spaceship1))
                x_speed *= -1;
            if (ball.Intersects(spaceship2) || ball.Intersects(spaceship2))
                x_speed *= -1;
            if (ball.Intersects(spaceship3) || ball.Intersects(spaceship3))
                x_speed *= -1;
            if (spaceship2.Intersects(spaceblock1) || spaceship2.Intersects(spaceblock1))
                spaceship2.X = spaceblock1.X - 20;
            if (spaceship1.Intersects(spaceblock2) || spaceship1.Intersects(spaceblock2))
                spaceship1.X = spaceblock2.X;
            if (spaceship2.Intersects(spaceblock4) || spaceship2.Intersects(spaceblock4))
                spaceship2.X = spaceblock4.X;
            if (spaceship1.Intersects(spaceblock3) || spaceship1.Intersects(spaceblock3))
                spaceship1.X = spaceblock3.X - 20;
            if (spaceship1.Intersects(spaceblock3) || spaceship1.Intersects(spaceblock3))
                spaceship1.X = spaceblock3.X - 20;

            if (pew3.Intersects(ball)) 
            {
                ball = new Rectangle(0, 0, 0, 10);
            }
            else if (pew4.Intersects(ball))
            {
                ball = new Rectangle(10, 10, 0, 10);
            }



            if (pew3.Y == 350)
            {
                pew3.Y -= 0;
            }
            else
            {
                pew3.Y -= y2_speed;
            }

            if (pew4.Y == 350)
            {
                pew4.Y -= 0;
            }
            else
            {
                pew4.Y -= y2_speed;
            }

            if (pew3.Y < 0 || pew3.Y > Window.ClientBounds.Height)
            {
                pew3.Y = 480;
            }
            if (pew4.Y < 0 || pew4.Y > Window.ClientBounds.Height)
            {
                pew4.Y = 480;
            }

                
            
            //Task.Delay(200).Wait(pew2.Y = 245);
            //Task.Delay(200).Wait(pew1.Y = 245);
            //int milisecounds = 200;
            //Thread.Sleep(milisecounds);




            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            base.Draw(gameTime);
            spriteBatch.Begin();
            KeyboardState kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(Keys.Space))
            {
                pew3.Y = 349;
                pew4.Y = 349;
                pew3.X = spaceship1.X + 5;
                pew4.X = spaceship2.X + 5;

            }
            else
            {
                spriteBatch.Draw(pixel, pew1, Color.Black);
                spriteBatch.Draw(pixel, pew2, Color.Black);
                pew1.X = spaceship1.X + 5;
                pew2.X = spaceship2.X + 5;
                pew3.X = spaceship1.X+5;
                pew4.X = spaceship2.X+5;
            }
            spriteBatch.Draw(pixel, spaceship1, Color.Green);
            spriteBatch.Draw(pixel, spaceship2, Color.Green);
            spriteBatch.Draw(pixel, right_paddle, Color.Green);
            spriteBatch.Draw(pixel, pew3, Color.Blue);
            spriteBatch.Draw(pixel, pew4, Color.Blue);
            spriteBatch.Draw(pixel, thicc, Color.Black);
            spriteBatch.Draw(pixel, spaceblock1, Color.Black);
            spriteBatch.Draw(pixel, spaceblock2, Color.Black);
            spriteBatch.Draw(pixel, spaceblock3, Color.Black);
            spriteBatch.Draw(pixel, spaceblock4, Color.Black);
            spriteBatch.Draw(pixel, spaceship3, Color.Green);
            spriteBatch.Draw(pixel, ball, Color.Green);

            spriteBatch.End();
        }
    }
}
