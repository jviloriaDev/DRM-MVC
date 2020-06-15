var ConditionBusinessRuleTable;
var ActionBusinessRuleTable;
var ActionNotBusinessRuleTable;

var rowConditionId;
var rowActionId;
var rowActionNotId;

function getDropdown(elementKey, rowindex, rowAlternative) {
    if (rowindex == -1)
        rowindex = rowAlternative;
    var dropDown = '<select id="' + elementKey + '_' + rowindex + '" class="form-control ' + elementKey + '"><option value="">--Select--</option></select>';
    return dropDown;
}
function getDropdownAndTextbox(elementKey, rowindex, rowAlternative) {
    if (rowindex == -1)
        rowindex = rowAlternative;
    var dropDown = '<select style="display:none;" id="ddl' + elementKey + '_' + rowindex + '" class="form-control ' + elementKey + '"><option value="">--Select--</option></select>';
    var textbox = '<textarea style="display:none;" id="txt' + elementKey + '_' + rowindex + '"  class="form-control ' + elementKey + '" />';
    return dropDown + textbox;
}

var removedConditionData = [];
function DeleteRowCondition(rowIndex) {
    if (confirm("are you sure you want to delete")) {
        var prevData = ConditionBusinessRuleTable.fnGetData(rowIndex);
        removedConditionData.push(prevData);
        ConditionBusinessRuleTable.fnDeleteRow(rowIndex);
    }
}
var removedActionData = [];
function DeleteRowAction(rowIndex) {
    if (confirm("are you sure you want to delete")) {
        var prevData = ActionBusinessRuleTable.fnGetData(rowIndex);
        removedActionData.push(prevData);
        ActionBusinessRuleTable.fnDeleteRow(rowIndex);
    }
}
var removedActionNotData = [];
function DeleteRowActionNot(rowIndex) {
    if (confirm("are you sure you want to delete")) {
        var prevData = ActionNotBusinessRuleTable.fnGetData(rowIndex);
        removedActionNotData.push(prevData);
        ActionNotBusinessRuleTable.fnDeleteRow(rowIndex);
    }
}

function SaveRowAction(rowIndex) {
    var prevData = ActionBusinessRuleTable.fnGetData(rowIndex);
    var data = ActionBusinessRuleTable.fnGetNodes(rowIndex);
    var newData = {
        IsInsertRow: false,
        ActionTrueDetailId: prevData.ActionTrueDetailId,
        ActionClassification: data.childNodes[1].childNodes[0].value,
        Action: data.childNodes[2].childNodes[0].value,
        ActionResult: data.childNodes[3].childNodes[0].value,
        Parameter1: (data.childNodes[4].childNodes.length == 2) ? '' : ((data.childNodes[4].childNodes[1].value == '') ? data.childNodes[4].childNodes[2].value : $('#' + $(data.childNodes[4].childNodes[1])[0].id + ' option:selected').text()),
        Parameter2: (data.childNodes[5].childNodes.length == 2) ? '' : ((data.childNodes[5].childNodes[1].value == '') ? data.childNodes[5].childNodes[2].value : $('#' + $(data.childNodes[5].childNodes[1])[0].id + ' option:selected').text()),
        Parameter3: (data.childNodes[6].childNodes.length == 2) ? '' : ((data.childNodes[6].childNodes[1].value == '') ? data.childNodes[6].childNodes[2].value : $('#' + $(data.childNodes[6].childNodes[1])[0].id + ' option:selected').text()),
        Parameter4: (data.childNodes[7].childNodes.length == 2) ? '' : ((data.childNodes[7].childNodes[1].value == '') ? data.childNodes[7].childNodes[2].value : $('#' + $(data.childNodes[7].childNodes[1])[0].id + ' option:selected').text()),
        Parameter5: (data.childNodes[8].childNodes.length == 2) ? '' : ((data.childNodes[8].childNodes[1].value == '') ? data.childNodes[8].childNodes[2].value : $('#' + $(data.childNodes[8].childNodes[1])[0].id + ' option:selected').text()),
    }
    ActionBusinessRuleTable.fnUpdate(newData, rowIndex, null, true);
    ActionBusinessRuleTableCreationGrid(data, newData, rowIndex);
}
function SaveRowActionNot(rowIndex) {
    var prevData = ActionNotBusinessRuleTable.fnGetData(rowIndex);
    var data = ActionNotBusinessRuleTable.fnGetNodes(rowIndex);
    var newData = {
        IsInsertRow: false,
        ActionFalseDetailId: prevData.ActionFalseDetailId,
        ActionClassification: data.childNodes[1].childNodes[0].value,
        Action: data.childNodes[2].childNodes[0].value,
        ActionResult: data.childNodes[3].childNodes[0].value,
        Parameter1: (data.childNodes[4].childNodes.length == 2) ? '' : ((data.childNodes[4].childNodes[1].value == '') ? data.childNodes[4].childNodes[2].value : $('#' + $(data.childNodes[4].childNodes[1])[0].id + ' option:selected').text()),
        Parameter2: (data.childNodes[5].childNodes.length == 2) ? '' : ((data.childNodes[5].childNodes[1].value == '') ? data.childNodes[5].childNodes[2].value : $('#' + $(data.childNodes[5].childNodes[1])[0].id + ' option:selected').text()),
        Parameter3: (data.childNodes[6].childNodes.length == 2) ? '' : ((data.childNodes[6].childNodes[1].value == '') ? data.childNodes[6].childNodes[2].value : $('#' + $(data.childNodes[6].childNodes[1])[0].id + ' option:selected').text()),
        Parameter4: (data.childNodes[7].childNodes.length == 2) ? '' : ((data.childNodes[7].childNodes[1].value == '') ? data.childNodes[7].childNodes[2].value : $('#' + $(data.childNodes[7].childNodes[1])[0].id + ' option:selected').text()),
        Parameter5: (data.childNodes[8].childNodes.length == 2) ? '' : ((data.childNodes[8].childNodes[1].value == '') ? data.childNodes[8].childNodes[2].value : $('#' + $(data.childNodes[8].childNodes[1])[0].id + ' option:selected').text()),
    }
    ActionNotBusinessRuleTable.fnUpdate(newData, rowIndex, null, true);
    ActionNotBusinessRuleTableCreationGrid(data, newData, rowIndex);
}
function SaveRowCondition(rowIndex) {
    
    var prevData = ConditionBusinessRuleTable.fnGetData(rowIndex);
    var data = ConditionBusinessRuleTable.fnGetNodes(rowIndex);
    var newData = {
        IsInsertRow: false
        , ConditionDetailId: prevData.ConditionDetailId
        , Operator: data.childNodes[1].childNodes[0].value
        , OperatorType1: data.childNodes[2].childNodes[0].value
        , OperatorValue1: (data.childNodes[3].childNodes[0].value == '') ? data.childNodes[3].childNodes[1].value : $('#' + $(data.childNodes[3].childNodes[0])[0].id + ' option:selected').text()
        , Condition: data.childNodes[4].childNodes[0].value
        , OperatorType2: data.childNodes[5].childNodes[0].value
        , OperatorValue2: (data.childNodes[6].childNodes[0].value == '') ? data.childNodes[6].childNodes[1].value : $('#' + $(data.childNodes[6].childNodes[0])[0].id + ' option:selected').text()
    }
    ConditionBusinessRuleTable.fnUpdate(newData, rowIndex, null, true);
    ConditionBusinessRuleTableCreationGrid(data, newData, rowIndex);
}

