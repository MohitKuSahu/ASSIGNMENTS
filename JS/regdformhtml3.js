
let firstname = document.getElementById("fname");
let lastname = document.getElementById("lname");
let dateOfBirth=document.getElementById("Date of Birth");
let email = document.getElementById("email");
let address1 = document.getElementById("addr1");
let address2 = document.getElementById("addr2");
let mobileno = document.getElementById("phn");
let aadhar = document.getElementById("aadhar");
let pan = document.getElementById("pan");
let school = document.getElementsByClassName("school");
let address = document.getElementsByClassName("address");
let percent = document.getElementsByClassName("percent");
let country=document.getElementById("COUNTRY");
let state=document.getElementById("STATE");



// about validation
function validateInput() {
    var returnval = true;

    if (firstname.value.trim() === "") {
        onError(firstname, "First Name cannot be empty");
        returnval = false;
    } else {
        onSuccess(firstname);
    }

    if (lastname.value.trim() === "") {
        onError(lastname, "Last Name cannot be empty");
        returnval = false;
    } else {
        onSuccess(lastname);
    }
     
    if (dateOfBirth.value.trim() === "") {
        onError(dateOfBirth, "Date of Birth cannot be empty");
        returnval = false;
    } else {
        onSuccess(dateOfBirth);
    }


    if (aadhar.value.trim() === "") {
        onError(aadhar, "aadhar no  cannot be empty");
        returnval = false;
    } else {
        if (!isValidaadhar(aadhar.value.trim())) {
            onError(aadhar, "AADHAR no should contain 10 digits");
            returnval = false;
        } else {
            onSuccess(aadhar);
        }
    }


    if (pan.value.trim() === "") {
        onError(pan, "PAN number cannot be empty");
        returnval = false;
    } else {
        onSuccess(pan);
    }

    for (let index = 0; index < school.length; index++) {
        if (school[index].value.trim() == "") {
            onError(school[index], "School/college can't be empty");
            returnval = false;
        }
        else {
            onSuccess(school[index]);
        }
    }

     
  
    if (country.value.trim() === "") {
            onError(country, "Country cannot be empty");
            returnval = false;
        } else {
            onSuccess(country);
        }

    
        if (state.value.trim() === "") {
            onError(state, "State cannot be empty");
            returnval = false;
        } else {
            onSuccess(state);
        }
    
        
        var k=0;
        var ele = document.getElementsByName("GENDER");
        for (i = 0; i < ele.length; i++) {
            if (ele[i].checked){
                onSuccess(ele[i]);
            k++;
            }
        }
        if(k==0){
        onError(GENDER, " Gender needed to be checked");
        returnval=false;
        }


        var k=0;
        var ele = document.getElementsByName("STATUS");
        for (i = 0; i < ele.length; i++) {
            if (ele[i].checked){
                onSuccess(ele[i]);
                  k++;
            }
        }
        if(k==0){
        onError(STATUS,"Status needed to be checked");
        returnval=false;
        }

        var k=0;
        var ele = document.getElementsByName("Board10");
        for (i = 0; i < ele.length; i++) {
            if (ele[i].checked){
                onSuccess(ele[i]);
               k++;
            }
        }
        if(k==0){
        onError(Board10, " 10th Board needed to be checked");
        returnval=false;
        }


        var k=0;
        var ele = document.getElementsByName("Board12");
        for (i = 0; i < ele.length; i++) {
            if (ele[i].checked){
                onSuccess(ele[i]);
            k++;
            }
        }
        if(k==0){
        onError(Board12, " 12th Board needed to be checked");
        returnval=false;
        }



       var che=document.getElementsByName("checkbox");
        for (index = 0; index < che.length; index++) {
             if (!che[index].checked) {
                onError(che[index],"This needed to be checked");
                returnval=false;
             }
             else{
                onSuccess(che[index]);
             }
        }
        





    for (let index = 0; index < percent.length; index++) {
        if (percent[index].value.trim() == "") {
            onError(percent[index], "Percent can't be empty");
            returnval = false;
        }
        else {
            if (!(percent[index].value.trim() >= 0 && percent[index].value.trim() <= 100)) {
                onError(percent[index], "Percent no is not valid");
                returnval = false;
            }
            else {
                onSuccess(percent[index]);
            }
        }
    }

    if (email.value.trim() === "") {
        onError(email, "Email cannot be empty");
        returnval = false;
    } else {
        if (!isValidEmail(email.value.trim())) {
            onError(email, "Email is not valid");
            returnval = false;
        } else {
            onSuccess(email);
        }
    }


    for (let index = 0; index < address.length; index++) {
        if (address[index].value.trim() == "") {
            onError(address[index], "Address can't be empty");
            returnval = false;
        }
        else {
            onSuccess(address[index]);
        }
    }





    if (mobileno.value.trim() === "") {
        onError(mobileno, "Mobile no cannot be empty");
        returnval = false;
    } else {
        if (!isValidmobileno(mobileno.value.trim())) {
            onError(mobileno, "Mobile no should contain 10 digits");
            returnval = false;
        } else {
            onSuccess(mobileno);
        }

    }



    if (returnval) {
       openModal();
    }
}

// popup about input values
function openModal() {
    var inputs = document.querySelectorAll('input');
    var inputValues = {};

    inputs.forEach(function(input) {
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

      if(key=="GENDER"||key=="Board10"||key=="Board12"||key=="STATUS"){
        var ele = document.getElementsByName(key);
 
        for (i = 0; i < ele.length; i++) {
            if (ele[i].checked)
            formattedValues += key + ': ' + ele[i].value + '<br>'+'<hr>';
        }
      }
      else if(key!="checkbox"){
      formattedValues += key + ': ' + inputValues[key] + '<br>'+'<hr>';
      }
    }
    return formattedValues;
  }





// popup after submitting
const openModalButtons = document.querySelectorAll('[data-modal-target]')
const overlay = document.getElementById('overlays')

openModalButtons.forEach(button => {
  button.addEventListener('click', () => {
    openModa(modal)
  })
})


function openModa(modal) {
  if (modal == null) return
  modal.classList.add('active')
  overlays.classList.add('active')
}










//validation msg

function onSuccess(input) {
    let parent = input.parentElement;
    let messageEle = parent.querySelector("small");
    messageEle.style.visibility = "hidden";
    parent.classList.remove("error");
    parent.classList.add("success");
}
function onError(input, message) {
    let parent = input.parentElement;
    let messageEle = parent.querySelector("small");
    messageEle.style.visibility = "visible";
    messageEle.innerText = message;
    parent.classList.add("error");
    parent.classList.remove("success");

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








