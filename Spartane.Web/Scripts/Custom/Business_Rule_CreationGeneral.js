function RemoveAttachmentMainDocumentation() {
    $("#hdnRemoveDocumentation").val("1");
    $("#divAttachmentDocumentation").hide();
}

var Spartan_BR_HistorycountRowsChecked = 0;
function GetSpartan_BR_History_Spartan_UserName(Id) {
    for (var i = 0; i < Spartan_BR_History_Spartan_UserItems.length; i++) {
        if (Spartan_BR_History_Spartan_UserItems[i].Id_User == Id) {
            return Spartan_BR_History_Spartan_UserItems[i].Name;
        }
    }
    return "";
}

function GetSpartan_BR_History_Spartan_UserDropDown() {
    var Spartan_BR_History_Spartan_UserDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '' }).appendTo(Spartan_BR_History_Spartan_UserDropdown);
    if (Spartan_BR_History_Spartan_UserItems != null) {
        for (var i = 0; i < Spartan_BR_History_Spartan_UserItems.length; i++) {
            $('<option />', { value: Spartan_BR_History_Spartan_UserItems[i].Id_User, text: Spartan_BR_History_Spartan_UserItems[i].Name }).appendTo(Spartan_BR_History_Spartan_UserDropdown);
        }
    }
    return Spartan_BR_History_Spartan_UserDropdown;
}
function GetSpartan_BR_History_Spartan_BR_StatusName(Id) {
    for (var i = 0; i < Spartan_BR_History_Spartan_BR_StatusItems.length; i++) {
        if (Spartan_BR_History_Spartan_BR_StatusItems[i].StatusId == Id) {
            return Spartan_BR_History_Spartan_BR_StatusItems[i].Description;
        }
    }
    return "";
}

function GetSpartan_BR_History_Spartan_BR_StatusDropDown() {
    var Spartan_BR_History_Spartan_BR_StatusDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '' }).appendTo(Spartan_BR_History_Spartan_BR_StatusDropdown);
    if (Spartan_BR_History_Spartan_BR_StatusItems != null) {
        for (var i = 0; i < Spartan_BR_History_Spartan_BR_StatusItems.length; i++) {
            $('<option />', { value: Spartan_BR_History_Spartan_BR_StatusItems[i].StatusId, text: Spartan_BR_History_Spartan_BR_StatusItems[i].Description }).appendTo(Spartan_BR_History_Spartan_BR_StatusDropdown);
        }
    }
    return Spartan_BR_History_Spartan_BR_StatusDropdown;
}
function GetSpartan_BR_History_Spartan_BR_Type_HistoryName(Id) {
    for (var i = 0; i < Spartan_BR_History_Spartan_BR_Type_HistoryItems.length; i++) {
        if (Spartan_BR_History_Spartan_BR_Type_HistoryItems[i].Key_Type_History == Id) {
            return Spartan_BR_History_Spartan_BR_Type_HistoryItems[i].Description;
        }
    }
    return "";
}

function GetSpartan_BR_History_Spartan_BR_Type_HistoryDropDown() {
    var Spartan_BR_History_Spartan_BR_Type_HistoryDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '' }).appendTo(Spartan_BR_History_Spartan_BR_Type_HistoryDropdown);
    if (Spartan_BR_History_Spartan_BR_Type_HistoryItems != null) {
        for (var i = 0; i < Spartan_BR_History_Spartan_BR_Type_HistoryItems.length; i++) {
            $('<option />', { value: Spartan_BR_History_Spartan_BR_Type_HistoryItems[i].Key_Type_History, text: Spartan_BR_History_Spartan_BR_Type_HistoryItems[i].Description }).appendTo(Spartan_BR_History_Spartan_BR_Type_HistoryDropdown);
        }
    }
    return Spartan_BR_History_Spartan_BR_Type_HistoryDropdown;
}


function GetInsertSpartan_BR_HistoryRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $(GetSpartan_BR_History_Spartan_UserDropDown()).addClass('Spartan_BR_History_User_logged User_logged').attr('id', 'Spartan_BR_History_User_logged_' + index).attr('data-field', 'User_logged');
    columnData[1] = $(GetSpartan_BR_History_Spartan_BR_StatusDropDown()).addClass('Spartan_BR_History_Status Status').attr('id', 'Spartan_BR_History_Status_' + index).attr('data-field', 'Status');
    columnData[2] = $($.parseHTML(GetGridDatePicker())).addClass('Spartan_BR_History_Change_Date Change_Date').attr('id', 'Spartan_BR_History_Change_Date_' + index).attr('data-field', 'Change_Date');
    columnData[3] = $($.parseHTML(GetGridTimePicker())).addClass('Spartan_BR_History_Hour_Date Hour_Date').attr('id', 'Spartan_BR_History_Hour_Date_' + index).attr('data-field', 'Hour_Date');
    columnData[4] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Spartan_BR_History_Time_elapsed Time_elapsed').attr('id', 'Spartan_BR_History_Time_elapsed_' + index).attr('data-field', 'Time_elapsed');
    columnData[5] = $(GetSpartan_BR_History_Spartan_BR_Type_HistoryDropDown()).addClass('Spartan_BR_History_Change_Type Change_Type').attr('id', 'Spartan_BR_History_Change_Type_' + index).attr('data-field', 'Change_Type');
    columnData[6] = $($.parseHTML(inputData)).addClass('Spartan_BR_History_Conditions Conditions').attr('id', 'Spartan_BR_History_Conditions_' + index).attr('data-field', 'Conditions');
    columnData[7] = $($.parseHTML(inputData)).addClass('Spartan_BR_History_Actions_True Actions_True').attr('id', 'Spartan_BR_History_Actions_True_' + index).attr('data-field', 'Actions_True');
    columnData[8] = $($.parseHTML(inputData)).addClass('Spartan_BR_History_Actions_False Actions_False').attr('id', 'Spartan_BR_History_Actions_False_' + index).attr('data-field', 'Actions_False');


    initiateUIControls();
    return columnData;
}

