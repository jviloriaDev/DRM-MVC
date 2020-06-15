var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
$(document).ready(function () {
//BusinessRuleId:86, Attribute:258244, Operation:Field, Event:None
$("form#CreateMedicos").on('keyup', '#Nombres', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Nombre_Completo' + rowIndex).val(EvaluaQuery("select 'FLD[Nombres]' + ' ' + 'FLD[Apellido_Paterno]' + ' ' + 'FLD[Apellido_Materno]'", rowIndex, nameOfTable));
});

//BusinessRuleId:86, Attribute:258244, Operation:Field, Event:None

//BusinessRuleId:87, Attribute:258245, Operation:Field, Event:None
$("form#CreateMedicos").on('keyup', '#Apellido_Paterno', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Nombre_Completo' + rowIndex).val(EvaluaQuery(" select 'FLD[Nombres]' + ' ' + 'FLD[Apellido_Paterno]' + ' ' + 'FLD[Apellido_Materno]'", rowIndex, nameOfTable));
});

//BusinessRuleId:87, Attribute:258245, Operation:Field, Event:None

//BusinessRuleId:88, Attribute:258246, Operation:Field, Event:None
$("form#CreateMedicos").on('keyup', '#Apellido_Materno', function () {
	nameOfTable='';
	rowIndex='';
 $('#' + nameOfTable + 'Nombre_Completo' + rowIndex).val(EvaluaQuery("select 'FLD[Nombres]' + ' ' + 'FLD[Apellido_Paterno]' + ' ' + 'FLD[Apellido_Materno]'", rowIndex, nameOfTable));
});

//BusinessRuleId:88, Attribute:258246, Operation:Field, Event:None









$("form#CreateMedicos").on('change', '#Tipo_de_Especialista', function () {
	nameOfTable='';
	rowIndex='';
SetNotRequiredToControl( $('#' + nameOfTable + 'Email_institucional' + rowIndex));
 $('#divEmail_institucional').css('display', 'none'); 
 SetNotRequiredToControl( $('#' + nameOfTable + 'Email_institucional' + rowIndex)); 
 $("a[href='#tabDatos_de_Contacto']").css('display', 'none'); 
 $("a[href='#tabDatos_Profesionales']").css('display', 'none');
 $("a[href='#tabDatos_Fiscales']").css('display', 'none'); 
 $("a[href='#tabDocumentacion']").css('display', 'none');
 $("a[href='#tabCodigos_de_Referencia']").css('display', 'none'); $("a[href='#tabSuscripcion_Red_de_Especialistas']").css('display', 'none'); 
 $("a[href='#tabDatos_Bancarios']").css('display', 'none'); $("a[href='#tabFacturacion']").css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Contactos' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Email_ppal_publico' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Email_de_contacto' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calle' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_exterior' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_interior' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Colonia' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CP' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Ciudad' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estado' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Telefonos' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'En_Hospital' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_del_Hospital' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Piso_hospital' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_consultorio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Redes_sociales' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Aseguradoras_con_convenio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Se_ajusta_tabulador' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Codigos_para_Referenciar_Pacientes' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Regimen_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_o_Razon_Social' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'RFC' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calle_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_exterior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_interior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Colonia_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CP_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Ciudad_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estado_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Telefono_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fax' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombres_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Apellido_Paterno_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Apellido_Materno_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_Completo_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Regimen_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_o_Razon_Social' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'RFC' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calle_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_exterior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_interior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Colonia_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CP_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Ciudad_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estado_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Telefono' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fax' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Profesion' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Especialidad' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Titulos' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Resumen_Profesional' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Cedula_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Contratos' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Identificacion_Oficial' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Cedula_Fiscal_Documento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Comprobante_de_Domicilio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Facturas' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Suscripcion_Red_de_Especialistas' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calificacion_Red_de_Medicos' + rowIndex));

});




//BusinessRuleId:130, Attribute:258468, Operation:Field, Event:None



//BusinessRuleId:132, Attribute:258468, Operation:Field, Event:None
$("form#CreateMedicos").on('change', '#Tipo_de_Especialista', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Tipo_de_Especialista' + rowIndex).val()==TryParseInt('4', '4') ) { $("a[href='#tabDatos_de_Contacto']").css('display', 'block'); 
$("a[href='#tabDatos_Fiscales']").css('display', 'block'); $("a[href='#tabCodigos_de_Referencia']").css('display', 'block'); 
$("a[href='#tabDatos_Bancarios']").css('display', 'block'); $("a[href='#tabFacturacion']").css('display', 'block');
$("a[href='#tabSuscripcion_Red_de_Especialistas']").css('display', 'block');} else {}
});

//BusinessRuleId:132, Attribute:258468, Operation:Field, Event:None

//BusinessRuleId:130, Attribute:258468, Operation:Field, Event:None
$("form#CreateMedicos").on('change', '#Tipo_de_Especialista', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Tipo_de_Especialista' + rowIndex).val()==TryParseInt('2', '2') ) { 
$("a[href='#tabDatos_de_Contacto']").css('display', 'block'); $("a[href='#tabSuscripcion_Red_de_Especialistas']").css('display', 'block');} 
else { }
});


