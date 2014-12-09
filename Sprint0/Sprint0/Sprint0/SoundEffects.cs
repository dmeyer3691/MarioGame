using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections;

namespace TeamYoshi
{

    public class SoundEffects : Microsoft.Xna.Framework.Game
    {
        private Song marioTheme;
        private SoundEffect oneUp;
        private SoundEffect breakBlock;
        private SoundEffect bump;
        private SoundEffect coin;
        private SoundEffect fireball;
        private SoundEffect flagpole;
        private SoundEffect gameOver;
        private SoundEffect kick;
        private SoundEffect jumpSmall;
        private SoundEffect pause;
        private SoundEffect pipe;
        private SoundEffect powerup;
        private SoundEffect popup;
        private SoundEffect stageClear;
        private SoundEffect timeWarning;
        private SoundEffect marioDie;

        public SoundEffects()
        {
            Content.RootDirectory = "Content";
            marioTheme = Content.Load<Song>("Sounds/main-theme-overworld");
            oneUp = Content.Load<SoundEffect>("Sounds/smb_1-up");
            breakBlock = Content.Load<SoundEffect>("Sounds/smb_breakblock");
            bump = Content.Load<SoundEffect>("Sounds/smb_bump");
            coin = Content.Load<SoundEffect>("Sounds/smb_coin");
            fireball = Content.Load<SoundEffect>("Sounds/smb_fireball");
            flagpole = Content.Load<SoundEffect>("Sounds/smb_flagpole");
            gameOver = Content.Load<SoundEffect>("Sounds/smb_gameover");
            kick = Content.Load<SoundEffect>("Sounds/smb_kick");
            pause = Content.Load<SoundEffect>("Sounds/smb_pause");
            pipe = Content.Load<SoundEffect>("Sounds/smb_pipe");
            powerup = Content.Load<SoundEffect>("Sounds/smb_powerup");
            popup = Content.Load<SoundEffect>("Sounds/smb_powerup_appears");
            stageClear = Content.Load<SoundEffect>("Sounds/smb_stage_clear");
            timeWarning = Content.Load<SoundEffect>("Sounds/smb_warning");
            jumpSmall = Content.Load<SoundEffect>("Sounds/smb_jumpsmall");
            marioDie = Content.Load<SoundEffect>("Sounds/smb_mariodie");


        }

        public void StartTheme()
        {
            MediaPlayer.Play(marioTheme);
            MediaPlayer.IsRepeating = true;
        }

        public void StopTheme()
        {
            MediaPlayer.Stop();
        }

        public void OneUp()
        {
            oneUp.Play();
        }

        public void FlagPole()
        {
            flagpole.Play();
        }

        public void Pipe()
        {
            pipe.Play();
        }

        public void JumpSmall()
        {
            // Its buggy since it can call really really fast.
            //jumpSmall.Play();
        }

        public void GameOver()
        {
            gameOver.Play();
        }

        public void Powerup()
        {
            powerup.Play();
        }

        public void Pause()
        {
            pause.Play();
        }

        public void Popup()
        {
            popup.Play();
        }

        public void Coin()
        {
            coin.Play();
        }

        public void MarioDie()
        {
            marioDie.Play();
        }

        public void LuigiDie()
        {
            marioDie.Play();
        }

        public void Fireball()
        {
            fireball.Play();
        }

        public void Bump()
        {
            bump.Play();
        }

        public void Kick()
        {
            kick.Play();
        }

        public void BreakBlock()
        {
            breakBlock.Play();
        }

    }
}
