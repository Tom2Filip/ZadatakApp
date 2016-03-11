<%@ Page Title="" Language="C#" MasterPageFile="~/Zadaci.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Zadaci.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>                             
        <div class="float-right">
            <asp:ImageButton id="imagebuttonEnglish" runat="server" Height="17px" Width="20px" AlternateText="<%$ Resources:Resource, imgButtonUKText %>" ImageUrl="Images/Flags/United_Kingdom.jpg" OnClick="btn_Click2"/>
            <asp:ImageButton id="imagebuttonHrvatski" runat="server" Height="17px" Width="20px" AlternateText="<%$ Resources:Resource, imgButtonCroatiaText %>" ImageUrl="Images/Flags/Croatia.jpg" OnClick="btn_Click2"/>           
        </div>

        <br />

        <asp:GridView ID="zadaciGridView" runat="server" DataKeyNames="Id" AutoGenerateColumns="False" EmptyDataText="<%$ Resources:Resource, zadaciGridViewEmptyDataText %>" CellPadding="4" ForeColor="#333333"
                         GridLines="None" OnSelectedIndexChanged="zadaciGridView_SelectedIndexChanged" OnRowDeleting="zadaciGridView_RowDeleting" 
                         AllowSorting="true" CurrentSortField="Id" CurrentSortDirection="ASC" AllowPaging="True" OnPageIndexChanging="zadaciGridView_PageIndexChanging" 
                         OnSorting="zadaciGridView_Sorting" PageSize="6">
            <AlternatingRowStyle BackColor="White" />
            <PagerStyle Font-Bold="true" CssClass="GridViewPagerStyle" />
            <PagerSettings Mode="Numeric" PageButtonCount="4" />
            <EmptyDataRowStyle BackColor="LightBlue" ForeColor="Red" />
           <Columns>
            <asp:CommandField ShowDeleteButton="True" DeleteText="<%$ Resources:Resource, zadaciGridViewDeleteText %>" ShowSelectButton="true" SelectText="<%$ Resources:Resource, zadaciGridViewSelectText %>" ItemStyle-ForeColor="#767676" />

            <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" />
            <asp:BoundField DataField="Naslov" HeaderText="<%$ Resources:Resource, zadaciGridViewNaslovText %>" SortExpression="Naslov" />
            <asp:BoundField DataField="Start" HeaderText="<%$ Resources:Resource, zadaciGridViewStartText %>" SortExpression="Start" />
            <asp:BoundField DataField="Opis" HeaderText="<%$ Resources:Resource, zadaciGridViewOpisText %>" SortExpression="Opis" />
            <asp:CheckBoxField DataField="Status" HeaderText="<%$ Resources:Resource, zadaciGridViewStatusText %>" SortExpression="Status"/>          
            <asp:BoundField DataField="Kraj" HeaderText="<%$ Resources:Resource, zadaciGridViewKrajText %>" SortExpression="Kraj" /> 
           </Columns>
             <EditRowStyle BackColor="#2461BF" />
             <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
             <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Right" />
             <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
             <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
             <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
             <SortedAscendingCellStyle BackColor="#F5F7FB" />
             <SortedAscendingHeaderStyle BackColor="#6D95E1" />
             <SortedDescendingCellStyle BackColor="#E9EBEF" />
             <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>

        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        <br /><br />


        <asp:DetailsView ID="DodajZadatakDetailsView" runat="server" HeaderText="<%$ Resources:Resource, DodajZadatakDetailsViewHeaderText %>"
            AutoGenerateRows="False" DefaultMode="Insert" DataKeyNames="Id" OnItemInserting="DodajZadatakDetailsView_ItemInserting" OnModeChanging="DodajZadatakDetailsView_ModeChanging" 
             OnItemUpdating="DodajZadatakDetailsView_ItemUpdating"
            CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>

            <CommandRowStyle BackColor="#E2DED6" Font-Bold="True"></CommandRowStyle>
            <EditRowStyle BackColor="#999999"></EditRowStyle>
            <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True"></FieldHeaderStyle>
            <Fields>
                <asp:TemplateField HeaderText="<%$ Resources:Resource, NaslovHeaderText %>">
                    <EditItemTemplate>
                        <asp:TextBox ID="naslovTextBox1" runat="server" Text='<%# Bind("Naslov") %>'></asp:TextBox>
                        <asp:RegularExpressionValidator ID="naslovRegValidator1" runat="server" ValidationGroup="DodajZadatakValidationGroup" ControlToValidate="naslovTextBox1" ValidationExpression=".{0,50}" Text="*" Display="Dynamic" ErrorMessage="<%$ Resources:Resource, NaslovLengthErrorMessage %>"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="naslovReqValidator1" ValidationGroup="DodajZadatakValidationGroup" ControlToValidate="naslovTextBox1" runat="server"
                            ErrorMessage="<%$ Resources:Resource, NaslovRequiredErrorMessage %>" Display="Dynamic" Text="*" ></asp:RequiredFieldValidator>                        
                    </EditItemTemplate>
                    <InsertItemTemplate>                        
                        <asp:TextBox ID="naslovTextBox" runat="server" Text='<%# Bind("Naslov") %>'></asp:TextBox> 
                        <asp:RegularExpressionValidator ID="naslovRegValidator" runat="server" ValidationGroup="DodajZadatakValidationGroup" ControlToValidate="naslovTextBox" ValidationExpression=".{0,50}" Text="*" Display="Dynamic" ErrorMessage="<%$ Resources:Resource, NaslovLengthErrorMessage %>"></asp:RegularExpressionValidator>                       
                        <asp:RequiredFieldValidator ID="naslovReqValidator" ValidationGroup="DodajZadatakValidationGroup" ControlToValidate="naslovTextBox" runat="server"
                            ErrorMessage="<%$ Resources:Resource, NaslovRequiredErrorMessage %>" Display="Dynamic" Text="*" ></asp:RequiredFieldValidator>                        
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Naslov") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="<%$ Resources:Resource, PocetakHeaderText %>" SortExpression="Start">
                    <EditItemTemplate>                        
                        <div style="display:inline-block;">                            
                        <asp:TextBox ID="startDateTextBox" runat="server" Text='<%# Bind("Start", "{0:d}") %>' ReadOnly="true"></asp:TextBox>                            
                        <asp:RequiredFieldValidator ID="startDateReqValidator" ValidationGroup="DodajZadatakValidationGroup" ControlToValidate="startDateTextBox" runat="server"
                            ErrorMessage="<%$ Resources:Resource, PocetakRequiredErrorMessage %>" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
                        
                            <div style="display:inline-block;">
                        <asp:ImageButton ID="calendarImage" runat="server" Height="14px" Width="14px"  ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar_icon2.png" OnClick="calendarImage_Click" />
                            </div>
                            <div style="display:inline-block">
                        <asp:Calendar ID="startDateCalendar" runat="server" Visible="false" ImageUrl="~/Images/calendar_icon.png" OnSelectionChanged="startDateCalendar_SelectionChanged"></asp:Calendar>
                        </div>
                        
                            <div style="display:inline-block">
                        <asp:Label ID="lblHour" runat="server" AssociatedControlID="ddlHours" Text="<%$ Resources:Resource, lblHourText %>"></asp:Label>
                                </div>
                                <div style="display:inline-block">
                        <asp:DropDownList ID="ddlHours" runat="server"></asp:DropDownList>
                                </div>
                            <div style="display:inline-block">
                        <asp:Label ID="lblMinutes" runat="server" AssociatedControlID="ddlMinutes" Text="<%$ Resources:Resource, lblMinutesText %>"></asp:Label>
                                </div>
                                <div style="display:inline-block">
                        <asp:DropDownList ID="ddlMinutes" runat="server"></asp:DropDownList>
                                </div>                        
                        </div>
                    </EditItemTemplate>
                    
                    
                    <InsertItemTemplate>
                        <div style="display:inline-block;">                            
                        <asp:TextBox ID="startDateTextBox" runat="server" Text='<%# Bind("Start", "{0:d}") %>' ReadOnly="true"></asp:TextBox>                            
                        <asp:RequiredFieldValidator ID="startDateReqValidator" ValidationGroup="DodajZadatakValidationGroup" ControlToValidate="startDateTextBox" runat="server"
                            ErrorMessage="<%$ Resources:Resource, PocetakRequiredErrorMessage %>" Display="Dynamic" Text="*"></asp:RequiredFieldValidator>
                        
                            <div style="display:inline-block;">
                        <asp:ImageButton ID="calendarImage" runat="server" Height="14px" Width="14px"  ImageAlign="AbsMiddle" ImageUrl="~/Images/calendar_icon2.png" OnClick="calendarImage_Click" />
                            </div>
                            <div style="display:inline-block">
                        <asp:Calendar ID="startDateCalendar" runat="server" Visible="false" ImageUrl="~/Images/calendar_icon.png" OnSelectionChanged="startDateCalendar_SelectionChanged"></asp:Calendar>
                        </div>
                        
                            <div style="display:inline-block">
                        <asp:Label ID="lblHour" runat="server" AssociatedControlID="ddlHours" Text="<%$ Resources:Resource, lblHourText %>"></asp:Label>
                                </div>
                                <div style="display:inline-block">
                        <asp:DropDownList ID="ddlHours" runat="server"></asp:DropDownList>
                                </div>
                            <div style="display:inline-block">
                        <asp:Label ID="lblMinutes" runat="server" AssociatedControlID="ddlMinutes" Text="<%$ Resources:Resource, lblMinutesText %>"></asp:Label>
                                </div>
                                <div style="display:inline-block">
                        <asp:DropDownList ID="ddlMinutes" runat="server"></asp:DropDownList>
                                </div>                        
                        </div>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Start") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                                
                <asp:TemplateField HeaderText="<%$ Resources:Resource, OpisHeaderText %>">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBoxOpis1" runat="server" Text='<%# Bind("Opis") %>'></asp:TextBox>
                        <asp:RegularExpressionValidator ID="opisRegValidator1" runat="server" ValidationGroup="DodajZadatakValidationGroup" ControlToValidate="txtBoxOpis1" ValidationExpression=".{0,300}" Text="*" Display="Dynamic" ErrorMessage="<%$ Resources:Resource, OpisLengthErrorMessage %>"></asp:RegularExpressionValidator>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="txtBoxOpis" runat="server" Text='<%# Bind("Opis") %>'></asp:TextBox>
                        <asp:RegularExpressionValidator ID="opisRegValidator" runat="server" ValidationGroup="DodajZadatakValidationGroup" ControlToValidate="txtBoxOpis" ValidationExpression=".{0,300}" Text="*" Display="Dynamic" ErrorMessage="<%$ Resources:Resource, OpisLengthErrorMessage %>"></asp:RegularExpressionValidator>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblOpis" runat="server" Text='<%# Bind("Opis") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:CommandField  UpdateText="<%$ Resources:Resource, UpdateButtonText %>" ShowEditButton="true" ValidationGroup="DodajZadatakValidationGroup" CancelText="<%$ Resources:Resource, CancelButtonText %>" />
                <asp:CommandField InsertText="<%$ Resources:Resource, InsertButtonText %>" ShowInsertButton="True" ValidationGroup="DodajZadatakValidationGroup" CancelText="<%$ Resources:Resource, CancelButtonText %>" />
            </Fields>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

            <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

            <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
        </asp:DetailsView>

        <br />
        <asp:Button ID="btnZavrsi" runat="server" Text="<%$ Resources:Resource, btnZavrsiText %>" OnClick="btnZavrsi_Click" />

    <asp:ValidationSummary ID="DodajZadatakDetailsViewValidationSummary" ValidationGroup="DodajZadatakValidationGroup" runat="server" ShowSummary="true" DisplayMode="BulletList" ForeColor="Red"/>

        <br />
    <asp:Label ID="lblErrorMessage" runat="server" ViewStateMode="Disabled"></asp:Label>

    </div>
</asp:Content>
