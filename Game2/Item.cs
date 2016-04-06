using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game2
{
    class Item
    {
        public Texture2D img { get; set; }
        public string id { get; set; }
        public string description { get; set; }

        public Item (string id)
        {
            this.id = id;
        }
               
    }
}
