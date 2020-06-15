

//Begin Declarations for Foreigns fields for Spartan_BR_Action_Configuration_Detail MultiRow
var Spartan_BR_Action_Configuration_DetailcountRowsChecked = 0;
function GetSpartan_BR_Action_Configuration_Detail_Spartan_BR_Action_Param_TypeName(Id) {
    for (var i = 0; i < Spartan_BR_Action_Configuration_Detail_Spartan_BR_Action_Param_TypeItems.length; i++) {
        if (Spartan_BR_Action_Configuration_Detail_Spartan_BR_Action_Param_TypeItems[i].ParameterTypeId == Id) {
            return Spartan_BR_Action_Configuration_Detail_Spartan_BR_Action_Param_TypeItems[i].Description;
        }
    }
    return "";
}

function GetSpartan_BR_Action_Configuration_Detail_Spartan_BR_Action_Param_TypeDropDown() {
    var Spartan_BR_Action_Configuration_Detail_Spartan_BR_Action_Param_TypeDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_BR_Action_Configuration_Detail_Spartan_BR_Action_Param_TypeDropdown);

    for (var i = 0; i < Spartan_BR_Action_Configuration_Detail_Spartan_BR_Action_Param_TypeItems.length; i++) {
        $('<option />', { value: Spartan_BR_Action_Configuration_Detail_Spartan_BR_Action_Param_TypeItems[i].ParameterTypeId, text: Spartan_BR_Action_Configuration_Detail_Spartan_BR_Action_Param_TypeItems[i].Description }).appendTo(Spartan_BR_Action_Configuration_Detail_Spartan_BR_Action_Param_TypeDropdown);
    }
    return Spartan_BR_Action_Configuration_Detail_Spartan_BR_Action_Param_TypeDropdown;
}


function GetInsertSpartan_BR_Action_Configuration_DetailRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $($.parseHTML(inputData)).addClass('Spartan_BR_Action_Configuration_Detail_Parameter_Name').attr('id', 'Spartan_BR_Action_Configuration_Detail_Parameter_Name_' + index);
    columnData[1] = $(GetSpartan_BR_Action_Configuration_Detail_Spartan_BR_Action_Param_TypeDropDown()).addClass('Spartan_BR_Action_Configuration_Detail_Parameter_Type').attr('id', 'Spartan_BR_Action_Configuration_Detail_Parameter_Type_' + index);


    initiateUIControls();
    return columnData;
}

function Spartan_BR_Action_Configuration_DetailInsertRow(rowIndex) {
    var prevData = Spartan_BR_Action_Configuration_DetailTable.fnGetData(rowIndex);
    var data = Spartan_BR_Action_Configuration_DetailTable.fnGetNodes(rowIndex);
    var newData = {
        ActionConfigurationId: prevData.ActionConfigurationId,
        IsInsertRow: false
        ,Parameter_Name: data.childNodes[1].childNodes[0].value
        ,Parameter_Type: data.childNodes[2].childNodes[0].value

    }
    Spartan_BR_Action_Configuration_DetailTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_BR_Action_Configuration_DetailrowCreationGrid(data, newData, rowIndex);
    Spartan_BR_Action_Configuration_DetailcountRowsChecked--;	
}

function Spartan_BR_Action_Configuration_DetailCancelRow(rowIndex) {
    var prevData = Spartan_BR_Action_Configuration_DetailTable.fnGetData(rowIndex);
    var data = Spartan_BR_Action_Configuration_DetailTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Spartan_BR_Action_Configuration_DetailTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Spartan_BR_Action_Configuration_DetailrowCreationGrid(data, prevData, rowIndex);
    }
    Spartan_BR_Action_Configuration_DetailcountRowsChecked--;
}

function GetSpartan_BR_Action_Configuration_DetailFromDataTable() {
    var Spartan_BR_Action_Configuration_DetailData = [];
    var gridData = Spartan_BR_Action_Configuration_DetailTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Spartan_BR_Action_Configuration_DetailData.push({
                ActionConfigurationId: gridData[i].ActionConfigurationId
                ,Parameter_Name: gridData[i].Parameter_Name
                ,Parameter_Type: gridData[i].Parameter_Type

                ,Removed: false
            });
    }

    for (i = 0; i < removedSpartan_BR_Action_Configuration_DetailData.length; i++) {
        if (removedSpartan_BR_Action_Configuration_DetailData[i] != null && removedSpartan_BR_Action_Configuration_DetailData[i].ActionConfigurationId > 0)
            Spartan_BR_Action_Configuration_DetailData.push({
                ActionConfigurationId: removedSpartan_BR_Action_Configuration_DetailData[i].ActionConfigurationId
                ,Parameter_Name: removedData[i].Parameter_Name
                ,Parameter_Type: removedSpartan_BR_Action_Param_TypeData[i].Parameter_Type

                , Removed: true
            });
    }	

    return Spartan_BR_Action_Configuration_DetailData;
}

function Spartan_BR_Action_Configuration_DetailEditRow(rowIndex) {
    Spartan_BR_Action_Configuration_DetailcountRowsChecked++;
    var Spartan_BR_Action_Configuration_DetailRowElement = "Spartan_BR_Action_Configuration_Detail_" + rowIndex.toString();
    var prevData = Spartan_BR_Action_Configuration_DetailTable.fnGetData(rowIndex);
    var row = Spartan_BR_Action_Configuration_DetailTable.fnGetNodes(rowIndex);
    row.innerHTML = "";

    var controls = Spartan_BR_Action_Configuration_DetailGetUpdateRowControls(prevData);

    var abc = "if(dynamicFieldValidation('" + Spartan_BR_Action_Configuration_DetailRowElement + "')){ Spartan_BR_Action_Configuration_DetailInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Spartan_BR_Action_Configuration_DetailCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (var i = 0; i < controls.length; i++) {
        $(controls[i]).appendTo($('<td>').appendTo(row));
    }

    initiateUIControls();
}

function Spartan_BR_Action_Configuration_DetailfnOpenAddRowPopUp() {
    var currentRowIndex = Spartan_BR_Action_Configuration_DetailTable.fnGetData().length;
    Spartan_BR_Action_Configuration_DetailfnClickAddRow();
    GetAddSpartan_BR_Action_Configuration_DetailPopup(currentRowIndex, 0);
}

function Spartan_BR_Action_Configuration_DetailEditRowPopup(rowIndex) {
    var Spartan_BR_Action_Configuration_DetailRowElement = "Spartan_BR_Action_Configuration_Detail_" + rowIndex.toString();
    var prevData = Spartan_BR_Action_Configuration_DetailTable.fnGetData(rowIndex);
    GetAddSpartan_BR_Action_Configuration_DetailPopup(rowIndex, 1);
    $('#Parameter_NamePop').val(prevData.Parameter_Name);
    $('#Parameter_TypePop').val(prevData.Parameter_Type);

    initiateUIControls();

}

