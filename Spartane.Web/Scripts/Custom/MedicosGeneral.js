        function RemoveAttachmentMainFoto () {
            $("#hdnRemoveFoto").val("1");
            $("#divAttachmentFoto").hide();
        }
        function RemoveAttachmentMainCedula_Fiscal_Documento () {
            $("#hdnRemoveCedula_Fiscal_Documento").val("1");
            $("#divAttachmentCedula_Fiscal_Documento").hide();
        }
        function RemoveAttachmentMainComprobante_de_Domicilio () {
            $("#hdnRemoveComprobante_de_Domicilio").val("1");
            $("#divAttachmentComprobante_de_Domicilio").hide();
        }


//Begin Declarations for Foreigns fields for Detalle_Redes_Sociales_Especialista MultiRow
var Detalle_Redes_Sociales_EspecialistacountRowsChecked = 0;

function GetDetalle_Redes_Sociales_Especialista_Redes_socialesName(Id) {
    for (var i = 0; i < Detalle_Redes_Sociales_Especialista_Redes_socialesItems.length; i++) {
        if (Detalle_Redes_Sociales_Especialista_Redes_socialesItems[i].Clave == Id) {
            return Detalle_Redes_Sociales_Especialista_Redes_socialesItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Redes_Sociales_Especialista_Redes_socialesDropDown() {
    var Detalle_Redes_Sociales_Especialista_Redes_socialesDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Redes_Sociales_Especialista_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Redes_Sociales_Especialista_Redes_socialesDropdown);
    if(Detalle_Redes_Sociales_Especialista_Redes_socialesItems != null)
    {
       for (var i = 0; i < Detalle_Redes_Sociales_Especialista_Redes_socialesItems.length; i++) {
           $('<option />', { value: Detalle_Redes_Sociales_Especialista_Redes_socialesItems[i].Clave, text:    Detalle_Redes_Sociales_Especialista_Redes_socialesItems[i].Descripcion }).appendTo(Detalle_Redes_Sociales_Especialista_Redes_socialesDropdown);
       }
    }
    return Detalle_Redes_Sociales_Especialista_Redes_socialesDropdown;
}




function GetInsertDetalle_Redes_Sociales_EspecialistaRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $(GetDetalle_Redes_Sociales_Especialista_Redes_socialesDropDown()).addClass('Detalle_Redes_Sociales_Especialista_Red_Social Red_Social').attr('id', 'Detalle_Redes_Sociales_Especialista_Red_Social_' + index).attr('data-field', 'Red_Social').after($.parseHTML(addNew('Detalle_Redes_Sociales_Especialista', 'Redes_sociales', 'Red_Social', 258884)));
    columnData[1] = $($.parseHTML(inputData)).addClass('Detalle_Redes_Sociales_Especialista_URL URL').attr('id', 'Detalle_Redes_Sociales_Especialista_URL_' + index).attr('data-field', 'URL');
    columnData[2] = $($.parseHTML(GetGridCheckBox())).addClass('Detalle_Redes_Sociales_Especialista_Principal Principal').attr('id', 'Detalle_Redes_Sociales_Especialista_Principal_' + index).attr('data-field', 'Principal');


    initiateUIControls();
    return columnData;
}

function Detalle_Redes_Sociales_EspecialistaInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Redes_Sociales_Especialista("Detalle_Redes_Sociales_Especialista_", "_" + rowIndex)) {
    var iPage = Detalle_Redes_Sociales_EspecialistaTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Redes_Sociales_Especialista';
    var prevData = Detalle_Redes_Sociales_EspecialistaTable.fnGetData(rowIndex);
    var data = Detalle_Redes_Sociales_EspecialistaTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Red_Social:  data.childNodes[counter++].childNodes[0].value
        ,URL:  data.childNodes[counter++].childNodes[0].value
        ,Principal: $(data.childNodes[counter++].childNodes[2]).is(':checked')

    }
    Detalle_Redes_Sociales_EspecialistaTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Redes_Sociales_EspecialistarowCreationGrid(data, newData, rowIndex);
    Detalle_Redes_Sociales_EspecialistaTable.fnPageChange(iPage);
    Detalle_Redes_Sociales_EspecialistacountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Redes_Sociales_Especialista("Detalle_Redes_Sociales_Especialista_", "_" + rowIndex);
  }
}

function Detalle_Redes_Sociales_EspecialistaCancelRow(rowIndex) {
    var prevData = Detalle_Redes_Sociales_EspecialistaTable.fnGetData(rowIndex);
    var data = Detalle_Redes_Sociales_EspecialistaTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Redes_Sociales_EspecialistaTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Redes_Sociales_EspecialistarowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Redes_Sociales_EspecialistaGrid(Detalle_Redes_Sociales_EspecialistaTable.fnGetData());
    Detalle_Redes_Sociales_EspecialistacountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Redes_Sociales_EspecialistaFromDataTable() {
    var Detalle_Redes_Sociales_EspecialistaData = [];
    var gridData = Detalle_Redes_Sociales_EspecialistaTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Redes_Sociales_EspecialistaData.push({
                Folio: gridData[i].Folio

                ,Red_Social: gridData[i].Red_Social
                ,URL: gridData[i].URL
                ,Principal: gridData[i].Principal

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Redes_Sociales_EspecialistaData.length; i++) {
        if (removedDetalle_Redes_Sociales_EspecialistaData[i] != null && removedDetalle_Redes_Sociales_EspecialistaData[i].Folio > 0)
            Detalle_Redes_Sociales_EspecialistaData.push({
                Folio: removedDetalle_Redes_Sociales_EspecialistaData[i].Folio

                ,Red_Social: removedDetalle_Redes_Sociales_EspecialistaData[i].Red_Social
                ,URL: removedDetalle_Redes_Sociales_EspecialistaData[i].URL
                ,Principal: removedDetalle_Redes_Sociales_EspecialistaData[i].Principal

                , Removed: true
            });
    }	

    return Detalle_Redes_Sociales_EspecialistaData;
}

function Detalle_Redes_Sociales_EspecialistaEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Redes_Sociales_EspecialistaTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Redes_Sociales_EspecialistacountRowsChecked++;
    var Detalle_Redes_Sociales_EspecialistaRowElement = "Detalle_Redes_Sociales_Especialista_" + rowIndex.toString();
    var prevData = Detalle_Redes_Sociales_EspecialistaTable.fnGetData(rowIndexTable );
    var row = Detalle_Redes_Sociales_EspecialistaTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Redes_Sociales_Especialista_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Redes_Sociales_EspecialistaGetUpdateRowControls(prevData, "Detalle_Redes_Sociales_Especialista_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Redes_Sociales_EspecialistaRowElement + "')){ Detalle_Redes_Sociales_EspecialistaInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_Redes_Sociales_EspecialistaCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Redes_Sociales_EspecialistaGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Redes_Sociales_EspecialistaGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_Redes_Sociales_EspecialistaValidation();
    initiateUIControls();
    $('.Detalle_Redes_Sociales_Especialista' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Redes_Sociales_Especialista(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Redes_Sociales_EspecialistafnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Redes_Sociales_EspecialistaTable.fnGetData().length;
    Detalle_Redes_Sociales_EspecialistafnClickAddRow();
    GetAddDetalle_Redes_Sociales_EspecialistaPopup(currentRowIndex, 0);
}

function Detalle_Redes_Sociales_EspecialistaEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Redes_Sociales_EspecialistaTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Redes_Sociales_EspecialistaRowElement = "Detalle_Redes_Sociales_Especialista_" + rowIndex.toString();
    var prevData = Detalle_Redes_Sociales_EspecialistaTable.fnGetData(rowIndexTable);
    GetAddDetalle_Redes_Sociales_EspecialistaPopup(rowIndex, 1, prevData.Folio);

    $('#Detalle_Redes_Sociales_EspecialistaRed_Social').val(prevData.Red_Social);
    $('#Detalle_Redes_Sociales_EspecialistaURL').val(prevData.URL);
    $('#Detalle_Redes_Sociales_EspecialistaPrincipal').prop('checked', prevData.Principal);

    initiateUIControls();





}

function Detalle_Redes_Sociales_EspecialistaAddInsertRow() {
    if (Detalle_Redes_Sociales_EspecialistainsertRowCurrentIndex < 1)
    {
        Detalle_Redes_Sociales_EspecialistainsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Red_Social: ""
        ,URL: ""
        ,Principal: ""

    }
}

function Detalle_Redes_Sociales_EspecialistafnClickAddRow() {
    Detalle_Redes_Sociales_EspecialistacountRowsChecked++;
    Detalle_Redes_Sociales_EspecialistaTable.fnAddData(Detalle_Redes_Sociales_EspecialistaAddInsertRow(), true);
    Detalle_Redes_Sociales_EspecialistaTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_Redes_Sociales_EspecialistaGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_Redes_Sociales_EspecialistaGrid tbody tr:nth-of-type(' + (Detalle_Redes_Sociales_EspecialistainsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Redes_Sociales_Especialista("Detalle_Redes_Sociales_Especialista_", "_" + Detalle_Redes_Sociales_EspecialistainsertRowCurrentIndex);
}

function Detalle_Redes_Sociales_EspecialistaClearGridData() {
    Detalle_Redes_Sociales_EspecialistaData = [];
    Detalle_Redes_Sociales_EspecialistadeletedItem = [];
    Detalle_Redes_Sociales_EspecialistaDataMain = [];
    Detalle_Redes_Sociales_EspecialistaDataMainPages = [];
    Detalle_Redes_Sociales_EspecialistanewItemCount = 0;
    Detalle_Redes_Sociales_EspecialistamaxItemIndex = 0;
    $("#Detalle_Redes_Sociales_EspecialistaGrid").DataTable().clear();
    $("#Detalle_Redes_Sociales_EspecialistaGrid").DataTable().destroy();
}

//Used to Get Especialistas Information
function GetDetalle_Redes_Sociales_Especialista() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Redes_Sociales_EspecialistaData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Redes_Sociales_EspecialistaData[i].Folio);

        form_data.append('[' + i + '].Red_Social', Detalle_Redes_Sociales_EspecialistaData[i].Red_Social);
        form_data.append('[' + i + '].URL', Detalle_Redes_Sociales_EspecialistaData[i].URL);
        form_data.append('[' + i + '].Principal', Detalle_Redes_Sociales_EspecialistaData[i].Principal);

        form_data.append('[' + i + '].Removed', Detalle_Redes_Sociales_EspecialistaData[i].Removed);
    }
    return form_data;
}
function Detalle_Redes_Sociales_EspecialistaInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Redes_Sociales_Especialista("Detalle_Redes_Sociales_EspecialistaTable", rowIndex)) {
    var prevData = Detalle_Redes_Sociales_EspecialistaTable.fnGetData(rowIndex);
    var data = Detalle_Redes_Sociales_EspecialistaTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Red_Social: $('#Detalle_Redes_Sociales_EspecialistaRed_Social').val()
        ,URL: $('#Detalle_Redes_Sociales_EspecialistaURL').val()
        ,Principal: $('#Detalle_Redes_Sociales_EspecialistaPrincipal').is(':checked')

    }

    Detalle_Redes_Sociales_EspecialistaTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Redes_Sociales_EspecialistarowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Redes_Sociales_Especialista-form').modal({ show: false });
    $('#AddDetalle_Redes_Sociales_Especialista-form').modal('hide');
    Detalle_Redes_Sociales_EspecialistaEditRow(rowIndex);
    Detalle_Redes_Sociales_EspecialistaInsertRow(rowIndex);
    //}
}
function Detalle_Redes_Sociales_EspecialistaRemoveAddRow(rowIndex) {
    Detalle_Redes_Sociales_EspecialistaTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Redes_Sociales_Especialista MultiRow
//Begin Declarations for Foreigns fields for Detalle_Convenio_Medicos_Aseguradoras MultiRow
var Detalle_Convenio_Medicos_AseguradorascountRowsChecked = 0;

function GetDetalle_Convenio_Medicos_Aseguradoras_AseguradorasName(Id) {
    for (var i = 0; i < Detalle_Convenio_Medicos_Aseguradoras_AseguradorasItems.length; i++) {
        if (Detalle_Convenio_Medicos_Aseguradoras_AseguradorasItems[i].Folio == Id) {
            return Detalle_Convenio_Medicos_Aseguradoras_AseguradorasItems[i].Nombre;
        }
    }
    return "";
}

function GetDetalle_Convenio_Medicos_Aseguradoras_AseguradorasDropDown() {
    var Detalle_Convenio_Medicos_Aseguradoras_AseguradorasDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Convenio_Medicos_Aseguradoras_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Convenio_Medicos_Aseguradoras_AseguradorasDropdown);
    if(Detalle_Convenio_Medicos_Aseguradoras_AseguradorasItems != null)
    {
       for (var i = 0; i < Detalle_Convenio_Medicos_Aseguradoras_AseguradorasItems.length; i++) {
           $('<option />', { value: Detalle_Convenio_Medicos_Aseguradoras_AseguradorasItems[i].Folio, text:    Detalle_Convenio_Medicos_Aseguradoras_AseguradorasItems[i].Nombre }).appendTo(Detalle_Convenio_Medicos_Aseguradoras_AseguradorasDropdown);
       }
    }
    return Detalle_Convenio_Medicos_Aseguradoras_AseguradorasDropdown;
}


function GetInsertDetalle_Convenio_Medicos_AseguradorasRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $(GetDetalle_Convenio_Medicos_Aseguradoras_AseguradorasDropDown()).addClass('Detalle_Convenio_Medicos_Aseguradoras_Aseguradora_medico Aseguradora_medico').attr('id', 'Detalle_Convenio_Medicos_Aseguradoras_Aseguradora_medico_' + index).attr('data-field', 'Aseguradora_medico').after($.parseHTML(addNew('Detalle_Convenio_Medicos_Aseguradoras', 'Aseguradoras', 'Aseguradora_medico', 258629)));


    initiateUIControls();
    return columnData;
}

function Detalle_Convenio_Medicos_AseguradorasInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Convenio_Medicos_Aseguradoras("Detalle_Convenio_Medicos_Aseguradoras_", "_" + rowIndex)) {
    var iPage = Detalle_Convenio_Medicos_AseguradorasTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Convenio_Medicos_Aseguradoras';
    var prevData = Detalle_Convenio_Medicos_AseguradorasTable.fnGetData(rowIndex);
    var data = Detalle_Convenio_Medicos_AseguradorasTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Aseguradora_medico:  data.childNodes[counter++].childNodes[0].value

    }
    Detalle_Convenio_Medicos_AseguradorasTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Convenio_Medicos_AseguradorasrowCreationGrid(data, newData, rowIndex);
    Detalle_Convenio_Medicos_AseguradorasTable.fnPageChange(iPage);
    Detalle_Convenio_Medicos_AseguradorascountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Convenio_Medicos_Aseguradoras("Detalle_Convenio_Medicos_Aseguradoras_", "_" + rowIndex);
  }
}

