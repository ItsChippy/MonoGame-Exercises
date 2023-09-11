using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace Ö2_1A
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        List<Vector2> positionList;
        List<Logo> listOfLogoObjects;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D peepoStare = Content.Load<Texture2D>(@"peepostare");
            Texture2D peepoHappy = Content.Load<Texture2D>(@"peepohappy");;
        
            int stopX = Window.ClientBounds.Width - peepoStare.Width;
            int stopY = Window.ClientBounds.Height - peepoStare.Height;

            Random rnd = new Random();
            
            listOfLogoObjects = new List<Logo>();

            for (int i = 0; i < 10; i++)
            {
                int randomXNumber = rnd.Next(0, stopX);
                int randomYNumber = rnd.Next(0, stopY);
                Vector2 objectPosition = new Vector2(randomXNumber, randomYNumber);
                Logo tempLogo = new Logo(objectPosition, stopY, stopX, peepoStare);
                listOfLogoObjects.Add(tempLogo);
            }
            
            
            /*Vector2 pos1 = Vector2.Zero;

            Vector2 pos2;
            pos2.X = Window.ClientBounds.Width / 2 - peepoHappy.Width / 2;
            pos2.Y = Window.ClientBounds.Height / 2 - peepoHappy.Height / 2;

            peepoStareLogo = new Logo(pos1, stopY, stopX, peepoStare);

            stopX = Window.ClientBounds.Width - peepoHappy.Width;
            stopY = Window.ClientBounds.Height - peepoHappy.Height;
            peepoHappyLogo = new Logo(pos2, stopY, stopX, peepoHappy);*/
            
                     
            /*positionList = new List<Vector2>();
            Random rand = new Random();
            for (int i = 0; i < 3; i++)
            {
                int randX = rand.Next(0, stopX);
                int randY = rand.Next(0, stopY);
                Vector2 pos = new(randX, randY);
                positionList.Add(pos);
            }*/
            

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach(Logo logoElement in listOfLogoObjects)
            {
                logoElement.Update();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();
            foreach(Logo logoElement in listOfLogoObjects)
            {
                logoElement.Draw(_spriteBatch);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}