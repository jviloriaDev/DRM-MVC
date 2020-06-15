

//Begin Declarations for Foreigns fields for Spartan_Report_Fields_Detail MultiRow
var Spartan_Report_Fields_DetailcountRowsChecked = 0;
function GetSpartan_Report_Fields_Detail_Spartan_Report_FunctionName(Id) {
    for (var i = 0; i < Spartan_Report_Fields_Detail_Spartan_Report_FunctionItems.length; i++) {
        if (Spartan_Report_Fields_Detail_Spartan_Report_FunctionItems[i].FunctionId == Id) {
            return Spartan_Report_Fields_Detail_Spartan_Report_FunctionItems[i].Description;
        }
    }
    return "";
}

function GetSpartan_Report_Fields_Detail_Spartan_Report_FunctionDropDown() {
    var Spartan_Report_Fields_Detail_Spartan_Report_FunctionDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_Report_Fields_Detail_Spartan_Report_FunctionDropdown);
    if(Spartan_Report_Fields_Detail_Spartan_Report_FunctionItems != null)
    {
       for (var i = 0; i < Spartan_Report_Fields_Detail_Spartan_Report_FunctionItems.length; i++) {
           $('<option />', { value: Spartan_Report_Fields_Detail_Spartan_Report_FunctionItems[i].FunctionId, text:    Spartan_Report_Fields_Detail_Spartan_Report_FunctionItems[i].Description }).appendTo(Spartan_Report_Fields_Detail_Spartan_Report_FunctionDropdown);
       }
    }
    return Spartan_Report_Fields_Detail_Spartan_Report_FunctionDropdown;
}
function GetSpartan_Report_Fields_Detail_Spartan_Report_FormatName(Id) {
    for (var i = 0; i < Spartan_Report_Fields_Detail_Spartan_Report_FormatItems.length; i++) {
        if (Spartan_Report_Fields_Detail_Spartan_Report_FormatItems[i].FormatId == Id) {
            return Spartan_Report_Fields_Detail_Spartan_Report_FormatItems[i].Description;
        }
    }
    return "";
}

function GetSpartan_Report_Fields_Detail_Spartan_Report_FormatDropDown() {
    var Spartan_Report_Fields_Detail_Spartan_Report_FormatDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_Report_Fields_Detail_Spartan_Report_FormatDropdown);
    if(Spartan_Report_Fields_Detail_Spartan_Report_FormatItems != null)
    {
       for (var i = 0; i < Spartan_Report_Fields_Detail_Spartan_Report_FormatItems.length; i++) {
           $('<option />', { value: Spartan_Report_Fields_Detail_Spartan_Report_FormatItems[i].FormatId, text:    Spartan_Report_Fields_Detail_Spartan_Report_FormatItems[i].Description }).appendTo(Spartan_Report_Fields_Detail_Spartan_Report_FormatDropdown);
       }
    }
    return Spartan_Report_Fields_Detail_Spartan_Report_FormatDropdown;
}
function GetSpartan_Report_Fields_Detail_Spartan_Report_Order_TypeName(Id) {
    for (var i = 0; i < Spartan_Report_Fields_Detail_Spartan_Report_Order_TypeItems.length; i++) {
        if (Spartan_Report_Fields_Detail_Spartan_Report_Order_TypeItems[i].OrderTypeId == Id) {
            return Spartan_Report_Fields_Detail_Spartan_Report_Order_TypeItems[i].Description;
        }
    }
    return "";
}

function GetSpartan_Report_Fields_Detail_Spartan_Report_Order_TypeDropDown() {
    var Spartan_Report_Fields_Detail_Spartan_Report_Order_TypeDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_Report_Fields_Detail_Spartan_Report_Order_TypeDropdown);
    if(Spartan_Report_Fields_Detail_Spartan_Report_Order_TypeItems != null)
    {
       for (var i = 0; i < Spartan_Report_Fields_Detail_Spartan_Report_Order_TypeItems.length; i++) {
           $('<option />', { value: Spartan_Report_Fields_Detail_Spartan_Report_Order_TypeItems[i].OrderTypeId, text:    Spartan_Report_Fields_Detail_Spartan_Report_Order_TypeItems[i].Description }).appendTo(Spartan_Report_Fields_Detail_Spartan_Report_Order_TypeDropdown);
       }
    }
    return Spartan_Report_Fields_Detail_Spartan_Report_Order_TypeDropdown;
}
function GetSpartan_Report_Fields_Detail_Spartan_Report_Field_TypeName(Id) {
    for (var i = 0; i < Spartan_Report_Fields_Detail_Spartan_Report_Field_TypeItems.length; i++) {
        if (Spartan_Report_Fields_Detail_Spartan_Report_Field_TypeItems[i].FieldTypeId == Id) {
            return Spartan_Report_Fields_Detail_Spartan_Report_Field_TypeItems[i].Description;
        }
    }
    return "";
}

