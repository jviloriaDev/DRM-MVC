

//Begin Declarations for Foreigns fields for Spartan_BR_Scope_Detail MultiRow
var Spartan_BR_Scope_DetailcountRowsChecked = 0;
function GetSpartan_BR_Scope_Detail_Spartan_BR_ScopeName(Id) {
    for (var i = 0; i < Spartan_BR_Scope_Detail_Spartan_BR_ScopeItems.length; i++) {
        if (Spartan_BR_Scope_Detail_Spartan_BR_ScopeItems[i].ScopeId == Id) {
            return Spartan_BR_Scope_Detail_Spartan_BR_ScopeItems[i].Description;
        }
    }
    return "";
}

function GetSpartan_BR_Scope_Detail_Spartan_BR_ScopeDropDown() {
    var Spartan_BR_Scope_Detail_Spartan_BR_ScopeDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_BR_Scope_Detail_Spartan_BR_ScopeDropdown);

    for (var i = 0; i < Spartan_BR_Scope_Detail_Spartan_BR_ScopeItems.length; i++) {
        $('<option />', { value: Spartan_BR_Scope_Detail_Spartan_BR_ScopeItems[i].ScopeId, text: Spartan_BR_Scope_Detail_Spartan_BR_ScopeItems[i].Description }).appendTo(Spartan_BR_Scope_Detail_Spartan_BR_ScopeDropdown);
    }
    return Spartan_BR_Scope_Detail_Spartan_BR_ScopeDropdown;
}


function GetInsertSpartan_BR_Scope_DetailRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $(GetSpartan_BR_Scope_Detail_Spartan_BR_ScopeDropDown()).addClass('Spartan_BR_Scope_Detail_Scope').attr('id', 'Spartan_BR_Scope_Detail_Scope_' + index);


    initiateUIControls();
    return columnData;
}

function Spartan_BR_Scope_DetailInsertRow(rowIndex) {
    var prevData = Spartan_BR_Scope_DetailTable.fnGetData(rowIndex);
    var data = Spartan_BR_Scope_DetailTable.fnGetNodes(rowIndex);
    var newData = {
        ScopeDetailId: prevData.ScopeDetailId,
        IsInsertRow: false
        ,Scope: data.childNodes[1].childNodes[0].value

    }
    Spartan_BR_Scope_DetailTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_BR_Scope_DetailrowCreationGrid(data, newData, rowIndex);
    Spartan_BR_Scope_DetailcountRowsChecked--;	
}

function Spartan_BR_Scope_DetailCancelRow(rowIndex) {
    var prevData = Spartan_BR_Scope_DetailTable.fnGetData(rowIndex);
    var data = Spartan_BR_Scope_DetailTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Spartan_BR_Scope_DetailTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Spartan_BR_Scope_DetailrowCreationGrid(data, prevData, rowIndex);
    }
    Spartan_BR_Scope_DetailcountRowsChecked--;
}

function GetSpartan_BR_Scope_DetailFromDataTable() {
    var Spartan_BR_Scope_DetailData = [];
    var gridData = Spartan_BR_Scope_DetailTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Spartan_BR_Scope_DetailData.push({
                ScopeDetailId: gridData[i].ScopeDetailId
                ,Scope: gridData[i].Scope

                ,Removed: false
            });
    }

    for (i = 0; i < removedSpartan_BR_Scope_DetailData.length; i++) {
        if (removedSpartan_BR_Scope_DetailData[i] != null && removedSpartan_BR_Scope_DetailData[i].ScopeDetailId > 0)
            Spartan_BR_Scope_DetailData.push({
                ScopeDetailId: removedSpartan_BR_Scope_DetailData[i].ScopeDetailId
                ,Scope: removedSpartan_BR_ScopeData[i].Scope

                , Removed: true
            });
    }	

    return Spartan_BR_Scope_DetailData;
}

function Spartan_BR_Scope_DetailEditRow(rowIndex) {
    Spartan_BR_Scope_DetailcountRowsChecked++;
    var Spartan_BR_Scope_DetailRowElement = "Spartan_BR_Scope_Detail_" + rowIndex.toString();
    var prevData = Spartan_BR_Scope_DetailTable.fnGetData(rowIndex);
    var row = Spartan_BR_Scope_DetailTable.fnGetNodes(rowIndex);
    row.innerHTML = "";

    var controls = Spartan_BR_Scope_DetailGetUpdateRowControls(prevData);

    var abc = "if(dynamicFieldValidation('" + Spartan_BR_Scope_DetailRowElement + "')){ Spartan_BR_Scope_DetailInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Spartan_BR_Scope_DetailCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (var i = 0; i < controls.length; i++) {
        $(controls[i]).appendTo($('<td>').appendTo(row));
    }

    initiateUIControls();
}

function Spartan_BR_Scope_DetailfnOpenAddRowPopUp() {
    var currentRowIndex = Spartan_BR_Scope_DetailTable.fnGetData().length;
    Spartan_BR_Scope_DetailfnClickAddRow();
    GetAddSpartan_BR_Scope_DetailPopup(currentRowIndex, 0);
}

function Spartan_BR_Scope_DetailEditRowPopup(rowIndex) {
    var Spartan_BR_Scope_DetailRowElement = "Spartan_BR_Scope_Detail_" + rowIndex.toString();
    var prevData = Spartan_BR_Scope_DetailTable.fnGetData(rowIndex);
    GetAddSpartan_BR_Scope_DetailPopup(rowIndex, 1);
    $('#ScopePop').val(prevData.Scope);

    initiateUIControls();

}

function Spartan_BR_Scope_DetailAddInsertRow() {
    if (Spartan_BR_Scope_DetailinsertRowCurrentIndex < 1)
    {
        Spartan_BR_Scope_DetailinsertRowCurrentIndex = 1;
    }
    return {
        ScopeDetailId: null,
        IsInsertRow: true
        ,Scope: ""

    }
}

function Spartan_BR_Scope_DetailfnClickAddRow() {
    Spartan_BR_Scope_DetailcountRowsChecked++;
    Spartan_BR_Scope_DetailTable
        .fnAddData(Spartan_BR_Scope_DetailAddInsertRow(), true);
    initiateUIControls();
}

function Spartan_BR_Scope_DetailClearGridData() {
    Spartan_BR_Scope_DetailData = [];
    Spartan_BR_Scope_DetaildeletedItem = [];
    Spartan_BR_Scope_DetailDataMain = [];
    Spartan_BR_Scope_DetailDataMainPages = [];
    Spartan_BR_Scope_DetailnewItemCount = 0;
    Spartan_BR_Scope_DetailmaxItemIndex = 0;
    $("#Spartan_BR_Scope_DetailGrid").DataTable().clear();
    $("#Spartan_BR_Scope_DetailGrid").DataTable().destroy();
}

//Used to Get Business Rule Information
function GetSpartan_BR_Scope_Detail() {
    var form_data = new FormData();
    for (var i = 0; i < Spartan_BR_Scope_DetailData.length; i++) {
        form_data.append('[' + i + '].ScopeDetailId', Spartan_BR_Scope_DetailData[i].ScopeDetailId);
        form_data.append('[' + i + '].Scope', Spartan_BR_Scope_DetailData[i].Scope);

        form_data.append('[' + i + '].Removed', Spartan_BR_Scope_DetailData[i].Removed);
    }
    return form_data;
}
function Spartan_BR_Scope_DetailInsertRowFromPopup(rowIndex) {
    var prevData = Spartan_BR_Scope_DetailTable.fnGetData(rowIndex);
    var data = Spartan_BR_Scope_DetailTable.fnGetNodes(rowIndex);
    var newData = {
        BusinessRuleId: prevData.BusinessRuleId,
        IsInsertRow: false
        ,Scope: $('#dvScope').find('select').val()

    }

    Spartan_BR_Scope_DetailTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_BR_Scope_DetailrowCreationGrid(data, newData, rowIndex);
    $('#AddSpartan_BR_Scope_Detail-form').modal({ show: false });
    $('#AddSpartan_BR_Scope_Detail-form').modal('hide');
}
function Spartan_BR_Scope_DetailRemoveAddRow(rowIndex) {
    Spartan_BR_Scope_DetailTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Spartan_BR_Scope_Detail MultiRow
//Begin Declarations for Foreigns fields for Spartan_BR_Operation_Detail MultiRow
var Spartan_BR_Operation_DetailcountRowsChecked = 0;
function GetSpartan_BR_Operation_Detail_Spartan_BR_OperationName(Id) {
    for (var i = 0; i < Spartan_BR_Operation_Detail_Spartan_BR_OperationItems.length; i++) {
        if (Spartan_BR_Operation_Detail_Spartan_BR_OperationItems[i].OperationId == Id) {
            return Spartan_BR_Operation_Detail_Spartan_BR_OperationItems[i].Description;
        }
    }
    return "";
}

function GetSpartan_BR_Operation_Detail_Spartan_BR_OperationDropDown() {
    var Spartan_BR_Operation_Detail_Spartan_BR_OperationDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_BR_Operation_Detail_Spartan_BR_OperationDropdown);

    for (var i = 0; i < Spartan_BR_Operation_Detail_Spartan_BR_OperationItems.length; i++) {
        $('<option />', { value: Spartan_BR_Operation_Detail_Spartan_BR_OperationItems[i].OperationId, text: Spartan_BR_Operation_Detail_Spartan_BR_OperationItems[i].Description }).appendTo(Spartan_BR_Operation_Detail_Spartan_BR_OperationDropdown);
    }
    return Spartan_BR_Operation_Detail_Spartan_BR_OperationDropdown;
}


function GetInsertSpartan_BR_Operation_DetailRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $(GetSpartan_BR_Operation_Detail_Spartan_BR_OperationDropDown()).addClass('Spartan_BR_Operation_Detail_Operation').attr('id', 'Spartan_BR_Operation_Detail_Operation_' + index);


    initiateUIControls();
    return columnData;
}

function Spartan_BR_Operation_DetailInsertRow(rowIndex) {
    var prevData = Spartan_BR_Operation_DetailTable.fnGetData(rowIndex);
    var data = Spartan_BR_Operation_DetailTable.fnGetNodes(rowIndex);
    var newData = {
        OperationDetailId: prevData.OperationDetailId,
        IsInsertRow: false
        ,Operation: data.childNodes[1].childNodes[0].value

    }
    Spartan_BR_Operation_DetailTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_BR_Operation_DetailrowCreationGrid(data, newData, rowIndex);
    Spartan_BR_Operation_DetailcountRowsChecked--;	
}

function Spartan_BR_Operation_DetailCancelRow(rowIndex) {
    var prevData = Spartan_BR_Operation_DetailTable.fnGetData(rowIndex);
    var data = Spartan_BR_Operation_DetailTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Spartan_BR_Operation_DetailTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Spartan_BR_Operation_DetailrowCreationGrid(data, prevData, rowIndex);
    }
    Spartan_BR_Operation_DetailcountRowsChecked--;
}

function GetSpartan_BR_Operation_DetailFromDataTable() {
    var Spartan_BR_Operation_DetailData = [];
    var gridData = Spartan_BR_Operation_DetailTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Spartan_BR_Operation_DetailData.push({
                OperationDetailId: gridData[i].OperationDetailId
                ,Operation: gridData[i].Operation

                ,Removed: false
            });
    }

    for (i = 0; i < removedSpartan_BR_Operation_DetailData.length; i++) {
        if (removedSpartan_BR_Operation_DetailData[i] != null && removedSpartan_BR_Operation_DetailData[i].OperationDetailId > 0)
            Spartan_BR_Operation_DetailData.push({
                OperationDetailId: removedSpartan_BR_Operation_DetailData[i].OperationDetailId
                ,Operation: removedSpartan_BR_OperationData[i].Operation

                , Removed: true
            });
    }	

    return Spartan_BR_Operation_DetailData;
}

function Spartan_BR_Operation_DetailEditRow(rowIndex) {
    Spartan_BR_Operation_DetailcountRowsChecked++;
    var Spartan_BR_Operation_DetailRowElement = "Spartan_BR_Operation_Detail_" + rowIndex.toString();
    var prevData = Spartan_BR_Operation_DetailTable.fnGetData(rowIndex);
    var row = Spartan_BR_Operation_DetailTable.fnGetNodes(rowIndex);
    row.innerHTML = "";

    var controls = Spartan_BR_Operation_DetailGetUpdateRowControls(prevData);

    var abc = "if(dynamicFieldValidation('" + Spartan_BR_Operation_DetailRowElement + "')){ Spartan_BR_Operation_DetailInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Spartan_BR_Operation_DetailCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (var i = 0; i < controls.length; i++) {
        $(controls[i]).appendTo($('<td>').appendTo(row));
    }

    initiateUIControls();
}

function Spartan_BR_Operation_DetailfnOpenAddRowPopUp() {
    var currentRowIndex = Spartan_BR_Operation_DetailTable.fnGetData().length;
    Spartan_BR_Operation_DetailfnClickAddRow();
    GetAddSpartan_BR_Operation_DetailPopup(currentRowIndex, 0);
}

function Spartan_BR_Operation_DetailEditRowPopup(rowIndex) {
    var Spartan_BR_Operation_DetailRowElement = "Spartan_BR_Operation_Detail_" + rowIndex.toString();
    var prevData = Spartan_BR_Operation_DetailTable.fnGetData(rowIndex);
    GetAddSpartan_BR_Operation_DetailPopup(rowIndex, 1);
    $('#OperationPop').val(prevData.Operation);

    initiateUIControls();

}

function Spartan_BR_Operation_DetailAddInsertRow() {
    if (Spartan_BR_Operation_DetailinsertRowCurrentIndex < 1)
    {
        Spartan_BR_Operation_DetailinsertRowCurrentIndex = 1;
    }
    return {
        OperationDetailId: null,
        IsInsertRow: true
        ,Operation: ""

    }
}

function Spartan_BR_Operation_DetailfnClickAddRow() {
    Spartan_BR_Operation_DetailcountRowsChecked++;
    Spartan_BR_Operation_DetailTable
        .fnAddData(Spartan_BR_Operation_DetailAddInsertRow(), true);
    initiateUIControls();
}

