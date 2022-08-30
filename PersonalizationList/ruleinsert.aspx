<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ruleinsert.aspx.cs" Inherits="PersonalizationList.Ruleinsert" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Insert Personalization Rule</title>
	<style>
		       body {
           font-family: "Helvetica", Arial, serif;
           background: #F0F0F0;
       }
       .loader {
           height: 80px;
           width: 98%;
           background: #d0cfcf;
           margin: 0 1% 0.5% 1%;
           padding-top: 15px;
           padding-left: 5px;
           padding-right: 5px;
       }

       .sc_btn{          
          background-image:url('~/icons/sitecorelogo.png');  
          cursor:pointer;
        }

      
       .header {
           height: 5%;
           width: 98%;
           margin: 0.5% 1% 0.5% 1%;
           padding-top: 1%;
           padding-bottom: 1%;
           text-align: center;
           color: #313335;
           font-size: x-large;
       }

       #headerbg {
           background: url('https://localhost:44306/leadrerbg.png') no-repeat;
       }
       
       .panel {
           margin: 1% 1% 0% 0%;
       }

       .row {
           margin-left: 1%;
       }

       #gViewContainer {
           background: #D0CFCF;
           width: 96%;
       }

       #dvModuleJson {
           height: 730px;
       }

       .btn {
           background: #0077b5;
       }
	</style>
</head>
<body>
    <form id="form1" runat="server">
						<h1>Insert Personalization Rule</h1>
					<table>
						<tr><td><asp:Label ID="Label2" label="Valid Folder Path:" ToolTip="Provide serialization folder path" runat="server" Text="Folder Path: "></asp:Label><asp:TextBox ID="txtInsertRulePath" runat="server" Width="478px"></asp:TextBox><asp:Button ID="Button2"  runat="server" Text="Load Rules" OnClick="Button2_Click" />
						</td></tr>
					 <tr><td><asp:Label ID="Label3" label="Select Rule:" ToolTip="Select the rule to insert" runat="server" Text="Select Rule: "/>
						 <asp:DropDownList ID="ddlRules" runat="server" DataValueField='<%# Bind("RuleName") %>'>
                                 <asp:ListItem value="select">Select One</asp:ListItem>
						
                    </asp:DropDownList><asp:Button ID="btnDisplay"  runat="server" Text="Display Pages" OnClick="btnDisplay_Click"  /></td></tr>
                    </table>
								            	          <asp:gridview ID="gvRules" runat="server" autogeneratecolumns="False" datakeynames="Page"  Width="98%"
                                style="margin-top: 20px;"  onrowcommand="gvRules_RowCommand"
                                BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
		                                <AlternatingRowStyle BackColor="#CCCCCC" />
		                                <columns>
											<asp:templatefield headertext="Action">
				                                <itemtemplate>
                                                    <asp:linkbutton id="btnInsert" runat="server" commandname="Insert" text="Insert" />
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
