var operation = $('#OperationCreate').val();
var nameOfTable = '';
var rowIndex = '';
$(document).ready(function () {
    //NEWBUSINESSRULE_NONE//
    if (operation == 'New') {
        $('#Creation_Date').val(EvaluaQuery('select convert(nvarchar(11), getdate(), 105)'));
        $('#Creation_Hour').val(EvaluaQuery('select convert(nvarchar(8), getdate(), 108)'));
        $('#User').val(EvaluaQuery('select GLOBAL[USERID]'));
        $('#Status').val(4);
    }
    $('#Last_Updated_Date').val(EvaluaQuery('select convert(nvarchar(11), getdate(), 105)'));
    $('#Last_Updated_Hour').val(EvaluaQuery('select convert(nvarchar(8), getdate(), 108)'));
});
function EjecutarValidacionesAlComienzo() {
//NEWBUSINESSRULE_SCREENOPENING//
}
function EjecutarValidacionesAntesDeGuardar(){
	var result = true;
	if ($('#ErrorName').html() != '') {
        result = false;
        $('#Name').css('border', '1px solid Red');
    }
//NEWBUSINESSRULE_BEFORESAVING//
    return result;
}
function EjecutarValidacionesDespuesDeGuardar(){
//NEWBUSINESSRULE_AFTERSAVING//
}