function Spartan_BR_Operation_DetailClearGridData() {
    Spartan_BR_Operation_DetailData = [];
    Spartan_BR_Operation_DetaildeletedItem = [];
    Spartan_BR_Operation_DetailDataMain = [];
    Spartan_BR_Operation_DetailDataMainPages = [];
    Spartan_BR_Operation_DetailnewItemCount = 0;
    Spartan_BR_Operation_DetailmaxItemIndex = 0;
    $("#Spartan_BR_Operation_DetailGrid").DataTable().clear();
    $("#Spartan_BR_Operation_DetailGrid").DataTable().destroy();
}

//Used to Get Business Rule Information
function GetSpartan_BR_Operation_Detail() {
    var form_data = new FormData();
    for (var i = 0; i < Spartan_BR_Operation_DetailData.length; i++) {
        form_data.append('[' + i + '].OperationDetailId', Spartan_BR_Operation_DetailData[i].OperationDetailId);
        form_data.append('[' + i + '].Operation', Spartan_BR_Operation_DetailData[i].Operation);

        form_data.append('[' + i + '].Removed', Spartan_BR_Operation_DetailData[i].Removed);
    }
    return form_data;
}
function Spartan_BR_Operation_DetailInsertRowFromPopup(rowIndex) {
    var prevData = Spartan_BR_Operation_DetailTable.fnGetData(rowIndex);
    var data = Spartan_BR_Operation_DetailTable.fnGetNodes(rowIndex);
    var newData = {
        BusinessRuleId: prevData.BusinessRuleId,
        IsInsertRow: false
        ,Operation: $('#dvOperation').find('select').val()

    }

    Spartan_BR_Operation_DetailTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_BR_Operation_DetailrowCreationGrid(data, newData, rowIndex);
    $('#AddSpartan_BR_Operation_Detail-form').modal({ show: false });
    $('#AddSpartan_BR_Operation_Detail-form').modal('hide');
}
function Spartan_BR_Operation_DetailRemoveAddRow(rowIndex) {
    Spartan_BR_Operation_DetailTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Spartan_BR_Operation_Detail MultiRow
//Begin Declarations for Foreigns fields for Spartan_BR_Process_Event_Detail MultiRow
var Spartan_BR_Process_Event_DetailcountRowsChecked = 0;
function GetSpartan_BR_Process_Event_Detail_Spartan_BR_Process_EventName(Id) {
    for (var i = 0; i < Spartan_BR_Process_Event_Detail_Spartan_BR_Process_EventItems.length; i++) {
        if (Spartan_BR_Process_Event_Detail_Spartan_BR_Process_EventItems[i].ProcessEventId == Id) {
            return Spartan_BR_Process_Event_Detail_Spartan_BR_Process_EventItems[i].Description;
        }
    }
    return "";
}

function GetSpartan_BR_Process_Event_Detail_Spartan_BR_Process_EventDropDown() {
    var Spartan_BR_Process_Event_Detail_Spartan_BR_Process_EventDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_BR_Process_Event_Detail_Spartan_BR_Process_EventDropdown);

    for (var i = 0; i < Spartan_BR_Process_Event_Detail_Spartan_BR_Process_EventItems.length; i++) {
        $('<option />', { value: Spartan_BR_Process_Event_Detail_Spartan_BR_Process_EventItems[i].ProcessEventId, text: Spartan_BR_Process_Event_Detail_Spartan_BR_Process_EventItems[i].Description }).appendTo(Spartan_BR_Process_Event_Detail_Spartan_BR_Process_EventDropdown);
    }
    return Spartan_BR_Process_Event_Detail_Spartan_BR_Process_EventDropdown;
}


function GetInsertSpartan_BR_Process_Event_DetailRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $(GetSpartan_BR_Process_Event_Detail_Spartan_BR_Process_EventDropDown()).addClass('Spartan_BR_Process_Event_Detail_Process_Event').attr('id', 'Spartan_BR_Process_Event_Detail_Process_Event_' + index);


    initiateUIControls();
    return columnData;
}

function Spartan_BR_Process_Event_DetailInsertRow(rowIndex) {
    var prevData = Spartan_BR_Process_Event_DetailTable.fnGetData(rowIndex);
    var data = Spartan_BR_Process_Event_DetailTable.fnGetNodes(rowIndex);
    var newData = {
        ProcessEventDetailId: prevData.ProcessEventDetailId,
        IsInsertRow: false
        ,Process_Event: data.childNodes[1].childNodes[0].value

    }
    Spartan_BR_Process_Event_DetailTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_BR_Process_Event_DetailrowCreationGrid(data, newData, rowIndex);
    Spartan_BR_Process_Event_DetailcountRowsChecked--;	
}

function Spartan_BR_Process_Event_DetailCancelRow(rowIndex) {
    var prevData = Spartan_BR_Process_Event_DetailTable.fnGetData(rowIndex);
    var data = Spartan_BR_Process_Event_DetailTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Spartan_BR_Process_Event_DetailTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Spartan_BR_Process_Event_DetailrowCreationGrid(data, prevData, rowIndex);
    }
    Spartan_BR_Process_Event_DetailcountRowsChecked--;
}

function GetSpartan_BR_Process_Event_DetailFromDataTable() {
    var Spartan_BR_Process_Event_DetailData = [];
    var gridData = Spartan_BR_Process_Event_DetailTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Spartan_BR_Process_Event_DetailData.push({
                ProcessEventDetailId: gridData[i].ProcessEventDetailId
                ,Process_Event: gridData[i].Process_Event

                ,Removed: false
            });
    }

    for (i = 0; i < removedSpartan_BR_Process_Event_DetailData.length; i++) {
        if (removedSpartan_BR_Process_Event_DetailData[i] != null && removedSpartan_BR_Process_Event_DetailData[i].ProcessEventDetailId > 0)
            Spartan_BR_Process_Event_DetailData.push({
                ProcessEventDetailId: removedSpartan_BR_Process_Event_DetailData[i].ProcessEventDetailId
                ,Process_Event: removedSpartan_BR_Process_EventData[i].Process_Event

                , Removed: true
            });
    }	

    return Spartan_BR_Process_Event_DetailData;
}

function Spartan_BR_Process_Event_DetailEditRow(rowIndex) {
    Spartan_BR_Process_Event_DetailcountRowsChecked++;
    var Spartan_BR_Process_Event_DetailRowElement = "Spartan_BR_Process_Event_Detail_" + rowIndex.toString();
    var prevData = Spartan_BR_Process_Event_DetailTable.fnGetData(rowIndex);
    var row = Spartan_BR_Process_Event_DetailTable.fnGetNodes(rowIndex);
    row.innerHTML = "";

    var controls = Spartan_BR_Process_Event_DetailGetUpdateRowControls(prevData);

    var abc = "if(dynamicFieldValidation('" + Spartan_BR_Process_Event_DetailRowElement + "')){ Spartan_BR_Process_Event_DetailInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Spartan_BR_Process_Event_DetailCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (var i = 0; i < controls.length; i++) {
        $(controls[i]).appendTo($('<td>').appendTo(row));
    }

    initiateUIControls();
}

function Spartan_BR_Process_Event_DetailfnOpenAddRowPopUp() {
    var currentRowIndex = Spartan_BR_Process_Event_DetailTable.fnGetData().length;
    Spartan_BR_Process_Event_DetailfnClickAddRow();
    GetAddSpartan_BR_Process_Event_DetailPopup(currentRowIndex, 0);
}

function Spartan_BR_Process_Event_DetailEditRowPopup(rowIndex) {
    var Spartan_BR_Process_Event_DetailRowElement = "Spartan_BR_Process_Event_Detail_" + rowIndex.toString();
    var prevData = Spartan_BR_Process_Event_DetailTable.fnGetData(rowIndex);
    GetAddSpartan_BR_Process_Event_DetailPopup(rowIndex, 1);
    $('#Process_EventPop').val(prevData.Process_Event);

    initiateUIControls();

}

function Spartan_BR_Process_Event_DetailAddInsertRow() {
    if (Spartan_BR_Process_Event_DetailinsertRowCurrentIndex < 1)
    {
        Spartan_BR_Process_Event_DetailinsertRowCurrentIndex = 1;
    }
    return {
        ProcessEventDetailId: null,
        IsInsertRow: true
        ,Process_Event: ""

    }
}

function Spartan_BR_Process_Event_DetailfnClickAddRow() {
    Spartan_BR_Process_Event_DetailcountRowsChecked++;
    Spartan_BR_Process_Event_DetailTable
        .fnAddData(Spartan_BR_Process_Event_DetailAddInsertRow(), true);
    initiateUIControls();
}

function Spartan_BR_Process_Event_DetailClearGridData() {
    Spartan_BR_Process_Event_DetailData = [];
    Spartan_BR_Process_Event_DetaildeletedItem = [];
    Spartan_BR_Process_Event_DetailDataMain = [];
    Spartan_BR_Process_Event_DetailDataMainPages = [];
    Spartan_BR_Process_Event_DetailnewItemCount = 0;
    Spartan_BR_Process_Event_DetailmaxItemIndex = 0;
    $("#Spartan_BR_Process_Event_DetailGrid").DataTable().clear();
    $("#Spartan_BR_Process_Event_DetailGrid").DataTable().destroy();
}

//Used to Get Business Rule Information
function GetSpartan_BR_Process_Event_Detail() {
    var form_data = new FormData();
    for (var i = 0; i < Spartan_BR_Process_Event_DetailData.length; i++) {
        form_data.append('[' + i + '].ProcessEventDetailId', Spartan_BR_Process_Event_DetailData[i].ProcessEventDetailId);
        form_data.append('[' + i + '].Process_Event', Spartan_BR_Process_Event_DetailData[i].Process_Event);

        form_data.append('[' + i + '].Removed', Spartan_BR_Process_Event_DetailData[i].Removed);
    }
    return form_data;
}
function Spartan_BR_Process_Event_DetailInsertRowFromPopup(rowIndex) {
    var prevData = Spartan_BR_Process_Event_DetailTable.fnGetData(rowIndex);
    var data = Spartan_BR_Process_Event_DetailTable.fnGetNodes(rowIndex);
    var newData = {
        BusinessRuleId: prevData.BusinessRuleId,
        IsInsertRow: false
        ,Process_Event: $('#dvProcess_Event').find('select').val()

    }

    Spartan_BR_Process_Event_DetailTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_BR_Process_Event_DetailrowCreationGrid(data, newData, rowIndex);
    $('#AddSpartan_BR_Process_Event_Detail-form').modal({ show: false });
    $('#AddSpartan_BR_Process_Event_Detail-form').modal('hide');
}
function Spartan_BR_Process_Event_DetailRemoveAddRow(rowIndex) {
    Spartan_BR_Process_Event_DetailTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Spartan_BR_Process_Event_Detail MultiRow
//Begin Declarations for Foreigns fields for Spartan_BR_Conditions_Detail MultiRow
var Spartan_BR_Conditions_DetailcountRowsChecked = 0;
function GetSpartan_BR_Conditions_Detail_Spartan_BR_Condition_OperatorName(Id) {
    for (var i = 0; i < Spartan_BR_Conditions_Detail_Spartan_BR_Condition_OperatorItems.length; i++) {
        if (Spartan_BR_Conditions_Detail_Spartan_BR_Condition_OperatorItems[i].ConditionOperatorId == Id) {
            return Spartan_BR_Conditions_Detail_Spartan_BR_Condition_OperatorItems[i].Description;
        }
    }
    return "";
}

function GetSpartan_BR_Conditions_Detail_Spartan_BR_Condition_OperatorDropDown() {
    var Spartan_BR_Conditions_Detail_Spartan_BR_Condition_OperatorDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_BR_Conditions_Detail_Spartan_BR_Condition_OperatorDropdown);

    for (var i = 0; i < Spartan_BR_Conditions_Detail_Spartan_BR_Condition_OperatorItems.length; i++) {
        $('<option />', { value: Spartan_BR_Conditions_Detail_Spartan_BR_Condition_OperatorItems[i].ConditionOperatorId, text: Spartan_BR_Conditions_Detail_Spartan_BR_Condition_OperatorItems[i].Description }).appendTo(Spartan_BR_Conditions_Detail_Spartan_BR_Condition_OperatorDropdown);
    }
    return Spartan_BR_Conditions_Detail_Spartan_BR_Condition_OperatorDropdown;
}
function GetSpartan_BR_Conditions_Detail_Spartan_BR_Operator_TypeName(Id) {
    for (var i = 0; i < Spartan_BR_Conditions_Detail_Spartan_BR_Operator_TypeItems.length; i++) {
        if (Spartan_BR_Conditions_Detail_Spartan_BR_Operator_TypeItems[i].OperatorTypeId == Id) {
            return Spartan_BR_Conditions_Detail_Spartan_BR_Operator_TypeItems[i].Description;
        }
    }
    return "";
}

function GetSpartan_BR_Conditions_Detail_Spartan_BR_Operator_TypeDropDown() {
    var Spartan_BR_Conditions_Detail_Spartan_BR_Operator_TypeDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_BR_Conditions_Detail_Spartan_BR_Operator_TypeDropdown);

    for (var i = 0; i < Spartan_BR_Conditions_Detail_Spartan_BR_Operator_TypeItems.length; i++) {
        $('<option />', { value: Spartan_BR_Conditions_Detail_Spartan_BR_Operator_TypeItems[i].OperatorTypeId, text: Spartan_BR_Conditions_Detail_Spartan_BR_Operator_TypeItems[i].Description }).appendTo(Spartan_BR_Conditions_Detail_Spartan_BR_Operator_TypeDropdown);
    }
    return Spartan_BR_Conditions_Detail_Spartan_BR_Operator_TypeDropdown;
}
function GetSpartan_BR_Conditions_Detail_Spartan_BR_ConditionName(Id) {
    for (var i = 0; i < Spartan_BR_Conditions_Detail_Spartan_BR_ConditionItems.length; i++) {
        if (Spartan_BR_Conditions_Detail_Spartan_BR_ConditionItems[i].ConditionId == Id) {
            return Spartan_BR_Conditions_Detail_Spartan_BR_ConditionItems[i].Description;
        }
    }
    return "";
}

