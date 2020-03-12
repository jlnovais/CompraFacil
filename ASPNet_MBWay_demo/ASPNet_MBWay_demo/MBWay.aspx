<%@ Page Title="MBway - option 1" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MBWay.aspx.cs" Inherits="ASPNet_MBWay_demo.MBWay" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>


    <asp:Panel runat="server" ID="formPanel" Visible="True">

        <div class="row">

            <div class="col-md-6">

                <div class="form-group">
                    <label for="inputPhone">Phone number</label>
                    <asp:TextBox runat="server" type="number" CssClass="form-control" ID="inputPhone" aria-describedby="phoneHelp" placeholder="Enter phone number" required />
                    <small id="phoneHelp" class="form-text text-muted">You mobile phone number.</small>
                </div>

                <div class="form-group">
                    <label for="inputAmount">Amount (euros)</label>
                    <div class="input-group">
                        <span class="input-group-addon">€</span>
                        <asp:TextBox runat="server" type="number" value="1" min="0" step="0.01" data-number-to-fixed="2" data-number-stepfactor="100" CssClass="form-control currency" ID="inputAmount" aria-describedby="amountHelp" placeholder="Enter amount" required />
                    </div>
                    <small id="amountHelp" class="form-text text-muted">Amount to pay.</small>

                </div>

                <div class="form-group">
                    <label for="inputEmail">Email address</label>
                    <asp:TextBox runat="server" type="email" CssClass="form-control" ID="inputEmail" aria-describedby="emailHelp" placeholder="Enter email" required/>
                    <small id="emailHelp" class="form-text text-muted">Your email address.</small>
                </div>


                <asp:Button CssClass="btn btn-primary" ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
            </div>
        </div>

    </asp:Panel>
    <asp:Panel runat="server" ID="resultsOKPanel" Visible="False">
        <div class="col-md-12">
            <p class="text-success">Your request was successful.</p>
        </div>

        <div class="container">
            <div class="row">
                <div class="col-sm-2 text-right"><strong>Reference:</strong></div>
                <div class="col-sm-3">
                    <asp:Label runat="server" ID="labelReference"></asp:Label></div>
            </div>
            <div class="row">
                <div class="col-sm-2 text-right"><strong>Status:</strong></div>
                <div class="col-sm-3">
                    <asp:Label runat="server" ID="labelStatus"></asp:Label></div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="resultsErrorPanel" Visible="False">

        <div class="col-md-12">
            <p class="text-danger">Your request was unsuccessful.</p>
        </div>


        <div class="container">
            <div class="row">
                <div class="col-sm-2 text-right"><strong>Error:</strong></div>
                <div class="col-sm-3">
                    <asp:Label runat="server" ID="labelError"></asp:Label></div>
            </div>

            <div class="row">
                <div class="col-sm-2 text-right"><strong>Description:</strong></div>
                <div class="col-sm-3">
                    <asp:Label runat="server" ID="labelErrorDescription"></asp:Label></div>
            </div>
            <div class="row">
                <div class="col-sm-2 text-right"><strong>Details:</strong></div>
                <div class="col-sm-3">
                    <asp:Label runat="server" ID="labelErrorDetails"></asp:Label></div>
            </div>
        </div>
    </asp:Panel>

</asp:Content>