function ConditionEditRow(rowIndex) {
    var ConditionRowElement = "Condition_" + rowIndex.toString();
    var prevData = ConditionBusinessRuleTable.fnGetData(rowIndex);
    var row = ConditionBusinessRuleTable.fnGetNodes(rowIndex);
    row.innerHTML = "";

    var controls = GetInsertConditionRowControls(prevData, rowIndex);

    var abc = "SaveRowCondition(" + rowIndex + ");";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='DeleteRowCondition(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (var i = 0; i < controls.length; i++) {
        $(controls[i]).appendTo($('<td>').appendTo(row));
    }
    GetConditionOperator('Operator_' + rowIndex);
    GetConditions('Condition_' + rowIndex);
    GetOperatorTypes('OperatorType1_' + rowIndex);
    GetOperatorTypes('OperatorType2_' + rowIndex);
    $('#Operator_' + rowIndex).val(prevData.Operator);
    $('#OperatorType1_' + rowIndex).val(prevData.OperatorType1).change();
    if (prevData.OperatorType1 == 3) {
        $('#ddlOperatorValue1_' + rowIndex).val(prevData.OperatorValue1);
    }
    else {
        $('#txtOperatorValue1_' + rowIndex).val(prevData.OperatorValue1);
    }
    
    $('#Condition_' + rowIndex).val(prevData.Condition);
    $('#OperatorType2_' + rowIndex).val(prevData.OperatorType2).change();
    if (prevData.OperatorType2 == 3) {
        $('#ddlOperatorValue2_' + rowIndex).val(prevData.OperatorValue2);
    }
    else {
        $('#txtOperatorValue2_' + rowIndex).val(prevData.OperatorValue2);
    }
}
function ActionEditRow(rowIndex) {
    var ActionRowElement = "Action_" + rowIndex.toString();
    var prevData = ActionBusinessRuleTable.fnGetData(rowIndex);
    var row = ActionBusinessRuleTable.fnGetNodes(rowIndex);
    row.innerHTML = "";

    var controls = GetInsertActionRowControls(prevData, rowIndex);

    var abc = "SaveRowAction(" + rowIndex + ");";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='DeleteRowAction(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (var i = 0; i < controls.length; i++) {
        $(controls[i]).appendTo($('<td>').appendTo(row));
    }
    GetActionClassification('ActionClassificationTrue_' + rowIndex);
    GetActionResult('ActionResultTrue_' + rowIndex);
    $('#ActionClassificationTrue_' + rowIndex).val(prevData.ActionClassification).change();
    $('#ActionTrue_' + rowIndex).val(prevData.Action).change();
    $('#ActionResultTrue_' + rowIndex).val(prevData.ActionResult);
    $('#txtParameter1True_' + rowIndex).val(prevData.Parameter1);
    $('#txtParameter2True_' + rowIndex).val(prevData.Parameter2);
    $('#txtParameter3True_' + rowIndex).val(prevData.Parameter3);
    $('#txtParameter4True_' + rowIndex).val(prevData.Parameter4);
    $('#txtParameter5True_' + rowIndex).val(prevData.Parameter5);
    debugger;
    //$('#' + prevData.Parameter1 + ' option:selected').text()
    $('#ddlParameter1True_' + rowIndex).val(prevData.Parameter1);
    $('#ddlParameter2True_' + rowIndex).val(prevData.Parameter2);
    $('#ddlParameter3True_' + rowIndex).val(prevData.Parameter3);
    $('#ddlParameter4True_' + rowIndex).val(prevData.Parameter4);
    $('#ddlParameter5True_' + rowIndex).val(prevData.Parameter5);
}
function ActionNotEditRow(rowIndex) {
    var ActionNotRowElement = "ActionNot_" + rowIndex.toString();
    var prevData = ActionNotBusinessRuleTable.fnGetData(rowIndex);
    var row = ActionNotBusinessRuleTable.fnGetNodes(rowIndex);
    row.innerHTML = "";

    var controls = GetInsertActionNotRowControls(prevData, rowIndex);

    var abc = "SaveRowActionNot(" + rowIndex + ");";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='DeleteRowActionNot(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (var i = 0; i < controls.length; i++) {
        $(controls[i]).appendTo($('<td>').appendTo(row));
    }
    GetActionClassification('ActionClassificationFalse_' + rowIndex);
    GetActionResult('ActionResultFalse_' + rowIndex)
    $('#ActionClassificationFalse_' + rowIndex).val(prevData.ActionClassification).change();
    $('#ActionFalse_' + rowIndex).val(prevData.Action).change();
    $('#ActionResultFalse_' + rowIndex).val(prevData.ActionResult);
    $('#txtParameter1False_' + rowIndex).val(prevData.Parameter1);
    $('#txtParameter2False_' + rowIndex).val(prevData.Parameter2);
    $('#txtParameter3False_' + rowIndex).val(prevData.Parameter3);
    $('#txtParameter4False_' + rowIndex).val(prevData.Parameter4);
    $('#txtParameter5False_' + rowIndex).val(prevData.Parameter5);
    $('#ddlParameter1False_' + rowIndex).val(prevData.Parameter1);
    $('#ddlParameter2False_' + rowIndex).val(prevData.Parameter2);
    $('#ddlParameter3False_' + rowIndex).val(prevData.Parameter3);
    $('#ddlParameter4False_' + rowIndex).val(prevData.Parameter4);
    $('#ddlParameter5False_' + rowIndex).val(prevData.Parameter5);
}

