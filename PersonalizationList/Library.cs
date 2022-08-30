using System;
using System.Collections.Generic;
using System.IO;

namespace PersonalizationList
{
   
    [Serializable()]
    public class Rule
    {
        public string Page { get; set; }
        public string RuleId { get; set; }
        public string RuleName { get; set; }
        public string Condition { get; set; }
        public string Field { get; set; }
        public string Value { get; set; }

        public Rule()
        { }

        public Rule(string ruleId, string ruleName, string field, string name)
        {
            this.RuleId = ruleId;
            this.RuleName = ruleName;
            this.Field = field;
            this.Value = name;
        }
    }

    public static class Library
    {
        public static string GetSubString(string stringVal, string string1, string string2)
        {

            int pFrom = stringVal.IndexOf(string1) + string1.Length;
            int pTo = stringVal.LastIndexOf(string2);

            return stringVal.Substring(pFrom, pTo - pFrom);
        }

        public static string Right(this string value, int length)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;

            return value.Length <= length ? value : value.Substring(value.Length - length);
        }

        public static List<Rule> LookupDirectory(string grandParentPath)
        {
            var siteRules = new List<Rule>();
            try
            {
                string[] files = Directory.GetFiles(grandParentPath, "*.yml", SearchOption.AllDirectories);
                // find all the files.
                foreach (string file in files)
                {
                    var rules = ListRulesinYml(file);
                    if (rules != null) siteRules.AddRange(rules);

                }
            }
            catch (Exception ex)
            {
               throw ex;
            }

            return siteRules;
        }

        public static string GetRuleBlock(string filePath, string ruleId)
        {
            string prevline = string.Empty;
            string newline = string.Empty;
            //bool conditionExists = false;
            bool ruleExists = false;
            bool ruleExactmatch = false;
            bool ruleEnds = false;
            string foundProps = string.Empty;
            string concatLines = string.Empty;
            Rule rule = new Rule();
            List<Rule> ruleList = new List<Rule>();

            string rulename = string.Empty;
            string field = string.Empty;
            string value = string.Empty;

            using (var input = File.OpenText(filePath))
            using (var output = new StreamWriter(@"c:\temp\temp.yml"))
            {
                string currline;
                while (null != (currline = input.ReadLine()))
                {
                    if (!ruleExists)
                    {
                        //  modify line.
                        if (!currline.ToLower().Contains("<ruleset") && currline.ToLower().Contains("<rule"))
                        {
                            ruleExists = true;
                        }
                    }
                    else
                    {
                        if (prevline.ToLower().Contains("<rule") && currline.Contains(ruleId))
                        {
                            concatLines += "                  <rule\r";
                            ruleExactmatch = true;
                            ruleExists = true;
                        }
                        else
                        {
                            if (!ruleExactmatch) ruleExists = false;
                        }

                        if (ruleExactmatch)
                        {
                            if (!ruleEnds)
                            {
                                concatLines += currline + "\r";
                            }

                            if (currline.ToLower().Contains("</rule>"))
                            {
                                ruleEnds = false;
                                ruleExists = false;
                                ruleExactmatch = false;

                                return concatLines;
                            }
                        }
                    }

                    prevline = currline;
                }

            }

            return string.Empty;
        }


        public static string InsertRuleinYml(string filePath, string ruleId, string ruleBlock)
        {
            string prevline = string.Empty;
            string newline = string.Empty;
            bool fileChanges = false;
            //bool conditionExists = false;
            bool ruleExists = false;
            bool ruleExactmatch = false;
            bool valueFound = false;
            bool fieldExists = false;
            bool ruleInserted = false;
            string foundProps = string.Empty;
            string concatLines = string.Empty;
            Rule rule = new Rule();
            List<Rule> ruleList = new List<Rule>();

            string rulename = string.Empty;
            string field = string.Empty;
            string value = string.Empty;

            using (var input = File.OpenText(filePath))
            using (var output = new StreamWriter(@"c:\temp\temp.yml"))
            {
                string currline;
                while (null != (currline = input.ReadLine()))
                {
                    if (!ruleExists)
                    {
                        //  modify line.
                        if (!currline.ToLower().Contains("<ruleset") && currline.ToLower().Contains("<rule"))
                        {
                            if (prevline.ToLower().Contains("s:pet=\"true\">") && currline.Contains("<rule"))
                            {
                                concatLines += ruleBlock;
                                ruleInserted = true;
                                fileChanges = true;
                                ruleExists = true;
                            }
                        }
                        concatLines += currline + "\r";
                    }
                    else
                    {
                        if (ruleInserted) ruleExists = false;
                        concatLines += currline + "\r";

                    }

                    prevline = currline;
                }

            }

            if (fileChanges)
            {
                File.WriteAllText(@"c:\temp\temp1.yml", concatLines);

                File.Replace(@"c:\temp\temp1.yml", filePath, null);
                File.Delete(@"c:\temp\temp1.yml");
            }

            return concatLines;
        }

