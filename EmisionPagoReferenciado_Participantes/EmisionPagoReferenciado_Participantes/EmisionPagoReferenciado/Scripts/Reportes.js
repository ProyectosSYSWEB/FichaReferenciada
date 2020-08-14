

function VerReporte2(cverep) {
    window.open('ReportesFicha/VisualizadorCrystal.aspx?cverep=' + cverep, '_black', 'toolbar=yes', 'location=no', 'menubar=yes', 'resizable=yes');

    return false;
}
function VerReporte(cverep, Nombre, Referencia, Importe, Vigencia, Concepto) {
    window.open('../ReportesFicha/VisualizadorCrystal.aspx?cverep=' + cverep + '&Nombre=' + Nombre + '&Referencia=' + Referencia + '&Importe=' + Importe + '&Vigencia=' + Vigencia + '&Concepto=' + Concepto, 'miniContenedor', 'toolbar=yes', 'location=no', 'menubar=yes', 'resizable=yes');

    return false;
}
function VerReporteEX(cverep, Nombre, Referencia, Importe, Vigencia, Concepto) {
    window.open('ReportesFicha/VisualizadorCrystal.aspx?cverep=' + cverep + '&Nombre=' + Nombre + '&Referencia=' + Referencia + '&Importe=' + Importe + '&Vigencia=' + Vigencia + '&Concepto=' + Concepto, '_black', 'toolbar=yes', 'location=no', 'menubar=yes', 'resizable=yes');

    return false;
}

function VerReporteIN(cverep, Matricula, Evento) {
    window.open('ReportesFicha/VisualizadorCrystal.aspx?cverep=' + cverep + '&Evento=' + Evento + '&Matricula=' + Matricula, 'miniContenedor', 'toolbar=yes', 'location=no', 'menubar=yes', 'resizable=yes');

    return false;
}

function VerRecibo(cverep, idFact) {
    //alert("PASO " + cverep + " : " + idFact);
    window.open('../Reportes/VisualizadorCrystal.aspx?cverep=' + cverep + '&idFact=' + idFact, 'miniContenedor', 'toolbar=yes', 'location=no', 'menubar=yes', 'resizable=yes');
    return false;
}

