var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
var saltarValidacion = false;
$(document).ready(function () {










//BusinessRuleId:92, Attribute:258689, Operation:Field, Event:None
$("form#CreateEventos").on('change', '#Evento_en_Empresa', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Evento_en_Empresa' + rowIndex).val()==TryParseInt('1', '1') ) { $('#' + nameOfTable + 'Nombre_del_Lugar' + rowIndex).val(EvaluaQuery("select Nombre_de_la_Empresa from Empresas where Folio = FLD[Empresa]", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Calle' + rowIndex).val(EvaluaQuery("select Calle from Empresas where Folio = FLD[Empresa]", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Numero_exterior' + rowIndex).val(EvaluaQuery("select Numero_exterior from Empresas where Folio = FLD[Empresa]", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Numero_interior' + rowIndex).val(EvaluaQuery("select Numero_interior from Empresas where Folio = FLD[Empresa]", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Colonia' + rowIndex).val(EvaluaQuery("select Colonia from Empresas where Folio = FLD[Empresa]", rowIndex, nameOfTable)); $('#' + nameOfTable + 'CP' + rowIndex).val(EvaluaQuery("select CP from Empresas where Folio = FLD[Empresa]", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Ciudad' + rowIndex).val(EvaluaQuery(" select Ciudad from Empresas where Folio = FLD[Empresa]", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Estado' + rowIndex).val(EvaluaQuery("select Estado from Empresas where Folio = FLD[Empresa]"
+" "
+" ", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Pais' + rowIndex).val(EvaluaQuery("select Pais from Empresas where Folio = FLD[Empresa]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Nombre_del_Lugar" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Calle" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Numero_exterior" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Numero_interior" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Colonia" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "CP" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Ciudad" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Estado" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Pais" + rowIndex), ("true" == "true"));} else { $('#' + nameOfTable + 'Nombre_del_Lugar' + rowIndex).val('‎'); $('#' + nameOfTable + 'Calle' + rowIndex).val('‎'); $('#' + nameOfTable + 'Numero_exterior' + rowIndex).val('‎'); $('#' + nameOfTable + 'Numero_interior' + rowIndex).val('‎'); $('#' + nameOfTable + 'Colonia' + rowIndex).val('‎'); $('#' + nameOfTable + 'CP' + rowIndex).val('‎'); $('#' + nameOfTable + 'Ciudad' + rowIndex).val('‎'); $('#' + nameOfTable + 'Estado' + rowIndex).val('NULL'); $('#' + nameOfTable + 'Pais' + rowIndex).val('NULL'); DisabledControl($("#" + nameOfTable + "Nombre_del_Lugar" + rowIndex), ("false" == "true")); DisabledControl($("#" + nameOfTable + "Calle" + rowIndex), ("false" == "true")); DisabledControl($("#" + nameOfTable + "Numero_exterior" + rowIndex), ("false" == "true")); DisabledControl($("#" + nameOfTable + "Numero_interior" + rowIndex), ("false" == "true")); DisabledControl($("#" + nameOfTable + "Colonia" + rowIndex), ("false" == "true")); DisabledControl($("#" + nameOfTable + "CP" + rowIndex), ("false" == "true")); DisabledControl($("#" + nameOfTable + "Ciudad" + rowIndex), ("false" == "true")); DisabledControl($("#" + nameOfTable + "Estado" + rowIndex), ("false" == "true")); DisabledControl($("#" + nameOfTable + "Pais" + rowIndex), ("false" == "true"));}
});

//BusinessRuleId:92, Attribute:258689, Operation:Field, Event:None







//BusinessRuleId:94, Attribute:258721, Operation:Field, Event:None
$("#Detalle_Actividades_EventoGrid").on('keyup', '.Duracion_maxima_por_paciente_mins', function () {
	nameOfTable = $(this).parent().parent().parent().parent()[0].id.replace('Grid', '') + '_';
	rowIndex = '_' + $(this).parent().parent()[0].className.replace(' odd', '').replace(' even', '').replace(nameOfTable, '');
if( $('#' + nameOfTable + 'Duracion_maxima_por_paciente_mins' + rowIndex).val()==TryParseInt('0', '0') || $('#' + nameOfTable + 'Duracion_maxima_por_paciente_mins' + rowIndex).val()==TryParseInt('NULL', 'NULL') ) { $('#' + nameOfTable + 'Cupo_limitado' + rowIndex).val('false'); DisabledControl($("#" + nameOfTable + "Cupo_limitado" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Cupo_maximo" + rowIndex), ("false" == "true"));} else {}
	nameOfTable='';
	rowIndex='';
});
$("form#CreateDetalle_Actividades_Evento").on('keyup', '#Detalle_Actividades_EventoDuracion_maxima_por_paciente_mins', function () {
	nameOfTable='Detalle_Actividades_Evento';
	rowIndex='';
if( $('#' + nameOfTable + 'Duracion_maxima_por_paciente_mins' + rowIndex).val()==TryParseInt('0', '0') || $('#' + nameOfTable + 'Duracion_maxima_por_paciente_mins' + rowIndex).val()==TryParseInt('NULL', 'NULL') ) { $('#' + nameOfTable + 'Cupo_limitado' + rowIndex).val('false'); DisabledControl($("#" + nameOfTable + "Cupo_limitado" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Cupo_maximo" + rowIndex), ("false" == "true"));} else {}
});
//BusinessRuleId:94, Attribute:258721, Operation:Field, Event:None





//BusinessRuleId:90, Attribute:258687, Operation:Field, Event:None
$("form#CreateEventos").on('change', '#Fecha_fin_del_Evento', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Cantidad_de_dias' + rowIndex).val(EvaluaQuery(" declare @Fecha nvarchar(10) = 'FLD[Fecha_inicio_del_Evento]'"
+" declare @Fecha2 nvarchar(10) = 'FLD[Fecha_fin_del_Evento]'"
+" declare @FechaNueva nvarchar(10)"
+" declare @FechaNueva2 nvarchar(10)"
+" set @FechaNueva = substring(@Fecha,4,2) + '/' + left(@fecha,2) + '/' + right(@fecha,4)  "
+" set @FechaNueva2 = substring(@Fecha2,4,2) + '/' + left(@fecha2,2) + '/' + right(@fecha2,4)  "
+" select DATEDIFF(day,@FechaNueva, @FechaNueva2) + 1", rowIndex, nameOfTable));
});

//BusinessRuleId:90, Attribute:258687, Operation:Field, Event:None

//BusinessRuleId:89, Attribute:258686, Operation:Field, Event:None
$("form#CreateEventos").on('change', '#Fecha_inicio_del_Evento', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Cantidad_de_dias' + rowIndex).val(EvaluaQuery(" declare @Fecha nvarchar(10) = 'FLD[Fecha_inicio_del_Evento]'"
+" declare @Fecha2 nvarchar(10) = 'FLD[Fecha_fin_del_Evento]'"
+" declare @FechaNueva nvarchar(10)"
+" declare @FechaNueva2 nvarchar(10)"
+" set @FechaNueva = substring(@Fecha,4,2) + '/' + left(@fecha,2) + '/' + right(@fecha,4)  "
+" set @FechaNueva2 = substring(@Fecha2,4,2) + '/' + left(@fecha2,2) + '/' + right(@fecha2,4)  "
+" select DATEDIFF(day,@FechaNueva, @FechaNueva2) + 1", rowIndex, nameOfTable));
});

//BusinessRuleId:89, Attribute:258686, Operation:Field, Event:None

//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {
//BusinessRuleId:91, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#divFolio').css('display', 'none'); $('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex).val(EvaluaQuery(" select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Hora_de_Registro' + rowIndex).val(EvaluaQuery(" select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex).val(EvaluaQuery(" select GLOBAL[USERID]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Cantidad_de_dias" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:91, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:91, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 $('#divFolio').css('display', 'none'); $('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex).val(EvaluaQuery(" select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Hora_de_Registro' + rowIndex).val(EvaluaQuery(" select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex).val(EvaluaQuery(" select GLOBAL[USERID]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Cantidad_de_dias" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:91, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:115, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#' + nameOfTable + 'Estatus' + rowIndex).val('1');

}
//BusinessRuleId:115, Attribute:0, Operation:Object, Event:SCREENOPENING

