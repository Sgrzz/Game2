using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Game2
{
    class MainMenu
    {
        ContentManager Content;



        enum MenuState
        {
            MAINMENU, NEWGAME, OPTIONS, LOADGAME, CREDITS, EXIT, PLAY
        }

        MenuState menu = MenuState.MAINMENU;

        public bool IsDone { get; set; } = false;

        //mainmenu

        MenuButton[] buttonsMainMenu ={
            new MenuButton(1,"NEW GAME", new Vector2((float)0.5, (float)0.3), new Color(91,23,91)),
            new MenuButton(3,"OPTIONS", new Vector2((float)0.5, (float)0.5), new Color(91,23,91)),
            new MenuButton(2,"LOAD GAME", new Vector2((float)0.5, (float)0.4), new Color(91,23,91)),
            new MenuButton(4,"CREDITS", new Vector2((float)0.5, (float)0.6), new Color(91,23,91)),
            new MenuButton(5,"EXIT", new Vector2((float)0.5, (float)0.7),  new Color(91,23,91))};


        //new game

        TextBox textBoxNewGame = new TextBox(new Vector2((float)0.5, (float)0.5),0.2,0.2, new Color(91, 23, 91));

        MenuButton[] buttonsNewGame = { new MenuButton(2, "Accept", new Vector2((float)0.6, (float)0.6),  new Color(91,23,91)),
            new MenuButton(1, "Cancel", new Vector2((float)0.4, (float)0.6),  new Color(91,23,91)) };

        Label labelCharacter = new Label("Type the save name:", new Vector2((float)0.5, (float)0.4), new Color(91, 23, 91), true);
        public string saveName { get; set; } = "";

        //credits
        Label[] labelCredits =
        {
            new Label("Developed by:", new Vector2((float)0.5, (float)0.1), Color.Red, true),
            new Label("Alexandre Fernandes      Paulo Goncalves", new Vector2((float)0.5, (float)0.2), Color.Red, true),
            new Label("Graphics:", new Vector2((float)0.5, (float)0.3), Color.Red, true),
            new Label("ainda nao roubado nas internets", new Vector2((float)0.5, (float)0.4), Color.Red, true),
            new Label("Sound:", new Vector2((float)0.5, (float)0.5), Color.Red, true),
            new Label("Same", new Vector2((float)0.5, (float)0.6), Color.Red, true),
            new Label("Developed in context for a assignment", new Vector2((float)0.5, (float)0.7), Color.Red, true)
        };

        MenuButton[] buttonsCredits = { new MenuButton(1, "BACK", new Vector2((float)0.5, (float)0.9), Color.Purple) };

        //loadGame
        LoadGame loadGame = new LoadGame();




        public void LoadContent(ContentManager content, GraphicsDevice graphicsDevice)
        {
            Content = content;


            //mainmenu

            foreach (var item in buttonsMainMenu)
            {
                item.LoadContent(Content,graphicsDevice);
            }

            //new game

            foreach (var item in buttonsNewGame)
            {
                item.LoadContent(Content, graphicsDevice);
            }

            textBoxNewGame.LoadContent(Content, graphicsDevice);

            labelCharacter.LoadContent(Content, graphicsDevice);


            //credits

            foreach (var item in labelCredits)
            {
                item.LoadContent(content, graphicsDevice);
            }

            foreach (var item in buttonsCredits)
            {
                item.LoadContent(Content, graphicsDevice);
            }


            loadGame.LoadContent(Content,graphicsDevice);

        }
        public void UnloadContent()
        {

            //mainmenu
            foreach (var item in buttonsMainMenu)
            {
                item.UnloadContent();
            }

            //new game
            foreach (var item in buttonsNewGame)
            {
                item.UnloadContent();
            }

            textBoxNewGame.UnloadContent();
            labelCharacter.UnloadContent();

            //credits
            foreach (var item in labelCredits)
            {
                item.UnloadContent();
            }

            foreach (var item in buttonsCredits)
            {
                item.UnloadContent();
            }

            loadGame.UnLoadContent();
        }

        


        public void Update(GameTime gameTime)
        {
            switch (menu)
            {
                case MenuState.MAINMENU:
                    foreach (var item in buttonsMainMenu)
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
                    textBoxNewGame.Update(gameTime);
                    foreach (var item in buttonsNewGame)
                    {
                        switch (item.IsClicked())
                        {
                            case 1:
                                menu = MenuState.MAINMENU;
                                break;
                            case 2:
                                if (textBoxNewGame.Text()!="")
                                {
                                    menu = MenuState.PLAY;
                                    IsDone = true;
                                    saveName = textBoxNewGame.Text();

                                    Directory.CreateDirectory((System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments)) + "\\MayhemOfSound\\SaveData\\" + saveName);
                                    using (FileStream fs = File.Create((System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments)) + "\\MayhemOfSound\\SaveData\\" + saveName + "\\Items.txt"))
                                    {
                                        Byte[] info = new UTF8Encoding(true).GetBytes("1,1");
                                        fs.Write(info, 0, info.Length);
                                    }
                                    
                                }
                                else
                                {
                                    labelCharacter.Text("You must type in something!");
                                }
                                
                                


                                break;
                            default:
                                break;
                        }
                    }


                    break;
                case MenuState.OPTIONS:
                    break;
                case MenuState.LOADGAME:

                    loadGame.Update(gameTime);

                    break;
                case MenuState.CREDITS:
                        if (buttonsCredits[0].IsClicked()==1)
                        {
                            menu = MenuState.MAINMENU;
                        }
                    break;
                case MenuState.EXIT:
                    System.Environment.Exit(1);
                    break;
                default:
                    break;
            }

            
           
        }



        public void Draw(SpriteBatch spriteBatch)
        {


            //MouseState mouse = Mouse.GetState();
            //spriteBatch.DrawString(Content.Load<SpriteFont>("angry blue"), mouse.Position.ToString(), Vector2.Zero, Color.Black);

            switch (menu)
            {
                case MenuState.MAINMENU:
                    foreach (var item in buttonsMainMenu)
                    {
                        item.Draw(spriteBatch);
                        
                    }

                    break;
                case MenuState.NEWGAME:

                    

                    foreach (var item in buttonsNewGame)
                    {
                        item.Draw(spriteBatch);

                    }


                    labelCharacter.Draw(spriteBatch);
                    textBoxNewGame.Draw(spriteBatch);
                       
                    break;
                case MenuState.OPTIONS:
                    

                    break;
                case MenuState.LOADGAME:
                    loadGame.Draw(spriteBatch);
                    break;
                case MenuState.CREDITS:
                    foreach (var item in labelCredits)
                    {
                        item.Draw(spriteBatch);
                    }
                    foreach (var item in buttonsCredits)
                    {
                        item.Draw(spriteBatch);
                    }
                    break;
                case MenuState.EXIT:
                    
                    break;
                default:
                    break;
            }

            
            

        }


    }
}
