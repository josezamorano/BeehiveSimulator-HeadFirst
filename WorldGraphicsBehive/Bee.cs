using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using WorldGraphicsBehive.FlowerHelper;
using WorldGraphicsBehive.BeeHiveHelper;
using WorldGraphicsBehive.BeeWorldHelper;

namespace WorldGraphicsBehive
{
    public class Bee
    {
       
        Random rand = new Random();
        private List<FlowerData> FlowersListFromWorld;
        private List<BeeData> BeeListFromBehive;
      
        BeeAnimation beeAnimation;
        BeeHive beehiveInfo;
        Bitmap bm = null;
        //bool goInsideHive = false; 
        
        int beeImageWidth;
        int beeImageHeight;     
        int mainFormHeight;
        int mainFormWidth;

        int exitCornerAX;
        int exitCornerAY;
        int exitWidth;
        int exitHeight;

        public void SetFlowerListFromWorld(List<FlowerData> fl)
        {
            FlowersListFromWorld = fl;
        }
        public void SetBeeListFromBeehive(List<BeeData> bl)
        {
            BeeListFromBehive = bl;
        }
       
        public void SetBeeAnimation(BeeAnimation ba)
        {
            beeAnimation = ba;
        }
       
        public void SetExitHiveData(BeeHiveGraphics  beeHiveInsideInfo)
        {
            exitCornerAX = beeHiveInsideInfo.ExitCornerAX;
            exitCornerAY = beeHiveInsideInfo.ExitCornerAY;
            exitWidth = beeHiveInsideInfo.ExitWidth;;
            exitHeight = beeHiveInsideInfo.ExitHeight; 
        }
        public void SetMainFormLimits(Point p)
        {
            mainFormWidth = p.X;
            mainFormHeight = p.Y;
            beeAnimation.SetFormLimits(p);
        }
        public void SetBeehiveFromForm(BeeHive beehive)
        {
            beehiveInfo = beehive;
            BeeListFromBehive = beehive.BeeList;
        }
        public void GenerateBeeWingsMovement(BeeHive behive)
        {
            foreach(BeeData bee in behive.BeeList)
            {
                if(bee.BeeTargetEnum !=null)
                {              
                    if(bee.BeeTargetEnum.Equals(Target.InsideHive))
                    {
                        //First We get the Current Bee Image in the bee list
                        int currentImageIndex = bee.BeeInsideHiveImageIndex;

                        //We check for the next image of the wings movement
                        int countImages =beeAnimation.AnimateBeeWings().Count;
                        for (int i = 0; i < countImages; i++)
                        {
                            //Once we find the image that we stored in the Bee list and 
                            //its equivalent in the wing Animation list
                            if (i == currentImageIndex)
                            {
                                if (currentImageIndex < countImages - 1)
                                {
                                    //we update the image in the Bee list with the next 
                                    //Image from the Wing Animation list
                                    //In the last image from the list, when the counter i reaches the 
                                    //last image, we go back to zero 0 index 
                                    currentImageIndex = currentImageIndex + 1;
                                    bee.BeeInsideHiveImage = beeAnimation.AnimateBeeWings()[currentImageIndex];
                                    bee.BeeInsideHiveImageIndex = currentImageIndex;
                                    //When the i counter goes from 0 to 4 we add the next image
                                    break;
                                }
                                else
                                {
                                    bee.BeeInsideHiveImage = beeAnimation.AnimateBeeWings()[0];
                                    bee.BeeInsideHiveImageIndex = 0;                               
                                    break;
                                }
                            }
                        } 
                    }
                    else
                    {
                        //First We get the Current Bee Image in the bee list
                       int currentImageIndex = bee.BeeWorldImageIndex;

                        //We check for the next image of the wings movement
                        int countImages = beeAnimation.AnimateBeeWings().Count;
                        for(int i=0; i<countImages; i++)
                        {
                            //Once we find the image that we stored in the Bee list and 
                            //its equivalent in the wing Animation list
                            if(i==currentImageIndex)
                            {
                                if (currentImageIndex < countImages - 1)
                                {
                                    //we update the image in the Bee list with the next 
                                    //Image from the Wing Animation list
                                    //In the last image from the list, when the counter i reaches the 
                                    //last image, we go back to zero 0 index 
                                    currentImageIndex = currentImageIndex + 1;
                                    bee.BeeWorldImage = beeAnimation.AnimateBeeWings()[currentImageIndex];
                                    bee.BeeWorldImageIndex = currentImageIndex;
                                    //When the i counter goes from 0 to 4 we add the next image
                                    break;
                                }
                                else
                                {
                                    bee.BeeWorldImage = beeAnimation.AnimateBeeWings()[0];
                                    bee.BeeWorldImageIndex = 0;
                                    break;
                                }
                            }               
                        }               
                    }
                }
            }
        }

