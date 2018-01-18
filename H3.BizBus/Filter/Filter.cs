using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;

namespace H3.BizBus
{
    /// <summary>
    /// ��������������SQL��SELECT��䣬����GetList����������������Ķ���
    /// </summary>
    [System.Serializable]
    public class Filter 
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        public Filter()
        {
        }

        #region ���Ĺ�������

        private Filter _ParentFilter = null;
        /// <summary>
        /// ������Ĺ�����������������Ҫ���˳��Ӷ����ʱ���е�ʱ����Ҫ���븸����������������ѯ������ϸ��ʱ�򣬿�����Ҫ����ͷ�ϵ��Ƶ�ʱ����Ϊ��ѯ����
        /// </summary>
        public Filter ParentFilter
        {
            get
            {
                return this._ParentFilter;
            }
            set
            {
                this._ParentFilter = value;
            }
        }

        #endregion

        #region Row Numֵ

        private int _FromRowNum = -1;
        /// <summary>
        /// �ӵ�N����¼��ʼ��������0��������N��
        /// </summary>
        public int FromRowNum
        {
            get
            {
                return this._FromRowNum;
            }
            set
            {
                this._FromRowNum = value;
            }
        }

        /// <summary>
        /// һ���������ķ��ؼ�¼������
        /// </summary>
        public const int DefaultMaxSize = 1000;

        private int _ToRowNum = DefaultMaxSize;
        /// <summary>
        /// ����M����������0����������M��
        /// </summary>
        public int ToRowNum
        {
            get
            {
                return this._ToRowNum;
            }
            set
            {
                this._ToRowNum = value;
            }
        }

        #endregion

        #region ��ѯ����

        private Matcher _Matcher = null;
        /// <summary>
        /// �ö����ƥ������
        /// </summary>
        public Matcher Matcher
        {
            get
            {
                return this._Matcher;
            }
            set
            {
                this._Matcher = value;
            }
        }

        #endregion

        #region ����

        private List<SortBy> _SortByCollection = new List<SortBy>();
        /// <summary>
        /// �����������򷽷�
        /// </summary>
        public SortBy[] SortByCollection
        {
            get
            {
                return this._SortByCollection.ToArray();
            }
            set
            {
                this._SortByCollection = new List<SortBy>() ;
                for(int i = 0; i < value.Length; i++)
                {
                    this._SortByCollection.Add(value[i]);
                }
            }
        }

        /// <summary>
        /// ��������ֶ�
        /// </summary>
        /// <param name="itemName">������ֶε�����</param>
        /// <param name="direction">�Ӵ�С���ߴ�С����</param>
        /// <returns>�����ӳɹ����򷵻�true�����򷵻�false</returns>
        public bool AddSortBy(string itemName, SortDirection direction)
        {
            SortBy sortBy = new SortBy(itemName, direction);
            return this.AddSortBy(sortBy);
        }

        /// <summary>
        /// ��������ֶ�
        /// </summary>
        /// <param name="sortBy">�����ֶε���Ϣ</param>
        /// <returns>���û���ظ��������򷵻�true�����򷵻�false</returns>
        public bool AddSortBy(SortBy sortBy)
        {
            if (sortBy == null)
            {
                return false;
            }
            // ����ڼ������Ƿ��Ѿ�����
            foreach (SortBy iterator in this._SortByCollection)
            {
                if (iterator.ItemName == sortBy.ItemName)
                {
                    return false;
                }
            }
            this._SortByCollection.Add(sortBy);
            return true;
        }

        /// <summary>
        /// ɾ�������ֶ�
        /// </summary>
        /// <param name="index">Ҫɾ��������������</param>
        /// <returns>���ɾ���ɹ����򷵻�true�����򷵻�false</returns>
        public bool RemoveSortBy(int index)
        {
            if (index < 0 || index > this._SortByCollection.Count - 1)
            {
                return false;
            }
            this._SortByCollection.RemoveAt(index);
            return true;
        }

        #endregion

        /// <summary>
        /// Ҫ���ص��еļ��ϣ������Ϊ�գ����ʾֻ��Ҫ�������е��У��������ʾ����Ĭ�ϵķ��ط�ʽ�����������ReturnColumns����ͨ�ģ����������������ʾ����
        /// </summary>
        public string[] ReturnItems
        {
            get
            {
                List<string> columns = new List<string>();
                if(this.ReturnColumns != null)
                {
                    foreach(ReturnColumn c in this.ReturnColumns)
                    {
                        columns.Add(c.ColumnName);
                    }
                }
                return columns.ToArray();
            }
            set
            {
                List<ReturnColumn> columns = new List<ReturnColumn>();
                if(value != null)
                {
                    foreach(string c in value)
                    {
                        ReturnColumn column = new ReturnColumn(c, null);
                        columns.Add(column);
                    }
                }
                this._ReturnColumns = columns.ToArray();
            }
        }

        private ReturnColumn[] _ReturnColumns;
        /// <summary>
        /// Ҫ���ص��еļ��ϣ������Ϊ�գ����ʾֻ��Ҫ�������е��У��������ʾ����Ĭ�ϵķ��ط�ʽ�����������ReturnItems����ͨ�ģ��������������ʾ����
        /// </summary>
        public ReturnColumn[] ReturnColumns
        {
            get
            {
                return this._ReturnColumns;
            }
            set
            {
                this._ReturnColumns = value;
            }
        }

        private bool _RequireCount = false;
        /// <summary>
        /// �Ƿ���Ҫ���ط��������ļ�¼��������ͨ�����ڷ�ҳ��ʾ��¼��ʱ������Ҫ���������
        /// </summary>
        public bool RequireCount
        {
            get
            {
                return this._RequireCount;
            }
            set
            {
                this._RequireCount = value;
            }
        }

    }
}
