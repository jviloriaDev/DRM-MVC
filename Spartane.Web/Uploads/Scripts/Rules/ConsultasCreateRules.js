var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
var saltarValidacion = false;
$(document).ready(function () {


















//BusinessRuleId:45, Attribute:257911, Operation:Field, Event:None
$("form#CreateConsultas").on('keyup', '#Estatura', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'IMC' + rowIndex).val(EvaluaQuery(" SELECT round( (FLD[Peso_actual]/ ((cast (isnull(FLD[Estatura],0) as decimal) /100) * (cast (isnull(FLD[Estatura],0) as decimal) /100) )),2)", rowIndex, nameOfTable));
});

//BusinessRuleId:45, Attribute:257911, Operation:Field, Event:None

//BusinessRuleId:46, Attribute:257910, Operation:Field, Event:None
$("form#CreateConsultas").on('keyup', '#Peso_actual', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'IMC' + rowIndex).val(EvaluaQuery(" SELECT round( (FLD[Peso_actual]/ ((cast (isnull(FLD[Estatura],0) as decimal) /100) * (cast (isnull(FLD[Estatura],0) as decimal) /100) )),2)", rowIndex, nameOfTable));
});

//BusinessRuleId:46, Attribute:257910, Operation:Field, Event:None

//BusinessRuleId:47, Attribute:257911, Operation:Field, Event:None
$("form#CreateConsultas").on('keyup', '#Estatura', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Calorias' + rowIndex).val(EvaluaQuery(" exec Sp_selCalorias_paciente FLD[Sexo], FLD[Peso_actual], FLD[Estatura], 'FLD[Edad]', FLD[Esta_embarazada], FLD[Peso_pregestacional], FLD[Semana_de_gestacion]	", rowIndex, nameOfTable));
});

//BusinessRuleId:47, Attribute:257911, Operation:Field, Event:None



//BusinessRuleId:48, Attribute:257907, Operation:Field, Event:None
$("form#CreateConsultas").on('keyup', '#Frecuencia_Cardiaca', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Frecuencia_cardiaca_en_Esfuerzo' + rowIndex).val(EvaluaQuery("SELECT ROUND((((208 - 0.7 * FLD[Edad])- cast(isnull(FLD[Frecuencia_Cardiaca],0) as decimal))*0.7) + cast(isnull(FLD[Frecuencia_Cardiaca],0) as decimal),2)", rowIndex, nameOfTable));
});

//BusinessRuleId:48, Attribute:257907, Operation:Field, Event:None

//BusinessRuleId:49, Attribute:257912, Operation:Field, Event:None
$("form#CreateConsultas").on('keyup', '#Circunferencia_de_cintura_cm', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex).val(EvaluaQuery("SELECT round(cast(isnull(FLD[Circunferencia_de_cintura_cm],0) as decimal) / (cast(isnull(FLD[Circunferencia_de_cadera_cm],0) as decimal)),2) ", rowIndex, nameOfTable));
});

//BusinessRuleId:49, Attribute:257912, Operation:Field, Event:None

//BusinessRuleId:50, Attribute:257914, Operation:Field, Event:None
$("form#CreateConsultas").on('keyup', '#Circunferencia_de_cadera_cm', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex).val(EvaluaQuery(" SELECT round(cast(isnull(FLD[Circunferencia_de_cintura_cm],0) as decimal) / (cast(isnull(FLD[Circunferencia_de_cadera_cm],0) as decimal)),2)", rowIndex, nameOfTable));
});

//IMC bajo peso	
$("form#CreateConsultas").on('mouseleave', '#Estatura', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'IMC' + rowIndex).val()<TryParseInt('18.5', '18.5') ) { $('#' + nameOfTable + 'Interpretacion_IMC' + rowIndex).val('1');} else {}
});
$("form#CreateConsultas").on('mouseleave', '#Peso_actual', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'IMC' + rowIndex).val()<TryParseInt('18.5', '18.5') ) { $('#' + nameOfTable + 'Interpretacion_IMC' + rowIndex).val('1');} else {}
});