function ConditionfnClickAddRow() {
    ConditionBusinessRuleTable
        .fnAddData(ConditionAddInsertRow(), true);
    GetConditionOperator('Operator_' + rowConditionId);
    GetConditions('Condition_' + rowConditionId);
    GetOperatorTypes('OperatorType1_' + rowConditionId);
    GetOperatorTypes('OperatorType2_' + rowConditionId);
    rowConditionId+= 1;
}
function ActionfnClickAddRow() {
    ActionBusinessRuleTable
        .fnAddData(ActionAddInsertRow(), true);
    GetActionClassification('ActionClassificationTrue_' + rowActionId);
    GetActionResult('ActionResultTrue_' + rowActionId);
    rowActionId += 1;
}
function ActionNotfnClickAddRow() {
    ActionNotBusinessRuleTable
        .fnAddData(ActionNotAddInsertRow(), true);
    GetActionClassification('ActionClassificationFalse_' + rowActionNotId);
    GetActionResult('ActionResultFalse_' + rowActionNotId);
    rowActionNotId += 1;
}

function ConditionAddInsertRow() {
    if (rowConditionId == undefined || rowConditionId < 0) {
        rowConditionId = 0;
    }
    return {
        IsInsertRow: true
        ,ConditionDetailId: 0
        , Operator: ""
        , OperatorType1: ""
        , OperatorValue1: ""
        , Condition: ""
        , OperatorType2: ""
        , OperatorValue2: ""
    }
}
function ActionAddInsertRow() {
    if (rowActionId == undefined || rowActionId < 0) {
        rowActionId = 0;
    }
    return {
        IsInsertRow: true
        ,ActionTrueDetailId: 0
        ,ActionClassification: ""
        ,Action: ""
        ,ActionResult: ""
        ,Parameter1: ""
        ,Parameter2: ""
        ,Parameter3: ""
        ,Parameter4: ""
        ,Parameter5: ""
    }
}
function ActionNotAddInsertRow() {
    if (rowActionNotId == undefined || rowActionNotId < 0) {
        rowActionNotId = 0;
    }
    return {
        IsInsertRow: true
        , ActionFalseDetailId: 0
        , ActionClassification: ""
        , Action: ""
        , ActionResult: ""
        , Parameter1: ""
        , Parameter2: ""
        , Parameter3: ""
        , Parameter4: ""
        , Parameter5: ""
    }
}

