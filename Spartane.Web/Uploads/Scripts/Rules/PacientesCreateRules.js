var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
$(document).ready(function () {










//BusinessRuleId:2, Attribute:257715, Operation:Field, Event:None
$("form#CreatePacientes").on('change', '#Sexo', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Sexo' + rowIndex).val()==TryParseInt('1', '1') ) { $("a[href='#tabDatos_Ginecologicos']").css('display', 'none');} else {}
});

//BusinessRuleId:2, Attribute:257715, Operation:Field, Event:None

//BusinessRuleId:3, Attribute:257715, Operation:Field, Event:None
$("form#CreatePacientes").on('change', '#Sexo', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Sexo' + rowIndex).val()==TryParseInt('2', '2') ) { $("a[href='#tabDatos_Ginecologicos']").css('display', 'block');} else {}
});

//BusinessRuleId:3, Attribute:257715, Operation:Field, Event:None













//BusinessRuleId:4, Attribute:257796, Operation:Field, Event:None
$("form#CreatePacientes").on('keyup', '#Estatura', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'IMC' + rowIndex).val(EvaluaQuery("SELECT round( (FLD[Peso_actual]/ ((cast (isnull(FLD[Estatura]*100,0) as decimal)/100) * (cast (isnull(FLD[Estatura]*100,0) as decimal) /100) )),2)", rowIndex, nameOfTable));
});

//BusinessRuleId:4, Attribute:257796, Operation:Field, Event:None





























//BusinessRuleId:10, Attribute:257819, Operation:Field, Event:None
$("form#CreatePacientes").on('change', '#Toma_anticonceptivos', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Toma_anticonceptivos' + rowIndex).val()==TryParseInt('1', '1') ) { $('#divNombre_del_Anticonceptivo').css('display', 'block'); $('#divDosis').css('display', 'block');} else {}
});

//BusinessRuleId:10, Attribute:257819, Operation:Field, Event:None

//BusinessRuleId:11, Attribute:257819, Operation:Field, Event:None
$("form#CreatePacientes").on('change', '#Toma_anticonceptivos', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Toma_anticonceptivos' + rowIndex).val()==TryParseInt('2', '2') ) { $('#divNombre_del_Anticonceptivo').css('display', 'none'); $('#divDosis').css('display', 'none');} else {}
});

//BusinessRuleId:11, Attribute:257819, Operation:Field, Event:None



//BusinessRuleId:13, Attribute:257822, Operation:Field, Event:None
$("form#CreatePacientes").on('change', '#Climaterio', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Climaterio' + rowIndex).val()==TryParseInt('1', '1') ) { $('#divFecha_Climaterio').css('display', 'block');} else {}
});

//BusinessRuleId:13, Attribute:257822, Operation:Field, Event:None

//BusinessRuleId:14, Attribute:257822, Operation:Field, Event:None
$("form#CreatePacientes").on('change', '#Climaterio', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Climaterio' + rowIndex).val()==TryParseInt('2', '2') ) { $('#divFecha_Climaterio').css('display', 'none');} else {}
});

//BusinessRuleId:14, Attribute:257822, Operation:Field, Event:None

//BusinessRuleId:15, Attribute:257824, Operation:Field, Event:None
$("form#CreatePacientes").on('change', '#Terapia_reemplazo_hormonal', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Terapia_reemplazo_hormonal' + rowIndex).val()==TryParseInt('1', '1') ) { if('false' == 'true')
{
	$('#divDetalle_de_Terapia_Hormonal').css('display', 'none');
}
else
{
	$('#divDetalle_de_Terapia_Hormonal').css('display', 'block');
}} else {}
});

//BusinessRuleId:15, Attribute:257824, Operation:Field, Event:None

//BusinessRuleId:16, Attribute:257824, Operation:Field, Event:None
$("form#CreatePacientes").on('change', '#Terapia_reemplazo_hormonal', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Terapia_reemplazo_hormonal' + rowIndex).val()==TryParseInt('2', '2') ) { if('true' == 'true')
{
	$('#divDetalle_de_Terapia_Hormonal').css('display', 'none');
}
else
{
	$('#divDetalle_de_Terapia_Hormonal').css('display', 'block');
}} else {}
});

//BusinessRuleId:16, Attribute:257824, Operation:Field, Event:None

//BusinessRuleId:17, Attribute:257721, Operation:Field, Event:None
$("form#CreatePacientes").on('change', '#Frecuencia_Ejercicio', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Frecuencia_Ejercicio' + rowIndex).val()==TryParseInt('5', '5') || $('#' + nameOfTable + 'Frecuencia_Ejercicio' + rowIndex).val()==TryParseInt('6', '6') ) { $('#' + nameOfTable + 'Dificultad_de_Rutina_de_Ejercicios' + rowIndex).val('Principiante');} else {}
});

//BusinessRuleId:17, Attribute:257721, Operation:Field, Event:None

//BusinessRuleId:18, Attribute:257721, Operation:Field, Event:None
$("form#CreatePacientes").on('change', '#Frecuencia_Ejercicio', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Frecuencia_Ejercicio' + rowIndex).val()==TryParseInt('7', '7') ) { $('#' + nameOfTable + 'Dificultad_de_Rutina_de_Ejercicios' + rowIndex).val('Intermedio');} else {}
});

//BusinessRuleId:18, Attribute:257721, Operation:Field, Event:None

//BusinessRuleId:19, Attribute:257721, Operation:Field, Event:None
$("form#CreatePacientes").on('change', '#Frecuencia_Ejercicio', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Frecuencia_Ejercicio' + rowIndex).val()==TryParseInt('8', '8') ) { $('#' + nameOfTable + 'Dificultad_de_Rutina_de_Ejercicios' + rowIndex).val('Avanzado');} else {}
});

//BusinessRuleId:19, Attribute:257721, Operation:Field, Event:None

//BusinessRuleId:9, Attribute:257816, Operation:Field, Event:None
$("form#CreatePacientes").on('change', '#Esta_embarazada', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Esta_embarazada' + rowIndex).val()==TryParseInt('1', '1') ) { $('#divSemana_de_gestacion').css('display', 'block'); $('#divPeso_pregestacional').css('display', 'block');} else {}
});

//BusinessRuleId:9, Attribute:257816, Operation:Field, Event:None



//BusinessRuleId:12, Attribute:257816, Operation:Field, Event:None
$("form#CreatePacientes").on('change', '#Esta_embarazada', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Esta_embarazada' + rowIndex).val()==TryParseInt('2', '2') ) { $('#divSemana_de_gestacion').css('display', 'none'); $('#divPeso_pregestacional').css('display', 'none');} else {}
});

//BusinessRuleId:12, Attribute:257816, Operation:Field, Event:None

//BusinessRuleId:20, Attribute:257801, Operation:Field, Event:None
$("form#CreatePacientes").on('keyup', '#Anchura_de_muneca_mm', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Complexion_corporal' + rowIndex).val(EvaluaQuery("SELECT round(cast(isnull(FLD[Estatura],0) as decimal) / (cast(isnull(FLD[Anchura_de_muneca_mm],0) as decimal)),2)", rowIndex, nameOfTable));
});

//BusinessRuleId:20, Attribute:257801, Operation:Field, Event:None

//BusinessRuleId:22, Attribute:257739, Operation:Field, Event:None
$("form#CreatePacientes").on('change', '#Medicamentos_bajar_peso', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Medicamentos_bajar_peso' + rowIndex).val()==TryParseInt('1', '1') ) { $('#divCual_medicamento').css('display', 'block');} else {}
});

//BusinessRuleId:22, Attribute:257739, Operation:Field, Event:None

//BusinessRuleId:23, Attribute:257739, Operation:Field, Event:None
$("form#CreatePacientes").on('change', '#Medicamentos_bajar_peso', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Medicamentos_bajar_peso' + rowIndex).val()==TryParseInt('2', '2') ) { $('#divCual_medicamento').css('display', 'none');} else {}
});

//BusinessRuleId:23, Attribute:257739, Operation:Field, Event:None



























































//BusinessRuleId:30, Attribute:257796, Operation:Field, Event:None
$("form#CreatePacientes").on('keyup', '#Estatura', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Calorias' + rowIndex).val(EvaluaQuery("exec Sp_selCalorias_paciente FLD[Sexo], FLD[Peso_actual], FLD[Estatura], 'FLD[Fecha_de_nacimiento]', FLD[Esta_embarazada], FLD[Peso_pregestacional], FLD[Semana_de_gestacion]", rowIndex, nameOfTable));
});

//BusinessRuleId:30, Attribute:257796, Operation:Field, Event:None

//BusinessRuleId:25, Attribute:257795, Operation:Field, Event:None
$("form#CreatePacientes").on('keyup', '#Peso_actual', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Calorias' + rowIndex).val(EvaluaQuery("	exec Sp_selCalorias_paciente FLD[Sexo], FLD[Peso_actual], FLD[Estatura], 'FLD[Fecha_de_nacimiento]', FLD[Esta_embarazada], FLD[Peso_pregestacional], FLD[Semana_de_gestacion]", rowIndex, nameOfTable));
});

