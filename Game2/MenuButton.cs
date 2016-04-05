using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;


namespace Game2
{
    class MenuButton
    {

        string text;
        Vector2 position;
        Color textcolor;
        ContentManager Content;
        private Vector2 realPosition;
        private bool flag;
        private GameTime time;
        SpriteFont font;
        private int alphatemp,oldseconds;
        string temp = "";


        public MenuButton(string text,Vector2 position,Color textcolor)
        {
            this.text = text;
            this.position = position;
            this.textcolor = textcolor;
           
                 
        }

        public void LoadContent(ContentManager content, GraphicsDevice graphicsDevice)
        {
            this.Content = content;
            font= Content.Load<SpriteFont>("angryblue");

        }
        public void UnloadContent()
        {

        }

        public void Update(GameTime gameTime)
        {
            time = gameTime;
            oldseconds = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            Color cor = textcolor;
            if (IsCursorOn() && oldseconds<time.TotalGameTime.TotalMilliseconds/100)
            {
               

                temp = temp == "1" ? "0" : "1";

                spriteBatch.DrawString(font, temp, new Vector2(250, 40), cor);

                oldseconds = (int)time.TotalGameTime.TotalMilliseconds/100;

                spriteBatch.DrawString(font, oldseconds.ToString(), new Vector2(250,0), cor);


                flag = alphatemp > 300 ? false : alphatemp < 1 ? true : false;
                alphatemp = flag ? alphatemp + 1 : alphatemp - 1;
                

                int alpha = flag ? 300 - (alphatemp / 3) : (alphatemp / 3);
               

                cor = new Color(textcolor, alpha);
            }
           


            spriteBatch.DrawString(font, text, new Vector2((float)((spriteBatch.GraphicsDevice.Viewport.Width * position.X) - (font.MeasureString(text).X) / 2), (float)(spriteBatch.GraphicsDevice.Viewport.Height * position.Y)), cor);
            realPosition = new Vector2((float)((spriteBatch.GraphicsDevice.Viewport.Width * position.X) - (font.MeasureString(text).X) / 2), (float)(spriteBatch.GraphicsDevice.Viewport.Height * position.Y));

        }

        public bool IsCursorOn()
        {
            MouseState cursor = Mouse.GetState();

            if (realPosition.X < cursor.Position.X && realPosition.Y < cursor.Position.Y && realPosition.X+font.MeasureString(text).X>cursor.Position.X && realPosition.Y + font.MeasureString(text).Y > cursor.Position.Y)
                return true;

            return false;
        }
    }
}
