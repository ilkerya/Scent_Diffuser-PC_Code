
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

//namespace MLDC_DataLog
//namespace VOI_DAQ
     namespace DAQ_VOC
{
    class DAQ
    {
        public static bool Connect ;
        public static UInt16 Int_Counter = 0;
     //   public static byte Task_Counter = 0;
        public static UInt32 Index = 0; // index
        public static UInt32 Offset = 0; // index

        public static UInt32 Multi_Gas_1_VOC = 0;
        public static UInt32 Multi_Gas_1_C2H5OH = 0;
        public static UInt32 Multi_Gas_1_CO = 0;
        public static UInt32 Multi_Gas_1_NO2 = 0;

        public static UInt32 Multi_Gas_2_VOC = 0;
        public static UInt32 Multi_Gas_2_C2H5OH = 0;
        public static UInt32 Multi_Gas_2_CO = 0;
        public static UInt32 Multi_Gas_2_NO2 = 0;

        public static UInt32 Multi_Gas_3_VOC = 0;
        public static UInt32 Multi_Gas_3_C2H5OH = 0;
        public static UInt32 Multi_Gas_3_CO = 0;
        public static UInt32 Multi_Gas_3_NO2 = 0;

        public static UInt32 Multi_Gas_4_VOC = 0;
        public static UInt32 Multi_Gas_4_C2H5OH = 0;
        public static UInt32 Multi_Gas_4_CO = 0;
        public static UInt32 Multi_Gas_4_NO2 = 0;

        public static Int32 Temperature_OnBoard = 0;
        public static Int32 Humidity_OnBoard = 0;

        public static Int32 Temperature_Convert = 0;
        public static Int32 Humidity_Convert = 0;

        public static string Temperature_Float ;
        public static string Humidity_Float ;

        public static Int32 BME_Voc1;
        public static Int32 BME_Voc2;
        public static Int32 BME_Voc3;
        public static Int32 BME_Voc4;

        public static string BME680_Temp_1 ="";
        public static string BME680_Hum_1 = "";
        public static string BME680_Voc_1 = "";
        public static string BME680_Prs_1 = "";

        public static string BME680_Temp_2 = "";
        public static string BME680_Hum_2 = "";
        public static string BME680_Voc_2 = "";
        public static string BME680_Prs_2 = "";

        public static string BME680_Temp_3 = "";
        public static string BME680_Hum_3 = "";
        public static string BME680_Voc_3 = "";
        public static string BME680_Prs_3 = "";

        public static string BME680_Temp_4 = "";
        public static string BME680_Hum_4 = "";
        public static string BME680_Voc_4 = "";
        public static string BME680_Prs_4 = "";


        //   public static float* Temperature_P;

        //      public static UInt16 Voltage_Adc = 0;
        //       public static UInt16 Current_Adc = 0;

        /*
                public static UInt16 Current_Simulator = 2358;  // 5 Amper
                public static UInt16 Voltage_Simulator = 3440; // 54 Volt
                public static UInt16 AngularSpeed_Simulator = 0;
                public static byte AngularSpeedDirection_Simulator;
                public static bool Simulator_Init;
                public static bool Simulator_Electric;
                public static bool Simulator_Rpm;
        */
        //     public static UInt16 Voltage = 0;
        //    public static Int16 Current = 0;
        //      public static double Power = 0;
        //     public static float Vehicle_Speed = 0;
        public static Int16 Temperature = 0;

        //   public static double PowerConsumption = 0;

        //       public static double  Current_d = 0;
        //        public static double Voltage_d = 0;
        //        public static Int32 Current_32 = 0;
        //       public static Int32 Voltage_32 = 0;

        //    public static UInt16 Voltage_Adc_Offset= 62; //77
        //    public static Int16 Voltage_Offset = 1140; //1147

        //     public static UInt16 Current_Adc_Offset = 21; //77
        //    public static UInt16 Current_Adc_Offset = 60; //77
        //     public static Int16 Current_Offset = 16; //16
        //   public static UInt16 Voltage_Dec = 0;
        //      public static UInt16 Current_Dec = 0;


