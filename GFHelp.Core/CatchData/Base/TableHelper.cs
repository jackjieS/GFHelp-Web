using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using GFHelp.Core.CatchData.Base.CMD;
using GFHelp.Core.Helper;
using ICSharpCode.SharpZipLib.GZip;

namespace GFHelp.Core.CatchData.Base
{



    // Token: 0x02000635 RID: 1589
    public class TableHelper
    {
        // Token: 0x06003D44 RID: 15684 RVA: 0x00174190 File Offset: 0x00172390
        public static bool LoadTable<T>(ref tBaseDatas<T> tDatas, CmdDef table) where T : NullCmdStruct, tBaseData, new()
        {
            if (tDatas != null)
            {
                tDatas.Clear();
            }
            else
            {
                tDatas = new tBaseDatas<T>();
            }
            return TableHelper.LoadBytesTable<T>(tDatas, table);
        }
        private static bool LoadBytesTable<T>(tBaseDatas<T> tDatas, CmdDef table) where T : NullCmdStruct, tBaseData, new()
        {
            string stcDirectory = SystemManager.ConfigData.currentDirectory + @"\stc";
            string str = "\\";
            int num = (int)table;
            string text = stcDirectory + str + num.ToString() + TableHelper.cachePostfix;
            if (!File.Exists(text))
            {
                //NDebug.LogError("找不到表格:" + text, string.Empty);
                return false;
            }

            try
            {
                using (Stream stream = new FileStream(text, FileMode.Open))
                {
                    using (SimpleEncryptStream simpleEncryptStream = new SimpleEncryptStream(stream))
                    {
                        simpleEncryptStream.SetManualHeader(Encoding.ASCII.GetBytes(TableHelper.encryption));
                        using (Stream stream2 = new GZipInputStream(simpleEncryptStream))
                        {
                            if (TableHelper.dataBuffer == null)
                            {
                                TableHelper.dataBuffer = new byte[4194304];
                            }
                            int num2 = stream.Read(TableHelper.dataBuffer, 0, 4194304);
                            if (num2 <= 0)
                            {
                                Console.WriteLine("读取表格字段失败！");

                                stream2.Close();
                                return false;
                            }
                            stream.Close();
                            if (TableHelper.dataBuffer.Length <= 0)
                            {
                                return false;
                            }
                            ByteBuffer byteBuffer = new ByteBuffer(TableHelper.dataBuffer);
                            ushort num3 = byteBuffer.ReadUShort();
                            ushort num4 = byteBuffer.ReadUShort();
                            ushort num5 = byteBuffer.ReadUShort();
                            byte b = byteBuffer.ReadByte();
                            TableHelper.listDataType.Clear();
                            for (int i = 0; i < (int)b; i++)
                            {
                                TableHelper.listDataType.Add((TableHelper.eDataType)byteBuffer.ReadByte());
                            }
                            byteBuffer.initRead();
                            for (int j = 0; j < (int)num5; j++)
                            {
                                TableHelper.readIndex = 0;
                                T data = Activator.CreateInstance<T>();
                                data.UnPack(byteBuffer);
                                for (int k = (int)TableHelper.readIndex; k < TableHelper.listDataType.Count; k++)
                                {
                                    switch (TableHelper.listDataType[k])
                                    {
                                        case TableHelper.eDataType.@sbyte:
                                            byteBuffer.ReadSbyte();
                                            break;
                                        case TableHelper.eDataType.@byte:
                                            byteBuffer.ReadByte();
                                            break;
                                        case TableHelper.eDataType.@short:
                                            byteBuffer.ReadShort();
                                            break;
                                        case TableHelper.eDataType.@ushort:
                                            byteBuffer.ReadUShort();
                                            break;
                                        case TableHelper.eDataType.@int:
                                            byteBuffer.ReadInt();
                                            break;
                                        case TableHelper.eDataType.@uint:
                                            byteBuffer.ReadUInt();
                                            break;
                                        case TableHelper.eDataType.@long:
                                            byteBuffer.ReadLong();
                                            break;
                                        case TableHelper.eDataType.@ulong:
                                            byteBuffer.ReadULong();
                                            break;
                                        case TableHelper.eDataType.@float:
                                            byteBuffer.ReadFloat();
                                            break;
                                        case TableHelper.eDataType.@double:
                                            byteBuffer.ReadDouble();
                                            break;
                                        case TableHelper.eDataType.@string:
                                            byteBuffer.ReadString();
                                            break;
                                    }
                                }
                                tDatas.Add(data);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return true;
        }

        // Token: 0x06003ED1 RID: 16081 RVA: 0x001ECE9C File Offset: 0x001EB09C
        public static void ClearBuffer()
        {
            TableHelper.dataBuffer = null;
        }

        // Token: 0x040074D1 RID: 29905
        private static string cachePostfix = ".stc";

        // Token: 0x040074D2 RID: 29906
        private static string encryption = "c88d016d261eb80ce4d6e41a510d4048";

        // Token: 0x040074D3 RID: 29907
        private static byte[] dataBuffer;

        // Token: 0x040074D4 RID: 29908
        private const int BUFFER_SIZE = 4194304;

        // Token: 0x040074D5 RID: 29909
        internal static List<TableHelper.eDataType> listDataType = new List<TableHelper.eDataType>();

        // Token: 0x040074D6 RID: 29910
        internal static byte readIndex = 0;


        // Token: 0x02000796 RID: 1942
        internal enum eDataType
        {
            // Token: 0x040074DC RID: 29916
            @sbyte = 1,
            // Token: 0x040074DD RID: 29917
            @byte,
            // Token: 0x040074DE RID: 29918
            @short,
            // Token: 0x040074DF RID: 29919
            @ushort,
            // Token: 0x040074E0 RID: 29920
            @int,
            // Token: 0x040074E1 RID: 29921
            @uint,
            // Token: 0x040074E2 RID: 29922
            @long,
            // Token: 0x040074E3 RID: 29923
            @ulong,
            // Token: 0x040074E4 RID: 29924
            @float,
            // Token: 0x040074E5 RID: 29925
            @double,
            // Token: 0x040074E6 RID: 29926
            @string
        }







































    }

}