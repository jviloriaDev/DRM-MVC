var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
$(document).ready(function () {






//BusinessRuleId:139, Attribute:258954, Operation:Field, Event:None
$("form#CreateEmpresas").on('change', '#Tipo_de_Empresa', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'Tipo_de_Empresa' + rowIndex).val()==TryParseInt('2', '2') || $('#' + nameOfTable + 'Tipo_de_Empresa' + rowIndex).val()==TryParseInt('3', '3') ) 
{ $("a[href='#tabSuscripcion']").css('display', 'block'); $("a[href='#tabDocumentacion']").css('display', 'block');} 
else { $("a[href='#tabSuscripcion']").css('display', 'none'); $("a[href='#tabDocumentacion']").css('display', 'none');}
});

//BusinessRuleId:139, Attribute:258954, Operation:Field, Event:None

//BusinessRuleId:143, Attribute:258329, Operation:Field, Event:None
$("form#CreateEmpresas").on('keyup', '#Nombres_del_Representante_Legal', function () {
	nameOfTable='';
	rowIndex='';
 AsignarValor($('#' + nameOfTable + 'Nombre_Completo_del_Representante_Legal' + rowIndex),EvaluaQuery("select 'FLD[Nombres_del_Representante_Legal]' + ' ' + 'FLD[Apellido_Paterno_del_Representante_Legal]' + ' ' + 'FLD[Apellido_Materno_del_Representante_Legal]'", rowIndex, nameOfTable));
});

//BusinessRuleId:143, Attribute:258329, Operation:Field, Event:None

//BusinessRuleId:144, Attribute:258330, Operation:Field, Event:None
$("form#CreateEmpresas").on('keyup', '#Apellido_Paterno_del_Representante_Legal', function () {
	nameOfTable='';
	rowIndex='';
 AsignarValor($('#' + nameOfTable + 'Nombre_Completo_del_Representante_Legal' + rowIndex),EvaluaQuery(" select 'FLD[Nombres_del_Representante_Legal]' + ' ' + 'FLD[Apellido_Paterno_del_Representante_Legal]' + ' ' + 'FLD[Apellido_Materno_del_Representante_Legal]'", rowIndex, nameOfTable));
});

//BusinessRuleId:144, Attribute:258330, Operation:Field, Event:None

//BusinessRuleId:145, Attribute:258331, Operation:Field, Event:None
$("form#CreateEmpresas").on('keyup', '#Apellido_Materno_del_Representante_Legal', function () {
	nameOfTable='';
	rowIndex='';
 AsignarValor($('#' + nameOfTable + 'Nombre_Completo_del_Representante_Legal' + rowIndex),EvaluaQuery(" select 'FLD[Nombres_del_Representante_Legal]' + ' ' + 'FLD[Apellido_Paterno_del_Representante_Legal]' + ' ' + 'FLD[Apellido_Materno_del_Representante_Legal]'", rowIndex, nameOfTable));
});

//BusinessRuleId:145, Attribute:258331, Operation:Field, Event:None

//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {
//BusinessRuleId:83, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#divFolio').css('display', 'none'); $('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex).val(EvaluaQuery(" select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Hora_de_Registro' + rowIndex).val(EvaluaQuery("select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex).val(EvaluaQuery("select GLOBAL[USERID]"
+" "
+" ", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:83, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:83, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 $('#divFolio').css('display', 'none'); $('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex).val(EvaluaQuery(" select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Hora_de_Registro' + rowIndex).val(EvaluaQuery("select convert (varchar(8),getdate(),108)", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex).val(EvaluaQuery("select GLOBAL[USERID]"
+" "
+" ", rowIndex, nameOfTable)); DisabledControl($("#" + nameOfTable + "Fecha_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Hora_de_Registro" + rowIndex), ("true" == "true")); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:83, Attribute:0, Operation:Object, Event:SCREENOPENING

// VALIDAR RFC
 $( "#RFC" ).blur(function() { 
	var v = $('#' + nameOfTable + 'RFC' + rowIndex).val(); 
	if (v != ""){ 
		var valid = '^(([A-Z]|[a-z]){3})([0-9]{6})((([A-Z]|[a-z]|[0-9]){3}))'; 
		var validRfc=new RegExp(valid); 
		var matchArray=v.match(validRfc); 
		if (matchArray==null || v.length>12) { 
			$('#' + nameOfTable + 'RFC' + rowIndex).attr("placeholder", "El formato del RFC es incorrecto.").val("").focus().blur(); 
			return false; 
		} 
	} 
  });

//NO PERMITIR MÁS DE 5 DIGITOS EN CP
$("form#CreateEmpresas").on('keyup', '#CP', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'CP' + rowIndex).val()<=TryParseInt('99999', '99999') ) {} else { $('#CP').attr("placeholder", "No se permiten más de 5 dígitos.").val("").focus().blur();}
});


