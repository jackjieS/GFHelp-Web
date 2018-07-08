using LitJson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ICSharpCode.SharpZipLib.GZip;
using AC;
using GFHelp.Core.Management;
using System.Security.Cryptography;

namespace GFHelp.Core.Helper
{
    class Decrypt
    {
        public static int randomtime(int time)
        {
            Random random = new Random();
            if (time == 0) return 0;
            return random.Next(1, time);
        }

        public static DateTime LocalDateTimeConvertToChina(DateTime dateTime)
        {
            TimeZoneInfo timeZoneSource = TimeZoneInfo.Local;
            TimeZoneInfo timeZoneDestination = TimeZoneInfo.FindSystemTimeZoneById("China Standard Time");
            return TimeZoneInfo.ConvertTime(dateTime, timeZoneSource, timeZoneDestination);
        }
        public static int ConvertDateTime_China_Int(DateTime time)
        {
            try
            {
                TimeZoneInfo timeZoneSource = TimeZoneInfo.Local;
                TimeZoneInfo timeZoneDestination = TimeZoneInfo.FindSystemTimeZoneById("China Standard Time");
                time = TimeZoneInfo.ConvertTime(time, timeZoneSource, timeZoneDestination);


                DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(LocalDateTimeConvertToChina(new DateTime(1970, 1, 1, 0, 0, 0, 0)));

                var t = (time.Ticks - startTime.Ticks) / 10000000;

                    return (int)t;
            }
            catch (Exception e)
            {
                new Log().systemInit("ConvertDateTime_China_Int", e.ToString()).coreError();
                throw;
            }

        }



        public static string DecodeAndMapJson(GameAccount gameAccount,string wwwText)
        {
            JsonData result = new JsonData();
            try
            {
                if (wwwText.StartsWith("#"))
                {
                    using (MemoryStream memoryStream = new MemoryStream(AuthCode.DecodeWithGzip(wwwText.Substring(1), gameAccount.sign)))
                    {
                        using (Stream stream = new GZipInputStream(memoryStream))
                        {
                            using (StreamReader streamReader = new StreamReader(stream, Encoding.Default))
                            {
                                result = JsonMapper.ToObject(streamReader);
                                return result.ToJson();
                            }
                        }
                    }
                }
                string text2 = AuthCode.Decode(wwwText, gameAccount.sign);

                result = JsonMapper.ToObject(text2);
            }
            catch (Exception e)
            {
                new Log().systemInit("DecodeAndMapJson", e.ToString()).coreError();

            }
            return result.ToJson();
        }