function Detalle_Convenio_Medicos_AseguradorasCancelRow(rowIndex) {
    var prevData = Detalle_Convenio_Medicos_AseguradorasTable.fnGetData(rowIndex);
    var data = Detalle_Convenio_Medicos_AseguradorasTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Convenio_Medicos_AseguradorasTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Convenio_Medicos_AseguradorasrowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Convenio_Medicos_AseguradorasGrid(Detalle_Convenio_Medicos_AseguradorasTable.fnGetData());
    Detalle_Convenio_Medicos_AseguradorascountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Convenio_Medicos_AseguradorasFromDataTable() {
    var Detalle_Convenio_Medicos_AseguradorasData = [];
    var gridData = Detalle_Convenio_Medicos_AseguradorasTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Convenio_Medicos_AseguradorasData.push({
                Folio: gridData[i].Folio

                ,Aseguradora_medico: gridData[i].Aseguradora_medico

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Convenio_Medicos_AseguradorasData.length; i++) {
        if (removedDetalle_Convenio_Medicos_AseguradorasData[i] != null && removedDetalle_Convenio_Medicos_AseguradorasData[i].Folio > 0)
            Detalle_Convenio_Medicos_AseguradorasData.push({
                Folio: removedDetalle_Convenio_Medicos_AseguradorasData[i].Folio

                ,Aseguradora_medico: removedDetalle_Convenio_Medicos_AseguradorasData[i].Aseguradora_medico

                , Removed: true
            });
    }	

    return Detalle_Convenio_Medicos_AseguradorasData;
}

function Detalle_Convenio_Medicos_AseguradorasEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Convenio_Medicos_AseguradorasTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Convenio_Medicos_AseguradorascountRowsChecked++;
    var Detalle_Convenio_Medicos_AseguradorasRowElement = "Detalle_Convenio_Medicos_Aseguradoras_" + rowIndex.toString();
    var prevData = Detalle_Convenio_Medicos_AseguradorasTable.fnGetData(rowIndexTable );
    var row = Detalle_Convenio_Medicos_AseguradorasTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Convenio_Medicos_Aseguradoras_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Convenio_Medicos_AseguradorasGetUpdateRowControls(prevData, "Detalle_Convenio_Medicos_Aseguradoras_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Convenio_Medicos_AseguradorasRowElement + "')){ Detalle_Convenio_Medicos_AseguradorasInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_Convenio_Medicos_AseguradorasCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Convenio_Medicos_AseguradorasGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Convenio_Medicos_AseguradorasGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_Convenio_Medicos_AseguradorasValidation();
    initiateUIControls();
    $('.Detalle_Convenio_Medicos_Aseguradoras' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Convenio_Medicos_Aseguradoras(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Convenio_Medicos_AseguradorasfnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Convenio_Medicos_AseguradorasTable.fnGetData().length;
    Detalle_Convenio_Medicos_AseguradorasfnClickAddRow();
    GetAddDetalle_Convenio_Medicos_AseguradorasPopup(currentRowIndex, 0);
}

function Detalle_Convenio_Medicos_AseguradorasEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Convenio_Medicos_AseguradorasTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Convenio_Medicos_AseguradorasRowElement = "Detalle_Convenio_Medicos_Aseguradoras_" + rowIndex.toString();
    var prevData = Detalle_Convenio_Medicos_AseguradorasTable.fnGetData(rowIndexTable);
    GetAddDetalle_Convenio_Medicos_AseguradorasPopup(rowIndex, 1, prevData.Folio);

    $('#Detalle_Convenio_Medicos_AseguradorasAseguradora_medico').val(prevData.Aseguradora_medico);

    initiateUIControls();



}

function Detalle_Convenio_Medicos_AseguradorasAddInsertRow() {
    if (Detalle_Convenio_Medicos_AseguradorasinsertRowCurrentIndex < 1)
    {
        Detalle_Convenio_Medicos_AseguradorasinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Aseguradora_medico: ""

    }
}

function Detalle_Convenio_Medicos_AseguradorasfnClickAddRow() {
    Detalle_Convenio_Medicos_AseguradorascountRowsChecked++;
    Detalle_Convenio_Medicos_AseguradorasTable.fnAddData(Detalle_Convenio_Medicos_AseguradorasAddInsertRow(), true);
    Detalle_Convenio_Medicos_AseguradorasTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_Convenio_Medicos_AseguradorasGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_Convenio_Medicos_AseguradorasGrid tbody tr:nth-of-type(' + (Detalle_Convenio_Medicos_AseguradorasinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Convenio_Medicos_Aseguradoras("Detalle_Convenio_Medicos_Aseguradoras_", "_" + Detalle_Convenio_Medicos_AseguradorasinsertRowCurrentIndex);
}

function Detalle_Convenio_Medicos_AseguradorasClearGridData() {
    Detalle_Convenio_Medicos_AseguradorasData = [];
    Detalle_Convenio_Medicos_AseguradorasdeletedItem = [];
    Detalle_Convenio_Medicos_AseguradorasDataMain = [];
    Detalle_Convenio_Medicos_AseguradorasDataMainPages = [];
    Detalle_Convenio_Medicos_AseguradorasnewItemCount = 0;
    Detalle_Convenio_Medicos_AseguradorasmaxItemIndex = 0;
    $("#Detalle_Convenio_Medicos_AseguradorasGrid").DataTable().clear();
    $("#Detalle_Convenio_Medicos_AseguradorasGrid").DataTable().destroy();
}

//Used to Get Especialistas Information
function GetDetalle_Convenio_Medicos_Aseguradoras() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Convenio_Medicos_AseguradorasData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Convenio_Medicos_AseguradorasData[i].Folio);

        form_data.append('[' + i + '].Aseguradora_medico', Detalle_Convenio_Medicos_AseguradorasData[i].Aseguradora_medico);

        form_data.append('[' + i + '].Removed', Detalle_Convenio_Medicos_AseguradorasData[i].Removed);
    }
    return form_data;
}
function Detalle_Convenio_Medicos_AseguradorasInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Convenio_Medicos_Aseguradoras("Detalle_Convenio_Medicos_AseguradorasTable", rowIndex)) {
    var prevData = Detalle_Convenio_Medicos_AseguradorasTable.fnGetData(rowIndex);
    var data = Detalle_Convenio_Medicos_AseguradorasTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Aseguradora_medico: $('#Detalle_Convenio_Medicos_AseguradorasAseguradora_medico').val()

    }

    Detalle_Convenio_Medicos_AseguradorasTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Convenio_Medicos_AseguradorasrowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Convenio_Medicos_Aseguradoras-form').modal({ show: false });
    $('#AddDetalle_Convenio_Medicos_Aseguradoras-form').modal('hide');
    Detalle_Convenio_Medicos_AseguradorasEditRow(rowIndex);
    Detalle_Convenio_Medicos_AseguradorasInsertRow(rowIndex);
    //}
}
function Detalle_Convenio_Medicos_AseguradorasRemoveAddRow(rowIndex) {
    Detalle_Convenio_Medicos_AseguradorasTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Convenio_Medicos_Aseguradoras MultiRow
//Begin Declarations for Foreigns fields for Detalle_Titulos_Medicos MultiRow
var Detalle_Titulos_MedicoscountRowsChecked = 0;











function GetInsertDetalle_Titulos_MedicosRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $($.parseHTML(inputData)).addClass('Detalle_Titulos_Medicos_Nombre_del_Titulo Nombre_del_Titulo').attr('id', 'Detalle_Titulos_Medicos_Nombre_del_Titulo_' + index).attr('data-field', 'Nombre_del_Titulo');
    columnData[1] = $($.parseHTML(inputData)).addClass('Detalle_Titulos_Medicos_Institucion_Facultad Institucion_Facultad').attr('id', 'Detalle_Titulos_Medicos_Institucion_Facultad_' + index).attr('data-field', 'Institucion_Facultad');
    columnData[2] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Titulos_Medicos_Fecha_de_Titulacion Fecha_de_Titulacion').attr('id', 'Detalle_Titulos_Medicos_Fecha_de_Titulacion_' + index).attr('data-field', 'Fecha_de_Titulacion');
    columnData[3] = $($.parseHTML(GetFileUploader())).addClass('Detalle_Titulos_Medicos_Titulo_FileUpload Titulo').attr('id', 'Detalle_Titulos_Medicos_Titulo_' + index).attr('data-field', 'Titulo');
    columnData[4] = $($.parseHTML(inputData)).addClass('Detalle_Titulos_Medicos_Numero_de_Cedula Numero_de_Cedula').attr('id', 'Detalle_Titulos_Medicos_Numero_de_Cedula_' + index).attr('data-field', 'Numero_de_Cedula');
    columnData[5] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Titulos_Medicos_Fecha_de_Expedicion Fecha_de_Expedicion').attr('id', 'Detalle_Titulos_Medicos_Fecha_de_Expedicion_' + index).attr('data-field', 'Fecha_de_Expedicion');
    columnData[6] = $($.parseHTML(GetFileUploader())).addClass('Detalle_Titulos_Medicos_Cedula_Frente_FileUpload Cedula_Frente').attr('id', 'Detalle_Titulos_Medicos_Cedula_Frente_' + index).attr('data-field', 'Cedula_Frente');
    columnData[7] = $($.parseHTML(GetFileUploader())).addClass('Detalle_Titulos_Medicos_Cedula_Reverso_FileUpload Cedula_Reverso').attr('id', 'Detalle_Titulos_Medicos_Cedula_Reverso_' + index).attr('data-field', 'Cedula_Reverso');


    initiateUIControls();
    return columnData;
}

function Detalle_Titulos_MedicosInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Titulos_Medicos("Detalle_Titulos_Medicos_", "_" + rowIndex)) {
    var iPage = Detalle_Titulos_MedicosTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Titulos_Medicos';
    var prevData = Detalle_Titulos_MedicosTable.fnGetData(rowIndex);
    var data = Detalle_Titulos_MedicosTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Nombre_del_Titulo:  data.childNodes[counter++].childNodes[0].value
        ,Institucion_Facultad:  data.childNodes[counter++].childNodes[0].value
        ,Fecha_de_Titulacion:  data.childNodes[counter++].childNodes[0].value
        ,TituloFileInfo: ($('#' + nameOfGrid + 'Grid .TituloHeader').css('display') != 'none') ? { 
             FileName: prevData.TituloFileInfo != null && prevData.TituloFileInfo.FileName != null && prevData.TituloFileInfo.FileName != ''? prevData.TituloFileInfo.FileName : (data.childNodes[counter].childNodes[0].files.length > 0 ? data.childNodes[counter].childNodes[0].files[0].name : ''),              
			 FileId:   prevData.TituloFileInfo != null && prevData.TituloFileInfo.FileName != null && prevData.TituloFileInfo.FileName != '' ? prevData.TituloFileInfo.FileId :  prevData.TituloFileInfo != null && prevData.TituloFileInfo.FileId != '' && prevData.TituloFileInfo.FileId != undefined ? prevData.TituloFileInfo.FileId : '0',
             FileSize: prevData.TituloFileInfo != null && prevData.TituloFileInfo.FileName != null ? prevData.TituloFileInfo.FileSize : (data.childNodes[counter].childNodes[0].files.length > 0 ? data.childNodes[counter].childNodes[0].files[0].name : '') 
         } : ''
        ,TituloDetail: (data.childNodes[counter] != 'undefined' && data.childNodes[counter].childNodes[0].childNodes.length == 0) ? data.childNodes[counter++].childNodes[0] : prevData.TituloDetail
        ,Numero_de_Cedula:  data.childNodes[counter++].childNodes[0].value
        ,Fecha_de_Expedicion:  data.childNodes[counter++].childNodes[0].value
        ,Cedula_FrenteFileInfo: ($('#' + nameOfGrid + 'Grid .Cedula_FrenteHeader').css('display') != 'none') ? { 
             FileName: prevData.Cedula_FrenteFileInfo != null && prevData.Cedula_FrenteFileInfo.FileName != null && prevData.Cedula_FrenteFileInfo.FileName != ''? prevData.Cedula_FrenteFileInfo.FileName : (data.childNodes[counter].childNodes[0].files.length > 0 ? data.childNodes[counter].childNodes[0].files[0].name : ''),              
			 FileId:   prevData.Cedula_FrenteFileInfo != null && prevData.Cedula_FrenteFileInfo.FileName != null && prevData.Cedula_FrenteFileInfo.FileName != '' ? prevData.Cedula_FrenteFileInfo.FileId :  prevData.Cedula_FrenteFileInfo != null && prevData.Cedula_FrenteFileInfo.FileId != '' && prevData.Cedula_FrenteFileInfo.FileId != undefined ? prevData.Cedula_FrenteFileInfo.FileId : '0',
             FileSize: prevData.Cedula_FrenteFileInfo != null && prevData.Cedula_FrenteFileInfo.FileName != null ? prevData.Cedula_FrenteFileInfo.FileSize : (data.childNodes[counter].childNodes[0].files.length > 0 ? data.childNodes[counter].childNodes[0].files[0].name : '') 
         } : ''
        ,Cedula_FrenteDetail: (data.childNodes[counter] != 'undefined' && data.childNodes[counter].childNodes[0].childNodes.length == 0) ? data.childNodes[counter++].childNodes[0] : prevData.Cedula_FrenteDetail
        ,Cedula_ReversoFileInfo: ($('#' + nameOfGrid + 'Grid .Cedula_ReversoHeader').css('display') != 'none') ? { 
             FileName: prevData.Cedula_ReversoFileInfo != null && prevData.Cedula_ReversoFileInfo.FileName != null && prevData.Cedula_ReversoFileInfo.FileName != ''? prevData.Cedula_ReversoFileInfo.FileName : (data.childNodes[counter].childNodes[0].files.length > 0 ? data.childNodes[counter].childNodes[0].files[0].name : ''),              
			 FileId:   prevData.Cedula_ReversoFileInfo != null && prevData.Cedula_ReversoFileInfo.FileName != null && prevData.Cedula_ReversoFileInfo.FileName != '' ? prevData.Cedula_ReversoFileInfo.FileId :  prevData.Cedula_ReversoFileInfo != null && prevData.Cedula_ReversoFileInfo.FileId != '' && prevData.Cedula_ReversoFileInfo.FileId != undefined ? prevData.Cedula_ReversoFileInfo.FileId : '0',
             FileSize: prevData.Cedula_ReversoFileInfo != null && prevData.Cedula_ReversoFileInfo.FileName != null ? prevData.Cedula_ReversoFileInfo.FileSize : (data.childNodes[counter].childNodes[0].files.length > 0 ? data.childNodes[counter].childNodes[0].files[0].name : '') 
         } : ''
        ,Cedula_ReversoDetail: (data.childNodes[counter] != 'undefined' && data.childNodes[counter].childNodes[0].childNodes.length == 0) ? data.childNodes[counter++].childNodes[0] : prevData.Cedula_ReversoDetail

    }
    Detalle_Titulos_MedicosTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Titulos_MedicosrowCreationGrid(data, newData, rowIndex);
    Detalle_Titulos_MedicosTable.fnPageChange(iPage);
    Detalle_Titulos_MedicoscountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Titulos_Medicos("Detalle_Titulos_Medicos_", "_" + rowIndex);
  }
}

