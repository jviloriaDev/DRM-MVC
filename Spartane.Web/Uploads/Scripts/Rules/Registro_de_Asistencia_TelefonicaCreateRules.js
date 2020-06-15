var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
var saltarValidacion = false;
$(document).ready(function () {
//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {
//BusinessRuleId:156, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#divFolio').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Folio' + rowIndex)); DisabledControl($("#" + nameOfTable + "Fecha_de_llamada" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_de_llamada" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_llama" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Dispositivo" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Nombre_Paciente" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Suscripcion" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Numero_telefonico_del_Paciente" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Correo_del_Paciente" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Telefono_de_Asistencia_marcado" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_inicio_de_la_Llamada" + rowIndex), ("true" == "true")); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_de_llamada' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Hora_de_llamada' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Usuario_que_llama' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Dispositivo' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_Paciente' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Suscripcion' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_telefonico_del_Paciente' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Correo_del_Paciente' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Telefono_de_Asistencia_marcado' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Hora_inicio_de_la_Llamada' + rowIndex));

}
//BusinessRuleId:156, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:156, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 $('#divFolio').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Folio' + rowIndex)); DisabledControl($("#" + nameOfTable + "Fecha_de_llamada" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_de_llamada" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_llama" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Dispositivo" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Nombre_Paciente" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Suscripcion" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Numero_telefonico_del_Paciente" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Correo_del_Paciente" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Telefono_de_Asistencia_marcado" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_inicio_de_la_Llamada" + rowIndex), ("true" == "true")); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_de_llamada' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Hora_de_llamada' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Usuario_que_llama' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Dispositivo' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_Paciente' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Suscripcion' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_telefonico_del_Paciente' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Correo_del_Paciente' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Telefono_de_Asistencia_marcado' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Hora_inicio_de_la_Llamada' + rowIndex));

}
//BusinessRuleId:156, Attribute:0, Operation:Object, Event:SCREENOPENING

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


