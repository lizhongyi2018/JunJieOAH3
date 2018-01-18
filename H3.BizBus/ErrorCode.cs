using System;

namespace H3
{
    /// <summary>
    /// �������
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// �ɹ�
        /// </summary>
        Success = 0,

        /// <summary>
        /// ͨ����ʧ�ܣ�����H3�����ⲿ��ϵͳ��ʱ�򣬿��ܲ���ϸ�־���Ĵ�����룬��ô��ʹ������������
        /// </summary>
        GeneralFailed = 1,

        #region ͨ���ʹ������

        /// <summary>
        /// ������Item�Ѿ�����
        /// </summary>
        ItemExists = 10,

        /// <summary>
        /// ��Ŀ������
        /// </summary>
        ItemNotExists = 11,

        /// <summary>
        /// ����Ĳ���Ϊ��
        /// </summary>
        ArgumentIsNull = 12,

        /// <summary>
        /// �������
        /// </summary>
        SaveFailed = 13,

        /// <summary>
        /// �������Ϸ�
        /// </summary>
        ParameterInvalid = 14,

        /// <summary>
        /// �����Ѿ�����
        /// </summary>
        CodeExists = 15,

        /// <summary>
        /// ���뱻�ı�
        /// </summary>
        CodeIsNotChangable = 16,

        /// <summary>
        /// �����ֶβ��Ϸ�
        /// </summary>
        CodeInvalid = 17,

        /// <summary>
        /// ID���Ϸ�
        /// </summary>
        IdInvalid = 18,

        /// <summary>
        /// ���Ʋ��Ϸ�
        /// </summary>
        NameInvalid = 19,

        /// <summary>
        /// �����ظ�
        /// </summary>
        NameDuplicated = 20,

        /// <summary>
        /// ��֯�ı�������ظ�
        /// </summary>
        CodeDuplicated = 21,

        /// <summary>
        /// ��֯�ı���Ϊ��
        /// </summary>
        CodeIsNull = 22,

        /// <summary>
        /// ״̬���Ϸ�����ֹ�������
        /// </summary>
        InvalidState = 23,

        /// <summary>
        /// ����������
        /// </summary>
        NotSender=24,

        /// <summary>
        /// Json�ַ������Ϸ�
        /// </summary>
        JsonInvalid = 25,

        #endregion

        #region ��Ⱥ

        /// <summary>
        /// ���治����
        /// </summary>
        LogicUnitNotExists = 100,

        /// <summary>
        /// ��������������
        /// </summary>
        LogicUnitIsRunning = 101,

        /// <summary>
        /// ���������ʱ������쳣
        /// </summary>
        LoadLogicUnitException = 102,

        /// <summary>
        /// �û��ı���Ϊ��
        /// </summary>
        UserCodeIsNull = 103,

        /// <summary>
        /// �û������Ѿ�����
        /// </summary>
        UserCodeExists = 104,

        /// <summary>
        /// �û����ֻ����Ѿ�����
        /// </summary>
        UserMobileExists = 105,

        /// <summary>
        /// �û����ʼ���ַ�Ѿ�����
        /// </summary>
        UserEmailExists = 106,

        /// <summary>
        /// ע������ʧ��
        /// </summary>
        AddLogicUnitFailed = 107,

        /// <summary>
        /// ��¼���Ѿ�������
        /// </summary>
        LoginNameExists = 108,

        /// <summary>
        /// �˻����Ͳ��Ϸ�
        /// </summary>
        AccountTypeInvalid = 109,

        /// <summary>
        /// ��֤�����
        /// </summary>
        VerificationCodeInvalid = 110,

        /// <summary>
        /// ����ID�Ѵ���
        /// </summary>
        UserDingTalkAccountExists = 113,

        /// <summary>
        /// û�пɹ�ʹ�õ����ݿ������
        /// </summary>
        NoAvailableDbServer = 114,

        /// <summary>
        /// �޷��������ݿ���Դ
        /// </summary>
        NoAvailableDatabase = 115,