function Detalle_Titulos_MedicosCancelRow(rowIndex) {
    var prevData = Detalle_Titulos_MedicosTable.fnGetData(rowIndex);
    var data = Detalle_Titulos_MedicosTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Titulos_MedicosTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Titulos_MedicosrowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Titulos_MedicosGrid(Detalle_Titulos_MedicosTable.fnGetData());
    Detalle_Titulos_MedicoscountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Titulos_MedicosFromDataTable() {
    var Detalle_Titulos_MedicosData = [];
    var gridData = Detalle_Titulos_MedicosTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Titulos_MedicosData.push({
                Folio: gridData[i].Folio

                ,Nombre_del_Titulo: gridData[i].Nombre_del_Titulo
                ,Institucion_Facultad: gridData[i].Institucion_Facultad
                ,Fecha_de_Titulacion: gridData[i].Fecha_de_Titulacion
                ,TituloInfo: {
                    FileName: gridData[i].TituloFileInfo.FileName, FileId: gridData[i].TituloFileInfo.FileId, FileSize: gridData[i].TituloFileInfo.FileSize,
                    Control: gridData[i].TituloDetail != null && gridData[i].TituloDetail.files != null && gridData[i].TituloDetail.files.length > 0 ? gridData[i].TituloDetail.files[0] : null,
                    TituloRemoveFile: gridData[i].TituloDetail != null
                }
                ,Numero_de_Cedula: gridData[i].Numero_de_Cedula
                ,Fecha_de_Expedicion: gridData[i].Fecha_de_Expedicion
                ,Cedula_FrenteInfo: {
                    FileName: gridData[i].Cedula_FrenteFileInfo.FileName, FileId: gridData[i].Cedula_FrenteFileInfo.FileId, FileSize: gridData[i].Cedula_FrenteFileInfo.FileSize,
                    Control: gridData[i].Cedula_FrenteDetail != null && gridData[i].Cedula_FrenteDetail.files != null && gridData[i].Cedula_FrenteDetail.files.length > 0 ? gridData[i].Cedula_FrenteDetail.files[0] : null,
                    Cedula_FrenteRemoveFile: gridData[i].Cedula_FrenteDetail != null
                }
                ,Cedula_ReversoInfo: {
                    FileName: gridData[i].Cedula_ReversoFileInfo.FileName, FileId: gridData[i].Cedula_ReversoFileInfo.FileId, FileSize: gridData[i].Cedula_ReversoFileInfo.FileSize,
                    Control: gridData[i].Cedula_ReversoDetail != null && gridData[i].Cedula_ReversoDetail.files != null && gridData[i].Cedula_ReversoDetail.files.length > 0 ? gridData[i].Cedula_ReversoDetail.files[0] : null,
                    Cedula_ReversoRemoveFile: gridData[i].Cedula_ReversoDetail != null
                }

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Titulos_MedicosData.length; i++) {
        if (removedDetalle_Titulos_MedicosData[i] != null && removedDetalle_Titulos_MedicosData[i].Folio > 0)
            Detalle_Titulos_MedicosData.push({
                Folio: removedDetalle_Titulos_MedicosData[i].Folio

                ,Nombre_del_Titulo: removedDetalle_Titulos_MedicosData[i].Nombre_del_Titulo
                ,Institucion_Facultad: removedDetalle_Titulos_MedicosData[i].Institucion_Facultad
                ,Fecha_de_Titulacion: removedDetalle_Titulos_MedicosData[i].Fecha_de_Titulacion
                ,TituloInfo: {
                    FileName: removedDetalle_Titulos_MedicosData[i].TituloFileInfo.FileName, 
                    FileId: removedDetalle_Titulos_MedicosData[i].TituloFileInfo.FileId, 
                    FileSize: removedDetalle_Titulos_MedicosData[i].TituloFileInfo.FileSize,
                    Control: removedDetalle_Titulos_MedicosData[i].TituloDetail != null && removedDetalle_Titulos_MedicosData[i].TituloDetail.files.length > 0 ? removedDetalle_Titulos_MedicosData[i].TituloDetail.files[0] : null,
                    TituloRemoveFile: removedDetalle_Titulos_MedicosData[i].TituloDetail != null
                }
                ,Numero_de_Cedula: removedDetalle_Titulos_MedicosData[i].Numero_de_Cedula
                ,Fecha_de_Expedicion: removedDetalle_Titulos_MedicosData[i].Fecha_de_Expedicion
                ,Cedula_FrenteInfo: {
                    FileName: removedDetalle_Titulos_MedicosData[i].Cedula_FrenteFileInfo.FileName, 
                    FileId: removedDetalle_Titulos_MedicosData[i].Cedula_FrenteFileInfo.FileId, 
                    FileSize: removedDetalle_Titulos_MedicosData[i].Cedula_FrenteFileInfo.FileSize,
                    Control: removedDetalle_Titulos_MedicosData[i].Cedula_FrenteDetail != null && removedDetalle_Titulos_MedicosData[i].Cedula_FrenteDetail.files.length > 0 ? removedDetalle_Titulos_MedicosData[i].Cedula_FrenteDetail.files[0] : null,
                    Cedula_FrenteRemoveFile: removedDetalle_Titulos_MedicosData[i].Cedula_FrenteDetail != null
                }
                ,Cedula_ReversoInfo: {
                    FileName: removedDetalle_Titulos_MedicosData[i].Cedula_ReversoFileInfo.FileName, 
                    FileId: removedDetalle_Titulos_MedicosData[i].Cedula_ReversoFileInfo.FileId, 
                    FileSize: removedDetalle_Titulos_MedicosData[i].Cedula_ReversoFileInfo.FileSize,
                    Control: removedDetalle_Titulos_MedicosData[i].Cedula_ReversoDetail != null && removedDetalle_Titulos_MedicosData[i].Cedula_ReversoDetail.files.length > 0 ? removedDetalle_Titulos_MedicosData[i].Cedula_ReversoDetail.files[0] : null,
                    Cedula_ReversoRemoveFile: removedDetalle_Titulos_MedicosData[i].Cedula_ReversoDetail != null
                }

                , Removed: true
            });
    }	

    return Detalle_Titulos_MedicosData;
}

function Detalle_Titulos_MedicosEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Titulos_MedicosTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Titulos_MedicoscountRowsChecked++;
    var Detalle_Titulos_MedicosRowElement = "Detalle_Titulos_Medicos_" + rowIndex.toString();
    var prevData = Detalle_Titulos_MedicosTable.fnGetData(rowIndexTable );
    var row = Detalle_Titulos_MedicosTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Titulos_Medicos_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Titulos_MedicosGetUpdateRowControls(prevData, "Detalle_Titulos_Medicos_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Titulos_MedicosRowElement + "')){ Detalle_Titulos_MedicosInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_Titulos_MedicosCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Titulos_MedicosGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Titulos_MedicosGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_Titulos_MedicosValidation();
    initiateUIControls();
    $('.Detalle_Titulos_Medicos' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Titulos_Medicos(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Titulos_MedicosfnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Titulos_MedicosTable.fnGetData().length;
    Detalle_Titulos_MedicosfnClickAddRow();
    GetAddDetalle_Titulos_MedicosPopup(currentRowIndex, 0);
}

function Detalle_Titulos_MedicosEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Titulos_MedicosTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Titulos_MedicosRowElement = "Detalle_Titulos_Medicos_" + rowIndex.toString();
    var prevData = Detalle_Titulos_MedicosTable.fnGetData(rowIndexTable);
    GetAddDetalle_Titulos_MedicosPopup(rowIndex, 1, prevData.Folio);

    $('#Detalle_Titulos_MedicosNombre_del_Titulo').val(prevData.Nombre_del_Titulo);
    $('#Detalle_Titulos_MedicosInstitucion_Facultad').val(prevData.Institucion_Facultad);
    $('#Detalle_Titulos_MedicosFecha_de_Titulacion').val(prevData.Fecha_de_Titulacion);

    $('#Detalle_Titulos_MedicosNumero_de_Cedula').val(prevData.Numero_de_Cedula);
    $('#Detalle_Titulos_MedicosFecha_de_Expedicion').val(prevData.Fecha_de_Expedicion);



    initiateUIControls();




    $('#existingTitulo').html(prevData.TituloFileDetail == null && (prevData.TituloFileInfo.FileId == null || prevData.TituloFileInfo.FileId <= 0) ? $.parseHTML(GetFileUploader()) : GetFileInfo(prevData.TituloFileInfo, prevData.TituloFileDetail));


    $('#existingCedula_Frente').html(prevData.Cedula_FrenteFileDetail == null && (prevData.Cedula_FrenteFileInfo.FileId == null || prevData.Cedula_FrenteFileInfo.FileId <= 0) ? $.parseHTML(GetFileUploader()) : GetFileInfo(prevData.Cedula_FrenteFileInfo, prevData.Cedula_FrenteFileDetail));
    $('#existingCedula_Reverso').html(prevData.Cedula_ReversoFileDetail == null && (prevData.Cedula_ReversoFileInfo.FileId == null || prevData.Cedula_ReversoFileInfo.FileId <= 0) ? $.parseHTML(GetFileUploader()) : GetFileInfo(prevData.Cedula_ReversoFileInfo, prevData.Cedula_ReversoFileDetail));

}

function Detalle_Titulos_MedicosAddInsertRow() {
    if (Detalle_Titulos_MedicosinsertRowCurrentIndex < 1)
    {
        Detalle_Titulos_MedicosinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Nombre_del_Titulo: ""
        ,Institucion_Facultad: ""
        ,Fecha_de_Titulacion: ""
        ,TituloFileInfo: ""
        ,Numero_de_Cedula: ""
        ,Fecha_de_Expedicion: ""
        ,Cedula_FrenteFileInfo: ""
        ,Cedula_ReversoFileInfo: ""

    }
}

function Detalle_Titulos_MedicosfnClickAddRow() {
    Detalle_Titulos_MedicoscountRowsChecked++;
    Detalle_Titulos_MedicosTable.fnAddData(Detalle_Titulos_MedicosAddInsertRow(), true);
    Detalle_Titulos_MedicosTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_Titulos_MedicosGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_Titulos_MedicosGrid tbody tr:nth-of-type(' + (Detalle_Titulos_MedicosinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Titulos_Medicos("Detalle_Titulos_Medicos_", "_" + Detalle_Titulos_MedicosinsertRowCurrentIndex);
}

function Detalle_Titulos_MedicosClearGridData() {
    Detalle_Titulos_MedicosData = [];
    Detalle_Titulos_MedicosdeletedItem = [];
    Detalle_Titulos_MedicosDataMain = [];
    Detalle_Titulos_MedicosDataMainPages = [];
    Detalle_Titulos_MedicosnewItemCount = 0;
    Detalle_Titulos_MedicosmaxItemIndex = 0;
    $("#Detalle_Titulos_MedicosGrid").DataTable().clear();
    $("#Detalle_Titulos_MedicosGrid").DataTable().destroy();
}

//Used to Get Especialistas Information
function GetDetalle_Titulos_Medicos() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Titulos_MedicosData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Titulos_MedicosData[i].Folio);

        form_data.append('[' + i + '].Nombre_del_Titulo', Detalle_Titulos_MedicosData[i].Nombre_del_Titulo);
        form_data.append('[' + i + '].Institucion_Facultad', Detalle_Titulos_MedicosData[i].Institucion_Facultad);
        form_data.append('[' + i + '].Fecha_de_Titulacion', Detalle_Titulos_MedicosData[i].Fecha_de_Titulacion);
        form_data.append('[' + i + '].TituloInfo.FileId', Detalle_Titulos_MedicosData[i].TituloInfo.FileId);
        form_data.append('[' + i + '].TituloInfo.FileName', Detalle_Titulos_MedicosData[i].TituloInfo.FileName);
        form_data.append('[' + i + '].TituloInfo.FileSize', Detalle_Titulos_MedicosData[i].TituloInfo.FileSize);
        form_data.append('[' + i + '].TituloInfo.Control', Detalle_Titulos_MedicosData[i].TituloInfo.Control);
        form_data.append('[' + i + '].TituloInfo.RemoveFile', Detalle_Titulos_MedicosData[i].TituloInfo.ArchivoRemoveFile);
        form_data.append('[' + i + '].Numero_de_Cedula', Detalle_Titulos_MedicosData[i].Numero_de_Cedula);
        form_data.append('[' + i + '].Fecha_de_Expedicion', Detalle_Titulos_MedicosData[i].Fecha_de_Expedicion);
        form_data.append('[' + i + '].Cedula_FrenteInfo.FileId', Detalle_Titulos_MedicosData[i].Cedula_FrenteInfo.FileId);
        form_data.append('[' + i + '].Cedula_FrenteInfo.FileName', Detalle_Titulos_MedicosData[i].Cedula_FrenteInfo.FileName);
        form_data.append('[' + i + '].Cedula_FrenteInfo.FileSize', Detalle_Titulos_MedicosData[i].Cedula_FrenteInfo.FileSize);
        form_data.append('[' + i + '].Cedula_FrenteInfo.Control', Detalle_Titulos_MedicosData[i].Cedula_FrenteInfo.Control);
        form_data.append('[' + i + '].Cedula_FrenteInfo.RemoveFile', Detalle_Titulos_MedicosData[i].Cedula_FrenteInfo.ArchivoRemoveFile);
        form_data.append('[' + i + '].Cedula_ReversoInfo.FileId', Detalle_Titulos_MedicosData[i].Cedula_ReversoInfo.FileId);
        form_data.append('[' + i + '].Cedula_ReversoInfo.FileName', Detalle_Titulos_MedicosData[i].Cedula_ReversoInfo.FileName);
        form_data.append('[' + i + '].Cedula_ReversoInfo.FileSize', Detalle_Titulos_MedicosData[i].Cedula_ReversoInfo.FileSize);
        form_data.append('[' + i + '].Cedula_ReversoInfo.Control', Detalle_Titulos_MedicosData[i].Cedula_ReversoInfo.Control);
        form_data.append('[' + i + '].Cedula_ReversoInfo.RemoveFile', Detalle_Titulos_MedicosData[i].Cedula_ReversoInfo.ArchivoRemoveFile);

        form_data.append('[' + i + '].Removed', Detalle_Titulos_MedicosData[i].Removed);
    }
    return form_data;
}
function Detalle_Titulos_MedicosInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Titulos_Medicos("Detalle_Titulos_MedicosTable", rowIndex)) {
    var prevData = Detalle_Titulos_MedicosTable.fnGetData(rowIndex);
    var data = Detalle_Titulos_MedicosTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Nombre_del_Titulo: $('#Detalle_Titulos_MedicosNombre_del_Titulo').val()
        ,Institucion_Facultad: $('#Detalle_Titulos_MedicosInstitucion_Facultad').val()
        ,Fecha_de_Titulacion: $('#Detalle_Titulos_MedicosFecha_de_Titulacion').val()
        ,TituloFileInfo: { TituloFileName: prevData.TituloFileInfo.FileName, TituloFileId: prevData.TituloFileInfo.FileId, TituloFileSize: prevData.TituloFileInfo.FileSize }
        ,TituloFileDetail: $('#Titulo').find('label').length == 0 ? $('#TituloFileInfoPop')[0] : prevData.TituloFileDetail
        ,Numero_de_Cedula: $('#Detalle_Titulos_MedicosNumero_de_Cedula').val()
        ,Fecha_de_Expedicion: $('#Detalle_Titulos_MedicosFecha_de_Expedicion').val()
        ,Cedula_FrenteFileInfo: { Cedula_FrenteFileName: prevData.Cedula_FrenteFileInfo.FileName, Cedula_FrenteFileId: prevData.Cedula_FrenteFileInfo.FileId, Cedula_FrenteFileSize: prevData.Cedula_FrenteFileInfo.FileSize }
        ,Cedula_FrenteFileDetail: $('#Cedula_Frente').find('label').length == 0 ? $('#Cedula_FrenteFileInfoPop')[0] : prevData.Cedula_FrenteFileDetail
        ,Cedula_ReversoFileInfo: { Cedula_ReversoFileName: prevData.Cedula_ReversoFileInfo.FileName, Cedula_ReversoFileId: prevData.Cedula_ReversoFileInfo.FileId, Cedula_ReversoFileSize: prevData.Cedula_ReversoFileInfo.FileSize }
        ,Cedula_ReversoFileDetail: $('#Cedula_Reverso').find('label').length == 0 ? $('#Cedula_ReversoFileInfoPop')[0] : prevData.Cedula_ReversoFileDetail

    }

    Detalle_Titulos_MedicosTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Titulos_MedicosrowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Titulos_Medicos-form').modal({ show: false });
    $('#AddDetalle_Titulos_Medicos-form').modal('hide');
    Detalle_Titulos_MedicosEditRow(rowIndex);
    Detalle_Titulos_MedicosInsertRow(rowIndex);
    //}
}
function Detalle_Titulos_MedicosRemoveAddRow(rowIndex) {
    Detalle_Titulos_MedicosTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Titulos_Medicos MultiRow
//Begin Declarations for Foreigns fields for Detalle_Identificacion_Oficial_Medicos MultiRow
var Detalle_Identificacion_Oficial_MedicoscountRowsChecked = 0;

function GetDetalle_Identificacion_Oficial_Medicos_Identificaciones_OficialesName(Id) {
    for (var i = 0; i < Detalle_Identificacion_Oficial_Medicos_Identificaciones_OficialesItems.length; i++) {
        if (Detalle_Identificacion_Oficial_Medicos_Identificaciones_OficialesItems[i].Clave == Id) {
            return Detalle_Identificacion_Oficial_Medicos_Identificaciones_OficialesItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Identificacion_Oficial_Medicos_Identificaciones_OficialesDropDown() {
    var Detalle_Identificacion_Oficial_Medicos_Identificaciones_OficialesDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Identificacion_Oficial_Medicos_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Identificacion_Oficial_Medicos_Identificaciones_OficialesDropdown);
    if(Detalle_Identificacion_Oficial_Medicos_Identificaciones_OficialesItems != null)
    {
       for (var i = 0; i < Detalle_Identificacion_Oficial_Medicos_Identificaciones_OficialesItems.length; i++) {
           $('<option />', { value: Detalle_Identificacion_Oficial_Medicos_Identificaciones_OficialesItems[i].Clave, text:    Detalle_Identificacion_Oficial_Medicos_Identificaciones_OficialesItems[i].Descripcion }).appendTo(Detalle_Identificacion_Oficial_Medicos_Identificaciones_OficialesDropdown);
       }
    }
    return Detalle_Identificacion_Oficial_Medicos_Identificaciones_OficialesDropdown;
}



function GetInsertDetalle_Identificacion_Oficial_MedicosRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $(GetDetalle_Identificacion_Oficial_Medicos_Identificaciones_OficialesDropDown()).addClass('Detalle_Identificacion_Oficial_Medicos_Tipo_de_Identificacion_Oficial Tipo_de_Identificacion_Oficial').attr('id', 'Detalle_Identificacion_Oficial_Medicos_Tipo_de_Identificacion_Oficial_' + index).attr('data-field', 'Tipo_de_Identificacion_Oficial').after($.parseHTML(addNew('Detalle_Identificacion_Oficial_Medicos', 'Identificaciones_Oficiales', 'Tipo_de_Identificacion_Oficial', 258294)));
    columnData[1] = $($.parseHTML(GetFileUploader())).addClass('Detalle_Identificacion_Oficial_Medicos_Documento_FileUpload Documento').attr('id', 'Detalle_Identificacion_Oficial_Medicos_Documento_' + index).attr('data-field', 'Documento');


    initiateUIControls();
    return columnData;
}

function Detalle_Identificacion_Oficial_MedicosInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Identificacion_Oficial_Medicos("Detalle_Identificacion_Oficial_Medicos_", "_" + rowIndex)) {
    var iPage = Detalle_Identificacion_Oficial_MedicosTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Identificacion_Oficial_Medicos';
    var prevData = Detalle_Identificacion_Oficial_MedicosTable.fnGetData(rowIndex);
    var data = Detalle_Identificacion_Oficial_MedicosTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Tipo_de_Identificacion_Oficial:  data.childNodes[counter++].childNodes[0].value
        ,DocumentoFileInfo: ($('#' + nameOfGrid + 'Grid .DocumentoHeader').css('display') != 'none') ? { 
             FileName: prevData.DocumentoFileInfo != null && prevData.DocumentoFileInfo.FileName != null && prevData.DocumentoFileInfo.FileName != ''? prevData.DocumentoFileInfo.FileName : (data.childNodes[counter].childNodes[0].files.length > 0 ? data.childNodes[counter].childNodes[0].files[0].name : ''),              
			 FileId:   prevData.DocumentoFileInfo != null && prevData.DocumentoFileInfo.FileName != null && prevData.DocumentoFileInfo.FileName != '' ? prevData.DocumentoFileInfo.FileId :  prevData.DocumentoFileInfo != null && prevData.DocumentoFileInfo.FileId != '' && prevData.DocumentoFileInfo.FileId != undefined ? prevData.DocumentoFileInfo.FileId : '0',
             FileSize: prevData.DocumentoFileInfo != null && prevData.DocumentoFileInfo.FileName != null ? prevData.DocumentoFileInfo.FileSize : (data.childNodes[counter].childNodes[0].files.length > 0 ? data.childNodes[counter].childNodes[0].files[0].name : '') 
         } : ''
        ,DocumentoDetail: (data.childNodes[counter] != 'undefined' && data.childNodes[counter].childNodes[0].childNodes.length == 0) ? data.childNodes[counter++].childNodes[0] : prevData.DocumentoDetail

    }
    Detalle_Identificacion_Oficial_MedicosTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Identificacion_Oficial_MedicosrowCreationGrid(data, newData, rowIndex);
    Detalle_Identificacion_Oficial_MedicosTable.fnPageChange(iPage);
    Detalle_Identificacion_Oficial_MedicoscountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Identificacion_Oficial_Medicos("Detalle_Identificacion_Oficial_Medicos_", "_" + rowIndex);
  }
}

