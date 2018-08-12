using GFHelp.Core.CatchData.Base.CMD;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace GFHelp.Core.CatchData.Base
{
    public class SquadCPUGrid : StcSquad_grid, tBaseData
    {
        // Token: 0x0600242F RID: 9263 RVA: 0x000EE01C File Offset: 0x000EC21C
        public SquadCPUGrid()
        {
        }

        // Token: 0x06002430 RID: 9264 RVA: 0x000EE04C File Offset: 0x000EC24C
        public long GetID()
        {

            return (long)this.id;
        }

        // Token: 0x06002431 RID: 9265 RVA: 0x000EE080 File Offset: 0x000EC280
        public override void InitData()
        {
            this.shape = new ChipShape(this.grid, false);
        }

        // Token: 0x04004471 RID: 17521
        public ChipShape shape;
    }
    [Serializable]
    public struct ChipShape
    {
        // Token: 0x06002443 RID: 9283 RVA: 0x000EE574 File Offset: 0x000EC774
        public ChipShape(string data, bool translateToZero = false)
        {
            string[] array = data.Split(new char[]
            {
            '|'
            });
            this.grids = new BoardVector[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                this.grids[i] = new BoardVector(array[i]);
            }
            if (translateToZero)
            {
                this.TranslateToZero();

            }
        }

        // Token: 0x06002444 RID: 9284 RVA: 0x000EE600 File Offset: 0x000EC800
        public ChipShape(BoardVector[] grids, bool translateToZero = false)
        {
            this.grids = grids;
            if (translateToZero)
            {
                this.TranslateToZero();

            }
        }

        // Token: 0x06002445 RID: 9285 RVA: 0x000EE644 File Offset: 0x000EC844
        public void TranslateToZero()
        {

            BoardVector rhs = this.grids[0];
            for (int i = 0; i < this.grids.Length; i++)
            {
                this.grids[i] = this.grids[i] - rhs;
            }
        }

        // Token: 0x06002446 RID: 9286 RVA: 0x000EE6C8 File Offset: 0x000EC8C8
        public bool Contains(int x, int y)
        {

            for (int i = 0; i < this.grids.Length; i++)
            {
                if (this.grids[i].x == x && this.grids[i].y == y)
                {
                    return true;
                }
            }
            return false;
        }

        // Token: 0x06002447 RID: 9287 RVA: 0x000EE744 File Offset: 0x000EC944
        public bool Contains(BoardVector pos)
        {

            for (int i = 0; i < this.grids.Length; i++)
            {
                if (this.grids[i] == pos)
                {
                    return true;
                }
            }
            return false;
        }

        // Token: 0x06002448 RID: 9288 RVA: 0x000EE7AC File Offset: 0x000EC9AC
        public int[] GetAABB()
        {

            if (this.grids == null || this.grids.Length == 0)
            {
                return new int[4];
            }
            int[] array = new int[]
            {
            999,
            999,
            -999,
            -999
            };
            for (int i = 0; i < this.grids.Length; i++)
            {
                if (this.grids[i].x < array[0])
                {
                    array[0] = this.grids[i].x;
                }
                if (this.grids[i].x > array[2])
                {
                    array[2] = this.grids[i].x;
                }
                if (this.grids[i].y < array[1])
                {
                    array[1] = this.grids[i].y;
                }
                if (this.grids[i].y > array[3])
                {
                    array[3] = this.grids[i].y;
                }
            }
            return array;
        }

        // Token: 0x06002449 RID: 9289 RVA: 0x000EE8DC File Offset: 0x000ECADC
        public ChipShape Rotate(bool clockwise)
        {

            BoardVector[] array = new BoardVector[this.grids.Length];
            this.grids.CopyTo(array, 0);
            for (int i = 0; i < array.Length; i++)
            {
                int x = array[i].x;
                array[i].x = array[i].y;
                array[i].y = x;
                if (clockwise)
                {
                    array[i].y = -array[i].y;
                }
                else
                {
                    array[i].x = -array[i].x;
                }
            }
            return new ChipShape(array, false);
        }

        // Token: 0x0600244A RID: 9290 RVA: 0x000EE9B4 File Offset: 0x000ECBB4
        public ChipShape RotateTwice()
        {

            BoardVector[] array = new BoardVector[this.grids.Length];
            this.grids.CopyTo(array, 0);
            for (int i = 0; i < array.Length; i++)
            {
                array[i].x = -this.grids[i].x;
                array[i].y = -this.grids[i].y;
            }
            return new ChipShape(array, false);
        }

        // Token: 0x0600244B RID: 9291 RVA: 0x000EEA58 File Offset: 0x000ECC58
        public ChipShape Mirror(bool horizontal)
        {

            BoardVector[] array = new BoardVector[this.grids.Length];
            this.grids.CopyTo(array, 0);
            for (int i = 0; i < array.Length; i++)
            {
                if (horizontal)
                {
                    array[i].x = -array[i].x;
                }
                else
                {
                    array[i].y = -array[i].y;
                }
            }
            return new ChipShape(array, false);
        }

        // Token: 0x0600244C RID: 9292 RVA: 0x000EEAFC File Offset: 0x000ECCFC
        public ChipShape Translate(int x, int y)
        {

            BoardVector[] array = new BoardVector[this.grids.Length];
            this.grids.CopyTo(array, 0);
            for (int i = 0; i < array.Length; i++)
            {
                BoardVector[] array2 = array;
                int num = i;
                array2[num].x = array2[num].x + x;
                BoardVector[] array3 = array;
                int num2 = i;
                array3[num2].y = array3[num2].y + y;
            }
            return new ChipShape(array, false);
        }

        // Token: 0x0600244D RID: 9293 RVA: 0x000EEB8C File Offset: 0x000ECD8C
        public ChipShape Translate(BoardVector dir)
        {

            return this.Translate(dir.x, dir.y);
        }

        // Token: 0x0600244E RID: 9294 RVA: 0x000EEBD0 File Offset: 0x000ECDD0
        public ChipShape TranslateTo(int x, int y)
        {
            return this.Translate(x - this.grids[0].x, y - this.grids[0].y);
        }

        // Token: 0x0600244F RID: 9295 RVA: 0x000EEC30 File Offset: 0x000ECE30
        public ChipShape TranslateTo(BoardVector target)
        {
            return this.Translate(target - this.grids[0]);
        }

        // Token: 0x06002450 RID: 9296 RVA: 0x000EEC80 File Offset: 0x000ECE80
        public bool SameShapeWith(ChipShape target)
        {

            if (this.grids.Length == target.grids.Length)
            {
                int num = 99;
                int num2 = 99;
                int num3 = 99;
                int num4 = 99;
                for (int i = 0; i < this.grids.Length; i++)
                {
                    num = Mathf.Min(new int[]
                    {
                    num,
                    this.grids[i].x
                    });
                    num2 = Mathf.Min(new int[]
                    {
                    num2,
                    this.grids[i].y
                    });
                    num3 = Mathf.Min(new int[]
                    {
                    num3,
                    target.grids[i].x
                    });
                    num4 = Mathf.Min(new int[]
                    {
                    num4,
                    target.grids[i].y
                    });
                }
                for (int j = 0; j < this.grids.Length; j++)
                {
                    if (!target.Contains(this.grids[j] + new BoardVector(num3 - num, num4 - num2)))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        // Token: 0x06002451 RID: 9297 RVA: 0x000EEDD8 File Offset: 0x000ECFD8
        public ChipShape AppendRotation(ChipRotation rot)
        {

            ChipShape result = this;
            int num = rot.clockwise;
            if (num >= 2)
            {
                result = result.RotateTwice();
                num -= 2;
            }
            if (num > 0)
            {
                result = result.Rotate(true);
                num--;
            }
            if (rot.flip)
            {
                result = result.Mirror(true);
            }
            return result;
        }

        // Token: 0x06002452 RID: 9298 RVA: 0x000EEE54 File Offset: 0x000ED054
        public ChipShape AppendRotationWithCenter(ChipRotation rot, BoardVector center)
        {

            return this.Translate(-center).AppendRotation(rot).Translate(center);
        }

        // Token: 0x06002453 RID: 9299 RVA: 0x000EEEA4 File Offset: 0x000ED0A4
        public override string ToString()
        {

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < this.grids.Length; i++)
            {
                stringBuilder.Append(this.grids[i].ToString());
                if (i < this.grids.Length - 1)
                {
                    stringBuilder.Append('|');
                }
            }
            return stringBuilder.ToString();
        }

        // Token: 0x04004487 RID: 17543
        public BoardVector[] grids;
    }
    [Serializable]
    public struct BoardVector
    {
        // Token: 0x06002D6A RID: 11626 RVA: 0x00140CA4 File Offset: 0x0013EEA4
        public BoardVector(int x, int y)
        {
            this.x = x;
            this.y = y;

        }

        // Token: 0x06002D6B RID: 11627 RVA: 0x00140CE4 File Offset: 0x0013EEE4
        public BoardVector(string data)
        {
            this.x = 0;
            this.y = 0;
            string[] array = data.Split(new char[]
            {
            ','
            });
            if (array.Length >= 2)
            {
                int.TryParse(array[0], out this.x);
                int.TryParse(array[1], out this.y);
            }
        }

        // Token: 0x06002D6C RID: 11628 RVA: 0x00140D5C File Offset: 0x0013EF5C
        public int GridDistance(BoardVector target)
        {

            return Math.Abs(target.x - this.x) + Math.Abs(target.y - this.y);
        }

        // Token: 0x06002D6D RID: 11629 RVA: 0x00140DB4 File Offset: 0x0013EFB4
        public override bool Equals(object obj)
        {

            return this == (BoardVector)obj;
        }

        // Token: 0x06002D6E RID: 11630 RVA: 0x00140DF8 File Offset: 0x0013EFF8
        public override int GetHashCode()
        {

            return base.GetHashCode();
        }

        // Token: 0x06002D6F RID: 11631 RVA: 0x00140E38 File Offset: 0x0013F038
        public override string ToString()
        {

            return string.Format("{0},{1}", this.x, this.y);
        }

        // Token: 0x06002D70 RID: 11632 RVA: 0x00140E88 File Offset: 0x0013F088
        public Vector2 ToVector2()
        {

            return new Vector2((float)this.x, (float)this.y);
        }

        // Token: 0x06002D71 RID: 11633 RVA: 0x00140ECC File Offset: 0x0013F0CC
        public static BoardVector operator +(BoardVector lhs, BoardVector rhs)
        {

            return new BoardVector(lhs.x + rhs.x, lhs.y + rhs.y);
        }

        // Token: 0x06002D72 RID: 11634 RVA: 0x00140F1C File Offset: 0x0013F11C
        public static BoardVector operator -(BoardVector lhs, BoardVector rhs)
        {

            return new BoardVector(lhs.x - rhs.x, lhs.y - rhs.y);
        }

        // Token: 0x06002D73 RID: 11635 RVA: 0x00140F6C File Offset: 0x0013F16C
        public static bool operator ==(BoardVector lhs, BoardVector rhs)
        {

            return lhs.x == rhs.x && lhs.y == rhs.y;
        }

        // Token: 0x06002D74 RID: 11636 RVA: 0x00140FC0 File Offset: 0x0013F1C0
        public static bool operator !=(BoardVector lhs, BoardVector rhs)
        {

            return lhs.x != rhs.x || lhs.y != rhs.y;
        }

        // Token: 0x06002D75 RID: 11637 RVA: 0x00141014 File Offset: 0x0013F214
        public static BoardVector operator -(BoardVector b)
        {
            return new BoardVector(-b.x, -b.y);
        }

        // Token: 0x04005065 RID: 20581
        public int x;

        // Token: 0x04005066 RID: 20582
        public int y;
    }
    [Serializable]
    public struct ChipRotation
    {
        // Token: 0x06002454 RID: 9300 RVA: 0x000EEF2C File Offset: 0x000ED12C
        public ChipRotation(int clockwise, bool flip)
        {
            this.clockwise = clockwise;
            this.flip = flip;
            this.Generate();
        }

        // Token: 0x06002455 RID: 9301 RVA: 0x000EEF70 File Offset: 0x000ED170
        public ChipRotation(string data)
        {
            this.clockwise = 0;
            this.flip = false;
            string[] array = data.Split(new char[]
            {
            ','
            });
            if (array.Length >= 2)
            {
                int.TryParse(array[0], out this.clockwise);
                int num;
                if (int.TryParse(array[1], out num))
                {
                    this.flip = (num != 0);
                }
            }
            this.Generate();
        }

        // Token: 0x1700077E RID: 1918
        // (get) Token: 0x06002457 RID: 9303 RVA: 0x000EF048 File Offset: 0x000ED248
        // (set) Token: 0x06002458 RID: 9304 RVA: 0x000EF080 File Offset: 0x000ED280
        public int Clockwise
        {
            get
            {

                return this.clockwise;
            }
            set
            {

                this.clockwise = value;
                this.Generate();
            }
        }

        // Token: 0x1700077F RID: 1919
        // (get) Token: 0x06002459 RID: 9305 RVA: 0x000EF0C0 File Offset: 0x000ED2C0
        public bool isZero
        {
            get
            {

                this.Generate();
                return this.clockwise == 0 && !this.flip;
            }
        }

        // Token: 0x0600245A RID: 9306 RVA: 0x000EF10C File Offset: 0x000ED30C
        private void Generate()
        {

            if (this.clockwise > 0)
            {
                this.clockwise %= 4;
            }
            else
            {
                while (this.clockwise < 0)
                {
                    this.clockwise += 4;
                }
            }
        }

        // Token: 0x0600245B RID: 9307 RVA: 0x000EF17C File Offset: 0x000ED37C
        public ChipRotation AppendRotation(ChipRotation rot)
        {

            int num = this.clockwise + ((!this.flip) ? rot.clockwise : (-rot.clockwise));
            return new ChipRotation(num, this.flip != rot.flip);
        }

        // Token: 0x0600245C RID: 9308 RVA: 0x000EF1EC File Offset: 0x000ED3EC
        public ChipRotation Rotate(bool isClockwise)
        {

            int num = this.clockwise + ((isClockwise == this.flip) ? 3 : 1);
            return new ChipRotation(num, this.flip);
        }

        // Token: 0x0600245D RID: 9309 RVA: 0x000EF244 File Offset: 0x000ED444
        public override string ToString()
        {

            return string.Format("{0},{1}", this.clockwise, (!this.flip) ? 0 : 1);
        }

        // Token: 0x0600245E RID: 9310 RVA: 0x000EF2A0 File Offset: 0x000ED4A0
        public override bool Equals(object obj)
        {

            return obj is ChipRotation && this == (ChipRotation)obj;
        }

        // Token: 0x0600245F RID: 9311 RVA: 0x000EF2F0 File Offset: 0x000ED4F0
        public override int GetHashCode()
        {

            return this.clockwise + ((!this.flip) ? 0 : 8);
        }

        // Token: 0x06002460 RID: 9312 RVA: 0x000EF338 File Offset: 0x000ED538
        public static bool operator ==(ChipRotation l, ChipRotation r)
        {

            return l.clockwise == r.clockwise && l.flip == r.flip;
        }

        // Token: 0x06002461 RID: 9313 RVA: 0x000EF38C File Offset: 0x000ED58C
        public static bool operator !=(ChipRotation l, ChipRotation r)
        {

            return l.clockwise != r.clockwise || l.flip != r.flip;
        }

        // Token: 0x06002462 RID: 9314 RVA: 0x000EF3E0 File Offset: 0x000ED5E0
        public static ChipRotation operator -(ChipRotation r)
        {

            return new ChipRotation(-r.clockwise, r.flip);
        }

        // Token: 0x04004499 RID: 17561
        public static ChipRotation zero = new ChipRotation(0, false);

        // Token: 0x0400449A RID: 17562
        public static ChipRotation rotateClockwise = new ChipRotation(1, false);

        // Token: 0x0400449B RID: 17563
        public static ChipRotation rotateTwice = new ChipRotation(2, false);

        // Token: 0x0400449C RID: 17564
        public static ChipRotation flipHorizontal = new ChipRotation(0, false);

        // Token: 0x0400449D RID: 17565
        public static ChipRotation flipVertical = new ChipRotation(2, false);

        // Token: 0x0400449E RID: 17566
        public int clockwise;

        // Token: 0x0400449F RID: 17567
        public bool flip;

    }








    }
