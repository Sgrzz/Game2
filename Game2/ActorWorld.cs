using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Game2
{
    class ActorWorld : Actor
    {

        enum MovingState
        {
            moving,stop
        }

        MovingState currentState = MovingState.stop;

        string direction;

        public ActorWorld(int id, Vector2 position, float height, float width, string texture) : base(id, position, height, width, texture)
        {

        }

        public new void Update(GameTime gameTime)
        {

            KeyboardState PressedKeyboard = Keyboard.GetState();

            foreach (var item in PressedKeyboard.GetPressedKeys())
            {
                switch (item)
                {
                    case Keys.W:
                        direction = "w";
                        currentState = MovingState.moving;
                        break;
                    case Keys.S:
                        direction = "s";
                        currentState = MovingState.moving;
                        break;
                    case Keys.A:
                        direction = "a";
                        currentState = MovingState.moving;
                        break;
                    case Keys.D:
                        direction = "d";
                        currentState = MovingState.moving;
                        break;
                    default:
                        break;
                }
            }


            Move();
            base.Update(gameTime);
        }

        private void Move()
        {
            switch (currentState)
            {
                case MovingState.moving:
                    base.position.X += 1;
                    break;
                case MovingState.stop:
                    break;
                default:
                    break;
            }


        }

    } 
}
