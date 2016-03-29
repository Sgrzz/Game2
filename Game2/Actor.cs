using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Game2
{
    class Actor
    {
        ContentManager Content;
        Texture2D texture;
        Vector2 position;
        int height;
        int width;


        public void LoadContent(ContentManager content, GraphicsDevice graphicsDevice)
        {
            this.Content = content;
            texture = Content.Load<Texture2D>("dude");
            position = new Vector2(250,250);
            height = (int)(graphicsDevice.Viewport.Height*0.2);
            width = (int)(graphicsDevice.Viewport.Width*0.2);

           

        }
        public void UnloadContent()
        {

        }


        public void Update(GameTime gameTime)
        {
            position.X += 1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture, (new Rectangle((int)position.X, (int)position.Y, width, height)), Color.White);
        }
    }
}
