using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ChequeProcessing
{
    public class ScannerRanger : System.Windows.Forms.Form
    {
        private AxRANGERLib.AxRanger axRanger1;
        //private RANGERLib.Ranger axRanger1;
        public ScannerRangerListener Listener;
        private bool usingIQA;
        private bool toEndorse;
        private bool isStarted;
        string currentMICRText;
        private int lineNo;
        private long startSeq;
        private System.ComponentModel.Container components = null;
        private PictureBox pbxRear;
        private PictureBox pbxFront;
        internal Label Label3;
        internal Label Label4;
        internal TextBox txtNewItem;
        internal TextBox txtInPocket;
        internal Label Label1;
        internal Label Label2;
        internal TextBox txtState;
        internal TextBox txtMICR;
        internal Button cmdStartFeeding;
        internal Button cmdStopFeeding;
        internal Button cmdShutDown;
        internal Button cmdStartUp;

        private int maxLines;

        string scanner;
        string model;

        #region Enumerations
        private enum XportStates
        {
            TransportShutDown = 0,
            TransportStartingUp = 1,
            TransportChangeOptions = 2,
            TransportEnablingOptions = 3,
            TransportReadyToFeed = 4,
            TransportFeeding = 5,
            TransportExceptionInProgress = 6,
            TransportShuttingDown = 7
        };

        private enum FeedingStoppedReasons
        {
            FeedRequestFinished = 0,
            MainHopperEmpty = 1,
            MergeHopperEmpty = 2,
            ManualDropEmpty = 3,
            FeedStopRequested = 4,
            ClearTrackRequested = 5,
            BlackBandItemDetected = 6,
            EndOfLogicalMicrofilmRoll = 7,
            ExceptionDetected = 8
        };

        private enum IQATestIDs
        {
            IQATest_UndersizeImage = 1,
            IQATest_OversizeImage = 2,
            IQATest_BelowMinCompressedSize = 3,
            IQATest_AboveMaxCompressedSize = 4,
            IQATest_FrontRearDimensionMismatch = 5,
            IQATest_HorizontalStreaks = 6,
            IQATest_ImageTooLight = 7,
            IQATest_ImageTooDark = 8,
            IQATest_CarbonStrip = 9,
            IQATest_FramingError = 10,
            IQATest_ExcessiveSkew = 11,
            IQATest_TornEdges = 12,
            IQATest_TornCorners = 13,
            IQATest_SpotNoise = 14
        };

        private enum IQATestStatus
        {
            IQATestStatus_NotTested = 0,
            IQATestStatus_DefectPresent = 1,
            IQATestStatus_DefectNotPresent = 2
        };

        private enum IQAResults
        {
            IQAResult_TestResult = 1
        };

        private enum IQAResults_UndersizeImage : int
        {
            UndersizeImage_ImageWidth = 2,
            UndersizeImage_ImageHeight = 3
        };

        private enum IQAResults_OversizeImage
        {
            OversizeImage_ImageWidth = 2,
            OversizeImage_ImageHeight = 3
        };

        private enum IQAResults_BelowMinCompressedSize
        {
            BelowMinCompressedSize_CompressedImageSize = 2,
            BelowMinCompressedSize_ImageResolution = 3
        };

        private enum IQAResults_AboveMaxCompressedSize
        {
            AboveMaxCompressedSize_CompressedImageSize = 2,
            AboveMaxCompressedSize_ImageResolution = 3
        };

        private enum IQAResults_FrontRearDimensionMismatch
        {
            FrontRearDimensionMismatch_WidthDifference = 2,
            FrontRearDimensionMismatch_HeightDifference = 3
        };

        private enum IQAResults_HorizontalStreaks
        {
            HorizontalStreaks_StreakCount = 2,
            HorizontalStreaks_ThickestStreak = 3,
            HorizontalStreaks_ThickestStreakLocation = 4
        };

        private enum IQAResults_ImageTooLight
        {
            ImageTooLight_BitonalBlackPixelPercent = 2
        };

        private enum IQAResults_ImageTooDark
        {
            ImageTooDark_BitonalBlackPixelPercent = 2
        };

        private enum IQAResults_FramingError
        {
            FramingError_TopEdge = 2,
            FramingError_LeftEdge = 3,
            FramingError_BottomEdge = 4,
            FramingError_RightEdge = 5
        };

        private enum IQAResults_ExcessiveSkew
        {
            ExcessiveSkew_Angle = 2
        };

        private enum IQAResults_TornEdges
        {
            TornEdges_LeftTearWidth = 2,
            TornEdges_LeftTearHeight = 3,
            TornEdges_BottomTearWidth = 4,
            TornEdges_BottomTearHeight = 5,
            TornEdges_RightTearWidth = 6,
            TornEdges_RightTearHeight = 7,
            TornEdges_TopTearWidth = 8,
            TornEdges_TopTearHeight = 9
        };

        private enum IQAResults_TornCorners
        {
            TornCorners_TopLeftTearWidth = 2,
            TornCorners_TopLeftTearHeight = 3,
            TornCorners_BottomLeftTearWidth = 4,
            TornCorners_BottomLeftTearHeight = 5,
            TornCorners_TopRightTearWidth = 6,
            TornCorners_TopRightTearHeight = 7,
            TornCorners_BottomRightTearWidth = 8,
            TornCorners_BottomRightTearHeight = 9
        };

        private enum IQAResults_SpotNoise
        {
            SpotNoise_AverageSpotNoiseCount = 2
        };

        private enum Sides
        {
            TransportFront = 0,
            TransportRear = 1,
        };

        private enum ImageColorTypes
        {
            ImageColorTypeUnknown = -1,
            ImageColorTypeBitonal = 0,
            ImageColorTypeGrayscale = 1,
            ImageColorTypeColor = 2
        };


        #endregion

        int i = 0;
        string preFix;
        string postFix;

        public ScannerRanger(ScannerRangerListener Listener)
        {
            InitializeComponent();
            this.Listener = Listener;
        }

        public ScannerRanger()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScannerRanger));
            this.axRanger1 = new AxRANGERLib.AxRanger();
            this.pbxRear = new System.Windows.Forms.PictureBox();
            this.pbxFront = new System.Windows.Forms.PictureBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtNewItem = new System.Windows.Forms.TextBox();
            this.txtInPocket = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtState = new System.Windows.Forms.TextBox();
            this.txtMICR = new System.Windows.Forms.TextBox();
            this.cmdStartFeeding = new System.Windows.Forms.Button();
            this.cmdStopFeeding = new System.Windows.Forms.Button();
            this.cmdShutDown = new System.Windows.Forms.Button();
            this.cmdStartUp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axRanger1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFront)).BeginInit();
            this.SuspendLayout();
            // 
            // axRanger1
            // 
            this.axRanger1.Enabled = true;
            this.axRanger1.Location = new System.Drawing.Point(422, 12);
            this.axRanger1.Name = "axRanger1";
            this.axRanger1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axRanger1.OcxState")));
            this.axRanger1.Size = new System.Drawing.Size(96, 93);
            this.axRanger1.TabIndex = 22;
            this.axRanger1.TransportNewItem += new System.EventHandler(this.axRanger1_TransportNewItem);
            this.axRanger1.TransportNewState += new AxRANGERLib._DRangerEvents_TransportNewStateEventHandler(this.axRanger1_TransportNewState);
            this.axRanger1.TransportSetItemOutput += new AxRANGERLib._DRangerEvents_TransportSetItemOutputEventHandler(this.axRanger1_TransportSetItemOutput);
            this.axRanger1.TransportItemInPocket += new AxRANGERLib._DRangerEvents_TransportItemInPocketEventHandler(this.axRanger1_TransportItemInPocket);
            this.axRanger1.TransportReadyToFeedState += new AxRANGERLib._DRangerEvents_TransportReadyToFeedStateEventHandler(this.axRanger1_TransportReadyToFeedState);
            this.axRanger1.TransportChangeOptionsState += new AxRANGERLib._DRangerEvents_TransportChangeOptionsStateEventHandler(this.axRanger1_TransportChangeOptionsState);
            this.axRanger1.TransportFeedingStopped += new AxRANGERLib._DRangerEvents_TransportFeedingStoppedEventHandler(this.axRanger1_TransportFeedingStopped);
            this.axRanger1.TransportFeedingState += new System.EventHandler(this.axRanger1_TransportFeedingState);
            // 
            // pbxRear
            // 
            this.pbxRear.Location = new System.Drawing.Point(8, 377);
            this.pbxRear.Name = "pbxRear";
            this.pbxRear.Size = new System.Drawing.Size(448, 221);
            this.pbxRear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxRear.TabIndex = 24;
            this.pbxRear.TabStop = false;
            // 
            // pbxFront
            // 
            this.pbxFront.Location = new System.Drawing.Point(8, 140);
            this.pbxFront.Name = "pbxFront";
            this.pbxFront.Size = new System.Drawing.Size(448, 221);
            this.pbxFront.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxFront.TabIndex = 23;
            this.pbxFront.TabStop = false;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(602, 24);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(55, 13);
            this.Label3.TabIndex = 16;
            this.Label3.Text = "New Item:";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(602, 63);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(56, 13);
            this.Label4.TabIndex = 17;
            this.Label4.Text = "In Pocket:";
            // 
            // txtNewItem
            // 
            this.txtNewItem.Enabled = false;
            this.txtNewItem.Location = new System.Drawing.Point(674, 24);
            this.txtNewItem.Name = "txtNewItem";
            this.txtNewItem.Size = new System.Drawing.Size(40, 20);
            this.txtNewItem.TabIndex = 20;
            // 
            // txtInPocket
            // 
            this.txtInPocket.Enabled = false;
            this.txtInPocket.Location = new System.Drawing.Point(674, 63);
            this.txtInPocket.Name = "txtInPocket";
            this.txtInPocket.Size = new System.Drawing.Size(40, 20);
            this.txtInPocket.TabIndex = 21;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(112, 48);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(70, 13);
            this.Label1.TabIndex = 14;
            this.Label1.Text = "Ranger State";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(112, 80);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(34, 13);
            this.Label2.TabIndex = 15;
            this.Label2.Text = "MICR";
            // 
            // txtState
            // 
            this.txtState.Enabled = false;
            this.txtState.Location = new System.Drawing.Point(192, 48);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(128, 20);
            this.txtState.TabIndex = 18;
            // 
            // txtMICR
            // 
            this.txtMICR.Enabled = false;
            this.txtMICR.Location = new System.Drawing.Point(152, 80);
            this.txtMICR.Name = "txtMICR";
            this.txtMICR.Size = new System.Drawing.Size(264, 20);
            this.txtMICR.TabIndex = 19;
            // 
            // cmdStartFeeding
            // 
            this.cmdStartFeeding.Location = new System.Drawing.Point(0, 0);
            this.cmdStartFeeding.Name = "cmdStartFeeding";
            this.cmdStartFeeding.Size = new System.Drawing.Size(80, 32);
            this.cmdStartFeeding.TabIndex = 12;
            this.cmdStartFeeding.Text = "Start Feeding";
            this.cmdStartFeeding.Click += new System.EventHandler(this.cmdStartFeeding_Click);
            // 
            // cmdStopFeeding
            // 
            this.cmdStopFeeding.Location = new System.Drawing.Point(0, 0);
            this.cmdStopFeeding.Name = "cmdStopFeeding";
            this.cmdStopFeeding.Size = new System.Drawing.Size(80, 32);
            this.cmdStopFeeding.TabIndex = 13;
            this.cmdStopFeeding.Text = "Stop Feeding";
            this.cmdStopFeeding.Click += new System.EventHandler(this.cmdStopFeeding_Click);
            // 
            // cmdShutDown
            // 
            this.cmdShutDown.Location = new System.Drawing.Point(0, 0);
            this.cmdShutDown.Name = "cmdShutDown";
            this.cmdShutDown.Size = new System.Drawing.Size(80, 31);
            this.cmdShutDown.TabIndex = 11;
            this.cmdShutDown.Text = "Shutdown";
            this.cmdShutDown.Click += new System.EventHandler(this.cmdShutDown_Click);
            // 
            // cmdStartUp
            // 
            this.cmdStartUp.Location = new System.Drawing.Point(0, 0);
            this.cmdStartUp.Name = "cmdStartUp";
            this.cmdStartUp.Size = new System.Drawing.Size(80, 32);
            this.cmdStartUp.TabIndex = 10;
            this.cmdStartUp.Text = "Start Ranger";
            this.cmdStartUp.Click += new System.EventHandler(this.cmdStartUp_Click);
            // 
            // ScannerRanger
            // 
            this.ClientSize = new System.Drawing.Size(722, 606);
            this.Controls.Add(this.pbxRear);
            this.Controls.Add(this.pbxFront);
            this.Controls.Add(this.axRanger1);
            this.Controls.Add(this.txtInPocket);
            this.Controls.Add(this.txtNewItem);
            this.Controls.Add(this.txtMICR);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.cmdStopFeeding);
            this.Controls.Add(this.cmdStartFeeding);
            this.Controls.Add(this.cmdShutDown);
            this.Controls.Add(this.cmdStartUp);
            this.MaximizeBox = false;
            this.Name = "ScannerRanger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "C#.Net BareBones";
            this.Load += new System.EventHandler(this.main_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.main_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.axRanger1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFront)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Public Methods...

        public void StartUp()
        {
            cmdStartUp.Enabled = false;
            isStarted = true;
            axRanger1.StartUp();
        }

        public void StartScan(bool toEndorse, string startSequence, string preFix, string postFix, int lnNo)
        {
            int FeedSourceMainHopper = 0, FeedContinuously = 0;

            cmdShutDown.Enabled = false;
            cmdStartFeeding.Enabled = false;

            this.preFix = preFix;
            this.postFix = postFix;
            this.toEndorse = toEndorse;
            this.lineNo = lnNo + 1;

            if (scanner == null)
            {
                scanner = axRanger1.GetTransportInfo("General", "Make");
            }
            try
            {
                startSeq = long.Parse(startSequence);
            }
            catch
            { }
            txtMICR.Text = "";
            if (scanner == "Canon")
            {
                if (toEndorse)
                {
                    string counter = startSequence;
                    axRanger1.CallPassthroughMethod("SetPageCount(" + counter + ")");
                    //axRanger1.SetFixedEndorseText((int)Sides.TransportRear, 1, preFix + " <C11> " + postFix);
                    axRanger1.SetFixedEndorseText((int)Sides.TransportRear, lineNo, preFix + " <C11> " + postFix);
                }
                else
                {
                    axRanger1.SetFixedEndorseText((int)Sides.TransportRear, 1, "");
                }
                axRanger1.StartFeeding(FeedSourceMainHopper, FeedContinuously);
            }
            else if (scanner == "DigitalCheck BUICAPI" )
            {
                if (toEndorse)
                {
                    axRanger1.SetFixedEndorseText((int)Sides.TransportRear, 1, preFix + " " +
                        startSeq.ToString("00000000000") + " " + postFix);
                }
                else
                {
                    axRanger1.SetFixedEndorseText((int)Sides.TransportRear, 1, "");
                }
                axRanger1.StartFeeding(FeedSourceMainHopper, FeedContinuously);
            }
            else if (scanner == "Panini")
            {
                if (lineNo > maxLines)
                {
                    lineNo = maxLines;
                }
                if (toEndorse)
                {

                    int restLine1 = ((lineNo + 1) % 3 == 0) ? 3 : (lineNo + 1) % 3;
                    int restLine2 = ((lineNo + 2) % 3 == 0) ? 3 : (lineNo + 2) % 3;
                    axRanger1.SetFixedEndorseText((int)Sides.TransportRear, restLine1, "");
                    axRanger1.SetFixedEndorseText((int)Sides.TransportRear, restLine2, "");

                    axRanger1.SetFixedEndorseText((int)Sides.TransportRear, lineNo, preFix + " " +
                        startSeq.ToString("00000000000") + " " + postFix);
                }
                else
                {
                    axRanger1.SetFixedEndorseText((int)Sides.TransportRear, 1, "");
                    axRanger1.SetFixedEndorseText((int)Sides.TransportRear, 2, "");
                    axRanger1.SetFixedEndorseText((int)Sides.TransportRear, 3, "");
                }
                axRanger1.StartFeeding(FeedSourceMainHopper, FeedContinuously);

            }
            else if (scanner == "Unisys")
            {
                if (toEndorse)
                {
                    //axRanger1.SetFixedEndorseText((int)Sides.TransportRear, lineNo, (preFix + " " +
                    //    startSeq.ToString("00000000000") + " " + postFix));
                    int restLine1 = ((lineNo + 1) % 3 == 0) ? 3 : (lineNo + 1) % 3;
                    int restLine2 = ((lineNo + 2) % 3 == 0) ? 3 : (lineNo + 2) % 3;
                    axRanger1.SetFixedEndorseText((int)Sides.TransportRear, restLine1, "");
                    axRanger1.SetFixedEndorseText((int)Sides.TransportRear, restLine2, "");
                }
                else
                {
                    axRanger1.SetFixedEndorseText((int)Sides.TransportRear, 1, "");
                    axRanger1.SetFixedEndorseText((int)Sides.TransportRear, 2, "");
                    axRanger1.SetFixedEndorseText((int)Sides.TransportRear, 3, "");
                }
                axRanger1.StartFeeding(FeedSourceMainHopper, FeedContinuously);
            }
            else if (scanner == "MagTek")
            {
                if (toEndorse)
                {
                    axRanger1.SetFixedEndorseText((int)Sides.TransportRear, 1, (preFix + " " +
                        startSeq.ToString("00000000000") + " " + postFix));
                }
                else
                {
                    axRanger1.SetFixedEndorseText((int)Sides.TransportRear, 1, "");
                }
                axRanger1.StartFeeding(FeedSourceMainHopper, FeedContinuously);
            }
            cmdStopFeeding.Enabled = true;
        }

        public void StopScan()
        {
            axRanger1.StopFeeding();
        }

        public void ShutDown()
        {
            if (isStarted)
            {

                axRanger1.ShutDown();
                isStarted = false;
                if (scanner == "Panini")
                {
                    System.Threading.Thread.Sleep(3000);
                }
            }
        }
        #endregion



        private void axRanger1_TransportChangeOptionsState(object sender, AxRANGERLib._DRangerEvents_TransportChangeOptionsStateEvent e)
        {

            if (e.previousState == (int)XportStates.TransportStartingUp)
            {

                axRanger1.SetGenericOption("OptionalDevices", "NeedImaging", "true");
                axRanger1.SetGenericOption("OptionalDevices", "NeedFrontImage1", "true");
                axRanger1.SetGenericOption("OptionalDevices", "NeedRearImage1", "true");

                axRanger1.SetGenericOption("OptionalDevices", "NeedFrontImage2", "False");
                axRanger1.SetGenericOption("OptionalDevices", "NeedRearImage2", "False");
                axRanger1.SetGenericOption("OptionalDevices", "NeedFrontImage3", "False");
                axRanger1.SetGenericOption("OptionalDevices", "NeedRearImage3", "False");
                axRanger1.SetGenericOption("OptionalDevices", "NeedFrontImage4", "False");
                axRanger1.SetGenericOption("OptionalDevices", "NeedRearImage4", "False");

                axRanger1.SetGenericOption("OptionalDevices", "NeedRearEndorser", "true");
                
                scanner = axRanger1.GetTransportInfo("General", "Make");
                model = axRanger1.GetTransportInfo("General", "Model");
                maxLines = Int32.Parse(axRanger1.GetTransportInfo("RearEndorser", "MaxLines"));

                if (scanner == "Canon")
                {
                    axRanger1.SetDriverOption("Endorser", "PageCountIncrement", "1");
                    axRanger1.SetDriverOption("Endorser", "PrintSide", "TrailEdge");
                    if (model == "CR-190i" || model == "CR-135i")
                    {
                        axRanger1.SetDriverOption("Endorser", "YPosition", "20");
                    }
                    else
                    {
                        axRanger1.SetDriverOption("Endorser", "YPosition", "75");
                    }
                    axRanger1.SetDriverOption("Endorser", "Font", "Small");

                    axRanger1.SetDriverOption("Imaging", "BackgroundErase", "true");
                    axRanger1.SetDriverOption("Imaging", "Deskew", "true");

                    axRanger1.SetDriverOption("FrontBitonalImage", "Resolution", "200");
                    axRanger1.SetDriverOption("RearBitonalImage", "Resolution", "200");
                }
                else if (scanner == "Panini")
                {
                    axRanger1.SetDriverOption("Inkjet", "EndorsementOffset", "5");
                    axRanger1.SetDriverOption("Inkjet", "PrintEdge", "Trailing");
                    axRanger1.SetDriverOption("Inkjet", "FontHeight", "19");
                    axRanger1.SetDriverOption("Inkjet", "FontWidth", "9");
                    axRanger1.SetDriverOption("Inkjet", "FontWeight", "500");
                    axRanger1.SetDriverOption("Inkjet", "AGPQuality", "High");
                }
                axRanger1.EnableOptions();
            }
        }

        private void axRanger1_TransportNewState(object sender, AxRANGERLib._DRangerEvents_TransportNewStateEvent e)
        {
            DisplayRangerState();
            if (e.currentState == (int)XportStates.TransportChangeOptions)
            {
                cmdShutDown.Enabled = true;
            }
            else if (e.currentState == (int)XportStates.TransportReadyToFeed)
            {
                cmdStartFeeding.Enabled = true;
                Listener.ScannerReady();
            }
            else if (e.currentState == (int)XportStates.TransportFeeding)
            {
                Listener.ScanningStarted();
            }
            else if (e.currentState == (int)XportStates.TransportExceptionInProgress)
            {
            }
            else if (e.currentState == (int)XportStates.TransportShutDown)
            {
                cmdStartFeeding.Enabled = false;
                cmdStopFeeding.Enabled = false;
                Listener.CannotConnect();
            }
            else if (e.currentState == (int)XportStates.TransportStartingUp)
            {
                Listener.StartingUp();
            }
        }

        private void DisplayRangerState()
        {
            txtState.Text = axRanger1.GetTransportStateString();
        }

        private void axRanger1_TransportFeedingStopped(object sender, AxRANGERLib._DRangerEvents_TransportFeedingStoppedEvent e)
        {
            if (e.reason == (int)FeedingStoppedReasons.MainHopperEmpty)
            {
                cmdShutDown.Enabled = true;
                cmdStartFeeding.Enabled = true;
                cmdStopFeeding.Enabled = false;

                Listener.ScanningCompleted();

            }
            else if (e.reason == (int)FeedingStoppedReasons.FeedRequestFinished)
            {
                Listener.ScanningCompleted();
            }
            else if (e.reason == (int)FeedingStoppedReasons.FeedStopRequested)
            {
            }
        }

        private void axRanger1_TransportNewItem(object sender, System.EventArgs e)
        {
            int ItemID = axRanger1.GetItemID();
            txtNewItem.Text = ItemID.ToString();
            ++startSeq;
            if (scanner == "Unisys" && toEndorse)
            {
                axRanger1.SetEndorseText((int)Sides.TransportRear, lineNo, (preFix + " " +
                    startSeq.ToString("00000000000") + " " + postFix));
            }
            else if (scanner == "Panini" && toEndorse)
            {
                axRanger1.SetFixedEndorseText((int)Sides.TransportRear, lineNo, preFix + " " +
                        startSeq.ToString("00000000000") + " " + postFix);
            }
            else if (scanner != "Canon" && toEndorse)
            {
                axRanger1.SetFixedEndorseText((int)Sides.TransportRear, 1, preFix + " " +
                    startSeq.ToString("00000000000") + " " + postFix);
            }
        }

        private void axRanger1_TransportSetItemOutput(object sender, AxRANGERLib._DRangerEvents_TransportSetItemOutputEvent e)
        {
            currentMICRText = axRanger1.GetMicrText(1);
            txtMICR.Text = '"' + currentMICRText + '"';
        }

        private void axRanger1_TransportItemInPocket(object sender, AxRANGERLib._DRangerEvents_TransportItemInPocketEvent e)
        {

            txtInPocket.Text = e.itemId.ToString();

            /*            Note: The following section illustrates the process of retrieving the front and rear bitonal images.
            Both the 'GetImageByteCount' and 'GetImageAddress' methods refer to images that were requested in
            the event handler AxRanger1_TransportChangeOptionsState via 'NeedFrontImage1' and 'NeedRearImage1'.
            If grayscale images are to be requested,  NeedFrontImage2/NeedRearImage2 should be set to 'true'
            and 'ImageColorTypeGrayscale' should be passed to both the GetImageByteCount and GetImageAddress methods.
            */


            int sizeFront;
            sizeFront = axRanger1.GetImageByteCount((int)Sides.TransportFront, (int)ImageColorTypes.ImageColorTypeBitonal);
            byte[] mybytesFront = new byte[sizeFront];

            IntPtr ptrFront = new IntPtr(axRanger1.GetImageAddress((int)Sides.TransportFront, (int)ImageColorTypes.ImageColorTypeBitonal));

            Marshal.Copy(ptrFront, mybytesFront, 0, sizeFront);

            System.IO.MemoryStream streamBitmapFront = new MemoryStream(mybytesFront);
            Bitmap bitImageFront = new Bitmap(Image.FromStream(streamBitmapFront));

            pbxFront.Image = bitImageFront;

            int sizeRear;
            sizeRear = axRanger1.GetImageByteCount((int)Sides.TransportRear, (int)ImageColorTypes.ImageColorTypeBitonal);
            byte[] mybytesRear = new byte[sizeRear];

            IntPtr ptrRear = new IntPtr(axRanger1.GetImageAddress((int)Sides.TransportRear, (int)ImageColorTypes.ImageColorTypeBitonal));

            Marshal.Copy(ptrRear, mybytesRear, 0, sizeRear);

            System.IO.MemoryStream streamBitmapRear = new MemoryStream(mybytesRear);
            Bitmap bitImageRear = new Bitmap(Image.FromStream(streamBitmapRear));

            pbxRear.Image = bitImageRear;

            currentMICRText = axRanger1.GetMicrText(1);
            string endorseText = (startSeq - 1).ToString("00000000000");;

            if(scanner != "Canon" && toEndorse)
            {
                endorseText = axRanger1.GetEndorseText((int)Sides.TransportRear, lineNo).Substring(10, 11);
            }

            Cheque cheque = new Cheque(
                currentMICRText,
                ImageConverter.ToCCITT4(bitImageFront, currentMICRText + "F"),
                ImageConverter.ToCCITT4(bitImageRear, currentMICRText + "B"),
                endorseText
            );
            
            Listener.ChequeScanned(cheque);
        }

        private void main_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (axRanger1.GetTransportState() != (int)XportStates.TransportShutDown)
            {
                MessageBox.Show("You cannot close this application without shutting down ranger");
                e.Cancel = true;
            }
        }
        
        public void SetListener(ScannerRangerListener Listner)
        {
            this.Listener = Listner;
        }

        private void axRanger1_TransportFeedingState(object sender, EventArgs e)
        {
        }

        private void cmdStartUp_Click(object sender, System.EventArgs e)
        {
            cmdStartUp.Enabled = false;
            isStarted = true;
            axRanger1.StartUp();
        }

        private void cmdShutDown_Click(object sender, System.EventArgs e)
        {
            axRanger1.ShutDown();
            isStarted = false;
            cmdShutDown.Enabled = false;
            cmdStartUp.Enabled = true;
        }

        private void main_Load(object sender, System.EventArgs e)
        {
            cmdStartUp.Enabled = true;
            cmdShutDown.Enabled = true;
            cmdStartFeeding.Enabled = false;
            cmdStopFeeding.Enabled = false;
            DisplayRangerState();
        }

        private void cmdStartFeeding_Click(object sender, System.EventArgs e)
        {
            int FeedSourceMainHopper = 0,
                FeedContinuously = 0;

            cmdShutDown.Enabled = false;
            cmdStartFeeding.Enabled = false;

            txtMICR.Text = "";
            axRanger1.StartFeeding(FeedSourceMainHopper, FeedContinuously);
            cmdStopFeeding.Enabled = true;

        }

        private void cmdStopFeeding_Click(object sender, System.EventArgs e)
        {
            cmdStopFeeding.Enabled = false;

            axRanger1.StopFeeding();

            cmdStartFeeding.Enabled = true;
            cmdShutDown.Enabled = true;
        }

        private void axRanger1_TransportReadyToFeedState(object sender, AxRANGERLib._DRangerEvents_TransportReadyToFeedStateEvent e)
        {
            if (scanner == "MagTek" && toEndorse)
            {
                axRanger1.SetFixedEndorseText((int)Sides.TransportRear, lineNo, preFix + " " +
                        startSeq.ToString("00000000000") + " " + postFix);
            }

            if (scanner == "Unisys")
            {
                //axRanger1.SetDriverOption("Endorse.MJEREAR", "PAGEENDREARPOSITION", "50");
                axRanger1.CallPassthroughMethod("SetPEndRearPosition(46)");
            }
        }
    }
}
