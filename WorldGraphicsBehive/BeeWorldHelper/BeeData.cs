using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Extra Using Directives

namespace WorldGraphicsBehive.BeeWorldHelper
{
    public class BeeData
    {
        public int BeeId { get; set; }

        //==Bee Data required for the World Display BEGIN=== 
        public bool BeeWorldDisplayImage { get; set; }
        public Bitmap BeeWorldImage { get; set; }
        public int BeeWorldImageIndex { get; set; }

        public int BeeWorldLocationX { get; set; }
        public int BeeWorldLocationY { get; set; }
        //==Bee Data required for the World Display END======
        //==Bee Data required inside the hive Display BEGIN==
        public bool BeeInsideHiveDisplayImage { get; set; }
        public Bitmap BeeInsideHiveImage { get; set; }
        public int BeeInsideHiveImageIndex { get; set; }
        public int BeeInsideHiveLocationX { get; set; }
        public int BeeInsideHiveLocationY { get; set; }

        //==Bee Data required inside the hive Display END====
        public int BeeLifeSpan { get; set; }
        public double BeeLifeSpanUsage { get; set; }

        //Life cycle
        public Enum BeeLifeStage { get; set; }
        public int BeeWaitingTimeToDisplay { get; set; }
        public int BeeWaitingTimeCounter { get; set; }
        public int BeeStandingStillTime { get; set; }
        public int BeeStandingStillCounter { get; set; }
        //Target
        public Enum BeeTargetEnum { get; set; }
        public int TargetFlowerForLibationID { get; set; }
        public int BeeCarryingCapacity { get; set; }
        public int BeePollenCollectionRate { get; set; }
        public int BeePollenCollected { get; set; }
        //Direction Control
        public Enum DirectionToMoveEnum { get; set; }

    }
}
