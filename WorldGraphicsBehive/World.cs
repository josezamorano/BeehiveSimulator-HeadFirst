using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;
using WorldGraphicsBehive.FlowerHelper;

namespace WorldGraphicsBehive
{
    public class World
    {
        Random rand = new Random();
        public List<FlowerData> FlowersList = new List<FlowerData>();
        bool flowerReplacementInField = true;
        int maxPollenContainedByFlower = 5000;
        //Flower life span
        int minLifeSpanFlower = 30;
        int maxLifeSpanFlower = 100;
        int maxWaitingTimeToDisplayAFlower = 9;
        int widthForm;
        int heightForm;
        Bitmap natureImage;
        Bitmap hiveInNature; 
        int targetImageWidth;
        int targetImageHeight;
      
        private List<Size> formSizesList = new List<Size>();    
        public World()
        {
            targetImageWidth = (int)Math.Floor(852 * 1.5);
            targetImageHeight = (int)Math.Floor(480 * 1.5);

        }

        public void SetFormsWidthAndHeight(int w, int h)
        {
            widthForm = w;
            heightForm = h;
        }

        public void CreateFlower(int numberOfFlowersInField)
        {
            int startingNumber = 0;
            if (FlowersList != null)
            {
                if (FlowersList.Count < numberOfFlowersInField)
                {
                    if (flowerReplacementInField == true)
                    {
                        startingNumber = FlowersList.Count;
                    }

                    for (int i = startingNumber; i < numberOfFlowersInField; i++)
                    {
                        FlowerData flowerInfo = new FlowerData();
                        flowerInfo.FlowerDataKeyStatus = "updateLocation";
                        flowerInfo.FlowerWaitingTimeToDisplay = SetWaitingTimeToDisplayAFlower();
                        flowerInfo.FlowerID = SetFlowerID();
                        flowerInfo.FlowerLifeSpan = SetFlowerLifeSpan();
                        flowerInfo.FlowerPollenContainer = SetFlowerTotalPollen();
                        FlowersList.Add(flowerInfo);
                    }
                }
            }
        }

        private int SetWaitingTimeToDisplayAFlower()
        {
            int waitingTimeToCreateAFlower = rand.Next(1, maxWaitingTimeToDisplayAFlower);
            return waitingTimeToCreateAFlower;
        }
        private int SetFlowerID()
        {
            int flowerId = 0;
            FlowerData lastFlower = FlowersList.OrderByDescending(a => a.FlowerID).FirstOrDefault();
            if (lastFlower != null)
            {
                flowerId = lastFlower.FlowerID + 1;
            }
            else
            {
                flowerId = 1;
            }
            return flowerId;
        }
        private int SetFlowerLifeSpan()
        {
            int life = rand.Next(minLifeSpanFlower, maxLifeSpanFlower);
            return life;
        }
        private int SetFlowerTotalPollen()
        {
            int totalPollen = rand.Next(0, maxPollenContainedByFlower);
            return totalPollen;
        }

        public void PaintLandscapeInWorldForm(PaintEventArgs e)
        {
            //Cartoon Images
            hiveInNature = WorldGraphicsBehive.Properties.Resources.Hive__outside_;
        
            e.Graphics.FillRectangle(Brushes.LightBlue, 0, 0, widthForm, heightForm / 2);
            e.Graphics.FillEllipse(Brushes.Yellow, new Rectangle(50, 35, 70, 70));
            e.Graphics.FillRectangle(Brushes.Green, 0, heightForm / 2, widthForm, heightForm / 2);
            e.Graphics.DrawLine(new System.Drawing.Pen(Color.DarkOliveGreen, 5), new Point(683, 0), new Point(683, 30));
            e.Graphics.DrawImage(hiveInNature, new Rectangle(647, 29, 75, 75));

            //NOTE: Uncomment when Debugging only*******************
            //e.Graphics.FillRectangle(Brushes.Red, 703, 90, 2,  2);
            //******************************************************
                    
        }

     
    }
}
