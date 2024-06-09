function submitCustomerData() {

    var stateDropDown = document.getElementById("state");
    var cityDropDown = document.getElementById("city");

    var customerData = {
        First_Name: $('#firstName').val().trim(),
        Last_Name: $('#lastName').val().trim(),
        Mobile_Number: $('#mobileNumber').val().trim(),
        Email: $('#email').val().trim(),
        State: stateDropDown.value,
        City: cityDropDown.value,
        Customer_Selected_Plane: $('#customerSelectedPlane').val().trim(),
        Suggested: $('#suggested').val().trim(),
        Address: $('#address').val().trim(),
        Customer_Comment: $('#comments').val().trim()
    };

    if (customerData.First_Name === "" || customerData.Mobile_Number === ""
        || customerData.Email === "" || customerData.State === ""
        || customerData.City === "" || customerData.Customer_Selected_Plane === ""
        || customerData.Suggested === "" || customerData.Address === "") {

        $("#firstNameError").text(customerData.First_Name === "" ? "*First Name can not be empty" : "");
        $("#mobileNumberError").text(customerData.Mobile_Number === "" ? "*Mobile Number can not be empty" : "");
        $("#emailError").text(customerData.Email === "" ? "*Email can not be empty" : "");
        $("#StateError").text(customerData.State === "" ? "*Please Select the State" : "");
        $("#cityError").text(customerData.City === "" ? "*Please Select the City" : "");
        $("#planeError").text(customerData.Customer_Selected_Plane === "" ? "*Please Select the Plane" : "");
        $("#suggestedError").text(customerData.Suggested === "" ? "*Please Select who suggest you?" : "");
        $("#addressError").text(customerData.Address === "" ? "*Address can not be empty" : "");

        return;
    }

    // Validation for Mobile Number
    if (!/^\d{10}$/.test(customerData.Mobile_Number)) {
        $("#mobileNumberError").text("*Mobile Number must have exactly 10 digits");
        return;
    }

    console.log(customerData);

    $.ajax({
        url: '/ContactUs/SubmitCustomerData',
        type: 'POST',
        data: { contactUsModel: customerData },
        success: function (result, status, xhr) {

            if (result.responce === "Exist") {
                console.log("Already exist");
            }

            // USer ne ayathi patavi dyo
            console.log(result)

            var emailData = {
                contactId: result.contactId,
                responce: result.responce
            };

            $.ajax({
                url: '/ContactUs/SendEmail',
                type: 'POST',
                data: { customerAddResponceModel: emailData },
                success: function (result, status, xhr) {

                    console.log("Email nu oan resilt avi gayu");
                    console.log(result)
                },
                error: function (xhr, status, result) {
                    alert("Error Occured");
                }
            });

            console.log(result.contactId)


        },
        error: function (xhr, status, result) {
            alert("Error Occured");
        }
    });
    
}

