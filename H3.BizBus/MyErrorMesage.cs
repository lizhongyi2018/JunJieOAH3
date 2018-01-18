using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H3.BizBus
{
    [Serializable()]
    public class MyErrorMesage
    {
        public static string GetError(string ErrorMesage, bool IsDebugPara)
        {
            try
            {
                if (IsDebugPara != true)
                {
                    int i1 = ErrorMesage.IndexOf("`", 0);
                    if (i1 >= 0)
                    {
                        ErrorMesage = ErrorMesage.Substring(i1 + 1);
                        int i2 = ErrorMesage.IndexOf("`");
                        if (i2 >= 0)
                        {
                            ErrorMesage = ErrorMesage.Substring(0, i2);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {

            }

            return ErrorMesage;
        }

    }
}
