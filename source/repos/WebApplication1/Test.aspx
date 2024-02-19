<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Test.aspx.cs" Inherits="WebApplication1.Test" %>




<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


        <div>
           <%-- <asp:TextBox ID="textbox1" runat="server"></asp:TextBox> --%>
            

            
            UserName: <asp:TextBox ID="TextBox2" runat="server" Width="188px"></asp:TextBox>
            <br />
            Password: <asp:TextBox ID="TextBox3" runat="server" Width="192px"></asp:TextBox>
            <br />
            <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Submit" Width="163px" />


            <asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
        
            </div>
                
                   
         
           <div>  
                  <h2>Select Date from the Calender</h2>
                  <uc1:Calender1 ID="Calender1" runat="server" />
          </div>  
                    <asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>
          <asp:TextBox ID="txtFirstName" runat="server" TabIndex="2" />
          <asp:TextBox ID="txtLastName" runat="server" TabIndex="1" />
          <asp:Button ID="btnSubmit" runat="server" Text="Submit" TabIndex="3" />



            <p>Select a City of Your Choice</p>  
        <div>  
            <asp:DropDownList ID="DropDownList1" runat="server" >  
            <asp:ListItem Value="">Please Select</asp:ListItem>  
            <asp:ListItem>New Delhi </asp:ListItem>  
            <asp:ListItem>Greater Noida</asp:ListItem>  
            <asp:ListItem>NewYork</asp:ListItem>  
            <asp:ListItem>Paris</asp:ListItem>  
            <asp:ListItem>London</asp:ListItem>  
        </asp:DropDownList>  
        </div>  
        <br />  
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />  
        <br />  
        <br />  
        <asp:Label ID="Label2" runat="server" EnableViewState="False"></asp:Label> 

            <div>  
            <p>The DataList shows data of DataTable</p>  
        </div>  
        <asp:DataList ID="DataList1" runat="server">  
            <ItemTemplate>  
                <table cellpadding="2" cellspacing="0" border="1" style="width: 300px; height: 100px;   
                border: dashed 2px #04AFEF; background-color: #FFFFFF">  
                    <tr>  
                        <td>  
                            <b>ID: </b><span class="city"><%# Eval("ID") %></span><br />  
                            <b>Name: </b><span class="postal"><%# Eval("Name") %></span><br />  
                            <b>Email: </b><span class="country"><%# Eval("Email")%></span><br />  
                        </td>  
                    </tr>  
                </table>  
            </ItemTemplate>  
        </asp:DataList>  
     
        
    <asp:DataList ID="DataList2" runat="server" DataSourceID="SqlDataSource1">
        <ItemTemplate>
            id:
            <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
            <br />
            name:
            <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' />
            <br />
            email:
            <asp:Label ID="emailLabel" runat="server" Text='<%# Eval("email") %>' />
            <br />
<br />
        </ItemTemplate>
</asp:DataList>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:studentConnectionString2 %>" ProviderName="<%$ ConnectionStrings:studentConnectionString2.ProviderName %>" SelectCommand="SELECT * FROM [student]"></asp:SqlDataSource>
   <%--  (imp)Trust Server Certificate should not be used.--%>
        
    </asp:Content>