
let firstname = $("#fname");
let lastname = $("#lname");
let dateOfBirth = document.getElementById("Date of Birth");
let email = $("#email");
let address1 = $("#addr1");
let address2 = $("#addr2");
let mobileno = $("#phn");
let aadhar = $("#aadhar");
let pan = $("#pan");
let school = $(".school"); 
let address = $(".address"); 
let percent = $(".percent"); 
let country = $("#COUNTRY");
let state = $("#STATE");



const form = $("#myForm");
function validateInput() {
    var content=[];
    returnval= true;

     content.push(validateField(firstname, "First Name cannot be empty"));

     content.push(validateField(lastname, "Last Name cannot be empty"));

    
     if (dateOfBirth.value.trim() === "") {
        onError(dateOfBirth, "Date of Birth cannot be empty");
          returnval=false;
    } else {
        onSuccess(dateOfBirth);
    }

   content.push(validateAadhar(aadhar, "aadhar no cannot be empty", "AADHAR no should contain 10 digits"));

   content.push(validateField(pan, "PAN number cannot be empty"));

    for (let index = 0; index < school.length; index++) {
       content.push(validateField(school[index], "School/college can't be empty"));
    }

   content.push(validateField(country, "Country cannot be empty"));

   content.push(validateField(state, "State cannot be empty"));




    for (let index = 0; index < percent.length; index++) {
       content.push(validatePercent(percent[index], "Percent can't be empty", "Percent no is not valid"));
    }

   content.push(validateEmail(email, "Email cannot be empty", "Email is not valid"));

    for (let index = 0; index < address.length; index++) {
       content.push(validateField(address[index], "Address can't be empty"));
    }

   content.push(validateMobileNo(mobileno, "Mobile no cannot be empty", "Mobile no should contain 10 digits"));

   content.push(validateCheckbox("checkbox1", "This needed to be checked"));

   content.push(validateCheckbox("checkbox2", "This needed to be checked"));
    
   var k = 0;
   var ele = document.getElementsByName("GENDER");
   for (i = 0; i < ele.length; i++) {
       if (ele[i].checked) {
           onSuccess(ele[i]);
           k++;
       }
   }
   if (k == 0) {
       onError(GENDER, " Gender needed to be checked");
       returnval = false;
   }


   var k = 0;
   var ele = document.getElementsByName("STATUS");
   for (i = 0; i < ele.length; i++) {
       if (ele[i].checked) {
           onSuccess(ele[i]);
           k++;
       }
   }
   if (k == 0) {
       onError(STATUS, "Status needed to be checked");
       returnval = false;
   }

   var k = 0;
   var ele = document.getElementsByName("Board10");
   for (i = 0; i < ele.length; i++) {
       if (ele[i].checked) {
           onSuccess(ele[i]);
           k++;
       }
   }
   if (k == 0) {
       onError(Board10, " 10th Board needed to be checked");
       returnval = false;
   }


   var k = 0;
   var ele = document.getElementsByName("Board12");
   for (i = 0; i < ele.length; i++) {
       if (ele[i].checked) {
           onSuccess(ele[i]);
           k++;
       }
   }
   if (k == 0) {
       onError(Board12, " 12th Board needed to be checked");
       returnval = false;
   }


   
    if (returnval&&!content.find(Element=> Element == "false")) {
        openModal();
    }
}



// popup about input values
function openModal() {
    var inputValues = {};

    $('input').each(function() {
        inputValues[$(this).attr('name')] = $(this).val();
    });


    localStorage.setItem('inputValues', JSON.stringify(inputValues));

    $('#inputValues').html(formatInputValues(inputValues));

    $('#myModal').css('display', 'block');
    $('#overlay').css('display', 'block');
}

function closeModal() {
    $('#myModal').css('display', 'none');
    $('#overlay').css('display', 'none');
}


function formatInputValues(inputValues) {

    var formattedValues = '';
     for (var key in inputValues) {
    if (key == "GENDER" || key == "Board10" || key == "Board12" || key == "STATUS") {
        var ele = $('[name="' + key + '"]:checked');
        if (ele.length > 0) {
            formattedValues += key + ': ' + ele.val() + '<br>' + '<hr>';
        }
    } else if (key != "checkbox1") {
        formattedValues += key + ': ' + inputValues[key] + '<br>' + '<hr>';
    }
}
return formattedValues;
}

//validation msg

function onSuccess(input) {
    var parent = $(input).parent();
    var messageEle = parent.find("small");
    messageEle.css({"visibility":"hidden","color":"green"});
    parent.removeClass("error").addClass("success");
}

function onError(input, message) {
    var parent = $(input).parent();
    var messageEle = parent.find("small");
    messageEle.css({"visibility": "visible", "color": "red"}).text(message);
    parent.addClass("error").removeClass("success");
}

function validateEmail(emailField, emptyErrorMessage, formatErrorMessage) {
    if (emailField.val().trim() === "") {
        onError(emailField, emptyErrorMessage);
        return false;
    } else {
        if (!isValidEmail(emailField.val().trim())) {
            onError(emailField, formatErrorMessage);
            return  false;
        } else {
            onSuccess(emailField);
            return  true;
        }
    }
}

function validateMobileNo(mobileNoField, emptyErrorMessage, formatErrorMessage) {
    if (mobileNoField.val().trim() === "") {
        onError(mobileNoField, emptyErrorMessage);
        return false;
    } else {
        if (!isValidmobileno(mobileNoField.val().trim())) {
            onError(mobileNoField, formatErrorMessage);
            return false;
        } else {
            onSuccess(mobileNoField);
            return true;
        }
    }
}


function validatePercent(percentField, emptyErrorMessage, formatErrorMessage) {
    if ($(percentField).val().trim() === "") {
        onError(percentField, emptyErrorMessage);
        return false;
    } else {
        if (!($(percentField).val().trim() >= 0 && $(percentField).val().trim() <= 100)) {
            onError(percentField, formatErrorMessage);
            return false;
        } else {
            onSuccess(percentField);
            return true;
        }
    }
}

function validateField(field, errorMessage) {
    if ($(field).val().trim() === "") {
        onError(field, errorMessage);
        return false;
    } else {
        onSuccess(field);
        return true;
    }
}


function validateAadhar(aadharField, emptyErrorMessage, formatErrorMessage) {
    if (aadharField.val().trim() === "") {
        onError(aadharField, emptyErrorMessage);
        return false;
    } else {
        if (!isValidaadhar(aadharField.val().trim())) {
            onError(aadharField, formatErrorMessage);
            return false;
        } else {
            onSuccess(aadharField);
            return true;
        }
    }
}


function validateCheckbox(checkboxName, errorMessage) {
    var che = $("input[name='" + checkboxName + "']");
    che.each(function (index, element) {
        if (!$(element).prop("checked")) {
            onError($(element), errorMessage);
            return false;
        } else {
            onSuccess($(element));
            return true;
        }
    });
}





function isValidEmail(email) {
    return /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(email);
}
function isValidmobileno(mobileno) {
    return /^\d{10}$/.test(mobileno);
}
function isValidaadhar(aadhar) {
    return /^\d{12}$/.test(aadhar);
}
// popup after submitting
const openModalButtons = $('[data-modal-target]')
const overlay = $('#overlays')

openModalButtons.each(function() {
    $(this).click(function() {
        openModa(modal);
    });
});


function openModa(modal) {
    if (modal == null) return
    $(modal).addClass('active');
    $(overlays).addClass('active');
}
   









