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
        double multiplierX = 0, multiplierY=0;

        private List<Item> LoadItems()
        {
            List<Item> items = new List<Item>();
            string path = (System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments))+ "\\MayhemOfSound\\SaveData\\User\\Items.txt";

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
                item.img = Content.Load<Texture2D>("Items\\"+item.id);
            }
            position.X = (float) 0.03;
            position.Y = (float) 0.03;

        }
        public void UnloadContent()
        {
        }

        public void Update(GameTime gameTime)
        {            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int c = allItems.Count;
            /*foreach (var item in allItems)
            {
                
                spriteBatch.Draw(item.img, new Vector2((float)((spriteBatch.GraphicsDevice.Viewport.Width *( position.X + multiplierX))), (float)(spriteBatch.GraphicsDevice.Viewport.Height * (position.Y + multiplierY))), Color.White);
                multiplierX = multiplierX == 0.12*(7) ? 0 : multiplierX += 0.12;
                multiplierY = multiplierX == 0.12*(7) ? multiplierY += 0.16 : multiplierY;
                multiplierY = multiplierY == 0.16*(2) ? 0 : multiplierY;
                         
            }*/

            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    if (( allItems.Count-1 ) < ( x + y * 10))
                    {
                        //preecher com blank
                        spriteBatch.Draw(Content.Load<Texture2D>("Items\\0"), new Vector2((float)((spriteBatch.GraphicsDevice.Viewport.Width * (position.X + (x * 0.06)))), (float)(spriteBatch.GraphicsDevice.Viewport.Height * (position.Y + (y * 0.16)))), Color.White);
                    }
                    else
                    {
                        spriteBatch.Draw(allItems[x + y * 10].img, new Vector2((float)((spriteBatch.GraphicsDevice.Viewport.Width * (position.X + (x*0.06) ))), (float)(spriteBatch.GraphicsDevice.Viewport.Height * (position.Y + (y*0.16) ))), Color.White);
                    }
                    //multiplierX = multiplierX == 0.06 * (allItems.Count) ? 0 : multiplierX += 0.06;
                    //multiplierY = multiplierX == 0.06 * (allItems.Count) ? multiplierY += 0.16 : multiplierY;
                    //multiplierY = multiplierY == 0.16 * (2) ? 0 : multiplierY;
                    
                }
            }

            
            

        }
    }
}
