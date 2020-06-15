

//Begin Declarations for Foreigns fields for Spartan_WorkFlow_Phases MultiRow
var Spartan_WorkFlow_PhasescountRowsChecked = 0;
function GetSpartan_WorkFlow_Phases_Spartan_WorkFlow_Phase_TypeName(Id) {
    for (var i = 0; i < Spartan_WorkFlow_Phases_Spartan_WorkFlow_Phase_TypeItems.length; i++) {
        if (Spartan_WorkFlow_Phases_Spartan_WorkFlow_Phase_TypeItems[i].Phase_TypeId == Id) {
            return Spartan_WorkFlow_Phases_Spartan_WorkFlow_Phase_TypeItems[i].Description;
        }
    }
    return "";
}

function GetSpartan_WorkFlow_Phases_Spartan_WorkFlow_Phase_TypeDropDown() {
    var Spartan_WorkFlow_Phases_Spartan_WorkFlow_Phase_TypeDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_WorkFlow_Phases_Spartan_WorkFlow_Phase_TypeDropdown);
    if(Spartan_WorkFlow_Phases_Spartan_WorkFlow_Phase_TypeItems != null)
    {
       for (var i = 0; i < Spartan_WorkFlow_Phases_Spartan_WorkFlow_Phase_TypeItems.length; i++) {
           $('<option />', { value: Spartan_WorkFlow_Phases_Spartan_WorkFlow_Phase_TypeItems[i].Phase_TypeId, text:    Spartan_WorkFlow_Phases_Spartan_WorkFlow_Phase_TypeItems[i].Description }).appendTo(Spartan_WorkFlow_Phases_Spartan_WorkFlow_Phase_TypeDropdown);
       }
    }
    return Spartan_WorkFlow_Phases_Spartan_WorkFlow_Phase_TypeDropdown;
}
function GetSpartan_WorkFlow_Phases_Spartan_WorkFlow_Type_Work_DistributionName(Id) {
    for (var i = 0; i < Spartan_WorkFlow_Phases_Spartan_WorkFlow_Type_Work_DistributionItems.length; i++) {
        if (Spartan_WorkFlow_Phases_Spartan_WorkFlow_Type_Work_DistributionItems[i].Type_of_Work_DistributionId == Id) {
            return Spartan_WorkFlow_Phases_Spartan_WorkFlow_Type_Work_DistributionItems[i].Description;
        }
    }
    return "";
}

function GetSpartan_WorkFlow_Phases_Spartan_WorkFlow_Type_Work_DistributionDropDown() {
    var Spartan_WorkFlow_Phases_Spartan_WorkFlow_Type_Work_DistributionDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_WorkFlow_Phases_Spartan_WorkFlow_Type_Work_DistributionDropdown);
    if(Spartan_WorkFlow_Phases_Spartan_WorkFlow_Type_Work_DistributionItems != null)
    {
       for (var i = 0; i < Spartan_WorkFlow_Phases_Spartan_WorkFlow_Type_Work_DistributionItems.length; i++) {
           $('<option />', { value: Spartan_WorkFlow_Phases_Spartan_WorkFlow_Type_Work_DistributionItems[i].Type_of_Work_DistributionId, text:    Spartan_WorkFlow_Phases_Spartan_WorkFlow_Type_Work_DistributionItems[i].Description }).appendTo(Spartan_WorkFlow_Phases_Spartan_WorkFlow_Type_Work_DistributionDropdown);
       }
    }
    return Spartan_WorkFlow_Phases_Spartan_WorkFlow_Type_Work_DistributionDropdown;
}
function GetSpartan_WorkFlow_Phases_Spartan_WorkFlow_Type_Flow_ControlName(Id) {
    for (var i = 0; i < Spartan_WorkFlow_Phases_Spartan_WorkFlow_Type_Flow_ControlItems.length; i++) {
        if (Spartan_WorkFlow_Phases_Spartan_WorkFlow_Type_Flow_ControlItems[i].Type_Flow_ControlId == Id) {
            return Spartan_WorkFlow_Phases_Spartan_WorkFlow_Type_Flow_ControlItems[i].Description;
        }
    }
    return "";
}

function GetSpartan_WorkFlow_Phases_Spartan_WorkFlow_Type_Flow_ControlDropDown() {
    var Spartan_WorkFlow_Phases_Spartan_WorkFlow_Type_Flow_ControlDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_WorkFlow_Phases_Spartan_WorkFlow_Type_Flow_ControlDropdown);
    if(Spartan_WorkFlow_Phases_Spartan_WorkFlow_Type_Flow_ControlItems != null)
    {
       for (var i = 0; i < Spartan_WorkFlow_Phases_Spartan_WorkFlow_Type_Flow_ControlItems.length; i++) {
           $('<option />', { value: Spartan_WorkFlow_Phases_Spartan_WorkFlow_Type_Flow_ControlItems[i].Type_Flow_ControlId, text:    Spartan_WorkFlow_Phases_Spartan_WorkFlow_Type_Flow_ControlItems[i].Description }).appendTo(Spartan_WorkFlow_Phases_Spartan_WorkFlow_Type_Flow_ControlDropdown);
       }
    }
    return Spartan_WorkFlow_Phases_Spartan_WorkFlow_Type_Flow_ControlDropdown;
}
function GetSpartan_WorkFlow_Phases_Spartan_WorkFlow_Phase_StatusName(Id) {
    for (var i = 0; i < Spartan_WorkFlow_Phases_Spartan_WorkFlow_Phase_StatusItems.length; i++) {
        if (Spartan_WorkFlow_Phases_Spartan_WorkFlow_Phase_StatusItems[i].StatusId == Id) {
            return Spartan_WorkFlow_Phases_Spartan_WorkFlow_Phase_StatusItems[i].Description;
        }
    }
    return "";
}

function GetSpartan_WorkFlow_Phases_Spartan_WorkFlow_Phase_StatusDropDown() {
    var Spartan_WorkFlow_Phases_Spartan_WorkFlow_Phase_StatusDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_WorkFlow_Phases_Spartan_WorkFlow_Phase_StatusDropdown);
    if(Spartan_WorkFlow_Phases_Spartan_WorkFlow_Phase_StatusItems != null)
    {
       for (var i = 0; i < Spartan_WorkFlow_Phases_Spartan_WorkFlow_Phase_StatusItems.length; i++) {
           $('<option />', { value: Spartan_WorkFlow_Phases_Spartan_WorkFlow_Phase_StatusItems[i].StatusId, text:    Spartan_WorkFlow_Phases_Spartan_WorkFlow_Phase_StatusItems[i].Description }).appendTo(Spartan_WorkFlow_Phases_Spartan_WorkFlow_Phase_StatusDropdown);
       }
    }
    return Spartan_WorkFlow_Phases_Spartan_WorkFlow_Phase_StatusDropdown;
}


function GetInsertSpartan_WorkFlow_PhasesRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Spartan_WorkFlow_Phases_Phase_Number Phase_Number').attr('id', 'Spartan_WorkFlow_Phases_Phase_Number_' + index).attr('data-field', 'Phase_Number');
    columnData[1] = $($.parseHTML(inputData)).addClass('Spartan_WorkFlow_Phases_Name Name').attr('id', 'Spartan_WorkFlow_Phases_Name_' + index).attr('data-field', 'Name');
    columnData[2] = $(GetSpartan_WorkFlow_Phases_Spartan_WorkFlow_Phase_TypeDropDown()).addClass('Spartan_WorkFlow_Phases_Phase_Type Phase_Type').attr('id', 'Spartan_WorkFlow_Phases_Phase_Type_' + index).attr('data-field', 'Phase_Type');
    columnData[3] = $(GetSpartan_WorkFlow_Phases_Spartan_WorkFlow_Type_Work_DistributionDropDown()).addClass('Spartan_WorkFlow_Phases_Type_of_Work_Distribution Type_of_Work_Distribution').attr('id', 'Spartan_WorkFlow_Phases_Type_of_Work_Distribution_' + index).attr('data-field', 'Type_of_Work_Distribution');
    columnData[4] = $(GetSpartan_WorkFlow_Phases_Spartan_WorkFlow_Type_Flow_ControlDropDown()).addClass('Spartan_WorkFlow_Phases_Type_Flow_Control Type_Flow_Control').attr('id', 'Spartan_WorkFlow_Phases_Type_Flow_Control_' + index).attr('data-field', 'Type_Flow_Control');
    columnData[5] = $(GetSpartan_WorkFlow_Phases_Spartan_WorkFlow_Phase_StatusDropDown()).addClass('Spartan_WorkFlow_Phases_Phase_Status Phase_Status').attr('id', 'Spartan_WorkFlow_Phases_Phase_Status_' + index).attr('data-field', 'Phase_Status');


    initiateUIControls();
    return columnData;
}

function Spartan_WorkFlow_PhasesInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRSpartan_WorkFlow_Phases("Spartan_WorkFlow_Phases_", "_" + rowIndex)) {
    var nameOfGrid = 'Spartan_WorkFlow_Phases';
    var prevData = Spartan_WorkFlow_PhasesTable.fnGetData(rowIndex);
    var data = Spartan_WorkFlow_PhasesTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        PhasesId: prevData.PhasesId,
        IsInsertRow: false
        ,Phase_Number: ($('#' + nameOfGrid + 'Grid .Phase_NumberHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Name: ($('#' + nameOfGrid + 'Grid .NameHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Phase_Type: ($('#' + nameOfGrid + 'Grid .Phase_TypeHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Type_of_Work_Distribution: ($('#' + nameOfGrid + 'Grid .Type_of_Work_DistributionHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Type_Flow_Control: ($('#' + nameOfGrid + 'Grid .Type_Flow_ControlHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Phase_Status: ($('#' + nameOfGrid + 'Grid .Phase_StatusHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''

    }
    Spartan_WorkFlow_PhasesTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_WorkFlow_PhasesrowCreationGrid(data, newData, rowIndex);
    Spartan_WorkFlow_PhasescountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRSpartan_WorkFlow_Phases("Spartan_WorkFlow_Phases_", "_" + rowIndex);
  }
}

function Spartan_WorkFlow_PhasesCancelRow(rowIndex) {
    var prevData = Spartan_WorkFlow_PhasesTable.fnGetData(rowIndex);
    var data = Spartan_WorkFlow_PhasesTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Spartan_WorkFlow_PhasesTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Spartan_WorkFlow_PhasesrowCreationGrid(data, prevData, rowIndex);
    }
	showSpartan_WorkFlow_PhasesGrid(Spartan_WorkFlow_PhasesTable.fnGetData());
    Spartan_WorkFlow_PhasescountRowsChecked--;
}

function GetSpartan_WorkFlow_PhasesFromDataTable() {
    var Spartan_WorkFlow_PhasesData = [];
    var gridData = Spartan_WorkFlow_PhasesTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Spartan_WorkFlow_PhasesData.push({
                PhasesId: gridData[i].PhasesId
                ,Phase_Number: gridData[i].Phase_Number
                ,Name: gridData[i].Name
                ,Phase_Type: gridData[i].Phase_Type
                ,Type_of_Work_Distribution: gridData[i].Type_of_Work_Distribution
                ,Type_Flow_Control: gridData[i].Type_Flow_Control
                ,Phase_Status: gridData[i].Phase_Status

                ,Removed: false
            });
    }

    for (i = 0; i < removedSpartan_WorkFlow_PhasesData.length; i++) {
        if (removedSpartan_WorkFlow_PhasesData[i] != null && removedSpartan_WorkFlow_PhasesData[i].PhasesId > 0)
            Spartan_WorkFlow_PhasesData.push({
                PhasesId: removedSpartan_WorkFlow_PhasesData[i].PhasesId
                ,Phase_Number: removedSpartan_WorkFlow_PhasesData[i].Phase_Number
                ,Name: removedSpartan_WorkFlow_PhasesData[i].Name
                ,Phase_Type: removedSpartan_WorkFlow_PhasesData[i].Phase_Type
                ,Type_of_Work_Distribution: removedSpartan_WorkFlow_PhasesData[i].Type_of_Work_Distribution
                ,Type_Flow_Control: removedSpartan_WorkFlow_PhasesData[i].Type_Flow_Control
                ,Phase_Status: removedSpartan_WorkFlow_PhasesData[i].Phase_Status

                , Removed: true
            });
    }	

    return Spartan_WorkFlow_PhasesData;
}