function Spartan_BR_Action_Configuration_DetailAddInsertRow() {
    if (Spartan_BR_Action_Configuration_DetailinsertRowCurrentIndex < 1)
    {
        Spartan_BR_Action_Configuration_DetailinsertRowCurrentIndex = 1;
    }
    return {
        ActionConfigurationId: null,
        IsInsertRow: true
        ,Parameter_Name: ""
        ,Parameter_Type: ""

    }
}

function Spartan_BR_Action_Configuration_DetailfnClickAddRow() {
    Spartan_BR_Action_Configuration_DetailcountRowsChecked++;
    Spartan_BR_Action_Configuration_DetailTable
        .fnAddData(Spartan_BR_Action_Configuration_DetailAddInsertRow(), true);
    initiateUIControls();
}

function Spartan_BR_Action_Configuration_DetailClearGridData() {
    Spartan_BR_Action_Configuration_DetailData = [];
    Spartan_BR_Action_Configuration_DetaildeletedItem = [];
    Spartan_BR_Action_Configuration_DetailDataMain = [];
    Spartan_BR_Action_Configuration_DetailDataMainPages = [];
    Spartan_BR_Action_Configuration_DetailnewItemCount = 0;
    Spartan_BR_Action_Configuration_DetailmaxItemIndex = 0;
    $("#Spartan_BR_Action_Configuration_DetailGrid").DataTable().clear();
    $("#Spartan_BR_Action_Configuration_DetailGrid").DataTable().destroy();
}

//Used to Get Business Rule Action Information
function GetSpartan_BR_Action_Configuration_Detail() {
    var form_data = new FormData();
    for (var i = 0; i < Spartan_BR_Action_Configuration_DetailData.length; i++) {
        form_data.append('[' + i + '].ActionConfigurationId', Spartan_BR_Action_Configuration_DetailData[i].ActionConfigurationId);
        form_data.append('[' + i + '].Parameter_Name', Spartan_BR_Action_Configuration_DetailData[i].Parameter_Name);
        form_data.append('[' + i + '].Parameter_Type', Spartan_BR_Action_Configuration_DetailData[i].Parameter_Type);

        form_data.append('[' + i + '].Removed', Spartan_BR_Action_Configuration_DetailData[i].Removed);
    }
    return form_data;
}
function Spartan_BR_Action_Configuration_DetailInsertRowFromPopup(rowIndex) {
    var prevData = Spartan_BR_Action_Configuration_DetailTable.fnGetData(rowIndex);
    var data = Spartan_BR_Action_Configuration_DetailTable.fnGetNodes(rowIndex);
    var newData = {
        ActionId: prevData.ActionId,
        IsInsertRow: false
        ,Parameter_Name: $('#Parameter_NamePop').val()
        ,Parameter_Type: $('#dvParameter_Type').find('select').val()

    }

    Spartan_BR_Action_Configuration_DetailTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_BR_Action_Configuration_DetailrowCreationGrid(data, newData, rowIndex);
    $('#AddSpartan_BR_Action_Configuration_Detail-form').modal({ show: false });
    $('#AddSpartan_BR_Action_Configuration_Detail-form').modal('hide');
}
function Spartan_BR_Action_Configuration_DetailRemoveAddRow(rowIndex) {
    Spartan_BR_Action_Configuration_DetailTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Spartan_BR_Action_Configuration_Detail MultiRow
//Begin Declarations for Foreigns fields for Spartan_BR_Attribute_Restrictions_Detail MultiRow
var Spartan_BR_Attribute_Restrictions_DetailcountRowsChecked = 0;
function GetSpartan_BR_Attribute_Restrictions_Detail_Spartan_Attribute_TypeName(Id) {
    for (var i = 0; i < Spartan_BR_Attribute_Restrictions_Detail_Spartan_Attribute_TypeItems.length; i++) {
        if (Spartan_BR_Attribute_Restrictions_Detail_Spartan_Attribute_TypeItems[i].Attribute_Type_Id == Id) {
            return Spartan_BR_Attribute_Restrictions_Detail_Spartan_Attribute_TypeItems[i].Description;
        }
    }
    return "";
}

function GetSpartan_BR_Attribute_Restrictions_Detail_Spartan_Attribute_TypeDropDown() {
    var Spartan_BR_Attribute_Restrictions_Detail_Spartan_Attribute_TypeDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_BR_Attribute_Restrictions_Detail_Spartan_Attribute_TypeDropdown);

    for (var i = 0; i < Spartan_BR_Attribute_Restrictions_Detail_Spartan_Attribute_TypeItems.length; i++) {
        $('<option />', { value: Spartan_BR_Attribute_Restrictions_Detail_Spartan_Attribute_TypeItems[i].Attribute_Type_Id, text: Spartan_BR_Attribute_Restrictions_Detail_Spartan_Attribute_TypeItems[i].Description }).appendTo(Spartan_BR_Attribute_Restrictions_Detail_Spartan_Attribute_TypeDropdown);
    }
    return Spartan_BR_Attribute_Restrictions_Detail_Spartan_Attribute_TypeDropdown;
}
function GetSpartan_BR_Attribute_Restrictions_Detail_Spartan_Attribute_Control_TypeName(Id) {
    for (var i = 0; i < Spartan_BR_Attribute_Restrictions_Detail_Spartan_Attribute_Control_TypeItems.length; i++) {
        if (Spartan_BR_Attribute_Restrictions_Detail_Spartan_Attribute_Control_TypeItems[i].ControlTypeId == Id) {
            return Spartan_BR_Attribute_Restrictions_Detail_Spartan_Attribute_Control_TypeItems[i].Description;
        }
    }
    return "";
}

function GetSpartan_BR_Attribute_Restrictions_Detail_Spartan_Attribute_Control_TypeDropDown() {
    var Spartan_BR_Attribute_Restrictions_Detail_Spartan_Attribute_Control_TypeDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_BR_Attribute_Restrictions_Detail_Spartan_Attribute_Control_TypeDropdown);

    for (var i = 0; i < Spartan_BR_Attribute_Restrictions_Detail_Spartan_Attribute_Control_TypeItems.length; i++) {
        $('<option />', { value: Spartan_BR_Attribute_Restrictions_Detail_Spartan_Attribute_Control_TypeItems[i].ControlTypeId, text: Spartan_BR_Attribute_Restrictions_Detail_Spartan_Attribute_Control_TypeItems[i].Description }).appendTo(Spartan_BR_Attribute_Restrictions_Detail_Spartan_Attribute_Control_TypeDropdown);
    }
    return Spartan_BR_Attribute_Restrictions_Detail_Spartan_Attribute_Control_TypeDropdown;
}