//IMC peso normal	$("form#CreateConsultas").on('mouseleave', '#Estatura', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'IMC' + rowIndex).val()>TryParseInt('18.5', '18.5') && $('#' + nameOfTable + 'IMC' + rowIndex).val()<TryParseInt('24.9', '24.9') ) { $('#' + nameOfTable + 'Interpretacion_IMC' + rowIndex).val('2');} else {}
});
$("form#CreateConsultas").on('mouseleave', '#Peso_actual', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'IMC' + rowIndex).val()>TryParseInt('18.5', '18.5') && $('#' + nameOfTable + 'IMC' + rowIndex).val()<TryParseInt('24.9', '24.9') ) { $('#' + nameOfTable + 'Interpretacion_IMC' + rowIndex).val('2');} else {}
});

//IMC sobrepeso
$("form#CreateConsultas").on('keyup', '#Estatura', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'IMC' + rowIndex).val()>TryParseInt('25', '25') && $('#' + nameOfTable + 'IMC' + rowIndex).val()<TryParseInt('29.9', '29.9') ) { $('#' + nameOfTable + 'Interpretacion_IMC' + rowIndex).val('3');} else {}
});
$("form#CreateConsultas").on('keyup', '#Peso_actual', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'IMC' + rowIndex).val()>TryParseInt('25', '25') && $('#' + nameOfTable + 'IMC' + rowIndex).val()<TryParseInt('29.9', '29.9') ) { $('#' + nameOfTable + 'Interpretacion_IMC' + rowIndex).val('3');} else {}
});

//IMC Obesidad grado 1
$("form#CreateConsultas").on('keyup', '#Estatura', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'IMC' + rowIndex).val()>TryParseInt('30', '30') && $('#' + nameOfTable + 'IMC' + rowIndex).val()<TryParseInt('34.5', '34.5') ) { $('#' + nameOfTable + 'Interpretacion_IMC' + rowIndex).val('4');} else {}
});
$("form#CreateConsultas").on('keyup', '#Peso_actual', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'IMC' + rowIndex).val()>TryParseInt('30', '30') && $('#' + nameOfTable + 'IMC' + rowIndex).val()<TryParseInt('34.5', '34.5') ) { $('#' + nameOfTable + 'Interpretacion_IMC' + rowIndex).val('4');} else {}
});

//IMC Obesidad grado 2
$("form#CreateConsultas").on('mouseleave', '#Estatura', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'IMC' + rowIndex).val()>TryParseInt('35', '35') && $('#' + nameOfTable + 'IMC' + rowIndex).val()<TryParseInt('39.9', '39.9') ) { $('#' + nameOfTable + 'Interpretacion_IMC' + rowIndex).val('5');} else {}
});
$("form#CreateConsultas").on('mouseleave', '#Peso_actual', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'IMC' + rowIndex).val()>TryParseInt('35', '35') && $('#' + nameOfTable + 'IMC' + rowIndex).val()<TryParseInt('39.9', '39.9') ) { $('#' + nameOfTable + 'Interpretacion_IMC' + rowIndex).val('5');} else {}
});

//IMC Obesidad grado 3
$("form#CreateConsultas").on('mouseleave', '#Estatura', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'IMC' + rowIndex).val()>TryParseInt('40', '40') ) { $('#' + nameOfTable + 'Interpretacion_IMC' + rowIndex).val('6');} else {}
});
$("form#CreateConsultas").on('mouseleave', '#Peso_actual', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'IMC' + rowIndex).val()>TryParseInt('40', '40') ) { $('#' + nameOfTable + 'Interpretacion_IMC' + rowIndex).val('6');} else {}
});

