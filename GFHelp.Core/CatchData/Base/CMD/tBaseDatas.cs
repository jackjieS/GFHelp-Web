using System;
using System.Collections.Generic;
using System.Text;

namespace GFHelp.Core.CatchData.Base.CMD
{
    public interface tBaseData
    {
        // Token: 0x06001B82 RID: 7042
        long GetID();
    }
    public class tBaseDatas<T> where T : tBaseData
    {
        // Token: 0x06001B86 RID: 7046 RVA: 0x0008DE54 File Offset: 0x0008C054
        public tBaseDatas()
        {
        }

        // Token: 0x06001B87 RID: 7047 RVA: 0x0008DE74 File Offset: 0x0008C074
        public tBaseDatas(List<T> datas)
        {
            this.mDatas = datas;
            if (this.mDatas != null)
            {
                for (int i = 0; i < this.mDatas.Count; i++)
                {
                    T value = datas[i];
                    if (this.mDicDatas.ContainsKey(value.GetID()))
                    {
                        throw new Exception("数据中存在重复id！");
                    }
                    this.mDicDatas.Add(value.GetID(), value);
                }
            }
        }

        // Token: 0x06001B88 RID: 7048 RVA: 0x0008DF14 File Offset: 0x0008C114
        public bool Contains(T t)
        {
            return this.mDatas.Contains(t);
        }

        // Token: 0x06001B89 RID: 7049 RVA: 0x0008DF24 File Offset: 0x0008C124
        public bool ContainsKey(long id)
        {
            return this.mDicDatas.ContainsKey(id);
        }

        // Token: 0x06001B8A RID: 7050 RVA: 0x0008DF34 File Offset: 0x0008C134
        public void Clear()
        {
            this.mDatas.Clear();
            this.mDicDatas.Clear();
        }

        // Token: 0x06001B8B RID: 7051 RVA: 0x0008DF4C File Offset: 0x0008C14C
        public IEnumerator<T> GetEnumerator()
        {
            return this.mDatas.GetEnumerator();
        }

        // Token: 0x06001B8C RID: 7052 RVA: 0x0008DF60 File Offset: 0x0008C160
        public List<T> GetList()
        {
            return this.mDatas;
        }

        // Token: 0x06001B8D RID: 7053 RVA: 0x0008DF68 File Offset: 0x0008C168
        public Dictionary<long, T> GetDict()
        {
            return this.mDicDatas;
        }

        // Token: 0x17000443 RID: 1091
        // (get) Token: 0x06001B8E RID: 7054 RVA: 0x0008DF70 File Offset: 0x0008C170
        public int Count
        {
            get
            {
                return this.mDatas.Count;
            }
        }

        // Token: 0x06001B8F RID: 7055 RVA: 0x0008DF80 File Offset: 0x0008C180
        public T Find(Predicate<T> match)
        {
            int i = 0;
            int count = this.mDatas.Count;
            while (i < count)
            {
                T t = this.mDatas[i];
                if (match(t))
                {
                    return t;
                }
                i++;
            }
            return default(T);
        }

        // Token: 0x06001B90 RID: 7056 RVA: 0x0008DFD0 File Offset: 0x0008C1D0
        public List<T> FindAll(Predicate<T> match)
        {
            List<T> list = new List<T>();
            int i = 0;
            int count = this.mDatas.Count;
            while (i < count)
            {
                T t = this.mDatas[i];
                if (match(t))
                {
                    list.Add(t);
                }
                i++;
            }
            return list;
        }

        // Token: 0x06001B91 RID: 7057 RVA: 0x0008E024 File Offset: 0x0008C224
        public tBaseDatas<T> FindAllEx(Predicate<T> match)
        {
            return new tBaseDatas<T>(this.FindAll(match));
        }

        // Token: 0x06001B92 RID: 7058 RVA: 0x0008E034 File Offset: 0x0008C234
        public T GetDataByIndex(int index)
        {
            return (this.mDatas.Count > index) ? this.mDatas[index] : default(T);
        }

