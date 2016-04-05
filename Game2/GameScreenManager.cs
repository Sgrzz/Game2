using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Game2
{
    class GameScreenManager
    {


        WorldMap worldMap;
        MainMenu menu;
        
        enum State
        {
            menu,worldmap,battle,inventory
        }

        State gameState;

        private static GameScreenManager instance;



        public static GameScreenManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameScreenManager();
                }
                return instance;
            }
        }


        private GameScreenManager()
        {
            
            worldMap = new WorldMap();
            menu = new MainMenu();
          
            gameState = State.menu;

            

        }

        public void LoadContent(ContentManager Content, GraphicsDevice graphicsDevice)
        {
            worldMap.LoadContent(Content, graphicsDevice);
            menu.LoadContent(Content, graphicsDevice);
         
        }
        public void UnloadContent()
        {
            worldMap.UnloadContent();
            menu.UnloadContent();
            
        }


        public void Update(GameTime gameTime)
        {
            switch (gameState)
            {
                case State.menu:
                        menu.Update(gameTime);
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
                        
                        
                        menu.Draw(spriteBatch);
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
