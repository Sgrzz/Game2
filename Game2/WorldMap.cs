using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Game2
{
    class WorldMap
    {
        ContentManager Content;
        Texture2D texture;
        Vector2 position;
        int height;
        int width;
        Rectangle rect;
        ActorWorld dude = new ActorWorld(0, new Vector2((float)0.0, (float)0.0),(float) 0.1,(float) 0.05, "WorldActor");

        public void LoadContent(ContentManager content,GraphicsDevice graphicsDevice)
        {
            Content = content;
            texture = Content.Load<Texture2D>("WorldMap\\WorldMapFull");
            position = Vector2.Zero;
            height = graphicsDevice.Viewport.Height;
            width = graphicsDevice.Viewport.Width;

            rect = new Rectangle((int)position.X,(int) position.Y, width, height);

            dude.LoadContent(content, graphicsDevice);

        }
        public void UnloadContent()
        {
            dude.UnloadContent();
        }


        public void Update(GameTime gameTime)
        {
            dude.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture, rect, Color.Black);
            dude.Draw(spriteBatch);
        }
    }
}
