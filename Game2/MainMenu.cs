using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;

namespace Game2
{
    class MainMenu
    {
        ContentManager Content;

        MenuButton[] arrayButtons ={
            new MenuButton("NEW GAME", new Vector2((float)0.5, (float)0.3), Color.Coral),
            new MenuButton("OPTIONS", new Vector2((float)0.5, (float)0.4), Color.Purple),
            new MenuButton("LOAD GAME", new Vector2((float)0.5, (float)0.5), Color.Purple),
            new MenuButton("CREDITS", new Vector2((float)0.5, (float)0.6), Color.Purple),
            new MenuButton("EXIT", new Vector2((float)0.5, (float)0.7), Color.Purple)};


        public void LoadContent(ContentManager content, GraphicsDevice graphicsDevice)
        {
            Content = content;

            
            foreach (var item in arrayButtons)
            {
                item.LoadContent(Content,graphicsDevice);
            }


        }
        public void UnloadContent()
        {
            foreach (var item in arrayButtons)
            {
                item.UnloadContent();
            }

        }


        public void Update(GameTime gameTime)
        {
            foreach (var item in arrayButtons)
            {
                item.Update(gameTime);
            }

        }

        private int CursorOn()
        {


            return 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {


            SpriteFont font = Content.Load<SpriteFont>("angryblue");

            foreach (var item in arrayButtons)
            {
                item.Draw(spriteBatch);
                spriteBatch.DrawString(font,item.IsCursorOn().ToString(), Vector2.Zero, Color.Black);
            }
            

            



        }
    }
}