//Interpretacion indice cintura riesgo bajo
$("form#CreateConsultas").on('keyup', '#Circunferencia_de_cadera_cm', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Sexo' + rowIndex).val()==TryParseInt('1', '1') && $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex).val()<=TryParseInt('0.95', '0.95') ) { $('#' + nameOfTable + 'Interpretacion_indice' + rowIndex).val('1');} else {}
});
$("form#CreateConsultas").on('keyup', '#Circunferencia_de_cadera_cm', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Sexo' + rowIndex).val()==TryParseInt('2', '2') && $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex).val()<=TryParseInt('0.80', '0.80') ) { $('#' + nameOfTable + 'Interpretacion_indice' + rowIndex).val('1');} else {}
});
$("form#CreateConsultas").on('keyup', '#Circunferencia_de_cintura_cm', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Sexo' + rowIndex).val()==TryParseInt('1', '1') && $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex).val()<=TryParseInt('0.95', '0.95') ) { $('#' + nameOfTable + 'Interpretacion_indice' + rowIndex).val('1');} else {}
});
$("form#CreateConsultas").on('keyup', '#Circunferencia_de_cintura_cm', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Sexo' + rowIndex).val()==TryParseInt('2', '2') && $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex).val()<=TryParseInt('0.80', '0.80') ) { $('#' + nameOfTable + 'Interpretacion_indice' + rowIndex).val('1');} else {}
});

//Interpretacion indice cintura riesgo medio
$("form#CreateConsultas").on('keyup', '#Circunferencia_de_cadera_cm', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Sexo' + rowIndex).val()==TryParseInt('1', '1') && $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex).val()>TryParseInt('0.96', '0.96') && $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex).val()<TryParseInt('1.0', '1.0') ) { $('#' + nameOfTable + 'Interpretacion_indice' + rowIndex).val('2');} else {}
});
$("form#CreateConsultas").on('keyup', '#Circunferencia_de_cadera_cm', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Sexo' + rowIndex).val()==TryParseInt('2', '2') && $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex).val()>TryParseInt('0.81', '0.81') && $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex).val()<TryParseInt('0.85', '0.85') ) { $('#' + nameOfTable + 'Interpretacion_indice' + rowIndex).val('2');} else {}
});
$("form#CreateConsultas").on('keyup', '#Circunferencia_de_cintura_cm', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Sexo' + rowIndex).val()==TryParseInt('1', '1') && $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex).val()>TryParseInt('0.96', '0.96') && $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex).val()<TryParseInt('1.0', '1.0') ) { $('#' + nameOfTable + 'Interpretacion_indice' + rowIndex).val('2');} else {}
});
$("form#CreateConsultas").on('keyup', '#Circunferencia_de_cintura_cm', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Sexo' + rowIndex).val()==TryParseInt('2', '2') && $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex).val()>TryParseInt('0.81', '0.81') && $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex).val()<TryParseInt('0.85', '0.85') ) { $('#' + nameOfTable + 'Interpretacion_indice' + rowIndex).val('2');} else {}
});

//Interpretacion indice cintura riesgo alto
$("form#CreateConsultas").on('keyup', '#Circunferencia_de_cadera_cm', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Sexo' + rowIndex).val()==TryParseInt('1', '1') && $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex).val()>=TryParseInt('1.0', '1.0') ) { $('#' + nameOfTable + 'Interpretacion_indice' + rowIndex).val('3');} else {}
});
$("form#CreateConsultas").on('keyup', '#Circunferencia_de_cadera_cm', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Sexo' + rowIndex).val()==TryParseInt('2', '2') && $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex).val()>=TryParseInt('0.85', '0.85') ) { $('#' + nameOfTable + 'Interpretacion_indice' + rowIndex).val('3');} else {}
});
$("form#CreateConsultas").on('keyup', '#Circunferencia_de_cintura_cm', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Sexo' + rowIndex).val()==TryParseInt('1', '1') && $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex).val()>=TryParseInt('1.0', '1.0') ) { $('#' + nameOfTable + 'Interpretacion_indice' + rowIndex).val('3');} else {}
});
$("form#CreateConsultas").on('keyup', '#Circunferencia_de_cintura_cm', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Sexo' + rowIndex).val()==TryParseInt('2', '2') && $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex).val()>=TryParseInt('0.85', '0.85') ) { $('#' + nameOfTable + 'Interpretacion_indice' + rowIndex).val('3');} else {}
});