//BusinessRuleId:25, Attribute:257795, Operation:Field, Event:None

//BusinessRuleId:35, Attribute:257713, Operation:Field, Event:None
$("form#CreatePacientes").on('change', '#Fecha_de_nacimiento', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Calorias' + rowIndex).val(EvaluaQuery("	exec Sp_selCalorias_paciente FLD[Sexo], FLD[Peso_actual], FLD[Estatura], 'FLD[Fecha_de_nacimiento]', FLD[Esta_embarazada], FLD[Peso_pregestacional], FLD[Semana_de_gestacion] ", rowIndex, nameOfTable));
});

//BusinessRuleId:35, Attribute:257713, Operation:Field, Event:None

//BusinessRuleId:29, Attribute:257715, Operation:Field, Event:None
$("form#CreatePacientes").on('change', '#Sexo', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Calorias' + rowIndex).val(EvaluaQuery("	exec Sp_selCalorias_paciente FLD[Sexo], FLD[Peso_actual], FLD[Estatura], 'FLD[Fecha_de_nacimiento]', FLD[Esta_embarazada], FLD[Peso_pregestacional], FLD[Semana_de_gestacion]", rowIndex, nameOfTable));
});

//BusinessRuleId:29, Attribute:257715, Operation:Field, Event:None

//BusinessRuleId:31, Attribute:257816, Operation:Field, Event:None
$("form#CreatePacientes").on('change', '#Esta_embarazada', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Calorias' + rowIndex).val(EvaluaQuery("	exec Sp_selCalorias_paciente FLD[Sexo], FLD[Peso_actual], FLD[Estatura], 'FLD[Fecha_de_nacimiento]', FLD[Esta_embarazada], FLD[Peso_pregestacional], FLD[Semana_de_gestacion]", rowIndex, nameOfTable));
});

//BusinessRuleId:31, Attribute:257816, Operation:Field, Event:None

//BusinessRuleId:26, Attribute:257817, Operation:Field, Event:None
$("form#CreatePacientes").on('keyup', '#Semana_de_gestacion', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Calorias' + rowIndex).val(EvaluaQuery("	exec Sp_selCalorias_paciente FLD[Sexo], FLD[Peso_actual], FLD[Estatura], 'FLD[Fecha_de_nacimiento]', FLD[Esta_embarazada], FLD[Peso_pregestacional], FLD[Semana_de_gestacion]", rowIndex, nameOfTable));
});

//BusinessRuleId:26, Attribute:257817, Operation:Field, Event:None

//BusinessRuleId:27, Attribute:257818, Operation:Field, Event:None
$("form#CreatePacientes").on('keyup', '#Peso_pregestacional', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Calorias' + rowIndex).val(EvaluaQuery("	exec Sp_selCalorias_paciente FLD[Sexo], FLD[Peso_actual], FLD[Estatura], 'FLD[Fecha_de_nacimiento]', FLD[Esta_embarazada], FLD[Peso_pregestacional], FLD[Semana_de_gestacion]", rowIndex, nameOfTable));
});

//BusinessRuleId:27, Attribute:257818, Operation:Field, Event:None

//BusinessRuleId:37, Attribute:257717, Operation:Field, Event:None
	$('#Email').change(function(){ 
		let email = $('#Email').val(); 
		let exp = new RegExp(/^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/); 
		if (exp.test(email) == false){ 
			$('#Email').attr("placeholder", "Correo electrónico no válido.").val("").focus().blur(); 
		} 
	});
//BusinessRuleId:37, Attribute:257717, Operation:Field, Event:None



//BusinessRuleId:38, Attribute:257800, Operation:Field, Event:None
$("form#CreatePacientes").on('keyup', '#Circunferencia_de_cadera_cm', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Distribucion_de_grasa_corporal' + rowIndex).val(EvaluaQuery("SELECT round(cast(isnull(FLD[Circunferencia_de_cintura_cm],0) as decimal) / (cast(isnull(FLD[Circunferencia_de_cadera_cm],0) as decimal)),2)", rowIndex, nameOfTable));
});

//BusinessRuleId:38, Attribute:257800, Operation:Field, Event:None

//BusinessRuleId:39, Attribute:257800, Operation:Field, Event:None
$("form#CreatePacientes").on('keyup', '#Circunferencia_de_cadera_cm', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex).val(EvaluaQuery(" "
+" SELECT round(cast(isnull(FLD[Circunferencia_de_cintura_cm],0) as decimal) / (cast(isnull(FLD[Circunferencia_de_cadera_cm],0) as decimal)),2)", rowIndex, nameOfTable));
});

//BusinessRuleId:39, Attribute:257800, Operation:Field, Event:None

//BusinessRuleId:40, Attribute:257797, Operation:Field, Event:None

//BusinessRuleId:40, Attribute:257797, Operation:Field, Event:None



//BusinessRuleId:51, Attribute:257795, Operation:Field, Event:None
$("form#CreatePacientes").on('keyup', '#Peso_actual', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Frecuencia_cardiaca_en_Esfuerzo' + rowIndex).val(EvaluaQuery(" 	SELECT round( (FLD[Peso_actual]/ ((cast (isnull(FLD[Estatura],0) as decimal) /100) * (cast (isnull(FLD[Estatura],0) as decimal) /100) )),2)", rowIndex, nameOfTable));
});

//BusinessRuleId:51, Attribute:257795, Operation:Field, Event:None













//BusinessRuleId:56, Attribute:257796, Operation:Field, Event:None
$("form#CreatePacientes").on('mouseleave', '#Estatura', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'IMC' + rowIndex).val()<TryParseInt('18.5', '18.5') ) { $('#' + nameOfTable + 'Interpretacion_IMC' + rowIndex).val('1');} else {}
});
$("form#CreatePacientes").on('mouseleave', '#Peso_actual', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'IMC' + rowIndex).val()<TryParseInt('18.5', '18.5') ) { $('#' + nameOfTable + 'Interpretacion_IMC' + rowIndex).val('1');} else {}
});
//BusinessRuleId:56, Attribute:257796, Operation:Field, Event:None



//BusinessRuleId:57, Attribute:257796, Operation:Field, Event:None
$("form#CreatePacientes").on('mouseleave', '#Estatura', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'IMC' + rowIndex).val()>TryParseInt('18.5', '18.5') && $('#' + nameOfTable + 'IMC' + rowIndex).val()<TryParseInt('24.9', '24.9') ) { $('#' + nameOfTable + 'Interpretacion_IMC' + rowIndex).val('2');} else {}
});
$("form#CreatePacientes").on('mouseleave', '#Peso_actual', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'IMC' + rowIndex).val()>TryParseInt('18.5', '18.5') && $('#' + nameOfTable + 'IMC' + rowIndex).val()<TryParseInt('24.9', '24.9') ) { $('#' + nameOfTable + 'Interpretacion_IMC' + rowIndex).val('2');} else {}
});
//BusinessRuleId:57, Attribute:257796, Operation:Field, Event:None





//BusinessRuleId:61, Attribute:257796, Operation:Field, Event:None
$("form#CreatePacientes").on('mouseleave', '#Estatura', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'IMC' + rowIndex).val()>TryParseInt('35', '35') && $('#' + nameOfTable + 'IMC' + rowIndex).val()<TryParseInt('39.9', '39.9') ) { $('#' + nameOfTable + 'Interpretacion_IMC' + rowIndex).val('5');} else {}
});
$("form#CreatePacientes").on('mouseleave', '#Peso_actual', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'IMC' + rowIndex).val()>TryParseInt('35', '35') && $('#' + nameOfTable + 'IMC' + rowIndex).val()<TryParseInt('39.9', '39.9') ) { $('#' + nameOfTable + 'Interpretacion_IMC' + rowIndex).val('5');} else {}
});

//BusinessRuleId:61, Attribute:257796, Operation:Field, Event:None



//BusinessRuleId:62, Attribute:257796, Operation:Field, Event:None
$("form#CreatePacientes").on('mouseleave', '#Estatura', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'IMC' + rowIndex).val()>TryParseInt('40', '40') ) { $('#' + nameOfTable + 'Interpretacion_IMC' + rowIndex).val('6');} else {}
});
$("form#CreatePacientes").on('mouseleave', '#Peso_actual', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'IMC' + rowIndex).val()>TryParseInt('40', '40') ) { $('#' + nameOfTable + 'Interpretacion_IMC' + rowIndex).val('6');} else {}
});
//BusinessRuleId:62, Attribute:257796, Operation:Field, Event:None