//NEWBUSINESSRULE_SCREENOPENING//
}
function EjecutarValidacionesAntesDeGuardar(){
	var result = true;
































//NEWBUSINESSRULE_BEFORESAVING//
    return result;
}
function EjecutarValidacionesDespuesDeGuardar(){
















//BusinessRuleId:117, Attribute:2, Operation:Object, Event:AFTERSAVING
if(operation == 'New'){
	var valor = $('#lblFolio').text().trim();
if( $('#' + nameOfTable + 'Estatus' + rowIndex).val()==TryParseInt('1', '1') ) 
{ 
var valor2 = "UPDATE ACTIVIDADES_DEL_EVENTO SET ESTATUS = 5 WHERE EVENTO = " + valor;
EvaluaQuery(valor2, rowIndex, nameOfTable);} 
else {}

}
//BusinessRuleId:117, Attribute:2, Operation:Object, Event:AFTERSAVING

//BusinessRuleId:117, Attribute:2, Operation:Object, Event:AFTERSAVING
if(operation == 'Update'){
	var valor = $('#lblFolio').text().trim();
if( $('#' + nameOfTable + 'Estatus' + rowIndex).val()==TryParseInt('1', '1') ) 
{ 
var valor2 = "UPDATE ACTIVIDADES_DEL_EVENTO SET ESTATUS = 5 WHERE EVENTO = " + valor;
EvaluaQuery(valor2, rowIndex, nameOfTable);}
else {}

}
//BusinessRuleId:117, Attribute:2, Operation:Object, Event:AFTERSAVING

//BusinessRuleId:116, Attribute:2, Operation:Object, Event:AFTERSAVING
if(operation == 'New'){
	var valor = $('#lblFolio').text().trim();
if( $('#' + nameOfTable + 'Estatus' + rowIndex).val()==TryParseInt('2', '2') || $('#' + nameOfTable + 'Estatus' + rowIndex).val()==TryParseInt('3', '3') ||
 $('#' + nameOfTable + 'Estatus' + rowIndex).val()==TryParseInt('5', '5') ) 
 { 
 var valor2 = "exec Update_ActividaesEvento FLD[Estatus], " + valor;
 EvaluaQuery(valor2, rowIndex, nameOfTable);} 
 else {}

}
//BusinessRuleId:116, Attribute:2, Operation:Object, Event:AFTERSAVING

//BusinessRuleId:116, Attribute:2, Operation:Object, Event:AFTERSAVING
if(operation == 'Update'){
	debugger;
	var valor = $('#lblFolio').text().trim();
if( $('#' + nameOfTable + 'Estatus' + rowIndex).val()==TryParseInt('2', '2') || $('#' + nameOfTable + 'Estatus' + rowIndex).val()==TryParseInt('3', '3') ||
 $('#' + nameOfTable + 'Estatus' + rowIndex).val()==TryParseInt('5', '5') ) 
 { 
 var valor2 = "exec Update_ActividaesEvento FLD[Estatus], " + valor;
 EvaluaQuery(valor2, rowIndex, nameOfTable);} 
 else {}

}
//BusinessRuleId:116, Attribute:2, Operation:Object, Event:AFTERSAVING

//BusinessRuleId:99, Attribute:2, Operation:Object, Event:AFTERSAVING
if(operation == 'New'){
if( $('#' + nameOfTable + 'Estatus' + rowIndex).val()==TryParseInt('2', '2') ) { EvaluaQuery("exec Insert_ActividadEventos "
+" GLOBAL[KeyValueInserted], FLD[Folio]", rowIndex, nameOfTable);} else {}

}
//BusinessRuleId:99, Attribute:2, Operation:Object, Event:AFTERSAVING

//NEWBUSINESSRULE_AFTERSAVING//
}

