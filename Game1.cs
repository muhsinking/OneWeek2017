using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace OneWeek2017
{
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		Texture2D badger;
		int windowWidth = 1200;
		int windowHeight = 600;
		LevelEngine levelEngine;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			graphics.PreferredBackBufferWidth = windowWidth;  // set this value to the desired width of your window
			graphics.PreferredBackBufferHeight = windowHeight;   // set this value to the desired height of your window
			graphics.ApplyChanges();
		}

		protected override void Initialize()
		{
			base.Initialize();
		}

		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			levelEngine = new LevelEngine(Content, new Vector2(windowWidth, windowHeight));

			// load test sprite
			badger = Content.Load<Texture2D>("halberd-badger");
		}

		protected override void Update(GameTime gameTime)
		{
			float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
			levelEngine.Update(elapsedTime);
			base.Update(gameTime);

		}

		protected override void Draw(GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, null);

			//spriteBatch.Draw(badger, new Vector2(100, 100), Color.White);

			levelEngine.Draw(spriteBatch);

			spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}