function GetSpartan_Report_Fields_Detail_Spartan_Report_Field_TypeDropDown() {
    var Spartan_Report_Fields_Detail_Spartan_Report_Field_TypeDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_Report_Fields_Detail_Spartan_Report_Field_TypeDropdown);
    if(Spartan_Report_Fields_Detail_Spartan_Report_Field_TypeItems != null)
    {
       for (var i = 0; i < Spartan_Report_Fields_Detail_Spartan_Report_Field_TypeItems.length; i++) {
           $('<option />', { value: Spartan_Report_Fields_Detail_Spartan_Report_Field_TypeItems[i].FieldTypeId, text:    Spartan_Report_Fields_Detail_Spartan_Report_Field_TypeItems[i].Description }).appendTo(Spartan_Report_Fields_Detail_Spartan_Report_Field_TypeDropdown);
       }
    }
    return Spartan_Report_Fields_Detail_Spartan_Report_Field_TypeDropdown;
}
function GetSpartan_Report_Fields_Detail_Spartan_MetadataName(Id) {
    for (var i = 0; i < Spartan_Report_Fields_Detail_Spartan_MetadataItems.length; i++) {
        if (Spartan_Report_Fields_Detail_Spartan_MetadataItems[i].AttributeId == Id) {
            return Spartan_Report_Fields_Detail_Spartan_MetadataItems[i].Logical_Name;
        }
    }
    return "";
}

function GetSpartan_Report_Fields_Detail_Spartan_MetadataDropDown() {
    var Spartan_Report_Fields_Detail_Spartan_MetadataDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_Report_Fields_Detail_Spartan_MetadataDropdown);
    if(Spartan_Report_Fields_Detail_Spartan_MetadataItems != null)
    {
       for (var i = 0; i < Spartan_Report_Fields_Detail_Spartan_MetadataItems.length; i++) {
           $('<option />', { value: Spartan_Report_Fields_Detail_Spartan_MetadataItems[i].AttributeId, text:    Spartan_Report_Fields_Detail_Spartan_MetadataItems[i].Logical_Name }).appendTo(Spartan_Report_Fields_Detail_Spartan_MetadataDropdown);
       }
    }
    return Spartan_Report_Fields_Detail_Spartan_MetadataDropdown;
}


function GetInsertSpartan_Report_Fields_DetailRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $($.parseHTML(inputData)).addClass('Spartan_Report_Fields_Detail_PathField PathField').attr('id', 'Spartan_Report_Fields_Detail_PathField_' + index).attr('data-field', 'PathField');
    columnData[1] = $($.parseHTML(inputData)).addClass('Spartan_Report_Fields_Detail_Physical_Name Physical_Name').attr('id', 'Spartan_Report_Fields_Detail_Physical_Name_' + index).attr('data-field', 'Physical_Name');
    columnData[2] = $($.parseHTML(inputData)).addClass('Spartan_Report_Fields_Detail_Title Title').attr('id', 'Spartan_Report_Fields_Detail_Title_' + index).attr('data-field', 'Title');
    columnData[3] = $(GetSpartan_Report_Fields_Detail_Spartan_Report_FunctionDropDown()).addClass('Spartan_Report_Fields_Detail_Function Function').attr('id', 'Spartan_Report_Fields_Detail_Function_' + index).attr('data-field', 'Function');
    columnData[4] = $(GetSpartan_Report_Fields_Detail_Spartan_Report_FormatDropDown()).addClass('Spartan_Report_Fields_Detail_Format Format').attr('id', 'Spartan_Report_Fields_Detail_Format_' + index).attr('data-field', 'Format');
    columnData[5] = $(GetSpartan_Report_Fields_Detail_Spartan_Report_Order_TypeDropDown()).addClass('Spartan_Report_Fields_Detail_Order_Type Order_Type').attr('id', 'Spartan_Report_Fields_Detail_Order_Type_' + index).attr('data-field', 'Order_Type');
    columnData[6] = $(GetSpartan_Report_Fields_Detail_Spartan_Report_Field_TypeDropDown()).addClass('Spartan_Report_Fields_Detail_Field_Type Field_Type').attr('id', 'Spartan_Report_Fields_Detail_Field_Type_' + index).attr('data-field', 'Field_Type');
    columnData[7] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Spartan_Report_Fields_Detail_Order_Number Order_Number').attr('id', 'Spartan_Report_Fields_Detail_Order_Number_' + index).attr('data-field', 'Order_Number');
    columnData[8] = $(GetSpartan_Report_Fields_Detail_Spartan_MetadataDropDown()).addClass('Spartan_Report_Fields_Detail_AttributeId AttributeId').attr('id', 'Spartan_Report_Fields_Detail_AttributeId_' + index).attr('data-field', 'AttributeId');


    initiateUIControls();
    return columnData;
}