function EjecutarValidacionesAntesDeGuardarMRDetalle_Actividades_Evento(nameOfTable, rowIndex){
    var result = true;
    



//BusinessRuleId:98, Attribute:258814, Operation:Object, Event:BEFORESAVINGMR
if(operation == 'New'){
if( $('#' + nameOfTable + 'Duracion_maxima_por_paciente_mins' + rowIndex).val()>TryParseInt('60', '60') ) { alert(DecodifyText('El tiempo máximo es de 60 minutos, favor de introducir un valor menor.', rowIndex, nameOfTable));
result=false;} else {}

}
//BusinessRuleId:98, Attribute:258814, Operation:Object, Event:BEFORESAVINGMR

//BusinessRuleId:98, Attribute:258814, Operation:Object, Event:BEFORESAVINGMR
if(operation == 'Update'){
if( $('#' + nameOfTable + 'Duracion_maxima_por_paciente_mins' + rowIndex).val()>TryParseInt('60', '60') ) { alert(DecodifyText('El tiempo máximo es de 60 minutos, favor de introducir un valor menor.', rowIndex, nameOfTable));
result=false;} else {}

}
//BusinessRuleId:98, Attribute:258814, Operation:Object, Event:BEFORESAVINGMR

//BusinessRuleId:97, Attribute:258814, Operation:Object, Event:BEFORESAVINGMR
if(operation == 'New'){
if( $('#' + nameOfTable + 'Duracion_maxima_por_paciente_mins' + rowIndex).val()>=TryParseInt('1', '1') && $('#' + nameOfTable + 'Duracion_maxima_por_paciente_mins' + rowIndex).val()<TryParseInt('5', '5') ) { alert(DecodifyText('El tiempo mínimo es de 5 minutos, favor de introducir un valor mayor.', rowIndex, nameOfTable));
result=false;} else {}

}
//BusinessRuleId:97, Attribute:258814, Operation:Object, Event:BEFORESAVINGMR

//BusinessRuleId:97, Attribute:258814, Operation:Object, Event:BEFORESAVINGMR
if(operation == 'Update'){
if( $('#' + nameOfTable + 'Duracion_maxima_por_paciente_mins' + rowIndex).val()>=TryParseInt('1', '1') && $('#' + nameOfTable + 'Duracion_maxima_por_paciente_mins' + rowIndex).val()<TryParseInt('5', '5') ) { alert(DecodifyText('El tiempo mínimo es de 5 minutos, favor de introducir un valor mayor.', rowIndex, nameOfTable));
result=false;} else {}

}
//BusinessRuleId:97, Attribute:258814, Operation:Object, Event:BEFORESAVINGMR































//BusinessRuleId:120, Attribute:258814, Operation:Object, Event:BEFORESAVINGMR
if(operation == 'New'){
if( $('#' + nameOfTable + 'Duracion_maxima_por_paciente_mins' + rowIndex).val()>=TryParseInt('5', '5') && $('#' + nameOfTable + 'Duracion_maxima_por_paciente_mins' + rowIndex).val()<=TryParseInt('60', '60') ) { $('#' + nameOfTable + 'Cupo_limitado' + rowIndex).val('true'); DisabledControl($("#" + nameOfTable + "Cupo_limitado" + rowIndex), ("true" == "true")); $('#' + nameOfTable + 'Cupo_maximo' + rowIndex).val(EvaluaQuery("declare @TiempoTotal int"
+" set @TiempoTotal = (datediff(minute, 'FLD[Hora_inicio]', 'FLD[Hora_fin]'))-(datediff(minute, 'FLD[Hora_inicio_receso]', 'FLD[Hora_fin_receso]'))"
+" declare @CupoMaximo int"
+" set @CupoMaximo = ((@TiempoTotal)/(FLD[Duracion_maxima_por_paciente_mins]))"
+" select @CupoMaximo", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Cupo_maximo" + rowIndex), ("true" == "true")); SetNotRequiredToControl( $('#' + nameOfTable + 'Cupo_maximo' + rowIndex));} else {}

}
//BusinessRuleId:120, Attribute:258814, Operation:Object, Event:BEFORESAVINGMR

//BusinessRuleId:120, Attribute:258814, Operation:Object, Event:BEFORESAVINGMR
if(operation == 'Update'){
if( $('#' + nameOfTable + 'Duracion_maxima_por_paciente_mins' + rowIndex).val()>=TryParseInt('5', '5') && $('#' + nameOfTable + 'Duracion_maxima_por_paciente_mins' + rowIndex).val()<=TryParseInt('60', '60') ) { $('#' + nameOfTable + 'Cupo_limitado' + rowIndex).val('true'); DisabledControl($("#" + nameOfTable + "Cupo_limitado" + rowIndex), ("true" == "true")); $('#' + nameOfTable + 'Cupo_maximo' + rowIndex).val(EvaluaQuery("declare @TiempoTotal int"
+" set @TiempoTotal = (datediff(minute, 'FLD[Hora_inicio]', 'FLD[Hora_fin]'))-(datediff(minute, 'FLD[Hora_inicio_receso]', 'FLD[Hora_fin_receso]'))"
+" declare @CupoMaximo int"
+" set @CupoMaximo = ((@TiempoTotal)/(FLD[Duracion_maxima_por_paciente_mins]))"
+" select @CupoMaximo", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Cupo_maximo" + rowIndex), ("true" == "true")); SetNotRequiredToControl( $('#' + nameOfTable + 'Cupo_maximo' + rowIndex));} else {}

}
//BusinessRuleId:120, Attribute:258814, Operation:Object, Event:BEFORESAVINGMR

//BusinessRuleId:120, Attribute:258814, Operation:Object, Event:BEFORESAVINGMR
if(operation == 'Consult'){
if( $('#' + nameOfTable + 'Duracion_maxima_por_paciente_mins' + rowIndex).val()>=TryParseInt('5', '5') && $('#' + nameOfTable + 'Duracion_maxima_por_paciente_mins' + rowIndex).val()<=TryParseInt('60', '60') ) { $('#' + nameOfTable + 'Cupo_limitado' + rowIndex).val('true'); DisabledControl($("#" + nameOfTable + "Cupo_limitado" + rowIndex), ("true" == "true")); $('#' + nameOfTable + 'Cupo_maximo' + rowIndex).val(EvaluaQuery("declare @TiempoTotal int"
+" set @TiempoTotal = (datediff(minute, 'FLD[Hora_inicio]', 'FLD[Hora_fin]'))-(datediff(minute, 'FLD[Hora_inicio_receso]', 'FLD[Hora_fin_receso]'))"
+" declare @CupoMaximo int"
+" set @CupoMaximo = ((@TiempoTotal)/(FLD[Duracion_maxima_por_paciente_mins]))"
+" select @CupoMaximo", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Cupo_maximo" + rowIndex), ("true" == "true")); SetNotRequiredToControl( $('#' + nameOfTable + 'Cupo_maximo' + rowIndex));} else {}

}
//BusinessRuleId:120, Attribute:258814, Operation:Object, Event:BEFORESAVINGMR

//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Actividades_Evento//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRDetalle_Actividades_Evento(nameOfTable, rowIndex){
    







//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Actividades_Evento//
}
function EjecutarValidacionesAlEliminarMRDetalle_Actividades_Evento(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Detalle_Actividades_Evento//
    return result;
}
function EjecutarValidacionesNewRowMRDetalle_Actividades_Evento(nameOfTable, rowIndex){
    var result = true;
    



//BusinessRuleId:121, Attribute:258814, Operation:Object, Event:NEWROWMR
if(operation == 'New'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Cupo_maximo' + rowIndex)); DisabledControl($("#" + nameOfTable + "Cupo_maximo" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:121, Attribute:258814, Operation:Object, Event:NEWROWMR

//BusinessRuleId:121, Attribute:258814, Operation:Object, Event:NEWROWMR
if(operation == 'Update'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Cupo_maximo' + rowIndex)); DisabledControl($("#" + nameOfTable + "Cupo_maximo" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:121, Attribute:258814, Operation:Object, Event:NEWROWMR

//NEWBUSINESSRULE_NEWROWMR_Detalle_Actividades_Evento//
    return result;
}
function EjecutarValidacionesEditRowMRDetalle_Actividades_Evento(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Detalle_Actividades_Evento//
    return result;
}