//BusinessRuleId:59, Attribute:257796, Operation:Field, Event:None
$("form#CreatePacientes").on('keyup', '#Estatura', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'IMC' + rowIndex).val()>TryParseInt('25', '25') && $('#' + nameOfTable + 'IMC' + rowIndex).val()<TryParseInt('29.9', '29.9') ) { $('#' + nameOfTable + 'Interpretacion_IMC' + rowIndex).val('3');} else {}
});
$("form#CreatePacientes").on('keyup', '#Peso_actual', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'IMC' + rowIndex).val()>TryParseInt('25', '25') && $('#' + nameOfTable + 'IMC' + rowIndex).val()<TryParseInt('29.9', '29.9') ) { $('#' + nameOfTable + 'Interpretacion_IMC' + rowIndex).val('3');} else {}
});
//BusinessRuleId:59, Attribute:257796, Operation:Field, Event:None

//BusinessRuleId:63, Attribute:257795, Operation:Field, Event:None
$("form#CreatePacientes").on('keyup', '#Peso_actual', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'IMC' + rowIndex).val(EvaluaQuery("SELECT round( (FLD[Peso_actual]/ ((cast (isnull(FLD[Estatura]*100,0) as decimal)/100) * (cast (isnull(FLD[Estatura]*100,0) as decimal) /100) )),2)", rowIndex, nameOfTable));
});

//BusinessRuleId:63, Attribute:257795, Operation:Field, Event:None

//BusinessRuleId:64, Attribute:257800, Operation:Field, Event:None
$("form#CreatePacientes").on('keyup', '#Anchura_de_muneca_mm', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Complexion_corporal' + rowIndex).val()>TryParseInt('11', '11') && $('#' + nameOfTable + 'Sexo' + rowIndex).val()==TryParseInt('2', '2') ) { $('#' + nameOfTable + 'Interpretacion_complexion_corporal' + rowIndex).val('1');} else {}
});

//BusinessRuleId:64, Attribute:257800, Operation:Field, Event:None



//BusinessRuleId:66, Attribute:257800, Operation:Field, Event:None
$("form#CreatePacientes").on('keyup', '#Anchura_de_muneca_mm', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Complexion_corporal' + rowIndex).val()<TryParseInt('10.1', '10.1') && $('#' + nameOfTable + 'Sexo' + rowIndex).val()==TryParseInt('2', '2') ) { $('#' + nameOfTable + 'Interpretacion_complexion_corporal' + rowIndex).val('3');} else {}
});

//BusinessRuleId:66, Attribute:257800, Operation:Field, Event:None

//BusinessRuleId:65, Attribute:257800, Operation:Field, Event:None
$("form#CreatePacientes").on('keyup', '#Anchura_de_muneca_mm', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Complexion_corporal' + rowIndex).val()>TryParseInt('10.1', '10.1') && $('#' + nameOfTable + 'Complexion_corporal' + rowIndex).val()<TryParseInt('11', '11') && $('#' + nameOfTable + 'Sexo' + rowIndex).val()==TryParseInt('2', '2') ) { $('#' + nameOfTable + 'Interpretacion_complexion_corporal' + rowIndex).val('2');} else {}
});

//BusinessRuleId:65, Attribute:257800, Operation:Field, Event:None

//BusinessRuleId:67, Attribute:257801, Operation:Field, Event:None
$("form#CreatePacientes").on('keyup', '#Anchura_de_muneca_mm', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Interpretacion_complexion_corporal' + rowIndex).val('1');
});

//BusinessRuleId:67, Attribute:257801, Operation:Field, Event:None

//BusinessRuleId:68, Attribute:257801, Operation:Field, Event:None
$("form#CreatePacientes").on('keyup', '#Anchura_de_muneca_mm', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Interpretacion_complexion_corporal' + rowIndex).val('2');
});

//BusinessRuleId:68, Attribute:257801, Operation:Field, Event:None

//BusinessRuleId:69, Attribute:257801, Operation:Field, Event:None
$("form#CreatePacientes").on('keyup', '#Anchura_de_muneca_mm', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Interpretacion_complexion_corporal' + rowIndex).val('3');
});

//BusinessRuleId:69, Attribute:257801, Operation:Field, Event:None



//BusinessRuleId:70, Attribute:257800, Operation:Field, Event:None
$("form#CreatePacientes").on('keyup', '#Circunferencia_de_cadera_cm', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Distribucion_de_grasa_corporal' + rowIndex).val()>=TryParseInt('1.0', '1.0') && $('#' + nameOfTable + 'Sexo' + rowIndex).val()==TryParseInt('1', '1') ) { $('#' + nameOfTable + 'Interpretacion_grasa_corporal' + rowIndex).val('1');} else { $('#' + nameOfTable + 'Interpretacion_grasa_corporal' + rowIndex).val('2');}
});
$("form#CreatePacientes").on('keyup', '#Circunferencia_de_cintura_cm', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Distribucion_de_grasa_corporal' + rowIndex).val()>=TryParseInt('1.0', '1.0') && $('#' + nameOfTable + 'Sexo' + rowIndex).val()==TryParseInt('1', '1') ) { $('#' + nameOfTable + 'Interpretacion_grasa_corporal' + rowIndex).val('1');} else { $('#' + nameOfTable + 'Interpretacion_grasa_corporal' + rowIndex).val('2');}
});
//BusinessRuleId:70, Attribute:257800, Operation:Field, Event:None

//BusinessRuleId:71, Attribute:257800, Operation:Field, Event:None
$("form#CreatePacientes").on('keyup', '#Circunferencia_de_cadera_cm', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Distribucion_de_grasa_corporal' + rowIndex).val()>=TryParseInt('0.8', '0.8') && $('#' + nameOfTable + 'Sexo' + rowIndex).val()==TryParseInt('2', '2') ) { $('#' + nameOfTable + 'Interpretacion_grasa_corporal' + rowIndex).val('1');} else { $('#' + nameOfTable + 'Interpretacion_grasa_corporal' + rowIndex).val('2');}
});
$("form#CreatePacientes").on('keyup', '#Circunferencia_de_cintura_cm', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Distribucion_de_grasa_corporal' + rowIndex).val()>=TryParseInt('0.8', '0.8') && $('#' + nameOfTable + 'Sexo' + rowIndex).val()==TryParseInt('2', '2') ) { $('#' + nameOfTable + 'Interpretacion_grasa_corporal' + rowIndex).val('1');} else { $('#' + nameOfTable + 'Interpretacion_grasa_corporal' + rowIndex).val('2');}
});

//BusinessRuleId:71, Attribute:257800, Operation:Field, Event:None













//BusinessRuleId:74, Attribute:257800, Operation:Field, Event:None
$("form#CreatePacientes").on('keyup', '#Circunferencia_de_cadera_cm', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Sexo' + rowIndex).val()==TryParseInt('1', '1') && $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex).val()>=TryParseInt('1.0', '1.0') ) { $('#' + nameOfTable + 'Interpretacion_indice' + rowIndex).val('3');} else {}
});
$("form#CreatePacientes").on('keyup', '#Circunferencia_de_cadera_cm', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Sexo' + rowIndex).val()==TryParseInt('2', '2') && $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex).val()>=TryParseInt('0.85', '0.85') ) { $('#' + nameOfTable + 'Interpretacion_indice' + rowIndex).val('3');} else {}
});
$("form#CreatePacientes").on('keyup', '#Circunferencia_de_cintura_cm', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Sexo' + rowIndex).val()==TryParseInt('1', '1') && $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex).val()>=TryParseInt('1.0', '1.0') ) { $('#' + nameOfTable + 'Interpretacion_indice' + rowIndex).val('3');} else {}
});
$("form#CreatePacientes").on('keyup', '#Circunferencia_de_cintura_cm', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Sexo' + rowIndex).val()==TryParseInt('2', '2') && $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex).val()>=TryParseInt('0.85', '0.85') ) { $('#' + nameOfTable + 'Interpretacion_indice' + rowIndex).val('3');} else {}
});
//BusinessRuleId:74, Attribute:257800, Operation:Field, Event:None

//BusinessRuleId:72, Attribute:257800, Operation:Field, Event:None
$("form#CreatePacientes").on('keyup', '#Circunferencia_de_cadera_cm', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Sexo' + rowIndex).val()==TryParseInt('1', '1') && $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex).val()<=TryParseInt('0.95', '0.95') ) { $('#' + nameOfTable + 'Interpretacion_indice' + rowIndex).val('1');} else {}
});
$("form#CreatePacientes").on('keyup', '#Circunferencia_de_cadera_cm', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Sexo' + rowIndex).val()==TryParseInt('2', '2') && $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex).val()<=TryParseInt('0.80', '0.80') ) { $('#' + nameOfTable + 'Interpretacion_indice' + rowIndex).val('1');} else {}
});
$("form#CreatePacientes").on('keyup', '#Circunferencia_de_cintura_cm', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Sexo' + rowIndex).val()==TryParseInt('1', '1') && $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex).val()<=TryParseInt('0.95', '0.95') ) { $('#' + nameOfTable + 'Interpretacion_indice' + rowIndex).val('1');} else {}
});
$("form#CreatePacientes").on('keyup', '#Circunferencia_de_cintura_cm', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Sexo' + rowIndex).val()==TryParseInt('2', '2') && $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex).val()<=TryParseInt('0.80', '0.80') ) { $('#' + nameOfTable + 'Interpretacion_indice' + rowIndex).val('1');} else {}
});
//BusinessRuleId:72, Attribute:257800, Operation:Field, Event:None

