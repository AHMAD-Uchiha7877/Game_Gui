using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PacMan.GameGL
{
    class GameTerminatorPlayer : GameObject
    {
        bool checkEnemy = false; // Set the initial value to false.

        public GameTerminatorPlayer(Image image, GameCell startCell) : base(GameObjectType.PLAYER, image)
        {
            this.CurrentCell = startCell;
        }

        public GameCell move(GameDirection direction)
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(direction);

            if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.REWARD)
            {
                RobotGame.AddScore();
            }
            if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.FireEnemy )
            {
                RobotGame.SetFireCheck(true);
            }
            else
            {
                RobotGame.SetFireCheck(false); // Reset the flag if not on FireEnemy.
            }

            this.CurrentCell = nextCell;

            if (currentCell != nextCell)
            {
                currentCell.setGameObject(RobotGame.getBlankGameObject());
            }
            return nextCell;
        }

        public void Set_BulletCheckPlayer(bool check)
        {
            checkEnemy = check;
        }

        public bool GetBulletEnemy_Check()
        {
            return checkEnemy;
        }
    }

}
