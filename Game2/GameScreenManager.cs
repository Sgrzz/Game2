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
        Inventory inventory;
        BattleGround battleGround;
        string saveName;

        enum State
        {
            MENU,WORLDMAP,BATTLE,INVENTORY
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
            inventory = new Inventory();
            battleGround = new BattleGround();
            gameState = State.MENU;

            

        }

        public void LoadContent(ContentManager Content, GraphicsDevice graphicsDevice)
        {
            worldMap.LoadContent(Content, graphicsDevice);
            menu.LoadContent(Content, graphicsDevice);
            inventory.LoadContent(Content, graphicsDevice);
            battleGround.LoadContent(Content, graphicsDevice);


        }
        public void UnloadContent()
        {
            worldMap.UnloadContent();
            menu.UnloadContent();
            inventory.UnloadContent();
            battleGround.UnloadContent();
            
        }


        public void Update(GameTime gameTime)
        {
            switch (gameState)
            {
                case State.MENU:
                        menu.Update(gameTime);
                    if (menu.IsDone)
                        gameState = State.WORLDMAP;
                        menu.IsDone = false;
                        saveName = menu.saveName;
                    break;
                case State.WORLDMAP:
                        worldMap.Update(gameTime);
                        if (worldMap.IsDone)
                        {
                            gameState = State.INVENTORY;
                            inventory.Update(gameTime,saveName);
                            worldMap.IsDone = false;
                        }
                        if (worldMap.CanBattle)
                        {
                            gameState = State.BATTLE;
                        }
                            
                    break;
                case State.BATTLE:

                    worldMap.SetBattle(false);
                    battleGround.Update(gameTime);
                    break;
                case State.INVENTORY:
                    inventory.Update(gameTime,saveName);
                    if (inventory.IsDone)
                    {
                        gameState = State.WORLDMAP;
                        inventory.IsDone = false;
                    }
                    break;
                default:
                    break;
            }
            
           
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            

            switch (gameState)
            {
                case State.MENU:
                        
                        
                        menu.Draw(spriteBatch);
                    break;
                case State.WORLDMAP:
                        worldMap.Draw(spriteBatch);
                    break;
                case State.BATTLE:
                        battleGround.Draw(spriteBatch);
                    break;
                case State.INVENTORY:
                        inventory.Draw(spriteBatch);
                    break;
                default:
                    break;
            }
            
            

        }
    }
}