function GetInsertSpartan_BR_Attribute_Restrictions_DetailRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $(GetSpartan_BR_Attribute_Restrictions_Detail_Spartan_Attribute_TypeDropDown()).addClass('Spartan_BR_Attribute_Restrictions_Detail_Attribute_Type').attr('id', 'Spartan_BR_Attribute_Restrictions_Detail_Attribute_Type_' + index);
    columnData[1] = $(GetSpartan_BR_Attribute_Restrictions_Detail_Spartan_Attribute_Control_TypeDropDown()).addClass('Spartan_BR_Attribute_Restrictions_Detail_Control_Type').attr('id', 'Spartan_BR_Attribute_Restrictions_Detail_Control_Type_' + index);


    initiateUIControls();
    return columnData;
}

function Spartan_BR_Attribute_Restrictions_DetailInsertRow(rowIndex) {
    var prevData = Spartan_BR_Attribute_Restrictions_DetailTable.fnGetData(rowIndex);
    var data = Spartan_BR_Attribute_Restrictions_DetailTable.fnGetNodes(rowIndex);
    var newData = {
        RestrictionId: prevData.RestrictionId,
        IsInsertRow: false
        ,Attribute_Type: data.childNodes[1].childNodes[0].value
        ,Control_Type: data.childNodes[2].childNodes[0].value

    }
    Spartan_BR_Attribute_Restrictions_DetailTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_BR_Attribute_Restrictions_DetailrowCreationGrid(data, newData, rowIndex);
    Spartan_BR_Attribute_Restrictions_DetailcountRowsChecked--;	
}

function Spartan_BR_Attribute_Restrictions_DetailCancelRow(rowIndex) {
    var prevData = Spartan_BR_Attribute_Restrictions_DetailTable.fnGetData(rowIndex);
    var data = Spartan_BR_Attribute_Restrictions_DetailTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Spartan_BR_Attribute_Restrictions_DetailTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Spartan_BR_Attribute_Restrictions_DetailrowCreationGrid(data, prevData, rowIndex);
    }
    Spartan_BR_Attribute_Restrictions_DetailcountRowsChecked--;
}

function GetSpartan_BR_Attribute_Restrictions_DetailFromDataTable() {
    var Spartan_BR_Attribute_Restrictions_DetailData = [];
    var gridData = Spartan_BR_Attribute_Restrictions_DetailTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Spartan_BR_Attribute_Restrictions_DetailData.push({
                RestrictionId: gridData[i].RestrictionId
                ,Attribute_Type: gridData[i].Attribute_Type
                ,Control_Type: gridData[i].Control_Type

                ,Removed: false
            });
    }

    for (i = 0; i < removedSpartan_BR_Attribute_Restrictions_DetailData.length; i++) {
        if (removedSpartan_BR_Attribute_Restrictions_DetailData[i] != null && removedSpartan_BR_Attribute_Restrictions_DetailData[i].RestrictionId > 0)
            Spartan_BR_Attribute_Restrictions_DetailData.push({
                RestrictionId: removedSpartan_BR_Attribute_Restrictions_DetailData[i].RestrictionId
                ,Attribute_Type: removedSpartan_Attribute_TypeData[i].Attribute_Type
                ,Control_Type: removedSpartan_Attribute_Control_TypeData[i].Control_Type

                , Removed: true
            });
    }	

    return Spartan_BR_Attribute_Restrictions_DetailData;
}

function Spartan_BR_Attribute_Restrictions_DetailEditRow(rowIndex) {
    Spartan_BR_Attribute_Restrictions_DetailcountRowsChecked++;
    var Spartan_BR_Attribute_Restrictions_DetailRowElement = "Spartan_BR_Attribute_Restrictions_Detail_" + rowIndex.toString();
    var prevData = Spartan_BR_Attribute_Restrictions_DetailTable.fnGetData(rowIndex);
    var row = Spartan_BR_Attribute_Restrictions_DetailTable.fnGetNodes(rowIndex);
    row.innerHTML = "";

    var controls = Spartan_BR_Attribute_Restrictions_DetailGetUpdateRowControls(prevData);

    var abc = "if(dynamicFieldValidation('" + Spartan_BR_Attribute_Restrictions_DetailRowElement + "')){ Spartan_BR_Attribute_Restrictions_DetailInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Spartan_BR_Attribute_Restrictions_DetailCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (var i = 0; i < controls.length; i++) {
        $(controls[i]).appendTo($('<td>').appendTo(row));
    }

    initiateUIControls();
}

function Spartan_BR_Attribute_Restrictions_DetailfnOpenAddRowPopUp() {
    var currentRowIndex = Spartan_BR_Attribute_Restrictions_DetailTable.fnGetData().length;
    Spartan_BR_Attribute_Restrictions_DetailfnClickAddRow();
    GetAddSpartan_BR_Attribute_Restrictions_DetailPopup(currentRowIndex, 0);
}

function Spartan_BR_Attribute_Restrictions_DetailEditRowPopup(rowIndex) {
    var Spartan_BR_Attribute_Restrictions_DetailRowElement = "Spartan_BR_Attribute_Restrictions_Detail_" + rowIndex.toString();
    var prevData = Spartan_BR_Attribute_Restrictions_DetailTable.fnGetData(rowIndex);
    GetAddSpartan_BR_Attribute_Restrictions_DetailPopup(rowIndex, 1);
    $('#Attribute_TypePop').val(prevData.Attribute_Type);
    $('#Control_TypePop').val(prevData.Control_Type);

    initiateUIControls();

}

function Spartan_BR_Attribute_Restrictions_DetailAddInsertRow() {
    if (Spartan_BR_Attribute_Restrictions_DetailinsertRowCurrentIndex < 1)
    {
        Spartan_BR_Attribute_Restrictions_DetailinsertRowCurrentIndex = 1;
    }
    return {
        RestrictionId: null,
        IsInsertRow: true
        ,Attribute_Type: ""
        ,Control_Type: ""

    }
}

function Spartan_BR_Attribute_Restrictions_DetailfnClickAddRow() {
    Spartan_BR_Attribute_Restrictions_DetailcountRowsChecked++;
    Spartan_BR_Attribute_Restrictions_DetailTable
        .fnAddData(Spartan_BR_Attribute_Restrictions_DetailAddInsertRow(), true);
    initiateUIControls();
}