//BusinessRuleId:73, Attribute:257800, Operation:Field, Event:None
$("form#CreatePacientes").on('keyup', '#Circunferencia_de_cadera_cm', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Sexo' + rowIndex).val()==TryParseInt('1', '1') && $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex).val()>TryParseInt('0.96', '0.96') && $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex).val()<TryParseInt('1.0', '1.0') ) { $('#' + nameOfTable + 'Interpretacion_indice' + rowIndex).val('2');} else {}
});
$("form#CreatePacientes").on('keyup', '#Circunferencia_de_cadera_cm', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Sexo' + rowIndex).val()==TryParseInt('2', '2') && $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex).val()>TryParseInt('0.81', '0.81') && $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex).val()<TryParseInt('0.85', '0.85') ) { $('#' + nameOfTable + 'Interpretacion_indice' + rowIndex).val('2');} else {}
});$("form#CreatePacientes").on('keyup', '#Circunferencia_de_cintura_cm', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Sexo' + rowIndex).val()==TryParseInt('1', '1') && $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex).val()>TryParseInt('0.96', '0.96') && $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex).val()<TryParseInt('1.0', '1.0') ) { $('#' + nameOfTable + 'Interpretacion_indice' + rowIndex).val('2');} else {}
});
$("form#CreatePacientes").on('keyup', '#Circunferencia_de_cintura_cm', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Sexo' + rowIndex).val()==TryParseInt('2', '2') && $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex).val()>TryParseInt('0.81', '0.81') && $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex).val()<TryParseInt('0.85', '0.85') ) { $('#' + nameOfTable + 'Interpretacion_indice' + rowIndex).val('2');} else {}
});
//BusinessRuleId:73, Attribute:257800, Operation:Field, Event:None















//BusinessRuleId:76, Attribute:257706, Operation:Field, Event:None
$("form#CreatePacientes").on('keyup', '#Apellido_Paterno', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Nombre_Completo' + rowIndex).val(EvaluaQuery("select 'FLD[Nombres]' + ' ' + 'FLD[Apellido_Paterno]' + ' ' + 'FLD[Apellido_Materno]'", rowIndex, nameOfTable));
});

//BusinessRuleId:76, Attribute:257706, Operation:Field, Event:None

//BusinessRuleId:77, Attribute:257707, Operation:Field, Event:None
$("form#CreatePacientes").on('keyup', '#Apellido_Materno', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Nombre_Completo' + rowIndex).val(EvaluaQuery("select 'FLD[Nombres]' + ' ' + 'FLD[Apellido_Paterno]' + ' ' + 'FLD[Apellido_Materno]'", rowIndex, nameOfTable));
});

//BusinessRuleId:77, Attribute:257707, Operation:Field, Event:None

//BusinessRuleId:60, Attribute:257796, Operation:Field, Event:None
$("form#CreatePacientes").on('keyup', '#Estatura', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'IMC' + rowIndex).val()>TryParseInt('30', '30') && $('#' + nameOfTable + 'IMC' + rowIndex).val()<TryParseInt('34.5', '34.5') ) { $('#' + nameOfTable + 'Interpretacion_IMC' + rowIndex).val('4');} else {}
});
$("form#CreatePacientes").on('keyup', '#Peso_actual', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'IMC' + rowIndex).val()>TryParseInt('30', '30') && $('#' + nameOfTable + 'IMC' + rowIndex).val()<TryParseInt('34.5', '34.5') ) { $('#' + nameOfTable + 'Interpretacion_IMC' + rowIndex).val('4');} else {}
});

//BusinessRuleId:60, Attribute:257796, Operation:Field, Event:None

//BusinessRuleId:5, Attribute:257791, Operation:Field, Event:None
$("form#CreatePacientes").on('keyup', '#Frecuencia_Cardiaca', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Frecuencia_cardiaca_en_Esfuerzo' + rowIndex).val(EvaluaQuery("declare @Fecha nvarchar(10) = 'FLD[Fecha_de_nacimiento]'"
+" declare @FechaNueva nvarchar(10)"
+" set @FechaNueva = substring(@Fecha,4,2) + '/' + left(@fecha,2) + '/' + right(@fecha,4)"
+" SELECT ROUND((((208 - 0.7 * dbo.FncGetEdad(@FechaNueva))- cast(isnull(FLD[Frecuencia_Cardiaca],0) as decimal))*0.7) + cast(isnull(FLD[Frecuencia_Cardiaca],0) as decimal),2)", rowIndex, nameOfTable));
});
$("form#CreatePacientes").on('keyup', '#Fecha_de_nacimiento', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Frecuencia_cardiaca_en_Esfuerzo' + rowIndex).val(EvaluaQuery("declare @Fecha nvarchar(10) = 'FLD[Fecha_de_nacimiento]'"
+" declare @FechaNueva nvarchar(10)"
+" set @FechaNueva = substring(@Fecha,4,2) + '/' + left(@fecha,2) + '/' + right(@fecha,4)"
+" SELECT ROUND((((208 - 0.7 * dbo.FncGetEdad(@FechaNueva))- cast(isnull(FLD[Frecuencia_Cardiaca],0) as decimal))*0.7) + cast(isnull(FLD[Frecuencia_Cardiaca],0) as decimal),2)", rowIndex, nameOfTable));
});

//BusinessRuleId:5, Attribute:257791, Operation:Field, Event:None







//BusinessRuleId:6, Attribute:257713, Operation:Field, Event:None
$("form#CreatePacientes").on('change', '#Fecha_de_nacimiento', function () {
	nameOfTable='';
	rowIndex='';
if( EvaluaQuery("declare @Fecha nvarchar(10) = 'FLD[Fecha_de_nacimiento]'"
+" declare @FechaNueva nvarchar(10)"
+" set @FechaNueva = substring(@Fecha,4,2) + '/' + left(@fecha,2) + '/' + right(@fecha,4) "
+" select dbo.FncGetEdad(@FechaNueva)",rowIndex, nameOfTable)<TryParseInt('18', '18') ) { $('#divNombre_del_Padre_o_Tutor').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Nombre_del_Padre_o_Tutor' + rowIndex)); $('#divIMC_Pediatria').css('display', 'block');} else { SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_del_Padre_o_Tutor' + rowIndex)); $('#divNombre_del_Padre_o_Tutor').css('display', 'none'); $('#divIMC_Pediatria').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'IMC_Pediatria' + rowIndex));}
});

//BusinessRuleId:6, Attribute:257713, Operation:Field, Event:None









//No permitir más de 10 dígitos en el campo celular.
$("form#CreatePacientes").on('keyup', '#Celular', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Celular' + rowIndex).val()<=TryParseInt('9999999999', '9999999999') ) {} else { $('#Celular').attr("placeholder", "No se permiten más de 10 dígitos.").val("").focus().blur();}
});








//BusinessRuleId:75, Attribute:257705, Operation:Field, Event:None
$("form#CreatePacientes").on('keyup', '#Nombres', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Nombre_Completo' + rowIndex).val(EvaluaQuery("select 'FLD[Nombres]' + ' ' + 'FLD[Apellido_Paterno]' + ' ' + 'FLD[Apellido_Materno]'", rowIndex, nameOfTable));
});

//BusinessRuleId:75, Attribute:257705, Operation:Field, Event:None

//BusinessRuleId:103, Attribute:258855, Operation:Field, Event:None
$("form#CreatePacientes").on('change', '#Cuenta_con_padecimientos', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Cuenta_con_padecimientos' + rowIndex).val()==TryParseInt('1', '1') ) { if('false' == 'true')
{
	$('#divDetalle_del_padecimiento').css('display', 'none');
}
else
{
	$('#divDetalle_del_padecimiento').css('display', 'block');
}} else { if('true' == 'true')
{
	$('#divDetalle_del_padecimiento').css('display', 'none');
}
else
{
	$('#divDetalle_del_padecimiento').css('display', 'block');
}}
});

//BusinessRuleId:103, Attribute:258855, Operation:Field, Event:None



