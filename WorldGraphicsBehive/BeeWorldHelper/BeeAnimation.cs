using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldGraphicsBehive.FlowerHelper;

namespace WorldGraphicsBehive.BeeWorldHelper
{
    public class BeeAnimation
    {
        Random rand = new Random();
        BeeData directionControl;
        int widthForm;
        int heightForm;
        int pixelMovement = 5;
        public List<Bitmap> AnimateBeeWings()
        {
            List<Bitmap> beeImagesList = new List<Bitmap>();
            beeImagesList.Add(WorldGraphicsBehive.Properties.Resources.Bee_animation_1a);
            beeImagesList.Add(WorldGraphicsBehive.Properties.Resources.Bee_animation_2a);
            beeImagesList.Add(WorldGraphicsBehive.Properties.Resources.Bee_animation_3a);
            beeImagesList.Add(WorldGraphicsBehive.Properties.Resources.Bee_animation_4a);
            beeImagesList.Add(WorldGraphicsBehive.Properties.Resources.Bee_animation_3a);
            beeImagesList.Add(WorldGraphicsBehive.Properties.Resources.Bee_animation_2a);
            return beeImagesList;
        }
        public void SetFormLimits(int widthHiveForm, int heightHiveForm)
        {
            widthForm = widthHiveForm;
            heightForm = heightHiveForm;
        }
        public void SetFormLimits(Point p)
        {
            widthForm = p.X;
            heightForm = p.Y;
        }
        public void SetBeeData(BeeData data)
        {
            directionControl = data;
        }
        //RANDOM Movement 1 of 4
        public Point GenerateRandomMovement(Enum directionToMove, Point p)
        {
            if (directionToMove != null)
            {
                if (directionToMove.ToString().Equals("Up"))
                {
                    p.Y = p.Y - pixelMovement;
                    p.X = p.X;
                    return p;
                }
                if (directionToMove.ToString().Equals("Down"))
                {
                    p.Y = p.Y + pixelMovement;
                    p.X = p.X;
                    return p;
                }
                if (directionToMove.ToString().Equals("Left"))
                {
                    p.X = p.X - pixelMovement;
                    p.Y = p.Y;
                    return p;
                }
                if (directionToMove.ToString().Equals("Right"))
                {
                    p.X = p.X + pixelMovement;
                    p.Y = p.Y;
                    return p;
                }
                if (directionToMove.ToString().Equals("Degrees45DiagonalUpRight"))
                {
                    p.X = p.X + pixelMovement;
                    p.Y = p.Y - pixelMovement;
                    return p;
                }
                if (directionToMove.ToString().Equals("Degrees45DiagonalUpLeft"))
                {
                    p.X = p.X - pixelMovement;
                    p.Y = p.Y - pixelMovement;
                    return p;
                }
                if (directionToMove.ToString().Equals("Degrees45DiagonalDownRight"))
                {
                    p.X = p.X + pixelMovement;
                    p.Y = p.Y + pixelMovement;
                    return p;
                }
                if (directionToMove.ToString().Equals("Degrees45DiagonalDownLeft"))
                {
                    p.X = p.X - pixelMovement;
                    p.Y = p.Y + pixelMovement;
                    return p;
                }
            }
            return p;
        }