function Spartan_Report_Fields_DetailInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRSpartan_Report_Fields_Detail("Spartan_Report_Fields_Detail_", "_" + rowIndex)) {
    var nameOfGrid = 'Spartan_Report_Fields_Detail';
    var prevData = Spartan_Report_Fields_DetailTable.fnGetData(rowIndex);
    var data = Spartan_Report_Fields_DetailTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        DesignDetailId: prevData.DesignDetailId,
        IsInsertRow: false
        ,PathField: ($('#' + nameOfGrid + 'Grid .PathFieldHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Physical_Name: ($('#' + nameOfGrid + 'Grid .Physical_NameHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Title: ($('#' + nameOfGrid + 'Grid .TitleHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Function: ($('#' + nameOfGrid + 'Grid .FunctionHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Format: ($('#' + nameOfGrid + 'Grid .FormatHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Order_Type: ($('#' + nameOfGrid + 'Grid .Order_TypeHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Field_Type: ($('#' + nameOfGrid + 'Grid .Field_TypeHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Order_Number: ($('#' + nameOfGrid + 'Grid .Order_NumberHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,AttributeId: ($('#' + nameOfGrid + 'Grid .AttributeIdHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''

    }
    Spartan_Report_Fields_DetailTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_Report_Fields_DetailrowCreationGrid(data, newData, rowIndex);
    Spartan_Report_Fields_DetailcountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRSpartan_Report_Fields_Detail("Spartan_Report_Fields_Detail_", "_" + rowIndex);
  }
}

function Spartan_Report_Fields_DetailCancelRow(rowIndex) {
    var prevData = Spartan_Report_Fields_DetailTable.fnGetData(rowIndex);
    var data = Spartan_Report_Fields_DetailTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Spartan_Report_Fields_DetailTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Spartan_Report_Fields_DetailrowCreationGrid(data, prevData, rowIndex);
    }
	showSpartan_Report_Fields_DetailGrid(Spartan_Report_Fields_DetailTable.fnGetData());
    Spartan_Report_Fields_DetailcountRowsChecked--;
}

function GetSpartan_Report_Fields_DetailFromDataTable() {
    var Spartan_Report_Fields_DetailData = [];
    var gridData = [];//Spartan_Report_Fields_DetailTable.fnGetData();
    if (FieldsInMemory.length != 0)
    {
        for (var i = 0; i < FieldsInMemory.length; i++) {
            var IsInsert = false;
            if (FieldsInMemory[i].fieldId == 0)
                IsInsert = false;
            var data = {
                Physical_Name: FieldsInMemory[i].physicalName,
                DesignDetailId: FieldsInMemory[i].fieldId,
                Function: FieldsInMemory[i].functionF,
                Format: FieldsInMemory[i].format,
                Order_Type: FieldsInMemory[i].orderBy,
                Order_Number: FieldsInMemory[i].orderNumber,
                PathField: FieldsInMemory[i].fieldPath,
                Field_Type: FieldsInMemory[i].fieldType,
                AttributeId: FieldsInMemory[i].attributeId,
                Title: FieldsInMemory[i].title,
                IsInsertRow: IsInsert
            };
            gridData.push(data);
        }
    }
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Spartan_Report_Fields_DetailData.push({
                DesignDetailId: gridData[i].DesignDetailId
                ,PathField: gridData[i].PathField
                ,Physical_Name: gridData[i].Physical_Name
                ,Title: gridData[i].Title
                ,Function: gridData[i].Function
                ,Format: gridData[i].Format
                ,Order_Type: gridData[i].Order_Type
                ,Field_Type: gridData[i].Field_Type
                ,Order_Number: gridData[i].Order_Number
                ,AttributeId: gridData[i].AttributeId

                ,Removed: false
            });
    }

    for (i = 0; i < removedSpartan_Report_Fields_DetailData.length; i++) {
        if (removedSpartan_Report_Fields_DetailData[i] != null && removedSpartan_Report_Fields_DetailData[i].DesignDetailId > 0)
            Spartan_Report_Fields_DetailData.push({
                DesignDetailId: removedSpartan_Report_Fields_DetailData[i].DesignDetailId
                ,PathField: removedSpartan_Report_Fields_DetailData[i].PathField
                ,Physical_Name: removedSpartan_Report_Fields_DetailData[i].Physical_Name
                ,Title: removedSpartan_Report_Fields_DetailData[i].Title
                ,Function: removedSpartan_Report_Fields_DetailData[i].Function
                ,Format: removedSpartan_Report_Fields_DetailData[i].Format
                ,Order_Type: removedSpartan_Report_Fields_DetailData[i].Order_Type
                ,Field_Type: removedSpartan_Report_Fields_DetailData[i].Field_Type
                ,Order_Number: removedSpartan_Report_Fields_DetailData[i].Order_Number
                ,AttributeId: removedSpartan_Report_Fields_DetailData[i].AttributeId

                , Removed: true
            });
    }	

    return Spartan_Report_Fields_DetailData;
}