//BusinessRuleId:105, Attribute:257773, Operation:Field, Event:None
$("#Detalle_Examenes_LaboratorioGrid").on('change', '.Indicador', function () {
	nameOfTable = $(this).parent().parent().parent().parent()[0].id.replace('Grid', '') + '_';
	rowIndex = '_' + $(this).parent().parent()[0].className.replace(' odd', '').replace(' even', '').replace(nameOfTable, '');
 $('#' + nameOfTable + 'Unidad' + rowIndex).val(EvaluaQuery("select Unidad_de_Medida from indicadores_laboratorio where Folio = FLD[Indicador]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Unidad" + rowIndex), ("true" == "true")); $('#' + nameOfTable + 'Intervalo_de_Referencia' + rowIndex).val(EvaluaQuery("DECLARE @mybin1 int, @mybin2 int"
+" SET @mybin1 = (select limite_inferior from indicadores_laboratorio where Folio = FLD[Indicador])"
+" SET @mybin2 = (select Limite_superior from indicadores_laboratorio where Folio = FLD[Indicador])"
+" "
+" SELECT CAST(@mybin1 AS varchar(5)) + '-'   "
+"    + CAST(@mybin2 AS varchar(5))  ", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Intervalo_de_Referencia" + rowIndex), ("true" == "true"));
	nameOfTable='';
	rowIndex='';
});

//BusinessRuleId:105, Attribute:257773, Operation:Field, Event:None







//BusinessRuleId:119, Attribute:258975, Operation:Field, Event:None
$("form#CreatePacientes").on('change', '#Tipo_de_Paciente', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Tipo_de_Paciente' + rowIndex).val()==TryParseInt('1', '1') ) { $('#divEmpresa').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Empresa' + rowIndex)); $('#divNumero_de_Empleado').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_Empleado' + rowIndex));} else { $('#divEmpresa').css('display', 'block'); SetRequiredToControl( $('#' + nameOfTable + 'Empresa' + rowIndex)); $('#divNumero_de_Empleado').css('display', 'block'); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_Empleado' + rowIndex));}
});

//BusinessRuleId:119, Attribute:258975, Operation:Field, Event:None



//BusinessRuleId:146, Attribute:257717, Operation:Field, Event:None
$("form#CreatePacientes").on('keyup', '#Email', function () {
	nameOfTable='';
	rowIndex='';
if( EvaluaQuery("select COUNT(Email) from Spartan_User where Email = 'FLD[Email]'",rowIndex, nameOfTable)>=TryParseInt('1', '1') ) { $('#Email').attr("placeholder", "El correo electrónico ya está registrado.").val("").focus().blur();} else {}
});

//BusinessRuleId:146, Attribute:257717, Operation:Field, Event:None

//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {


























//BusinessRuleId:1, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex).val(EvaluaQuery("select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Hora_de_Registro' + rowIndex).val(EvaluaQuery(" select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex).val(EvaluaQuery("select GLOBAL[USERID]", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Nombre_del_Medico' + rowIndex).val(EvaluaQuery("select GLOBAL[USERID]", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Tipo_de_Registro' + rowIndex).val('2'); $('#' + nameOfTable + 'Pais' + rowIndex).val('1'); $('#' + nameOfTable + 'Pais_de_nacimiento' + rowIndex).val('1');

}
//BusinessRuleId:1, Attribute:0, Operation:Object, Event:SCREENOPENING

//OCULTAR CAMPO USUARIO REGISTRADO
if(operation == 'New'){
 $('#divUsuario_Registrado').css('display', 'none');
 SetNotRequiredToControl( $('#' + nameOfTable + 'Usuario_Registrado' + rowIndex));

}
if(operation == 'Update'){
 $('#divUsuario_Registrado').css('display', 'none');

 SetNotRequiredToControl( $('#' + nameOfTable + 'Usuario_Registrado' + rowIndex));
}
if(operation == 'Update'){
 $('#divNombre_del_Padre_o_Tutor').css('display', 'none');

 SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_del_Padre_o_Tutor' + rowIndex));
}




//BusinessRuleId:7, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#divNombre_del_Padre_o_Tutor').css('display', 'none'); $('#divSemana_de_gestacion').css('display', 'none'); $('#divPeso_pregestacional').css('display', 'none'); $('#divNombre_del_Anticonceptivo').css('display', 'none'); $('#divDosis').css('display', 'none'); $('#divFecha_Climaterio').css('display', 'none'); if('true' == 'true')
{
	$('#divDetalle_de_Terapia_Hormonal').css('display', 'none');
}
else
{
	$('#divDetalle_de_Terapia_Hormonal').css('display', 'block');
} $('#divCual_medicamento').css('display', 'none');

}
//BusinessRuleId:7, Attribute:0, Operation:Object, Event:SCREENOPENING





