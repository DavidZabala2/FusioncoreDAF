using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
<<<<<<< HEAD
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace FusioncoreDAF
{
    class Player : PhysicalObject
    {
      
        
        double timeSinceLastBullet = 0;
        int points = 0;
        public int Points { get { return points; } set { points = value; } }
   
        public  Player(Texture2D texture, float X, float Y, float speedX, float speedY, Texture2D bulletTexture) : base(texture, X, Y, speedX, speedY)
        {
        }

=======
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FusioncoreDAF
{ /// <summary>
/// 
/// </summary>
    class Player : PhysicalObject
    {
        int points = 0;
        public int Points { get { return points; } set { points = value; } }

        public Player(Texture2D texture, float X, float Y, float speedX, float speedY)
           : base(texture, X, Y, speedX, speedY)
        {
        }
>>>>>>> master
        public void Reset(float X, float Y, float speedX, float speedY)
        {
            vector.X = X;
            vector.Y = Y;
            speed.X = speedX;
            speed.Y = speedY;
<<<<<<< HEAD
        }
        public void Update(GameWindow window, GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

=======
            points = 0;
            isAlive = true;
        }
            public void Update(GameWindow window, GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();


>>>>>>> master
            if (vector.X <= window.ClientBounds.Width - texture.Width && vector.X >= 0)
            {
                if (keyboardState.IsKeyDown(Keys.Right))
                    vector.X += speed.X;
                if (keyboardState.IsKeyDown(Keys.Left))
                    vector.X -= speed.X;
            }
<<<<<<< HEAD
=======


>>>>>>> master
            if (vector.Y <= window.ClientBounds.Height - texture.Height && vector.Y >= 0)
            {
                if (keyboardState.IsKeyDown(Keys.Down))
                    vector.Y += speed.Y;
                if (keyboardState.IsKeyDown(Keys.Up))
                    vector.Y -= speed.Y;
            }

            if (vector.X < 0)
                vector.X = 0;

            if (vector.X > window.ClientBounds.Width - texture.Width)
            {
                vector.X = window.ClientBounds.Width - texture.Width;
            }
<<<<<<< HEAD
            if (vector.Y < 0)
                vector.Y = 0;
=======

            if (vector.Y < 0)
                vector.Y = 0;

>>>>>>> master
            if (vector.Y > window.ClientBounds.Height - texture.Height)
            {
                vector.Y = window.ClientBounds.Height - texture.Height;
            }
<<<<<<< HEAD
            
        }
    }
}










=======

        }
        public void Update()
        {
            vector.Y -= speed.Y;
            if (vector.Y < 0)
                isAlive = false;
        }
    }
}
 
>>>>>>> master
