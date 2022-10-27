using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.IO;

namespace ChequeProcessing
{
    public class ScannerObject
    {
        [DllImport(@"CR55.dll", CharSet = CharSet.Ansi)]
        public static extern string StartScan(string im_path, int img_type, int img_mode, int bit_perpixel, int xres, int yres);

        [DllImport(@"CR55.dll", CharSet = CharSet.Ansi)]
        public static extern string scan(
            int img_mode, string img_path, string img_name, int img_type,
            int bit_perpixel, int xres, int yres, bool read_MICR, bool read_OCR
        );

        [DllImport(@"CR55.dll", CharSet = CharSet.Ansi)]
        public static extern bool Check();

        [DllImport(@"CR55.dll", CharSet = CharSet.Ansi)]
        public static extern int check();

        [DllImport(@"CR55.dll", CharSet = CharSet.Ansi)]
        public static extern void SetImgProperty(int img_mode, int bit_perpixel, int xres, int yres);

        [DllImport(@"CR55.dll", CharSet = CharSet.Ansi)]
        public static extern void SetMicrProperty(bool read_MICR);

        private AxRANGERLib.AxRanger axRanger1;

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

        private bool UsingIQA;

        private bool IsStarted;

        public void StartScan()
        {
            if (!IsStarted)
            {
                IsStarted = true;
                axRanger1.StartUp();
            }
            int FeedSourceMainHopper = 0, FeedContinuously = 0;

            axRanger1.StartFeeding(FeedSourceMainHopper, FeedContinuously);
        }
        
        public void StopScan()
        {
            //Request that the transport stop feeding.
            //The "TransportTrackIsClear" event will be fired when all fed
            //items in the track have completed processing.
            axRanger1.StopFeeding();
        }
        
        private void axRanger1_TransportChangeOptionsState(object sender, AxRANGERLib._DRangerEvents_TransportChangeOptionsStateEvent e)
        {
            //Using the enum RangerTransportStates makes debugging easier.

            //if we just completed powering up...
            if (e.previousState == (int)XportStates.TransportStartingUp)
            {
                //This is "Bare Bones", uses default job-related parameters (see programmers reference)

                //enable imaging
                axRanger1.SetGenericOption("OptionalDevices", "NeedImaging", "True");
                axRanger1.SetGenericOption("OptionalDevices", "NeedFrontImage1", "True");
                axRanger1.SetGenericOption("OptionalDevices", "NeedRearImage1", "True");

                //Turn off the images we aren't going to use
                axRanger1.SetGenericOption("OptionalDevices", "NeedFrontImage2", "False");
                axRanger1.SetGenericOption("OptionalDevices", "NeedRearImage2", "False");
                axRanger1.SetGenericOption("OptionalDevices", "NeedFrontImage3", "False");
                axRanger1.SetGenericOption("OptionalDevices", "NeedRearImage3", "False");
                axRanger1.SetGenericOption("OptionalDevices", "NeedFrontImage4", "False");
                axRanger1.SetGenericOption("OptionalDevices", "NeedRearImage4", "False");

                //Request that the current job-related parameters be enabled.
                //The "OnTransportReadyToFeedState" event will be fired when the options are enabled.
                //Prior to the transport being ready to feed, Ranger will be in the "TransportEnablingOptions" state.

                axRanger1.EnableOptions(); //enable job-related parameters
                //else  (e.PrevState == (int)XportStates.TransportReadyToFeed)
                //This is true if you called axRanger1.PrepareToChangeOptions() in preparation
                //for changing job-related parameters (see programmers reference)
            }

        }

        private void axRanger1_TransportNewState(object sender, AxRANGERLib._DRangerEvents_TransportNewStateEvent e)
        {
            //This event is fired whenever Ranger changes its state.
            //Individual state events, such as "TransportChangeOptionsState",
            //are also fired after a state transition.
            //DisplayRangerState();


            if (e.currentState == (int)XportStates.TransportChangeOptions)
            {
                //If Startup completed sucessfully then we will be in 
                //change options state. So enable the shutdown button
                //cmdShutDown.Enabled = true;
            }
            else if (e.currentState == (int)XportStates.TransportReadyToFeed)
            {
                //If we have transitioned correctly from change options to
                //ready to feed, then enable the startfeeding button
                //cmdStartFeeding.Enabled = true;
            }
            else if (e.currentState == (int)XportStates.TransportShutDown)
            {
                //cmdStartFeeding.Enabled = false;
                //cmdStopFeeding.Enabled = false;
            }
        }

        private void axRanger1_TransportFeedingStopped(object sender, AxRANGERLib._DRangerEvents_TransportFeedingStoppedEvent e)
        {
            //This event is fired whenever feeding stops.  Items may still be on their way to the pocket.
            //The "TransportTrackIsClear" event will be fired when all items in the track have completed
            //processing (i.e in the pocket).
            //e.reason can be used to determine why the feeding was stopped

            //Enable the shutdown and start buttons once we have stopped feeding
            //and disable the stopfeeding button
            if (e.reason == (int)FeedingStoppedReasons.MainHopperEmpty)
            {
                //cmdShutDown.Enabled = true;
                //cmdStartFeeding.Enabled = true;
                //cmdStopFeeding.Enabled = false;
            }
        }