        //RANDOM Movement 2 of 4
        public BeeData ControlWorldFormBoundaries(BeeData beeInfo)
        {
            int beeImageHeight = 50; //beeInfo.BeeImage.Height;
            int beeImageWidth = 50;// beeInfo.BeeImage.Width;
            directionControl = beeInfo;
            Point p = new Point();
            p.X = beeInfo.BeeWorldLocationX;
            p.Y = beeInfo.BeeWorldLocationY;
            //Case: Image Hits Top Limit
            //We are at the Top corner => We Move Back Down 
            if (p.Y < 10)
            {
                p.Y = p.Y + 2;

                directionControl.BeeWorldLocationY = p.Y;
                directionControl.BeeWorldLocationX = p.X;
                //We Change Direction and We Indicate the Image hit the top
                directionControl.DirectionToMoveEnum = ChangeDirection(WorldGraphicsBehive.BeeWorldHelper.Move.Up);
                return directionControl;
            }
            //Case: Image Hits Bottom Limit
            //We are at the Bottom corner => We Move Back Up 
            if (p.Y > heightForm - beeImageHeight - 40)
            {
                p.Y = p.Y - 2;
                directionControl.BeeWorldLocationY = p.Y;
                directionControl.BeeWorldLocationX = p.X;
                //We Change Direction and We Indicate the Image hit the bottom
                directionControl.DirectionToMoveEnum = ChangeDirection(WorldGraphicsBehive.BeeWorldHelper.Move.Down);
                return directionControl;
            }

            //Case: Image Hits Left Limit
            //We are at the left corner => We Move Back right
            if (p.X < 10)
            {
                p.X = p.X + 2;
                directionControl.BeeWorldLocationY = p.Y;
                directionControl.BeeWorldLocationX = p.X;
                //We Change Direction and We Indicate the Image hit the left
                directionControl.DirectionToMoveEnum = ChangeDirection(WorldGraphicsBehive.BeeWorldHelper.Move.Left);
                return directionControl;
            }
            //Case: Image Hits Right Limit
            //We are at the right corner => We Move Back left
            if (p.X > widthForm - beeImageWidth - 30)
            {
                p.X = p.X - 2;
                directionControl.BeeWorldLocationY = p.Y;
                directionControl.BeeWorldLocationX = p.X;
                //We Change Direction and We Indicate the Image hit the right
                directionControl.DirectionToMoveEnum = ChangeDirection(WorldGraphicsBehive.BeeWorldHelper.Move.Right);
                return directionControl;
            }
            return directionControl;
        }

        //RANDOM Movement 3 of 4
        public BeeData ControlBeeHiveFormBoundaries(BeeData beeInfo)//, BeeHiveForm insideBeehive )
        {
            int vectorHiveCornerAX = 35;
            int vectorHiveCornerAY = 80;

            int widthHive = widthForm - 80;  //240 px
            int heightHive = heightForm - 140; //210 px

            /*********BOUNDARIES*****************************
            We Constantly check the position of the Bee
            In relation to the Dimensions of the Hive inside View.
            *a |---------------------------------|d
            *  |                                 |
            *  |                                 |
            *  |                                 |
            *  |                                 |
            *  |                                 |
            *  |                                 |
            * b|---------------------------------|c
            * Vector a=(x,y)
            * Vector b=(x,y+height)
            * Vector c=(x+width, y+height)
            * Vector d=(x+width, y) 
            * 
            * 
            * */
            int vectorHiveCornerBX = vectorHiveCornerAX;
            int vectorHiveCornerBY = vectorHiveCornerAY + heightHive;

            int vectorHiveCornerCX = vectorHiveCornerAX + widthHive;
            int vectorHiveCornerCY = vectorHiveCornerAY + heightHive;

            int vectorHiveCornerDX = vectorHiveCornerAX + widthHive;
            int vectorHiveCornerDY = vectorHiveCornerAY;

            int beeImageHeight = 50;
            int beeImageWidth = 50;

            directionControl = beeInfo;
            Point p = new Point();
            p.X = beeInfo.BeeInsideHiveLocationX;
            p.Y = beeInfo.BeeInsideHiveLocationY;
            //Case: Image Hits Top Limit
            //We are at the Top corner => We Move Back Down 
            if (p.Y <= vectorHiveCornerAY)
            {
                p.Y = vectorHiveCornerAY + 2;
                directionControl.BeeInsideHiveLocationY = p.Y;
                directionControl.BeeInsideHiveLocationX = p.X;
                //We Change Direction and We Indicate the Image hit the top
                directionControl.DirectionToMoveEnum = ChangeDirection(WorldGraphicsBehive.BeeWorldHelper.Move.Up);
                return directionControl;
            }
            //Case: Image Hits Bottom Limit
            //We are at the Bottom corner => We Move Back Up 
            int minPointY = vectorHiveCornerBY - beeImageHeight;
            if (p.Y >= minPointY)
            {
                p.Y = minPointY - 2;
                directionControl.BeeInsideHiveLocationY = p.Y;
                directionControl.BeeInsideHiveLocationX = p.X;
                //We Change Direction and We Indicate the Image hit the bottom
                directionControl.DirectionToMoveEnum = ChangeDirection(WorldGraphicsBehive.BeeWorldHelper.Move.Down);
                return directionControl;
            }
            //Case: Image Hits Left Limit
            //We are at the left corner => We Move Back right
            if (p.X <= vectorHiveCornerAX)
            {
                p.X = vectorHiveCornerAX + 2;
                directionControl.BeeInsideHiveLocationX = p.X;
                directionControl.BeeInsideHiveLocationY = p.Y;
                //We Change Direction and We Indicate the Image hit the left
                directionControl.DirectionToMoveEnum = ChangeDirection(WorldGraphicsBehive.BeeWorldHelper.Move.Left);
                return directionControl;
            }
            //Case: Image Hits Right Limit
            //We are at the right corner => We Move Back left
            int maxPointX = vectorHiveCornerCX - beeImageWidth;
            if (p.X > maxPointX)
            {
                p.X = maxPointX - 2;
                directionControl.BeeInsideHiveLocationX = p.X;
                directionControl.BeeInsideHiveLocationY = p.Y;
                //We Change Direction and We Indicate the Image hit the right
                directionControl.DirectionToMoveEnum = ChangeDirection(WorldGraphicsBehive.BeeWorldHelper.Move.Right);
                return directionControl;
            }
            return directionControl;
        }
       

