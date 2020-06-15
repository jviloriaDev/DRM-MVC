

//Begin Declarations for Foreigns fields for Spartan_Traduction_Process_Data MultiRow
var Spartan_Traduction_Process_DatacountRowsChecked = 0;
function GetSpartan_Traduction_Process_Data_Spartan_Traduction_Concept_TypeName(Id) {
    for (var i = 0; i < Spartan_Traduction_Process_Data_Spartan_Traduction_Concept_TypeItems.length; i++) {
        if (Spartan_Traduction_Process_Data_Spartan_Traduction_Concept_TypeItems[i].IdConcept == Id) {
            return Spartan_Traduction_Process_Data_Spartan_Traduction_Concept_TypeItems[i].Concept_Description;
        }
    }
    return "";
}

function GetSpartan_Traduction_Process_Data_Spartan_Traduction_Concept_TypeDropDown() {
    var Spartan_Traduction_Process_Data_Spartan_Traduction_Concept_TypeDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_Traduction_Process_Data_Spartan_Traduction_Concept_TypeDropdown);
    if(Spartan_Traduction_Process_Data_Spartan_Traduction_Concept_TypeItems != null)
    {
       for (var i = 0; i < Spartan_Traduction_Process_Data_Spartan_Traduction_Concept_TypeItems.length; i++) {
           $('<option />', { value: Spartan_Traduction_Process_Data_Spartan_Traduction_Concept_TypeItems[i].IdConcept, text:    Spartan_Traduction_Process_Data_Spartan_Traduction_Concept_TypeItems[i].Concept_Description }).appendTo(Spartan_Traduction_Process_Data_Spartan_Traduction_Concept_TypeDropdown);
       }
    }
    return Spartan_Traduction_Process_Data_Spartan_Traduction_Concept_TypeDropdown;
}


function GetInsertSpartan_Traduction_Process_DataRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $(GetSpartan_Traduction_Process_Data_Spartan_Traduction_Concept_TypeDropDown()).addClass('Spartan_Traduction_Process_Data_Concept Concept').attr('id', 'Spartan_Traduction_Process_Data_Concept_' + index).attr('data-field', 'Concept');
    columnData[1] = $($.parseHTML(inputData)).addClass('Spartan_Traduction_Process_Data_Name_of_Control Name_of_Control').attr('id', 'Spartan_Traduction_Process_Data_Name_of_Control_' + index).attr('data-field', 'Name_of_Control');
    columnData[2] = $($.parseHTML(inputData)).addClass('Spartan_Traduction_Process_Data_Original_Text Original_Text').attr('id', 'Spartan_Traduction_Process_Data_Original_Text_' + index).attr('data-field', 'Original_Text');
    columnData[3] = $($.parseHTML(inputData)).addClass('Spartan_Traduction_Process_Data_Translated_Text Translated_Text').attr('id', 'Spartan_Traduction_Process_Data_Translated_Text_' + index).attr('data-field', 'Translated_Text');


    initiateUIControls();
    return columnData;
}

function Spartan_Traduction_Process_DataInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRSpartan_Traduction_Process_Data("Spartan_Traduction_Process_Data_", "_" + rowIndex)) {
    var iPage = Spartan_Traduction_Process_DataTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Spartan_Traduction_Process_Data';
    var prevData = Spartan_Traduction_Process_DataTable.fnGetData(rowIndex);
    var data = Spartan_Traduction_Process_DataTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Clave: prevData.Clave,
        IsInsertRow: false
        ,Concept: ($('#' + nameOfGrid + 'Grid .ConceptHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Name_of_Control: ($('#' + nameOfGrid + 'Grid .Name_of_ControlHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Original_Text: ($('#' + nameOfGrid + 'Grid .Original_TextHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Translated_Text: ($('#' + nameOfGrid + 'Grid .Translated_TextHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''

    }
    Spartan_Traduction_Process_DataTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_Traduction_Process_DatarowCreationGrid(data, newData, rowIndex);
    Spartan_Traduction_Process_DataTable.fnPageChange(iPage);
    Spartan_Traduction_Process_DatacountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRSpartan_Traduction_Process_Data("Spartan_Traduction_Process_Data_", "_" + rowIndex);
  }
}

function Spartan_Traduction_Process_DataCancelRow(rowIndex) {
    var prevData = Spartan_Traduction_Process_DataTable.fnGetData(rowIndex);
    var data = Spartan_Traduction_Process_DataTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Spartan_Traduction_Process_DataTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Spartan_Traduction_Process_DatarowCreationGrid(data, prevData, rowIndex);
    }
	showSpartan_Traduction_Process_DataGrid(Spartan_Traduction_Process_DataTable.fnGetData());
    Spartan_Traduction_Process_DatacountRowsChecked--;
}

function GetSpartan_Traduction_Process_DataFromDataTable() {
    var Spartan_Traduction_Process_DataData = [];
    var gridData = Spartan_Traduction_Process_DataTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Spartan_Traduction_Process_DataData.push({
                Clave: gridData[i].Clave
                ,Concept: gridData[i].Concept
                ,Name_of_Control: gridData[i].Name_of_Control
                ,Original_Text: gridData[i].Original_Text
                ,Translated_Text: gridData[i].Translated_Text

                ,Removed: false
            });
    }

    for (i = 0; i < removedSpartan_Traduction_Process_DataData.length; i++) {
        if (removedSpartan_Traduction_Process_DataData[i] != null && removedSpartan_Traduction_Process_DataData[i].Clave > 0)
            Spartan_Traduction_Process_DataData.push({
                Clave: removedSpartan_Traduction_Process_DataData[i].Clave
                ,Concept: removedSpartan_Traduction_Process_DataData[i].Concept
                ,Name_of_Control: removedSpartan_Traduction_Process_DataData[i].Name_of_Control
                ,Original_Text: removedSpartan_Traduction_Process_DataData[i].Original_Text
                ,Translated_Text: removedSpartan_Traduction_Process_DataData[i].Translated_Text

                , Removed: true
            });
    }	

    return Spartan_Traduction_Process_DataData;
}