function GetSpartan_BR_Conditions_Detail_Spartan_BR_ConditionDropDown() {
    var Spartan_BR_Conditions_Detail_Spartan_BR_ConditionDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_BR_Conditions_Detail_Spartan_BR_ConditionDropdown);

    for (var i = 0; i < Spartan_BR_Conditions_Detail_Spartan_BR_ConditionItems.length; i++) {
        $('<option />', { value: Spartan_BR_Conditions_Detail_Spartan_BR_ConditionItems[i].ConditionId, text: Spartan_BR_Conditions_Detail_Spartan_BR_ConditionItems[i].Description }).appendTo(Spartan_BR_Conditions_Detail_Spartan_BR_ConditionDropdown);
    }
    return Spartan_BR_Conditions_Detail_Spartan_BR_ConditionDropdown;
}


function GetInsertSpartan_BR_Conditions_DetailRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $(GetSpartan_BR_Conditions_Detail_Spartan_BR_Condition_OperatorDropDown()).addClass('Spartan_BR_Conditions_Detail_Condition_Operator').attr('id', 'Spartan_BR_Conditions_Detail_Condition_Operator_' + index);
    columnData[1] = $(GetSpartan_BR_Conditions_Detail_Spartan_BR_Operator_TypeDropDown()).addClass('Spartan_BR_Conditions_Detail_First_Operator_Type').attr('id', 'Spartan_BR_Conditions_Detail_First_Operator_Type_' + index);
    columnData[2] = $($.parseHTML(inputData)).addClass('Spartan_BR_Conditions_Detail_First_Operator_Value').attr('id', 'Spartan_BR_Conditions_Detail_First_Operator_Value_' + index);
    columnData[3] = $(GetSpartan_BR_Conditions_Detail_Spartan_BR_ConditionDropDown()).addClass('Spartan_BR_Conditions_Detail_Condition').attr('id', 'Spartan_BR_Conditions_Detail_Condition_' + index);
    columnData[4] = $(GetSpartan_BR_Conditions_Detail_Spartan_BR_Operator_TypeDropDown()).addClass('Spartan_BR_Conditions_Detail_Second_Operator_Type').attr('id', 'Spartan_BR_Conditions_Detail_Second_Operator_Type_' + index);
    columnData[5] = $($.parseHTML(inputData)).addClass('Spartan_BR_Conditions_Detail_Second_Operator_Value').attr('id', 'Spartan_BR_Conditions_Detail_Second_Operator_Value_' + index);


    initiateUIControls();
    return columnData;
}

function Spartan_BR_Conditions_DetailInsertRow(rowIndex) {
    var prevData = Spartan_BR_Conditions_DetailTable.fnGetData(rowIndex);
    var data = Spartan_BR_Conditions_DetailTable.fnGetNodes(rowIndex);
    var newData = {
        ConditionsDetailId: prevData.ConditionsDetailId,
        IsInsertRow: false
        ,Condition_Operator: data.childNodes[1].childNodes[0].value
        ,First_Operator_Type: data.childNodes[2].childNodes[0].value
        ,First_Operator_Value: data.childNodes[3].childNodes[0].value
        ,Condition: data.childNodes[4].childNodes[0].value
        ,Second_Operator_Type: data.childNodes[5].childNodes[0].value
        ,Second_Operator_Value: data.childNodes[6].childNodes[0].value

    }
    Spartan_BR_Conditions_DetailTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_BR_Conditions_DetailrowCreationGrid(data, newData, rowIndex);
    Spartan_BR_Conditions_DetailcountRowsChecked--;	
}

function Spartan_BR_Conditions_DetailCancelRow(rowIndex) {
    var prevData = Spartan_BR_Conditions_DetailTable.fnGetData(rowIndex);
    var data = Spartan_BR_Conditions_DetailTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Spartan_BR_Conditions_DetailTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Spartan_BR_Conditions_DetailrowCreationGrid(data, prevData, rowIndex);
    }
    Spartan_BR_Conditions_DetailcountRowsChecked--;
}

function GetSpartan_BR_Conditions_DetailFromDataTable() {
    var Spartan_BR_Conditions_DetailData = [];
    var gridData = Spartan_BR_Conditions_DetailTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Spartan_BR_Conditions_DetailData.push({
                ConditionsDetailId: gridData[i].ConditionsDetailId
                ,Condition_Operator: gridData[i].Condition_Operator
                ,First_Operator_Type: gridData[i].First_Operator_Type
                ,First_Operator_Value: gridData[i].First_Operator_Value
                ,Condition: gridData[i].Condition
                ,Second_Operator_Type: gridData[i].Second_Operator_Type
                ,Second_Operator_Value: gridData[i].Second_Operator_Value

                ,Removed: false
            });
    }

    for (i = 0; i < removedSpartan_BR_Conditions_DetailData.length; i++) {
        if (removedSpartan_BR_Conditions_DetailData[i] != null && removedSpartan_BR_Conditions_DetailData[i].ConditionsDetailId > 0)
            Spartan_BR_Conditions_DetailData.push({
                ConditionsDetailId: removedSpartan_BR_Conditions_DetailData[i].ConditionsDetailId
                ,Condition_Operator: removedSpartan_BR_Condition_OperatorData[i].Condition_Operator
                ,First_Operator_Type: removedSpartan_BR_Operator_TypeData[i].First_Operator_Type
                ,First_Operator_Value: removedData[i].First_Operator_Value
                ,Condition: removedSpartan_BR_ConditionData[i].Condition
                ,Second_Operator_Type: removedSpartan_BR_Operator_TypeData[i].Second_Operator_Type
                ,Second_Operator_Value: removedData[i].Second_Operator_Value

                , Removed: true
            });
    }	

    return Spartan_BR_Conditions_DetailData;
}

function Spartan_BR_Conditions_DetailEditRow(rowIndex) {
    Spartan_BR_Conditions_DetailcountRowsChecked++;
    var Spartan_BR_Conditions_DetailRowElement = "Spartan_BR_Conditions_Detail_" + rowIndex.toString();
    var prevData = Spartan_BR_Conditions_DetailTable.fnGetData(rowIndex);
    var row = Spartan_BR_Conditions_DetailTable.fnGetNodes(rowIndex);
    row.innerHTML = "";

    var controls = Spartan_BR_Conditions_DetailGetUpdateRowControls(prevData);

    var abc = "if(dynamicFieldValidation('" + Spartan_BR_Conditions_DetailRowElement + "')){ Spartan_BR_Conditions_DetailInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Spartan_BR_Conditions_DetailCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (var i = 0; i < controls.length; i++) {
        $(controls[i]).appendTo($('<td>').appendTo(row));
    }

    initiateUIControls();
}

function Spartan_BR_Conditions_DetailfnOpenAddRowPopUp() {
    var currentRowIndex = Spartan_BR_Conditions_DetailTable.fnGetData().length;
    Spartan_BR_Conditions_DetailfnClickAddRow();
    GetAddSpartan_BR_Conditions_DetailPopup(currentRowIndex, 0);
}

function Spartan_BR_Conditions_DetailEditRowPopup(rowIndex) {
    var Spartan_BR_Conditions_DetailRowElement = "Spartan_BR_Conditions_Detail_" + rowIndex.toString();
    var prevData = Spartan_BR_Conditions_DetailTable.fnGetData(rowIndex);
    GetAddSpartan_BR_Conditions_DetailPopup(rowIndex, 1);
    $('#Condition_OperatorPop').val(prevData.Condition_Operator);
    $('#First_Operator_TypePop').val(prevData.First_Operator_Type);
    $('#First_Operator_ValuePop').val(prevData.First_Operator_Value);
    $('#ConditionPop').val(prevData.Condition);
    $('#Second_Operator_TypePop').val(prevData.Second_Operator_Type);
    $('#Second_Operator_ValuePop').val(prevData.Second_Operator_Value);

    initiateUIControls();

}

function Spartan_BR_Conditions_DetailAddInsertRow() {
    if (Spartan_BR_Conditions_DetailinsertRowCurrentIndex < 1)
    {
        Spartan_BR_Conditions_DetailinsertRowCurrentIndex = 1;
    }
    return {
        ConditionsDetailId: null,
        IsInsertRow: true
        ,Condition_Operator: ""
        ,First_Operator_Type: ""
        ,First_Operator_Value: ""
        ,Condition: ""
        ,Second_Operator_Type: ""
        ,Second_Operator_Value: ""

    }
}

function Spartan_BR_Conditions_DetailfnClickAddRow() {
    Spartan_BR_Conditions_DetailcountRowsChecked++;
    Spartan_BR_Conditions_DetailTable
        .fnAddData(Spartan_BR_Conditions_DetailAddInsertRow(), true);
    initiateUIControls();
}

function Spartan_BR_Conditions_DetailClearGridData() {
    Spartan_BR_Conditions_DetailData = [];
    Spartan_BR_Conditions_DetaildeletedItem = [];
    Spartan_BR_Conditions_DetailDataMain = [];
    Spartan_BR_Conditions_DetailDataMainPages = [];
    Spartan_BR_Conditions_DetailnewItemCount = 0;
    Spartan_BR_Conditions_DetailmaxItemIndex = 0;
    $("#Spartan_BR_Conditions_DetailGrid").DataTable().clear();
    $("#Spartan_BR_Conditions_DetailGrid").DataTable().destroy();
}

//Used to Get Business Rule Information
function GetSpartan_BR_Conditions_Detail() {
    var form_data = new FormData();
    for (var i = 0; i < Spartan_BR_Conditions_DetailData.length; i++) {
        form_data.append('[' + i + '].ConditionsDetailId', Spartan_BR_Conditions_DetailData[i].ConditionsDetailId);
        form_data.append('[' + i + '].Condition_Operator', Spartan_BR_Conditions_DetailData[i].Condition_Operator);
        form_data.append('[' + i + '].First_Operator_Type', Spartan_BR_Conditions_DetailData[i].First_Operator_Type);
        form_data.append('[' + i + '].First_Operator_Value', Spartan_BR_Conditions_DetailData[i].First_Operator_Value);
        form_data.append('[' + i + '].Condition', Spartan_BR_Conditions_DetailData[i].Condition);
        form_data.append('[' + i + '].Second_Operator_Type', Spartan_BR_Conditions_DetailData[i].Second_Operator_Type);
        form_data.append('[' + i + '].Second_Operator_Value', Spartan_BR_Conditions_DetailData[i].Second_Operator_Value);

        form_data.append('[' + i + '].Removed', Spartan_BR_Conditions_DetailData[i].Removed);
    }
    return form_data;
}
function Spartan_BR_Conditions_DetailInsertRowFromPopup(rowIndex) {
    var prevData = Spartan_BR_Conditions_DetailTable.fnGetData(rowIndex);
    var data = Spartan_BR_Conditions_DetailTable.fnGetNodes(rowIndex);
    var newData = {
        BusinessRuleId: prevData.BusinessRuleId,
        IsInsertRow: false
        ,Condition_Operator: $('#dvCondition_Operator').find('select').val()
        ,First_Operator_Type: $('#dvFirst_Operator_Type').find('select').val()
        ,First_Operator_Value: $('#First_Operator_ValuePop').val()
        ,Condition: $('#dvCondition').find('select').val()
        ,Second_Operator_Type: $('#dvSecond_Operator_Type').find('select').val()
        ,Second_Operator_Value: $('#Second_Operator_ValuePop').val()

    }

    Spartan_BR_Conditions_DetailTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_BR_Conditions_DetailrowCreationGrid(data, newData, rowIndex);
    $('#AddSpartan_BR_Conditions_Detail-form').modal({ show: false });
    $('#AddSpartan_BR_Conditions_Detail-form').modal('hide');
}
function Spartan_BR_Conditions_DetailRemoveAddRow(rowIndex) {
    Spartan_BR_Conditions_DetailTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Spartan_BR_Conditions_Detail MultiRow
//Begin Declarations for Foreigns fields for Spartan_BR_Actions_True_Detail MultiRow
var Spartan_BR_Actions_True_DetailcountRowsChecked = 0;
function GetSpartan_BR_Actions_True_Detail_Spartan_BR_Action_ClassificationName(Id) {
    for (var i = 0; i < Spartan_BR_Actions_True_Detail_Spartan_BR_Action_ClassificationItems.length; i++) {
        if (Spartan_BR_Actions_True_Detail_Spartan_BR_Action_ClassificationItems[i].ClassificationId == Id) {
            return Spartan_BR_Actions_True_Detail_Spartan_BR_Action_ClassificationItems[i].Description;
        }
    }
    return "";
}

function GetSpartan_BR_Actions_True_Detail_Spartan_BR_Action_ClassificationDropDown() {
    var Spartan_BR_Actions_True_Detail_Spartan_BR_Action_ClassificationDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_BR_Actions_True_Detail_Spartan_BR_Action_ClassificationDropdown);

    for (var i = 0; i < Spartan_BR_Actions_True_Detail_Spartan_BR_Action_ClassificationItems.length; i++) {
        $('<option />', { value: Spartan_BR_Actions_True_Detail_Spartan_BR_Action_ClassificationItems[i].ClassificationId, text: Spartan_BR_Actions_True_Detail_Spartan_BR_Action_ClassificationItems[i].Description }).appendTo(Spartan_BR_Actions_True_Detail_Spartan_BR_Action_ClassificationDropdown);
    }
    return Spartan_BR_Actions_True_Detail_Spartan_BR_Action_ClassificationDropdown;
}
function GetSpartan_BR_Actions_True_Detail_Spartan_BR_ActionName(Id) {
    for (var i = 0; i < Spartan_BR_Actions_True_Detail_Spartan_BR_ActionItems.length; i++) {
        if (Spartan_BR_Actions_True_Detail_Spartan_BR_ActionItems[i].ActionId == Id) {
            return Spartan_BR_Actions_True_Detail_Spartan_BR_ActionItems[i].Description;
        }
    }
    return "";
}