function Detalle_Identificacion_Oficial_MedicosCancelRow(rowIndex) {
    var prevData = Detalle_Identificacion_Oficial_MedicosTable.fnGetData(rowIndex);
    var data = Detalle_Identificacion_Oficial_MedicosTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Identificacion_Oficial_MedicosTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Identificacion_Oficial_MedicosrowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Identificacion_Oficial_MedicosGrid(Detalle_Identificacion_Oficial_MedicosTable.fnGetData());
    Detalle_Identificacion_Oficial_MedicoscountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Identificacion_Oficial_MedicosFromDataTable() {
    var Detalle_Identificacion_Oficial_MedicosData = [];
    var gridData = Detalle_Identificacion_Oficial_MedicosTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Identificacion_Oficial_MedicosData.push({
                Folio: gridData[i].Folio

                ,Tipo_de_Identificacion_Oficial: gridData[i].Tipo_de_Identificacion_Oficial
                ,DocumentoInfo: {
                    FileName: gridData[i].DocumentoFileInfo.FileName, FileId: gridData[i].DocumentoFileInfo.FileId, FileSize: gridData[i].DocumentoFileInfo.FileSize,
                    Control: gridData[i].DocumentoDetail != null && gridData[i].DocumentoDetail.files != null && gridData[i].DocumentoDetail.files.length > 0 ? gridData[i].DocumentoDetail.files[0] : null,
                    DocumentoRemoveFile: gridData[i].DocumentoDetail != null
                }

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Identificacion_Oficial_MedicosData.length; i++) {
        if (removedDetalle_Identificacion_Oficial_MedicosData[i] != null && removedDetalle_Identificacion_Oficial_MedicosData[i].Folio > 0)
            Detalle_Identificacion_Oficial_MedicosData.push({
                Folio: removedDetalle_Identificacion_Oficial_MedicosData[i].Folio

                ,Tipo_de_Identificacion_Oficial: removedDetalle_Identificacion_Oficial_MedicosData[i].Tipo_de_Identificacion_Oficial
                ,DocumentoInfo: {
                    FileName: removedDetalle_Identificacion_Oficial_MedicosData[i].DocumentoFileInfo.FileName, 
                    FileId: removedDetalle_Identificacion_Oficial_MedicosData[i].DocumentoFileInfo.FileId, 
                    FileSize: removedDetalle_Identificacion_Oficial_MedicosData[i].DocumentoFileInfo.FileSize,
                    Control: removedDetalle_Identificacion_Oficial_MedicosData[i].DocumentoDetail != null && removedDetalle_Identificacion_Oficial_MedicosData[i].DocumentoDetail.files.length > 0 ? removedDetalle_Identificacion_Oficial_MedicosData[i].DocumentoDetail.files[0] : null,
                    DocumentoRemoveFile: removedDetalle_Identificacion_Oficial_MedicosData[i].DocumentoDetail != null
                }

                , Removed: true
            });
    }	

    return Detalle_Identificacion_Oficial_MedicosData;
}

function Detalle_Identificacion_Oficial_MedicosEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Identificacion_Oficial_MedicosTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Identificacion_Oficial_MedicoscountRowsChecked++;
    var Detalle_Identificacion_Oficial_MedicosRowElement = "Detalle_Identificacion_Oficial_Medicos_" + rowIndex.toString();
    var prevData = Detalle_Identificacion_Oficial_MedicosTable.fnGetData(rowIndexTable );
    var row = Detalle_Identificacion_Oficial_MedicosTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Identificacion_Oficial_Medicos_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Identificacion_Oficial_MedicosGetUpdateRowControls(prevData, "Detalle_Identificacion_Oficial_Medicos_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Identificacion_Oficial_MedicosRowElement + "')){ Detalle_Identificacion_Oficial_MedicosInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_Identificacion_Oficial_MedicosCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Identificacion_Oficial_MedicosGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Identificacion_Oficial_MedicosGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_Identificacion_Oficial_MedicosValidation();
    initiateUIControls();
    $('.Detalle_Identificacion_Oficial_Medicos' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Identificacion_Oficial_Medicos(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Identificacion_Oficial_MedicosfnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Identificacion_Oficial_MedicosTable.fnGetData().length;
    Detalle_Identificacion_Oficial_MedicosfnClickAddRow();
    GetAddDetalle_Identificacion_Oficial_MedicosPopup(currentRowIndex, 0);
}

function Detalle_Identificacion_Oficial_MedicosEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Identificacion_Oficial_MedicosTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Identificacion_Oficial_MedicosRowElement = "Detalle_Identificacion_Oficial_Medicos_" + rowIndex.toString();
    var prevData = Detalle_Identificacion_Oficial_MedicosTable.fnGetData(rowIndexTable);
    GetAddDetalle_Identificacion_Oficial_MedicosPopup(rowIndex, 1, prevData.Folio);

    $('#Detalle_Identificacion_Oficial_MedicosTipo_de_Identificacion_Oficial').val(prevData.Tipo_de_Identificacion_Oficial);


    initiateUIControls();


    $('#existingDocumento').html(prevData.DocumentoFileDetail == null && (prevData.DocumentoFileInfo.FileId == null || prevData.DocumentoFileInfo.FileId <= 0) ? $.parseHTML(GetFileUploader()) : GetFileInfo(prevData.DocumentoFileInfo, prevData.DocumentoFileDetail));

}

function Detalle_Identificacion_Oficial_MedicosAddInsertRow() {
    if (Detalle_Identificacion_Oficial_MedicosinsertRowCurrentIndex < 1)
    {
        Detalle_Identificacion_Oficial_MedicosinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Tipo_de_Identificacion_Oficial: ""
        ,DocumentoFileInfo: ""

    }
}

function Detalle_Identificacion_Oficial_MedicosfnClickAddRow() {
    Detalle_Identificacion_Oficial_MedicoscountRowsChecked++;
    Detalle_Identificacion_Oficial_MedicosTable.fnAddData(Detalle_Identificacion_Oficial_MedicosAddInsertRow(), true);
    Detalle_Identificacion_Oficial_MedicosTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_Identificacion_Oficial_MedicosGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_Identificacion_Oficial_MedicosGrid tbody tr:nth-of-type(' + (Detalle_Identificacion_Oficial_MedicosinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Identificacion_Oficial_Medicos("Detalle_Identificacion_Oficial_Medicos_", "_" + Detalle_Identificacion_Oficial_MedicosinsertRowCurrentIndex);
}

function Detalle_Identificacion_Oficial_MedicosClearGridData() {
    Detalle_Identificacion_Oficial_MedicosData = [];
    Detalle_Identificacion_Oficial_MedicosdeletedItem = [];
    Detalle_Identificacion_Oficial_MedicosDataMain = [];
    Detalle_Identificacion_Oficial_MedicosDataMainPages = [];
    Detalle_Identificacion_Oficial_MedicosnewItemCount = 0;
    Detalle_Identificacion_Oficial_MedicosmaxItemIndex = 0;
    $("#Detalle_Identificacion_Oficial_MedicosGrid").DataTable().clear();
    $("#Detalle_Identificacion_Oficial_MedicosGrid").DataTable().destroy();
}

//Used to Get Especialistas Information
function GetDetalle_Identificacion_Oficial_Medicos() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Identificacion_Oficial_MedicosData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Identificacion_Oficial_MedicosData[i].Folio);

        form_data.append('[' + i + '].Tipo_de_Identificacion_Oficial', Detalle_Identificacion_Oficial_MedicosData[i].Tipo_de_Identificacion_Oficial);
        form_data.append('[' + i + '].DocumentoInfo.FileId', Detalle_Identificacion_Oficial_MedicosData[i].DocumentoInfo.FileId);
        form_data.append('[' + i + '].DocumentoInfo.FileName', Detalle_Identificacion_Oficial_MedicosData[i].DocumentoInfo.FileName);
        form_data.append('[' + i + '].DocumentoInfo.FileSize', Detalle_Identificacion_Oficial_MedicosData[i].DocumentoInfo.FileSize);
        form_data.append('[' + i + '].DocumentoInfo.Control', Detalle_Identificacion_Oficial_MedicosData[i].DocumentoInfo.Control);
        form_data.append('[' + i + '].DocumentoInfo.RemoveFile', Detalle_Identificacion_Oficial_MedicosData[i].DocumentoInfo.ArchivoRemoveFile);

        form_data.append('[' + i + '].Removed', Detalle_Identificacion_Oficial_MedicosData[i].Removed);
    }
    return form_data;
}
function Detalle_Identificacion_Oficial_MedicosInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Identificacion_Oficial_Medicos("Detalle_Identificacion_Oficial_MedicosTable", rowIndex)) {
    var prevData = Detalle_Identificacion_Oficial_MedicosTable.fnGetData(rowIndex);
    var data = Detalle_Identificacion_Oficial_MedicosTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Tipo_de_Identificacion_Oficial: $('#Detalle_Identificacion_Oficial_MedicosTipo_de_Identificacion_Oficial').val()
        ,DocumentoFileInfo: { DocumentoFileName: prevData.DocumentoFileInfo.FileName, DocumentoFileId: prevData.DocumentoFileInfo.FileId, DocumentoFileSize: prevData.DocumentoFileInfo.FileSize }
        ,DocumentoFileDetail: $('#Documento').find('label').length == 0 ? $('#DocumentoFileInfoPop')[0] : prevData.DocumentoFileDetail

    }

    Detalle_Identificacion_Oficial_MedicosTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Identificacion_Oficial_MedicosrowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Identificacion_Oficial_Medicos-form').modal({ show: false });
    $('#AddDetalle_Identificacion_Oficial_Medicos-form').modal('hide');
    Detalle_Identificacion_Oficial_MedicosEditRow(rowIndex);
    Detalle_Identificacion_Oficial_MedicosInsertRow(rowIndex);
    //}
}
function Detalle_Identificacion_Oficial_MedicosRemoveAddRow(rowIndex) {
    Detalle_Identificacion_Oficial_MedicosTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Identificacion_Oficial_Medicos MultiRow
//Begin Declarations for Foreigns fields for Detalle_Codigos_Referidos MultiRow
var Detalle_Codigos_ReferidoscountRowsChecked = 0;








function GetDetalle_Codigos_Referidos_Spartan_UserName(Id) {
    for (var i = 0; i < Detalle_Codigos_Referidos_Spartan_UserItems.length; i++) {
        if (Detalle_Codigos_Referidos_Spartan_UserItems[i].Id_User == Id) {
            return Detalle_Codigos_Referidos_Spartan_UserItems[i].Name;
        }
    }
    return "";
}

function GetDetalle_Codigos_Referidos_Spartan_UserDropDown() {
    var Detalle_Codigos_Referidos_Spartan_UserDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Codigos_Referidos_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Codigos_Referidos_Spartan_UserDropdown);
    if(Detalle_Codigos_Referidos_Spartan_UserItems != null)
    {
       for (var i = 0; i < Detalle_Codigos_Referidos_Spartan_UserItems.length; i++) {
           $('<option />', { value: Detalle_Codigos_Referidos_Spartan_UserItems[i].Id_User, text:    Detalle_Codigos_Referidos_Spartan_UserItems[i].Name }).appendTo(Detalle_Codigos_Referidos_Spartan_UserDropdown);
       }
    }
    return Detalle_Codigos_Referidos_Spartan_UserDropdown;
}


function GetDetalle_Codigos_Referidos_EstatusName(Id) {
    for (var i = 0; i < Detalle_Codigos_Referidos_EstatusItems.length; i++) {
        if (Detalle_Codigos_Referidos_EstatusItems[i].Clave == Id) {
            return Detalle_Codigos_Referidos_EstatusItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Codigos_Referidos_EstatusDropDown() {
    var Detalle_Codigos_Referidos_EstatusDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Codigos_Referidos_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Codigos_Referidos_EstatusDropdown);
    if(Detalle_Codigos_Referidos_EstatusItems != null)
    {
       for (var i = 0; i < Detalle_Codigos_Referidos_EstatusItems.length; i++) {
           $('<option />', { value: Detalle_Codigos_Referidos_EstatusItems[i].Clave, text:    Detalle_Codigos_Referidos_EstatusItems[i].Descripcion }).appendTo(Detalle_Codigos_Referidos_EstatusDropdown);
       }
    }
    return Detalle_Codigos_Referidos_EstatusDropdown;
}


function GetInsertDetalle_Codigos_ReferidosRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";


    columnData[0] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Codigos_Referidos_Porcentaje_de_descuento Porcentaje_de_descuento').attr('id', 'Detalle_Codigos_Referidos_Porcentaje_de_descuento_' + index).attr('data-field', 'Porcentaje_de_descuento');
    columnData[1] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Codigos_Referidos_Fecha_inicio_vigencia Fecha_inicio_vigencia').attr('id', 'Detalle_Codigos_Referidos_Fecha_inicio_vigencia_' + index).attr('data-field', 'Fecha_inicio_vigencia');
    columnData[2] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Codigos_Referidos_Fecha_fin_vigencia Fecha_fin_vigencia').attr('id', 'Detalle_Codigos_Referidos_Fecha_fin_vigencia_' + index).attr('data-field', 'Fecha_fin_vigencia');
    columnData[3] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Codigos_Referidos_Cantidad_maxima_de_referenciados Cantidad_maxima_de_referenciados').attr('id', 'Detalle_Codigos_Referidos_Cantidad_maxima_de_referenciados_' + index).attr('data-field', 'Cantidad_maxima_de_referenciados');
    columnData[4] = $($.parseHTML(inputData)).addClass('Detalle_Codigos_Referidos_Codigo_para_Referenciados Codigo_para_Referenciados').attr('id', 'Detalle_Codigos_Referidos_Codigo_para_Referenciados_' + index).attr('data-field', 'Codigo_para_Referenciados');
    columnData[5] = $($.parseHTML(GetGridCheckBox())).addClass('Detalle_Codigos_Referidos_Autorizado Autorizado').attr('id', 'Detalle_Codigos_Referidos_Autorizado_' + index).attr('data-field', 'Autorizado');
    columnData[6] = $(GetDetalle_Codigos_Referidos_Spartan_UserDropDown()).addClass('Detalle_Codigos_Referidos_Usuario_que_autoriza Usuario_que_autoriza').attr('id', 'Detalle_Codigos_Referidos_Usuario_que_autoriza_' + index).attr('data-field', 'Usuario_que_autoriza').after($.parseHTML(addNew('Detalle_Codigos_Referidos', 'Spartan_User', 'Usuario_que_autoriza', 258622)));
    columnData[7] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Codigos_Referidos_Fecha_de_autorizacion Fecha_de_autorizacion').attr('id', 'Detalle_Codigos_Referidos_Fecha_de_autorizacion_' + index).attr('data-field', 'Fecha_de_autorizacion');
    columnData[8] = $($.parseHTML(GetGridTimePicker())).addClass('Detalle_Codigos_Referidos_Hora_de_autorizacion Hora_de_autorizacion').attr('id', 'Detalle_Codigos_Referidos_Hora_de_autorizacion_' + index).attr('data-field', 'Hora_de_autorizacion');
    columnData[9] = $(GetDetalle_Codigos_Referidos_EstatusDropDown()).addClass('Detalle_Codigos_Referidos_Estatus Estatus').attr('id', 'Detalle_Codigos_Referidos_Estatus_' + index).attr('data-field', 'Estatus').after($.parseHTML(addNew('Detalle_Codigos_Referidos', 'Estatus', 'Estatus', 258625)));


    initiateUIControls();
    return columnData;
}

function Detalle_Codigos_ReferidosInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Codigos_Referidos("Detalle_Codigos_Referidos_", "_" + rowIndex)) {
    var iPage = Detalle_Codigos_ReferidosTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Codigos_Referidos';
    var prevData = Detalle_Codigos_ReferidosTable.fnGetData(rowIndex);
    var data = Detalle_Codigos_ReferidosTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false


        ,Porcentaje_de_descuento: data.childNodes[counter++].childNodes[0].value
        ,Fecha_inicio_vigencia:  data.childNodes[counter++].childNodes[0].value
        ,Fecha_fin_vigencia:  data.childNodes[counter++].childNodes[0].value
        ,Cantidad_maxima_de_referenciados: data.childNodes[counter++].childNodes[0].value
        ,Codigo_para_Referenciados:  data.childNodes[counter++].childNodes[0].value
        ,Autorizado: $(data.childNodes[counter++].childNodes[2]).is(':checked')
        ,Usuario_que_autoriza:  data.childNodes[counter++].childNodes[0].value
        ,Fecha_de_autorizacion:  data.childNodes[counter++].childNodes[0].value
        ,Hora_de_autorizacion:  data.childNodes[counter++].childNodes[0].value
        ,Estatus:  data.childNodes[counter++].childNodes[0].value

    }
    Detalle_Codigos_ReferidosTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Codigos_ReferidosrowCreationGrid(data, newData, rowIndex);
    Detalle_Codigos_ReferidosTable.fnPageChange(iPage);
    Detalle_Codigos_ReferidoscountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Codigos_Referidos("Detalle_Codigos_Referidos_", "_" + rowIndex);
  }
}

function Detalle_Codigos_ReferidosCancelRow(rowIndex) {
    var prevData = Detalle_Codigos_ReferidosTable.fnGetData(rowIndex);
    var data = Detalle_Codigos_ReferidosTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Codigos_ReferidosTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Codigos_ReferidosrowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Codigos_ReferidosGrid(Detalle_Codigos_ReferidosTable.fnGetData());
    Detalle_Codigos_ReferidoscountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Codigos_ReferidosFromDataTable() {
    var Detalle_Codigos_ReferidosData = [];
    var gridData = Detalle_Codigos_ReferidosTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Codigos_ReferidosData.push({
                Folio: gridData[i].Folio


                ,Porcentaje_de_descuento: gridData[i].Porcentaje_de_descuento
                ,Fecha_inicio_vigencia: gridData[i].Fecha_inicio_vigencia
                ,Fecha_fin_vigencia: gridData[i].Fecha_fin_vigencia
                ,Cantidad_maxima_de_referenciados: gridData[i].Cantidad_maxima_de_referenciados
                ,Codigo_para_Referenciados: gridData[i].Codigo_para_Referenciados
                ,Autorizado: gridData[i].Autorizado
                ,Usuario_que_autoriza: gridData[i].Usuario_que_autoriza
                ,Fecha_de_autorizacion: gridData[i].Fecha_de_autorizacion
                ,Hora_de_autorizacion: gridData[i].Hora_de_autorizacion
                ,Estatus: gridData[i].Estatus

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Codigos_ReferidosData.length; i++) {
        if (removedDetalle_Codigos_ReferidosData[i] != null && removedDetalle_Codigos_ReferidosData[i].Folio > 0)
            Detalle_Codigos_ReferidosData.push({
                Folio: removedDetalle_Codigos_ReferidosData[i].Folio


                ,Porcentaje_de_descuento: removedDetalle_Codigos_ReferidosData[i].Porcentaje_de_descuento
                ,Fecha_inicio_vigencia: removedDetalle_Codigos_ReferidosData[i].Fecha_inicio_vigencia
                ,Fecha_fin_vigencia: removedDetalle_Codigos_ReferidosData[i].Fecha_fin_vigencia
                ,Cantidad_maxima_de_referenciados: removedDetalle_Codigos_ReferidosData[i].Cantidad_maxima_de_referenciados
                ,Codigo_para_Referenciados: removedDetalle_Codigos_ReferidosData[i].Codigo_para_Referenciados
                ,Autorizado: removedDetalle_Codigos_ReferidosData[i].Autorizado
                ,Usuario_que_autoriza: removedDetalle_Codigos_ReferidosData[i].Usuario_que_autoriza
                ,Fecha_de_autorizacion: removedDetalle_Codigos_ReferidosData[i].Fecha_de_autorizacion
                ,Hora_de_autorizacion: removedDetalle_Codigos_ReferidosData[i].Hora_de_autorizacion
                ,Estatus: removedDetalle_Codigos_ReferidosData[i].Estatus

                , Removed: true
            });
    }	

    return Detalle_Codigos_ReferidosData;
}

function Detalle_Codigos_ReferidosEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Codigos_ReferidosTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Codigos_ReferidoscountRowsChecked++;
    var Detalle_Codigos_ReferidosRowElement = "Detalle_Codigos_Referidos_" + rowIndex.toString();
    var prevData = Detalle_Codigos_ReferidosTable.fnGetData(rowIndexTable );
    var row = Detalle_Codigos_ReferidosTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Codigos_Referidos_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Codigos_ReferidosGetUpdateRowControls(prevData, "Detalle_Codigos_Referidos_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Codigos_ReferidosRowElement + "')){ Detalle_Codigos_ReferidosInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_Codigos_ReferidosCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Codigos_ReferidosGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Codigos_ReferidosGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_Codigos_ReferidosValidation();
    initiateUIControls();
    $('.Detalle_Codigos_Referidos' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Codigos_Referidos(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Codigos_ReferidosfnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Codigos_ReferidosTable.fnGetData().length;
    Detalle_Codigos_ReferidosfnClickAddRow();
    GetAddDetalle_Codigos_ReferidosPopup(currentRowIndex, 0);
}

function Detalle_Codigos_ReferidosEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Codigos_ReferidosTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Codigos_ReferidosRowElement = "Detalle_Codigos_Referidos_" + rowIndex.toString();
    var prevData = Detalle_Codigos_ReferidosTable.fnGetData(rowIndexTable);
    GetAddDetalle_Codigos_ReferidosPopup(rowIndex, 1, prevData.Folio);


    $('#Detalle_Codigos_ReferidosPorcentaje_de_descuento').val(prevData.Porcentaje_de_descuento);
    $('#Detalle_Codigos_ReferidosFecha_inicio_vigencia').val(prevData.Fecha_inicio_vigencia);
    $('#Detalle_Codigos_ReferidosFecha_fin_vigencia').val(prevData.Fecha_fin_vigencia);
    $('#Detalle_Codigos_ReferidosCantidad_maxima_de_referenciados').val(prevData.Cantidad_maxima_de_referenciados);
    $('#Detalle_Codigos_ReferidosCodigo_para_Referenciados').val(prevData.Codigo_para_Referenciados);
    $('#Detalle_Codigos_ReferidosAutorizado').prop('checked', prevData.Autorizado);
    $('#Detalle_Codigos_ReferidosUsuario_que_autoriza').val(prevData.Usuario_que_autoriza);
    $('#Detalle_Codigos_ReferidosFecha_de_autorizacion').val(prevData.Fecha_de_autorizacion);
    $('#Detalle_Codigos_ReferidosHora_de_autorizacion').val(prevData.Hora_de_autorizacion);
    $('#Detalle_Codigos_ReferidosEstatus').val(prevData.Estatus);

    initiateUIControls();













}

function Detalle_Codigos_ReferidosAddInsertRow() {
    if (Detalle_Codigos_ReferidosinsertRowCurrentIndex < 1)
    {
        Detalle_Codigos_ReferidosinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true


        ,Porcentaje_de_descuento: ""
        ,Fecha_inicio_vigencia: ""
        ,Fecha_fin_vigencia: ""
        ,Cantidad_maxima_de_referenciados: ""
        ,Codigo_para_Referenciados: ""
        ,Autorizado: ""
        ,Usuario_que_autoriza: ""
        ,Fecha_de_autorizacion: ""
        ,Hora_de_autorizacion: ""
        ,Estatus: ""

    }
}

function Detalle_Codigos_ReferidosfnClickAddRow() {
    Detalle_Codigos_ReferidoscountRowsChecked++;
    Detalle_Codigos_ReferidosTable.fnAddData(Detalle_Codigos_ReferidosAddInsertRow(), true);
    Detalle_Codigos_ReferidosTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_Codigos_ReferidosGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_Codigos_ReferidosGrid tbody tr:nth-of-type(' + (Detalle_Codigos_ReferidosinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Codigos_Referidos("Detalle_Codigos_Referidos_", "_" + Detalle_Codigos_ReferidosinsertRowCurrentIndex);
}

function Detalle_Codigos_ReferidosClearGridData() {
    Detalle_Codigos_ReferidosData = [];
    Detalle_Codigos_ReferidosdeletedItem = [];
    Detalle_Codigos_ReferidosDataMain = [];
    Detalle_Codigos_ReferidosDataMainPages = [];
    Detalle_Codigos_ReferidosnewItemCount = 0;
    Detalle_Codigos_ReferidosmaxItemIndex = 0;
    $("#Detalle_Codigos_ReferidosGrid").DataTable().clear();
    $("#Detalle_Codigos_ReferidosGrid").DataTable().destroy();
}

//Used to Get Especialistas Information
function GetDetalle_Codigos_Referidos() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Codigos_ReferidosData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Codigos_ReferidosData[i].Folio);


        form_data.append('[' + i + '].Porcentaje_de_descuento', Detalle_Codigos_ReferidosData[i].Porcentaje_de_descuento);
        form_data.append('[' + i + '].Fecha_inicio_vigencia', Detalle_Codigos_ReferidosData[i].Fecha_inicio_vigencia);
        form_data.append('[' + i + '].Fecha_fin_vigencia', Detalle_Codigos_ReferidosData[i].Fecha_fin_vigencia);
        form_data.append('[' + i + '].Cantidad_maxima_de_referenciados', Detalle_Codigos_ReferidosData[i].Cantidad_maxima_de_referenciados);
        form_data.append('[' + i + '].Codigo_para_Referenciados', Detalle_Codigos_ReferidosData[i].Codigo_para_Referenciados);
        form_data.append('[' + i + '].Autorizado', Detalle_Codigos_ReferidosData[i].Autorizado);
        form_data.append('[' + i + '].Usuario_que_autoriza', Detalle_Codigos_ReferidosData[i].Usuario_que_autoriza);
        form_data.append('[' + i + '].Fecha_de_autorizacion', Detalle_Codigos_ReferidosData[i].Fecha_de_autorizacion);
        form_data.append('[' + i + '].Hora_de_autorizacion', Detalle_Codigos_ReferidosData[i].Hora_de_autorizacion);
        form_data.append('[' + i + '].Estatus', Detalle_Codigos_ReferidosData[i].Estatus);

        form_data.append('[' + i + '].Removed', Detalle_Codigos_ReferidosData[i].Removed);
    }
    return form_data;
}
function Detalle_Codigos_ReferidosInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Codigos_Referidos("Detalle_Codigos_ReferidosTable", rowIndex)) {
    var prevData = Detalle_Codigos_ReferidosTable.fnGetData(rowIndex);
    var data = Detalle_Codigos_ReferidosTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false


        ,Porcentaje_de_descuento: $('#Detalle_Codigos_ReferidosPorcentaje_de_descuento').val()

        ,Fecha_inicio_vigencia: $('#Detalle_Codigos_ReferidosFecha_inicio_vigencia').val()
        ,Fecha_fin_vigencia: $('#Detalle_Codigos_ReferidosFecha_fin_vigencia').val()
        ,Cantidad_maxima_de_referenciados: $('#Detalle_Codigos_ReferidosCantidad_maxima_de_referenciados').val()

        ,Codigo_para_Referenciados: $('#Detalle_Codigos_ReferidosCodigo_para_Referenciados').val()
        ,Autorizado: $('#Detalle_Codigos_ReferidosAutorizado').is(':checked')
        ,Usuario_que_autoriza: $('#Detalle_Codigos_ReferidosUsuario_que_autoriza').val()
        ,Fecha_de_autorizacion: $('#Detalle_Codigos_ReferidosFecha_de_autorizacion').val()
        ,Hora_de_autorizacion: $('#Detalle_Codigos_ReferidosHora_de_autorizacion').val()
        ,Estatus: $('#Detalle_Codigos_ReferidosEstatus').val()

    }

    Detalle_Codigos_ReferidosTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Codigos_ReferidosrowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Codigos_Referidos-form').modal({ show: false });
    $('#AddDetalle_Codigos_Referidos-form').modal('hide');
    Detalle_Codigos_ReferidosEditRow(rowIndex);
    Detalle_Codigos_ReferidosInsertRow(rowIndex);
    //}
}
function Detalle_Codigos_ReferidosRemoveAddRow(rowIndex) {
    Detalle_Codigos_ReferidosTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Codigos_Referidos MultiRow
//Begin Declarations for Foreigns fields for Detalle_Planes_de_Suscripcion_Especialistas MultiRow
var Detalle_Planes_de_Suscripcion_EspecialistascountRowsChecked = 0;

function GetDetalle_Planes_de_Suscripcion_Especialistas_Planes_de_Suscripcion_EspecialistasName(Id) {
    for (var i = 0; i < Detalle_Planes_de_Suscripcion_Especialistas_Planes_de_Suscripcion_EspecialistasItems.length; i++) {
        if (Detalle_Planes_de_Suscripcion_Especialistas_Planes_de_Suscripcion_EspecialistasItems[i].Folio == Id) {
            return Detalle_Planes_de_Suscripcion_Especialistas_Planes_de_Suscripcion_EspecialistasItems[i].Nombre;
        }
    }
    return "";
}

function GetDetalle_Planes_de_Suscripcion_Especialistas_Planes_de_Suscripcion_EspecialistasDropDown() {
    var Detalle_Planes_de_Suscripcion_Especialistas_Planes_de_Suscripcion_EspecialistasDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Planes_de_Suscripcion_Especialistas_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Planes_de_Suscripcion_Especialistas_Planes_de_Suscripcion_EspecialistasDropdown);
    if(Detalle_Planes_de_Suscripcion_Especialistas_Planes_de_Suscripcion_EspecialistasItems != null)
    {
       for (var i = 0; i < Detalle_Planes_de_Suscripcion_Especialistas_Planes_de_Suscripcion_EspecialistasItems.length; i++) {
           $('<option />', { value: Detalle_Planes_de_Suscripcion_Especialistas_Planes_de_Suscripcion_EspecialistasItems[i].Folio, text:    Detalle_Planes_de_Suscripcion_Especialistas_Planes_de_Suscripcion_EspecialistasItems[i].Nombre }).appendTo(Detalle_Planes_de_Suscripcion_Especialistas_Planes_de_Suscripcion_EspecialistasDropdown);
       }
    }
    return Detalle_Planes_de_Suscripcion_Especialistas_Planes_de_Suscripcion_EspecialistasDropdown;
}





