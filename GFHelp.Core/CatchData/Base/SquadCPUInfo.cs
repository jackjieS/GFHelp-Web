using GFHelp.Core.CatchData.Base.CMD;
using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base
{
    public class SquadCPUInfo : StcSquad_cpu, tBaseData
    {
        // Token: 0x0600241F RID: 9247 RVA: 0x000EDBCC File Offset: 0x000EBDCC
        public SquadCPUInfo()
        {

        }

        // Token: 0x17000779 RID: 1913
        // (get) Token: 0x06002420 RID: 9248 RVA: 0x000EDBFC File Offset: 0x000EBDFC
        public SquadCPUColor colorInfo
        {
            get
            {
                return GameData.listSquadCPUColor.GetDataById((long)this.color);
            }
        }

        // Token: 0x06002421 RID: 9249 RVA: 0x000EDC38 File Offset: 0x000EBE38
        public long GetID()
        {

            return (long)this.id;
        }

        // Token: 0x06002422 RID: 9250 RVA: 0x000EDC6C File Offset: 0x000EBE6C
        public override void InitData()
        {

            this.arrCPUId = new int[5];
            this.arrCPUId[0] = this.grid1;
            this.arrCPUId[1] = this.grid2;
            this.arrCPUId[2] = this.grid3;
            this.arrCPUId[3] = this.grid4;
            this.arrCPUId[4] = this.grid5;
        }

        // Token: 0x06002423 RID: 9251 RVA: 0x000EDCE8 File Offset: 0x000EBEE8
        public SquadCPUGrid GetGridWithRank(int rank)
        {

            rank = Mathf.Clamp(rank, 1, 5);
            return GameData.listSquadCPUGrid.GetDataById((long)this.arrCPUId[rank - 1]);
        }

        // Token: 0x06002424 RID: 9252 RVA: 0x000EDD34 File Offset: 0x000EBF34
        public List<SquadCPUCompletion> GetCompletionList()
        {
            List<SquadCPUCompletion> list = GameData.listSquadCPUCompletion.FindAll((SquadCPUCompletion cc) => cc.group_id == this.cpu_bonus);
            list.Sort((SquadCPUCompletion l, SquadCPUCompletion r) => l.lv - r.lv);
            return list;
        }

        // Token: 0x0400445F RID: 17503
        public int[] arrCPUId;
    }
}