$('#tblConditionBusinessRule').on('change', '.OperatorType1', function () {
    var control = $(this);
    var idOperatorType = control[0].id;
    var idtxtOperatorValue = 'txt' + idOperatorType.replace('Type', 'Value');
    var idddlOperatorValue = 'ddl' + idOperatorType.replace('Type', 'Value');
    GetOperatorType(control.val(), idtxtOperatorValue, idddlOperatorValue);
});
$('#tblConditionBusinessRule').on('change', '.OperatorType2', function () {
    var control = $(this);
    var idOperatorType = control[0].id;
    var idtxtOperatorValue = 'txt' + idOperatorType.replace('Type', 'Value');
    var idddlOperatorValue = 'ddl' + idOperatorType.replace('Type', 'Value');
    GetOperatorType(control.val(), idtxtOperatorValue, idddlOperatorValue);
});
$('#tblActionBusinessRule').on('change', '.ActionClassificationTrue', function () {
    var control = $(this);
    var idActionClassification = control[0].id;
    var idDllAction = idActionClassification.replace('ActionClassificationTrue', 'ActionTrue');
    GetActionsByClassification(control.val(), idDllAction);
});
$('#tblActionNotBusinessRule').on('change', '.ActionClassificationFalse', function () {
    var control = $(this);
    var idActionClassification = control[0].id;
    var idDllAction = idActionClassification.replace('ActionClassificationFalse', 'ActionFalse');
    GetActionsByClassification(control.val(), idDllAction);
});
$('#tblActionBusinessRule').on('change', '.ActionTrue', function () {
    var control = $(this);
    var idAction = control[0].id;
    var idParameterGeneric = idAction.replace('Action', 'Parameter[NUMBER]');
    var idParameter1 = idAction.replace('Action', 'Parameter1');
    var idParameter2 = idAction.replace('Action', 'Parameter2');
    var idParameter3 = idAction.replace('Action', 'Parameter3');
    var idParameter4 = idAction.replace('Action', 'Parameter4');
    var idParameter5 = idAction.replace('Action', 'Parameter5');
    $('#ddl' + idParameter1).css('display', 'none');
    $('#ddl' + idParameter2).css('display', 'none');
    $('#ddl' + idParameter3).css('display', 'none');
    $('#ddl' + idParameter4).css('display', 'none');
    $('#ddl' + idParameter5).css('display', 'none');
    $('#txt' + idParameter1).css('display', 'none');
    $('#txt' + idParameter2).css('display', 'none');
    $('#txt' + idParameter3).css('display', 'none');
    $('#txt' + idParameter4).css('display', 'none');
    $('#txt' + idParameter5).css('display', 'none');
    if (control.val() != '') {
        GetParametersByActionId(control.val(), idParameterGeneric);
    }
});
$('#tblActionNotBusinessRule').on('change', '.ActionFalse', function () {
    var control = $(this);
    var idAction = control[0].id;
    var idParameterGeneric = idAction.replace('Action', 'Parameter[NUMBER]');
    var idParameter1 = idAction.replace('Action', 'Parameter1');
    var idParameter2 = idAction.replace('Action', 'Parameter2');
    var idParameter3 = idAction.replace('Action', 'Parameter3');
    var idParameter4 = idAction.replace('Action', 'Parameter4');
    var idParameter5 = idAction.replace('Action', 'Parameter5');
    $('#ddl' + idParameter1).css('display', 'none');
    $('#ddl' + idParameter2).css('display', 'none');
    $('#ddl' + idParameter3).css('display', 'none');
    $('#ddl' + idParameter4).css('display', 'none');
    $('#ddl' + idParameter5).css('display', 'none');
    $('#txt' + idParameter1).css('display', 'none');
    $('#txt' + idParameter2).css('display', 'none');
    $('#txt' + idParameter3).css('display', 'none');
    $('#txt' + idParameter4).css('display', 'none');
    $('#txt' + idParameter5).css('display', 'none');
    if (control.val() != '') {
        GetParametersByActionId(control.val(), idParameterGeneric);
    }
});
$('#Scopes').change(function (item) {
    if ($('#hdnFieldId').val() != "") {
        var idObject = 0;
        var selected = $(this).val();
        $.each(ScopesItems, function (index, item) {
            if (item.Description == 'Object')
                idObject = item.ScopeId;
        });
        var found = $.inArray(idObject.toString(), selected) > -1;
        if (found) {
            $('#divOperations').css('display', 'block');
            $('#divEvents').css('display', 'block');
        }
        else {
            $('#divOperations').css('display', 'none');
            $('#divEvents').css('display', 'none');
        }
    }
});