function Spartan_Traduction_Process_DataEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Spartan_Traduction_Process_DataTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Spartan_Traduction_Process_DatacountRowsChecked++;
    var Spartan_Traduction_Process_DataRowElement = "Spartan_Traduction_Process_Data_" + rowIndex.toString();
    var prevData = Spartan_Traduction_Process_DataTable.fnGetData(rowIndexTable );
    var row = Spartan_Traduction_Process_DataTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Spartan_Traduction_Process_Data_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Spartan_Traduction_Process_DataGetUpdateRowControls(prevData, "Spartan_Traduction_Process_Data_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Spartan_Traduction_Process_DataRowElement + "')){ Spartan_Traduction_Process_DataInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Spartan_Traduction_Process_DataCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
        if ($('#Spartan_Traduction_Process_DataGrid .' + idHeader).css('display') != 'none') {
            $(controls[i]).appendTo($('<td id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));
        }
    }
    $('.Spartan_Traduction_Process_Data' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    initiateUIControls();
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRSpartan_Traduction_Process_Data(nameOfTable, rowIndexFormed);
    }
}

function Spartan_Traduction_Process_DatafnOpenAddRowPopUp() {
    var currentRowIndex = Spartan_Traduction_Process_DataTable.fnGetData().length;
    Spartan_Traduction_Process_DatafnClickAddRow();
    GetAddSpartan_Traduction_Process_DataPopup(currentRowIndex, 0);
}

function Spartan_Traduction_Process_DataEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Spartan_Traduction_Process_DataTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Spartan_Traduction_Process_DataRowElement = "Spartan_Traduction_Process_Data_" + rowIndex.toString();
    var prevData = Spartan_Traduction_Process_DataTable.fnGetData(rowIndexTable);
    GetAddSpartan_Traduction_Process_DataPopup(rowIndex, 1, prevData.Clave);
    $('#Spartan_Traduction_Process_DataConcept').val(prevData.Concept);
    $('#Spartan_Traduction_Process_DataName_of_Control').val(prevData.Name_of_Control);
    $('#Spartan_Traduction_Process_DataOriginal_Text').val(prevData.Original_Text);
    $('#Spartan_Traduction_Process_DataTranslated_Text').val(prevData.Translated_Text);

    initiateUIControls();

}

function Spartan_Traduction_Process_DataAddInsertRow() {
    if (Spartan_Traduction_Process_DatainsertRowCurrentIndex < 1)
    {
        Spartan_Traduction_Process_DatainsertRowCurrentIndex = 1;
    }
    return {
        Clave: null,
        IsInsertRow: true
        ,Concept: ""
        ,Name_of_Control: ""
        ,Original_Text: ""
        ,Translated_Text: ""

    }
}

function Spartan_Traduction_Process_DatafnClickAddRow() {
    Spartan_Traduction_Process_DatacountRowsChecked++;
    Spartan_Traduction_Process_DataTable.fnAddData(Spartan_Traduction_Process_DataAddInsertRow(), true);
    Spartan_Traduction_Process_DataTable.fnPageChange('last');
    initiateUIControls();
    EjecutarValidacionesNewRowMRSpartan_Traduction_Process_Data("Spartan_Traduction_Process_Data_", "_" + Spartan_Traduction_Process_DatainsertRowCurrentIndex);
}

function Spartan_Traduction_Process_DataClearGridData() {
    Spartan_Traduction_Process_DataData = [];
    Spartan_Traduction_Process_DatadeletedItem = [];
    Spartan_Traduction_Process_DataDataMain = [];
    Spartan_Traduction_Process_DataDataMainPages = [];
    Spartan_Traduction_Process_DatanewItemCount = 0;
    Spartan_Traduction_Process_DatamaxItemIndex = 0;
    $("#Spartan_Traduction_Process_DataGrid").DataTable().clear();
    $("#Spartan_Traduction_Process_DataGrid").DataTable().destroy();
}

