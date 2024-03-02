

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
        url: '@Url.Action("GetStatesForCountry", "Home")',
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
                form.classList.add('was-validated');
            }, false);
        });
})();

function SubmitFormData() {
    var formData = {
        fname: $("#firstName").val(),
        mname: $("#middleName").val(),
        lname: $("#lastName").val(),
        fathername: $("#fatherName").val(),
        mothername: $("#motherName").val(),
        gname: $("#gname").val(),
        dob: $("#DateofBirth").val(),
        gender: $("input[name='GENDER']:checked").val(),
        bloodGroupInput: $("#bloodGroupInput").val(),
        status: $("input[name='STATUS']:checked").val(),
        workExperience: $("input[name='WORKEXPERIENCE']:checked").val(),
        documentsInput: $("#documentsInput").val(),
        board10: $("input[name='Board10']:checked").val(),
        board12: $("input[name='Board12']:checked").val(),
        institutename10: $("#institutename10").val(),
        institutename10: $("#institutename12").val(),
        institutenameB_Tech: $("#institutenameB.Tech").val(),
        percent10: $("#percent10").val(),
        percent12: $("#percent12").val(),
        percentB_Tech: $("#percentB.Tech").val(),
        email: $("#email").val(),
        password: $("#password").val(),
        phn: $("#phn").val(),
        altn: $("#altn").val(),
    };
    var PermanentAddress = {
        ddlPermanentCountry: $("#ddlPermanentCountry").val(),
        ddlPermanentState: $("#ddlPermanentState").val(),
        address1_: $("#address1_").val(),
        type: 1,
    };
    var PresentAddress = {
        ddlPresentCountry: $("#ddlPresentCountry").val(),
        ddlPresentState: $("#ddlPresentState").val(),
        address1: $("#address1").val(),
        type: 0,
    }

    var addressesList = [];
    addressesList.push(PermanentAddress);
    addressesList.push(PresentAddress);


    $.ajax({
        type: "POST",
        url: '@Url.Action("SaveDetails", "UserDetails2")',
        data: JSON.stringify({
            user: formData,
            Address: addressesList
        }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            console.log(JSON.stringify({
                user: formData,
                Address: addressesList
            }));
        },
        error: function (error) {
            console.log("Error:", error);
        }
    });


}