        //RANDOM Movement 4 of 4
        private Enum ChangeDirection(Enum newDir)
        {
            //The new Direction Can contain the KEYWORKDS: UP, DOWN, LEFT or RIGHT
            Enum newDirectionEnum = newDir;

            List<Enum> listDirection = new List<Enum>();
            var enumValuesList = Enum.GetValues(typeof(WorldGraphicsBehive.BeeWorldHelper.Move)).Cast<Move>();
            foreach (var val in enumValuesList)
            {
                listDirection.Add(val);
            }
            for (int i = listDirection.Count() - 1; i >= 0; i--)
            {
                //We eliminate every Direction Enum that is related to the Initial
                //direction, leaving only the Opposite enums that refer to opposite
                //directions.
                if (listDirection[i].ToString().Contains(newDir.ToString()))
                {
                    listDirection.Remove(listDirection[i]);
                }
            }
            //With the Remaining list of Enum, we shuffle again to find another direction to go.
            int result = rand.Next(0, listDirection.Count);

            if (listDirection[result].ToString().Equals("Up")) { newDirectionEnum = WorldGraphicsBehive.BeeWorldHelper.Move.Up; }
            if (listDirection[result].ToString().Equals("Down")) { newDirectionEnum = WorldGraphicsBehive.BeeWorldHelper.Move.Down; }
            if (listDirection[result].ToString().Equals("Left")) { newDirectionEnum = WorldGraphicsBehive.BeeWorldHelper.Move.Left; }
            if (listDirection[result].ToString().Equals("Right")) { newDirectionEnum = WorldGraphicsBehive.BeeWorldHelper.Move.Right; }

            if (listDirection[result].ToString().Equals("Degrees45DiagonalUpRight")) { newDirectionEnum = WorldGraphicsBehive.BeeWorldHelper.Move.Degrees45DiagonalUpRight; }
            if (listDirection[result].ToString().Equals("Degrees45DiagonalUpLeft")) { newDirectionEnum = WorldGraphicsBehive.BeeWorldHelper.Move.Degrees45DiagonalUpLeft; }
            if (listDirection[result].ToString().Equals("Degrees45DiagonalDownRight")) { newDirectionEnum = WorldGraphicsBehive.BeeWorldHelper.Move.Degrees45DiagonalDownRight; }
            if (listDirection[result].ToString().Equals("Degrees45DiagonalDownLeft")) { newDirectionEnum = WorldGraphicsBehive.BeeWorldHelper.Move.Degrees45DiagonalDownLeft; }

            return newDirectionEnum;
        }

