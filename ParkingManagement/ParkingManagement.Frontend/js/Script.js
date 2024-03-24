$(document).ready(function () {


    function fetchParkingZones() {
        $.get("https://localhost:7084/api/ParkingZoneAPI", function (data) {
            var dropdown = $('#parking-zone-select');
            dropdown.append($('<option disabled selected>').text('Select Here'));
            $.each(data, function (index, zone) {
                dropdown.append($('<option>').val(zone.parkingZoneId).text(zone.parkingZoneTitle));
            });
        });
    }
    fetchParkingZones();



    function fetchParkingSpaces(zoneId) {
        const apiUrl = `https://localhost:7084/api/ParkingSpaceAPI/${zoneId}`;

        return $.ajax({
            url: apiUrl,
            type: 'GET',
            dataType: 'json'
        });
    }
    

    function fetchVehicleDetails(spaceId) {
        const apiUrl = `https://localhost:7084/api/VehicleParkingAPI/${spaceId}`;
        return $.ajax({
            url: apiUrl,
            type: 'GET',
            dataType: 'json'
        });
    }


    function fetchBookingsForToday() {
        return $.ajax({
            url: 'https://localhost:7084/api/VehicleParkingAPI', 
            type: 'GET',
            dataType: 'json'
        });
    }

    var spaceId;
    var occupied=0;

    function renderParkingSpaces(zoneId) {
        var currentTime = new Date();
        fetchParkingSpaces(zoneId).done(function (parkingSpaces) {
            fetchBookingsForToday().done(function (bookings) {
                var html = '';
                var row = '<div class="row">';
                $.each(parkingSpaces, function(index, space) {
                    var bookingsForSpace = bookings.filter(function(booking) {
                        if (booking.parkingSpaceId === space.parkingSpaceId) {
                            if (!booking.bookingDateTime || (booking.releaseDateTime && new Date(booking.releaseDateTime) <= currentTime)) {
                                return false;
                            } else {
                                return true;
                            }
                        } else {
                            return false;
                        }
                    });
                
                    var bookingColor = bookingsForSpace.length > 0 ? 'lightgray' : 'lightgreen';
                
                    row += '<div class="col-6 col-sm-4 col-md-3 col-lg-2 parking-space ' + bookingColor + '" data-space-title="' + space.parkingSpaceTitle + '" data-space-id="' + space.parkingSpaceId + '">';
                    row += '<h4>' + space.parkingSpaceTitle + '</h4>';
                    row += '</div>';
                
                    if (index === parkingSpaces.length - 1) {
                        row += '</div>';
                        html += row;
                        row = '<div class="row">';
                    }
                });
                
                html += '<div class="row mt-2"></div>';
                html += '<div id="color-indication" class="col-12">';
                html += '<div class="row align-items-center">';
                html += '<div class="col-auto d-flex ">';
                html += '<div class="color-block lightgreen mr-2 align-items-center"></div>';
                html += '<p class="status-text">Vacant</p>';
                html += '</div>';
                html += '<div class="w-100"></div>';
                html += '<div class="col-auto d-flex ">';
                html += '<div class="color-block lightgray mr-2 align-items-center"></div>';
                html += '<p class="status-text">Occupied</p>';
                html += '</div>';
                html += '</div>'; 
                html += '</div>'; 

                $('#parking-spaces').html(html); 

                $('.parking-space.lightgreen').click(function () {
                    var spaceTitle = $(this).data('space-title');
                    spaceId = $(this).attr('data-space-id');
                    occupied=0;
                    openModal(spaceTitle);
                });


                $('.parking-space.lightgray').click(function () {
                    spaceId = $(this).attr('data-space-id');
                    var spaceTitle = $(this).data('space-title');
                    occupied=1;
                    fetchVehicleDetails(spaceId).done(function (vehicleDetails) {
                        if (Array.isArray(vehicleDetails) && vehicleDetails.length > 0) {
                            var vehicleDetail = vehicleDetails[0];
                            $('#vehicle-registration').val(vehicleDetail.vehicleRegistration);
                            $('#booking-date-time').val(vehicleDetail.bookingDateTime);
                            $('#release-date-time').val(vehicleDetail.releaseDateTime);
                            // Open the modal
                            openModal(spaceTitle);
                        } else {
                            console.error("No vehicle details found for space ID:", spaceId);
                        }
                    }).fail(function (jqXHR, textStatus, errorThrown) {
                        console.error("Error fetching booking details:", textStatus, errorThrown);
                    });
                });


            }).fail(function (jqXHR, textStatus, errorThrown) {
                console.error("Error fetching bookings for today:", textStatus, errorThrown);
            });
        }).fail(function (jqXHR, textStatus, errorThrown) {
            console.error("Error fetching parking spaces:", textStatus, errorThrown);
        });
    }


    
    function openModal(spaceTitle) {
        $('#vehicle-modal').css('display', 'block');
        if (occupied==1) {
            $('#release-Btn').show();
        }
        else {
            $('#release-Btn').hide(); 
        }
        $('#spaceTitle').text(spaceTitle);
    }

    $('.close').click(function () {
        $('#vehicle-modal').css('display', 'none');
    });
    $(window).click(function (event) {
        if (event.target == $('#vehicle-modal')[0]) {
            $('#vehicle-modal').css('display', 'none');
        }
    });
    
    $('#refresh-button').click(function () {
        var selectedZoneId = $('#parking-zone-select').val(); 
        $('#parking-spaces').empty(); 
        renderParkingSpaces(selectedZoneId); 
    });

    $('#submit-Btn').click(function (event) {
        // Prevent default form submission
        event.preventDefault();
    
        var vehicleRegistration = $('#vehicle-registration').val();
        var bookingDateTime = $('#booking-date-time').val();
        var releaseDateTime = $('#release-date-time').val();
        var parkingZoneId = $('#parking-zone-select').val();
        var parkingSpaceId = spaceId;
    

            if (!vehicleRegistration) {
                alert('Please fill in all required fields.');
                return; 
            }   
       
        var requestData = {
            vehicleRegistration: vehicleRegistration,
            bookingDateTime: bookingDateTime || null,
            releaseDateTime: releaseDateTime || null,
            parkingZoneId: parkingZoneId,
            parkingSpaceId: parkingSpaceId
        };

        console.log("Submitting data:", requestData); // Debugging log
    
        $.ajax({
            url: 'https://localhost:7084/api/VehicleParkingAPI',
            type: 'PUT', // Assuming you're updating existing data
            contentType: 'application/json',
            data: JSON.stringify(requestData),
            success: function (response) {
                alert('Booking Successful');
                $('#vehicle-modal').css('display', 'none'); // Close the modal
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.error('Error submitting booking:', textStatus, errorThrown);
            }
        });
    });

    $('#release-Btn').click(function () {
        if (confirm("Are you sure you want to release this vehicle?")) {
            $.ajax({
                url: `https://localhost:7084/api/VehicleParkingAPI/${spaceId}`,
                type: 'DELETE',
                success: function (response) {
                    alert('Space is now vacant successfully');
                    $('#vehicle-modal').modal('hide');
                    location.reload();
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    console.error('Error releasing space:', textStatus, errorThrown);
                    alert('Failed to release space. Please try again.');
                }
            });
        }
    });
    
    
});