        public static void DecodeSign(GameAccount gameAccount,string result)
        {
            JsonData jsonData2 = null;
            gameAccount.realtimeSinceLogin = Convert.ToInt32((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds);

            AuthCode.Init(new AuthCode.IntDelegate(gameAccount.GetCurrentTimeStamp));

            gameAccount.loginTime = ConvertDateTime_China_Int(DateTime.Now);
            try
            {
                using (MemoryStream stream = new MemoryStream(AuthCode.DecodeWithGzip(result.Substring(1), "yundoudou")))
                {
                    using (Stream stream2 = new GZipInputStream(stream))
                    {
                        using (StreamReader streamReader = new StreamReader(stream2, Encoding.Default))
                        {
                            jsonData2 = JsonMapper.ToObject(streamReader);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                //向網頁傳輸數據一個錯誤窗口之類的
                throw;
            }
            gameAccount.uid = jsonData2["uid"].String;
            gameAccount.sign = jsonData2["sign"].String;
        }



    }


    /// <summary>
    /// A class for encrypting and decrypting a string into base64 format which makes it safe for transfer
    /// between applications.
    ///
    /// Reference:
    /// Based upon the javascript implementation of xxtea by: Chris Veness
    /// www.movable-type.co.uk/tea-block.html
    ///
    /// Using the corrected block tea algorithm developed by: David Wheeler & Roger Needham
    ///
    /// But written for c# by me :D
    /// </summary>
    public class XXTea
    {

        /// <summary>
        /// Encryption using corrected Block TEA (xxtea) algorithm
        /// </summary>
        /// <param name="text">String to be encrypted (multi-byte safe)</param>
        /// <param name="password">Password to be used for encryption (1st 16 chars)</param>
        /// <returns></returns>
        /// 

        private static byte[] password = { 49, 50, 51, 52, 53, 54, 55, 56, 57, 48, 0, 0, 0, 0, 0, 0 };
        public static byte[] Encrypt(String text)
        {

            //if (text.Length == 0)
            //    return "";  // nothing to encrypt

            // Check the user has passed a large enough salt to encrypt the data
            if (password.Length < 8)
            {
                throw new ArgumentException("The salt for encryption is too short");
            }

            // The salt needs to be at least 16 chars in size so if less than 16 double it until it reaches that size
            //while (password.Length < 16) { password += password; }

            // Convert the text into UTF-8 encoding (byte size)
            var v = ToLongs((new UTF8Encoding()).GetBytes(text));

            // algorithm doesn't work for n<2 so fudge by adding an ascii null
            if (v.Length == 1) { v[0] = 0; }

            // Simply convert first 16 chars of password as key
            var k = ToLongs(password);

            // Use UInt32 as the original is based on 'unsigned long' in C, which is equiv to UInt32 in .Net (and not ulong)
            UInt32 n = (UInt32)v.Length,
                   z = v[n - 1],
                   y = v[0],
                   delta = 0x9e3779b9,
                   e,
                   q = (UInt32)(6 + (52 / n)),
                   sum = 0,
                   p = 0;

            while (q-- > 0)
            {
                sum += delta;
                e = sum >> 2 & 3;

                for (p = 0; p < (n - 1); p++)
                {
                    y = v[(p + 1)];
                    z = v[p] += (z >> 5 ^ y << 2) + (y >> 3 ^ z << 4) ^ (sum ^ y) + (k[p & 3 ^ e] ^ z);
                }

                y = v[0];
                z = v[n - 1] += (z >> 5 ^ y << 2) + (y >> 3 ^ z << 4) ^ (sum ^ y) + (k[p & 3 ^ e] ^ z);
            }

            // do not Convert to Base64 so that Control characters doesnt break it
            return ToBytes(v);
        }

        /// <summary>
        /// Decryption using Corrected Block TEA (xxtea) algorithm
        /// </summary>
        /// <param name="ciphertext">String to be decrypted</param>
        /// <param name="password">Password to be used for decryption (1st 16 chars)</param>
        /// <returns></returns>
        public static String Decrypt(String ciphertext)
        {

            if (ciphertext.Length == 0) { return ""; }

            var v = ToLongs(Convert.FromBase64String(ciphertext));
            var k = ToLongs(password);

            UInt32 n = (UInt32)v.Length,
                   z = v[n - 1],
                   y = v[0],
                   delta = 0x9e3779b9,
                   e,
                   q = (UInt32)(6 + (52 / n)),
                   sum = q * delta,
                   p = 0;

            while (sum != 0)
            {
                e = sum >> 2 & 3;

                for (p = (n - 1); p > 0; p--)
                {
                    z = v[p - 1];
                    y = v[p] -= (z >> 5 ^ y << 2) + (y >> 3 ^ z << 4) ^ (sum ^ y) + (k[p & 3 ^ e] ^ z);
                }

                z = v[n - 1];
                y = v[0] -= (z >> 5 ^ y << 2) + (y >> 3 ^ z << 4) ^ (sum ^ y) + (k[p & 3 ^ e] ^ z);

                sum -= delta;
            }

            var plaintext = (new UTF8Encoding()).GetString(ToBytes(v));

            return plaintext;
        }

        /// <summary>
        /// convert utf-8 byte to array of longs, each containing 4 chars to be manipulated
        /// </summary>
        /// <param name="s"></param>
        private static UInt32[] ToLongs(byte[] s)
        {

            // note chars must be within ISO-8859-1 (with Unicode code-point < 256) to fit 4/long
            var l = new UInt32[(int)Math.Ceiling(((decimal)s.Length / 4))];

            // Create an array of long, each long holding the data of 4 characters, if the last block is less than 4
            // characters in length, fill with ascii null values
            for (int i = 0; i < l.Length; i++)
            {
                // Note: little-endian encoding - endianness is irrelevant as long as it is the same in ToBytes()
                l[i] = ((s[i * 4])) +
                       ((i * 4 + 1) >= s.Length ? (UInt32)0 << 8 : ((UInt32)s[i * 4 + 1] << 8)) +
                       ((i * 4 + 2) >= s.Length ? (UInt32)0 << 16 : ((UInt32)s[i * 4 + 2] << 16)) +
                       ((i * 4 + 3) >= s.Length ? (UInt32)0 << 24 : ((UInt32)s[i * 4 + 3] << 24));
            }

            return l;
        }

        /// <summary>
        /// Convert array of longs back to utf-8 byte array
        /// </summary>
        /// <returns></returns>
        private static byte[] ToBytes(UInt32[] l)
        {
            byte[] b = new byte[l.Length * 4];

            // Split each long value into 4 separate characters (bytes) using the same format as ToLongs()
            for (Int32 i = 0; i < l.Length; i++)
            {
                b[(i * 4)] = (byte)(l[i] & 0xFF);
                b[(i * 4) + 1] = (byte)(l[i] >> (8 & 0xFF));
                b[(i * 4) + 2] = (byte)(l[i] >> (16 & 0xFF));
                b[(i * 4) + 3] = (byte)(l[i] >> (24 & 0xFF));
            }
            return b;
        }

    }

    public class md5
    {
        public static string EncryptWithMD5(string source)
        {
            byte[] sor = Encoding.UTF8.GetBytes(source);
            MD5 md5 = MD5.Create();
            byte[] result = md5.ComputeHash(sor);
            StringBuilder strbul = new StringBuilder(40);
            for (int i = 0; i < result.Length; i++)
            {
                strbul.Append(result[i].ToString("x2"));//加密结果"x2"结果为32位,"x3"结果为48位,"x4"结果为64位

            }
            return strbul.ToString();
        }
    }

    // Token: 0x02000410 RID: 1040
    public class SimpleEncryptStream : Stream
    {
        // Token: 0x060020DD RID: 8413 RVA: 0x000BA074 File Offset: 0x000B8274
        public SimpleEncryptStream(Stream stream)
        {
            this.refenceStream = stream;
        }

        // Token: 0x060020DE RID: 8414 RVA: 0x000BA084 File Offset: 0x000B8284
        public void WriteHeader(string header)
        {
            if (header.Length < 16)
            {
                header = header.PadRight(16, '=');
            }
            else if (header.Length > 16)
            {
                header = header.Substring(0, 16);
            }
            byte[] bytes = Encoding.UTF8.GetBytes(header);
            MD5 md = new MD5CryptoServiceProvider();
            this.header = md.ComputeHash(bytes);
            this.headerLength = (this.encryptionLength = 16);
            this.refenceStream.Write(this.header, 0, 16);
        }

        // Token: 0x060020DF RID: 8415 RVA: 0x000BA10C File Offset: 0x000B830C
        public void ReadHeader()
        {
            this.header = new byte[16];
            this.refenceStream.Seek(0L, SeekOrigin.Begin);
            this.refenceStream.Read(this.header, 0, 16);
            this.headerLength = (this.encryptionLength = 16);
        }

        // Token: 0x060020E0 RID: 8416 RVA: 0x000BA15C File Offset: 0x000B835C
        public void SetManualHeader(byte[] header)
        {
            this.header = header;
            this.headerLength = 0;
            this.encryptionLength = header.Length;
        }

        // Token: 0x170005B2 RID: 1458
        // (get) Token: 0x060020E1 RID: 8417 RVA: 0x000BA178 File Offset: 0x000B8378
        public override bool CanRead
        {
            get
            {
                return this.refenceStream.CanRead;
            }
        }

        // Token: 0x170005B3 RID: 1459
        // (get) Token: 0x060020E2 RID: 8418 RVA: 0x000BA188 File Offset: 0x000B8388
        public override bool CanSeek
        {
            get
            {
                return this.refenceStream.CanSeek;
            }
        }

        // Token: 0x170005B4 RID: 1460
        // (get) Token: 0x060020E3 RID: 8419 RVA: 0x000BA198 File Offset: 0x000B8398
        public override bool CanWrite
        {
            get
            {
                return this.refenceStream.CanWrite;
            }
        }

        // Token: 0x170005B5 RID: 1461
        // (get) Token: 0x060020E4 RID: 8420 RVA: 0x000BA1A8 File Offset: 0x000B83A8
        public override long Length
        {
            get
            {
                return this.refenceStream.Length;
            }
        }

        // Token: 0x170005B6 RID: 1462
        // (get) Token: 0x060020E5 RID: 8421 RVA: 0x000BA1B8 File Offset: 0x000B83B8
        // (set) Token: 0x060020E6 RID: 8422 RVA: 0x000BA1C8 File Offset: 0x000B83C8
        public override long Position
        {
            get
            {
                return this.refenceStream.Position;
            }
            set
            {
                this.refenceStream.Position = value;
            }
        }

        // Token: 0x060020E7 RID: 8423 RVA: 0x000BA1D8 File Offset: 0x000B83D8
        public override void Flush()
        {
            this.refenceStream.Flush();
        }

        // Token: 0x060020E8 RID: 8424 RVA: 0x000BA1E8 File Offset: 0x000B83E8
        public override int Read(byte[] buffer, int offset, int count)
        {
            long position = this.Position;
            int num = this.refenceStream.Read(buffer, offset, count);
            int i = 0;
            int num2 = 0;
            while (i < num)
            {
                if (num2 == this.encryptionLength)
                {
                    num2 = 0;
                }
                int num3 = (int)buffer[i + offset];
                int num4 = (int)this.header[num2];
                buffer[i + offset] = (byte)(num3 ^ num4);
                num2++;
                i++;
            }
            return num;
        }

        // Token: 0x060020E9 RID: 8425 RVA: 0x000BA250 File Offset: 0x000B8450
        public override long Seek(long offset, SeekOrigin origin)
        {
            return this.refenceStream.Seek(offset + (long)this.headerLength, origin);
        }

        // Token: 0x060020EA RID: 8426 RVA: 0x000BA268 File Offset: 0x000B8468
        public override void SetLength(long value)
        {
            this.refenceStream.SetLength(value);
        }

        // Token: 0x060020EB RID: 8427 RVA: 0x000BA278 File Offset: 0x000B8478
        public override void Write(byte[] buffer, int offset, int count)
        {
            int i = 0;
            int num = 0;
            while (i < count)
            {
                if (num == this.encryptionLength)
                {
                    num = 0;
                }

                var temp = buffer[i + offset] ^ this.header[num];
                buffer[i + offset] = (byte)temp;
                num++;
                i++;
            }
            this.refenceStream.Write(buffer, offset, count);
        }

        // Token: 0x060020EC RID: 8428 RVA: 0x000BA2D0 File Offset: 0x000B84D0
        public override void Close()
        {
            this.refenceStream.Close();
        }

        // Token: 0x04002B67 RID: 11111
        private const int HEADER_LENGTH = 16;

        // Token: 0x04002B68 RID: 11112
        public Stream refenceStream;

        // Token: 0x04002B69 RID: 11113
        public byte[] header;

        // Token: 0x04002B6A RID: 11114
        private int headerLength;

        // Token: 0x04002B6B RID: 11115
        private int encryptionLength;
    }





}