function Spartan_BR_HistoryInsertRow(rowIndex) {
    if (EjecutarValidacionesAntesDeGuardarMRSpartan_BR_History("Spartan_BR_History_", "_" + rowIndex)) {
        var iPage = Spartan_BR_HistoryTable.fnPagingInfo().iPage;
        var nameOfGrid = 'Spartan_BR_History';
        var prevData = Spartan_BR_HistoryTable.fnGetData(rowIndex);
        var data = Spartan_BR_HistoryTable.fnGetNodes(rowIndex);
        var counter = 1;
        var newData = {
            Key_History: prevData.Key_History,
            IsInsertRow: false
            , User_logged: ($('#' + nameOfGrid + 'Grid .User_loggedHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
            , Status: ($('#' + nameOfGrid + 'Grid .StatusHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
            , Change_Date: ($('#' + nameOfGrid + 'Grid .Change_DateHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
            , Hour_Date: ($('#' + nameOfGrid + 'Grid .Hour_DateHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
            , Time_elapsed: ($('#' + nameOfGrid + 'Grid .Time_elapsedHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
            , Change_Type: ($('#' + nameOfGrid + 'Grid .Change_TypeHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
            , Conditions: ($('#' + nameOfGrid + 'Grid .ConditionsHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
            , Actions_True: ($('#' + nameOfGrid + 'Grid .Actions_TrueHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
            , Actions_False: ($('#' + nameOfGrid + 'Grid .Actions_FalseHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''

        }
        Spartan_BR_HistoryTable.fnUpdate(newData, rowIndex, null, true);
        Spartan_BR_HistoryrowCreationGrid(data, newData, rowIndex);
        Spartan_BR_HistoryTable.fnPageChange(iPage);
        Spartan_BR_HistorycountRowsChecked--;
        EjecutarValidacionesDespuesDeGuardarMRSpartan_BR_History("Spartan_BR_History_", "_" + rowIndex);
    }
}

function Spartan_BR_HistoryCancelRow(rowIndex) {
    var prevData = Spartan_BR_HistoryTable.fnGetData(rowIndex);
    var data = Spartan_BR_HistoryTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Spartan_BR_HistoryTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Spartan_BR_HistoryrowCreationGrid(data, prevData, rowIndex);
    }
    showSpartan_BR_HistoryGrid(Spartan_BR_HistoryTable.fnGetData());
    Spartan_BR_HistorycountRowsChecked--;
}

function GetSpartan_BR_HistoryFromDataTable() {
    var Spartan_BR_HistoryData = [];
    var gridData = Spartan_BR_HistoryTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Spartan_BR_HistoryData.push({
                Key_History: gridData[i].Key_History
                , User_logged: gridData[i].User_logged
                , Status: gridData[i].Status
                , Change_Date: gridData[i].Change_Date
                , Hour_Date: gridData[i].Hour_Date
                , Time_elapsed: gridData[i].Time_elapsed
                , Change_Type: gridData[i].Change_Type
                , Conditions: gridData[i].Conditions
                , Actions_True: gridData[i].Actions_True
                , Actions_False: gridData[i].Actions_False

                , Removed: false
            });
    }

    for (i = 0; i < removedSpartan_BR_HistoryData.length; i++) {
        if (removedSpartan_BR_HistoryData[i] != null && removedSpartan_BR_HistoryData[i].Key_History > 0)
            Spartan_BR_HistoryData.push({
                Key_History: removedSpartan_BR_HistoryData[i].Key_History
                , User_logged: removedSpartan_BR_HistoryData[i].User_logged
                , Status: removedSpartan_BR_HistoryData[i].Status
                , Change_Date: removedSpartan_BR_HistoryData[i].Change_Date
                , Hour_Date: removedSpartan_BR_HistoryData[i].Hour_Date
                , Time_elapsed: removedSpartan_BR_HistoryData[i].Time_elapsed
                , Change_Type: removedSpartan_BR_HistoryData[i].Change_Type
                , Conditions: removedSpartan_BR_HistoryData[i].Conditions
                , Actions_True: removedSpartan_BR_HistoryData[i].Actions_True
                , Actions_False: removedSpartan_BR_HistoryData[i].Actions_False

                , Removed: true
            });
    }

    return Spartan_BR_HistoryData;
}

function Spartan_BR_HistoryEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Spartan_BR_HistoryTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Spartan_BR_HistorycountRowsChecked++;
    var Spartan_BR_HistoryRowElement = "Spartan_BR_History_" + rowIndex.toString();
    var prevData = Spartan_BR_HistoryTable.fnGetData(rowIndexTable);
    var row = Spartan_BR_HistoryTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Spartan_BR_History_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Spartan_BR_HistoryGetUpdateRowControls(prevData, "Spartan_BR_History_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Spartan_BR_HistoryRowElement + "')){ Spartan_BR_HistoryInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Spartan_BR_HistoryCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
        if ($('#Spartan_BR_HistoryGrid .' + idHeader).css('display') != 'none') {
            $(controls[i]).appendTo($('<td id="td' + nameOfTable + idHeader.replace('Header', '') + rowIndexFormed + '">').appendTo(row));
        }
    }
    $('.Spartan_BR_History' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    setSpartan_BR_HistoryValidation();
    initiateUIControls();
    if (executeRules == null || (executeRules != null && executeRules == true)) {
        EjecutarValidacionesEditRowMRSpartan_BR_History(nameOfTable, rowIndexFormed);
    }
}

function Spartan_BR_HistoryfnOpenAddRowPopUp() {
    var currentRowIndex = Spartan_BR_HistoryTable.fnGetData().length;
    Spartan_BR_HistoryfnClickAddRow();
    GetAddSpartan_BR_HistoryPopup(currentRowIndex, 0);
}

function Spartan_BR_HistoryEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Spartan_BR_HistoryTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Spartan_BR_HistoryRowElement = "Spartan_BR_History_" + rowIndex.toString();
    var prevData = Spartan_BR_HistoryTable.fnGetData(rowIndexTable);
    GetAddSpartan_BR_HistoryPopup(rowIndex, 1, prevData.Key_History);
    $('#Spartan_BR_HistoryUser_logged').val(prevData.User_logged);
    $('#Spartan_BR_HistoryStatus').val(prevData.Status);
    $('#Spartan_BR_HistoryChange_Date').val(prevData.Change_Date);
    $('#Spartan_BR_HistoryHour_Date').val(prevData.Hour_Date);
    $('#Spartan_BR_HistoryTime_elapsed').val(prevData.Time_elapsed);
    $('#Spartan_BR_HistoryChange_Type').val(prevData.Change_Type);
    $('#Spartan_BR_HistoryConditions').val(prevData.Conditions);
    $('#Spartan_BR_HistoryActions_True').val(prevData.Actions_True);
    $('#Spartan_BR_HistoryActions_False').val(prevData.Actions_False);

    initiateUIControls();

}

function Spartan_BR_HistoryAddInsertRow() {
    if (Spartan_BR_HistoryinsertRowCurrentIndex < 1) {
        Spartan_BR_HistoryinsertRowCurrentIndex = 1;
    }
    return {
        Key_History: null,
        IsInsertRow: true
        , User_logged: ""
        , Status: ""
        , Change_Date: ""
        , Hour_Date: ""
        , Time_elapsed: ""
        , Change_Type: ""
        , Conditions: ""
        , Actions_True: ""
        , Actions_False: ""

    }
}

function Spartan_BR_HistoryfnClickAddRow() {
    Spartan_BR_HistorycountRowsChecked++;
    Spartan_BR_HistoryTable.fnAddData(Spartan_BR_HistoryAddInsertRow(), true);
    Spartan_BR_HistoryTable.fnPageChange('last');
    initiateUIControls();
    EjecutarValidacionesNewRowMRSpartan_BR_History("Spartan_BR_History_", "_" + Spartan_BR_HistoryinsertRowCurrentIndex);
}

function Spartan_BR_HistoryClearGridData() {
    Spartan_BR_HistoryData = [];
    Spartan_BR_HistorydeletedItem = [];
    Spartan_BR_HistoryDataMain = [];
    Spartan_BR_HistoryDataMainPages = [];
    Spartan_BR_HistorynewItemCount = 0;
    Spartan_BR_HistorymaxItemIndex = 0;
    $("#Spartan_BR_HistoryGrid").DataTable().clear();
    $("#Spartan_BR_HistoryGrid").DataTable().destroy();
}

//Used to Get Business Rule Creation Information
function GetSpartan_BR_History() {
    var form_data = new FormData();
    for (var i = 0; i < Spartan_BR_HistoryData.length; i++) {
        form_data.append('[' + i + '].Key_History', Spartan_BR_HistoryData[i].Key_History);
        form_data.append('[' + i + '].User_logged', Spartan_BR_HistoryData[i].User_logged);
        form_data.append('[' + i + '].Status', Spartan_BR_HistoryData[i].Status);
        form_data.append('[' + i + '].Change_Date', Spartan_BR_HistoryData[i].Change_Date);
        form_data.append('[' + i + '].Hour_Date', Spartan_BR_HistoryData[i].Hour_Date);
        form_data.append('[' + i + '].Time_elapsed', Spartan_BR_HistoryData[i].Time_elapsed);
        form_data.append('[' + i + '].Change_Type', Spartan_BR_HistoryData[i].Change_Type);
        form_data.append('[' + i + '].Conditions', Spartan_BR_HistoryData[i].Conditions);
        form_data.append('[' + i + '].Actions_True', Spartan_BR_HistoryData[i].Actions_True);
        form_data.append('[' + i + '].Actions_False', Spartan_BR_HistoryData[i].Actions_False);

        form_data.append('[' + i + '].Removed', Spartan_BR_HistoryData[i].Removed);
    }
    return form_data;
}
function Spartan_BR_HistoryInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRSpartan_BR_History("Spartan_BR_HistoryTable", rowIndex)) {
    var prevData = Spartan_BR_HistoryTable.fnGetData(rowIndex);
    var data = Spartan_BR_HistoryTable.fnGetNodes(rowIndex);
    var newData = {
        Key_History: prevData.Key_History,
        IsInsertRow: false
        , User_logged: $('#Spartan_BR_HistoryUser_logged').val()
        , Status: $('#Spartan_BR_HistoryStatus').val()
        , Change_Date: $('#Spartan_BR_HistoryChange_Date').val()
        , Hour_Date: $('#Spartan_BR_HistoryHour_Date').val()
        , Time_elapsed: $('#Spartan_BR_HistoryTime_elapsed').val()

        , Change_Type: $('#Spartan_BR_HistoryChange_Type').val()
        , Conditions: $('#Spartan_BR_HistoryConditions').val()
        , Actions_True: $('#Spartan_BR_HistoryActions_True').val()
        , Actions_False: $('#Spartan_BR_HistoryActions_False').val()

    }

    Spartan_BR_HistoryTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_BR_HistoryrowCreationGrid(data, newData, rowIndex);
    $('#AddSpartan_BR_History-form').modal({ show: false });
    $('#AddSpartan_BR_History-form').modal('hide');
    Spartan_BR_HistoryEditRow(rowIndex);
    Spartan_BR_HistoryInsertRow(rowIndex);
    //}
}
function Spartan_BR_HistoryRemoveAddRow(rowIndex) {
    Spartan_BR_HistoryTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}
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

    $('<option />', { value: '', text: '' }).appendTo(Spartan_BR_Conditions_Detail_Spartan_BR_Condition_OperatorDropdown);
    if (Spartan_BR_Conditions_Detail_Spartan_BR_Condition_OperatorItems != null) {
        for (var i = 0; i < Spartan_BR_Conditions_Detail_Spartan_BR_Condition_OperatorItems.length; i++) {
            $('<option />', { value: Spartan_BR_Conditions_Detail_Spartan_BR_Condition_OperatorItems[i].ConditionOperatorId, text: Spartan_BR_Conditions_Detail_Spartan_BR_Condition_OperatorItems[i].Description }).appendTo(Spartan_BR_Conditions_Detail_Spartan_BR_Condition_OperatorDropdown);
        }
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

    $('<option />', { value: '', text: '' }).appendTo(Spartan_BR_Conditions_Detail_Spartan_BR_Operator_TypeDropdown);
    if (Spartan_BR_Conditions_Detail_Spartan_BR_Operator_TypeItems != null) {
        for (var i = 0; i < Spartan_BR_Conditions_Detail_Spartan_BR_Operator_TypeItems.length; i++) {
            $('<option />', { value: Spartan_BR_Conditions_Detail_Spartan_BR_Operator_TypeItems[i].OperatorTypeId, text: Spartan_BR_Conditions_Detail_Spartan_BR_Operator_TypeItems[i].Description }).appendTo(Spartan_BR_Conditions_Detail_Spartan_BR_Operator_TypeDropdown);
        }
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

    $('<option />', { value: '', text: '' }).appendTo(Spartan_BR_Conditions_Detail_Spartan_BR_ConditionDropdown);
    if (Spartan_BR_Conditions_Detail_Spartan_BR_ConditionItems != null) {
        for (var i = 0; i < Spartan_BR_Conditions_Detail_Spartan_BR_ConditionItems.length; i++) {
            $('<option />', { value: Spartan_BR_Conditions_Detail_Spartan_BR_ConditionItems[i].ConditionId, text: Spartan_BR_Conditions_Detail_Spartan_BR_ConditionItems[i].Description }).appendTo(Spartan_BR_Conditions_Detail_Spartan_BR_ConditionDropdown);
        }
    }
    return Spartan_BR_Conditions_Detail_Spartan_BR_ConditionDropdown;
}


function GetInsertSpartan_BR_Conditions_DetailRowControls(index) {
    /*var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $(GetSpartan_BR_Conditions_Detail_Spartan_BR_Condition_OperatorDropDown()).addClass('Spartan_BR_Conditions_Detail_Condition_Operator Condition_Operator').attr('id', 'Spartan_BR_Conditions_Detail_Condition_Operator_' + index).attr('data-field', 'Condition_Operator');
    columnData[1] = $(GetSpartan_BR_Conditions_Detail_Spartan_BR_Operator_TypeDropDown()).addClass('Spartan_BR_Conditions_Detail_First_Operator_Type First_Operator_Type').attr('id', 'Spartan_BR_Conditions_Detail_First_Operator_Type_' + index).attr('data-field', 'First_Operator_Type');
    columnData[2] = $($.parseHTML(inputData)).addClass('Spartan_BR_Conditions_Detail_First_Operator_Value First_Operator_Value').attr('id', 'Spartan_BR_Conditions_Detail_First_Operator_Value_' + index).attr('data-field', 'First_Operator_Value');
    columnData[3] = $(GetSpartan_BR_Conditions_Detail_Spartan_BR_ConditionDropDown()).addClass('Spartan_BR_Conditions_Detail_Condition Condition').attr('id', 'Spartan_BR_Conditions_Detail_Condition_' + index).attr('data-field', 'Condition');
    columnData[4] = $(GetSpartan_BR_Conditions_Detail_Spartan_BR_Operator_TypeDropDown()).addClass('Spartan_BR_Conditions_Detail_Second_Operator_Type Second_Operator_Type').attr('id', 'Spartan_BR_Conditions_Detail_Second_Operator_Type_' + index).attr('data-field', 'Second_Operator_Type');
    columnData[5] = $($.parseHTML(inputData)).addClass('Spartan_BR_Conditions_Detail_Second_Operator_Value Second_Operator_Value').attr('id', 'Spartan_BR_Conditions_Detail_Second_Operator_Value_' + index).attr('data-field', 'Second_Operator_Value');
    */


    //initiateUIControls();
    //return columnData;
    var columnData = [];
    var ddlOperator = $(getDropdown('Condition_Operator', index, Spartan_BR_Conditions_DetailinsertRowCurrentIndex));
    var ddlOperatorType1 = $(getDropdown('First_Operator_Type', index, Spartan_BR_Conditions_DetailinsertRowCurrentIndex));
    var ddlOperatorValue1 = $(getDropdownAndTextbox('First_Operator_Value', index, Spartan_BR_Conditions_DetailinsertRowCurrentIndex));
    var ddlCondition = $(getDropdown('Condition', index, Spartan_BR_Conditions_DetailinsertRowCurrentIndex));
    var ddlOperatorType2 = $(getDropdown('Second_Operator_Type', index, Spartan_BR_Conditions_DetailinsertRowCurrentIndex));
    var ddlOperatorValue2 = $(getDropdownAndTextbox('Second_Operator_Value', index, Spartan_BR_Conditions_DetailinsertRowCurrentIndex));

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

function Spartan_BR_Conditions_DetailInsertRow(rowIndex) {
    if (EjecutarValidacionesAntesDeGuardarMRSpartan_BR_Conditions_Detail("Spartan_BR_Conditions_Detail_", "_" + rowIndex)) {
        var iPage = Spartan_BR_Conditions_DetailTable.fnPagingInfo().iPage;
        var nameOfGrid = 'Spartan_BR_Conditions_Detail';
        var prevData = Spartan_BR_Conditions_DetailTable.fnGetData(rowIndex);
        var data = Spartan_BR_Conditions_DetailTable.fnGetNodes(rowIndex);
        var counter = 1;
        var newData = {
            ConditionsDetailId: prevData.ConditionsDetailId,
            IsInsertRow: false
            , Condition_Operator: data.childNodes[1].childNodes[0].value
            , First_Operator_Type: data.childNodes[2].childNodes[0].value
            , First_Operator_Value: (data.childNodes[3].childNodes[0].value == '') ? data.childNodes[3].childNodes[1].value : $('#' + $(data.childNodes[3].childNodes[0])[0].id + ' option:selected').text()
            , Condition: ($('#' + nameOfGrid + 'Grid .ConditionHeader').css('display') != 'none') ? data.childNodes[4].childNodes[0].value : ''
            , Second_Operator_Type: data.childNodes[5].childNodes[0].value
            , Second_Operator_Value: (data.childNodes[6].childNodes[0].value == '') ? data.childNodes[6].childNodes[1].value : $('#' + $(data.childNodes[6].childNodes[0])[0].id + ' option:selected').text()


        }
        Spartan_BR_Conditions_DetailTable.fnUpdate(newData, rowIndex, null, true);
        Spartan_BR_Conditions_DetailrowCreationGrid(data, newData, rowIndex);
        Spartan_BR_Conditions_DetailTable.fnPageChange(iPage);
        Spartan_BR_Conditions_DetailcountRowsChecked--;
        EjecutarValidacionesDespuesDeGuardarMRSpartan_BR_Conditions_Detail("Spartan_BR_Conditions_Detail_", "_" + rowIndex);
    }
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
    showSpartan_BR_Conditions_DetailGrid(Spartan_BR_Conditions_DetailTable.fnGetData());
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
                , First_Operator_Type: gridData[i].First_Operator_Type
                , Condition_Operator: gridData[i].Condition_Operator
                , First_Operator_Value: gridData[i].First_Operator_Value
                , Second_Operator_Type: gridData[i].Second_Operator_Type
                , Second_Operator_Value: gridData[i].Second_Operator_Value
                , Condition: gridData[i].Condition

                , Removed: false
            });
    }

    for (i = 0; i < removedSpartan_BR_Conditions_DetailData.length; i++) {
        if (removedSpartan_BR_Conditions_DetailData[i] != null && removedSpartan_BR_Conditions_DetailData[i].ConditionsDetailId > 0)
            Spartan_BR_Conditions_DetailData.push({
                ConditionsDetailId: removedSpartan_BR_Conditions_DetailData[i].ConditionsDetailId
                , First_Operator_Type: removedSpartan_BR_Conditions_DetailData[i].First_Operator_Type
                , Condition_Operator: removedSpartan_BR_Conditions_DetailData[i].Condition_Operator
                , First_Operator_Value: removedSpartan_BR_Conditions_DetailData[i].First_Operator_Value
                , Second_Operator_Type: removedSpartan_BR_Conditions_DetailData[i].Second_Operator_Type
                , Second_Operator_Value: removedSpartan_BR_Conditions_DetailData[i].Second_Operator_Value
                , Condition: removedSpartan_BR_Conditions_DetailData[i].Condition

                , Removed: true
            });
    }

    return Spartan_BR_Conditions_DetailData;
}

function Spartan_BR_Conditions_DetailEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Spartan_BR_Conditions_DetailTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Spartan_BR_Conditions_DetailcountRowsChecked++;
    var Spartan_BR_Conditions_DetailRowElement = "Spartan_BR_Conditions_Detail_" + rowIndex.toString();
    var prevData = Spartan_BR_Conditions_DetailTable.fnGetData(rowIndexTable);
    var row = Spartan_BR_Conditions_DetailTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Spartan_BR_Conditions_Detail_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Spartan_BR_Conditions_DetailGetUpdateRowControls(prevData, "Spartan_BR_Conditions_Detail_", rowIndex);

    var abc = "if(dynamicFieldValidation('" + Spartan_BR_Conditions_DetailRowElement + "')){ Spartan_BR_Conditions_DetailInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Spartan_BR_Conditions_DetailCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
        if ($('#Spartan_BR_Conditions_DetailGrid .' + idHeader).css('display') != 'none') {
            $(controls[i]).appendTo($('<td id="td' + nameOfTable + idHeader.replace('Header', '') + rowIndexFormed + '">').appendTo(row));
        }
    }
    GetConditionOperator('Condition_Operator_' + rowIndex);
    GetConditions('Condition_' + rowIndex);
    GetOperatorTypes('First_Operator_Type_' + rowIndex);
    GetOperatorTypes('Second_Operator_Type_' + rowIndex);
    $('#Condition_Operator_' + rowIndex).val(prevData.Condition_Operator);
    $('#First_Operator_Type_' + rowIndex).val(prevData.First_Operator_Type).change();
    if (prevData.First_Operator_Type == 3) {
        var val = $('#ddlFirst_Operator_Value_' + rowIndex + ' option').filter(function () { return $(this).html() == prevData.First_Operator_Value; }).val();
        $('#ddlFirst_Operator_Value_' + rowIndex).val(val);
    }
    else {
        $('#txtFirst_Operator_Value_' + rowIndex).val(prevData.First_Operator_Value);
    }

    $('#Condition_' + rowIndex).val(prevData.Condition);
    $('#Second_Operator_Type_' + rowIndex).val(prevData.Second_Operator_Type).change();
    if (prevData.Second_Operator_Type == 3) {
        var val = $('#ddlSecond_Operator_Value_' + rowIndex + ' option').filter(function () { return $(this).html() == prevData.Second_Operator_Value; }).val();
        $('#ddlSecond_Operator_Value_' + rowIndex).val(val);
    }
    else {
        $('#txtSecond_Operator_Value_' + rowIndex).val(prevData.Second_Operator_Value);
    }

    $('.Spartan_BR_Conditions_Detail' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    setSpartan_BR_Conditions_DetailValidation();
    initiateUIControls();
    if (executeRules == null || (executeRules != null && executeRules == true)) {
        EjecutarValidacionesEditRowMRSpartan_BR_Conditions_Detail(nameOfTable, rowIndexFormed);
    }
}

function Spartan_BR_Conditions_DetailfnOpenAddRowPopUp() {
    var currentRowIndex = Spartan_BR_Conditions_DetailTable.fnGetData().length;
    Spartan_BR_Conditions_DetailfnClickAddRow();
    GetAddSpartan_BR_Conditions_DetailPopup(currentRowIndex, 0);
}

function Spartan_BR_Conditions_DetailEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Spartan_BR_Conditions_DetailTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Spartan_BR_Conditions_DetailRowElement = "Spartan_BR_Conditions_Detail_" + rowIndex.toString();
    var prevData = Spartan_BR_Conditions_DetailTable.fnGetData(rowIndexTable);
    GetAddSpartan_BR_Conditions_DetailPopup(rowIndex, 1, prevData.ConditionsDetailId);
    $('#Spartan_BR_Conditions_DetailFirst_Operator_Type').val(prevData.First_Operator_Type);
    $('#Spartan_BR_Conditions_DetailCondition_Operator').val(prevData.Condition_Operator);
    $('#Spartan_BR_Conditions_DetailFirst_Operator_Value').val(prevData.First_Operator_Value);
    $('#Spartan_BR_Conditions_DetailSecond_Operator_Type').val(prevData.Second_Operator_Type);
    $('#Spartan_BR_Conditions_DetailSecond_Operator_Value').val(prevData.Second_Operator_Value);
    $('#Spartan_BR_Conditions_DetailCondition').val(prevData.Condition);

    initiateUIControls();

}

function Spartan_BR_Conditions_DetailAddInsertRow() {
    if (Spartan_BR_Conditions_DetailinsertRowCurrentIndex < 1) {
        Spartan_BR_Conditions_DetailinsertRowCurrentIndex = 1;
    }
    return {
        ConditionsDetailId: null,
        IsInsertRow: true
        , First_Operator_Type: ""
        , Condition_Operator: ""
        , First_Operator_Value: ""
        , Second_Operator_Type: ""
        , Second_Operator_Value: ""
        , Condition: ""

    }
}

function Spartan_BR_Conditions_DetailfnClickAddRow() {
    Spartan_BR_Conditions_DetailTable.fnAddData(Spartan_BR_Conditions_DetailAddInsertRow(), true);
    GetConditionOperator('Condition_Operator_' + Spartan_BR_Conditions_DetailinsertRowCurrentIndex);
    GetConditions('Condition_' + Spartan_BR_Conditions_DetailinsertRowCurrentIndex);
    GetOperatorTypes('First_Operator_Type_' + Spartan_BR_Conditions_DetailinsertRowCurrentIndex);
    GetOperatorTypes('Second_Operator_Type_' + Spartan_BR_Conditions_DetailinsertRowCurrentIndex);
    Spartan_BR_Conditions_DetailTable.fnPageChange('last');
    initiateUIControls();
    EjecutarValidacionesNewRowMRSpartan_BR_Conditions_Detail("Spartan_BR_Conditions_Detail_", "_" + Spartan_BR_Conditions_DetailinsertRowCurrentIndex);
    Spartan_BR_Conditions_DetailcountRowsChecked++;
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

//Used to Get Business Rule Creation Information
function GetSpartan_BR_Conditions_Detail() {
    var form_data = new FormData();
    for (var i = 0; i < Spartan_BR_Conditions_DetailData.length; i++) {
        form_data.append('[' + i + '].ConditionsDetailId', Spartan_BR_Conditions_DetailData[i].ConditionsDetailId);
        form_data.append('[' + i + '].First_Operator_Type', Spartan_BR_Conditions_DetailData[i].First_Operator_Type);
        form_data.append('[' + i + '].Condition_Operator', Spartan_BR_Conditions_DetailData[i].Condition_Operator);
        form_data.append('[' + i + '].First_Operator_Value', Spartan_BR_Conditions_DetailData[i].First_Operator_Value);
        form_data.append('[' + i + '].Second_Operator_Type', Spartan_BR_Conditions_DetailData[i].Second_Operator_Type);
        form_data.append('[' + i + '].Second_Operator_Value', Spartan_BR_Conditions_DetailData[i].Second_Operator_Value);
        form_data.append('[' + i + '].Condition', Spartan_BR_Conditions_DetailData[i].Condition);

        form_data.append('[' + i + '].Removed', Spartan_BR_Conditions_DetailData[i].Removed);
    }
    return form_data;
}
function Spartan_BR_Conditions_DetailInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRSpartan_BR_Conditions_Detail("Spartan_BR_Conditions_DetailTable", rowIndex)) {
    var prevData = Spartan_BR_Conditions_DetailTable.fnGetData(rowIndex);
    var data = Spartan_BR_Conditions_DetailTable.fnGetNodes(rowIndex);
    var newData = {
        ConditionsDetailId: prevData.ConditionsDetailId,
        IsInsertRow: false
        , First_Operator_Type: $('#Spartan_BR_Conditions_DetailFirst_Operator_Type').val()
        , Condition_Operator: $('#Spartan_BR_Conditions_DetailCondition_Operator').val()
        , First_Operator_Value: $('#Spartan_BR_Conditions_DetailFirst_Operator_Value').val()
        , Second_Operator_Type: $('#Spartan_BR_Conditions_DetailSecond_Operator_Type').val()

        , Second_Operator_Value: $('#Spartan_BR_Conditions_DetailSecond_Operator_Value').val()
        , Condition: $('#Spartan_BR_Conditions_DetailCondition').val()

    }

    Spartan_BR_Conditions_DetailTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_BR_Conditions_DetailrowCreationGrid(data, newData, rowIndex);
    $('#AddSpartan_BR_Conditions_Detail-form').modal({ show: false });
    $('#AddSpartan_BR_Conditions_Detail-form').modal('hide');
    Spartan_BR_Conditions_DetailEditRow(rowIndex);
    Spartan_BR_Conditions_DetailInsertRow(rowIndex);
    //}
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

    $('<option />', { value: '', text: '' }).appendTo(Spartan_BR_Actions_True_Detail_Spartan_BR_Action_ClassificationDropdown);
    if (Spartan_BR_Actions_True_Detail_Spartan_BR_Action_ClassificationItems != null) {
        for (var i = 0; i < Spartan_BR_Actions_True_Detail_Spartan_BR_Action_ClassificationItems.length; i++) {
            $('<option />', { value: Spartan_BR_Actions_True_Detail_Spartan_BR_Action_ClassificationItems[i].ClassificationId, text: Spartan_BR_Actions_True_Detail_Spartan_BR_Action_ClassificationItems[i].Description }).appendTo(Spartan_BR_Actions_True_Detail_Spartan_BR_Action_ClassificationDropdown);
        }
    }
    return Spartan_BR_Actions_True_Detail_Spartan_BR_Action_ClassificationDropdown;
}
function GetSpartan_BR_Actions_True_Detail_Spartan_BR_ActionName(Id) {
    debugger;
    for (var i = 0; i < Spartan_BR_Actions_True_Detail_Spartan_BR_ActionItems.length; i++) {
        if (Spartan_BR_Actions_True_Detail_Spartan_BR_ActionItems[i].ActionId == Id) {
            return Spartan_BR_Actions_True_Detail_Spartan_BR_ActionItems[i].Description;
        }
    }
    return "";
}

function GetSpartan_BR_Actions_True_Detail_Spartan_BR_ActionDropDown() {
    var Spartan_BR_Actions_True_Detail_Spartan_BR_ActionDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '' }).appendTo(Spartan_BR_Actions_True_Detail_Spartan_BR_ActionDropdown);
    if (Spartan_BR_Actions_True_Detail_Spartan_BR_ActionItems != null) {
        for (var i = 0; i < Spartan_BR_Actions_True_Detail_Spartan_BR_ActionItems.length; i++) {
            $('<option />', { value: Spartan_BR_Actions_True_Detail_Spartan_BR_ActionItems[i].ActionId, text: Spartan_BR_Actions_True_Detail_Spartan_BR_ActionItems[i].Description }).appendTo(Spartan_BR_Actions_True_Detail_Spartan_BR_ActionDropdown);
        }
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

    $('<option />', { value: '', text: '' }).appendTo(Spartan_BR_Actions_True_Detail_Spartan_BR_Action_ResultDropdown);
    if (Spartan_BR_Actions_True_Detail_Spartan_BR_Action_ResultItems != null) {
        for (var i = 0; i < Spartan_BR_Actions_True_Detail_Spartan_BR_Action_ResultItems.length; i++) {
            $('<option />', { value: Spartan_BR_Actions_True_Detail_Spartan_BR_Action_ResultItems[i].ActionResultId, text: Spartan_BR_Actions_True_Detail_Spartan_BR_Action_ResultItems[i].Description }).appendTo(Spartan_BR_Actions_True_Detail_Spartan_BR_Action_ResultDropdown);
        }
    }
    return Spartan_BR_Actions_True_Detail_Spartan_BR_Action_ResultDropdown;
}


function GetInsertSpartan_BR_Actions_True_DetailRowControls(index) {
    /*var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $(GetSpartan_BR_Actions_True_Detail_Spartan_BR_Action_ClassificationDropDown()).addClass('Spartan_BR_Actions_True_Detail_Action_Classification Action_Classification').attr('id', 'Spartan_BR_Actions_True_Detail_Action_Classification_' + index).attr('data-field', 'Action_Classification');
    columnData[1] = $(GetSpartan_BR_Actions_True_Detail_Spartan_BR_ActionDropDown()).addClass('Spartan_BR_Actions_True_Detail_Action Action').attr('id', 'Spartan_BR_Actions_True_Detail_Action_' + index).attr('data-field', 'Action');
    columnData[2] = $(GetSpartan_BR_Actions_True_Detail_Spartan_BR_Action_ResultDropDown()).addClass('Spartan_BR_Actions_True_Detail_Action_Result Action_Result').attr('id', 'Spartan_BR_Actions_True_Detail_Action_Result_' + index).attr('data-field', 'Action_Result');
    columnData[3] = $($.parseHTML(inputData)).addClass('Spartan_BR_Actions_True_Detail_Parameter_1 Parameter_1').attr('id', 'Spartan_BR_Actions_True_Detail_Parameter_1_' + index).attr('data-field', 'Parameter_1');
    columnData[4] = $($.parseHTML(inputData)).addClass('Spartan_BR_Actions_True_Detail_Parameter_2 Parameter_2').attr('id', 'Spartan_BR_Actions_True_Detail_Parameter_2_' + index).attr('data-field', 'Parameter_2');
    columnData[5] = $($.parseHTML(inputData)).addClass('Spartan_BR_Actions_True_Detail_Parameter_3 Parameter_3').attr('id', 'Spartan_BR_Actions_True_Detail_Parameter_3_' + index).attr('data-field', 'Parameter_3');
    columnData[6] = $($.parseHTML(inputData)).addClass('Spartan_BR_Actions_True_Detail_Parameter_4 Parameter_4').attr('id', 'Spartan_BR_Actions_True_Detail_Parameter_4_' + index).attr('data-field', 'Parameter_4');
    columnData[7] = $($.parseHTML(inputData)).addClass('Spartan_BR_Actions_True_Detail_Parameter_5 Parameter_5').attr('id', 'Spartan_BR_Actions_True_Detail_Parameter_5_' + index).attr('data-field', 'Parameter_5');


    initiateUIControls();
    return columnData;*/
    var columnData = [];
    var ddlActionClassification = $(getDropdown('Action_Classification', index, Spartan_BR_Actions_True_DetailinsertRowCurrentIndex));
    var ddlAction = $(getDropdown('Action', index, Spartan_BR_Actions_True_DetailinsertRowCurrentIndex));
    var ddlActionResult = $(getDropdown('Action_Result', index, Spartan_BR_Actions_True_DetailinsertRowCurrentIndex));
    var inputParameter1 = $(getDropdownAndTextbox('Parameter_1', index, Spartan_BR_Actions_True_DetailinsertRowCurrentIndex));
    var inputParameter2 = $(getDropdownAndTextbox('Parameter_2', index, Spartan_BR_Actions_True_DetailinsertRowCurrentIndex));
    var inputParameter3 = $(getDropdownAndTextbox('Parameter_3', index, Spartan_BR_Actions_True_DetailinsertRowCurrentIndex));
    var inputParameter4 = $(getDropdownAndTextbox('Parameter_4', index, Spartan_BR_Actions_True_DetailinsertRowCurrentIndex));
    var inputParameter5 = $(getDropdownAndTextbox('Parameter_5', index, Spartan_BR_Actions_True_DetailinsertRowCurrentIndex));
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

function Spartan_BR_Actions_True_DetailInsertRow(rowIndex) {
    debugger;
    if (EjecutarValidacionesAntesDeGuardarMRSpartan_BR_Actions_True_Detail("Spartan_BR_Actions_True_Detail_", "_" + rowIndex)) {
        var iPage = Spartan_BR_Actions_True_DetailTable.fnPagingInfo().iPage;
        var nameOfGrid = 'Spartan_BR_Actions_True_Detail';
        var prevData = Spartan_BR_Actions_True_DetailTable.fnGetData(rowIndex);
        var data = Spartan_BR_Actions_True_DetailTable.fnGetNodes(rowIndex);
        var counter = 1;
        var newData = {
            ActionsTrueDetailId: prevData.ActionsTrueDetailId,
            IsInsertRow: false
            , Action_Classification: ($('#' + nameOfGrid + 'Grid .Action_ClassificationHeader').css('display') != 'none') ? data.childNodes[1].childNodes[0].value : ''
            , Action: ($('#' + nameOfGrid + 'Grid .ActionHeader').css('display') != 'none') ? data.childNodes[2].childNodes[0].value : ''
            , Action_Result: ($('#' + nameOfGrid + 'Grid .Action_ResultHeader').css('display') != 'none') ? data.childNodes[3].childNodes[0].value : ''
            , Parameter_1: (data.childNodes[4].childNodes.length == 2) ? '' : ((data.childNodes[4].childNodes[1].value == '') ? data.childNodes[4].childNodes[2].value : $('#' + $(data.childNodes[4].childNodes[1])[0].id + ' option:selected').text()),
            Parameter_2: (data.childNodes[5].childNodes.length == 2) ? '' : ((data.childNodes[5].childNodes[1].value == '') ? (data.childNodes[5].childNodes[2].value == null ? '' : data.childNodes[5].childNodes[2].value) : $('#' + $(data.childNodes[5].childNodes[1])[0].id + ' option:selected').text()),
            Parameter_3: (data.childNodes[6].childNodes.length == 2) ? '' : ((data.childNodes[6].childNodes[1].value == '') ? (data.childNodes[6].childNodes[2].value == null ? '' : data.childNodes[6].childNodes[2].value) : $('#' + $(data.childNodes[6].childNodes[1])[0].id + ' option:selected').text()),
            Parameter_4: (data.childNodes[7].childNodes.length == 2) ? '' : ((data.childNodes[7].childNodes[1].value == '') ? (data.childNodes[7].childNodes[2].value == null ? '' : data.childNodes[7].childNodes[2].value) : $('#' + $(data.childNodes[7].childNodes[1])[0].id + ' option:selected').text()),
            Parameter_5: (data.childNodes[8].childNodes.length == 2) ? '' : ((data.childNodes[8].childNodes[1].value == '') ? (data.childNodes[8].childNodes[2].value == null ? '' : data.childNodes[8].childNodes[2].value) : $('#' + $(data.childNodes[8].childNodes[1])[0].id + ' option:selected').text()),

        }

        Spartan_BR_Actions_True_DetailTable.fnUpdate(newData, rowIndex, null, true);
        Spartan_BR_Actions_True_DetailrowCreationGrid(data, newData, rowIndex);
        Spartan_BR_Actions_True_DetailTable.fnPageChange(iPage);
        Spartan_BR_Actions_True_DetailcountRowsChecked--;
        EjecutarValidacionesDespuesDeGuardarMRSpartan_BR_Actions_True_Detail("Spartan_BR_Actions_True_Detail_", "_" + rowIndex);
    }
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
    showSpartan_BR_Actions_True_DetailGrid(Spartan_BR_Actions_True_DetailTable.fnGetData());
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
                , Action_Classification: gridData[i].Action_Classification
                , Action: gridData[i].Action
                , Action_Result: gridData[i].Action_Result
                , Parameter_1: gridData[i].Parameter_1
                , Parameter_2: gridData[i].Parameter_2
                , Parameter_3: gridData[i].Parameter_3
                , Parameter_4: gridData[i].Parameter_4
                , Parameter_5: gridData[i].Parameter_5

                , Removed: false
            });
    }

    for (i = 0; i < removedSpartan_BR_Actions_True_DetailData.length; i++) {
        if (removedSpartan_BR_Actions_True_DetailData[i] != null && removedSpartan_BR_Actions_True_DetailData[i].ActionsTrueDetailId > 0)
            Spartan_BR_Actions_True_DetailData.push({
                ActionsTrueDetailId: removedSpartan_BR_Actions_True_DetailData[i].ActionsTrueDetailId
                , Action_Classification: removedSpartan_BR_Actions_True_DetailData[i].Action_Classification
                , Action: removedSpartan_BR_Actions_True_DetailData[i].Action
                , Action_Result: removedSpartan_BR_Actions_True_DetailData[i].Action_Result
                , Parameter_1: removedSpartan_BR_Actions_True_DetailData[i].Parameter_1
                , Parameter_2: removedSpartan_BR_Actions_True_DetailData[i].Parameter_2
                , Parameter_3: removedSpartan_BR_Actions_True_DetailData[i].Parameter_3
                , Parameter_4: removedSpartan_BR_Actions_True_DetailData[i].Parameter_4
                , Parameter_5: removedSpartan_BR_Actions_True_DetailData[i].Parameter_5

                , Removed: true
            });
    }

    return Spartan_BR_Actions_True_DetailData;
}

function Spartan_BR_Actions_True_DetailEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Spartan_BR_Actions_True_DetailTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Spartan_BR_Actions_True_DetailcountRowsChecked++;
    var Spartan_BR_Actions_True_DetailRowElement = "Spartan_BR_Actions_True_Detail_" + rowIndex.toString();
    var prevData = Spartan_BR_Actions_True_DetailTable.fnGetData(rowIndexTable);
    var row = Spartan_BR_Actions_True_DetailTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Spartan_BR_Actions_True_Detail_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Spartan_BR_Actions_True_DetailGetUpdateRowControls(prevData, "Spartan_BR_Actions_True_Detail_", rowIndex);

    var abc = "if(dynamicFieldValidation('" + Spartan_BR_Actions_True_DetailRowElement + "')){ Spartan_BR_Actions_True_DetailInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Spartan_BR_Actions_True_DetailCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
        if ($('#Spartan_BR_Actions_True_DetailGrid .' + idHeader).css('display') != 'none') {
            $(controls[i]).appendTo($('<td id="td' + nameOfTable + idHeader.replace('Header', '') + rowIndexFormed + '">').appendTo(row));
        }
    }

    GetActionClassification('Action_Classification_' + rowIndex);
    GetActionResult('Action_Result_' + rowIndex);
    $('#Action_Classification_' + rowIndex).val(prevData.Action_Classification).change();
    $('#Action_' + rowIndex).val(prevData.Action).change();
    $('#Action_Result_' + rowIndex).val(prevData.Action_Result);
    $('#txtParameter_1_' + rowIndex).val(prevData.Parameter_1);
    $('#txtParameter_2_' + rowIndex).val(prevData.Parameter_2);
    $('#txtParameter_3_' + rowIndex).val(prevData.Parameter_3);
    $('#txtParameter_4_' + rowIndex).val(prevData.Parameter_4);
    $('#txtParameter_5_' + rowIndex).val(prevData.Parameter_5);
    var valParam1 = $('#ddlParameter_1_' + rowIndex + ' option').filter(function () { return $(this).html() == prevData.Parameter_1; }).val();
    $('#ddlParameter_1_' + rowIndex).val(valParam1);
    var valParam2 = $('#ddlParameter_2_' + rowIndex + ' option').filter(function () { return $(this).html() == prevData.Parameter_2; }).val();
    $('#ddlParameter_2_' + rowIndex).val(valParam2);
    var valParam3 = $('#ddlParameter_3_' + rowIndex + ' option').filter(function () { return $(this).html() == prevData.Parameter_3; }).val();
    $('#ddlParameter_3_' + rowIndex).val(valParam3);
    var valParam4 = $('#ddlParameter_4_' + rowIndex + ' option').filter(function () { return $(this).html() == prevData.Parameter_4; }).val();
    $('#ddlParameter_4_' + rowIndex).val(valParam4);
    var valParam5 = $('#ddlParameter_5_' + rowIndex + ' option').filter(function () { return $(this).html() == prevData.Parameter_5; }).val();
    $('#ddlParameter_5_' + rowIndex).val(valParam5);
    $('.Spartan_BR_Actions_True_Detail' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    setSpartan_BR_Actions_True_DetailValidation();
    initiateUIControls();
    if (executeRules == null || (executeRules != null && executeRules == true)) {
        EjecutarValidacionesEditRowMRSpartan_BR_Actions_True_Detail(nameOfTable, rowIndexFormed);
    }
}

function Spartan_BR_Actions_True_DetailfnOpenAddRowPopUp() {
    var currentRowIndex = Spartan_BR_Actions_True_DetailTable.fnGetData().length;
    Spartan_BR_Actions_True_DetailfnClickAddRow();
    GetAddSpartan_BR_Actions_True_DetailPopup(currentRowIndex, 0);
}

function Spartan_BR_Actions_True_DetailEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Spartan_BR_Actions_True_DetailTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Spartan_BR_Actions_True_DetailRowElement = "Spartan_BR_Actions_True_Detail_" + rowIndex.toString();
    var prevData = Spartan_BR_Actions_True_DetailTable.fnGetData(rowIndexTable);
    GetAddSpartan_BR_Actions_True_DetailPopup(rowIndex, 1, prevData.ActionsTrueDetailId);
    $('#Spartan_BR_Actions_True_DetailAction_Classification').val(prevData.Action_Classification);
    $('#Spartan_BR_Actions_True_DetailAction').val(prevData.Action);
    $('#Spartan_BR_Actions_True_DetailAction_Result').val(prevData.Action_Result);
    $('#Spartan_BR_Actions_True_DetailParameter_1').val(prevData.Parameter_1);
    $('#Spartan_BR_Actions_True_DetailParameter_2').val(prevData.Parameter_2);
    $('#Spartan_BR_Actions_True_DetailParameter_3').val(prevData.Parameter_3);
    $('#Spartan_BR_Actions_True_DetailParameter_4').val(prevData.Parameter_4);
    $('#Spartan_BR_Actions_True_DetailParameter_5').val(prevData.Parameter_5);

    initiateUIControls();

}

function Spartan_BR_Actions_True_DetailAddInsertRow() {
    if (Spartan_BR_Actions_True_DetailinsertRowCurrentIndex < 1) {
        Spartan_BR_Actions_True_DetailinsertRowCurrentIndex = 1;
    }
    return {
        ActionsTrueDetailId: null,
        IsInsertRow: true
        , Action_Classification: ""
        , Action: ""
        , Action_Result: ""
        , Parameter_1: ""
        , Parameter_2: ""
        , Parameter_3: ""
        , Parameter_4: ""
        , Parameter_5: ""

    }
}

function Spartan_BR_Actions_True_DetailfnClickAddRow() {
    debugger;
    var operations = '';
    var events = '';
    var op = $('#Operations');
    if (op != null && op.val() != null && op.val().length != 0) {
        operations = op.toString();
    }
    var ev = $('#Events');
    if (ev != null && ev.val() != null && ev.val().length != 0) {
        events = ev.toString();
    }
    GetSpartan_BR_Actions_True_Detail_Spartan_BR_ActionItem(operations, events);
    Spartan_BR_Actions_True_DetailTable.fnAddData(Spartan_BR_Actions_True_DetailAddInsertRow(), true);
    GetActionClassification('Action_Classification_' + Spartan_BR_Actions_True_DetailinsertRowCurrentIndex);
    GetActionResult('Action_Result_' + Spartan_BR_Actions_True_DetailinsertRowCurrentIndex);
    Spartan_BR_Actions_True_DetailTable.fnPageChange('last');
    initiateUIControls();
    EjecutarValidacionesNewRowMRSpartan_BR_Actions_True_Detail("Spartan_BR_Actions_True_Detail_", "_" + Spartan_BR_Actions_True_DetailinsertRowCurrentIndex);
    Spartan_BR_Actions_True_DetailcountRowsChecked++;
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

//Used to Get Business Rule Creation Information
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
    //if (EjecutarValidacionesAntesDeGuardarMRSpartan_BR_Actions_True_Detail("Spartan_BR_Actions_True_DetailTable", rowIndex)) {
    var prevData = Spartan_BR_Actions_True_DetailTable.fnGetData(rowIndex);
    var data = Spartan_BR_Actions_True_DetailTable.fnGetNodes(rowIndex);
    var newData = {
        ActionsTrueDetailId: prevData.ActionsTrueDetailId,
        IsInsertRow: false
        , Action_Classification: $('#Spartan_BR_Actions_True_DetailAction_Classification').val()
        , Action: $('#Spartan_BR_Actions_True_DetailAction').val()
        , Action_Result: $('#Spartan_BR_Actions_True_DetailAction_Result').val()
        , Parameter_1: $('#Spartan_BR_Actions_True_DetailParameter_1').val()
        , Parameter_2: $('#Spartan_BR_Actions_True_DetailParameter_2').val()
        , Parameter_3: $('#Spartan_BR_Actions_True_DetailParameter_3').val()
        , Parameter_4: $('#Spartan_BR_Actions_True_DetailParameter_4').val()
        , Parameter_5: $('#Spartan_BR_Actions_True_DetailParameter_5').val()

    }

    Spartan_BR_Actions_True_DetailTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_BR_Actions_True_DetailrowCreationGrid(data, newData, rowIndex);
    $('#AddSpartan_BR_Actions_True_Detail-form').modal({ show: false });
    $('#AddSpartan_BR_Actions_True_Detail-form').modal('hide');
    Spartan_BR_Actions_True_DetailEditRow(rowIndex);
    Spartan_BR_Actions_True_DetailInsertRow(rowIndex);
    //}
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

    $('<option />', { value: '', text: '' }).appendTo(Spartan_BR_Actions_False_Detail_Spartan_BR_Action_ClassificationDropdown);
    if (Spartan_BR_Actions_False_Detail_Spartan_BR_Action_ClassificationItems != null) {
        for (var i = 0; i < Spartan_BR_Actions_False_Detail_Spartan_BR_Action_ClassificationItems.length; i++) {
            $('<option />', { value: Spartan_BR_Actions_False_Detail_Spartan_BR_Action_ClassificationItems[i].ClassificationId, text: Spartan_BR_Actions_False_Detail_Spartan_BR_Action_ClassificationItems[i].Description }).appendTo(Spartan_BR_Actions_False_Detail_Spartan_BR_Action_ClassificationDropdown);
        }
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

    $('<option />', { value: '', text: '' }).appendTo(Spartan_BR_Actions_False_Detail_Spartan_BR_ActionDropdown);
    if (Spartan_BR_Actions_False_Detail_Spartan_BR_ActionItems != null) {
        for (var i = 0; i < Spartan_BR_Actions_False_Detail_Spartan_BR_ActionItems.length; i++) {
            $('<option />', { value: Spartan_BR_Actions_False_Detail_Spartan_BR_ActionItems[i].ActionId, text: Spartan_BR_Actions_False_Detail_Spartan_BR_ActionItems[i].Description }).appendTo(Spartan_BR_Actions_False_Detail_Spartan_BR_ActionDropdown);
        }
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

    $('<option />', { value: '', text: '' }).appendTo(Spartan_BR_Actions_False_Detail_Spartan_BR_Action_ResultDropdown);
    if (Spartan_BR_Actions_False_Detail_Spartan_BR_Action_ResultItems != null) {
        for (var i = 0; i < Spartan_BR_Actions_False_Detail_Spartan_BR_Action_ResultItems.length; i++) {
            $('<option />', { value: Spartan_BR_Actions_False_Detail_Spartan_BR_Action_ResultItems[i].ActionResultId, text: Spartan_BR_Actions_False_Detail_Spartan_BR_Action_ResultItems[i].Description }).appendTo(Spartan_BR_Actions_False_Detail_Spartan_BR_Action_ResultDropdown);
        }
    }
    return Spartan_BR_Actions_False_Detail_Spartan_BR_Action_ResultDropdown;
}


function GetInsertSpartan_BR_Actions_False_DetailRowControls(index) {
    /*var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $(GetSpartan_BR_Actions_False_Detail_Spartan_BR_Action_ClassificationDropDown()).addClass('Spartan_BR_Actions_False_Detail_Action_Classification Action_Classification').attr('id', 'Spartan_BR_Actions_False_Detail_Action_Classification_' + index).attr('data-field', 'Action_Classification');
    columnData[1] = $(GetSpartan_BR_Actions_False_Detail_Spartan_BR_ActionDropDown()).addClass('Spartan_BR_Actions_False_Detail_Action Action').attr('id', 'Spartan_BR_Actions_False_Detail_Action_' + index).attr('data-field', 'Action');
    columnData[2] = $(GetSpartan_BR_Actions_False_Detail_Spartan_BR_Action_ResultDropDown()).addClass('Spartan_BR_Actions_False_Detail_Action_Result Action_Result').attr('id', 'Spartan_BR_Actions_False_Detail_Action_Result_' + index).attr('data-field', 'Action_Result');
    columnData[3] = $($.parseHTML(inputData)).addClass('Spartan_BR_Actions_False_Detail_Parameter_1 Parameter_1').attr('id', 'Spartan_BR_Actions_False_Detail_Parameter_1_' + index).attr('data-field', 'Parameter_1');
    columnData[4] = $($.parseHTML(inputData)).addClass('Spartan_BR_Actions_False_Detail_Parameter_2 Parameter_2').attr('id', 'Spartan_BR_Actions_False_Detail_Parameter_2_' + index).attr('data-field', 'Parameter_2');
    columnData[5] = $($.parseHTML(inputData)).addClass('Spartan_BR_Actions_False_Detail_Parameter_3 Parameter_3').attr('id', 'Spartan_BR_Actions_False_Detail_Parameter_3_' + index).attr('data-field', 'Parameter_3');
    columnData[6] = $($.parseHTML(inputData)).addClass('Spartan_BR_Actions_False_Detail_Parameter_4 Parameter_4').attr('id', 'Spartan_BR_Actions_False_Detail_Parameter_4_' + index).attr('data-field', 'Parameter_4');
    columnData[7] = $($.parseHTML(inputData)).addClass('Spartan_BR_Actions_False_Detail_Parameter_5 Parameter_5').attr('id', 'Spartan_BR_Actions_False_Detail_Parameter_5_' + index).attr('data-field', 'Parameter_5');


    initiateUIControls();
    return columnData;*/
    var columnData = [];
    var ddlActionClassification = $(getDropdown('Action_Classification', index, Spartan_BR_Actions_False_DetailinsertRowCurrentIndex));
    var ddlAction = $(getDropdown('Action', index, Spartan_BR_Actions_False_DetailinsertRowCurrentIndex));
    var ddlActionResult = $(getDropdown('Action_Result', index, Spartan_BR_Actions_False_DetailinsertRowCurrentIndex));
    var inputParameter1 = $(getDropdownAndTextbox('Parameter_1', index, Spartan_BR_Actions_False_DetailinsertRowCurrentIndex));
    var inputParameter2 = $(getDropdownAndTextbox('Parameter_2', index, Spartan_BR_Actions_False_DetailinsertRowCurrentIndex));
    var inputParameter3 = $(getDropdownAndTextbox('Parameter_3', index, Spartan_BR_Actions_False_DetailinsertRowCurrentIndex));
    var inputParameter4 = $(getDropdownAndTextbox('Parameter_4', index, Spartan_BR_Actions_False_DetailinsertRowCurrentIndex));
    var inputParameter5 = $(getDropdownAndTextbox('Parameter_5', index, Spartan_BR_Actions_False_DetailinsertRowCurrentIndex));
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

function Spartan_BR_Actions_False_DetailInsertRow(rowIndex) {
    if (EjecutarValidacionesAntesDeGuardarMRSpartan_BR_Actions_False_Detail("Spartan_BR_Actions_False_Detail_", "_" + rowIndex)) {
        var iPage = Spartan_BR_Actions_False_DetailTable.fnPagingInfo().iPage;
        var nameOfGrid = 'Spartan_BR_Actions_False_Detail';
        var prevData = Spartan_BR_Actions_False_DetailTable.fnGetData(rowIndex);
        var data = Spartan_BR_Actions_False_DetailTable.fnGetNodes(rowIndex);
        var counter = 1;
        var newData = {
            ActionsFalseDetailId: prevData.ActionsFalseDetailId,
            IsInsertRow: false
            , Action_Classification: ($('#' + nameOfGrid + 'Grid .Action_ClassificationHeader').css('display') != 'none') ? data.childNodes[1].childNodes[0].value : ''
            , Action: ($('#' + nameOfGrid + 'Grid .ActionHeader').css('display') != 'none') ? data.childNodes[2].childNodes[0].value : ''
            , Action_Result: ($('#' + nameOfGrid + 'Grid .Action_ResultHeader').css('display') != 'none') ? data.childNodes[3].childNodes[0].value : ''
            , Parameter_1: (data.childNodes[4].childNodes.length == 2) ? '' : ((data.childNodes[4].childNodes[1].value == '') ? data.childNodes[4].childNodes[2].value : $('#' + $(data.childNodes[4].childNodes[1])[0].id + ' option:selected').text()),
            Parameter_2: (data.childNodes[5].childNodes.length == 2) ? '' : ((data.childNodes[5].childNodes[1].value == '') ? (data.childNodes[5].childNodes[2].value == null ? '' : data.childNodes[5].childNodes[2].value) : $('#' + $(data.childNodes[5].childNodes[1])[0].id + ' option:selected').text()),
            Parameter_3: (data.childNodes[6].childNodes.length == 2) ? '' : ((data.childNodes[6].childNodes[1].value == '') ? (data.childNodes[6].childNodes[2].value == null ? '' : data.childNodes[6].childNodes[2].value) : $('#' + $(data.childNodes[6].childNodes[1])[0].id + ' option:selected').text()),
            Parameter_4: (data.childNodes[7].childNodes.length == 2) ? '' : ((data.childNodes[7].childNodes[1].value == '') ? (data.childNodes[7].childNodes[2].value == null ? '' : data.childNodes[7].childNodes[2].value) : $('#' + $(data.childNodes[7].childNodes[1])[0].id + ' option:selected').text()),
            Parameter_5: (data.childNodes[8].childNodes.length == 2) ? '' : ((data.childNodes[8].childNodes[1].value == '') ? (data.childNodes[8].childNodes[2].value == null ? '' : data.childNodes[8].childNodes[2].value) : $('#' + $(data.childNodes[8].childNodes[1])[0].id + ' option:selected').text()),

        }
        Spartan_BR_Actions_False_DetailTable.fnUpdate(newData, rowIndex, null, true);
        Spartan_BR_Actions_False_DetailrowCreationGrid(data, newData, rowIndex);
        Spartan_BR_Actions_False_DetailTable.fnPageChange(iPage);
        Spartan_BR_Actions_False_DetailcountRowsChecked--;
        EjecutarValidacionesDespuesDeGuardarMRSpartan_BR_Actions_False_Detail("Spartan_BR_Actions_False_Detail_", "_" + rowIndex);
    }
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
    showSpartan_BR_Actions_False_DetailGrid(Spartan_BR_Actions_False_DetailTable.fnGetData());
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
                , Action_Classification: gridData[i].Action_Classification
                , Action: gridData[i].Action
                , Action_Result: gridData[i].Action_Result
                , Parameter_1: gridData[i].Parameter_1
                , Parameter_2: gridData[i].Parameter_2
                , Parameter_3: gridData[i].Parameter_3
                , Parameter_4: gridData[i].Parameter_4
                , Parameter_5: gridData[i].Parameter_5

                , Removed: false
            });
    }

    for (i = 0; i < removedSpartan_BR_Actions_False_DetailData.length; i++) {
        if (removedSpartan_BR_Actions_False_DetailData[i] != null && removedSpartan_BR_Actions_False_DetailData[i].ActionsFalseDetailId > 0)
            Spartan_BR_Actions_False_DetailData.push({
                ActionsFalseDetailId: removedSpartan_BR_Actions_False_DetailData[i].ActionsFalseDetailId
                , Action_Classification: removedSpartan_BR_Actions_False_DetailData[i].Action_Classification
                , Action: removedSpartan_BR_Actions_False_DetailData[i].Action
                , Action_Result: removedSpartan_BR_Actions_False_DetailData[i].Action_Result
                , Parameter_1: removedSpartan_BR_Actions_False_DetailData[i].Parameter_1
                , Parameter_2: removedSpartan_BR_Actions_False_DetailData[i].Parameter_2
                , Parameter_3: removedSpartan_BR_Actions_False_DetailData[i].Parameter_3
                , Parameter_4: removedSpartan_BR_Actions_False_DetailData[i].Parameter_4
                , Parameter_5: removedSpartan_BR_Actions_False_DetailData[i].Parameter_5

                , Removed: true
            });
    }

    return Spartan_BR_Actions_False_DetailData;
}

function Spartan_BR_Actions_False_DetailEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Spartan_BR_Actions_False_DetailTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Spartan_BR_Actions_False_DetailcountRowsChecked++;
    var Spartan_BR_Actions_False_DetailRowElement = "Spartan_BR_Actions_False_Detail_" + rowIndex.toString();
    var prevData = Spartan_BR_Actions_False_DetailTable.fnGetData(rowIndexTable);
    var row = Spartan_BR_Actions_False_DetailTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Spartan_BR_Actions_False_Detail_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Spartan_BR_Actions_False_DetailGetUpdateRowControls(prevData, "Spartan_BR_Actions_False_Detail_", rowIndex);

    var abc = "if(dynamicFieldValidation('" + Spartan_BR_Actions_False_DetailRowElement + "')){ Spartan_BR_Actions_False_DetailInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Spartan_BR_Actions_False_DetailCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
        if ($('#Spartan_BR_Actions_False_DetailGrid .' + idHeader).css('display') != 'none') {
            $(controls[i]).appendTo($('<td id="td' + nameOfTable + idHeader.replace('Header', '') + rowIndexFormed + '">').appendTo(row));
        }
    }

    GetActionClassification('Action_Classification_' + rowIndex);
    GetActionResult('Action_Result_' + rowIndex);
    $('#Action_Classification_' + rowIndex).val(prevData.Action_Classification).change();
    $('#Action_' + rowIndex).val(prevData.Action).change();
    $('#Action_Result_' + rowIndex).val(prevData.Action_Result);
    $('#txtParameter_1_' + rowIndex).val(prevData.Parameter_1);
    $('#txtParameter_2_' + rowIndex).val(prevData.Parameter_2);
    $('#txtParameter_3_' + rowIndex).val(prevData.Parameter_3);
    $('#txtParameter_4_' + rowIndex).val(prevData.Parameter_4);
    $('#txtParameter_5_' + rowIndex).val(prevData.Parameter_5);
    var valParam1 = $('#ddlParameter_1_' + rowIndex + ' option').filter(function () { return $(this).html() == prevData.Parameter_1; }).val();
    $('#ddlParameter_1_' + rowIndex).val(valParam1);
    var valParam2 = $('#ddlParameter_2_' + rowIndex + ' option').filter(function () { return $(this).html() == prevData.Parameter_2; }).val();
    $('#ddlParameter_2_' + rowIndex).val(valParam2);
    var valParam3 = $('#ddlParameter_3_' + rowIndex + ' option').filter(function () { return $(this).html() == prevData.Parameter_3; }).val();
    $('#ddlParameter_3_' + rowIndex).val(valParam3);
    var valParam4 = $('#ddlParameter_4_' + rowIndex + ' option').filter(function () { return $(this).html() == prevData.Parameter_4; }).val();
    $('#ddlParameter_4_' + rowIndex).val(valParam4);
    var valParam5 = $('#ddlParameter_5_' + rowIndex + ' option').filter(function () { return $(this).html() == prevData.Parameter_5; }).val();
    $('#ddlParameter_5_' + rowIndex).val(valParam5);
    $('.Spartan_BR_Actions_True_Detail' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.Spartan_BR_Actions_False_Detail' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    setSpartan_BR_Actions_False_DetailValidation();
    initiateUIControls();
    if (executeRules == null || (executeRules != null && executeRules == true)) {
        EjecutarValidacionesEditRowMRSpartan_BR_Actions_False_Detail(nameOfTable, rowIndexFormed);
    }
}

function Spartan_BR_Actions_False_DetailfnOpenAddRowPopUp() {
    var currentRowIndex = Spartan_BR_Actions_False_DetailTable.fnGetData().length;
    Spartan_BR_Actions_False_DetailfnClickAddRow();
    GetAddSpartan_BR_Actions_False_DetailPopup(currentRowIndex, 0);
}

function Spartan_BR_Actions_False_DetailEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Spartan_BR_Actions_False_DetailTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Spartan_BR_Actions_False_DetailRowElement = "Spartan_BR_Actions_False_Detail_" + rowIndex.toString();
    var prevData = Spartan_BR_Actions_False_DetailTable.fnGetData(rowIndexTable);
    GetAddSpartan_BR_Actions_False_DetailPopup(rowIndex, 1, prevData.ActionsFalseDetailId);
    $('#Spartan_BR_Actions_False_DetailAction_Classification').val(prevData.Action_Classification);
    $('#Spartan_BR_Actions_False_DetailAction').val(prevData.Action);
    $('#Spartan_BR_Actions_False_DetailAction_Result').val(prevData.Action_Result);
    $('#Spartan_BR_Actions_False_DetailParameter_1').val(prevData.Parameter_1);
    $('#Spartan_BR_Actions_False_DetailParameter_2').val(prevData.Parameter_2);
    $('#Spartan_BR_Actions_False_DetailParameter_3').val(prevData.Parameter_3);
    $('#Spartan_BR_Actions_False_DetailParameter_4').val(prevData.Parameter_4);
    $('#Spartan_BR_Actions_False_DetailParameter_5').val(prevData.Parameter_5);

    initiateUIControls();

}

function Spartan_BR_Actions_False_DetailAddInsertRow() {
    if (Spartan_BR_Actions_False_DetailinsertRowCurrentIndex < 1) {
        Spartan_BR_Actions_False_DetailinsertRowCurrentIndex = 1;
    }
    return {
        ActionsFalseDetailId: null,
        IsInsertRow: true
        , Action_Classification: ""
        , Action: ""
        , Action_Result: ""
        , Parameter_1: ""
        , Parameter_2: ""
        , Parameter_3: ""
        , Parameter_4: ""
        , Parameter_5: ""

    }
}

function Spartan_BR_Actions_False_DetailfnClickAddRow() {
    Spartan_BR_Actions_False_DetailTable.fnAddData(Spartan_BR_Actions_False_DetailAddInsertRow(), true);
    GetActionClassification('Action_Classification_' + Spartan_BR_Actions_False_DetailinsertRowCurrentIndex);
    GetActionResult('Action_Result_' + Spartan_BR_Actions_False_DetailinsertRowCurrentIndex);
    Spartan_BR_Actions_False_DetailTable.fnPageChange('last');
    initiateUIControls();
    EjecutarValidacionesNewRowMRSpartan_BR_Actions_False_Detail("Spartan_BR_Actions_False_Detail_", "_" + Spartan_BR_Actions_False_DetailinsertRowCurrentIndex);
    Spartan_BR_Actions_False_DetailcountRowsChecked++;
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

//Used to Get Business Rule Creation Information
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
    //if (EjecutarValidacionesAntesDeGuardarMRSpartan_BR_Actions_False_Detail("Spartan_BR_Actions_False_DetailTable", rowIndex)) {
    var prevData = Spartan_BR_Actions_False_DetailTable.fnGetData(rowIndex);
    var data = Spartan_BR_Actions_False_DetailTable.fnGetNodes(rowIndex);
    var newData = {
        ActionsFalseDetailId: prevData.ActionsFalseDetailId,
        IsInsertRow: false
        , Action_Classification: $('#Spartan_BR_Actions_False_DetailAction_Classification').val()
        , Action: $('#Spartan_BR_Actions_False_DetailAction').val()
        , Action_Result: $('#Spartan_BR_Actions_False_DetailAction_Result').val()
        , Parameter_1: $('#Spartan_BR_Actions_False_DetailParameter_1').val()
        , Parameter_2: $('#Spartan_BR_Actions_False_DetailParameter_2').val()
        , Parameter_3: $('#Spartan_BR_Actions_False_DetailParameter_3').val()
        , Parameter_4: $('#Spartan_BR_Actions_False_DetailParameter_4').val()
        , Parameter_5: $('#Spartan_BR_Actions_False_DetailParameter_5').val()

    }

    Spartan_BR_Actions_False_DetailTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_BR_Actions_False_DetailrowCreationGrid(data, newData, rowIndex);
    $('#AddSpartan_BR_Actions_False_Detail-form').modal({ show: false });
    $('#AddSpartan_BR_Actions_False_Detail-form').modal('hide');
    Spartan_BR_Actions_False_DetailEditRow(rowIndex);
    Spartan_BR_Actions_False_DetailInsertRow(rowIndex);
    //}
}
function Spartan_BR_Actions_False_DetailRemoveAddRow(rowIndex) {
    Spartan_BR_Actions_False_DetailTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Spartan_BR_Actions_False_Detail MultiRow
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

    $('<option />', { value: '', text: '' }).appendTo(Spartan_BR_Operation_Detail_Spartan_BR_OperationDropdown);
    if (Spartan_BR_Operation_Detail_Spartan_BR_OperationItems != null) {
        for (var i = 0; i < Spartan_BR_Operation_Detail_Spartan_BR_OperationItems.length; i++) {
            $('<option />', { value: Spartan_BR_Operation_Detail_Spartan_BR_OperationItems[i].OperationId, text: Spartan_BR_Operation_Detail_Spartan_BR_OperationItems[i].Description }).appendTo(Spartan_BR_Operation_Detail_Spartan_BR_OperationDropdown);
        }
    }
    return Spartan_BR_Operation_Detail_Spartan_BR_OperationDropdown;
}


function GetInsertSpartan_BR_Operation_DetailRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $(GetSpartan_BR_Operation_Detail_Spartan_BR_OperationDropDown()).addClass('Spartan_BR_Operation_Detail_Operation Operation').attr('id', 'Spartan_BR_Operation_Detail_Operation_' + index).attr('data-field', 'Operation');


    initiateUIControls();
    return columnData;
}

function Spartan_BR_Operation_DetailInsertRow(rowIndex) {
    if (EjecutarValidacionesAntesDeGuardarMRSpartan_BR_Operation_Detail("Spartan_BR_Operation_Detail_", "_" + rowIndex)) {
        var iPage = Spartan_BR_Operation_DetailTable.fnPagingInfo().iPage;
        var nameOfGrid = 'Spartan_BR_Operation_Detail';
        var prevData = Spartan_BR_Operation_DetailTable.fnGetData(rowIndex);
        var data = Spartan_BR_Operation_DetailTable.fnGetNodes(rowIndex);
        var counter = 1;
        var newData = {
            OperationDetailId: prevData.OperationDetailId,
            IsInsertRow: false
            , Operation: ($('#' + nameOfGrid + 'Grid .OperationHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''

        }
        Spartan_BR_Operation_DetailTable.fnUpdate(newData, rowIndex, null, true);
        Spartan_BR_Operation_DetailrowCreationGrid(data, newData, rowIndex);
        Spartan_BR_Operation_DetailTable.fnPageChange(iPage);
        Spartan_BR_Operation_DetailcountRowsChecked--;
        EjecutarValidacionesDespuesDeGuardarMRSpartan_BR_Operation_Detail("Spartan_BR_Operation_Detail_", "_" + rowIndex);
    }
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
    showSpartan_BR_Operation_DetailGrid(Spartan_BR_Operation_DetailTable.fnGetData());
    Spartan_BR_Operation_DetailcountRowsChecked--;
}

function GetSpartan_BR_Operation_DetailFromDataTable() {
    var Spartan_BR_Operation_DetailData = [];
    var gridData = [];
    $('#Operations option:selected').each(function (i, selected) {
        gridData[i] = $(selected).val();
    });
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        Spartan_BR_Operation_DetailData.push({
            OperationDetailId: 0
                , Operation: gridData[i]
        });
    }

    return Spartan_BR_Operation_DetailData;
}

function Spartan_BR_Operation_DetailEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Spartan_BR_Operation_DetailTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Spartan_BR_Operation_DetailcountRowsChecked++;
    var Spartan_BR_Operation_DetailRowElement = "Spartan_BR_Operation_Detail_" + rowIndex.toString();
    var prevData = Spartan_BR_Operation_DetailTable.fnGetData(rowIndexTable);
    var row = Spartan_BR_Operation_DetailTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Spartan_BR_Operation_Detail_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Spartan_BR_Operation_DetailGetUpdateRowControls(prevData, "Spartan_BR_Operation_Detail_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Spartan_BR_Operation_DetailRowElement + "')){ Spartan_BR_Operation_DetailInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Spartan_BR_Operation_DetailCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
        if ($('#Spartan_BR_Operation_DetailGrid .' + idHeader).css('display') != 'none') {
            $(controls[i]).appendTo($('<td id="td' + nameOfTable + idHeader.replace('Header', '') + rowIndexFormed + '">').appendTo(row));
        }
    }
    $('.Spartan_BR_Operation_Detail' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    setSpartan_BR_Operation_DetailValidation();
    initiateUIControls();
    if (executeRules == null || (executeRules != null && executeRules == true)) {
        EjecutarValidacionesEditRowMRSpartan_BR_Operation_Detail(nameOfTable, rowIndexFormed);
    }
}

function Spartan_BR_Operation_DetailfnOpenAddRowPopUp() {
    var currentRowIndex = Spartan_BR_Operation_DetailTable.fnGetData().length;
    Spartan_BR_Operation_DetailfnClickAddRow();
    GetAddSpartan_BR_Operation_DetailPopup(currentRowIndex, 0);
}

function Spartan_BR_Operation_DetailEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Spartan_BR_Operation_DetailTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Spartan_BR_Operation_DetailRowElement = "Spartan_BR_Operation_Detail_" + rowIndex.toString();
    var prevData = Spartan_BR_Operation_DetailTable.fnGetData(rowIndexTable);
    GetAddSpartan_BR_Operation_DetailPopup(rowIndex, 1, prevData.OperationDetailId);
    $('#Spartan_BR_Operation_DetailOperation').val(prevData.Operation);

    initiateUIControls();

}

function Spartan_BR_Operation_DetailAddInsertRow() {
    if (Spartan_BR_Operation_DetailinsertRowCurrentIndex < 1) {
        Spartan_BR_Operation_DetailinsertRowCurrentIndex = 1;
    }
    return {
        OperationDetailId: null,
        IsInsertRow: true
        , Operation: ""

    }
}

function Spartan_BR_Operation_DetailfnClickAddRow() {
    Spartan_BR_Operation_DetailcountRowsChecked++;
    Spartan_BR_Operation_DetailTable.fnAddData(Spartan_BR_Operation_DetailAddInsertRow(), true);
    Spartan_BR_Operation_DetailTable.fnPageChange('last');
    initiateUIControls();
    EjecutarValidacionesNewRowMRSpartan_BR_Operation_Detail("Spartan_BR_Operation_Detail_", "_" + Spartan_BR_Operation_DetailinsertRowCurrentIndex);
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

//Used to Get Business Rule Creation Information
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
    //if (EjecutarValidacionesAntesDeGuardarMRSpartan_BR_Operation_Detail("Spartan_BR_Operation_DetailTable", rowIndex)) {
    var prevData = Spartan_BR_Operation_DetailTable.fnGetData(rowIndex);
    var data = Spartan_BR_Operation_DetailTable.fnGetNodes(rowIndex);
    var newData = {
        OperationDetailId: prevData.OperationDetailId,
        IsInsertRow: false
        , Operation: $('#Spartan_BR_Operation_DetailOperation').val()

    }

    Spartan_BR_Operation_DetailTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_BR_Operation_DetailrowCreationGrid(data, newData, rowIndex);
    $('#AddSpartan_BR_Operation_Detail-form').modal({ show: false });
    $('#AddSpartan_BR_Operation_Detail-form').modal('hide');
    Spartan_BR_Operation_DetailEditRow(rowIndex);
    Spartan_BR_Operation_DetailInsertRow(rowIndex);
    //}
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

    $('<option />', { value: '', text: '' }).appendTo(Spartan_BR_Process_Event_Detail_Spartan_BR_Process_EventDropdown);
    if (Spartan_BR_Process_Event_Detail_Spartan_BR_Process_EventItems != null) {
        for (var i = 0; i < Spartan_BR_Process_Event_Detail_Spartan_BR_Process_EventItems.length; i++) {
            $('<option />', { value: Spartan_BR_Process_Event_Detail_Spartan_BR_Process_EventItems[i].ProcessEventId, text: Spartan_BR_Process_Event_Detail_Spartan_BR_Process_EventItems[i].Description }).appendTo(Spartan_BR_Process_Event_Detail_Spartan_BR_Process_EventDropdown);
        }
    }
    return Spartan_BR_Process_Event_Detail_Spartan_BR_Process_EventDropdown;
}


function GetInsertSpartan_BR_Process_Event_DetailRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $(GetSpartan_BR_Process_Event_Detail_Spartan_BR_Process_EventDropDown()).addClass('Spartan_BR_Process_Event_Detail_Process_Event Process_Event').attr('id', 'Spartan_BR_Process_Event_Detail_Process_Event_' + index).attr('data-field', 'Process_Event');


    initiateUIControls();
    return columnData;
}

function Spartan_BR_Process_Event_DetailInsertRow(rowIndex) {
    if (EjecutarValidacionesAntesDeGuardarMRSpartan_BR_Process_Event_Detail("Spartan_BR_Process_Event_Detail_", "_" + rowIndex)) {
        var iPage = Spartan_BR_Process_Event_DetailTable.fnPagingInfo().iPage;
        var nameOfGrid = 'Spartan_BR_Process_Event_Detail';
        var prevData = Spartan_BR_Process_Event_DetailTable.fnGetData(rowIndex);
        var data = Spartan_BR_Process_Event_DetailTable.fnGetNodes(rowIndex);
        var counter = 1;
        var newData = {
            ProcessEventDetailId: prevData.ProcessEventDetailId,
            IsInsertRow: false
            , Process_Event: ($('#' + nameOfGrid + 'Grid .Process_EventHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''

        }
        Spartan_BR_Process_Event_DetailTable.fnUpdate(newData, rowIndex, null, true);
        Spartan_BR_Process_Event_DetailrowCreationGrid(data, newData, rowIndex);
        Spartan_BR_Process_Event_DetailTable.fnPageChange(iPage);
        Spartan_BR_Process_Event_DetailcountRowsChecked--;
        EjecutarValidacionesDespuesDeGuardarMRSpartan_BR_Process_Event_Detail("Spartan_BR_Process_Event_Detail_", "_" + rowIndex);
    }
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
    showSpartan_BR_Process_Event_DetailGrid(Spartan_BR_Process_Event_DetailTable.fnGetData());
    Spartan_BR_Process_Event_DetailcountRowsChecked--;
}

function GetSpartan_BR_Process_Event_DetailFromDataTable() {
    var Spartan_BR_Process_Event_DetailData = [];
    var gridData = [];
    $('#Events option:selected').each(function (i, selected) {
        gridData[i] = $(selected).val();
    });
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        Spartan_BR_Process_Event_DetailData.push({
            ProcessEventDetailId: 0
                , Process_Event: gridData[i]
        });
    }

    return Spartan_BR_Process_Event_DetailData;
}

function Spartan_BR_Process_Event_DetailEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Spartan_BR_Process_Event_DetailTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Spartan_BR_Process_Event_DetailcountRowsChecked++;
    var Spartan_BR_Process_Event_DetailRowElement = "Spartan_BR_Process_Event_Detail_" + rowIndex.toString();
    var prevData = Spartan_BR_Process_Event_DetailTable.fnGetData(rowIndexTable);
    var row = Spartan_BR_Process_Event_DetailTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Spartan_BR_Process_Event_Detail_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Spartan_BR_Process_Event_DetailGetUpdateRowControls(prevData, "Spartan_BR_Process_Event_Detail_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Spartan_BR_Process_Event_DetailRowElement + "')){ Spartan_BR_Process_Event_DetailInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Spartan_BR_Process_Event_DetailCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
        if ($('#Spartan_BR_Process_Event_DetailGrid .' + idHeader).css('display') != 'none') {
            $(controls[i]).appendTo($('<td id="td' + nameOfTable + idHeader.replace('Header', '') + rowIndexFormed + '">').appendTo(row));
        }
    }
    $('.Spartan_BR_Process_Event_Detail' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    setSpartan_BR_Process_Event_DetailValidation();
    initiateUIControls();
    if (executeRules == null || (executeRules != null && executeRules == true)) {
        EjecutarValidacionesEditRowMRSpartan_BR_Process_Event_Detail(nameOfTable, rowIndexFormed);
    }
}

function Spartan_BR_Process_Event_DetailfnOpenAddRowPopUp() {
    var currentRowIndex = Spartan_BR_Process_Event_DetailTable.fnGetData().length;
    Spartan_BR_Process_Event_DetailfnClickAddRow();
    GetAddSpartan_BR_Process_Event_DetailPopup(currentRowIndex, 0);
}

function Spartan_BR_Process_Event_DetailEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Spartan_BR_Process_Event_DetailTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Spartan_BR_Process_Event_DetailRowElement = "Spartan_BR_Process_Event_Detail_" + rowIndex.toString();
    var prevData = Spartan_BR_Process_Event_DetailTable.fnGetData(rowIndexTable);
    GetAddSpartan_BR_Process_Event_DetailPopup(rowIndex, 1, prevData.ProcessEventDetailId);
    $('#Spartan_BR_Process_Event_DetailProcess_Event').val(prevData.Process_Event);

    initiateUIControls();

}

function Spartan_BR_Process_Event_DetailAddInsertRow() {
    if (Spartan_BR_Process_Event_DetailinsertRowCurrentIndex < 1) {
        Spartan_BR_Process_Event_DetailinsertRowCurrentIndex = 1;
    }
    return {
        ProcessEventDetailId: null,
        IsInsertRow: true
        , Process_Event: ""

    }
}

function Spartan_BR_Process_Event_DetailfnClickAddRow() {
    Spartan_BR_Process_Event_DetailcountRowsChecked++;
    Spartan_BR_Process_Event_DetailTable.fnAddData(Spartan_BR_Process_Event_DetailAddInsertRow(), true);
    Spartan_BR_Process_Event_DetailTable.fnPageChange('last');
    initiateUIControls();
    EjecutarValidacionesNewRowMRSpartan_BR_Process_Event_Detail("Spartan_BR_Process_Event_Detail_", "_" + Spartan_BR_Process_Event_DetailinsertRowCurrentIndex);
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

//Used to Get Business Rule Creation Information
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
    //if (EjecutarValidacionesAntesDeGuardarMRSpartan_BR_Process_Event_Detail("Spartan_BR_Process_Event_DetailTable", rowIndex)) {
    var prevData = Spartan_BR_Process_Event_DetailTable.fnGetData(rowIndex);
    var data = Spartan_BR_Process_Event_DetailTable.fnGetNodes(rowIndex);
    var newData = {
        ProcessEventDetailId: prevData.ProcessEventDetailId,
        IsInsertRow: false
        , Process_Event: $('#Spartan_BR_Process_Event_DetailProcess_Event').val()

    }

    Spartan_BR_Process_Event_DetailTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_BR_Process_Event_DetailrowCreationGrid(data, newData, rowIndex);
    $('#AddSpartan_BR_Process_Event_Detail-form').modal({ show: false });
    $('#AddSpartan_BR_Process_Event_Detail-form').modal('hide');
    Spartan_BR_Process_Event_DetailEditRow(rowIndex);
    Spartan_BR_Process_Event_DetailInsertRow(rowIndex);
    //}
}
function Spartan_BR_Process_Event_DetailRemoveAddRow(rowIndex) {
    Spartan_BR_Process_Event_DetailTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Spartan_BR_Process_Event_Detail MultiRow
//Begin Declarations for Foreigns fields for Spartan_BR_Peer_Review MultiRow
var Spartan_BR_Peer_ReviewcountRowsChecked = 0;
function GetSpartan_BR_Peer_Review_Spartan_UserName(Id) {
    for (var i = 0; i < Spartan_BR_Peer_Review_Spartan_UserItems.length; i++) {
        if (Spartan_BR_Peer_Review_Spartan_UserItems[i].Id_User == Id) {
            return Spartan_BR_Peer_Review_Spartan_UserItems[i].Name;
        }
    }
    return "";
}

function GetSpartan_BR_Peer_Review_Spartan_UserDropDown() {
    var Spartan_BR_Peer_Review_Spartan_UserDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '' }).appendTo(Spartan_BR_Peer_Review_Spartan_UserDropdown);
    if (Spartan_BR_Peer_Review_Spartan_UserItems != null) {
        for (var i = 0; i < Spartan_BR_Peer_Review_Spartan_UserItems.length; i++) {
            $('<option />', { value: Spartan_BR_Peer_Review_Spartan_UserItems[i].Id_User, text: Spartan_BR_Peer_Review_Spartan_UserItems[i].Name }).appendTo(Spartan_BR_Peer_Review_Spartan_UserDropdown);
        }
    }
    return Spartan_BR_Peer_Review_Spartan_UserDropdown;
}
function GetSpartan_BR_Peer_Review_Spartan_BR_Rejection_ReasonName(Id) {
    for (var i = 0; i < Spartan_BR_Peer_Review_Spartan_BR_Rejection_ReasonItems.length; i++) {
        if (Spartan_BR_Peer_Review_Spartan_BR_Rejection_ReasonItems[i].Key_Rejection_Reason == Id) {
            return Spartan_BR_Peer_Review_Spartan_BR_Rejection_ReasonItems[i].Description;
        }
    }
    return "";
}

function GetSpartan_BR_Peer_Review_Spartan_BR_Rejection_ReasonDropDown() {
    var Spartan_BR_Peer_Review_Spartan_BR_Rejection_ReasonDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '' }).appendTo(Spartan_BR_Peer_Review_Spartan_BR_Rejection_ReasonDropdown);
    if (Spartan_BR_Peer_Review_Spartan_BR_Rejection_ReasonItems != null) {
        for (var i = 0; i < Spartan_BR_Peer_Review_Spartan_BR_Rejection_ReasonItems.length; i++) {
            $('<option />', { value: Spartan_BR_Peer_Review_Spartan_BR_Rejection_ReasonItems[i].Key_Rejection_Reason, text: Spartan_BR_Peer_Review_Spartan_BR_Rejection_ReasonItems[i].Description }).appendTo(Spartan_BR_Peer_Review_Spartan_BR_Rejection_ReasonDropdown);
        }
    }
    return Spartan_BR_Peer_Review_Spartan_BR_Rejection_ReasonDropdown;
}


