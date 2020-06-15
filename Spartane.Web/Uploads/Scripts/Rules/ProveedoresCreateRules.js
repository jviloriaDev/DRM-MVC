var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
var saltarValidacion = false;
$(document).ready(function () {
//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {
//BusinessRuleId:170, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#divFolio').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Folio' + rowIndex)); AsignarValor($('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex),EvaluaQuery(" select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Hora_de_Registro' + rowIndex),EvaluaQuery("select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex),EvaluaQuery(" select GLOBAL[USERID]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:170, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:170, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 $('#divFolio').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Folio' + rowIndex)); AsignarValor($('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex),EvaluaQuery(" select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Hora_de_Registro' + rowIndex),EvaluaQuery("select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex),EvaluaQuery(" select GLOBAL[USERID]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:170, Attribute:0, Operation:Object, Event:SCREENOPENING

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

function EjecutarValidacionesAntesDeGuardarMRDetalle_Sucursales_Proveedores(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Sucursales_Proveedores//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRDetalle_Sucursales_Proveedores(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Sucursales_Proveedores//
}
function EjecutarValidacionesAlEliminarMRDetalle_Sucursales_Proveedores(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Detalle_Sucursales_Proveedores//
    return result;
}
function EjecutarValidacionesNewRowMRDetalle_Sucursales_Proveedores(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Detalle_Sucursales_Proveedores//
    return result;
}
function EjecutarValidacionesEditRowMRDetalle_Sucursales_Proveedores(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Detalle_Sucursales_Proveedores//
    return result;
}
function EjecutarValidacionesAntesDeGuardarMRDetalle_Suscripcion_Red_de_Especialistas_Proveedores(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Suscripcion_Red_de_Especialistas_Proveedores//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRDetalle_Suscripcion_Red_de_Especialistas_Proveedores(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Suscripcion_Red_de_Especialistas_Proveedores//
}
function EjecutarValidacionesAlEliminarMRDetalle_Suscripcion_Red_de_Especialistas_Proveedores(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Detalle_Suscripcion_Red_de_Especialistas_Proveedores//
    return result;
}
function EjecutarValidacionesNewRowMRDetalle_Suscripcion_Red_de_Especialistas_Proveedores(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Detalle_Suscripcion_Red_de_Especialistas_Proveedores//
    return result;
}
function EjecutarValidacionesEditRowMRDetalle_Suscripcion_Red_de_Especialistas_Proveedores(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Detalle_Suscripcion_Red_de_Especialistas_Proveedores//
    return result;
}