        public static string RemoveRuleinYml(string filePath, string ruleId)
        {
            string prevline = string.Empty;
            string newline = string.Empty;
            bool fileChanges = false;
            //bool conditionExists = false;
            bool ruleExists = false;
            bool ruleExactmatch = false;
            bool valueFound = false;
            bool fieldExists = false;
            bool ruleEnds = false;
            string foundProps = string.Empty;
            string concatLines = string.Empty;
            Rule rule = new Rule();
            List<Rule> ruleList = new List<Rule>();

            string rulename = string.Empty;
            string field = string.Empty;
            string value = string.Empty;

            using (var input = File.OpenText(filePath))
            using (var output = new StreamWriter(@"c:\temp\temp.yml"))
            {
                string currline;
                while (null != (currline = input.ReadLine()))
                {
                    if (!ruleExists)
                    {
                        //  modify line.
                        if (!currline.ToLower().Contains("<ruleset") && currline.ToLower().Contains("<rule"))
                        {
                            ruleExists = true;
                            concatLines += currline + "\r";
                        }
                        else
                        {
                            concatLines += currline + "\r";
                        }
                    }
                    else
                    {
                        if (prevline.ToLower().Contains("<rule") && currline.Contains(ruleId))
                        {
                            newline += string.Empty;
                            ruleExactmatch = true;
                            fileChanges = true;
                            ruleExists = true;
                        }
                        else
                        {
                            if (!ruleExactmatch) ruleExists = false;
                        }

                        if (ruleExactmatch)
                        {
                            if (!ruleEnds)
                            {
                                newline += string.Empty;
                            }

                            if (currline.ToLower().Contains("</rule>"))
                            {
                                newline += string.Empty;
                                ruleEnds = false;
                                ruleExists = false;
                                ruleExactmatch = false;
                                newline = string.Empty;
                            }

                            concatLines += newline;
                        }
                        else
                        {
                            concatLines += currline + "\r";
                        }
                    }

                    prevline = currline;
                }

            }

            if (fileChanges)
            {
                string orphanline = "                  <rule\r                  <rule";
                string repline = "                  <rule";
                File.WriteAllText(@"c:\temp\temp1.yml", concatLines.Replace(orphanline, repline));

                File.Replace(@"c:\temp\temp1.yml", filePath, null);
                File.Delete(@"c:\temp\temp1.yml");
            }
            return concatLines;
        }

        public static bool RuleExistsinYml(string filePath,string ruleId,string ruleName=null)
        {
            string prevline = string.Empty;

            using (var input = File.OpenText(filePath))
            {
                string currline;
                while (null != (currline = input.ReadLine()))
                {
                    if (prevline.ToLower().Contains("<rule") && currline.ToLower().Contains("uid="))
                    {
                        if (!string.IsNullOrWhiteSpace(ruleId))
                        {
                            if (ruleId == GetSubString(currline, "\"", "\""))
                                return true;
                        }

                    }

                    if (currline.ToLower().Contains("s:name="))
                    {
                        if (!string.IsNullOrWhiteSpace(ruleName))
                        {
                            if (ruleName == GetSubString(currline, "\"", "\""))
                                return true;
                        }
                    }

                    prevline = currline;
                }

            }

            return false;
        }

