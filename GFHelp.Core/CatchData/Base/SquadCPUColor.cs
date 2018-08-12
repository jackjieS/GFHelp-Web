using GFHelp.Core.CatchData.Base.CMD;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace GFHelp.Core.CatchData.Base
{
    public class SquadCPUColor : StcSquad_color, tBaseData
    {// Token: 0x06002427 RID: 9255 RVA: 0x000EDDBC File Offset: 0x000EBFBC
        public SquadCPUColor()
        {

        }

        // Token: 0x1700077A RID: 1914
        // (get) Token: 0x06002428 RID: 9256 RVA: 0x000EDDEC File Offset: 0x000EBFEC
        public string name
        {
            get
            {
                return this.fliter_text;
            }
        }

        // Token: 0x06002429 RID: 9257 RVA: 0x000EDE28 File Offset: 0x000EC028
        public long GetID()
        {
            return (long)this.id;
        }

        // Token: 0x0600242A RID: 9258 RVA: 0x000EDE5C File Offset: 0x000EC05C
        public override void InitData()
        {
            int[] array = new int[3];
            string[] array2 = this.rgb.Split(new char[]
            {
            ','
            });
            if (array2.Length >= 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    int.TryParse(array2[i], out array[i]);
                }
            }
            this.color = new Color32((byte)array[0], (byte)array[1], (byte)array[2], byte.MaxValue);
            this.colorHex = string.Format("{0:X2}{1:X2}{2:X2}{3:X2}", new object[]
            {
            this.color.r,
            this.color.g,
            this.color.b,
            this.color.a
            });
        }

        // Token: 0x04004467 RID: 17511
        public Color32 color;

        // Token: 0x04004468 RID: 17512
        public string colorHex;
    }
}
