using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace PersonalizationList
{
    public partial class Ruleinsert : System.Web.UI.Page
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
					this.ViewState["Rules"] = Library.LookupDirectory(txtInsertRulePath.Text);
				}

				return this.ViewState["Rules"] as List<Rule>;
			}
		}
        
        protected void gvRules_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Insert")
            {
                GridViewRow gvr = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                int index = gvr.RowIndex;
                string pageName = (string)gvRules.DataKeys[index]["Page"];
                string ruleId = (string)ViewState["RuleId"];

                if (Library.RuleExistsinYml(pageName, ruleId))
                {
                    gvr.Cells[0].Text = "Exists";
                    gvr.BackColor = System.Drawing.Color.OrangeRed;
                    return;
                }


                // What you want to do when the button is clicked.
                string ruleBlock = (string)ViewState["RuleBlock"];
                if (!string.IsNullOrWhiteSpace(ruleBlock))
                {
                   Library.InsertRuleinYml(pageName, ruleId, ruleBlock);

                    gvr.Cells[0].Text = "Done";
                    gvr.BackColor = System.Drawing.Color.LightGreen;
                }
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
              

        protected void Button2_Click(object sender, EventArgs e)
        {
            List<Rule> rules= (Library.LookupDirectory(txtInsertRulePath.Text)).GroupBy(p => p.RuleId).Select(g => g.First()).ToList(); 
             
            if (ddlRules.Items?.Count == 1)
            {
                foreach (Rule rule in rules)
                {
                   if (rule.RuleId!= "{00000000-0000-0000-0000-000000000000}") ddlRules.Items.Add(rule.RuleName);
                }
            }
            ViewState["LoadRules"] = 1;
        }
        
        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            List<Rule> rules = (Library.LookupDirectory(txtInsertRulePath.Text));
            gvRules.DataSource = rules;
            gvRules.DataBind();
            
            Rule rule = rules.FirstOrDefault(x => x.RuleName == ddlRules.Text);
            string pageName = rule?.Page;
            string ruleId = rule?.RuleId;
            ViewState["Page"] = pageName;
            ViewState["RuleBlock"] = Library.GetRuleBlock(pageName, ruleId);
            ViewState["RuleId"] = rule?.RuleId;
        }
    }
}