function ConditionBusinessRuleTableCreationGrid(row, data, index) {
    
    var ConditionTableRowElement = "Condition_" + index.toString();
    $(row).addClass(ConditionTableRowElement);

    row.innerHTML = "";

    if (data.IsInsertRow) {

        if (row.childNodes.length != 0) {
            for (var i = 0; i < row.childNodes.length; i++) {
                row.childNodes[i].remove();
            }
        }
        var controls = GetInsertConditionRowControls(null, -1);

        var actionColInsert = $('<td>');

        var abc = " SaveRowCondition(" + index + ");";
        var insertRowHTML = '<a  onclick="' + abc + '">';
        $('<i class="fa fa-check">').appendTo($(insertRowHTML).appendTo(actionColInsert));
        $('<i class="fa fa-times">').appendTo($("<a  onclick='DeleteRowCondition(" + index + ")'>").appendTo(actionColInsert));
        actionColInsert.appendTo(row);

        for (i = 0; i < controls.length; i++) {
            $(controls[i]).appendTo($('<td>').appendTo(row));
        }
        return;
    }

    var actionCol = $('<td>');
    $('<i class="fa fa-pencil">').appendTo($("<a title='Edit' class='' onclick='ConditionEditRow(" + index + ")'>").appendTo(actionCol));
    $('<i class="fa fa-trash-o">').appendTo($("<a title='Delete' class='' onclick='DeleteRowCondition(" + index + ")'>").appendTo(actionCol));
    actionCol.appendTo(row);
    
    GetOperatorTypes(null);
    GetConditionOperator(null);
    GetConditions(null);
    $('<td>').text(findConditionOperatorText(data.Operator)).appendTo(row);
    $('<td>').text(findOperatorTypeText(data.OperatorType1)).appendTo(row);
    GetOperatorType(data.OperatorType1, null, null);
    $('<td>').text(findOperatorValueText(data.OperatorValue1)).appendTo(row);
    $('<td>').text(findConditionsText(data.Condition)).appendTo(row);
    $('<td>').text(findOperatorTypeText(data.OperatorType2)).appendTo(row);
    GetOperatorType(data.OperatorType2, null, null);
    $('<td>').text(findOperatorValueText(data.OperatorValue2)).appendTo(row);
}
function ActionBusinessRuleTableCreationGrid(row, data, index) {
    var ActionTableRowElement = "Action_" + index.toString();
    $(row).addClass(ActionTableRowElement);

    row.innerHTML = "";

    if (data.IsInsertRow) {

        if (row.childNodes.length != 0) {
            for (var i = 0; i < row.childNodes.length; i++) {
                row.childNodes[i].remove();
            }
        }
        var controls = GetInsertActionRowControls(null, -1);

        var actionColInsert = $('<td>');

        var abc = " SaveRowAction(" + index + ");";
        var insertRowHTML = '<a  onclick="' + abc + '">';
        $('<i class="fa fa-check">').appendTo($(insertRowHTML).appendTo(actionColInsert));
        $('<i class="fa fa-times">').appendTo($("<a  onclick='DeleteRowAction(" + index + ")'>").appendTo(actionColInsert));
        actionColInsert.appendTo(row);

        for (i = 0; i < controls.length; i++) {
            $(controls[i]).appendTo($('<td>').appendTo(row));
        }
        return;
    }

    var actionCol = $('<td>');
    $('<i class="fa fa-pencil">').appendTo($("<a title='Edit' class='' onclick='ActionEditRow(" + index + ")'>").appendTo(actionCol));
    $('<i class="fa fa-trash-o">').appendTo($("<a title='Delete' class='' onclick='DeleteRowAction(" + index + ")'>").appendTo(actionCol));
    actionCol.appendTo(row);

    GetActionsByClassification(data.ActionClassification, null);
    GetActionResult(null);
    GetActionClassification(null);

    $('<td>').text(findActionClassificationText(data.ActionClassification)).appendTo(row);
    $('<td>').text(findActionText(data.Action)).appendTo(row);
    $('<td>').text(findActionResultText(data.ActionResult)).appendTo(row);
    GetParametersByActionId(data.Action, null);
    $('<td>').text(findParameterTextByAction(data.Parameter1, 0)).appendTo(row);
    $('<td>').text(findParameterTextByAction(data.Parameter2, 1)).appendTo(row);
    $('<td>').text(findParameterTextByAction(data.Parameter3, 2)).appendTo(row);
    $('<td>').text(findParameterTextByAction(data.Parameter4, 3)).appendTo(row);
    $('<td>').text(findParameterTextByAction(data.Parameter5, 4)).appendTo(row);
}
function ActionNotBusinessRuleTableCreationGrid(row, data, index) {
    var ActionNotTableRowElement = "ActionNot_" + index.toString();
    $(row).addClass(ActionNotTableRowElement);

    row.innerHTML = "";

    if (data.IsInsertRow) {

        if (row.childNodes.length != 0) {
            for (var i = 0; i < row.childNodes.length; i++) {
                row.childNodes[i].remove();
            }
        }
        var controls = GetInsertActionNotRowControls(null, -1);

        var actionColInsert = $('<td>');

        var abc = " SaveRowActionNot(" + index + ");";
        var insertRowHTML = '<a  onclick="' + abc + '">';
        $('<i class="fa fa-check">').appendTo($(insertRowHTML).appendTo(actionColInsert));
        $('<i class="fa fa-times">').appendTo($("<a  onclick='DeleteRowActionNot(" + index + ")'>").appendTo(actionColInsert));
        actionColInsert.appendTo(row);

        for (i = 0; i < controls.length; i++) {
            $(controls[i]).appendTo($('<td>').appendTo(row));
        }
        return;
    }

    var actionCol = $('<td>');
    $('<i class="fa fa-pencil">').appendTo($("<a title='Edit' class='' onclick='ActionNotEditRow(" + index + ")'>").appendTo(actionCol));
    $('<i class="fa fa-trash-o">').appendTo($("<a title='Delete' class='' onclick='DeleteRowActionNot(" + index + ")'>").appendTo(actionCol));
    actionCol.appendTo(row);

    GetActionsByClassification(data.ActionClassification, null);
    GetActionResult(null);
    GetActionClassification(null);

    $('<td>').text(findActionClassificationText(data.ActionClassification)).appendTo(row);
    $('<td>').text(findActionText(data.Action)).appendTo(row);
    $('<td>').text(findActionResultText(data.ActionResult)).appendTo(row);
    GetParametersByActionId(data.Action, null);
    $('<td>').text(findParameterTextByAction(data.Parameter1, 0)).appendTo(row);
    $('<td>').text(findParameterTextByAction(data.Parameter2, 1)).appendTo(row);
    $('<td>').text(findParameterTextByAction(data.Parameter3, 2)).appendTo(row);
    $('<td>').text(findParameterTextByAction(data.Parameter4, 3)).appendTo(row);
    $('<td>').text(findParameterTextByAction(data.Parameter5, 4)).appendTo(row);
}

