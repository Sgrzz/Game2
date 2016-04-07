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
        public string anim { get; set; }

        public bool IsMoving = false;

        int time = 0;
        int spriteY, spriteX;
        

        

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
            texture = Content.Load<Texture2D>("Actor\\" + textureString +"\\"+ textureString);
            
            


        }
        public void UnloadContent()
        {

        }


        public void Update(GameTime gameTime)
        {


            if (gameTime.TotalGameTime.TotalMilliseconds-time>100 && IsMoving)
            {

                time = (int)gameTime.TotalGameTime.TotalMilliseconds;

                spriteX = spriteX == 3 ? 0 : spriteX + 1;

                

            }



            switch (anim)
            {

                case "left":
                    spriteY = 1;
                    break;
                case "right":
                    spriteY = 2;
                    break;
                case "up":
                    spriteY = 3;
                    break;
                case "down":
                    spriteY = 0;
                    break;

                default:
                    break;
            }


        }


        

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture, (new Rectangle((int)(spriteBatch.GraphicsDevice.Viewport.Width*position.X), (int)(spriteBatch.GraphicsDevice.Viewport.Height * position.Y), (int)(spriteBatch.GraphicsDevice.Viewport.Width * width), (int)(spriteBatch.GraphicsDevice.Viewport.Height * height))),new Rectangle(32*spriteX,48*spriteY,32,48), Color.White);
        }
    }
}
