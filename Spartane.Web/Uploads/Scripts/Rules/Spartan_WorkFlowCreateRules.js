var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
$(document).ready(function () {


    //NEWBUSINESSRULE_NONE//

});
function EjecutarValidacionesAlComienzo() {














    //BusinessRuleId:1432, Attribute:0, Operation:Object, Event:SCREENOPENING
    if (operation == 'Update') {
        CreateSessionVar('workid', EvaluaQuery("select 'FLDD[lblWorkFlowId]'", rowIndex, nameOfTable));


    }
    //BusinessRuleId:1432, Attribute:0, Operation:Object, Event:SCREENOPENING

    //BusinessRuleId:1430, Attribute:0, Operation:Object, Event:SCREENOPENING
    if (operation == 'New') {
        $("a[href='#tabMatrix_of_States']").css('display', 'none');


    }
    //BusinessRuleId:1430, Attribute:0, Operation:Object, Event:SCREENOPENING

    //BusinessRuleId:1430, Attribute:0, Operation:Object, Event:SCREENOPENING
    if (operation == 'Update') {
        $("a[href='#tabMatrix_of_States']").css('display', 'none');


    }
    //BusinessRuleId:1430, Attribute:0, Operation:Object, Event:SCREENOPENING

    //BusinessRuleId:1430, Attribute:0, Operation:Object, Event:SCREENOPENING
    if (operation == 'Consult') {
        $("a[href='#tabMatrix_of_States']").css('display', 'none');


    }
    //BusinessRuleId:1430, Attribute:0, Operation:Object, Event:SCREENOPENING

    //NEWBUSINESSRULE_SCREENOPENING//

}
function EjecutarValidacionesAntesDeGuardar() {
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVING//

    return result;
}
function EjecutarValidacionesDespuesDeGuardar() {
    //NEWBUSINESSRULE_AFTERSAVING//

}