//Used to Get Spartan Traduction Process Information
function GetSpartan_Traduction_Process_Data() {
    var form_data = new FormData();
    for (var i = 0; i < Spartan_Traduction_Process_DataData.length; i++) {
        form_data.append('[' + i + '].Clave', Spartan_Traduction_Process_DataData[i].Clave);
        form_data.append('[' + i + '].Concept', Spartan_Traduction_Process_DataData[i].Concept);
        form_data.append('[' + i + '].Name_of_Control', Spartan_Traduction_Process_DataData[i].Name_of_Control);
        form_data.append('[' + i + '].Original_Text', Spartan_Traduction_Process_DataData[i].Original_Text);
        form_data.append('[' + i + '].Translated_Text', Spartan_Traduction_Process_DataData[i].Translated_Text);

        form_data.append('[' + i + '].Removed', Spartan_Traduction_Process_DataData[i].Removed);
    }
    return form_data;
}
function Spartan_Traduction_Process_DataInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRSpartan_Traduction_Process_Data("Spartan_Traduction_Process_DataTable", rowIndex)) {
    var prevData = Spartan_Traduction_Process_DataTable.fnGetData(rowIndex);
    var data = Spartan_Traduction_Process_DataTable.fnGetNodes(rowIndex);
    var newData = {
        Clave: prevData.Clave,
        IsInsertRow: false
        ,Concept: $('#Spartan_Traduction_Process_DataConcept').val()
        ,Name_of_Control: $('#Spartan_Traduction_Process_DataName_of_Control').val()
        ,Original_Text: $('#Spartan_Traduction_Process_DataOriginal_Text').val()
        ,Translated_Text: $('#Spartan_Traduction_Process_DataTranslated_Text').val()

    }

    Spartan_Traduction_Process_DataTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_Traduction_Process_DatarowCreationGrid(data, newData, rowIndex);
    $('#AddSpartan_Traduction_Process_Data-form').modal({ show: false });
    $('#AddSpartan_Traduction_Process_Data-form').modal('hide');
    Spartan_Traduction_Process_DataEditRow(rowIndex);
    Spartan_Traduction_Process_DataInsertRow(rowIndex);
    //}
}
function Spartan_Traduction_Process_DataRemoveAddRow(rowIndex) {
    Spartan_Traduction_Process_DataTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Spartan_Traduction_Process_Data MultiRow
//Begin Declarations for Foreigns fields for Spartan_Traduction_Detail MultiRow
var Spartan_Traduction_DetailcountRowsChecked = 0;
function GetSpartan_Traduction_Detail_Spartan_Traduction_Concept_TypeName(Id) {
    for (var i = 0; i < Spartan_Traduction_Detail_Spartan_Traduction_Concept_TypeItems.length; i++) {
        if (Spartan_Traduction_Detail_Spartan_Traduction_Concept_TypeItems[i].IdConcept == Id) {
            return Spartan_Traduction_Detail_Spartan_Traduction_Concept_TypeItems[i].Concept_Description;
        }
    }
    return "";
}

function GetSpartan_Traduction_Detail_Spartan_Traduction_Concept_TypeDropDown() {
    var Spartan_Traduction_Detail_Spartan_Traduction_Concept_TypeDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_Traduction_Detail_Spartan_Traduction_Concept_TypeDropdown);
    if(Spartan_Traduction_Detail_Spartan_Traduction_Concept_TypeItems != null)
    {
       for (var i = 0; i < Spartan_Traduction_Detail_Spartan_Traduction_Concept_TypeItems.length; i++) {
           $('<option />', { value: Spartan_Traduction_Detail_Spartan_Traduction_Concept_TypeItems[i].IdConcept, text:    Spartan_Traduction_Detail_Spartan_Traduction_Concept_TypeItems[i].Concept_Description }).appendTo(Spartan_Traduction_Detail_Spartan_Traduction_Concept_TypeDropdown);
       }
    }
    return Spartan_Traduction_Detail_Spartan_Traduction_Concept_TypeDropdown;
}


function GetInsertSpartan_Traduction_DetailRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $(GetSpartan_Traduction_Detail_Spartan_Traduction_Concept_TypeDropDown()).addClass('Spartan_Traduction_Detail_Concept Concept').attr('id', 'Spartan_Traduction_Detail_Concept_' + index).attr('data-field', 'Concept');
    columnData[1] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Spartan_Traduction_Detail_IdConcept IdConcept').attr('id', 'Spartan_Traduction_Detail_IdConcept_' + index).attr('data-field', 'IdConcept');
    columnData[2] = $($.parseHTML(inputData)).addClass('Spartan_Traduction_Detail_Original_Text Original_Text').attr('id', 'Spartan_Traduction_Detail_Original_Text_' + index).attr('data-field', 'Original_Text');
    columnData[3] = $($.parseHTML(inputData)).addClass('Spartan_Traduction_Detail_Translated_Text Translated_Text').attr('id', 'Spartan_Traduction_Detail_Translated_Text_' + index).attr('data-field', 'Translated_Text');


    initiateUIControls();
    return columnData;
}

function Spartan_Traduction_DetailInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRSpartan_Traduction_Detail("Spartan_Traduction_Detail_", "_" + rowIndex)) {
    var iPage = Spartan_Traduction_DetailTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Spartan_Traduction_Detail';
    var prevData = Spartan_Traduction_DetailTable.fnGetData(rowIndex);
    var data = Spartan_Traduction_DetailTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        IdTraductionDetail: prevData.IdTraductionDetail,
        IsInsertRow: false
        ,Concept: ($('#' + nameOfGrid + 'Grid .ConceptHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,IdConcept: ($('#' + nameOfGrid + 'Grid .IdConceptHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Original_Text: ($('#' + nameOfGrid + 'Grid .Original_TextHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Translated_Text: ($('#' + nameOfGrid + 'Grid .Translated_TextHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''

    }
    Spartan_Traduction_DetailTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_Traduction_DetailrowCreationGrid(data, newData, rowIndex);
    Spartan_Traduction_DetailTable.fnPageChange(iPage);
    Spartan_Traduction_DetailcountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRSpartan_Traduction_Detail("Spartan_Traduction_Detail_", "_" + rowIndex);
  }
}

function Spartan_Traduction_DetailCancelRow(rowIndex) {
    var prevData = Spartan_Traduction_DetailTable.fnGetData(rowIndex);
    var data = Spartan_Traduction_DetailTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Spartan_Traduction_DetailTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Spartan_Traduction_DetailrowCreationGrid(data, prevData, rowIndex);
    }
	showSpartan_Traduction_DetailGrid(Spartan_Traduction_DetailTable.fnGetData());
    Spartan_Traduction_DetailcountRowsChecked--;
}

function GetSpartan_Traduction_DetailFromDataTable() {
    var Spartan_Traduction_DetailData = [];
    var gridData = Spartan_Traduction_DetailTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Spartan_Traduction_DetailData.push({
                IdTraductionDetail: gridData[i].IdTraductionDetail
                ,Concept: gridData[i].Concept
                ,IdConcept: gridData[i].IdConcept
                ,Original_Text: gridData[i].Original_Text
                ,Translated_Text: gridData[i].Translated_Text

                ,Removed: false
            });
    }

    for (i = 0; i < removedSpartan_Traduction_DetailData.length; i++) {
        if (removedSpartan_Traduction_DetailData[i] != null && removedSpartan_Traduction_DetailData[i].IdTraductionDetail > 0)
            Spartan_Traduction_DetailData.push({
                IdTraductionDetail: removedSpartan_Traduction_DetailData[i].IdTraductionDetail
                ,Concept: removedSpartan_Traduction_DetailData[i].Concept
                ,IdConcept: removedSpartan_Traduction_DetailData[i].IdConcept
                ,Original_Text: removedSpartan_Traduction_DetailData[i].Original_Text
                ,Translated_Text: removedSpartan_Traduction_DetailData[i].Translated_Text

                , Removed: true
            });
    }	

    return Spartan_Traduction_DetailData;
}

