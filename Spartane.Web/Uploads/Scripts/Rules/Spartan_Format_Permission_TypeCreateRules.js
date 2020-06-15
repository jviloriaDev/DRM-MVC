var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
$(document).ready(function () {
EjecutarValidacionesAlComienzo();
//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {
//NEWBUSINESSRULE_SCREENOPENING//
}
function EjecutarValidacionesAntesDeGuardar()
{
//NEWBUSINESSRULE_BEFORESAVING//
}
function EjecutarValidacionesDespuesDeGuardar()
{
//NEWBUSINESSRULE_AFTERSAVING//
}
function EjecutarValidacionesAntesDeGuardarMR()
{
    var result = true;
//NEWBUSINESSRULE_BEFORESAVINGMR//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMR()
{
    //NEWBUSINESSRULE_AFTERSAVINGMR//
}
function EjecutarValidacionesAlEliminarMR() {
    var result = true;
    //NEWBUSINESSRULE_DELETEMR//
    return result;
}