function Spartan_WorkFlow_PhasesEditRow(rowIndex, currentRow) {
    var rowIndexTable = (currentRow) ? Spartan_WorkFlow_PhasesTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Spartan_WorkFlow_PhasescountRowsChecked++;
    var Spartan_WorkFlow_PhasesRowElement = "Spartan_WorkFlow_Phases_" + rowIndex.toString();
    var prevData = Spartan_WorkFlow_PhasesTable.fnGetData(rowIndexTable );
    var row = Spartan_WorkFlow_PhasesTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Spartan_WorkFlow_Phases_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Spartan_WorkFlow_PhasesGetUpdateRowControls(prevData, "Spartan_WorkFlow_Phases_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Spartan_WorkFlow_PhasesRowElement + "')){ Spartan_WorkFlow_PhasesInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Spartan_WorkFlow_PhasesCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
        if ($('#Spartan_WorkFlow_PhasesGrid .' + idHeader).css('display') != 'none') {
            $(controls[i]).appendTo($('<td id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));
        }
    }
    $('.Spartan_WorkFlow_Phases' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    initiateUIControls();
    EjecutarValidacionesNewRowMRSpartan_WorkFlow_Phases(nameOfTable, rowIndexFormed);
	EjecutarValidacionesEditRowMRSpartan_WorkFlow_Phases(nameOfTable, rowIndexFormed);
}

function Spartan_WorkFlow_PhasesfnOpenAddRowPopUp() {
    var currentRowIndex = Spartan_WorkFlow_PhasesTable.fnGetData().length;
    Spartan_WorkFlow_PhasesfnClickAddRow();
    GetAddSpartan_WorkFlow_PhasesPopup(currentRowIndex, 0);
}

function Spartan_WorkFlow_PhasesEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Spartan_WorkFlow_PhasesTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Spartan_WorkFlow_PhasesRowElement = "Spartan_WorkFlow_Phases_" + rowIndex.toString();
    var prevData = Spartan_WorkFlow_PhasesTable.fnGetData(rowIndexTable);
    GetAddSpartan_WorkFlow_PhasesPopup(rowIndex, 1, prevData.PhasesId);
    $('#Spartan_WorkFlow_PhasesPhase_Number').val(prevData.Phase_Number);
    $('#Spartan_WorkFlow_PhasesName').val(prevData.Name);
    $('#Spartan_WorkFlow_PhasesPhase_Type').val(prevData.Phase_Type);
    $('#Spartan_WorkFlow_PhasesType_of_Work_Distribution').val(prevData.Type_of_Work_Distribution);
    $('#Spartan_WorkFlow_PhasesType_Flow_Control').val(prevData.Type_Flow_Control);
    $('#Spartan_WorkFlow_PhasesPhase_Status').val(prevData.Phase_Status);

    initiateUIControls();

}

function Spartan_WorkFlow_PhasesAddInsertRow() {
    if (Spartan_WorkFlow_PhasesinsertRowCurrentIndex < 1)
    {
        Spartan_WorkFlow_PhasesinsertRowCurrentIndex = 1;
    }
    return {
        PhasesId: null,
        IsInsertRow: true
        ,Phase_Number: ""
        ,Name: ""
        ,Phase_Type: ""
        ,Type_of_Work_Distribution: ""
        ,Type_Flow_Control: ""
        ,Phase_Status: ""

    }
}

function Spartan_WorkFlow_PhasesfnClickAddRow() {
    Spartan_WorkFlow_PhasescountRowsChecked++;
    Spartan_WorkFlow_PhasesTable.fnAddData(Spartan_WorkFlow_PhasesAddInsertRow(), true);
    Spartan_WorkFlow_PhasesTable.fnPageChange('last');
    initiateUIControls();
    EjecutarValidacionesNewRowMRSpartan_WorkFlow_Phases("Spartan_WorkFlow_Phases_", "_" + Spartan_WorkFlow_PhasesinsertRowCurrentIndex);
}

function Spartan_WorkFlow_PhasesClearGridData() {
    Spartan_WorkFlow_PhasesData = [];
    Spartan_WorkFlow_PhasesdeletedItem = [];
    Spartan_WorkFlow_PhasesDataMain = [];
    Spartan_WorkFlow_PhasesDataMainPages = [];
    Spartan_WorkFlow_PhasesnewItemCount = 0;
    Spartan_WorkFlow_PhasesmaxItemIndex = 0;
    $("#Spartan_WorkFlow_PhasesGrid").DataTable().clear();
    $("#Spartan_WorkFlow_PhasesGrid").DataTable().destroy();
}

//Used to Get Spartan WorkFlow Information
function GetSpartan_WorkFlow_Phases() {
    var form_data = new FormData();
    for (var i = 0; i < Spartan_WorkFlow_PhasesData.length; i++) {
        form_data.append('[' + i + '].PhasesId', Spartan_WorkFlow_PhasesData[i].PhasesId);
        form_data.append('[' + i + '].Phase_Number', Spartan_WorkFlow_PhasesData[i].Phase_Number);
        form_data.append('[' + i + '].Name', Spartan_WorkFlow_PhasesData[i].Name);
        form_data.append('[' + i + '].Phase_Type', Spartan_WorkFlow_PhasesData[i].Phase_Type);
        form_data.append('[' + i + '].Type_of_Work_Distribution', Spartan_WorkFlow_PhasesData[i].Type_of_Work_Distribution);
        form_data.append('[' + i + '].Type_Flow_Control', Spartan_WorkFlow_PhasesData[i].Type_Flow_Control);
        form_data.append('[' + i + '].Phase_Status', Spartan_WorkFlow_PhasesData[i].Phase_Status);

        form_data.append('[' + i + '].Removed', Spartan_WorkFlow_PhasesData[i].Removed);
    }
    return form_data;
}
function Spartan_WorkFlow_PhasesInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRSpartan_WorkFlow_Phases("Spartan_WorkFlow_PhasesTable", rowIndex)) {
    var prevData = Spartan_WorkFlow_PhasesTable.fnGetData(rowIndex);
    var data = Spartan_WorkFlow_PhasesTable.fnGetNodes(rowIndex);
    var newData = {
        PhasesId: prevData.PhasesId,
        IsInsertRow: false
        ,Phase_Number: $('#Spartan_WorkFlow_PhasesPhase_Number').val()

        ,Name: $('#Spartan_WorkFlow_PhasesName').val()
        ,Phase_Type: $('#Spartan_WorkFlow_PhasesPhase_Type').val()
        ,Type_of_Work_Distribution: $('#Spartan_WorkFlow_PhasesType_of_Work_Distribution').val()
        ,Type_Flow_Control: $('#Spartan_WorkFlow_PhasesType_Flow_Control').val()
        ,Phase_Status: $('#Spartan_WorkFlow_PhasesPhase_Status').val()

    }

    Spartan_WorkFlow_PhasesTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_WorkFlow_PhasesrowCreationGrid(data, newData, rowIndex);
    $('#AddSpartan_WorkFlow_Phases-form').modal({ show: false });
    $('#AddSpartan_WorkFlow_Phases-form').modal('hide');
    Spartan_WorkFlow_PhasesEditRow(rowIndex);
    Spartan_WorkFlow_PhasesInsertRow(rowIndex);
    //}
}
function Spartan_WorkFlow_PhasesRemoveAddRow(rowIndex) {
    Spartan_WorkFlow_PhasesTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Spartan_WorkFlow_Phases MultiRow
//Begin Declarations for Foreigns fields for Spartan_WorkFlow_State MultiRow
var Spartan_WorkFlow_StatecountRowsChecked = 0;
function GetSpartan_WorkFlow_State_Spartan_WorkFlow_PhasesName(Id) {
    for (var i = 0; i < Spartan_WorkFlow_State_Spartan_WorkFlow_PhasesItems.length; i++) {
        if (Spartan_WorkFlow_State_Spartan_WorkFlow_PhasesItems[i].PhasesId == Id) {
            return Spartan_WorkFlow_State_Spartan_WorkFlow_PhasesItems[i].Name;
        }
    }
    return "";
}

function GetSpartan_WorkFlow_State_Spartan_WorkFlow_PhasesDropDown() {
    var Spartan_WorkFlow_State_Spartan_WorkFlow_PhasesDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_WorkFlow_State_Spartan_WorkFlow_PhasesDropdown);
    if(Spartan_WorkFlow_State_Spartan_WorkFlow_PhasesItems != null)
    {
       for (var i = 0; i < Spartan_WorkFlow_State_Spartan_WorkFlow_PhasesItems.length; i++) {
           $('<option />', { value: Spartan_WorkFlow_State_Spartan_WorkFlow_PhasesItems[i].PhasesId, text:    Spartan_WorkFlow_State_Spartan_WorkFlow_PhasesItems[i].Name }).appendTo(Spartan_WorkFlow_State_Spartan_WorkFlow_PhasesDropdown);
       }
    }
    return Spartan_WorkFlow_State_Spartan_WorkFlow_PhasesDropdown;
}
function GetSpartan_WorkFlow_State_Spartan_MetadataName(Id) {
    for (var i = 0; i < Spartan_WorkFlow_State_Spartan_MetadataItems.length; i++) {
        if (Spartan_WorkFlow_State_Spartan_MetadataItems[i].AttributeId == Id) {
            return Spartan_WorkFlow_State_Spartan_MetadataItems[i].Logical_Name;
        }
    }
    return "";
}

function GetSpartan_WorkFlow_State_Spartan_MetadataDropDown() {
    var Spartan_WorkFlow_State_Spartan_MetadataDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_WorkFlow_State_Spartan_MetadataDropdown);

    for (var i = 0; i < Spartan_WorkFlow_State_Spartan_MetadataItems.length; i++) {
        $('<option />', { value: Spartan_WorkFlow_State_Spartan_MetadataItems[i].AttributeId, text: Spartan_WorkFlow_State_Spartan_MetadataItems[i].Logical_Name }).appendTo(Spartan_WorkFlow_State_Spartan_MetadataDropdown);
    }
    return Spartan_WorkFlow_State_Spartan_MetadataDropdown;
}


function GetInsertSpartan_WorkFlow_StateRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $(GetSpartan_WorkFlow_State_Spartan_WorkFlow_PhasesDropDown()).addClass('Spartan_WorkFlow_State_Phase Phase').attr('id', 'Spartan_WorkFlow_State_Phase_' + index).attr('data-field', 'Phase');
    columnData[1] = $($.parseHTML(GetGridAutoComplete(null,'AutoCompleteSpartan_WorkFlow_State_Attribute'))).addClass('Spartan_WorkFlow_State_Attribute Attribute').attr('id', 'Spartan_WorkFlow_State_Attribute_' + index).attr('data-field', 'Attribute');
    columnData[2] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Spartan_WorkFlow_State_State_Code State_Code').attr('id', 'Spartan_WorkFlow_State_State_Code_' + index).attr('data-field', 'State_Code');
    columnData[3] = $($.parseHTML(inputData)).addClass('Spartan_WorkFlow_State_Name Name').attr('id', 'Spartan_WorkFlow_State_Name_' + index).attr('data-field', 'Name');
    columnData[4] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Spartan_WorkFlow_State_Value Value').attr('id', 'Spartan_WorkFlow_State_Value_' + index).attr('data-field', 'Value');
    columnData[5] = $($.parseHTML(inputData)).addClass('Spartan_WorkFlow_State_Text Text').attr('id', 'Spartan_WorkFlow_State_Text_' + index).attr('data-field', 'Text');


    initiateUIControls();
    return columnData;
}

function Spartan_WorkFlow_StateInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRSpartan_WorkFlow_State("Spartan_WorkFlow_State_", "_" + rowIndex)) {
    var nameOfGrid = 'Spartan_WorkFlow_State';
    var prevData = Spartan_WorkFlow_StateTable.fnGetData(rowIndex);
    var data = Spartan_WorkFlow_StateTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        StateId: prevData.StateId,
        IsInsertRow: false
        ,Phase: ($('#' + nameOfGrid + 'Grid .PhaseHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        , AttributeLogical_Name: ($('#' + nameOfGrid + 'Grid .AttributeHeader').css('display') != 'none') ?  $(data.childNodes[counter].childNodes[0]).find('option:selected').text() : ''
        , Attribute: ($('#' + nameOfGrid + 'Grid .AttributeHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''	
        ,State_Code: ($('#' + nameOfGrid + 'Grid .State_CodeHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Name: ($('#' + nameOfGrid + 'Grid .NameHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Value: ($('#' + nameOfGrid + 'Grid .ValueHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Text: ($('#' + nameOfGrid + 'Grid .TextHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''

    }
    Spartan_WorkFlow_StateTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_WorkFlow_StaterowCreationGrid(data, newData, rowIndex);
    Spartan_WorkFlow_StatecountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRSpartan_WorkFlow_State("Spartan_WorkFlow_State_", "_" + rowIndex);
  }
}

function Spartan_WorkFlow_StateCancelRow(rowIndex) {
    var prevData = Spartan_WorkFlow_StateTable.fnGetData(rowIndex);
    var data = Spartan_WorkFlow_StateTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Spartan_WorkFlow_StateTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Spartan_WorkFlow_StaterowCreationGrid(data, prevData, rowIndex);
    }
	showSpartan_WorkFlow_StateGrid(Spartan_WorkFlow_StateTable.fnGetData());
    Spartan_WorkFlow_StatecountRowsChecked--;
}

function GetSpartan_WorkFlow_StateFromDataTable() {
    var Spartan_WorkFlow_StateData = [];
    var gridData = Spartan_WorkFlow_StateTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Spartan_WorkFlow_StateData.push({
                StateId: gridData[i].StateId
                ,Phase: gridData[i].Phase
                ,Attribute: gridData[i].Attribute
                ,State_Code: gridData[i].State_Code
                ,Name: gridData[i].Name
                ,Value: gridData[i].Value
                ,Text: gridData[i].Text

                ,Removed: false
            });
    }

    for (i = 0; i < removedSpartan_WorkFlow_StateData.length; i++) {
        if (removedSpartan_WorkFlow_StateData[i] != null && removedSpartan_WorkFlow_StateData[i].StateId > 0)
            Spartan_WorkFlow_StateData.push({
                StateId: removedSpartan_WorkFlow_StateData[i].StateId
                ,Phase: removedSpartan_WorkFlow_StateData[i].Phase
                ,Attribute: removedSpartan_WorkFlow_StateData[i].Attribute
                ,State_Code: removedSpartan_WorkFlow_StateData[i].State_Code
                ,Name: removedSpartan_WorkFlow_StateData[i].Name
                ,Value: removedSpartan_WorkFlow_StateData[i].Value
                ,Text: removedSpartan_WorkFlow_StateData[i].Text

                , Removed: true
            });
    }	

    return Spartan_WorkFlow_StateData;
}

function Spartan_WorkFlow_StateEditRow(rowIndex, currentRow) {
    var rowIndexTable = (currentRow) ? Spartan_WorkFlow_StateTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Spartan_WorkFlow_StatecountRowsChecked++;
    var Spartan_WorkFlow_StateRowElement = "Spartan_WorkFlow_State_" + rowIndex.toString();
    var prevData = Spartan_WorkFlow_StateTable.fnGetData(rowIndexTable );
    var row = Spartan_WorkFlow_StateTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Spartan_WorkFlow_State_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Spartan_WorkFlow_StateGetUpdateRowControls(prevData, "Spartan_WorkFlow_State_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Spartan_WorkFlow_StateRowElement + "')){ Spartan_WorkFlow_StateInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Spartan_WorkFlow_StateCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
        if ($('#Spartan_WorkFlow_StateGrid .' + idHeader).css('display') != 'none') {
            $(controls[i]).appendTo($('<td id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));
        }
    }
    $('.Spartan_WorkFlow_State' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    initiateUIControls();
    EjecutarValidacionesNewRowMRSpartan_WorkFlow_State(nameOfTable, rowIndexFormed);
	EjecutarValidacionesEditRowMRSpartan_WorkFlow_State(nameOfTable, rowIndexFormed);
}

function Spartan_WorkFlow_StatefnOpenAddRowPopUp() {
    var currentRowIndex = Spartan_WorkFlow_StateTable.fnGetData().length;
    Spartan_WorkFlow_StatefnClickAddRow();
    GetAddSpartan_WorkFlow_StatePopup(currentRowIndex, 0);
}

function Spartan_WorkFlow_StateEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Spartan_WorkFlow_StateTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Spartan_WorkFlow_StateRowElement = "Spartan_WorkFlow_State_" + rowIndex.toString();
    var prevData = Spartan_WorkFlow_StateTable.fnGetData(rowIndexTable);
    GetAddSpartan_WorkFlow_StatePopup(rowIndex, 1, prevData.StateId);
    $('#Spartan_WorkFlow_StatePhase').val(prevData.Phase);
    $('#dvSpartan_WorkFlow_StateAttribute').html($($.parseHTML(GetGridAutoComplete(prevData.Attribute.label,'AutoCompleteAttribute'))).addClass('Spartan_WorkFlow_State_Attribute'));
    $('#Spartan_WorkFlow_StateState_Code').val(prevData.State_Code);
    $('#Spartan_WorkFlow_StateName').val(prevData.Name);
    $('#Spartan_WorkFlow_StateValue').val(prevData.Value);
    $('#Spartan_WorkFlow_StateText').val(prevData.Text);

    initiateUIControls();

}

function Spartan_WorkFlow_StateAddInsertRow() {
    if (Spartan_WorkFlow_StateinsertRowCurrentIndex < 1)
    {
        Spartan_WorkFlow_StateinsertRowCurrentIndex = 1;
    }
    return {
        StateId: null,
        IsInsertRow: true
        ,Phase: ""
        ,Attribute: ""
        ,State_Code: ""
        ,Name: ""
        ,Value: ""
        ,Text: ""

    }
}

function Spartan_WorkFlow_StatefnClickAddRow() {
    Spartan_WorkFlow_StatecountRowsChecked++;
    Spartan_WorkFlow_StateTable.fnAddData(Spartan_WorkFlow_StateAddInsertRow(), true);
    Spartan_WorkFlow_StateTable.fnPageChange('last');
    initiateUIControls();
    EjecutarValidacionesNewRowMRSpartan_WorkFlow_State("Spartan_WorkFlow_State_", "_" + Spartan_WorkFlow_StateinsertRowCurrentIndex);
}

function Spartan_WorkFlow_StateClearGridData() {
    Spartan_WorkFlow_StateData = [];
    Spartan_WorkFlow_StatedeletedItem = [];
    Spartan_WorkFlow_StateDataMain = [];
    Spartan_WorkFlow_StateDataMainPages = [];
    Spartan_WorkFlow_StatenewItemCount = 0;
    Spartan_WorkFlow_StatemaxItemIndex = 0;
    $("#Spartan_WorkFlow_StateGrid").DataTable().clear();
    $("#Spartan_WorkFlow_StateGrid").DataTable().destroy();
}

//Used to Get Spartan WorkFlow Information
function GetSpartan_WorkFlow_State() {
    var form_data = new FormData();
    for (var i = 0; i < Spartan_WorkFlow_StateData.length; i++) {
        form_data.append('[' + i + '].StateId', Spartan_WorkFlow_StateData[i].StateId);
        form_data.append('[' + i + '].Phase', Spartan_WorkFlow_StateData[i].Phase);
        form_data.append('[' + i + '].Attribute', Spartan_WorkFlow_StateData[i].Attribute);
        form_data.append('[' + i + '].State_Code', Spartan_WorkFlow_StateData[i].State_Code);
        form_data.append('[' + i + '].Name', Spartan_WorkFlow_StateData[i].Name);
        form_data.append('[' + i + '].Value', Spartan_WorkFlow_StateData[i].Value);
        form_data.append('[' + i + '].Text', Spartan_WorkFlow_StateData[i].Text);

        form_data.append('[' + i + '].Removed', Spartan_WorkFlow_StateData[i].Removed);
    }
    return form_data;
}
function Spartan_WorkFlow_StateInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRSpartan_WorkFlow_State("Spartan_WorkFlow_StateTable", rowIndex)) {
    var prevData = Spartan_WorkFlow_StateTable.fnGetData(rowIndex);
    var data = Spartan_WorkFlow_StateTable.fnGetNodes(rowIndex);
    var newData = {
        StateId: prevData.StateId,
        IsInsertRow: false
        ,Phase: $('#Spartan_WorkFlow_StatePhase').val()
        ,Attribute: $('#Spartan_WorkFlow_StateAttribute').val()
        ,State_Code: $('#Spartan_WorkFlow_StateState_Code').val()

        ,Name: $('#Spartan_WorkFlow_StateName').val()
        ,Value: $('#Spartan_WorkFlow_StateValue').val()

        ,Text: $('#Spartan_WorkFlow_StateText').val()

    }

    Spartan_WorkFlow_StateTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_WorkFlow_StaterowCreationGrid(data, newData, rowIndex);
    $('#AddSpartan_WorkFlow_State-form').modal({ show: false });
    $('#AddSpartan_WorkFlow_State-form').modal('hide');
    Spartan_WorkFlow_StateEditRow(rowIndex);
    Spartan_WorkFlow_StateInsertRow(rowIndex);
    //}
}
function Spartan_WorkFlow_StateRemoveAddRow(rowIndex) {
    Spartan_WorkFlow_StateTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Spartan_WorkFlow_State MultiRow
//Begin Declarations for Foreigns fields for Spartan_WorkFlow_Conditions_by_State MultiRow
var Spartan_WorkFlow_Conditions_by_StatecountRowsChecked = 0;
function GetSpartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_PhasesName(Id) {
    for (var i = 0; i < Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_PhasesItems.length; i++) {
        if (Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_PhasesItems[i].PhasesId == Id) {
            return Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_PhasesItems[i].Name;
        }
    }
    return "";
}

function GetSpartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_PhasesDropDown() {
    var Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_PhasesDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_PhasesDropdown);
    if(Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_PhasesItems != null)
    {
       for (var i = 0; i < Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_PhasesItems.length; i++) {
           $('<option />', { value: Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_PhasesItems[i].PhasesId, text:    Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_PhasesItems[i].Name }).appendTo(Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_PhasesDropdown);
       }
    }
    return Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_PhasesDropdown;
}
function GetSpartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_StateName(Id) {
    for (var i = 0; i < Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_StateItems.length; i++) {
        if (Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_StateItems[i].StateId == Id) {
            return Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_StateItems[i].Name;
        }
    }
    return "";
}

function GetSpartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_StateDropDown() {
    var Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_StateDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_StateDropdown);
    if(Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_StateItems != null)
    {
       for (var i = 0; i < Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_StateItems.length; i++) {
           $('<option />', { value: Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_StateItems[i].StateId, text:    Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_StateItems[i].Name }).appendTo(Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_StateDropdown);
       }
    }
    return Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_StateDropdown;
}
function GetSpartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_Condition_OperatorName(Id) {
    for (var i = 0; i < Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_Condition_OperatorItems.length; i++) {
        if (Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_Condition_OperatorItems[i].Condition_OperatorId == Id) {
            return Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_Condition_OperatorItems[i].Description;
        }
    }
    return "";
}

function GetSpartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_Condition_OperatorDropDown() {
    var Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_Condition_OperatorDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_Condition_OperatorDropdown);
    if(Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_Condition_OperatorItems != null)
    {
       for (var i = 0; i < Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_Condition_OperatorItems.length; i++) {
           $('<option />', { value: Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_Condition_OperatorItems[i].Condition_OperatorId, text:    Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_Condition_OperatorItems[i].Description }).appendTo(Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_Condition_OperatorDropdown);
       }
    }
    return Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_Condition_OperatorDropdown;
}
function GetSpartan_WorkFlow_Conditions_by_State_Spartan_MetadataName(Id) {
    for (var i = 0; i < Spartan_WorkFlow_Conditions_by_State_Spartan_MetadataItems.length; i++) {
        if (Spartan_WorkFlow_Conditions_by_State_Spartan_MetadataItems[i].AttributeId == Id) {
            return Spartan_WorkFlow_Conditions_by_State_Spartan_MetadataItems[i].Logical_Name;
        }
    }
    return "";
}

function GetSpartan_WorkFlow_Conditions_by_State_Spartan_MetadataDropDown() {
    var Spartan_WorkFlow_Conditions_by_State_Spartan_MetadataDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_WorkFlow_Conditions_by_State_Spartan_MetadataDropdown);
    if(Spartan_WorkFlow_Conditions_by_State_Spartan_MetadataItems != null)
    {
       for (var i = 0; i < Spartan_WorkFlow_Conditions_by_State_Spartan_MetadataItems.length; i++) {
           $('<option />', { value: Spartan_WorkFlow_Conditions_by_State_Spartan_MetadataItems[i].AttributeId, text:    Spartan_WorkFlow_Conditions_by_State_Spartan_MetadataItems[i].Logical_Name }).appendTo(Spartan_WorkFlow_Conditions_by_State_Spartan_MetadataDropdown);
       }
    }
    return Spartan_WorkFlow_Conditions_by_State_Spartan_MetadataDropdown;
}
function GetSpartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_ConditionName(Id) {
    for (var i = 0; i < Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_ConditionItems.length; i++) {
        if (Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_ConditionItems[i].ConditionId == Id) {
            return Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_ConditionItems[i].Description;
        }
    }
    return "";
}

function GetSpartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_ConditionDropDown() {
    var Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_ConditionDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_ConditionDropdown);
    if(Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_ConditionItems != null)
    {
       for (var i = 0; i < Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_ConditionItems.length; i++) {
           $('<option />', { value: Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_ConditionItems[i].ConditionId, text:    Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_ConditionItems[i].Description }).appendTo(Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_ConditionDropdown);
       }
    }
    return Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_ConditionDropdown;
}
function GetSpartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_OperatorName(Id) {
    for (var i = 0; i < Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_OperatorItems.length; i++) {
        if (Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_OperatorItems[i].OperatorId == Id) {
            return Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_OperatorItems[i].Description;
        }
    }
    return "";
}

function GetSpartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_OperatorDropDown() {
    var Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_OperatorDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_OperatorDropdown);
    if(Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_OperatorItems != null)
    {
       for (var i = 0; i < Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_OperatorItems.length; i++) {
           $('<option />', { value: Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_OperatorItems[i].OperatorId, text:    Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_OperatorItems[i].Description }).appendTo(Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_OperatorDropdown);
       }
    }
    return Spartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_OperatorDropdown;
}


function GetInsertSpartan_WorkFlow_Conditions_by_StateRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $(GetSpartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_PhasesDropDown()).addClass('Spartan_WorkFlow_Conditions_by_State_Phase Phase').attr('id', 'Spartan_WorkFlow_Conditions_by_State_Phase_' + index).attr('data-field', 'Phase');
    columnData[1] = $(GetSpartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_StateDropDown()).addClass('Spartan_WorkFlow_Conditions_by_State_State State').attr('id', 'Spartan_WorkFlow_Conditions_by_State_State_' + index).attr('data-field', 'State');
    columnData[2] = $(GetSpartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_Condition_OperatorDropDown()).addClass('Spartan_WorkFlow_Conditions_by_State_Condition_Operator Condition_Operator').attr('id', 'Spartan_WorkFlow_Conditions_by_State_Condition_Operator_' + index).attr('data-field', 'Condition_Operator');
    columnData[3] = $(GetSpartan_WorkFlow_Conditions_by_State_Spartan_MetadataDropDown()).addClass('Spartan_WorkFlow_Conditions_by_State_Attribute Attribute').attr('id', 'Spartan_WorkFlow_Conditions_by_State_Attribute_' + index).attr('data-field', 'Attribute');
    columnData[4] = $(GetSpartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_ConditionDropDown()).addClass('Spartan_WorkFlow_Conditions_by_State_Condition Condition').attr('id', 'Spartan_WorkFlow_Conditions_by_State_Condition_' + index).attr('data-field', 'Condition');
    columnData[5] = $(GetSpartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_OperatorDropDown()).addClass('Spartan_WorkFlow_Conditions_by_State_Operator Operator').attr('id', 'Spartan_WorkFlow_Conditions_by_State_Operator_' + index).attr('data-field', 'Operator');
    columnData[6] = $($.parseHTML(inputData)).addClass('Spartan_WorkFlow_Conditions_by_State_Operator_Value Operator_Value').attr('id', 'Spartan_WorkFlow_Conditions_by_State_Operator_Value_' + index).attr('data-field', 'Operator_Value');
    columnData[7] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Spartan_WorkFlow_Conditions_by_State_Priority Priority').attr('id', 'Spartan_WorkFlow_Conditions_by_State_Priority_' + index).attr('data-field', 'Priority');


    initiateUIControls();
    return columnData;
}

function Spartan_WorkFlow_Conditions_by_StateInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRSpartan_WorkFlow_Conditions_by_State("Spartan_WorkFlow_Conditions_by_State_", "_" + rowIndex)) {
    var nameOfGrid = 'Spartan_WorkFlow_Conditions_by_State';
    var prevData = Spartan_WorkFlow_Conditions_by_StateTable.fnGetData(rowIndex);
    var data = Spartan_WorkFlow_Conditions_by_StateTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Conditions_by_StateId: prevData.Conditions_by_StateId,
        IsInsertRow: false
        ,Phase: ($('#' + nameOfGrid + 'Grid .PhaseHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,State: ($('#' + nameOfGrid + 'Grid .StateHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Condition_Operator: ($('#' + nameOfGrid + 'Grid .Condition_OperatorHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Attribute: ($('#' + nameOfGrid + 'Grid .AttributeHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Condition: ($('#' + nameOfGrid + 'Grid .ConditionHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Operator: ($('#' + nameOfGrid + 'Grid .OperatorHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Operator_Value: ($('#' + nameOfGrid + 'Grid .Operator_ValueHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Priority: ($('#' + nameOfGrid + 'Grid .PriorityHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''

    }
    Spartan_WorkFlow_Conditions_by_StateTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_WorkFlow_Conditions_by_StaterowCreationGrid(data, newData, rowIndex);
    Spartan_WorkFlow_Conditions_by_StatecountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRSpartan_WorkFlow_Conditions_by_State("Spartan_WorkFlow_Conditions_by_State_", "_" + rowIndex);
  }
}

function Spartan_WorkFlow_Conditions_by_StateCancelRow(rowIndex) {
    var prevData = Spartan_WorkFlow_Conditions_by_StateTable.fnGetData(rowIndex);
    var data = Spartan_WorkFlow_Conditions_by_StateTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Spartan_WorkFlow_Conditions_by_StateTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Spartan_WorkFlow_Conditions_by_StaterowCreationGrid(data, prevData, rowIndex);
    }
	showSpartan_WorkFlow_Conditions_by_StateGrid(Spartan_WorkFlow_Conditions_by_StateTable.fnGetData());
    Spartan_WorkFlow_Conditions_by_StatecountRowsChecked--;
}

function GetSpartan_WorkFlow_Conditions_by_StateFromDataTable() {
    var Spartan_WorkFlow_Conditions_by_StateData = [];
    var gridData = Spartan_WorkFlow_Conditions_by_StateTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Spartan_WorkFlow_Conditions_by_StateData.push({
                Conditions_by_StateId: gridData[i].Conditions_by_StateId
                ,Phase: gridData[i].Phase
                ,State: gridData[i].State
                ,Condition_Operator: gridData[i].Condition_Operator
                ,Attribute: gridData[i].Attribute
                ,Condition: gridData[i].Condition
                ,Operator: gridData[i].Operator
                ,Operator_Value: gridData[i].Operator_Value
                ,Priority: gridData[i].Priority

                ,Removed: false
            });
    }

    for (i = 0; i < removedSpartan_WorkFlow_Conditions_by_StateData.length; i++) {
        if (removedSpartan_WorkFlow_Conditions_by_StateData[i] != null && removedSpartan_WorkFlow_Conditions_by_StateData[i].Conditions_by_StateId > 0)
            Spartan_WorkFlow_Conditions_by_StateData.push({
                Conditions_by_StateId: removedSpartan_WorkFlow_Conditions_by_StateData[i].Conditions_by_StateId
                ,Phase: removedSpartan_WorkFlow_Conditions_by_StateData[i].Phase
                ,State: removedSpartan_WorkFlow_Conditions_by_StateData[i].State
                ,Condition_Operator: removedSpartan_WorkFlow_Conditions_by_StateData[i].Condition_Operator
                ,Attribute: removedSpartan_WorkFlow_Conditions_by_StateData[i].Attribute
                ,Condition: removedSpartan_WorkFlow_Conditions_by_StateData[i].Condition
                ,Operator: removedSpartan_WorkFlow_Conditions_by_StateData[i].Operator
                ,Operator_Value: removedSpartan_WorkFlow_Conditions_by_StateData[i].Operator_Value
                ,Priority: removedSpartan_WorkFlow_Conditions_by_StateData[i].Priority

                , Removed: true
            });
    }	

    return Spartan_WorkFlow_Conditions_by_StateData;
}