        //Generate Movement towards other targets

        //HIVE
        public void GenerateMovementTowardsBehiveTarget(BeeData bee)
        {
            if (bee.BeeTargetEnum.Equals(Target.Hive))
            {
                Point p = new Point();
                p=beeAnimation.MoveTowardsTargetBehive(bee, beehiveInfo);
                bee.BeeWorldLocationX = p.X;
                bee.BeeWorldLocationY = p.Y;


                //== Target Accomplished
                //Then we check if the bee has reached the target or not
                /*********BOUNDARIES*****************************
                We Constantly check the position of the Bee
                In relation to the Target Flower.
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
                int vectorApositionX = bee.BeeWorldLocationX;
                int vectorApositionY = bee.BeeWorldLocationY;
                int vectorBpositionX = bee.BeeWorldLocationX;
                int vectorBpositionY = bee.BeeWorldLocationY + (beeImageHeight / 3);
                int vectorCpositionX = bee.BeeWorldLocationX + (beeImageWidth);
                int vectorCpositionY = bee.BeeWorldLocationY + (beeImageHeight / 3);
                int vectorDpositionX = bee.BeeWorldLocationX + (beeImageWidth);
                int vectorDpositionY = bee.BeeWorldLocationY;

                //TARGET Central Entrance Point
                int targetCenterPositionX = beehiveInfo.BeehiveTargetPointLocationX;
                int targetCenterPositionY = beehiveInfo.BeehiveTargetPointLocationY;
                int targetWidth = 5;
                int targetHegith = 5;
                //From this point we build a rectangle and we will compare it with any of the 
                //Bees' edges
                int targetCornerApositionX = targetCenterPositionX - targetWidth;
                int targetCornerApositionY = targetCenterPositionY - targetHegith;
                int targetCornerCpositionX = targetCenterPositionX + targetWidth;
                int targetCornerCpositionY = targetCenterPositionY + targetHegith;
              
                //Target accomplished

                //we need to define a rectangle door and if the image bee hits that door at any point, 
                //then we enable entrance in the hive
              
                //check that the bee goes inside the hive once the bee hit the behive entrance TARGET POINT
                if (
                    ((vectorApositionX >= targetCornerApositionX && vectorApositionX <= targetCornerCpositionX) && (vectorApositionY >= targetCornerApositionY && vectorApositionY <= targetCornerCpositionY)) ||
                    ((vectorBpositionX >= targetCornerApositionX && vectorBpositionX <= targetCornerCpositionX) && (vectorBpositionY >= targetCornerApositionY && vectorBpositionY <= targetCornerCpositionY)) ||
                       ((vectorCpositionX >= targetCornerApositionX && vectorCpositionX <= targetCornerCpositionX) && (vectorCpositionY >= targetCornerApositionY && vectorCpositionY <= targetCornerCpositionY)) ||
                          ((vectorDpositionX >= targetCornerApositionX && vectorDpositionX <= targetCornerCpositionX) && (vectorCpositionY >= targetCornerApositionY && vectorDpositionY <= targetCornerCpositionY)) 

                     )
                {
                    //We HIDE The bee for a random amount of time
                    bee.BeeTargetEnum = Target.InsideHive;
                    //We align the bee with the entrance/exit hive point for it to 
                    //leave the Hive gracefully.
                    bee.BeeWorldLocationX = beehiveInfo.BeehiveTargetPointLocationX;
                    bee.BeeWorldLocationY = beehiveInfo.BeehiveTargetPointLocationY;
                    GoInsideBeehive(bee);
                }
            }
        }
        //Go Inside BEEHIVE
        
        public void GoInsideBeehive(BeeData bee)
        {
            if(bee.BeeTargetEnum.Equals(Target.InsideHive))
            {
               
                if(bee.BeeWaitingTimeToDisplay==0 && bee.BeeInsideHiveDisplayImage==false)
                {
                    bee.BeeInsideHiveDisplayImage = true;
                   
                    bee.BeeWorldDisplayImage = false;
                    bee.BeeWaitingTimeCounter =0 ;
                    bee.BeeWaitingTimeToDisplay = rand.Next(0, 200);
                    bee.BeeInsideHiveLocationX = 220;
                    bee.BeeInsideHiveLocationY = 220;
                    bee.DirectionToMoveEnum = Move.Left;
                    //The bee gives its pollen load to the Hive Container
                    int pollenCollectedByBee = bee.BeePollenCollected;
                    bee.BeePollenCollected = 0;
                    beehiveInfo.AddPollenToHiveContainer(pollenCollectedByBee);
                   
                }
               
                 bee.BeeWaitingTimeCounter++;

                //When the counter reaches the time inside hive, the bee
                //must go out to the world.
                
                GenerateMovementInsideHive(bee);
            }
        }

        public void GenerateMovementInsideHive(BeeData bee)
        {     
            //Random Standing Still of the bee
            int beeRemainingTimeInsideHive      = bee.BeeWaitingTimeToDisplay - bee.BeeWaitingTimeCounter;
            int beeRemaningTimeInsideHive20Perc = (int)(beeRemainingTimeInsideHive *0.2);
            int beeWaitingTimeToDisplay20Perc   = (int)(bee.BeeWaitingTimeToDisplay *0.2);
            int beeWaitingTimeToDisplay10Perc   = (int)(bee.BeeWaitingTimeToDisplay * 0.1);
            int beeWaitingTimeToDisplay5Perc    = (int)(bee.BeeWaitingTimeToDisplay * 0.05);
           
            /* */
            int randomStandingStill = rand.Next(0, 125);
            if (randomStandingStill == 10 && bee.BeeStandingStillTime==0)
            {
                //The bee will be only waiting for the 20% of the 
                //Available time to go back to the world
              
                if(beeRemainingTimeInsideHive> beeWaitingTimeToDisplay20Perc
                    && beeWaitingTimeToDisplay20Perc>0)
                { 
                    bee.BeeStandingStillTime = rand.Next(0, beeWaitingTimeToDisplay20Perc);
                    bee.DirectionToMoveEnum = null;
                }
            }
          
            if(bee.BeeStandingStillTime !=0)
            {
                bee.BeeStandingStillCounter++;
            }
            
            //We Compare the Standing Still Timer and the Counter to check when they are 
            //The same. When they are the same, the time is up and 
            if(bee.BeeStandingStillCounter == bee.BeeStandingStillTime &&
                bee.BeeStandingStillTime>0)
            { 
                bee.BeeStandingStillTime = 0;
                bee.BeeStandingStillCounter = 1;
                bee.DirectionToMoveEnum = beehiveInfo.SetDirectionToMoveEnum();
                Point p = new Point();
                p.X = bee.BeeInsideHiveLocationX;
                p.Y = bee.BeeInsideHiveLocationY;


                Move directionToMove = (Move)bee.DirectionToMoveEnum;
                Point pNew = new Point();
                pNew = beeAnimation.GenerateRandomMovement(directionToMove,p);
                
                bee.BeeInsideHiveLocationX = pNew.X;
                bee.BeeInsideHiveLocationY = pNew.Y;
            }

            int beeWidth = 5;
            int beeHeight = 5;
            int beeVectorAX = bee.BeeInsideHiveLocationX;
            int beeVectorAY = bee.BeeInsideHiveLocationY;
            int beeVectorBX = bee.BeeInsideHiveLocationX ;
            int beeVectorBY = bee.BeeInsideHiveLocationY + beeHeight;
            int beeVectorCX = bee.BeeInsideHiveLocationX + beeWidth;
            int beeVectorCY = bee.BeeInsideHiveLocationY + beeHeight;
            int beeVectorDX = bee.BeeInsideHiveLocationX + beeWidth;
            int beeVectorDY = bee.BeeInsideHiveLocationY;
           
            //at a minimum time, the bee will head to the EXIT
            //and once hit the exit will appear in the world.
            if(beeRemainingTimeInsideHive<beeWaitingTimeToDisplay5Perc)
            {
                //bee heads towards the Exit
                Point newBeePoint = new Point();
                newBeePoint = beeAnimation.MoveTowardsTargetExit(bee, exitCornerAX,exitCornerAY,exitWidth,exitHeight);

                bee.BeeInsideHiveLocationX = newBeePoint.X;
                bee.BeeInsideHiveLocationY = newBeePoint.Y;
                //We calculate the boundaries of the exit
               
                int exitCornerCX = exitCornerAX + exitWidth;
                int exitCornerCY = exitCornerAY + exitHeight;

                //We compare the  Bee vectors
                if ((beeVectorAX >= exitCornerAX && beeVectorAX <= exitCornerCX) && (beeVectorAY >= exitCornerAY && beeVectorAY <= exitCornerCY)
                    ||
                    (beeVectorBX >= exitCornerAX && beeVectorBX <= exitCornerCX) && (beeVectorBY >= exitCornerAY && beeVectorBY <= exitCornerCY)
                    ||
                    (beeVectorCX >= exitCornerAX && beeVectorCX <= exitCornerCX) && (beeVectorCY >= exitCornerAY && beeVectorCY <= exitCornerCY)
                    ||
                    (beeVectorDX >= exitCornerAX && beeVectorDX <= exitCornerCX) && (beeVectorDY >= exitCornerAY && beeVectorDY <= exitCornerCY)
                    )
                {
                    //When the counter reaches the time inside hive, the bee
                    //must go out to the world.
                    //We make the Bee EXIT THE Hive
                    bee.BeeWorldDisplayImage = true;
                    bee.BeeTargetEnum = Target.Flower;
                    bee.BeeWaitingTimeCounter = 0;
                    bee.BeeWaitingTimeToDisplay = 0;
                    //goInsideHive = false;
                }


            }
            else //Regular time inside the hive therefore the bee can fly around
            {
                Point point = new Point();
                point.X = bee.BeeInsideHiveLocationX;
                point.Y = bee.BeeInsideHiveLocationY;

                Point pointNew = new Point();
                if(bee.DirectionToMoveEnum !=null)
                {
                    Move beeDirectionToM = (Move)bee.DirectionToMoveEnum;
                    pointNew = beeAnimation.GenerateRandomMovement(beeDirectionToM, point);
                    bee.BeeInsideHiveLocationX = pointNew.X;
                    bee.BeeInsideHiveLocationY = pointNew.Y;
                }
                //Control Boundaries

                BeeData beeUpdate = beeAnimation.ControlBeeHiveFormBoundaries(bee);
                //We Update The values in the Bee
                bee.DirectionToMoveEnum = beeUpdate.DirectionToMoveEnum;
                bee.BeeInsideHiveLocationX = beeUpdate.BeeInsideHiveLocationX;
                bee.BeeInsideHiveLocationY = beeUpdate.BeeInsideHiveLocationY;
            }
    
        }

        //POLLEN      
        public void CollectPollen(BeeData bee)
        { 
            //Flower Container
            //Find The corresponding Flower
            FlowerData flower = FlowersListFromWorld.Where(a => a.FlowerID == bee.TargetFlowerForLibationID).FirstOrDefault();

            if (flower != null)
            {
                if(flower.FlowerLibationPointX !=0 && flower.FlowerLibationPointY !=0)
                {
                    flower.FlowerPollenContainer = flower.FlowerPollenContainer - bee.BeePollenCollectionRate;

                    bee.BeePollenCollected = bee.BeePollenCollected + bee.BeePollenCollectionRate;
                    if (bee.BeeCarryingCapacity <= bee.BeePollenCollected)
                    {
                        bee.BeeTargetEnum = Target.Hive;
                        GenerateMovementTowardsBehiveTarget(bee);
                    }
                }
                else
                {
                    //Go to Another flower
                    bee.BeeTargetEnum = Target.Flower;
                    GenerateMovementTowardsFlowerTarget(bee);
                }
            }
        }

        public void GenerateMovementTowardsFlowerTarget(BeeData bee)
        {
            Point p = new Point();
            Point pNew = new Point();
          
            //Find corresponding flower
            FlowerData targetFlower =FlowersListFromWorld.Where(a=>a.FlowerID==bee.TargetFlowerForLibationID).FirstOrDefault();
            //We check if there is a flower with the same ID as the registered by the bee
            if(targetFlower !=null)
            {
                if(targetFlower.FlowerLibationPointY!=0 && targetFlower.FlowerLibationPointX !=0)
                {
                    p = beeAnimation.MoveTowardsTargetFlower(bee, targetFlower);
                    bee.BeeWorldLocationX = p.X;
                    bee.BeeWorldLocationY = p.Y;

                    //Then we check if the bee has reached the target or not
                    /*********BOUNDARIES*****************************
                    We Constantly check the position of the Bee
                    In relation to the Target Flower.
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
                    int vectorApositionX = bee.BeeWorldLocationX;
                    int vectorApositionY = bee.BeeWorldLocationY;

                    int vectorBpositionX = bee.BeeWorldLocationX;
                    int vectorBpositionY = bee.BeeWorldLocationY + (beeImageHeight/3);

                    int vectorCpositionX = bee.BeeWorldLocationX + (beeImageWidth);
                    int vectorCpositionY = bee.BeeWorldLocationY + (beeImageHeight / 3);

                    int vectorDpositionX = bee.BeeWorldLocationX + (beeImageWidth);
                    int vectorDpositionY = bee.BeeWorldLocationY;
                    //Target accomplished

                    if((vectorApositionX<targetFlower.FlowerLibationPointX && vectorApositionY<targetFlower.FlowerLibationPointY) &&
                        (vectorBpositionX<targetFlower.FlowerLibationPointX && vectorBpositionY>targetFlower.FlowerLibationPointY) &&
                        (vectorCpositionX>targetFlower.FlowerLibationPointX && vectorCpositionY>targetFlower.FlowerLibationPointY) &&
                        (vectorDpositionX>targetFlower.FlowerLibationPointX && vectorDpositionY<targetFlower.FlowerLibationPointY)  
                        )
                    {
                        //Bee Set New Target pollen Collection                        
                        bee.BeeTargetEnum = Target.Pollen;
                        CollectPollen(bee);   
                    }
                }
                else
                {
                    //Review the FLOW and assigment of Directions to move              
                    p.X = bee.BeeWorldLocationX;
                    p.Y = bee.BeeWorldLocationY;
                    if (bee.DirectionToMoveEnum == null)
                    {
                        bee.DirectionToMoveEnum = beehiveInfo.SetDirectionToMoveEnum();
                    }
                    pNew= beeAnimation.GenerateRandomMovement(bee.DirectionToMoveEnum,p);                   
                    bee.BeeWorldLocationX = pNew.X;
                    bee.BeeWorldLocationY = pNew.Y;                   
                }
            }
            //If there is no flower with that ID, we assign a new flower Id to the bee
            else
            {
                int randomIndex = rand.Next(0, FlowersListFromWorld.Count());
                //We get the corresponding flower
                FlowerData correspondingFlower = FlowersListFromWorld[randomIndex];
                bee.TargetFlowerForLibationID = correspondingFlower.FlowerID;                 
            }

            //Control Boundaries             
            BeeData beeUpdate = beeAnimation.ControlWorldFormBoundaries(bee);
            //We Update The values in the Bee
            bee.DirectionToMoveEnum = beeUpdate.DirectionToMoveEnum;
            bee.BeeWorldLocationX = beeUpdate.BeeWorldLocationX;
            bee.BeeWorldLocationY = beeUpdate.BeeWorldLocationY;           
            //Once the Bee Hits the Flower target it updates its target for a new behavior,
        }

        public void PaintAllBees(PaintEventArgs e,string paintSignalOrigin)
        {
            if (BeeListFromBehive != null)
            {
                if (BeeListFromBehive.Count > 0)
                {
                    for (int i = 0; i < BeeListFromBehive.Count; i++)
                    {
                        if(paintSignalOrigin.Equals("insideHive") && BeeListFromBehive[i].BeeInsideHiveDisplayImage==true)
                        {
                            PaintBee(i, e);
                        }

                        if (paintSignalOrigin.Equals("world") && BeeListFromBehive[i].BeeWorldDisplayImage == true)
                        {
                            PaintBee(i, e);
                        }

                    }
                }
            }
        }

        public void PaintBee(int beeIndex, PaintEventArgs e)
        {
            Point    p = new Point();
            Graphics g = e.Graphics;
            
            for(int i=0; i<BeeListFromBehive.Count; i++)
            {  
                if (i == beeIndex)
                {
                    if(BeeListFromBehive[i].BeeTargetEnum !=null)
                    {
                        if(BeeListFromBehive[i].BeeTargetEnum.Equals(Target.InsideHive))
                        {
                            //Bee Inside Hive BEGIN=================
                            BeeListFromBehive[i].BeeWorldDisplayImage = false;
                            BeeListFromBehive[i].BeeInsideHiveDisplayImage = true;

                            bm = BeeListFromBehive[i].BeeInsideHiveImage;
                           
                            p.X = BeeListFromBehive[i].BeeInsideHiveLocationX;
                            p.Y = BeeListFromBehive[i].BeeInsideHiveLocationY;
                            beeImageWidth = 50;
                            beeImageHeight = 50;
                            //Bee Inside Hive END===================
                        }
                        else
                        {
                            //Bee In World BEGIN====================
                            BeeListFromBehive[i].BeeWorldDisplayImage = true;
                            BeeListFromBehive[i].BeeInsideHiveDisplayImage = false;
                            bm = BeeListFromBehive[i].BeeWorldImage;

                            p.X = BeeListFromBehive[i].BeeWorldLocationX;
                            p.Y = BeeListFromBehive[i].BeeWorldLocationY;
                            beeImageWidth = 15;
                            beeImageHeight = 15;
                            //Bee In World END======================
                        }
                        g.DrawImage(bm, p.X, p.Y, beeImageWidth, beeImageHeight);

                        //Draw BEE Boundaries Begin========
                        //using (Pen pen = new Pen(Color.Red))
                        //{
                        //    e.Graphics.DrawRectangle(pen, p.X, p.Y, beeImageWidth + marginImage, beeImageHeight + marginImage);

                        //}
                        //Draw BEE Boundaries END==========
                        //Draw BEE "A" Corner BEGIN========
                        //using (Pen pen = new Pen(Color.Red))
                        //{
                        //    e.Graphics.DrawRectangle(pen, p.X, p.Y, 5, 5);
                        //}
                        //Draw BEE "A" Corner END==========
                    }
                }
                if (i > beeIndex)
                {
                    break;
                }
            }
        }

        public void SetBeeTarget(BeeHive beehiveInfo)
        {
            if(beehiveInfo.BeeList !=null)
            {
                foreach(BeeData bee in beehiveInfo.BeeList)
                {        
                    if(bee.BeeTargetEnum == null)
                    {
                        //If there is not target set, the bee will target a flower
                        bee.BeeInsideHiveDisplayImage = false;
                        bee.BeeWorldDisplayImage = true;
                        bee.BeeTargetEnum = Target.Flower;           
                        GenerateMovementTowardsFlowerTarget(bee);

                    }//We Identify the type of object the bee is Targeting 
                    else  
                    {
                        //Current Target
                        if(bee.BeeTargetEnum.Equals(Target.Flower))
                        {
                            GenerateMovementTowardsFlowerTarget(bee);
                        }
                        if (bee.BeeTargetEnum.Equals(Target.Pollen))
                        {
                            CollectPollen(bee);
                        }
                        if (bee.BeeTargetEnum.Equals(Target.Hive))
                        {
                            GenerateMovementTowardsBehiveTarget(bee);
                        }

                        if(bee.BeeTargetEnum.Equals(Target.InsideHive))
                        {

                            GoInsideBeehive(bee);
                        }
                    }  
                }
            }
        }

        //Define Bee Life Stage
        public void RunLifeSpan(BeeHive beehiveInfo)
        {   
            foreach (BeeData bee in beehiveInfo.BeeList)
            {         
                bee.BeeLifeSpanUsage++;
            }
        }
        //Remove Bee when Dead. NOT IMPLEMENTED
    }
}
