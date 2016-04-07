using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;



namespace Game2
{
    class Item
    {
        public Texture2D img { get; set; }
        public string id { get; set; }
        public string description { get; set; }
        public Vector2 position;
        public Boolean clicked { get; private set; } = false;

        public Item (string id)
        {
            this.id = id;
        }

        private bool IsCursorOn()
        {
            MouseState cursor = Mouse.GetState();

            if (position.X < cursor.X && position.Y < cursor.Y && position.X + img.Width > cursor.X && position.Y+ img.Height > cursor.Y)
                return true;
            return false;
        }

        public void IsClicked()
        {
            MouseState cursor = Mouse.GetState();
            if (IsCursorOn() && (cursor.LeftButton == ButtonState.Pressed))
                clicked = true;
            else
                clicked = false;

            
        }

    }
}
