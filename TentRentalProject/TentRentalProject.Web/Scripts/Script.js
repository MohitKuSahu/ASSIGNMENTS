
function exportToPDF() {
    const content = document.getElementById('summaryReport');
    const pdf = new jsPDF();
    pdf.fromHTML(content, 15, 15);
    pdf.save('Inventory-Report.pdf');
}