//BusinessRuleId:50, Attribute:257914, Operation:Field, Event:None













//BusinessRuleId:44, Attribute:257901, Operation:Field, Event:None
$("form#CreateConsultas").on('change', '#Paciente', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Edad' + rowIndex).val()<TryParseInt('18', '18') ) { DisabledControl($("#" + nameOfTable + "Estatura" + rowIndex), ("false" == "true")); $('#divNombre_del_padre').css('display', 'block'); AsignarValor($('#' + nameOfTable + 'Estatura' + rowIndex),EvaluaQuery("select NULL"
+" ", rowIndex, nameOfTable)); $('#divIMC_Pediatria').css('display', 'block'); $('.IMC_PediatriaHeader').css('display', 'block'); SetNotRequiredToControl( $('#' + nameOfTable + 'Interpretacion_IMC' + rowIndex)); $('#divInterpretacion_IMC').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Interpretacion_IMC' + rowIndex)); $('.IMCHeader').css('display', 'none');
var index = $('.IMCHeader').index();
 eval($('.IMCHeader').parent().parent().parent()[0].id.replace("Grid", "Table")).find("td:eq("+index+")").hide();} else { $('#divNombre_del_padre').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_del_padre' + rowIndex)); DisabledControl($("#" + nameOfTable + "Estatura" + rowIndex), ("true" == "true")); AsignarValor($('#' + nameOfTable + 'Estatura' + rowIndex),EvaluaQuery(" SELECT Estatura from Pacientes where Folio = FLD[Paciente]", rowIndex, nameOfTable)); $('#divIMC_Pediatria').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'IMC_Pediatria' + rowIndex)); $('.IMC_PediatriaHeader').css('display', 'none');
var index = $('.IMC_PediatriaHeader').index();
 eval($('.IMC_PediatriaHeader').parent().parent().parent()[0].id.replace("Grid", "Table")).find("td:eq("+index+")").hide(); SetNotRequiredToControl( $('#' + nameOfTable + 'IMC_Pediatria' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'IMC_Pediatria' + rowIndex)); $('#divIMC').css('display', 'block'); $('.IMCHeader').css('display', 'block');}
});

//BusinessRuleId:44, Attribute:257901, Operation:Field, Event:None