function GetInsertSpartan_BR_Peer_ReviewRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $(GetSpartan_BR_Peer_Review_Spartan_UserDropDown()).addClass('Spartan_BR_Peer_Review_User_that_reviewed User_that_reviewed').attr('id', 'Spartan_BR_Peer_Review_User_that_reviewed_' + index).attr('data-field', 'User_that_reviewed');
    columnData[1] = $($.parseHTML(inputData)).addClass('Spartan_BR_Peer_Review_Acceptance_Criteria Acceptance_Criteria').attr('id', 'Spartan_BR_Peer_Review_Acceptance_Criteria_' + index).attr('data-field', 'Acceptance_Criteria');
    columnData[2] = $($.parseHTML(GetGridCheckBox())).addClass('Spartan_BR_Peer_Review_It_worked It_worked').attr('id', 'Spartan_BR_Peer_Review_It_worked_' + index).attr('data-field', 'It_worked');
    columnData[3] = $(GetSpartan_BR_Peer_Review_Spartan_BR_Rejection_ReasonDropDown()).addClass('Spartan_BR_Peer_Review_Rejection_reason Rejection_reason').attr('id', 'Spartan_BR_Peer_Review_Rejection_reason_' + index).attr('data-field', 'Rejection_reason');
    columnData[4] = $($.parseHTML(inputData)).addClass('Spartan_BR_Peer_Review_Comments Comments').attr('id', 'Spartan_BR_Peer_Review_Comments_' + index).attr('data-field', 'Comments');
    columnData[5] = $($.parseHTML(GetFileUploader())).addClass('Spartan_BR_Peer_Review_Evidence_FileUpload Evidence').attr('id', 'Spartan_BR_Peer_Review_Evidence_' + index).attr('data-field', 'Evidence');


    initiateUIControls();
    return columnData;
}