function Spartan_BR_Attribute_Restrictions_DetailClearGridData() {
    Spartan_BR_Attribute_Restrictions_DetailData = [];
    Spartan_BR_Attribute_Restrictions_DetaildeletedItem = [];
    Spartan_BR_Attribute_Restrictions_DetailDataMain = [];
    Spartan_BR_Attribute_Restrictions_DetailDataMainPages = [];
    Spartan_BR_Attribute_Restrictions_DetailnewItemCount = 0;
    Spartan_BR_Attribute_Restrictions_DetailmaxItemIndex = 0;
    $("#Spartan_BR_Attribute_Restrictions_DetailGrid").DataTable().clear();
    $("#Spartan_BR_Attribute_Restrictions_DetailGrid").DataTable().destroy();
}

//Used to Get Business Rule Action Information
function GetSpartan_BR_Attribute_Restrictions_Detail() {
    var form_data = new FormData();
    for (var i = 0; i < Spartan_BR_Attribute_Restrictions_DetailData.length; i++) {
        form_data.append('[' + i + '].RestrictionId', Spartan_BR_Attribute_Restrictions_DetailData[i].RestrictionId);
        form_data.append('[' + i + '].Attribute_Type', Spartan_BR_Attribute_Restrictions_DetailData[i].Attribute_Type);
        form_data.append('[' + i + '].Control_Type', Spartan_BR_Attribute_Restrictions_DetailData[i].Control_Type);

        form_data.append('[' + i + '].Removed', Spartan_BR_Attribute_Restrictions_DetailData[i].Removed);
    }
    return form_data;
}
function Spartan_BR_Attribute_Restrictions_DetailInsertRowFromPopup(rowIndex) {
    var prevData = Spartan_BR_Attribute_Restrictions_DetailTable.fnGetData(rowIndex);
    var data = Spartan_BR_Attribute_Restrictions_DetailTable.fnGetNodes(rowIndex);
    var newData = {
        ActionId: prevData.ActionId,
        IsInsertRow: false
        ,Attribute_Type: $('#dvAttribute_Type').find('select').val()
        ,Control_Type: $('#dvControl_Type').find('select').val()

    }

    Spartan_BR_Attribute_Restrictions_DetailTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_BR_Attribute_Restrictions_DetailrowCreationGrid(data, newData, rowIndex);
    $('#AddSpartan_BR_Attribute_Restrictions_Detail-form').modal({ show: false });
    $('#AddSpartan_BR_Attribute_Restrictions_Detail-form').modal('hide');
}
function Spartan_BR_Attribute_Restrictions_DetailRemoveAddRow(rowIndex) {
    Spartan_BR_Attribute_Restrictions_DetailTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Spartan_BR_Attribute_Restrictions_Detail MultiRow
//Begin Declarations for Foreigns fields for Spartan_BR_Operation_Restrictions_Detail MultiRow
var Spartan_BR_Operation_Restrictions_DetailcountRowsChecked = 0;
function GetSpartan_BR_Operation_Restrictions_Detail_Spartan_BR_OperationName(Id) {
    for (var i = 0; i < Spartan_BR_Operation_Restrictions_Detail_Spartan_BR_OperationItems.length; i++) {
        if (Spartan_BR_Operation_Restrictions_Detail_Spartan_BR_OperationItems[i].OperationId == Id) {
            return Spartan_BR_Operation_Restrictions_Detail_Spartan_BR_OperationItems[i].Description;
        }
    }
    return "";
}

function GetSpartan_BR_Operation_Restrictions_Detail_Spartan_BR_OperationDropDown() {
    var Spartan_BR_Operation_Restrictions_Detail_Spartan_BR_OperationDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_BR_Operation_Restrictions_Detail_Spartan_BR_OperationDropdown);

    for (var i = 0; i < Spartan_BR_Operation_Restrictions_Detail_Spartan_BR_OperationItems.length; i++) {
        $('<option />', { value: Spartan_BR_Operation_Restrictions_Detail_Spartan_BR_OperationItems[i].OperationId, text: Spartan_BR_Operation_Restrictions_Detail_Spartan_BR_OperationItems[i].Description }).appendTo(Spartan_BR_Operation_Restrictions_Detail_Spartan_BR_OperationDropdown);
    }
    return Spartan_BR_Operation_Restrictions_Detail_Spartan_BR_OperationDropdown;
}


function GetInsertSpartan_BR_Operation_Restrictions_DetailRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $(GetSpartan_BR_Operation_Restrictions_Detail_Spartan_BR_OperationDropDown()).addClass('Spartan_BR_Operation_Restrictions_Detail_Operation').attr('id', 'Spartan_BR_Operation_Restrictions_Detail_Operation_' + index);


    initiateUIControls();
    return columnData;
}

function Spartan_BR_Operation_Restrictions_DetailInsertRow(rowIndex) {
    var prevData = Spartan_BR_Operation_Restrictions_DetailTable.fnGetData(rowIndex);
    var data = Spartan_BR_Operation_Restrictions_DetailTable.fnGetNodes(rowIndex);
    var newData = {
        RestrictionId: prevData.RestrictionId,
        IsInsertRow: false
        ,Operation: data.childNodes[1].childNodes[0].value

    }
    Spartan_BR_Operation_Restrictions_DetailTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_BR_Operation_Restrictions_DetailrowCreationGrid(data, newData, rowIndex);
    Spartan_BR_Operation_Restrictions_DetailcountRowsChecked--;	
}

function Spartan_BR_Operation_Restrictions_DetailCancelRow(rowIndex) {
    var prevData = Spartan_BR_Operation_Restrictions_DetailTable.fnGetData(rowIndex);
    var data = Spartan_BR_Operation_Restrictions_DetailTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Spartan_BR_Operation_Restrictions_DetailTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Spartan_BR_Operation_Restrictions_DetailrowCreationGrid(data, prevData, rowIndex);
    }
    Spartan_BR_Operation_Restrictions_DetailcountRowsChecked--;
}

function GetSpartan_BR_Operation_Restrictions_DetailFromDataTable() {
    var Spartan_BR_Operation_Restrictions_DetailData = [];
    var gridData = Spartan_BR_Operation_Restrictions_DetailTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Spartan_BR_Operation_Restrictions_DetailData.push({
                RestrictionId: gridData[i].RestrictionId
                ,Operation: gridData[i].Operation

                ,Removed: false
            });
    }

    for (i = 0; i < removedSpartan_BR_Operation_Restrictions_DetailData.length; i++) {
        if (removedSpartan_BR_Operation_Restrictions_DetailData[i] != null && removedSpartan_BR_Operation_Restrictions_DetailData[i].RestrictionId > 0)
            Spartan_BR_Operation_Restrictions_DetailData.push({
                RestrictionId: removedSpartan_BR_Operation_Restrictions_DetailData[i].RestrictionId
                ,Operation: removedSpartan_BR_OperationData[i].Operation

                , Removed: true
            });
    }	

    return Spartan_BR_Operation_Restrictions_DetailData;
}

