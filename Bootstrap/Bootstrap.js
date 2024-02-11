
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
                    openModal();
                }

                form.classList.add('was-validated');
            }, false);
        });
})();



$(document).ready(function () {
    
    var copyAddressCheckbox = $('#copyAddressCheckbox');
    var presentCountryInput = $('#countryInput');
    var presentStateInput = $('#stateInput');
    var presentCityInput = $('#cityInput');
    var presentAddress1Input = $('#address1');
    var presentAddress2Input = $('#address2');
    var presentPincodeInput = $('#PINCODE');

    var permanentCountryInput = $('#countryInput1');
    var permanentStateInput = $('#stateInput1');
    var permanentCityInput = $('#cityInput1');
    var permanentAddress1Input = $('#address1_');
    var permanentAddress2Input = $('#address2_');
    var permanentPincodeInput = $('#PINCODE_');

   
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


function openModal() {
    var inputs = document.querySelectorAll('input');
    var inputValues = {};

    inputs.forEach(function (input) {
        inputValues[input.name] = input.value;
    });


    localStorage.setItem('inputValues', JSON.stringify(inputValues));


    document.getElementById('inputValues').innerHTML = formatInputValues(inputValues);
    document.getElementById('myModal').style.display = 'block';
    document.getElementById('overlay').style.display = 'block';
}

function closeModal() {
    document.getElementById('myModal').style.display = 'none';
    document.getElementById('overlay').style.display = 'none';
}


function formatInputValues(inputValues) {

    var formattedValues = '';
    for (var key in inputValues) {

        if (key == "GENDER" || key == "Board10" || key == "Board12" || key == "STATUS" || key == "WORK EXPERIENCE") {
            var ele = document.getElementsByName(key);

            for (i = 0; i < ele.length; i++) {
                if (ele[i].checked)
                    formattedValues += key + ': ' + ele[i].value + '<br>' + '<hr>';
            }
        }
        else if (key != "checkbox") {
            formattedValues += key + ': ' + inputValues[key] + '<br>' + '<hr>';
        }
    }
    return formattedValues;
}