function Spartan_BR_Peer_ReviewInsertRow(rowIndex) {
    if (EjecutarValidacionesAntesDeGuardarMRSpartan_BR_Peer_Review("Spartan_BR_Peer_Review_", "_" + rowIndex)) {
        var iPage = Spartan_BR_Peer_ReviewTable.fnPagingInfo().iPage;
        var nameOfGrid = 'Spartan_BR_Peer_Review';
        var prevData = Spartan_BR_Peer_ReviewTable.fnGetData(rowIndex);
        var data = Spartan_BR_Peer_ReviewTable.fnGetNodes(rowIndex);
        var counter = 1;
        var newData = {
            Key_Peer_Review: prevData.Key_Peer_Review,
            IsInsertRow: false
            , User_that_reviewed: ($('#' + nameOfGrid + 'Grid .User_that_reviewedHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
            , Acceptance_Criteria: ($('#' + nameOfGrid + 'Grid .Acceptance_CriteriaHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
            , It_worked: ($('#' + nameOfGrid + 'Grid .It_workedHeader').css('display') != 'none') ? $(data.childNodes[counter++].childNodes[1]).is(':checked') : ''
            , Rejection_reason: ($('#' + nameOfGrid + 'Grid .Rejection_reasonHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
            , Comments: ($('#' + nameOfGrid + 'Grid .CommentsHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
            , EvidenceFileInfo: ($('#' + nameOfGrid + 'Grid .EvidenceHeader').css('display') != 'none') ? {
                FileName: prevData.EvidenceFileInfo != null && prevData.EvidenceFileInfo.FileName != null ? prevData.EvidenceFileInfo.FileName : (data.childNodes[counter].childNodes[0].files.length > 0 ? data.childNodes[counter].childNodes[0].files[0].name : ''),
                FileId: prevData.EvidenceFileInfo != null && prevData.EvidenceFileInfo.FileName != null ? prevData.EvidenceFileInfo.FileId : '0',
                FileSize: prevData.EvidenceFileInfo != null && prevData.EvidenceFileInfo.FileName != null ? prevData.EvidenceFileInfo.FileSize : (data.childNodes[counter].childNodes[0].files.length > 0 ? data.childNodes[counter].childNodes[0].files[0].name : '')
            } : ''
            , EvidenceDetail: (data.childNodes[counter] != 'undefined' && data.childNodes[counter].childNodes[0].childNodes.length == 0) ? data.childNodes[counter++].childNodes[0] : null

        }
        Spartan_BR_Peer_ReviewTable.fnUpdate(newData, rowIndex, null, true);
        Spartan_BR_Peer_ReviewrowCreationGrid(data, newData, rowIndex);
        Spartan_BR_Peer_ReviewTable.fnPageChange(iPage);
        Spartan_BR_Peer_ReviewcountRowsChecked--;
        EjecutarValidacionesDespuesDeGuardarMRSpartan_BR_Peer_Review("Spartan_BR_Peer_Review_", "_" + rowIndex);
    }
}

function Spartan_BR_Peer_ReviewCancelRow(rowIndex) {
    var prevData = Spartan_BR_Peer_ReviewTable.fnGetData(rowIndex);
    var data = Spartan_BR_Peer_ReviewTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Spartan_BR_Peer_ReviewTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Spartan_BR_Peer_ReviewrowCreationGrid(data, prevData, rowIndex);
    }
    showSpartan_BR_Peer_ReviewGrid(Spartan_BR_Peer_ReviewTable.fnGetData());
    Spartan_BR_Peer_ReviewcountRowsChecked--;
}

function GetSpartan_BR_Peer_ReviewFromDataTable() {
    var Spartan_BR_Peer_ReviewData = [];
    var gridData = Spartan_BR_Peer_ReviewTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Spartan_BR_Peer_ReviewData.push({
                Key_Peer_Review: gridData[i].Key_Peer_Review
                , User_that_reviewed: gridData[i].User_that_reviewed
                , Acceptance_Criteria: gridData[i].Acceptance_Criteria
                , It_worked: gridData[i].It_worked
                , Rejection_reason: gridData[i].Rejection_reason
                , Comments: gridData[i].Comments
                , EvidenceInfo: {
                    FileName: gridData[i].EvidenceFileInfo.FileName, FileId: gridData[i].EvidenceFileInfo.FileId, FileSize: gridData[i].EvidenceFileInfo.FileSize,
                    Control: gridData[i].EvidenceDetail != null && gridData[i].EvidenceDetail.files != null && gridData[i].EvidenceDetail.files.length > 0 ? gridData[i].EvidenceDetail.files[0] : null,
                    EvidenceRemoveFile: gridData[i].EvidenceDetail != null
                }

                , Removed: false
            });
    }

    for (i = 0; i < removedSpartan_BR_Peer_ReviewData.length; i++) {
        if (removedSpartan_BR_Peer_ReviewData[i] != null && removedSpartan_BR_Peer_ReviewData[i].Key_Peer_Review > 0)
            Spartan_BR_Peer_ReviewData.push({
                Key_Peer_Review: removedSpartan_BR_Peer_ReviewData[i].Key_Peer_Review
                , User_that_reviewed: removedSpartan_BR_Peer_ReviewData[i].User_that_reviewed
                , Acceptance_Criteria: removedSpartan_BR_Peer_ReviewData[i].Acceptance_Criteria
                , It_worked: removedSpartan_BR_Peer_ReviewData[i].It_worked
                , Rejection_reason: removedSpartan_BR_Peer_ReviewData[i].Rejection_reason
                , Comments: removedSpartan_BR_Peer_ReviewData[i].Comments
                , EvidenceInfo: {
                    FileName: removedSpartan_BR_Peer_ReviewData[i].EvidenceFileInfo.FileName,
                    FileId: removedSpartan_BR_Peer_ReviewData[i].EvidenceFileInfo.FileId,
                    FileSize: removedSpartan_BR_Peer_ReviewData[i].EvidenceFileInfo.FileSize,
                    Control: removedSpartan_BR_Peer_ReviewData[i].EvidenceDetail != null && removedSpartan_BR_Peer_ReviewData[i].EvidenceDetail.files.length > 0 ? removedSpartan_BR_Peer_ReviewData[i].EvidenceDetail.files[0] : null,
                    EvidenceRemoveFile: removedSpartan_BR_Peer_ReviewData[i].EvidenceDetail != null
                }

                , Removed: true
            });
    }

    return Spartan_BR_Peer_ReviewData;
}

function Spartan_BR_Peer_ReviewEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Spartan_BR_Peer_ReviewTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Spartan_BR_Peer_ReviewcountRowsChecked++;
    var Spartan_BR_Peer_ReviewRowElement = "Spartan_BR_Peer_Review_" + rowIndex.toString();
    var prevData = Spartan_BR_Peer_ReviewTable.fnGetData(rowIndexTable);
    var row = Spartan_BR_Peer_ReviewTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Spartan_BR_Peer_Review_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Spartan_BR_Peer_ReviewGetUpdateRowControls(prevData, "Spartan_BR_Peer_Review_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Spartan_BR_Peer_ReviewRowElement + "')){ Spartan_BR_Peer_ReviewInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Spartan_BR_Peer_ReviewCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
        if ($('#Spartan_BR_Peer_ReviewGrid .' + idHeader).css('display') != 'none') {
            $(controls[i]).appendTo($('<td id="td' + nameOfTable + idHeader.replace('Header', '') + rowIndexFormed + '">').appendTo(row));
        }
    }
    $('.Spartan_BR_Peer_Review' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    setSpartan_BR_Peer_ReviewValidation();
    initiateUIControls();
    if (executeRules == null || (executeRules != null && executeRules == true)) {
        EjecutarValidacionesEditRowMRSpartan_BR_Peer_Review(nameOfTable, rowIndexFormed);
    }
}

function Spartan_BR_Peer_ReviewfnOpenAddRowPopUp() {
    var currentRowIndex = Spartan_BR_Peer_ReviewTable.fnGetData().length;
    Spartan_BR_Peer_ReviewfnClickAddRow();
    GetAddSpartan_BR_Peer_ReviewPopup(currentRowIndex, 0);
}

function Spartan_BR_Peer_ReviewEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Spartan_BR_Peer_ReviewTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Spartan_BR_Peer_ReviewRowElement = "Spartan_BR_Peer_Review_" + rowIndex.toString();
    var prevData = Spartan_BR_Peer_ReviewTable.fnGetData(rowIndexTable);
    GetAddSpartan_BR_Peer_ReviewPopup(rowIndex, 1, prevData.Key_Peer_Review);
    $('#Spartan_BR_Peer_ReviewUser_that_reviewed').val(prevData.User_that_reviewed);
    $('#Spartan_BR_Peer_ReviewAcceptance_Criteria').val(prevData.Acceptance_Criteria);
    $('#Spartan_BR_Peer_ReviewIt_worked').prop('checked', prevData.It_worked);
    $('#Spartan_BR_Peer_ReviewRejection_reason').val(prevData.Rejection_reason);
    $('#Spartan_BR_Peer_ReviewComments').val(prevData.Comments);

    initiateUIControls();
    $('#existingEvidence').html(prevData.EvidenceFileDetail == null && (prevData.EvidenceFileInfo.FileId == null || prevData.EvidenceFileInfo.FileId <= 0) ? $.parseHTML(GetFileUploader()) : GetFileInfo(prevData.EvidenceFileInfo, prevData.EvidenceFileDetail));

}

function Spartan_BR_Peer_ReviewAddInsertRow() {
    if (Spartan_BR_Peer_ReviewinsertRowCurrentIndex < 1) {
        Spartan_BR_Peer_ReviewinsertRowCurrentIndex = 1;
    }
    return {
        Key_Peer_Review: null,
        IsInsertRow: true
        , User_that_reviewed: ""
        , Acceptance_Criteria: ""
        , It_worked: ""
        , Rejection_reason: ""
        , Comments: ""
        , EvidenceFileInfo: ""

    }
}

function Spartan_BR_Peer_ReviewfnClickAddRow() {
    Spartan_BR_Peer_ReviewcountRowsChecked++;
    Spartan_BR_Peer_ReviewTable.fnAddData(Spartan_BR_Peer_ReviewAddInsertRow(), true);
    Spartan_BR_Peer_ReviewTable.fnPageChange('last');
    initiateUIControls();
    EjecutarValidacionesNewRowMRSpartan_BR_Peer_Review("Spartan_BR_Peer_Review_", "_" + Spartan_BR_Peer_ReviewinsertRowCurrentIndex);
}

function Spartan_BR_Peer_ReviewClearGridData() {
    Spartan_BR_Peer_ReviewData = [];
    Spartan_BR_Peer_ReviewdeletedItem = [];
    Spartan_BR_Peer_ReviewDataMain = [];
    Spartan_BR_Peer_ReviewDataMainPages = [];
    Spartan_BR_Peer_ReviewnewItemCount = 0;
    Spartan_BR_Peer_ReviewmaxItemIndex = 0;
    $("#Spartan_BR_Peer_ReviewGrid").DataTable().clear();
    $("#Spartan_BR_Peer_ReviewGrid").DataTable().destroy();
}

//Used to Get Business Rule Creation Information
function GetSpartan_BR_Peer_Review() {
    var form_data = new FormData();
    for (var i = 0; i < Spartan_BR_Peer_ReviewData.length; i++) {
        form_data.append('[' + i + '].Key_Peer_Review', Spartan_BR_Peer_ReviewData[i].Key_Peer_Review);
        form_data.append('[' + i + '].User_that_reviewed', Spartan_BR_Peer_ReviewData[i].User_that_reviewed);
        form_data.append('[' + i + '].Acceptance_Criteria', Spartan_BR_Peer_ReviewData[i].Acceptance_Criteria);
        form_data.append('[' + i + '].It_worked', Spartan_BR_Peer_ReviewData[i].It_worked);
        form_data.append('[' + i + '].Rejection_reason', Spartan_BR_Peer_ReviewData[i].Rejection_reason);
        form_data.append('[' + i + '].Comments', Spartan_BR_Peer_ReviewData[i].Comments);
        form_data.append('[' + i + '].EvidenceInfo.FileId', Spartan_BR_Peer_ReviewData[i].EvidenceInfo.FileId);
        form_data.append('[' + i + '].EvidenceInfo.FileName', Spartan_BR_Peer_ReviewData[i].EvidenceInfo.FileName);
        form_data.append('[' + i + '].EvidenceInfo.FileSize', Spartan_BR_Peer_ReviewData[i].EvidenceInfo.FileSize);
        form_data.append('[' + i + '].EvidenceInfo.Control', Spartan_BR_Peer_ReviewData[i].EvidenceInfo.Control);
        form_data.append('[' + i + '].EvidenceInfo.RemoveFile', Spartan_BR_Peer_ReviewData[i].EvidenceInfo.ArchivoRemoveFile);

        form_data.append('[' + i + '].Removed', Spartan_BR_Peer_ReviewData[i].Removed);
    }
    return form_data;
}
function Spartan_BR_Peer_ReviewInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRSpartan_BR_Peer_Review("Spartan_BR_Peer_ReviewTable", rowIndex)) {
    var prevData = Spartan_BR_Peer_ReviewTable.fnGetData(rowIndex);
    var data = Spartan_BR_Peer_ReviewTable.fnGetNodes(rowIndex);
    var newData = {
        Key_Peer_Review: prevData.Key_Peer_Review,
        IsInsertRow: false
        , User_that_reviewed: $('#Spartan_BR_Peer_ReviewUser_that_reviewed').val()
        , Acceptance_Criteria: $('#Spartan_BR_Peer_ReviewAcceptance_Criteria').val()
        , It_worked: $('#Spartan_BR_Peer_ReviewIt_worked').is(':checked')
        , Rejection_reason: $('#Spartan_BR_Peer_ReviewRejection_reason').val()
        , Comments: $('#Spartan_BR_Peer_ReviewComments').val()
        , EvidenceFileInfo: { EvidenceFileName: prevData.EvidenceFileInfo.FileName, EvidenceFileId: prevData.EvidenceFileInfo.FileId, EvidenceFileSize: prevData.EvidenceFileInfo.FileSize }
        , EvidenceFileDetail: $('#Evidence').find('label').length == 0 ? $('#EvidenceFileInfoPop')[0] : prevData.EvidenceFileDetail

    }

    Spartan_BR_Peer_ReviewTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_BR_Peer_ReviewrowCreationGrid(data, newData, rowIndex);
    $('#AddSpartan_BR_Peer_Review-form').modal({ show: false });
    $('#AddSpartan_BR_Peer_Review-form').modal('hide');
    Spartan_BR_Peer_ReviewEditRow(rowIndex);
    Spartan_BR_Peer_ReviewInsertRow(rowIndex);
    //}
}
function Spartan_BR_Peer_ReviewRemoveAddRow(rowIndex) {
    Spartan_BR_Peer_ReviewTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Spartan_BR_Peer_Review MultiRow
//Begin Declarations for Foreigns fields for Spartan_BR_Testing MultiRow
var Spartan_BR_TestingcountRowsChecked = 0;
function GetSpartan_BR_Testing_Spartan_UserName(Id) {
    for (var i = 0; i < Spartan_BR_Testing_Spartan_UserItems.length; i++) {
        if (Spartan_BR_Testing_Spartan_UserItems[i].Id_User == Id) {
            return Spartan_BR_Testing_Spartan_UserItems[i].Name;
        }
    }
    return "";
}

function GetSpartan_BR_Testing_Spartan_UserDropDown() {
    var Spartan_BR_Testing_Spartan_UserDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '' }).appendTo(Spartan_BR_Testing_Spartan_UserDropdown);
    if (Spartan_BR_Testing_Spartan_UserItems != null) {
        for (var i = 0; i < Spartan_BR_Testing_Spartan_UserItems.length; i++) {
            $('<option />', { value: Spartan_BR_Testing_Spartan_UserItems[i].Id_User, text: Spartan_BR_Testing_Spartan_UserItems[i].Name }).appendTo(Spartan_BR_Testing_Spartan_UserDropdown);
        }
    }
    return Spartan_BR_Testing_Spartan_UserDropdown;
}
function GetSpartan_BR_Testing_Spartan_BR_Rejection_ReasonName(Id) {
    for (var i = 0; i < Spartan_BR_Testing_Spartan_BR_Rejection_ReasonItems.length; i++) {
        if (Spartan_BR_Testing_Spartan_BR_Rejection_ReasonItems[i].Key_Rejection_Reason == Id) {
            return Spartan_BR_Testing_Spartan_BR_Rejection_ReasonItems[i].Description;
        }
    }
    return "";
}

function GetSpartan_BR_Testing_Spartan_BR_Rejection_ReasonDropDown() {
    var Spartan_BR_Testing_Spartan_BR_Rejection_ReasonDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '' }).appendTo(Spartan_BR_Testing_Spartan_BR_Rejection_ReasonDropdown);
    if (Spartan_BR_Testing_Spartan_BR_Rejection_ReasonItems != null) {
        for (var i = 0; i < Spartan_BR_Testing_Spartan_BR_Rejection_ReasonItems.length; i++) {
            $('<option />', { value: Spartan_BR_Testing_Spartan_BR_Rejection_ReasonItems[i].Key_Rejection_Reason, text: Spartan_BR_Testing_Spartan_BR_Rejection_ReasonItems[i].Description }).appendTo(Spartan_BR_Testing_Spartan_BR_Rejection_ReasonDropdown);
        }
    }
    return Spartan_BR_Testing_Spartan_BR_Rejection_ReasonDropdown;
}


function GetInsertSpartan_BR_TestingRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $(GetSpartan_BR_Testing_Spartan_UserDropDown()).addClass('Spartan_BR_Testing_User_that_reviewed User_that_reviewed').attr('id', 'Spartan_BR_Testing_User_that_reviewed_' + index).attr('data-field', 'User_that_reviewed');
    columnData[1] = $($.parseHTML(inputData)).addClass('Spartan_BR_Testing_Acceptance_Critera Acceptance_Critera').attr('id', 'Spartan_BR_Testing_Acceptance_Critera_' + index).attr('data-field', 'Acceptance_Critera');
    columnData[2] = $($.parseHTML(GetGridCheckBox())).addClass('Spartan_BR_Testing_It_worked It_worked').attr('id', 'Spartan_BR_Testing_It_worked_' + index).attr('data-field', 'It_worked');
    columnData[3] = $(GetSpartan_BR_Testing_Spartan_BR_Rejection_ReasonDropDown()).addClass('Spartan_BR_Testing_Rejection_Reason Rejection_Reason').attr('id', 'Spartan_BR_Testing_Rejection_Reason_' + index).attr('data-field', 'Rejection_Reason');
    columnData[4] = $($.parseHTML(inputData)).addClass('Spartan_BR_Testing_Comments Comments').attr('id', 'Spartan_BR_Testing_Comments_' + index).attr('data-field', 'Comments');
    columnData[5] = $($.parseHTML(GetFileUploader())).addClass('Spartan_BR_Testing_Evidence_FileUpload Evidence').attr('id', 'Spartan_BR_Testing_Evidence_' + index).attr('data-field', 'Evidence');


    initiateUIControls();
    return columnData;
}

