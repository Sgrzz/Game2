using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;
using System.IO;

namespace Game2
{
    class LoadGame
    {

        ContentManager Content;
        SpriteFont font;
        string[] saves;
        float percentage;
 


        public void LoadContent(ContentManager content,GraphicsDevice graphicsDevice)
        {
            Content = content;
            font = Content.Load<SpriteFont>("angryblue");
            saves = Directory.GetDirectories(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\MayhemOfSound\\SaveData\\");
            percentage= (float)1/saves.Length;
         
        }


        public void UnLoadContent()
        {

        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw (SpriteBatch spriteBatch)
        {
            int temp = 0;

            foreach (var item in saves)
            {
        


               spriteBatch.DrawString(font, new DirectoryInfo(item).Name, new Vector2((((float)(spriteBatch.GraphicsDevice.Viewport.Width * 0.5) - (font.MeasureString(new DirectoryInfo(item).Name).X / 2))), (spriteBatch.GraphicsDevice.Viewport.Height*(percentage*temp))), Color.Purple);

                

                temp++;
                // spriteBatch.DrawString(font, new DirectoryInfo(item).Name, Vector2.Zero, Color.Purple); 
            }

        }

    }
}
