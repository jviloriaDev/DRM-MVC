var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
var saltarValidacion = false;
$(document).ready(function () {
//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {
//NEWBUSINESSRULE_SCREENOPENING//
}
function EjecutarValidacionesAntesDeGuardar(){
	var result = true;
//NEWBUSINESSRULE_BEFORESAVING//
    return result;
}
function EjecutarValidacionesDespuesDeGuardar(){
//NEWBUSINESSRULE_AFTERSAVING//
}

function EjecutarValidacionesAntesDeGuardarMRDetalle_Consulta_Actividades_Registro_Evento(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Consulta_Actividades_Registro_Evento//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRDetalle_Consulta_Actividades_Registro_Evento(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Consulta_Actividades_Registro_Evento//
}
function EjecutarValidacionesAlEliminarMRDetalle_Consulta_Actividades_Registro_Evento(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Detalle_Consulta_Actividades_Registro_Evento//
    return result;
}
function EjecutarValidacionesNewRowMRDetalle_Consulta_Actividades_Registro_Evento(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Detalle_Consulta_Actividades_Registro_Evento//
    return result;
}
function EjecutarValidacionesEditRowMRDetalle_Consulta_Actividades_Registro_Evento(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Detalle_Consulta_Actividades_Registro_Evento//
    return result;
}
function EjecutarValidacionesAntesDeGuardarMRDetalle_Registro_en_Actividad_Evento(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Registro_en_Actividad_Evento//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRDetalle_Registro_en_Actividad_Evento(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Registro_en_Actividad_Evento//
}
function EjecutarValidacionesAlEliminarMRDetalle_Registro_en_Actividad_Evento(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Detalle_Registro_en_Actividad_Evento//
    return result;
}
function EjecutarValidacionesNewRowMRDetalle_Registro_en_Actividad_Evento(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Detalle_Registro_en_Actividad_Evento//
    return result;
}
function EjecutarValidacionesEditRowMRDetalle_Registro_en_Actividad_Evento(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Detalle_Registro_en_Actividad_Evento//
    return result;
}

