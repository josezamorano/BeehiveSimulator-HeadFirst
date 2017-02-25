using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldGraphicsBehive.BeeWorldHelper;
using WorldGraphicsBehive.FlowerHelper;
using System.Drawing;


namespace WorldGraphicsBehive
{
    public class BeeHive
    {
        Random rand = new Random();
        public List<BeeData> BeeList = new List<BeeData>();
        private List<FlowerData> FlowersList;
        private BeeAnimation beeAnimation;

        //Behive Entrance
        public int BeehiveTargetPointLocationX { get; set; }
        public int BeehiveTargetPointLocationY { get; set; }

        int initialNumberOfBees = 1;
        int totalBeesInField; 
        //Bee life span
        int minLifeSpanBee = 3000;
        int maxLifeSpanBee = 10000;
        //Bee Carrying Capacity
        int maxBeeCarryingCapacity = 100;
        //Total Polem To CreateA new Bee
        int totalPollenForANewBee;
        //Hive Polen container total
        int hivePollenBalance;

        public void SetTotalBeesInField(int x)
        {
            totalBeesInField = x;
        }
        public void SetTotalPollenForANewBee(int x)
        {
            totalPollenForANewBee = x;
        }
        public int GetHivePollenBalance()
        {
            return hivePollenBalance;
        }

        public void SetHivePollenBallance(int value)
        {
            hivePollenBalance = value;
        }
        public void SetBeeAnimationFromForm(BeeAnimation ba)
        {
            beeAnimation = ba;
        }
        public void SetFlowersListFromForm(List<FlowerData> fl)
        {
            FlowersList = fl;
        }

        public void AddPollenToHiveContainer(int pollenQuantity)
        {
            hivePollenBalance += pollenQuantity;
        }

        public void CalculatePollenInContainerToCreateANewBee()
        {
            //Investigate if there is enough pollen for a new bee.
            if(hivePollenBalance>=totalPollenForANewBee)
            {
                if(BeeList.Count <totalBeesInField)
                {
                    //Calculate the NET balance of the pollen container
                    hivePollenBalance -= totalPollenForANewBee;
                    CreateBee();
                }
                
            }
        }
        public void RemoveDeadBees()
        {
            for (int i =BeeList.Count-1; i >= 0;i-- )
            {
                if(BeeList[i].BeeTargetEnum !=null)
                {
                    if(BeeList[i].BeeTargetEnum.Equals(Target.InsideHive) && BeeList[i].BeeLifeSpanUsage>=BeeList[i].BeeLifeSpan)
                    {
                        BeeList.Remove(BeeList[i]);
                    }
                }
            }    
        }

        //Create a bee
        public void CreateBee()
        {
            if (BeeList.Count < initialNumberOfBees)
            {
                for (int i = BeeList.Count; i < initialNumberOfBees; i++)
                {
                    SetNewBee();
                }
            }
                //If there is enough pollen in the container and received the 
                //command from the method CalculatePollenInContainerToCreateANewBee()
                //then create another bee
            else
            {
                if (BeeList.Count < totalBeesInField)
                {
                    SetNewBee();
                }
            }
        }

        //Set a New Bee
        private void SetNewBee()
        {
            BeeData bee = new BeeData();
            //Initial Bee WORLD Image
            int randomIndex = rand.Next(0,beeAnimation.AnimateBeeWings().Count);
            bee.BeeWorldImage = beeAnimation.AnimateBeeWings()[randomIndex];
            bee.BeeWorldImageIndex = randomIndex;
            //Initial Bee BEEHIVE Image
            bee.BeeInsideHiveImage = beeAnimation.AnimateBeeWings()[randomIndex];
            bee.BeeInsideHiveImageIndex = randomIndex;
            //BeeHiveEntrance from where the Bee goes to the World
            bee.BeeWorldLocationX = 703;
            bee.BeeWorldLocationY = 90;

            //Set Bee Life Span
            bee.BeeLifeSpan = SetBeeLifeSpan();
            bee.BeeLifeSpanUsage = 0;
            bee.BeeStandingStillCounter = 1;
            //Set Bee Waiting Time To appear in the world
            bee.BeeWorldDisplayImage = true;
        
            bee.BeeCarryingCapacity = SetBeeCarryingCapacity();
            bee.BeePollenCollectionRate = SetBeePollenCollectionRate();

            bee.BeeId = SetBeeID();

            int flowersCount = FlowersList.Count();
            int randomFlowerIndex =0;
            if(flowersCount>0)
            {
                randomFlowerIndex  = rand.Next(0,flowersCount);
            }
            FlowerData randomFlower = FlowersList[randomFlowerIndex];
            if(randomFlower !=null)
            {
                bee.TargetFlowerForLibationID = randomFlower.FlowerID;
              
            }
            bee.DirectionToMoveEnum = SetDirectionToMoveEnum();
           
            BeeList.Add(bee);
        }
        //Set Bee Life Span
        private int SetBeeLifeSpan()
        {
            int lifeSpan = rand.Next(minLifeSpanBee, maxLifeSpanBee);
            return lifeSpan;
        }

        private int SetBeeCarryingCapacity()
        {
            //Bee Carrying Capacity
            int capacity = rand.Next(50,maxBeeCarryingCapacity);
            return capacity;
        }
        private int SetBeePollenCollectionRate()
        {
            //Bee Carrying Capacity
            int collectionRate = rand.Next(1, 20);
            return collectionRate;
        }
        //the ID of the Bee is the same as the Index of the list    
        private int SetBeeID()
        {
            int numberId = 0;
            BeeData lastBee = BeeList.OrderByDescending(a => a.BeeId).FirstOrDefault();
            if(lastBee !=null)
            {
                numberId = lastBee.BeeId+1;
            }
            else
            {
                numberId = 1;
            }

            return numberId;
        }
        public Move SetDirectionToMoveEnum()
        {
            Move[] enumValuesList = (Move[])Enum.GetValues(typeof(Move)).Cast<Move>();
          
            int randVal = rand.Next(0, enumValuesList.Count());
            Move newDirectionEnum = enumValuesList[randVal];
            return newDirectionEnum;
        }   
    }
}