function Spartan_BR_Operation_Restrictions_DetailEditRow(rowIndex) {
    Spartan_BR_Operation_Restrictions_DetailcountRowsChecked++;
    var Spartan_BR_Operation_Restrictions_DetailRowElement = "Spartan_BR_Operation_Restrictions_Detail_" + rowIndex.toString();
    var prevData = Spartan_BR_Operation_Restrictions_DetailTable.fnGetData(rowIndex);
    var row = Spartan_BR_Operation_Restrictions_DetailTable.fnGetNodes(rowIndex);
    row.innerHTML = "";

    var controls = Spartan_BR_Operation_Restrictions_DetailGetUpdateRowControls(prevData);

    var abc = "if(dynamicFieldValidation('" + Spartan_BR_Operation_Restrictions_DetailRowElement + "')){ Spartan_BR_Operation_Restrictions_DetailInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Spartan_BR_Operation_Restrictions_DetailCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (var i = 0; i < controls.length; i++) {
        $(controls[i]).appendTo($('<td>').appendTo(row));
    }

    initiateUIControls();
}

function Spartan_BR_Operation_Restrictions_DetailfnOpenAddRowPopUp() {
    var currentRowIndex = Spartan_BR_Operation_Restrictions_DetailTable.fnGetData().length;
    Spartan_BR_Operation_Restrictions_DetailfnClickAddRow();
    GetAddSpartan_BR_Operation_Restrictions_DetailPopup(currentRowIndex, 0);
}

function Spartan_BR_Operation_Restrictions_DetailEditRowPopup(rowIndex) {
    var Spartan_BR_Operation_Restrictions_DetailRowElement = "Spartan_BR_Operation_Restrictions_Detail_" + rowIndex.toString();
    var prevData = Spartan_BR_Operation_Restrictions_DetailTable.fnGetData(rowIndex);
    GetAddSpartan_BR_Operation_Restrictions_DetailPopup(rowIndex, 1);
    $('#OperationPop').val(prevData.Operation);

    initiateUIControls();

}

function Spartan_BR_Operation_Restrictions_DetailAddInsertRow() {
    if (Spartan_BR_Operation_Restrictions_DetailinsertRowCurrentIndex < 1)
    {
        Spartan_BR_Operation_Restrictions_DetailinsertRowCurrentIndex = 1;
    }
    return {
        RestrictionId: null,
        IsInsertRow: true
        ,Operation: ""

    }
}

function Spartan_BR_Operation_Restrictions_DetailfnClickAddRow() {
    Spartan_BR_Operation_Restrictions_DetailcountRowsChecked++;
    Spartan_BR_Operation_Restrictions_DetailTable
        .fnAddData(Spartan_BR_Operation_Restrictions_DetailAddInsertRow(), true);
    initiateUIControls();
}

function Spartan_BR_Operation_Restrictions_DetailClearGridData() {
    Spartan_BR_Operation_Restrictions_DetailData = [];
    Spartan_BR_Operation_Restrictions_DetaildeletedItem = [];
    Spartan_BR_Operation_Restrictions_DetailDataMain = [];
    Spartan_BR_Operation_Restrictions_DetailDataMainPages = [];
    Spartan_BR_Operation_Restrictions_DetailnewItemCount = 0;
    Spartan_BR_Operation_Restrictions_DetailmaxItemIndex = 0;
    $("#Spartan_BR_Operation_Restrictions_DetailGrid").DataTable().clear();
    $("#Spartan_BR_Operation_Restrictions_DetailGrid").DataTable().destroy();
}

//Used to Get Business Rule Action Information
function GetSpartan_BR_Operation_Restrictions_Detail() {
    var form_data = new FormData();
    for (var i = 0; i < Spartan_BR_Operation_Restrictions_DetailData.length; i++) {
        form_data.append('[' + i + '].RestrictionId', Spartan_BR_Operation_Restrictions_DetailData[i].RestrictionId);
        form_data.append('[' + i + '].Operation', Spartan_BR_Operation_Restrictions_DetailData[i].Operation);

        form_data.append('[' + i + '].Removed', Spartan_BR_Operation_Restrictions_DetailData[i].Removed);
    }
    return form_data;
}
function Spartan_BR_Operation_Restrictions_DetailInsertRowFromPopup(rowIndex) {
    var prevData = Spartan_BR_Operation_Restrictions_DetailTable.fnGetData(rowIndex);
    var data = Spartan_BR_Operation_Restrictions_DetailTable.fnGetNodes(rowIndex);
    var newData = {
        ActionId: prevData.ActionId,
        IsInsertRow: false
        ,Operation: $('#dvOperation').find('select').val()

    }

    Spartan_BR_Operation_Restrictions_DetailTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_BR_Operation_Restrictions_DetailrowCreationGrid(data, newData, rowIndex);
    $('#AddSpartan_BR_Operation_Restrictions_Detail-form').modal({ show: false });
    $('#AddSpartan_BR_Operation_Restrictions_Detail-form').modal('hide');
}
function Spartan_BR_Operation_Restrictions_DetailRemoveAddRow(rowIndex) {
    Spartan_BR_Operation_Restrictions_DetailTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Spartan_BR_Operation_Restrictions_Detail MultiRow
//Begin Declarations for Foreigns fields for Spartan_BR_Event_Restrictions_Detail MultiRow
var Spartan_BR_Event_Restrictions_DetailcountRowsChecked = 0;
function GetSpartan_BR_Event_Restrictions_Detail_Spartan_BR_Process_EventName(Id) {
    for (var i = 0; i < Spartan_BR_Event_Restrictions_Detail_Spartan_BR_Process_EventItems.length; i++) {
        if (Spartan_BR_Event_Restrictions_Detail_Spartan_BR_Process_EventItems[i].ProcessEventId == Id) {
            return Spartan_BR_Event_Restrictions_Detail_Spartan_BR_Process_EventItems[i].Description;
        }
    }
    return "";
}

function GetSpartan_BR_Event_Restrictions_Detail_Spartan_BR_Process_EventDropDown() {
    var Spartan_BR_Event_Restrictions_Detail_Spartan_BR_Process_EventDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_BR_Event_Restrictions_Detail_Spartan_BR_Process_EventDropdown);

    for (var i = 0; i < Spartan_BR_Event_Restrictions_Detail_Spartan_BR_Process_EventItems.length; i++) {
        $('<option />', { value: Spartan_BR_Event_Restrictions_Detail_Spartan_BR_Process_EventItems[i].ProcessEventId, text: Spartan_BR_Event_Restrictions_Detail_Spartan_BR_Process_EventItems[i].Description }).appendTo(Spartan_BR_Event_Restrictions_Detail_Spartan_BR_Process_EventDropdown);
    }
    return Spartan_BR_Event_Restrictions_Detail_Spartan_BR_Process_EventDropdown;
}


