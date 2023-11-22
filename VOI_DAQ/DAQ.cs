using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//namespace MLDC_DataLog
    namespace VOI_DAQ
{
    class DAQ
    {
        public static Int32 EncPulseSample = 0;
        public static Int32 EncPulseSample_Close = 0;
        public static string[] EncoderPulseArr = new string[20000];
        public static string[] SpeedActual_Arr = new string[20000];
        public static string[] SpeedTarget_Arr = new string[20000];
        public static string[] SpeedAverageSProfile_Arr = new string[20000];
        public static string[] CurrentDiffArr = new string[20000];
        public static string[] CurrentSetArr = new string[20000];
        public static string[] ErrorArr = new string[20000];
        public static string[] PIDArr = new string[20000];

      //             MLDC.PIDHighLimitArr[MLDC.EncPulseSample_Close] = (MLDC.PID_HIGHLIMT / 10).ToString();
        //           MLDC.PIDLowLimitArr[MLDC.EncPulseSample_Close] = (MLDC.PID_LOWLIMT / 10).ToString();
        public static string[] PIDHighLimitArr = new string[20000];
        public static string[] PIDLowLimitArr = new string[20000];
        public static string[] ProfileArr = new string[20000];

     //   public static string[] CurrentErrorArr = new string[20000];
        
        public static Int16  Error;
    //    public static Int16 CurrentError;
        public static UInt16 PID_HIGHLIMT;
        public static UInt16 PID_LOWLIMT;
        public static UInt16 PID;
        public static UInt16 Current_Setlevel;
        public static UInt16 Current_Sampled;
        public static Int32 Current_Diff;
        public static Int32 Current_Set;
        
  //      public static string[] DataArray1 = new string[10000];
  //      public static string[] DataArray2 = new string[10000];
 //       public static string[] DataArray3 = new string[10000];
//        public static string[] DataArray4 = new string[10000];



        public static  Int32 EncPulse_InspectedMax;
        public static  Int32 EncPulse_Current;
        public static  Int32 EncPulse_Current_Previous;
        
    }
}
