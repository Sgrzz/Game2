using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.IO;
using System.Collections.Generic;

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
            string path;
            path = "C:\\Users\\Estagio\\Desktop\\Items.txt"; //Exemplo
            StreamReader listItems = new StreamReader(path);
            {
                int x= 0;
                while (!listItems.EndOfStream)
                {                   
                    items.Add(new Item(listItems.ReadLine()));

                    items[x].description = listItems.ReadLine();
                    x++;
                }              
            }
            listItems.Close();           
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
            position.X = (float) 0.01;
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
            
            foreach (var item in allItems)
            {
                spriteBatch.Draw(item.img, new Vector2((float)((spriteBatch.GraphicsDevice.Viewport.Width *( position.X + multiplierX))), (float)(spriteBatch.GraphicsDevice.Viewport.Height * (position.Y + multiplierY))), Color.White);

                multiplierX = multiplierX == 0.12*(7) ? 0 : multiplierX += 0.12;
                multiplierY = multiplierX == 0.12*(7) ? multiplierY += 0.16 : multiplierY;
                multiplierY = multiplierY == 0.16*(2) ? 0 : multiplierY;
                 
              
            }

            
            

        }
    }
}
