using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldGraphicsBehive.BeeWorldHelper;
using WorldGraphicsBehive.BeeHiveHelper;
using WorldGraphicsBehive.FlowerHelper;

namespace WorldGraphicsBehive
{
    public partial class Form1 : Form
    {
        Bee _bee;
        World _world;
        Flower _flower;
        BeeHive _beehive;         
        BeeAnimation _beeAnimation;
        BeeHiveForm _insideHiveForm;
        //Timer Created in the Form Code
        Timer _beeWingsAnimationTimer;
        Timer _beeAnimationTimer;
        Timer _flowerTimer;
       
        bool formInitialization;
        bool enableForm;
        public bool EnableFormHandlersAndTimers(bool command)
        {
            if(command ==true)
            { 
                enableForm = true;
                _flowerTimer.Enabled = true;
                _beeAnimationTimer.Enabled = true;
                _beeWingsAnimationTimer.Enabled = true;
            }
            else
            { 
                enableForm = false;
                _flowerTimer.Enabled = false; 
                _beeAnimationTimer.Enabled = false;
                _beeWingsAnimationTimer.Enabled = false;
            }
            return enableForm;
        }

        public Form1()
        {
            InitializeComponent();
        }
    
        public void SetFormObjects(World world, BeeHive beehive, Flower flower, 
            Bee bee, BeeHiveForm insideForm,BeeAnimation beeAnimation,
            Timer beeWingsAnimationTimer, Timer beeAnimationTimer, Timer flowerTimer) 
        {
            _bee = bee;
            _world = world;
            _flower = flower;
            _beehive = beehive;
            _flowerTimer = flowerTimer;
            _beeAnimation = beeAnimation;
            _insideHiveForm = insideForm;
            _beeAnimationTimer = beeAnimationTimer;
            _beeWingsAnimationTimer = beeWingsAnimationTimer;
            
            //World Info
            formInitialization = true;

           

            Point p = new Point();
            p.X = 866;
            p.Y = 518;
            this.MinimumSize = new Size(p.X,p.Y );
            this.MaximumSize = new Size(p.X, p.Y);
            string keyInfo = "updateLocation";
            int totalFlowersInField = 4;

            _world.CreateFlower(totalFlowersInField);
            _world.SetFormsWidthAndHeight(this.Width, this.Height);
            _flower.SetKeyToUpdateData(keyInfo);         
            _flower.FormInitialization(formInitialization); 
            _flower.SetTotalFlowersInField(totalFlowersInField);
            _flower.SetMainFormHeightAndWidth(this.Height, this.Width);

            beehive.BeeList = new List<BeeData>();
            beehive.SetFlowersListFromForm(world.FlowersList);
            beehive.BeehiveTargetPointLocationY = 70;
            beehive.BeehiveTargetPointLocationX = 703;
            beehive.SetBeeAnimationFromForm(_beeAnimation);
            
            beehive.CreateBee();

            _bee.SetFlowerListFromWorld(_world.FlowersList);
            _bee.SetBeeAnimation(_beeAnimation);             
            _bee.SetBeehiveFromForm(beehive);
            _bee.SetMainFormLimits(p); 
          
            //==EVENTS BEGIN=======
            _flowerTimer.Tick += new System.EventHandler(this.FlowerTimer_Tick);
          
            _flowerTimer.Interval = 1;
            _flowerTimer.Start();
            _beeAnimationTimer.Interval = 1;
            _beeAnimationTimer.Start();
            _beeWingsAnimationTimer.Interval = 10;
            _beeWingsAnimationTimer.Start();

            _beeWingsAnimationTimer.Tick += new EventHandler(BeeWingsAnimationTimer_Tick);
            _beeAnimationTimer.Tick += new EventHandler(BeeAnimationTimer_Tick);
            this.Paint += new PaintEventHandler(Form1_Paint);
            //==EVENTS END=========
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            _world .PaintLandscapeInWorldForm(e);
            //  _insideHiveForm.Refresh(); <<<==Performance Problems
            if(enableForm==false) { return; }
          
            _flower.PaintAllFlowersInWorldField(sender, e);
            //BEES Paint All Bees.     
            //We pass the Flowers list to the bees for them to define which flower to 
            //target for the polen collection process.
            _beehive.SetFlowersListFromForm( _world.FlowersList);
            _bee.PaintAllBees(e,"world");

            //Bee Animate Bee Wings===============          
            _bee.GenerateBeeWingsMovement(_beehive);
          
            _bee.SetBeeTarget(_beehive);
            
          
        }
        //Flower LifeSpan timer
        private void FlowerTimer_Tick(object sender, EventArgs e)
        {
            _flower.RunFlowerLifeSpan();
            _flower.RunFlowerWaitingTimeToDisplayCounter();
          //  _insideHiveForm.Refresh(); <<<==Performance Problems
            this.Refresh();  
        }
        //Bee Wings animation speed
     
        private void  BeeWingsAnimationTimer_Tick(object sender, EventArgs e)
        {
            //Bee Animate Bee Wings=================
            _bee.GenerateBeeWingsMovement(_beehive);
            //  _insideHiveForm.Refresh(); <<<==Performance Problems
            this.Refresh();
        }

        //Bee Movement speed
        private void BeeAnimationTimer_Tick(object sender, EventArgs e)
        {
            _beehive.SetFlowersListFromForm(_world.FlowersList);
            _bee.SetBeeListFromBeehive (_beehive.BeeList);
            //Bee Animate Bee
           
            _bee.SetBeeTarget(_beehive);
            //  _insideHiveForm.Refresh(); <<<==Performance Problems
            //this.Refresh();<<<==Performance Problems
         
            //We check if there is enought pollen to create a new bee.
            _bee.RunLifeSpan(_beehive);
            _beehive.CalculatePollenInContainerToCreateANewBee();
            _beehive.RemoveDeadBees();
            //  _insideHiveForm.Refresh(); <<<==Performance Problems
            this.Refresh();
        }


    }
}
