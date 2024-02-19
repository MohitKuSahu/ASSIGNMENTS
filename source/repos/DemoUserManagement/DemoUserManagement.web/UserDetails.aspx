<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="UserDetails.aspx.cs" Inherits="DemoUserManagement.UserDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <script type="text/javascript">
            $(document).ready(function () {
                var copyAddressCheckbox = $('#<%= copyAddressCheckbox.ClientID %>');
                var presentCountryInput = $('#<%= ddlPresentCountry.ClientID %>');
                var presentStateInput = $('#<%= ddlPresentState.ClientID %>');
                var presentCityInput = $('#<%= cityInput.ClientID %>');
                var presentAddress1Input = $('#<%= address1.ClientID %>');
                var presentAddress2Input = $('#<%= address2.ClientID %>');
                var presentPincodeInput = $('#<%= PINCODE.ClientID %>');

                var permanentCountryInput = $('#<%= ddlPermanentCountry.ClientID %>');
                var permanentStateInput = $('#<%= ddlPermanentState.ClientID %>');
                var permanentCityInput = $('#<%= cityInput_.ClientID %>');
                var permanentAddress1Input = $('#<%= address1_.ClientID %>');
                var permanentAddress2Input = $('#<%= address2_.ClientID %>');
                var permanentPincodeInput = $('#<%= PINCODE_.ClientID %>');

                copyAddressCheckbox.change(function () {
                    // Copy the values from present address to permanent address if checkbox is checked
                    if (copyAddressCheckbox.prop('checked')) {
                        permanentCountryInput.val(presentCountryInput.val());
                        permanentStateInput.val(presentStateInput.val());
                        permanentCityInput.val(presentCityInput.val());
                        permanentAddress1Input.val(presentAddress1Input.val());
                        permanentAddress2Input.val(presentAddress2Input.val());
                        permanentPincodeInput.val(presentPincodeInput.val());
                    } else {
                        // Clear permanent address if checkbox is unchecked
                        permanentCountryInput.val('');
                        permanentStateInput.val('');
                        permanentCityInput.val('');
                        permanentAddress1Input.val('');
                        permanentAddress2Input.val('');
                        permanentPincodeInput.val('');
                    }
                });
            });


        </script>


        <div id="registrationForm" class="container needs-validation">
            <center>
                <h3>REGISTRATION FORM</h3>
            </center>

            <div class="container1">
                <h3>PERSONAL DETAILS:</h3>
                <div class="row mb-5">
                    <div class="col-md-4 position-relative">
                        <asp:Label runat="server" AssociatedControlID="fname" Text="FIRST NAME:" />
                        <asp:TextBox runat="server" ID="fname" CssClass="form-control" required="required" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="fname"
                            Display="Dynamic" CssClass="invalid-tooltip" ErrorMessage="Please fill up" />
                    </div>

                    <div class="col-md-4">
                        <asp:Label runat="server" AssociatedControlID="mname" Text="MIDDLE NAME:" />
                        <asp:TextBox runat="server" ID="mname" CssClass="form-control" />
                    </div>

                    <div class="col-md-4 position-relative">
                        <asp:Label runat="server" AssociatedControlID="lname" Text="LAST NAME:" />
                        <asp:TextBox runat="server" ID="lname" CssClass="form-control" required="required" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="lname"
                            Display="Dynamic" CssClass="invalid-tooltip" ErrorMessage="Please fill up" />
                    </div>
                </div>
                <div class="row mb-5">
                    <div class="col-md-4 position-relative">
                        <asp:Label runat="server" AssociatedControlID="fathername" Text="FATHER'S NAME:" />
                        <asp:TextBox runat="server" ID="fathername" CssClass="form-control" required="required" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="fathername"
                            Display="Dynamic" CssClass="invalid-tooltip" ErrorMessage="Please fill up" />
                    </div>

                    <div class="col-md-4 position-relative">
                        <asp:Label runat="server" AssociatedControlID="mothername" Text="MOTHER'S NAME:" />
                        <asp:TextBox runat="server" ID="mothername" CssClass="form-control" required="required" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="mothername"
                            Display="Dynamic" CssClass="invalid-tooltip" ErrorMessage="Please fill up" />
                    </div>

                    <div class="col-md-4">
                        <asp:Label runat="server" AssociatedControlID="gname" Text="GUARDIAN'S NAME (if any):" />
                        <asp:TextBox runat="server" ID="gname" CssClass="form-control" />
                    </div>
                </div>
                <div class="row mb-5">
                    <div class="col-md-4 position-relative">
                        <asp:Label runat="server" AssociatedControlID="dob" Text="DATE OF BIRTH:" />
                        <asp:TextBox runat="server" ID="dob" CssClass="form-control" type="date" min="2000-01-01" required="required" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="dob"
                            Display="Dynamic" CssClass="invalid-tooltip" ErrorMessage="Please fill up" />
                    </div>

                    <div class="col-md-4 position-relative">
                        <asp:Label runat="server" AssociatedControlID="bloodGroupInput" Text="BLOOD GROUP:" />
                        <asp:TextBox runat="server" ID="bloodGroupInput" CssClass="form-control" placeholder="Select Here" list="bloodGroups" required="required" />
                        <datalist id="bloodGroups">
                            <option value="" label="Select Here"></option>
                            <option value="O+"></option>
                            <option value="O-"></option>
                            <option value="A+"></option>
                            <option value="A-"></option>
                            <option value="B+"></option>
                            <option value="B-"></option>
                            <option value="AB+"></option>
                            <option value="AB-"></option>
                        </datalist>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="bloodGroupInput"
                            Display="Dynamic" CssClass="invalid-tooltip" ErrorMessage="Please select a valid Blood group." />
                    </div>

                    <div class="col-md-4 position-relative">
                        <asp:Label runat="server" AssociatedControlID="employeeId" Text="EMPLOYEE ID:" />
                        <asp:TextBox runat="server" ID="employeeId" CssClass="form-control" type="number" required="required" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="employeeId"
                            Display="Dynamic" CssClass="invalid-tooltip" ErrorMessage="Please fill up" />
                    </div>
                </div>
                <div class="row mb-5">
                    <div class="col-md-4">

                        <asp:Label ID="Label2" runat="server" AssociatedControlID="Gender"> GENDER:</asp:Label>
                        <asp:RadioButtonList ID="Gender" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="MALE" Value="MALE" />
                            <asp:ListItem Text="FEMALE" Value="FEMALE" />
                            <asp:ListItem Text="OTHERS" Value="OTHERS" />
                        </asp:RadioButtonList>
                    </div>

                    <div class="col-md-4">

                        <asp:Label ID="lblMaritalStatus" runat="server" AssociatedControlID="Status"> STATUS:</asp:Label>
                        <asp:RadioButtonList ID="Status" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Married" Value="married" />
                            <asp:ListItem Text="Unmarried" Value="unmarried" />
                        </asp:RadioButtonList>
                    </div>

                    <div class="col-md-4">
                        <asp:Label ID="Label1" runat="server" AssociatedControlID="WorkExperience"> WORK EXPERIENCE:</asp:Label>
                        <asp:RadioButtonList ID="WorkExperience" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="0 yrs" Value="0 yrs" />
                            <asp:ListItem Text="0-5 yrs" Value="0-5 yrs" />
                            <asp:ListItem Text="6-10 yrs" Value="6-10 yrs" />
                            <asp:ListItem Text="10+ yrs" Value="10+ yrs" />
                        </asp:RadioButtonList>


                    </div>

                </div>

                <div class="row mb-5">
                    <div class="col-md-4 position-relative">
                        <asp:Label runat="server" AssociatedControlID="documentsInput" Text="DOCUMENTS VERIFY:" />
                        <asp:TextBox runat="server" ID="documentsInput" CssClass="form-control" placeholder="Select Here" list="documentTypes" required="required" />
                        <datalist id="documentTypes">
                            <option value="AADHAR CARD"></option>
                            <option value="PAN CARD"></option>
                            <option value="VOTER ID CARD"></option>
                        </datalist>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="documentsInput"
                            Display="Dynamic" CssClass="invalid-tooltip" ErrorMessage="Please select your Documents" />
                    </div>

                    <div class="col-md-4 position-relative">
                        <asp:Label runat="server" AssociatedControlID="docUpload" Text="DOC UPLOAD:" />
                        <asp:FileUpload runat="server" ID="docUpload" CssClass="form-control" required="required" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="docUpload"
                            Display="Dynamic" CssClass="invalid-tooltip" ErrorMessage="Please fill up" />
                    </div>

                    <div class="col-md-4 position-relative">
                        <asp:Label runat="server" AssociatedControlID="PHOTO" Text="UPLOAD PHOTO:" />
                        <asp:FileUpload runat="server" ID="PHOTO" CssClass="form-control" required="required" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="PHOTO"
                            Display="Dynamic" CssClass="invalid-tooltip" ErrorMessage="Please fill up" />
                    </div>
                </div>

            </div>

            <div class="container2">

                <h3>EDUCATIONAL DETAILS</h3>
                <div class="row mb-5">
                    <div class="col-md-4">
                        <asp:Label ID="Label3" runat="server" AssociatedControlID="Board10"> CLASS 10th BOARD</asp:Label>
                        <asp:RadioButtonList ID="Board10" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="CBSE" Value="CBSE" />
                            <asp:ListItem Text="ICSE" Value="ICSE" />
                            <asp:ListItem Text="OTHERS" Value="OTHERS" />
                        </asp:RadioButtonList>

                    </div>

                    <div class="col-md-4">
                        <asp:Label ID="Label4" runat="server" AssociatedControlID="Board12"> CLASS 10th BOARD</asp:Label>
                        <asp:RadioButtonList ID="Board12" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="CBSE" Value="CBSE" />
                            <asp:ListItem Text="ICSE" Value="ICSE" />
                            <asp:ListItem Text="OTHERS" Value="OTHERS" />
                        </asp:RadioButtonList>
                    </div>
                </div>

                <div class="row mb-5">
                    <div class="col-md-4 position-relative">
                        <asp:Label runat="server" AssociatedControlID="institutename10" Text="Class 10th Institute Name:" />
                        <asp:TextBox runat="server" ID="institutename10" CssClass="form-control" required="required" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="institutename10"
                            Display="Dynamic" CssClass="invalid-tooltip" ErrorMessage="Please fill up" />
                    </div>

                    <div class="col-md-4 position-relative">
                        <asp:Label runat="server" AssociatedControlID="institutename12" Text="Class 12th Institute Name:" />
                        <asp:TextBox runat="server" ID="institutename12" CssClass="form-control" required="required" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="institutename12"
                            Display="Dynamic" CssClass="invalid-tooltip" ErrorMessage="Please fill up" />
                    </div>

                    <div class="col-md-4 position-relative">
                        <asp:Label runat="server" AssociatedControlID="institutenameB_Tech" Text="B.Tech Institute Name:" />
                        <asp:TextBox runat="server" ID="institutenameB_Tech" CssClass="form-control" required="required" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="institutenameB_Tech"
                            Display="Dynamic" CssClass="invalid-tooltip" ErrorMessage="Please fill up" />
                    </div>
                </div>


                <div class="row mb-5">
                    <div class="col-md-4 position-relative">
                        <asp:Label runat="server" AssociatedControlID="percent10" Text="Class 10th Percentage:" />
                        <asp:TextBox runat="server" ID="percent10" CssClass="form-control" TextMode="Number" required="required" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="percent10"
                            Display="Dynamic" CssClass="invalid-tooltip" ErrorMessage="Please fill up properly" />
                    </div>

                    <div class="col-md-4 position-relative">
                        <asp:Label runat="server" AssociatedControlID="percent12" Text="Class 12th Percentage:" />
                        <asp:TextBox runat="server" ID="percent12" CssClass="form-control" TextMode="Number" required="required" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="percent12"
                            Display="Dynamic" CssClass="invalid-tooltip" ErrorMessage="Please fill up properly" />
                    </div>

                    <div class="col-md-4 position-relative">
                        <asp:Label runat="server" AssociatedControlID="percentB_Tech" Text="B.Tech CGPA:" />
                        <asp:TextBox runat="server" ID="percentB_Tech" CssClass="form-control" TextMode="Number" required="required" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="percentB_Tech"
                            Display="Dynamic" CssClass="invalid-tooltip" ErrorMessage="Please fill up properly" />
                    </div>
                </div>


            </div>

            <div class="container3">
                <h3>LOCATION</h3>
                <h4>PRESENT ADDRESS:</h4>
                <div class="row mb-5">
                    <div class="col-md-4 position-relative">
                        <asp:Label ID="lblddlPresentCountry" runat="server" AssociatedControlID="ddlPresentCountry">COUNTRY:</asp:Label>

                        <asp:DropDownList ID="ddlPresentCountry" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DdlPresentCountry_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlPresentCountry"
                            Display="Dynamic" CssClass="invalid-tooltip" ErrorMessage="Please select your Country" />
                    </div>

                    <div class="col-md-4 position-relative">
                        <asp:Label ID="lblddlPresentState" runat="server" AssociatedControlID="ddlPresentState"> STATE:</asp:Label>
                        <asp:DropDownList ID="ddlPresentState" runat="server" CssClass="form-control" placeholder="Select state"></asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlPresentState"
                            Display="Dynamic" CssClass="invalid-tooltip" ErrorMessage="Please select your State" />
                    </div>

                    <div class="col-md-4 position-relative">
                        <asp:Label runat="server" AssociatedControlID="cityInput" Text="CITY:" />
                        <asp:TextBox runat="server" ID="cityInput" CssClass="form-control" placeholder="Select Here" list="city" required="required" />
                        <datalist id="city">
                            <option value="" label="Select Here">
                            <option value="NEW DELHI">
                            <option value="ISLAMABAD">
                            <option value="SHINJUKU">
                            <option value="SHIBUYA">
                            <option value="OTHERS">
                        </datalist>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="cityInput"
                            Display="Dynamic" CssClass="invalid-tooltip" ErrorMessage="Please select your City" />
                    </div>

                </div>

                <div class="row mb-5">
                    <div class="col-md-4 position-relative">
                        <label for="address1" class="form-label">ADDRESS LINE 1:</label>
                        <asp:TextBox runat="server" ID="address1" CssClass="form-control" name="PRESENT ADDRESS LINE 1" Required="required"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="address1"
                            Display="Dynamic" CssClass="invalid-tooltip" ErrorMessage="Please select address" />
                    </div>
                    <div class="col-md-4 position-relative">
                        <label for="address2" class="form-label">ADDRESS LINE 2:</label>
                        <asp:TextBox runat="server" ID="address2" CssClass="form-control" name="PRESENT ADDRESS LINE 2" Required="required"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="address2"
                            Display="Dynamic" CssClass="invalid-tooltip" ErrorMessage="Please select address" />
                    </div>
                    <div class="col-md-4 position-relative">
                        <label for="PINCODE" class="form-label">PINCODE</label>
                        <asp:TextBox runat="server" ID="PINCODE" CssClass="form-control" name="PRESENT PINCODE" Required="required" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="PINCODE"
                            Display="Dynamic" CssClass="invalid-tooltip" ErrorMessage="Please select your PINCODE" />
                    </div>
                </div>


                <div style="margin-bottom: 35px;">
                    <asp:CheckBox runat="server" ID="copyAddressCheckbox" CssClass="checkbox" BorderStyle="None" />
                    <asp:Label runat="server" AssociatedControlID="copyAddressCheckbox" CssClass="form-check-label">
                                 Same as Present Address
                    </asp:Label>
                </div>

                <h3>LOCATION</h3>
                <h4>PERMANENT ADDRESS:</h4>
                <div class="row mb-5">
                    <div class="col-md-4 position-relative">
                        <asp:Label ID="lblddlPermanentCountry" runat="server" AssociatedControlID="ddlPermanentCountry"> COUNTRY:</asp:Label>

                        <asp:DropDownList ID="ddlPermanentCountry" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DdlPermanentCountry_SelectedIndexChanged">
                        </asp:DropDownList>

                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlPermanentCountry"
                            Display="Dynamic" CssClass="invalid-tooltip" ErrorMessage="Please select your Country" />
                    </div>

                    <div class="col-md-4 position-relative">
                        <asp:Label ID="lblddlPermanentState" runat="server" AssociatedControlID="ddlPermanentState"> STATE:</asp:Label>

                        <asp:DropDownList ID="ddlPermanentState" runat="server" CssClass="form-control" placeholder="Select state"></asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlPermanentState"
                            Display="Dynamic" CssClass="invalid-tooltip" ErrorMessage="Please select your State" />
                    </div>

                    <div class="col-md-4 position-relative">
                        <asp:Label runat="server" AssociatedControlID="cityInput_" Text="CITY:" />
                        <asp:TextBox runat="server" ID="cityInput_" CssClass="form-control" placeholder="Select Here" list="city_" required="required" />
                        <datalist id="city_">
                            <option value="NEW DELHI">
                            <option value="ISLAMABAD">
                            <option value="SHINJUKU">
                            <option value="SHIBUYA">
                            <option value="OTHERS">
                        </datalist>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="cityInput_"
                            Display="Dynamic" CssClass="invalid-tooltip" ErrorMessage="Please select your City" />
                    </div>

                </div>

                <div class="row mb-5">
                    <div class="col-md-4 position-relative">
                        <label for="address1_" class="form-label">ADDRESS LINE 1:</label>
                        <asp:TextBox runat="server" ID="address1_" CssClass="form-control" name="PERMANENT ADDRESS LINE 1" Required="required"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="address1_"
                            Display="Dynamic" CssClass="invalid-tooltip" ErrorMessage="Please select address" />
                    </div>
                    <div class="col-md-4 position-relative">
                        <label for="address2_" class="form-label">ADDRESS LINE 2:</label>
                        <asp:TextBox runat="server" ID="address2_" CssClass="form-control" name="PERMANENT ADDRESS LINE 2" Required="required"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="address2_"
                            Display="Dynamic" CssClass="invalid-tooltip" ErrorMessage="Please select address" />
                    </div>
                    <div class="col-md-4 position-relative">
                        <label for="PINCODE_" class="form-label">PINCODE</label>
                        <asp:TextBox runat="server" ID="PINCODE_" CssClass="form-control" name="PERMANENT PINCODE" Required="required" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="PINCODE_"
                            Display="Dynamic" CssClass="invalid-tooltip" ErrorMessage="Please select your PINCODE" />
                    </div>
                </div>
            </div>

            <div class="container4">
                <h3>CONTACTS</h3>
                <div class="row mb-5">
                    <div class="col-md-6 position-relative">
                        <asp:Label runat="server" AssociatedControlID="phn" CssClass="form-label">MOBILE NUMBER:</asp:Label>
                        <asp:TextBox runat="server" ID="phn" CssClass="form-control" TextMode="Phone" Pattern="[1-9]{1}[0-9]{9}" Name="MOBILE NUMBER" Required="true"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="phn"
                            Display="Dynamic" CssClass="invalid-tooltip" ErrorMessage="  Please choose a valid phone number." />
                    </div>

                    <div class="col-md-6 ">
                        <asp:Label runat="server" AssociatedControlID="altn" CssClass="form-label">ALTERNATE NUMBER:</asp:Label>
                        <asp:TextBox runat="server" ID="altn" CssClass="form-control" TextMode="Phone" Pattern="[1-9]{1}[0-9]{9}" Name="ALTERNATE NUMBER"></asp:TextBox>
                    </div>
                </div>
                <div class="row mb-5">
                    <div class="col-md-6 position-relative">
                        <asp:Label runat="server" AssociatedControlID="email" CssClass="form-label">EMAIL:</asp:Label>
                        <asp:TextBox runat="server" ID="email" CssClass="form-control" TextMode="Email" Name="EMAIL" Required="true"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="email"
                            Display="Dynamic" CssClass="invalid-tooltip" ErrorMessage="  Please choose a valid email." />
                    </div>


                    <div class="col-md-6 position-relative">
                        <asp:Label runat="server" AssociatedControlID="password" CssClass="form-label"> PASSWORD:</asp:Label>
                        <asp:TextBox runat="server" ID="password" CssClass="form-control" Name="PASSWORD" Required="true"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="password"
                            Display="Dynamic" CssClass="invalid-tooltip" ErrorMessage="  Please choose a valid password." />

                    </div>
                </div>

            </div>




            <div class="d-flex justify-content-between">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-success" OnClick="BtnSubmit_Click" />
                <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-danger" OnClick="BtnReset_Click" />
            </div>










        </div>
    </main>

</asp:Content>