function GetSpartan_BR_Actions_True_Detail_Spartan_BR_ActionDropDown() {
    var Spartan_BR_Actions_True_Detail_Spartan_BR_ActionDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_BR_Actions_True_Detail_Spartan_BR_ActionDropdown);

    for (var i = 0; i < Spartan_BR_Actions_True_Detail_Spartan_BR_ActionItems.length; i++) {
        $('<option />', { value: Spartan_BR_Actions_True_Detail_Spartan_BR_ActionItems[i].ActionId, text: Spartan_BR_Actions_True_Detail_Spartan_BR_ActionItems[i].Description }).appendTo(Spartan_BR_Actions_True_Detail_Spartan_BR_ActionDropdown);
    }
    return Spartan_BR_Actions_True_Detail_Spartan_BR_ActionDropdown;
}
function GetSpartan_BR_Actions_True_Detail_Spartan_BR_Action_ResultName(Id) {
    for (var i = 0; i < Spartan_BR_Actions_True_Detail_Spartan_BR_Action_ResultItems.length; i++) {
        if (Spartan_BR_Actions_True_Detail_Spartan_BR_Action_ResultItems[i].ActionResultId == Id) {
            return Spartan_BR_Actions_True_Detail_Spartan_BR_Action_ResultItems[i].Description;
        }
    }
    return "";
}

function GetSpartan_BR_Actions_True_Detail_Spartan_BR_Action_ResultDropDown() {
    var Spartan_BR_Actions_True_Detail_Spartan_BR_Action_ResultDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_BR_Actions_True_Detail_Spartan_BR_Action_ResultDropdown);

    for (var i = 0; i < Spartan_BR_Actions_True_Detail_Spartan_BR_Action_ResultItems.length; i++) {
        $('<option />', { value: Spartan_BR_Actions_True_Detail_Spartan_BR_Action_ResultItems[i].ActionResultId, text: Spartan_BR_Actions_True_Detail_Spartan_BR_Action_ResultItems[i].Description }).appendTo(Spartan_BR_Actions_True_Detail_Spartan_BR_Action_ResultDropdown);
    }
    return Spartan_BR_Actions_True_Detail_Spartan_BR_Action_ResultDropdown;
}


function GetInsertSpartan_BR_Actions_True_DetailRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $(GetSpartan_BR_Actions_True_Detail_Spartan_BR_Action_ClassificationDropDown()).addClass('Spartan_BR_Actions_True_Detail_Action_Classification').attr('id', 'Spartan_BR_Actions_True_Detail_Action_Classification_' + index);
    columnData[1] = $(GetSpartan_BR_Actions_True_Detail_Spartan_BR_ActionDropDown()).addClass('Spartan_BR_Actions_True_Detail_Action').attr('id', 'Spartan_BR_Actions_True_Detail_Action_' + index);
    columnData[2] = $(GetSpartan_BR_Actions_True_Detail_Spartan_BR_Action_ResultDropDown()).addClass('Spartan_BR_Actions_True_Detail_Action_Result').attr('id', 'Spartan_BR_Actions_True_Detail_Action_Result_' + index);
    columnData[3] = $($.parseHTML(inputData)).addClass('Spartan_BR_Actions_True_Detail_Parameter_1').attr('id', 'Spartan_BR_Actions_True_Detail_Parameter_1_' + index);
    columnData[4] = $($.parseHTML(inputData)).addClass('Spartan_BR_Actions_True_Detail_Parameter_2').attr('id', 'Spartan_BR_Actions_True_Detail_Parameter_2_' + index);
    columnData[5] = $($.parseHTML(inputData)).addClass('Spartan_BR_Actions_True_Detail_Parameter_3').attr('id', 'Spartan_BR_Actions_True_Detail_Parameter_3_' + index);
    columnData[6] = $($.parseHTML(inputData)).addClass('Spartan_BR_Actions_True_Detail_Parameter_4').attr('id', 'Spartan_BR_Actions_True_Detail_Parameter_4_' + index);
    columnData[7] = $($.parseHTML(inputData)).addClass('Spartan_BR_Actions_True_Detail_Parameter_5').attr('id', 'Spartan_BR_Actions_True_Detail_Parameter_5_' + index);


    initiateUIControls();
    return columnData;
}

function Spartan_BR_Actions_True_DetailInsertRow(rowIndex) {
    var prevData = Spartan_BR_Actions_True_DetailTable.fnGetData(rowIndex);
    var data = Spartan_BR_Actions_True_DetailTable.fnGetNodes(rowIndex);
    var newData = {
        ActionsTrueDetailId: prevData.ActionsTrueDetailId,
        IsInsertRow: false
        ,Action_Classification: data.childNodes[1].childNodes[0].value
        ,Action: data.childNodes[2].childNodes[0].value
        ,Action_Result: data.childNodes[3].childNodes[0].value
        ,Parameter_1: data.childNodes[4].childNodes[0].value
        ,Parameter_2: data.childNodes[5].childNodes[0].value
        ,Parameter_3: data.childNodes[6].childNodes[0].value
        ,Parameter_4: data.childNodes[7].childNodes[0].value
        ,Parameter_5: data.childNodes[8].childNodes[0].value

    }
    Spartan_BR_Actions_True_DetailTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_BR_Actions_True_DetailrowCreationGrid(data, newData, rowIndex);
    Spartan_BR_Actions_True_DetailcountRowsChecked--;	
}

function Spartan_BR_Actions_True_DetailCancelRow(rowIndex) {
    var prevData = Spartan_BR_Actions_True_DetailTable.fnGetData(rowIndex);
    var data = Spartan_BR_Actions_True_DetailTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Spartan_BR_Actions_True_DetailTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Spartan_BR_Actions_True_DetailrowCreationGrid(data, prevData, rowIndex);
    }
    Spartan_BR_Actions_True_DetailcountRowsChecked--;
}

function GetSpartan_BR_Actions_True_DetailFromDataTable() {
    var Spartan_BR_Actions_True_DetailData = [];
    var gridData = Spartan_BR_Actions_True_DetailTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Spartan_BR_Actions_True_DetailData.push({
                ActionsTrueDetailId: gridData[i].ActionsTrueDetailId
                ,Action_Classification: gridData[i].Action_Classification
                ,Action: gridData[i].Action
                ,Action_Result: gridData[i].Action_Result
                ,Parameter_1: gridData[i].Parameter_1
                ,Parameter_2: gridData[i].Parameter_2
                ,Parameter_3: gridData[i].Parameter_3
                ,Parameter_4: gridData[i].Parameter_4
                ,Parameter_5: gridData[i].Parameter_5

                ,Removed: false
            });
    }

    for (i = 0; i < removedSpartan_BR_Actions_True_DetailData.length; i++) {
        if (removedSpartan_BR_Actions_True_DetailData[i] != null && removedSpartan_BR_Actions_True_DetailData[i].ActionsTrueDetailId > 0)
            Spartan_BR_Actions_True_DetailData.push({
                ActionsTrueDetailId: removedSpartan_BR_Actions_True_DetailData[i].ActionsTrueDetailId
                ,Action_Classification: removedSpartan_BR_Action_ClassificationData[i].Action_Classification
                ,Action: removedSpartan_BR_ActionData[i].Action
                ,Action_Result: removedSpartan_BR_Action_ResultData[i].Action_Result
                ,Parameter_1: removedData[i].Parameter_1
                ,Parameter_2: removedData[i].Parameter_2
                ,Parameter_3: removedData[i].Parameter_3
                ,Parameter_4: removedData[i].Parameter_4
                ,Parameter_5: removedData[i].Parameter_5

                , Removed: true
            });
    }	

    return Spartan_BR_Actions_True_DetailData;
}

function Spartan_BR_Actions_True_DetailEditRow(rowIndex) {
    Spartan_BR_Actions_True_DetailcountRowsChecked++;
    var Spartan_BR_Actions_True_DetailRowElement = "Spartan_BR_Actions_True_Detail_" + rowIndex.toString();
    var prevData = Spartan_BR_Actions_True_DetailTable.fnGetData(rowIndex);
    var row = Spartan_BR_Actions_True_DetailTable.fnGetNodes(rowIndex);
    row.innerHTML = "";

    var controls = Spartan_BR_Actions_True_DetailGetUpdateRowControls(prevData);

    var abc = "if(dynamicFieldValidation('" + Spartan_BR_Actions_True_DetailRowElement + "')){ Spartan_BR_Actions_True_DetailInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Spartan_BR_Actions_True_DetailCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (var i = 0; i < controls.length; i++) {
        $(controls[i]).appendTo($('<td>').appendTo(row));
    }

    initiateUIControls();
}

function Spartan_BR_Actions_True_DetailfnOpenAddRowPopUp() {
    var currentRowIndex = Spartan_BR_Actions_True_DetailTable.fnGetData().length;
    Spartan_BR_Actions_True_DetailfnClickAddRow();
    GetAddSpartan_BR_Actions_True_DetailPopup(currentRowIndex, 0);
}

function Spartan_BR_Actions_True_DetailEditRowPopup(rowIndex) {
    var Spartan_BR_Actions_True_DetailRowElement = "Spartan_BR_Actions_True_Detail_" + rowIndex.toString();
    var prevData = Spartan_BR_Actions_True_DetailTable.fnGetData(rowIndex);
    GetAddSpartan_BR_Actions_True_DetailPopup(rowIndex, 1);
    $('#Action_ClassificationPop').val(prevData.Action_Classification);
    $('#ActionPop').val(prevData.Action);
    $('#Action_ResultPop').val(prevData.Action_Result);
    $('#Parameter_1Pop').val(prevData.Parameter_1);
    $('#Parameter_2Pop').val(prevData.Parameter_2);
    $('#Parameter_3Pop').val(prevData.Parameter_3);
    $('#Parameter_4Pop').val(prevData.Parameter_4);
    $('#Parameter_5Pop').val(prevData.Parameter_5);

    initiateUIControls();

}

function Spartan_BR_Actions_True_DetailAddInsertRow() {
    if (Spartan_BR_Actions_True_DetailinsertRowCurrentIndex < 1)
    {
        Spartan_BR_Actions_True_DetailinsertRowCurrentIndex = 1;
    }
    return {
        ActionsTrueDetailId: null,
        IsInsertRow: true
        ,Action_Classification: ""
        ,Action: ""
        ,Action_Result: ""
        ,Parameter_1: ""
        ,Parameter_2: ""
        ,Parameter_3: ""
        ,Parameter_4: ""
        ,Parameter_5: ""

    }
}

function Spartan_BR_Actions_True_DetailfnClickAddRow() {
    Spartan_BR_Actions_True_DetailcountRowsChecked++;
    Spartan_BR_Actions_True_DetailTable
        .fnAddData(Spartan_BR_Actions_True_DetailAddInsertRow(), true);
    initiateUIControls();
}

function Spartan_BR_Actions_True_DetailClearGridData() {
    Spartan_BR_Actions_True_DetailData = [];
    Spartan_BR_Actions_True_DetaildeletedItem = [];
    Spartan_BR_Actions_True_DetailDataMain = [];
    Spartan_BR_Actions_True_DetailDataMainPages = [];
    Spartan_BR_Actions_True_DetailnewItemCount = 0;
    Spartan_BR_Actions_True_DetailmaxItemIndex = 0;
    $("#Spartan_BR_Actions_True_DetailGrid").DataTable().clear();
    $("#Spartan_BR_Actions_True_DetailGrid").DataTable().destroy();
}

//Used to Get Business Rule Information
function GetSpartan_BR_Actions_True_Detail() {
    var form_data = new FormData();
    for (var i = 0; i < Spartan_BR_Actions_True_DetailData.length; i++) {
        form_data.append('[' + i + '].ActionsTrueDetailId', Spartan_BR_Actions_True_DetailData[i].ActionsTrueDetailId);
        form_data.append('[' + i + '].Action_Classification', Spartan_BR_Actions_True_DetailData[i].Action_Classification);
        form_data.append('[' + i + '].Action', Spartan_BR_Actions_True_DetailData[i].Action);
        form_data.append('[' + i + '].Action_Result', Spartan_BR_Actions_True_DetailData[i].Action_Result);
        form_data.append('[' + i + '].Parameter_1', Spartan_BR_Actions_True_DetailData[i].Parameter_1);
        form_data.append('[' + i + '].Parameter_2', Spartan_BR_Actions_True_DetailData[i].Parameter_2);
        form_data.append('[' + i + '].Parameter_3', Spartan_BR_Actions_True_DetailData[i].Parameter_3);
        form_data.append('[' + i + '].Parameter_4', Spartan_BR_Actions_True_DetailData[i].Parameter_4);
        form_data.append('[' + i + '].Parameter_5', Spartan_BR_Actions_True_DetailData[i].Parameter_5);

        form_data.append('[' + i + '].Removed', Spartan_BR_Actions_True_DetailData[i].Removed);
    }
    return form_data;
}
function Spartan_BR_Actions_True_DetailInsertRowFromPopup(rowIndex) {
    var prevData = Spartan_BR_Actions_True_DetailTable.fnGetData(rowIndex);
    var data = Spartan_BR_Actions_True_DetailTable.fnGetNodes(rowIndex);
    var newData = {
        BusinessRuleId: prevData.BusinessRuleId,
        IsInsertRow: false
        ,Action_Classification: $('#dvAction_Classification').find('select').val()
        ,Action: $('#dvAction').find('select').val()
        ,Action_Result: $('#dvAction_Result').find('select').val()
        ,Parameter_1: $('#Parameter_1Pop').val()
        ,Parameter_2: $('#Parameter_2Pop').val()
        ,Parameter_3: $('#Parameter_3Pop').val()
        ,Parameter_4: $('#Parameter_4Pop').val()
        ,Parameter_5: $('#Parameter_5Pop').val()

    }

    Spartan_BR_Actions_True_DetailTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_BR_Actions_True_DetailrowCreationGrid(data, newData, rowIndex);
    $('#AddSpartan_BR_Actions_True_Detail-form').modal({ show: false });
    $('#AddSpartan_BR_Actions_True_Detail-form').modal('hide');
}
function Spartan_BR_Actions_True_DetailRemoveAddRow(rowIndex) {
    Spartan_BR_Actions_True_DetailTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Spartan_BR_Actions_True_Detail MultiRow
//Begin Declarations for Foreigns fields for Spartan_BR_Actions_False_Detail MultiRow
var Spartan_BR_Actions_False_DetailcountRowsChecked = 0;
function GetSpartan_BR_Actions_False_Detail_Spartan_BR_Action_ClassificationName(Id) {
    for (var i = 0; i < Spartan_BR_Actions_False_Detail_Spartan_BR_Action_ClassificationItems.length; i++) {
        if (Spartan_BR_Actions_False_Detail_Spartan_BR_Action_ClassificationItems[i].ClassificationId == Id) {
            return Spartan_BR_Actions_False_Detail_Spartan_BR_Action_ClassificationItems[i].Description;
        }
    }
    return "";
}

function GetSpartan_BR_Actions_False_Detail_Spartan_BR_Action_ClassificationDropDown() {
    var Spartan_BR_Actions_False_Detail_Spartan_BR_Action_ClassificationDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_BR_Actions_False_Detail_Spartan_BR_Action_ClassificationDropdown);

    for (var i = 0; i < Spartan_BR_Actions_False_Detail_Spartan_BR_Action_ClassificationItems.length; i++) {
        $('<option />', { value: Spartan_BR_Actions_False_Detail_Spartan_BR_Action_ClassificationItems[i].ClassificationId, text: Spartan_BR_Actions_False_Detail_Spartan_BR_Action_ClassificationItems[i].Description }).appendTo(Spartan_BR_Actions_False_Detail_Spartan_BR_Action_ClassificationDropdown);
    }
    return Spartan_BR_Actions_False_Detail_Spartan_BR_Action_ClassificationDropdown;
}
function GetSpartan_BR_Actions_False_Detail_Spartan_BR_ActionName(Id) {
    for (var i = 0; i < Spartan_BR_Actions_False_Detail_Spartan_BR_ActionItems.length; i++) {
        if (Spartan_BR_Actions_False_Detail_Spartan_BR_ActionItems[i].ActionId == Id) {
            return Spartan_BR_Actions_False_Detail_Spartan_BR_ActionItems[i].Description;
        }
    }
    return "";
}