//BusinessRuleId:79, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#divEmpresa').css('display', 'none');

}
//BusinessRuleId:79, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:79, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 $('#divEmpresa').css('display', 'none');

}
//BusinessRuleId:79, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:80, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("select GLOBAL[USERROLEID]",rowIndex, nameOfTable)==TryParseInt('1', '1') ) { DisabledControl($("#" + nameOfTable + "Tipo_de_Registro" + rowIndex), ("false" == "true"));} else {}

}
//BusinessRuleId:80, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:80, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("select GLOBAL[USERROLEID]",rowIndex, nameOfTable)==TryParseInt('1', '1') ) { DisabledControl($("#" + nameOfTable + "Tipo_de_Registro" + rowIndex), ("false" == "true"));} else {}

}
//BusinessRuleId:80, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:21, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Padecimiento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Empresa' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_Completo' + rowIndex)); DisabledControl($("#" + nameOfTable + "Folio" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Tipo_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Nombre_Completo" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "IMC" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Complexion_corporal" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Distribucion_de_grasa_corporal" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Consumo_de_agua_resultado" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Frecuencia_cardiaca_en_Esfuerzo" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Dificultad_de_Rutina_de_Ejercicios" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Calorias" + rowIndex), ("true" == "true")); SetNotRequiredToControl( $('#' + nameOfTable + 'Observaciones' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calorias' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Dificultad_de_Rutina_de_Ejercicios' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Frecuencia_cardiaca_en_Esfuerzo' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Consumo_de_agua_resultado' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Distribucion_de_grasa_corporal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Complexion_corporal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'IMC' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Terapia_reemplazo_hormonal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_Climaterio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Climaterio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Dosis' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_del_Anticonceptivo' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Toma_anticonceptivos' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Peso_pregestacional' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Semana_de_gestacion' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Esta_embarazada' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Masa_Muscular_' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Masa_Muscular_kg' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Grasa_Corporal_kg' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Grasa_Corporal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Grasa_Visceral' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Agua_corporal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Edad_Metabolica' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_de_Resultado' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pliegue_cutaneo_supraespinal_mm' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pliegue_cutaneo_subescapular_mm' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pliegue_cutaneo_bicipital_mm' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pliegue_cutaneo_tricipital_mm' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Circunferencia_de_brazo_cm' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Anchura_de_muneca_mm' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Circunferencia_de_cadera_cm' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Peso_habitual' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Circunferencia_de_cintura_cm' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatura' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Peso_actual' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Presion_diastolica' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Presion_sistolica' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Frecuencia_Respiratoria' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Frecuencia_Cardiaca' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Dosis' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus_Indicador' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Intervalo_de_Referencia' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Unidad' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Cantidad' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Frecuencia' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Sustancia' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Parentesco' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Enfermedad' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Cantidad_hijos' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Ocupacion' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CP' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Colonia' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_interior' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calle' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estado_Civil' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Lugar_de_nacimiento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais_de_nacimiento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Medicamentos_bajar_peso' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Cuando_cambia_mi_estado_de_animo' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Horario_hambre' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Habitos_Modificacion' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Apetito' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Entre_comidas' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Grasas_Preferencias' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Consumo_de_sal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Suplementos' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Alergias' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_Dieta' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Antiguedad_Ejercicio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_Ejercicio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Duracion_Ejercicio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Frecuencia_Ejercicio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Ciudad' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estado' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_exterior' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Comidas_cantidad' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Preparacion_Preferencias' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Cual_medicamento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex)); DisabledControl($("#" + nameOfTable + "Indice_cintura_cadera" + rowIndex), ("true" == "true")); SetNotRequiredToControl( $('#' + nameOfTable + 'Interpretacion_IMC' + rowIndex)); DisabledControl($("#" + nameOfTable + "Interpretacion_IMC" + rowIndex), ("true" == "true")); SetNotRequiredToControl( $('#' + nameOfTable + 'Interpretacion_complexion_corporal' + rowIndex)); DisabledControl($("#" + nameOfTable + "Interpretacion_complexion_corporal" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Interpretacion_grasa_corporal" + rowIndex), ("true" == "true")); SetNotRequiredToControl( $('#' + nameOfTable + 'Interpretacion_grasa_corporal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Interpretacion_indice' + rowIndex)); DisabledControl($("#" + nameOfTable + "Interpretacion_indice" + rowIndex), ("true" == "true")); SetNotRequiredToControl( $('#' + nameOfTable + 'Interpretacion_agua' + rowIndex)); DisabledControl($("#" + nameOfTable + "Interpretacion_agua" + rowIndex), ("true" == "true")); SetNotRequiredToControl( $('#' + nameOfTable + 'Interpretacion_frecuencia' + rowIndex)); DisabledControl($("#" + nameOfTable + "Interpretacion_frecuencia" + rowIndex), ("true" == "true")); SetNotRequiredToControl( $('#' + nameOfTable + 'Interpretacion_dificultad' + rowIndex)); DisabledControl($("#" + nameOfTable + "Interpretacion_dificultad" + rowIndex), ("true" == "true")); SetNotRequiredToControl( $('#' + nameOfTable + 'Interpretacion_calorias' + rowIndex)); DisabledControl($("#" + nameOfTable + "Interpretacion_calorias" + rowIndex), ("true" == "true")); SetNotRequiredToControl( $('#' + nameOfTable + 'IMC_Pediatria' + rowIndex));

}
//BusinessRuleId:21, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:21, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Padecimiento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Empresa' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_Completo' + rowIndex)); DisabledControl($("#" + nameOfTable + "Folio" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Tipo_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Nombre_Completo" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "IMC" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Complexion_corporal" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Distribucion_de_grasa_corporal" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Consumo_de_agua_resultado" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Frecuencia_cardiaca_en_Esfuerzo" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Dificultad_de_Rutina_de_Ejercicios" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Calorias" + rowIndex), ("true" == "true")); SetNotRequiredToControl( $('#' + nameOfTable + 'Observaciones' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calorias' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Dificultad_de_Rutina_de_Ejercicios' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Frecuencia_cardiaca_en_Esfuerzo' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Consumo_de_agua_resultado' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Distribucion_de_grasa_corporal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Complexion_corporal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'IMC' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Terapia_reemplazo_hormonal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_Climaterio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Climaterio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Dosis' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_del_Anticonceptivo' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Toma_anticonceptivos' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Peso_pregestacional' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Semana_de_gestacion' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Esta_embarazada' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Masa_Muscular_' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Masa_Muscular_kg' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Grasa_Corporal_kg' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Grasa_Corporal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Grasa_Visceral' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Agua_corporal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Edad_Metabolica' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_de_Resultado' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pliegue_cutaneo_supraespinal_mm' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pliegue_cutaneo_subescapular_mm' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pliegue_cutaneo_bicipital_mm' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pliegue_cutaneo_tricipital_mm' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Circunferencia_de_brazo_cm' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Anchura_de_muneca_mm' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Circunferencia_de_cadera_cm' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Peso_habitual' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Circunferencia_de_cintura_cm' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatura' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Peso_actual' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Presion_diastolica' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Presion_sistolica' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Frecuencia_Respiratoria' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Frecuencia_Cardiaca' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Dosis' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus_Indicador' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Intervalo_de_Referencia' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Unidad' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Cantidad' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Frecuencia' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Sustancia' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Parentesco' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Enfermedad' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Cantidad_hijos' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Ocupacion' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CP' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Colonia' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_interior' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calle' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estado_Civil' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Lugar_de_nacimiento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais_de_nacimiento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Medicamentos_bajar_peso' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Cuando_cambia_mi_estado_de_animo' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Horario_hambre' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Habitos_Modificacion' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Apetito' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Entre_comidas' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Grasas_Preferencias' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Consumo_de_sal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Suplementos' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Alergias' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_Dieta' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Antiguedad_Ejercicio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_Ejercicio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Duracion_Ejercicio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Frecuencia_Ejercicio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Ciudad' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estado' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_exterior' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Comidas_cantidad' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Preparacion_Preferencias' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Cual_medicamento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Indice_cintura_cadera' + rowIndex)); DisabledControl($("#" + nameOfTable + "Indice_cintura_cadera" + rowIndex), ("true" == "true")); SetNotRequiredToControl( $('#' + nameOfTable + 'Interpretacion_IMC' + rowIndex)); DisabledControl($("#" + nameOfTable + "Interpretacion_IMC" + rowIndex), ("true" == "true")); SetNotRequiredToControl( $('#' + nameOfTable + 'Interpretacion_complexion_corporal' + rowIndex)); DisabledControl($("#" + nameOfTable + "Interpretacion_complexion_corporal" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Interpretacion_grasa_corporal" + rowIndex), ("true" == "true")); SetNotRequiredToControl( $('#' + nameOfTable + 'Interpretacion_grasa_corporal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Interpretacion_indice' + rowIndex)); DisabledControl($("#" + nameOfTable + "Interpretacion_indice" + rowIndex), ("true" == "true")); SetNotRequiredToControl( $('#' + nameOfTable + 'Interpretacion_agua' + rowIndex)); DisabledControl($("#" + nameOfTable + "Interpretacion_agua" + rowIndex), ("true" == "true")); SetNotRequiredToControl( $('#' + nameOfTable + 'Interpretacion_frecuencia' + rowIndex)); DisabledControl($("#" + nameOfTable + "Interpretacion_frecuencia" + rowIndex), ("true" == "true")); SetNotRequiredToControl( $('#' + nameOfTable + 'Interpretacion_dificultad' + rowIndex)); DisabledControl($("#" + nameOfTable + "Interpretacion_dificultad" + rowIndex), ("true" == "true")); SetNotRequiredToControl( $('#' + nameOfTable + 'Interpretacion_calorias' + rowIndex)); DisabledControl($("#" + nameOfTable + "Interpretacion_calorias" + rowIndex), ("true" == "true")); SetNotRequiredToControl( $('#' + nameOfTable + 'IMC_Pediatria' + rowIndex));

}
//BusinessRuleId:21, Attribute:0, Operation:Object, Event:SCREENOPENING









//BusinessRuleId:104, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 if('true' == 'true')
{
	$('#divDetalle_del_padecimiento').css('display', 'none');
}
else
{
	$('#divDetalle_del_padecimiento').css('display', 'block');
}

}
//BusinessRuleId:104, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:104, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 if('true' == 'true')
{
	$('#divDetalle_del_padecimiento').css('display', 'none');
}
else
{
	$('#divDetalle_del_padecimiento').css('display', 'block');
}

}
//BusinessRuleId:104, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:122, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#' + nameOfTable + 'Tipo_de_Registro' + rowIndex).val('1');

}
//BusinessRuleId:122, Attribute:0, Operation:Object, Event:SCREENOPENING













//BusinessRuleId:125, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 CreateSessionVar('VariableContrasena', EvaluaQuery("declare @valor nvarchar(5)"
+" set @valor= lower(left(replace(newid(),'-',''),5))"
+" select @valor", rowIndex, nameOfTable));

}
//BusinessRuleId:125, Attribute:0, Operation:Object, Event:SCREENOPENING