function GetInsertConditionRowControls(data, rowIndex) {
    
    var columnData = [];    
    var ddlOperator = $(getDropdown('Operator', rowIndex, rowConditionId));
    var ddlOperatorType1 = $(getDropdown('OperatorType1', rowIndex, rowConditionId));
    var ddlOperatorValue1 = $(getDropdownAndTextbox('OperatorValue1', rowIndex, rowConditionId));
    var ddlCondition = $(getDropdown('Condition', rowIndex, rowConditionId));
    var ddlOperatorType2 = $(getDropdown('OperatorType2', rowIndex, rowConditionId));
    var ddlOperatorValue2 = $(getDropdownAndTextbox('OperatorValue2', rowIndex, rowConditionId));
    GetConditionOperator(ddlOperator[0].id);
    GetConditions(ddlCondition[0].id);
    GetOperatorTypes(ddlOperatorType1[0].id);
    GetOperatorTypes(ddlOperatorType2[0].id);
    columnData[0] = ddlOperator;
    columnData[1] = ddlOperatorType1;
    columnData[2] = ddlOperatorValue1;
    columnData[3] = ddlCondition;
    columnData[4] = ddlOperatorType2;
    columnData[5] = ddlOperatorValue2;
    return columnData;
}
function GetInsertActionRowControls(data, rowIndex) {
    var columnData = [];
    var ddlActionClassification = $(getDropdown('ActionClassificationTrue', rowIndex, rowActionId));
    var ddlAction = $(getDropdown('ActionTrue', rowIndex, rowActionId));
    var ddlActionResult = $(getDropdown('ActionResultTrue', rowIndex, rowActionId));
    var inputParameter1 = $(getDropdownAndTextbox('Parameter1True', rowIndex, rowActionId));
    var inputParameter2 = $(getDropdownAndTextbox('Parameter2True', rowIndex, rowActionId));
    var inputParameter3 = $(getDropdownAndTextbox('Parameter3True', rowIndex, rowActionId));
    var inputParameter4 = $(getDropdownAndTextbox('Parameter4True', rowIndex, rowActionId));
    var inputParameter5 = $(getDropdownAndTextbox('Parameter5True', rowIndex, rowActionId));
    GetActionResult(ddlActionResult[0].id);
    GetActionClassification(ddlActionClassification[0].id);
    columnData[0] = ddlActionClassification;
    columnData[1] = ddlAction;
    columnData[2] = ddlActionResult;
    columnData[3] = inputParameter1;
    columnData[4] = inputParameter2;
    columnData[5] = inputParameter3;
    columnData[6] = inputParameter4;
    columnData[7] = inputParameter5;
    return columnData;
}
function GetInsertActionNotRowControls(data, rowIndex) {
    var columnData = [];
    var ddlActionClassification = $(getDropdown('ActionClassificationFalse', rowIndex, rowActionNotId));
    var ddlAction = $(getDropdown('ActionFalse', rowIndex, rowActionNotId));
    var ddlActionResult = $(getDropdown('ActionResultFalse', rowIndex, rowActionNotId));
    var inputParameter1 = $(getDropdownAndTextbox('Parameter1False', rowIndex, rowActionNotId));
    var inputParameter2 = $(getDropdownAndTextbox('Parameter2False', rowIndex, rowActionNotId));
    var inputParameter3 = $(getDropdownAndTextbox('Parameter3False', rowIndex, rowActionNotId));
    var inputParameter4 = $(getDropdownAndTextbox('Parameter4False', rowIndex, rowActionNotId));
    var inputParameter5 = $(getDropdownAndTextbox('Parameter5False', rowIndex, rowActionNotId));
    GetActionResult(ddlActionResult[0].id);
    GetActionClassification(ddlActionClassification[0].id);
    columnData[0] = ddlActionClassification;
    columnData[1] = ddlAction;
    columnData[2] = ddlActionResult;
    columnData[3] = inputParameter1;
    columnData[4] = inputParameter2;
    columnData[5] = inputParameter3;
    columnData[6] = inputParameter4;
    columnData[7] = inputParameter5;
    return columnData;
}