function Spartan_Report_Fields_DetailEditRow(rowIndex, currentRow) {
    var rowIndexTable = (currentRow) ? Spartan_Report_Fields_DetailTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Spartan_Report_Fields_DetailcountRowsChecked++;
    var Spartan_Report_Fields_DetailRowElement = "Spartan_Report_Fields_Detail_" + rowIndex.toString();
    var prevData = Spartan_Report_Fields_DetailTable.fnGetData(rowIndexTable );
    var row = Spartan_Report_Fields_DetailTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Spartan_Report_Fields_Detail_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Spartan_Report_Fields_DetailGetUpdateRowControls(prevData, "Spartan_Report_Fields_Detail_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Spartan_Report_Fields_DetailRowElement + "')){ Spartan_Report_Fields_DetailInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Spartan_Report_Fields_DetailCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
        if ($('#Spartan_Report_Fields_DetailGrid .' + idHeader).css('display') != 'none') {
            $(controls[i]).appendTo($('<td id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));
        }
    }
    $('.Spartan_Report_Fields_Detail' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    initiateUIControls();
    EjecutarValidacionesNewRowMRSpartan_Report_Fields_Detail(nameOfTable, rowIndexFormed);
	EjecutarValidacionesEditRowMRSpartan_Report_Fields_Detail(nameOfTable, rowIndexFormed);
}

function Spartan_Report_Fields_DetailfnOpenAddRowPopUp() {
    var currentRowIndex = Spartan_Report_Fields_DetailTable.fnGetData().length;
    Spartan_Report_Fields_DetailfnClickAddRow();
    GetAddSpartan_Report_Fields_DetailPopup(currentRowIndex, 0);
}

function Spartan_Report_Fields_DetailEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Spartan_Report_Fields_DetailTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Spartan_Report_Fields_DetailRowElement = "Spartan_Report_Fields_Detail_" + rowIndex.toString();
    var prevData = Spartan_Report_Fields_DetailTable.fnGetData(rowIndexTable);
    GetAddSpartan_Report_Fields_DetailPopup(rowIndex, 1, prevData.DesignDetailId);
    $('#Spartan_Report_Fields_DetailPathField').val(prevData.PathField);
    $('#Spartan_Report_Fields_DetailPhysical_Name').val(prevData.Physical_Name);
    $('#Spartan_Report_Fields_DetailTitle').val(prevData.Title);
    $('#Spartan_Report_Fields_DetailFunction').val(prevData.Function);
    $('#Spartan_Report_Fields_DetailFormat').val(prevData.Format);
    $('#Spartan_Report_Fields_DetailOrder_Type').val(prevData.Order_Type);
    $('#Spartan_Report_Fields_DetailField_Type').val(prevData.Field_Type);
    $('#Spartan_Report_Fields_DetailOrder_Number').val(prevData.Order_Number);
    $('#Spartan_Report_Fields_DetailAttributeId').val(prevData.AttributeId);

    initiateUIControls();

}

function Spartan_Report_Fields_DetailAddInsertRow() {
    if (Spartan_Report_Fields_DetailinsertRowCurrentIndex < 1)
    {
        Spartan_Report_Fields_DetailinsertRowCurrentIndex = 1;
    }
    return {
        DesignDetailId: null,
        IsInsertRow: true
        ,PathField: ""
        ,Physical_Name: ""
        ,Title: ""
        ,Function: ""
        ,Format: ""
        ,Order_Type: ""
        ,Field_Type: ""
        ,Order_Number: ""
        ,AttributeId: ""

    }
}

function Spartan_Report_Fields_DetailfnClickAddRow() {
    Spartan_Report_Fields_DetailcountRowsChecked++;
    Spartan_Report_Fields_DetailTable.fnAddData(Spartan_Report_Fields_DetailAddInsertRow(), true);
    Spartan_Report_Fields_DetailTable.fnPageChange('last');
    initiateUIControls();
    EjecutarValidacionesNewRowMRSpartan_Report_Fields_Detail("Spartan_Report_Fields_Detail_", "_" + Spartan_Report_Fields_DetailinsertRowCurrentIndex);
}

function Spartan_Report_Fields_DetailClearGridData() {
    Spartan_Report_Fields_DetailData = [];
    Spartan_Report_Fields_DetaildeletedItem = [];
    Spartan_Report_Fields_DetailDataMain = [];
    Spartan_Report_Fields_DetailDataMainPages = [];
    Spartan_Report_Fields_DetailnewItemCount = 0;
    Spartan_Report_Fields_DetailmaxItemIndex = 0;
    $("#Spartan_Report_Fields_DetailGrid").DataTable().clear();
    $("#Spartan_Report_Fields_DetailGrid").DataTable().destroy();
}

//Used to Get Spartan Report Information
function GetSpartan_Report_Fields_Detail() {
    var form_data = new FormData();
    for (var i = 0; i < Spartan_Report_Fields_DetailData.length; i++) {
        form_data.append('[' + i + '].DesignDetailId', Spartan_Report_Fields_DetailData[i].DesignDetailId);
        form_data.append('[' + i + '].PathField', Spartan_Report_Fields_DetailData[i].PathField);
        form_data.append('[' + i + '].Physical_Name', Spartan_Report_Fields_DetailData[i].Physical_Name);
        form_data.append('[' + i + '].Title', Spartan_Report_Fields_DetailData[i].Title);
        form_data.append('[' + i + '].Function', Spartan_Report_Fields_DetailData[i].Function);
        form_data.append('[' + i + '].Format', Spartan_Report_Fields_DetailData[i].Format);
        form_data.append('[' + i + '].Order_Type', Spartan_Report_Fields_DetailData[i].Order_Type);
        form_data.append('[' + i + '].Field_Type', Spartan_Report_Fields_DetailData[i].Field_Type);
        form_data.append('[' + i + '].Order_Number', Spartan_Report_Fields_DetailData[i].Order_Number);
        form_data.append('[' + i + '].AttributeId', Spartan_Report_Fields_DetailData[i].AttributeId);

        form_data.append('[' + i + '].Removed', Spartan_Report_Fields_DetailData[i].Removed);
    }
    return form_data;
}
function Spartan_Report_Fields_DetailInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRSpartan_Report_Fields_Detail("Spartan_Report_Fields_DetailTable", rowIndex)) {
    var prevData = Spartan_Report_Fields_DetailTable.fnGetData(rowIndex);
    var data = Spartan_Report_Fields_DetailTable.fnGetNodes(rowIndex);
    var newData = {
        DesignDetailId: prevData.DesignDetailId,
        IsInsertRow: false
        ,PathField: $('#Spartan_Report_Fields_DetailPathField').val()
        ,Physical_Name: $('#Spartan_Report_Fields_DetailPhysical_Name').val()
        ,Title: $('#Spartan_Report_Fields_DetailTitle').val()
        ,Function: $('#Spartan_Report_Fields_DetailFunction').val()
        ,Format: $('#Spartan_Report_Fields_DetailFormat').val()
        ,Order_Type: $('#Spartan_Report_Fields_DetailOrder_Type').val()
        ,Field_Type: $('#Spartan_Report_Fields_DetailField_Type').val()
        ,Order_Number: $('#Spartan_Report_Fields_DetailOrder_Number').val()

        ,AttributeId: $('#Spartan_Report_Fields_DetailAttributeId').val()

    }

    Spartan_Report_Fields_DetailTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_Report_Fields_DetailrowCreationGrid(data, newData, rowIndex);
    $('#AddSpartan_Report_Fields_Detail-form').modal({ show: false });
    $('#AddSpartan_Report_Fields_Detail-form').modal('hide');
    Spartan_Report_Fields_DetailEditRow(rowIndex);
    Spartan_Report_Fields_DetailInsertRow(rowIndex);
    //}
}
function Spartan_Report_Fields_DetailRemoveAddRow(rowIndex) {
    Spartan_Report_Fields_DetailTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Spartan_Report_Fields_Detail MultiRow
//Begin Declarations for Foreigns fields for Spartan_Report_Filter MultiRow
var Spartan_Report_FiltercountRowsChecked = 0;
function GetSpartan_Report_Filter_Spartan_MetadataName(Id) {
    for (var i = 0; i < Spartan_Report_Filter_Spartan_MetadataItems.length; i++) {
        if (Spartan_Report_Filter_Spartan_MetadataItems[i].AttributeId == Id) {
            return Spartan_Report_Filter_Spartan_MetadataItems[i].Logical_Name;
        }
    }
    return "";
}

function GetSpartan_Report_Filter_Spartan_MetadataDropDown() {
    var Spartan_Report_Filter_Spartan_MetadataDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_Report_Filter_Spartan_MetadataDropdown);
    if(Spartan_Report_Filter_Spartan_MetadataItems != null)
    {
       for (var i = 0; i < Spartan_Report_Filter_Spartan_MetadataItems.length; i++) {
           $('<option />', { value: Spartan_Report_Filter_Spartan_MetadataItems[i].AttributeId, text:    Spartan_Report_Filter_Spartan_MetadataItems[i].Logical_Name }).appendTo(Spartan_Report_Filter_Spartan_MetadataDropdown);
       }
    }
    return Spartan_Report_Filter_Spartan_MetadataDropdown;
}


function GetInsertSpartan_Report_FilterRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $(GetSpartan_Report_Filter_Spartan_MetadataDropDown()).addClass('Spartan_Report_Filter_Field Field').attr('id', 'Spartan_Report_Filter_Field_' + index).attr('data-field', 'Field');
    columnData[1] = $($.parseHTML(GetGridCheckBox())).addClass('Spartan_Report_Filter_QuickFilter QuickFilter').attr('id', 'Spartan_Report_Filter_QuickFilter_' + index).attr('data-field', 'QuickFilter');
    //columnData[2] = $($.parseHTML(GetGridCheckBox())).addClass('Spartan_Report_Filter_AdvanceFilter AdvanceFilter').attr('id', 'Spartan_Report_Filter_AdvanceFilter_' + index).attr('data-field', 'AdvanceFilter');


    initiateUIControls();
    return columnData;
}

