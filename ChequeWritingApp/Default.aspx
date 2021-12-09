<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChequeWritingApp._Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h4>Cheque Calculator</h4>
        <br />
         <label>Name</label> 
         <asp:TextBox ID="ChequeName" runat="server"></asp:TextBox>
         <label>Value</label>
        <asp:TextBox ID="ChequeValue" runat="server" ></asp:TextBox>
        <asp:Button ID="submitInput" runat="server" Text="Submit" OnClick="submitInput_Click" />

        <br /><br />
        <p><asp:Label runat="server" ID="PersonName"></asp:Label></p>
       <p><asp:label ID="NumberWithDecimal" runat="server"></asp:label><asp:label ID="NumberInWords" runat="server"></asp:label></p> 
    </div>
   
    

</asp:Content>
