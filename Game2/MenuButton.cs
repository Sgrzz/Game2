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
        SpriteFont font;
        private int alpha;
        int id;


        public MenuButton(int id,string text,Vector2 position,Color textcolor)
        {
            this.text = text;
            this.position = position;
            this.textcolor = textcolor;
            this.id = id;
                 
        }

        public void LoadContent(ContentManager content, GraphicsDevice graphicsDevice)
        {
            this.Content = content;
            font= Content.Load<SpriteFont>("angryblue");

        }
        public void UnloadContent()
        {

        }


        public void Draw(SpriteBatch spriteBatch)
        {
            
            Color cor = textcolor;
            if (IsCursorOn())
            {
                          

                if (alpha > 300)
                    flag = false;
                if (alpha < 0)
                    flag = true;
           
                alpha = flag ? alpha + 15 : alpha - 15;
                cor = new Color(textcolor, alpha);
            }
            else
            {
                alpha = 300;
            }



            spriteBatch.DrawString(font, text, new Vector2((float)((spriteBatch.GraphicsDevice.Viewport.Width * position.X) - (font.MeasureString(text).X) / 2), (float)(spriteBatch.GraphicsDevice.Viewport.Height * position.Y)), cor);
            realPosition = new Vector2((float)((spriteBatch.GraphicsDevice.Viewport.Width * position.X) - (font.MeasureString(text).X) / 2), (float)(spriteBatch.GraphicsDevice.Viewport.Height * position.Y));

        }

        public int IsClicked()
        {
            MouseState cursor = Mouse.GetState();
            if (IsCursorOn() && cursor.LeftButton == ButtonState.Pressed)
                return id;
            return 0;
        }

        private bool IsCursorOn()
        {
            MouseState cursor = Mouse.GetState();
            

            //if (realPosition.X < cursor.Position.X && realPosition.Y < cursor.Position.Y && realPosition.X+font.MeasureString(text).X>cursor.Position.X && realPosition.Y + font.MeasureString(text).Y > cursor.Position.Y)
            //    return true;

            if (realPosition.X < cursor.X && realPosition.Y < cursor.Y && realPosition.X + font.MeasureString(text).X > cursor.X && realPosition.Y + font.MeasureString(text).Y > cursor.Y)
                return true;

            return false;
        }
    }
}
