using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Game2
{
    class BattleGround
    {
        ContentManager Content;
        Texture2D texture;
        Vector2 position;
        int height;
        int width;


        public void LoadContent(ContentManager content, GraphicsDevice graphicsDevice)
        {
            this.Content = content;
            texture = Content.Load<Texture2D>("background_battle");
            position = new Vector2(0, 0);
            height = (graphicsDevice.Viewport.Height);
            width = (graphicsDevice.Viewport.Width);



        }
        public void UnloadContent()
        {

        }


        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture, (new Rectangle((int)position.X, (int)position.Y, width, height)), Color.White);
        }
    }
}
