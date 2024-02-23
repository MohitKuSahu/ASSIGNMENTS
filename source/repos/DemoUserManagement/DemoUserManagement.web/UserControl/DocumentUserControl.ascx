<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DocumentUserControl.ascx.cs" Inherits=" DemoUserManagement.Web.User_Control.DocumentUserControl" %>



<div class="form-group">
    <label for="ddlDocumentType">Select Document Type:</label>
    <asp:DropDownList ID="ddlDocumentType" runat="server" CssClass="form-control">
           <asp:ListItem Text="Documents" Value="2" />
           <asp:ListItem Text="ProfilePic" Value="3" />
    </asp:DropDownList>
</div>
<div class="form-group">
    <label for="fileUpload">Upload Document:</label>
    <div class="input-group">
        <div class="custom-file">
            <asp:FileUpload ID="fileUpload" runat="server" CssClass="custom-file-input" />
        </div>
        <div class="input-group-append">
            <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="btn btn-primary" OnClick="BtnUpload_Click"  />
        </div>
    </div>
</div>
<br />
<div>
      <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updatePanel">
      <ContentTemplate>
              <asp:GridView ID="DocumentGrid" runat="server" AutoGenerateColumns="False" ClientIDMode="Static" AllowCustomPaging="true"
        AllowSorting="true" AllowPaging="true" PageSize="2" OnSorting="DocumentGrid_Sorting" OnPageIndexChanging="DocumentGrid_PageIndexChanging" EnableViewState="true">
        <Columns>
            <asp:BoundField DataField="DocumentID" HeaderText="Document ID" SortExpression="DocumentID" />
            <asp:BoundField DataField="DocumentOriginalName" HeaderText="Document Original Name" SortExpression="DocumentOriginalName" />
            <asp:TemplateField HeaderText="Download File">
                <ItemTemplate>
                    <asp:HyperLink ID="hypDownload" runat="server" Text="Download" NavigateUrl='<%# $"FileDownloadHandler.ashx?fileName="+Eval("DocumentGuidName") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="TimeStamp" HeaderText="Added On" SortExpression="CreatedDate" />
        </Columns>

          <HeaderStyle BackColor="#E2E2E2" ForeColor="#333333" BorderStyle="Solid" BorderColor="#CCCCCC" BorderWidth="1px" />
<RowStyle BackColor="#F7F6F3" ForeColor="#333333" BorderStyle="Solid" BorderColor="#CCCCCC" BorderWidth="1px" />
<AlternatingRowStyle BackColor="White" ForeColor="#333333" BorderStyle="Solid" BorderColor="#CCCCCC" BorderWidth="1px" />
<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" BorderStyle="Solid" BorderColor="#CCCCCC" BorderWidth="1px" />
 <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" BorderStyle="Solid" BorderColor="#CCCCCC" BorderWidth="1px"/>
    </asp:GridView>
        </ContentTemplate>
        </asp:UpdatePanel>
   

    
</div>