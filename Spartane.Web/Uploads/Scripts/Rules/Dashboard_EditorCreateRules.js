var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
var saltarValidacion = false;
$(document).ready(function () {
//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {
//BusinessRuleId:2, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#' + nameOfTable + 'Registration_Date' + rowIndex).val(EvaluaQuery(" SELECT CONVERT(NVARCHAR(11),GETDATE(),105)", rowIndex, nameOfTable)); $('#' + nameOfTable + 'Registration_User' + rowIndex).val(EvaluaQuery("SELECT GLOBAL[USERID]", rowIndex, nameOfTable));

}
//BusinessRuleId:2, Attribute:0, Operation:Object, Event:SCREENOPENING

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

function EjecutarValidacionesAntesDeGuardarMRDashboard_Config_Detail(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Dashboard_Config_Detail//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRDashboard_Config_Detail(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Dashboard_Config_Detail//
}
function EjecutarValidacionesAlEliminarMRDashboard_Config_Detail(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Dashboard_Config_Detail//
    return result;
}
function EjecutarValidacionesNewRowMRDashboard_Config_Detail(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Dashboard_Config_Detail//
    return result;
}
function EjecutarValidacionesEditRowMRDashboard_Config_Detail(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Dashboard_Config_Detail//
    return result;
}


function EjecutarValidacionesAntesDeGuardarMRDetail(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Detail// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetail(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detail// 
} 

function EjecutarValidacionesAlEliminarMRDetail(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detail// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetail(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Detail// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetail(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detail// 
 return result; 
} 