function EjecutarValidacionesAntesDeGuardarMRSpartan_WorkFlow_Phases(nameOfTable, rowIndex) {
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Spartan_WorkFlow_Phases//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRSpartan_WorkFlow_Phases(nameOfTable, rowIndex) {
    //NEWBUSINESSRULE_AFTERSAVINGMR_Spartan_WorkFlow_Phases//
}
function EjecutarValidacionesAlEliminarMRSpartan_WorkFlow_Phases(nameOfTable, rowIndex) {
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Spartan_WorkFlow_Phases//
    return result;
}
function EjecutarValidacionesNewRowMRSpartan_WorkFlow_Phases(nameOfTable, rowIndex) {
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Spartan_WorkFlow_Phases//
    return result;
}
function EjecutarValidacionesAntesDeGuardarMRSpartan_WorkFlow_State(nameOfTable, rowIndex) {
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Spartan_WorkFlow_State//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRSpartan_WorkFlow_State(nameOfTable, rowIndex) {
    //NEWBUSINESSRULE_AFTERSAVINGMR_Spartan_WorkFlow_State//
}
function EjecutarValidacionesAlEliminarMRSpartan_WorkFlow_State(nameOfTable, rowIndex) {
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Spartan_WorkFlow_State//
    return result;
}
function EjecutarValidacionesNewRowMRSpartan_WorkFlow_State(nameOfTable, rowIndex) {
    var result = true;








    //BusinessRuleId:1439, Attribute:163581, Operation:Object, Event:NEWROWMR
    if (operation == 'New') {
        var valor = $('#' + nameOfTable + 'Attribute' + rowIndex).val(); $('#' + nameOfTable + 'Attribute' + rowIndex).empty(); if (!$('#' + nameOfTable + 'Attribute' + rowIndex).hasClass('AutoComplete')) {
            $('#' + nameOfTable + 'Attribute' + rowIndex).append($("<option selected />").val("").text("")); $.each(EvaluaQueryDictionary("select AttributeId, Physical_Name from Spartan_Metadata"
           + " "
           + " where Object_Id = FLDP[Object]", rowIndex, nameOfTable), function (index, value) { $('#' + nameOfTable + 'Attribute' + rowIndex).append($("<option />").val(index).text(value)); });
        } else {
            $('#' + nameOfTable + 'Attribute' + rowIndex).select2('destroy').empty(); var selectData = []; selectData.push({ id: "", text: "" }); $.each(EvaluaQueryDictionary("select AttributeId, Physical_Name from Spartan_Metadata"
            + " "
            + " where Object_Id = FLDP[Object]", rowIndex, nameOfTable), function (index, value) { selectData.push({ id: index, text: value }); }); $('#' + nameOfTable + 'Attribute' + rowIndex).select2({ data: selectData })
        } $('#' + nameOfTable + 'Attribute' + rowIndex).val(valor);


    }
    //BusinessRuleId:1439, Attribute:163581, Operation:Object, Event:NEWROWMR

    //BusinessRuleId:1439, Attribute:163581, Operation:Object, Event:NEWROWMR
    if (operation == 'Update') {
        var valor = $('#' + nameOfTable + 'Attribute' + rowIndex).val(); $('#' + nameOfTable + 'Attribute' + rowIndex).empty(); if (!$('#' + nameOfTable + 'Attribute' + rowIndex).hasClass('AutoComplete')) {
            $('#' + nameOfTable + 'Attribute' + rowIndex).append($("<option selected />").val("").text("")); $.each(EvaluaQueryDictionary("select AttributeId, Physical_Name from Spartan_Metadata"
           + " "
           + " where Object_Id = FLDP[Object]", rowIndex, nameOfTable), function (index, value) { $('#' + nameOfTable + 'Attribute' + rowIndex).append($("<option />").val(index).text(value)); });
        } else {
            $('#' + nameOfTable + 'Attribute' + rowIndex).select2('destroy').empty(); var selectData = []; selectData.push({ id: "", text: "" }); $.each(EvaluaQueryDictionary("select AttributeId, Physical_Name from Spartan_Metadata"
            + " "
            + " where Object_Id = FLDP[Object]", rowIndex, nameOfTable), function (index, value) { selectData.push({ id: index, text: value }); }); $('#' + nameOfTable + 'Attribute' + rowIndex).select2({ data: selectData })
        } $('#' + nameOfTable + 'Attribute' + rowIndex).val(valor);


    }
    //BusinessRuleId:1439, Attribute:163581, Operation:Object, Event:NEWROWMR

    //BusinessRuleId:1431, Attribute:163581, Operation:Object, Event:NEWROWMR
    if (operation == 'Update') {
        var valor = $('#' + nameOfTable + 'Phase' + rowIndex).val(); $('#' + nameOfTable + 'Phase' + rowIndex).empty(); if (!$('#' + nameOfTable + 'Phase' + rowIndex).hasClass('AutoComplete')) {
            $('#' + nameOfTable + 'Phase' + rowIndex).append($("<option selected />").val("").text("")); $.each(EvaluaQueryDictionary("select PhasesId, Name from Spartan_WorkFlow_Phases"
           + " "
           + " where Workflow = GLOBAL[workid]", rowIndex, nameOfTable), function (index, value) { $('#' + nameOfTable + 'Phase' + rowIndex).append($("<option />").val(index).text(value)); });
        } else {
            $('#' + nameOfTable + 'Phase' + rowIndex).select2('destroy').empty(); var selectData = []; selectData.push({ id: "", text: "" }); $.each(EvaluaQueryDictionary("select PhasesId, Name from Spartan_WorkFlow_Phases"
            + " "
            + " where Workflow = GLOBAL[workid]", rowIndex, nameOfTable), function (index, value) { selectData.push({ id: index, text: value }); }); $('#' + nameOfTable + 'Phase' + rowIndex).select2({ data: selectData })
        } $('#' + nameOfTable + 'Phase' + rowIndex).val(valor);


    }
    //BusinessRuleId:1431, Attribute:163581, Operation:Object, Event:NEWROWMR

    //NEWBUSINESSRULE_NEWROWMR_Spartan_WorkFlow_State//
    return result;
}
function EjecutarValidacionesAntesDeGuardarMRSpartan_WorkFlow_Conditions_by_State(nameOfTable, rowIndex) {
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Spartan_WorkFlow_Conditions_by_State//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRSpartan_WorkFlow_Conditions_by_State(nameOfTable, rowIndex) {
    //NEWBUSINESSRULE_AFTERSAVINGMR_Spartan_WorkFlow_Conditions_by_State//
}
function EjecutarValidacionesAlEliminarMRSpartan_WorkFlow_Conditions_by_State(nameOfTable, rowIndex) {
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Spartan_WorkFlow_Conditions_by_State//
    return result;
}
function EjecutarValidacionesNewRowMRSpartan_WorkFlow_Conditions_by_State(nameOfTable, rowIndex) {
    var result = true;






    //BusinessRuleId:1435, Attribute:163625, Operation:Object, Event:NEWROWMR
    if (operation == 'New') {
        var valor = $('#' + nameOfTable + 'Phase' + rowIndex).val(); $('#' + nameOfTable + 'Phase' + rowIndex).empty(); if (!$('#' + nameOfTable + 'Phase' + rowIndex).hasClass('AutoComplete')) {
            $('#' + nameOfTable + 'Phase' + rowIndex).append($("<option selected />").val("").text("")); $.each(EvaluaQueryDictionary("select PhasesId, Name from Spartan_WorkFlow_Phases"
           + " "
           + "  where Workflow = GLOBAL[workid]", rowIndex, nameOfTable), function (index, value) { $('#' + nameOfTable + 'Phase' + rowIndex).append($("<option />").val(index).text(value)); });
        } else {
            $('#' + nameOfTable + 'Phase' + rowIndex).select2('destroy').empty(); var selectData = []; selectData.push({ id: "", text: "" }); $.each(EvaluaQueryDictionary("select PhasesId, Name from Spartan_WorkFlow_Phases"
            + " "
            + "  where Workflow = GLOBAL[workid]", rowIndex, nameOfTable), function (index, value) { selectData.push({ id: index, text: value }); }); $('#' + nameOfTable + 'Phase' + rowIndex).select2({ data: selectData })
        } $('#' + nameOfTable + 'Phase' + rowIndex).val(valor);


    }
    //BusinessRuleId:1435, Attribute:163625, Operation:Object, Event:NEWROWMR

    //BusinessRuleId:1435, Attribute:163625, Operation:Object, Event:NEWROWMR
    if (operation == 'Update') {
        var valor = $('#' + nameOfTable + 'Phase' + rowIndex).val(); $('#' + nameOfTable + 'Phase' + rowIndex).empty(); if (!$('#' + nameOfTable + 'Phase' + rowIndex).hasClass('AutoComplete')) {
            $('#' + nameOfTable + 'Phase' + rowIndex).append($("<option selected />").val("").text("")); $.each(EvaluaQueryDictionary("select PhasesId, Name from Spartan_WorkFlow_Phases"
           + " "
           + "  where Workflow = GLOBAL[workid]", rowIndex, nameOfTable), function (index, value) { $('#' + nameOfTable + 'Phase' + rowIndex).append($("<option />").val(index).text(value)); });
        } else {
            $('#' + nameOfTable + 'Phase' + rowIndex).select2('destroy').empty(); var selectData = []; selectData.push({ id: "", text: "" }); $.each(EvaluaQueryDictionary("select PhasesId, Name from Spartan_WorkFlow_Phases"
            + " "
            + "  where Workflow = GLOBAL[workid]", rowIndex, nameOfTable), function (index, value) { selectData.push({ id: index, text: value }); }); $('#' + nameOfTable + 'Phase' + rowIndex).select2({ data: selectData })
        } $('#' + nameOfTable + 'Phase' + rowIndex).val(valor);


    }
    //BusinessRuleId:1435, Attribute:163625, Operation:Object, Event:NEWROWMR
    if ($('#' + nameOfTable + 'Phase' + rowIndex).val() == '') {
        $('#' + nameOfTable + 'State' + rowIndex).empty();
    }
    else {
        var valor = $('#' + nameOfTable + 'Phase' + rowIndex).val();
        var valorState = $('#' + nameOfTable + 'State' + rowIndex).val();
        $('#' + nameOfTable + 'State' + rowIndex).empty();
        $('#' + nameOfTable + 'State' + rowIndex).append($("<option selected />").val("").text(""));
        $.each(EvaluaQueryDictionary("select StateId, Name from Spartan_WorkFlow_State"
           + " "
           + "  where Phase = " + valor, rowIndex, nameOfTable), function (index, value) {
               $('#' + nameOfTable + 'State' + rowIndex).append($("<option />").val(index).text(value));
           });
        $('#' + nameOfTable + 'State' + rowIndex).val(valorState);
    }

    $('#' + nameOfTable + 'Phase' + rowIndex).change(function () {
        var valor = $('#' + nameOfTable + 'Phase' + rowIndex).val();
        var valorState = $('#' + nameOfTable + 'State' + rowIndex).val();
        $('#' + nameOfTable + 'State' + rowIndex).empty();
        $('#' + nameOfTable + 'State' + rowIndex).append($("<option selected />").val("").text(""));
        $.each(EvaluaQueryDictionary("select StateId, Name from Spartan_WorkFlow_State"
           + " "
           + "  where Phase = " + valor, rowIndex, nameOfTable), function (index, value) {
               $('#' + nameOfTable + 'State' + rowIndex).append($("<option />").val(index).text(value));
           });
        $('#' + nameOfTable + 'State' + rowIndex).val(valorState);
    });

    if (operation == 'New' || operation == 'Update') {
        var valor = $('#' + nameOfTable + 'Attribute' + rowIndex).val(); $('#' + nameOfTable + 'Attribute' + rowIndex).empty(); if (!$('#' + nameOfTable + 'Attribute' + rowIndex).hasClass('AutoComplete')) {
            $('#' + nameOfTable + 'Attribute' + rowIndex).append($("<option selected />").val("").text("")); $.each(EvaluaQueryDictionary("select AttributeId, Physical_Name from Spartan_Metadata"
           + " "
           + "  where Object_Id = FLDP[Object]", rowIndex, nameOfTable), function (index, value) { $('#' + nameOfTable + 'Attribute' + rowIndex).append($("<option />").val(index).text(value)); });
        } else {
            $('#' + nameOfTable + 'Attribute' + rowIndex).select2('destroy').empty(); var selectData = []; selectData.push({ id: "", text: "" }); $.each(EvaluaQueryDictionary("select AttributeId, Physical_Name from Spartan_Metadata"
            + " "
            + "  where Object_Id = FLDP[Object]", rowIndex, nameOfTable), function (index, value) { selectData.push({ id: index, text: value }); }); $('#' + nameOfTable + 'Attribute' + rowIndex).select2({ data: selectData })
        } $('#' + nameOfTable + 'Attribute' + rowIndex).val(valor);


    }
    //NEWBUSINESSRULE_NEWROWMR_Spartan_WorkFlow_Conditions_by_State//
    return result;
}
function EjecutarValidacionesAntesDeGuardarMRSpartan_WorkFlow_Information_by_State(nameOfTable, rowIndex) {
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Spartan_WorkFlow_Information_by_State//
    return result;
}
function EjecutarValidacionesEditRowMRSpartan_WorkFlow_Information_by_State(nameOfTable, rowIndex) {
    var result = true;
    //EDITBUSINESSRULE_BEFORESAVINGMR_Spartan_WorkFlow_Information_by_State//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRSpartan_WorkFlow_Information_by_State(nameOfTable, rowIndex) {
    //NEWBUSINESSRULE_AFTERSAVINGMR_Spartan_WorkFlow_Information_by_State//
}
function EjecutarValidacionesAlEliminarMRSpartan_WorkFlow_Information_by_State(nameOfTable, rowIndex) {
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Spartan_WorkFlow_Information_by_State//
    return result;
}
function EjecutarValidacionesNewRowMRSpartan_WorkFlow_Information_by_State(nameOfTable, rowIndex) {
    var result = true;




    //BusinessRuleId:1441, Attribute:163626, Operation:Object, Event:NEWROWMR
    if (operation == 'New') {
        var valor = $('#' + nameOfTable + 'Folder' + rowIndex).val(); $('#' + nameOfTable + 'Folder' + rowIndex).empty(); if (!$('#' + nameOfTable + 'Folder' + rowIndex).hasClass('AutoComplete')) { $('#' + nameOfTable + 'Folder' + rowIndex).append($("<option selected />").val("").text("")); $.each(EvaluaQueryDictionary("Select max(attributeid),Group_Name from spartan_metadata where object_id=" + $('#Object').val() + " group by group_name order by group_name", rowIndex, nameOfTable), function (index, value) { $('#' + nameOfTable + 'Folder' + rowIndex).append($("<option />").val(index).text(value)); }); } else { $('#' + nameOfTable + 'Folder' + rowIndex).select2('destroy').empty(); var selectData = []; selectData.push({ id: "", text: "" }); $.each(EvaluaQueryDictionary("Select max(attributeid),Group_Name from spartan_metadata where object_id=" + $('#Object').val() + " group by group_name order by group_name", rowIndex, nameOfTable), function (index, value) { selectData.push({ id: index, text: value }); }); $('#' + nameOfTable + 'Folder' + rowIndex).select2({ data: selectData }) } $('#' + nameOfTable + 'Folder' + rowIndex).val(valor);


    }
    //BusinessRuleId:1441, Attribute:163626, Operation:Object, Event:NEWROWMR

    //BusinessRuleId:1441, Attribute:163626, Operation:Object, Event:NEWROWMR
    if (operation == 'Update') {
        debugger;
        var valor = $('#' + nameOfTable + 'Folder' + rowIndex).val(); $('#' + nameOfTable + 'Folder' + rowIndex).empty(); if (!$('#' + nameOfTable + 'Folder' + rowIndex).hasClass('AutoComplete')) { $('#' + nameOfTable + 'Folder' + rowIndex).append($("<option selected />").val("").text("")); $.each(EvaluaQueryDictionary("Select max(attributeid),Group_Name from spartan_metadata where object_id=" + $('#Object').val() + " group by group_name order by group_name", rowIndex, nameOfTable), function (index, value) { $('#' + nameOfTable + 'Folder' + rowIndex).append($("<option />").val(index).text(value)); }); } else { $('#' + nameOfTable + 'Folder' + rowIndex).select2('destroy').empty(); var selectData = []; selectData.push({ id: "", text: "" }); $.each(EvaluaQueryDictionary("Select max(attributeid),Group_Name from spartan_metadata where object_id=" + $('#Object').val() + " group by group_name order by group_name", rowIndex, nameOfTable), function (index, value) { selectData.push({ id: index, text: value }); }); $('#' + nameOfTable + 'Folder' + rowIndex).select2({ data: selectData }) } $('#' + nameOfTable + 'Folder' + rowIndex).val(valor);


    }
    //BusinessRuleId:1441, Attribute:163626, Operation:Object, Event:NEWROWMR

    //BusinessRuleId:1436, Attribute:163626, Operation:Object, Event:NEWROWMR
    if (operation == 'New') {
        var valor = $('#' + nameOfTable + 'Phase' + rowIndex).val(); $('#' + nameOfTable + 'Phase' + rowIndex).empty(); if (!$('#' + nameOfTable + 'Phase' + rowIndex).hasClass('AutoComplete')) {
            $('#' + nameOfTable + 'Phase' + rowIndex).append($("<option selected />").val("").text("")); $.each(EvaluaQueryDictionary("select PhasesId, Name from Spartan_WorkFlow_Phases"
           + " "
           + "  where Workflow = GLOBAL[workid]", rowIndex, nameOfTable), function (index, value) { $('#' + nameOfTable + 'Phase' + rowIndex).append($("<option />").val(index).text(value)); });
        } else {
            $('#' + nameOfTable + 'Phase' + rowIndex).select2('destroy').empty(); var selectData = []; selectData.push({ id: "", text: "" }); $.each(EvaluaQueryDictionary("select PhasesId, Name from Spartan_WorkFlow_Phases"
            + " "
            + "  where Workflow = GLOBAL[workid]", rowIndex, nameOfTable), function (index, value) { selectData.push({ id: index, text: value }); }); $('#' + nameOfTable + 'Phase' + rowIndex).select2({ data: selectData })
        } $('#' + nameOfTable + 'Phase' + rowIndex).val(valor);


    }
    //BusinessRuleId:1436, Attribute:163626, Operation:Object, Event:NEWROWMR

    //BusinessRuleId:1436, Attribute:163626, Operation:Object, Event:NEWROWMR
    if (operation == 'Update') {
        var valor = $('#' + nameOfTable + 'Phase' + rowIndex).val(); $('#' + nameOfTable + 'Phase' + rowIndex).empty(); if (!$('#' + nameOfTable + 'Phase' + rowIndex).hasClass('AutoComplete')) {
            $('#' + nameOfTable + 'Phase' + rowIndex).append($("<option selected />").val("").text("")); $.each(EvaluaQueryDictionary("select PhasesId, Name from Spartan_WorkFlow_Phases"
           + " "
           + "  where Workflow = GLOBAL[workid]", rowIndex, nameOfTable), function (index, value) { $('#' + nameOfTable + 'Phase' + rowIndex).append($("<option />").val(index).text(value)); });
        } else {
            $('#' + nameOfTable + 'Phase' + rowIndex).select2('destroy').empty(); var selectData = []; selectData.push({ id: "", text: "" }); $.each(EvaluaQueryDictionary("select PhasesId, Name from Spartan_WorkFlow_Phases"
            + " "
            + "  where Workflow = GLOBAL[workid]", rowIndex, nameOfTable), function (index, value) { selectData.push({ id: index, text: value }); }); $('#' + nameOfTable + 'Phase' + rowIndex).select2({ data: selectData })
        } $('#' + nameOfTable + 'Phase' + rowIndex).val(valor);


    }
    //BusinessRuleId:1436, Attribute:163626, Operation:Object, Event:NEWROWMR
    if ($('#' + nameOfTable + 'Phase' + rowIndex).val() == '') {
        $('#' + nameOfTable + 'State' + rowIndex).empty();
    }
    else {
        var valor = $('#' + nameOfTable + 'Phase' + rowIndex).val();
        var valorState = $('#' + nameOfTable + 'State' + rowIndex).val();
        $('#' + nameOfTable + 'State' + rowIndex).empty();
        $('#' + nameOfTable + 'State' + rowIndex).append($("<option selected />").val("").text(""));
        $.each(EvaluaQueryDictionary("select StateId, Name from Spartan_WorkFlow_State"
           + " "
           + "  where Phase = " + valor, rowIndex, nameOfTable), function (index, value) {
               $('#' + nameOfTable + 'State' + rowIndex).append($("<option />").val(index).text(value));
           });
        $('#' + nameOfTable + 'State' + rowIndex).val(valorState);
    }

    $('#' + nameOfTable + 'Phase' + rowIndex).change(function () {
        var valor = $('#' + nameOfTable + 'Phase' + rowIndex).val();
        var valorState = $('#' + nameOfTable + 'State' + rowIndex).val();
        $('#' + nameOfTable + 'State' + rowIndex).empty();
        $('#' + nameOfTable + 'State' + rowIndex).append($("<option selected />").val("").text(""));
        $.each(EvaluaQueryDictionary("select StateId, Name from Spartan_WorkFlow_State"
           + " "
           + "  where Phase = " + valor, rowIndex, nameOfTable), function (index, value) {
               $('#' + nameOfTable + 'State' + rowIndex).append($("<option />").val(index).text(value));
           });
        $('#' + nameOfTable + 'State' + rowIndex).val(valorState);
    });
    //NEWBUSINESSRULE_NEWROWMR_Spartan_WorkFlow_Information_by_State//
    return result;
}
function EjecutarValidacionesAntesDeGuardarMRSpartan_WorkFlow_Roles_by_State(nameOfTable, rowIndex) {
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Spartan_WorkFlow_Roles_by_State//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRSpartan_WorkFlow_Roles_by_State(nameOfTable, rowIndex) {
    //NEWBUSINESSRULE_AFTERSAVINGMR_Spartan_WorkFlow_Roles_by_State//
}
function EjecutarValidacionesAlEliminarMRSpartan_WorkFlow_Roles_by_State(nameOfTable, rowIndex) {
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Spartan_WorkFlow_Roles_by_State//
    return result;
}
function EjecutarValidacionesEditRowMRSpartan_WorkFlow_Roles_by_State(nameOfTable, rowIndex) {
    var result = true;
    return result;
}
function EjecutarValidacionesNewRowMRSpartan_WorkFlow_Roles_by_State(nameOfTable, rowIndex) {
    var result = true;


    //BusinessRuleId:1437, Attribute:163687, Operation:Object, Event:NEWROWMR
    if (operation == 'New') {
        var valor = $('#' + nameOfTable + 'Phase' + rowIndex).val(); $('#' + nameOfTable + 'Phase' + rowIndex).empty(); if (!$('#' + nameOfTable + 'Phase' + rowIndex).hasClass('AutoComplete')) {
            $('#' + nameOfTable + 'Phase' + rowIndex).append($("<option selected />").val("").text("")); $.each(EvaluaQueryDictionary("select PhasesId, Name from Spartan_WorkFlow_Phases"
           + " "
           + "  where Workflow = GLOBAL[workid]", rowIndex, nameOfTable), function (index, value) { $('#' + nameOfTable + 'Phase' + rowIndex).append($("<option />").val(index).text(value)); });
        } else {
            $('#' + nameOfTable + 'Phase' + rowIndex).select2('destroy').empty(); var selectData = []; selectData.push({ id: "", text: "" }); $.each(EvaluaQueryDictionary("select PhasesId, Name from Spartan_WorkFlow_Phases"
            + " "
            + "  where Workflow = GLOBAL[workid]", rowIndex, nameOfTable), function (index, value) { selectData.push({ id: index, text: value }); }); $('#' + nameOfTable + 'Phase' + rowIndex).select2({ data: selectData })
        } $('#' + nameOfTable + 'Phase' + rowIndex).val(valor);


    }
    //BusinessRuleId:1437, Attribute:163687, Operation:Object, Event:NEWROWMR

    //BusinessRuleId:1437, Attribute:163687, Operation:Object, Event:NEWROWMR
    if (operation == 'Update') {
        var valor = $('#' + nameOfTable + 'Phase' + rowIndex).val(); $('#' + nameOfTable + 'Phase' + rowIndex).empty(); if (!$('#' + nameOfTable + 'Phase' + rowIndex).hasClass('AutoComplete')) {
            $('#' + nameOfTable + 'Phase' + rowIndex).append($("<option selected />").val("").text("")); $.each(EvaluaQueryDictionary("select PhasesId, Name from Spartan_WorkFlow_Phases"
           + " "
           + "  where Workflow = GLOBAL[workid]", rowIndex, nameOfTable), function (index, value) { $('#' + nameOfTable + 'Phase' + rowIndex).append($("<option />").val(index).text(value)); });
        } else {
            $('#' + nameOfTable + 'Phase' + rowIndex).select2('destroy').empty(); var selectData = []; selectData.push({ id: "", text: "" }); $.each(EvaluaQueryDictionary("select PhasesId, Name from Spartan_WorkFlow_Phases"
            + " "
            + "  where Workflow = GLOBAL[workid]", rowIndex, nameOfTable), function (index, value) { selectData.push({ id: index, text: value }); }); $('#' + nameOfTable + 'Phase' + rowIndex).select2({ data: selectData })
        } $('#' + nameOfTable + 'Phase' + rowIndex).val(valor);


    }
    //BusinessRuleId:1437, Attribute:163687, Operation:Object, Event:NEWROWMR
    if ($('#' + nameOfTable + 'Phase' + rowIndex).val() == '') {
        $('#' + nameOfTable + 'State' + rowIndex).empty();
    }
    else {
        var valor = $('#' + nameOfTable + 'Phase' + rowIndex).val();
        var valorState = $('#' + nameOfTable + 'State' + rowIndex).val();
        $('#' + nameOfTable + 'State' + rowIndex).empty();
        $('#' + nameOfTable + 'State' + rowIndex).append($("<option selected />").val("").text(""));
        $.each(EvaluaQueryDictionary("select StateId, Name from Spartan_WorkFlow_State"
           + " "
           + "  where Phase = " + valor, rowIndex, nameOfTable), function (index, value) {
               $('#' + nameOfTable + 'State' + rowIndex).append($("<option />").val(index).text(value));
           });
        $('#' + nameOfTable + 'State' + rowIndex).val(valorState);
    }

    $('#' + nameOfTable + 'Phase' + rowIndex).change(function () {
        var valor = $('#' + nameOfTable + 'Phase' + rowIndex).val();
        var valorState = $('#' + nameOfTable + 'State' + rowIndex).val();
        $('#' + nameOfTable + 'State' + rowIndex).empty();
        $('#' + nameOfTable + 'State' + rowIndex).append($("<option selected />").val("").text(""));
        $.each(EvaluaQueryDictionary("select StateId, Name from Spartan_WorkFlow_State"
           + " "
           + "  where Phase = " + valor, rowIndex, nameOfTable), function (index, value) {
               $('#' + nameOfTable + 'State' + rowIndex).append($("<option />").val(index).text(value));
           });
        $('#' + nameOfTable + 'State' + rowIndex).val(valorState);
    });
    //NEWBUSINESSRULE_NEWROWMR_Spartan_WorkFlow_Roles_by_State//
    return result;
}
function EjecutarValidacionesAntesDeGuardarMRSpartan_WorkFlow_Matrix_of_States(nameOfTable, rowIndex) {
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Spartan_WorkFlow_Matrix_of_States//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRSpartan_WorkFlow_Matrix_of_States(nameOfTable, rowIndex) {
    //NEWBUSINESSRULE_AFTERSAVINGMR_Spartan_WorkFlow_Matrix_of_States//
}
function EjecutarValidacionesAlEliminarMRSpartan_WorkFlow_Matrix_of_States(nameOfTable, rowIndex) {
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Spartan_WorkFlow_Matrix_of_States//
    return result;
}
function EjecutarValidacionesNewRowMRSpartan_WorkFlow_Matrix_of_States(nameOfTable, rowIndex) {
    var result = true;


    //BusinessRuleId:1440, Attribute:163700, Operation:Object, Event:NEWROWMR
    if (operation == 'New') {
        var valor = $('#' + nameOfTable + 'Attribute' + rowIndex).val(); $('#' + nameOfTable + 'Attribute' + rowIndex).empty(); if (!$('#' + nameOfTable + 'Attribute' + rowIndex).hasClass('AutoComplete')) {
            $('#' + nameOfTable + 'Attribute' + rowIndex).append($("<option selected />").val("").text("")); $.each(EvaluaQueryDictionary("select AttributeId, Physical_Name from Spartan_Metadata"
           + " "
           + "  where Object_Id = FLDP[Object]", rowIndex, nameOfTable), function (index, value) { $('#' + nameOfTable + 'Attribute' + rowIndex).append($("<option />").val(index).text(value)); });
        } else {
            $('#' + nameOfTable + 'Attribute' + rowIndex).select2('destroy').empty(); var selectData = []; selectData.push({ id: "", text: "" }); $.each(EvaluaQueryDictionary("select AttributeId, Physical_Name from Spartan_Metadata"
            + " "
            + "  where Object_Id = FLDP[Object]", rowIndex, nameOfTable), function (index, value) { selectData.push({ id: index, text: value }); }); $('#' + nameOfTable + 'Attribute' + rowIndex).select2({ data: selectData })
        } $('#' + nameOfTable + 'Attribute' + rowIndex).val(valor);


    }
    //BusinessRuleId:1440, Attribute:163700, Operation:Object, Event:NEWROWMR

    //BusinessRuleId:1440, Attribute:163700, Operation:Object, Event:NEWROWMR
    if (operation == 'Update') {
        var valor = $('#' + nameOfTable + 'Attribute' + rowIndex).val(); $('#' + nameOfTable + 'Attribute' + rowIndex).empty(); if (!$('#' + nameOfTable + 'Attribute' + rowIndex).hasClass('AutoComplete')) {
            $('#' + nameOfTable + 'Attribute' + rowIndex).append($("<option selected />").val("").text("")); $.each(EvaluaQueryDictionary("select AttributeId, Physical_Name from Spartan_Metadata"
           + " "
           + "  where Object_Id = FLDP[Object]", rowIndex, nameOfTable), function (index, value) { $('#' + nameOfTable + 'Attribute' + rowIndex).append($("<option />").val(index).text(value)); });
        } else {
            $('#' + nameOfTable + 'Attribute' + rowIndex).select2('destroy').empty(); var selectData = []; selectData.push({ id: "", text: "" }); $.each(EvaluaQueryDictionary("select AttributeId, Physical_Name from Spartan_Metadata"
            + " "
            + "  where Object_Id = FLDP[Object]", rowIndex, nameOfTable), function (index, value) { selectData.push({ id: index, text: value }); }); $('#' + nameOfTable + 'Attribute' + rowIndex).select2({ data: selectData })
        } $('#' + nameOfTable + 'Attribute' + rowIndex).val(valor);


    }
    //BusinessRuleId:1440, Attribute:163700, Operation:Object, Event:NEWROWMR

    //BusinessRuleId:1438, Attribute:163700, Operation:Object, Event:NEWROWMR
    if (operation == 'New') {
        var valor = $('#' + nameOfTable + 'Phase' + rowIndex).val(); $('#' + nameOfTable + 'Phase' + rowIndex).empty(); if (!$('#' + nameOfTable + 'Phase' + rowIndex).hasClass('AutoComplete')) {
            $('#' + nameOfTable + 'Phase' + rowIndex).append($("<option selected />").val("").text("")); $.each(EvaluaQueryDictionary("select PhasesId, Name from Spartan_WorkFlow_Phases"
           + " "
           + "  where Workflow = GLOBAL[workid]", rowIndex, nameOfTable), function (index, value) { $('#' + nameOfTable + 'Phase' + rowIndex).append($("<option />").val(index).text(value)); });
        } else {
            $('#' + nameOfTable + 'Phase' + rowIndex).select2('destroy').empty(); var selectData = []; selectData.push({ id: "", text: "" }); $.each(EvaluaQueryDictionary("select PhasesId, Name from Spartan_WorkFlow_Phases"
            + " "
            + "  where Workflow = GLOBAL[workid]", rowIndex, nameOfTable), function (index, value) { selectData.push({ id: index, text: value }); }); $('#' + nameOfTable + 'Phase' + rowIndex).select2({ data: selectData })
        } $('#' + nameOfTable + 'Phase' + rowIndex).val(valor);


    }
    //BusinessRuleId:1438, Attribute:163700, Operation:Object, Event:NEWROWMR

    //BusinessRuleId:1438, Attribute:163700, Operation:Object, Event:NEWROWMR
    if (operation == 'Update') {
        var valor = $('#' + nameOfTable + 'Phase' + rowIndex).val(); $('#' + nameOfTable + 'Phase' + rowIndex).empty(); if (!$('#' + nameOfTable + 'Phase' + rowIndex).hasClass('AutoComplete')) {
            $('#' + nameOfTable + 'Phase' + rowIndex).append($("<option selected />").val("").text("")); $.each(EvaluaQueryDictionary("select PhasesId, Name from Spartan_WorkFlow_Phases"
           + " "
           + "  where Workflow = GLOBAL[workid]", rowIndex, nameOfTable), function (index, value) { $('#' + nameOfTable + 'Phase' + rowIndex).append($("<option />").val(index).text(value)); });
        } else {
            $('#' + nameOfTable + 'Phase' + rowIndex).select2('destroy').empty(); var selectData = []; selectData.push({ id: "", text: "" }); $.each(EvaluaQueryDictionary("select PhasesId, Name from Spartan_WorkFlow_Phases"
            + " "
            + "  where Workflow = GLOBAL[workid]", rowIndex, nameOfTable), function (index, value) { selectData.push({ id: index, text: value }); }); $('#' + nameOfTable + 'Phase' + rowIndex).select2({ data: selectData })
        } $('#' + nameOfTable + 'Phase' + rowIndex).val(valor);


    }
    //BusinessRuleId:1438, Attribute:163700, Operation:Object, Event:NEWROWMR

    //NEWBUSINESSRULE_NEWROWMR_Spartan_WorkFlow_Matrix_of_States//
    return result;
}


function EjecutarValidacionesEditRowMRSpartan_WorkFlow_State(nameOfTable, rowIndex) {
    var result = true;
    //NEWBUSINESSRULE_EDITROWMRSpartan_WorkFlow_State//
    return result;
}