function GetInsertSpartan_BR_Event_Restrictions_DetailRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $(GetSpartan_BR_Event_Restrictions_Detail_Spartan_BR_Process_EventDropDown()).addClass('Spartan_BR_Event_Restrictions_Detail_Process_Event').attr('id', 'Spartan_BR_Event_Restrictions_Detail_Process_Event_' + index);


    initiateUIControls();
    return columnData;
}

function Spartan_BR_Event_Restrictions_DetailInsertRow(rowIndex) {
    var prevData = Spartan_BR_Event_Restrictions_DetailTable.fnGetData(rowIndex);
    var data = Spartan_BR_Event_Restrictions_DetailTable.fnGetNodes(rowIndex);
    var newData = {
        RestrictionId: prevData.RestrictionId,
        IsInsertRow: false
        ,Process_Event: data.childNodes[1].childNodes[0].value

    }
    Spartan_BR_Event_Restrictions_DetailTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_BR_Event_Restrictions_DetailrowCreationGrid(data, newData, rowIndex);
    Spartan_BR_Event_Restrictions_DetailcountRowsChecked--;	
}

function Spartan_BR_Event_Restrictions_DetailCancelRow(rowIndex) {
    var prevData = Spartan_BR_Event_Restrictions_DetailTable.fnGetData(rowIndex);
    var data = Spartan_BR_Event_Restrictions_DetailTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Spartan_BR_Event_Restrictions_DetailTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Spartan_BR_Event_Restrictions_DetailrowCreationGrid(data, prevData, rowIndex);
    }
    Spartan_BR_Event_Restrictions_DetailcountRowsChecked--;
}

function GetSpartan_BR_Event_Restrictions_DetailFromDataTable() {
    var Spartan_BR_Event_Restrictions_DetailData = [];
    var gridData = Spartan_BR_Event_Restrictions_DetailTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Spartan_BR_Event_Restrictions_DetailData.push({
                RestrictionId: gridData[i].RestrictionId
                ,Process_Event: gridData[i].Process_Event

                ,Removed: false
            });
    }

    for (i = 0; i < removedSpartan_BR_Event_Restrictions_DetailData.length; i++) {
        if (removedSpartan_BR_Event_Restrictions_DetailData[i] != null && removedSpartan_BR_Event_Restrictions_DetailData[i].RestrictionId > 0)
            Spartan_BR_Event_Restrictions_DetailData.push({
                RestrictionId: removedSpartan_BR_Event_Restrictions_DetailData[i].RestrictionId
                ,Process_Event: removedSpartan_BR_Process_EventData[i].Process_Event

                , Removed: true
            });
    }	

    return Spartan_BR_Event_Restrictions_DetailData;
}

function Spartan_BR_Event_Restrictions_DetailEditRow(rowIndex) {
    Spartan_BR_Event_Restrictions_DetailcountRowsChecked++;
    var Spartan_BR_Event_Restrictions_DetailRowElement = "Spartan_BR_Event_Restrictions_Detail_" + rowIndex.toString();
    var prevData = Spartan_BR_Event_Restrictions_DetailTable.fnGetData(rowIndex);
    var row = Spartan_BR_Event_Restrictions_DetailTable.fnGetNodes(rowIndex);
    row.innerHTML = "";

    var controls = Spartan_BR_Event_Restrictions_DetailGetUpdateRowControls(prevData);

    var abc = "if(dynamicFieldValidation('" + Spartan_BR_Event_Restrictions_DetailRowElement + "')){ Spartan_BR_Event_Restrictions_DetailInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Spartan_BR_Event_Restrictions_DetailCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (var i = 0; i < controls.length; i++) {
        $(controls[i]).appendTo($('<td>').appendTo(row));
    }

    initiateUIControls();
}

function Spartan_BR_Event_Restrictions_DetailfnOpenAddRowPopUp() {
    var currentRowIndex = Spartan_BR_Event_Restrictions_DetailTable.fnGetData().length;
    Spartan_BR_Event_Restrictions_DetailfnClickAddRow();
    GetAddSpartan_BR_Event_Restrictions_DetailPopup(currentRowIndex, 0);
}

function Spartan_BR_Event_Restrictions_DetailEditRowPopup(rowIndex) {
    var Spartan_BR_Event_Restrictions_DetailRowElement = "Spartan_BR_Event_Restrictions_Detail_" + rowIndex.toString();
    var prevData = Spartan_BR_Event_Restrictions_DetailTable.fnGetData(rowIndex);
    GetAddSpartan_BR_Event_Restrictions_DetailPopup(rowIndex, 1);
    $('#Process_EventPop').val(prevData.Process_Event);

    initiateUIControls();

}

function Spartan_BR_Event_Restrictions_DetailAddInsertRow() {
    if (Spartan_BR_Event_Restrictions_DetailinsertRowCurrentIndex < 1)
    {
        Spartan_BR_Event_Restrictions_DetailinsertRowCurrentIndex = 1;
    }
    return {
        RestrictionId: null,
        IsInsertRow: true
        ,Process_Event: ""

    }
}

function Spartan_BR_Event_Restrictions_DetailfnClickAddRow() {
    Spartan_BR_Event_Restrictions_DetailcountRowsChecked++;
    Spartan_BR_Event_Restrictions_DetailTable
        .fnAddData(Spartan_BR_Event_Restrictions_DetailAddInsertRow(), true);
    initiateUIControls();
}

function Spartan_BR_Event_Restrictions_DetailClearGridData() {
    Spartan_BR_Event_Restrictions_DetailData = [];
    Spartan_BR_Event_Restrictions_DetaildeletedItem = [];
    Spartan_BR_Event_Restrictions_DetailDataMain = [];
    Spartan_BR_Event_Restrictions_DetailDataMainPages = [];
    Spartan_BR_Event_Restrictions_DetailnewItemCount = 0;
    Spartan_BR_Event_Restrictions_DetailmaxItemIndex = 0;
    $("#Spartan_BR_Event_Restrictions_DetailGrid").DataTable().clear();
    $("#Spartan_BR_Event_Restrictions_DetailGrid").DataTable().destroy();
}