//NEWBUSINESSRULE_SCREENOPENING//
}
function EjecutarValidacionesAntesDeGuardar(){
	var result = true;
        nameOfTable = '';
        rowIndex = '';




//BusinessRuleId:36, Attribute:2, Operation:Object, Event:BEFORESAVING
if(operation == 'New'){
 $('#' + nameOfTable + 'Nombre_Completo' + rowIndex).val(EvaluaQuery("select 'FLD[Nombres]' + ' ' + 'FLD[Apellido_Paterno]' + ' ' + 'FLD[Apellido_Materno]'", rowIndex, nameOfTable));

}
//BusinessRuleId:36, Attribute:2, Operation:Object, Event:BEFORESAVING

//BusinessRuleId:36, Attribute:2, Operation:Object, Event:BEFORESAVING
if(operation == 'Update'){
 $('#' + nameOfTable + 'Nombre_Completo' + rowIndex).val(EvaluaQuery("select 'FLD[Nombres]' + ' ' + 'FLD[Apellido_Paterno]' + ' ' + 'FLD[Apellido_Materno]'", rowIndex, nameOfTable));

}
//BusinessRuleId:36, Attribute:2, Operation:Object, Event:BEFORESAVING

//BusinessRuleId:36, Attribute:2, Operation:Object, Event:BEFORESAVING
if(operation == 'Consult'){
 $('#' + nameOfTable + 'Nombre_Completo' + rowIndex).val(EvaluaQuery("select 'FLD[Nombres]' + ' ' + 'FLD[Apellido_Paterno]' + ' ' + 'FLD[Apellido_Materno]'", rowIndex, nameOfTable));

}
//BusinessRuleId:36, Attribute:2, Operation:Object, Event:BEFORESAVING























//BusinessRuleId:126, Attribute:2, Operation:Object, Event:BEFORESAVING
if(operation == 'New'){
SendEmailQuery('Contraseña', EvaluaQuery("select Email from pacientes where Folio = GLOBAL[KeyValueInserted]"), "Tu contraseña de acceso es: GLOBAL[VariableContrasena]",rowIndex,nameOfTable);
}
//BusinessRuleId:126, Attribute:2, Operation:Object, Event:BEFORESAVING

//NEWBUSINESSRULE_BEFORESAVING//
    return result;
}
function EjecutarValidacionesDespuesDeGuardar(){
//BusinessRuleId:32, Attribute:2, Operation:Object, Event:AFTERSAVING
if(operation == 'New'){
 $('#' + nameOfTable + 'Calorias' + rowIndex).val(EvaluaQuery(" 	exec Sp_selCalorias_paciente FLD[Sexo], FLD[Peso_Actual], FLD[Estatura], FLD[Fecha_de_nacimiento], FLD[Esta_embarazada], FLD[Peso_pregestacional], FLD[Semana_de_gestación]", rowIndex, nameOfTable));

}
//BusinessRuleId:32, Attribute:2, Operation:Object, Event:AFTERSAVING

//BusinessRuleId:32, Attribute:2, Operation:Object, Event:AFTERSAVING
if(operation == 'Update'){
 $('#' + nameOfTable + 'Calorias' + rowIndex).val(EvaluaQuery(" 	exec Sp_selCalorias_paciente FLD[Sexo], FLD[Peso_Actual], FLD[Estatura], FLD[Fecha_de_nacimiento], FLD[Esta_embarazada], FLD[Peso_pregestacional], FLD[Semana_de_gestación]", rowIndex, nameOfTable));

}
//BusinessRuleId:32, Attribute:2, Operation:Object, Event:AFTERSAVING



//BusinessRuleId:123, Attribute:2, Operation:Object, Event:AFTERSAVING
if(operation == 'New'){
if( EvaluaQuery("select Email from spartan_user where Email = 'FLD[Email]'",rowIndex, nameOfTable)==$('#' + nameOfTable + 'Email' + rowIndex + ' option:selected').text() ) { alert(DecodifyText('El correo electrónico ya se encuentra registrado, favor de introducir otro correo electrónico.', rowIndex, nameOfTable));
result=false;} else {}

}
//BusinessRuleId:123, Attribute:2, Operation:Object, Event:AFTERSAVING

















//BusinessRuleId:124, Attribute:2, Operation:Object, Event:AFTERSAVING
if(operation == 'New'){
 EvaluaQuery("exec InsertSpartanPacientes GLOBAL[KeyValueInserted], 'GLOBAL[VariableContrasena]'", rowIndex, nameOfTable);

}
//BusinessRuleId:124, Attribute:2, Operation:Object, Event:AFTERSAVING









//BusinessRuleId:133, Attribute:2, Operation:Object, Event:AFTERSAVING
if(operation == 'Update'){
 EvaluaQuery("exec UpdateSpartanPacientes GLOBAL[KeyValueInserted]", rowIndex, nameOfTable);

}
//BusinessRuleId:133, Attribute:2, Operation:Object, Event:AFTERSAVING

//NEWBUSINESSRULE_AFTERSAVING//
}

function EjecutarValidacionesAntesDeGuardarMRDetalle_de_Padecimientos(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_de_Padecimientos//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRDetalle_de_Padecimientos(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_de_Padecimientos//
}
function EjecutarValidacionesAlEliminarMRDetalle_de_Padecimientos(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Detalle_de_Padecimientos//
    return result;
}
function EjecutarValidacionesNewRowMRDetalle_de_Padecimientos(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Detalle_de_Padecimientos//
    return result;
}
function EjecutarValidacionesEditRowMRDetalle_de_Padecimientos(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Detalle_de_Padecimientos//
    return result;
}
function EjecutarValidacionesAntesDeGuardarMRDetalle_Antecedentes_Familiares(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Antecedentes_Familiares//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRDetalle_Antecedentes_Familiares(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Antecedentes_Familiares//
}
function EjecutarValidacionesAlEliminarMRDetalle_Antecedentes_Familiares(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Detalle_Antecedentes_Familiares//
    return result;
}
function EjecutarValidacionesNewRowMRDetalle_Antecedentes_Familiares(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Detalle_Antecedentes_Familiares//
    return result;
}
function EjecutarValidacionesEditRowMRDetalle_Antecedentes_Familiares(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Detalle_Antecedentes_Familiares//
    return result;
}
function EjecutarValidacionesAntesDeGuardarMRDetalle_Antecedentes_No_Patologicos(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Antecedentes_No_Patologicos//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRDetalle_Antecedentes_No_Patologicos(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Antecedentes_No_Patologicos//
}
function EjecutarValidacionesAlEliminarMRDetalle_Antecedentes_No_Patologicos(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Detalle_Antecedentes_No_Patologicos//
    return result;
}
function EjecutarValidacionesNewRowMRDetalle_Antecedentes_No_Patologicos(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Detalle_Antecedentes_No_Patologicos//
    return result;
}
function EjecutarValidacionesEditRowMRDetalle_Antecedentes_No_Patologicos(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Detalle_Antecedentes_No_Patologicos//
    return result;
}
function EjecutarValidacionesAntesDeGuardarMRDetalle_Examenes_Laboratorio(nameOfTable, rowIndex){
    var result = true;
    







//BusinessRuleId:107, Attribute:257815, Operation:Object, Event:BEFORESAVINGMR
if(operation == 'New'){
if( $('#' + nameOfTable + 'Resultado' + rowIndex).val()<EvaluaQuery("select limite_inferior from indicadores_laboratorio where Folio = FLD[Indicador]",rowIndex, nameOfTable) ) { $('#' + nameOfTable + 'Estatus_Indicador' + rowIndex).val('Bajo'); DisabledControl($("#" + nameOfTable + "Estatus_Indicador" + rowIndex), ("true" == "true"));} else {}

}
//BusinessRuleId:107, Attribute:257815, Operation:Object, Event:BEFORESAVINGMR

//BusinessRuleId:107, Attribute:257815, Operation:Object, Event:BEFORESAVINGMR
if(operation == 'Update'){
if( $('#' + nameOfTable + 'Resultado' + rowIndex).val()<EvaluaQuery("select limite_inferior from indicadores_laboratorio where Folio = FLD[Indicador]",rowIndex, nameOfTable) ) { $('#' + nameOfTable + 'Estatus_Indicador' + rowIndex).val('Bajo'); DisabledControl($("#" + nameOfTable + "Estatus_Indicador" + rowIndex), ("true" == "true"));} else {}

}
//BusinessRuleId:107, Attribute:257815, Operation:Object, Event:BEFORESAVINGMR

//BusinessRuleId:108, Attribute:257815, Operation:Object, Event:BEFORESAVINGMR
if(operation == 'New'){
if( $('#' + nameOfTable + 'Resultado' + rowIndex).val()>EvaluaQuery("select Limite_superior from indicadores_laboratorio where Folio = FLD[Indicador]",rowIndex, nameOfTable) ) { $('#' + nameOfTable + 'Estatus_Indicador' + rowIndex).val('Alto'); DisabledControl($("#" + nameOfTable + "Estatus_Indicador" + rowIndex), ("true" == "true"));} else {}

}
//BusinessRuleId:108, Attribute:257815, Operation:Object, Event:BEFORESAVINGMR

//BusinessRuleId:108, Attribute:257815, Operation:Object, Event:BEFORESAVINGMR
if(operation == 'Update'){
if( $('#' + nameOfTable + 'Resultado' + rowIndex).val()>EvaluaQuery("select Limite_superior from indicadores_laboratorio where Folio = FLD[Indicador]",rowIndex, nameOfTable) ) { $('#' + nameOfTable + 'Estatus_Indicador' + rowIndex).val('Alto'); DisabledControl($("#" + nameOfTable + "Estatus_Indicador" + rowIndex), ("true" == "true"));} else {}

}
//BusinessRuleId:108, Attribute:257815, Operation:Object, Event:BEFORESAVINGMR

//BusinessRuleId:106, Attribute:257815, Operation:Object, Event:BEFORESAVINGMR
if(operation == 'New'){
if( $('#' + nameOfTable + 'Resultado' + rowIndex).val()>=EvaluaQuery("select limite_inferior from indicadores_laboratorio where Folio = FLD[Indicador]",rowIndex, nameOfTable) && $('#' + nameOfTable + 'Resultado' + rowIndex).val()<=EvaluaQuery("select Limite_superior from indicadores_laboratorio where Folio = FLD[Indicador]",rowIndex, nameOfTable) ) { $('#' + nameOfTable + 'Estatus_Indicador' + rowIndex).val('Normal'); DisabledControl($("#" + nameOfTable + "Estatus_Indicador" + rowIndex), ("true" == "true"));} else {}

}
//BusinessRuleId:106, Attribute:257815, Operation:Object, Event:BEFORESAVINGMR

//BusinessRuleId:106, Attribute:257815, Operation:Object, Event:BEFORESAVINGMR
if(operation == 'Update'){
if( $('#' + nameOfTable + 'Resultado' + rowIndex).val()>=EvaluaQuery("select limite_inferior from indicadores_laboratorio where Folio = FLD[Indicador]",rowIndex, nameOfTable) && $('#' + nameOfTable + 'Resultado' + rowIndex).val()<=EvaluaQuery("select Limite_superior from indicadores_laboratorio where Folio = FLD[Indicador]",rowIndex, nameOfTable) ) { $('#' + nameOfTable + 'Estatus_Indicador' + rowIndex).val('Normal'); DisabledControl($("#" + nameOfTable + "Estatus_Indicador" + rowIndex), ("true" == "true"));} else {}

}
//BusinessRuleId:106, Attribute:257815, Operation:Object, Event:BEFORESAVINGMR





//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Examenes_Laboratorio//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRDetalle_Examenes_Laboratorio(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Examenes_Laboratorio//
}
function EjecutarValidacionesAlEliminarMRDetalle_Examenes_Laboratorio(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Detalle_Examenes_Laboratorio//
    return result;
}
function EjecutarValidacionesNewRowMRDetalle_Examenes_Laboratorio(nameOfTable, rowIndex){
    var result = true;
    



//BusinessRuleId:112, Attribute:257815, Operation:Object, Event:NEWROWMR
if(operation == 'New'){
 DisabledControl($("#" + nameOfTable + "Unidad" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Intervalo_de_Referencia" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Estatus_Indicador" + rowIndex), ("true" == "true")); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus_Indicador' + rowIndex));

}
//BusinessRuleId:112, Attribute:257815, Operation:Object, Event:NEWROWMR

//BusinessRuleId:112, Attribute:257815, Operation:Object, Event:NEWROWMR
if(operation == 'Update'){
 DisabledControl($("#" + nameOfTable + "Unidad" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Intervalo_de_Referencia" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Estatus_Indicador" + rowIndex), ("true" == "true")); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus_Indicador' + rowIndex));

}
//BusinessRuleId:112, Attribute:257815, Operation:Object, Event:NEWROWMR

//NEWBUSINESSRULE_NEWROWMR_Detalle_Examenes_Laboratorio//
    return result;
}
function EjecutarValidacionesEditRowMRDetalle_Examenes_Laboratorio(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Detalle_Examenes_Laboratorio//
    return result;
}
function EjecutarValidacionesAntesDeGuardarMRDetalle_Terapia_Hormonal(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Terapia_Hormonal//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRDetalle_Terapia_Hormonal(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Terapia_Hormonal//
}
function EjecutarValidacionesAlEliminarMRDetalle_Terapia_Hormonal(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Detalle_Terapia_Hormonal//
    return result;
}
function EjecutarValidacionesNewRowMRDetalle_Terapia_Hormonal(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Detalle_Terapia_Hormonal//
    return result;
}
function EjecutarValidacionesEditRowMRDetalle_Terapia_Hormonal(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Detalle_Terapia_Hormonal//
    return result;
}
function EjecutarValidacionesAntesDeGuardarMRDetalle_Preferencia_Bebidas(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Preferencia_Bebidas//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRDetalle_Preferencia_Bebidas(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Preferencia_Bebidas//
}
function EjecutarValidacionesAlEliminarMRDetalle_Preferencia_Bebidas(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Detalle_Preferencia_Bebidas//
    return result;
}
function EjecutarValidacionesNewRowMRDetalle_Preferencia_Bebidas(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Detalle_Preferencia_Bebidas//
    return result;
}
function EjecutarValidacionesEditRowMRDetalle_Preferencia_Bebidas(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Detalle_Preferencia_Bebidas//
    return result;
}