        /// <summary>
        /// �������ݿ�ʧ��
        /// </summary>
        CreateDatabaseFailed = 116,

        /// <summary>
        /// ����RDS�˻�ʧ��
        /// </summary>
        CreateRdsDbAccountFailed = 117,

        /// <summary>
        /// ��RDS�˻���Ȩʧ��
        /// </summary>
        GrantRdsDbAccountFailed = 118,

        /// <summary>
        /// ���ӵ�RDS���ݿ�ʧ��
        /// </summary>
        ConnectToRdsDbFailed = 119,

        /// <summary>
        /// û�п��Է�������ݿ�
        /// </summary>
        NoAllocatableDb = 120,

        /// <summary>
        /// ɾ�����ݿ�ʧ��
        /// </summary>
        DropDbFailed = 121,

        /// <summary>
        /// ��ʼ������ʧ��
        /// </summary>
        InitializeLogicUnitFailed = 130,

        /// <summary>
        /// ������������ 
        /// </summary>
        VesselNotExists = 131,

        /// <summary>
        /// ����������������״̬
        /// </summary>
        VesselNotRunning = 132,

        /// <summary>
        /// ��ֹ��IP����ϵͳ
        /// </summary>
        IpBlocked = 133,

        /// <summary>
        /// ��IP���ʵĴ������࣬��Щ����ͨ�������磺ע������֮���
        /// </summary>
        TooManyVisitWithinIp = 134,

        /// <summary>
        /// IP��ַ���ڰ�������
        /// </summary>
        IpNotInWhitelist = 135,

        /// <summary>
        /// �������
        /// </summary>
        PasswordInvalid = 137,

        /// <summary>
        /// ����ʧ��
        /// </summary>
        ConnectionFailed = 138,

        /// <summary>
        /// Ȩ�޲���
        /// </summary>
        NotEnoughPermission = 139,

        /// <summary>
        /// �������ĵ�ַ���Ϸ�
        /// </summary>
        ServerAddressInvalid = 140,

        /// <summary>
        /// �����ڲ���������
        /// </summary>
        ServiceInternalError = 141,

        /// <summary>
        /// ��������������������
        /// </summary>
        NotMaster = 142,

        /// <summary>
        /// ָ�����߼���Ԫ����������״̬
        /// </summary>
        LogicUnitNotRunning = 143,

        /// <summary>
        /// �û���������
        /// </summary>
        UserDisabled = 144,

        /// <summary>
        /// ������������������࣬�û�������
        /// </summary>
        UserLocked = 145,

        /// <summary>
        /// ��Ⱥ���Ʋ��Ϸ�
        /// </summary>
        ClusterTokenInvalid = 146,

        /// <summary>
        /// �������̫��
        /// </summary>
        ApplyTooMany = 147,

        /// <summary>
        /// �����Ŷ�ע����
        /// </summary>
        RegisteringLogicUnit = 148,

        /// <summary>
        /// ������ҵ�Ѿ�������
        /// </summary>
        DingTalkCoprIdExists = 150,

        /// <summary>
        /// ��װӦ��ʧ��
        /// </summary>
        InstallAppFailed = 151,

        /// <summary>
        /// ָ�����߼���Ԫδ������
        /// </summary>
        LogicUnitNotMounted = 152,

        /// <summary>
        /// ����ID���Ϸ�
        /// </summary>
        DingTalkIdInvalid = 153,

        DingTalkCorpIdNotExists = 154,

        DingTalkCorpExistsUserNotExists = 155,

        DingTalkSignatureNotExists = 156,

        DingTalkServiceNotRunning = 157,

        DingTalkPermanentCodeGetError = 158,

