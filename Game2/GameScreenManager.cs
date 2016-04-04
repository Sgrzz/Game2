using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Game2
{
    class GameManager
    {


        WorldMap worldMap;
        
        enum State
        {
            menu,worldmap,battle,inventory
        }

        State gameState;

        private static MainMenu instance;



        public static MainMenu Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainMenu();
                }
                return instance;
            }
        }


        private GameManager()
        {
            
            worldMap = new WorldMap();
          
            gameState = State.menu;
        }

        public void LoadContent(ContentManager Content, GraphicsDevice graphicsDevice)
        {
            worldMap.LoadContent(Content, graphicsDevice);
         
        }
        public void UnloadContent()
        {
            worldMap.UnloadContent();
            
        }


        public void Update(GameTime gameTime)
        {
            switch (gameState)
            {
                case State.menu:
                    break;
                case State.worldmap:
                        worldMap.Update(gameTime);
                    break;
                case State.battle:
                    break;
                case State.inventory:
                    break;
                default:
                    break;
            }
            
           
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (gameState)
            {
                case State.menu:
                    break;
                case State.worldmap:
                        worldMap.Draw(spriteBatch);
                    break;
                case State.battle:
                    break;
                case State.inventory:
                    break;
                default:
                    break;
            }
            
            

        }
    }
}
