#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

using SpaceEnvader.GameBuildingBlocks.SpaceShipStuff;
using SpaceEnvader.GameBuildingBlocks.MonstersStuff;
using SpaceEnvader.Animations;
using SpaceEnvader.GameBuildingBlocks;
using SpaceEnvader.GameStateStuff;
using Microsoft.Xna.Framework.Audio;

namespace SpaceEnvader
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Monsters monsters;
        SpaceShip spaceShip;

        GeneralGameState gameState;

        int windowWidth, windowHeight;

       

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 600;

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
            windowHeight = graphics.PreferredBackBufferHeight;
            windowWidth  = graphics.PreferredBackBufferWidth;
            
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

            //public SpaceShip(ContentManager content, string textureName, string gunTextureName, string arrowTextureName, Point startLoc, int speed, int winHeight, int winWidth)
            spaceShip = new SpaceShip(
                                  Content, "Spaceship","Gun","Arrow",
                                  startLoc: new Point((windowWidth / 2) - 60,windowHeight - 80),
                                  speed    : 9, 
                                  winHeight: windowHeight,
                                  winWidth : windowWidth
                                  );


            monsters = new Monsters(Content, "RedMonster", windowHeight, windowWidth);


            gameState = new GeneralGameState(Content, monsters, spaceShip, windowHeight, windowWidth);


            //SoundEffect sound = Content.Load<SoundEffect>(@"Audio/39458__the-bizniss__laser-4");
            //sound.Play();
                                        
        }


        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (gameState.PuaseGame == false)
            {
                spaceShip.Update(gameTime);

                monsters.Update(gameTime);
            }

            gameState.Update(spaceShip,monsters);

           
           
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            //draw code below this

            spaceShip.Draw(spriteBatch);
            monsters.Draw(spriteBatch);
            
            gameState.Draw(spriteBatch);

            //draw code over this
            spriteBatch.End();
           
            base.Draw(gameTime);
        }



        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
    }
}
