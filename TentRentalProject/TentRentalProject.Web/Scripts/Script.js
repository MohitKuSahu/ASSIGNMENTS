
function exportToPDF() {
    const content = document.getElementById('report');
    const pdf = new jsPDF();
    const currentDate = new Date();
    const formattedDate = currentDate.toDateString();
    const formattedTime = currentDate.toLocaleTimeString();
    const formattedDateTime = formattedDate +" " +formattedTime;
    pdf.fromHTML(content, 15, 15);
    const fileName = `Inventory-Report-${formattedDateTime}.pdf`;
    pdf.save(fileName);
}

