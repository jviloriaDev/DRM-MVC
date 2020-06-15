var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
$(document).ready(function () {




//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {

//BusinessRuleId:2, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex).val(EvaluaQuery(" select convert(nvarchar(11),getdate(),105)", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Hora_de_Registro' + rowIndex).val(EvaluaQuery("  select convert(nvarchar(8),getdate(),108)", rowIndex, nameOfTable));


}
//BusinessRuleId:2, Attribute:0, Operation:Object, Event:SCREENOPENING






//BusinessRuleId:13, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#' + nameOfTable + 'Usuario' + rowIndex).val(EvaluaQuery(" select 'GLOBAL[USERID]'", rowIndex, nameOfTable));


}
//BusinessRuleId:13, Attribute:0, Operation:Object, Event:SCREENOPENING

//NEWBUSINESSRULE_SCREENOPENING//
}
function EjecutarValidacionesAntesDeGuardar(){
	var result = true;
//NEWBUSINESSRULE_BEFORESAVING//
    return result;
}
function EjecutarValidacionesDespuesDeGuardar(){


    //BusinessRuleId:16, Attribute:2, Operation:Object, Event:AFTERSAVING
if(operation == 'Update'){
    if (GetValueByControlType($('#' + nameOfTable + 'Estatus' + rowIndex)) == TryParseInt('2', '2')) { SendEmailQuery('Change Password', EvaluaQuery(" select 'FLD[Email]'", rowIndex, nameOfTable), 'Su cambio de Password fue Autorizado', rowIndex, nameOfTable); } else { }
    if (GetValueByControlType($('#' + nameOfTable + 'Estatus' + rowIndex)) == TryParseInt('3', '3')) { SendEmailQuery('Change Password', EvaluaQuery(" select 'FLD[Email]'", rowIndex, nameOfTable), 'Su cambio de Password no fue Autorizado', rowIndex, nameOfTable); } else { }

}
//BusinessRuleId:16, Attribute:2, Operation:Object, Event:AFTERSAVING

//NEWBUSINESSRULE_AFTERSAVING//
}