function Spartan_Traduction_DetailEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Spartan_Traduction_DetailTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Spartan_Traduction_DetailcountRowsChecked++;
    var Spartan_Traduction_DetailRowElement = "Spartan_Traduction_Detail_" + rowIndex.toString();
    var prevData = Spartan_Traduction_DetailTable.fnGetData(rowIndexTable );
    var row = Spartan_Traduction_DetailTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Spartan_Traduction_Detail_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Spartan_Traduction_DetailGetUpdateRowControls(prevData, "Spartan_Traduction_Detail_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Spartan_Traduction_DetailRowElement + "')){ Spartan_Traduction_DetailInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Spartan_Traduction_DetailCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
        if ($('#Spartan_Traduction_DetailGrid .' + idHeader).css('display') != 'none') {
            $(controls[i]).appendTo($('<td id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));
        }
    }
    $('.Spartan_Traduction_Detail' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    initiateUIControls();
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRSpartan_Traduction_Detail(nameOfTable, rowIndexFormed);
    }
}

function Spartan_Traduction_DetailfnOpenAddRowPopUp() {
    var currentRowIndex = Spartan_Traduction_DetailTable.fnGetData().length;
    Spartan_Traduction_DetailfnClickAddRow();
    GetAddSpartan_Traduction_DetailPopup(currentRowIndex, 0);
}

function Spartan_Traduction_DetailEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Spartan_Traduction_DetailTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Spartan_Traduction_DetailRowElement = "Spartan_Traduction_Detail_" + rowIndex.toString();
    var prevData = Spartan_Traduction_DetailTable.fnGetData(rowIndexTable);
    GetAddSpartan_Traduction_DetailPopup(rowIndex, 1, prevData.IdTraductionDetail);
    $('#Spartan_Traduction_DetailConcept').val(prevData.Concept);
    $('#Spartan_Traduction_DetailIdConcept').val(prevData.IdConcept);
    $('#Spartan_Traduction_DetailOriginal_Text').val(prevData.Original_Text);
    $('#Spartan_Traduction_DetailTranslated_Text').val(prevData.Translated_Text);

    initiateUIControls();

}

function Spartan_Traduction_DetailAddInsertRow() {
    if (Spartan_Traduction_DetailinsertRowCurrentIndex < 1)
    {
        Spartan_Traduction_DetailinsertRowCurrentIndex = 1;
    }
    return {
        IdTraductionDetail: null,
        IsInsertRow: true
        ,Concept: ""
        ,IdConcept: ""
        ,Original_Text: ""
        ,Translated_Text: ""

    }
}

function Spartan_Traduction_DetailfnClickAddRow() {
    Spartan_Traduction_DetailcountRowsChecked++;
    Spartan_Traduction_DetailTable.fnAddData(Spartan_Traduction_DetailAddInsertRow(), true);
    Spartan_Traduction_DetailTable.fnPageChange('last');
    initiateUIControls();
    EjecutarValidacionesNewRowMRSpartan_Traduction_Detail("Spartan_Traduction_Detail_", "_" + Spartan_Traduction_DetailinsertRowCurrentIndex);
}

function Spartan_Traduction_DetailClearGridData() {
    Spartan_Traduction_DetailData = [];
    Spartan_Traduction_DetaildeletedItem = [];
    Spartan_Traduction_DetailDataMain = [];
    Spartan_Traduction_DetailDataMainPages = [];
    Spartan_Traduction_DetailnewItemCount = 0;
    Spartan_Traduction_DetailmaxItemIndex = 0;
    $("#Spartan_Traduction_DetailGrid").DataTable().clear();
    $("#Spartan_Traduction_DetailGrid").DataTable().destroy();
}

