#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using MasterSmith.Classes;
#endregion

namespace MasterSmith {
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class MasterSmith : Game {
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		Player player;
		List<GameObject> objects = new List<GameObject>();

		public MasterSmith() : base() {
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize() {
			Defaults.ScreenWidth = GraphicsDevice.Viewport.Width;
			Defaults.ScreenHeight = GraphicsDevice.Viewport.Height;

			player = new Player(new Vector2(Defaults.ScreenWidth / 2, Defaults.ScreenHeight - Defaults.GROUND));

			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent() {
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			// TODO: use this.Content to load your game content here
			Texture2D debugTexture = Content.Load<Texture2D>("roundedsquare");
			player.texture = debugTexture;
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// all content.
		/// </summary>
		protected override void UnloadContent() {
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime) {
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			player.Update(gameTime);
			foreach (GameObject obj in objects) obj.Update(gameTime);

			Defaults.ScreenWidth = GraphicsDevice.Viewport.Width;
			Defaults.ScreenHeight = GraphicsDevice.Viewport.Height;

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime) {
			GraphicsDevice.Clear(Color.Black);

			spriteBatch.Begin();
			player.Draw(spriteBatch);
			foreach(GameObject obj in objects) obj.Draw(spriteBatch);
			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