function GetDetalle_Planes_de_Suscripcion_Especialistas_Estatus_de_SuscripcionName(Id) {
    for (var i = 0; i < Detalle_Planes_de_Suscripcion_Especialistas_Estatus_de_SuscripcionItems.length; i++) {
        if (Detalle_Planes_de_Suscripcion_Especialistas_Estatus_de_SuscripcionItems[i].Clave == Id) {
            return Detalle_Planes_de_Suscripcion_Especialistas_Estatus_de_SuscripcionItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Planes_de_Suscripcion_Especialistas_Estatus_de_SuscripcionDropDown() {
    var Detalle_Planes_de_Suscripcion_Especialistas_Estatus_de_SuscripcionDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Planes_de_Suscripcion_Especialistas_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Planes_de_Suscripcion_Especialistas_Estatus_de_SuscripcionDropdown);
    if(Detalle_Planes_de_Suscripcion_Especialistas_Estatus_de_SuscripcionItems != null)
    {
       for (var i = 0; i < Detalle_Planes_de_Suscripcion_Especialistas_Estatus_de_SuscripcionItems.length; i++) {
           $('<option />', { value: Detalle_Planes_de_Suscripcion_Especialistas_Estatus_de_SuscripcionItems[i].Clave, text:    Detalle_Planes_de_Suscripcion_Especialistas_Estatus_de_SuscripcionItems[i].Descripcion }).appendTo(Detalle_Planes_de_Suscripcion_Especialistas_Estatus_de_SuscripcionDropdown);
       }
    }
    return Detalle_Planes_de_Suscripcion_Especialistas_Estatus_de_SuscripcionDropdown;
}


function GetInsertDetalle_Planes_de_Suscripcion_EspecialistasRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $(GetDetalle_Planes_de_Suscripcion_Especialistas_Planes_de_Suscripcion_EspecialistasDropDown()).addClass('Detalle_Planes_de_Suscripcion_Especialistas_Plan_de_Suscripcion Plan_de_Suscripcion').attr('id', 'Detalle_Planes_de_Suscripcion_Especialistas_Plan_de_Suscripcion_' + index).attr('data-field', 'Plan_de_Suscripcion').after($.parseHTML(addNew('Detalle_Planes_de_Suscripcion_Especialistas', 'Planes_de_Suscripcion_Especialistas', 'Plan_de_Suscripcion', 258638)));
    columnData[1] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Planes_de_Suscripcion_Especialistas_Fecha_de_inicio Fecha_de_inicio').attr('id', 'Detalle_Planes_de_Suscripcion_Especialistas_Fecha_de_inicio_' + index).attr('data-field', 'Fecha_de_inicio');
    columnData[2] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Planes_de_Suscripcion_Especialistas_Fecha_fin Fecha_fin').attr('id', 'Detalle_Planes_de_Suscripcion_Especialistas_Fecha_fin_' + index).attr('data-field', 'Fecha_fin');
    columnData[3] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Planes_de_Suscripcion_Especialistas_Costo Costo').attr('id', 'Detalle_Planes_de_Suscripcion_Especialistas_Costo_' + index).attr('data-field', 'Costo');
    columnData[4] = $($.parseHTML(GetFileUploader())).addClass('Detalle_Planes_de_Suscripcion_Especialistas_Contrato_FileUpload Contrato').attr('id', 'Detalle_Planes_de_Suscripcion_Especialistas_Contrato_' + index).attr('data-field', 'Contrato');
    columnData[5] = $($.parseHTML(GetGridCheckBox())).addClass('Detalle_Planes_de_Suscripcion_Especialistas_Firmo_Contrato Firmo_Contrato').attr('id', 'Detalle_Planes_de_Suscripcion_Especialistas_Firmo_Contrato_' + index).attr('data-field', 'Firmo_Contrato');
    columnData[6] = $(GetDetalle_Planes_de_Suscripcion_Especialistas_Estatus_de_SuscripcionDropDown()).addClass('Detalle_Planes_de_Suscripcion_Especialistas_Estatus Estatus').attr('id', 'Detalle_Planes_de_Suscripcion_Especialistas_Estatus_' + index).attr('data-field', 'Estatus').after($.parseHTML(addNew('Detalle_Planes_de_Suscripcion_Especialistas', 'Estatus_de_Suscripcion', 'Estatus', 258643)));


    initiateUIControls();
    return columnData;
}

function Detalle_Planes_de_Suscripcion_EspecialistasInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Planes_de_Suscripcion_Especialistas("Detalle_Planes_de_Suscripcion_Especialistas_", "_" + rowIndex)) {
    var iPage = Detalle_Planes_de_Suscripcion_EspecialistasTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Planes_de_Suscripcion_Especialistas';
    var prevData = Detalle_Planes_de_Suscripcion_EspecialistasTable.fnGetData(rowIndex);
    var data = Detalle_Planes_de_Suscripcion_EspecialistasTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Plan_de_Suscripcion:  data.childNodes[counter++].childNodes[0].value
        ,Fecha_de_inicio:  data.childNodes[counter++].childNodes[0].value
        ,Fecha_fin:  data.childNodes[counter++].childNodes[0].value
        ,Costo: data.childNodes[counter++].childNodes[0].value
        ,ContratoFileInfo: ($('#' + nameOfGrid + 'Grid .ContratoHeader').css('display') != 'none') ? { 
             FileName: prevData.ContratoFileInfo != null && prevData.ContratoFileInfo.FileName != null && prevData.ContratoFileInfo.FileName != ''? prevData.ContratoFileInfo.FileName : (data.childNodes[counter].childNodes[0].files.length > 0 ? data.childNodes[counter].childNodes[0].files[0].name : ''),              
			 FileId:   prevData.ContratoFileInfo != null && prevData.ContratoFileInfo.FileName != null && prevData.ContratoFileInfo.FileName != '' ? prevData.ContratoFileInfo.FileId :  prevData.ContratoFileInfo != null && prevData.ContratoFileInfo.FileId != '' && prevData.ContratoFileInfo.FileId != undefined ? prevData.ContratoFileInfo.FileId : '0',
             FileSize: prevData.ContratoFileInfo != null && prevData.ContratoFileInfo.FileName != null ? prevData.ContratoFileInfo.FileSize : (data.childNodes[counter].childNodes[0].files.length > 0 ? data.childNodes[counter].childNodes[0].files[0].name : '') 
         } : ''
        ,ContratoDetail: (data.childNodes[counter] != 'undefined' && data.childNodes[counter].childNodes[0].childNodes.length == 0) ? data.childNodes[counter++].childNodes[0] : prevData.ContratoDetail
        ,Firmo_Contrato: $(data.childNodes[counter++].childNodes[2]).is(':checked')
        ,Estatus:  data.childNodes[counter++].childNodes[0].value

    }
    Detalle_Planes_de_Suscripcion_EspecialistasTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Planes_de_Suscripcion_EspecialistasrowCreationGrid(data, newData, rowIndex);
    Detalle_Planes_de_Suscripcion_EspecialistasTable.fnPageChange(iPage);
    Detalle_Planes_de_Suscripcion_EspecialistascountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Planes_de_Suscripcion_Especialistas("Detalle_Planes_de_Suscripcion_Especialistas_", "_" + rowIndex);
  }
}