//Used to Get Spartan Traduction Process Information
function GetSpartan_Traduction_Detail() {
    var form_data = new FormData();
    for (var i = 0; i < Spartan_Traduction_DetailData.length; i++) {
        form_data.append('[' + i + '].IdTraductionDetail', Spartan_Traduction_DetailData[i].IdTraductionDetail);
        form_data.append('[' + i + '].Concept', Spartan_Traduction_DetailData[i].Concept);
        form_data.append('[' + i + '].IdConcept', Spartan_Traduction_DetailData[i].IdConcept);
        form_data.append('[' + i + '].Original_Text', Spartan_Traduction_DetailData[i].Original_Text);
        form_data.append('[' + i + '].Translated_Text', Spartan_Traduction_DetailData[i].Translated_Text);

        form_data.append('[' + i + '].Removed', Spartan_Traduction_DetailData[i].Removed);
    }
    return form_data;
}
function Spartan_Traduction_DetailInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRSpartan_Traduction_Detail("Spartan_Traduction_DetailTable", rowIndex)) {
    var prevData = Spartan_Traduction_DetailTable.fnGetData(rowIndex);
    var data = Spartan_Traduction_DetailTable.fnGetNodes(rowIndex);
    var newData = {
        IdTraductionDetail: prevData.IdTraductionDetail,
        IsInsertRow: false
        ,Concept: $('#Spartan_Traduction_DetailConcept').val()
        ,IdConcept: $('#Spartan_Traduction_DetailIdConcept').val()

        ,Original_Text: $('#Spartan_Traduction_DetailOriginal_Text').val()
        ,Translated_Text: $('#Spartan_Traduction_DetailTranslated_Text').val()

    }

    Spartan_Traduction_DetailTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_Traduction_DetailrowCreationGrid(data, newData, rowIndex);
    $('#AddSpartan_Traduction_Detail-form').modal({ show: false });
    $('#AddSpartan_Traduction_Detail-form').modal('hide');
    Spartan_Traduction_DetailEditRow(rowIndex);
    Spartan_Traduction_DetailInsertRow(rowIndex);
    //}
}
function Spartan_Traduction_DetailRemoveAddRow(rowIndex) {
    Spartan_Traduction_DetailTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Spartan_Traduction_Detail MultiRow
//Begin Declarations for Foreigns fields for Spartan_Traduction_Process_Workflow MultiRow
var Spartan_Traduction_Process_WorkflowcountRowsChecked = 0;
function GetSpartan_Traduction_Process_Workflow_Spartan_Traduction_Concept_TypeName(Id) {
    for (var i = 0; i < Spartan_Traduction_Process_Workflow_Spartan_Traduction_Concept_TypeItems.length; i++) {
        if (Spartan_Traduction_Process_Workflow_Spartan_Traduction_Concept_TypeItems[i].IdConcept == Id) {
            return Spartan_Traduction_Process_Workflow_Spartan_Traduction_Concept_TypeItems[i].Concept_Description;
        }
    }
    return "";
}

function GetSpartan_Traduction_Process_Workflow_Spartan_Traduction_Concept_TypeDropDown() {
    var Spartan_Traduction_Process_Workflow_Spartan_Traduction_Concept_TypeDropdown = $('<select class="form-control" />');

    $('<option />', { value: '', text: '--Select--' }).appendTo(Spartan_Traduction_Process_Workflow_Spartan_Traduction_Concept_TypeDropdown);
    if(Spartan_Traduction_Process_Workflow_Spartan_Traduction_Concept_TypeItems != null)
    {
       for (var i = 0; i < Spartan_Traduction_Process_Workflow_Spartan_Traduction_Concept_TypeItems.length; i++) {
           $('<option />', { value: Spartan_Traduction_Process_Workflow_Spartan_Traduction_Concept_TypeItems[i].IdConcept, text:    Spartan_Traduction_Process_Workflow_Spartan_Traduction_Concept_TypeItems[i].Concept_Description }).appendTo(Spartan_Traduction_Process_Workflow_Spartan_Traduction_Concept_TypeDropdown);
       }
    }
    return Spartan_Traduction_Process_Workflow_Spartan_Traduction_Concept_TypeDropdown;
}


function GetInsertSpartan_Traduction_Process_WorkflowRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $(GetSpartan_Traduction_Process_Workflow_Spartan_Traduction_Concept_TypeDropDown()).addClass('Spartan_Traduction_Process_Workflow_Concept Concept').attr('id', 'Spartan_Traduction_Process_Workflow_Concept_' + index).attr('data-field', 'Concept');
    columnData[1] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Spartan_Traduction_Process_Workflow_ID_of_Step ID_of_Step').attr('id', 'Spartan_Traduction_Process_Workflow_ID_of_Step_' + index).attr('data-field', 'ID_of_Step');
    columnData[2] = $($.parseHTML(inputData)).addClass('Spartan_Traduction_Process_Workflow_Original_Text Original_Text').attr('id', 'Spartan_Traduction_Process_Workflow_Original_Text_' + index).attr('data-field', 'Original_Text');
    columnData[3] = $($.parseHTML(inputData)).addClass('Spartan_Traduction_Process_Workflow_Translated_Text Translated_Text').attr('id', 'Spartan_Traduction_Process_Workflow_Translated_Text_' + index).attr('data-field', 'Translated_Text');


    initiateUIControls();
    return columnData;
}

function Spartan_Traduction_Process_WorkflowInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRSpartan_Traduction_Process_Workflow("Spartan_Traduction_Process_Workflow_", "_" + rowIndex)) {
    var iPage = Spartan_Traduction_Process_WorkflowTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Spartan_Traduction_Process_Workflow';
    var prevData = Spartan_Traduction_Process_WorkflowTable.fnGetData(rowIndex);
    var data = Spartan_Traduction_Process_WorkflowTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Clave: prevData.Clave,
        IsInsertRow: false
        ,Concept: ($('#' + nameOfGrid + 'Grid .ConceptHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,ID_of_Step: ($('#' + nameOfGrid + 'Grid .ID_of_StepHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Original_Text: ($('#' + nameOfGrid + 'Grid .Original_TextHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''
        ,Translated_Text: ($('#' + nameOfGrid + 'Grid .Translated_TextHeader').css('display') != 'none') ? data.childNodes[counter++].childNodes[0].value : ''

    }
    Spartan_Traduction_Process_WorkflowTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_Traduction_Process_WorkflowrowCreationGrid(data, newData, rowIndex);
    Spartan_Traduction_Process_WorkflowTable.fnPageChange(iPage);
    Spartan_Traduction_Process_WorkflowcountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRSpartan_Traduction_Process_Workflow("Spartan_Traduction_Process_Workflow_", "_" + rowIndex);
  }
}

function Spartan_Traduction_Process_WorkflowCancelRow(rowIndex) {
    var prevData = Spartan_Traduction_Process_WorkflowTable.fnGetData(rowIndex);
    var data = Spartan_Traduction_Process_WorkflowTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Spartan_Traduction_Process_WorkflowTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Spartan_Traduction_Process_WorkflowrowCreationGrid(data, prevData, rowIndex);
    }
	showSpartan_Traduction_Process_WorkflowGrid(Spartan_Traduction_Process_WorkflowTable.fnGetData());
    Spartan_Traduction_Process_WorkflowcountRowsChecked--;
}