function Spartan_WorkFlow_Conditions_by_StateEditRow(rowIndex, currentRow) {
    var rowIndexTable = (currentRow) ? Spartan_WorkFlow_Conditions_by_StateTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Spartan_WorkFlow_Conditions_by_StatecountRowsChecked++;
    var Spartan_WorkFlow_Conditions_by_StateRowElement = "Spartan_WorkFlow_Conditions_by_State_" + rowIndex.toString();
    var prevData = Spartan_WorkFlow_Conditions_by_StateTable.fnGetData(rowIndexTable );
    var row = Spartan_WorkFlow_Conditions_by_StateTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Spartan_WorkFlow_Conditions_by_State_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Spartan_WorkFlow_Conditions_by_StateGetUpdateRowControls(prevData, "Spartan_WorkFlow_Conditions_by_State_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Spartan_WorkFlow_Conditions_by_StateRowElement + "')){ Spartan_WorkFlow_Conditions_by_StateInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Spartan_WorkFlow_Conditions_by_StateCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
        if ($('#Spartan_WorkFlow_Conditions_by_StateGrid .' + idHeader).css('display') != 'none') {
            $(controls[i]).appendTo($('<td id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));
        }
    }
    $('.Spartan_WorkFlow_Conditions_by_State' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    initiateUIControls();
    EjecutarValidacionesNewRowMRSpartan_WorkFlow_Conditions_by_State(nameOfTable, rowIndexFormed);
	EjecutarValidacionesEditRowMRSpartan_WorkFlow_Conditions_by_State(nameOfTable, rowIndexFormed);
}

function Spartan_WorkFlow_Conditions_by_StatefnOpenAddRowPopUp() {
    var currentRowIndex = Spartan_WorkFlow_Conditions_by_StateTable.fnGetData().length;
    Spartan_WorkFlow_Conditions_by_StatefnClickAddRow();
    GetAddSpartan_WorkFlow_Conditions_by_StatePopup(currentRowIndex, 0);
}

function Spartan_WorkFlow_Conditions_by_StateEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Spartan_WorkFlow_Conditions_by_StateTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Spartan_WorkFlow_Conditions_by_StateRowElement = "Spartan_WorkFlow_Conditions_by_State_" + rowIndex.toString();
    var prevData = Spartan_WorkFlow_Conditions_by_StateTable.fnGetData(rowIndexTable);
    GetAddSpartan_WorkFlow_Conditions_by_StatePopup(rowIndex, 1, prevData.Conditions_by_StateId);
    $('#Spartan_WorkFlow_Conditions_by_StatePhase').val(prevData.Phase);
    $('#Spartan_WorkFlow_Conditions_by_StateState').val(prevData.State);
    $('#Spartan_WorkFlow_Conditions_by_StateCondition_Operator').val(prevData.Condition_Operator);
    $('#Spartan_WorkFlow_Conditions_by_StateAttribute').val(prevData.Attribute);
    $('#Spartan_WorkFlow_Conditions_by_StateCondition').val(prevData.Condition);
    $('#Spartan_WorkFlow_Conditions_by_StateOperator').val(prevData.Operator);
    $('#Spartan_WorkFlow_Conditions_by_StateOperator_Value').val(prevData.Operator_Value);
    $('#Spartan_WorkFlow_Conditions_by_StatePriority').val(prevData.Priority);

    initiateUIControls();

}

function Spartan_WorkFlow_Conditions_by_StateAddInsertRow() {
    if (Spartan_WorkFlow_Conditions_by_StateinsertRowCurrentIndex < 1)
    {
        Spartan_WorkFlow_Conditions_by_StateinsertRowCurrentIndex = 1;
    }
    return {
        Conditions_by_StateId: null,
        IsInsertRow: true
        ,Phase: ""
        ,State: ""
        ,Condition_Operator: ""
        ,Attribute: ""
        ,Condition: ""
        ,Operator: ""
        ,Operator_Value: ""
        ,Priority: ""

    }
}

function Spartan_WorkFlow_Conditions_by_StatefnClickAddRow() {
    Spartan_WorkFlow_Conditions_by_StatecountRowsChecked++;
    Spartan_WorkFlow_Conditions_by_StateTable.fnAddData(Spartan_WorkFlow_Conditions_by_StateAddInsertRow(), true);
    Spartan_WorkFlow_Conditions_by_StateTable.fnPageChange('last');
    initiateUIControls();
    EjecutarValidacionesNewRowMRSpartan_WorkFlow_Conditions_by_State("Spartan_WorkFlow_Conditions_by_State_", "_" + Spartan_WorkFlow_Conditions_by_StateinsertRowCurrentIndex);
}

function Spartan_WorkFlow_Conditions_by_StateClearGridData() {
    Spartan_WorkFlow_Conditions_by_StateData = [];
    Spartan_WorkFlow_Conditions_by_StatedeletedItem = [];
    Spartan_WorkFlow_Conditions_by_StateDataMain = [];
    Spartan_WorkFlow_Conditions_by_StateDataMainPages = [];
    Spartan_WorkFlow_Conditions_by_StatenewItemCount = 0;
    Spartan_WorkFlow_Conditions_by_StatemaxItemIndex = 0;
    $("#Spartan_WorkFlow_Conditions_by_StateGrid").DataTable().clear();
    $("#Spartan_WorkFlow_Conditions_by_StateGrid").DataTable().destroy();
}

//Used to Get Spartan WorkFlow Information
function GetSpartan_WorkFlow_Conditions_by_State() {
    var form_data = new FormData();
    for (var i = 0; i < Spartan_WorkFlow_Conditions_by_StateData.length; i++) {
        form_data.append('[' + i + '].Conditions_by_StateId', Spartan_WorkFlow_Conditions_by_StateData[i].Conditions_by_StateId);
        form_data.append('[' + i + '].Phase', Spartan_WorkFlow_Conditions_by_StateData[i].Phase);
        form_data.append('[' + i + '].State', Spartan_WorkFlow_Conditions_by_StateData[i].State);
        form_data.append('[' + i + '].Condition_Operator', Spartan_WorkFlow_Conditions_by_StateData[i].Condition_Operator);
        form_data.append('[' + i + '].Attribute', Spartan_WorkFlow_Conditions_by_StateData[i].Attribute);
        form_data.append('[' + i + '].Condition', Spartan_WorkFlow_Conditions_by_StateData[i].Condition);
        form_data.append('[' + i + '].Operator', Spartan_WorkFlow_Conditions_by_StateData[i].Operator);
        form_data.append('[' + i + '].Operator_Value', Spartan_WorkFlow_Conditions_by_StateData[i].Operator_Value);
        form_data.append('[' + i + '].Priority', Spartan_WorkFlow_Conditions_by_StateData[i].Priority);

        form_data.append('[' + i + '].Removed', Spartan_WorkFlow_Conditions_by_StateData[i].Removed);
    }
    return form_data;
}
function Spartan_WorkFlow_Conditions_by_StateInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRSpartan_WorkFlow_Conditions_by_State("Spartan_WorkFlow_Conditions_by_StateTable", rowIndex)) {
    var prevData = Spartan_WorkFlow_Conditions_by_StateTable.fnGetData(rowIndex);
    var data = Spartan_WorkFlow_Conditions_by_StateTable.fnGetNodes(rowIndex);
    var newData = {
        Conditions_by_StateId: prevData.Conditions_by_StateId,
        IsInsertRow: false
        ,Phase: $('#Spartan_WorkFlow_Conditions_by_StatePhase').val()
        ,State: $('#Spartan_WorkFlow_Conditions_by_StateState').val()
        ,Condition_Operator: $('#Spartan_WorkFlow_Conditions_by_StateCondition_Operator').val()
        ,Attribute: $('#Spartan_WorkFlow_Conditions_by_StateAttribute').val()
        ,Condition: $('#Spartan_WorkFlow_Conditions_by_StateCondition').val()
        ,Operator: $('#Spartan_WorkFlow_Conditions_by_StateOperator').val()
        ,Operator_Value: $('#Spartan_WorkFlow_Conditions_by_StateOperator_Value').val()
        ,Priority: $('#Spartan_WorkFlow_Conditions_by_StatePriority').val()


    }

    Spartan_WorkFlow_Conditions_by_StateTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_WorkFlow_Conditions_by_StaterowCreationGrid(data, newData, rowIndex);
    $('#AddSpartan_WorkFlow_Conditions_by_State-form').modal({ show: false });
    $('#AddSpartan_WorkFlow_Conditions_by_State-form').modal('hide');
    Spartan_WorkFlow_Conditions_by_StateEditRow(rowIndex);
    Spartan_WorkFlow_Conditions_by_StateInsertRow(rowIndex);
    //}
}
function Spartan_WorkFlow_Conditions_by_StateRemoveAddRow(rowIndex) {
    Spartan_WorkFlow_Conditions_by_StateTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Spartan_WorkFlow_Conditions_by_State MultiRow
//Begin Declarations for Foreigns fields for Spartan_WorkFlow_Information_by_State MultiRow
var Spartan_WorkFlow_Information_by_StatecountRowsChecked = 0;
function GetSpartan_WorkFlow_Information_by_State_Spartan_WorkFlow_PhasesName(Id) {
    for (var i = 0; i < Spartan_WorkFlow_Information_by_State_Spartan_WorkFlow_PhasesItems.length; i++) {
        if (Spartan_WorkFlow_Information_by_State_Spartan_WorkFlow_PhasesItems[i].PhasesId == Id) {
            return Spartan_WorkFlow_Information_by_State_Spartan_WorkFlow_PhasesItems[i].Name;
        }
    }
    return "";
}

function GetSpartan_WorkFlow_Information_by_State_Spartan_WorkFlow_PhasesDropDown() {
    var Spartan_WorkFlow_Information_by_State_Spartan_WorkFlow_PhasesDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_WorkFlow_Information_by_State_Spartan_WorkFlow_PhasesDropdown);
    if(Spartan_WorkFlow_Information_by_State_Spartan_WorkFlow_PhasesItems != null)
    {
       for (var i = 0; i < Spartan_WorkFlow_Information_by_State_Spartan_WorkFlow_PhasesItems.length; i++) {
           $('<option />', { value: Spartan_WorkFlow_Information_by_State_Spartan_WorkFlow_PhasesItems[i].PhasesId, text:    Spartan_WorkFlow_Information_by_State_Spartan_WorkFlow_PhasesItems[i].Name }).appendTo(Spartan_WorkFlow_Information_by_State_Spartan_WorkFlow_PhasesDropdown);
       }
    }
    return Spartan_WorkFlow_Information_by_State_Spartan_WorkFlow_PhasesDropdown;
}
function GetSpartan_WorkFlow_Information_by_State_Spartan_WorkFlow_StateName(Id) {
    for (var i = 0; i < Spartan_WorkFlow_Information_by_State_Spartan_WorkFlow_StateItems.length; i++) {
        if (Spartan_WorkFlow_Information_by_State_Spartan_WorkFlow_StateItems[i].StateId == Id) {
            return Spartan_WorkFlow_Information_by_State_Spartan_WorkFlow_StateItems[i].Name;
        }
    }
    return "";
}

function GetSpartan_WorkFlow_Information_by_State_Spartan_WorkFlow_StateDropDown() {
    var Spartan_WorkFlow_Information_by_State_Spartan_WorkFlow_StateDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_WorkFlow_Information_by_State_Spartan_WorkFlow_StateDropdown);
    if(Spartan_WorkFlow_Information_by_State_Spartan_WorkFlow_StateItems != null)
    {
       for (var i = 0; i < Spartan_WorkFlow_Information_by_State_Spartan_WorkFlow_StateItems.length; i++) {
           $('<option />', { value: Spartan_WorkFlow_Information_by_State_Spartan_WorkFlow_StateItems[i].StateId, text:    Spartan_WorkFlow_Information_by_State_Spartan_WorkFlow_StateItems[i].Name }).appendTo(Spartan_WorkFlow_Information_by_State_Spartan_WorkFlow_StateDropdown);
       }
    }
    return Spartan_WorkFlow_Information_by_State_Spartan_WorkFlow_StateDropdown;
}
function GetSpartan_WorkFlow_Information_by_State_Spartan_MetadataName(Id) {
    for (var i = 0; i < Spartan_WorkFlow_Information_by_State_Spartan_MetadataItems.length; i++) {
        if (Spartan_WorkFlow_Information_by_State_Spartan_MetadataItems[i].AttributeId == Id) {
            return Spartan_WorkFlow_Information_by_State_Spartan_MetadataItems[i].Group_Name;
        }
    }
    return "";
}

function GetSpartan_WorkFlow_Information_by_State_Spartan_MetadataDropDown() {
    var Spartan_WorkFlow_Information_by_State_Spartan_MetadataDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_WorkFlow_Information_by_State_Spartan_MetadataDropdown);

    for (var i = 0; i < Spartan_WorkFlow_Information_by_State_Spartan_MetadataItems.length; i++) {
        $('<option />', { value: Spartan_WorkFlow_Information_by_State_Spartan_MetadataItems[i].AttributeId, text: Spartan_WorkFlow_Information_by_State_Spartan_MetadataItems[i].Group_Name }).appendTo(Spartan_WorkFlow_Information_by_State_Spartan_MetadataDropdown);
    }
    return Spartan_WorkFlow_Information_by_State_Spartan_MetadataDropdown;
}


function GetInsertSpartan_WorkFlow_Information_by_StateRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $(GetSpartan_WorkFlow_Information_by_State_Spartan_WorkFlow_PhasesDropDown()).addClass('Spartan_WorkFlow_Information_by_State_Phase Phase').attr('id', 'Spartan_WorkFlow_Information_by_State_Phase_' + index).attr('data-field', 'Phase');
    columnData[1] = $(GetSpartan_WorkFlow_Information_by_State_Spartan_WorkFlow_StateDropDown()).addClass('Spartan_WorkFlow_Information_by_State_State State').attr('id', 'Spartan_WorkFlow_Information_by_State_State_' + index).attr('data-field', 'State');
    columnData[2] = $($.parseHTML(GetGridAutoComplete(null,'AutoCompleteSpartan_WorkFlow_Information_by_State_Folder'))).addClass('Spartan_WorkFlow_Information_by_State_Folder Folder').attr('id', 'Spartan_WorkFlow_Information_by_State_Folder_' + index).attr('data-field', 'Folder');
    columnData[3] = $($.parseHTML(GetGridCheckBox())).addClass('Spartan_WorkFlow_Information_by_State_Visible Visible').attr('id', 'Spartan_WorkFlow_Information_by_State_Visible_' + index).attr('data-field', 'Visible');
    columnData[4] = $($.parseHTML(GetGridCheckBox())).addClass('Spartan_WorkFlow_Information_by_State_Read_Only Read_Only').attr('id', 'Spartan_WorkFlow_Information_by_State_Read_Only_' + index).attr('data-field', 'Read_Only');
    columnData[5] = $($.parseHTML(GetGridCheckBox())).addClass('Spartan_WorkFlow_Information_by_State_Required Required').attr('id', 'Spartan_WorkFlow_Information_by_State_Required_' + index).attr('data-field', 'Required');
    columnData[6] = $($.parseHTML(inputData)).addClass('Spartan_WorkFlow_Information_by_State_Label Label').attr('id', 'Spartan_WorkFlow_Information_by_State_Label_' + index).attr('data-field', 'Label');


    initiateUIControls();
    return columnData;
}

