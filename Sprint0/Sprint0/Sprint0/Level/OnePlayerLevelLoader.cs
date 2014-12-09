using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TeamYoshi.Blocks;
using TeamYoshi.Enemies;
using TeamYoshi.Items;

namespace TeamYoshi
{
    static public class OnePlayerLevelLoader
    {
        /*Note: for the purposes of this level loader I assume that XML tags appear one tag per line. 
         * This is how the levels will be set up in the file, but is a restriction from XML at large.
         */

        static public OnePlayerLevel LoadLevelFromFile(String filename, SoundEffects s)
        {
            OnePlayerLevel level = null;
            filename = String.Concat("Content/", filename);
            using (StreamReader stream = new StreamReader(filename))
            {
                stream.ReadLine(); //should be an XML specifier
                level = LoadLevel(stream, s);
            }
            return level;
        }
        static private OnePlayerLevel LoadLevel(StreamReader stream, SoundEffects s)
        {
            List<IEnemy> enemies = new List<IEnemy>();
            List<IBlock> blocks = new List<IBlock>();
            List<IItem> items = new List<IItem>();
            List<IProjectile> projectiles = new List<IProjectile>();
            Mario mario = null;
            Luigi luigi = null;
            Flagpole flagpole = null;
            Camera cam = new Camera();
            HUD hud = new HUD();
            SoundEffects sound = s;

                String tag;

                stream.ReadLine(); //should be <level>
                while ((tag = stream.ReadLine()) != null && !tag.Equals("</level>"))
                {
                    string[] words = tag.Split(' ');
                    int? xpos = null;
                    int? ypos = null;
                    bool isMario = false;
                    bool isLuigi = false;
                    if (words[0].Equals("<mario")) isMario = true;
                    if (words[0].Equals("<luigi")) isLuigi = true;
                    //because type uniquely specifies things anyways, and type is required for non marios, no need to check for the other possibilities here.
                    String type = "";
                    for (int wordsCount = 1; wordsCount < words.Length; wordsCount++)
                    {
                        if (words[wordsCount].Length >= 6)
                        {
                            if(words[wordsCount].Substring(0,5).Equals("type=")) 
                            {
                                type = words[wordsCount].Substring(5).Trim('"').ToLower();                                
                            }
                            else if (words[wordsCount].Substring(0, 5).Equals("xpos="))
                            {
                                xpos = Int32.Parse(words[wordsCount].Substring(5).Trim('"'));
                            }
                            else if (words[wordsCount].Substring(0, 5).Equals("ypos="))
                            {
                                ypos = Int32.Parse(words[wordsCount].Substring(5).Trim('"'));
                            }
                        }
                    }
                    if (!xpos.HasValue || !ypos.HasValue) continue; //if we didn't read a position, we can't place it in the world. (if we didn't read a type, then type = "" and it wont get placed in a list anyways)
                    if (isMario)
                    {
                        mario = new Mario(xpos.Value, ypos.Value, cam, sound, projectiles);
                    }
                    else
                    {
                        switch (type.Trim('"'))
                        {
                            case "goomba":
                                enemies.Add(new Goomba(xpos.Value, ypos.Value, cam));
                                break;
                            case "greenkoopa":
                                enemies.Add(new GreenKoopa(xpos.Value, ypos.Value, cam));
                                break;
                            case "redkoopa":
                                enemies.Add(new RedKoopa(xpos.Value, ypos.Value, cam));
                                break;
                            case "piranha":
                                enemies.Add(new Piranha(xpos.Value, ypos.Value, cam));
                                break;

                            case "brick":
                                blocks.Add(new Brick(xpos.Value, ypos.Value, cam, BrickState.bempty));
                                break;
                            case "starbrick":
                                blocks.Add(new Brick(xpos.Value, ypos.Value, cam, BrickState.bstar));
                                break;
                            case "hitqblock":
                                blocks.Add(new Brick(xpos.Value, ypos.Value, cam, BrickState.qempty));
                                break;
                            case "qblock":
                                blocks.Add(new Brick(xpos.Value, ypos.Value, cam, BrickState.qcoin));
                                break;
                            case "qitem":
                                blocks.Add(new Brick(xpos.Value, ypos.Value, cam, BrickState.qitem));
                                break;
                            case "qlife":
                                blocks.Add(new Brick(xpos.Value, ypos.Value, cam, BrickState.qlife));
                                break;
                            case "pipe":
                                blocks.Add(new Pipe(xpos.Value, ypos.Value, cam));
                                break;
                            case "pipe2":
                                blocks.Add(new Pipe2(xpos.Value, ypos.Value, cam));
                                break;
                            case "vpipe":
                                blocks.Add(new VerticalWarpPipe(xpos.Value, ypos.Value, cam));
                                break;
                            case "hpipe":
                                blocks.Add(new HorizontalWarpPipe(xpos.Value, ypos.Value, cam));
                                break;
                            case "roughplatform":
                                blocks.Add(new RoughPlatform(xpos.Value, ypos.Value, cam));
                                break;
                            case "smoothplatform":
                                blocks.Add(new SmoothPlatform(xpos.Value, ypos.Value, cam));
                                break;
                            case "flagpole":
                                flagpole = new Flagpole(xpos.Value, ypos.Value, cam);
                                break;
                            case "castle":
                                blocks.Add(new Castle(xpos.Value, ypos.Value, cam));
                                break;
                            case "greenplatform":
                                blocks.Add(new GreenRoughPlatform(xpos.Value, ypos.Value, cam));
                                break;
                            case "greenbrick":
                                blocks.Add(new GreenBrick(xpos.Value, ypos.Value, cam));
                                break;
                            case "coin":
                                items.Add(new Coin(xpos.Value, ypos.Value, cam));
                                break;
                            case "fireflower":
                                items.Add(new Fireflower(xpos.Value, ypos.Value, cam));
                                break;
                            case "mushroom":
                                items.Add(new Mushroom(xpos.Value, ypos.Value, cam));
                                break;
                            case "oneup":
                                items.Add(new Oneup(xpos.Value, ypos.Value, cam));
                                break;
                            case "star":
                                items.Add(new Star(xpos.Value, ypos.Value, cam));
                                break;
                            default:
                                break;
                        }
                    }
                }
                cam.Init(mario);
                return new OnePlayerLevel(items, enemies, blocks, projectiles, mario, cam, hud, sound, flagpole);
        }
    }
}
