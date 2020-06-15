var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
$(document).ready(function () {
//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {
//BusinessRuleId:85, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#divFolio').css('display', 'none'); $('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex).val(EvaluaQuery("select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Hora_de_Registro' + rowIndex).val(EvaluaQuery("select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex).val(EvaluaQuery("select GLOBAL[USERID]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:85, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:85, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 $('#divFolio').css('display', 'none'); $('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex).val(EvaluaQuery("select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Hora_de_Registro' + rowIndex).val(EvaluaQuery("select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex).val(EvaluaQuery("select GLOBAL[USERID]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:85, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:169, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Dificultad' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Categoria_del_Platillo' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_de_comida' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Caracteristicas' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calificacion' + rowIndex));

}
//BusinessRuleId:169, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:169, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Dificultad' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Categoria_del_Platillo' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_de_comida' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Caracteristicas' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calificacion' + rowIndex));

}
//BusinessRuleId:169, Attribute:0, Operation:Object, Event:SCREENOPENING

//NEWBUSINESSRULE_SCREENOPENING//
}
function EjecutarValidacionesAntesDeGuardar(){
	var result = true;
        nameOfTable = '';
        rowIndex = '';
//NEWBUSINESSRULE_BEFORESAVING//
    return result;
}
function EjecutarValidacionesDespuesDeGuardar(){
//NEWBUSINESSRULE_AFTERSAVING//
}

function EjecutarValidacionesAntesDeGuardarMRDetalle_de_Ingredientes(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_de_Ingredientes//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRDetalle_de_Ingredientes(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_de_Ingredientes//
}
function EjecutarValidacionesAlEliminarMRDetalle_de_Ingredientes(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Detalle_de_Ingredientes//
    return result;
}
function EjecutarValidacionesNewRowMRDetalle_de_Ingredientes(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Detalle_de_Ingredientes//
    return result;
}
function EjecutarValidacionesEditRowMRDetalle_de_Ingredientes(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Detalle_de_Ingredientes//
    return result;
}


function EjecutarValidacionesAntesDeGuardarMRDetalle_Platillos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Platillos// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Platillos(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Platillos// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Platillos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Platillos// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Platillos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Detalle_Platillos// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Platillos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detalle_Platillos// 
 return result; 
} 