function Spartan_WorkFlow_Information_by_StateInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRSpartan_WorkFlow_Information_by_State("Spartan_WorkFlow_Information_by_State_", "_" + rowIndex)) {
    var nameOfGrid = 'Spartan_WorkFlow_Information_by_State';
    var prevData = Spartan_WorkFlow_Information_by_StateTable.fnGetData(rowIndex);
    var data = Spartan_WorkFlow_Information_by_StateTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Information_by_StateId: prevData.Information_by_StateId,
        IsInsertRow: false
        ,Phase: ($('#' + nameOfGrid + 'Grid .PhaseHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,State: ($('#' + nameOfGrid + 'Grid .StateHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        , FolderGroup_Name: ($('#' + nameOfGrid + 'Grid .FolderHeader').css('display') != 'none') ?  $(data.childNodes[counter].childNodes[0]).find('option:selected').text() : ''
        , Folder: ($('#' + nameOfGrid + 'Grid .FolderHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''	
        ,Visible: ($('#' + nameOfGrid + 'Grid .VisibleHeader').css('display') != 'none') ? $(data.childNodes[counter++].childNodes[1]).is(':checked') : ''
        ,Read_Only: ($('#' + nameOfGrid + 'Grid .Read_OnlyHeader').css('display') != 'none') ? $(data.childNodes[counter++].childNodes[1]).is(':checked') : ''
        ,Required: ($('#' + nameOfGrid + 'Grid .RequiredHeader').css('display') != 'none') ? $(data.childNodes[counter++].childNodes[1]).is(':checked') : ''
        ,Label: ($('#' + nameOfGrid + 'Grid .LabelHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''

    }
    Spartan_WorkFlow_Information_by_StateTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_WorkFlow_Information_by_StaterowCreationGrid(data, newData, rowIndex);
    Spartan_WorkFlow_Information_by_StatecountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRSpartan_WorkFlow_Information_by_State("Spartan_WorkFlow_Information_by_State_", "_" + rowIndex);
  }
}

function Spartan_WorkFlow_Information_by_StateCancelRow(rowIndex) {
    var prevData = Spartan_WorkFlow_Information_by_StateTable.fnGetData(rowIndex);
    var data = Spartan_WorkFlow_Information_by_StateTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Spartan_WorkFlow_Information_by_StateTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Spartan_WorkFlow_Information_by_StaterowCreationGrid(data, prevData, rowIndex);
    }
	showSpartan_WorkFlow_Information_by_StateGrid(Spartan_WorkFlow_Information_by_StateTable.fnGetData());
    Spartan_WorkFlow_Information_by_StatecountRowsChecked--;
}

function GetSpartan_WorkFlow_Information_by_StateFromDataTable() {
    var Spartan_WorkFlow_Information_by_StateData = [];
    var gridData = Spartan_WorkFlow_Information_by_StateTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Spartan_WorkFlow_Information_by_StateData.push({
                Information_by_StateId: gridData[i].Information_by_StateId
                ,Phase: gridData[i].Phase
                ,State: gridData[i].State
                ,Folder: gridData[i].Folder
                ,Visible: gridData[i].Visible
                ,Read_Only: gridData[i].Read_Only
                ,Required: gridData[i].Required
                ,Label: gridData[i].Label

                ,Removed: false
            });
    }

    for (i = 0; i < removedSpartan_WorkFlow_Information_by_StateData.length; i++) {
        if (removedSpartan_WorkFlow_Information_by_StateData[i] != null && removedSpartan_WorkFlow_Information_by_StateData[i].Information_by_StateId > 0)
            Spartan_WorkFlow_Information_by_StateData.push({
                Information_by_StateId: removedSpartan_WorkFlow_Information_by_StateData[i].Information_by_StateId
                ,Phase: removedSpartan_WorkFlow_Information_by_StateData[i].Phase
                ,State: removedSpartan_WorkFlow_Information_by_StateData[i].State
                ,Folder: removedSpartan_WorkFlow_Information_by_StateData[i].Folder
                ,Visible: removedSpartan_WorkFlow_Information_by_StateData[i].Visible
                ,Read_Only: removedSpartan_WorkFlow_Information_by_StateData[i].Read_Only
                ,Required: removedSpartan_WorkFlow_Information_by_StateData[i].Required
                ,Label: removedSpartan_WorkFlow_Information_by_StateData[i].Label

                , Removed: true
            });
    }	

    return Spartan_WorkFlow_Information_by_StateData;
}

function Spartan_WorkFlow_Information_by_StateEditRow(rowIndex, currentRow) {
    var rowIndexTable = (currentRow) ? Spartan_WorkFlow_Information_by_StateTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Spartan_WorkFlow_Information_by_StatecountRowsChecked++;
    var Spartan_WorkFlow_Information_by_StateRowElement = "Spartan_WorkFlow_Information_by_State_" + rowIndex.toString();
    var prevData = Spartan_WorkFlow_Information_by_StateTable.fnGetData(rowIndexTable );
    var row = Spartan_WorkFlow_Information_by_StateTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Spartan_WorkFlow_Information_by_State_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Spartan_WorkFlow_Information_by_StateGetUpdateRowControls(prevData, "Spartan_WorkFlow_Information_by_State_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Spartan_WorkFlow_Information_by_StateRowElement + "')){ Spartan_WorkFlow_Information_by_StateInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Spartan_WorkFlow_Information_by_StateCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
        if ($('#Spartan_WorkFlow_Information_by_StateGrid .' + idHeader).css('display') != 'none') {
            $(controls[i]).appendTo($('<td id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));
        }
    }
    $('.Spartan_WorkFlow_Information_by_State' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    initiateUIControls();
    EjecutarValidacionesNewRowMRSpartan_WorkFlow_Information_by_State(nameOfTable, rowIndexFormed);
	EjecutarValidacionesEditRowMRSpartan_WorkFlow_Information_by_State(nameOfTable, rowIndexFormed);
}

function Spartan_WorkFlow_Information_by_StatefnOpenAddRowPopUp() {
    var currentRowIndex = Spartan_WorkFlow_Information_by_StateTable.fnGetData().length;
    Spartan_WorkFlow_Information_by_StatefnClickAddRow();
    GetAddSpartan_WorkFlow_Information_by_StatePopup(currentRowIndex, 0);
}

function Spartan_WorkFlow_Information_by_StateEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Spartan_WorkFlow_Information_by_StateTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Spartan_WorkFlow_Information_by_StateRowElement = "Spartan_WorkFlow_Information_by_State_" + rowIndex.toString();
    var prevData = Spartan_WorkFlow_Information_by_StateTable.fnGetData(rowIndexTable);
    GetAddSpartan_WorkFlow_Information_by_StatePopup(rowIndex, 1, prevData.Information_by_StateId);
    $('#Spartan_WorkFlow_Information_by_StatePhase').val(prevData.Phase);
    $('#Spartan_WorkFlow_Information_by_StateState').val(prevData.State);
    $('#dvSpartan_WorkFlow_Information_by_StateFolder').html($($.parseHTML(GetGridAutoComplete(prevData.Folder.label,'AutoCompleteFolder'))).addClass('Spartan_WorkFlow_Information_by_State_Folder'));
    $('#Spartan_WorkFlow_Information_by_StateVisible').prop('checked', prevData.Visible);
    $('#Spartan_WorkFlow_Information_by_StateRead_Only').prop('checked', prevData.Read_Only);
    $('#Spartan_WorkFlow_Information_by_StateRequired').prop('checked', prevData.Required);
    $('#Spartan_WorkFlow_Information_by_StateLabel').val(prevData.Label);

    initiateUIControls();

}

function Spartan_WorkFlow_Information_by_StateAddInsertRow() {
    if (Spartan_WorkFlow_Information_by_StateinsertRowCurrentIndex < 1)
    {
        Spartan_WorkFlow_Information_by_StateinsertRowCurrentIndex = 1;
    }
    return {
        Information_by_StateId: null,
        IsInsertRow: true
        ,Phase: ""
        ,State: ""
        ,Folder: ""
        ,Visible: ""
        ,Read_Only: ""
        ,Required: ""
        ,Label: ""

    }
}

function Spartan_WorkFlow_Information_by_StatefnClickAddRow() {
    Spartan_WorkFlow_Information_by_StatecountRowsChecked++;
    Spartan_WorkFlow_Information_by_StateTable.fnAddData(Spartan_WorkFlow_Information_by_StateAddInsertRow(), true);
    Spartan_WorkFlow_Information_by_StateTable.fnPageChange('last');
    initiateUIControls();
    EjecutarValidacionesNewRowMRSpartan_WorkFlow_Information_by_State("Spartan_WorkFlow_Information_by_State_", "_" + Spartan_WorkFlow_Information_by_StateinsertRowCurrentIndex);
}

function Spartan_WorkFlow_Information_by_StateClearGridData() {
    Spartan_WorkFlow_Information_by_StateData = [];
    Spartan_WorkFlow_Information_by_StatedeletedItem = [];
    Spartan_WorkFlow_Information_by_StateDataMain = [];
    Spartan_WorkFlow_Information_by_StateDataMainPages = [];
    Spartan_WorkFlow_Information_by_StatenewItemCount = 0;
    Spartan_WorkFlow_Information_by_StatemaxItemIndex = 0;
    $("#Spartan_WorkFlow_Information_by_StateGrid").DataTable().clear();
    $("#Spartan_WorkFlow_Information_by_StateGrid").DataTable().destroy();
}

//Used to Get Spartan WorkFlow Information
function GetSpartan_WorkFlow_Information_by_State() {
    var form_data = new FormData();
    for (var i = 0; i < Spartan_WorkFlow_Information_by_StateData.length; i++) {
        form_data.append('[' + i + '].Information_by_StateId', Spartan_WorkFlow_Information_by_StateData[i].Information_by_StateId);
        form_data.append('[' + i + '].Phase', Spartan_WorkFlow_Information_by_StateData[i].Phase);
        form_data.append('[' + i + '].State', Spartan_WorkFlow_Information_by_StateData[i].State);
        form_data.append('[' + i + '].Folder', Spartan_WorkFlow_Information_by_StateData[i].Folder);
        form_data.append('[' + i + '].Visible', Spartan_WorkFlow_Information_by_StateData[i].Visible);
        form_data.append('[' + i + '].Read_Only', Spartan_WorkFlow_Information_by_StateData[i].Read_Only);
        form_data.append('[' + i + '].Required', Spartan_WorkFlow_Information_by_StateData[i].Required);
        form_data.append('[' + i + '].Label', Spartan_WorkFlow_Information_by_StateData[i].Label);

        form_data.append('[' + i + '].Removed', Spartan_WorkFlow_Information_by_StateData[i].Removed);
    }
    return form_data;
}
function Spartan_WorkFlow_Information_by_StateInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRSpartan_WorkFlow_Information_by_State("Spartan_WorkFlow_Information_by_StateTable", rowIndex)) {
    var prevData = Spartan_WorkFlow_Information_by_StateTable.fnGetData(rowIndex);
    var data = Spartan_WorkFlow_Information_by_StateTable.fnGetNodes(rowIndex);
    var newData = {
        Information_by_StateId: prevData.Information_by_StateId,
        IsInsertRow: false
        ,Phase: $('#Spartan_WorkFlow_Information_by_StatePhase').val()
        ,State: $('#Spartan_WorkFlow_Information_by_StateState').val()
        ,Folder: $('#Spartan_WorkFlow_Information_by_StateFolder').val()
        ,Visible: $('#Spartan_WorkFlow_Information_by_StateVisible').is(':checked')
        ,Read_Only: $('#Spartan_WorkFlow_Information_by_StateRead_Only').is(':checked')
        ,Required: $('#Spartan_WorkFlow_Information_by_StateRequired').is(':checked')
        ,Label: $('#Spartan_WorkFlow_Information_by_StateLabel').val()

    }

    Spartan_WorkFlow_Information_by_StateTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_WorkFlow_Information_by_StaterowCreationGrid(data, newData, rowIndex);
    $('#AddSpartan_WorkFlow_Information_by_State-form').modal({ show: false });
    $('#AddSpartan_WorkFlow_Information_by_State-form').modal('hide');
    Spartan_WorkFlow_Information_by_StateEditRow(rowIndex);
    Spartan_WorkFlow_Information_by_StateInsertRow(rowIndex);
    //}
}
function Spartan_WorkFlow_Information_by_StateRemoveAddRow(rowIndex) {
    Spartan_WorkFlow_Information_by_StateTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Spartan_WorkFlow_Information_by_State MultiRow
//Begin Declarations for Foreigns fields for Spartan_WorkFlow_Roles_by_State MultiRow
var Spartan_WorkFlow_Roles_by_StatecountRowsChecked = 0;
function GetSpartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_PhasesName(Id) {
    for (var i = 0; i < Spartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_PhasesItems.length; i++) {
        if (Spartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_PhasesItems[i].PhasesId == Id) {
            return Spartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_PhasesItems[i].Name;
        }
    }
    return "";
}

function GetSpartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_PhasesDropDown() {
    var Spartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_PhasesDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_PhasesDropdown);
    if(Spartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_PhasesItems != null)
    {
       for (var i = 0; i < Spartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_PhasesItems.length; i++) {
           $('<option />', { value: Spartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_PhasesItems[i].PhasesId, text:    Spartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_PhasesItems[i].Name }).appendTo(Spartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_PhasesDropdown);
       }
    }
    return Spartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_PhasesDropdown;
}
function GetSpartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_StateName(Id) {
    for (var i = 0; i < Spartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_StateItems.length; i++) {
        if (Spartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_StateItems[i].StateId == Id) {
            return Spartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_StateItems[i].Name;
        }
    }
    return "";
}

function GetSpartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_StateDropDown() {
    var Spartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_StateDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_StateDropdown);
    if(Spartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_StateItems != null)
    {
       for (var i = 0; i < Spartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_StateItems.length; i++) {
           $('<option />', { value: Spartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_StateItems[i].StateId, text:    Spartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_StateItems[i].Name }).appendTo(Spartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_StateDropdown);
       }
    }
    return Spartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_StateDropdown;
}

function GetSpartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_UserRoleName(Id) {
    for (var i = 0; i < Spartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_UserRoleItems.length; i++) {
        if (Spartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_UserRoleItems[i].User_Role_Id == Id) {
            return Spartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_UserRoleItems[i].Description;
        }
    }
    return "";
}

function GetSpartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_UserRoleDropDown() {
    var Spartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_UserRoleDropdown = $('<select class="form-control" />');
  
    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_UserRoleDropdown);
    if (Spartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_UserRoleItems != null) {
        for (var i = 0; i < Spartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_UserRoleItems.length; i++) {
            $('<option />', { value: Spartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_UserRoleItems[i].User_Role_Id, text: Spartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_UserRoleItems[i].Description }).appendTo(Spartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_UserRoleDropdown);
        }
    }
    return Spartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_UserRoleDropdown;
}


function GetInsertSpartan_WorkFlow_Roles_by_StateRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $(GetSpartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_PhasesDropDown()).addClass('Spartan_WorkFlow_Roles_by_State_Phase Phase').attr('id', 'Spartan_WorkFlow_Roles_by_State_Phase_' + index).attr('data-field', 'Phase');
    columnData[1] = $(GetSpartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_StateDropDown()).addClass('Spartan_WorkFlow_Roles_by_State_State State').attr('id', 'Spartan_WorkFlow_Roles_by_State_State_' + index).attr('data-field', 'State');
    columnData[2] = $(GetSpartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_UserRoleDropDown()).addClass('Spartan_WorkFlow_Roles_by_State_UserRole UserRole').attr('id', 'Spartan_WorkFlow_Roles_by_State_UserRole_' + index).attr('data-field', 'UserRole');
    //columnData[2] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Spartan_WorkFlow_Roles_by_State_User_Role User_Role').attr('id', 'Spartan_WorkFlow_Roles_by_State_User_Role_' + index).attr('data-field', 'User_Role');
    columnData[3] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Spartan_WorkFlow_Roles_by_State_Phase_Transition Phase_Transition').attr('id', 'Spartan_WorkFlow_Roles_by_State_Phase_Transition_' + index).attr('data-field', 'Phase_Transition');
    columnData[4] = $($.parseHTML(GetGridCheckBox())).addClass('Spartan_WorkFlow_Roles_by_State_Permission_To_Consult Permission_To_Consult').attr('id', 'Spartan_WorkFlow_Roles_by_State_Permission_To_Consult_' + index).attr('data-field', 'Permission_To_Consult');
    columnData[5] = $($.parseHTML(GetGridCheckBox())).addClass('Spartan_WorkFlow_Roles_by_State_Permission_To_New Permission_To_New').attr('id', 'Spartan_WorkFlow_Roles_by_State_Permission_To_New_' + index).attr('data-field', 'Permission_To_New');
    columnData[6] = $($.parseHTML(GetGridCheckBox())).addClass('Spartan_WorkFlow_Roles_by_State_Permission_To_Modify Permission_To_Modify').attr('id', 'Spartan_WorkFlow_Roles_by_State_Permission_To_Modify_' + index).attr('data-field', 'Permission_To_Modify');
    columnData[7] = $($.parseHTML(GetGridCheckBox())).addClass('Spartan_WorkFlow_Roles_by_State_Permission_to_Delete Permission_to_Delete').attr('id', 'Spartan_WorkFlow_Roles_by_State_Permission_to_Delete_' + index).attr('data-field', 'Permission_to_Delete');
    columnData[8] = $($.parseHTML(GetGridCheckBox())).addClass('Spartan_WorkFlow_Roles_by_State_Permission_To_Export Permission_To_Export').attr('id', 'Spartan_WorkFlow_Roles_by_State_Permission_To_Export_' + index).attr('data-field', 'Permission_To_Export');
    columnData[9] = $($.parseHTML(GetGridCheckBox())).addClass('Spartan_WorkFlow_Roles_by_State_Permission_To_Print Permission_To_Print').attr('id', 'Spartan_WorkFlow_Roles_by_State_Permission_To_Print_' + index).attr('data-field', 'Permission_To_Print');
    columnData[10] = $($.parseHTML(GetGridCheckBox())).addClass('Spartan_WorkFlow_Roles_by_State_Permission_Settings Permission_Settings').attr('id', 'Spartan_WorkFlow_Roles_by_State_Permission_Settings_' + index).attr('data-field', 'Permission_Settings');


    initiateUIControls();
    return columnData;
}

function Spartan_WorkFlow_Roles_by_StateInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRSpartan_WorkFlow_Roles_by_State("Spartan_WorkFlow_Roles_by_State_", "_" + rowIndex)) {
    var nameOfGrid = 'Spartan_WorkFlow_Roles_by_State';
    var prevData = Spartan_WorkFlow_Roles_by_StateTable.fnGetData(rowIndex);
    var data = Spartan_WorkFlow_Roles_by_StateTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Roles_by_StateId: prevData.Roles_by_StateId,
        IsInsertRow: false
        ,Phase: ($('#' + nameOfGrid + 'Grid .PhaseHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,State: ($('#' + nameOfGrid + 'Grid .StateHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,User_Role: ($('#' + nameOfGrid + 'Grid .User_RoleHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Phase_Transition: ($('#' + nameOfGrid + 'Grid .Phase_TransitionHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Permission_To_Consult: ($('#' + nameOfGrid + 'Grid .Permission_To_ConsultHeader').css('display') != 'none') ? $(data.childNodes[counter++].childNodes[1]).is(':checked') : ''
        ,Permission_To_New: ($('#' + nameOfGrid + 'Grid .Permission_To_NewHeader').css('display') != 'none') ? $(data.childNodes[counter++].childNodes[1]).is(':checked') : ''
        ,Permission_To_Modify: ($('#' + nameOfGrid + 'Grid .Permission_To_ModifyHeader').css('display') != 'none') ? $(data.childNodes[counter++].childNodes[1]).is(':checked') : ''
        ,Permission_to_Delete: ($('#' + nameOfGrid + 'Grid .Permission_to_DeleteHeader').css('display') != 'none') ? $(data.childNodes[counter++].childNodes[1]).is(':checked') : ''
        ,Permission_To_Export: ($('#' + nameOfGrid + 'Grid .Permission_To_ExportHeader').css('display') != 'none') ? $(data.childNodes[counter++].childNodes[1]).is(':checked') : ''
        ,Permission_To_Print: ($('#' + nameOfGrid + 'Grid .Permission_To_PrintHeader').css('display') != 'none') ? $(data.childNodes[counter++].childNodes[1]).is(':checked') : ''
        ,Permission_Settings: ($('#' + nameOfGrid + 'Grid .Permission_SettingsHeader').css('display') != 'none') ? $(data.childNodes[counter++].childNodes[1]).is(':checked') : ''

    }
    Spartan_WorkFlow_Roles_by_StateTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_WorkFlow_Roles_by_StaterowCreationGrid(data, newData, rowIndex);
    Spartan_WorkFlow_Roles_by_StatecountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRSpartan_WorkFlow_Roles_by_State("Spartan_WorkFlow_Roles_by_State_", "_" + rowIndex);
  }
}

function Spartan_WorkFlow_Roles_by_StateCancelRow(rowIndex) {
    var prevData = Spartan_WorkFlow_Roles_by_StateTable.fnGetData(rowIndex);
    var data = Spartan_WorkFlow_Roles_by_StateTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Spartan_WorkFlow_Roles_by_StateTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Spartan_WorkFlow_Roles_by_StaterowCreationGrid(data, prevData, rowIndex);
    }
	showSpartan_WorkFlow_Roles_by_StateGrid(Spartan_WorkFlow_Roles_by_StateTable.fnGetData());
    Spartan_WorkFlow_Roles_by_StatecountRowsChecked--;
}

function GetSpartan_WorkFlow_Roles_by_StateFromDataTable() {
    var Spartan_WorkFlow_Roles_by_StateData = [];
    var gridData = Spartan_WorkFlow_Roles_by_StateTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Spartan_WorkFlow_Roles_by_StateData.push({
                Roles_by_StateId: gridData[i].Roles_by_StateId
                ,Phase: gridData[i].Phase
                ,State: gridData[i].State
                ,User_Role: gridData[i].User_Role
                ,Phase_Transition: gridData[i].Phase_Transition
                ,Permission_To_Consult: gridData[i].Permission_To_Consult
                ,Permission_To_New: gridData[i].Permission_To_New
                ,Permission_To_Modify: gridData[i].Permission_To_Modify
                ,Permission_to_Delete: gridData[i].Permission_to_Delete
                ,Permission_To_Export: gridData[i].Permission_To_Export
                ,Permission_To_Print: gridData[i].Permission_To_Print
                ,Permission_Settings: gridData[i].Permission_Settings

                ,Removed: false
            });
    }

    for (i = 0; i < removedSpartan_WorkFlow_Roles_by_StateData.length; i++) {
        if (removedSpartan_WorkFlow_Roles_by_StateData[i] != null && removedSpartan_WorkFlow_Roles_by_StateData[i].Roles_by_StateId > 0)
            Spartan_WorkFlow_Roles_by_StateData.push({
                Roles_by_StateId: removedSpartan_WorkFlow_Roles_by_StateData[i].Roles_by_StateId
                ,Phase: removedSpartan_WorkFlow_Roles_by_StateData[i].Phase
                ,State: removedSpartan_WorkFlow_Roles_by_StateData[i].State
                ,User_Role: removedSpartan_WorkFlow_Roles_by_StateData[i].User_Role
                ,Phase_Transition: removedSpartan_WorkFlow_Roles_by_StateData[i].Phase_Transition
                ,Permission_To_Consult: removedSpartan_WorkFlow_Roles_by_StateData[i].Permission_To_Consult
                ,Permission_To_New: removedSpartan_WorkFlow_Roles_by_StateData[i].Permission_To_New
                ,Permission_To_Modify: removedSpartan_WorkFlow_Roles_by_StateData[i].Permission_To_Modify
                ,Permission_to_Delete: removedSpartan_WorkFlow_Roles_by_StateData[i].Permission_to_Delete
                ,Permission_To_Export: removedSpartan_WorkFlow_Roles_by_StateData[i].Permission_To_Export
                ,Permission_To_Print: removedSpartan_WorkFlow_Roles_by_StateData[i].Permission_To_Print
                ,Permission_Settings: removedSpartan_WorkFlow_Roles_by_StateData[i].Permission_Settings

                , Removed: true
            });
    }	

    return Spartan_WorkFlow_Roles_by_StateData;
}