function Spartan_BR_TestingInsertRow(rowIndex) {
    if (EjecutarValidacionesAntesDeGuardarMRSpartan_BR_Testing("Spartan_BR_Testing_", "_" + rowIndex)) {
        var iPage = Spartan_BR_TestingTable.fnPagingInfo().iPage;
        var nameOfGrid = 'Spartan_BR_Testing';
        var prevData = Spartan_BR_TestingTable.fnGetData(rowIndex);
        var data = Spartan_BR_TestingTable.fnGetNodes(rowIndex);
        var counter = 1;
        var newData = {
            Key_Testing: prevData.Key_Testing,
            IsInsertRow: false
            , User_that_reviewed: ($('#' + nameOfGrid + 'Grid .User_that_reviewedHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
            , Acceptance_Critera: ($('#' + nameOfGrid + 'Grid .Acceptance_CriteraHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
            , It_worked: ($('#' + nameOfGrid + 'Grid .It_workedHeader').css('display') != 'none') ? $(data.childNodes[counter++].childNodes[1]).is(':checked') : ''
            , Rejection_Reason: ($('#' + nameOfGrid + 'Grid .Rejection_ReasonHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
            , Comments: ($('#' + nameOfGrid + 'Grid .CommentsHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
            , EvidenceFileInfo: ($('#' + nameOfGrid + 'Grid .EvidenceHeader').css('display') != 'none') ? {
                FileName: prevData.EvidenceFileInfo != null && prevData.EvidenceFileInfo.FileName != null ? prevData.EvidenceFileInfo.FileName : (data.childNodes[counter].childNodes[0].files.length > 0 ? data.childNodes[counter].childNodes[0].files[0].name : ''),
                FileId: prevData.EvidenceFileInfo != null && prevData.EvidenceFileInfo.FileName != null ? prevData.EvidenceFileInfo.FileId : '0',
                FileSize: prevData.EvidenceFileInfo != null && prevData.EvidenceFileInfo.FileName != null ? prevData.EvidenceFileInfo.FileSize : (data.childNodes[counter].childNodes[0].files.length > 0 ? data.childNodes[counter].childNodes[0].files[0].name : '')
            } : ''
            , EvidenceDetail: (data.childNodes[counter] != 'undefined' && data.childNodes[counter].childNodes[0].childNodes.length == 0) ? data.childNodes[counter++].childNodes[0] : null

        }
        Spartan_BR_TestingTable.fnUpdate(newData, rowIndex, null, true);
        Spartan_BR_TestingrowCreationGrid(data, newData, rowIndex);
        Spartan_BR_TestingTable.fnPageChange(iPage);
        Spartan_BR_TestingcountRowsChecked--;
        EjecutarValidacionesDespuesDeGuardarMRSpartan_BR_Testing("Spartan_BR_Testing_", "_" + rowIndex);
    }
}

function Spartan_BR_TestingCancelRow(rowIndex) {
    var prevData = Spartan_BR_TestingTable.fnGetData(rowIndex);
    var data = Spartan_BR_TestingTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Spartan_BR_TestingTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Spartan_BR_TestingrowCreationGrid(data, prevData, rowIndex);
    }
    showSpartan_BR_TestingGrid(Spartan_BR_TestingTable.fnGetData());
    Spartan_BR_TestingcountRowsChecked--;
}

function GetSpartan_BR_TestingFromDataTable() {
    var Spartan_BR_TestingData = [];
    var gridData = Spartan_BR_TestingTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Spartan_BR_TestingData.push({
                Key_Testing: gridData[i].Key_Testing
                , User_that_reviewed: gridData[i].User_that_reviewed
                , Acceptance_Critera: gridData[i].Acceptance_Critera
                , It_worked: gridData[i].It_worked
                , Rejection_Reason: gridData[i].Rejection_Reason
                , Comments: gridData[i].Comments
                , EvidenceInfo: {
                    FileName: gridData[i].EvidenceFileInfo.FileName, FileId: gridData[i].EvidenceFileInfo.FileId, FileSize: gridData[i].EvidenceFileInfo.FileSize,
                    Control: gridData[i].EvidenceDetail != null && gridData[i].EvidenceDetail.files != null && gridData[i].EvidenceDetail.files.length > 0 ? gridData[i].EvidenceDetail.files[0] : null,
                    EvidenceRemoveFile: gridData[i].EvidenceDetail != null
                }

                , Removed: false
            });
    }

    for (i = 0; i < removedSpartan_BR_TestingData.length; i++) {
        if (removedSpartan_BR_TestingData[i] != null && removedSpartan_BR_TestingData[i].Key_Testing > 0)
            Spartan_BR_TestingData.push({
                Key_Testing: removedSpartan_BR_TestingData[i].Key_Testing
                , User_that_reviewed: removedSpartan_BR_TestingData[i].User_that_reviewed
                , Acceptance_Critera: removedSpartan_BR_TestingData[i].Acceptance_Critera
                , It_worked: removedSpartan_BR_TestingData[i].It_worked
                , Rejection_Reason: removedSpartan_BR_TestingData[i].Rejection_Reason
                , Comments: removedSpartan_BR_TestingData[i].Comments
                , EvidenceInfo: {
                    FileName: removedSpartan_BR_TestingData[i].EvidenceFileInfo.FileName,
                    FileId: removedSpartan_BR_TestingData[i].EvidenceFileInfo.FileId,
                    FileSize: removedSpartan_BR_TestingData[i].EvidenceFileInfo.FileSize,
                    Control: removedSpartan_BR_TestingData[i].EvidenceDetail != null && removedSpartan_BR_TestingData[i].EvidenceDetail.files.length > 0 ? removedSpartan_BR_TestingData[i].EvidenceDetail.files[0] : null,
                    EvidenceRemoveFile: removedSpartan_BR_TestingData[i].EvidenceDetail != null
                }

                , Removed: true
            });
    }

    return Spartan_BR_TestingData;
}

function Spartan_BR_TestingEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Spartan_BR_TestingTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Spartan_BR_TestingcountRowsChecked++;
    var Spartan_BR_TestingRowElement = "Spartan_BR_Testing_" + rowIndex.toString();
    var prevData = Spartan_BR_TestingTable.fnGetData(rowIndexTable);
    var row = Spartan_BR_TestingTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Spartan_BR_Testing_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Spartan_BR_TestingGetUpdateRowControls(prevData, "Spartan_BR_Testing_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Spartan_BR_TestingRowElement + "')){ Spartan_BR_TestingInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Spartan_BR_TestingCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
        if ($('#Spartan_BR_TestingGrid .' + idHeader).css('display') != 'none') {
            $(controls[i]).appendTo($('<td id="td' + nameOfTable + idHeader.replace('Header', '') + rowIndexFormed + '">').appendTo(row));
        }
    }
    $('.Spartan_BR_Testing' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    setSpartan_BR_TestingValidation();
    initiateUIControls();
    if (executeRules == null || (executeRules != null && executeRules == true)) {
        EjecutarValidacionesEditRowMRSpartan_BR_Testing(nameOfTable, rowIndexFormed);
    }
}

function Spartan_BR_TestingfnOpenAddRowPopUp() {
    var currentRowIndex = Spartan_BR_TestingTable.fnGetData().length;
    Spartan_BR_TestingfnClickAddRow();
    GetAddSpartan_BR_TestingPopup(currentRowIndex, 0);
}

function Spartan_BR_TestingEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Spartan_BR_TestingTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Spartan_BR_TestingRowElement = "Spartan_BR_Testing_" + rowIndex.toString();
    var prevData = Spartan_BR_TestingTable.fnGetData(rowIndexTable);
    GetAddSpartan_BR_TestingPopup(rowIndex, 1, prevData.Key_Testing);
    $('#Spartan_BR_TestingUser_that_reviewed').val(prevData.User_that_reviewed);
    $('#Spartan_BR_TestingAcceptance_Critera').val(prevData.Acceptance_Critera);
    $('#Spartan_BR_TestingIt_worked').prop('checked', prevData.It_worked);
    $('#Spartan_BR_TestingRejection_Reason').val(prevData.Rejection_Reason);
    $('#Spartan_BR_TestingComments').val(prevData.Comments);

    initiateUIControls();
    $('#existingEvidence').html(prevData.EvidenceFileDetail == null && (prevData.EvidenceFileInfo.FileId == null || prevData.EvidenceFileInfo.FileId <= 0) ? $.parseHTML(GetFileUploader()) : GetFileInfo(prevData.EvidenceFileInfo, prevData.EvidenceFileDetail));

}

function Spartan_BR_TestingAddInsertRow() {
    if (Spartan_BR_TestinginsertRowCurrentIndex < 1) {
        Spartan_BR_TestinginsertRowCurrentIndex = 1;
    }
    return {
        Key_Testing: null,
        IsInsertRow: true
        , User_that_reviewed: ""
        , Acceptance_Critera: ""
        , It_worked: ""
        , Rejection_Reason: ""
        , Comments: ""
        , EvidenceFileInfo: ""

    }
}

function Spartan_BR_TestingfnClickAddRow() {
    Spartan_BR_TestingcountRowsChecked++;
    Spartan_BR_TestingTable.fnAddData(Spartan_BR_TestingAddInsertRow(), true);
    Spartan_BR_TestingTable.fnPageChange('last');
    initiateUIControls();
    EjecutarValidacionesNewRowMRSpartan_BR_Testing("Spartan_BR_Testing_", "_" + Spartan_BR_TestinginsertRowCurrentIndex);
}

function Spartan_BR_TestingClearGridData() {
    Spartan_BR_TestingData = [];
    Spartan_BR_TestingdeletedItem = [];
    Spartan_BR_TestingDataMain = [];
    Spartan_BR_TestingDataMainPages = [];
    Spartan_BR_TestingnewItemCount = 0;
    Spartan_BR_TestingmaxItemIndex = 0;
    $("#Spartan_BR_TestingGrid").DataTable().clear();
    $("#Spartan_BR_TestingGrid").DataTable().destroy();
}

//Used to Get Business Rule Creation Information
function GetSpartan_BR_Testing() {
    var form_data = new FormData();
    for (var i = 0; i < Spartan_BR_TestingData.length; i++) {
        form_data.append('[' + i + '].Key_Testing', Spartan_BR_TestingData[i].Key_Testing);
        form_data.append('[' + i + '].User_that_reviewed', Spartan_BR_TestingData[i].User_that_reviewed);
        form_data.append('[' + i + '].Acceptance_Critera', Spartan_BR_TestingData[i].Acceptance_Critera);
        form_data.append('[' + i + '].It_worked', Spartan_BR_TestingData[i].It_worked);
        form_data.append('[' + i + '].Rejection_Reason', Spartan_BR_TestingData[i].Rejection_Reason);
        form_data.append('[' + i + '].Comments', Spartan_BR_TestingData[i].Comments);
        form_data.append('[' + i + '].EvidenceInfo.FileId', Spartan_BR_TestingData[i].EvidenceInfo.FileId);
        form_data.append('[' + i + '].EvidenceInfo.FileName', Spartan_BR_TestingData[i].EvidenceInfo.FileName);
        form_data.append('[' + i + '].EvidenceInfo.FileSize', Spartan_BR_TestingData[i].EvidenceInfo.FileSize);
        form_data.append('[' + i + '].EvidenceInfo.Control', Spartan_BR_TestingData[i].EvidenceInfo.Control);
        form_data.append('[' + i + '].EvidenceInfo.RemoveFile', Spartan_BR_TestingData[i].EvidenceInfo.ArchivoRemoveFile);

        form_data.append('[' + i + '].Removed', Spartan_BR_TestingData[i].Removed);
    }
    return form_data;
}
function Spartan_BR_TestingInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRSpartan_BR_Testing("Spartan_BR_TestingTable", rowIndex)) {
    var prevData = Spartan_BR_TestingTable.fnGetData(rowIndex);
    var data = Spartan_BR_TestingTable.fnGetNodes(rowIndex);
    var newData = {
        Key_Testing: prevData.Key_Testing,
        IsInsertRow: false
        , User_that_reviewed: $('#Spartan_BR_TestingUser_that_reviewed').val()
        , Acceptance_Critera: $('#Spartan_BR_TestingAcceptance_Critera').val()
        , It_worked: $('#Spartan_BR_TestingIt_worked').is(':checked')
        , Rejection_Reason: $('#Spartan_BR_TestingRejection_Reason').val()
        , Comments: $('#Spartan_BR_TestingComments').val()
        , EvidenceFileInfo: { EvidenceFileName: prevData.EvidenceFileInfo.FileName, EvidenceFileId: prevData.EvidenceFileInfo.FileId, EvidenceFileSize: prevData.EvidenceFileInfo.FileSize }
        , EvidenceFileDetail: $('#Evidence').find('label').length == 0 ? $('#EvidenceFileInfoPop')[0] : prevData.EvidenceFileDetail

    }

    Spartan_BR_TestingTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_BR_TestingrowCreationGrid(data, newData, rowIndex);
    $('#AddSpartan_BR_Testing-form').modal({ show: false });
    $('#AddSpartan_BR_Testing-form').modal('hide');
    Spartan_BR_TestingEditRow(rowIndex);
    Spartan_BR_TestingInsertRow(rowIndex);
    //}
}
function Spartan_BR_TestingRemoveAddRow(rowIndex) {
    Spartan_BR_TestingTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Spartan_BR_Testing MultiRow
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

    $('<option />', { value: '', text: '' }).appendTo(Spartan_BR_Scope_Detail_Spartan_BR_ScopeDropdown);
    if (Spartan_BR_Scope_Detail_Spartan_BR_ScopeItems != null) {
        for (var i = 0; i < Spartan_BR_Scope_Detail_Spartan_BR_ScopeItems.length; i++) {
            $('<option />', { value: Spartan_BR_Scope_Detail_Spartan_BR_ScopeItems[i].ScopeId, text: Spartan_BR_Scope_Detail_Spartan_BR_ScopeItems[i].Description }).appendTo(Spartan_BR_Scope_Detail_Spartan_BR_ScopeDropdown);
        }
    }
    return Spartan_BR_Scope_Detail_Spartan_BR_ScopeDropdown;
}


function GetInsertSpartan_BR_Scope_DetailRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $(GetSpartan_BR_Scope_Detail_Spartan_BR_ScopeDropDown()).addClass('Spartan_BR_Scope_Detail_Scope Scope').attr('id', 'Spartan_BR_Scope_Detail_Scope_' + index).attr('data-field', 'Scope');


    initiateUIControls();
    return columnData;
}

function Spartan_BR_Scope_DetailInsertRow(rowIndex) {
    if (EjecutarValidacionesAntesDeGuardarMRSpartan_BR_Scope_Detail("Spartan_BR_Scope_Detail_", "_" + rowIndex)) {
        var iPage = Spartan_BR_Scope_DetailTable.fnPagingInfo().iPage;
        var nameOfGrid = 'Spartan_BR_Scope_Detail';
        var prevData = Spartan_BR_Scope_DetailTable.fnGetData(rowIndex);
        var data = Spartan_BR_Scope_DetailTable.fnGetNodes(rowIndex);
        var counter = 1;
        var newData = {
            ScopeDetailId: prevData.ScopeDetailId,
            IsInsertRow: false
            , Scope: ($('#' + nameOfGrid + 'Grid .ScopeHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''

        }
        Spartan_BR_Scope_DetailTable.fnUpdate(newData, rowIndex, null, true);
        Spartan_BR_Scope_DetailrowCreationGrid(data, newData, rowIndex);
        Spartan_BR_Scope_DetailTable.fnPageChange(iPage);
        Spartan_BR_Scope_DetailcountRowsChecked--;
        EjecutarValidacionesDespuesDeGuardarMRSpartan_BR_Scope_Detail("Spartan_BR_Scope_Detail_", "_" + rowIndex);
    }
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
    showSpartan_BR_Scope_DetailGrid(Spartan_BR_Scope_DetailTable.fnGetData());
    Spartan_BR_Scope_DetailcountRowsChecked--;
}

function GetSpartan_BR_Scope_DetailFromDataTable() {
    var Spartan_BR_Scope_DetailData = [];
    var gridData = [];
    $('#Scopes option:selected').each(function (i, selected) {
        gridData[i] = $(selected).val();
    });
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        Spartan_BR_Scope_DetailData.push({
            ScopeDetailId: 0
                , Scope: gridData[i]
        });
    }

    return Spartan_BR_Scope_DetailData;
}

function Spartan_BR_Scope_DetailEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Spartan_BR_Scope_DetailTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Spartan_BR_Scope_DetailcountRowsChecked++;
    var Spartan_BR_Scope_DetailRowElement = "Spartan_BR_Scope_Detail_" + rowIndex.toString();
    var prevData = Spartan_BR_Scope_DetailTable.fnGetData(rowIndexTable);
    var row = Spartan_BR_Scope_DetailTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Spartan_BR_Scope_Detail_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Spartan_BR_Scope_DetailGetUpdateRowControls(prevData, "Spartan_BR_Scope_Detail_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Spartan_BR_Scope_DetailRowElement + "')){ Spartan_BR_Scope_DetailInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Spartan_BR_Scope_DetailCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
        if ($('#Spartan_BR_Scope_DetailGrid .' + idHeader).css('display') != 'none') {
            $(controls[i]).appendTo($('<td id="td' + nameOfTable + idHeader.replace('Header', '') + rowIndexFormed + '">').appendTo(row));
        }
    }
    $('.Spartan_BR_Scope_Detail' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    setSpartan_BR_Scope_DetailValidation();
    initiateUIControls();
    if (executeRules == null || (executeRules != null && executeRules == true)) {
        EjecutarValidacionesEditRowMRSpartan_BR_Scope_Detail(nameOfTable, rowIndexFormed);
    }
}

function Spartan_BR_Scope_DetailfnOpenAddRowPopUp() {
    var currentRowIndex = Spartan_BR_Scope_DetailTable.fnGetData().length;
    Spartan_BR_Scope_DetailfnClickAddRow();
    GetAddSpartan_BR_Scope_DetailPopup(currentRowIndex, 0);
}

function Spartan_BR_Scope_DetailEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Spartan_BR_Scope_DetailTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Spartan_BR_Scope_DetailRowElement = "Spartan_BR_Scope_Detail_" + rowIndex.toString();
    var prevData = Spartan_BR_Scope_DetailTable.fnGetData(rowIndexTable);
    GetAddSpartan_BR_Scope_DetailPopup(rowIndex, 1, prevData.ScopeDetailId);
    $('#Spartan_BR_Scope_DetailScope').val(prevData.Scope);

    initiateUIControls();

}

function Spartan_BR_Scope_DetailAddInsertRow() {
    if (Spartan_BR_Scope_DetailinsertRowCurrentIndex < 1) {
        Spartan_BR_Scope_DetailinsertRowCurrentIndex = 1;
    }
    return {
        ScopeDetailId: null,
        IsInsertRow: true
        , Scope: ""

    }
}

function Spartan_BR_Scope_DetailfnClickAddRow() {
    Spartan_BR_Scope_DetailcountRowsChecked++;
    Spartan_BR_Scope_DetailTable.fnAddData(Spartan_BR_Scope_DetailAddInsertRow(), true);
    Spartan_BR_Scope_DetailTable.fnPageChange('last');
    initiateUIControls();
    EjecutarValidacionesNewRowMRSpartan_BR_Scope_Detail("Spartan_BR_Scope_Detail_", "_" + Spartan_BR_Scope_DetailinsertRowCurrentIndex);
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

//Used to Get Business Rule Creation Information
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
    //if (EjecutarValidacionesAntesDeGuardarMRSpartan_BR_Scope_Detail("Spartan_BR_Scope_DetailTable", rowIndex)) {
    var prevData = Spartan_BR_Scope_DetailTable.fnGetData(rowIndex);
    var data = Spartan_BR_Scope_DetailTable.fnGetNodes(rowIndex);
    var newData = {
        ScopeDetailId: prevData.ScopeDetailId,
        IsInsertRow: false
        , Scope: $('#Spartan_BR_Scope_DetailScope').val()

    }

    Spartan_BR_Scope_DetailTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_BR_Scope_DetailrowCreationGrid(data, newData, rowIndex);
    $('#AddSpartan_BR_Scope_Detail-form').modal({ show: false });
    $('#AddSpartan_BR_Scope_Detail-form').modal('hide');
    Spartan_BR_Scope_DetailEditRow(rowIndex);
    Spartan_BR_Scope_DetailInsertRow(rowIndex);
    //}
}
function Spartan_BR_Scope_DetailRemoveAddRow(rowIndex) {
    Spartan_BR_Scope_DetailTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Spartan_BR_Scope_Detail MultiRow


$(function () {
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
    function Spartan_BR_Peer_ReviewinitializeMainArray(totalCount) {
        if (Spartan_BR_Peer_ReviewDataMain.length != totalCount && !Spartan_BR_Peer_ReviewDataMainInitialized) {
            Spartan_BR_Peer_ReviewDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Spartan_BR_Peer_ReviewDataMain[i] = null;
            }
        }
    }
    function Spartan_BR_Peer_ReviewremoveFromMainArray() {
        for (var j = 0; j < Spartan_BR_Peer_ReviewdeletedItem.length; j++) {
            for (var i = 0; i < Spartan_BR_Peer_ReviewDataMain.length; i++) {
                if (Spartan_BR_Peer_ReviewDataMain[i] != null && Spartan_BR_Peer_ReviewDataMain[i].Id == Spartan_BR_Peer_ReviewdeletedItem[j]) {
                    hSpartan_BR_Peer_ReviewDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Spartan_BR_Peer_ReviewcopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Spartan_BR_Peer_ReviewDataMain.length; i++) {
            data[i] = Spartan_BR_Peer_ReviewDataMain[i];

        }
        return data;
    }
    function Spartan_BR_Peer_ReviewgetNewResult() {
        var newData = copyMainSpartan_BR_Peer_ReviewArray();

        for (var i = 0; i < Spartan_BR_Peer_ReviewData.length; i++) {
            if (Spartan_BR_Peer_ReviewData[i].Removed == null || Spartan_BR_Peer_ReviewData[i].Removed == false) {
                newData.splice(0, 0, Spartan_BR_Peer_ReviewData[i]);
            }
        }
        return newData;
    }
    function Spartan_BR_Peer_ReviewpushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Spartan_BR_Peer_ReviewDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Spartan_BR_Peer_ReviewDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Spartan_BR_TestinginitializeMainArray(totalCount) {
        if (Spartan_BR_TestingDataMain.length != totalCount && !Spartan_BR_TestingDataMainInitialized) {
            Spartan_BR_TestingDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Spartan_BR_TestingDataMain[i] = null;
            }
        }
    }
    function Spartan_BR_TestingremoveFromMainArray() {
        for (var j = 0; j < Spartan_BR_TestingdeletedItem.length; j++) {
            for (var i = 0; i < Spartan_BR_TestingDataMain.length; i++) {
                if (Spartan_BR_TestingDataMain[i] != null && Spartan_BR_TestingDataMain[i].Id == Spartan_BR_TestingdeletedItem[j]) {
                    hSpartan_BR_TestingDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Spartan_BR_TestingcopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Spartan_BR_TestingDataMain.length; i++) {
            data[i] = Spartan_BR_TestingDataMain[i];

        }
        return data;
    }
    function Spartan_BR_TestinggetNewResult() {
        var newData = copyMainSpartan_BR_TestingArray();

        for (var i = 0; i < Spartan_BR_TestingData.length; i++) {
            if (Spartan_BR_TestingData[i].Removed == null || Spartan_BR_TestingData[i].Removed == false) {
                newData.splice(0, 0, Spartan_BR_TestingData[i]);
            }
        }
        return newData;
    }
    function Spartan_BR_TestingpushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Spartan_BR_TestingDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Spartan_BR_TestingDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
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

});

//Grid GetAutocomplete

//Grid GetAutocomplete

//Grid GetAutocomplete

//Grid GetAutocomplete

//Grid GetAutocomplete

//Grid GetAutocomplete

//Grid GetAutocomplete

//Grid GetAutocomplete



function getDropdown(elementKey) {
    var dropDown = '<select id="' + elementKey + '" class="form-control"><option value=""></option></select>';
    return dropDown;
}

function GetGridDatePicker() {
    return "<input type='text' class='fullWidth gridDatePicker xyz form-control' >";
}
function GetGridTimePicker() {
    return "<input type='text' class='fullWidth gridTimePicker form-control'  data-autoclose='true'>";
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

function GetGridAutoComplete(data, field, id) {

    var dataMain = data == null ? "Select" : data;
    id == (id == null || id == undefined) ? "" : id;

    return "<select class='AutoComplete fullWidth select2-dropDown " + field + " form-control' data-val='true'  ><option value='" + id + "'>" + dataMain + "</option></select>";
}

function ClearControls() {
    $("#ReferenceKey_Business_Rule_Creation").val("0");
    $('#CreateBusiness_Rule_Creation')[0].reset();
    ClearFormControls();
    $("#Key_Business_Rule_CreationId").val("0");
    Spartan_BR_Conditions_DetailClearGridData();
    Spartan_BR_Actions_True_DetailClearGridData();
    Spartan_BR_Actions_False_DetailClearGridData();
    Spartan_BR_Operation_DetailClearGridData();
    Spartan_BR_Process_Event_DetailClearGridData();
    Spartan_BR_Peer_ReviewClearGridData();
    Spartan_BR_TestingClearGridData();
    Spartan_BR_Scope_DetailClearGridData();

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreateBusiness_Rule_Creation').trigger('reset');
    $('#CreateBusiness_Rule_Creation').find(':input').each(function () {
        switch (this.type) {
            case 'password':
            case 'number':
            case 'select-multiple':
            case 'select-one':
            case 'select':
            case 'text':
            case 'textarea':
                $(this).val('');
                for (instance in CKEDITOR.instances) {
                    CKEDITOR.instances[instance].updateElement();
                    CKEDITOR.instances[instance].setData('');
                }
                break;
            case 'checkbox':
            case 'radio':
                this.checked = false;
        }
    });
}
function CheckValidation() {
    var $myForm = $('#CreateBusiness_Rule_Creation');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    if (Spartan_BR_Conditions_DetailcountRowsChecked > 0) {
        ShowMessagePendingRowSpartan_BR_Conditions_Detail();
        return false;
    }
    if (Spartan_BR_Actions_True_DetailcountRowsChecked > 0) {
        ShowMessagePendingRowSpartan_BR_Actions_True_Detail();
        return false;
    }
    if (Spartan_BR_Actions_False_DetailcountRowsChecked > 0) {
        ShowMessagePendingRowSpartan_BR_Actions_False_Detail();
        return false;
    }
    if (Spartan_BR_Operation_DetailcountRowsChecked > 0) {
        ShowMessagePendingRowSpartan_BR_Operation_Detail();
        return false;
    }
    if (Spartan_BR_Process_Event_DetailcountRowsChecked > 0) {
        ShowMessagePendingRowSpartan_BR_Process_Event_Detail();
        return false;
    }
    if (Spartan_BR_Peer_ReviewcountRowsChecked > 0) {
        ShowMessagePendingRowSpartan_BR_Peer_Review();
        return false;
    }
    if (Spartan_BR_TestingcountRowsChecked > 0) {
        ShowMessagePendingRowSpartan_BR_Testing();
        return false;
    }
    if (Spartan_BR_Scope_DetailcountRowsChecked > 0) {
        ShowMessagePendingRowSpartan_BR_Scope_Detail();
        return false;
    }

    return true;
}


function ResetClaveLabel() {
    $("#lblKey_Business_Rule_Creation").text("0");
}
$(document).ready(function () {
    $("form#CreateBusiness_Rule_Creation").submit(function (e) {
        e.preventDefault();
        return false;
    });
    $("form#CreateBusiness_Rule_Creation").on('click', '#Business_Rule_CreationCancelar', function () {
        $('.AddBusinessRuleModal').modal('hide');
    });
    $("form#CreateBusiness_Rule_Creation").on('click', '#Business_Rule_CreationGuardar', function () {
        if (EjecutarValidacionesAntesDeGuardar()) {
            if (CheckValidation())
                SendBusiness_Rule_CreationData(function () {
                    EjecutarValidacionesDespuesDeGuardar();
                    Business_Rule_CreationBackToGrid();
                });
        }
    });
    $("form#CreateBusiness_Rule_Creation").on('click', '#Business_Rule_CreationGuardarYNuevo', function () {
        if (EjecutarValidacionesAntesDeGuardar()) {
            if (CheckValidation()) {
                SendBusiness_Rule_CreationData(function () {
                    ClearControls();
                    ClearAttachmentsDiv();
                    ResetClaveLabel();
                    getSpartan_BR_Conditions_DetailData();
                    getSpartan_BR_Actions_True_DetailData();
                    getSpartan_BR_Actions_False_DetailData();
                    getSpartan_BR_Operation_DetailData();
                    getSpartan_BR_Process_Event_DetailData();
                    getSpartan_BR_Peer_ReviewData();
                    getSpartan_BR_TestingData();
                    getSpartan_BR_Scope_DetailData();

                    EjecutarValidacionesDespuesDeGuardar();
                    setIsNew();
                    $('#Time_that_took').val('0');
                    var current = 0;
                    setInterval(function () {
                        current = parseInt($('#Time_that_took').val());
                        $('#Time_that_took').val(current + 1);
                    }, 1000);
                    EjecutarValidacionesAlComienzo();
                });
            }
        }
    });
    $("form#CreateBusiness_Rule_Creation").on('click', '#Business_Rule_CreationGuardarYCopia', function () {
        if (EjecutarValidacionesAntesDeGuardar()) {
            if (CheckValidation())
                SendBusiness_Rule_CreationData(function (currentId) {
                    $("#Key_Business_Rule_CreationId").val("0");
                    Spartan_BR_Conditions_DetailClearGridData();
                    Spartan_BR_Actions_True_DetailClearGridData();
                    Spartan_BR_Actions_False_DetailClearGridData();
                    Spartan_BR_Operation_DetailClearGridData();
                    Spartan_BR_Process_Event_DetailClearGridData();
                    Spartan_BR_Peer_ReviewClearGridData();
                    Spartan_BR_TestingClearGridData();
                    Spartan_BR_Scope_DetailClearGridData();

                    ResetClaveLabel();
                    $("#ReferenceKey_Business_Rule_Creation").val(currentId);
                    getSpartan_BR_Conditions_DetailData();
                    getSpartan_BR_Actions_True_DetailData();
                    getSpartan_BR_Actions_False_DetailData();
                    getSpartan_BR_Operation_DetailData();
                    getSpartan_BR_Process_Event_DetailData();
                    getSpartan_BR_Peer_ReviewData();
                    getSpartan_BR_TestingData();
                    getSpartan_BR_Scope_DetailData();
                    //SOLUCION INCIDENCIA 1
                    $('#Name').val('');
                    EjecutarValidacionesDespuesDeGuardar();
                    setIsNew();
                });
        }
    });
});

function setIsNew() {
    $('#hdnIsNewCreate').val("True");
    $('#OperationCreate').val("New");
    operation = "New";
}



var mainElementObject;
var childElementObject;
function DisplayElementAttributes(data) {
}

function getElementTable(elementNumber, table) {

    for (var j = 0; j < childElementObject.length; j++) {
        if (childElementObject[j].table == table) {
            return childElementObject[j].elements[elementNumber];
            break;
        }
    }
}

function setRequired(elementNumber, element, elementType, table) {
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
        getElementTable(elementNumber, table).IsRequired = (getElementTable(elementNumber, table).IsRequired == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (getElementTable(elementNumber, table).IsRequired == true ? "Images/Required.png" : "Images/Not-Required.png") + "");
        $(element).attr('title', (getElementTable(elementNumber, table).IsRequired == true ? 'Required' : 'Not Required'));
        if (!getElementTable(elementNumber, table).IsVisible && getElementTable(elementNumber, table).IsRequired) {
            setVisible(elementNumber, $(element).parent().parent().find('div.visibleAttribute').find('a'), elementType);
        }
        if (getElementTable(elementNumber, table).IsReadOnly && getElementTable(elementNumber, table).IsRequired && getElementTable(elementNumber, table).DefaultValue == '') {
            setReadOnly(elementNumber, $(element).parent().parent().find('div.readOnlyAttribute').find('a'), elementType);
        }
    }
}
function setVisible(elementNumber, element, elementType, table) {
    if (elementType == "1") {
        if (mainElementObject[elementNumber].IsRequired && mainElementObject[elementNumber].DefaultValue == '' && mainElementObject[elementNumber].IsVisible) {
            showNotification("can not set in visible, as this field is required and has no default value", "error");
            return;
        }
        mainElementObject[elementNumber].IsVisible = (mainElementObject[elementNumber].IsVisible == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[elementNumber].IsVisible == true ? "Images/Visible.png" : "Images/inVisible.png") + "");
        $(element).attr('title', (mainElementObject[elementNumber].IsVisible == true ? 'Visible' : 'In Visible'));
    } else {
        if (getElementTable(elementNumber, table).IsRequired && getElementTable(elementNumber, table).DefaultValue == '' && getElementTable(elementNumber, table).IsVisible) {
            showNotification("can not set in visible, as this field is required and has no default value", "error");
            return;
        }
        getElementTable(elementNumber, table).IsVisible = (getElementTable(elementNumber, table).IsVisible == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (getElementTable(elementNumber, table).IsVisible == true ? "Images/Visible.png" : "Images/inVisible.png") + "");
        $(element).attr('title', (getElementTable(elementNumber, table).IsVisible == true ? 'Visible' : 'In Visible'));
    }
}
function setReadOnly(elementNumber, element, elementType, table) {
    if (elementType == "1") {
        if (mainElementObject[elementNumber].IsRequired && mainElementObject[elementNumber].DefaultValue == '' && !mainElementObject[elementNumber].IsReadOnly) {
            showNotification("can not set readonly, as this field is required and has no default value", "error");
            return;
        }
        mainElementObject[elementNumber].IsReadOnly = (mainElementObject[elementNumber].IsReadOnly == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[elementNumber].IsReadOnly == true ? "Images/Disabled.png" : "Images/Enabled.png") + "");
        $(element).attr('title', (mainElementObject[elementNumber].IsReadOnly == true ? 'Disabled' : 'Enabled'));
    } else {
        if (getElementTable(elementNumber, table).IsRequired && getElementTable(elementNumber, table).DefaultValue == '' && !getElementTable(elementNumber, table).IsReadOnly) {
            showNotification("can not set readonly, as this field is required and has no default value", "error");
            return;
        }
        getElementTable(elementNumber, table).IsReadOnly = (getElementTable(elementNumber, table).IsReadOnly == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (getElementTable(elementNumber, table).IsReadOnly == true ? "Images/Disabled.png" : "Images/Enabled.png") + "");
        $(element).attr('title', (getElementTable(elementNumber, table).IsReadOnly == true ? 'Disabled' : 'Enabled'));
    }
}
function setDefaultValue(elementNumber, element, elementType, table) {
    //debugger;
    $('#hdnAttributType').val('1');
    $('#hdnAttributNumber').val(elementNumber);
    $('#lblAttributeType').text('Default Value');
    if (elementType == "1") {
        $('#txtAttributeValue').val(mainElementObject[elementNumber].DefaultValue);
        $('#hdnElementType').val("1");
    } else {
        $('#txtAttributeValue').val(getElementTable(elementNumber, table).DefaultValue);
        $('#hdnElementType').val("2");
    }
    $('#dvAttributeValue').show();
}
function setHelpText(elementNumber, element, elementType, table) {
    $('#hdnAttributType').val('2');
    $('#hdnAttributNumber').val(elementNumber);
    $('#lblAttributeType').text('Help Text');
    if (elementType == "1") {
        $('#txtAttributeValue').val(mainElementObject[elementNumber].HelpText);
        $('#hdnElementType').val("1");
    } else {
        $('#txtAttributeValue').val(getElementTable(elementNumber, table).HelpText);
        $('#hdnElementType').val("2");
    }
    $('#dvAttributeValue').show();
    //$(element).children().attr("src", "" + (mainElementObject[elementNumber].HelpText == '' ? "Images/red-help.png" : "Images/green-help.png") + "");
}
function SaveValue(table) {
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
            getElementTable($('#hdnAttributNumber').val(), table).DefaultValue = $('#txtAttributeValue').val();
            console.log(childElementObject[$('#hdnAttributNumber').val()].DefaultValue);
            $('#hlDefaultValueHeader_' + $('#hdnAttributNumber').val()).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (getElementTable($('#hdnAttributNumber').val(), table).DefaultValue == '' ? "Images/Not-Default-Value.png" : "Images/default-value.png") + "");
            $('#hlDefaultValueHeader_' + $('#hdnAttributNumber').val()).attr('title', (getElementTable($('#hdnAttributNumber').val(), table).DefaultValue));
            console.log($('#hdnAttributNumber').val());
        } else if ($('#hdnAttributType').val() == "2") {
            getElementTable($('#hdnAttributNumber').val(), table).HelpText = $('#txtAttributeValue').val();
            $('#hlHelpTextHeader_' + $('#hdnAttributNumber').val()).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (getElementTable($('#hdnAttributNumber').val(), table).HelpText == '' ? "Images/red-help.jpg" : "Images/green-help.png") + "");
            $('#hlHelpTextHeader_' + $('#hdnAttributNumber').val()).attr('title', (getElementTable($('#hdnAttributNumber').val(), table).HelpText));
        }
    }
    $('#txtAttributeValue').val('');
    $('#dvAttributeValue').hide();
}
function returnAttributeHTML(element, table, number) {
    var mainElementAttributes = '<div class="col-ld-12" style="display:inline-flex;">';
    mainElementAttributes += '<div class="displayAttributes requiredAttribute"><a class="requiredClick" title="' + (element.IsRequired == true ? "Required" : "Not Required") + '" onclick="setRequired(' + number.toString() + ', this, 2,  \'' + table + '\')"><img src="' + $('#hdnApplicationDirectory').val() + (element.IsRequired == true ? "Images/Required.png" : "Images/Not-Required.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes visibleAttribute"><a class="visibleClick" title="' + (element.IsVisible == true ? "Visible" : "In Visible") + '" onclick="setVisible(' + number.toString() + ', this, 2,  \'' + table + '\')"><img src="' + $('#hdnApplicationDirectory').val() + (element.IsVisible == true ? "Images/Visible.png" : "Images/InVisible.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes readOnlyAttribute"><a class="readOnlyClick" title="' + (element.IsReadOnly == true ? "Disabled" : "Enabled") + '" onclick="setReadOnly(' + number.toString() + ', this, 2,  \'' + table + '\')"><img src="' + $('#hdnApplicationDirectory').val() + (element.IsReadOnly == true ? "Images/Disabled.png" : "Images/Enabled.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes defaultValueAttribute"><a id="hlDefaultValueHeader_' + number.toString() + '" class="defaultValueClick" title="' + (element.DefaultValue) + '" onclick="setDefaultValue(' + number.toString() + ', this, 2,  "' + table + '")"><img src="' + $('#hdnApplicationDirectory').val() + (element.DefaultValue != '' && element.DefaultValue != null ? "Images/default-value.png" : "Images/Not-Default-Value.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes helpTextAttribute"><a id="hlHelpTextHeader_' + number.toString() + '" class="helpTextClick" title="' + (element.HelpText) + '" onclick="setHelpText(' + number.toString() + ', this, 2,  \'' + table + '\')"><img src="' + $('#hdnApplicationDirectory').val() + (element.HelpText != '' && element.HelpText != null ? "Images/green-help.png" : "Images/red-help.jpg") + '" alt="" /></a></div>';
    mainElementAttributes += '</div>';
    return mainElementAttributes;

}


var Business_Rule_CreationisdisplayBusinessPropery = false;
Business_Rule_CreationDisplayBusinessRuleButtons(Business_Rule_CreationisdisplayBusinessPropery);
function Business_Rule_CreationDisplayBusinessRule() {
    if (!Business_Rule_CreationisdisplayBusinessPropery) {
        $('#CreateBusiness_Rule_Creation').find('.col-sm-8').each(function () {
            var div = $(this);
            if ($(this).find('.input-group').length > 0)
                div = $(this).find('.input-group').first().hasClass('date') ? $(this) : $(this).find('.input-group').first();
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = div.data('field-id');
            var fieldName = div.data('field-name');
            var attribute = div.data('attribute');
            mainElementAttributes += '<div class="Business_Rule_CreationdisplayBusinessPropery"><button type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#Business_Rule_CreationPropertyBusinessModal-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.Business_Rule_CreationdisplayBusinessPropery').remove();
    }
    Business_Rule_CreationDisplayBusinessRuleButtons(!Business_Rule_CreationisdisplayBusinessPropery);
    Business_Rule_CreationisdisplayBusinessPropery = (Business_Rule_CreationisdisplayBusinessPropery ? false : true);
}
function Business_Rule_CreationDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    //Solucion Incidencia 2
    /*if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }*/
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
    $.each(Spartan_BR_Conditions_Detail_Spartan_BR_Condition_OperatorItems, function (index, item) {
        if (item.ConditionOperatorId == id)
            result = item.Description;
    });
    return result;
}

function findOperatorTypeText(id) {
    var result = '';
    $.each(Spartan_BR_Conditions_Detail_Spartan_BR_Operator_TypeItems, function (index, item) {
        if (item.OperatorTypeId == id)
            result = item.Description;
    });
    return result;
}

function findConditionsText(id) {
    var result = '';
    $.each(Spartan_BR_Conditions_Detail_Spartan_BR_ConditionItems, function (index, item) {
        if (item.ConditionId == id)
            result = item.Description;
    });
    return result;
}

function findActionText(id) {
    var result = '';
    $.each(Spartan_BR_Actions_True_Detail_Spartan_BR_ActionItems, function (index, item) {
        if (item.ActionId == id)
            result = item.Description;
    });
    return result;
}

function findActionResultText(id) {
    var result = '';
    $.each(Spartan_BR_Actions_True_Detail_Spartan_BR_Action_ResultItems, function (index, item) {
        if (item.ActionResultId == id)
            result = item.Description;
    });
    return result;
}

function findActionClassificationText(id) {
    var result = '';
    $.each(Spartan_BR_Actions_True_Detail_Spartan_BR_Action_ClassificationItems, function (index, item) {
        if (item.ClassificationId == id)
            result = item.Description;
    });
    return result;
}

function getDropdown(elementKey, rowindex, rowAlternative) {
    if (rowindex == -1)
        rowindex = rowAlternative;
    var dropDown = '<select id="' + elementKey + '_' + rowindex + '" class="form-control ' + elementKey + '"><option value=""></option></select>';
    return dropDown;
}
function getDropdownAndTextbox(elementKey, rowindex, rowAlternative) {
    if (rowindex == -1)
        rowindex = rowAlternative;
    var dropDown = '<select style="display:none;" id="ddl' + elementKey + '_' + rowindex + '" class="form-control ' + elementKey + '"><option value=""></option></select>';
    var textbox = '<textarea style="display:none;width:260px; height:80px;" id="txt' + elementKey + '_' + rowindex + '"  class="form-control ' + elementKey + '" />';

    return dropDown + textbox;
}

/*******************************/
$('#Spartan_BR_Conditions_DetailGrid').on('change', '.First_Operator_Type', function () {
    debugger;
    var control = $(this);
    var idOperatorType = control[0].id;
    var idtxtOperatorValue = 'txt' + idOperatorType.replace('Type', 'Value');
    var idddlOperatorValue = 'ddl' + idOperatorType.replace('Type', 'Value');
    GetOperatorType(control.val(), idtxtOperatorValue, idddlOperatorValue);
    Spartan_BR_Conditions_DetailTable._fnAdjustColumnSizing();
});
$('#Spartan_BR_Conditions_DetailGrid').on('change', '.Second_Operator_Type', function () {
    var control = $(this);
    var idOperatorType = control[0].id;
    var idtxtOperatorValue = 'txt' + idOperatorType.replace('Type', 'Value');
    var idddlOperatorValue = 'ddl' + idOperatorType.replace('Type', 'Value');
    GetOperatorType(control.val(), idtxtOperatorValue, idddlOperatorValue);
    Spartan_BR_Conditions_DetailTable._fnAdjustColumnSizing();
});
$('#Spartan_BR_Actions_True_DetailGrid').on('change', '.Action_Classification', function () {
    var control = $(this);
    var idActionClassification = control[0].id;
    var idDllAction = idActionClassification.replace('Action_Classification', 'Action');
    GetActionsByClassification(control.val(), idDllAction);
    Spartan_BR_Actions_True_DetailTable._fnAdjustColumnSizing();
});
$('#Spartan_BR_Actions_False_DetailGrid').on('change', '.Action_Classification', function () {
    var control = $(this);
    var idActionClassification = control[0].id;
    var idDllAction = idActionClassification.replace('Action_Classification', 'Action');
    GetActionsByClassification(control.val(), idDllAction);
    Spartan_BR_Actions_False_DetailTable._fnAdjustColumnSizing();
});
$('#Spartan_BR_Actions_True_DetailGrid').on('change', '.Action', function () {
    var control = $(this);
    var idAction = control[0].id;
    var idParameterGeneric = idAction.replace('Action', 'Parameter_[NUMBER]');
    var idParameter1 = idAction.replace('Action', 'Parameter_1');
    var idParameter2 = idAction.replace('Action', 'Parameter_2');
    var idParameter3 = idAction.replace('Action', 'Parameter_3');
    var idParameter4 = idAction.replace('Action', 'Parameter_4');
    var idParameter5 = idAction.replace('Action', 'Parameter_5');
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
    //Solucion Incidencia 6
    $('#lbl' + idParameter1).html('');
    $('#lbl' + idParameter2).html('');
    $('#lbl' + idParameter3).html('');
    $('#lbl' + idParameter4).html('');
    $('#lbl' + idParameter5).html('');
    if (control.val() != '') {
        GetParametersByActionId(control.val(), idParameterGeneric);
    }
    Spartan_BR_Actions_True_DetailTable._fnAdjustColumnSizing();
});
$('#Spartan_BR_Actions_False_DetailGrid').on('change', '.Action', function () {
    var control = $(this);
    var idAction = control[0].id;
    var idParameterGeneric = idAction.replace('Action', 'Parameter_[NUMBER]');
    var idParameter1 = idAction.replace('Action', 'Parameter_1');
    var idParameter2 = idAction.replace('Action', 'Parameter_2');
    var idParameter3 = idAction.replace('Action', 'Parameter_3');
    var idParameter4 = idAction.replace('Action', 'Parameter_4');
    var idParameter5 = idAction.replace('Action', 'Parameter_5');
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
    Spartan_BR_Actions_False_DetailTable._fnAdjustColumnSizing();
});
$('#Scopes').change(function (item) {
    if ($(this).val() == "1") {//Campo
        $('#divOperations').css('display', 'none');
        $('#divEvents').css('display', 'none');
    }
    if ($(this).val() == "2") {//Proceso
        $('#divOperations').css('display', 'block');
        $('#divEvents').css('display', 'block');
        GetEventProcess(2);
        GetOperations(2);
    }
    if ($(this).val() == "3") {//WebAPi
        $('#divOperations').css('display', 'block');
        $('#divEvents').css('display', 'block');
        GetEventProcess(3);
        GetOperations(3);
    }
});