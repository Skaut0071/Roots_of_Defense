using Microsoft.VisualBasic.Devices;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roots_of_Defense
{
    internal class Menu
    {
        private string[] _options = { "Play", "Settings", "Story", "Leave" };
        private int _selectedIndex = 0;
        private SpriteFont _font;

       

       

        public void LoadContent(GraphicsDevice graphicsDevice, ContentManager content)
        {
            // Načtení fontu (je nutné mít font připravený v projektu MonoGame)
            _font = content.Load<SpriteFont>("DefaultFont");
        }

        

        public void Update(GameTime gameTime)
        {
            
        }

        private string WrapText(SpriteFont font, string text, float maxLineWidth)
        {
            string[] words = text.Split(' ');
            string wrappedText = "";
            float lineWidth = 0f;
            float spaceWidth = font.MeasureString(" ").X;

            foreach (string word in words)
            {
                Vector2 wordSize = font.MeasureString(word);

                if (lineWidth + wordSize.X < maxLineWidth)
                {
                    wrappedText += word + " ";
                    lineWidth += wordSize.X + spaceWidth;
                }
                else
                {
                    wrappedText += "\n" + word + " ";
                    lineWidth = wordSize.X + spaceWidth;
                }
            }

            return wrappedText;
        }


        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            if (CurrentState == MenuState.Settings)
            {
                graphicsDevice.Clear(Color.Gray);

                spriteBatch.Begin();

                string text = "Pravidla pro barvy micku a zivotu. Kazdy hrac ma 3 srdicka, kazde z nich je slozeno z 5 bodu. Kdyz ma hrac ubrany 1 bod z srdicka ubere se jako polovina aby hrac videl ze nema plny pocet bodu. Kdy:                          Zelena = +1 bod |                                     Cervena = -1 bod |                                    Cerna = -5 bodu |";
                float screenWidth = graphicsDevice.Viewport.Width;
                float screenHeight = graphicsDevice.Viewport.Height;
                float yPosition = screenHeight / 8;

                float maxWidth = screenWidth * 0.8f;

                string wrappedText = WrapText(_font, text, maxWidth);
                Vector2 textSize = _font.MeasureString(wrappedText);

                Vector2 position = new Vector2(
                    (screenWidth - textSize.X) / 2,
                    yPosition
                );

                spriteBatch.DrawString(_font, wrappedText, position, Color.White);

                spriteBatch.End();
            }
            else
            {
                graphicsDevice.Clear(Color.Gray);

                spriteBatch.Begin();
                for (int i = 0; i < _options.Length; i++)
                {
                    Color color = (i == _selectedIndex) ? Color.Yellow : Color.White;
                    Vector2 position = new Vector2(100, 100 + i * 50);
                    spriteBatch.DrawString(_font, _options[i], position, color);
                }
                string infoText = "Vyber a pohyb Sipky a Enter, zpet ESC";
                Vector2 textSize = _font.MeasureString(infoText);
                float screenWidth = graphicsDevice.Viewport.Width;

                Vector2 infoPosition = new Vector2(
                    (screenWidth - textSize.X) / 2, 300
                );
                spriteBatch.DrawString(_font, infoText, infoPosition, Color.LightGray);
                spriteBatch.End();
            }
        }


    }
}