function Spartan_WorkFlow_Roles_by_StateEditRow(rowIndex, currentRow) {
    var rowIndexTable = (currentRow) ? Spartan_WorkFlow_Roles_by_StateTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Spartan_WorkFlow_Roles_by_StatecountRowsChecked++;
    var Spartan_WorkFlow_Roles_by_StateRowElement = "Spartan_WorkFlow_Roles_by_State_" + rowIndex.toString();
    var prevData = Spartan_WorkFlow_Roles_by_StateTable.fnGetData(rowIndexTable );
    var row = Spartan_WorkFlow_Roles_by_StateTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Spartan_WorkFlow_Roles_by_State_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Spartan_WorkFlow_Roles_by_StateGetUpdateRowControls(prevData, "Spartan_WorkFlow_Roles_by_State_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Spartan_WorkFlow_Roles_by_StateRowElement + "')){ Spartan_WorkFlow_Roles_by_StateInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Spartan_WorkFlow_Roles_by_StateCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
        if ($('#Spartan_WorkFlow_Roles_by_StateGrid .' + idHeader).css('display') != 'none') {
            $(controls[i]).appendTo($('<td id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));
        }
    }
    $('.Spartan_WorkFlow_Roles_by_State' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    initiateUIControls();
    EjecutarValidacionesNewRowMRSpartan_WorkFlow_Roles_by_State(nameOfTable, rowIndexFormed);
	EjecutarValidacionesEditRowMRSpartan_WorkFlow_Roles_by_State(nameOfTable, rowIndexFormed);
}

function Spartan_WorkFlow_Roles_by_StatefnOpenAddRowPopUp() {
    var currentRowIndex = Spartan_WorkFlow_Roles_by_StateTable.fnGetData().length;
    Spartan_WorkFlow_Roles_by_StatefnClickAddRow();
    GetAddSpartan_WorkFlow_Roles_by_StatePopup(currentRowIndex, 0);
}

function Spartan_WorkFlow_Roles_by_StateEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Spartan_WorkFlow_Roles_by_StateTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Spartan_WorkFlow_Roles_by_StateRowElement = "Spartan_WorkFlow_Roles_by_State_" + rowIndex.toString();
    var prevData = Spartan_WorkFlow_Roles_by_StateTable.fnGetData(rowIndexTable);
    GetAddSpartan_WorkFlow_Roles_by_StatePopup(rowIndex, 1, prevData.Roles_by_StateId);
    $('#Spartan_WorkFlow_Roles_by_StatePhase').val(prevData.Phase);
    $('#Spartan_WorkFlow_Roles_by_StateState').val(prevData.State);
    $('#Spartan_WorkFlow_Roles_by_StateUser_Role').val(prevData.User_Role);
    $('#Spartan_WorkFlow_Roles_by_StatePhase_Transition').val(prevData.Phase_Transition);
    $('#Spartan_WorkFlow_Roles_by_StatePermission_To_Consult').prop('checked', prevData.Permission_To_Consult);
    $('#Spartan_WorkFlow_Roles_by_StatePermission_To_New').prop('checked', prevData.Permission_To_New);
    $('#Spartan_WorkFlow_Roles_by_StatePermission_To_Modify').prop('checked', prevData.Permission_To_Modify);
    $('#Spartan_WorkFlow_Roles_by_StatePermission_to_Delete').prop('checked', prevData.Permission_to_Delete);
    $('#Spartan_WorkFlow_Roles_by_StatePermission_To_Export').prop('checked', prevData.Permission_To_Export);
    $('#Spartan_WorkFlow_Roles_by_StatePermission_To_Print').prop('checked', prevData.Permission_To_Print);
    $('#Spartan_WorkFlow_Roles_by_StatePermission_Settings').prop('checked', prevData.Permission_Settings);

    initiateUIControls();

}

function Spartan_WorkFlow_Roles_by_StateAddInsertRow() {
    if (Spartan_WorkFlow_Roles_by_StateinsertRowCurrentIndex < 1)
    {
        Spartan_WorkFlow_Roles_by_StateinsertRowCurrentIndex = 1;
    }
    return {
        Roles_by_StateId: null,
        IsInsertRow: true
        ,Phase: ""
        ,State: ""
        ,User_Role: ""
        ,Phase_Transition: ""
        ,Permission_To_Consult: ""
        ,Permission_To_New: ""
        ,Permission_To_Modify: ""
        ,Permission_to_Delete: ""
        ,Permission_To_Export: ""
        ,Permission_To_Print: ""
        ,Permission_Settings: ""

    }
}

function Spartan_WorkFlow_Roles_by_StatefnClickAddRow() {
    Spartan_WorkFlow_Roles_by_StatecountRowsChecked++;
    Spartan_WorkFlow_Roles_by_StateTable.fnAddData(Spartan_WorkFlow_Roles_by_StateAddInsertRow(), true);
    Spartan_WorkFlow_Roles_by_StateTable.fnPageChange('last');
    initiateUIControls();
    EjecutarValidacionesNewRowMRSpartan_WorkFlow_Roles_by_State("Spartan_WorkFlow_Roles_by_State_", "_" + Spartan_WorkFlow_Roles_by_StateinsertRowCurrentIndex);
}

function Spartan_WorkFlow_Roles_by_StateClearGridData() {
    Spartan_WorkFlow_Roles_by_StateData = [];
    Spartan_WorkFlow_Roles_by_StatedeletedItem = [];
    Spartan_WorkFlow_Roles_by_StateDataMain = [];
    Spartan_WorkFlow_Roles_by_StateDataMainPages = [];
    Spartan_WorkFlow_Roles_by_StatenewItemCount = 0;
    Spartan_WorkFlow_Roles_by_StatemaxItemIndex = 0;
    $("#Spartan_WorkFlow_Roles_by_StateGrid").DataTable().clear();
    $("#Spartan_WorkFlow_Roles_by_StateGrid").DataTable().destroy();
}

//Used to Get Spartan WorkFlow Information
function GetSpartan_WorkFlow_Roles_by_State() {
    var form_data = new FormData();
    for (var i = 0; i < Spartan_WorkFlow_Roles_by_StateData.length; i++) {
        form_data.append('[' + i + '].Roles_by_StateId', Spartan_WorkFlow_Roles_by_StateData[i].Roles_by_StateId);
        form_data.append('[' + i + '].Phase', Spartan_WorkFlow_Roles_by_StateData[i].Phase);
        form_data.append('[' + i + '].State', Spartan_WorkFlow_Roles_by_StateData[i].State);
        form_data.append('[' + i + '].User_Role', Spartan_WorkFlow_Roles_by_StateData[i].User_Role);
        form_data.append('[' + i + '].Phase_Transition', Spartan_WorkFlow_Roles_by_StateData[i].Phase_Transition);
        form_data.append('[' + i + '].Permission_To_Consult', Spartan_WorkFlow_Roles_by_StateData[i].Permission_To_Consult);
        form_data.append('[' + i + '].Permission_To_New', Spartan_WorkFlow_Roles_by_StateData[i].Permission_To_New);
        form_data.append('[' + i + '].Permission_To_Modify', Spartan_WorkFlow_Roles_by_StateData[i].Permission_To_Modify);
        form_data.append('[' + i + '].Permission_to_Delete', Spartan_WorkFlow_Roles_by_StateData[i].Permission_to_Delete);
        form_data.append('[' + i + '].Permission_To_Export', Spartan_WorkFlow_Roles_by_StateData[i].Permission_To_Export);
        form_data.append('[' + i + '].Permission_To_Print', Spartan_WorkFlow_Roles_by_StateData[i].Permission_To_Print);
        form_data.append('[' + i + '].Permission_Settings', Spartan_WorkFlow_Roles_by_StateData[i].Permission_Settings);

        form_data.append('[' + i + '].Removed', Spartan_WorkFlow_Roles_by_StateData[i].Removed);
    }
    return form_data;
}
function Spartan_WorkFlow_Roles_by_StateInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRSpartan_WorkFlow_Roles_by_State("Spartan_WorkFlow_Roles_by_StateTable", rowIndex)) {
    var prevData = Spartan_WorkFlow_Roles_by_StateTable.fnGetData(rowIndex);
    var data = Spartan_WorkFlow_Roles_by_StateTable.fnGetNodes(rowIndex);
    var newData = {
        Roles_by_StateId: prevData.Roles_by_StateId,
        IsInsertRow: false
        ,Phase: $('#Spartan_WorkFlow_Roles_by_StatePhase').val()
        ,State: $('#Spartan_WorkFlow_Roles_by_StateState').val()
        ,User_Role: $('#Spartan_WorkFlow_Roles_by_StateUser_Role').val()

        ,Phase_Transition: $('#Spartan_WorkFlow_Roles_by_StatePhase_Transition').val()

        ,Permission_To_Consult: $('#Spartan_WorkFlow_Roles_by_StatePermission_To_Consult').is(':checked')
        ,Permission_To_New: $('#Spartan_WorkFlow_Roles_by_StatePermission_To_New').is(':checked')
        ,Permission_To_Modify: $('#Spartan_WorkFlow_Roles_by_StatePermission_To_Modify').is(':checked')
        ,Permission_to_Delete: $('#Spartan_WorkFlow_Roles_by_StatePermission_to_Delete').is(':checked')
        ,Permission_To_Export: $('#Spartan_WorkFlow_Roles_by_StatePermission_To_Export').is(':checked')
        ,Permission_To_Print: $('#Spartan_WorkFlow_Roles_by_StatePermission_To_Print').is(':checked')
        ,Permission_Settings: $('#Spartan_WorkFlow_Roles_by_StatePermission_Settings').is(':checked')

    }

    Spartan_WorkFlow_Roles_by_StateTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_WorkFlow_Roles_by_StaterowCreationGrid(data, newData, rowIndex);
    $('#AddSpartan_WorkFlow_Roles_by_State-form').modal({ show: false });
    $('#AddSpartan_WorkFlow_Roles_by_State-form').modal('hide');
    Spartan_WorkFlow_Roles_by_StateEditRow(rowIndex);
    Spartan_WorkFlow_Roles_by_StateInsertRow(rowIndex);
    //}
}
function Spartan_WorkFlow_Roles_by_StateRemoveAddRow(rowIndex) {
    Spartan_WorkFlow_Roles_by_StateTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Spartan_WorkFlow_Roles_by_State MultiRow
//Begin Declarations for Foreigns fields for Spartan_WorkFlow_Matrix_of_States MultiRow
var Spartan_WorkFlow_Matrix_of_StatescountRowsChecked = 0;
function GetSpartan_WorkFlow_Matrix_of_States_Spartan_WorkFlow_PhasesName(Id) {
    for (var i = 0; i < Spartan_WorkFlow_Matrix_of_States_Spartan_WorkFlow_PhasesItems.length; i++) {
        if (Spartan_WorkFlow_Matrix_of_States_Spartan_WorkFlow_PhasesItems[i].PhasesId == Id) {
            return Spartan_WorkFlow_Matrix_of_States_Spartan_WorkFlow_PhasesItems[i].Name;
        }
    }
    return "";
}

function GetSpartan_WorkFlow_Matrix_of_States_Spartan_WorkFlow_PhasesDropDown() {
    var Spartan_WorkFlow_Matrix_of_States_Spartan_WorkFlow_PhasesDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_WorkFlow_Matrix_of_States_Spartan_WorkFlow_PhasesDropdown);
    if(Spartan_WorkFlow_Matrix_of_States_Spartan_WorkFlow_PhasesItems != null)
    {
       for (var i = 0; i < Spartan_WorkFlow_Matrix_of_States_Spartan_WorkFlow_PhasesItems.length; i++) {
           $('<option />', { value: Spartan_WorkFlow_Matrix_of_States_Spartan_WorkFlow_PhasesItems[i].PhasesId, text:    Spartan_WorkFlow_Matrix_of_States_Spartan_WorkFlow_PhasesItems[i].Name }).appendTo(Spartan_WorkFlow_Matrix_of_States_Spartan_WorkFlow_PhasesDropdown);
       }
    }
    return Spartan_WorkFlow_Matrix_of_States_Spartan_WorkFlow_PhasesDropdown;
}
function GetSpartan_WorkFlow_Matrix_of_States_Spartan_WorkFlow_StateName(Id) {
    for (var i = 0; i < Spartan_WorkFlow_Matrix_of_States_Spartan_WorkFlow_StateItems.length; i++) {
        if (Spartan_WorkFlow_Matrix_of_States_Spartan_WorkFlow_StateItems[i].StateId == Id) {
            return Spartan_WorkFlow_Matrix_of_States_Spartan_WorkFlow_StateItems[i].Name;
        }
    }
    return "";
}

function GetSpartan_WorkFlow_Matrix_of_States_Spartan_WorkFlow_StateDropDown() {
    var Spartan_WorkFlow_Matrix_of_States_Spartan_WorkFlow_StateDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_WorkFlow_Matrix_of_States_Spartan_WorkFlow_StateDropdown);
    if(Spartan_WorkFlow_Matrix_of_States_Spartan_WorkFlow_StateItems != null)
    {
       for (var i = 0; i < Spartan_WorkFlow_Matrix_of_States_Spartan_WorkFlow_StateItems.length; i++) {
           $('<option />', { value: Spartan_WorkFlow_Matrix_of_States_Spartan_WorkFlow_StateItems[i].StateId, text:    Spartan_WorkFlow_Matrix_of_States_Spartan_WorkFlow_StateItems[i].Name }).appendTo(Spartan_WorkFlow_Matrix_of_States_Spartan_WorkFlow_StateDropdown);
       }
    }
    return Spartan_WorkFlow_Matrix_of_States_Spartan_WorkFlow_StateDropdown;
}
function GetSpartan_WorkFlow_Matrix_of_States_Spartan_MetadataName(Id) {
    for (var i = 0; i < Spartan_WorkFlow_Matrix_of_States_Spartan_MetadataItems.length; i++) {
        if (Spartan_WorkFlow_Matrix_of_States_Spartan_MetadataItems[i].AttributeId == Id) {
            return Spartan_WorkFlow_Matrix_of_States_Spartan_MetadataItems[i].Logical_Name;
        }
    }
    return "";
}

function GetSpartan_WorkFlow_Matrix_of_States_Spartan_MetadataDropDown() {
    var Spartan_WorkFlow_Matrix_of_States_Spartan_MetadataDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_WorkFlow_Matrix_of_States_Spartan_MetadataDropdown);

    for (var i = 0; i < Spartan_WorkFlow_Matrix_of_States_Spartan_MetadataItems.length; i++) {
        $('<option />', { value: Spartan_WorkFlow_Matrix_of_States_Spartan_MetadataItems[i].AttributeId, text: Spartan_WorkFlow_Matrix_of_States_Spartan_MetadataItems[i].Logical_Name }).appendTo(Spartan_WorkFlow_Matrix_of_States_Spartan_MetadataDropdown);
    }
    return Spartan_WorkFlow_Matrix_of_States_Spartan_MetadataDropdown;
}


function GetInsertSpartan_WorkFlow_Matrix_of_StatesRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $(GetSpartan_WorkFlow_Matrix_of_States_Spartan_WorkFlow_PhasesDropDown()).addClass('Spartan_WorkFlow_Matrix_of_States_Phase Phase').attr('id', 'Spartan_WorkFlow_Matrix_of_States_Phase_' + index).attr('data-field', 'Phase');
    columnData[1] = $(GetSpartan_WorkFlow_Matrix_of_States_Spartan_WorkFlow_StateDropDown()).addClass('Spartan_WorkFlow_Matrix_of_States_State State').attr('id', 'Spartan_WorkFlow_Matrix_of_States_State_' + index).attr('data-field', 'State');
    columnData[2] = $($.parseHTML(GetGridAutoComplete(null,'AutoCompleteSpartan_WorkFlow_Matrix_of_States_Attribute'))).addClass('Spartan_WorkFlow_Matrix_of_States_Attribute Attribute').attr('id', 'Spartan_WorkFlow_Matrix_of_States_Attribute_' + index).attr('data-field', 'Attribute');
    columnData[3] = $($.parseHTML(GetGridCheckBox())).addClass('Spartan_WorkFlow_Matrix_of_States_Visible Visible').attr('id', 'Spartan_WorkFlow_Matrix_of_States_Visible_' + index).attr('data-field', 'Visible');
    columnData[4] = $($.parseHTML(GetGridCheckBox())).addClass('Spartan_WorkFlow_Matrix_of_States_Required Required').attr('id', 'Spartan_WorkFlow_Matrix_of_States_Required_' + index).attr('data-field', 'Required');
    columnData[5] = $($.parseHTML(GetGridCheckBox())).addClass('Spartan_WorkFlow_Matrix_of_States_Read_Only Read_Only').attr('id', 'Spartan_WorkFlow_Matrix_of_States_Read_Only_' + index).attr('data-field', 'Read_Only');
    columnData[6] = $($.parseHTML(inputData)).addClass('Spartan_WorkFlow_Matrix_of_States_Label Label').attr('id', 'Spartan_WorkFlow_Matrix_of_States_Label_' + index).attr('data-field', 'Label');
    columnData[7] = $($.parseHTML(inputData)).addClass('Spartan_WorkFlow_Matrix_of_States_Default_Value Default_Value').attr('id', 'Spartan_WorkFlow_Matrix_of_States_Default_Value_' + index).attr('data-field', 'Default_Value');
    columnData[8] = $($.parseHTML(inputData)).addClass('Spartan_WorkFlow_Matrix_of_States_Help_Text Help_Text').attr('id', 'Spartan_WorkFlow_Matrix_of_States_Help_Text_' + index).attr('data-field', 'Help_Text');


    initiateUIControls();
    return columnData;
}

