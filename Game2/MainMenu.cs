using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;

namespace Game2
{
    class MainMenu
    {
        ContentManager Content;

        enum MenuState
        {
            MAINMENU,NEWGAME,OPTIONS,LOADGAME,CREDITS,EXIT,PLAY
        }

        MenuState menu = MenuState.MAINMENU;

        MenuButton[] mainMenuButtons ={
            new MenuButton(1,"NEW GAME", new Vector2((float)0.5, (float)0.3), Color.Purple),
            new MenuButton(2,"OPTIONS", new Vector2((float)0.5, (float)0.4), Color.Purple),
            new MenuButton(3,"LOAD GAME", new Vector2((float)0.5, (float)0.5), Color.Purple),
            new MenuButton(4,"CREDITS", new Vector2((float)0.5, (float)0.6), Color.Purple),
            new MenuButton(5,"EXIT", new Vector2((float)0.5, (float)0.7), Color.Purple)};


        TextBox newGameTextBox = new TextBox(new Vector2((float)0.5, (float)0.5),0.2,0.2, Color.Black);

        MenuButton[] newGameButtons = { new MenuButton(2, "Accept", new Vector2((float)0.6, (float)0.6), Color.Purple),
            new MenuButton(1, "Cancel", new Vector2((float)0.4, (float)0.6), Color.Purple) };



        public void LoadContent(ContentManager content, GraphicsDevice graphicsDevice)
        {
            Content = content;

            foreach (var item in mainMenuButtons)
            {
                item.LoadContent(Content,graphicsDevice);
            }

            foreach (var item in newGameButtons)
            {
                item.LoadContent(Content, graphicsDevice);
            }

            newGameTextBox.LoadContent(Content, graphicsDevice);


        }
        public void UnloadContent()
        {
            foreach (var item in mainMenuButtons)
            {
                item.UnloadContent();
            }
            foreach (var item in newGameButtons)
            {
                item.UnloadContent();
            }

            newGameTextBox.UnloadContent();

        }


        public void Update(GameTime gameTime)
        {
            switch (menu)
            {
                case MenuState.MAINMENU:
                    foreach (var item in mainMenuButtons)
                    {
                        switch (item.IsClicked())
                        {
                            case 1:
                                menu = MenuState.NEWGAME;
                                break;
                            case 2:
                                menu = MenuState.LOADGAME;
                                break;
                            case 3:
                                menu = MenuState.OPTIONS;
                                break;
                            case 4:
                                menu = MenuState.CREDITS;
                                break;
                            case 5:
                                menu = MenuState.EXIT;
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case MenuState.NEWGAME:
                    newGameTextBox.Update(gameTime);
                    foreach (var item in newGameButtons)
                    {
                        switch (item.IsClicked())
                        {
                            case 1:
                                menu = MenuState.MAINMENU;
                                break;
                            case 2:
                                menu = MenuState.PLAY;
                                break;
                            default:
                                break;
                        }
                    }


                    break;
                case MenuState.OPTIONS:
                    break;
                case MenuState.LOADGAME:
                    break;
                case MenuState.CREDITS:
                    break;
                case MenuState.EXIT:
                    break;
                default:
                    break;
            }

            
           
        }



        public void Draw(SpriteBatch spriteBatch)
        {

            switch (menu)
            {
                case MenuState.MAINMENU:
                    foreach (var item in mainMenuButtons)
                    {
                        item.Draw(spriteBatch);

                    }

                    break;
                case MenuState.NEWGAME:
                    foreach (var item in newGameButtons)
                    {
                        item.Draw(spriteBatch);

                    }
                    newGameTextBox.Draw(spriteBatch);
                       
                    break;
                case MenuState.OPTIONS:
                    break;
                case MenuState.LOADGAME:
                    break;
                case MenuState.CREDITS:
                    break;
                case MenuState.EXIT:
                    System.Environment.Exit(1);
                    break;
                default:
                    break;
            }

            
            

        }


    }
}
