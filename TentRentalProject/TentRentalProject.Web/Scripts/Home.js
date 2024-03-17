$(document).ready(function () {
    var transactions = []; // Array to store all transaction details

    $('#btnSubmit').click(function () {
        var custName = $("#customerName").val();
        var productTitle = $("#productTitle").val();

        $.ajax({
            url: '/Home/GetProductDetails',
            type: 'GET',
            data: {
                productTitle: productTitle
            },
            success: function (data) {
                var cardHtml = '';
                $.each(data.Products, function (index, product) {
                    cardHtml += '<div class="card mb-3 product-section">';
                    cardHtml += '<div class="card-header">';
                    cardHtml += 'Item:' + product.ProductTitle;
                    cardHtml += '</div>';
                    cardHtml += '<div class="card-body">';
                    cardHtml += '<p>Available Quantity: ' + (product.QuantityTotal - product.QuantityBooked) + '</p>';
                    cardHtml += '<p>Price: $' + product.Price + ' per day</p>';
                    cardHtml += '<input type="hidden" name="ProductID" value="' + product.ProductID + '">';
                    cardHtml += '<span>Select Transaction Type:</span>';
                    cardHtml += '<input type="hidden" name="CustomerName" value="' + custName + '">';
                    cardHtml += '<input type="radio" name="TransactionType" value="OUT">OUT';
                    cardHtml += '<input type="radio" name="TransactionType" value="IN">IN';
                    cardHtml += '<br>';
                    cardHtml += '<span>Enter Quantity:</span>';
                    cardHtml += '<input type="number" name="Quantity" class="form-control">';
                    cardHtml += '<button type="button" class="btn btn-primary submitTransaction">Add to Cart</button>';
                });

                $('#list').html(cardHtml);
            },
            error: function () {
                alert('Error getting product details.');
            }
        });
    });

    $(document).on('click', '.submitTransaction', function (event) {
        event.preventDefault(); 

        var TransactionType = $('input[name="TransactionType"]:checked').val(),
            Quantity = $('input[name="Quantity"]').val(),
            CustomerName = $('input[name="CustomerName"]').val(),
            ProductID = $('input[name="ProductID"]').val();

        var transactionList = [{
            TransactionType: TransactionType,
            Quantity: Quantity,
            ProductID: ProductID
        }];

        var userDetails = {
            Customer: {
                CustomerName: CustomerName
            },
            TransactionHistory: {
                TransactionList: transactionList
            }
        };

    
        $.ajax({
            type: 'POST',
            url: '/Home/SaveDetails',
            data: JSON.stringify({ userDetails: userDetails }),
            contentType: 'application/json',
            success: function (response) {
                alert("Transaction Added Successfully");
                window.location.href = '/Transaction/Index';
            },
            error: function (error) {
                console.error(error);
            },
        });
    });
});