        /*
                public static UInt16 Enc_Ang_Speed_Raw = 0;
                public static Int32 Enc_Ang_Speed_Abs = 0;
                public static Int32 Vehicle_Ang_Speed_Abs = 0;

        */


        /*
                public static byte  Speed_Animation_Latch = 0;
                public static byte  No_Animation_Latch = 0;
        */
        public static byte Plot_Init;
        /*
         union 
        {
        float f;
        struct {
            //unsigned int mantisa : 23;
           //unsigned int exponent : 8;
            //unsigned int sign : 1;
            }
            parts;
        }
        float_cast;
        */
/*
        public static double Slope = 0;
        public static double Angle = 0;
        public static double Radcalc = 0;
        public static double FrictionCoeff = 0.002;
        

        public static double Motor_Eff = 1;
        public static double Torque;
        public static double Torque_Gradient;
        public static double Torque_Friction;

        public static double Mech_Power = 0;
        public static double Weight1 = 0;
        public static double  Weight2 = 0;
        public static double Weight = 0;

        public static Int32 Accelometer_X = 0;
        public static Int32 Accelometer_Y = 0;
        public static Int32 Accelometer_Z = 0;
        public static float Accelometer_Xf = 0;
        public static float Accelometer_Yf = 0;
        public static float Accelometer_Zf = 0;


        public static float Accelometer_xP = 0;
        public static float Accelometer_yP = 0;
        public static float Accelometer_zP = 0;

        public static Int16[] MotorEff = new Int16[21];
        public static Int16[] MotorRpm = new Int16[21];

*/

        public static byte[] ACC_Buf = new byte[32];
        //    public static float* Acc ;


        public static Int16 sp = -1;  // important start -1
        public static Int16 bp = 0;

    //    public static UInt16 Max_Array_Size = 500;
    //    public static UInt16 SIZE_OF_ARRAY = 900;

        public const UInt16 SAMPLE_10SEC = 100;
        public const UInt16 SAMPLE_20SEC = 200;
        public const UInt16 SAMPLE_1MIN = 600;
        public const UInt16 SAMPLE_2MIN = 1200;
        public const UInt16 SAMPLE_3MIN = 1800;
        public const UInt16 MAX_ARRAY_SIZE = 1800;
        public static UInt16 ChartSize = SAMPLE_1MIN; //default 

        public static string[] Index_Arr = new string[MAX_ARRAY_SIZE];

        public static string[] VOC_Arr1 = new string[MAX_ARRAY_SIZE];
        public static string[] VOC_Arr2 = new string[MAX_ARRAY_SIZE];
        public static string[] VOC_Arr3 = new string[MAX_ARRAY_SIZE];
        public static string[] VOC_Arr4 = new string[MAX_ARRAY_SIZE];

        public static string[] BME_VOC_Arr1 = new string[MAX_ARRAY_SIZE];
        public static string[] BME_VOC_Arr2 = new string[MAX_ARRAY_SIZE];
        public static string[] BME_VOC_Arr3 = new string[MAX_ARRAY_SIZE];
        public static string[] BME_VOC_Arr4 = new string[MAX_ARRAY_SIZE];


        public static string[] Arr5 = new string[MAX_ARRAY_SIZE];
        public static string[] Arr6 = new string[MAX_ARRAY_SIZE];

        public static string[] VOC_Arr1_Median = new string[MAX_ARRAY_SIZE];
        public static string[] VOC_Arr2_Median = new string[MAX_ARRAY_SIZE];
        public static string[] VOC_Arr3_Median = new string[MAX_ARRAY_SIZE];
        public static string[] VOC_Arr4_Median = new string[MAX_ARRAY_SIZE];


        public static UInt32 Median_Total_VOC1 = 0;
        public static UInt32 Median_Total_VOC2 = 0;
        public static UInt32 Median_Total_VOC3 = 0;
        public static UInt32 Median_Total_VOC4 = 0;
        public static UInt32 Median_Counter = 100;


        public static string[] Power_Arr = new string[MAX_ARRAY_SIZE];

        public static UInt16 InitTimer = 0;
        public static bool EnableInitTimer = true;
        public static bool Enable_Menu_Time_Update = false;


        public static bool Log_Status = false;
        public static bool Log_Error = false;

        public static UInt32 Log_Counter = 0;
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

