using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi
{
    public static class Constants
    {
        //mario state constants
        public const int blinkFramecount = 5;
        public const int invinciblityTimeout = 28;
        public const int hitTimeout = 35;
        public const int itemTimeout = 60;
        public const int starTimeout = 500;//could use refining
        //level drawing constants
        public const int levelHeight = 240;//calibrated via testing
        public static Color backgroundOneColor = new Color(92, 148, 252);//this color matches the sky color of BackgroundOne.
        public const int undergroundSectionDepth = -8000;//should be plenty.
        //object behavior constants
        public const int flagpoleEdge = 3166;//seems fine
        public const int bottomOfFlagpole = 416;
        public const int castleDoorPos = 37 + 3232;//39 is the pixels from left side to door center, 3232 is castle left edge in xml.
        public const int enemyWakeDistance = 800;
        public const int tileLength = 16;
        public const int ticksPerFrame = 5;//maybe still a little fast?
        //camera constants
        public const int cameraBuffer = 450;
        public const int cameraVelocity = 3; //4 makes the camera too jittery to be pleasant, 2 allows for mario to outrun the camera.
        public const int screenWidth = 800;
        //mario physics constants
        public const int jumpLimit = 25;
        public const double velocityDecay = 0.8;
        public const int marioRunningSpeed = 3;
        public const int marioWalkingSpeed = 2;
        public const int marioFallingSpeed = 1;
        public const int marioJumpingSpeed = 4;
        public const int marioBounceLimit = 20;
        public const int marioBoostLimit = 50;
        public const int marioBounceDisplacement = 2;
        //luigi physics constants
        public const int luigiRunningSpeed = 3;
        public const int luigiWalkingSpeed = 2;
        public const int luigiFallingSpeed = 1;
        public const int luigiJumpingSpeed = 4;
        public const int luigiBounceLimit = 20;
        public const int luigiBoostLimit = 50;
        public const int luigiBounceDisplacement = 2;
        //HUD constants
        public const int initialTime = 400;
        public const int coinValue = 200;
        public const int brokenBrickValue = 50;
        public const int mushroomValue = 1000;
        public const int fireflowerValue = 1000;
        public const int starValue = 1000;
        public const int oneUpValue = 1000;
        public const int initialLives = 3;
        //level warp constants
        public static Tuple<int,int> verticalWarp = new Tuple<int,int>(-7984,432);//todo: calibrate
        public static Tuple<int,int> horizontalWarp = new Tuple<int,int>(2624,400);//todo: calibrate


    }
}
