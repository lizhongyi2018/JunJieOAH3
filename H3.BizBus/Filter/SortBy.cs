using System;

namespace H3.BizBus
{
    /// <summary>
    /// ����ʽ
    /// </summary>
    [Serializable]
    public class SortBy
	{
        /// <summary>
        /// �½��õĹ��캯��
        /// </summary>
        /// <param name="itemName">������Ŀ����</param>
        /// <param name="direction">����ķ���</param>
        public SortBy(string itemName, SortDirection direction)
		{
			this._Direction = direction;
            this._ItemName = itemName;
        }

        private string _ItemName;
        /// <summary>
        /// ������Ŀ����
        /// </summary>
        public string ItemName
        {
            get
            {
                return this._ItemName;
            }
        }

        private SortDirection _Direction;
        /// <summary>
        /// ����ķ���
        /// </summary>
        public SortDirection Direction
        {
            get
            {
                return this._Direction;
            }
        }

	}
}