        /// <summary>
        /// ����ID�Ѵ���
        /// </summary>
        UserDingIdAccountExists = 159,
        /// <summary>
        /// ����ɨ���¼�����ʧ��
        /// </summary>
        DingTalkScanFailed = 160,
        /// <summary>
        /// �����׼�δ�ҵ�
        /// </summary>
        DingTalkSuiteNotExists=161,
        /// <summary>
        /// DingTalkCorp��ɾ��
        /// </summary>
        DingTalkCorpNotExists=162,
        /// <summary>
        /// �������ڣ����治����
        /// </summary>
        DingTalkExistEngineNotExists=163,
        /// <summary>
        /// ������̨��½H3��֤�벻����
        /// </summary>
        DingTalkISVBackEndSignatureNotExists = 164,

        /// <summary>
        /// ��ȡ����AccessTokenʧ��
        /// </summary>
        DingTalkAccessTokenFailed = 165,

        /// <summary>
        /// ����ʧ��
        /// </summary>
        CompileError = 170,

        /// <summary>
        /// ����ʧ��
        /// </summary>
        UpdateFailed = 171,

        /// <summary>
        /// �޷�ͨ������ʽ��¼��������
        /// </summary>
        CanNotLoginProductSystem = 172,

        #endregion

        #region ��֯�ṹ

        /// <summary>
        /// ����Ա���Բ��Ϸ�
        /// </summary>
        ManagerInvalid = 201,
        
        /// <summary>
        /// �����Բ��Ϸ���Ϊ�ջ��߲�����
        /// </summary>
        ParentIsNull = 203,

        /// <summary>
        /// ��˾���Բ��Ϸ���Ϊ�ջ��߲�����
        /// </summary>
        CompanyInvalid = 204,

        /// <summary>
        /// ��֯��Ԫ�γ��˻������Ϸ�
        /// </summary>
        OrganizationUnitCycleInvalid = 205,

        /// <summary>
        /// �޷�·�ɵĸ�
        /// </summary>
        IterateToCompanyFailed = 206,

        /// <summary>
        /// ��˾��һ��
        /// </summary>
        CompanyInconsistent = 207,

        /// <summary>
        /// ��˾������
        /// </summary>
        CompanyNotExists = 208,

        /// <summary>
        /// ���������ΪOU���߹�˾
        /// </summary>
        ParentInvalid = 209,

        /// <summary>
        /// Ա����Ŵ����ظ�
        /// </summary>
        EmployeeNumberDuplicated = 210,

        /// <summary>
        /// �û�������
        /// </summary>
        UserNotExists = 212,

        /// <summary>
        /// ���ٱ���һ��ϵͳ����Ա
        /// </summary>
        AtLeastOneAdministrator = 213,

        /// <summary>
        /// ֻ���ֻ��ܹ���������
        /// </summary>
        MobileRequired = 214,

        /// <summary>
        /// �û��Ľ�ɫ������
        /// </summary>
        OrgRoleNotExists = 215,

        /// <summary>
        /// ����Ա��ɫ�������ñ��ƵĲ��ţ���Ϊ����Ա��ɫ�ǲ��ֲ��ŵ�
        /// </summary>
        AdminRoleCanNotSetDepts = 216,

        /// <summary>
        /// ����ͬһ���û���������������ͬ�Ľ�ɫ�µĸ�λ
        /// </summary>
        DuplicatedRoles = 217,

        /// <summary>
        /// ÿ���û�Ĭ�϶��������û���ɫ������Ҫ��������Ӷ�Ӧ�ĸ�λ
        /// </summary>
        EveryoneIsUserRoleByDefault = 218,

        /// <summary>
        /// ��λ��Ӧ�Ĳ��Ų��Ϸ���Ϊ�ջ��߲����ڣ������ظ�
        /// </summary>
        PostDeptInvalid = 219,

        /// <summary>
        /// �û�ֻ�ܴӶ�����ͬ����������������û�
        /// </summary>
        CanNotAddUser = 220,

        /// <summary>
        /// ���ܱ���û��ĵ�¼��Ϣ��ֻ�ܴӶ���ͬ������
        /// </summary>
        CanNotUpdateUserLoginName = 221,
        /// <summary>
        /// ����Ա��ɫ�û�������Ϊ��
        /// </summary>
        AdminRoleUserNumberNotBeZero,

