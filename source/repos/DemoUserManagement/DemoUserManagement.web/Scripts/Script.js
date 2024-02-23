


$(document).ready(function () {


    showButton(true);
    const queryString = window.location.search;
    const url = new URLSearchParams(queryString);
    userId = url.get("UserId");

    if (userId) {
        showButton(false);
        loadUserDetails(userId);
    }

    $.ajax({
        type: "POST",
        url: "UserDetails2.aspx/GetCountries",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var ddlCountries = $("#ddlPresentCountry");
            var ddlPermanentCountry = $("#ddlPermanentCountry");

            ddlCountries.empty();
            $.each(data.d, function (key, value) {
                ddlCountries.append($("<option></option>").val(value).html(value));
                ddlPermanentCountry.append($("<option></option>").val(value).html(value));
            });
        },
        error: function (error) {
            console.log("Error:", error);
        }
    });



    $("#btnSubmit").on("click", function () {
        var lblEmailError = document.getElementById("lblEmailError");
        if (lblEmailError.textContent === "Email Already exists.") {
            alert("Email already exists. Please choose a different email.");
            return;
        }
        SubmitFormData();
    });

    $("#btnUpdate").on("click", function () {
        var lblEmailError = document.getElementById("lblEmailError");
        if (lblEmailError.textContent === "Email Already exists.") {
            alert("Email already exists. Please choose a different email.");
            return;
        }
        updateFormData();
    });
  
    $("#ddlPresentCountry").change(function () {
        var selectedCountry = $(this).val();
        populateStates(selectedCountry, "#ddlPresentState");
    });

   
    $("#ddlPermanentCountry").change(function () {
        var selectedCountry = $(this).val();
        populateStates(selectedCountry, "#ddlPermanentState");
    });


    $(window).on("click", function (event) {
        if ($(event.target).is("#displayError")) {
            $("#displayError").css("display", "none");
        }
    });

    var copyAddressCheckbox = document.getElementById("<%= copyAddressCheckbox.ClientID %>");

    var presentCountryInput = document.getElementById("<%= ddlPresentCountry.ClientID %>");
    var presentStateInput = document.getElementById("<%= ddlPresentState.ClientID %>");
    var presentCityInput = document.getElementById("<%= cityInput.ClientID %>");
    var presentAddress1Input = document.getElementById("<%= address1.ClientID %>");
    var presentAddress2Input = document.getElementById("<%= address2.ClientID %>");
    var presentPincodeInput = document.getElementById("<%= PINCODE.ClientID %>");

    var permanentCountryInput = document.getElementById("<%= ddlPermanentCountry.ClientID %>");
    var permanentStateInput = document.getElementById("<%= ddlPermanentState.ClientID %>");
    var permanentCityInput = document.getElementById("<%= cityInput_.ClientID %>");
    var permanentAddress1Input = document.getElementById("<%= address1_.ClientID %>");
    var permanentAddress2Input = document.getElementById("<%= address2_.ClientID %>");
    var permanentPincodeInput = document.getElementById("<%= PINCODE_.ClientID %>");


    //copyAddressCheckbox.change(function () {
    //    if (copyAddressCheckbox.prop('checked')) {
    //        permanentCountryInput.val(presentCountryInput.val());
    //        permanentStateInput.val(presentStateInput.val());
    //        permanentCityInput.val(presentCityInput.val());
    //        permanentAddress1Input.val(presentAddress1Input.val());
    //        permanentAddress2Input.val(presentAddress2Input.val());
    //        permanentPincodeInput.val(presentPincodeInput.val());
    //    } else {
    //        permanentCountryInput.val('');
    //        permanentStateInput.val('');
    //        permanentCityInput.val('');
    //        permanentAddress1Input.val('');
    //        permanentAddress2Input.val('');
    //        permanentPincodeInput.val('');
    //    }
    //});
});

function populateStates(selectedCountry, stateDropdownId) {
    $.ajax({
        type: "POST",
        url: "UserDetails2.aspx/GetStatesForCountry",
        data: JSON.stringify({ selectedCountry: selectedCountry }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var ddlStates = $(stateDropdownId);
            ddlStates.empty();
            $.each(data.d, function (key, value) {
                ddlStates.append($("<option></option>").val(value).html(value));
            });
        },
        error: function (error) {
            console.log("Error:", error);
        }
    });

}


function showButton(button) {
    var btnSubmit = document.getElementById("btnSubmit");
    var btnUpdate = document.getElementById("btnUpdate");
    if (button) {
        btnSubmit.style.display = "block";
        btnUpdate.style.display = "none";
    } else {
        btnSubmit.style.display = "none";
        btnUpdate.style.display = "block";
    }
}

function loadUserDetails(userId) {
    $.ajax({
        type: "POST",
        url: "UserDetails2.aspx/PopulateValuesIntoForm",
        data: JSON.stringify({ userId: userId }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log(response);
        },
        error: function (xhr, status, error) {
            console.error("Error loading user details:", error);
        }
    });
}




function SubmitFormData() {
    var formData = {
        fname: $("#fname").val(),
        mname: $("#mname").val(),
        lname: $("#lname").val(),
        fathername: $("#fathername").val(),
        mothername: $("#mothername").val(),
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
        url: "UserDetails2.aspx/SubmitFormData",
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

function updateFormData() {

    var formData = {
        fname: $("#fname").val(),
        mname: $("#mname").val(),
        lname: $("#lname").val(),
        fathername: $("#fathername").val(),
        mothername: $("#mothername").val(),
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
    addressesList.push(permanentAddress);
    addressesList.push(presentAddress);
    $.ajax({
        url: 'UserDetails2.aspx/UpdateFormData',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({
            user: formData,
            Address: addressesList
        }),
        success: function (response) {
        },
        error: function (xhr, status, error) {
            console.error('Failed to send user details:', error);
        }
    });
}

function checkEmailAvailability() {
    document.getElementById("email").addEventListener("focusout", function () {
        var email = document.getElementById("email").value;

        var xhr = new XMLHttpRequest();
        xhr.onreadystatechange = function () {
            if (xhr.readyState === XMLHttpRequest.DONE) {
                if (xhr.status === 200) {
                    var response = JSON.parse(xhr.responseText);
                    if (response && response.d) {
                        document.getElementById("lblEmailError").textContent = "Email Already exists.";
                        document.getElementById("lblEmailError").style.color = "red";
                    } else {
                        document.getElementById("lblEmailError").textContent = "Valid Email.";
                        document.getElementById("lblEmailError").style.color = "green";
                    }
                } else {
                    console.error(xhr.responseText);
                    document.getElementById("lblEmailError").textContent = "Error checking email.";
                }
            }

        };
        xhr.open("POST", "UserDetails2.aspx/EmailExists", true);
        xhr.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
        xhr.send(JSON.stringify({ email: email }));
        checkUserEmail(email);
    });
}

function checkUserEmail(email) {
    const queryString = window.location.search;
    const url = new URLSearchParams(queryString);
    let userId = url.get("UserId");
    $.ajax({
        type: "POST",
        url: "UserDetails2.aspx/CheckUserEmail",
        data: JSON.stringify({ userId: userId, email: email }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d) {
                document.getElementById("lblEmailError").textContent = "Valid Email.";
                document.getElementById("lblEmailError").style.color = "green";
            }

        },
        error: function (xhr, status, error) {
            console.error("Error checking email:", error);
        }
    });
}