//BusinessRuleId:41, Attribute:257901, Operation:Field, Event:None
$("form#CreateConsultas").on('change', '#Paciente', function () {
	nameOfTable='';
	rowIndex='';
 AsignarValor($('#' + nameOfTable + 'Nombre_del_padre' + rowIndex),EvaluaQuery("SELECT Nombre_del_padre_o_tutor from Pacientes where Folio = FLD[Paciente]", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Sexo' + rowIndex),EvaluaQuery(" SELECT Sexo from Pacientes where Folio = FLD[Paciente]", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Email' + rowIndex),EvaluaQuery("SELECT Email from Pacientes where Folio = FLD[Paciente]", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Objetivo' + rowIndex),EvaluaQuery("SELECT Objetivo from Pacientes where Folio = FLD[Paciente]", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Edad' + rowIndex),EvaluaQuery(" select dbo.FncGetEdad(Fecha_de_nacimiento) from Pacientes where Folio = FLD[Paciente]", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Estatura' + rowIndex),EvaluaQuery("SELECT Estatura from Pacientes where Folio = FLD[Paciente]", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Frecuencia_Cardiaca' + rowIndex),EvaluaQuery("SELECT Frecuencia_Cardiaca from Pacientes where Folio = FLD[Paciente]", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Presion_sistolica' + rowIndex),EvaluaQuery(" SELECT Presion_sistolica from Pacientes where Folio = FLD[Paciente]", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Presion_diastolica' + rowIndex),EvaluaQuery(""
+" "
+" SELECT Presion_diastolica from Pacientes where Folio = FLD[Paciente]", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Peso_actual' + rowIndex),EvaluaQuery("SELECT Peso_actual from Pacientes where Folio = FLD[Paciente]", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Circunferencia_de_cintura_cm' + rowIndex),EvaluaQuery("SELECT Circunferencia_de_cintura_cm from Pacientes where Folio = FLD[Paciente]", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Circunferencia_de_cadera_cm' + rowIndex),EvaluaQuery("SELECT Circunferencia_de_cadera_cm from Pacientes where Folio = FLD[Paciente]", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Edad_Metabolica' + rowIndex),EvaluaQuery("SELECT Edad_Metabolica from Pacientes where Folio = FLD[Paciente]", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Agua_corporal' + rowIndex),EvaluaQuery("SELECT Agua_corporal from Pacientes where Folio = FLD[Paciente]", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Grasa_Visceral' + rowIndex),EvaluaQuery("SELECT Grasa_Visceral from Pacientes where Folio = FLD[Paciente]", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Grasa_Corporal' + rowIndex),EvaluaQuery("SELECT Grasa_Corporal from Pacientes where Folio = FLD[Paciente]", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Grasa_Corporal_kg' + rowIndex),EvaluaQuery("SELECT Grasa_Corporal_kg from Pacientes where Folio = FLD[Paciente]", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Masa_Muscular_kg' + rowIndex),EvaluaQuery("SELECT Masa_Muscular_kg from Pacientes where Folio = FLD[Paciente]", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Semana_de_gestacion' + rowIndex),EvaluaQuery("SELECT Semana_de_gestacion from Pacientes where Folio = FLD[Paciente]", rowIndex, nameOfTable));
});

//BusinessRuleId:41, Attribute:257901, Operation:Field, Event:None

//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {
//BusinessRuleId:42, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_del_padre' + rowIndex)); $('#divNombre_del_padre').css('display', 'none');

}
//BusinessRuleId:42, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:42, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_del_padre' + rowIndex)); $('#divNombre_del_padre').css('display', 'none');

}
//BusinessRuleId:42, Attribute:0, Operation:Object, Event:SCREENOPENING





//BusinessRuleId:148, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 if('true' == 'true')
{
	$('#divResultados a').attr('disabled', 'disabled');
	$('#divResultados a').css("pointer-events","none");
}
else
{
	$('#divResultados a').attr('disabled', '');
	$('#divResultados a').css("pointer-events","all");
} $('.Folio_PacientesHeader').css('display', 'none');
var index = $('.Folio_PacientesHeader').index();
 eval($('.Folio_PacientesHeader').parent().parent().parent()[0].id.replace("Grid", "Table")).find("td:eq("+index+")").hide();

}
//BusinessRuleId:148, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:148, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 if('true' == 'true')
{
	$('#divResultados a').attr('disabled', 'disabled');
	$('#divResultados a').css("pointer-events","none");
}
else
{
	$('#divResultados a').attr('disabled', '');
	$('#divResultados a').css("pointer-events","all");
} $('.Folio_PacientesHeader').css('display', 'none');
var index = $('.Folio_PacientesHeader').index();
 eval($('.Folio_PacientesHeader').parent().parent().parent()[0].id.replace("Grid", "Table")).find("td:eq("+index+")").hide();

}
//BusinessRuleId:148, Attribute:0, Operation:Object, Event:SCREENOPENING

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



function EjecutarValidacionesAntesDeGuardarMRDetalle_Resultados_Consultas(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Resultados_Consultas// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Resultados_Consultas(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Resultados_Consultas// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Resultados_Consultas(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Resultados_Consultas// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Resultados_Consultas(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Detalle_Resultados_Consultas// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Resultados_Consultas(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detalle_Resultados_Consultas// 
 return result; 
} 
