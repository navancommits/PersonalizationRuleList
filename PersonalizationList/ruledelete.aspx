<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ruledelete.aspx.cs" Inherits="PersonalizationList.ruledelete" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delete Personalization Rule</title>
	
</head>
<body>
    <form id="form1" runat="server">
						<h1>Delete Personalization Rule</h1>
					<table>
						<tr><td><asp:Label ID="Label2" label="Valid Folder Path:" ToolTip="Provide serialization folder path" runat="server" Text="Folder or .yml file Path:  "></asp:Label><asp:TextBox ID="txtDeleteRulePath" runat="server" Width="478px"></asp:TextBox><asp:Button ID="Button2"  runat="server" Text="Load Rules" OnClick="Button2_Click" />
						</td></tr>
					 <tr><td><asp:Label ID="Label3" label="Select Rule:" ToolTip="Select the rule to delete" runat="server" Text="Select Rule: "/>
						 <asp:DropDownList ID="ddlRules" runat="server" DataValueField='<%# Bind("RuleName") %>' OnSelectedIndexChanged="ddlRules_SelectedIndexChanged">
                                 <asp:ListItem value="select">Select One</asp:ListItem>
						
                    </asp:DropDownList><asp:Button ID="btnDisplay"  runat="server" Text="Display Pages" OnClick="btnDisplay_Click"  /></td></tr>
</table>								            	          
        <asp:gridview ID="gvRules" runat="server" autogeneratecolumns="False" datakeynames="Page"  Width="98%"
                                onrowdeleting="gvRules_RowDeleting" style="margin-top: 20px;"
                                BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
		                                <AlternatingRowStyle BackColor="#CCCCCC" />
		                                <columns>
											<asp:templatefield headertext="Action">
				                                <itemtemplate>
					                                <asp:linkbutton id="btnDelete" runat="server" causesvalidation="false" commandname="Delete" text="Delete" />
				                                </itemtemplate>
                                               
			                                </asp:templatefield>
											<asp:templatefield headertext="Page">
				                                <itemtemplate>
					                                <%# Eval("Page") %>
				                                </itemtemplate>				                               
			                                </asp:templatefield>
			                                <asp:templatefield  headertext="RuleId">
				                                <itemtemplate>
					                                <%# Eval("RuleId") %>
				                                </itemtemplate>				                                
			                                </asp:templatefield>
			                                <asp:templatefield headertext="Rule Name">
				                                <itemtemplate>
					                                <%# Eval("RuleName") %>
				                                </itemtemplate>				                               
			                                </asp:templatefield>
                                            <asp:templatefield headertext="Condition">
                                                <itemtemplate>
                                                    <%# Eval("Condition") %>
                                                </itemtemplate>				                               
                                            </asp:templatefield>
			                                <asp:templatefield headertext="Field">
				                                <itemtemplate>
					                                <%# Eval("Field") %>
				                                </itemtemplate>				                               
			                                </asp:templatefield>
                                            <asp:templatefield headertext="Value">
				                                <itemtemplate>
					                                <%# Eval("Value") %>
				                                </itemtemplate>				                               
			                                </asp:templatefield>
		                            </columns>
                                        <HeaderStyle BackColor="#313335" Font-Bold="True" ForeColor="LightGray" />
                                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="Gray" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#383838" />
	                            </asp:gridview>
    </form>
</body>
</html>
