using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;

namespace Game2
{
    class WorldMap
    {
        ContentManager Content;
        Texture2D texture;
        public bool IsDone { get;  set; } = false;
        Vector2 position;
        int height;
        int width;
        Rectangle rect;
        ActorWorld dude = new ActorWorld(0, new Vector2((float)0.0, (float)0.0),(float) 0.1,(float) 0.05, "Guitarist");
        public bool CanBattle { get;private set; } = false;

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


        public void SetBattle(bool can)
        {
            
                CanBattle = can;
        }


        public void Update(GameTime gameTime)
        {
            dude.Update(gameTime);

            if (dude.IsMoving==true)
            {
                Random rnd = new Random();
                if (rnd.Next(0, 100) == 1)
                    SetBattle(true);
            }

            KeyboardState key = Keyboard.GetState();
            if (key.IsKeyDown(Keys.I))
            {
                IsDone = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture, rect, Color.Purple);
            dude.Draw(spriteBatch);
        }
    }
}
