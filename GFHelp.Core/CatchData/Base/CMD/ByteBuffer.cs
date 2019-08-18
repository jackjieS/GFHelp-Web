using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GFHelp.Core.CatchData.Base.CMD
{
    // Token: 0x02000621 RID: 1569
    public class ByteBuffer
    {
        // Token: 0x06003CC9 RID: 15561 RVA: 0x00171DF4 File Offset: 0x0016FFF4
        public ByteBuffer()
        {
            this.mTarPackList = new List<byte>();
        }

        // Token: 0x06003CCA RID: 15562 RVA: 0x00171E08 File Offset: 0x00170008
        public ByteBuffer(byte[] data)
        {
            if (data != null)
            {
                this.mTarUnpackArray = data;
            }
            else
            {
                this.mTarPackList = new List<byte>();
            }
        }

        // Token: 0x06003CCB RID: 15563 RVA: 0x00171E30 File Offset: 0x00170030
        public void Close()
        {
            if (this.mTarPackList != null)
            {
                this.mTarPackList.Clear();
                this.mTarPackList = null;
            }
            this.mTarUnpackArray = null;
        }

        // Token: 0x06003CCC RID: 15564 RVA: 0x00171E64 File Offset: 0x00170064
        public byte[] ToBytes()
        {
            if (this.mTarPackList == null)
            {
                return null;
            }
            return this.mTarPackList.ToArray();
        }

        // Token: 0x06003CCD RID: 15565 RVA: 0x00171E80 File Offset: 0x00170080
        public void Flush()
        {
        }

        // Token: 0x06003CCE RID: 15566 RVA: 0x00171E84 File Offset: 0x00170084
        public void WriteLength(int index, ushort length)
        {
            if (index >= this.mTarPackList.Count - 1)
            {
                return;
            }
            this.mTarPackList[index] = (byte)(length & 255);
            this.mTarPackList[index + 1] = (byte)(length >> 8 & 255);
        }

        // Token: 0x17000D12 RID: 3346
        // (get) Token: 0x06003CCF RID: 15567 RVA: 0x00171ED4 File Offset: 0x001700D4
        public ushort DataLength
        {
            get
            {
                return (ushort)this.mTarPackList.Count;
            }
        }

        // Token: 0x06003CD0 RID: 15568 RVA: 0x00171EE4 File Offset: 0x001700E4
        public byte ReadByte()
        {
            byte result = this.mTarUnpackArray[this.mCurUnpackPos];
            this.mCurUnpackPos++;
            TableHelper.readIndex += 1;
            return result;
        }

        // Token: 0x06003CD1 RID: 15569 RVA: 0x00171F1C File Offset: 0x0017011C
        public void WriteByte(byte v)
        {
            this.mTarPackList.Add(v);
        }

        // Token: 0x06003CD2 RID: 15570 RVA: 0x00171F2C File Offset: 0x0017012C
        public sbyte ReadSbyte()
        {
            byte b = this.mTarUnpackArray[this.mCurUnpackPos];
            this.mCurUnpackPos++;
            TableHelper.readIndex += 1;
            return (sbyte)b;
        }

        // Token: 0x06003CD3 RID: 15571 RVA: 0x00171F64 File Offset: 0x00170164
        public void WriteSbyte(sbyte v)
        {
            this.mTarPackList.Add((byte)v);
        }

        // Token: 0x06003CD4 RID: 15572 RVA: 0x00171F74 File Offset: 0x00170174
        public short ReadShort()
        {
            short result = BitConverter.ToInt16(this.mTarUnpackArray, this.mCurUnpackPos);
            this.mCurUnpackPos += 2;
            TableHelper.readIndex += 1;
            return result;
        }

        // Token: 0x06003CD5 RID: 15573 RVA: 0x00171FB0 File Offset: 0x001701B0
        public void WriteShort(short v)
        {
            this.mTarPackList.Add((byte)(v & 255));
            this.mTarPackList.Add((byte)(v >> 8 & 255));
        }

        // Token: 0x06003CD6 RID: 15574 RVA: 0x00171FE8 File Offset: 0x001701E8


        public bool initRead()
        {
            firstID = this.ReadInt();
            try
            {
                while (true)
                {
                    int id = this.ReadInt();
                    if (id == firstID)
                    {
                        this.mCurUnpackPos -= 4;
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }



        }
        public ushort ReadUShort()
        {
            ushort num = 0;
            num += (ushort)this.mTarUnpackArray[this.mCurUnpackPos];
            num += (ushort)(this.mTarUnpackArray[this.mCurUnpackPos + 1] << 8);
            this.mCurUnpackPos += 2;
            TableHelper.readIndex += 1;
            return num;
        }

        // Token: 0x06003CD7 RID: 15575 RVA: 0x0017203C File Offset: 0x0017023C
        public void WriteUShort(ushort v)
        {
            this.mTarPackList.Add((byte)(v & 255));
            this.mTarPackList.Add((byte)(v >> 8 & 255));
        }

        // Token: 0x06003CD8 RID: 15576 RVA: 0x00172074 File Offset: 0x00170274
        public int ReadInt()
        {
            int result = BitConverter.ToInt32(this.mTarUnpackArray, this.mCurUnpackPos);
            this.mCurUnpackPos += 4;
            TableHelper.readIndex += 1;
            return result;
        }

        // Token: 0x06003CD9 RID: 15577 RVA: 0x001720B0 File Offset: 0x001702B0
        public void WriteInt(int v)
        {
            this.mTarPackList.Add((byte)(v & 255));
            this.mTarPackList.Add((byte)(v >> 8 & 255));
            this.mTarPackList.Add((byte)(v >> 16 & 255));
            this.mTarPackList.Add((byte)(v >> 24 & 255));
        }

        // Token: 0x06003CDA RID: 15578 RVA: 0x00172114 File Offset: 0x00170314
        public uint ReadUInt()
        {
            uint num = 0u;
            num += (uint)this.mTarUnpackArray[this.mCurUnpackPos];
            num += (uint)((uint)this.mTarUnpackArray[this.mCurUnpackPos + 1] << 8);
            num += (uint)((uint)this.mTarUnpackArray[this.mCurUnpackPos + 2] << 16);
            num += (uint)((uint)this.mTarUnpackArray[this.mCurUnpackPos + 3] << 24);
            this.mCurUnpackPos += 4;
            TableHelper.readIndex += 1;
            return num;
        }

        // Token: 0x06003CDB RID: 15579 RVA: 0x00172190 File Offset: 0x00170390
        public void WriteUInt(uint v)
        {
            this.mTarPackList.Add((byte)(v & 255u));
            this.mTarPackList.Add((byte)(v >> 8 & 255u));
            this.mTarPackList.Add((byte)(v >> 16 & 255u));
            this.mTarPackList.Add((byte)(v >> 24 & 255u));
        }

        // Token: 0x06003CDC RID: 15580 RVA: 0x001721F4 File Offset: 0x001703F4
        public long ReadLong()
        {
            long result = BitConverter.ToInt64(this.mTarUnpackArray, this.mCurUnpackPos);
            this.mCurUnpackPos += 8;
            TableHelper.readIndex += 1;
            return result;
        }

        // Token: 0x06003CDD RID: 15581 RVA: 0x00172230 File Offset: 0x00170430
        public void WriteLong(long v)
        {
            this.mTarPackList.Add((byte)(v & 255L));
            this.mTarPackList.Add((byte)(v >> 8 & 255L));
            this.mTarPackList.Add((byte)(v >> 16 & 255L));
            this.mTarPackList.Add((byte)(v >> 24 & 255L));
            this.mTarPackList.Add((byte)(v >> 32 & 255L));
            this.mTarPackList.Add((byte)(v >> 40 & 255L));
            this.mTarPackList.Add((byte)(v >> 48 & 255L));
            this.mTarPackList.Add((byte)(v >> 56 & 255L));
        }

        // Token: 0x06003CDE RID: 15582 RVA: 0x001722F4 File Offset: 0x001704F4
        public ulong ReadULong()
        {
            ulong num = 0UL;
            num += (ulong)this.mTarUnpackArray[this.mCurUnpackPos];
            num += (ulong)this.mTarUnpackArray[this.mCurUnpackPos + 1] << 8;
            num += (ulong)this.mTarUnpackArray[this.mCurUnpackPos + 2] << 16;
            num += (ulong)this.mTarUnpackArray[this.mCurUnpackPos + 3] << 24;
            num += (ulong)this.mTarUnpackArray[this.mCurUnpackPos + 4] << 32;
            num += (ulong)this.mTarUnpackArray[this.mCurUnpackPos + 5] << 40;
            num += (ulong)this.mTarUnpackArray[this.mCurUnpackPos + 6] << 48;
            num += (ulong)this.mTarUnpackArray[this.mCurUnpackPos + 7] << 56;
            this.mCurUnpackPos += 8;
            TableHelper.readIndex += 1;
            return num;
        }

        // Token: 0x06003CDF RID: 15583 RVA: 0x001723CC File Offset: 0x001705CC
        public void WriteULong(ulong v)
        {
            this.mTarPackList.Add((byte)(v & 255UL));
            this.mTarPackList.Add((byte)(v >> 8 & 255UL));
            this.mTarPackList.Add((byte)(v >> 16 & 255UL));
            this.mTarPackList.Add((byte)(v >> 24 & 255UL));
            this.mTarPackList.Add((byte)(v >> 32 & 255UL));
            this.mTarPackList.Add((byte)(v >> 40 & 255UL));
            this.mTarPackList.Add((byte)(v >> 48 & 255UL));
            this.mTarPackList.Add((byte)(v >> 56 & 255UL));
        }

        // Token: 0x06003CE0 RID: 15584 RVA: 0x00172490 File Offset: 0x00170690
        public float ReadFloat()
        {
            float result = BitConverter.ToSingle(this.mTarUnpackArray, this.mCurUnpackPos);
            this.mCurUnpackPos += 4;
            TableHelper.readIndex += 1;
            return result;
        }

        // Token: 0x06003CE1 RID: 15585 RVA: 0x001724CC File Offset: 0x001706CC
        public void WriteFloat(float v)
        {
            byte[] bytes = BitConverter.GetBytes(v);
            this.WriteBytes(bytes);
        }

        // Token: 0x06003CE2 RID: 15586 RVA: 0x001724E8 File Offset: 0x001706E8
        public double ReadDouble()
        {
            double result = BitConverter.ToDouble(this.mTarUnpackArray, this.mCurUnpackPos);
            this.mCurUnpackPos += 8;
            TableHelper.readIndex += 1;
            return result;
        }

        // Token: 0x06003CE3 RID: 15587 RVA: 0x00172524 File Offset: 0x00170724
        public void WriteDouble(double v)
        {
            byte[] bytes = BitConverter.GetBytes(v);
            this.WriteBytes(bytes);
        }

        // Token: 0x06003CE4 RID: 15588 RVA: 0x00172540 File Offset: 0x00170740
        public byte[] ReadBytes(int len)
        {
            byte[] array = new byte[len];
            Array.Copy(this.mTarUnpackArray, this.mCurUnpackPos, array, 0, len);
            this.mCurUnpackPos += len;
            TableHelper.readIndex += 1;
            return array;
        }


        // Token: 0x06003CE5 RID: 15589 RVA: 0x00172584 File Offset: 0x00170784
        public void WriteBytes(byte[] v)
        {
            for (int i = 0; i < v.Length; i++)
            {
                this.mTarPackList.Add(v[i]);
            }
        }

        // Token: 0x06003CE6 RID: 15590 RVA: 0x001725B4 File Offset: 0x001707B4
        public string ReadString()
        {
            int num = (int)this.ReadByte();
            num = (int)this.ReadUShort();
            if (num == 0)
            {
                return string.Empty;
            }
            byte[] bytes = this.ReadBytes(num);
            TableHelper.readIndex += 1;
            return Encoding.UTF8.GetString(bytes);
        }

        public string ReadStringNew()
        {
            int num = (int)this.ReadByte();
            num = (int)this.ReadUShort();
            byte[] bytes = this.ReadBytes(num);
            TableHelper.readIndex += 1;
            return Encoding.UTF8.GetString(bytes);
        }


        // Token: 0x06003CE7 RID: 15591 RVA: 0x001725F4 File Offset: 0x001707F4
        public void WriteString(string v)
        {
            ushort num = (ushort)v.Length;
            this.WriteUShort(num);
            if (num == 0)
            {
                return;
            }
            byte[] array = new byte[(int)num];
            if (v == null)
            {
                return;
            }
            Encoding.UTF8.GetBytes(v, 0, v.Length, array, 0);
            this.WriteBytes(array);
        }

        // Token: 0x06003CE8 RID: 15592 RVA: 0x00172644 File Offset: 0x00170844
        //public static ushort BytesToUshort(byte[] src, int startidx = 0)
        //{
        //	ushort num = 0;
        //	num += (ushort)(src[startidx + 1] << 8);
        //	return num + (ushort)src[startidx];
        //}

        // Token: 0x06003CE9 RID: 15593 RVA: 0x00172668 File Offset: 0x00170868
        public static uint BytesToUint(byte[] src, int startidx = 0)
        {
            uint num = (uint)((uint)src[startidx + 3] << 24);
            num += (uint)((uint)src[startidx + 2] << 16);
            num += (uint)((uint)src[startidx + 1] << 8);
            return num + (uint)src[startidx];
        }

        // Token: 0x06003CEA RID: 15594 RVA: 0x0017269C File Offset: 0x0017089C
        public static byte[] UintToBytes(uint value, byte[] src, int startidx = 0)
        {
            src[startidx + 3] = (byte)(value >> 24 & 255u);
            src[startidx + 2] = (byte)(value >> 16 & 255u);
            src[startidx + 1] = (byte)(value >> 8 & 255u);
            src[startidx] = (byte)(value & 255u);
            return src;
        }

        // Token: 0x06003CEB RID: 15595 RVA: 0x001726DC File Offset: 0x001708DC
        public static byte[] UshortToBytes(ushort value, byte[] src, int startidx = 0)
        {
            src[startidx + 1] = (byte)(value >> 8 & 255);
            src[startidx] = (byte)(value & 255);
            return src;
        }

        // Token: 0x06003CEC RID: 15596 RVA: 0x001726FC File Offset: 0x001708FC
        public static string BytesToString(byte[] bytes)
        {
            char[] chars = Encoding.UTF8.GetChars(bytes);
            int i;
            for (i = 0; i < chars.Length; i++)
            {
                if (chars[i] == '\0')
                {
                    break;
                }
            }
            return new string(chars, 0, i);
        }

        // Token: 0x06003CED RID: 15597 RVA: 0x00172740 File Offset: 0x00170940
        public static string BytesToString(byte[] buff, int start, int length)
        {
            byte[] array = new byte[length];
            Array.Copy(buff, start, array, 0, length);
            return ByteBuffer.BytesToString(array);
        }

        // Token: 0x06003CEE RID: 15598 RVA: 0x00172764 File Offset: 0x00170964
        public static byte[] CreateByteArray(int arrLength)
        {
            if (arrLength <= 0)
            {
                return null;
            }
            return new byte[arrLength];
        }

        // Token: 0x06003CEF RID: 15599 RVA: 0x00172778 File Offset: 0x00170978
        public static void ArrayCopy(byte[] srcArr, byte[] tarArr, int arrLen)
        {
            Array.Copy(srcArr, tarArr, arrLen);
        }

        private int firstID;
        // Token: 0x04003DE6 RID: 15846
        private byte[] mTarUnpackArray;

        // Token: 0x04003DE7 RID: 15847
        private int mCurUnpackPos;

        // Token: 0x04003DE8 RID: 15848
        private List<byte> mTarPackList;
    }

}
