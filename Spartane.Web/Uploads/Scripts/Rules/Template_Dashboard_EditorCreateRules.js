var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
var saltarValidacion = false;
$(document).ready(function () {
//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {
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

function EjecutarValidacionesAntesDeGuardarMRTemplate_Dashboard_Detail(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Template_Dashboard_Detail//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRTemplate_Dashboard_Detail(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Template_Dashboard_Detail//
}
function EjecutarValidacionesAlEliminarMRTemplate_Dashboard_Detail(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Template_Dashboard_Detail//
    return result;
}
function EjecutarValidacionesNewRowMRTemplate_Dashboard_Detail(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Template_Dashboard_Detail//
    return result;
}
function EjecutarValidacionesEditRowMRTemplate_Dashboard_Detail(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Template_Dashboard_Detail//
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
