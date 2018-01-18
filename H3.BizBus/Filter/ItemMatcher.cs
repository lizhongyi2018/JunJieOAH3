using System;

namespace H3.BizBus
{
    /// <summary>
    /// ����ƥ����
    /// </summary>
    [Serializable]
    public class ItemMatcher : Matcher
    {
        /// <summary>
        /// ��������ƥ����
        /// </summary>
        /// <param name="itemName">Ҫƥ�����Ŀ������</param>
        /// <param name="comparisonOperator">ƥ��ıȽϷ���</param>
        /// <param name="value">Ŀ��ֵ</param>
        public ItemMatcher(
            string itemName,
            ComparisonOperatorType comparisonOperator,
            object value,
            bool isColumn = false)
        {
            this._ItemName = itemName;
            this._ComparisonOperator = comparisonOperator;
            if (value == null)
            {
                this._Value = null;
            }
            else if (value is Enum)
            {
                this._Value = (int)value;
            }
            else if (value is bool)
            {
                this._Value = ((bool)value) ? 1 : 0;
            }
            else
            {
                this._Value = value;
            }
            this._IsColumn = isColumn;
        }

        private string _ItemName;
        /// <summary>
        /// Ҫƥ�����Ŀ������
        /// </summary>
        public string ItemName
        {
            get
            {
                return this._ItemName;
            }
        }

        private ComparisonOperatorType _ComparisonOperator;
        /// <summary>
        /// ƥ��ıȽϷ���
        /// </summary>
        public ComparisonOperatorType ComparisonOperator
        {
            get
            {
                return this._ComparisonOperator;
            }
        }

        private object _Value;
        /// <summary>
        /// Ŀ��ֵ
        /// </summary>
        public object Value
        {
            get
            {
                return this._Value;
            }
        }
        private bool _IsColumn;
        /// <summary>
        /// ItemValue�Ƿ�����
        /// </summary>
        public bool IsColumn
        {
            get
            {
                return this._IsColumn;
            }
        }

    }
}