        public static List<Rule> ListRulesinYml(string filePath)
        {
            string prevline = string.Empty;
            bool fileChanged;
            //bool conditionExists = false;
            bool ruleExists = false;
            bool valueFound = false;
            bool fieldExists = false;
            bool ruleNameAdded = false;
            Rule rule = new Rule();
            List<Rule> ruleList = new List<Rule>();

            using (var input = File.OpenText(filePath))
            {
                string currline;
                while (null != (currline = input.ReadLine()))
                {
                    if (!ruleExists)
                    {
                        //  modify line.
                        if (!currline.ToLower().Contains("<ruleset") && currline.ToLower().Contains("<rule"))
                        {
                            if (prevline.ToLower().Contains("<rule") && currline.ToLower().Contains("uid="))
                            {
                                rule = new Rule
                                {
                                    Page = filePath,
                                    RuleId = GetSubString(currline, "\"", "\"")
                                };
                                ruleExists = true;
                            }

                            if (currline.ToLower().Contains("s:name="))
                            {
                                rule.RuleName = GetSubString(currline, "\"", "\"");
                                ruleNameAdded = true;
                            }

                            if (currline.ToLower().Contains("s:fieldname="))
                            {
                                rule.Field = GetSubString(currline, "\"", "\"");
                            }

                            if (currline.ToLower().Contains("s:value"))
                            {
                                rule.Value = GetSubString(currline, "\"", "\"");
                                valueFound = true;
                            }

                            if (prevline.ToLower().Trim().StartsWith("s:") && currline.ToLower().Contains("</conditions>"))
                            {
                                rule.Condition= GetSubString(prevline, "s:", "/");
                            }

                            if (valueFound)
                            {
                                ruleList.Add(rule);
                                valueFound = false;
                                ruleExists = false;
                                ruleNameAdded = false;
                            }
                            else
                            {
                                if (currline.ToLower().Contains("</rule>") && ruleNameAdded)
                                {
                                    ruleList.Add(rule);
                                    ruleExists = false;
                                    ruleNameAdded = false;
                                }
                            }

                        }
                        else
                        {
                            if (prevline.ToLower().Contains("<rule") && currline.ToLower().Contains("uid="))
                            {
                                rule = new Rule
                                {
                                    Page = filePath,
                                    RuleId = GetSubString(currline, "\"", "\"")
                                };
                                ruleExists = true;
                            }

                            if (currline.ToLower().Contains("s:name="))
                            {
                                rule.RuleName = GetSubString(currline, "\"", "\"");
                                ruleNameAdded = true;
                            }

                            if (currline.ToLower().Contains("s:fieldname="))
                            {
                                rule.Field = GetSubString(currline, "\"", "\"");
                            }


                            if (currline.ToLower().Contains("s:value"))
                            {
                                rule.Value = GetSubString(currline, "\"", "\"");
                                valueFound = true;
                            }

                            if (prevline.ToLower().Trim().StartsWith("s:") && currline.ToLower().Contains("</conditions>"))
                            {
                                rule.Condition = GetSubString(prevline, "s:", "/");
                            }

                            if (valueFound)
                            {
                                ruleList.Add(rule);
                                valueFound = false;
                                ruleExists = false;
                                ruleNameAdded = false;
                            }
                            else
                            {
                                if (currline.ToLower().Contains("</rule>") && ruleNameAdded)
                                {
                                    ruleList.Add(rule);
                                    ruleExists = false;
                                    ruleNameAdded = false;
                                }
                            }

                        }
                    }
                    else
                    {
                        if (prevline.ToLower().Contains("<rule") && currline.ToLower().Contains("uid="))
                        {
                            rule = new Rule
                            {
                                Page = filePath,
                                RuleId = GetSubString(currline, "\"", "\"")
                            };
                        }

                        if (currline.ToLower().Contains("s:name="))
                        {
                            rule.RuleName = GetSubString(currline, "\"", "\"");
                            ruleNameAdded = true;
                        }

                        if (currline.ToLower().Contains("s:fieldname="))
                        {
                            rule.Field = GetSubString(currline, "\"", "\"");
                        }

                        if (currline.ToLower().Contains("s:value"))
                        {
                            rule.Value = GetSubString(currline, "\"", "\"");
                            valueFound = true;
                        }
                        
                        if (prevline.ToLower().Trim().StartsWith("s:") && currline.ToLower().Contains("</conditions>"))
                        {
                            rule.Condition= GetSubString(prevline, "s:", "/");
                        }

                        if (valueFound)
                        {
                            ruleList.Add(rule);
                            valueFound = false;
                            ruleExists = false;
                            ruleNameAdded = false;
                        }
                        else
                        {
                            if (currline.ToLower().Contains("</rule>") && ruleNameAdded)
                            {
                                ruleList.Add(rule);
                                ruleExists = false;
                                ruleNameAdded = false;
                            }
                        }

                    }

                    prevline = currline;
                }

            }

            return ruleList;
        }
    }
}