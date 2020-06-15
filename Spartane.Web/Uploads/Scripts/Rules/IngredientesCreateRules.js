var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
$(document).ready(function () {
//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {
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



function EjecutarValidacionesAntesDeGuardarMRDetalle_Caracteristicas_Ingrediente(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Caracteristicas_Ingrediente// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Caracteristicas_Ingrediente(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Caracteristicas_Ingrediente// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Caracteristicas_Ingrediente(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Caracteristicas_Ingrediente// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Caracteristicas_Ingrediente(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Detalle_Caracteristicas_Ingrediente// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Caracteristicas_Ingrediente(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detalle_Caracteristicas_Ingrediente// 
 return result; 
} 
