using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using PacManGUI.GameGL;
namespace PacMan.GameGL
{
    public class RobotGame
    {

        static int score = 0;
        static bool flag = true;
        static bool flag_FireCheck = false;

        public static GameObject getBlankGameObject()
        {
            GameObject blankGameObject = new GameObject(GameObjectType.NONE, PacManGUI.Properties.Resources.simplebox);
            return blankGameObject;
        }

        public static GameObject getCurrentObject(GameCell c)
        {

            GameObject Object = new GameObject(c.CurrentGameObject.GameObjectType, c.CurrentGameObject.Image);

            return Object;
        }

        public static void AddScore()
        {
            score = score + 7;

        }

        public static void decreaseHealth(Enemy enemy)
        {
            enemy.health -= 50;
        }

        public static void SetFireCheck(bool check)
        {
            flag_FireCheck = check;
        }

        public static bool GetFireCheck()
        {
            return flag_FireCheck;
        }

        public static void SetFlag(bool value)
        {
            flag = value;
        }

        public static bool GetFlag()
        {
            return flag;
        }
        public static int ReturnScore()
        {
            return score;
        }
        public static Image getGameObjectImage(char displayCharacter)
        {
            Image img = PacManGUI.Properties.Resources.simplebox;
            if (displayCharacter == '|' || displayCharacter == '%')
            {
                img = PacManGUI.Properties.Resources.vertical;
            }

            if (displayCharacter == '#')
            {
                img = PacManGUI.Properties.Resources.horizontal;
            }

            if (displayCharacter == '.')
            {
                img = PacManGUI.Properties.Resources.pallet;
            }
            if (displayCharacter == 'P' || displayCharacter == 'p')
            {
                img = PacManGUI.Properties.Resources.player1;
            }

            return img;
        }
    }
}
