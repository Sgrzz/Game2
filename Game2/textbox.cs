using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;

namespace Game2
{
    class TextBox
    {

        ContentManager Content;
        SpriteFont font;
        string text;
        Vector2 position;
        Color cor;
        double width, height;
        Keys[] oldkeys = { };
        Texture2D rect;


        public TextBox(Vector2 position,double width,double height,string text,Color cor)
        {
            this.position = position;
            this.text = text;
            this.cor = cor;
            this.width = width;
            this.height = height;
        }

        public TextBox(Vector2 position, double width, double height, Color cor)
        {
            this.text = "";
            this.position = position;
            this.cor = cor;
            this.width = width;
            this.height = height;
        }

        public void LoadContent(ContentManager content, GraphicsDevice graphicsDevice)
        {
            this.Content = content;
            font = Content.Load<SpriteFont>("angryblue");

            rect = new Texture2D(graphicsDevice,3,3);

        }
        public void UnloadContent()
        {

        }
        
        public void Update(GameTime gameTime)
        {
            KeyboardState keypressed = Keyboard.GetState();

            Keys[] temp = oldkeys;



            for (int i = 0; i < temp.Length; i++)
            {
                if ((keypressed.IsKeyUp(temp[i])))
                {

                    //switch (temp[i])
                    //{
                    //    case Keys.Space:text += " ";
                    //        break;
                    //    case Keys.Back:
                    //        text = text != "" ? text.Remove(text.Length - 1) : "";
                    //        break;
                             
                    //    default:
                    //        text += temp[i];
                    //        break;
                    //}
                    
                    if (temp[i] == Keys.Back && text.Length > 0)
                    {
                        text = text.Remove(text.Length - 1, 1);
                    }
                    else if (temp[i] == Keys.Space)
                    {
                        text = text.Insert(text.Length, " ");
                    }
                    else
                    {
                        string keyString = temp[i].ToString();
                        
                        bool isUpperCase = ((keypressed.IsKeyDown(Keys.CapsLock) &&
                                             (!keypressed.IsKeyDown(Keys.RightShift) &&
                                              !keypressed.IsKeyDown(Keys.LeftShift))) ||
                                            (!keypressed.IsKeyDown(Keys.CapsLock) &&
                                             (keypressed.IsKeyDown(Keys.RightShift) ||
                                              keypressed.IsKeyDown(Keys.LeftShift))));

                        if (keyString.Length == 1)
                        {
                            text += isUpperCase ? keyString.ToUpper() : keyString.ToLower();
                        }
                    }



                }
                
            }

            oldkeys = keypressed.GetPressedKeys();
            //guardo as antigas e comparo as que deixaram de ser primidas

           


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

            spriteBatch.DrawString(font, text, new Vector2((float)((spriteBatch.GraphicsDevice.Viewport.Width * position.X) - (font.MeasureString(text).X) / 2), (float)(spriteBatch.GraphicsDevice.Viewport.Height * position.Y)), cor);

        }
    }
}
