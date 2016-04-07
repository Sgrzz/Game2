using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System;

namespace Game2
{
    class Inventory
    {
        ContentManager Content;
        List<Item> allItems;
        Vector2 position;
        Item isClickedItem;
        public Boolean IsDone=true;

        private List<Item> LoadItems()
        {
            List<Item> items = new List<Item>();
            string path = (System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments)) + "\\MayhemOfSound\\SaveData\\User\\Items.txt";

            StreamReader listItems = new StreamReader(path);
            string allI = listItems.ReadLine();


            listItems.Close();
            string[] itemA = allI.Split(',');

            using (XmlReader itemsXml = XmlReader.Create("Content\\items.xml"))
            {

                foreach (var item in itemA)
                {
                    items.Add(new Item(item));
                    while (itemsXml.Read())
                    {
                        if ((itemsXml.Name == "id") && (itemsXml.Name == items[(items.Count) - 1].id))
                        {
                            items[(items.Count) - 1].description = itemsXml.GetAttribute("description");
                        }
                    }
                }
            }

            return (items);

        }

        public void LoadContent(ContentManager content, GraphicsDevice graphicsDevice)
        {
            this.Content = content;
            allItems = LoadItems();
            foreach (var item in allItems)
            {
                item.img = Content.Load<Texture2D>("Items\\" + item.id);
            }
            position.X = (float)0.03;
            position.Y = (float)0.04;

        }
        public void UnloadContent()
        {
        }

        public void Update(GameTime gameTime, string saveName)
        {
            foreach (var item in allItems)
            {
                item.IsClicked();
                if (item.clicked)
                {
                    isClickedItem = item;
                }
            }
        
        }

        public void Draw(SpriteBatch spriteBatch)
        {




            spriteBatch.Draw(Content.Load<Texture2D>("Items\\bgInv"),(new Rectangle (0,0,(int)(spriteBatch.GraphicsDevice.Viewport.Width*0.64),(int)(spriteBatch.GraphicsDevice.Viewport.Height*0.55))),Color.White);
            //spriteBatch.Draw(Content.Load<Texture2D>("Items\\bgInv"), new Rectangle(),null,Color.White,0,Vector2.Zero,0.80f,SpriteEffects.None,0);

            spriteBatch.Draw(Content.Load<Texture2D>("Items\\bgInv"),
                (new Rectangle(((int)(spriteBatch.GraphicsDevice.Viewport.Width * 0.64)),0
                ,(int)(spriteBatch.GraphicsDevice.Viewport.Width * 0.36), (int)(spriteBatch.GraphicsDevice.Viewport.Height * 0.55))), Color.White);
            spriteBatch.Draw(Content.Load<Texture2D>("Items\\bgInv"),
                (new Rectangle(0, ((int)(spriteBatch.GraphicsDevice.Viewport.Height * 0.55))
                , (int)(spriteBatch.GraphicsDevice.Viewport.Width * 1), (int)(spriteBatch.GraphicsDevice.Viewport.Height * 0.45))), Color.White);
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    if ((allItems.Count - 1) >= (x + y * 10))
                    {
                        spriteBatch.DrawString(Content.Load<SpriteFont>("angryblue"),allItems[x+y*10].clicked.ToString(),Vector2.Zero,Color.White);
                    }
                    

                    if (((allItems.Count - 1) >= (x + y * 10)) && (isClickedItem==allItems[x+y*10]))
                    {

                        spriteBatch.Draw(Content.Load<Texture2D>("Items\\esc"), allItems[x+y*10].position, null, Color.White, 0, Vector2.Zero, 1.1f, SpriteEffects.None, 0);
                       
                    }
                    else
                    {
                        spriteBatch.Draw(Content.Load<Texture2D>("Items\\vazio"), new Vector2((float)((spriteBatch.GraphicsDevice.Viewport.Width * ((position.X - 0.002) + (x * 0.06)))), (float)(spriteBatch.GraphicsDevice.Viewport.Height * ((position.Y - 0.003) + (y * 0.1)))), null, Color.White, 0, Vector2.Zero, 1.1f, SpriteEffects.None, 0);
                    }
                    

                    if ((allItems.Count - 1) >= (x + y * 10))
                        {
                            spriteBatch.Draw(allItems[x + y * 10].img, new Vector2((float)((spriteBatch.GraphicsDevice.Viewport.Width * (position.X + (x * 0.06)))), (float)(spriteBatch.GraphicsDevice.Viewport.Height * (position.Y + (y * 0.1)))), Color.White);
                            allItems[x + y * 10].position = new Vector2((float)((spriteBatch.GraphicsDevice.Viewport.Width * ((position.X - 0.002) + (x * 0.06)))), (float)(spriteBatch.GraphicsDevice.Viewport.Height * ((position.Y - 0.003) + (y * 0.1))));
                            // spriteBatch                       
                        }
                    
                    
                }
            }




        }
    }
}
