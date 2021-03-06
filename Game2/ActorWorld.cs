﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Game2
{
    class ActorWorld : Actor
    {

        enum MovingState
        {
            MOVING,STOP
        }

        MovingState currentState = MovingState.STOP;

        int numMovements=0;
        int numMovenentsAllowed=50;

        float movespeed =(float) 0.001;

        string direction;

        public ActorWorld(int id, Vector2 position, float height, float width, string texture) : base(id, position, height, width, texture)
        {

        }




        public new void Update(GameTime gameTime)
        {

            KeyboardState PressedKeyboard = Keyboard.GetState();

            if (currentState==MovingState.STOP)
            {
               

                foreach (var item in PressedKeyboard.GetPressedKeys())
                {
                    switch (item)
                    {
                        case Keys.W:
                            direction = "w";
                            this.anim = "up";
                            currentState = MovingState.MOVING;
                            IsMoving = true;
                            break;
                        case Keys.S:
                            direction = "s";
                            this.anim = "down";
                            currentState = MovingState.MOVING;
                            IsMoving = true;
                            break;
                        case Keys.A:
                            direction = "a";
                            this.anim = "left";
                            currentState = MovingState.MOVING;
                            IsMoving = true;
                            break;
                        case Keys.D:
                            direction = "d";
                            this.anim = "right";
                            currentState = MovingState.MOVING;
                            IsMoving = true;
                            break;
                        default:
                            break;
                    }
                }

                
            }


            if (currentState == MovingState.MOVING)
                Move();
            
            


            
            base.Update(gameTime);
        }

        private void Move()
        {
            if (numMovements!=numMovenentsAllowed)
            {
                switch (direction)
                {

                    case "w":
                        base.position.Y -= 2*movespeed;
                        break;
                    case "s":
                        base.position.Y += 2*movespeed;
                        break;
                    case "a":
                        base.position.X -= movespeed;
                        break;
                    case "d":
                        base.position.X += movespeed;
                        break;

                    default:
                        break;


                }
                
                numMovements++;
                

            }
            else
            {
                numMovements = 0;
                IsMoving = false;
                currentState = MovingState.STOP;
            }


        }

    } 
}
