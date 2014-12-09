using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace TeamYoshi.Sprites
{
 
    public static class SpriteFactory
    {

        public static MarioSmallWalkingSprite MarioSmallWalking;
        public static MarioLargeWalkingSprite MarioLargeWalking;
        public static MarioFireWalkingSprite MarioFireWalking;

        public static LuigiSmallWalkingSprite LuigiSmallWalking;
        public static LuigiLargeWalkingSprite LuigiLargeWalking;
        public static LuigiFireWalkingSprite LuigiFireWalking;

        public static void loadContent(ContentManager content, SpriteBatch spritebatch)
        {
            LoadMarioContent(content, spritebatch);
            LoadLuigiContent(content, spritebatch);
            LoadEnemyContent(content, spritebatch);
            LoadBlockContent(content, spritebatch);
            LoadItemContent(content, spritebatch);

            // Background Sprite
            BackgroundSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/background"));
            // Underground Background Sprite
            BlackRectangleSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/blackrectangle"));
        }

        private static void LoadMarioContent(ContentManager content, SpriteBatch spritebatch)
        {
            // Mario Sprites
            MarioSmallStandingSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/Mario/small-standing-mario"));
            MarioLargeStandingSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/Mario/large-standing-mario"));
            MarioFireStandingSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/Mario/fire-standing-mario"));
            MarioSmallJumpingSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/Mario/small-jumping-mario"));
            MarioLargeJumpingSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/Mario/large-jumping-mario"));
            MarioFireJumpingSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/Mario/fire-jumping-mario"));
            MarioSmallSlidingSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/Mario/small-sliding-mario"));
            MarioLargeSlidingSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/Mario/large-sliding-mario"));
            MarioFireSlidingSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/Mario/fire-sliding-mario"));
            List<Texture2D> smallWalkingTexture = new List<Texture2D>();
            for (int i = 1; i < 4; i++) smallWalkingTexture.Add(content.Load<Texture2D>(String.Concat("Sprites/Mario/small-walking-mario-", i)));
            MarioSmallWalking = new MarioSmallWalkingSprite(spritebatch, smallWalkingTexture);
            List<Texture2D> largeWalkingTexture = new List<Texture2D>();
            for (int i = 1; i < 4; i++) largeWalkingTexture.Add(content.Load<Texture2D>(String.Concat("Sprites/Mario/large-walking-mario-", i)));
            MarioLargeWalking = new MarioLargeWalkingSprite(spritebatch, largeWalkingTexture);
            List<Texture2D> fireWalkingTexture = new List<Texture2D>();
            for (int i = 1; i < 4; i++) fireWalkingTexture.Add(content.Load<Texture2D>(String.Concat("Sprites/Mario/fire-walking-mario-", i)));
            MarioFireWalking = new MarioFireWalkingSprite(spritebatch, fireWalkingTexture);
            MarioLargeCrouchingSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/Mario/large-crouching-mario"));
            MarioFireCrouchingSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/Mario/fire-crouching-mario"));
            MarioDeadSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/Mario/dead-mario"));

            //Projectile Sprites
            List<Texture2D> fireballTexture = new List<Texture2D>();
            for (int i = 1; i < 5; i++) fireballTexture.Add(content.Load<Texture2D>(String.Concat("Sprites/Mario/fireball-", i)));
            FireballSprite.Init(spritebatch, fireballTexture);
        }

        private static void LoadLuigiContent(ContentManager content, SpriteBatch spritebatch)
        {
            // Luigi Sprites
            LuigiSmallStandingSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/Luigi/small-standing-luigi"));
            LuigiLargeStandingSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/Luigi/large-standing-luigi"));
            LuigiFireStandingSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/Luigi/fire-standing-luigi"));
            LuigiSmallJumpingSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/Luigi/small-jumping-luigi"));
            LuigiLargeJumpingSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/Luigi/large-jumping-luigi"));
            LuigiFireJumpingSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/Luigi/fire-jumping-luigi"));
            LuigiSmallSlidingSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/Luigi/small-sliding-luigi"));
            LuigiLargeSlidingSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/Luigi/large-sliding-luigi"));
            LuigiFireSlidingSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/Luigi/fire-sliding-luigi"));
            List<Texture2D> smallWalkingTexture = new List<Texture2D>();
            for (int i = 1; i < 4; i++) smallWalkingTexture.Add(content.Load<Texture2D>(String.Concat("Sprites/Luigi/small-walking-luigi-", i)));
            LuigiSmallWalking = new LuigiSmallWalkingSprite(spritebatch, smallWalkingTexture);
            List<Texture2D> largeWalkingTexture = new List<Texture2D>();
            for (int i = 1; i < 4; i++) largeWalkingTexture.Add(content.Load<Texture2D>(String.Concat("Sprites/Luigi/large-walking-luigi-", i)));
            LuigiLargeWalking = new LuigiLargeWalkingSprite(spritebatch, largeWalkingTexture);
            List<Texture2D> fireWalkingTexture = new List<Texture2D>();
            for (int i = 1; i < 4; i++) fireWalkingTexture.Add(content.Load<Texture2D>(String.Concat("Sprites/Luigi/fire-walking-luigi-", i)));
            LuigiFireWalking = new LuigiFireWalkingSprite(spritebatch, fireWalkingTexture);
            LuigiLargeCrouchingSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/Luigi/large-crouching-luigi"));
            LuigiFireCrouchingSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/Luigi/fire-crouching-luigi"));
            LuigiDeadSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/Luigi/dead-luigi"));

            //Projectile Sprites
            List<Texture2D> fireballTexture = new List<Texture2D>();
            for (int i = 1; i < 5; i++) fireballTexture.Add(content.Load<Texture2D>(String.Concat("Sprites/Luigi/fireball-", i)));
            FireballSprite.Init(spritebatch, fireballTexture);
        }

        private static void LoadEnemyContent(ContentManager content, SpriteBatch spritebatch)
        {
            // Enemies Sprites
            List<Texture2D> goombaTexture = new List<Texture2D>();
            for (int i = 1; i < 3; i++) goombaTexture.Add(content.Load<Texture2D>(String.Concat("Sprites/enemies/goomba-", i)));
            GoombaSprite.Init(spritebatch, goombaTexture);
            List<Texture2D> greenPlantTexture = new List<Texture2D>();
            for (int i = 1; i < 3; i++) greenPlantTexture.Add(content.Load<Texture2D>(String.Concat("Sprites/enemies/green-plant-", i)));
            GreenPlantSprite.Init(spritebatch, greenPlantTexture);
            List<Texture2D> greenTurtleTexture = new List<Texture2D>();
            for (int i = 1; i < 3; i++) greenTurtleTexture.Add(content.Load<Texture2D>(String.Concat("Sprites/enemies/green-turtle-", i)));
            GreenTurtleSprite.Init(spritebatch, greenTurtleTexture);
            List<Texture2D> redTurtleTexture = new List<Texture2D>();
            for (int i = 1; i < 3; i++) redTurtleTexture.Add(content.Load<Texture2D>(String.Concat("Sprites/enemies/red-turtle-", i)));
            RedTurtleSprite.Init(spritebatch, redTurtleTexture);
        }

        private static void LoadBlockContent(ContentManager content, SpriteBatch spritebatch)
        {
            // Blocks Sprites
            FlagpoleSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/blocks/flagpole"));
            CastleSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/blocks/castle"));
            HorizontalPipeSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/blocks/horizontal-pipe"));
            HitQBlockSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/blocks/hit-question-block"));
            QBlockSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/blocks/question-block"));
            TopBrickSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/blocks/top-border-brick"));
            BrickSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/blocks/lower-brick"));
            PipeSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/blocks/pipe"));
            Pipe2Sprite.Init(spritebatch, content.Load<Texture2D>("Sprites/blocks/pipe2"));
            RoughPlatformSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/blocks/rough-platform"));
            SmoothPlatformSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/blocks/smooth-platform"));
        }

        private static void LoadItemContent(ContentManager content, SpriteBatch spritebatch)
        {
            // Items Sprites
            CoinSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/items/coin"));
            FireflowerSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/items/fireflower"));
            List<Texture2D> oneUpTexture = new List<Texture2D>();
            for (int i = 1; i < 3; i++) oneUpTexture.Add(content.Load<Texture2D>(String.Concat("Sprites/items/life-up-", i)));
            OneUpSprite.Init(spritebatch, oneUpTexture);
            List<Texture2D> mushroomTexture = new List<Texture2D>();
            for (int i = 1; i < 3; i++) mushroomTexture.Add(content.Load<Texture2D>(String.Concat("Sprites/items/mushroom-", i)));
            MushroomSprite.Init(spritebatch, mushroomTexture);
            StarSprite.Init(spritebatch, content.Load<Texture2D>("Sprites/items/star"));
        }
    }
}