function GetSpartan_BR_Actions_False_Detail_Spartan_BR_ActionDropDown() {
    var Spartan_BR_Actions_False_Detail_Spartan_BR_ActionDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_BR_Actions_False_Detail_Spartan_BR_ActionDropdown);

    for (var i = 0; i < Spartan_BR_Actions_False_Detail_Spartan_BR_ActionItems.length; i++) {
        $('<option />', { value: Spartan_BR_Actions_False_Detail_Spartan_BR_ActionItems[i].ActionId, text: Spartan_BR_Actions_False_Detail_Spartan_BR_ActionItems[i].Description }).appendTo(Spartan_BR_Actions_False_Detail_Spartan_BR_ActionDropdown);
    }
    return Spartan_BR_Actions_False_Detail_Spartan_BR_ActionDropdown;
}
function GetSpartan_BR_Actions_False_Detail_Spartan_BR_Action_ResultName(Id) {
    for (var i = 0; i < Spartan_BR_Actions_False_Detail_Spartan_BR_Action_ResultItems.length; i++) {
        if (Spartan_BR_Actions_False_Detail_Spartan_BR_Action_ResultItems[i].ActionResultId == Id) {
            return Spartan_BR_Actions_False_Detail_Spartan_BR_Action_ResultItems[i].Description;
        }
    }
    return "";
}

function GetSpartan_BR_Actions_False_Detail_Spartan_BR_Action_ResultDropDown() {
    var Spartan_BR_Actions_False_Detail_Spartan_BR_Action_ResultDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_BR_Actions_False_Detail_Spartan_BR_Action_ResultDropdown);

    for (var i = 0; i < Spartan_BR_Actions_False_Detail_Spartan_BR_Action_ResultItems.length; i++) {
        $('<option />', { value: Spartan_BR_Actions_False_Detail_Spartan_BR_Action_ResultItems[i].ActionResultId, text: Spartan_BR_Actions_False_Detail_Spartan_BR_Action_ResultItems[i].Description }).appendTo(Spartan_BR_Actions_False_Detail_Spartan_BR_Action_ResultDropdown);
    }
    return Spartan_BR_Actions_False_Detail_Spartan_BR_Action_ResultDropdown;
}


function GetInsertSpartan_BR_Actions_False_DetailRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $(GetSpartan_BR_Actions_False_Detail_Spartan_BR_Action_ClassificationDropDown()).addClass('Spartan_BR_Actions_False_Detail_Action_Classification').attr('id', 'Spartan_BR_Actions_False_Detail_Action_Classification_' + index);
    columnData[1] = $(GetSpartan_BR_Actions_False_Detail_Spartan_BR_ActionDropDown()).addClass('Spartan_BR_Actions_False_Detail_Action').attr('id', 'Spartan_BR_Actions_False_Detail_Action_' + index);
    columnData[2] = $(GetSpartan_BR_Actions_False_Detail_Spartan_BR_Action_ResultDropDown()).addClass('Spartan_BR_Actions_False_Detail_Action_Result').attr('id', 'Spartan_BR_Actions_False_Detail_Action_Result_' + index);
    columnData[3] = $($.parseHTML(inputData)).addClass('Spartan_BR_Actions_False_Detail_Parameter_1').attr('id', 'Spartan_BR_Actions_False_Detail_Parameter_1_' + index);
    columnData[4] = $($.parseHTML(inputData)).addClass('Spartan_BR_Actions_False_Detail_Parameter_2').attr('id', 'Spartan_BR_Actions_False_Detail_Parameter_2_' + index);
    columnData[5] = $($.parseHTML(inputData)).addClass('Spartan_BR_Actions_False_Detail_Parameter_3').attr('id', 'Spartan_BR_Actions_False_Detail_Parameter_3_' + index);
    columnData[6] = $($.parseHTML(inputData)).addClass('Spartan_BR_Actions_False_Detail_Parameter_4').attr('id', 'Spartan_BR_Actions_False_Detail_Parameter_4_' + index);
    columnData[7] = $($.parseHTML(inputData)).addClass('Spartan_BR_Actions_False_Detail_Parameter_5').attr('id', 'Spartan_BR_Actions_False_Detail_Parameter_5_' + index);


    initiateUIControls();
    return columnData;
}

function Spartan_BR_Actions_False_DetailInsertRow(rowIndex) {
    var prevData = Spartan_BR_Actions_False_DetailTable.fnGetData(rowIndex);
    var data = Spartan_BR_Actions_False_DetailTable.fnGetNodes(rowIndex);
    var newData = {
        ActionsFalseDetailId: prevData.ActionsFalseDetailId,
        IsInsertRow: false
        ,Action_Classification: data.childNodes[1].childNodes[0].value
        ,Action: data.childNodes[2].childNodes[0].value
        ,Action_Result: data.childNodes[3].childNodes[0].value
        ,Parameter_1: data.childNodes[4].childNodes[0].value
        ,Parameter_2: data.childNodes[5].childNodes[0].value
        ,Parameter_3: data.childNodes[6].childNodes[0].value
        ,Parameter_4: data.childNodes[7].childNodes[0].value
        ,Parameter_5: data.childNodes[8].childNodes[0].value

    }
    Spartan_BR_Actions_False_DetailTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_BR_Actions_False_DetailrowCreationGrid(data, newData, rowIndex);
    Spartan_BR_Actions_False_DetailcountRowsChecked--;	
}

function Spartan_BR_Actions_False_DetailCancelRow(rowIndex) {
    var prevData = Spartan_BR_Actions_False_DetailTable.fnGetData(rowIndex);
    var data = Spartan_BR_Actions_False_DetailTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Spartan_BR_Actions_False_DetailTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Spartan_BR_Actions_False_DetailrowCreationGrid(data, prevData, rowIndex);
    }
    Spartan_BR_Actions_False_DetailcountRowsChecked--;
}

function GetSpartan_BR_Actions_False_DetailFromDataTable() {
    var Spartan_BR_Actions_False_DetailData = [];
    var gridData = Spartan_BR_Actions_False_DetailTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Spartan_BR_Actions_False_DetailData.push({
                ActionsFalseDetailId: gridData[i].ActionsFalseDetailId
                ,Action_Classification: gridData[i].Action_Classification
                ,Action: gridData[i].Action
                ,Action_Result: gridData[i].Action_Result
                ,Parameter_1: gridData[i].Parameter_1
                ,Parameter_2: gridData[i].Parameter_2
                ,Parameter_3: gridData[i].Parameter_3
                ,Parameter_4: gridData[i].Parameter_4
                ,Parameter_5: gridData[i].Parameter_5

                ,Removed: false
            });
    }

    for (i = 0; i < removedSpartan_BR_Actions_False_DetailData.length; i++) {
        if (removedSpartan_BR_Actions_False_DetailData[i] != null && removedSpartan_BR_Actions_False_DetailData[i].ActionsFalseDetailId > 0)
            Spartan_BR_Actions_False_DetailData.push({
                ActionsFalseDetailId: removedSpartan_BR_Actions_False_DetailData[i].ActionsFalseDetailId
                ,Action_Classification: removedSpartan_BR_Action_ClassificationData[i].Action_Classification
                ,Action: removedSpartan_BR_ActionData[i].Action
                ,Action_Result: removedSpartan_BR_Action_ResultData[i].Action_Result
                ,Parameter_1: removedData[i].Parameter_1
                ,Parameter_2: removedData[i].Parameter_2
                ,Parameter_3: removedData[i].Parameter_3
                ,Parameter_4: removedData[i].Parameter_4
                ,Parameter_5: removedData[i].Parameter_5

                , Removed: true
            });
    }	

    return Spartan_BR_Actions_False_DetailData;
}

function Spartan_BR_Actions_False_DetailEditRow(rowIndex) {
    Spartan_BR_Actions_False_DetailcountRowsChecked++;
    var Spartan_BR_Actions_False_DetailRowElement = "Spartan_BR_Actions_False_Detail_" + rowIndex.toString();
    var prevData = Spartan_BR_Actions_False_DetailTable.fnGetData(rowIndex);
    var row = Spartan_BR_Actions_False_DetailTable.fnGetNodes(rowIndex);
    row.innerHTML = "";

    var controls = Spartan_BR_Actions_False_DetailGetUpdateRowControls(prevData);

    var abc = "if(dynamicFieldValidation('" + Spartan_BR_Actions_False_DetailRowElement + "')){ Spartan_BR_Actions_False_DetailInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Spartan_BR_Actions_False_DetailCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (var i = 0; i < controls.length; i++) {
        $(controls[i]).appendTo($('<td>').appendTo(row));
    }

    initiateUIControls();
}

function Spartan_BR_Actions_False_DetailfnOpenAddRowPopUp() {
    var currentRowIndex = Spartan_BR_Actions_False_DetailTable.fnGetData().length;
    Spartan_BR_Actions_False_DetailfnClickAddRow();
    GetAddSpartan_BR_Actions_False_DetailPopup(currentRowIndex, 0);
}

function Spartan_BR_Actions_False_DetailEditRowPopup(rowIndex) {
    var Spartan_BR_Actions_False_DetailRowElement = "Spartan_BR_Actions_False_Detail_" + rowIndex.toString();
    var prevData = Spartan_BR_Actions_False_DetailTable.fnGetData(rowIndex);
    GetAddSpartan_BR_Actions_False_DetailPopup(rowIndex, 1);
    $('#Action_ClassificationPop').val(prevData.Action_Classification);
    $('#ActionPop').val(prevData.Action);
    $('#Action_ResultPop').val(prevData.Action_Result);
    $('#Parameter_1Pop').val(prevData.Parameter_1);
    $('#Parameter_2Pop').val(prevData.Parameter_2);
    $('#Parameter_3Pop').val(prevData.Parameter_3);
    $('#Parameter_4Pop').val(prevData.Parameter_4);
    $('#Parameter_5Pop').val(prevData.Parameter_5);

    initiateUIControls();

}

function Spartan_BR_Actions_False_DetailAddInsertRow() {
    if (Spartan_BR_Actions_False_DetailinsertRowCurrentIndex < 1)
    {
        Spartan_BR_Actions_False_DetailinsertRowCurrentIndex = 1;
    }
    return {
        ActionsFalseDetailId: null,
        IsInsertRow: true
        ,Action_Classification: ""
        ,Action: ""
        ,Action_Result: ""
        ,Parameter_1: ""
        ,Parameter_2: ""
        ,Parameter_3: ""
        ,Parameter_4: ""
        ,Parameter_5: ""

    }
}

function Spartan_BR_Actions_False_DetailfnClickAddRow() {
    Spartan_BR_Actions_False_DetailcountRowsChecked++;
    Spartan_BR_Actions_False_DetailTable
        .fnAddData(Spartan_BR_Actions_False_DetailAddInsertRow(), true);
    initiateUIControls();
}

function Spartan_BR_Actions_False_DetailClearGridData() {
    Spartan_BR_Actions_False_DetailData = [];
    Spartan_BR_Actions_False_DetaildeletedItem = [];
    Spartan_BR_Actions_False_DetailDataMain = [];
    Spartan_BR_Actions_False_DetailDataMainPages = [];
    Spartan_BR_Actions_False_DetailnewItemCount = 0;
    Spartan_BR_Actions_False_DetailmaxItemIndex = 0;
    $("#Spartan_BR_Actions_False_DetailGrid").DataTable().clear();
    $("#Spartan_BR_Actions_False_DetailGrid").DataTable().destroy();
}