//NO PERMITIR MÁS DE 5 DIGITOS EN CP FISCAL
$("form#CreateEmpresas").on('keyup', '#CP_Fiscal', function () {
	nameOfTable='';
	rowIndex='';
if( $('#' + nameOfTable + 'CP_Fiscal' + rowIndex).val()<=TryParseInt('99999', '99999') ) {} else { $('#CP_Fiscal').attr("placeholder", "No se permiten más de 5 dígitos.").val("").focus().blur();}
});

//VALIDAR CORREO
	$('#Email').change(function(){ 
		let email = $('#Email').val(); 
		let exp = new RegExp(/^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/); 
		if (exp.test(email) == false){ 
			$('#Email').attr("placeholder", "Correo electrónico no válido.").val("").focus().blur(); 
		} 
	});

//BusinessRuleId:136, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $("a[href='#tabSuscripcion']").css('display', 'none'); $("a[href='#tabDocumentacion']").css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Cedula_Fiscal' + rowIndex));

}
//BusinessRuleId:136, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:136, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 $("a[href='#tabSuscripcion']").css('display', 'none'); $("a[href='#tabDocumentacion']").css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Cedula_Fiscal' + rowIndex));

}
//BusinessRuleId:136, Attribute:0, Operation:Object, Event:SCREENOPENING





//BusinessRuleId:137, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_interior' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CP' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus' + rowIndex)); $("a[href='#tabDatos Fiscales']").css('display', 'block'); SetNotRequiredToControl( $('#' + nameOfTable + 'Regimen_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_o_Razon_Social' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'RFC' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calle_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_exterior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_interior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Colonia_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CP_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Ciudad_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estado_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Telefono_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fax' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombres_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Apellido_Paterno_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Apellido_Materno_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_Completo_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Regimen_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_o_Razon_Social' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'RFC' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calle_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_exterior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_interior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Colonia_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CP_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Ciudad_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estado_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Telefono' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fax' + rowIndex));

}
//BusinessRuleId:137, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:137, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_interior' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CP' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus' + rowIndex)); $("a[href='#tabDatos Fiscales']").css('display', 'block'); SetNotRequiredToControl( $('#' + nameOfTable + 'Regimen_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_o_Razon_Social' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'RFC' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calle_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_exterior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_interior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Colonia_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CP_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Ciudad_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estado_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Telefono_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fax' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombres_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Apellido_Paterno_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Apellido_Materno_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_Completo_del_Representante_Legal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Regimen_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Nombre_o_Razon_Social' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'RFC' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Calle_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_exterior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_interior_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Colonia_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'CP_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Ciudad_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Estado_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Pais_Fiscal' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Telefono' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Fax' + rowIndex));

}
//BusinessRuleId:137, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:138, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 AsignarValor($('#' + nameOfTable + 'Estatus' + rowIndex),1);

}
//BusinessRuleId:138, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:142, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 DisabledControl($("#" + nameOfTable + "Nombre_Completo_del_Representante_Legal" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:142, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:142, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 DisabledControl($("#" + nameOfTable + "Nombre_Completo_del_Representante_Legal" + rowIndex), ("true" == "true"));

}
//BusinessRuleId:142, Attribute:0, Operation:Object, Event:SCREENOPENING



