using Lidige.Entities;
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
        Player _player;

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

            _player = new Player(Content.Load<Texture2D>("Sprites/0"));

            _mapRenderer = new MapRenderer(_spriteBatch, _camera, _player);

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
            _player.Update(deltaTime);

            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Down))
                _player.Move(Direction.Down);

            if (keyboardState.IsKeyDown(Keys.Up))
                _player.Move(Direction.Up);

            if (keyboardState.IsKeyDown(Keys.Left))
                _player.Move(Direction.Left);

            if (keyboardState.IsKeyDown(Keys.Right))
                _player.Move(Direction.Right);


            _camera.LookAt(_player.Position);
            //_camera.Position = Vector2.Lerp(_camera.Position, _player.Position, 0.5f);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            var matrix = _camera.GetViewMatrix();

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: matrix);

            _mapRenderer.Render(_map);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