function GetPrincipalData()
{
    var form_data = new FormData();
    var Name = $('#DescriptionRule').val();
    var BussinessRuleId = $('#hdnBussinessRuleId').val(); 
    var ObjectId = $('#hdnObjectId').val();
    var Attribute = $('#hdnAttribute').val();
    var Scopes = [];
    $('#Scopes option:selected').each(function (i, selected) {
        Scopes[i] = $(selected).val();
    });
    var Operations = [];
    $('#Operations option:selected').each(function (i, selected) {
        Operations[i] = $(selected).val();
    });
    var Events = [];
    $('#Events option:selected').each(function (i, selected) {
        Events[i] = $(selected).val();
    });

    form_data.append('Name', Name);
    form_data.append('Scopes', Scopes);
    form_data.append('Operations', Operations);
    form_data.append('Events', Events);
    form_data.append('BussinessRuleId', BussinessRuleId);
    form_data.append('ObjectId', ObjectId);
    form_data.append('Attribute', Attribute);
    return form_data;
}

function GetConditionsForSend() {
    var form_data = new FormData();
    for (var i = 0; i < ConditionsData.length; i++) {
        form_data.append('[' + i + '].ConditionDetailId', ConditionsData[i].ConditionDetailId);
        form_data.append('[' + i + '].Operator', ConditionsData[i].Operator);
        form_data.append('[' + i + '].OperatorType1', ConditionsData[i].OperatorType1);
        form_data.append('[' + i + '].OperatorValue1', ConditionsData[i].OperatorValue1);
        form_data.append('[' + i + '].Condition', ConditionsData[i].Condition);
        form_data.append('[' + i + '].OperatorType2', ConditionsData[i].OperatorType2);
        form_data.append('[' + i + '].OperatorValue2', ConditionsData[i].OperatorValue2);
        form_data.append('[' + i + '].Removed', ConditionsData[i].Removed);
    }
    return form_data;
}
function GetActionsForSend() {
    var form_data = new FormData();
    for (var i = 0; i < ActionsData.length; i++) {
        form_data.append('[' + i + '].ActionTrueDetailId', ActionsData[i].ActionTrueDetailId);
        form_data.append('[' + i + '].ActionClassification', ActionsData[i].ActionClassification);
        form_data.append('[' + i + '].Action', ActionsData[i].Action);
        form_data.append('[' + i + '].ActionResult', ActionsData[i].ActionResult);
        form_data.append('[' + i + '].Parameter1', ActionsData[i].Parameter1);
        form_data.append('[' + i + '].Parameter2', ActionsData[i].Parameter2);
        form_data.append('[' + i + '].Parameter3', ActionsData[i].Parameter3);
        form_data.append('[' + i + '].Parameter4', ActionsData[i].Parameter4);
        form_data.append('[' + i + '].Parameter5', ActionsData[i].Parameter5);
        form_data.append('[' + i + '].Removed', ActionsData[i].Removed);
    }
    return form_data;
}
function GetActionsNotForSend() {
    var form_data = new FormData();
    for (var i = 0; i < ActionsNotData.length; i++) {
        form_data.append('[' + i + '].ActionFalseDetailId', ActionsNotData[i].ActionFalseDetailId);
        form_data.append('[' + i + '].ActionClassification', ActionsNotData[i].ActionClassification);
        form_data.append('[' + i + '].Action', ActionsNotData[i].Action);
        form_data.append('[' + i + '].ActionResult', ActionsNotData[i].ActionResult);
        form_data.append('[' + i + '].Parameter1', ActionsNotData[i].Parameter1);
        form_data.append('[' + i + '].Parameter2', ActionsNotData[i].Parameter2);
        form_data.append('[' + i + '].Parameter3', ActionsNotData[i].Parameter3);
        form_data.append('[' + i + '].Parameter4', ActionsNotData[i].Parameter4);
        form_data.append('[' + i + '].Parameter5', ActionsNotData[i].Parameter5);
        form_data.append('[' + i + '].Removed', ActionsNotData[i].Removed);
    }
    return form_data;
}