function GetSpartan_Traduction_Process_WorkflowFromDataTable() {
    var Spartan_Traduction_Process_WorkflowData = [];
    var gridData = Spartan_Traduction_Process_WorkflowTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Spartan_Traduction_Process_WorkflowData.push({
                Clave: gridData[i].Clave
                ,Concept: gridData[i].Concept
                ,ID_of_Step: gridData[i].ID_of_Step
                ,Original_Text: gridData[i].Original_Text
                ,Translated_Text: gridData[i].Translated_Text

                ,Removed: false
            });
    }

    for (i = 0; i < removedSpartan_Traduction_Process_WorkflowData.length; i++) {
        if (removedSpartan_Traduction_Process_WorkflowData[i] != null && removedSpartan_Traduction_Process_WorkflowData[i].Clave > 0)
            Spartan_Traduction_Process_WorkflowData.push({
                Clave: removedSpartan_Traduction_Process_WorkflowData[i].Clave
                ,Concept: removedSpartan_Traduction_Process_WorkflowData[i].Concept
                ,ID_of_Step: removedSpartan_Traduction_Process_WorkflowData[i].ID_of_Step
                ,Original_Text: removedSpartan_Traduction_Process_WorkflowData[i].Original_Text
                ,Translated_Text: removedSpartan_Traduction_Process_WorkflowData[i].Translated_Text

                , Removed: true
            });
    }	

    return Spartan_Traduction_Process_WorkflowData;
}

function Spartan_Traduction_Process_WorkflowEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Spartan_Traduction_Process_WorkflowTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Spartan_Traduction_Process_WorkflowcountRowsChecked++;
    var Spartan_Traduction_Process_WorkflowRowElement = "Spartan_Traduction_Process_Workflow_" + rowIndex.toString();
    var prevData = Spartan_Traduction_Process_WorkflowTable.fnGetData(rowIndexTable );
    var row = Spartan_Traduction_Process_WorkflowTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Spartan_Traduction_Process_Workflow_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Spartan_Traduction_Process_WorkflowGetUpdateRowControls(prevData, "Spartan_Traduction_Process_Workflow_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Spartan_Traduction_Process_WorkflowRowElement + "')){ Spartan_Traduction_Process_WorkflowInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Spartan_Traduction_Process_WorkflowCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
        if ($('#Spartan_Traduction_Process_WorkflowGrid .' + idHeader).css('display') != 'none') {
            $(controls[i]).appendTo($('<td id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));
        }
    }
    $('.Spartan_Traduction_Process_Workflow' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    initiateUIControls();
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRSpartan_Traduction_Process_Workflow(nameOfTable, rowIndexFormed);
    }
}

function Spartan_Traduction_Process_WorkflowfnOpenAddRowPopUp() {
    var currentRowIndex = Spartan_Traduction_Process_WorkflowTable.fnGetData().length;
    Spartan_Traduction_Process_WorkflowfnClickAddRow();
    GetAddSpartan_Traduction_Process_WorkflowPopup(currentRowIndex, 0);
}

function Spartan_Traduction_Process_WorkflowEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Spartan_Traduction_Process_WorkflowTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Spartan_Traduction_Process_WorkflowRowElement = "Spartan_Traduction_Process_Workflow_" + rowIndex.toString();
    var prevData = Spartan_Traduction_Process_WorkflowTable.fnGetData(rowIndexTable);
    GetAddSpartan_Traduction_Process_WorkflowPopup(rowIndex, 1, prevData.Clave);
    $('#Spartan_Traduction_Process_WorkflowConcept').val(prevData.Concept);
    $('#Spartan_Traduction_Process_WorkflowID_of_Step').val(prevData.ID_of_Step);
    $('#Spartan_Traduction_Process_WorkflowOriginal_Text').val(prevData.Original_Text);
    $('#Spartan_Traduction_Process_WorkflowTranslated_Text').val(prevData.Translated_Text);

    initiateUIControls();

}

function Spartan_Traduction_Process_WorkflowAddInsertRow() {
    if (Spartan_Traduction_Process_WorkflowinsertRowCurrentIndex < 1)
    {
        Spartan_Traduction_Process_WorkflowinsertRowCurrentIndex = 1;
    }
    return {
        Clave: null,
        IsInsertRow: true
        ,Concept: ""
        ,ID_of_Step: ""
        ,Original_Text: ""
        ,Translated_Text: ""

    }
}

function Spartan_Traduction_Process_WorkflowfnClickAddRow() {
    Spartan_Traduction_Process_WorkflowcountRowsChecked++;
    Spartan_Traduction_Process_WorkflowTable.fnAddData(Spartan_Traduction_Process_WorkflowAddInsertRow(), true);
    Spartan_Traduction_Process_WorkflowTable.fnPageChange('last');
    initiateUIControls();
    EjecutarValidacionesNewRowMRSpartan_Traduction_Process_Workflow("Spartan_Traduction_Process_Workflow_", "_" + Spartan_Traduction_Process_WorkflowinsertRowCurrentIndex);
}

function Spartan_Traduction_Process_WorkflowClearGridData() {
    Spartan_Traduction_Process_WorkflowData = [];
    Spartan_Traduction_Process_WorkflowdeletedItem = [];
    Spartan_Traduction_Process_WorkflowDataMain = [];
    Spartan_Traduction_Process_WorkflowDataMainPages = [];
    Spartan_Traduction_Process_WorkflownewItemCount = 0;
    Spartan_Traduction_Process_WorkflowmaxItemIndex = 0;
    $("#Spartan_Traduction_Process_WorkflowGrid").DataTable().clear();
    $("#Spartan_Traduction_Process_WorkflowGrid").DataTable().destroy();
}

