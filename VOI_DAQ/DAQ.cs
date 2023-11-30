using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//namespace MLDC_DataLog
    namespace VOI_DAQ
{
    class DAQ
    {
        public static UInt32 Index = 0; // index
        public static UInt32 Offset = 0; // index
        public static UInt32 Encoder = 0;


        public static UInt16 Voltage = 0;
        public static UInt16 Current = 0;
        public static UInt16 Speed = 0;
        public static UInt16 Power = 0;
        public static Int16 Temperature = 0;

        public static  UInt16 MAX_ARRAY_SIZE = 500;
     //   public static UInt16  MAX_ARRAY = 499;

        public static string[] Index_Arr = new string[MAX_ARRAY_SIZE];
        public static string[] Speed_Arr = new string[MAX_ARRAY_SIZE];
        public static string[] Voltage_Arr = new string[MAX_ARRAY_SIZE];
        public static string[] Current_Arr  = new string[MAX_ARRAY_SIZE];
        public static string[] Power_Arr = new string[MAX_ARRAY_SIZE];
        public static string[] Temperature_Arr = new string[MAX_ARRAY_SIZE];

        public static UInt16 InitTimer = 0;
        public static bool EnableInitTimer = true ;
        public static bool Enable_Menu_Time_Update = false;


        public static bool Log_Status = false;
        public static bool Log_Error = false;

        public static int Log_Counter = 0;
        public static int Log_SampleCounter = 0;

        public static readonly string Log_Directory = "DataLog";
        public static string Original_Log_File = "DataLog\\data.csv";
        public static string Original_Log_File_Base;

        public static int Log_FileCount = 0;

        public static string nl = System.Environment.NewLine;
        public static string WorkDrive = "C:\\";

        // Original_Log_File

        // public static string[] ErrorArr = new string[20000];
        // public static string[] PIDArr = new string[20000];

        //             MLDC.PIDHighLimitArr[MLDC.EncPulseSample_Close] = (MLDC.PID_HIGHLIMT / 10).ToString();
        //           MLDC.PIDLowLimitArr[MLDC.EncPulseSample_Close] = (MLDC.PID_LOWLIMT / 10).ToString();
        //  public static string[] PIDHighLimitArr = new string[20000];
        //  public static string[] PIDLowLimitArr = new string[20000];
        //  public static string[] ProfileArr = new string[20000];

        //   public static string[] CurrentErrorArr = new string[20000];
        /*
        public static Int16  Error;
    //    public static Int16 CurrentError;
        public static UInt16 PID_HIGHLIMT;
        public static UInt16 PID_LOWLIMT;
        public static UInt16 PID;
        public static UInt16 Current_Setlevel;
        public static UInt16 Current_Sampled;
        public static Int32 Current_Diff;
        public static Int32 Current_Set;
        */
        //      public static string[] DataArray1 = new string[10000];
        //      public static string[] DataArray2 = new string[10000];
        //       public static string[] DataArray3 = new string[10000];
        //        public static string[] DataArray4 = new string[10000];



        // public static  Int32 EncPulse_InspectedMax;
        //   public static  Int32 EncPulse_Current;
        //  public static  Int32 Index_Previous;

    }
}