function GetConditionsFromDataTable() {
    var ConditionsData = [];
    var gridData = ConditionBusinessRuleTable.fnGetData();
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            ConditionsData.push({
                ConditionDetailId: gridData[i].ConditionDetailId
                , Operator: gridData[i].Operator
                , OperatorType1: gridData[i].OperatorType1
                , OperatorValue1: gridData[i].OperatorValue1
                , Condition: gridData[i].Condition
                , OperatorType2: gridData[i].OperatorType2
                , OperatorValue2: gridData[i].OperatorValue2
                , Removed: false
            });
    }

    for (i = 0; i < removedConditionData.length; i++) {
        if (removedConditionData[i].ConditionDetailId > 0)
            ConditionsData.push({
                ConditionDetailId: removedConditionData[i].ConditionDetailId
                , Operator: removedConditionData[i].Operator
                , OperatorType1: removedConditionData[i].OperatorType1
                , OperatorValue1: removedConditionData[i].OperatorValue1
                , Condition: removedConditionData[i].Condition
                , OperatorType2: removedConditionData[i].OperatorType2
                , OperatorValue2: removedConditionData[i].OperatorValue2
                , Removed: true
            });
    }

    return ConditionsData;
}
function GetActionsFromDataTable() {
    var ActionsData = [];
    var gridData = ActionBusinessRuleTable.fnGetData();
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            ActionsData.push({
                ActionTrueDetailId: gridData[i].ActionTrueDetailId
                , ActionClassification: gridData[i].ActionClassification
                , Action: gridData[i].Action
                , ActionResult: gridData[i].ActionResult
                , Parameter1: gridData[i].Parameter1
                , Parameter2: gridData[i].Parameter2
                , Parameter3: gridData[i].Parameter3
                , Parameter4: gridData[i].Parameter4
                , Parameter5: gridData[i].Parameter5
                , Removed: false
            });
    }
    for (i = 0; i < removedActionData.length; i++) {
        if (removedActionData[i].ActionTrueDetailId > 0)
            ActionsData.push({
                ActionTrueDetailId: removedActionData[i].ActionTrueDetailId
                , ActionClassification: removedActionData[i].ActionClassification
                , Action: removedActionData[i].Action
                , ActionResult: removedActionData[i].ActionResult
                , Parameter1: removedActionData[i].Parameter1
                , Parameter2: removedActionData[i].Parameter2
                , Parameter3: removedActionData[i].Parameter3
                , Parameter4: removedActionData[i].Parameter4
                , Parameter5: removedActionData[i].Parameter5
                , Removed: true
            });
    }

    return ActionsData;
}
function GetActionsNotFromDataTable() {
    var ActionsNotData = [];
    var gridData = ActionNotBusinessRuleTable.fnGetData();
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            ActionsNotData.push({
                ActionFalseDetailId: gridData[i].ActionFalseDetailId
                , ActionClassification: gridData[i].ActionClassification
                , Action: gridData[i].Action
                , ActionResult: gridData[i].ActionResult
                , Parameter1: gridData[i].Parameter1
                , Parameter2: gridData[i].Parameter2
                , Parameter3: gridData[i].Parameter3
                , Parameter4: gridData[i].Parameter4
                , Parameter5: gridData[i].Parameter5
                , Removed: false
            });
    }

    for (i = 0; i < removedActionNotData.length; i++) {
        if (removedActionNotData[i].ActionFalseDetailId > 0)
            ActionsNotData.push({
                ActionFalseDetailId: removedActionNotData[i].ActionFalseDetailId
                , ActionClassification: removedActionNotData[i].ActionClassification
                , Action: removedActionNotData[i].Action
                , ActionResult: removedActionNotData[i].ActionResult
                , Parameter1: removedActionNotData[i].Parameter1
                , Parameter2: removedActionNotData[i].Parameter2
                , Parameter3: removedActionNotData[i].Parameter3
                , Parameter4: removedActionNotData[i].Parameter4
                , Parameter5: removedActionNotData[i].Parameter5
                , Removed: true
            });
    }

    return ActionsNotData;
}

function findParameterTextByAction(parameter, index) {
    var result = '';
    if (parameter != '') {
        $.each(ParametersByActionID, function (i, item) {
            if (i == index) {
                if (item.ControlType == 2) {
                    $.each(item.ControlDataCombobox, function (val, des) {
                        if (des == parameter) {
                            result = des;
                        }
                    });
                }
                else {
                    result = parameter;
                }
            }
        });
    }
    return result;
}

function findOperatorValueText(id) {
    var result = id;
    $.each(OperatorTypeItems, function (val, des) {
        if (val == id)
            result = des;
    });
    return result;
}

function findConditionOperatorText(id) {
    var result = '';
    $.each(ConditionOperatorItems, function (index, item) {
        if (item.ConditionOperatorId == id)
            result = item.Description;
    });
    return result;
}

function findOperatorTypeText(id) {
    var result = '';
    $.each(OperatorTypesItems, function (index, item) {
        if (item.OperatorTypeId == id)
            result = item.Description;
    });
    return result;
}

function findConditionsText(id) {
    var result = '';
    $.each(ConditionsItems, function (index, item) {
        if (item.ConditionId == id)
            result = item.Description;
    });
    return result;
}

function findActionText(id) {
    var result = '';
    $.each(ActionItems, function (index, item) {
        if (item.ActionId == id)
            result = item.Description;
    });
    return result;
}

function findActionResultText(id) {
    var result = '';
    $.each(ActionResultItems, function (index, item) {
        if (item.ActionResultId == id)
            result = item.Description;
    });
    return result;
}

function findActionClassificationText(id) {
    var result = '';
    $.each(ActionClassificationItems, function (index, item) {
        if (item.ClassificationId == id)
            result = item.Description;
    });
    return result;
}