function Spartan_WorkFlow_Matrix_of_StatesInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRSpartan_WorkFlow_Matrix_of_States("Spartan_WorkFlow_Matrix_of_States_", "_" + rowIndex)) {
    var nameOfGrid = 'Spartan_WorkFlow_Matrix_of_States';
    var prevData = Spartan_WorkFlow_Matrix_of_StatesTable.fnGetData(rowIndex);
    var data = Spartan_WorkFlow_Matrix_of_StatesTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Matrix_of_StatesId: prevData.Matrix_of_StatesId,
        IsInsertRow: false
        ,Phase: ($('#' + nameOfGrid + 'Grid .PhaseHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,State: ($('#' + nameOfGrid + 'Grid .StateHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        , AttributeLogical_Name: ($('#' + nameOfGrid + 'Grid .AttributeHeader').css('display') != 'none') ?  $(data.childNodes[counter].childNodes[0]).find('option:selected').text() : ''
        , Attribute: ($('#' + nameOfGrid + 'Grid .AttributeHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''	
        ,Visible: ($('#' + nameOfGrid + 'Grid .VisibleHeader').css('display') != 'none') ? $(data.childNodes[counter++].childNodes[1]).is(':checked') : ''
        ,Required: ($('#' + nameOfGrid + 'Grid .RequiredHeader').css('display') != 'none') ? $(data.childNodes[counter++].childNodes[1]).is(':checked') : ''
        ,Read_Only: ($('#' + nameOfGrid + 'Grid .Read_OnlyHeader').css('display') != 'none') ? $(data.childNodes[counter++].childNodes[1]).is(':checked') : ''
        ,Label: ($('#' + nameOfGrid + 'Grid .LabelHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Default_Value: ($('#' + nameOfGrid + 'Grid .Default_ValueHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Help_Text: ($('#' + nameOfGrid + 'Grid .Help_TextHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''

    }
    Spartan_WorkFlow_Matrix_of_StatesTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_WorkFlow_Matrix_of_StatesrowCreationGrid(data, newData, rowIndex);
    Spartan_WorkFlow_Matrix_of_StatescountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRSpartan_WorkFlow_Matrix_of_States("Spartan_WorkFlow_Matrix_of_States_", "_" + rowIndex);
  }
}

function Spartan_WorkFlow_Matrix_of_StatesCancelRow(rowIndex) {
    var prevData = Spartan_WorkFlow_Matrix_of_StatesTable.fnGetData(rowIndex);
    var data = Spartan_WorkFlow_Matrix_of_StatesTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Spartan_WorkFlow_Matrix_of_StatesTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Spartan_WorkFlow_Matrix_of_StatesrowCreationGrid(data, prevData, rowIndex);
    }
	showSpartan_WorkFlow_Matrix_of_StatesGrid(Spartan_WorkFlow_Matrix_of_StatesTable.fnGetData());
    Spartan_WorkFlow_Matrix_of_StatescountRowsChecked--;
}

function GetSpartan_WorkFlow_Matrix_of_StatesFromDataTable() {
    var Spartan_WorkFlow_Matrix_of_StatesData = [];
    var gridData = Spartan_WorkFlow_Matrix_of_StatesTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Spartan_WorkFlow_Matrix_of_StatesData.push({
                Matrix_of_StatesId: gridData[i].Matrix_of_StatesId
                ,Phase: gridData[i].Phase
                ,State: gridData[i].State
                ,Attribute: gridData[i].Attribute
                ,Visible: gridData[i].Visible
                ,Required: gridData[i].Required
                ,Read_Only: gridData[i].Read_Only
                ,Label: gridData[i].Label
                ,Default_Value: gridData[i].Default_Value
                ,Help_Text: gridData[i].Help_Text

                ,Removed: false
            });
    }

    for (i = 0; i < removedSpartan_WorkFlow_Matrix_of_StatesData.length; i++) {
        if (removedSpartan_WorkFlow_Matrix_of_StatesData[i] != null && removedSpartan_WorkFlow_Matrix_of_StatesData[i].Matrix_of_StatesId > 0)
            Spartan_WorkFlow_Matrix_of_StatesData.push({
                Matrix_of_StatesId: removedSpartan_WorkFlow_Matrix_of_StatesData[i].Matrix_of_StatesId
                ,Phase: removedSpartan_WorkFlow_Matrix_of_StatesData[i].Phase
                ,State: removedSpartan_WorkFlow_Matrix_of_StatesData[i].State
                ,Attribute: removedSpartan_WorkFlow_Matrix_of_StatesData[i].Attribute
                ,Visible: removedSpartan_WorkFlow_Matrix_of_StatesData[i].Visible
                ,Required: removedSpartan_WorkFlow_Matrix_of_StatesData[i].Required
                ,Read_Only: removedSpartan_WorkFlow_Matrix_of_StatesData[i].Read_Only
                ,Label: removedSpartan_WorkFlow_Matrix_of_StatesData[i].Label
                ,Default_Value: removedSpartan_WorkFlow_Matrix_of_StatesData[i].Default_Value
                ,Help_Text: removedSpartan_WorkFlow_Matrix_of_StatesData[i].Help_Text

                , Removed: true
            });
    }	

    return Spartan_WorkFlow_Matrix_of_StatesData;
}

function Spartan_WorkFlow_Matrix_of_StatesEditRow(rowIndex, currentRow) {
    var rowIndexTable = (currentRow) ? Spartan_WorkFlow_Matrix_of_StatesTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Spartan_WorkFlow_Matrix_of_StatescountRowsChecked++;
    var Spartan_WorkFlow_Matrix_of_StatesRowElement = "Spartan_WorkFlow_Matrix_of_States_" + rowIndex.toString();
    var prevData = Spartan_WorkFlow_Matrix_of_StatesTable.fnGetData(rowIndexTable );
    var row = Spartan_WorkFlow_Matrix_of_StatesTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Spartan_WorkFlow_Matrix_of_States_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Spartan_WorkFlow_Matrix_of_StatesGetUpdateRowControls(prevData, "Spartan_WorkFlow_Matrix_of_States_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Spartan_WorkFlow_Matrix_of_StatesRowElement + "')){ Spartan_WorkFlow_Matrix_of_StatesInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Spartan_WorkFlow_Matrix_of_StatesCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
        if ($('#Spartan_WorkFlow_Matrix_of_StatesGrid .' + idHeader).css('display') != 'none') {
            $(controls[i]).appendTo($('<td id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));
        }
    }
    $('.Spartan_WorkFlow_Matrix_of_States' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    initiateUIControls();
    EjecutarValidacionesNewRowMRSpartan_WorkFlow_Matrix_of_States(nameOfTable, rowIndexFormed);
	EjecutarValidacionesEditRowMRSpartan_WorkFlow_Matrix_of_States(nameOfTable, rowIndexFormed);
}

function Spartan_WorkFlow_Matrix_of_StatesfnOpenAddRowPopUp() {
    var currentRowIndex = Spartan_WorkFlow_Matrix_of_StatesTable.fnGetData().length;
    Spartan_WorkFlow_Matrix_of_StatesfnClickAddRow();
    GetAddSpartan_WorkFlow_Matrix_of_StatesPopup(currentRowIndex, 0);
}

function Spartan_WorkFlow_Matrix_of_StatesEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Spartan_WorkFlow_Matrix_of_StatesTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Spartan_WorkFlow_Matrix_of_StatesRowElement = "Spartan_WorkFlow_Matrix_of_States_" + rowIndex.toString();
    var prevData = Spartan_WorkFlow_Matrix_of_StatesTable.fnGetData(rowIndexTable);
    GetAddSpartan_WorkFlow_Matrix_of_StatesPopup(rowIndex, 1, prevData.Matrix_of_StatesId);
    $('#Spartan_WorkFlow_Matrix_of_StatesPhase').val(prevData.Phase);
    $('#Spartan_WorkFlow_Matrix_of_StatesState').val(prevData.State);
    $('#dvSpartan_WorkFlow_Matrix_of_StatesAttribute').html($($.parseHTML(GetGridAutoComplete(prevData.Attribute.label,'AutoCompleteAttribute'))).addClass('Spartan_WorkFlow_Matrix_of_States_Attribute'));
    $('#Spartan_WorkFlow_Matrix_of_StatesVisible').prop('checked', prevData.Visible);
    $('#Spartan_WorkFlow_Matrix_of_StatesRequired').prop('checked', prevData.Required);
    $('#Spartan_WorkFlow_Matrix_of_StatesRead_Only').prop('checked', prevData.Read_Only);
    $('#Spartan_WorkFlow_Matrix_of_StatesLabel').val(prevData.Label);
    $('#Spartan_WorkFlow_Matrix_of_StatesDefault_Value').val(prevData.Default_Value);
    $('#Spartan_WorkFlow_Matrix_of_StatesHelp_Text').val(prevData.Help_Text);

    initiateUIControls();

}

function Spartan_WorkFlow_Matrix_of_StatesAddInsertRow() {
    if (Spartan_WorkFlow_Matrix_of_StatesinsertRowCurrentIndex < 1)
    {
        Spartan_WorkFlow_Matrix_of_StatesinsertRowCurrentIndex = 1;
    }
    return {
        Matrix_of_StatesId: null,
        IsInsertRow: true
        ,Phase: ""
        ,State: ""
        ,Attribute: ""
        ,Visible: ""
        ,Required: ""
        ,Read_Only: ""
        ,Label: ""
        ,Default_Value: ""
        ,Help_Text: ""

    }
}

function Spartan_WorkFlow_Matrix_of_StatesfnClickAddRow() {
    Spartan_WorkFlow_Matrix_of_StatescountRowsChecked++;
    Spartan_WorkFlow_Matrix_of_StatesTable.fnAddData(Spartan_WorkFlow_Matrix_of_StatesAddInsertRow(), true);
    Spartan_WorkFlow_Matrix_of_StatesTable.fnPageChange('last');
    initiateUIControls();
    EjecutarValidacionesNewRowMRSpartan_WorkFlow_Matrix_of_States("Spartan_WorkFlow_Matrix_of_States_", "_" + Spartan_WorkFlow_Matrix_of_StatesinsertRowCurrentIndex);
}

function Spartan_WorkFlow_Matrix_of_StatesClearGridData() {
    Spartan_WorkFlow_Matrix_of_StatesData = [];
    Spartan_WorkFlow_Matrix_of_StatesdeletedItem = [];
    Spartan_WorkFlow_Matrix_of_StatesDataMain = [];
    Spartan_WorkFlow_Matrix_of_StatesDataMainPages = [];
    Spartan_WorkFlow_Matrix_of_StatesnewItemCount = 0;
    Spartan_WorkFlow_Matrix_of_StatesmaxItemIndex = 0;
    $("#Spartan_WorkFlow_Matrix_of_StatesGrid").DataTable().clear();
    $("#Spartan_WorkFlow_Matrix_of_StatesGrid").DataTable().destroy();
}

//Used to Get Spartan WorkFlow Information
function GetSpartan_WorkFlow_Matrix_of_States() {
    var form_data = new FormData();
    for (var i = 0; i < Spartan_WorkFlow_Matrix_of_StatesData.length; i++) {
        form_data.append('[' + i + '].Matrix_of_StatesId', Spartan_WorkFlow_Matrix_of_StatesData[i].Matrix_of_StatesId);
        form_data.append('[' + i + '].Phase', Spartan_WorkFlow_Matrix_of_StatesData[i].Phase);
        form_data.append('[' + i + '].State', Spartan_WorkFlow_Matrix_of_StatesData[i].State);
        form_data.append('[' + i + '].Attribute', Spartan_WorkFlow_Matrix_of_StatesData[i].Attribute);
        form_data.append('[' + i + '].Visible', Spartan_WorkFlow_Matrix_of_StatesData[i].Visible);
        form_data.append('[' + i + '].Required', Spartan_WorkFlow_Matrix_of_StatesData[i].Required);
        form_data.append('[' + i + '].Read_Only', Spartan_WorkFlow_Matrix_of_StatesData[i].Read_Only);
        form_data.append('[' + i + '].Label', Spartan_WorkFlow_Matrix_of_StatesData[i].Label);
        form_data.append('[' + i + '].Default_Value', Spartan_WorkFlow_Matrix_of_StatesData[i].Default_Value);
        form_data.append('[' + i + '].Help_Text', Spartan_WorkFlow_Matrix_of_StatesData[i].Help_Text);

        form_data.append('[' + i + '].Removed', Spartan_WorkFlow_Matrix_of_StatesData[i].Removed);
    }
    return form_data;
}
function Spartan_WorkFlow_Matrix_of_StatesInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRSpartan_WorkFlow_Matrix_of_States("Spartan_WorkFlow_Matrix_of_StatesTable", rowIndex)) {
    var prevData = Spartan_WorkFlow_Matrix_of_StatesTable.fnGetData(rowIndex);
    var data = Spartan_WorkFlow_Matrix_of_StatesTable.fnGetNodes(rowIndex);
    var newData = {
        Matrix_of_StatesId: prevData.Matrix_of_StatesId,
        IsInsertRow: false
        ,Phase: $('#Spartan_WorkFlow_Matrix_of_StatesPhase').val()
        ,State: $('#Spartan_WorkFlow_Matrix_of_StatesState').val()
        ,Attribute: $('#Spartan_WorkFlow_Matrix_of_StatesAttribute').val()
        ,Visible: $('#Spartan_WorkFlow_Matrix_of_StatesVisible').is(':checked')
        ,Required: $('#Spartan_WorkFlow_Matrix_of_StatesRequired').is(':checked')
        ,Read_Only: $('#Spartan_WorkFlow_Matrix_of_StatesRead_Only').is(':checked')
        ,Label: $('#Spartan_WorkFlow_Matrix_of_StatesLabel').val()
        ,Default_Value: $('#Spartan_WorkFlow_Matrix_of_StatesDefault_Value').val()
        ,Help_Text: $('#Spartan_WorkFlow_Matrix_of_StatesHelp_Text').val()

    }

    Spartan_WorkFlow_Matrix_of_StatesTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_WorkFlow_Matrix_of_StatesrowCreationGrid(data, newData, rowIndex);
    $('#AddSpartan_WorkFlow_Matrix_of_States-form').modal({ show: false });
    $('#AddSpartan_WorkFlow_Matrix_of_States-form').modal('hide');
    Spartan_WorkFlow_Matrix_of_StatesEditRow(rowIndex);
    Spartan_WorkFlow_Matrix_of_StatesInsertRow(rowIndex);
    //}
}
function Spartan_WorkFlow_Matrix_of_StatesRemoveAddRow(rowIndex) {
    Spartan_WorkFlow_Matrix_of_StatesTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Spartan_WorkFlow_Matrix_of_States MultiRow


$(function () {
    function Spartan_WorkFlow_PhasesinitializeMainArray(totalCount) {
        if (Spartan_WorkFlow_PhasesDataMain.length != totalCount && !Spartan_WorkFlow_PhasesDataMainInitialized) {
            Spartan_WorkFlow_PhasesDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Spartan_WorkFlow_PhasesDataMain[i] = null;
            }
        }
    }
    function Spartan_WorkFlow_PhasesremoveFromMainArray() {
        for (var j = 0; j < Spartan_WorkFlow_PhasesdeletedItem.length; j++) {
            for (var i = 0; i < Spartan_WorkFlow_PhasesDataMain.length; i++) {
                if (Spartan_WorkFlow_PhasesDataMain[i] != null && Spartan_WorkFlow_PhasesDataMain[i].Id == Spartan_WorkFlow_PhasesdeletedItem[j]) {
                    hSpartan_WorkFlow_PhasesDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Spartan_WorkFlow_PhasescopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Spartan_WorkFlow_PhasesDataMain.length; i++) {
            data[i] = Spartan_WorkFlow_PhasesDataMain[i];

        }
        return data;
    }
    function Spartan_WorkFlow_PhasesgetNewResult() {
        var newData = copyMainSpartan_WorkFlow_PhasesArray();

        for (var i = 0; i < Spartan_WorkFlow_PhasesData.length; i++) {
            if (Spartan_WorkFlow_PhasesData[i].Removed == null || Spartan_WorkFlow_PhasesData[i].Removed == false) {
                newData.splice(0, 0, Spartan_WorkFlow_PhasesData[i]);
            }
        }
        return newData;
    }
    function Spartan_WorkFlow_PhasespushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Spartan_WorkFlow_PhasesDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Spartan_WorkFlow_PhasesDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Spartan_WorkFlow_StateinitializeMainArray(totalCount) {
        if (Spartan_WorkFlow_StateDataMain.length != totalCount && !Spartan_WorkFlow_StateDataMainInitialized) {
            Spartan_WorkFlow_StateDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Spartan_WorkFlow_StateDataMain[i] = null;
            }
        }
    }
    function Spartan_WorkFlow_StateremoveFromMainArray() {
        for (var j = 0; j < Spartan_WorkFlow_StatedeletedItem.length; j++) {
            for (var i = 0; i < Spartan_WorkFlow_StateDataMain.length; i++) {
                if (Spartan_WorkFlow_StateDataMain[i] != null && Spartan_WorkFlow_StateDataMain[i].Id == Spartan_WorkFlow_StatedeletedItem[j]) {
                    hSpartan_WorkFlow_StateDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Spartan_WorkFlow_StatecopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Spartan_WorkFlow_StateDataMain.length; i++) {
            data[i] = Spartan_WorkFlow_StateDataMain[i];

        }
        return data;
    }
    function Spartan_WorkFlow_StategetNewResult() {
        var newData = copyMainSpartan_WorkFlow_StateArray();

        for (var i = 0; i < Spartan_WorkFlow_StateData.length; i++) {
            if (Spartan_WorkFlow_StateData[i].Removed == null || Spartan_WorkFlow_StateData[i].Removed == false) {
                newData.splice(0, 0, Spartan_WorkFlow_StateData[i]);
            }
        }
        return newData;
    }
    function Spartan_WorkFlow_StatepushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Spartan_WorkFlow_StateDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Spartan_WorkFlow_StateDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Spartan_WorkFlow_Conditions_by_StateinitializeMainArray(totalCount) {
        if (Spartan_WorkFlow_Conditions_by_StateDataMain.length != totalCount && !Spartan_WorkFlow_Conditions_by_StateDataMainInitialized) {
            Spartan_WorkFlow_Conditions_by_StateDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Spartan_WorkFlow_Conditions_by_StateDataMain[i] = null;
            }
        }
    }
    function Spartan_WorkFlow_Conditions_by_StateremoveFromMainArray() {
        for (var j = 0; j < Spartan_WorkFlow_Conditions_by_StatedeletedItem.length; j++) {
            for (var i = 0; i < Spartan_WorkFlow_Conditions_by_StateDataMain.length; i++) {
                if (Spartan_WorkFlow_Conditions_by_StateDataMain[i] != null && Spartan_WorkFlow_Conditions_by_StateDataMain[i].Id == Spartan_WorkFlow_Conditions_by_StatedeletedItem[j]) {
                    hSpartan_WorkFlow_Conditions_by_StateDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Spartan_WorkFlow_Conditions_by_StatecopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Spartan_WorkFlow_Conditions_by_StateDataMain.length; i++) {
            data[i] = Spartan_WorkFlow_Conditions_by_StateDataMain[i];

        }
        return data;
    }
    function Spartan_WorkFlow_Conditions_by_StategetNewResult() {
        var newData = copyMainSpartan_WorkFlow_Conditions_by_StateArray();

        for (var i = 0; i < Spartan_WorkFlow_Conditions_by_StateData.length; i++) {
            if (Spartan_WorkFlow_Conditions_by_StateData[i].Removed == null || Spartan_WorkFlow_Conditions_by_StateData[i].Removed == false) {
                newData.splice(0, 0, Spartan_WorkFlow_Conditions_by_StateData[i]);
            }
        }
        return newData;
    }
    function Spartan_WorkFlow_Conditions_by_StatepushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Spartan_WorkFlow_Conditions_by_StateDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Spartan_WorkFlow_Conditions_by_StateDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Spartan_WorkFlow_Information_by_StateinitializeMainArray(totalCount) {
        if (Spartan_WorkFlow_Information_by_StateDataMain.length != totalCount && !Spartan_WorkFlow_Information_by_StateDataMainInitialized) {
            Spartan_WorkFlow_Information_by_StateDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Spartan_WorkFlow_Information_by_StateDataMain[i] = null;
            }
        }
    }
    function Spartan_WorkFlow_Information_by_StateremoveFromMainArray() {
        for (var j = 0; j < Spartan_WorkFlow_Information_by_StatedeletedItem.length; j++) {
            for (var i = 0; i < Spartan_WorkFlow_Information_by_StateDataMain.length; i++) {
                if (Spartan_WorkFlow_Information_by_StateDataMain[i] != null && Spartan_WorkFlow_Information_by_StateDataMain[i].Id == Spartan_WorkFlow_Information_by_StatedeletedItem[j]) {
                    hSpartan_WorkFlow_Information_by_StateDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Spartan_WorkFlow_Information_by_StatecopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Spartan_WorkFlow_Information_by_StateDataMain.length; i++) {
            data[i] = Spartan_WorkFlow_Information_by_StateDataMain[i];

        }
        return data;
    }
    function Spartan_WorkFlow_Information_by_StategetNewResult() {
        var newData = copyMainSpartan_WorkFlow_Information_by_StateArray();

        for (var i = 0; i < Spartan_WorkFlow_Information_by_StateData.length; i++) {
            if (Spartan_WorkFlow_Information_by_StateData[i].Removed == null || Spartan_WorkFlow_Information_by_StateData[i].Removed == false) {
                newData.splice(0, 0, Spartan_WorkFlow_Information_by_StateData[i]);
            }
        }
        return newData;
    }
    function Spartan_WorkFlow_Information_by_StatepushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Spartan_WorkFlow_Information_by_StateDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Spartan_WorkFlow_Information_by_StateDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Spartan_WorkFlow_Roles_by_StateinitializeMainArray(totalCount) {
        if (Spartan_WorkFlow_Roles_by_StateDataMain.length != totalCount && !Spartan_WorkFlow_Roles_by_StateDataMainInitialized) {
            Spartan_WorkFlow_Roles_by_StateDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Spartan_WorkFlow_Roles_by_StateDataMain[i] = null;
            }
        }
    }
    function Spartan_WorkFlow_Roles_by_StateremoveFromMainArray() {
        for (var j = 0; j < Spartan_WorkFlow_Roles_by_StatedeletedItem.length; j++) {
            for (var i = 0; i < Spartan_WorkFlow_Roles_by_StateDataMain.length; i++) {
                if (Spartan_WorkFlow_Roles_by_StateDataMain[i] != null && Spartan_WorkFlow_Roles_by_StateDataMain[i].Id == Spartan_WorkFlow_Roles_by_StatedeletedItem[j]) {
                    hSpartan_WorkFlow_Roles_by_StateDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Spartan_WorkFlow_Roles_by_StatecopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Spartan_WorkFlow_Roles_by_StateDataMain.length; i++) {
            data[i] = Spartan_WorkFlow_Roles_by_StateDataMain[i];

        }
        return data;
    }
    function Spartan_WorkFlow_Roles_by_StategetNewResult() {
        var newData = copyMainSpartan_WorkFlow_Roles_by_StateArray();

        for (var i = 0; i < Spartan_WorkFlow_Roles_by_StateData.length; i++) {
            if (Spartan_WorkFlow_Roles_by_StateData[i].Removed == null || Spartan_WorkFlow_Roles_by_StateData[i].Removed == false) {
                newData.splice(0, 0, Spartan_WorkFlow_Roles_by_StateData[i]);
            }
        }
        return newData;
    }
    function Spartan_WorkFlow_Roles_by_StatepushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Spartan_WorkFlow_Roles_by_StateDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Spartan_WorkFlow_Roles_by_StateDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Spartan_WorkFlow_Matrix_of_StatesinitializeMainArray(totalCount) {
        if (Spartan_WorkFlow_Matrix_of_StatesDataMain.length != totalCount && !Spartan_WorkFlow_Matrix_of_StatesDataMainInitialized) {
            Spartan_WorkFlow_Matrix_of_StatesDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Spartan_WorkFlow_Matrix_of_StatesDataMain[i] = null;
            }
        }
    }
    function Spartan_WorkFlow_Matrix_of_StatesremoveFromMainArray() {
        for (var j = 0; j < Spartan_WorkFlow_Matrix_of_StatesdeletedItem.length; j++) {
            for (var i = 0; i < Spartan_WorkFlow_Matrix_of_StatesDataMain.length; i++) {
                if (Spartan_WorkFlow_Matrix_of_StatesDataMain[i] != null && Spartan_WorkFlow_Matrix_of_StatesDataMain[i].Id == Spartan_WorkFlow_Matrix_of_StatesdeletedItem[j]) {
                    hSpartan_WorkFlow_Matrix_of_StatesDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Spartan_WorkFlow_Matrix_of_StatescopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Spartan_WorkFlow_Matrix_of_StatesDataMain.length; i++) {
            data[i] = Spartan_WorkFlow_Matrix_of_StatesDataMain[i];

        }
        return data;
    }
    function Spartan_WorkFlow_Matrix_of_StatesgetNewResult() {
        var newData = copyMainSpartan_WorkFlow_Matrix_of_StatesArray();

        for (var i = 0; i < Spartan_WorkFlow_Matrix_of_StatesData.length; i++) {
            if (Spartan_WorkFlow_Matrix_of_StatesData[i].Removed == null || Spartan_WorkFlow_Matrix_of_StatesData[i].Removed == false) {
                newData.splice(0, 0, Spartan_WorkFlow_Matrix_of_StatesData[i]);
            }
        }
        return newData;
    }
    function Spartan_WorkFlow_Matrix_of_StatespushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Spartan_WorkFlow_Matrix_of_StatesDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Spartan_WorkFlow_Matrix_of_StatesDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }

});

function GetAutoCompleteSpartan_WorkFlow_Object_Spartan_ObjectData(data) {
    var selectData = [];
    for (var i = 0; i < data.length; i++) {
        selectData.push({
            id: data[i].Object_Id,
            text: data[i].Name
        });
    }
    return selectData;
}
//Grid GetAutocomplete

//Grid GetAutocomplete
function GetAutoCompleteSpartan_WorkFlow_State_Attribute_Spartan_MetadataData(data) {
    var selectData = [];
    for (var i = 0; i < data.length; i++) {
        selectData.push({
            id: data[i].AttributeId,
            text: data[i].Logical_Name
        });
    }
    return selectData;
}

//Grid GetAutocomplete

//Grid GetAutocomplete
function GetAutoCompleteSpartan_WorkFlow_Information_by_State_Folder_Spartan_MetadataData(data) {
    var selectData = [];
    for (var i = 0; i < data.length; i++) {
        selectData.push({
            id: data[i].AttributeId,
            text: data[i].Group_Name
        });
    }
    return selectData;
}

//Grid GetAutocomplete

//Grid GetAutocomplete
function GetAutoCompleteSpartan_WorkFlow_Matrix_of_States_Attribute_Spartan_MetadataData(data) {
    var selectData = [];
    for (var i = 0; i < data.length; i++) {
        selectData.push({
            id: data[i].AttributeId,
            text: data[i].Logical_Name
        });
    }
    return selectData;
}



function getDropdown(elementKey) {
    var dropDown = '<select id="' + elementKey + '" class="form-control"><option value="">--Select--</option></select>';
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

function GetGridAutoComplete(data,field) {
    
    var dataMain = data == null ? "Select" : data;
    
     return "<select class='AutoComplete fullWidth select2-dropDown " + field + " form-control' data-val='true'  ><option>" + dataMain + "</option></select>";
}

function ClearControls() {
    $("#ReferenceWorkFlowId").val("0");
    $('#CreateSpartan_WorkFlow')[0].reset();
    ClearFormControls();
    $("#WorkFlowIdId").val("0");
    $('#Object').empty();
    $("#Object").append('<option value=""></option>');
    $('#Object').val('0').trigger('change');
                Spartan_WorkFlow_PhasesClearGridData();
                Spartan_WorkFlow_StateClearGridData();
                Spartan_WorkFlow_Conditions_by_StateClearGridData();
                Spartan_WorkFlow_Information_by_StateClearGridData();
                Spartan_WorkFlow_Roles_by_StateClearGridData();
                Spartan_WorkFlow_Matrix_of_StatesClearGridData();

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreateSpartan_WorkFlow').trigger('reset');
    $('#CreateSpartan_WorkFlow').find(':input').each(function () {
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
    var $myForm = $('#CreateSpartan_WorkFlow');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    if (Spartan_WorkFlow_PhasescountRowsChecked > 0)
    {
        ShowMessagePendingRowSpartan_WorkFlow_Phases();
        return false;
    }
    if (Spartan_WorkFlow_StatecountRowsChecked > 0)
    {
        ShowMessagePendingRowSpartan_WorkFlow_State();
        return false;
    }
    if (Spartan_WorkFlow_Conditions_by_StatecountRowsChecked > 0)
    {
        ShowMessagePendingRowSpartan_WorkFlow_Conditions_by_State();
        return false;
    }
    if (Spartan_WorkFlow_Information_by_StatecountRowsChecked > 0)
    {
        ShowMessagePendingRowSpartan_WorkFlow_Information_by_State();
        return false;
    }
    if (Spartan_WorkFlow_Roles_by_StatecountRowsChecked > 0)
    {
        ShowMessagePendingRowSpartan_WorkFlow_Roles_by_State();
        return false;
    }
    if (Spartan_WorkFlow_Matrix_of_StatescountRowsChecked > 0)
    {
        ShowMessagePendingRowSpartan_WorkFlow_Matrix_of_States();
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblWorkFlowId").text("0");
}
$(document).ready(function () {
    $("form#CreateSpartan_WorkFlow").submit(function (e) {
        e.preventDefault();
        return false;
    });
	$("form#CreateSpartan_WorkFlow").on('click', '#Spartan_WorkFlowCancelar', function () {
        Spartan_WorkFlowBackToGrid();
    });
	$("form#CreateSpartan_WorkFlow").on('click', '#Spartan_WorkFlowGuardar', function () {
	    $('.loading').css('display', 'block');
	    if (EjecutarValidacionesAntesDeGuardar()) {
	        if (CheckValidation())
	            SendSpartan_WorkFlowData(function () {
	                EjecutarValidacionesDespuesDeGuardar();
	                Spartan_WorkFlowBackToGrid();
	            });
	        else
	        {
	            $('.loading').css('display', 'none');
	        }
	    }
	    else {
	        $('.loading').css('display', 'none');
	    }
    });
	$("form#CreateSpartan_WorkFlow").on('click', '#Spartan_WorkFlowGuardarYNuevo', function () {
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation()) {
				SendSpartan_WorkFlowData(function () {
					ClearControls();
					ClearAttachmentsDiv();
					ResetClaveLabel();
	                getSpartan_WorkFlow_PhasesData();
                getSpartan_WorkFlow_StateData();
                getSpartan_WorkFlow_Conditions_by_StateData();
                getSpartan_WorkFlow_Information_by_StateData();
                getSpartan_WorkFlow_Roles_by_StateData();
                getSpartan_WorkFlow_Matrix_of_StatesData();

					EjecutarValidacionesDespuesDeGuardar();					
			setIsNew();
			EjecutarValidacionesAlComienzo();
				});
			}
		}
    });
    $("form#CreateSpartan_WorkFlow").on('click', '#Spartan_WorkFlowGuardarYCopia', function () {
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendSpartan_WorkFlowData(function (currentId) {
					$("#WorkFlowIdId").val("0");
	    $('#Object').empty();
    $("#Object").append('<option value=""></option>');
    $('#Object').val('0').trigger('change');
                Spartan_WorkFlow_PhasesClearGridData();
                Spartan_WorkFlow_StateClearGridData();
                Spartan_WorkFlow_Conditions_by_StateClearGridData();
                Spartan_WorkFlow_Information_by_StateClearGridData();
                Spartan_WorkFlow_Roles_by_StateClearGridData();
                Spartan_WorkFlow_Matrix_of_StatesClearGridData();

					ResetClaveLabel();
					$("#ReferenceWorkFlowId").val(currentId);
	                getSpartan_WorkFlow_PhasesData();
                getSpartan_WorkFlow_StateData();
                getSpartan_WorkFlow_Conditions_by_StateData();
                getSpartan_WorkFlow_Information_by_StateData();
                getSpartan_WorkFlow_Roles_by_StateData();
                getSpartan_WorkFlow_Matrix_of_StatesData();

					EjecutarValidacionesDespuesDeGuardar();					
			setIsNew();
				});
		}
    });
});

function setIsNew() {
    $('#hdnIsNew').val("True");
	$('#Operation').val("New");
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
    debugger;
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


var Spartan_WorkFlowisdisplayBusinessPropery = false;
Spartan_WorkFlowDisplayBusinessRuleButtons(Spartan_WorkFlowisdisplayBusinessPropery);
function Spartan_WorkFlowDisplayBusinessRule() {
    if (!Spartan_WorkFlowisdisplayBusinessPropery) {
        $('#CreateSpartan_WorkFlow').find('.col-sm-8').each(function () {
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = $(this).data('field-id');
            var fieldName = $(this).data('field-name');
            var attribute = $(this).data('attribute');
            mainElementAttributes += '<div class="Spartan_WorkFlowdisplayBusinessPropery"><button type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#Spartan_WorkFlowPropertyBusinessModal-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.Spartan_WorkFlowdisplayBusinessPropery').remove();
    }
    Spartan_WorkFlowDisplayBusinessRuleButtons(!Spartan_WorkFlowisdisplayBusinessPropery);
    Spartan_WorkFlowisdisplayBusinessPropery = (Spartan_WorkFlowisdisplayBusinessPropery ? false : true);
}
function Spartan_WorkFlowDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}

