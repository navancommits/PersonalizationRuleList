using System;
using System.Collections.Generic;

namespace PersonalizationList
{
    public partial class rulelist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
                        BindGridView();
        }

        private List<Rule> Rules
		{
			get
			{
                if (Library.Right(txtPath.Text?.Trim().ToLower(), 4) == ".yml")
                {
                    this.ViewState["Rules"] = Library.ListRulesinYml(txtPath.Text?.Trim());
                }
                else
                {
                    this.ViewState["Rules"] = Library.LookupDirectory(txtPath.Text?.Trim());
                }

				return (List<Rule>)this.ViewState["Rules"];
			}
		}

        private void BindGridView()
		{
			gvRules.DataSource = this.Rules;
			gvRules.DataBind();
		}
        
    }
}