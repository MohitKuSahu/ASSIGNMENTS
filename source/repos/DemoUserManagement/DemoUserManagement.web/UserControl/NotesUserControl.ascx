<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NotesUserControl.ascx.cs" Inherits="DemoUserManagement.UserControl.NotesUserControl" %>

<style>
    .notes {
        height: 100px;
        width: 500px;
    }

    .notesDisplay {
        height: 200px;
        width: 100vw;
    }
</style>

<h5>Add Notes:</h5>
<div class="container-fluid">
    <div class="row">
        <div class="col-md-6">
            <div class="notesDisplay">
                <div class="form-group">
                    <asp:TextBox ID="txtNotes" runat="server" placeholder="Add Notes Here" CssClass="form-control notes" ClientIDMode="Static" BorderStyle="Groove"></asp:TextBox>
                </div>
                <br />
                <div class="form-group">
                    <asp:Button ID="bttnAddNotes" runat="server" Text="Add" CssClass="btn btn-primary" UseSubmitBehavior="false" OnClick="BttnAddNotes_Click" />
                </div>
            </div>
        </div>
        <div class="col-md-6">
               <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updatePanel">
                <ContentTemplate>
                    <asp:GridView ID="NotesGrid" runat="server" AutoGenerateColumns="false" ClientIDMode="Static" AllowCustomPaging="true" AllowSorting="true" AllowPaging="true"
                        PageSize="3" OnSorting="NotesGrid_Sorting" OnPageIndexChanging="NotesGrid_PageIndexChanging" EnableViewState="true">
                        <Columns>
                            <asp:BoundField HeaderText="Note ID" DataField="NoteID" ItemStyle-Width="150px" SortExpression="NoteID" />
                            <asp:BoundField HeaderText="Note" DataField="NoteText" ItemStyle-Width="150px" SortExpression="NoteText" />
                            <asp:BoundField HeaderText="Added On" DataField="CreatedDate" ItemStyle-Width="300px" SortExpression="DateTimeAdded" />
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
                </asp:UpdatePanel>
        </div>

    </div>
</div>