function Spartan_Report_FilterInsertRow(rowIndex) {
    var nameOfGrid = 'Spartan_Report_Filter';
    var prevData = Spartan_Report_FilterTable.fnGetData(rowIndex);
    var data = Spartan_Report_FilterTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        ReportFilterId: prevData.ReportFilterId,
        IsInsertRow: false
        ,Field: ($('#' + nameOfGrid + 'Grid .FieldHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,QuickFilter: ($('#' + nameOfGrid + 'Grid .QuickFilterHeader').css('display') != 'none') ? $(data.childNodes[counter++].childNodes[1]).is(':checked') : ''
        //,AdvanceFilter: ($('#' + nameOfGrid + 'Grid .AdvanceFilterHeader').css('display') != 'none') ? $(data.childNodes[counter++].childNodes[1]).is(':checked') : ''

    }
    Spartan_Report_FilterTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_Report_FilterrowCreationGrid(data, newData, rowIndex);
    Spartan_Report_FiltercountRowsChecked--;	
}

function Spartan_Report_FilterCancelRow(rowIndex) {
    var prevData = Spartan_Report_FilterTable.fnGetData(rowIndex);
    var data = Spartan_Report_FilterTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Spartan_Report_FilterTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Spartan_Report_FilterrowCreationGrid(data, prevData, rowIndex);
    }
	showSpartan_Report_FilterGrid(Spartan_Report_FilterTable.fnGetData());
    Spartan_Report_FiltercountRowsChecked--;
}