function Detalle_Planes_de_Suscripcion_EspecialistasCancelRow(rowIndex) {
    var prevData = Detalle_Planes_de_Suscripcion_EspecialistasTable.fnGetData(rowIndex);
    var data = Detalle_Planes_de_Suscripcion_EspecialistasTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Planes_de_Suscripcion_EspecialistasTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Planes_de_Suscripcion_EspecialistasrowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Planes_de_Suscripcion_EspecialistasGrid(Detalle_Planes_de_Suscripcion_EspecialistasTable.fnGetData());
    Detalle_Planes_de_Suscripcion_EspecialistascountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Planes_de_Suscripcion_EspecialistasFromDataTable() {
    var Detalle_Planes_de_Suscripcion_EspecialistasData = [];
    var gridData = Detalle_Planes_de_Suscripcion_EspecialistasTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Planes_de_Suscripcion_EspecialistasData.push({
                Folio: gridData[i].Folio

                ,Plan_de_Suscripcion: gridData[i].Plan_de_Suscripcion
                ,Fecha_de_inicio: gridData[i].Fecha_de_inicio
                ,Fecha_fin: gridData[i].Fecha_fin
                ,Costo: gridData[i].Costo
                ,ContratoInfo: {
                    FileName: gridData[i].ContratoFileInfo.FileName, FileId: gridData[i].ContratoFileInfo.FileId, FileSize: gridData[i].ContratoFileInfo.FileSize,
                    Control: gridData[i].ContratoDetail != null && gridData[i].ContratoDetail.files != null && gridData[i].ContratoDetail.files.length > 0 ? gridData[i].ContratoDetail.files[0] : null,
                    ContratoRemoveFile: gridData[i].ContratoDetail != null
                }
                ,Firmo_Contrato: gridData[i].Firmo_Contrato
                ,Estatus: gridData[i].Estatus

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Planes_de_Suscripcion_EspecialistasData.length; i++) {
        if (removedDetalle_Planes_de_Suscripcion_EspecialistasData[i] != null && removedDetalle_Planes_de_Suscripcion_EspecialistasData[i].Folio > 0)
            Detalle_Planes_de_Suscripcion_EspecialistasData.push({
                Folio: removedDetalle_Planes_de_Suscripcion_EspecialistasData[i].Folio

                ,Plan_de_Suscripcion: removedDetalle_Planes_de_Suscripcion_EspecialistasData[i].Plan_de_Suscripcion
                ,Fecha_de_inicio: removedDetalle_Planes_de_Suscripcion_EspecialistasData[i].Fecha_de_inicio
                ,Fecha_fin: removedDetalle_Planes_de_Suscripcion_EspecialistasData[i].Fecha_fin
                ,Costo: removedDetalle_Planes_de_Suscripcion_EspecialistasData[i].Costo
                ,ContratoInfo: {
                    FileName: removedDetalle_Planes_de_Suscripcion_EspecialistasData[i].ContratoFileInfo.FileName, 
                    FileId: removedDetalle_Planes_de_Suscripcion_EspecialistasData[i].ContratoFileInfo.FileId, 
                    FileSize: removedDetalle_Planes_de_Suscripcion_EspecialistasData[i].ContratoFileInfo.FileSize,
                    Control: removedDetalle_Planes_de_Suscripcion_EspecialistasData[i].ContratoDetail != null && removedDetalle_Planes_de_Suscripcion_EspecialistasData[i].ContratoDetail.files.length > 0 ? removedDetalle_Planes_de_Suscripcion_EspecialistasData[i].ContratoDetail.files[0] : null,
                    ContratoRemoveFile: removedDetalle_Planes_de_Suscripcion_EspecialistasData[i].ContratoDetail != null
                }
                ,Firmo_Contrato: removedDetalle_Planes_de_Suscripcion_EspecialistasData[i].Firmo_Contrato
                ,Estatus: removedDetalle_Planes_de_Suscripcion_EspecialistasData[i].Estatus

                , Removed: true
            });
    }	

    return Detalle_Planes_de_Suscripcion_EspecialistasData;
}

function Detalle_Planes_de_Suscripcion_EspecialistasEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Planes_de_Suscripcion_EspecialistasTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Planes_de_Suscripcion_EspecialistascountRowsChecked++;
    var Detalle_Planes_de_Suscripcion_EspecialistasRowElement = "Detalle_Planes_de_Suscripcion_Especialistas_" + rowIndex.toString();
    var prevData = Detalle_Planes_de_Suscripcion_EspecialistasTable.fnGetData(rowIndexTable );
    var row = Detalle_Planes_de_Suscripcion_EspecialistasTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Planes_de_Suscripcion_Especialistas_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Planes_de_Suscripcion_EspecialistasGetUpdateRowControls(prevData, "Detalle_Planes_de_Suscripcion_Especialistas_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Planes_de_Suscripcion_EspecialistasRowElement + "')){ Detalle_Planes_de_Suscripcion_EspecialistasInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_Planes_de_Suscripcion_EspecialistasCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Planes_de_Suscripcion_EspecialistasGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Planes_de_Suscripcion_EspecialistasGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_Planes_de_Suscripcion_EspecialistasValidation();
    initiateUIControls();
    $('.Detalle_Planes_de_Suscripcion_Especialistas' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Planes_de_Suscripcion_Especialistas(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Planes_de_Suscripcion_EspecialistasfnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Planes_de_Suscripcion_EspecialistasTable.fnGetData().length;
    Detalle_Planes_de_Suscripcion_EspecialistasfnClickAddRow();
    GetAddDetalle_Planes_de_Suscripcion_EspecialistasPopup(currentRowIndex, 0);
}

function Detalle_Planes_de_Suscripcion_EspecialistasEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Planes_de_Suscripcion_EspecialistasTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Planes_de_Suscripcion_EspecialistasRowElement = "Detalle_Planes_de_Suscripcion_Especialistas_" + rowIndex.toString();
    var prevData = Detalle_Planes_de_Suscripcion_EspecialistasTable.fnGetData(rowIndexTable);
    GetAddDetalle_Planes_de_Suscripcion_EspecialistasPopup(rowIndex, 1, prevData.Folio);

    $('#Detalle_Planes_de_Suscripcion_EspecialistasPlan_de_Suscripcion').val(prevData.Plan_de_Suscripcion);
    $('#Detalle_Planes_de_Suscripcion_EspecialistasFecha_de_inicio').val(prevData.Fecha_de_inicio);
    $('#Detalle_Planes_de_Suscripcion_EspecialistasFecha_fin').val(prevData.Fecha_fin);
    $('#Detalle_Planes_de_Suscripcion_EspecialistasCosto').val(prevData.Costo);

    $('#Detalle_Planes_de_Suscripcion_EspecialistasFirmo_Contrato').prop('checked', prevData.Firmo_Contrato);
    $('#Detalle_Planes_de_Suscripcion_EspecialistasEstatus').val(prevData.Estatus);

    initiateUIControls();





    $('#existingContrato').html(prevData.ContratoFileDetail == null && (prevData.ContratoFileInfo.FileId == null || prevData.ContratoFileInfo.FileId <= 0) ? $.parseHTML(GetFileUploader()) : GetFileInfo(prevData.ContratoFileInfo, prevData.ContratoFileDetail));



}

function Detalle_Planes_de_Suscripcion_EspecialistasAddInsertRow() {
    if (Detalle_Planes_de_Suscripcion_EspecialistasinsertRowCurrentIndex < 1)
    {
        Detalle_Planes_de_Suscripcion_EspecialistasinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Plan_de_Suscripcion: ""
        ,Fecha_de_inicio: ""
        ,Fecha_fin: ""
        ,Costo: ""
        ,ContratoFileInfo: ""
        ,Firmo_Contrato: ""
        ,Estatus: ""

    }
}

function Detalle_Planes_de_Suscripcion_EspecialistasfnClickAddRow() {
    Detalle_Planes_de_Suscripcion_EspecialistascountRowsChecked++;
    Detalle_Planes_de_Suscripcion_EspecialistasTable.fnAddData(Detalle_Planes_de_Suscripcion_EspecialistasAddInsertRow(), true);
    Detalle_Planes_de_Suscripcion_EspecialistasTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_Planes_de_Suscripcion_EspecialistasGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_Planes_de_Suscripcion_EspecialistasGrid tbody tr:nth-of-type(' + (Detalle_Planes_de_Suscripcion_EspecialistasinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Planes_de_Suscripcion_Especialistas("Detalle_Planes_de_Suscripcion_Especialistas_", "_" + Detalle_Planes_de_Suscripcion_EspecialistasinsertRowCurrentIndex);
}

function Detalle_Planes_de_Suscripcion_EspecialistasClearGridData() {
    Detalle_Planes_de_Suscripcion_EspecialistasData = [];
    Detalle_Planes_de_Suscripcion_EspecialistasdeletedItem = [];
    Detalle_Planes_de_Suscripcion_EspecialistasDataMain = [];
    Detalle_Planes_de_Suscripcion_EspecialistasDataMainPages = [];
    Detalle_Planes_de_Suscripcion_EspecialistasnewItemCount = 0;
    Detalle_Planes_de_Suscripcion_EspecialistasmaxItemIndex = 0;
    $("#Detalle_Planes_de_Suscripcion_EspecialistasGrid").DataTable().clear();
    $("#Detalle_Planes_de_Suscripcion_EspecialistasGrid").DataTable().destroy();
}

//Used to Get Especialistas Information
function GetDetalle_Planes_de_Suscripcion_Especialistas() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Planes_de_Suscripcion_EspecialistasData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Planes_de_Suscripcion_EspecialistasData[i].Folio);

        form_data.append('[' + i + '].Plan_de_Suscripcion', Detalle_Planes_de_Suscripcion_EspecialistasData[i].Plan_de_Suscripcion);
        form_data.append('[' + i + '].Fecha_de_inicio', Detalle_Planes_de_Suscripcion_EspecialistasData[i].Fecha_de_inicio);
        form_data.append('[' + i + '].Fecha_fin', Detalle_Planes_de_Suscripcion_EspecialistasData[i].Fecha_fin);
        form_data.append('[' + i + '].Costo', Detalle_Planes_de_Suscripcion_EspecialistasData[i].Costo);
        form_data.append('[' + i + '].ContratoInfo.FileId', Detalle_Planes_de_Suscripcion_EspecialistasData[i].ContratoInfo.FileId);
        form_data.append('[' + i + '].ContratoInfo.FileName', Detalle_Planes_de_Suscripcion_EspecialistasData[i].ContratoInfo.FileName);
        form_data.append('[' + i + '].ContratoInfo.FileSize', Detalle_Planes_de_Suscripcion_EspecialistasData[i].ContratoInfo.FileSize);
        form_data.append('[' + i + '].ContratoInfo.Control', Detalle_Planes_de_Suscripcion_EspecialistasData[i].ContratoInfo.Control);
        form_data.append('[' + i + '].ContratoInfo.RemoveFile', Detalle_Planes_de_Suscripcion_EspecialistasData[i].ContratoInfo.ArchivoRemoveFile);
        form_data.append('[' + i + '].Firmo_Contrato', Detalle_Planes_de_Suscripcion_EspecialistasData[i].Firmo_Contrato);
        form_data.append('[' + i + '].Estatus', Detalle_Planes_de_Suscripcion_EspecialistasData[i].Estatus);

        form_data.append('[' + i + '].Removed', Detalle_Planes_de_Suscripcion_EspecialistasData[i].Removed);
    }
    return form_data;
}
function Detalle_Planes_de_Suscripcion_EspecialistasInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Planes_de_Suscripcion_Especialistas("Detalle_Planes_de_Suscripcion_EspecialistasTable", rowIndex)) {
    var prevData = Detalle_Planes_de_Suscripcion_EspecialistasTable.fnGetData(rowIndex);
    var data = Detalle_Planes_de_Suscripcion_EspecialistasTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Plan_de_Suscripcion: $('#Detalle_Planes_de_Suscripcion_EspecialistasPlan_de_Suscripcion').val()
        ,Fecha_de_inicio: $('#Detalle_Planes_de_Suscripcion_EspecialistasFecha_de_inicio').val()
        ,Fecha_fin: $('#Detalle_Planes_de_Suscripcion_EspecialistasFecha_fin').val()
        ,Costo: $('#Detalle_Planes_de_Suscripcion_EspecialistasCosto').val()
        ,ContratoFileInfo: { ContratoFileName: prevData.ContratoFileInfo.FileName, ContratoFileId: prevData.ContratoFileInfo.FileId, ContratoFileSize: prevData.ContratoFileInfo.FileSize }
        ,ContratoFileDetail: $('#Contrato').find('label').length == 0 ? $('#ContratoFileInfoPop')[0] : prevData.ContratoFileDetail
        ,Firmo_Contrato: $('#Detalle_Planes_de_Suscripcion_EspecialistasFirmo_Contrato').is(':checked')
        ,Estatus: $('#Detalle_Planes_de_Suscripcion_EspecialistasEstatus').val()

    }

    Detalle_Planes_de_Suscripcion_EspecialistasTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Planes_de_Suscripcion_EspecialistasrowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Planes_de_Suscripcion_Especialistas-form').modal({ show: false });
    $('#AddDetalle_Planes_de_Suscripcion_Especialistas-form').modal('hide');
    Detalle_Planes_de_Suscripcion_EspecialistasEditRow(rowIndex);
    Detalle_Planes_de_Suscripcion_EspecialistasInsertRow(rowIndex);
    //}
}
function Detalle_Planes_de_Suscripcion_EspecialistasRemoveAddRow(rowIndex) {
    Detalle_Planes_de_Suscripcion_EspecialistasTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Planes_de_Suscripcion_Especialistas MultiRow
//Begin Declarations for Foreigns fields for Detalle_Facturacion_Especialistas MultiRow
var Detalle_Facturacion_EspecialistascountRowsChecked = 0;













function GetInsertDetalle_Facturacion_EspecialistasRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Facturacion_Especialistas_Fecha_de_Registro Fecha_de_Registro').attr('id', 'Detalle_Facturacion_Especialistas_Fecha_de_Registro_' + index).attr('data-field', 'Fecha_de_Registro');
    columnData[1] = $($.parseHTML(inputData)).addClass('Detalle_Facturacion_Especialistas_Folio_Factura Folio_Factura').attr('id', 'Detalle_Facturacion_Especialistas_Folio_Factura_' + index).attr('data-field', 'Folio_Factura');
    columnData[2] = $($.parseHTML(inputData)).addClass('Detalle_Facturacion_Especialistas_Periodo_Facturado Periodo_Facturado').attr('id', 'Detalle_Facturacion_Especialistas_Periodo_Facturado_' + index).attr('data-field', 'Periodo_Facturado');
    columnData[3] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Facturacion_Especialistas_Cantidad Cantidad').attr('id', 'Detalle_Facturacion_Especialistas_Cantidad_' + index).attr('data-field', 'Cantidad');
    columnData[4] = $($.parseHTML(GetFileUploader())).addClass('Detalle_Facturacion_Especialistas_Archivo_XML_FileUpload Archivo_XML').attr('id', 'Detalle_Facturacion_Especialistas_Archivo_XML_' + index).attr('data-field', 'Archivo_XML');
    columnData[5] = $($.parseHTML(GetFileUploader())).addClass('Detalle_Facturacion_Especialistas_Archivo_PDF_FileUpload Archivo_PDF').attr('id', 'Detalle_Facturacion_Especialistas_Archivo_PDF_' + index).attr('data-field', 'Archivo_PDF');
    columnData[6] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Facturacion_Especialistas_Estatus Estatus').attr('id', 'Detalle_Facturacion_Especialistas_Estatus_' + index).attr('data-field', 'Estatus');
    columnData[7] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Facturacion_Especialistas_Fecha_programada_de_Pago Fecha_programada_de_Pago').attr('id', 'Detalle_Facturacion_Especialistas_Fecha_programada_de_Pago_' + index).attr('data-field', 'Fecha_programada_de_Pago');
    columnData[8] = $($.parseHTML(GetGridCheckBox())).addClass('Detalle_Facturacion_Especialistas_Pagada Pagada').attr('id', 'Detalle_Facturacion_Especialistas_Pagada_' + index).attr('data-field', 'Pagada');
    columnData[9] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Facturacion_Especialistas_Fecha_de_pago Fecha_de_pago').attr('id', 'Detalle_Facturacion_Especialistas_Fecha_de_pago_' + index).attr('data-field', 'Fecha_de_pago');


    initiateUIControls();
    return columnData;
}

function Detalle_Facturacion_EspecialistasInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Facturacion_Especialistas("Detalle_Facturacion_Especialistas_", "_" + rowIndex)) {
    var iPage = Detalle_Facturacion_EspecialistasTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Facturacion_Especialistas';
    var prevData = Detalle_Facturacion_EspecialistasTable.fnGetData(rowIndex);
    var data = Detalle_Facturacion_EspecialistasTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Fecha_de_Registro:  data.childNodes[counter++].childNodes[0].value
        ,Folio_Factura:  data.childNodes[counter++].childNodes[0].value
        ,Periodo_Facturado:  data.childNodes[counter++].childNodes[0].value
        ,Cantidad: data.childNodes[counter++].childNodes[0].value
        ,Archivo_XMLFileInfo: ($('#' + nameOfGrid + 'Grid .Archivo_XMLHeader').css('display') != 'none') ? { 
             FileName: prevData.Archivo_XMLFileInfo != null && prevData.Archivo_XMLFileInfo.FileName != null && prevData.Archivo_XMLFileInfo.FileName != ''? prevData.Archivo_XMLFileInfo.FileName : (data.childNodes[counter].childNodes[0].files.length > 0 ? data.childNodes[counter].childNodes[0].files[0].name : ''),              
			 FileId:   prevData.Archivo_XMLFileInfo != null && prevData.Archivo_XMLFileInfo.FileName != null && prevData.Archivo_XMLFileInfo.FileName != '' ? prevData.Archivo_XMLFileInfo.FileId :  prevData.Archivo_XMLFileInfo != null && prevData.Archivo_XMLFileInfo.FileId != '' && prevData.Archivo_XMLFileInfo.FileId != undefined ? prevData.Archivo_XMLFileInfo.FileId : '0',
             FileSize: prevData.Archivo_XMLFileInfo != null && prevData.Archivo_XMLFileInfo.FileName != null ? prevData.Archivo_XMLFileInfo.FileSize : (data.childNodes[counter].childNodes[0].files.length > 0 ? data.childNodes[counter].childNodes[0].files[0].name : '') 
         } : ''
        ,Archivo_XMLDetail: (data.childNodes[counter] != 'undefined' && data.childNodes[counter].childNodes[0].childNodes.length == 0) ? data.childNodes[counter++].childNodes[0] : prevData.Archivo_XMLDetail
        ,Archivo_PDFFileInfo: ($('#' + nameOfGrid + 'Grid .Archivo_PDFHeader').css('display') != 'none') ? { 
             FileName: prevData.Archivo_PDFFileInfo != null && prevData.Archivo_PDFFileInfo.FileName != null && prevData.Archivo_PDFFileInfo.FileName != ''? prevData.Archivo_PDFFileInfo.FileName : (data.childNodes[counter].childNodes[0].files.length > 0 ? data.childNodes[counter].childNodes[0].files[0].name : ''),              
			 FileId:   prevData.Archivo_PDFFileInfo != null && prevData.Archivo_PDFFileInfo.FileName != null && prevData.Archivo_PDFFileInfo.FileName != '' ? prevData.Archivo_PDFFileInfo.FileId :  prevData.Archivo_PDFFileInfo != null && prevData.Archivo_PDFFileInfo.FileId != '' && prevData.Archivo_PDFFileInfo.FileId != undefined ? prevData.Archivo_PDFFileInfo.FileId : '0',
             FileSize: prevData.Archivo_PDFFileInfo != null && prevData.Archivo_PDFFileInfo.FileName != null ? prevData.Archivo_PDFFileInfo.FileSize : (data.childNodes[counter].childNodes[0].files.length > 0 ? data.childNodes[counter].childNodes[0].files[0].name : '') 
         } : ''
        ,Archivo_PDFDetail: (data.childNodes[counter] != 'undefined' && data.childNodes[counter].childNodes[0].childNodes.length == 0) ? data.childNodes[counter++].childNodes[0] : prevData.Archivo_PDFDetail
        ,Estatus: data.childNodes[counter++].childNodes[0].value
        ,Fecha_programada_de_Pago:  data.childNodes[counter++].childNodes[0].value
        ,Pagada: $(data.childNodes[counter++].childNodes[2]).is(':checked')
        ,Fecha_de_pago:  data.childNodes[counter++].childNodes[0].value

    }
    Detalle_Facturacion_EspecialistasTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Facturacion_EspecialistasrowCreationGrid(data, newData, rowIndex);
    Detalle_Facturacion_EspecialistasTable.fnPageChange(iPage);
    Detalle_Facturacion_EspecialistascountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Facturacion_Especialistas("Detalle_Facturacion_Especialistas_", "_" + rowIndex);
  }
}

