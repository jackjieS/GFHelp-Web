using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base.CMD
{
    public class StcBattle_skill_config : NullCmdStruct
    {
        // Token: 0x06004154 RID: 16724 RVA: 0x001D665C File Offset: 0x001D485C
        public StcBattle_skill_config()
        {

        }

        // Token: 0x06004155 RID: 16725 RVA: 0x001D668C File Offset: 0x001D488C
        protected override void _Pack(ByteBuffer buffer)
        {
            buffer.WriteInt(this.id);
            buffer.WriteString(this.name);
            buffer.WriteInt(this.skill_group_id);
            buffer.WriteInt(this.level);
            buffer.WriteInt(this.type);
            buffer.WriteInt(this.skill_priority);
            buffer.WriteInt(this.cd_type);
            buffer.WriteInt(this.cd_time);
            buffer.WriteInt(this.start_cd_time);
            buffer.WriteString(this.trigger_id);
            buffer.WriteInt(this.trigger_type);
            buffer.WriteInt(this.trigger_target);
            buffer.WriteString(this.trigger_parameter);
            buffer.WriteInt(this.trigger_buff_id);
            buffer.WriteInt(this.target_select_ai);
            buffer.WriteSbyte(this.is_re_target);
            buffer.WriteInt(this.action_id);
            buffer.WriteString(this.skill_duration);
            buffer.WriteSbyte(this.is_form_action);
            buffer.WriteString(this.skin_action);
            buffer.WriteString(this.buff_id_target);
            buffer.WriteString(this.buff_id_self);
            buffer.WriteInt(this.buff_delay);
            buffer.WriteString(this.description);
            buffer.WriteString(this.lvup_description);
            buffer.WriteString(this.data_pool_1);
            buffer.WriteString(this.data_pool_2);
            buffer.WriteString(this.night_data_pool_1);
            buffer.WriteString(this.night_data_pool_2);
            buffer.WriteString(this.sp_data_pool_1);
            buffer.WriteString(this.sp_data_pool_2);
            buffer.WriteString(this.sppool_trigger_id);
            buffer.WriteInt(this.sppool_trigger_type);
            buffer.WriteInt(this.sppool_trigger_target);
            buffer.WriteInt(this.sppool_trigger_parameter);
            buffer.WriteInt(this.sppool_trigger_buff_id);
            buffer.WriteString(this.code);
            buffer.WriteInt(this.train_coin_type);
            buffer.WriteInt(this.train_coin_number);
            buffer.WriteInt(this.target_lost);
            buffer.WriteInt(this.daynight_only);
            buffer.WriteInt(this.interrupt_type);
            buffer.WriteInt(this.interrupt_damage_limit);
            buffer.WriteInt(this.creation_number);
            buffer.WriteSbyte(this.is_switch);
            buffer.WriteString(this.passive_name);
            buffer.WriteInt(this.weight);
            buffer.WriteInt(this.consumption);
            buffer.WriteSbyte(this.is_rare);
            buffer.WriteInt(this.skill_up_time);
            buffer.WriteInt(this.rank);
            buffer.WriteSbyte(this.is_mindupdate);
            buffer.WriteSbyte(this.is_manual);
        }

        // Token: 0x06004156 RID: 16726 RVA: 0x001D6934 File Offset: 0x001D4B34
        protected override void _UnPack(ByteBuffer buffer)
        {

            this.id = buffer.ReadInt();
            this.name = buffer.ReadString();
            this.skill_group_id = buffer.ReadInt();
            this.level = buffer.ReadInt();
            this.type = buffer.ReadInt();
            this.skill_priority = buffer.ReadInt();
            this.cd_type = buffer.ReadInt();
            this.cd_time = buffer.ReadInt();
            this.start_cd_time = buffer.ReadInt();
            this.trigger_id = buffer.ReadString();
            this.trigger_type = buffer.ReadInt();
            this.trigger_target = buffer.ReadInt();
            this.trigger_parameter = buffer.ReadString();
            this.trigger_buff_id = buffer.ReadInt();
            this.target_select_ai = buffer.ReadInt();
            this.is_re_target = buffer.ReadSbyte();
            this.action_id = buffer.ReadInt();
            this.skill_duration = buffer.ReadString();
            this.is_form_action = buffer.ReadSbyte();
            this.skin_action = buffer.ReadString();
            this.buff_id_target = buffer.ReadString();
            this.buff_id_self = buffer.ReadString();
            this.buff_delay = buffer.ReadInt();
            this.description = buffer.ReadString();
            this.lvup_description = buffer.ReadString();
            this.data_pool_1 = buffer.ReadString();
            this.data_pool_2 = buffer.ReadString();
            this.night_data_pool_1 = buffer.ReadString();
            this.night_data_pool_2 = buffer.ReadString();
            this.sp_data_pool_1 = buffer.ReadString();
            this.sp_data_pool_2 = buffer.ReadString();
            this.sppool_trigger_id = buffer.ReadString();
            this.sppool_trigger_type = buffer.ReadInt();
            this.sppool_trigger_target = buffer.ReadInt();
            this.sppool_trigger_parameter = buffer.ReadInt();
            this.sppool_trigger_buff_id = buffer.ReadInt();
            this.code = buffer.ReadString();
            this.train_coin_type = buffer.ReadInt();
            this.train_coin_number = buffer.ReadInt();
            this.target_lost = buffer.ReadInt();
            this.daynight_only = buffer.ReadInt();
            this.interrupt_type = buffer.ReadInt();
            this.interrupt_damage_limit = buffer.ReadInt();
            this.creation_number = buffer.ReadInt();
            this.is_switch = buffer.ReadSbyte();
            this.passive_name = buffer.ReadString();
            this.weight = buffer.ReadInt();
            this.consumption = buffer.ReadInt();
            this.is_rare = buffer.ReadSbyte();
            this.skill_up_time = buffer.ReadInt();
            this.rank = buffer.ReadInt();
            this.is_mindupdate = buffer.ReadSbyte();
            this.is_manual = buffer.ReadSbyte();
        }

        // Token: 0x04006D8E RID: 28046
        public int id;

        // Token: 0x04006D8F RID: 28047
        public string name;

        // Token: 0x04006D90 RID: 28048
        public int skill_group_id;

        // Token: 0x04006D91 RID: 28049
        public int level;

        // Token: 0x04006D92 RID: 28050
        public int type;

        // Token: 0x04006D93 RID: 28051
        public int skill_priority;

        // Token: 0x04006D94 RID: 28052
        public int cd_type;

        // Token: 0x04006D95 RID: 28053
        public int cd_time;

        // Token: 0x04006D96 RID: 28054
        public int start_cd_time;

        // Token: 0x04006D97 RID: 28055
        public string trigger_id;

        // Token: 0x04006D98 RID: 28056
        public int trigger_type;

        // Token: 0x04006D99 RID: 28057
        public int trigger_target;

        // Token: 0x04006D9A RID: 28058
        public string trigger_parameter;

        // Token: 0x04006D9B RID: 28059
        public int trigger_buff_id;

        // Token: 0x04006D9C RID: 28060
        public int target_select_ai;

        // Token: 0x04006D9D RID: 28061
        public sbyte is_re_target;

        // Token: 0x04006D9E RID: 28062
        public int action_id;

        // Token: 0x04006D9F RID: 28063
        public string skill_duration;

        // Token: 0x04006DA0 RID: 28064
        public sbyte is_form_action;

        // Token: 0x04006DA1 RID: 28065
        public string skin_action;

        // Token: 0x04006DA2 RID: 28066
        public string buff_id_target;

        // Token: 0x04006DA3 RID: 28067
        public string buff_id_self;

        // Token: 0x04006DA4 RID: 28068
        public int buff_delay;

        // Token: 0x04006DA5 RID: 28069
        public string description;

        // Token: 0x04006DA6 RID: 28070
        public string lvup_description;

        // Token: 0x04006DA7 RID: 28071
        public string data_pool_1;

        // Token: 0x04006DA8 RID: 28072
        public string data_pool_2;

        // Token: 0x04006DA9 RID: 28073
        public string night_data_pool_1;

        // Token: 0x04006DAA RID: 28074
        public string night_data_pool_2;

        // Token: 0x04006DAB RID: 28075
        public string sp_data_pool_1;

        // Token: 0x04006DAC RID: 28076
        public string sp_data_pool_2;

        // Token: 0x04006DAD RID: 28077
        public string sppool_trigger_id;

        // Token: 0x04006DAE RID: 28078
        public int sppool_trigger_type;

        // Token: 0x04006DAF RID: 28079
        public int sppool_trigger_target;

        // Token: 0x04006DB0 RID: 28080
        public int sppool_trigger_parameter;

        // Token: 0x04006DB1 RID: 28081
        public int sppool_trigger_buff_id;

        // Token: 0x04006DB2 RID: 28082
        public string code;

        // Token: 0x04006DB3 RID: 28083
        public int train_coin_type;

        // Token: 0x04006DB4 RID: 28084
        public int train_coin_number;

        // Token: 0x04006DB5 RID: 28085
        public int target_lost;

        // Token: 0x04006DB6 RID: 28086
        public int daynight_only;

        // Token: 0x04006DB7 RID: 28087
        public int interrupt_type;

        // Token: 0x04006DB8 RID: 28088
        public int interrupt_damage_limit;

        // Token: 0x04006DB9 RID: 28089
        public int creation_number;

        // Token: 0x04006DBA RID: 28090
        public sbyte is_switch;

        // Token: 0x04006DBB RID: 28091
        public string passive_name;

        // Token: 0x04006DBC RID: 28092
        public int weight;

        // Token: 0x04006DBD RID: 28093
        public int consumption;

        // Token: 0x04006DBE RID: 28094
        public sbyte is_rare;

        // Token: 0x04006DBF RID: 28095
        public int skill_up_time;

        // Token: 0x04006DC0 RID: 28096
        public int rank;

        // Token: 0x04006DC1 RID: 28097
        public sbyte is_mindupdate;

        // Token: 0x04006DC2 RID: 28098
        public sbyte is_manual;













    }
}
