using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace FusioncoreDAF
{
   static class GameElements
    {
        static Player player;
        
        static List<GoldCoin> goldCoins;
        static Texture2D goldCoinSprite;
        static PrintText printText;
        static Background background;

        public enum State { Menu, Run, HighScore, EnterHighScore, PrintHighScore, Quit };

        public static State currentState;
        static Menu menu;

        public static void Initialize()
        {
            goldCoins = new List<GoldCoin>();
        }



        public static void LoadContent(ContentManager content, GameWindow window)
        {
            menu = new Menu((int)State.Menu);
            menu.AddItem(content.Load<Texture2D>("start"), (int)State.Run);
            menu.AddItem(content.Load<Texture2D>("highscore"), (int)State.HighScore);
            menu.AddItem(content.Load<Texture2D>("exit"), (int)State.Quit);

            background = new Background(content.Load<Texture2D>("background"), window);

            player = new Player(content.Load<Texture2D>("Black_viper2"), 380, 400, 2.5f, 4.5f);
            printText = new PrintText(content.Load<SpriteFont>("myFont"));





            goldCoinSprite = content.Load<Texture2D>("coin");

        }
        public static State MenuUpdate(GameTime gameTime)
        {
            return (State)menu.Update(gameTime);
        }
        public static void MenuDraw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
            menu.Draw(spriteBatch);
        }
        public static State RunUpdate(ContentManager content, GameWindow window, GameTime gameTime)
        {

            background.Update(window);
            player.Update(window, gameTime);

           
            Random random = new Random();
            int newCoin = random.Next(1, 200);
            if (newCoin == 1)
            {
                int rndX = random.Next(0, window.ClientBounds.Width - goldCoinSprite.Width);

                int rndY = random.Next(0, window.ClientBounds.Height - goldCoinSprite.Height);

                goldCoins.Add(new GoldCoin(goldCoinSprite, rndX, rndY, gameTime));
            }

            foreach (GoldCoin gc in goldCoins.ToList())
            {
                if (gc.IsAlive)
                {
                    gc.Update(gameTime);

                    if (gc.CheckCollision(player))
                    {
                        goldCoins.Remove(gc);
                        player.Points++;
                    }
                }
                else
                    goldCoins.Remove(gc);
            }
            if (!player.IsAlive)
            {
                Reset(window, content);
                return State.Menu;
            }

            if (!player.IsAlive)
                return State.Menu;
            return State.Run;
        }

       

        public static void RunDraw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
            player.Draw(spriteBatch);
           
            foreach (GoldCoin gc in goldCoins)
                gc.Draw(spriteBatch);
            printText.Print("Points: " + player.Points, spriteBatch, 0, 0);
        }
        public static State HighScoreUpdate()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Escape))
                return State.Menu;
            return State.HighScore;
        }
        public static void HighScoreDraw(SpriteBatch spriteBatch)
        {

        }

        private static void Reset(GameWindow window, ContentManager content)
        {
            player.Reset(380, 400, 2.5f, 4.5f);



        }

    }
}