function EjecutarValidacionesAntesDeGuardarMRSpartan_BR_Conditions_Detail(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Spartan_BR_Conditions_Detail//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRSpartan_BR_Conditions_Detail(nameOfTable, rowIndex) {
    $('.dataTables_scrollHeadInner > table').css('margin-bottom', '0px');
    //NEWBUSINESSRULE_AFTERSAVINGMR_Spartan_BR_Conditions_Detail//
}
function EjecutarValidacionesAlEliminarMRSpartan_BR_Conditions_Detail(nameOfTable, rowIndex){
    var result = true;
    $('.dataTables_scrollHeadInner > table').css('margin-bottom', '0px');
    //NEWBUSINESSRULE_DELETEMR_Spartan_BR_Conditions_Detail//
    return result;
}
function EjecutarValidacionesNewRowMRSpartan_BR_Conditions_Detail(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Spartan_BR_Conditions_Detail//
    return result;
}
function EjecutarValidacionesEditRowMRSpartan_BR_Conditions_Detail(nameOfTable, rowIndex){
    var result = true;
    $('.dataTables_scrollHeadInner > table').css('margin-bottom', '0px');
    //NEWBUSINESSRULE_EDITROWMR_Spartan_BR_Conditions_Detail//
    return result;
}
function EjecutarValidacionesAntesDeGuardarMRSpartan_BR_Actions_True_Detail(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Spartan_BR_Actions_True_Detail//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRSpartan_BR_Actions_True_Detail(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Spartan_BR_Actions_True_Detail//
}
function EjecutarValidacionesAlEliminarMRSpartan_BR_Actions_True_Detail(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Spartan_BR_Actions_True_Detail//
    return result;
}
function EjecutarValidacionesNewRowMRSpartan_BR_Actions_True_Detail(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Spartan_BR_Actions_True_Detail//
    return result;
}
function EjecutarValidacionesEditRowMRSpartan_BR_Actions_True_Detail(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Spartan_BR_Actions_True_Detail//
    return result;
}
function EjecutarValidacionesAntesDeGuardarMRSpartan_BR_Actions_False_Detail(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Spartan_BR_Actions_False_Detail//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRSpartan_BR_Actions_False_Detail(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Spartan_BR_Actions_False_Detail//
}
function EjecutarValidacionesAlEliminarMRSpartan_BR_Actions_False_Detail(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Spartan_BR_Actions_False_Detail//
    return result;
}
function EjecutarValidacionesNewRowMRSpartan_BR_Actions_False_Detail(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Spartan_BR_Actions_False_Detail//
    return result;
}
function EjecutarValidacionesEditRowMRSpartan_BR_Actions_False_Detail(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Spartan_BR_Actions_False_Detail//
    return result;
}
function EjecutarValidacionesAntesDeGuardarMRSpartan_BR_Operation_Detail(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Spartan_BR_Operation_Detail//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRSpartan_BR_Operation_Detail(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Spartan_BR_Operation_Detail//
}
function EjecutarValidacionesAlEliminarMRSpartan_BR_Operation_Detail(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Spartan_BR_Operation_Detail//
    return result;
}
function EjecutarValidacionesNewRowMRSpartan_BR_Operation_Detail(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Spartan_BR_Operation_Detail//
    return result;
}
function EjecutarValidacionesEditRowMRSpartan_BR_Operation_Detail(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Spartan_BR_Operation_Detail//
    return result;
}
function EjecutarValidacionesAntesDeGuardarMRSpartan_BR_Process_Event_Detail(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Spartan_BR_Process_Event_Detail//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRSpartan_BR_Process_Event_Detail(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Spartan_BR_Process_Event_Detail//
}
function EjecutarValidacionesAlEliminarMRSpartan_BR_Process_Event_Detail(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Spartan_BR_Process_Event_Detail//
    return result;
}
function EjecutarValidacionesNewRowMRSpartan_BR_Process_Event_Detail(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Spartan_BR_Process_Event_Detail//
    return result;
}
function EjecutarValidacionesEditRowMRSpartan_BR_Process_Event_Detail(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Spartan_BR_Process_Event_Detail//
    return result;
}
function EjecutarValidacionesAntesDeGuardarMRSpartan_BR_Peer_Review(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Spartan_BR_Peer_Review//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRSpartan_BR_Peer_Review(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Spartan_BR_Peer_Review//
}
function EjecutarValidacionesAlEliminarMRSpartan_BR_Peer_Review(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Spartan_BR_Peer_Review//
    return result;
}
function EjecutarValidacionesNewRowMRSpartan_BR_Peer_Review(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Spartan_BR_Peer_Review//
    return result;
}
function EjecutarValidacionesEditRowMRSpartan_BR_Peer_Review(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Spartan_BR_Peer_Review//
    return result;
}
function EjecutarValidacionesAntesDeGuardarMRSpartan_BR_Testing(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Spartan_BR_Testing//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRSpartan_BR_Testing(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Spartan_BR_Testing//
}
function EjecutarValidacionesAlEliminarMRSpartan_BR_Testing(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Spartan_BR_Testing//
    return result;
}
function EjecutarValidacionesNewRowMRSpartan_BR_Testing(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Spartan_BR_Testing//
    return result;
}
function EjecutarValidacionesEditRowMRSpartan_BR_Testing(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Spartan_BR_Testing//
    return result;
}
function EjecutarValidacionesAntesDeGuardarMRSpartan_BR_Scope_Detail(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Spartan_BR_Scope_Detail//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRSpartan_BR_Scope_Detail(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Spartan_BR_Scope_Detail//
}
function EjecutarValidacionesAlEliminarMRSpartan_BR_Scope_Detail(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Spartan_BR_Scope_Detail//
    return result;
}
function EjecutarValidacionesNewRowMRSpartan_BR_Scope_Detail(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Spartan_BR_Scope_Detail//
    return result;
}
function EjecutarValidacionesEditRowMRSpartan_BR_Scope_Detail(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Spartan_BR_Scope_Detail//
    return result;
}


function EjecutarValidacionesAntesDeGuardarMRConditions(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_BEFORESAVINGMR_Conditions// 
} 

function EjecutarValidacionesDespuesDeGuardarMRConditions(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Conditions// 
} 

function EjecutarValidacionesAlEliminarMRConditions(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_DELETEMR_Conditions// 
} 

function EjecutarValidacionesNewRowMRConditions(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_NEWMR_Conditions// 
} 

function EjecutarValidacionesEditRowMRConditions(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_EDITMR_Conditions// 
} 

function EjecutarValidacionesAntesDeGuardarMRActions_if_conditions_are_True(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_BEFORESAVINGMR_Actions_if_conditions_are_True// 
} 