        //DIRECTIONAL Movement 1 of 3
        public Point MoveTowardsTargetFlower(BeeData bee, FlowerData targetFlower)
        {
            //We define a target and the bee has to chase that target
            Point p = new Point();
            p.X = bee.BeeWorldLocationX;
            p.Y = bee.BeeWorldLocationY;

            //Case: the flower is no longer abundant in pollem or do not exist and libation point is Zero
            if (targetFlower.FlowerLibationPointX == 0 && targetFlower.FlowerLibationPointY == 0)
            {
                p.X = bee.BeeWorldLocationX;
                p.Y = bee.BeeWorldLocationY;
                GenerateRandomMovement(bee.DirectionToMoveEnum, p);
            }

            //if(bee.BeeLocationX < targetFlower.FlowerLocationX )
            if (bee.BeeWorldLocationX < targetFlower.FlowerLibationPointX)
            {
                p.X = bee.BeeWorldLocationX;
                p.X = p.X + pixelMovement;
            }

            //if (bee.BeeLocationX > targetFlower.FlowerLocationX )
            if (bee.BeeWorldLocationX > targetFlower.FlowerLibationPointX)
            {
                p.X = bee.BeeWorldLocationX;
                p.X = p.X - pixelMovement;
            }

            //if (bee.BeeLocationY < targetFlower.FlowerLocationY )
            if (bee.BeeWorldLocationY < targetFlower.FlowerLibationPointY)
            {
                p.Y = bee.BeeWorldLocationY;
                p.Y = p.Y + pixelMovement;
            }

            //if (bee.BeeLocationY > targetFlower.FlowerLocationY)
            if (bee.BeeWorldLocationY > targetFlower.FlowerLibationPointY)
            {
                p.Y = bee.BeeWorldLocationY;
                p.Y = p.Y - pixelMovement;
            }
            return p;
        }

        //DIRECTIONAL Movement 2 of 3
        public Point MoveTowardsTargetBehive(BeeData bee, BeeHive behive)
        {
            //We define a target and the bee has to chase that target
            Point p = new Point();
            p.X = bee.BeeWorldLocationX;
            p.Y = bee.BeeWorldLocationY;
            if (behive.BeehiveTargetPointLocationX == 0 && behive.BeehiveTargetPointLocationY == 0)
            {
                p.X = bee.BeeWorldLocationX;
                p.Y = bee.BeeWorldLocationY;
                GenerateRandomMovement(bee.DirectionToMoveEnum, p);
            }
            //if(bee.BeeLocationX < targetFlower.FlowerLocationX )
            if (bee.BeeWorldLocationX < behive.BeehiveTargetPointLocationX)
            {
                p.X = bee.BeeWorldLocationX;
                p.X = p.X + pixelMovement;
            }
            //if (bee.BeeLocationX > targetFlower.FlowerLocationX )
            if (bee.BeeWorldLocationX > behive.BeehiveTargetPointLocationX)
            {
                p.X = bee.BeeWorldLocationX;
                p.X = p.X - pixelMovement;
            }
            //if (bee.BeeLocationY < targetFlower.FlowerLocationY )
            if (bee.BeeWorldLocationY < behive.BeehiveTargetPointLocationY)
            {
                p.Y = bee.BeeWorldLocationY;
                p.Y = p.Y + pixelMovement;
            }
            //if (bee.BeeLocationY > targetFlower.FlowerLocationY)
            if (bee.BeeWorldLocationY > behive.BeehiveTargetPointLocationY)
            {
                p.Y = bee.BeeWorldLocationY;
                p.Y = p.Y - pixelMovement;
            }
            return p;
        }

        //DIRECTIONAL Movement 3 of 3
        public Point MoveTowardsTargetExit(BeeData bee, int hiveExitCornerAX, int hiveExitCornerAY, int hiveExitWidth, int hiveExitHeight)
        {
            //We define a target and the bee has to chase that target
            Point pointLoc = new Point();
            pointLoc.X = bee.BeeInsideHiveLocationX;
            pointLoc.Y = bee.BeeInsideHiveLocationY;
            //We define the exit point at the top of the Exit door
            int exitPointX = (hiveExitWidth / 2) + hiveExitCornerAX;
            int exitPointY = hiveExitCornerAY;
            if (bee.BeeInsideHiveLocationX < exitPointX)
            {
                // p.X = bee.BeeInsideHiveLocationX;
                pointLoc.X = pointLoc.X + pixelMovement;
            }
            if (bee.BeeInsideHiveLocationX > exitPointX)
            {
                // p.X = bee.BeeInsideHiveLocationX;
                pointLoc.X = pointLoc.X - pixelMovement;
            }
            //if (bee.BeeLocationY < targetFlower.FlowerLocationY )
            if (bee.BeeInsideHiveLocationY < exitPointY)
            {
                // p.Y = bee.BeeInsideHiveLocationY;
                pointLoc.Y = pointLoc.Y + pixelMovement;
            }
            //if (bee.BeeLocationY > targetFlower.FlowerLocationY)
            if (bee.BeeInsideHiveLocationY > exitPointY)
            {
                // p.Y = bee.BeeInsideHiveLocationY;
                pointLoc.Y = pointLoc.Y - pixelMovement;
            }
            return pointLoc;
        }


    }
}
