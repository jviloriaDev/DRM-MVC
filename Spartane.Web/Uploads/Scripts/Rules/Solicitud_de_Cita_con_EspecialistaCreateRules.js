var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
var saltarValidacion = false;
$(document).ready(function () {












//BusinessRuleId:158, Attribute:258908, Operation:Field, Event:None
$("form#CreateSolicitud_de_Cita_con_Especialista").on('change', '#Asististe_a_tu_cita', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Asististe_a_tu_cita' + rowIndex).val()==TryParseInt('1', '1') ) { $('#divCalificacion_Especialista').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Calificacion_Especialista' + rowIndex)); $('#divMotivo_no_concreto_cita').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Motivo_no_concreto_cita' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Motivo_no_concreto_cita' + rowIndex));} else { $('#divCalificacion_Especialista').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Calificacion_Especialista' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calificacion_Especialista' + rowIndex)); $('#divMotivo_no_concreto_cita').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Motivo_no_concreto_cita' + rowIndex));}
});

//BusinessRuleId:158, Attribute:258908, Operation:Field, Event:None

//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {




//BusinessRuleId:157, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#divFolio').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Folio' + rowIndex)); AsignarValor($('#' + nameOfTable + 'Fecha_de_solicitud' + rowIndex),EvaluaQuery("select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Hora_de_solicitud' + rowIndex),EvaluaQuery("select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Usuario_que_solicita' + rowIndex),EvaluaQuery("select GLOBAL[USERID]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_solicitud" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_de_solicitud" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_solicita" + rowIndex), ("true" == "true")); $('#divCalificacion_Especialista').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Calificacion_Especialista' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calificacion_Especialista' + rowIndex)); $('#divMotivo_no_concreto_cita').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Motivo_no_concreto_cita' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Motivo_no_concreto_cita' + rowIndex));

}
//BusinessRuleId:157, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:157, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 $('#divFolio').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Folio' + rowIndex)); AsignarValor($('#' + nameOfTable + 'Fecha_de_solicitud' + rowIndex),EvaluaQuery("select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Hora_de_solicitud' + rowIndex),EvaluaQuery("select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Usuario_que_solicita' + rowIndex),EvaluaQuery("select GLOBAL[USERID]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_solicitud" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_de_solicitud" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_solicita" + rowIndex), ("true" == "true")); $('#divCalificacion_Especialista').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Calificacion_Especialista' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calificacion_Especialista' + rowIndex)); $('#divMotivo_no_concreto_cita').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Motivo_no_concreto_cita' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Motivo_no_concreto_cita' + rowIndex));

}
//BusinessRuleId:157, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:160, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( $('#' + nameOfTable + 'Asististe_a_tu_cita' + rowIndex).val()==TryParseInt('1', '1') ) { $('#divCalificacion_Especialista').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Calificacion_Especialista' + rowIndex)); $('#divMotivo_no_concreto_cita').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Motivo_no_concreto_cita' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Motivo_no_concreto_cita' + rowIndex));} else { $('#divMotivo_no_concreto_cita').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Motivo_no_concreto_cita' + rowIndex)); $('#divCalificacion_Especialista').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Calificacion_Especialista' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calificacion_Especialista' + rowIndex));}

}
//BusinessRuleId:160, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:160, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( $('#' + nameOfTable + 'Asististe_a_tu_cita' + rowIndex).val()==TryParseInt('1', '1') ) { $('#divCalificacion_Especialista').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Calificacion_Especialista' + rowIndex)); $('#divMotivo_no_concreto_cita').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Motivo_no_concreto_cita' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Motivo_no_concreto_cita' + rowIndex));} else { $('#divMotivo_no_concreto_cita').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Motivo_no_concreto_cita' + rowIndex)); $('#divCalificacion_Especialista').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Calificacion_Especialista' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calificacion_Especialista' + rowIndex));}

}
//BusinessRuleId:160, Attribute:0, Operation:Object, Event:SCREENOPENING

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


