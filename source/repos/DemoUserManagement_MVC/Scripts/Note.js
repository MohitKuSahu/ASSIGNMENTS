$(document).ready(function () {
    $("#NotesBtn").click(function (event) {
        event.preventDefault();
        var noteText = $("#NotesInput").val();
        var notesObjectId = $("#notesObjectID").val();
        $.ajax({
            type: "POST",
            url: '@Url.Action("SaveNote", "Notes")',
            data: JSON.stringify({
                NoteText: noteText, UserID: notesObjectId
            }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                if (result.success) {
                }
            },
            error: function (xhr, status, error) {
                console.log(xhr.responseText);
            }
        });
    });
});