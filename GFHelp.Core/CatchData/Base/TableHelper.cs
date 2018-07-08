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
        public static bool LoadTable<T>(ref tBaseDatas<T> tDatas, CmdDef table, bool excel) where T : NullCmdStruct, tBaseData, new()
        {
            if (tDatas != null)
            {
                tDatas.Clear();
            }
            else
            {
                //tDatas = new tBaseDatas<T>();
            }
            return TableHelper.LoadBytesTable(tDatas, table);
        }

        // Token: 0x06003D45 RID: 15685 RVA: 0x001741C0 File Offset: 0x001723C0
        private static bool LoadBytesTable<T>(tBaseDatas<T> tDatas, CmdDef table) where T : NullCmdStruct, tBaseData, new()
        {
            string stcDirectory = SystemOthers.ConfigData.currentDirectory + @"\stc";
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
                            int num2 = stream2.Read(TableHelper.dataBuffer, 0, 4194304);
                            if (num2 <= 0)
                            {
                                //NDebug.LogError("读取表格字段失败！", string.Empty);
                                stream2.Close();
                                return false;
                            }
                            stream2.Close();
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
                //NDebug.Log("读取" + text + "失败:" + ex.Message, string.Empty);
            }
            return true;
        }

        // Token: 0x06003D46 RID: 15686 RVA: 0x0017450C File Offset: 0x0017270C
        public static void ClearBuffer()
        {
            TableHelper.dataBuffer = null;
        }

        // Token: 0x04003EB8 RID: 16056
        private const int BUFFER_SIZE = 4194304;

        // Token: 0x04003EB9 RID: 16057
        private static string cachePostfix = ".stc";

        // Token: 0x04003EBA RID: 16058
        private static string encryption = "c88d016d261eb80ce4d6e41a510d4048";

        // Token: 0x04003EBB RID: 16059
        private static byte[] dataBuffer;

        // Token: 0x04003EBC RID: 16060
        internal static List<TableHelper.eDataType> listDataType = new List<TableHelper.eDataType>();

        // Token: 0x04003EBD RID: 16061
        internal static byte readIndex = 0;

        // Token: 0x02000636 RID: 1590
        internal enum eDataType
        {
            // Token: 0x04003EBF RID: 16063
            @sbyte = 1,
            // Token: 0x04003EC0 RID: 16064
            @byte,
            // Token: 0x04003EC1 RID: 16065
            @short,
            // Token: 0x04003EC2 RID: 16066
            @ushort,
            // Token: 0x04003EC3 RID: 16067
            @int,
            // Token: 0x04003EC4 RID: 16068
            @uint,
            // Token: 0x04003EC5 RID: 16069
            @long,
            // Token: 0x04003EC6 RID: 16070
            @ulong,
            // Token: 0x04003EC7 RID: 16071
            @float,
            // Token: 0x04003EC8 RID: 16072
            @double,
            // Token: 0x04003EC9 RID: 16073
            @string
        }
    }

}