//BusinessRuleId:130, Attribute:258468, Operation:Field, Event:None

//BusinessRuleId:131, Attribute:258468, Operation:Field, Event:None
$("form#CreateMedicos").on('change', '#Tipo_de_Especialista', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Tipo_de_Especialista' + rowIndex).val()==TryParseInt('3', '3') ) { $("a[href='#tabDatos_Fiscales']").css('display', 'block'); 
$("a[href='#tabCodigos_de_Referencia']").css('display', 'block'); $("a[href='#tabFacturacion']").css('display', 'block');
$("a[href='#tabDatos_Bancarios']").css('display', 'block');} else {}
});

//BusinessRuleId:131, Attribute:258468, Operation:Field, Event:None




//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {




//BusinessRuleId:84, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#divFolio').css('display', 'none'); $('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex).val(EvaluaQuery(" select convert (varchar(11),getdate(),105)"
+" "
+" ", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Hora_de_Registro' + rowIndex).val(EvaluaQuery(" select convert (varchar(8),getdate(),108)"
+" "
+" ", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex).val(EvaluaQuery("select GLOBAL[USERID]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Nombre_Completo" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:84, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:84, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 $('#divFolio').css('display', 'none'); $('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex).val(EvaluaQuery(" select convert (varchar(11),getdate(),105)"
+" "
+" ", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Hora_de_Registro' + rowIndex).val(EvaluaQuery(" select convert (varchar(8),getdate(),108)"
+" "
+" ", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex).val(EvaluaQuery("select GLOBAL[USERID]", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Nombre_Completo" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:84, Attribute:0, Operation:Object, Event:SCREENOPENING





















//BusinessRuleId:150, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Contactos' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Email_ppal_publico' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Email_de_contacto' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calle' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_exterior' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_interior' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Colonia' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CP' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Ciudad' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estado' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Telefonos' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'En_Hospital' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_del_Hospital' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Piso_hospital' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_consultorio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Redes_sociales' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Aseguradoras_con_convenio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Se_ajusta_tabulador' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Profesion' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Especialidad' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Titulos' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Resumen_Profesional' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Regimen_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_o_Razon_Social' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'RFC' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calle_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_exterior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_interior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Colonia_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CP_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Ciudad_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estado_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Telefono_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fax' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombres_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Apellido_Paterno_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Apellido_Materno_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_Completo_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Regimen_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_o_Razon_Social' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'RFC' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calle_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_exterior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_interior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Colonia_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CP_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Ciudad_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estado_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Telefono' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fax' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Codigos_para_Referenciar_Pacientes' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Suscripcion_Red_de_Especialistas' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calificacion_Red_de_Medicos' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Banco' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CLABE_Interbancaria' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_Cuenta' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_del_Titular' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Facturas' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Cedula_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Contratos' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Identificacion_Oficial' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Cedula_Fiscal_Documento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Comprobante_de_Domicilio' + rowIndex));

}
//BusinessRuleId:150, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:150, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Contactos' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Email_ppal_publico' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Email_de_contacto' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calle' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_exterior' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_interior' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Colonia' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CP' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Ciudad' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estado' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Telefonos' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'En_Hospital' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_del_Hospital' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Piso_hospital' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_consultorio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Redes_sociales' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Aseguradoras_con_convenio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Se_ajusta_tabulador' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Profesion' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Especialidad' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Titulos' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Resumen_Profesional' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Regimen_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_o_Razon_Social' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'RFC' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calle_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_exterior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_interior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Colonia_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CP_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Ciudad_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estado_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Telefono_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fax' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombres_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Apellido_Paterno_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Apellido_Materno_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_Completo_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Regimen_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_o_Razon_Social' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'RFC' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calle_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_exterior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_interior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Colonia_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CP_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Ciudad_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estado_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Telefono' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fax' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Codigos_para_Referenciar_Pacientes' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Suscripcion_Red_de_Especialistas' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calificacion_Red_de_Medicos' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Banco' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CLABE_Interbancaria' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_Cuenta' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_del_Titular' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Facturas' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Cedula_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Contratos' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Identificacion_Oficial' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Cedula_Fiscal_Documento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Comprobante_de_Domicilio' + rowIndex));

}
//BusinessRuleId:150, Attribute:0, Operation:Object, Event:SCREENOPENING



//BusinessRuleId:128, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Email_institucional' + rowIndex));
 $('#divEmail_institucional').css('display', 'none'); 
 SetNotRequiredToControl( $('#' + nameOfTable + 'Email_institucional' + rowIndex)); 
 $("a[href='#tabDatos_de_Contacto']").css('display', 'none'); 
 $("a[href='#tabDatos_Profesionales']").css('display', 'none');
 $("a[href='#tabDatos_Fiscales']").css('display', 'none'); 
 $("a[href='#tabDocumentacion']").css('display', 'none');
 $("a[href='#tabCodigos_de_Referencia']").css('display', 'none'); $("a[href='#tabSuscripcion_Red_de_Especialistas']").css('display', 'none'); 
 $("a[href='#tabDatos_Bancarios']").css('display', 'none'); $("a[href='#tabFacturacion']").css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Contactos' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Email_ppal_publico' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Email_de_contacto' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calle' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_exterior' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_interior' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Colonia' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CP' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Ciudad' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estado' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Telefonos' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'En_Hospital' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_del_Hospital' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Piso_hospital' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_consultorio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Redes_sociales' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Aseguradoras_con_convenio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Se_ajusta_tabulador' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Codigos_para_Referenciar_Pacientes' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Regimen_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_o_Razon_Social' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'RFC' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calle_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_exterior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_interior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Colonia_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CP_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Ciudad_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estado_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Telefono_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fax' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombres_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Apellido_Paterno_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Apellido_Materno_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_Completo_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Regimen_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_o_Razon_Social' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'RFC' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calle_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_exterior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_interior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Colonia_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CP_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Ciudad_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estado_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Telefono' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fax' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Profesion' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Especialidad' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Titulos' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Resumen_Profesional' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Cedula_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Contratos' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Identificacion_Oficial' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Cedula_Fiscal_Documento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Comprobante_de_Domicilio' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Facturas' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Suscripcion_Red_de_Especialistas' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calificacion_Red_de_Medicos' + rowIndex));

}
//BusinessRuleId:128, Attribute:0, Operation:Object, Event:SCREENOPENING

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



function EjecutarValidacionesAntesDeGuardarMRDetalle_Identificacion_Oficial_Medicos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Identificacion_Oficial_Medicos// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Identificacion_Oficial_Medicos(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Identificacion_Oficial_Medicos// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Identificacion_Oficial_Medicos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Identificacion_Oficial_Medicos// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Identificacion_Oficial_Medicos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Detalle_Identificacion_Oficial_Medicos// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Identificacion_Oficial_Medicos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detalle_Identificacion_Oficial_Medicos// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRDetalle_Titulos_Medicos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Titulos_Medicos// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Titulos_Medicos(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Titulos_Medicos// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Titulos_Medicos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Titulos_Medicos// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Titulos_Medicos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Detalle_Titulos_Medicos// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Titulos_Medicos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detalle_Titulos_Medicos// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRDetalle_Convenio_Medicos_Aseguradoras(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Convenio_Medicos_Aseguradoras// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Convenio_Medicos_Aseguradoras(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Convenio_Medicos_Aseguradoras// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Convenio_Medicos_Aseguradoras(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Convenio_Medicos_Aseguradoras// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Convenio_Medicos_Aseguradoras(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Detalle_Convenio_Medicos_Aseguradoras// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Convenio_Medicos_Aseguradoras(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detalle_Convenio_Medicos_Aseguradoras// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRDetalle_Codigos_Referidos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Codigos_Referidos// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Codigos_Referidos(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Codigos_Referidos// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Codigos_Referidos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Codigos_Referidos// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Codigos_Referidos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Detalle_Codigos_Referidos// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Codigos_Referidos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detalle_Codigos_Referidos// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRDetalle_Planes_de_Suscripcion_Especialistas(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Planes_de_Suscripcion_Especialistas// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Planes_de_Suscripcion_Especialistas(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Planes_de_Suscripcion_Especialistas// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Planes_de_Suscripcion_Especialistas(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Planes_de_Suscripcion_Especialistas// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Planes_de_Suscripcion_Especialistas(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Detalle_Planes_de_Suscripcion_Especialistas// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Planes_de_Suscripcion_Especialistas(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detalle_Planes_de_Suscripcion_Especialistas// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRDetalle_Pagos_Especialistas(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Pagos_Especialistas// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Pagos_Especialistas(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Pagos_Especialistas// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Pagos_Especialistas(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Pagos_Especialistas// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Pagos_Especialistas(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Detalle_Pagos_Especialistas// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Pagos_Especialistas(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detalle_Pagos_Especialistas// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRDatos_Bancarios_Especialistas(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Datos_Bancarios_Especialistas// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDatos_Bancarios_Especialistas(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Datos_Bancarios_Especialistas// 
} 

function EjecutarValidacionesAlEliminarMRDatos_Bancarios_Especialistas(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Datos_Bancarios_Especialistas// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDatos_Bancarios_Especialistas(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Datos_Bancarios_Especialistas// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDatos_Bancarios_Especialistas(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Datos_Bancarios_Especialistas// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRDetalle_Redes_Sociales_Especialista(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Redes_Sociales_Especialista// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Redes_Sociales_Especialista(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Redes_Sociales_Especialista// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Redes_Sociales_Especialista(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Redes_Sociales_Especialista// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Redes_Sociales_Especialista(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Detalle_Redes_Sociales_Especialista// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Redes_Sociales_Especialista(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detalle_Redes_Sociales_Especialista// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRDetalle_Facturacion_Especialistas(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Facturacion_Especialistas// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Facturacion_Especialistas(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Facturacion_Especialistas// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Facturacion_Especialistas(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Facturacion_Especialistas// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Facturacion_Especialistas(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Detalle_Facturacion_Especialistas// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Facturacion_Especialistas(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detalle_Facturacion_Especialistas// 
 return result; 
} 