function Detalle_Facturacion_EspecialistasCancelRow(rowIndex) {
    var prevData = Detalle_Facturacion_EspecialistasTable.fnGetData(rowIndex);
    var data = Detalle_Facturacion_EspecialistasTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Facturacion_EspecialistasTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Facturacion_EspecialistasrowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Facturacion_EspecialistasGrid(Detalle_Facturacion_EspecialistasTable.fnGetData());
    Detalle_Facturacion_EspecialistascountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Facturacion_EspecialistasFromDataTable() {
    var Detalle_Facturacion_EspecialistasData = [];
    var gridData = Detalle_Facturacion_EspecialistasTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Facturacion_EspecialistasData.push({
                Folio: gridData[i].Folio

                ,Fecha_de_Registro: gridData[i].Fecha_de_Registro
                ,Folio_Factura: gridData[i].Folio_Factura
                ,Periodo_Facturado: gridData[i].Periodo_Facturado
                ,Cantidad: gridData[i].Cantidad
                ,Archivo_XMLInfo: {
                    FileName: gridData[i].Archivo_XMLFileInfo.FileName, FileId: gridData[i].Archivo_XMLFileInfo.FileId, FileSize: gridData[i].Archivo_XMLFileInfo.FileSize,
                    Control: gridData[i].Archivo_XMLDetail != null && gridData[i].Archivo_XMLDetail.files != null && gridData[i].Archivo_XMLDetail.files.length > 0 ? gridData[i].Archivo_XMLDetail.files[0] : null,
                    Archivo_XMLRemoveFile: gridData[i].Archivo_XMLDetail != null
                }
                ,Archivo_PDFInfo: {
                    FileName: gridData[i].Archivo_PDFFileInfo.FileName, FileId: gridData[i].Archivo_PDFFileInfo.FileId, FileSize: gridData[i].Archivo_PDFFileInfo.FileSize,
                    Control: gridData[i].Archivo_PDFDetail != null && gridData[i].Archivo_PDFDetail.files != null && gridData[i].Archivo_PDFDetail.files.length > 0 ? gridData[i].Archivo_PDFDetail.files[0] : null,
                    Archivo_PDFRemoveFile: gridData[i].Archivo_PDFDetail != null
                }
                ,Estatus: gridData[i].Estatus
                ,Fecha_programada_de_Pago: gridData[i].Fecha_programada_de_Pago
                ,Pagada: gridData[i].Pagada
                ,Fecha_de_pago: gridData[i].Fecha_de_pago

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Facturacion_EspecialistasData.length; i++) {
        if (removedDetalle_Facturacion_EspecialistasData[i] != null && removedDetalle_Facturacion_EspecialistasData[i].Folio > 0)
            Detalle_Facturacion_EspecialistasData.push({
                Folio: removedDetalle_Facturacion_EspecialistasData[i].Folio

                ,Fecha_de_Registro: removedDetalle_Facturacion_EspecialistasData[i].Fecha_de_Registro
                ,Folio_Factura: removedDetalle_Facturacion_EspecialistasData[i].Folio_Factura
                ,Periodo_Facturado: removedDetalle_Facturacion_EspecialistasData[i].Periodo_Facturado
                ,Cantidad: removedDetalle_Facturacion_EspecialistasData[i].Cantidad
                ,Archivo_XMLInfo: {
                    FileName: removedDetalle_Facturacion_EspecialistasData[i].Archivo_XMLFileInfo.FileName, 
                    FileId: removedDetalle_Facturacion_EspecialistasData[i].Archivo_XMLFileInfo.FileId, 
                    FileSize: removedDetalle_Facturacion_EspecialistasData[i].Archivo_XMLFileInfo.FileSize,
                    Control: removedDetalle_Facturacion_EspecialistasData[i].Archivo_XMLDetail != null && removedDetalle_Facturacion_EspecialistasData[i].Archivo_XMLDetail.files.length > 0 ? removedDetalle_Facturacion_EspecialistasData[i].Archivo_XMLDetail.files[0] : null,
                    Archivo_XMLRemoveFile: removedDetalle_Facturacion_EspecialistasData[i].Archivo_XMLDetail != null
                }
                ,Archivo_PDFInfo: {
                    FileName: removedDetalle_Facturacion_EspecialistasData[i].Archivo_PDFFileInfo.FileName, 
                    FileId: removedDetalle_Facturacion_EspecialistasData[i].Archivo_PDFFileInfo.FileId, 
                    FileSize: removedDetalle_Facturacion_EspecialistasData[i].Archivo_PDFFileInfo.FileSize,
                    Control: removedDetalle_Facturacion_EspecialistasData[i].Archivo_PDFDetail != null && removedDetalle_Facturacion_EspecialistasData[i].Archivo_PDFDetail.files.length > 0 ? removedDetalle_Facturacion_EspecialistasData[i].Archivo_PDFDetail.files[0] : null,
                    Archivo_PDFRemoveFile: removedDetalle_Facturacion_EspecialistasData[i].Archivo_PDFDetail != null
                }
                ,Estatus: removedDetalle_Facturacion_EspecialistasData[i].Estatus
                ,Fecha_programada_de_Pago: removedDetalle_Facturacion_EspecialistasData[i].Fecha_programada_de_Pago
                ,Pagada: removedDetalle_Facturacion_EspecialistasData[i].Pagada
                ,Fecha_de_pago: removedDetalle_Facturacion_EspecialistasData[i].Fecha_de_pago

                , Removed: true
            });
    }	

    return Detalle_Facturacion_EspecialistasData;
}

function Detalle_Facturacion_EspecialistasEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Facturacion_EspecialistasTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Facturacion_EspecialistascountRowsChecked++;
    var Detalle_Facturacion_EspecialistasRowElement = "Detalle_Facturacion_Especialistas_" + rowIndex.toString();
    var prevData = Detalle_Facturacion_EspecialistasTable.fnGetData(rowIndexTable );
    var row = Detalle_Facturacion_EspecialistasTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Facturacion_Especialistas_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Facturacion_EspecialistasGetUpdateRowControls(prevData, "Detalle_Facturacion_Especialistas_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Facturacion_EspecialistasRowElement + "')){ Detalle_Facturacion_EspecialistasInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_Facturacion_EspecialistasCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Facturacion_EspecialistasGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Facturacion_EspecialistasGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_Facturacion_EspecialistasValidation();
    initiateUIControls();
    $('.Detalle_Facturacion_Especialistas' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Facturacion_Especialistas(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Facturacion_EspecialistasfnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Facturacion_EspecialistasTable.fnGetData().length;
    Detalle_Facturacion_EspecialistasfnClickAddRow();
    GetAddDetalle_Facturacion_EspecialistasPopup(currentRowIndex, 0);
}

function Detalle_Facturacion_EspecialistasEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Facturacion_EspecialistasTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Facturacion_EspecialistasRowElement = "Detalle_Facturacion_Especialistas_" + rowIndex.toString();
    var prevData = Detalle_Facturacion_EspecialistasTable.fnGetData(rowIndexTable);
    GetAddDetalle_Facturacion_EspecialistasPopup(rowIndex, 1, prevData.Folio);

    $('#Detalle_Facturacion_EspecialistasFecha_de_Registro').val(prevData.Fecha_de_Registro);
    $('#Detalle_Facturacion_EspecialistasFolio_Factura').val(prevData.Folio_Factura);
    $('#Detalle_Facturacion_EspecialistasPeriodo_Facturado').val(prevData.Periodo_Facturado);
    $('#Detalle_Facturacion_EspecialistasCantidad').val(prevData.Cantidad);


    $('#Detalle_Facturacion_EspecialistasEstatus').val(prevData.Estatus);
    $('#Detalle_Facturacion_EspecialistasFecha_programada_de_Pago').val(prevData.Fecha_programada_de_Pago);
    $('#Detalle_Facturacion_EspecialistasPagada').prop('checked', prevData.Pagada);
    $('#Detalle_Facturacion_EspecialistasFecha_de_pago').val(prevData.Fecha_de_pago);

    initiateUIControls();





    $('#existingArchivo_XML').html(prevData.Archivo_XMLFileDetail == null && (prevData.Archivo_XMLFileInfo.FileId == null || prevData.Archivo_XMLFileInfo.FileId <= 0) ? $.parseHTML(GetFileUploader()) : GetFileInfo(prevData.Archivo_XMLFileInfo, prevData.Archivo_XMLFileDetail));
    $('#existingArchivo_PDF').html(prevData.Archivo_PDFFileDetail == null && (prevData.Archivo_PDFFileInfo.FileId == null || prevData.Archivo_PDFFileInfo.FileId <= 0) ? $.parseHTML(GetFileUploader()) : GetFileInfo(prevData.Archivo_PDFFileInfo, prevData.Archivo_PDFFileDetail));





}

function Detalle_Facturacion_EspecialistasAddInsertRow() {
    if (Detalle_Facturacion_EspecialistasinsertRowCurrentIndex < 1)
    {
        Detalle_Facturacion_EspecialistasinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Fecha_de_Registro: ""
        ,Folio_Factura: ""
        ,Periodo_Facturado: ""
        ,Cantidad: ""
        ,Archivo_XMLFileInfo: ""
        ,Archivo_PDFFileInfo: ""
        ,Estatus: ""
        ,Fecha_programada_de_Pago: ""
        ,Pagada: ""
        ,Fecha_de_pago: ""

    }
}

function Detalle_Facturacion_EspecialistasfnClickAddRow() {
    Detalle_Facturacion_EspecialistascountRowsChecked++;
    Detalle_Facturacion_EspecialistasTable.fnAddData(Detalle_Facturacion_EspecialistasAddInsertRow(), true);
    Detalle_Facturacion_EspecialistasTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_Facturacion_EspecialistasGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_Facturacion_EspecialistasGrid tbody tr:nth-of-type(' + (Detalle_Facturacion_EspecialistasinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Facturacion_Especialistas("Detalle_Facturacion_Especialistas_", "_" + Detalle_Facturacion_EspecialistasinsertRowCurrentIndex);
}

function Detalle_Facturacion_EspecialistasClearGridData() {
    Detalle_Facturacion_EspecialistasData = [];
    Detalle_Facturacion_EspecialistasdeletedItem = [];
    Detalle_Facturacion_EspecialistasDataMain = [];
    Detalle_Facturacion_EspecialistasDataMainPages = [];
    Detalle_Facturacion_EspecialistasnewItemCount = 0;
    Detalle_Facturacion_EspecialistasmaxItemIndex = 0;
    $("#Detalle_Facturacion_EspecialistasGrid").DataTable().clear();
    $("#Detalle_Facturacion_EspecialistasGrid").DataTable().destroy();
}

//Used to Get Especialistas Information
function GetDetalle_Facturacion_Especialistas() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Facturacion_EspecialistasData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Facturacion_EspecialistasData[i].Folio);

        form_data.append('[' + i + '].Fecha_de_Registro', Detalle_Facturacion_EspecialistasData[i].Fecha_de_Registro);
        form_data.append('[' + i + '].Folio_Factura', Detalle_Facturacion_EspecialistasData[i].Folio_Factura);
        form_data.append('[' + i + '].Periodo_Facturado', Detalle_Facturacion_EspecialistasData[i].Periodo_Facturado);
        form_data.append('[' + i + '].Cantidad', Detalle_Facturacion_EspecialistasData[i].Cantidad);
        form_data.append('[' + i + '].Archivo_XMLInfo.FileId', Detalle_Facturacion_EspecialistasData[i].Archivo_XMLInfo.FileId);
        form_data.append('[' + i + '].Archivo_XMLInfo.FileName', Detalle_Facturacion_EspecialistasData[i].Archivo_XMLInfo.FileName);
        form_data.append('[' + i + '].Archivo_XMLInfo.FileSize', Detalle_Facturacion_EspecialistasData[i].Archivo_XMLInfo.FileSize);
        form_data.append('[' + i + '].Archivo_XMLInfo.Control', Detalle_Facturacion_EspecialistasData[i].Archivo_XMLInfo.Control);
        form_data.append('[' + i + '].Archivo_XMLInfo.RemoveFile', Detalle_Facturacion_EspecialistasData[i].Archivo_XMLInfo.ArchivoRemoveFile);
        form_data.append('[' + i + '].Archivo_PDFInfo.FileId', Detalle_Facturacion_EspecialistasData[i].Archivo_PDFInfo.FileId);
        form_data.append('[' + i + '].Archivo_PDFInfo.FileName', Detalle_Facturacion_EspecialistasData[i].Archivo_PDFInfo.FileName);
        form_data.append('[' + i + '].Archivo_PDFInfo.FileSize', Detalle_Facturacion_EspecialistasData[i].Archivo_PDFInfo.FileSize);
        form_data.append('[' + i + '].Archivo_PDFInfo.Control', Detalle_Facturacion_EspecialistasData[i].Archivo_PDFInfo.Control);
        form_data.append('[' + i + '].Archivo_PDFInfo.RemoveFile', Detalle_Facturacion_EspecialistasData[i].Archivo_PDFInfo.ArchivoRemoveFile);
        form_data.append('[' + i + '].Estatus', Detalle_Facturacion_EspecialistasData[i].Estatus);
        form_data.append('[' + i + '].Fecha_programada_de_Pago', Detalle_Facturacion_EspecialistasData[i].Fecha_programada_de_Pago);
        form_data.append('[' + i + '].Pagada', Detalle_Facturacion_EspecialistasData[i].Pagada);
        form_data.append('[' + i + '].Fecha_de_pago', Detalle_Facturacion_EspecialistasData[i].Fecha_de_pago);

        form_data.append('[' + i + '].Removed', Detalle_Facturacion_EspecialistasData[i].Removed);
    }
    return form_data;
}
function Detalle_Facturacion_EspecialistasInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Facturacion_Especialistas("Detalle_Facturacion_EspecialistasTable", rowIndex)) {
    var prevData = Detalle_Facturacion_EspecialistasTable.fnGetData(rowIndex);
    var data = Detalle_Facturacion_EspecialistasTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Fecha_de_Registro: $('#Detalle_Facturacion_EspecialistasFecha_de_Registro').val()
        ,Folio_Factura: $('#Detalle_Facturacion_EspecialistasFolio_Factura').val()
        ,Periodo_Facturado: $('#Detalle_Facturacion_EspecialistasPeriodo_Facturado').val()
        ,Cantidad: $('#Detalle_Facturacion_EspecialistasCantidad').val()
        ,Archivo_XMLFileInfo: { Archivo_XMLFileName: prevData.Archivo_XMLFileInfo.FileName, Archivo_XMLFileId: prevData.Archivo_XMLFileInfo.FileId, Archivo_XMLFileSize: prevData.Archivo_XMLFileInfo.FileSize }
        ,Archivo_XMLFileDetail: $('#Archivo_XML').find('label').length == 0 ? $('#Archivo_XMLFileInfoPop')[0] : prevData.Archivo_XMLFileDetail
        ,Archivo_PDFFileInfo: { Archivo_PDFFileName: prevData.Archivo_PDFFileInfo.FileName, Archivo_PDFFileId: prevData.Archivo_PDFFileInfo.FileId, Archivo_PDFFileSize: prevData.Archivo_PDFFileInfo.FileSize }
        ,Archivo_PDFFileDetail: $('#Archivo_PDF').find('label').length == 0 ? $('#Archivo_PDFFileInfoPop')[0] : prevData.Archivo_PDFFileDetail
        ,Estatus: $('#Detalle_Facturacion_EspecialistasEstatus').val()

        ,Fecha_programada_de_Pago: $('#Detalle_Facturacion_EspecialistasFecha_programada_de_Pago').val()
        ,Pagada: $('#Detalle_Facturacion_EspecialistasPagada').is(':checked')
        ,Fecha_de_pago: $('#Detalle_Facturacion_EspecialistasFecha_de_pago').val()

    }

    Detalle_Facturacion_EspecialistasTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Facturacion_EspecialistasrowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Facturacion_Especialistas-form').modal({ show: false });
    $('#AddDetalle_Facturacion_Especialistas-form').modal('hide');
    Detalle_Facturacion_EspecialistasEditRow(rowIndex);
    Detalle_Facturacion_EspecialistasInsertRow(rowIndex);
    //}
}
function Detalle_Facturacion_EspecialistasRemoveAddRow(rowIndex) {
    Detalle_Facturacion_EspecialistasTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Facturacion_Especialistas MultiRow


$(function () {
    function Detalle_Redes_Sociales_EspecialistainitializeMainArray(totalCount) {
        if (Detalle_Redes_Sociales_EspecialistaDataMain.length != totalCount && !Detalle_Redes_Sociales_EspecialistaDataMainInitialized) {
            Detalle_Redes_Sociales_EspecialistaDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Redes_Sociales_EspecialistaDataMain[i] = null;
            }
        }
    }
    function Detalle_Redes_Sociales_EspecialistaremoveFromMainArray() {
        for (var j = 0; j < Detalle_Redes_Sociales_EspecialistadeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Redes_Sociales_EspecialistaDataMain.length; i++) {
                if (Detalle_Redes_Sociales_EspecialistaDataMain[i] != null && Detalle_Redes_Sociales_EspecialistaDataMain[i].Id == Detalle_Redes_Sociales_EspecialistadeletedItem[j]) {
                    hDetalle_Redes_Sociales_EspecialistaDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Redes_Sociales_EspecialistacopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Redes_Sociales_EspecialistaDataMain.length; i++) {
            data[i] = Detalle_Redes_Sociales_EspecialistaDataMain[i];

        }
        return data;
    }
    function Detalle_Redes_Sociales_EspecialistagetNewResult() {
        var newData = copyMainDetalle_Redes_Sociales_EspecialistaArray();

        for (var i = 0; i < Detalle_Redes_Sociales_EspecialistaData.length; i++) {
            if (Detalle_Redes_Sociales_EspecialistaData[i].Removed == null || Detalle_Redes_Sociales_EspecialistaData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Redes_Sociales_EspecialistaData[i]);
            }
        }
        return newData;
    }
    function Detalle_Redes_Sociales_EspecialistapushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Redes_Sociales_EspecialistaDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Redes_Sociales_EspecialistaDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Detalle_Convenio_Medicos_AseguradorasinitializeMainArray(totalCount) {
        if (Detalle_Convenio_Medicos_AseguradorasDataMain.length != totalCount && !Detalle_Convenio_Medicos_AseguradorasDataMainInitialized) {
            Detalle_Convenio_Medicos_AseguradorasDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Convenio_Medicos_AseguradorasDataMain[i] = null;
            }
        }
    }
    function Detalle_Convenio_Medicos_AseguradorasremoveFromMainArray() {
        for (var j = 0; j < Detalle_Convenio_Medicos_AseguradorasdeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Convenio_Medicos_AseguradorasDataMain.length; i++) {
                if (Detalle_Convenio_Medicos_AseguradorasDataMain[i] != null && Detalle_Convenio_Medicos_AseguradorasDataMain[i].Id == Detalle_Convenio_Medicos_AseguradorasdeletedItem[j]) {
                    hDetalle_Convenio_Medicos_AseguradorasDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Convenio_Medicos_AseguradorascopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Convenio_Medicos_AseguradorasDataMain.length; i++) {
            data[i] = Detalle_Convenio_Medicos_AseguradorasDataMain[i];

        }
        return data;
    }
    function Detalle_Convenio_Medicos_AseguradorasgetNewResult() {
        var newData = copyMainDetalle_Convenio_Medicos_AseguradorasArray();

        for (var i = 0; i < Detalle_Convenio_Medicos_AseguradorasData.length; i++) {
            if (Detalle_Convenio_Medicos_AseguradorasData[i].Removed == null || Detalle_Convenio_Medicos_AseguradorasData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Convenio_Medicos_AseguradorasData[i]);
            }
        }
        return newData;
    }
    function Detalle_Convenio_Medicos_AseguradoraspushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Convenio_Medicos_AseguradorasDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Convenio_Medicos_AseguradorasDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Detalle_Titulos_MedicosinitializeMainArray(totalCount) {
        if (Detalle_Titulos_MedicosDataMain.length != totalCount && !Detalle_Titulos_MedicosDataMainInitialized) {
            Detalle_Titulos_MedicosDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Titulos_MedicosDataMain[i] = null;
            }
        }
    }
    function Detalle_Titulos_MedicosremoveFromMainArray() {
        for (var j = 0; j < Detalle_Titulos_MedicosdeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Titulos_MedicosDataMain.length; i++) {
                if (Detalle_Titulos_MedicosDataMain[i] != null && Detalle_Titulos_MedicosDataMain[i].Id == Detalle_Titulos_MedicosdeletedItem[j]) {
                    hDetalle_Titulos_MedicosDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Titulos_MedicoscopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Titulos_MedicosDataMain.length; i++) {
            data[i] = Detalle_Titulos_MedicosDataMain[i];

        }
        return data;
    }
    function Detalle_Titulos_MedicosgetNewResult() {
        var newData = copyMainDetalle_Titulos_MedicosArray();

        for (var i = 0; i < Detalle_Titulos_MedicosData.length; i++) {
            if (Detalle_Titulos_MedicosData[i].Removed == null || Detalle_Titulos_MedicosData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Titulos_MedicosData[i]);
            }
        }
        return newData;
    }
    function Detalle_Titulos_MedicospushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Titulos_MedicosDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Titulos_MedicosDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Detalle_Identificacion_Oficial_MedicosinitializeMainArray(totalCount) {
        if (Detalle_Identificacion_Oficial_MedicosDataMain.length != totalCount && !Detalle_Identificacion_Oficial_MedicosDataMainInitialized) {
            Detalle_Identificacion_Oficial_MedicosDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Identificacion_Oficial_MedicosDataMain[i] = null;
            }
        }
    }
    function Detalle_Identificacion_Oficial_MedicosremoveFromMainArray() {
        for (var j = 0; j < Detalle_Identificacion_Oficial_MedicosdeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Identificacion_Oficial_MedicosDataMain.length; i++) {
                if (Detalle_Identificacion_Oficial_MedicosDataMain[i] != null && Detalle_Identificacion_Oficial_MedicosDataMain[i].Id == Detalle_Identificacion_Oficial_MedicosdeletedItem[j]) {
                    hDetalle_Identificacion_Oficial_MedicosDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Identificacion_Oficial_MedicoscopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Identificacion_Oficial_MedicosDataMain.length; i++) {
            data[i] = Detalle_Identificacion_Oficial_MedicosDataMain[i];

        }
        return data;
    }
    function Detalle_Identificacion_Oficial_MedicosgetNewResult() {
        var newData = copyMainDetalle_Identificacion_Oficial_MedicosArray();

        for (var i = 0; i < Detalle_Identificacion_Oficial_MedicosData.length; i++) {
            if (Detalle_Identificacion_Oficial_MedicosData[i].Removed == null || Detalle_Identificacion_Oficial_MedicosData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Identificacion_Oficial_MedicosData[i]);
            }
        }
        return newData;
    }
    function Detalle_Identificacion_Oficial_MedicospushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Identificacion_Oficial_MedicosDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Identificacion_Oficial_MedicosDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Detalle_Codigos_ReferidosinitializeMainArray(totalCount) {
        if (Detalle_Codigos_ReferidosDataMain.length != totalCount && !Detalle_Codigos_ReferidosDataMainInitialized) {
            Detalle_Codigos_ReferidosDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Codigos_ReferidosDataMain[i] = null;
            }
        }
    }
    function Detalle_Codigos_ReferidosremoveFromMainArray() {
        for (var j = 0; j < Detalle_Codigos_ReferidosdeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Codigos_ReferidosDataMain.length; i++) {
                if (Detalle_Codigos_ReferidosDataMain[i] != null && Detalle_Codigos_ReferidosDataMain[i].Id == Detalle_Codigos_ReferidosdeletedItem[j]) {
                    hDetalle_Codigos_ReferidosDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Codigos_ReferidoscopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Codigos_ReferidosDataMain.length; i++) {
            data[i] = Detalle_Codigos_ReferidosDataMain[i];

        }
        return data;
    }
    function Detalle_Codigos_ReferidosgetNewResult() {
        var newData = copyMainDetalle_Codigos_ReferidosArray();

        for (var i = 0; i < Detalle_Codigos_ReferidosData.length; i++) {
            if (Detalle_Codigos_ReferidosData[i].Removed == null || Detalle_Codigos_ReferidosData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Codigos_ReferidosData[i]);
            }
        }
        return newData;
    }
    function Detalle_Codigos_ReferidospushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Codigos_ReferidosDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Codigos_ReferidosDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Detalle_Planes_de_Suscripcion_EspecialistasinitializeMainArray(totalCount) {
        if (Detalle_Planes_de_Suscripcion_EspecialistasDataMain.length != totalCount && !Detalle_Planes_de_Suscripcion_EspecialistasDataMainInitialized) {
            Detalle_Planes_de_Suscripcion_EspecialistasDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Planes_de_Suscripcion_EspecialistasDataMain[i] = null;
            }
        }
    }
    function Detalle_Planes_de_Suscripcion_EspecialistasremoveFromMainArray() {
        for (var j = 0; j < Detalle_Planes_de_Suscripcion_EspecialistasdeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Planes_de_Suscripcion_EspecialistasDataMain.length; i++) {
                if (Detalle_Planes_de_Suscripcion_EspecialistasDataMain[i] != null && Detalle_Planes_de_Suscripcion_EspecialistasDataMain[i].Id == Detalle_Planes_de_Suscripcion_EspecialistasdeletedItem[j]) {
                    hDetalle_Planes_de_Suscripcion_EspecialistasDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Planes_de_Suscripcion_EspecialistascopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Planes_de_Suscripcion_EspecialistasDataMain.length; i++) {
            data[i] = Detalle_Planes_de_Suscripcion_EspecialistasDataMain[i];

        }
        return data;
    }
    function Detalle_Planes_de_Suscripcion_EspecialistasgetNewResult() {
        var newData = copyMainDetalle_Planes_de_Suscripcion_EspecialistasArray();

        for (var i = 0; i < Detalle_Planes_de_Suscripcion_EspecialistasData.length; i++) {
            if (Detalle_Planes_de_Suscripcion_EspecialistasData[i].Removed == null || Detalle_Planes_de_Suscripcion_EspecialistasData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Planes_de_Suscripcion_EspecialistasData[i]);
            }
        }
        return newData;
    }
    function Detalle_Planes_de_Suscripcion_EspecialistaspushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Planes_de_Suscripcion_EspecialistasDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Planes_de_Suscripcion_EspecialistasDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Detalle_Facturacion_EspecialistasinitializeMainArray(totalCount) {
        if (Detalle_Facturacion_EspecialistasDataMain.length != totalCount && !Detalle_Facturacion_EspecialistasDataMainInitialized) {
            Detalle_Facturacion_EspecialistasDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Facturacion_EspecialistasDataMain[i] = null;
            }
        }
    }
    function Detalle_Facturacion_EspecialistasremoveFromMainArray() {
        for (var j = 0; j < Detalle_Facturacion_EspecialistasdeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Facturacion_EspecialistasDataMain.length; i++) {
                if (Detalle_Facturacion_EspecialistasDataMain[i] != null && Detalle_Facturacion_EspecialistasDataMain[i].Id == Detalle_Facturacion_EspecialistasdeletedItem[j]) {
                    hDetalle_Facturacion_EspecialistasDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Facturacion_EspecialistascopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Facturacion_EspecialistasDataMain.length; i++) {
            data[i] = Detalle_Facturacion_EspecialistasDataMain[i];

        }
        return data;
    }
    function Detalle_Facturacion_EspecialistasgetNewResult() {
        var newData = copyMainDetalle_Facturacion_EspecialistasArray();

        for (var i = 0; i < Detalle_Facturacion_EspecialistasData.length; i++) {
            if (Detalle_Facturacion_EspecialistasData[i].Removed == null || Detalle_Facturacion_EspecialistasData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Facturacion_EspecialistasData[i]);
            }
        }
        return newData;
    }
    function Detalle_Facturacion_EspecialistaspushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Facturacion_EspecialistasDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Facturacion_EspecialistasDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }

});