        // Token: 0x06001B93 RID: 7059 RVA: 0x0008E06C File Offset: 0x0008C26C
        public int GetIndexByData(T data)
        {
            return this.mDatas.FindIndex((T item) => item.GetID() == data.GetID());
        }

        // Token: 0x06001B94 RID: 7060 RVA: 0x0008E0A0 File Offset: 0x0008C2A0
        public T GetDataById(long id)
        {
            if (this.mDicDatas.ContainsKey(id))
            {
                return this.mDicDatas[id];
            }
            return default(T);
        }

        // Token: 0x06001B95 RID: 7061 RVA: 0x0008E0D4 File Offset: 0x0008C2D4
        public void Add(T data)
        {
            if (this.mDicDatas.ContainsKey(data.GetID()))
            {
                throw new Exception("数据中存在重复id！");
            }
            this.mDicDatas.Add(data.GetID(), data);
            this.mDatas.Add(data);
        }

        // Token: 0x06001B96 RID: 7062 RVA: 0x0008E130 File Offset: 0x0008C330
        public bool Exists(Predicate<T> match)
        {
            int i = 0;
            int count = this.mDatas.Count;
            while (i < count)
            {
                if (match(this.mDatas[i]))
                {
                    return true;
                }
                i++;
            }
            return false;
        }

        // Token: 0x06001B97 RID: 7063 RVA: 0x0008E178 File Offset: 0x0008C378
        public void Remove(T data)
        {
            if (!this.mDicDatas.ContainsKey(data.GetID()))
            {
                return;
            }
            this.mDicDatas.Remove(data.GetID());
            this.mDatas.Remove(data);
        }

        // Token: 0x06001B98 RID: 7064 RVA: 0x0008E1CC File Offset: 0x0008C3CC
        public void Remove(long id)
        {
            if (!this.mDicDatas.ContainsKey(id))
            {
                return;
            }
            this.mDatas.Remove(this.mDicDatas[id]);
            this.mDicDatas.Remove(id);
        }

        // Token: 0x06001B99 RID: 7065 RVA: 0x0008E210 File Offset: 0x0008C410
        public void Remove(Predicate<T> match)
        {
            T t = default(T);
            int i = 0;
            int count = this.mDatas.Count;
            while (i < count)
            {
                T t2 = this.mDatas[i];
                if (match(t2))
                {
                    t = t2;
                }
                i++;
            }
            if (t != null)
            {
                this.mDatas.Remove(t);
                this.mDicDatas.Remove(t.GetID());
            }
        }

        // Token: 0x06001B9A RID: 7066 RVA: 0x0008E294 File Offset: 0x0008C494
        public void RemoveAll(Predicate<T> match)
        {
            List<T> list = this.FindAll(match);
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    Dictionary<long, T> dictionary = this.mDicDatas;
                    T t = list[i];
                    dictionary.Remove(t.GetID());
                }
                this.mDatas.RemoveAll(match);
            }
        }

        // Token: 0x06001B9B RID: 7067 RVA: 0x0008E2F4 File Offset: 0x0008C4F4
        public void RemoveAt(int index)
        {
            if (this.mDicDatas.Count <= 0)
            {
                return;
            }
            Dictionary<long, T> dictionary = this.mDicDatas;
            T t = this.mDatas[index];
            dictionary.Remove(t.GetID());
            this.mDatas.RemoveAt(index);
        }

        // Token: 0x06001B9C RID: 7068 RVA: 0x0008E348 File Offset: 0x0008C548
        internal void Sort(Comparison<T> t)
        {
            this.mDatas.Sort(t);
        }

        // Token: 0x04001766 RID: 5990
        private List<T> mDatas = new List<T>();

        // Token: 0x04001767 RID: 5991
        private Dictionary<long, T> mDicDatas = new Dictionary<long, T>();
    }

}