//Used to Get Spartan Traduction Process Information
function GetSpartan_Traduction_Process_Workflow() {
    var form_data = new FormData();
    for (var i = 0; i < Spartan_Traduction_Process_WorkflowData.length; i++) {
        form_data.append('[' + i + '].Clave', Spartan_Traduction_Process_WorkflowData[i].Clave);
        form_data.append('[' + i + '].Concept', Spartan_Traduction_Process_WorkflowData[i].Concept);
        form_data.append('[' + i + '].ID_of_Step', Spartan_Traduction_Process_WorkflowData[i].ID_of_Step);
        form_data.append('[' + i + '].Original_Text', Spartan_Traduction_Process_WorkflowData[i].Original_Text);
        form_data.append('[' + i + '].Translated_Text', Spartan_Traduction_Process_WorkflowData[i].Translated_Text);

        form_data.append('[' + i + '].Removed', Spartan_Traduction_Process_WorkflowData[i].Removed);
    }
    return form_data;
}
function Spartan_Traduction_Process_WorkflowInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRSpartan_Traduction_Process_Workflow("Spartan_Traduction_Process_WorkflowTable", rowIndex)) {
    var prevData = Spartan_Traduction_Process_WorkflowTable.fnGetData(rowIndex);
    var data = Spartan_Traduction_Process_WorkflowTable.fnGetNodes(rowIndex);
    var newData = {
        Clave: prevData.Clave,
        IsInsertRow: false
        ,Concept: $('#Spartan_Traduction_Process_WorkflowConcept').val()
        ,ID_of_Step: $('#Spartan_Traduction_Process_WorkflowID_of_Step').val()

        ,Original_Text: $('#Spartan_Traduction_Process_WorkflowOriginal_Text').val()
        ,Translated_Text: $('#Spartan_Traduction_Process_WorkflowTranslated_Text').val()

    }

    Spartan_Traduction_Process_WorkflowTable.fnUpdate(newData, rowIndex, null, true);
    Spartan_Traduction_Process_WorkflowrowCreationGrid(data, newData, rowIndex);
    $('#AddSpartan_Traduction_Process_Workflow-form').modal({ show: false });
    $('#AddSpartan_Traduction_Process_Workflow-form').modal('hide');
    Spartan_Traduction_Process_WorkflowEditRow(rowIndex);
    Spartan_Traduction_Process_WorkflowInsertRow(rowIndex);
    //}
}
function Spartan_Traduction_Process_WorkflowRemoveAddRow(rowIndex) {
    Spartan_Traduction_Process_WorkflowTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Spartan_Traduction_Process_Workflow MultiRow


$(function () {
    function Spartan_Traduction_Process_DatainitializeMainArray(totalCount) {
        if (Spartan_Traduction_Process_DataDataMain.length != totalCount && !Spartan_Traduction_Process_DataDataMainInitialized) {
            Spartan_Traduction_Process_DataDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Spartan_Traduction_Process_DataDataMain[i] = null;
            }
        }
    }
    function Spartan_Traduction_Process_DataremoveFromMainArray() {
        for (var j = 0; j < Spartan_Traduction_Process_DatadeletedItem.length; j++) {
            for (var i = 0; i < Spartan_Traduction_Process_DataDataMain.length; i++) {
                if (Spartan_Traduction_Process_DataDataMain[i] != null && Spartan_Traduction_Process_DataDataMain[i].Id == Spartan_Traduction_Process_DatadeletedItem[j]) {
                    hSpartan_Traduction_Process_DataDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Spartan_Traduction_Process_DatacopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Spartan_Traduction_Process_DataDataMain.length; i++) {
            data[i] = Spartan_Traduction_Process_DataDataMain[i];

        }
        return data;
    }
    function Spartan_Traduction_Process_DatagetNewResult() {
        var newData = copyMainSpartan_Traduction_Process_DataArray();

        for (var i = 0; i < Spartan_Traduction_Process_DataData.length; i++) {
            if (Spartan_Traduction_Process_DataData[i].Removed == null || Spartan_Traduction_Process_DataData[i].Removed == false) {
                newData.splice(0, 0, Spartan_Traduction_Process_DataData[i]);
            }
        }
        return newData;
    }
    function Spartan_Traduction_Process_DatapushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Spartan_Traduction_Process_DataDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Spartan_Traduction_Process_DataDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Spartan_Traduction_DetailinitializeMainArray(totalCount) {
        if (Spartan_Traduction_DetailDataMain.length != totalCount && !Spartan_Traduction_DetailDataMainInitialized) {
            Spartan_Traduction_DetailDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Spartan_Traduction_DetailDataMain[i] = null;
            }
        }
    }
    function Spartan_Traduction_DetailremoveFromMainArray() {
        for (var j = 0; j < Spartan_Traduction_DetaildeletedItem.length; j++) {
            for (var i = 0; i < Spartan_Traduction_DetailDataMain.length; i++) {
                if (Spartan_Traduction_DetailDataMain[i] != null && Spartan_Traduction_DetailDataMain[i].Id == Spartan_Traduction_DetaildeletedItem[j]) {
                    hSpartan_Traduction_DetailDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Spartan_Traduction_DetailcopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Spartan_Traduction_DetailDataMain.length; i++) {
            data[i] = Spartan_Traduction_DetailDataMain[i];

        }
        return data;
    }
    function Spartan_Traduction_DetailgetNewResult() {
        var newData = copyMainSpartan_Traduction_DetailArray();

        for (var i = 0; i < Spartan_Traduction_DetailData.length; i++) {
            if (Spartan_Traduction_DetailData[i].Removed == null || Spartan_Traduction_DetailData[i].Removed == false) {
                newData.splice(0, 0, Spartan_Traduction_DetailData[i]);
            }
        }
        return newData;
    }
    function Spartan_Traduction_DetailpushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Spartan_Traduction_DetailDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Spartan_Traduction_DetailDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Spartan_Traduction_Process_WorkflowinitializeMainArray(totalCount) {
        if (Spartan_Traduction_Process_WorkflowDataMain.length != totalCount && !Spartan_Traduction_Process_WorkflowDataMainInitialized) {
            Spartan_Traduction_Process_WorkflowDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Spartan_Traduction_Process_WorkflowDataMain[i] = null;
            }
        }
    }
    function Spartan_Traduction_Process_WorkflowremoveFromMainArray() {
        for (var j = 0; j < Spartan_Traduction_Process_WorkflowdeletedItem.length; j++) {
            for (var i = 0; i < Spartan_Traduction_Process_WorkflowDataMain.length; i++) {
                if (Spartan_Traduction_Process_WorkflowDataMain[i] != null && Spartan_Traduction_Process_WorkflowDataMain[i].Id == Spartan_Traduction_Process_WorkflowdeletedItem[j]) {
                    hSpartan_Traduction_Process_WorkflowDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Spartan_Traduction_Process_WorkflowcopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Spartan_Traduction_Process_WorkflowDataMain.length; i++) {
            data[i] = Spartan_Traduction_Process_WorkflowDataMain[i];

        }
        return data;
    }
    function Spartan_Traduction_Process_WorkflowgetNewResult() {
        var newData = copyMainSpartan_Traduction_Process_WorkflowArray();

        for (var i = 0; i < Spartan_Traduction_Process_WorkflowData.length; i++) {
            if (Spartan_Traduction_Process_WorkflowData[i].Removed == null || Spartan_Traduction_Process_WorkflowData[i].Removed == false) {
                newData.splice(0, 0, Spartan_Traduction_Process_WorkflowData[i]);
            }
        }
        return newData;
    }
    function Spartan_Traduction_Process_WorkflowpushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Spartan_Traduction_Process_WorkflowDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Spartan_Traduction_Process_WorkflowDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }

});

//Grid GetAutocomplete

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

function GetGridAutoComplete(data,field, id) {
    
    var dataMain = data == null ? "Select" : data;
    id ==  (id==null   || id==undefined)? "":id;
    
     return "<select class='AutoComplete fullWidth select2-dropDown " + field + " form-control' data-val='true'  ><option value='" + id +"'>" + dataMain + "</option></select>";
}

function ClearControls() {
    $("#ReferenceIdTraduction").val("0");
    $('#CreateSpartan_Traduction_Process')[0].reset();
    ClearFormControls();
    $("#IdTraductionId").val("0");
                Spartan_Traduction_Process_DataClearGridData();
                Spartan_Traduction_DetailClearGridData();
                Spartan_Traduction_Process_WorkflowClearGridData();

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreateSpartan_Traduction_Process').trigger('reset');
    $('#CreateSpartan_Traduction_Process').find(':input').each(function () {
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
    var $myForm = $('#CreateSpartan_Traduction_Process');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    /*if (Spartan_Traduction_Process_DatacountRowsChecked > 0)
    {
        ShowMessagePendingRowSpartan_Traduction_Process_Data();
        return false;
    }
    if (Spartan_Traduction_DetailcountRowsChecked > 0)
    {
        ShowMessagePendingRowSpartan_Traduction_Detail();
        return false;
    }
    if (Spartan_Traduction_Process_WorkflowcountRowsChecked > 0)
    {
        ShowMessagePendingRowSpartan_Traduction_Process_Workflow();
        return false;
    }*/
	
    return true;
}


function ResetClaveLabel() {
    $("#lblIdTraduction").text("0");
}
$(document).ready(function () {
    $("form#CreateSpartan_Traduction_Process").submit(function (e) {
        e.preventDefault();
        return false;
    });
	$("form#CreateSpartan_Traduction_Process").on('click', '#Spartan_Traduction_ProcessCancelar', function () {
        Spartan_Traduction_ProcessBackToGrid();
    });
	$("form#CreateSpartan_Traduction_Process").on('click', '#Spartan_Traduction_ProcessGuardar', function () {
        if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendSpartan_Traduction_ProcessData(function () {
					EjecutarValidacionesDespuesDeGuardar();
					Spartan_Traduction_ProcessBackToGrid();
				});
		}
    });
	$("form#CreateSpartan_Traduction_Process").on('click', '#Spartan_Traduction_ProcessGuardarYNuevo', function () {
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation()) {
				SendSpartan_Traduction_ProcessData(function () {
					ClearControls();
					ClearAttachmentsDiv();
					ResetClaveLabel();
	                getSpartan_Traduction_Process_DataData();
                getSpartan_Traduction_DetailData();
                getSpartan_Traduction_Process_WorkflowData();

					EjecutarValidacionesDespuesDeGuardar();					
			setIsNew();
			EjecutarValidacionesAlComienzo();
				});
			}
		}
    });
    $("form#CreateSpartan_Traduction_Process").on('click', '#Spartan_Traduction_ProcessGuardarYCopia', function () {
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendSpartan_Traduction_ProcessData(function (currentId) {
					$("#IdTraductionId").val("0");
	                Spartan_Traduction_Process_DataClearGridData();
                Spartan_Traduction_DetailClearGridData();
                Spartan_Traduction_Process_WorkflowClearGridData();

					ResetClaveLabel();
					$("#ReferenceIdTraduction").val(currentId);
	                getSpartan_Traduction_Process_DataData();
                getSpartan_Traduction_DetailData();
                getSpartan_Traduction_Process_WorkflowData();

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


var Spartan_Traduction_ProcessisdisplayBusinessPropery = false;
Spartan_Traduction_ProcessDisplayBusinessRuleButtons(Spartan_Traduction_ProcessisdisplayBusinessPropery);
function Spartan_Traduction_ProcessDisplayBusinessRule() {
    if (!Spartan_Traduction_ProcessisdisplayBusinessPropery) {
        $('#CreateSpartan_Traduction_Process').find('.col-sm-8').each(function () {
			var div =$(this); 
			if ($(this).find('.input-group').length >0)
				div  =  $(this).find('.input-group').first().hasClass('date')? $(this): $(this).find('.input-group').first();	
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = div.data('field-id');
            var fieldName = div.data('field-name');
            var attribute = div.data('attribute');
            mainElementAttributes += '<div class="Spartan_Traduction_ProcessdisplayBusinessPropery"><button type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#Spartan_Traduction_ProcessPropertyBusinessModal-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.Spartan_Traduction_ProcessdisplayBusinessPropery').remove();
    }
    Spartan_Traduction_ProcessDisplayBusinessRuleButtons(!Spartan_Traduction_ProcessisdisplayBusinessPropery);
    Spartan_Traduction_ProcessisdisplayBusinessPropery = (Spartan_Traduction_ProcessisdisplayBusinessPropery ? false : true);
}
function Spartan_Traduction_ProcessDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}

