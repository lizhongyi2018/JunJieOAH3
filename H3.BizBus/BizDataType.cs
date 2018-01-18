using System;

namespace H3.BizBus
{
    /// <summary>
    /// ��������߼�����
    /// </summary>
    public enum BizDataType
    {
        /// <summary>
        /// ��ֵ
        /// </summary>
        Unspecified = -1,

        /// <summary>
        /// �߼���
        /// </summary>
        Bool = 1,

        /// <summary>
        /// ������
        /// </summary>
        DateTime = 5,

        /// <summary>
        /// ˫������ֵ��
        /// </summary>
        Double = 7,

        /// <summary>
        /// ����
        /// </summary>
        Int = 9,

        /// <summary>
        /// ������
        /// </summary>
        Long = 11,

        /// <summary>
        /// ���ı�
        /// </summary>
        String = 13,
        /// <summary>
        /// ���ı�
        /// </summary>
        ShortString = 14,

        /// <summary>
        /// ��������
        /// </summary>
        ByteArray = 20,

        ///// <summary>
        ///// δָ�����͵ĸ���
        ///// </summary>
        //File = 24,

        /// <summary>
        /// ʱ�����
        /// </summary>
        TimeSpan = 25,

        /// <summary>
        /// �����ߣ����ˣ�
        /// </summary>
        Unit = 26,
        /// <summary>
        /// �����ߣ����ˣ�
        /// </summary>
        UnitArray = 27,

        /// <summary>
        /// Html
        /// </summary>
        Html = 30,

        /// <summary>
        /// Xml
        /// </summary>
        Xml = 32,

        ///// <summary>
        ///// ҵ�����
        ///// </summary>
        //BizObject = 40,
        ///// <summary>
        ///// ҵ���������
        ///// </summary>
        //BizObjectArray = 41,
        /// <summary>
        /// ҵ��ṹ
        /// </summary>
        BizStructure = 42,
        /// <summary>
        /// ҵ��ṹ����
        /// </summary>
        BizStructureArray = 43,

        /// <summary>
        /// �����������Ķ��������ֶ��ڱ���ͨ�����Կ�����ѯ����ʽ����
        /// </summary>
        Association = 50,

        /// <summary>
        /// ��ͼ����,��json��ʽ��{Address:"",Point:{lat:32323.43,lng:323.232}}
        /// </summary>
        Map = 55,
        /// <summary>
        /// ��ַ����,��json��ʽ:{"Province":"����ʡ","City":"Ȫ����","Town":"�ݰ���","Detail":"32323"}
        /// </summary>
        Address
    }
}
