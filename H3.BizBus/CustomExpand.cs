using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using H3.BizBus;

namespace H3.BizBus
{
    public class CustomExpand
    {
        /// <summary>
        /// 返回匹配器所有的匹配名称(Name)和值(Value)，不包括匹配操作类型（> =）
        /// </summary>
        /// <param name="matcher">匹配器</param>
        /// <returns> 称(Name)和值(Value)字典</returns>
        public static Dictionary<string, string> MatcherToDictionary(Matcher matcher)
        {
            Dictionary<string, string> json = new Dictionary<string, string>();
            if (matcher == null)
            {
                return json;
            }

            if (matcher is ItemMatcher)
            {
                ItemMatcher i = (ItemMatcher)matcher;
                json.Add(i.ItemName, i.Value == null ? "" : i.Value.ToString());
                return json;
            }
            else
            {
                Matcher[] matchers = null;
                if (matcher is And)
                {
                    And and = (And)matcher;
                    json.Add("Type", "And");
                    matchers = and.Matchers;
                }
                else
                {
                    Or or = (Or)matcher;
                    json.Add("Type", "Or");
                    matchers = or.Matchers;
                }

                if (matchers != null)
                {
                    foreach (Matcher m in matchers)
                    {
                        //先去重键，否则报错
                        Dictionary<string, string> jsonb = MatcherToDictionary(m);
                        foreach (KeyValuePair<string, string> keyb in jsonb)
                        {
                            if (!json.ContainsKey(keyb.Key))
                            {
                                json.Add(keyb.Key, keyb.Value);
                            }
                        }
                    }
                }
                return json;
            }
        }
    }
}