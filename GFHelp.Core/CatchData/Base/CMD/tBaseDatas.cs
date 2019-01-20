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
        // Token: 0x06001543 RID: 5443 RVA: 0x0009C720 File Offset: 0x0009A920
        public tBaseDatas()
        {
        }

        // Token: 0x06001544 RID: 5444 RVA: 0x0009C740 File Offset: 0x0009A940
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

        // Token: 0x06001545 RID: 5445 RVA: 0x0009C7E0 File Offset: 0x0009A9E0
        public bool Contains(T t)
        {
            return this.mDatas.Contains(t);
        }

        // Token: 0x06001546 RID: 5446 RVA: 0x0009C7F0 File Offset: 0x0009A9F0
        public bool ContainsKey(long id)
        {
            return this.mDicDatas.ContainsKey(id);
        }

        // Token: 0x06001547 RID: 5447 RVA: 0x0009C800 File Offset: 0x0009AA00
        public void Clear()
        {
            this.mDatas.Clear();
            this.mDicDatas.Clear();
        }

        // Token: 0x06001548 RID: 5448 RVA: 0x0009C818 File Offset: 0x0009AA18
        public IEnumerator<T> GetEnumerator()
        {
            return this.mDatas.GetEnumerator();
        }

        // Token: 0x06001549 RID: 5449 RVA: 0x0009C82C File Offset: 0x0009AA2C
        public List<T> GetList()
        {
            return this.mDatas;
        }

        // Token: 0x0600154A RID: 5450 RVA: 0x0009C834 File Offset: 0x0009AA34
        public Dictionary<long, T> GetDict()
        {
            return this.mDicDatas;
        }

        // Token: 0x1700055E RID: 1374
        // (get) Token: 0x0600154B RID: 5451 RVA: 0x0009C83C File Offset: 0x0009AA3C
        public int Count
        {
            get
            {
                return this.mDatas.Count;
            }
        }

        // Token: 0x0600154C RID: 5452 RVA: 0x0009C84C File Offset: 0x0009AA4C
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

        // Token: 0x0600154D RID: 5453 RVA: 0x0009C89C File Offset: 0x0009AA9C
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

        // Token: 0x0600154E RID: 5454 RVA: 0x0009C8F0 File Offset: 0x0009AAF0
        public tBaseDatas<T> FindAllEx(Predicate<T> match)
        {
            return new tBaseDatas<T>(this.FindAll(match));
        }

        // Token: 0x0600154F RID: 5455 RVA: 0x0009C900 File Offset: 0x0009AB00
        public T GetDataByIndex(int index)
        {
            return (this.mDatas.Count > index) ? this.mDatas[index] : default(T);
        }

        // Token: 0x06001550 RID: 5456 RVA: 0x0009C938 File Offset: 0x0009AB38
        public int GetIndexByData(T data)
        {
            return this.mDatas.FindIndex((T item) => item.GetID() == data.GetID());
        }

        // Token: 0x06001551 RID: 5457 RVA: 0x0009C96C File Offset: 0x0009AB6C
        public T GetDataById(long id)
        {
            if (this.mDicDatas.ContainsKey(id))
            {
                return this.mDicDatas[id];
            }
            return default(T);
        }

        // Token: 0x06001552 RID: 5458 RVA: 0x0009C9A0 File Offset: 0x0009ABA0
        public void Add(T data)
        {
            if (this.mDicDatas.ContainsKey(data.GetID()))
            {
                Console.WriteLine("数据中存在重复id！");
            }
            else
            {
                this.mDicDatas.Add(data.GetID(), data);
                this.mDatas.Add(data);
            }

        }

        // Token: 0x06001553 RID: 5459 RVA: 0x0009C9FC File Offset: 0x0009ABFC
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

        // Token: 0x06001554 RID: 5460 RVA: 0x0009CA44 File Offset: 0x0009AC44
        public void Remove(T data)
        {
            if (!this.mDicDatas.ContainsKey(data.GetID()))
            {
                return;
            }
            this.mDicDatas.Remove(data.GetID());
            this.mDatas.Remove(data);
        }

        // Token: 0x06001555 RID: 5461 RVA: 0x0009CA98 File Offset: 0x0009AC98
        public void Remove(long id)
        {
            if (!this.mDicDatas.ContainsKey(id))
            {
                return;
            }
            this.mDatas.Remove(this.mDicDatas[id]);
            this.mDicDatas.Remove(id);
        }

        // Token: 0x06001556 RID: 5462 RVA: 0x0009CAD4 File Offset: 0x0009ACD4
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

        // Token: 0x06001557 RID: 5463 RVA: 0x0009CB58 File Offset: 0x0009AD58
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

        // Token: 0x06001558 RID: 5464 RVA: 0x0009CBB8 File Offset: 0x0009ADB8
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

        // Token: 0x06001559 RID: 5465 RVA: 0x0009CC0C File Offset: 0x0009AE0C
        internal void Sort(Comparison<T> t)
        {
            this.mDatas.Sort(t);
        }

        // Token: 0x0400225D RID: 8797
        private List<T> mDatas = new List<T>();

        // Token: 0x0400225E RID: 8798
        private Dictionary<long, T> mDicDatas = new Dictionary<long, T>();

    }
}