function GetSpartan_Report_FilterFromDataTable() {
    var Spartan_Report_FilterData = [];
    var gridData = Spartan_Report_FilterTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Spartan_Report_FilterData.push({
                ReportFilterId: gridData[i].ReportFilterId
                ,Field: gridData[i].Field
                ,QuickFilter: gridData[i].QuickFilter
                //,AdvanceFilter: gridData[i].AdvanceFilter

                ,Removed: false
            });
    }

    for (i = 0; i < removedSpartan_Report_FilterData.length; i++) {
        if (removedSpartan_Report_FilterData[i] != null && removedSpartan_Report_FilterData[i].ReportFilterId > 0)
            Spartan_Report_FilterData.push({
                ReportFilterId: removedSpartan_Report_FilterData[i].ReportFilterId
                ,Field: removedSpartan_Report_FilterData[i].Field
                ,QuickFilter: removedSpartan_Report_FilterData[i].QuickFilter
                //,AdvanceFilter: removedSpartan_Report_FilterData[i].AdvanceFilter

                , Removed: true
            });
    }	

    return Spartan_Report_FilterData;
}

function Spartan_Report_FilterEditRow(rowIndex, currentRow) {
    var rowIndexTable = (currentRow) ? Spartan_Report_FilterTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Spartan_Report_FiltercountRowsChecked++;
    var Spartan_Report_FilterRowElement = "Spartan_Report_Filter_" + rowIndex.toString();
    var prevData = Spartan_Report_FilterTable.fnGetData(rowIndexTable );
    var row = Spartan_Report_FilterTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Spartan_Report_Filter_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Spartan_Report_FilterGetUpdateRowControls(prevData, "Spartan_Report_Filter_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Spartan_Report_FilterRowElement + "')){ Spartan_Report_FilterInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Spartan_Report_FilterCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
        if ($('#Spartan_Report_FilterGrid .' + idHeader).css('display') != 'none') {
            $(controls[i]).appendTo($('<td id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));
        }
    }
    $('.Spartan_Report_Filter' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    initiateUIControls();
    EjecutarValidacionesNewRowMRSpartan_Report_Filter(nameOfTable, rowIndexFormed);
	EjecutarValidacionesEditRowMRSpartan_Report_Filter(nameOfTable, rowIndexFormed);
}

function Spartan_Report_FilterfnOpenAddRowPopUp() {
    var currentRowIndex = Spartan_Report_FilterTable.fnGetData().length;
    Spartan_Report_FilterfnClickAddRow();
    GetAddSpartan_Report_FilterPopup(currentRowIndex, 0);
}

function Spartan_Report_FilterEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Spartan_Report_FilterTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Spartan_Report_FilterRowElement = "Spartan_Report_Filter_" + rowIndex.toString();
    var prevData = Spartan_Report_FilterTable.fnGetData(rowIndexTable);
    GetAddSpartan_Report_FilterPopup(rowIndex, 1, prevData.ReportFilterId);
    $('#Spartan_Report_FilterField').val(prevData.Field);
    $('#Spartan_Report_FilterQuickFilter').prop('checked', prevData.QuickFilter);
    //$('#Spartan_Report_FilterAdvanceFilter').prop('checked', prevData.AdvanceFilter);

    initiateUIControls();

}

function Spartan_Report_FilterAddInsertRow() {
    if (Spartan_Report_FilterinsertRowCurrentIndex < 1)
    {
        Spartan_Report_FilterinsertRowCurrentIndex = 1;
    }
    return {
        ReportFilterId: null,
        IsInsertRow: true
        ,Field: ""
        ,QuickFilter: ""
        //,AdvanceFilter: ""

    }
}

function Spartan_Report_FilterfnClickAddRow() {
    Spartan_Report_FiltercountRowsChecked++;
    Spartan_Report_FilterTable.fnAddData(Spartan_Report_FilterAddInsertRow(), true);
    Spartan_Report_FilterTable.fnPageChange('last');
    initiateUIControls();
    EjecutarValidacionesNewRowMRSpartan_Report_Filter("Spartan_Report_Filter_", "_" + Spartan_Report_FilterinsertRowCurrentIndex);
}

function Spartan_Report_FilterClearGridData() {
    Spartan_Report_FilterData = [];
    Spartan_Report_FilterdeletedItem = [];
    Spartan_Report_FilterDataMain = [];
    Spartan_Report_FilterDataMainPages = [];
    Spartan_Report_FilternewItemCount = 0;
    Spartan_Report_FiltermaxItemIndex = 0;
    $("#Spartan_Report_FilterGrid").DataTable().clear();
    $("#Spartan_Report_FilterGrid").DataTable().destroy();
}

//Used to Get Spartan Report Information
function GetSpartan_Report_Filter() {
    var form_data = new FormData();
    for (var i = 0; i < Spartan_Report_FilterData.length; i++) {
        form_data.append('[' + i + '].ReportFilterId', Spartan_Report_FilterData[i].ReportFilterId);
        form_data.append('[' + i + '].Field', Spartan_Report_FilterData[i].Field);
        form_data.append('[' + i + '].QuickFilter', Spartan_Report_FilterData[i].QuickFilter);
        //form_data.append('[' + i + '].AdvanceFilter', Spartan_Report_FilterData[i].AdvanceFilter);

        form_data.append('[' + i + '].Removed', Spartan_Report_FilterData[i].Removed);
    }
    return form_data;
}
function Spartan_Report_FilterInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRSpartan_Report_Filter("Spartan_Report_FilterTable", rowIndex)) {
    var prevData = Spartan_Report_FilterTable.fnGetData(rowIndex);
    var data = Spartan_Report_FilterTable.fnGetNodes(rowIndex);
    var newData = {
        ReportFilterId: prevData.ReportFilterId,
        IsInsertRow: false
        ,Field: $('#Spartan_Report_FilterField').val()
        ,QuickFilter: $('#Spartan_Report_FilterQuickFilter').is(':checked')
        //,AdvanceFilter: $('#Spartan_Report_FilterAdvanceFilter').is(':checked')

    }

    Spartan_Report_FilterTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_Report_FilterrowCreationGrid(data, newData, rowIndex);
    $('#AddSpartan_Report_Filter-form').modal({ show: false });
    $('#AddSpartan_Report_Filter-form').modal('hide');
    Spartan_Report_FilterEditRow(rowIndex);
    Spartan_Report_FilterInsertRow(rowIndex);
    //}
}
function Spartan_Report_FilterRemoveAddRow(rowIndex) {
    Spartan_Report_FilterTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Spartan_Report_Filter MultiRow


$(function () {
    function Spartan_Report_Fields_DetailinitializeMainArray(totalCount) {
        if (Spartan_Report_Fields_DetailDataMain.length != totalCount && !Spartan_Report_Fields_DetailDataMainInitialized) {
            Spartan_Report_Fields_DetailDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Spartan_Report_Fields_DetailDataMain[i] = null;
            }
        }
    }
    function Spartan_Report_Fields_DetailremoveFromMainArray() {
        for (var j = 0; j < Spartan_Report_Fields_DetaildeletedItem.length; j++) {
            for (var i = 0; i < Spartan_Report_Fields_DetailDataMain.length; i++) {
                if (Spartan_Report_Fields_DetailDataMain[i] != null && Spartan_Report_Fields_DetailDataMain[i].Id == Spartan_Report_Fields_DetaildeletedItem[j]) {
                    hSpartan_Report_Fields_DetailDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Spartan_Report_Fields_DetailcopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Spartan_Report_Fields_DetailDataMain.length; i++) {
            data[i] = Spartan_Report_Fields_DetailDataMain[i];

        }
        return data;
    }
    function Spartan_Report_Fields_DetailgetNewResult() {
        var newData = copyMainSpartan_Report_Fields_DetailArray();

        for (var i = 0; i < Spartan_Report_Fields_DetailData.length; i++) {
            if (Spartan_Report_Fields_DetailData[i].Removed == null || Spartan_Report_Fields_DetailData[i].Removed == false) {
                newData.splice(0, 0, Spartan_Report_Fields_DetailData[i]);
            }
        }
        return newData;
    }
    function Spartan_Report_Fields_DetailpushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Spartan_Report_Fields_DetailDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Spartan_Report_Fields_DetailDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Spartan_Report_FilterinitializeMainArray(totalCount) {
        if (Spartan_Report_FilterDataMain.length != totalCount && !Spartan_Report_FilterDataMainInitialized) {
            Spartan_Report_FilterDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Spartan_Report_FilterDataMain[i] = null;
            }
        }
    }
    function Spartan_Report_FilterremoveFromMainArray() {
        for (var j = 0; j < Spartan_Report_FilterdeletedItem.length; j++) {
            for (var i = 0; i < Spartan_Report_FilterDataMain.length; i++) {
                if (Spartan_Report_FilterDataMain[i] != null && Spartan_Report_FilterDataMain[i].Id == Spartan_Report_FilterdeletedItem[j]) {
                    hSpartan_Report_FilterDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Spartan_Report_FiltercopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Spartan_Report_FilterDataMain.length; i++) {
            data[i] = Spartan_Report_FilterDataMain[i];

        }
        return data;
    }
    function Spartan_Report_FiltergetNewResult() {
        var newData = copyMainSpartan_Report_FilterArray();

        for (var i = 0; i < Spartan_Report_FilterData.length; i++) {
            if (Spartan_Report_FilterData[i].Removed == null || Spartan_Report_FilterData[i].Removed == false) {
                newData.splice(0, 0, Spartan_Report_FilterData[i]);
            }
        }
        return newData;
    }
    function Spartan_Report_FilterpushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Spartan_Report_FilterDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Spartan_Report_FilterDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }

});

//Grid GetAutocomplete

//Grid GetAutocomplete



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
    $("#ReferenceReportId").val("0");
    $('#CreateSpartan_Report')[0].reset();
    ClearFormControls();
    $("#ReportIdId").val("0");
                Spartan_Report_Fields_DetailClearGridData();
                Spartan_Report_FilterClearGridData();

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreateSpartan_Report').trigger('reset');
    $('#CreateSpartan_Report').find(':input').each(function () {
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
    var $myForm = $('#CreateSpartan_Report');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblReportId").text("0");
}
$(document).ready(function () {
    $("form#CreateSpartan_Report").submit(function (e) {
        e.preventDefault();
        return false;
    });
	$("form#CreateSpartan_Report").on('click', '#Spartan_ReportCancelar', function () {
        Spartan_ReportBackToGrid();
    });
	$("form#CreateSpartan_Report").on('click', '#Spartan_ReportGuardar', function () {
        if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendSpartan_ReportData(function () {
					EjecutarValidacionesDespuesDeGuardar();
					Spartan_ReportBackToGrid();
				});
		}
    });
	$("form#CreateSpartan_Report").on('click', '#Spartan_ReportGuardarYNuevo', function () {
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation()) {
				SendSpartan_ReportData(function () {
					ClearControls();
					ClearAttachmentsDiv();
					ResetClaveLabel();
	                getSpartan_Report_Fields_DetailData();
                getSpartan_Report_FilterData();

					EjecutarValidacionesDespuesDeGuardar();					
			setIsNew();
			EjecutarValidacionesAlComienzo();
				});
			}
		}
    });
    $("form#CreateSpartan_Report").on('click', '#Spartan_ReportGuardarYCopia', function () {
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendSpartan_ReportData(function (currentId) {
					$("#ReportIdId").val("0");
	                Spartan_Report_Fields_DetailClearGridData();
                Spartan_Report_FilterClearGridData();

					ResetClaveLabel();
					$("#ReferenceReportId").val(currentId);
	                getSpartan_Report_Fields_DetailData();
                getSpartan_Report_FilterData();

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


var Spartan_ReportisdisplayBusinessPropery = false;
Spartan_ReportDisplayBusinessRuleButtons(Spartan_ReportisdisplayBusinessPropery);
function Spartan_ReportDisplayBusinessRule() {
    if (!Spartan_ReportisdisplayBusinessPropery) {
        $('#CreateSpartan_Report').find('.col-sm-8').each(function () {
			var div =$(this); 
			if ($(this).find('.input-group').length >0)
				div  =  $(this).find('.input-group').first().hasClass('date')? $(this): $(this).find('.input-group').first();	
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = div.data('field-id');
            var fieldName = div.data('field-name');
            var attribute = div.data('attribute');
            mainElementAttributes += '<div class="Spartan_ReportdisplayBusinessPropery"><button type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#Spartan_ReportPropertyBusinessModal-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.Spartan_ReportdisplayBusinessPropery').remove();
    }
    Spartan_ReportDisplayBusinessRuleButtons(!Spartan_ReportisdisplayBusinessPropery);
    Spartan_ReportisdisplayBusinessPropery = (Spartan_ReportisdisplayBusinessPropery ? false : true);
}
function Spartan_ReportDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}

