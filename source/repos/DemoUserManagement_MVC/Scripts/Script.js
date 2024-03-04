$(document).ready(function () {
    var copyAddressCheckbox = $('#copyAddressCheckbox');
    var presentCountryInput = $('#ddlPresentCountry');
    var presentStateInput = $('#ddlPresentState');
    var presentCityInput = $('#cityInput');
    var presentAddress1Input = $('#address1');
    var presentAddress2Input = $('#address2');
    var presentPincodeInput = $('#PINCODE');
    var presentPincodeInput = $('#PINCODE');

    var permanentCountryInput = $('#ddlPermanentCountry');
    var permanentStateInput = $('#ddlPermanentState');
    var permanentCityInput = $('#cityInput1');
    var permanentAddress1Input = $('#address1_');
    var permanentAddress2Input = $('#address2_');
    var permanentPincodeInput = $('#PINCODE_');


    copyAddressCheckbox.change(function () {

        if (copyAddressCheckbox.prop('checked')) {
            permanentCountryInput.val(presentCountryInput.val());
            permanentStateInput.val(presentStateInput.val());
            permanentCityInput.val(presentCityInput.val());
            permanentAddress1Input.val(presentAddress1Input.val());
            permanentAddress2Input.val(presentAddress2Input.val());
            permanentPincodeInput.val(presentPincodeInput.val());
        } else {

            permanentCountryInput.val('');
            permanentStateInput.val('');
            permanentCityInput.val('');
            permanentAddress1Input.val('');
            permanentAddress2Input.val('');
            permanentPincodeInput.val('');
        }
    });


    document.addEventListener('DOMContentLoaded', function () {
        var select = document.getElementById("BloodGroup");
        if (select != null) {
            select.options[0].disabled = true;
        }
    });

    document.addEventListener('DOMContentLoaded', function () {
        var select = document.getElementById("Documents");
        if (select != null) {
            select.options[0].disabled = true;
        }
    });

    $.ajax({
        type: "GET",
        url: '@Url.Action("GetCountries", "UserDetails2")',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var ddlCountries = $("#ddlPresentCountry");
            var ddlPermanentCountry = $("#ddlPermanentCountry");

            $.each(data, function (key, value) {
                ddlCountries.append($("<option></option>").text(value).val(value));
                ddlPermanentCountry.append($("<option></option>").text(value).val(value));
            });
        },
        error: function (error) {
            console.log("Error:", error);
        }
    });
});

function DdlPresentCountry_SelectedIndexChanged() {
    var selectedCountry = $("#ddlPresentCountry").val();
    console.log("Selected Country: " + selectedCountry);
    populateStates(selectedCountry, "#ddlPresentState");
}

function DdlPermanentCountry_SelectedIndexChanged() {
    var selectedCountry = $("#ddlPermanentCountry").val();
    console.log("Selected Country: " + selectedCountry);
    populateStates(selectedCountry, "#ddlPermanentState");
}

function populateStates(selectedCountry, stateDropdownId) {
    $.ajax({
        type: "GET",
        url: '@Url.Action("GetStatesForCountry", "UserDetails2")',
        data: { selectedCountry: selectedCountry },
        success: function (data) {
            var ddlStates = $(stateDropdownId);
            ddlStates.empty();
            $.each(data, function (key, value) {
                ddlStates.append($("<option></option>").val(value).html(value));
            });
        },
        error: function (error) {
            console.log("Error:", error);
        }
    });
}

(function () {
    'use strict';


    var forms = document.querySelectorAll('.needs-validation');


    Array.prototype.slice.call(forms)
        .forEach(function (form) {
            form.addEventListener('submit', function (event) {
                if (!form.checkValidity()) {
                    event.preventDefault();
                    event.stopPropagation();
                }
                else {
                    event.preventDefault();
                    SubmitFormData();
                }
                form.classList.add('was-validated');
            }, false);
        });
})();

function SubmitFormData() {
    var userDetails = {
        User: {
            FirstName: $("#firstName").val(),
            MiddleName: $("#middleName").val(),
            LastName: $("#lastName").val(),
            FatherName: $("#fatherName").val(),
            MotherName: $("#motherName").val(),
            GuardianName: $("#gname").val(),
            DOB: $("#DateofBirth").val(),
            Gender: $("input[name='GENDER']:checked").val(),
            BloodGroup: $("#bloodGroupInput").val(),
            Status: $("input[name='STATUS']:checked").val(),
            WorkExperience: $("input[name='WORKEXPERIENCE']:checked").val(),
            Documents: $("#documentsInput").val(),
            Board10th: $("input[name='Board10']:checked").val(),
            Board12th: $("input[name='Board12']:checked").val(),
            Institute10th: $("#institutename10").val(),
            Institute12th: $("#institutename12").val(),
            InstituteBTECH: $("#institutenameB.Tech").val(),
            Percentage10th: $("#percent10").val(),
            Percentage12th: $("#percent12").val(),
            PercentageBTECH: $("#percentB.Tech").val(),
            Email: $("#email").val(),
            Password: $("#password").val(),
            PhoneNumber: $("#phn").val(),
            AlternatePhoneNumber: $("#altn").val(),
            FileName: $("#docUpload").val(),
            Profile: $("PHOTO").val()

        },
        PresentAddress: {
            Address: $("#address1").val(),
        },
        PresentCountry: {
            CountryName: $("#ddlPresentCountry").val(),
        },
        PresentState: {
            StateName: $("#ddlPresentState").val(),
        },
        PermanentAddress: {
            Address: $("#address1_").val(),
        },
        PermanentCountry: {
            CountryName: $("#ddlPermanentCountry").val(),
        },
        PermanentState: {
            StateName: $("#ddlPermanentState").val(),
        },

    };

    var formData = new FormData();
    formData.append('file1', document.getElementById('docUpload').files[0]);
    formData.append('file2', document.getElementById('PHOTO').files[0]);

    $.ajax({
        type: "POST",
        url: '@Url.Action("SaveDetails", "UserDetails2")',
        data: JSON.stringify({
            userDetails: userDetails,
            formData: formData
        }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {

        },
        error: function (error) {
            console.log("Error:", error);
        }
    });




}