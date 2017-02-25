using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldGraphicsBehive.BeeHiveHelper;
using WorldGraphicsBehive.BeeWorldHelper;

namespace WorldGraphicsBehive
{
    public partial class DashboardForm : Form
    {
        Timer timer1 = new Timer(); 
        Timer _flowerTimer = new Timer();
        Timer _beeAnimationTimer = new Timer();
        Timer _beeWingsAnimationTimer = new Timer();
       
     
        private DateTime _start = DateTime.Now;
        private DateTime _end;
        private int _framesRun;
        private int _maxTimeSimulation = 3000;

        public int totalFlowersInField;
        //We Create the objects
        Bee bee = new Bee();
        World world = new World();
        Flower flower = new Flower();
        BeeHive beehive = new BeeHive();
        BeeData beeMovementControl = new BeeData();
        BeeAnimation beeAnimation = new BeeAnimation();  
        BeeHiveGraphics BeehiveGraphicsInfo = new BeeHiveGraphics();
   

        //Then we create the forms
        Form1 F1 = new Form1();  
        BeeHiveForm InsideHiveForm = new BeeHiveForm();   
        //Form Constructor
        public DashboardForm()
        {
            InitializeComponent();
            List<int> comboList = new List<int>() { 100,200,300,400,500};
            foreach (var x in comboList) 
            {
                this.PollenNumberComboBox.Items.Add(x);        
            }
                
            F1.SetFormObjects(world,beehive,flower,bee,InsideHiveForm,beeAnimation,_beeWingsAnimationTimer,_beeAnimationTimer,_flowerTimer);
            F1.Show();
           

            InsideHiveForm.Show();
            InsideHiveForm.SetBeeObject(bee);
            InsideHiveForm.SetBeeHiveObject(beehive);
            InsideHiveForm.SetBeeHiveFormTimer(_beeAnimationTimer);       
            InsideHiveForm.SetBeeHiveGraphicsObject(BeehiveGraphicsInfo);
            
            beeAnimation.SetBeeData(beeMovementControl);
            beeAnimation.SetFormLimits(InsideHiveForm.Width, InsideHiveForm.Height);

            flower.SetWorldObject(world);
           

            timer1.Interval = 50;
            timer1.Tick += RunFrame;
            timer1.Enabled = false;
           
            bee.SetBeeTarget(beehive);
            this.Refresh();
            MoveChildForms(); 
            UpdateStats(new TimeSpan());    
        }
        private void UpdateStats(TimeSpan frameDuration)
        {
            BeesLabelNumber.Text = beehive.BeeList.Count().ToString();
            FlowerLabelNumber.Text = world.FlowersList.Count().ToString();
            HiveHoneyLabelNumber.Text =string.Format("{0:f3}", beehive.GetHivePollenBalance().ToString()) ;
           //Nectar In field
            int nectar = 0;// beehive.FlowersList.Sum(a => a.FlowerPollenContainer);
            foreach (var f in world.FlowersList)
            {
                if(f.FlowerLibationPointX !=0 && f.FlowerLibationPointY !=0)
                {
                    nectar += f.FlowerPollenContainer;
                }
            }
            FieldNectarLabelNumber.Text = nectar.ToString();//string.Format("{0:f3}",nectar);
            nectar = 0;
            FramesRunLabelNumber.Text = _framesRun.ToString();

            double milliSeconds = frameDuration.TotalMilliseconds;
            if (milliSeconds != 0.0)
                FramesRateLabelNumber.Text
                         = string.Format("{0:f0} ({1:f1}ms)",
                    1000 / milliSeconds, milliSeconds);
            else
                FramesRateLabelNumber.Text = "N/A";
        }
        private void RunFrame(object sender, EventArgs e)
        {
            StatusBeeListBox.Items.Clear();
            StatusFlowerListBox.Items.Clear();
            _framesRun++;
            //Update all the reports
            _end = DateTime.Now;
            TimeSpan frameDuration = _end - _start;
            _start = _end;
            UpdateStats(frameDuration);
            foreach (var x in beehive.BeeList)
            {
                StatusBeeListBox.Items.Add(string.Format("Bee Id: {0} Move towards: {1}. Pollen Collected: {2}", x.BeeId, x.BeeTargetEnum.ToString(), x.BeePollenCollected.ToString()));           
            }

            foreach (var f in world.FlowersList)
            {
                StatusFlowerListBox.Items.Add(string.Format("Flower Id: {0} Stage: {1}. Pollen In flower: {2}",
                    f.FlowerID,
                    f.FlowerStage,
                    ((f.FlowerLibationPointX!=0 && f.FlowerLibationPointY!=0) ?f.FlowerPollenContainer  : 0)  ));
            }
            //Conditions to end the simulation
            int totalPollenInHive = beehive.GetHivePollenBalance();
            if (_maxTimeSimulation == _framesRun || totalPollenInHive >= 1000)
            {
                ResetAllInformation();
              
            }
        }
        private void toolStripButtonStart_Click(object sender, EventArgs e)
        {      
            if (timer1.Enabled)
            {
                toolStrip1.Items[0].Text = ControlButtonOptions.ResumeSimulation.ToString();
              
                timer1.Stop();
                F1.EnableFormHandlersAndTimers(false);
                InsideHiveForm.EnableFormHandlersAndTimers(false);
              
            }
            else
            {
                totalFlowersInField = (int)FlowersNumericUpDown.Value;
                flower.SetTotalFlowersInField(totalFlowersInField);
                beehive.SetTotalBeesInField((int)BeesNumericUpDown.Value);
                int value = PollenNumberComboBox.SelectedItem == null ? 100 : (int)PollenNumberComboBox.SelectedItem;
                beehive.SetTotalPollenForANewBee(value);
                toolStrip1.Items[0].Text = ControlButtonOptions.PauseSimulation.ToString();
                if(beehive.BeeList.Count==0)
                {
                    world.CreateFlower(totalFlowersInField);
                    beehive.CreateBee();
                }
                timer1.Start();
                F1.EnableFormHandlersAndTimers(true);
                InsideHiveForm.EnableFormHandlersAndTimers(true);            
            }
        }
        private void toolStripButtonReset_Click(object sender, EventArgs e)
        {
            ResetAllInformation();
           
        }
        private enum ControlButtonOptions
        {
            StartSimulation,
            PauseSimulation,
            ResumeSimulation
        }
        private void DashboardForm_Move(object sender, EventArgs e)
        {
            MoveChildForms();
        }
        private void MoveChildForms()
        {
            InsideHiveForm.Location = new Point(Location.X + Width - 10, Location.Y);
            F1.Location = new Point(Location.X+305,
                Location.Y + Math.Max(Height, InsideHiveForm.Height) - 200);
        }