        #endregion

        #region ����

        /// <summary>
        /// ����ʵ��������
        /// </summary>
        WorkflowInstanceNotExists = 300,

        /// <summary>
        /// ����ģ����û���ҵ�
        /// </summary>
        WorkflowClauseNotExists = 301,

        /// <summary>
        /// ���������
        /// </summary>
        WorkItemNotExists = 302,

        /// <summary>
        /// Ҫ����������Working״̬
        /// </summary>
        WorkItemStateNotMatched = 303,

        /// <summary>
        /// �������ظ�
        /// </summary>
        WorkItemParticipantDuplicated = 304,

        #endregion

        #region ����

        /// <summary>
        /// ��������Ϊ��
        /// </summary>
        ReportSettingNotExists = 400,

        /// <summary>
        /// ��������Դ���Ϸ�
        /// </summary>
        ReportSourceInvalid = 401,

        /// <summary>
        /// �������ô���
        /// </summary>
        ReportSettingInvalid = 402,

        #endregion

        #region Ӧ��

        /// <summary>
        /// ��������
        /// </summary>
        FormNotExists = 501,

        /// <summary>
        /// ҵ�����ģʽ�����ظ�
        /// </summary>
        SchemaCodeDuplicated = 503,

        /// <summary>
        /// ҵ�����ģʽ������
        /// </summary>
        SchemaNotExists = 504,

        /// <summary>
        /// ҵ�����ģʽ����̫����
        /// </summary>
        SchemaRowTooLarge = 505,

        /// <summary>
        /// ҵ�����ģʽ���г�ͻ
        /// </summary>
        SchemaColumnConflicted = 506,

        /// <summary>
        /// ҵ��������������ڱ�ɾ���Ķ���
        /// </summary>
        BizObjectReferToRemovingObjects = 507,

        /// <summary>
        /// ��ҵ������޷�����������ɾ���͸���
        /// </summary>
        ChildBizObjectCanNotInvokeMethodAlone = 508,

        /// <summary>
        /// ����ɾ��һ�������õĶ���
        /// </summary>
        CanNotRemoveObjectWhichReferred = 509,

        /// <summary>
        /// ����ɾ��������ʵ���Ķ���
        /// </summary>
        CanNotRemoveObjectWithWorkflowInstance = 510,

        /// <summary>
        /// �������ύ����
        /// </summary>
        ValidateSubmitRuleFailed = 511,

        /// <summary>
        /// ����ҵ������Ӧ�Ĵ洢����ʧ��
        /// </summary>
        CreateBizRuleProcedureFailed = 512,

        /// <summary>
        /// �������ڱ�ɾ��
        /// </summary>
        ObjectIsRemoving = 513,

        /// <summary>
        /// �ڵ㲻����
        /// </summary>
        NodeNotExists = 514,

        /// <summary>
        /// ҵ��������ڱ������û�����
        /// </summary>
        BizObjectIsUpdating = 515,

        /// <summary>
        /// ҵ�����̫����
        /// </summary>
        BizObjectIsTooLarge = 516,

        #endregion

        #region BizBus

        /// <summary>
        /// ��ȡ������ϵͳ������ʧ�ܣ�����Ҫ�����ڵ�����ϵͳ������£���õ�����ϵͳ�е����Ƶ������ʹ�õ�
        /// </summary>
        LoadAccessPointTokenFailed = 600,
        /// <summary>
        /// �Ѿ�������
        /// </summary>
        HaveAttached = 601,
        /// <summary>
        /// δ�����Ȩ��ʶ
        /// </summary>
        NotAuthroized = 603,
        /// <summary>
        /// ����ͬ����֯����
        /// </summary>
        SynchronizingOrganization = 604,

        #endregion

        #region ����

        /// <summary>
        /// ��ǰ��ɲ�֧�ֵ���Web Service
        /// </summary>
        LicenseNotSupportWebService = 700

        #endregion
    }
}
