using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Roots_of_Defense
{
    public class Roots_of_Defense : Game
    {
        public enum GameState
        {
            Menu,
            Game,
            Settings,
            Story,
            Exit
        }

        private Menu _menu;
        private Session _hra;
        private Story _story;
        private Settings _settings;

        private SpriteFont _font;

        public GameState CurrentState { get; set; } = GameState.Menu;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Roots_of_Defense()
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
            _font = Content.Load<SpriteFont>("Font");
            _menu = new Menu();
            _hra = new Session();
            _story = new Story();
            _settings = new Settings();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            switch (CurrentState)
            {
                case GameState.Menu:
                    _menu.Update(gameTime);
                    break;
                case GameState.Game:
                    _hra.Update(gameTime);
                    break;
                case GameState.Exit:
                    Exit();
                    break;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            switch (CurrentState)
            {
                case GameState.Menu:
                    _menu.Draw(_spriteBatch, GraphicsDevice);
                    break;
                case GameState.Game:
                    _hra.Draw(_spriteBatch, GraphicsDevice);
                    break;
            }
            _spriteBatch.End();

            base.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}
