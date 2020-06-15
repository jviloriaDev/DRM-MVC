var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
var saltarValidacion = false;
$(document).ready(function () {




//BusinessRuleId:161, Attribute:259783, Operation:Field, Event:None
$("form#CreatePlanes_de_Rutinas").on('change', '#Fecha_inicio_del_Plan', function () {
	nameOfTable='';
	rowIndex='';
 AsignarValor($('#' + nameOfTable + 'Fecha_fin_del_Plan' + rowIndex),EvaluaQuery("declare @Fecha nvarchar(10) = 'FLD[Fecha_inicio_del_Plan]'"
+" "
+" declare @FechaNueva nvarchar(10)"
+" "
+" set @FechaNueva = substring(@Fecha,4,2) + '/' + left(@fecha,2) + '/' + right(@fecha,4) "
+" "
+" "
+" declare @fecha2 date"
+" "
+" declare @duracion int"
+" "
+" "
+" set @duracion = 7"
+" "
+" set @fecha2 = (select DATEADD(DD, @Duracion, @FechaNueva))"
+" "
+" "
+" select convert (varchar(11),@fecha2,105)"
+" "
+" "
+" ", rowIndex, nameOfTable));
});

//BusinessRuleId:161, Attribute:259783, Operation:Field, Event:None

//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {




//BusinessRuleId:153, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#divFolio').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Folio' + rowIndex)); AsignarValor($('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex),EvaluaQuery("select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Hora_de_Registro' + rowIndex),EvaluaQuery("select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex),EvaluaQuery("select GLOBAL[USERID]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Fecha_fin_del_Plan" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:153, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:153, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 $('#divFolio').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Folio' + rowIndex)); AsignarValor($('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex),EvaluaQuery("select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Hora_de_Registro' + rowIndex),EvaluaQuery("select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex),EvaluaQuery("select GLOBAL[USERID]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Fecha_fin_del_Plan" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:153, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:164, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 AsignarValor($('#' + nameOfTable + 'Estatus' + rowIndex),1);

}
//BusinessRuleId:164, Attribute:0, Operation:Object, Event:SCREENOPENING

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

function EjecutarValidacionesAntesDeGuardarMRDetalle_Planes_de_Rutinas(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Planes_de_Rutinas//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRDetalle_Planes_de_Rutinas(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Planes_de_Rutinas//
}
function EjecutarValidacionesAlEliminarMRDetalle_Planes_de_Rutinas(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Detalle_Planes_de_Rutinas//
    return result;
}
function EjecutarValidacionesNewRowMRDetalle_Planes_de_Rutinas(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Detalle_Planes_de_Rutinas//
    return result;
}
function EjecutarValidacionesEditRowMRDetalle_Planes_de_Rutinas(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Detalle_Planes_de_Rutinas//
    return result;
}