function EjecutarValidacionesAntesDeGuardarMRDetalle_Suscripciones_Paciente(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Suscripciones_Paciente// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Suscripciones_Paciente(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Suscripciones_Paciente// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Suscripciones_Paciente(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Suscripciones_Paciente// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Suscripciones_Paciente(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Detalle_Suscripciones_Paciente// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Suscripciones_Paciente(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detalle_Suscripciones_Paciente// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRDetalle_Pagos_Paciente(nameOfTable, rowIndex){ 
 var result= true; 












//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Pagos_Paciente// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Pagos_Paciente(nameOfTable, rowIndex){ 
















//BusinessRuleId:113, Attribute:258441, Operation:Object, Event:AFTERSAVINGMR
if(operation == 'New'){
 fillMRFromQuery('Detalle_Suscripciones_Paciente', "exec LlenarMRSuscripcionesPacientes 'FLD[Fecha_de_Pago]', FLD[Suscripcion]");

}
//BusinessRuleId:113, Attribute:258441, Operation:Object, Event:AFTERSAVINGMR

//BusinessRuleId:113, Attribute:258441, Operation:Object, Event:AFTERSAVINGMR
if(operation == 'Update'){
 fillMRFromQuery('Detalle_Suscripciones_Paciente', "exec LlenarMRSuscripcionesPacientes 'FLD[Fecha_de_Pago]', FLD[Suscripcion]");

}
//BusinessRuleId:113, Attribute:258441, Operation:Object, Event:AFTERSAVINGMR





//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Pagos_Paciente// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Pagos_Paciente(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Pagos_Paciente// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Pagos_Paciente(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Detalle_Pagos_Paciente// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Pagos_Paciente(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detalle_Pagos_Paciente// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRMS_Exclusion_Ingredientes_Paciente(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_MS_Exclusion_Ingredientes_Paciente// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRMS_Exclusion_Ingredientes_Paciente(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_MS_Exclusion_Ingredientes_Paciente// 
} 

function EjecutarValidacionesAlEliminarMRMS_Exclusion_Ingredientes_Paciente(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_MS_Exclusion_Ingredientes_Paciente// 
 return result; 
} 

function EjecutarValidacionesNewRowMRMS_Exclusion_Ingredientes_Paciente(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_MS_Exclusion_Ingredientes_Paciente// 
  return result; 
} 

function EjecutarValidacionesEditRowMRMS_Exclusion_Ingredientes_Paciente(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_MS_Exclusion_Ingredientes_Paciente// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRDetalle_Especialistas_Pacientes(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Especialistas_Pacientes// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Especialistas_Pacientes(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Especialistas_Pacientes// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Especialistas_Pacientes(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Especialistas_Pacientes// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Especialistas_Pacientes(nameOfTable, rowIndex){ 
 var result= true; 
//BusinessRuleId:114, Attribute:258856, Operation:Object, Event:NEWROWMR
if(operation == 'New'){
 var valor = $('#' + nameOfTable + 'Especialista' + rowIndex).val();   $('#' + nameOfTable + 'Especialista' + rowIndex).empty();         if(!$('#' + nameOfTable + 'Especialista' + rowIndex).hasClass('AutoComplete'))  {         $('#' + nameOfTable + 'Especialista' + rowIndex).append($("<option selected />").val("").text(""));         $.each(EvaluaQueryDictionary("select Id_User, Name from Spartan_User where Role IN (7,8,9,10)", rowIndex, nameOfTable), function (index, value) {           $('#' + nameOfTable + 'Especialista' + rowIndex).append($("<option />").val(index).text(value));      });  }       else    {    var selectData = [];   selectData.push({id: "",text: "" });      $.each(EvaluaQueryDictionary("select Id_User, Name from Spartan_User where Role IN (7,8,9,10)", rowIndex, nameOfTable), function (index, value) {            selectData.push({              id: index,              text: value          });    });      $('#' + nameOfTable + 'Especialista' + rowIndex).select2({data: selectData})    }   $('#' + nameOfTable + 'Especialista' + rowIndex).val(valor).trigger('change');

}
//BusinessRuleId:114, Attribute:258856, Operation:Object, Event:NEWROWMR

//BusinessRuleId:114, Attribute:258856, Operation:Object, Event:NEWROWMR
if(operation == 'Update'){
 var valor = $('#' + nameOfTable + 'Especialista' + rowIndex).val();   $('#' + nameOfTable + 'Especialista' + rowIndex).empty();         if(!$('#' + nameOfTable + 'Especialista' + rowIndex).hasClass('AutoComplete'))  {         $('#' + nameOfTable + 'Especialista' + rowIndex).append($("<option selected />").val("").text(""));         $.each(EvaluaQueryDictionary("select Id_User, Name from Spartan_User where Role IN (7,8,9,10)", rowIndex, nameOfTable), function (index, value) {           $('#' + nameOfTable + 'Especialista' + rowIndex).append($("<option />").val(index).text(value));      });  }       else    {    var selectData = [];   selectData.push({id: "",text: "" });      $.each(EvaluaQueryDictionary("select Id_User, Name from Spartan_User where Role IN (7,8,9,10)", rowIndex, nameOfTable), function (index, value) {            selectData.push({              id: index,              text: value          });    });      $('#' + nameOfTable + 'Especialista' + rowIndex).select2({data: selectData})    }   $('#' + nameOfTable + 'Especialista' + rowIndex).val(valor).trigger('change');

}
//BusinessRuleId:114, Attribute:258856, Operation:Object, Event:NEWROWMR

//NEWBUSINESSRULE_NEWROWMR_Detalle_Especialistas_Pacientes// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Especialistas_Pacientes(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detalle_Especialistas_Pacientes// 
 return result; 
} 