//Used to Get Business Rule Action Information
function GetSpartan_BR_Event_Restrictions_Detail() {
    var form_data = new FormData();
    for (var i = 0; i < Spartan_BR_Event_Restrictions_DetailData.length; i++) {
        form_data.append('[' + i + '].RestrictionId', Spartan_BR_Event_Restrictions_DetailData[i].RestrictionId);
        form_data.append('[' + i + '].Process_Event', Spartan_BR_Event_Restrictions_DetailData[i].Process_Event);

        form_data.append('[' + i + '].Removed', Spartan_BR_Event_Restrictions_DetailData[i].Removed);
    }
    return form_data;
}
function Spartan_BR_Event_Restrictions_DetailInsertRowFromPopup(rowIndex) {
    var prevData = Spartan_BR_Event_Restrictions_DetailTable.fnGetData(rowIndex);
    var data = Spartan_BR_Event_Restrictions_DetailTable.fnGetNodes(rowIndex);
    var newData = {
        ActionId: prevData.ActionId,
        IsInsertRow: false
        ,Process_Event: $('#dvProcess_Event').find('select').val()

    }

    Spartan_BR_Event_Restrictions_DetailTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_BR_Event_Restrictions_DetailrowCreationGrid(data, newData, rowIndex);
    $('#AddSpartan_BR_Event_Restrictions_Detail-form').modal({ show: false });
    $('#AddSpartan_BR_Event_Restrictions_Detail-form').modal('hide');
}
function Spartan_BR_Event_Restrictions_DetailRemoveAddRow(rowIndex) {
    Spartan_BR_Event_Restrictions_DetailTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Spartan_BR_Event_Restrictions_Detail MultiRow


$(function () {
    function Spartan_BR_Action_Configuration_DetailinitializeMainArray(totalCount) {
        if (Spartan_BR_Action_Configuration_DetailDataMain.length != totalCount && !Spartan_BR_Action_Configuration_DetailDataMainInitialized) {
            Spartan_BR_Action_Configuration_DetailDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Spartan_BR_Action_Configuration_DetailDataMain[i] = null;
            }
        }
    }
    function Spartan_BR_Action_Configuration_DetailremoveFromMainArray() {
        for (var j = 0; j < Spartan_BR_Action_Configuration_DetaildeletedItem.length; j++) {
            for (var i = 0; i < Spartan_BR_Action_Configuration_DetailDataMain.length; i++) {
                if (Spartan_BR_Action_Configuration_DetailDataMain[i] != null && Spartan_BR_Action_Configuration_DetailDataMain[i].Id == Spartan_BR_Action_Configuration_DetaildeletedItem[j]) {
                    hSpartan_BR_Action_Configuration_DetailDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Spartan_BR_Action_Configuration_DetailcopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Spartan_BR_Action_Configuration_DetailDataMain.length; i++) {
            data[i] = Spartan_BR_Action_Configuration_DetailDataMain[i];

        }
        return data;
    }
    function Spartan_BR_Action_Configuration_DetailgetNewResult() {
        var newData = copyMainSpartan_BR_Action_Configuration_DetailArray();

        for (var i = 0; i < Spartan_BR_Action_Configuration_DetailData.length; i++) {
            if (Spartan_BR_Action_Configuration_DetailData[i].Removed == null || Spartan_BR_Action_Configuration_DetailData[i].Removed == false) {
                newData.splice(0, 0, Spartan_BR_Action_Configuration_DetailData[i]);
            }
        }
        return newData;
    }
    function Spartan_BR_Action_Configuration_DetailpushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Spartan_BR_Action_Configuration_DetailDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Spartan_BR_Action_Configuration_DetailDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Spartan_BR_Attribute_Restrictions_DetailinitializeMainArray(totalCount) {
        if (Spartan_BR_Attribute_Restrictions_DetailDataMain.length != totalCount && !Spartan_BR_Attribute_Restrictions_DetailDataMainInitialized) {
            Spartan_BR_Attribute_Restrictions_DetailDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Spartan_BR_Attribute_Restrictions_DetailDataMain[i] = null;
            }
        }
    }
    function Spartan_BR_Attribute_Restrictions_DetailremoveFromMainArray() {
        for (var j = 0; j < Spartan_BR_Attribute_Restrictions_DetaildeletedItem.length; j++) {
            for (var i = 0; i < Spartan_BR_Attribute_Restrictions_DetailDataMain.length; i++) {
                if (Spartan_BR_Attribute_Restrictions_DetailDataMain[i] != null && Spartan_BR_Attribute_Restrictions_DetailDataMain[i].Id == Spartan_BR_Attribute_Restrictions_DetaildeletedItem[j]) {
                    hSpartan_BR_Attribute_Restrictions_DetailDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Spartan_BR_Attribute_Restrictions_DetailcopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Spartan_BR_Attribute_Restrictions_DetailDataMain.length; i++) {
            data[i] = Spartan_BR_Attribute_Restrictions_DetailDataMain[i];

        }
        return data;
    }
    function Spartan_BR_Attribute_Restrictions_DetailgetNewResult() {
        var newData = copyMainSpartan_BR_Attribute_Restrictions_DetailArray();

        for (var i = 0; i < Spartan_BR_Attribute_Restrictions_DetailData.length; i++) {
            if (Spartan_BR_Attribute_Restrictions_DetailData[i].Removed == null || Spartan_BR_Attribute_Restrictions_DetailData[i].Removed == false) {
                newData.splice(0, 0, Spartan_BR_Attribute_Restrictions_DetailData[i]);
            }
        }
        return newData;
    }
    function Spartan_BR_Attribute_Restrictions_DetailpushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Spartan_BR_Attribute_Restrictions_DetailDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Spartan_BR_Attribute_Restrictions_DetailDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Spartan_BR_Operation_Restrictions_DetailinitializeMainArray(totalCount) {
        if (Spartan_BR_Operation_Restrictions_DetailDataMain.length != totalCount && !Spartan_BR_Operation_Restrictions_DetailDataMainInitialized) {
            Spartan_BR_Operation_Restrictions_DetailDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Spartan_BR_Operation_Restrictions_DetailDataMain[i] = null;
            }
        }
    }
    function Spartan_BR_Operation_Restrictions_DetailremoveFromMainArray() {
        for (var j = 0; j < Spartan_BR_Operation_Restrictions_DetaildeletedItem.length; j++) {
            for (var i = 0; i < Spartan_BR_Operation_Restrictions_DetailDataMain.length; i++) {
                if (Spartan_BR_Operation_Restrictions_DetailDataMain[i] != null && Spartan_BR_Operation_Restrictions_DetailDataMain[i].Id == Spartan_BR_Operation_Restrictions_DetaildeletedItem[j]) {
                    hSpartan_BR_Operation_Restrictions_DetailDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Spartan_BR_Operation_Restrictions_DetailcopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Spartan_BR_Operation_Restrictions_DetailDataMain.length; i++) {
            data[i] = Spartan_BR_Operation_Restrictions_DetailDataMain[i];

        }
        return data;
    }
    function Spartan_BR_Operation_Restrictions_DetailgetNewResult() {
        var newData = copyMainSpartan_BR_Operation_Restrictions_DetailArray();

        for (var i = 0; i < Spartan_BR_Operation_Restrictions_DetailData.length; i++) {
            if (Spartan_BR_Operation_Restrictions_DetailData[i].Removed == null || Spartan_BR_Operation_Restrictions_DetailData[i].Removed == false) {
                newData.splice(0, 0, Spartan_BR_Operation_Restrictions_DetailData[i]);
            }
        }
        return newData;
    }
    function Spartan_BR_Operation_Restrictions_DetailpushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Spartan_BR_Operation_Restrictions_DetailDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Spartan_BR_Operation_Restrictions_DetailDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Spartan_BR_Event_Restrictions_DetailinitializeMainArray(totalCount) {
        if (Spartan_BR_Event_Restrictions_DetailDataMain.length != totalCount && !Spartan_BR_Event_Restrictions_DetailDataMainInitialized) {
            Spartan_BR_Event_Restrictions_DetailDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Spartan_BR_Event_Restrictions_DetailDataMain[i] = null;
            }
        }
    }
    function Spartan_BR_Event_Restrictions_DetailremoveFromMainArray() {
        for (var j = 0; j < Spartan_BR_Event_Restrictions_DetaildeletedItem.length; j++) {
            for (var i = 0; i < Spartan_BR_Event_Restrictions_DetailDataMain.length; i++) {
                if (Spartan_BR_Event_Restrictions_DetailDataMain[i] != null && Spartan_BR_Event_Restrictions_DetailDataMain[i].Id == Spartan_BR_Event_Restrictions_DetaildeletedItem[j]) {
                    hSpartan_BR_Event_Restrictions_DetailDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Spartan_BR_Event_Restrictions_DetailcopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Spartan_BR_Event_Restrictions_DetailDataMain.length; i++) {
            data[i] = Spartan_BR_Event_Restrictions_DetailDataMain[i];

        }
        return data;
    }
    function Spartan_BR_Event_Restrictions_DetailgetNewResult() {
        var newData = copyMainSpartan_BR_Event_Restrictions_DetailArray();

        for (var i = 0; i < Spartan_BR_Event_Restrictions_DetailData.length; i++) {
            if (Spartan_BR_Event_Restrictions_DetailData[i].Removed == null || Spartan_BR_Event_Restrictions_DetailData[i].Removed == false) {
                newData.splice(0, 0, Spartan_BR_Event_Restrictions_DetailData[i]);
            }
        }
        return newData;
    }
    function Spartan_BR_Event_Restrictions_DetailpushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Spartan_BR_Event_Restrictions_DetailDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Spartan_BR_Event_Restrictions_DetailDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }

});

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
    $("#ReferenceActionId").val("0");
    $('#CreateSpartan_BR_Action')[0].reset();
    ClearFormControls();
    $("#ActionIdId").val("0");
                Spartan_BR_Action_Configuration_DetailClearGridData();
                Spartan_BR_Attribute_Restrictions_DetailClearGridData();
                Spartan_BR_Operation_Restrictions_DetailClearGridData();
                Spartan_BR_Event_Restrictions_DetailClearGridData();

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreateSpartan_BR_Action').trigger('reset');
    $('#CreateSpartan_BR_Action').find(':input').each(function () {
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
    var $myForm = $('#CreateSpartan_BR_Action');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    if (Spartan_BR_Action_Configuration_DetailcountRowsChecked > 0)
    {
		showNotification('Ha dejado un renglón pendiente de guardar en Configuration', "warning");						
        return false;
    }
    if (Spartan_BR_Attribute_Restrictions_DetailcountRowsChecked > 0)
    {
		showNotification('Ha dejado un renglón pendiente de guardar en Attribute Restrictions', "warning");						
        return false;
    }
    if (Spartan_BR_Operation_Restrictions_DetailcountRowsChecked > 0)
    {
		showNotification('Ha dejado un renglón pendiente de guardar en Operation Restrictions', "warning");				
        return false;
    }
    if (Spartan_BR_Event_Restrictions_DetailcountRowsChecked > 0)
    {
		showNotification('Ha dejado un renglón pendiente de guardar en Process Event Restrictions', "warning");		
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblActionId").text("0");
}
$(document).ready(function () {
    $("form#CreateSpartan_BR_Action").submit(function (e) {
        e.preventDefault();
        return false;
    });
    $("#Cancelar").click(function () {
        BackToGrid();
    });
    $("#Guardar").click(function () {
        if (CheckValidation())
            SendSpartan_BR_ActionData(function () {
                BackToGrid();
            });
    });
    $("#GuardarYNuevo").click(function () {
        if (CheckValidation()) {
            SendSpartan_BR_ActionData(function () {
                ClearControls();
                ClearAttachmentsDiv();
                ResetClaveLabel();
                getSpartan_BR_Action_Configuration_DetailData();
                getSpartan_BR_Attribute_Restrictions_DetailData();
                getSpartan_BR_Operation_Restrictions_DetailData();
                getSpartan_BR_Event_Restrictions_DetailData();

            });
        }
    });
    $("#GuardarYCopia").click(function () {
        if (CheckValidation())
            SendSpartan_BR_ActionData(function (currentId) {
                $("#ActionIdId").val("0");
                Spartan_BR_Action_Configuration_DetailClearGridData();
                Spartan_BR_Attribute_Restrictions_DetailClearGridData();
                Spartan_BR_Operation_Restrictions_DetailClearGridData();
                Spartan_BR_Event_Restrictions_DetailClearGridData();

                ResetClaveLabel();
                $("#ReferenceActionId").val(currentId);
                getSpartan_BR_Action_Configuration_DetailData();
                getSpartan_BR_Attribute_Restrictions_DetailData();
                getSpartan_BR_Operation_Restrictions_DetailData();
                getSpartan_BR_Event_Restrictions_DetailData();

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
        $('#CreateSpartan_BR_Action').find('.col-sm-8').each(function () {
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
