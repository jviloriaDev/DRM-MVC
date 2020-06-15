var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
var saltarValidacion = false;
$(document).ready(function () {
//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {
//BusinessRuleId:168, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#divFolio').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Folio' + rowIndex)); AsignarValor($('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex),EvaluaQuery("select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Hora_de_Registro' + rowIndex),EvaluaQuery("select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex),EvaluaQuery("select GLOBAL[USERID]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:168, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:168, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 $('#divFolio').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Folio' + rowIndex)); AsignarValor($('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex),EvaluaQuery("select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Hora_de_Registro' + rowIndex),EvaluaQuery("select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex),EvaluaQuery("select GLOBAL[USERID]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:168, Attribute:0, Operation:Object, Event:SCREENOPENING

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

function EjecutarValidacionesAntesDeGuardarMRDetalle_Codigos_de_Referencia_Vendedores(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Codigos_de_Referencia_Vendedores//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRDetalle_Codigos_de_Referencia_Vendedores(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Codigos_de_Referencia_Vendedores//
}
function EjecutarValidacionesAlEliminarMRDetalle_Codigos_de_Referencia_Vendedores(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Detalle_Codigos_de_Referencia_Vendedores//
    return result;
}
function EjecutarValidacionesNewRowMRDetalle_Codigos_de_Referencia_Vendedores(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Detalle_Codigos_de_Referencia_Vendedores//
    return result;
}
function EjecutarValidacionesEditRowMRDetalle_Codigos_de_Referencia_Vendedores(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Detalle_Codigos_de_Referencia_Vendedores//
    return result;
}
function EjecutarValidacionesAntesDeGuardarMRDetalle_Facturacion_Vendedores(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Facturacion_Vendedores//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRDetalle_Facturacion_Vendedores(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Facturacion_Vendedores//
}
function EjecutarValidacionesAlEliminarMRDetalle_Facturacion_Vendedores(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Detalle_Facturacion_Vendedores//
    return result;
}
function EjecutarValidacionesNewRowMRDetalle_Facturacion_Vendedores(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Detalle_Facturacion_Vendedores//
    return result;
}
function EjecutarValidacionesEditRowMRDetalle_Facturacion_Vendedores(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Detalle_Facturacion_Vendedores//
    return result;
}