//Used to Get Business Rule Information
function GetSpartan_BR_Actions_False_Detail() {
    var form_data = new FormData();
    for (var i = 0; i < Spartan_BR_Actions_False_DetailData.length; i++) {
        form_data.append('[' + i + '].ActionsFalseDetailId', Spartan_BR_Actions_False_DetailData[i].ActionsFalseDetailId);
        form_data.append('[' + i + '].Action_Classification', Spartan_BR_Actions_False_DetailData[i].Action_Classification);
        form_data.append('[' + i + '].Action', Spartan_BR_Actions_False_DetailData[i].Action);
        form_data.append('[' + i + '].Action_Result', Spartan_BR_Actions_False_DetailData[i].Action_Result);
        form_data.append('[' + i + '].Parameter_1', Spartan_BR_Actions_False_DetailData[i].Parameter_1);
        form_data.append('[' + i + '].Parameter_2', Spartan_BR_Actions_False_DetailData[i].Parameter_2);
        form_data.append('[' + i + '].Parameter_3', Spartan_BR_Actions_False_DetailData[i].Parameter_3);
        form_data.append('[' + i + '].Parameter_4', Spartan_BR_Actions_False_DetailData[i].Parameter_4);
        form_data.append('[' + i + '].Parameter_5', Spartan_BR_Actions_False_DetailData[i].Parameter_5);

        form_data.append('[' + i + '].Removed', Spartan_BR_Actions_False_DetailData[i].Removed);
    }
    return form_data;
}
function Spartan_BR_Actions_False_DetailInsertRowFromPopup(rowIndex) {
    var prevData = Spartan_BR_Actions_False_DetailTable.fnGetData(rowIndex);
    var data = Spartan_BR_Actions_False_DetailTable.fnGetNodes(rowIndex);
    var newData = {
        BusinessRuleId: prevData.BusinessRuleId,
        IsInsertRow: false
        ,Action_Classification: $('#dvAction_Classification').find('select').val()
        ,Action: $('#dvAction').find('select').val()
        ,Action_Result: $('#dvAction_Result').find('select').val()
        ,Parameter_1: $('#Parameter_1Pop').val()
        ,Parameter_2: $('#Parameter_2Pop').val()
        ,Parameter_3: $('#Parameter_3Pop').val()
        ,Parameter_4: $('#Parameter_4Pop').val()
        ,Parameter_5: $('#Parameter_5Pop').val()

    }

    Spartan_BR_Actions_False_DetailTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_BR_Actions_False_DetailrowCreationGrid(data, newData, rowIndex);
    $('#AddSpartan_BR_Actions_False_Detail-form').modal({ show: false });
    $('#AddSpartan_BR_Actions_False_Detail-form').modal('hide');
}
function Spartan_BR_Actions_False_DetailRemoveAddRow(rowIndex) {
    Spartan_BR_Actions_False_DetailTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Spartan_BR_Actions_False_Detail MultiRow
//Begin Declarations for Foreigns fields for Spartan_BR_Modifications_Log MultiRow
var Spartan_BR_Modifications_LogcountRowsChecked = 0;


function GetInsertSpartan_BR_Modifications_LogRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $($.parseHTML(GetGridDatePicker())).addClass('Spartan_BR_Modifications_Log_Modification_Date').attr('id', 'Spartan_BR_Modifications_Log_Modification_Date_' + index);
    columnData[1] = $($.parseHTML(GetGridTimePicker())).addClass('Spartan_BR_Modifications_Log_Modification_Hour').attr('id', 'Spartan_BR_Modifications_Log_Modification_Hour_' + index);
    columnData[2] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Spartan_BR_Modifications_Log_Modification_User').attr('id', 'Spartan_BR_Modifications_Log_Modification_User_' + index);
    columnData[3] = $($.parseHTML(inputData)).addClass('Spartan_BR_Modifications_Log_Comments').attr('id', 'Spartan_BR_Modifications_Log_Comments_' + index);
    columnData[4] = $($.parseHTML(inputData)).addClass('Spartan_BR_Modifications_Log_Implementation_Code').attr('id', 'Spartan_BR_Modifications_Log_Implementation_Code_' + index);


    initiateUIControls();
    return columnData;
}

function Spartan_BR_Modifications_LogInsertRow(rowIndex) {
    var prevData = Spartan_BR_Modifications_LogTable.fnGetData(rowIndex);
    var data = Spartan_BR_Modifications_LogTable.fnGetNodes(rowIndex);
    var newData = {
        ModificationId: prevData.ModificationId,
        IsInsertRow: false
        ,Modification_Date: data.childNodes[1].childNodes[0].value
        ,Modification_Hour: data.childNodes[2].childNodes[0].value
        ,Modification_User: data.childNodes[3].childNodes[0].value
        ,Comments: data.childNodes[4].childNodes[0].value
        ,Implementation_Code: data.childNodes[5].childNodes[0].value

    }
    Spartan_BR_Modifications_LogTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_BR_Modifications_LogrowCreationGrid(data, newData, rowIndex);
    Spartan_BR_Modifications_LogcountRowsChecked--;	
}

function Spartan_BR_Modifications_LogCancelRow(rowIndex) {
    var prevData = Spartan_BR_Modifications_LogTable.fnGetData(rowIndex);
    var data = Spartan_BR_Modifications_LogTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Spartan_BR_Modifications_LogTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Spartan_BR_Modifications_LogrowCreationGrid(data, prevData, rowIndex);
    }
    Spartan_BR_Modifications_LogcountRowsChecked--;
}

function GetSpartan_BR_Modifications_LogFromDataTable() {
    var Spartan_BR_Modifications_LogData = [];
    var gridData = Spartan_BR_Modifications_LogTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Spartan_BR_Modifications_LogData.push({
                ModificationId: gridData[i].ModificationId
                ,Modification_Date: gridData[i].Modification_Date
                ,Modification_Hour: gridData[i].Modification_Hour
                ,Modification_User: gridData[i].Modification_User
                ,Comments: gridData[i].Comments
                ,Implementation_Code: gridData[i].Implementation_Code

                ,Removed: false
            });
    }

    for (i = 0; i < removedSpartan_BR_Modifications_LogData.length; i++) {
        if (removedSpartan_BR_Modifications_LogData[i] != null && removedSpartan_BR_Modifications_LogData[i].ModificationId > 0)
            Spartan_BR_Modifications_LogData.push({
                ModificationId: removedSpartan_BR_Modifications_LogData[i].ModificationId
                ,Modification_Date: removedData[i].Modification_Date
                ,Modification_Hour: removedData[i].Modification_Hour
                ,Modification_User: removedData[i].Modification_User
                ,Comments: removedData[i].Comments
                ,Implementation_Code: removedData[i].Implementation_Code

                , Removed: true
            });
    }	

    return Spartan_BR_Modifications_LogData;
}

function Spartan_BR_Modifications_LogEditRow(rowIndex) {
    Spartan_BR_Modifications_LogcountRowsChecked++;
    var Spartan_BR_Modifications_LogRowElement = "Spartan_BR_Modifications_Log_" + rowIndex.toString();
    var prevData = Spartan_BR_Modifications_LogTable.fnGetData(rowIndex);
    var row = Spartan_BR_Modifications_LogTable.fnGetNodes(rowIndex);
    row.innerHTML = "";

    var controls = Spartan_BR_Modifications_LogGetUpdateRowControls(prevData);

    var abc = "if(dynamicFieldValidation('" + Spartan_BR_Modifications_LogRowElement + "')){ Spartan_BR_Modifications_LogInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Spartan_BR_Modifications_LogCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (var i = 0; i < controls.length; i++) {
        $(controls[i]).appendTo($('<td>').appendTo(row));
    }

    initiateUIControls();
}

function Spartan_BR_Modifications_LogfnOpenAddRowPopUp() {
    var currentRowIndex = Spartan_BR_Modifications_LogTable.fnGetData().length;
    Spartan_BR_Modifications_LogfnClickAddRow();
    GetAddSpartan_BR_Modifications_LogPopup(currentRowIndex, 0);
}

function Spartan_BR_Modifications_LogEditRowPopup(rowIndex) {
    var Spartan_BR_Modifications_LogRowElement = "Spartan_BR_Modifications_Log_" + rowIndex.toString();
    var prevData = Spartan_BR_Modifications_LogTable.fnGetData(rowIndex);
    GetAddSpartan_BR_Modifications_LogPopup(rowIndex, 1);
    $('#Modification_DatePop').val(prevData.Modification_Date);
    $('#Modification_HourPop').val(prevData.Modification_Hour);
    $('#Modification_UserPop').val(prevData.Modification_User);
    $('#CommentsPop').val(prevData.Comments);
    $('#Implementation_CodePop').val(prevData.Implementation_Code);

    initiateUIControls();

}

function Spartan_BR_Modifications_LogAddInsertRow() {
    if (Spartan_BR_Modifications_LoginsertRowCurrentIndex < 1)
    {
        Spartan_BR_Modifications_LoginsertRowCurrentIndex = 1;
    }
    return {
        ModificationId: null,
        IsInsertRow: true
        ,Modification_Date: ""
        ,Modification_Hour: ""
        ,Modification_User: ""
        ,Comments: ""
        ,Implementation_Code: ""

    }
}

function Spartan_BR_Modifications_LogfnClickAddRow() {
    Spartan_BR_Modifications_LogcountRowsChecked++;
    Spartan_BR_Modifications_LogTable
        .fnAddData(Spartan_BR_Modifications_LogAddInsertRow(), true);
    initiateUIControls();
}

function Spartan_BR_Modifications_LogClearGridData() {
    Spartan_BR_Modifications_LogData = [];
    Spartan_BR_Modifications_LogdeletedItem = [];
    Spartan_BR_Modifications_LogDataMain = [];
    Spartan_BR_Modifications_LogDataMainPages = [];
    Spartan_BR_Modifications_LognewItemCount = 0;
    Spartan_BR_Modifications_LogmaxItemIndex = 0;
    $("#Spartan_BR_Modifications_LogGrid").DataTable().clear();
    $("#Spartan_BR_Modifications_LogGrid").DataTable().destroy();
}