var AutoCompleteTitulo_PersonalData = [];
function GetAutoCompleteMedicos_Titulo_Personal_Titulos_PersonalesData(data) {
	AutoCompleteTitulo_PersonalData = [];
    for (var i = 0; i < data.length; i++) {
        AutoCompleteTitulo_PersonalData.push({
            id: data[i].Clave,
            text: data[i].Descripcion
        });
    }
    return AutoCompleteTitulo_PersonalData;
}
//Grid GetAutocomplete

//Grid GetAutocomplete

//Grid GetAutocomplete

//Grid GetAutocomplete

//Grid GetAutocomplete

//Grid GetAutocomplete

//Grid GetAutocomplete



function getDropdown(elementKey) {
    var labelSelect = $("#Medicos_cmbLabelSelect").val();
    var dropDown = '<select id="' + elementKey + '" class="form-control"><option value="">' + labelSelect + '</option></select>';
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
    $("#ReferenceFolio").val("0");
    $('#CreateMedicos')[0].reset();
    ClearFormControls();
    $("#FolioId").val("0");
    $('#Titulo_Personal').empty();
    $("#Titulo_Personal").append('<option value=""></option>');
    $('#Titulo_Personal').val('0').trigger('change');
                Detalle_Redes_Sociales_EspecialistaClearGridData();
                Detalle_Convenio_Medicos_AseguradorasClearGridData();
                Detalle_Titulos_MedicosClearGridData();
                Detalle_Identificacion_Oficial_MedicosClearGridData();
                Detalle_Codigos_ReferidosClearGridData();
                Detalle_Planes_de_Suscripcion_EspecialistasClearGridData();
                Detalle_Facturacion_EspecialistasClearGridData();

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreateMedicos').trigger('reset');
    $('#CreateMedicos').find(':input').each(function () {
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
    var $myForm = $('#CreateMedicos');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    if (Detalle_Redes_Sociales_EspecialistacountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Redes_Sociales_Especialista();
        return false;
    }
    if (Detalle_Convenio_Medicos_AseguradorascountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Convenio_Medicos_Aseguradoras();
        return false;
    }
    if (Detalle_Titulos_MedicoscountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Titulos_Medicos();
        return false;
    }
    if (Detalle_Identificacion_Oficial_MedicoscountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Identificacion_Oficial_Medicos();
        return false;
    }
    if (Detalle_Codigos_ReferidoscountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Codigos_Referidos();
        return false;
    }
    if (Detalle_Planes_de_Suscripcion_EspecialistascountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Planes_de_Suscripcion_Especialistas();
        return false;
    }
    if (Detalle_Facturacion_EspecialistascountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Facturacion_Especialistas();
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblFolio").text("0");
}
$(document).ready(function () {
    $("form#CreateMedicos").submit(function (e) {
        e.preventDefault();
        return false;
    });
	$("form#CreateMedicos").on('click', '#MedicosCancelar', function () {
	  if (!isPartial) {
        MedicosBackToGrid();
	  } else {
            window.close();
      }
    });
	$("form#CreateMedicos").on('click', '#MedicosGuardar', function () {
		$('#MedicosGuardar').attr('disabled', true);
		$('#MedicosGuardar').unbind()
        if (EjecutarValidacionesAntesDeGuardar() && CheckValidation()) {
				if (!SendMedicosData(function () {
					EjecutarValidacionesDespuesDeGuardar();
					if (!isPartial)
						MedicosBackToGrid();
					else {						
						if (!isMR)
							window.opener.RefreshCatalog('Medicos', nameAttribute);
						else {
							var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
							if(!control.hasClass('AutoComplete'))
							{
							if (control.attr("data-isfilter") == "true") {
									eval(GetReglaFilter(control,  $(window.opener.document.getElementById('ObjectId')).val()));								    
								}
								else 
								{
									eval('window.opener.Get' + nameMR + '_MedicosItem()');
									var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
									control.html(eval('window.opener.Get' + nameMR + '_MedicosDropDown().get(0)').innerHTML);  
								}								
							}
						}
						window.close();						
						}
				})) {
					$('#MedicosGuardar').removeAttr('disabled');
					$('#MedicosGuardar').bind()
				}
		}
		else {
			$('#MedicosGuardar').removeAttr('disabled');
			$('#MedicosGuardar').bind()
		}
    });
	$("form#CreateMedicos").on('click', '#MedicosGuardarYNuevo', function () {	
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation()) {
				SendMedicosData(function () {
					ClearControls();
					ClearAttachmentsDiv();
					ResetClaveLabel();
	                getDetalle_Redes_Sociales_EspecialistaData();
                getDetalle_Convenio_Medicos_AseguradorasData();
                getDetalle_Titulos_MedicosData();
                getDetalle_Identificacion_Oficial_MedicosData();
                getDetalle_Codigos_ReferidosData();
                getDetalle_Planes_de_Suscripcion_EspecialistasData();
                getDetalle_Facturacion_EspecialistasData();

					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Medicos', nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_MedicosItem()');                           
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
                            control.html(eval('window.opener.Get' + nameMR + '_MedicosDropDown().get(0)').innerHTML);   
					    }	
					}						
					EjecutarValidacionesDespuesDeGuardar();				
			setIsNew();
			EjecutarValidacionesAlComienzo();
				});
			}
		}		
    });
    $("form#CreateMedicos").on('click', '#MedicosGuardarYCopia', function () {
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendMedicosData(function (currentId) {
					$("#FolioId").val("0");
	    $('#Titulo_Personal').empty();
    $("#Titulo_Personal").append('<option value=""></option>');
    $('#Titulo_Personal').val('0').trigger('change');
                Detalle_Redes_Sociales_EspecialistaClearGridData();
                Detalle_Convenio_Medicos_AseguradorasClearGridData();
                Detalle_Titulos_MedicosClearGridData();
                Detalle_Identificacion_Oficial_MedicosClearGridData();
                Detalle_Codigos_ReferidosClearGridData();
                Detalle_Planes_de_Suscripcion_EspecialistasClearGridData();
                Detalle_Facturacion_EspecialistasClearGridData();

					ResetClaveLabel();
					$("#ReferenceFolio").val(currentId);
	                getDetalle_Redes_Sociales_EspecialistaData();
                getDetalle_Convenio_Medicos_AseguradorasData();
                getDetalle_Titulos_MedicosData();
                getDetalle_Identificacion_Oficial_MedicosData();
                getDetalle_Codigos_ReferidosData();
                getDetalle_Planes_de_Suscripcion_EspecialistasData();
                getDetalle_Facturacion_EspecialistasData();

					EjecutarValidacionesDespuesDeGuardar();		
					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Medicos',nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_MedicosItem()');                          
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);						
							control.html(eval('window.opener.Get' + nameMR + '_MedicosDropDown().get(0)').innerHTML);                          
					    }	
					}						
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
        $(element).attr('title', (mainElementObject[elementNumber].IsRequired == true ? GetTraduction('Required') : GetTraduction('NotRequired')));
        if (!mainElementObject[elementNumber].IsVisible && mainElementObject[elementNumber].IsRequired) {
            setVisible(elementNumber, $(element).parent().parent().find('div.visibleAttribute').find('a'), elementType);
        }
        if (mainElementObject[elementNumber].IsReadOnly && mainElementObject[elementNumber].IsRequired && mainElementObject[elementNumber].DefaultValue == '') {
            setReadOnly(elementNumber, $(element).parent().parent().find('div.readOnlyAttribute').find('a'), elementType);
        }
    } else {
        getElementTable(elementNumber, table).IsRequired = (getElementTable(elementNumber, table).IsRequired == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (getElementTable(elementNumber, table).IsRequired == true ? "Images/Required.png" : "Images/Not-Required.png") + "");
        $(element).attr('title', (getElementTable(elementNumber, table).IsRequired == true ? GetTraduction('Required') : GetTraduction('NotRequired')));
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
            showNotification(GetTraduction("messagedNoInVisible"), "error");
            return;
        }
        mainElementObject[elementNumber].IsVisible = (mainElementObject[elementNumber].IsVisible == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[elementNumber].IsVisible == true ? "Images/Visible.png" : "Images/inVisible.png") + "");
        $(element).attr('title', (mainElementObject[elementNumber].IsVisible == true ? GetTraduction('Visible') : GetTraduction('InVisible')));
    } else {
        if (getElementTable(elementNumber, table).IsRequired && getElementTable(elementNumber, table).DefaultValue == '' && getElementTable(elementNumber, table).IsVisible) {
            showNotification(GetTraduction("messagedNoInVisible"), "error");
            return;
        }
        getElementTable(elementNumber, table).IsVisible = (getElementTable(elementNumber, table).IsVisible == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (getElementTable(elementNumber, table).IsVisible == true ? "Images/Visible.png" : "Images/inVisible.png") + "");
        $(element).attr('title', (getElementTable(elementNumber, table).IsVisible == true ? GetTraduction('Visible') : GetTraduction('InVisible')));
    }
}
function setReadOnly(elementNumber, element, elementType, table) {
    if (elementType == "1") {
        if (mainElementObject[elementNumber].IsRequired && mainElementObject[elementNumber].DefaultValue == '' && !mainElementObject[elementNumber].IsReadOnly) {
            showNotification(GetTraduction("messagedNoReadOnly"), "error");
            return;
        }
        mainElementObject[elementNumber].IsReadOnly = (mainElementObject[elementNumber].IsReadOnly == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[elementNumber].IsReadOnly == true ? "Images/Disabled.png" : "Images/Enabled.png") + "");
        $(element).attr('title', (mainElementObject[elementNumber].IsReadOnly == true ?GetTraduction('Disabled') : GetTraduction('Enabled')));
    } else {
        if (getElementTable(elementNumber, table).IsRequired && getElementTable(elementNumber, table).DefaultValue == '' && !getElementTable(elementNumber, table).IsReadOnly) {
            showNotification(GetTraduction("messagedNoReadOnly"), "error");
            return;
        }
        getElementTable(elementNumber, table).IsReadOnly = (getElementTable(elementNumber, table).IsReadOnly == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (getElementTable(elementNumber, table).IsReadOnly == true ? "Images/Disabled.png" : "Images/Enabled.png") + "");
        $(element).attr('title', (getElementTable(elementNumber, table).IsReadOnly == true ? GetTraduction('Disabled') : GetTraduction('Enabled')));
    }
}
function setDefaultValue(elementNumber, element, elementType, table) {
    //debugger;
    $('#hdnAttributType').val('1');
    $('#hdnAttributNumber').val(elementNumber);
    $('#lblAttributeType').text(GetTraduction('DefaultValue'));
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
    $('#lblAttributeType').text(GetTraduction('HelpText'));
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
    mainElementAttributes += '<div class="displayAttributes requiredAttribute"><a class="requiredClick" title="' + (element.IsRequired == true ? GetTraduction("Required") : GetTraduction("NotRequired")) + '" onclick="setRequired(' + number.toString() + ', this, 2,  \'' + table + '\')"><img src="' + $('#hdnApplicationDirectory').val() + (element.IsRequired == true ? "Images/Required.png" : "Images/Not-Required.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes visibleAttribute"><a class="visibleClick" title="' + (element.IsVisible == true ? GetTraduction("Visible") : GetTraduction("InVisible")) + '" onclick="setVisible(' + number.toString() + ', this, 2,  \'' + table + '\')"><img src="' + $('#hdnApplicationDirectory').val() + (element.IsVisible == true ? "Images/Visible.png" : "Images/InVisible.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes readOnlyAttribute"><a class="readOnlyClick" title="' + (element.IsReadOnly == true ?GetTraduction("Disabled") :GetTraduction("Enabled")) + '" onclick="setReadOnly(' + number.toString() + ', this, 2,  \'' + table + '\')"><img src="' + $('#hdnApplicationDirectory').val() + (element.IsReadOnly == true ? "Images/Disabled.png" : "Images/Enabled.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes defaultValueAttribute"><a id="hlDefaultValueHeader_' + number.toString() + '" class="defaultValueClick" title="' + (element.DefaultValue) + '" onclick="setDefaultValue(' + number.toString() + ', this, 2,  "' + table + '")"><img src="' + $('#hdnApplicationDirectory').val() + (element.DefaultValue != '' && element.DefaultValue != null ? "Images/default-value.png" : "Images/Not-Default-Value.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes helpTextAttribute"><a id="hlHelpTextHeader_' + number.toString() + '" class="helpTextClick" title="' + (element.HelpText) + '" onclick="setHelpText(' + number.toString() + ', this, 2,  \'' + table + '\')"><img src="' + $('#hdnApplicationDirectory').val() + (element.HelpText != '' && element.HelpText != null ? "Images/green-help.png" : "Images/red-help.jpg") + '" alt="" /></a></div>';
    mainElementAttributes += '</div>';
    return mainElementAttributes;
}



var MedicosisdisplayBusinessPropery = false;
MedicosDisplayBusinessRuleButtons(MedicosisdisplayBusinessPropery);
function MedicosDisplayBusinessRule() {
    if (!MedicosisdisplayBusinessPropery) {
        $('#CreateMedicos').find('.col-sm-8').each(function () {
			var div =$(this); 
			if ($(this).find('.input-group').length >0)
				div  =  $(this).find('.input-group').first().hasClass('date')? $(this): $(this).find('.input-group').first();	
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = div.data('field-id');
            var fieldName = div.data('field-name');
            var attribute = div.data('attribute');
            mainElementAttributes += '<div class="MedicosdisplayBusinessPropery"><button onclick="MedicosGetBusinessRule()" type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#MedicosBusinessRule-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.MedicosdisplayBusinessPropery').remove();
    }
    MedicosDisplayBusinessRuleButtons(!MedicosisdisplayBusinessPropery);
    MedicosisdisplayBusinessPropery = (MedicosisdisplayBusinessPropery ? false : true);
}
function MedicosDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}

