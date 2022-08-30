<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rulelist.aspx.cs" Inherits="PersonalizationList.rulelist" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Personalization Page List</title>
</head>
<body>
    <form id="form1" runat="server">
					<div>
						<h1>Personalization Page List</h1>
						<asp:Label ID="Label2" label="Valid Folder Path:" ToolTip="Provide serialization folder path" runat="server" Text="Folder or .yml file Path: "></asp:Label><asp:TextBox ID="txtPath" runat="server" Width="478px"></asp:TextBox><asp:Button ID="Button2" type="submit" runat="server" Text="Load Rules"/>
            	          <asp:gridview ID="gvRules" runat="server" autogeneratecolumns="False" datakeynames="RuleId"  Width="98%"
                                style="margin-top: 20px;"
                                BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" Enabled="False">
		                                <AlternatingRowStyle BackColor="#CCCCCC" />
		                                <columns>
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
						</div>
		
    </form>
</body>
</html>