function EjecutarValidacionesDespuesDeGuardarMRActions_if_conditions_are_True(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Actions_if_conditions_are_True// 
} 

function EjecutarValidacionesAlEliminarMRActions_if_conditions_are_True(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_DELETEMR_Actions_if_conditions_are_True// 
} 

function EjecutarValidacionesNewRowMRActions_if_conditions_are_True(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_NEWMR_Actions_if_conditions_are_True// 
} 

function EjecutarValidacionesEditRowMRActions_if_conditions_are_True(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_EDITMR_Actions_if_conditions_are_True// 
} 

function EjecutarValidacionesAntesDeGuardarMRActions_if_conditions_are_False(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_BEFORESAVINGMR_Actions_if_conditions_are_False// 
} 

function EjecutarValidacionesDespuesDeGuardarMRActions_if_conditions_are_False(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Actions_if_conditions_are_False// 
} 

function EjecutarValidacionesAlEliminarMRActions_if_conditions_are_False(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_DELETEMR_Actions_if_conditions_are_False// 
} 

function EjecutarValidacionesNewRowMRActions_if_conditions_are_False(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_NEWMR_Actions_if_conditions_are_False// 
} 

function EjecutarValidacionesEditRowMRActions_if_conditions_are_False(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_EDITMR_Actions_if_conditions_are_False// 
} 

function EjecutarValidacionesAntesDeGuardarMROperations(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_BEFORESAVINGMR_Operations// 
} 

function EjecutarValidacionesDespuesDeGuardarMROperations(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Operations// 
} 

function EjecutarValidacionesAlEliminarMROperations(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_DELETEMR_Operations// 
} 

function EjecutarValidacionesNewRowMROperations(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_NEWMR_Operations// 
} 

function EjecutarValidacionesEditRowMROperations(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_EDITMR_Operations// 
} 

function EjecutarValidacionesAntesDeGuardarMREvents(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_BEFORESAVINGMR_Events// 
} 

function EjecutarValidacionesDespuesDeGuardarMREvents(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Events// 
} 

function EjecutarValidacionesAlEliminarMREvents(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_DELETEMR_Events// 
} 

function EjecutarValidacionesNewRowMREvents(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_NEWMR_Events// 
} 

function EjecutarValidacionesEditRowMREvents(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_EDITMR_Events// 
} 

function EjecutarValidacionesAntesDeGuardarMRPeer_Reviews(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_BEFORESAVINGMR_Peer_Reviews// 
} 

function EjecutarValidacionesDespuesDeGuardarMRPeer_Reviews(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Peer_Reviews// 
} 

function EjecutarValidacionesAlEliminarMRPeer_Reviews(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_DELETEMR_Peer_Reviews// 
} 

function EjecutarValidacionesNewRowMRPeer_Reviews(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_NEWMR_Peer_Reviews// 
} 

function EjecutarValidacionesEditRowMRPeer_Reviews(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_EDITMR_Peer_Reviews// 
} 

function EjecutarValidacionesAntesDeGuardarMRTesting(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_BEFORESAVINGMR_Testing// 
} 

function EjecutarValidacionesDespuesDeGuardarMRTesting(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Testing// 
} 

function EjecutarValidacionesAlEliminarMRTesting(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_DELETEMR_Testing// 
} 

function EjecutarValidacionesNewRowMRTesting(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_NEWMR_Testing// 
} 

function EjecutarValidacionesEditRowMRTesting(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_EDITMR_Testing// 
} 

function EjecutarValidacionesAntesDeGuardarMRScopes(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_BEFORESAVINGMR_Scopes// 
} 

function EjecutarValidacionesDespuesDeGuardarMRScopes(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Scopes// 
} 

function EjecutarValidacionesAlEliminarMRScopes(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_DELETEMR_Scopes// 
} 

function EjecutarValidacionesNewRowMRScopes(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_NEWMR_Scopes// 
} 

function EjecutarValidacionesEditRowMRScopes(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_EDITMR_Scopes// 
} 