        private void axRanger1_TransportNewItem(object sender, System.EventArgs e)
        {
            //A new item has been fed.
            //From this point on, it could jam.

            //You can optionally set the ID used to identify this item during later events.
            //You can only set the item's ID during this event.
            //The item ID also stored with the item's image(s).

            //axRanger1.SetItemID(NextNewItemId);

            int ItemID = axRanger1.GetItemID();
            //txtNewItem.Text = ItemID.ToString();

            //You could do other application tasks related to managing a new item here.

            //You can also attach data to the item using m_Ranger.SetItemReference().
            //For example to attach a pointer to an application object use:
            //  AxRanger1.SetItemReference(YourObjectPointer);

            //You can retrieve your pointer during later events by calling AxRanger.GetItemReference().
            //Ranger will store your pointer until your TransportItemInPocket() event
            //handler returns. However, Ranger does not free any memory that you may have allocated
            //after the item is in the pocket.
        }

        private void axRanger1_TransportSetItemOutput(object sender, AxRANGERLib._DRangerEvents_TransportSetItemOutputEvent e)
        {
            //e.ItemId identifies which item this event refers to.

            //The code line text is available now for the item.

            //get MICR line and add quotes to ends of the line
            //txtMICR.Text = '"' + axRanger1.GetMicrText(1) + '"';

            //Set any output to be done to the item.
            // Use:   (see programmer's reference for details)
            //   AxRanger1.SetEncodeText("b0000012345b");
            //   AxRanger1.SetEndorseText(TransportRear, 1, "Rear Line #1");
            //   AxRanger1.SetEndorseText(TransportRear, 2, "Rear Line #2");
            //   etc.

            //Set the destination pocket
            axRanger1.SetTargetLogicalPocket(1);

            //Please note that pocket #1 is also used by Ranger for items rejected during excetion handling.

            //The item will be sent to the pocket when this function returns

            //Can call this to do data entry on the item, else the item will be pocketed
            //  AxRanger1.SuspendItem
        }

        private void axRanger1_TransportItemInPocket(object sender, AxRANGERLib._DRangerEvents_TransportItemInPocketEvent e)
        {
            //e.ItemId identifies which item this event refers to.
            //txtInPocket.Text = e.itemId.ToString();

            //At this point the item is either in the pocket or it was removed from
            //the document stream for some reason.


            //You also have access to all data read and output requests during this event.
            //Could call:
            //  AxRanger1.GetEncodeText()
            //  AxRanger1.GetEndorseText(TransportRear, 1)
            //  AxRanger1.GetEndorseText(TransportRear, 2)
            //  etc.

            //*****************************************
            //Copy the image from unmanaged memory to managed memory
            //that C# can access.

            /* 
            Note: The following section illustrates the process of retrieving the front and rear bitonal images.
            Both the 'GetImageByteCount' and 'GetImageAddress' methods refer to images that were requested in
            the event handler AxRanger1_TransportChangeOptionsState via 'NeedFrontImage1' and 'NeedRearImage1'.
            If grayscale images are to be requested,  NeedFrontImage2/NeedRearImage2 should be set to 'true'
            and 'ImageColorTypeGrayscale' should be passed to both the GetImageByteCount and GetImageAddress methods.
            */

            //get the size
            int sizeFront;
            sizeFront = axRanger1.GetImageByteCount((int)Sides.TransportFront, (int)ImageColorTypes.ImageColorTypeBitonal);
            byte[] mybytesFront = new byte[sizeFront];
            //create the pointer and assign the Ranger image address to it
            IntPtr ptrFront = new IntPtr(axRanger1.GetImageAddress((int)Sides.TransportFront, (int)ImageColorTypes.ImageColorTypeBitonal));
            //Copy the bytes from nmanaged memory to managed memory
            Marshal.Copy(ptrFront, mybytesFront, 0, sizeFront);
            //Create an image stream and a bitmap object to hold the image 
            MemoryStream streamBitmapFront = new MemoryStream(mybytesFront);
            Bitmap bitImageFront = new Bitmap(Image.FromStream(streamBitmapFront));
            //assign that bitmap object to the picture box

            //get the size
            int sizeRear;
            sizeRear = axRanger1.GetImageByteCount((int)Sides.TransportRear, (int)ImageColorTypes.ImageColorTypeBitonal);
            byte[] mybytesRear = new byte[sizeRear];
            //create the pointer and assign the Ranger image address to it
            IntPtr ptrRear = new IntPtr(axRanger1.GetImageAddress((int)Sides.TransportRear, (int)ImageColorTypes.ImageColorTypeBitonal));
            //Copy the bytes from nmanaged memory to managed memory
            Marshal.Copy(ptrRear, mybytesRear, 0, sizeRear);
            //Create an image stream and a bitmap object to hold the image 
            MemoryStream streamBitmapRear = new MemoryStream(mybytesRear);
            Bitmap bitImageRear = new Bitmap(Image.FromStream(streamBitmapRear));
            //assign that bitmap object to the picture box


            //*****************************************



        }

        private void main_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Don't let the user shut the program down without first shutting down the
            //Ranger driver.
            if (axRanger1.GetTransportState() != (int)XportStates.TransportShutDown)
            {
                System.Windows.Forms.MessageBox.Show("You cannot close this application without shutting down ranger");
                e.Cancel = true;
            }
        }

    }
}