//BusinessRuleId:147, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 AsignarValor($('#' + nameOfTable + 'Pais_Fiscal' + rowIndex),1);

}
//BusinessRuleId:147, Attribute:0, Operation:Object, Event:SCREENOPENING

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



function EjecutarValidacionesAntesDeGuardarMRDetalle_Contactos_Empresa(nameOfTable, rowIndex){ 
 var result= true; 












//BusinessRuleId:141, Attribute:258519, Operation:Object, Event:BEFORESAVINGMR
if(operation == 'New'){
if( EvaluaQuery("select COUNT(Name) from Spartan_User where Name = 'FLD[Nombre_de_usuario]'",rowIndex, nameOfTable)>=TryParseInt('1', '1') ) { alert(DecodifyText('El nombre del usuario ya está registrado.', rowIndex, nameOfTable));
result=false;} else {}

}
//BusinessRuleId:141, Attribute:258519, Operation:Object, Event:BEFORESAVINGMR

//BusinessRuleId:141, Attribute:258519, Operation:Object, Event:BEFORESAVINGMR
if(operation == 'Update'){
if( EvaluaQuery("select COUNT(Name) from Spartan_User where Name = 'FLD[Nombre_de_usuario]'",rowIndex, nameOfTable)>=TryParseInt('1', '1') ) { alert(DecodifyText('El nombre del usuario ya está registrado.', rowIndex, nameOfTable));
result=false;} else {}

}
//BusinessRuleId:141, Attribute:258519, Operation:Object, Event:BEFORESAVINGMR

//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Contactos_Empresa// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Contactos_Empresa(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Contactos_Empresa// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Contactos_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Contactos_Empresa// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Contactos_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//BusinessRuleId:140, Attribute:258519, Operation:Object, Event:NEWROWMR
if(operation == 'New'){
 AsignarValor($('#' + nameOfTable + 'Estatus' + rowIndex),2);

}
//BusinessRuleId:140, Attribute:258519, Operation:Object, Event:NEWROWMR

//BusinessRuleId:140, Attribute:258519, Operation:Object, Event:NEWROWMR
if(operation == 'Update'){
 AsignarValor($('#' + nameOfTable + 'Estatus' + rowIndex),2);

}
//BusinessRuleId:140, Attribute:258519, Operation:Object, Event:NEWROWMR

//NEWBUSINESSRULE_NEWROWMR_Detalle_Contactos_Empresa// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Contactos_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detalle_Contactos_Empresa// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRDetalle_Suscripciones_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Suscripciones_Empresa// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Suscripciones_Empresa(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Suscripciones_Empresa// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Suscripciones_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Suscripciones_Empresa// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Suscripciones_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Detalle_Suscripciones_Empresa// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Suscripciones_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detalle_Suscripciones_Empresa// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRDetalle_Pagos_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Pagos_Empresa// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Pagos_Empresa(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Pagos_Empresa// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Pagos_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Pagos_Empresa// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Pagos_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Detalle_Pagos_Empresa// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Pagos_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detalle_Pagos_Empresa// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRDetalle_Contratos_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Contratos_Empresa// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Contratos_Empresa(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Contratos_Empresa// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Contratos_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Contratos_Empresa// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Contratos_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Detalle_Contratos_Empresa// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Contratos_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detalle_Contratos_Empresa// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRDetalle_Registro_Beneficiarios_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Registro_Beneficiarios_Empresa// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Registro_Beneficiarios_Empresa(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Registro_Beneficiarios_Empresa// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Registro_Beneficiarios_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Registro_Beneficiarios_Empresa// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Registro_Beneficiarios_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Detalle_Registro_Beneficiarios_Empresa// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Registro_Beneficiarios_Empresa(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detalle_Registro_Beneficiarios_Empresa// 
 return result; 
} 