//Used to Get Business Rule Information
function GetSpartan_BR_Modifications_Log() {
    var form_data = new FormData();
    for (var i = 0; i < Spartan_BR_Modifications_LogData.length; i++) {
        form_data.append('[' + i + '].ModificationId', Spartan_BR_Modifications_LogData[i].ModificationId);
        form_data.append('[' + i + '].Modification_Date', Spartan_BR_Modifications_LogData[i].Modification_Date);
        form_data.append('[' + i + '].Modification_Hour', Spartan_BR_Modifications_LogData[i].Modification_Hour);
        form_data.append('[' + i + '].Modification_User', Spartan_BR_Modifications_LogData[i].Modification_User);
        form_data.append('[' + i + '].Comments', Spartan_BR_Modifications_LogData[i].Comments);
        form_data.append('[' + i + '].Implementation_Code', Spartan_BR_Modifications_LogData[i].Implementation_Code);

        form_data.append('[' + i + '].Removed', Spartan_BR_Modifications_LogData[i].Removed);
    }
    return form_data;
}
function Spartan_BR_Modifications_LogInsertRowFromPopup(rowIndex) {
    var prevData = Spartan_BR_Modifications_LogTable.fnGetData(rowIndex);
    var data = Spartan_BR_Modifications_LogTable.fnGetNodes(rowIndex);
    var newData = {
        BusinessRuleId: prevData.BusinessRuleId,
        IsInsertRow: false
        ,Modification_Date: $('#Modification_DatePop').val()
        ,Modification_Hour: $('#Modification_HourPop').val()
        ,Modification_User: $('#Modification_UserPop').val()
        ,Comments: $('#CommentsPop').val()
        ,Implementation_Code: $('#Implementation_CodePop').val()

    }

    Spartan_BR_Modifications_LogTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_BR_Modifications_LogrowCreationGrid(data, newData, rowIndex);
    $('#AddSpartan_BR_Modifications_Log-form').modal({ show: false });
    $('#AddSpartan_BR_Modifications_Log-form').modal('hide');
}
function Spartan_BR_Modifications_LogRemoveAddRow(rowIndex) {
    Spartan_BR_Modifications_LogTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Spartan_BR_Modifications_Log MultiRow


$(function () {
    function Spartan_BR_Scope_DetailinitializeMainArray(totalCount) {
        if (Spartan_BR_Scope_DetailDataMain.length != totalCount && !Spartan_BR_Scope_DetailDataMainInitialized) {
            Spartan_BR_Scope_DetailDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Spartan_BR_Scope_DetailDataMain[i] = null;
            }
        }
    }
    function Spartan_BR_Scope_DetailremoveFromMainArray() {
        for (var j = 0; j < Spartan_BR_Scope_DetaildeletedItem.length; j++) {
            for (var i = 0; i < Spartan_BR_Scope_DetailDataMain.length; i++) {
                if (Spartan_BR_Scope_DetailDataMain[i] != null && Spartan_BR_Scope_DetailDataMain[i].Id == Spartan_BR_Scope_DetaildeletedItem[j]) {
                    hSpartan_BR_Scope_DetailDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Spartan_BR_Scope_DetailcopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Spartan_BR_Scope_DetailDataMain.length; i++) {
            data[i] = Spartan_BR_Scope_DetailDataMain[i];

        }
        return data;
    }
    function Spartan_BR_Scope_DetailgetNewResult() {
        var newData = copyMainSpartan_BR_Scope_DetailArray();

        for (var i = 0; i < Spartan_BR_Scope_DetailData.length; i++) {
            if (Spartan_BR_Scope_DetailData[i].Removed == null || Spartan_BR_Scope_DetailData[i].Removed == false) {
                newData.splice(0, 0, Spartan_BR_Scope_DetailData[i]);
            }
        }
        return newData;
    }
    function Spartan_BR_Scope_DetailpushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Spartan_BR_Scope_DetailDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Spartan_BR_Scope_DetailDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Spartan_BR_Operation_DetailinitializeMainArray(totalCount) {
        if (Spartan_BR_Operation_DetailDataMain.length != totalCount && !Spartan_BR_Operation_DetailDataMainInitialized) {
            Spartan_BR_Operation_DetailDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Spartan_BR_Operation_DetailDataMain[i] = null;
            }
        }
    }
    function Spartan_BR_Operation_DetailremoveFromMainArray() {
        for (var j = 0; j < Spartan_BR_Operation_DetaildeletedItem.length; j++) {
            for (var i = 0; i < Spartan_BR_Operation_DetailDataMain.length; i++) {
                if (Spartan_BR_Operation_DetailDataMain[i] != null && Spartan_BR_Operation_DetailDataMain[i].Id == Spartan_BR_Operation_DetaildeletedItem[j]) {
                    hSpartan_BR_Operation_DetailDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Spartan_BR_Operation_DetailcopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Spartan_BR_Operation_DetailDataMain.length; i++) {
            data[i] = Spartan_BR_Operation_DetailDataMain[i];

        }
        return data;
    }
    function Spartan_BR_Operation_DetailgetNewResult() {
        var newData = copyMainSpartan_BR_Operation_DetailArray();

        for (var i = 0; i < Spartan_BR_Operation_DetailData.length; i++) {
            if (Spartan_BR_Operation_DetailData[i].Removed == null || Spartan_BR_Operation_DetailData[i].Removed == false) {
                newData.splice(0, 0, Spartan_BR_Operation_DetailData[i]);
            }
        }
        return newData;
    }
    function Spartan_BR_Operation_DetailpushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Spartan_BR_Operation_DetailDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Spartan_BR_Operation_DetailDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Spartan_BR_Process_Event_DetailinitializeMainArray(totalCount) {
        if (Spartan_BR_Process_Event_DetailDataMain.length != totalCount && !Spartan_BR_Process_Event_DetailDataMainInitialized) {
            Spartan_BR_Process_Event_DetailDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Spartan_BR_Process_Event_DetailDataMain[i] = null;
            }
        }
    }
    function Spartan_BR_Process_Event_DetailremoveFromMainArray() {
        for (var j = 0; j < Spartan_BR_Process_Event_DetaildeletedItem.length; j++) {
            for (var i = 0; i < Spartan_BR_Process_Event_DetailDataMain.length; i++) {
                if (Spartan_BR_Process_Event_DetailDataMain[i] != null && Spartan_BR_Process_Event_DetailDataMain[i].Id == Spartan_BR_Process_Event_DetaildeletedItem[j]) {
                    hSpartan_BR_Process_Event_DetailDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Spartan_BR_Process_Event_DetailcopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Spartan_BR_Process_Event_DetailDataMain.length; i++) {
            data[i] = Spartan_BR_Process_Event_DetailDataMain[i];

        }
        return data;
    }
    function Spartan_BR_Process_Event_DetailgetNewResult() {
        var newData = copyMainSpartan_BR_Process_Event_DetailArray();

        for (var i = 0; i < Spartan_BR_Process_Event_DetailData.length; i++) {
            if (Spartan_BR_Process_Event_DetailData[i].Removed == null || Spartan_BR_Process_Event_DetailData[i].Removed == false) {
                newData.splice(0, 0, Spartan_BR_Process_Event_DetailData[i]);
            }
        }
        return newData;
    }
    function Spartan_BR_Process_Event_DetailpushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Spartan_BR_Process_Event_DetailDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Spartan_BR_Process_Event_DetailDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Spartan_BR_Conditions_DetailinitializeMainArray(totalCount) {
        if (Spartan_BR_Conditions_DetailDataMain.length != totalCount && !Spartan_BR_Conditions_DetailDataMainInitialized) {
            Spartan_BR_Conditions_DetailDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Spartan_BR_Conditions_DetailDataMain[i] = null;
            }
        }
    }
    function Spartan_BR_Conditions_DetailremoveFromMainArray() {
        for (var j = 0; j < Spartan_BR_Conditions_DetaildeletedItem.length; j++) {
            for (var i = 0; i < Spartan_BR_Conditions_DetailDataMain.length; i++) {
                if (Spartan_BR_Conditions_DetailDataMain[i] != null && Spartan_BR_Conditions_DetailDataMain[i].Id == Spartan_BR_Conditions_DetaildeletedItem[j]) {
                    hSpartan_BR_Conditions_DetailDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Spartan_BR_Conditions_DetailcopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Spartan_BR_Conditions_DetailDataMain.length; i++) {
            data[i] = Spartan_BR_Conditions_DetailDataMain[i];

        }
        return data;
    }
    function Spartan_BR_Conditions_DetailgetNewResult() {
        var newData = copyMainSpartan_BR_Conditions_DetailArray();

        for (var i = 0; i < Spartan_BR_Conditions_DetailData.length; i++) {
            if (Spartan_BR_Conditions_DetailData[i].Removed == null || Spartan_BR_Conditions_DetailData[i].Removed == false) {
                newData.splice(0, 0, Spartan_BR_Conditions_DetailData[i]);
            }
        }
        return newData;
    }
    function Spartan_BR_Conditions_DetailpushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Spartan_BR_Conditions_DetailDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Spartan_BR_Conditions_DetailDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Spartan_BR_Actions_True_DetailinitializeMainArray(totalCount) {
        if (Spartan_BR_Actions_True_DetailDataMain.length != totalCount && !Spartan_BR_Actions_True_DetailDataMainInitialized) {
            Spartan_BR_Actions_True_DetailDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Spartan_BR_Actions_True_DetailDataMain[i] = null;
            }
        }
    }
    function Spartan_BR_Actions_True_DetailremoveFromMainArray() {
        for (var j = 0; j < Spartan_BR_Actions_True_DetaildeletedItem.length; j++) {
            for (var i = 0; i < Spartan_BR_Actions_True_DetailDataMain.length; i++) {
                if (Spartan_BR_Actions_True_DetailDataMain[i] != null && Spartan_BR_Actions_True_DetailDataMain[i].Id == Spartan_BR_Actions_True_DetaildeletedItem[j]) {
                    hSpartan_BR_Actions_True_DetailDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Spartan_BR_Actions_True_DetailcopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Spartan_BR_Actions_True_DetailDataMain.length; i++) {
            data[i] = Spartan_BR_Actions_True_DetailDataMain[i];

        }
        return data;
    }
    function Spartan_BR_Actions_True_DetailgetNewResult() {
        var newData = copyMainSpartan_BR_Actions_True_DetailArray();

        for (var i = 0; i < Spartan_BR_Actions_True_DetailData.length; i++) {
            if (Spartan_BR_Actions_True_DetailData[i].Removed == null || Spartan_BR_Actions_True_DetailData[i].Removed == false) {
                newData.splice(0, 0, Spartan_BR_Actions_True_DetailData[i]);
            }
        }
        return newData;
    }
    function Spartan_BR_Actions_True_DetailpushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Spartan_BR_Actions_True_DetailDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Spartan_BR_Actions_True_DetailDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Spartan_BR_Actions_False_DetailinitializeMainArray(totalCount) {
        if (Spartan_BR_Actions_False_DetailDataMain.length != totalCount && !Spartan_BR_Actions_False_DetailDataMainInitialized) {
            Spartan_BR_Actions_False_DetailDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Spartan_BR_Actions_False_DetailDataMain[i] = null;
            }
        }
    }
    function Spartan_BR_Actions_False_DetailremoveFromMainArray() {
        for (var j = 0; j < Spartan_BR_Actions_False_DetaildeletedItem.length; j++) {
            for (var i = 0; i < Spartan_BR_Actions_False_DetailDataMain.length; i++) {
                if (Spartan_BR_Actions_False_DetailDataMain[i] != null && Spartan_BR_Actions_False_DetailDataMain[i].Id == Spartan_BR_Actions_False_DetaildeletedItem[j]) {
                    hSpartan_BR_Actions_False_DetailDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Spartan_BR_Actions_False_DetailcopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Spartan_BR_Actions_False_DetailDataMain.length; i++) {
            data[i] = Spartan_BR_Actions_False_DetailDataMain[i];

        }
        return data;
    }
    function Spartan_BR_Actions_False_DetailgetNewResult() {
        var newData = copyMainSpartan_BR_Actions_False_DetailArray();

        for (var i = 0; i < Spartan_BR_Actions_False_DetailData.length; i++) {
            if (Spartan_BR_Actions_False_DetailData[i].Removed == null || Spartan_BR_Actions_False_DetailData[i].Removed == false) {
                newData.splice(0, 0, Spartan_BR_Actions_False_DetailData[i]);
            }
        }
        return newData;
    }
    function Spartan_BR_Actions_False_DetailpushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Spartan_BR_Actions_False_DetailDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Spartan_BR_Actions_False_DetailDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Spartan_BR_Modifications_LoginitializeMainArray(totalCount) {
        if (Spartan_BR_Modifications_LogDataMain.length != totalCount && !Spartan_BR_Modifications_LogDataMainInitialized) {
            Spartan_BR_Modifications_LogDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Spartan_BR_Modifications_LogDataMain[i] = null;
            }
        }
    }
    function Spartan_BR_Modifications_LogremoveFromMainArray() {
        for (var j = 0; j < Spartan_BR_Modifications_LogdeletedItem.length; j++) {
            for (var i = 0; i < Spartan_BR_Modifications_LogDataMain.length; i++) {
                if (Spartan_BR_Modifications_LogDataMain[i] != null && Spartan_BR_Modifications_LogDataMain[i].Id == Spartan_BR_Modifications_LogdeletedItem[j]) {
                    hSpartan_BR_Modifications_LogDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Spartan_BR_Modifications_LogcopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Spartan_BR_Modifications_LogDataMain.length; i++) {
            data[i] = Spartan_BR_Modifications_LogDataMain[i];

        }
        return data;
    }
    function Spartan_BR_Modifications_LoggetNewResult() {
        var newData = copyMainSpartan_BR_Modifications_LogArray();

        for (var i = 0; i < Spartan_BR_Modifications_LogData.length; i++) {
            if (Spartan_BR_Modifications_LogData[i].Removed == null || Spartan_BR_Modifications_LogData[i].Removed == false) {
                newData.splice(0, 0, Spartan_BR_Modifications_LogData[i]);
            }
        }
        return newData;
    }
    function Spartan_BR_Modifications_LogpushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Spartan_BR_Modifications_LogDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Spartan_BR_Modifications_LogDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }

});

//Grid GetAutocomplete

//Grid GetAutocomplete

//Grid GetAutocomplete

//Grid GetAutocomplete

//Grid GetAutocomplete

//Grid GetAutocomplete

//Grid GetAutocomplete



function getDropdown(elementKey) {
    var dropDown = '<select id="' + elementKey + '" class="form-control"><option value="">--Select--</option></select>';
    return dropDown;
}

function GetGridDatePicker() {
    return "<input type='text' class='fullWidth gridDatePicker xyz form-control' readonly='readonly'>";
}
function GetGridTimePicker() {
    return "<input type='text' class='fullWidth gridTimePicker form-control' readonly='readonly' data-autoclose='true'>";
}
function GetGridTextArea() {
    return "<textarea rows='2'></textarea>";
}
function GetGridCheckBox() {
    return " <input type='checkbox' class='fullWidth'> ";
}
function GetFileUploader() {
    return "<input type='file' class='fullWidth'>";
}

function GetGridAutoComplete(data,field) {
    
    var dataMain = data == null ? "Select" : data;
    
    return "<select class='" + field + " form-control' style='width: 250px'><option>" + dataMain + "</option></select>";
}

function ClearControls() {
    $("#ReferenceBusinessRuleId").val("0");
    $('#CreateSpartan_Business_Rule')[0].reset();
    ClearFormControls();
    $("#BusinessRuleIdId").val("0");
                Spartan_BR_Scope_DetailClearGridData();
                Spartan_BR_Operation_DetailClearGridData();
                Spartan_BR_Process_Event_DetailClearGridData();
                Spartan_BR_Conditions_DetailClearGridData();
                Spartan_BR_Actions_True_DetailClearGridData();
                Spartan_BR_Actions_False_DetailClearGridData();
                Spartan_BR_Modifications_LogClearGridData();

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreateSpartan_Business_Rule').trigger('reset');
    $('#CreateSpartan_Business_Rule').find(':input').each(function () {
        switch (this.type) {
            case 'password':
            case 'number':
            case 'select-multiple':
            case 'select-one':
            case 'select':
            case 'text':
            case 'textarea':
                $(this).val('');
                break;
            case 'checkbox':
            case 'radio':
                this.checked = false;
        }
    });
}
function CheckValidation() {
    var $myForm = $('#CreateSpartan_Business_Rule');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    if (Spartan_BR_Scope_DetailcountRowsChecked > 0)
    {
		showNotification('Ha dejado un renglón pendiente de guardar en Scope', "warning");
        return false;
    }
    if (Spartan_BR_Operation_DetailcountRowsChecked > 0)
    {
		showNotification('Ha dejado un renglón pendiente de guardar en Operation', "warning");
        return false;
    }
    if (Spartan_BR_Process_Event_DetailcountRowsChecked > 0)
    {
		showNotification('Ha dejado un renglón pendiente de guardar en Process Event', "warning");								
        return false;
    }
    if (Spartan_BR_Conditions_DetailcountRowsChecked > 0)
    {
		showNotification('Ha dejado un renglón pendiente de guardar en Conditions', "warning");
        return false;
    }
    if (Spartan_BR_Actions_True_DetailcountRowsChecked > 0)
    {
		showNotification('Ha dejado un renglón pendiente de guardar en Actions if Fulfills', "warning");
        return false;
    }
    if (Spartan_BR_Actions_False_DetailcountRowsChecked > 0)
    {
		showNotification('Ha dejado un renglón pendiente de guardar en Actions if not Fulfills', "warning");
        return false;
    }
    if (Spartan_BR_Modifications_LogcountRowsChecked > 0)
    {        
		showNotification('Ha dejado un renglón pendiente de guardar en Modifications Log', "warning");
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblBusinessRuleId").text("0");
}
$(document).ready(function () {
    $("form#CreateSpartan_Business_Rule").submit(function (e) {
        e.preventDefault();
        return false;
    });
    $("#Cancelar").click(function () {
        BackToGrid();
    });
    $("#Guardar").click(function () {
        if (CheckValidation())
            SendSpartan_Business_RuleData(function () {
                BackToGrid();
            });
    });
    $("#GuardarYNuevo").click(function () {
        if (CheckValidation()) {
            SendSpartan_Business_RuleData(function () {
                ClearControls();
                ClearAttachmentsDiv();
                ResetClaveLabel();
                getSpartan_BR_Scope_DetailData();
                getSpartan_BR_Operation_DetailData();
                getSpartan_BR_Process_Event_DetailData();
                getSpartan_BR_Conditions_DetailData();
                getSpartan_BR_Actions_True_DetailData();
                getSpartan_BR_Actions_False_DetailData();
                getSpartan_BR_Modifications_LogData();

            });
        }
    });
    $("#GuardarYCopia").click(function () {
        if (CheckValidation())
            SendSpartan_Business_RuleData(function (currentId) {
                $("#BusinessRuleIdId").val("0");
                Spartan_BR_Scope_DetailClearGridData();
                Spartan_BR_Operation_DetailClearGridData();
                Spartan_BR_Process_Event_DetailClearGridData();
                Spartan_BR_Conditions_DetailClearGridData();
                Spartan_BR_Actions_True_DetailClearGridData();
                Spartan_BR_Actions_False_DetailClearGridData();
                Spartan_BR_Modifications_LogClearGridData();

                ResetClaveLabel();
                $("#ReferenceBusinessRuleId").val(currentId);
                getSpartan_BR_Scope_DetailData();
                getSpartan_BR_Operation_DetailData();
                getSpartan_BR_Process_Event_DetailData();
                getSpartan_BR_Conditions_DetailData();
                getSpartan_BR_Actions_True_DetailData();
                getSpartan_BR_Actions_False_DetailData();
                getSpartan_BR_Modifications_LogData();

            });
    });
});
var mainElementObject;
var childElementObject;
function DisplayElementAttributes(data) {
}
function setRequired(elementNumber, element, elementType) {
    //debugger;
    if (elementType == "1") {
        mainElementObject[elementNumber].IsRequired = (mainElementObject[elementNumber].IsRequired == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[elementNumber].IsRequired == true ? "Images/Required.png" : "Images/Not-Required.png") + "");
        $(element).attr('title', (mainElementObject[elementNumber].IsRequired == true ? 'Required' : 'Not Required'));
        if (!mainElementObject[elementNumber].IsVisible && mainElementObject[elementNumber].IsRequired) {
            setVisible(elementNumber, $(element).parent().parent().find('div.visibleAttribute').find('a'), elementType);
        }
        if (mainElementObject[elementNumber].IsReadOnly && mainElementObject[elementNumber].IsRequired && mainElementObject[elementNumber].DefaultValue == '') {
            setReadOnly(elementNumber, $(element).parent().parent().find('div.readOnlyAttribute').find('a'), elementType);
        }
    } else {
        childElementObject[elementNumber].IsRequired = (childElementObject[elementNumber].IsRequired == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (childElementObject[elementNumber].IsRequired == true ? "Images/Required.png" : "Images/Not-Required.png") + "");
        $(element).attr('title', (childElementObject[elementNumber].IsRequired == true ? 'Required' : 'Not Required'));
        if (!childElementObject[elementNumber].IsVisible && childElementObject[elementNumber].IsRequired) {
            setVisible(elementNumber, $(element).parent().parent().find('div.visibleAttribute').find('a'), elementType);
        }
        if (childElementObject[elementNumber].IsReadOnly && childElementObject[elementNumber].IsRequired && childElementObject[elementNumber].DefaultValue == '') {
            setReadOnly(elementNumber, $(element).parent().parent().find('div.readOnlyAttribute').find('a'), elementType);
        }
    }
}
function setVisible(elementNumber, element, elementType) {
    if (elementType == "1") {
        if (mainElementObject[elementNumber].IsRequired && mainElementObject[elementNumber].DefaultValue == '' && mainElementObject[elementNumber].IsVisible) {
            showNotification("can not set in visible, as this field is required and has no default value", "error");
            return;
        }
        mainElementObject[elementNumber].IsVisible = (mainElementObject[elementNumber].IsVisible == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[elementNumber].IsVisible == true ? "Images/Visible.png" : "Images/inVisible.png") + "");
        $(element).attr('title', (mainElementObject[elementNumber].IsVisible == true ? 'Visible' : 'In Visible'));
    } else {
        if (childElementObject[elementNumber].IsRequired && childElementObject[elementNumber].DefaultValue == '' && childElementObject[elementNumber].IsVisible) {
            showNotification("can not set in visible, as this field is required and has no default value", "error");
            return;
        }
        childElementObject[elementNumber].IsVisible = (childElementObject[elementNumber].IsVisible == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (childElementObject[elementNumber].IsVisible == true ? "Images/Visible.png" : "Images/inVisible.png") + "");
        $(element).attr('title', (childElementObject[elementNumber].IsVisible == true ? 'Visible' : 'In Visible'));
    }
}
function setReadOnly(elementNumber, element, elementType) {
    if (elementType == "1") {
        if (mainElementObject[elementNumber].IsRequired && mainElementObject[elementNumber].DefaultValue == '' && !mainElementObject[elementNumber].IsReadOnly) {
            showNotification("can not set readonly, as this field is required and has no default value", "error");
            return;
        }
        mainElementObject[elementNumber].IsReadOnly = (mainElementObject[elementNumber].IsReadOnly == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[elementNumber].IsReadOnly == true ? "Images/Disabled.png" : "Images/Enabled.png") + "");
        $(element).attr('title', (mainElementObject[elementNumber].IsReadOnly == true ? 'Disabled' : 'Enabled'));
    } else {
        if (childElementObject[elementNumber].IsRequired && childElementObject[elementNumber].DefaultValue == '' && !childElementObject[elementNumber].IsReadOnly) {
            showNotification("can not set readonly, as this field is required and has no default value", "error");
            return;
        }
        childElementObject[elementNumber].IsReadOnly = (childElementObject[elementNumber].IsReadOnly == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (childElementObject[elementNumber].IsReadOnly == true ? "Images/Disabled.png" : "Images/Enabled.png") + "");
        $(element).attr('title', (childElementObject[elementNumber].IsReadOnly == true ? 'Disabled' : 'Enabled'));
    }
}
function setDefaultValue(elementNumber, element, elementType) {
    //debugger;
    $('#hdnAttributType').val('1');
    $('#hdnAttributNumber').val(elementNumber);
    $('#lblAttributeType').text('Default Value');
    if (elementType == "1") {
        $('#txtAttributeValue').val(mainElementObject[elementNumber].DefaultValue);
        $('#hdnElementType').val("1");
    } else {
        $('#txtAttributeValue').val(childElementObject[elementNumber].DefaultValue);
        $('#hdnElementType').val("2");
    }
    $('#dvAttributeValue').show();
}
function setHelpText(elementNumber, element, elementType) {
    $('#hdnAttributType').val('2');
    $('#hdnAttributNumber').val(elementNumber);
    $('#lblAttributeType').text('Help Text');
    if (elementType == "1") {
        $('#txtAttributeValue').val(mainElementObject[elementNumber].HelpText);
        $('#hdnElementType').val("1");
    } else {
        $('#txtAttributeValue').val(childElementObject[elementNumber].HelpText);
        $('#hdnElementType').val("2");
    }
    $('#dvAttributeValue').show();
    //$(element).children().attr("src", "" + (mainElementObject[elementNumber].HelpText == '' ? "Images/red-help.png" : "Images/green-help.png") + "");
}
function SaveValue() {
    //debugger;
    if ($('#hdnElementType').val() == "1") {
        if ($('#hdnAttributType').val() == "1") {
            mainElementObject[$('#hdnAttributNumber').val()].DefaultValue = $('#txtAttributeValue').val();
            $('#hlDefaultValueHeader_' + $('#hdnAttributNumber').val()).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[$('#hdnAttributNumber').val()].DefaultValue == '' ? "Images/Not-Default-Value.png" : "Images/default-value.png") + "");
            $('#hlDefaultValueHeader_' + $('#hdnAttributNumber').val()).attr('title', (mainElementObject[$('#hdnAttributNumber').val()].DefaultValue));
        } else if ($('#hdnAttributType').val() == "2") {
            mainElementObject[$('#hdnAttributNumber').val()].HelpText = $('#txtAttributeValue').val();
            $('#hlHelpTextHeader_' + $('#hdnAttributNumber').val()).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[$('#hdnAttributNumber').val()].HelpText == '' ? "Images/red-help.jpg" : "Images/green-help.png") + "");
            $('#hlHelpTextHeader_' + $('#hdnAttributNumber').val()).attr('title', (mainElementObject[$('#hdnAttributNumber').val()].HelpText));
        }
    } else {
        if ($('#hdnAttributType').val() == "1") {
            childElementObject[$('#hdnAttributNumber').val()].DefaultValue = $('#txtAttributeValue').val();
            console.log(childElementObject[$('#hdnAttributNumber').val()].DefaultValue);
            $('#hlDefaultValueHeader_' + $('#hdnAttributNumber').val()).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (childElementObject[$('#hdnAttributNumber').val()].DefaultValue == '' ? "Images/Not-Default-Value.png" : "Images/default-value.png") + "");
            $('#hlDefaultValueHeader_' + $('#hdnAttributNumber').val()).attr('title', (childElementObject[$('#hdnAttributNumber').val()].DefaultValue));
            console.log($('#hdnAttributNumber').val());
        } else if ($('#hdnAttributType').val() == "2") {
            childElementObject[$('#hdnAttributNumber').val()].HelpText = $('#txtAttributeValue').val();
            $('#hlHelpTextHeader_' + $('#hdnAttributNumber').val()).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (childElementObject[$('#hdnAttributNumber').val()].HelpText == '' ? "Images/red-help.jpg" : "Images/green-help.png") + "");
            $('#hlHelpTextHeader_' + $('#hdnAttributNumber').val()).attr('title', (childElementObject[$('#hdnAttributNumber').val()].HelpText));
        }
    }
    $('#txtAttributeValue').val('');
    $('#dvAttributeValue').hide();
}
function returnAttributeHTML(elementNumber) {
    var mainElementAttributes = '<div class="col-ld-12" style="display:inline-flex;">';
    mainElementAttributes += '<div class="displayAttributes requiredAttribute"><a class="requiredClick" title="' + (childElementObject[elementNumber].IsRequired == true ? "Required" : "Not Required") + '" onclick="setRequired(' + elementNumber.toString() + ', this, 2)"><img src="' + $('#hdnApplicationDirectory').val() + (childElementObject[elementNumber].IsRequired == true ? "Images/Required.png" : "Images/Not-Required.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes visibleAttribute"><a class="visibleClick" title="' + (childElementObject[elementNumber].IsVisible == true ? "Visible" : "In Visible") + '" onclick="setVisible(' + elementNumber.toString() + ', this, 2)"><img src="' + $('#hdnApplicationDirectory').val() + (childElementObject[elementNumber].IsVisible == true ? "Images/Visible.png" : "Images/InVisible.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes readOnlyAttribute"><a class="readOnlyClick" title="' + (childElementObject[elementNumber].IsReadOnly == true ? "Disabled" : "Enabled") + '" onclick="setReadOnly(' + elementNumber.toString() + ', this, 2)"><img src="' + $('#hdnApplicationDirectory').val() + (childElementObject[elementNumber].IsReadOnly == true ? "Images/Disabled.png" : "Images/Enabled.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes defaultValueAttribute"><a id="hlDefaultValueHeader_' + elementNumber.toString() + '" class="defaultValueClick" title="' + (childElementObject[elementNumber].DefaultValue) + '" onclick="setDefaultValue(' + elementNumber.toString() + ', this, 2)"><img src="' + $('#hdnApplicationDirectory').val() + (childElementObject[elementNumber].DefaultValue != '' && childElementObject[elementNumber].DefaultValue != null ? "Images/default-value.png" : "Images/Not-Default-Value.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes helpTextAttribute"><a id="hlHelpTextHeader_' + elementNumber.toString() + '" class="helpTextClick" title="' + (childElementObject[elementNumber].HelpText) + '" onclick="setHelpText(' + elementNumber.toString() + ', this, 2)"><img src="' + $('#hdnApplicationDirectory').val() + (childElementObject[elementNumber].HelpText != '' && childElementObject[elementNumber].HelpText != null ? "Images/green-help.png" : "Images/red-help.jpg") + '" alt="" /></a></div>';
    mainElementAttributes += '</div>';
    return mainElementAttributes;
}
var isdisplayBusinessPropery = false;
DisplayBusinessRuleButtons(isdisplayBusinessPropery);
function DisplayBusinessRule() {
    if (!isdisplayBusinessPropery) {
        $('#CreateSpartan_Business_Rule').find('.col-sm-8').each(function () {
            var mainElementAttributes = '<div class="col-sm-2">';
            //mainElementAttributes += '<div class="displayBusinessPropery"><a onclick="DisplayBusinessRulePopup()"><i class="fa fa-cogs fa-spin"></i></a></div>';
            mainElementAttributes += '<div class="displayBusinessPropery"><button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#PropertyBusinessModal-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.displayBusinessPropery').remove();
    }
    DisplayBusinessRuleButtons(!isdisplayBusinessPropery);
    isdisplayBusinessPropery = (isdisplayBusinessPropery ? false : true);
}
function DisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}

var ConditionBusinessRuleTable;
var ActionBusinessRuleTable;
var ActionNotBusinessRuleTable;
function initializeBusinessRuleTable(){
    ConditionBusinessRuleTable = $("#tblConditionBusinessRule").DataTable();
    ActionBusinessRuleTable = $("#tblActionBusinessRule").DataTable();
    ActionNotBusinessRuleTable = $("#tblActionNotBusinessRule").DataTable();
}

function AddNewRowCondition() {
    var actionLinks = '<i class="fa fa-save" onclick="SaveRowCondition()"><a></a></i><i class="fa fa-trash-o" onclick="DeleteRowCondition(this)"><a></a></i>';
    ConditionBusinessRuleTable.row.add([actionLinks, getDropdown('Operator'), getDropdown('OperatorType1'), getDropdown('OperatorValue1'), getDropdown('Condition'), getDropdown('OperatorType2'), getDropdown('OperatorValue2')]).draw();
}
function AddNewRowAction() {
    var actionLinks = '<i class="fa fa-save" onclick="SaveRowAction()"><a></a></i><i class="fa fa-trash-o" onclick="DeleteRowAction(this)"><a></a></i>';
    ActionBusinessRuleTable.row.add([actionLinks, getDropdown('AAction'), getDropdown('AActionResult'), getDropdown('AParam1'), getDropdown('AParam2'), getDropdown('AParam3'), getDropdown('AParam4'), getDropdown('AParam5')]).draw();
}
function AddNewRowNotAction() {
    var actionLinks = '<i class="fa fa-save" onclick="SaveRowNotAction()"><a></a></i><i class="fa fa-trash-o" onclick="DeleteRowNotAction(this)"><a></a></i>';
    ActionNotBusinessRuleTable.row.add([actionLinks, getDropdown('ANAction'), getDropdown('ANActionResult'), getDropdown('ANParam1'), getDropdown('ANParam2'), getDropdown('ANParam3'), getDropdown('ANParam4'), getDropdown('ANParam5')]).draw();
}
function DeleteRowCondition(element) {
    if (confirm("are you sure you want to delete")) {
        ConditionBusinessRuleTable.row($(element).closest('tr')).remove().draw();
    }
}
function DeleteRowAction(element) {
    if (confirm("are you sure you want to delete")) {
        ActionBusinessRuleTable.row($(element).closest('tr')).remove().draw();
    }
}
function DeleteRowNotAction(element) {
    if (confirm("are you sure you want to delete")) {
        ActionNotBusinessRuleTable.row($(element).closest('tr')).remove().draw();
    }
}
function SaveRowAction() {

}
function SaveRowNotAction() {

}
function SaveRowCondition() {

}
