 $(document).ready(function () {
        $("#DocumentBtn").click(function (event) {
            event.preventDefault();
            var formData = new FormData();

            var fileInput = $("#fileUpload")[0].files[0];

            formData.append("fileUpload", fileInput);
            formData.append("ObjectId", $("#docObjectID").val());
            $.ajax({
                type: "POST",
                url: '@Url.Action("UploadFile", "Document")',
                data: formData,
                contentType: false,
                processData: false,
                success: function (result) {
                    if (result.success) {
                        console.log("File uploaded successfully.");
                    } else {
                        console.error("File upload failed: " + result.message);
                    }
                },
                error: function (xhr, status, error) {
                    console.error("Error in AJAX request: " + error);
                }
            });
        });


    });