        private void ResetAllInformation()
        {
            //Everything goest back to zero
            _framesRun = 0;
            StatusBeeListBox.Items.Clear();
            StatusFlowerListBox.Items.Clear();
            BeesLabelNumber.Text = Convert.ToString(0);
            FlowerLabelNumber.Text = Convert.ToString(0);
            HiveHoneyLabelNumber.Text = Convert.ToString(0);
            FramesRunLabelNumber.Text = Convert.ToString(0);
            FramesRateLabelNumber.Text = Convert.ToString(0);         
            FieldNectarLabelNumber.Text = Convert.ToString(0);
         
            beehive.SetHivePollenBallance(0);
            HiveHoneyLabelNumber.Text = string.Format("{0:f3}", beehive.GetHivePollenBalance().ToString());
            toolStrip1.Items[0].Text = ControlButtonOptions.StartSimulation.ToString();
            timer1.Stop();
            F1.EnableFormHandlersAndTimers(false);
            InsideHiveForm.EnableFormHandlersAndTimers(false);

            //We remove all the bees from the field
            beehive.BeeList.Clear();
            F1.Refresh();

            //We remove all the flowers from the field
            world.FlowersList.Clear();
            F1.Refresh();
            InsideHiveForm.Refresh();
        }

        
    }
}
