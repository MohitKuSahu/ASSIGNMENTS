$(document).ready(function () {
    $('#btnSubmit').click(function () {
        var date = $("#exactDate").val();
        var formattedDate = new Date(date).toLocaleDateString('en-GB');

        $.ajax({
            url: '/Reports/GetTransactionDetailsByDate',
            type: 'GET',
            data: { date: date }, 
            success: function (data) {
                var listHtml = '';
                listHtml += '<center>' + '<h3>' + 'Detailed Report on ' + formattedDate + '</h3>' + '</center>';
                $.each(data.Products, function (index, product) {
                    listHtml += '<div class="card mb-3 product-section">';
                    listHtml += '<div class="card-header">';
                    listHtml += 'Item Name: ' + product.ProductTitle;
                    listHtml += '<br />';
                    listHtml += 'Available Quantity: ' + (product.AvailableQuantity)
                    listHtml += '</div>';

                    // Check if there are transactions exists for the Product ID.
                    var transactionsForProduct = data.Transactions.filter(function (transaction) {
                        return transaction.ProductID === product.ProductID;
                    });

                    if (transactionsForProduct.length > 0) {
                        listHtml += '<div class="card-body">';
                        listHtml += '<table class="table table-bordered table-striped">';
                        listHtml += '<thead class="thead-dark">';
                        listHtml += '<tr>';
                        listHtml += '<th>Transaction ID</th>';
                        listHtml += '<th>Date</th>';
                        listHtml += '<th>Type</th>';
                        listHtml += '<th>Quantity</th>';
                        listHtml += '</tr>';
                        listHtml += '</thead>';
                        listHtml += '<tbody>';

                        $.each(transactionsForProduct, function (index,transaction) {
                            listHtml += '<tr>';
                            listHtml += '<td>' + transaction.TransactionID + '</td>';
                            var publishDate = new Date(parseInt(transaction.TransactionDateTime.substr(6)));
                            var formattedDate = publishDate.toLocaleTimeString();
                            listHtml += '<td>' + formattedDate + '</td>';
                            listHtml += '<td>' + transaction.TransactionType + '</td>';
                            listHtml += '<td>' + transaction.Quantity + '</td>';
                            listHtml += '</tr>';
                        });

                        listHtml += '</tbody>';
                        listHtml += '</table>';
                        listHtml += '</div>'; // End of card-body
                    }

                    listHtml += '</div>'; // End of card
                });
                $('#list').html(listHtml);
            },
            error: function () {
                alert('Error loading data.');
            }
        });
    });
});
