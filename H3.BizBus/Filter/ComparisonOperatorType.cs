namespace H3.BizBus
{
    // ERROR, ������Ҫע���£������ܷ��H3.DataModel.Math���ƥ����ϲ�
    /// <summary>
    /// �Ƚ��õ�ͨ���
    /// </summary>
    public enum ComparisonOperatorType
	{
        /// <summary>
        /// ����
        /// </summary>
		Above = 0, 
        /// <summary>
        /// ���ڵ���
        /// </summary>
		NotBelow = 1, 
        /// <summary>
        /// ����
        /// </summary>
		Equal = 2, 
        /// <summary>
        /// С�ڵ���
        /// </summary>
		NotAbove = 3, 
        /// <summary>
        /// С��
        /// </summary>
		Below = 4,
        /// <summary>
        /// ������
        /// </summary>
		NotEqual = 5,
        
        /// <summary>
        /// ��ĳ����Χ��
        /// </summary>
		In = 6, 
        /// <summary>
        /// ����ĳ����Χ��
        /// </summary>
		NotIn = 7, 

        /// <summary>
        /// �ȽϷ���ߵĶ�������ұߵĶ��󣬱��磺{1, 2, 3} Contain {2} == true��������ַ����Ļ��������string.Contains�������߼�
        /// </summary>
		Contains = 8,

		/// <summary>
		/// ��ĳ���ַ���Ϊ��ʼ
		/// </summary>
		StartWith = 13, 
        /// <summary>
        /// ��ĳ���ַ���Ϊ����
        /// </summary>
		EndWith = 14,
		
        /// <summary>
        /// �Ƿ���Null
        /// </summary>
        IsNull = 18,
        /// <summary>
        /// �Ƿ���Null
        /// </summary>
        NotNull = 19,
        /// <summary>
        /// �߼����ǿգ���ʾΪNull��""��object[0]
        /// </summary>
        IsNone = 20,
        /// <summary>
        /// �߼��Ϸǿգ���ʾ����Null��""��object[0]
        /// </summary>
        NotNone = 21
	}
}
