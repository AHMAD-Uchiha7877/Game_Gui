using PacMan.GameGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PacManGUI.GameGL;

namespace Game.GameGL
{
    class GameFire : GameObject
    {
        private int directionX;
        bool flag = true;
        bool flag2 = false;
        bool flag3 = false;
        public GameFire()
        { }
        public GameFire(char DisplayCharacter, GameObjectType type, GameCell cell) : base(type, DisplayCharacter)
        {
            this.DisplayCharacter = DisplayCharacter;
            this.GameObjectType = type;
        }
        public GameFire(Image img, GameObjectType type, GameCell cell) : base(type, img)
        {
            this.CurrentCell = cell;
            this.GameObjectType = type;
            this.Image = img;
        }
        public GameCell MoveEnemyFireLeft(GameGrid grid)
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = grid.getCell(CurrentCell.X, CurrentCell.Y - 1);
            if (nextCell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
            {
                if (nextCell != null)
                {
                    currentCell.setGameObject(RobotGame.getBlankGameObject());
                    CurrentCell = nextCell;
                    return nextCell;
                }
            }

            if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.PLAYER)
            {
                RobotGame.SetFireCheck(true);

            }
            if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.WALL)
            {
                SetFlag();

            }
            return null;

        }
        public GameCell MoveEnemyFireRight(GameGrid grid)
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = grid.getCell(CurrentCell.X, CurrentCell.Y + 1);
            if (nextCell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
            {
                if (nextCell != null)
                {
                    currentCell.setGameObject(RobotGame.getBlankGameObject());
                    CurrentCell = nextCell;
                    return nextCell;
                }
            }
            if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.PLAYER)
            {
                RobotGame.SetFireCheck(true);
               


            }

            if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.WALL)
            {
                SetFlag();
            }
            return null;
        }
        public GameCell MovePlayerFireRight(GameGrid grid)
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = grid.getCell(CurrentCell.X, CurrentCell.Y + 1);
            if (nextCell != null)
            {
                if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.ENEMY)
                {
                    Enemy enemy = (Enemy)nextCell.CurrentGameObject;
                    SetFlag3();
                    RobotGame.decreaseHealth(enemy);
                    RobotGame.AddScore();
                }
                if (nextCell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                {
                    currentCell.setGameObject(RobotGame.getBlankGameObject());
                    CurrentCell = nextCell;
                    return nextCell;
                }
                else
                {
                    SetFlag();
                }
            }

            return null;
        }

        public GameCell MovePlayerFireLeft(GameGrid grid)
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = grid.getCell(CurrentCell.X, CurrentCell.Y - 1);

            if (nextCell != null)
            {
                if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.ENEMY)
                {
                    Enemy enemy = (Enemy)nextCell.CurrentGameObject;
                    SetFlag3();
                    RobotGame.decreaseHealth(enemy);
                    RobotGame.AddScore();
                }

                if (nextCell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                {
                    currentCell.setGameObject(RobotGame.getBlankGameObject());
                    CurrentCell = nextCell;
                    return nextCell;
                }
                else
                {
                    SetFlag();
                }
            }

            return null;
        }
        public void SetFlag2()
        {
            flag2 = true;
        }
        public void SetFlag3()
        {
            flag3 = true;
        }
        public bool GetFlag2()
        {
            return flag2;
        }

        public void SetFlag()
        {
            flag = false;
        }
        public bool GetFlag()
        {
            return flag;
        }
        public bool GetFlag3()
        {
            return flag3;
        }

    }
}
