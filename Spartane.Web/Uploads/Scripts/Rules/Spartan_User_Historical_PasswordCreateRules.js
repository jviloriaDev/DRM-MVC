var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
$(document).ready(function () {

//BusinessRuleId:5, Attribute:185656, Operation:Field, Event:None
$("form#CreateSpartan_User_Historical_Password").on('change', '#Usuario', function () {
	nameOfTable='';
	rowIndex='';

});


//BusinessRuleId:5, Attribute:185656, Operation:Field, Event:None





//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {

//BusinessRuleId:1, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#' + nameOfTable + 'Fecha_de_Registro' + rowIndex).val(EvaluaQuery(" select convert(nvarchar(11),getdate(),105)", rowIndex, nameOfTable));


}
//BusinessRuleId:1, Attribute:0, Operation:Object, Event:SCREENOPENING











//BusinessRuleId:14, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#' + nameOfTable + 'Usuario' + rowIndex).val(EvaluaQuery(" select 'GLOBAL[USERID]'", rowIndex, nameOfTable));


}
//BusinessRuleId:14, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:8, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#' + nameOfTable + 'Password' + rowIndex).val(EvaluaQuery(" select 'FLD[Usuario]'+' '+'co&2'", rowIndex, nameOfTable));

}
//BusinessRuleId:8, Attribute:0, Operation:Object, Event:SCREENOPENING

//NEWBUSINESSRULE_SCREENOPENING//
}
function EjecutarValidacionesAntesDeGuardar(){
	var result = true;




//NEWBUSINESSRULE_BEFORESAVING//
    return result;
}
function EjecutarValidacionesDespuesDeGuardar(){







//BusinessRuleId:15, Attribute:2, Operation:Object, Event:AFTERSAVING
if(operation == 'New'){
 SendEmailQuery('test', EvaluaQuery(" select 'isramty@gmail.com'", rowIndex, nameOfTable), "'FLD[Password]'",rowIndex,nameOfTable);


}
//BusinessRuleId:15, Attribute:2, Operation:Object, Event:AFTERSAVING

//NEWBUSINESSRULE_AFTERSAVING//
}


