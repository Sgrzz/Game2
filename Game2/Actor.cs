using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Game2
{
    class Actor
    {
        protected ContentManager Content;
        protected Texture2D texture;
        protected string textureString;
        protected Vector2 position;
        protected float height;
        protected float width;
        protected int id;

        public Actor(int id,Vector2 position,float height,float width,string texture)
        {
            this.id = id;
            this.position = position;
            this.height = height;
            this.width = width;
            this.textureString = texture;
        }

        public void LoadContent(ContentManager content, GraphicsDevice graphicsDevice)
        {
            this.Content = content;
            texture = Content.Load<Texture2D>(textureString);

           

        }
        public void UnloadContent()
        {

        }


        public void Update(GameTime gameTime)
        {
           /// position.X += 1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture, (new Rectangle((int)(spriteBatch.GraphicsDevice.Viewport.Width*position.X), (int)(spriteBatch.GraphicsDevice.Viewport.Height * position.Y), (int)(spriteBatch.GraphicsDevice.Viewport.Width * width), (int)(spriteBatch.GraphicsDevice.Viewport.Height * height))), Color.White);
        }
    }
}
