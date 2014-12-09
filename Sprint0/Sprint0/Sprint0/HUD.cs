using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi
{
    public class HUD
    {
        private int Time;

        private int MarioScore;
        private int MarioCoins;
        private int MarioLives;
        private int LuigiScore;
        private int LuigiCoins;
        private int LuigiLives;
        private int[] enemyKilledPoints;
        private int luigiEnemyKilledCount;
        private int marioEnemyKilledCount;

        public Achievements achievements;

        public HUD()
        {
            MarioLives = Constants.initialLives;
            MarioScore = 0;
            MarioCoins = 0;
            LuigiLives = Constants.initialLives;
            LuigiScore = 0;
            LuigiCoins = 0;
            Time = Constants.initialTime;
            enemyKilledPoints = new int[10] {100, 200, 400, 500, 800, 1000, 2000, 4000, 8000, 10000};
            marioEnemyKilledCount = 0;
            luigiEnemyKilledCount = 0;
            achievements = new Achievements();
        }

        public void Update(double time, double previous)
        {
            Time = Constants.initialTime - (int)(time-previous);
        }

        public void Draw(SpriteBatch batch, SpriteFont font, bool twoPlayer)
        {
            if (twoPlayer)
            {
                batch.DrawString(font, "MARIO" + addSpaces(4) + "COINS" + addSpaces(4) + "LIVES" + addSpaces(4) + "TIME" + addSpaces(5) + "WORLD" + addSpaces(5) + "LUIGI" + addSpaces(4) + "COINS" + addSpaces(4) + "LIVES", new Vector2(10, 10), Color.White);
                batch.DrawString(font, formattedScore(MarioScore) + addSpaces(3) + formattedCoins(MarioCoins) + addSpaces(7) + formattedLives(MarioLives) + addSpaces(7) + Time.ToString() + addSpaces(6) + "1-1"  + addSpaces(7) + formattedScore(LuigiScore) + addSpaces(3) + formattedCoins(LuigiCoins) + addSpaces(7) + formattedLives(LuigiLives), new Vector2(10, 25), Color.White);

            }
            else
            {
                batch.DrawString(font, "MARIO" + addSpaces(4) + "COINS" + addSpaces(4) + "LIVES" + addSpaces(5) + "TIME" + addSpaces(4) + "WORLD", new Vector2(10, 10), Color.White);
                batch.DrawString(font, formattedScore(MarioScore) + addSpaces(3) + formattedCoins(MarioCoins) + addSpaces(7) + formattedLives(MarioLives) + addSpaces(8) + Time.ToString() + addSpaces(5) + "1-1" , new Vector2(10, 25), Color.White);
            }
            achievements.Draw(batch, font);
        }

        public void marioEnemyKill(Mario mario)
        {
            if (mario.isInKillSequence())
            {
                marioEnemyKilledCount++;
            }
            else
            {
                marioEnemyKilledCount = 0;
            }
            MarioScore += enemyKilledPoints[marioEnemyKilledCount];
        }

        public void luigiEnemyKill(Luigi luigi)
        {
            if (luigi.isInKillSequence())
            {
                luigiEnemyKilledCount++;
            }
            else
            {
                luigiEnemyKilledCount = 0;
            }
            LuigiScore += enemyKilledPoints[luigiEnemyKilledCount];
        }

        public void addCoinMario()
        {
            MarioCoins++;
        }

        public void addCoinLuigi()
        {
            LuigiCoins++;
        }

        public void extraLifeMario()
        {
            MarioLives++;
        }

        public void extraLifeLuigi()
        {
            LuigiLives++;
        }

        public void lifeLostMario()
        {
            if (MarioLives == 0)
            {
                //death screen
            }
            else if (MarioLives > 0)
            {
                MarioLives--;
                //restart screen
            }
        }

        public void lifeLostLuigi()
        {
            if (LuigiLives == 0)
            {
                //death screen
            }
            else if (LuigiLives > 0)
            {
                LuigiLives--;
                //restart screen
            }
        }

        public void increaseScoreLuigi(int score)
        {
            LuigiScore += score;
        }

        public void increaseScoreMario(int score)
        {
            MarioScore += score;
        }

        private String addSpaces(int spaces)
        {
            String text = "";
            for (int i = 0; i < spaces; i++) text = text + " ";
            return text;
        }

        private String formattedScore(int score)
        {
            int gameScore = score;
            String text = "";
            for (int i = 0; i < 6; i++)
            {
                text = (gameScore % 10) + text;
                gameScore /= 10;
            }
            return text;
        }

        private String formattedCoins(int coins)
        {
            String text = "";
            if (coins < 10)
            {
                text = "0" + coins.ToString();
            }
            else
            {
                text = coins.ToString();
            }
            return text;
        }

        private String formattedLives(int lives)
        {
            String text = "";
            if (lives < 10)
            {
                text = "0" + lives.ToString();
            }
            else if (lives > 99)
            {
                text = "99";
                lives = 99;
            }
            else
            {
                text = lives.ToString();
            }
            return text;
        }
    }
}
