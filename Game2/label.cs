using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;

namespace Game2
{
    class Label
    {
        ContentManager Content;
        SpriteFont font;
        string text;
        Vector2 position;
        Color cor;
        bool centered;


        public Label(string text,Vector2 position, Color cor,bool centered)
        {
            this.position = position;
            this.text = text;
            this.cor = cor;
            this.centered = centered;

        }

        public Label(Vector2 position, Color cor, bool centered)
        {
            this.text = "";
            this.position = position;
            this.cor = cor;
            this.centered = centered;
        }

        public void LoadContent(ContentManager content, GraphicsDevice graphicsDevice)
        {
            this.Content = content;
            font = Content.Load<SpriteFont>("angryblue");


        }
        public void UnloadContent()
        {

        }

        public void Update(GameTime gameTime)
        {
           



        }

        public void Text(string text)
        {
            this.text = text;
        }


        public string Text()
        {
            return text;
        }




        public void Draw(SpriteBatch spriteBatch)
        {


            //spriteBatch.Draw(rect, coor, Color.White);

            spriteBatch.DrawString(font, text, new Vector2((float)((spriteBatch.GraphicsDevice.Viewport.Width * position.X) - ( centered?font.MeasureString(text).X:0) / 2), (float)(spriteBatch.GraphicsDevice.Viewport.Height * position.Y)), cor);

        }
    }
}
