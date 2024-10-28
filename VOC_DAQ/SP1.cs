using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



//namespace VOI_DAQ
     namespace DAQ_VOC
{
    class SP1
    {

        public static String VID_1 = "04D8";
        public static String PID_1 = "00DD"; // microchip board
        public static String NAM_1 = "Microchip Serial Interface";

        public static String VID_2 = "0403";
        public static String PID_2 = "6015"; // ft232 serial converter metinde
        public static String NAM_2 = "FT232 Serial Converter";

        public static String VID_3 = "10C4";
        public static String PID_3 = "EA60"; // Silicon Labs CP210x USB to UART Bridge
        public static String NAM_3 = "ESP32 Serial Interface";

        public static String VID_4 = "2341";
        public static String PID_4 = "0042"; // Arduino Mega Com Port
        public static String NAM_4 = "Arduino Mega Serial";

        public static String VID_5 = "0403";
        public static String PID_5 = "6001"; // ft232 serial converter
        public static String NAM_5 = "FT232 Serial Converter"; // ft232 serial converter


        /*
         public static String Def_VID = SP1.VID_4;
         public static String Def_PID = SP1.PID_4;
         public static String Def_NAM = SP1.NAM_4;
        */

        public static String Def_VID = SP1.VID_3;
        public static String Def_PID = SP1.PID_3;
        public static String Def_NAM = SP1.NAM_3;
        
        public static String PortConnectName;
        public static uint ComTimeout;  // SP1.ComTimeout
        public static uint ErrorCount;
        //   uint ReadSequence;
        public static uint ReadSequence;
        public static UInt16 Preamble;
  
        /*
        public static uint Data1;
        public static uint Data2;
        public static uint Data3;
        public static uint Data4;
        public static uint Data5;
        */
        public static UInt16 CRC_Received;
        public static UInt16 Preamble_Trial;
        /*
        public static uint RecCommand;
        public static uint RecAdress;
        public static uint RecAdrLength;
        */
        public static Byte[] ReceiveBuf = new byte[256]; // preamble+length+crc + 4*4 byte data  4 byte + 4 byte + 4 byte + 16 byte
        public static byte[] SendBuf = new byte[256]; // preamble+length+crc + 4*4 byte data  4 byte + 4 byte + 4 byte + 16 byte

   

        public static byte[] Buffer = new byte[256];
/*
        public static UInt16 Send_TotLength;
        public static uint SendCommand;
        public static uint SendAdress;
        public static uint Send_AdrLength;
        public static uint SendData1 = 234;
        public static uint SendData2 = 567;
        public static uint SendData3 = 34567;
        public static uint SendData4 = 11134;
        public static uint SendData5 = 11134;
        public static uint SendCRC;
        */
        public static UInt16 CRC_Calc;
        public static UInt16 CRC_Error;
        public static UInt32 CRC_Success;

        //    static byte[] SP1_ReceiveBuf = new byte[256]; // preamble+length+crc + 4*4 byte data  4 byte + 4 byte + 4 byte + 16 byte
        //    static byte[] SP1_SendBuf = new byte[256]; // preamble+length+crc + 4*4 byte data  4 byte + 4 byte + 4 byte + 16 byte

        //     static byte[] SP1_Buffer = new byte[256];
        
        //       UInt16 PREAMBLE_BYTES + DATA_BYTES
        // constant variables
        public static readonly UInt16 PREAMBLE_BYTES = 2; // preamble+length 4 byte + 2 byte
        public static readonly UInt16 DATALENGTH_BYTES = 2;
        public static readonly UInt16 CRC_BYTES = 2;

        public static readonly UInt16 DEFAULT_PREAMBLE = 0XAAAA; // preamble+length 4 byte + 4 byte
        public static readonly UInt16 DEFAULT_CRC_INIT = 0XAAAA; // preamble+length 4 byte + 4 byte

        public static readonly UInt16 DEFAULT_LENGTH = 133; // islemci tarafindaki ayni def ile degerde olmali

        public static readonly UInt16 SHIFT24 = 24;
        public static readonly UInt16 SHIFT16 = 16;
       public static readonly UInt16 SHIFT8 = 8;

        public static UInt16 Length = DEFAULT_LENGTH;

    }



}



