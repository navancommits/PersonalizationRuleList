using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace PersonalizationList
{
    public partial class ruledelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                if (ViewState["Rules"] != null)
                {
                    BindGridView((List<Rule>)ViewState["Rules"]);
                }
            }
        }
        
        private List<Rule> Rules
		{
			get
			{
                if (this.ViewState["Rules"] == null)
                {
                    if (Library.Right(txtDeleteRulePath.Text?.Trim().ToLower(), 4) == ".yml")
                    {
                        this.ViewState["Rules"] = Library.ListRulesinYml(txtDeleteRulePath.Text?.Trim());
                    }
                    else
                    {
                        this.ViewState["Rules"] = Library.LookupDirectory(txtDeleteRulePath.Text?.Trim());
                    }
                }

                return (List<Rule>)this.ViewState["Rules"];
            }
        }


        private void BindGridView(List<Rule> ruleList=null)
		{
            if (ruleList == null)
            {
                gvRules.DataSource = this.Rules;
            }
            else
            {
                gvRules.DataSource = ruleList;
            }

			gvRules.DataBind();
		}

		protected void gvRules_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			string pageName = (string)gvRules.DataKeys[e.RowIndex]["Page"];
            Rule rule = this.Rules.Find(r => r.Page == pageName);

            this.Rules.Remove(rule);
            string textLines = Library.RemoveRuleinYml(pageName, rule.RuleId);

            this.BindGridView();
		}
      

        protected void Button2_Click(object sender, EventArgs e)
        {
            List<Rule> rules= (Library.LookupDirectory(txtDeleteRulePath.Text)).GroupBy(p => p.RuleId).Select(g => g.First()).ToList(); 
             
            if (ddlRules.Items?.Count == 1)
            {
                foreach (Rule rule in rules)
                {
                   ddlRules.Items.Add(rule.RuleName);
                }
            }
            ViewState["LoadRules"] = 1;
        }


        protected void ddlRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Rule> ruleList = Library.LookupDirectory(txtDeleteRulePath.Text);
            List<Rule> rules = ruleList.Where(x => x.RuleName == ddlRules.Text).ToList();
            ViewState["Rules"] = rules;
            gvRules.DataSource = rules;
            gvRules.DataBind();
        }

        protected void btnDisplay_Click(object sender, EventArgs e)
        {
        }
    }
}