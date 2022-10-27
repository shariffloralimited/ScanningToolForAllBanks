<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DHBLCBS.ascx.cs" Inherits="RTGS.Modules.DHBLCBS" %>
<style>
.GrayBackWhiteFont
{
	background:#2456A6;
	font-family: Verdana, Helvetica, sans-serif;
	font-size: 11px;
	color: #FFFFFF;
	font-weight: bold
	
}
.GrayBackWhiteSmallFont
{
	background:#2456A6;
	font-family: Verdana, Helvetica, sans-serif;
	font-size: smaller;
	color: #FFFFFF;
	font-weight: bold;
}
.NormalSmall
{
    font-family: Verdana, Helvetica, sans-serif,AponaLohit,Siyamrupali_1_01;
    font-size:x-small;
    font-weight: normal;
    line-height: 12px;
}
</style>

<asp:DropDownList ID="StateList" Width="200px" CssClass="form-control" 
    runat="server" AutoPostBack="true">
            <asp:ListItem Text="Account Info" Value="1" />
            <asp:ListItem Text="Special Instruction" Value="2" />
            <asp:ListItem Text="Signature" Value="3" />
            <asp:ListItem Text="Customer Info" Value="4" />
</asp:DropDownList>
  
<asp:DataGrid CssClass="table table-bordered" ID="MyGrid" 
    HeaderStyle-CssClass="GrayBackWhiteFont" FooterStyle-CssClass="GrayBackWhiteFont"
    ItemStyle-CssClass="NormalSmall" ItemStyle-Wrap="false"
    runat="server" CellSpacing="0" CellPadding="2" AutoGenerateColumns="true" 
    GridLines="Both" BorderWidth="1px"  ShowFooter="false" ShowHeader="false" Height="0px"  />
        
<asp:DataList ID="ImgList" runat="server" RepeatDirection="Vertical" BackColor="#000000" CellPadding="2">
    <ItemTemplate>
        <img id="img"  src='<%#DataBinder.Eval(Container.DataItem, "ImgSrc")%>' style="width:500px;" runat="server" alt=""/>
    </ItemTemplate>
</asp:DataList>
        