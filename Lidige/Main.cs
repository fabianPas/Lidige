using Lidige.Maps;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lidige
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Main : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        Camera _camera;

        MapRenderer _mapRenderer;
        Map _map;

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
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
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 800;

            _camera = new Camera(GraphicsDevice.Viewport);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _mapRenderer = new MapRenderer(_spriteBatch, _camera);


            _map = Content.Load<Map>("Maps/1");

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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            var keyboardState = Keyboard.GetState();

            // rotation
            if (keyboardState.IsKeyDown(Keys.Q))
                _camera.Rotation -= deltaTime;

            if (keyboardState.IsKeyDown(Keys.W))
                _camera.Rotation += deltaTime;

            // movement
            if (keyboardState.IsKeyDown(Keys.Up))
                _camera.Position -= new Vector2(0, 250) * deltaTime;

            if (keyboardState.IsKeyDown(Keys.Down))
                _camera.Position += new Vector2(0, 250) * deltaTime;

            if (keyboardState.IsKeyDown(Keys.Left))
                _camera.Position -= new Vector2(250, 0) * deltaTime;

            if (keyboardState.IsKeyDown(Keys.Right))
                _camera.Position += new Vector2(250, 0) * deltaTime;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _mapRenderer.Render(_map);

            base.Draw(gameTime);
        }
    }
}
