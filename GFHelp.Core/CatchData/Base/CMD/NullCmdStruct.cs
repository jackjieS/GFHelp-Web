using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base.CMD
{
    // Token: 0x02000634 RID: 1588
    public class NullCmdStruct
    {
        // Token: 0x06003D3D RID: 15677 RVA: 0x0017412C File Offset: 0x0017232C
        protected virtual void _Pack(ByteBuffer buffer)
        {
        }

        // Token: 0x06003D3E RID: 15678 RVA: 0x00174130 File Offset: 0x00172330
        protected virtual void _UnPack(ByteBuffer buffer)
        {
        }

        // Token: 0x06003D3F RID: 15679 RVA: 0x00174134 File Offset: 0x00172334
        public void Pack(ByteBuffer buffer)
        {
            this._Pack(buffer);
        }

        // Token: 0x06003D40 RID: 15680 RVA: 0x00174140 File Offset: 0x00172340
        public void UnPack(ByteBuffer buffer)
        {
            this._UnPack(buffer);
            this.InitData();
        }

        // Token: 0x06003D41 RID: 15681 RVA: 0x00174150 File Offset: 0x00172350
        public virtual void InitData()
        {
        }

        // Token: 0x04003EB7 RID: 16055
        public ushort length;
    }

}
