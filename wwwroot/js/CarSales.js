
$("#nationality").change(function () {
    debugger;
    var id = $("#nationality").val();
    $("#state").empty();
    $.ajax({
        url: "/Account/GetState",
        type: "Get",
        data: { countryId: id },
        success: function (result) {
            debugger;
            if (!result.isError) {
                $.each(result.data, function (index, state) {
                    $("#state").append('<option value="' + state.id + '">' + state.name+ '</option>');
                });
            }
            else {

            }
        },
        error: function () {

        }
    });
})


$("#customerCountry").change(function () {
    debugger;
    var id = $("#customerCountry").val();
    $("#customerState").empty();
    $.ajax({
        url: "/Account/GetState",
        type: "Get",
        data: { countryId: id },
        success: function (result) {
            debugger;
            if (!result.isError) {
                $.each(result.data, function (index, state) {
                    $("#customerState").append('<option value="' + state.id + '">' + state.name + '</option>');
                });
            }
            else {

            }
        },
        error: function () {

        }
    });
})

$("#Customer").change(function () {
    debugger;
    var id = $("#Customer").val();
    $("#customer").empty();
    $.ajax({
        url: "/Account/GetCars",
        type: "Get",
        data: { CustomerId: id },
        success: function (result) {
            debugger;
            if (!result.isError) {
                $.each(result.data, function (index, state) {
                    $("#Cars").append('<option value="' + state.id + '">' + state.name + '</option>');
                });
            }
            else {

            }
        },
        error: function () {

        }
    });
})

$("#Cars").change(function () {
    debugger;
    var id = $("#Cars").val();
    $("#cars").empty();
    $.ajax({
        url: "/Account/GetCars",
        type: "Get",
        data: { Cars: id },
        success: function (result) {
            debugger;
            if (!result.isError) {
                $.each(result.data, function (index, state) {
                    $("#Cars").append('<option value="' + state.id + '">' + state.name + '</option>');
                });
            }
            else {

            }
        },
        error: function () {

        }
    });
})

$("#ServiceType").change(function () {
    debugger;
    var id = $("#ServiceType").val();
    $("#ServiceType").empty();
    $.ajax({
        url: "/Account/GetServiceType",
        type: "Get",
        data: { Cars: id },
        success: function (result) {
            debugger;
            if (!result.isError) {
                $.each(result.data, function (index, state) {
                    $("#ServiceType").append('<option value="' + state.id + '">' + state.name + '</option>');
                });
            }
            else {

            }
        },
        error: function () {

        }
    });
})

$("#cars").change(function () {
    debugger;
    var id = $("#cars").val();
    $("#price").empty();
    $.ajax({
        url: "/Admin/GetPrice",
        type: "Get",
        data: { id: id },
        success: function (result) {
            debugger;
            if (!result.isError) {
                $("#price").val(result.data)
            }
            else {
                $("#text").text("please select")
            }
        },
        error: function () {

        }
    });
})

function makePayment() {
    
    var productId = $("#cars").val();
    var serviceTypeId = $("#servicesType").val();
    $.ajax({
        url: "/Admin/AdminBankDetails",
        type: "Get",
        data: {
            productId: productId,
            serviceTypeId: serviceTypeId
        },
        success: function (result) {
            debugger;
            if (!result.isError) {
                location.href = "/Admin/AdminBankDetails"
            }
            else {
                $("#text").text("please select")
            }
        },
        error: function () {

        }
    });

}

$("#Customer").change(function () {
    debugger;
    var id = $("#Customer").val();
    $("#Customer").empty();
    $.ajax({
        url: "/Account/GetCustomer",
        type: "Get",
        data: { Customer: id },
        success: function (result) {
            debugger;
            if (!result.isError) {
                $.each(result.data, function (index, state) {
                    $("#Customer").append('<option value="' + state.id + '">' + state.name + '</option>');
                });
            }
            else {

            }
        },
        error: function () {

        }
    });
})

$("#ServiceType").change(function () {
    debugger;
    var id = $("#ServiceType").val();
    $("#ServiceType").empty();
    $.ajax({
        url: "/Account/GetServiceType",
        type: "Get",
        data: { Cars: id },
        success: function (result) {
            debugger;
            if (!result.isError) {
                $.each(result.data, function (index, state) {
                    $("#ServiceType").append('<option value="' + state.id + '">' + state.name + '</option>');
                });
            }
            else {

            }
        },
        error: function () {

        }
    });
})

function submitPayment() {

    debugger;
    var data = {};
    data.ServiceTypeId = $("#servicesTypeId").val();
    data.CustomerId = $("#customerId").val();
    data.Price = $("#price").val();
    data.Name = $("#name").val();
    data.BankName = $("#bankName").text();
    data.AccountNumber = $("#accountNumber").text();
    data.ReferenceNo = $("#referenceNumber").val();

   /* var ref: No = $(#bankName).val();
    var brand: brand.val();*/

    $.ajax({
        url: "/Admin/AdminCarPayment",
        type: "Post",
        data: {
            paymentData : data
        },
        success: function (result) {
            debugger;
            if (!result.isError) {
                var msg = "Payment Successful";
                newSuccessAlert(msg);
            }
            else {
                errorAlert(result.msg);
            }
        },
        error: function () {
            errorAlert("Failed");
        }
    });

}


$(document).ready(function () {
    $('#example').DataTable();
});
