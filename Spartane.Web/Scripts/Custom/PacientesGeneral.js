

//Begin Declarations for Foreigns fields for Detalle_de_Padecimientos MultiRow
var Detalle_de_PadecimientoscountRowsChecked = 0;

function GetDetalle_de_Padecimientos_PadecimientosName(Id) {
    for (var i = 0; i < Detalle_de_Padecimientos_PadecimientosItems.length; i++) {
        if (Detalle_de_Padecimientos_PadecimientosItems[i].Clave == Id) {
            return Detalle_de_Padecimientos_PadecimientosItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_de_Padecimientos_PadecimientosDropDown() {
    var Detalle_de_Padecimientos_PadecimientosDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_de_Padecimientos_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_de_Padecimientos_PadecimientosDropdown);
    if(Detalle_de_Padecimientos_PadecimientosItems != null)
    {
       for (var i = 0; i < Detalle_de_Padecimientos_PadecimientosItems.length; i++) {
           $('<option />', { value: Detalle_de_Padecimientos_PadecimientosItems[i].Clave, text:    Detalle_de_Padecimientos_PadecimientosItems[i].Descripcion }).appendTo(Detalle_de_Padecimientos_PadecimientosDropdown);
       }
    }
    return Detalle_de_Padecimientos_PadecimientosDropdown;
}
function GetDetalle_de_Padecimientos_Tiempo_PadecimientoName(Id) {
    for (var i = 0; i < Detalle_de_Padecimientos_Tiempo_PadecimientoItems.length; i++) {
        if (Detalle_de_Padecimientos_Tiempo_PadecimientoItems[i].Clave == Id) {
            return Detalle_de_Padecimientos_Tiempo_PadecimientoItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_de_Padecimientos_Tiempo_PadecimientoDropDown() {
    var Detalle_de_Padecimientos_Tiempo_PadecimientoDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_de_Padecimientos_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_de_Padecimientos_Tiempo_PadecimientoDropdown);
    if(Detalle_de_Padecimientos_Tiempo_PadecimientoItems != null)
    {
       for (var i = 0; i < Detalle_de_Padecimientos_Tiempo_PadecimientoItems.length; i++) {
           $('<option />', { value: Detalle_de_Padecimientos_Tiempo_PadecimientoItems[i].Clave, text:    Detalle_de_Padecimientos_Tiempo_PadecimientoItems[i].Descripcion }).appendTo(Detalle_de_Padecimientos_Tiempo_PadecimientoDropdown);
       }
    }
    return Detalle_de_Padecimientos_Tiempo_PadecimientoDropdown;
}
function GetDetalle_de_Padecimientos_Respuesta_LogicaName(Id) {
    for (var i = 0; i < Detalle_de_Padecimientos_Respuesta_LogicaItems.length; i++) {
        if (Detalle_de_Padecimientos_Respuesta_LogicaItems[i].Clave == Id) {
            return Detalle_de_Padecimientos_Respuesta_LogicaItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_de_Padecimientos_Respuesta_LogicaDropDown() {
    var Detalle_de_Padecimientos_Respuesta_LogicaDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_de_Padecimientos_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_de_Padecimientos_Respuesta_LogicaDropdown);
    if(Detalle_de_Padecimientos_Respuesta_LogicaItems != null)
    {
       for (var i = 0; i < Detalle_de_Padecimientos_Respuesta_LogicaItems.length; i++) {
           $('<option />', { value: Detalle_de_Padecimientos_Respuesta_LogicaItems[i].Clave, text:    Detalle_de_Padecimientos_Respuesta_LogicaItems[i].Descripcion }).appendTo(Detalle_de_Padecimientos_Respuesta_LogicaDropdown);
       }
    }
    return Detalle_de_Padecimientos_Respuesta_LogicaDropdown;
}

function GetDetalle_de_Padecimientos_Estatus_PadecimientoName(Id) {
    for (var i = 0; i < Detalle_de_Padecimientos_Estatus_PadecimientoItems.length; i++) {
        if (Detalle_de_Padecimientos_Estatus_PadecimientoItems[i].Clave == Id) {
            return Detalle_de_Padecimientos_Estatus_PadecimientoItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_de_Padecimientos_Estatus_PadecimientoDropDown() {
    var Detalle_de_Padecimientos_Estatus_PadecimientoDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_de_Padecimientos_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_de_Padecimientos_Estatus_PadecimientoDropdown);
    if(Detalle_de_Padecimientos_Estatus_PadecimientoItems != null)
    {
       for (var i = 0; i < Detalle_de_Padecimientos_Estatus_PadecimientoItems.length; i++) {
           $('<option />', { value: Detalle_de_Padecimientos_Estatus_PadecimientoItems[i].Clave, text:    Detalle_de_Padecimientos_Estatus_PadecimientoItems[i].Descripcion }).appendTo(Detalle_de_Padecimientos_Estatus_PadecimientoDropdown);
       }
    }
    return Detalle_de_Padecimientos_Estatus_PadecimientoDropdown;
}


function GetInsertDetalle_de_PadecimientosRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $(GetDetalle_de_Padecimientos_PadecimientosDropDown()).addClass('Detalle_de_Padecimientos_Padecimiento Padecimiento').attr('id', 'Detalle_de_Padecimientos_Padecimiento_' + index).attr('data-field', 'Padecimiento').after($.parseHTML(addNew('Detalle_de_Padecimientos', 'Padecimientos', 'Padecimiento', 257617)));
    columnData[1] = $(GetDetalle_de_Padecimientos_Tiempo_PadecimientoDropDown()).addClass('Detalle_de_Padecimientos_Tiempo_con_el_diagnostico Tiempo_con_el_diagnostico').attr('id', 'Detalle_de_Padecimientos_Tiempo_con_el_diagnostico_' + index).attr('data-field', 'Tiempo_con_el_diagnostico').after($.parseHTML(addNew('Detalle_de_Padecimientos', 'Tiempo_Padecimiento', 'Tiempo_con_el_diagnostico', 257618)));
    columnData[2] = $(GetDetalle_de_Padecimientos_Respuesta_LogicaDropDown()).addClass('Detalle_de_Padecimientos_Intervencion_quirurgica Intervencion_quirurgica').attr('id', 'Detalle_de_Padecimientos_Intervencion_quirurgica_' + index).attr('data-field', 'Intervencion_quirurgica').after($.parseHTML(addNew('Detalle_de_Padecimientos', 'Respuesta_Logica', 'Intervencion_quirurgica', 259119)));
    columnData[3] = $($.parseHTML(inputData)).addClass('Detalle_de_Padecimientos_Tratamiento Tratamiento').attr('id', 'Detalle_de_Padecimientos_Tratamiento_' + index).attr('data-field', 'Tratamiento');
    columnData[4] = $(GetDetalle_de_Padecimientos_Estatus_PadecimientoDropDown()).addClass('Detalle_de_Padecimientos_Estado_actual Estado_actual').attr('id', 'Detalle_de_Padecimientos_Estado_actual_' + index).attr('data-field', 'Estado_actual').after($.parseHTML(addNew('Detalle_de_Padecimientos', 'Estatus_Padecimiento', 'Estado_actual', 257620)));


    initiateUIControls();
    return columnData;
}

function Detalle_de_PadecimientosInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_de_Padecimientos("Detalle_de_Padecimientos_", "_" + rowIndex)) {
    var iPage = Detalle_de_PadecimientosTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_de_Padecimientos';
    var prevData = Detalle_de_PadecimientosTable.fnGetData(rowIndex);
    var data = Detalle_de_PadecimientosTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Padecimiento:  data.childNodes[counter++].childNodes[0].value
        ,Tiempo_con_el_diagnostico:  data.childNodes[counter++].childNodes[0].value
        ,Intervencion_quirurgica:  data.childNodes[counter++].childNodes[0].value
        ,Tratamiento:  data.childNodes[counter++].childNodes[0].value
        ,Estado_actual:  data.childNodes[counter++].childNodes[0].value

    }
    Detalle_de_PadecimientosTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_de_PadecimientosrowCreationGrid(data, newData, rowIndex);
    Detalle_de_PadecimientosTable.fnPageChange(iPage);
    Detalle_de_PadecimientoscountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_de_Padecimientos("Detalle_de_Padecimientos_", "_" + rowIndex);
  }
}

function Detalle_de_PadecimientosCancelRow(rowIndex) {
    var prevData = Detalle_de_PadecimientosTable.fnGetData(rowIndex);
    var data = Detalle_de_PadecimientosTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_de_PadecimientosTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_de_PadecimientosrowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_de_PadecimientosGrid(Detalle_de_PadecimientosTable.fnGetData());
    Detalle_de_PadecimientoscountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_de_PadecimientosFromDataTable() {
    var Detalle_de_PadecimientosData = [];
    var gridData = Detalle_de_PadecimientosTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_de_PadecimientosData.push({
                Folio: gridData[i].Folio

                ,Padecimiento: gridData[i].Padecimiento
                ,Tiempo_con_el_diagnostico: gridData[i].Tiempo_con_el_diagnostico
                ,Intervencion_quirurgica: gridData[i].Intervencion_quirurgica
                ,Tratamiento: gridData[i].Tratamiento
                ,Estado_actual: gridData[i].Estado_actual

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_de_PadecimientosData.length; i++) {
        if (removedDetalle_de_PadecimientosData[i] != null && removedDetalle_de_PadecimientosData[i].Folio > 0)
            Detalle_de_PadecimientosData.push({
                Folio: removedDetalle_de_PadecimientosData[i].Folio

                ,Padecimiento: removedDetalle_de_PadecimientosData[i].Padecimiento
                ,Tiempo_con_el_diagnostico: removedDetalle_de_PadecimientosData[i].Tiempo_con_el_diagnostico
                ,Intervencion_quirurgica: removedDetalle_de_PadecimientosData[i].Intervencion_quirurgica
                ,Tratamiento: removedDetalle_de_PadecimientosData[i].Tratamiento
                ,Estado_actual: removedDetalle_de_PadecimientosData[i].Estado_actual

                , Removed: true
            });
    }	

    return Detalle_de_PadecimientosData;
}

function Detalle_de_PadecimientosEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_de_PadecimientosTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_de_PadecimientoscountRowsChecked++;
    var Detalle_de_PadecimientosRowElement = "Detalle_de_Padecimientos_" + rowIndex.toString();
    var prevData = Detalle_de_PadecimientosTable.fnGetData(rowIndexTable );
    var row = Detalle_de_PadecimientosTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_de_Padecimientos_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_de_PadecimientosGetUpdateRowControls(prevData, "Detalle_de_Padecimientos_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_de_PadecimientosRowElement + "')){ Detalle_de_PadecimientosInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_de_PadecimientosCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_de_PadecimientosGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_de_PadecimientosGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_de_PadecimientosValidation();
    initiateUIControls();
    $('.Detalle_de_Padecimientos' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_de_Padecimientos(nameOfTable, rowIndexFormed);
    }
}

function Detalle_de_PadecimientosfnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_de_PadecimientosTable.fnGetData().length;
    Detalle_de_PadecimientosfnClickAddRow();
    GetAddDetalle_de_PadecimientosPopup(currentRowIndex, 0);
}

function Detalle_de_PadecimientosEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_de_PadecimientosTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_de_PadecimientosRowElement = "Detalle_de_Padecimientos_" + rowIndex.toString();
    var prevData = Detalle_de_PadecimientosTable.fnGetData(rowIndexTable);
    GetAddDetalle_de_PadecimientosPopup(rowIndex, 1, prevData.Folio);

    $('#Detalle_de_PadecimientosPadecimiento').val(prevData.Padecimiento);
    $('#Detalle_de_PadecimientosTiempo_con_el_diagnostico').val(prevData.Tiempo_con_el_diagnostico);
    $('#Detalle_de_PadecimientosIntervencion_quirurgica').val(prevData.Intervencion_quirurgica);
    $('#Detalle_de_PadecimientosTratamiento').val(prevData.Tratamiento);
    $('#Detalle_de_PadecimientosEstado_actual').val(prevData.Estado_actual);

    initiateUIControls();







}

function Detalle_de_PadecimientosAddInsertRow() {
    if (Detalle_de_PadecimientosinsertRowCurrentIndex < 1)
    {
        Detalle_de_PadecimientosinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Padecimiento: ""
        ,Tiempo_con_el_diagnostico: ""
        ,Intervencion_quirurgica: ""
        ,Tratamiento: ""
        ,Estado_actual: ""

    }
}

function Detalle_de_PadecimientosfnClickAddRow() {
    Detalle_de_PadecimientoscountRowsChecked++;
    Detalle_de_PadecimientosTable.fnAddData(Detalle_de_PadecimientosAddInsertRow(), true);
    Detalle_de_PadecimientosTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_de_PadecimientosGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_de_PadecimientosGrid tbody tr:nth-of-type(' + (Detalle_de_PadecimientosinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_de_Padecimientos("Detalle_de_Padecimientos_", "_" + Detalle_de_PadecimientosinsertRowCurrentIndex);
}

function Detalle_de_PadecimientosClearGridData() {
    Detalle_de_PadecimientosData = [];
    Detalle_de_PadecimientosdeletedItem = [];
    Detalle_de_PadecimientosDataMain = [];
    Detalle_de_PadecimientosDataMainPages = [];
    Detalle_de_PadecimientosnewItemCount = 0;
    Detalle_de_PadecimientosmaxItemIndex = 0;
    $("#Detalle_de_PadecimientosGrid").DataTable().clear();
    $("#Detalle_de_PadecimientosGrid").DataTable().destroy();
}

//Used to Get Pacientes Information
function GetDetalle_de_Padecimientos() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_de_PadecimientosData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_de_PadecimientosData[i].Folio);

        form_data.append('[' + i + '].Padecimiento', Detalle_de_PadecimientosData[i].Padecimiento);
        form_data.append('[' + i + '].Tiempo_con_el_diagnostico', Detalle_de_PadecimientosData[i].Tiempo_con_el_diagnostico);
        form_data.append('[' + i + '].Intervencion_quirurgica', Detalle_de_PadecimientosData[i].Intervencion_quirurgica);
        form_data.append('[' + i + '].Tratamiento', Detalle_de_PadecimientosData[i].Tratamiento);
        form_data.append('[' + i + '].Estado_actual', Detalle_de_PadecimientosData[i].Estado_actual);

        form_data.append('[' + i + '].Removed', Detalle_de_PadecimientosData[i].Removed);
    }
    return form_data;
}
function Detalle_de_PadecimientosInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_de_Padecimientos("Detalle_de_PadecimientosTable", rowIndex)) {
    var prevData = Detalle_de_PadecimientosTable.fnGetData(rowIndex);
    var data = Detalle_de_PadecimientosTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Padecimiento: $('#Detalle_de_PadecimientosPadecimiento').val()
        ,Tiempo_con_el_diagnostico: $('#Detalle_de_PadecimientosTiempo_con_el_diagnostico').val()
        ,Intervencion_quirurgica: $('#Detalle_de_PadecimientosIntervencion_quirurgica').val()
        ,Tratamiento: $('#Detalle_de_PadecimientosTratamiento').val()
        ,Estado_actual: $('#Detalle_de_PadecimientosEstado_actual').val()

    }

    Detalle_de_PadecimientosTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_de_PadecimientosrowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_de_Padecimientos-form').modal({ show: false });
    $('#AddDetalle_de_Padecimientos-form').modal('hide');
    Detalle_de_PadecimientosEditRow(rowIndex);
    Detalle_de_PadecimientosInsertRow(rowIndex);
    //}
}
function Detalle_de_PadecimientosRemoveAddRow(rowIndex) {
    Detalle_de_PadecimientosTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_de_Padecimientos MultiRow
//Begin Declarations for Foreigns fields for Detalle_Antecedentes_Familiares MultiRow
var Detalle_Antecedentes_FamiliarescountRowsChecked = 0;

function GetDetalle_Antecedentes_Familiares_PadecimientosName(Id) {
    for (var i = 0; i < Detalle_Antecedentes_Familiares_PadecimientosItems.length; i++) {
        if (Detalle_Antecedentes_Familiares_PadecimientosItems[i].Clave == Id) {
            return Detalle_Antecedentes_Familiares_PadecimientosItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Antecedentes_Familiares_PadecimientosDropDown() {
    var Detalle_Antecedentes_Familiares_PadecimientosDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Antecedentes_Familiares_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Antecedentes_Familiares_PadecimientosDropdown);
    if(Detalle_Antecedentes_Familiares_PadecimientosItems != null)
    {
       for (var i = 0; i < Detalle_Antecedentes_Familiares_PadecimientosItems.length; i++) {
           $('<option />', { value: Detalle_Antecedentes_Familiares_PadecimientosItems[i].Clave, text:    Detalle_Antecedentes_Familiares_PadecimientosItems[i].Descripcion }).appendTo(Detalle_Antecedentes_Familiares_PadecimientosDropdown);
       }
    }
    return Detalle_Antecedentes_Familiares_PadecimientosDropdown;
}
function GetDetalle_Antecedentes_Familiares_ParentescoName(Id) {
    for (var i = 0; i < Detalle_Antecedentes_Familiares_ParentescoItems.length; i++) {
        if (Detalle_Antecedentes_Familiares_ParentescoItems[i].Clave == Id) {
            return Detalle_Antecedentes_Familiares_ParentescoItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Antecedentes_Familiares_ParentescoDropDown() {
    var Detalle_Antecedentes_Familiares_ParentescoDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Antecedentes_Familiares_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Antecedentes_Familiares_ParentescoDropdown);
    if(Detalle_Antecedentes_Familiares_ParentescoItems != null)
    {
       for (var i = 0; i < Detalle_Antecedentes_Familiares_ParentescoItems.length; i++) {
           $('<option />', { value: Detalle_Antecedentes_Familiares_ParentescoItems[i].Clave, text:    Detalle_Antecedentes_Familiares_ParentescoItems[i].Descripcion }).appendTo(Detalle_Antecedentes_Familiares_ParentescoDropdown);
       }
    }
    return Detalle_Antecedentes_Familiares_ParentescoDropdown;
}


function GetInsertDetalle_Antecedentes_FamiliaresRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $(GetDetalle_Antecedentes_Familiares_PadecimientosDropDown()).addClass('Detalle_Antecedentes_Familiares_Enfermedad Enfermedad').attr('id', 'Detalle_Antecedentes_Familiares_Enfermedad_' + index).attr('data-field', 'Enfermedad').after($.parseHTML(addNew('Detalle_Antecedentes_Familiares', 'Padecimientos', 'Enfermedad', 257759)));
    columnData[1] = $(GetDetalle_Antecedentes_Familiares_ParentescoDropDown()).addClass('Detalle_Antecedentes_Familiares_Parentesco Parentesco').attr('id', 'Detalle_Antecedentes_Familiares_Parentesco_' + index).attr('data-field', 'Parentesco').after($.parseHTML(addNew('Detalle_Antecedentes_Familiares', 'Parentesco', 'Parentesco', 257760)));


    initiateUIControls();
    return columnData;
}

function Detalle_Antecedentes_FamiliaresInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Antecedentes_Familiares("Detalle_Antecedentes_Familiares_", "_" + rowIndex)) {
    var iPage = Detalle_Antecedentes_FamiliaresTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Antecedentes_Familiares';
    var prevData = Detalle_Antecedentes_FamiliaresTable.fnGetData(rowIndex);
    var data = Detalle_Antecedentes_FamiliaresTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Enfermedad:  data.childNodes[counter++].childNodes[0].value
        ,Parentesco:  data.childNodes[counter++].childNodes[0].value

    }
    Detalle_Antecedentes_FamiliaresTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Antecedentes_FamiliaresrowCreationGrid(data, newData, rowIndex);
    Detalle_Antecedentes_FamiliaresTable.fnPageChange(iPage);
    Detalle_Antecedentes_FamiliarescountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Antecedentes_Familiares("Detalle_Antecedentes_Familiares_", "_" + rowIndex);
  }
}

function Detalle_Antecedentes_FamiliaresCancelRow(rowIndex) {
    var prevData = Detalle_Antecedentes_FamiliaresTable.fnGetData(rowIndex);
    var data = Detalle_Antecedentes_FamiliaresTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Antecedentes_FamiliaresTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Antecedentes_FamiliaresrowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Antecedentes_FamiliaresGrid(Detalle_Antecedentes_FamiliaresTable.fnGetData());
    Detalle_Antecedentes_FamiliarescountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Antecedentes_FamiliaresFromDataTable() {
    var Detalle_Antecedentes_FamiliaresData = [];
    var gridData = Detalle_Antecedentes_FamiliaresTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Antecedentes_FamiliaresData.push({
                Folio: gridData[i].Folio

                ,Enfermedad: gridData[i].Enfermedad
                ,Parentesco: gridData[i].Parentesco

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Antecedentes_FamiliaresData.length; i++) {
        if (removedDetalle_Antecedentes_FamiliaresData[i] != null && removedDetalle_Antecedentes_FamiliaresData[i].Folio > 0)
            Detalle_Antecedentes_FamiliaresData.push({
                Folio: removedDetalle_Antecedentes_FamiliaresData[i].Folio

                ,Enfermedad: removedDetalle_Antecedentes_FamiliaresData[i].Enfermedad
                ,Parentesco: removedDetalle_Antecedentes_FamiliaresData[i].Parentesco

                , Removed: true
            });
    }	

    return Detalle_Antecedentes_FamiliaresData;
}

function Detalle_Antecedentes_FamiliaresEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Antecedentes_FamiliaresTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Antecedentes_FamiliarescountRowsChecked++;
    var Detalle_Antecedentes_FamiliaresRowElement = "Detalle_Antecedentes_Familiares_" + rowIndex.toString();
    var prevData = Detalle_Antecedentes_FamiliaresTable.fnGetData(rowIndexTable );
    var row = Detalle_Antecedentes_FamiliaresTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Antecedentes_Familiares_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Antecedentes_FamiliaresGetUpdateRowControls(prevData, "Detalle_Antecedentes_Familiares_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Antecedentes_FamiliaresRowElement + "')){ Detalle_Antecedentes_FamiliaresInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_Antecedentes_FamiliaresCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Antecedentes_FamiliaresGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Antecedentes_FamiliaresGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_Antecedentes_FamiliaresValidation();
    initiateUIControls();
    $('.Detalle_Antecedentes_Familiares' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Antecedentes_Familiares(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Antecedentes_FamiliaresfnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Antecedentes_FamiliaresTable.fnGetData().length;
    Detalle_Antecedentes_FamiliaresfnClickAddRow();
    GetAddDetalle_Antecedentes_FamiliaresPopup(currentRowIndex, 0);
}

function Detalle_Antecedentes_FamiliaresEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Antecedentes_FamiliaresTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Antecedentes_FamiliaresRowElement = "Detalle_Antecedentes_Familiares_" + rowIndex.toString();
    var prevData = Detalle_Antecedentes_FamiliaresTable.fnGetData(rowIndexTable);
    GetAddDetalle_Antecedentes_FamiliaresPopup(rowIndex, 1, prevData.Folio);

    $('#Detalle_Antecedentes_FamiliaresEnfermedad').val(prevData.Enfermedad);
    $('#Detalle_Antecedentes_FamiliaresParentesco').val(prevData.Parentesco);

    initiateUIControls();




}

function Detalle_Antecedentes_FamiliaresAddInsertRow() {
    if (Detalle_Antecedentes_FamiliaresinsertRowCurrentIndex < 1)
    {
        Detalle_Antecedentes_FamiliaresinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Enfermedad: ""
        ,Parentesco: ""

    }
}

function Detalle_Antecedentes_FamiliaresfnClickAddRow() {
    Detalle_Antecedentes_FamiliarescountRowsChecked++;
    Detalle_Antecedentes_FamiliaresTable.fnAddData(Detalle_Antecedentes_FamiliaresAddInsertRow(), true);
    Detalle_Antecedentes_FamiliaresTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_Antecedentes_FamiliaresGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_Antecedentes_FamiliaresGrid tbody tr:nth-of-type(' + (Detalle_Antecedentes_FamiliaresinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Antecedentes_Familiares("Detalle_Antecedentes_Familiares_", "_" + Detalle_Antecedentes_FamiliaresinsertRowCurrentIndex);
}

function Detalle_Antecedentes_FamiliaresClearGridData() {
    Detalle_Antecedentes_FamiliaresData = [];
    Detalle_Antecedentes_FamiliaresdeletedItem = [];
    Detalle_Antecedentes_FamiliaresDataMain = [];
    Detalle_Antecedentes_FamiliaresDataMainPages = [];
    Detalle_Antecedentes_FamiliaresnewItemCount = 0;
    Detalle_Antecedentes_FamiliaresmaxItemIndex = 0;
    $("#Detalle_Antecedentes_FamiliaresGrid").DataTable().clear();
    $("#Detalle_Antecedentes_FamiliaresGrid").DataTable().destroy();
}

//Used to Get Pacientes Information
function GetDetalle_Antecedentes_Familiares() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Antecedentes_FamiliaresData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Antecedentes_FamiliaresData[i].Folio);

        form_data.append('[' + i + '].Enfermedad', Detalle_Antecedentes_FamiliaresData[i].Enfermedad);
        form_data.append('[' + i + '].Parentesco', Detalle_Antecedentes_FamiliaresData[i].Parentesco);

        form_data.append('[' + i + '].Removed', Detalle_Antecedentes_FamiliaresData[i].Removed);
    }
    return form_data;
}
function Detalle_Antecedentes_FamiliaresInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Antecedentes_Familiares("Detalle_Antecedentes_FamiliaresTable", rowIndex)) {
    var prevData = Detalle_Antecedentes_FamiliaresTable.fnGetData(rowIndex);
    var data = Detalle_Antecedentes_FamiliaresTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Enfermedad: $('#Detalle_Antecedentes_FamiliaresEnfermedad').val()
        ,Parentesco: $('#Detalle_Antecedentes_FamiliaresParentesco').val()

    }

    Detalle_Antecedentes_FamiliaresTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Antecedentes_FamiliaresrowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Antecedentes_Familiares-form').modal({ show: false });
    $('#AddDetalle_Antecedentes_Familiares-form').modal('hide');
    Detalle_Antecedentes_FamiliaresEditRow(rowIndex);
    Detalle_Antecedentes_FamiliaresInsertRow(rowIndex);
    //}
}
function Detalle_Antecedentes_FamiliaresRemoveAddRow(rowIndex) {
    Detalle_Antecedentes_FamiliaresTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Antecedentes_Familiares MultiRow
//Begin Declarations for Foreigns fields for Detalle_Antecedentes_No_Patologicos MultiRow
var Detalle_Antecedentes_No_PatologicoscountRowsChecked = 0;

function GetDetalle_Antecedentes_No_Patologicos_SustanciasName(Id) {
    for (var i = 0; i < Detalle_Antecedentes_No_Patologicos_SustanciasItems.length; i++) {
        if (Detalle_Antecedentes_No_Patologicos_SustanciasItems[i].Clave == Id) {
            return Detalle_Antecedentes_No_Patologicos_SustanciasItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Antecedentes_No_Patologicos_SustanciasDropDown() {
    var Detalle_Antecedentes_No_Patologicos_SustanciasDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Antecedentes_No_Patologicos_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Antecedentes_No_Patologicos_SustanciasDropdown);
    if(Detalle_Antecedentes_No_Patologicos_SustanciasItems != null)
    {
       for (var i = 0; i < Detalle_Antecedentes_No_Patologicos_SustanciasItems.length; i++) {
           $('<option />', { value: Detalle_Antecedentes_No_Patologicos_SustanciasItems[i].Clave, text:    Detalle_Antecedentes_No_Patologicos_SustanciasItems[i].Descripcion }).appendTo(Detalle_Antecedentes_No_Patologicos_SustanciasDropdown);
       }
    }
    return Detalle_Antecedentes_No_Patologicos_SustanciasDropdown;
}
function GetDetalle_Antecedentes_No_Patologicos_Frecuencia_SustanciasName(Id) {
    for (var i = 0; i < Detalle_Antecedentes_No_Patologicos_Frecuencia_SustanciasItems.length; i++) {
        if (Detalle_Antecedentes_No_Patologicos_Frecuencia_SustanciasItems[i].Clave == Id) {
            return Detalle_Antecedentes_No_Patologicos_Frecuencia_SustanciasItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Antecedentes_No_Patologicos_Frecuencia_SustanciasDropDown() {
    var Detalle_Antecedentes_No_Patologicos_Frecuencia_SustanciasDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Antecedentes_No_Patologicos_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Antecedentes_No_Patologicos_Frecuencia_SustanciasDropdown);
    if(Detalle_Antecedentes_No_Patologicos_Frecuencia_SustanciasItems != null)
    {
       for (var i = 0; i < Detalle_Antecedentes_No_Patologicos_Frecuencia_SustanciasItems.length; i++) {
           $('<option />', { value: Detalle_Antecedentes_No_Patologicos_Frecuencia_SustanciasItems[i].Clave, text:    Detalle_Antecedentes_No_Patologicos_Frecuencia_SustanciasItems[i].Descripcion }).appendTo(Detalle_Antecedentes_No_Patologicos_Frecuencia_SustanciasDropdown);
       }
    }
    return Detalle_Antecedentes_No_Patologicos_Frecuencia_SustanciasDropdown;
}



function GetInsertDetalle_Antecedentes_No_PatologicosRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $(GetDetalle_Antecedentes_No_Patologicos_SustanciasDropDown()).addClass('Detalle_Antecedentes_No_Patologicos_Sustancia Sustancia').attr('id', 'Detalle_Antecedentes_No_Patologicos_Sustancia_' + index).attr('data-field', 'Sustancia').after($.parseHTML(addNew('Detalle_Antecedentes_No_Patologicos', 'Sustancias', 'Sustancia', 257763)));
    columnData[1] = $(GetDetalle_Antecedentes_No_Patologicos_Frecuencia_SustanciasDropDown()).addClass('Detalle_Antecedentes_No_Patologicos_Frecuencia Frecuencia').attr('id', 'Detalle_Antecedentes_No_Patologicos_Frecuencia_' + index).attr('data-field', 'Frecuencia').after($.parseHTML(addNew('Detalle_Antecedentes_No_Patologicos', 'Frecuencia_Sustancias', 'Frecuencia', 257764)));
    columnData[2] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Antecedentes_No_Patologicos_Cantidad Cantidad').attr('id', 'Detalle_Antecedentes_No_Patologicos_Cantidad_' + index).attr('data-field', 'Cantidad');


    initiateUIControls();
    return columnData;
}

function Detalle_Antecedentes_No_PatologicosInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Antecedentes_No_Patologicos("Detalle_Antecedentes_No_Patologicos_", "_" + rowIndex)) {
    var iPage = Detalle_Antecedentes_No_PatologicosTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Antecedentes_No_Patologicos';
    var prevData = Detalle_Antecedentes_No_PatologicosTable.fnGetData(rowIndex);
    var data = Detalle_Antecedentes_No_PatologicosTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Sustancia:  data.childNodes[counter++].childNodes[0].value
        ,Frecuencia:  data.childNodes[counter++].childNodes[0].value
        ,Cantidad: data.childNodes[counter++].childNodes[0].value

    }
    Detalle_Antecedentes_No_PatologicosTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Antecedentes_No_PatologicosrowCreationGrid(data, newData, rowIndex);
    Detalle_Antecedentes_No_PatologicosTable.fnPageChange(iPage);
    Detalle_Antecedentes_No_PatologicoscountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Antecedentes_No_Patologicos("Detalle_Antecedentes_No_Patologicos_", "_" + rowIndex);
  }
}

function Detalle_Antecedentes_No_PatologicosCancelRow(rowIndex) {
    var prevData = Detalle_Antecedentes_No_PatologicosTable.fnGetData(rowIndex);
    var data = Detalle_Antecedentes_No_PatologicosTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Antecedentes_No_PatologicosTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Antecedentes_No_PatologicosrowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Antecedentes_No_PatologicosGrid(Detalle_Antecedentes_No_PatologicosTable.fnGetData());
    Detalle_Antecedentes_No_PatologicoscountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Antecedentes_No_PatologicosFromDataTable() {
    var Detalle_Antecedentes_No_PatologicosData = [];
    var gridData = Detalle_Antecedentes_No_PatologicosTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Antecedentes_No_PatologicosData.push({
                Folio: gridData[i].Folio

                ,Sustancia: gridData[i].Sustancia
                ,Frecuencia: gridData[i].Frecuencia
                ,Cantidad: gridData[i].Cantidad

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Antecedentes_No_PatologicosData.length; i++) {
        if (removedDetalle_Antecedentes_No_PatologicosData[i] != null && removedDetalle_Antecedentes_No_PatologicosData[i].Folio > 0)
            Detalle_Antecedentes_No_PatologicosData.push({
                Folio: removedDetalle_Antecedentes_No_PatologicosData[i].Folio

                ,Sustancia: removedDetalle_Antecedentes_No_PatologicosData[i].Sustancia
                ,Frecuencia: removedDetalle_Antecedentes_No_PatologicosData[i].Frecuencia
                ,Cantidad: removedDetalle_Antecedentes_No_PatologicosData[i].Cantidad

                , Removed: true
            });
    }	

    return Detalle_Antecedentes_No_PatologicosData;
}

function Detalle_Antecedentes_No_PatologicosEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Antecedentes_No_PatologicosTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Antecedentes_No_PatologicoscountRowsChecked++;
    var Detalle_Antecedentes_No_PatologicosRowElement = "Detalle_Antecedentes_No_Patologicos_" + rowIndex.toString();
    var prevData = Detalle_Antecedentes_No_PatologicosTable.fnGetData(rowIndexTable );
    var row = Detalle_Antecedentes_No_PatologicosTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Antecedentes_No_Patologicos_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Antecedentes_No_PatologicosGetUpdateRowControls(prevData, "Detalle_Antecedentes_No_Patologicos_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Antecedentes_No_PatologicosRowElement + "')){ Detalle_Antecedentes_No_PatologicosInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_Antecedentes_No_PatologicosCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Antecedentes_No_PatologicosGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Antecedentes_No_PatologicosGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_Antecedentes_No_PatologicosValidation();
    initiateUIControls();
    $('.Detalle_Antecedentes_No_Patologicos' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Antecedentes_No_Patologicos(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Antecedentes_No_PatologicosfnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Antecedentes_No_PatologicosTable.fnGetData().length;
    Detalle_Antecedentes_No_PatologicosfnClickAddRow();
    GetAddDetalle_Antecedentes_No_PatologicosPopup(currentRowIndex, 0);
}

function Detalle_Antecedentes_No_PatologicosEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Antecedentes_No_PatologicosTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Antecedentes_No_PatologicosRowElement = "Detalle_Antecedentes_No_Patologicos_" + rowIndex.toString();
    var prevData = Detalle_Antecedentes_No_PatologicosTable.fnGetData(rowIndexTable);
    GetAddDetalle_Antecedentes_No_PatologicosPopup(rowIndex, 1, prevData.Folio);

    $('#Detalle_Antecedentes_No_PatologicosSustancia').val(prevData.Sustancia);
    $('#Detalle_Antecedentes_No_PatologicosFrecuencia').val(prevData.Frecuencia);
    $('#Detalle_Antecedentes_No_PatologicosCantidad').val(prevData.Cantidad);

    initiateUIControls();





}

function Detalle_Antecedentes_No_PatologicosAddInsertRow() {
    if (Detalle_Antecedentes_No_PatologicosinsertRowCurrentIndex < 1)
    {
        Detalle_Antecedentes_No_PatologicosinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Sustancia: ""
        ,Frecuencia: ""
        ,Cantidad: ""

    }
}

function Detalle_Antecedentes_No_PatologicosfnClickAddRow() {
    Detalle_Antecedentes_No_PatologicoscountRowsChecked++;
    Detalle_Antecedentes_No_PatologicosTable.fnAddData(Detalle_Antecedentes_No_PatologicosAddInsertRow(), true);
    Detalle_Antecedentes_No_PatologicosTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_Antecedentes_No_PatologicosGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_Antecedentes_No_PatologicosGrid tbody tr:nth-of-type(' + (Detalle_Antecedentes_No_PatologicosinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Antecedentes_No_Patologicos("Detalle_Antecedentes_No_Patologicos_", "_" + Detalle_Antecedentes_No_PatologicosinsertRowCurrentIndex);
}

function Detalle_Antecedentes_No_PatologicosClearGridData() {
    Detalle_Antecedentes_No_PatologicosData = [];
    Detalle_Antecedentes_No_PatologicosdeletedItem = [];
    Detalle_Antecedentes_No_PatologicosDataMain = [];
    Detalle_Antecedentes_No_PatologicosDataMainPages = [];
    Detalle_Antecedentes_No_PatologicosnewItemCount = 0;
    Detalle_Antecedentes_No_PatologicosmaxItemIndex = 0;
    $("#Detalle_Antecedentes_No_PatologicosGrid").DataTable().clear();
    $("#Detalle_Antecedentes_No_PatologicosGrid").DataTable().destroy();
}

//Used to Get Pacientes Information
function GetDetalle_Antecedentes_No_Patologicos() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Antecedentes_No_PatologicosData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Antecedentes_No_PatologicosData[i].Folio);

        form_data.append('[' + i + '].Sustancia', Detalle_Antecedentes_No_PatologicosData[i].Sustancia);
        form_data.append('[' + i + '].Frecuencia', Detalle_Antecedentes_No_PatologicosData[i].Frecuencia);
        form_data.append('[' + i + '].Cantidad', Detalle_Antecedentes_No_PatologicosData[i].Cantidad);

        form_data.append('[' + i + '].Removed', Detalle_Antecedentes_No_PatologicosData[i].Removed);
    }
    return form_data;
}
function Detalle_Antecedentes_No_PatologicosInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Antecedentes_No_Patologicos("Detalle_Antecedentes_No_PatologicosTable", rowIndex)) {
    var prevData = Detalle_Antecedentes_No_PatologicosTable.fnGetData(rowIndex);
    var data = Detalle_Antecedentes_No_PatologicosTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Sustancia: $('#Detalle_Antecedentes_No_PatologicosSustancia').val()
        ,Frecuencia: $('#Detalle_Antecedentes_No_PatologicosFrecuencia').val()
        ,Cantidad: $('#Detalle_Antecedentes_No_PatologicosCantidad').val()


    }

    Detalle_Antecedentes_No_PatologicosTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Antecedentes_No_PatologicosrowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Antecedentes_No_Patologicos-form').modal({ show: false });
    $('#AddDetalle_Antecedentes_No_Patologicos-form').modal('hide');
    Detalle_Antecedentes_No_PatologicosEditRow(rowIndex);
    Detalle_Antecedentes_No_PatologicosInsertRow(rowIndex);
    //}
}
function Detalle_Antecedentes_No_PatologicosRemoveAddRow(rowIndex) {
    Detalle_Antecedentes_No_PatologicosTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Antecedentes_No_Patologicos MultiRow
//Begin Declarations for Foreigns fields for Detalle_Examenes_Laboratorio MultiRow
var Detalle_Examenes_LaboratoriocountRowsChecked = 0;

function GetDetalle_Examenes_Laboratorio_Indicadores_LaboratorioName(Id) {
    for (var i = 0; i < Detalle_Examenes_Laboratorio_Indicadores_LaboratorioItems.length; i++) {
        if (Detalle_Examenes_Laboratorio_Indicadores_LaboratorioItems[i].Folio == Id) {
            return Detalle_Examenes_Laboratorio_Indicadores_LaboratorioItems[i].Indicador;
        }
    }
    return "";
}

function GetDetalle_Examenes_Laboratorio_Indicadores_LaboratorioDropDown() {
    var Detalle_Examenes_Laboratorio_Indicadores_LaboratorioDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Examenes_Laboratorio_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Examenes_Laboratorio_Indicadores_LaboratorioDropdown);
    if(Detalle_Examenes_Laboratorio_Indicadores_LaboratorioItems != null)
    {
       for (var i = 0; i < Detalle_Examenes_Laboratorio_Indicadores_LaboratorioItems.length; i++) {
           $('<option />', { value: Detalle_Examenes_Laboratorio_Indicadores_LaboratorioItems[i].Folio, text:    Detalle_Examenes_Laboratorio_Indicadores_LaboratorioItems[i].Indicador }).appendTo(Detalle_Examenes_Laboratorio_Indicadores_LaboratorioDropdown);
       }
    }
    return Detalle_Examenes_Laboratorio_Indicadores_LaboratorioDropdown;
}







function GetInsertDetalle_Examenes_LaboratorioRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $(GetDetalle_Examenes_Laboratorio_Indicadores_LaboratorioDropDown()).addClass('Detalle_Examenes_Laboratorio_Indicador Indicador').attr('id', 'Detalle_Examenes_Laboratorio_Indicador_' + index).attr('data-field', 'Indicador').after($.parseHTML(addNew('Detalle_Examenes_Laboratorio', 'Indicadores_Laboratorio', 'Indicador', 257773)));
    columnData[1] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Examenes_Laboratorio_Resultado Resultado').attr('id', 'Detalle_Examenes_Laboratorio_Resultado_' + index).attr('data-field', 'Resultado');
    columnData[2] = $($.parseHTML(inputData)).addClass('Detalle_Examenes_Laboratorio_Unidad Unidad').attr('id', 'Detalle_Examenes_Laboratorio_Unidad_' + index).attr('data-field', 'Unidad');
    columnData[3] = $($.parseHTML(inputData)).addClass('Detalle_Examenes_Laboratorio_Intervalo_de_Referencia Intervalo_de_Referencia').attr('id', 'Detalle_Examenes_Laboratorio_Intervalo_de_Referencia_' + index).attr('data-field', 'Intervalo_de_Referencia');
    columnData[4] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Examenes_Laboratorio_Fecha_de_Resultado Fecha_de_Resultado').attr('id', 'Detalle_Examenes_Laboratorio_Fecha_de_Resultado_' + index).attr('data-field', 'Fecha_de_Resultado');
    columnData[5] = $($.parseHTML(inputData)).addClass('Detalle_Examenes_Laboratorio_Estatus_Indicador Estatus_Indicador').attr('id', 'Detalle_Examenes_Laboratorio_Estatus_Indicador_' + index).attr('data-field', 'Estatus_Indicador');


    initiateUIControls();
    return columnData;
}

function Detalle_Examenes_LaboratorioInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Examenes_Laboratorio("Detalle_Examenes_Laboratorio_", "_" + rowIndex)) {
    var iPage = Detalle_Examenes_LaboratorioTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Examenes_Laboratorio';
    var prevData = Detalle_Examenes_LaboratorioTable.fnGetData(rowIndex);
    var data = Detalle_Examenes_LaboratorioTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Indicador:  data.childNodes[counter++].childNodes[0].value
        ,Resultado: data.childNodes[counter++].childNodes[0].value
        ,Unidad:  data.childNodes[counter++].childNodes[0].value
        ,Intervalo_de_Referencia:  data.childNodes[counter++].childNodes[0].value
        ,Fecha_de_Resultado:  data.childNodes[counter++].childNodes[0].value
        ,Estatus_Indicador:  data.childNodes[counter++].childNodes[0].value

    }
    Detalle_Examenes_LaboratorioTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Examenes_LaboratoriorowCreationGrid(data, newData, rowIndex);
    Detalle_Examenes_LaboratorioTable.fnPageChange(iPage);
    Detalle_Examenes_LaboratoriocountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Examenes_Laboratorio("Detalle_Examenes_Laboratorio_", "_" + rowIndex);
  }
}

function Detalle_Examenes_LaboratorioCancelRow(rowIndex) {
    var prevData = Detalle_Examenes_LaboratorioTable.fnGetData(rowIndex);
    var data = Detalle_Examenes_LaboratorioTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Examenes_LaboratorioTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Examenes_LaboratoriorowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Examenes_LaboratorioGrid(Detalle_Examenes_LaboratorioTable.fnGetData());
    Detalle_Examenes_LaboratoriocountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Examenes_LaboratorioFromDataTable() {
    var Detalle_Examenes_LaboratorioData = [];
    var gridData = Detalle_Examenes_LaboratorioTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Examenes_LaboratorioData.push({
                Folio: gridData[i].Folio

                ,Indicador: gridData[i].Indicador
                ,Resultado: gridData[i].Resultado
                ,Unidad: gridData[i].Unidad
                ,Intervalo_de_Referencia: gridData[i].Intervalo_de_Referencia
                ,Fecha_de_Resultado: gridData[i].Fecha_de_Resultado
                ,Estatus_Indicador: gridData[i].Estatus_Indicador

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Examenes_LaboratorioData.length; i++) {
        if (removedDetalle_Examenes_LaboratorioData[i] != null && removedDetalle_Examenes_LaboratorioData[i].Folio > 0)
            Detalle_Examenes_LaboratorioData.push({
                Folio: removedDetalle_Examenes_LaboratorioData[i].Folio

                ,Indicador: removedDetalle_Examenes_LaboratorioData[i].Indicador
                ,Resultado: removedDetalle_Examenes_LaboratorioData[i].Resultado
                ,Unidad: removedDetalle_Examenes_LaboratorioData[i].Unidad
                ,Intervalo_de_Referencia: removedDetalle_Examenes_LaboratorioData[i].Intervalo_de_Referencia
                ,Fecha_de_Resultado: removedDetalle_Examenes_LaboratorioData[i].Fecha_de_Resultado
                ,Estatus_Indicador: removedDetalle_Examenes_LaboratorioData[i].Estatus_Indicador

                , Removed: true
            });
    }	

    return Detalle_Examenes_LaboratorioData;
}

function Detalle_Examenes_LaboratorioEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Examenes_LaboratorioTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Examenes_LaboratoriocountRowsChecked++;
    var Detalle_Examenes_LaboratorioRowElement = "Detalle_Examenes_Laboratorio_" + rowIndex.toString();
    var prevData = Detalle_Examenes_LaboratorioTable.fnGetData(rowIndexTable );
    var row = Detalle_Examenes_LaboratorioTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Examenes_Laboratorio_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Examenes_LaboratorioGetUpdateRowControls(prevData, "Detalle_Examenes_Laboratorio_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Examenes_LaboratorioRowElement + "')){ Detalle_Examenes_LaboratorioInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_Examenes_LaboratorioCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Examenes_LaboratorioGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Examenes_LaboratorioGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_Examenes_LaboratorioValidation();
    initiateUIControls();
    $('.Detalle_Examenes_Laboratorio' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Examenes_Laboratorio(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Examenes_LaboratoriofnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Examenes_LaboratorioTable.fnGetData().length;
    Detalle_Examenes_LaboratoriofnClickAddRow();
    GetAddDetalle_Examenes_LaboratorioPopup(currentRowIndex, 0);
}

function Detalle_Examenes_LaboratorioEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Examenes_LaboratorioTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Examenes_LaboratorioRowElement = "Detalle_Examenes_Laboratorio_" + rowIndex.toString();
    var prevData = Detalle_Examenes_LaboratorioTable.fnGetData(rowIndexTable);
    GetAddDetalle_Examenes_LaboratorioPopup(rowIndex, 1, prevData.Folio);

    $('#Detalle_Examenes_LaboratorioIndicador').val(prevData.Indicador);
    $('#Detalle_Examenes_LaboratorioResultado').val(prevData.Resultado);
    $('#Detalle_Examenes_LaboratorioUnidad').val(prevData.Unidad);
    $('#Detalle_Examenes_LaboratorioIntervalo_de_Referencia').val(prevData.Intervalo_de_Referencia);
    $('#Detalle_Examenes_LaboratorioFecha_de_Resultado').val(prevData.Fecha_de_Resultado);
    $('#Detalle_Examenes_LaboratorioEstatus_Indicador').val(prevData.Estatus_Indicador);

    initiateUIControls();








}

function Detalle_Examenes_LaboratorioAddInsertRow() {
    if (Detalle_Examenes_LaboratorioinsertRowCurrentIndex < 1)
    {
        Detalle_Examenes_LaboratorioinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Indicador: ""
        ,Resultado: ""
        ,Unidad: ""
        ,Intervalo_de_Referencia: ""
        ,Fecha_de_Resultado: ""
        ,Estatus_Indicador: ""

    }
}

function Detalle_Examenes_LaboratoriofnClickAddRow() {
    Detalle_Examenes_LaboratoriocountRowsChecked++;
    Detalle_Examenes_LaboratorioTable.fnAddData(Detalle_Examenes_LaboratorioAddInsertRow(), true);
    Detalle_Examenes_LaboratorioTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_Examenes_LaboratorioGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_Examenes_LaboratorioGrid tbody tr:nth-of-type(' + (Detalle_Examenes_LaboratorioinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Examenes_Laboratorio("Detalle_Examenes_Laboratorio_", "_" + Detalle_Examenes_LaboratorioinsertRowCurrentIndex);
}

function Detalle_Examenes_LaboratorioClearGridData() {
    Detalle_Examenes_LaboratorioData = [];
    Detalle_Examenes_LaboratoriodeletedItem = [];
    Detalle_Examenes_LaboratorioDataMain = [];
    Detalle_Examenes_LaboratorioDataMainPages = [];
    Detalle_Examenes_LaboratorionewItemCount = 0;
    Detalle_Examenes_LaboratoriomaxItemIndex = 0;
    $("#Detalle_Examenes_LaboratorioGrid").DataTable().clear();
    $("#Detalle_Examenes_LaboratorioGrid").DataTable().destroy();
}

//Used to Get Pacientes Information
function GetDetalle_Examenes_Laboratorio() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Examenes_LaboratorioData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Examenes_LaboratorioData[i].Folio);

        form_data.append('[' + i + '].Indicador', Detalle_Examenes_LaboratorioData[i].Indicador);
        form_data.append('[' + i + '].Resultado', Detalle_Examenes_LaboratorioData[i].Resultado);
        form_data.append('[' + i + '].Unidad', Detalle_Examenes_LaboratorioData[i].Unidad);
        form_data.append('[' + i + '].Intervalo_de_Referencia', Detalle_Examenes_LaboratorioData[i].Intervalo_de_Referencia);
        form_data.append('[' + i + '].Fecha_de_Resultado', Detalle_Examenes_LaboratorioData[i].Fecha_de_Resultado);
        form_data.append('[' + i + '].Estatus_Indicador', Detalle_Examenes_LaboratorioData[i].Estatus_Indicador);

        form_data.append('[' + i + '].Removed', Detalle_Examenes_LaboratorioData[i].Removed);
    }
    return form_data;
}
function Detalle_Examenes_LaboratorioInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Examenes_Laboratorio("Detalle_Examenes_LaboratorioTable", rowIndex)) {
    var prevData = Detalle_Examenes_LaboratorioTable.fnGetData(rowIndex);
    var data = Detalle_Examenes_LaboratorioTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Indicador: $('#Detalle_Examenes_LaboratorioIndicador').val()
        ,Resultado: $('#Detalle_Examenes_LaboratorioResultado').val()

        ,Unidad: $('#Detalle_Examenes_LaboratorioUnidad').val()
        ,Intervalo_de_Referencia: $('#Detalle_Examenes_LaboratorioIntervalo_de_Referencia').val()
        ,Fecha_de_Resultado: $('#Detalle_Examenes_LaboratorioFecha_de_Resultado').val()
        ,Estatus_Indicador: $('#Detalle_Examenes_LaboratorioEstatus_Indicador').val()

    }

    Detalle_Examenes_LaboratorioTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Examenes_LaboratoriorowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Examenes_Laboratorio-form').modal({ show: false });
    $('#AddDetalle_Examenes_Laboratorio-form').modal('hide');
    Detalle_Examenes_LaboratorioEditRow(rowIndex);
    Detalle_Examenes_LaboratorioInsertRow(rowIndex);
    //}
}
function Detalle_Examenes_LaboratorioRemoveAddRow(rowIndex) {
    Detalle_Examenes_LaboratorioTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Examenes_Laboratorio MultiRow
//Begin Declarations for Foreigns fields for Detalle_Terapia_Hormonal MultiRow
var Detalle_Terapia_HormonalcountRowsChecked = 0;





function GetInsertDetalle_Terapia_HormonalRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $($.parseHTML(inputData)).addClass('Detalle_Terapia_Hormonal_Nombre Nombre').attr('id', 'Detalle_Terapia_Hormonal_Nombre_' + index).attr('data-field', 'Nombre');
    columnData[1] = $($.parseHTML(inputData)).addClass('Detalle_Terapia_Hormonal_Dosis Dosis').attr('id', 'Detalle_Terapia_Hormonal_Dosis_' + index).attr('data-field', 'Dosis');


    initiateUIControls();
    return columnData;
}

function Detalle_Terapia_HormonalInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Terapia_Hormonal("Detalle_Terapia_Hormonal_", "_" + rowIndex)) {
    var iPage = Detalle_Terapia_HormonalTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Terapia_Hormonal';
    var prevData = Detalle_Terapia_HormonalTable.fnGetData(rowIndex);
    var data = Detalle_Terapia_HormonalTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Nombre:  data.childNodes[counter++].childNodes[0].value
        ,Dosis:  data.childNodes[counter++].childNodes[0].value

    }
    Detalle_Terapia_HormonalTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Terapia_HormonalrowCreationGrid(data, newData, rowIndex);
    Detalle_Terapia_HormonalTable.fnPageChange(iPage);
    Detalle_Terapia_HormonalcountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Terapia_Hormonal("Detalle_Terapia_Hormonal_", "_" + rowIndex);
  }
}

function Detalle_Terapia_HormonalCancelRow(rowIndex) {
    var prevData = Detalle_Terapia_HormonalTable.fnGetData(rowIndex);
    var data = Detalle_Terapia_HormonalTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Terapia_HormonalTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Terapia_HormonalrowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Terapia_HormonalGrid(Detalle_Terapia_HormonalTable.fnGetData());
    Detalle_Terapia_HormonalcountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Terapia_HormonalFromDataTable() {
    var Detalle_Terapia_HormonalData = [];
    var gridData = Detalle_Terapia_HormonalTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Terapia_HormonalData.push({
                Folio: gridData[i].Folio

                ,Nombre: gridData[i].Nombre
                ,Dosis: gridData[i].Dosis

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Terapia_HormonalData.length; i++) {
        if (removedDetalle_Terapia_HormonalData[i] != null && removedDetalle_Terapia_HormonalData[i].Folio > 0)
            Detalle_Terapia_HormonalData.push({
                Folio: removedDetalle_Terapia_HormonalData[i].Folio

                ,Nombre: removedDetalle_Terapia_HormonalData[i].Nombre
                ,Dosis: removedDetalle_Terapia_HormonalData[i].Dosis

                , Removed: true
            });
    }	

    return Detalle_Terapia_HormonalData;
}

function Detalle_Terapia_HormonalEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Terapia_HormonalTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Terapia_HormonalcountRowsChecked++;
    var Detalle_Terapia_HormonalRowElement = "Detalle_Terapia_Hormonal_" + rowIndex.toString();
    var prevData = Detalle_Terapia_HormonalTable.fnGetData(rowIndexTable );
    var row = Detalle_Terapia_HormonalTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Terapia_Hormonal_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Terapia_HormonalGetUpdateRowControls(prevData, "Detalle_Terapia_Hormonal_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Terapia_HormonalRowElement + "')){ Detalle_Terapia_HormonalInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_Terapia_HormonalCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Terapia_HormonalGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Terapia_HormonalGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_Terapia_HormonalValidation();
    initiateUIControls();
    $('.Detalle_Terapia_Hormonal' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Terapia_Hormonal(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Terapia_HormonalfnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Terapia_HormonalTable.fnGetData().length;
    Detalle_Terapia_HormonalfnClickAddRow();
    GetAddDetalle_Terapia_HormonalPopup(currentRowIndex, 0);
}

function Detalle_Terapia_HormonalEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Terapia_HormonalTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Terapia_HormonalRowElement = "Detalle_Terapia_Hormonal_" + rowIndex.toString();
    var prevData = Detalle_Terapia_HormonalTable.fnGetData(rowIndexTable);
    GetAddDetalle_Terapia_HormonalPopup(rowIndex, 1, prevData.Folio);

    $('#Detalle_Terapia_HormonalNombre').val(prevData.Nombre);
    $('#Detalle_Terapia_HormonalDosis').val(prevData.Dosis);

    initiateUIControls();




}

function Detalle_Terapia_HormonalAddInsertRow() {
    if (Detalle_Terapia_HormonalinsertRowCurrentIndex < 1)
    {
        Detalle_Terapia_HormonalinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Nombre: ""
        ,Dosis: ""

    }
}

function Detalle_Terapia_HormonalfnClickAddRow() {
    Detalle_Terapia_HormonalcountRowsChecked++;
    Detalle_Terapia_HormonalTable.fnAddData(Detalle_Terapia_HormonalAddInsertRow(), true);
    Detalle_Terapia_HormonalTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_Terapia_HormonalGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_Terapia_HormonalGrid tbody tr:nth-of-type(' + (Detalle_Terapia_HormonalinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Terapia_Hormonal("Detalle_Terapia_Hormonal_", "_" + Detalle_Terapia_HormonalinsertRowCurrentIndex);
}

function Detalle_Terapia_HormonalClearGridData() {
    Detalle_Terapia_HormonalData = [];
    Detalle_Terapia_HormonaldeletedItem = [];
    Detalle_Terapia_HormonalDataMain = [];
    Detalle_Terapia_HormonalDataMainPages = [];
    Detalle_Terapia_HormonalnewItemCount = 0;
    Detalle_Terapia_HormonalmaxItemIndex = 0;
    $("#Detalle_Terapia_HormonalGrid").DataTable().clear();
    $("#Detalle_Terapia_HormonalGrid").DataTable().destroy();
}

//Used to Get Pacientes Information
function GetDetalle_Terapia_Hormonal() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Terapia_HormonalData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Terapia_HormonalData[i].Folio);

        form_data.append('[' + i + '].Nombre', Detalle_Terapia_HormonalData[i].Nombre);
        form_data.append('[' + i + '].Dosis', Detalle_Terapia_HormonalData[i].Dosis);

        form_data.append('[' + i + '].Removed', Detalle_Terapia_HormonalData[i].Removed);
    }
    return form_data;
}
function Detalle_Terapia_HormonalInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Terapia_Hormonal("Detalle_Terapia_HormonalTable", rowIndex)) {
    var prevData = Detalle_Terapia_HormonalTable.fnGetData(rowIndex);
    var data = Detalle_Terapia_HormonalTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Nombre: $('#Detalle_Terapia_HormonalNombre').val()
        ,Dosis: $('#Detalle_Terapia_HormonalDosis').val()

    }

    Detalle_Terapia_HormonalTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Terapia_HormonalrowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Terapia_Hormonal-form').modal({ show: false });
    $('#AddDetalle_Terapia_Hormonal-form').modal('hide');
    Detalle_Terapia_HormonalEditRow(rowIndex);
    Detalle_Terapia_HormonalInsertRow(rowIndex);
    //}
}
function Detalle_Terapia_HormonalRemoveAddRow(rowIndex) {
    Detalle_Terapia_HormonalTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Terapia_Hormonal MultiRow
var MS_Exclusion_Ingredientes_PacientecountRowsChecked = 0;
function GetMS_Exclusion_Ingredientes_PacienteFromDataTable() {
    var MS_Exclusion_Ingredientes_PacienteData = [];
    debugger;

    var items = $("#ddlAlergiasMult").chosen().val();
    //es nuevo 
    if (MS_Exclusion_Ingredientes_PacienteDataDataTable == undefined || MS_Exclusion_Ingredientes_PacienteDataDataTable.length == 0) {
        if (items!= null && items.length > 0) {
            for (var i = 0; i < items.length; i++) {
                MS_Exclusion_Ingredientes_PacienteData.push({ 
                      Folio: 0
                      
, Ingrediente: items[i]

                      ,Removed: false
                });
            }
        }
    }
    else // esta editando 
    {
        // se borran los que ya no estan 
        for (var i = 0; i < MS_Exclusion_Ingredientes_PacienteDataDataTable.length; i++)
        {
            var borrar = true;
            if (items != null) {
                if (items.length > 0) {
                    for (var j = 0; j < items.length; j++) {
                        if (MS_Exclusion_Ingredientes_PacienteDataDataTable[i].Folio == items[j]) {
                            borrar = false;
                        }
                    }
                }
            }
            
                if (borrar) {
                    MS_Exclusion_Ingredientes_PacienteData.push({
                        Folio: MS_Exclusion_Ingredientes_PacienteDataDataTable[i].Folio
                        
                   , Ingrediente: MS_Exclusion_Ingredientes_PacienteDataDataTable[i].Ingrediente

                        , Removed: true
                    });
                }
        }

        if (items != null)
        {
            if (items.length > 0) {
                // Se agregan los nuevoss 
                for (var i = 0; i < items.length; i++) {
                    var existe = false;
                    for (var j = 0; j < MS_Exclusion_Ingredientes_PacienteDataDataTable.length; j++) {
                        if (items[i] == MS_Exclusion_Ingredientes_PacienteDataDataTable[j].Folio) {
                            existe = true;
                        }
                    }
                    if (!existe) {
                        MS_Exclusion_Ingredientes_PacienteData.push({ 
                              Folio: 0
                              
, Ingrediente: items[i]
 
                        });
                    }
                }
            }
        }
       
        
    }

    return MS_Exclusion_Ingredientes_PacienteData;
}

//Used to Get Pacientes Information
function GetMS_Exclusion_Ingredientes_Paciente() {
    var form_data = new FormData();
    for (var i = 0; i < MS_Exclusion_Ingredientes_PacienteData.length; i++) {
       form_data.append('[' + i + '].Folio', MS_Exclusion_Ingredientes_PacienteData[i].Folio);
       
      form_data.append('[' + i +'].Ingrediente',MS_Exclusion_Ingredientes_PacienteData[i].Ingrediente);


       form_data.append('[' + i + '].Removed', MS_Exclusion_Ingredientes_PacienteData[i].Removed);
    }
    return form_data;
}

//Begin Declarations for Foreigns fields for Detalle_Preferencia_Bebidas MultiRow
var Detalle_Preferencia_BebidascountRowsChecked = 0;

function GetDetalle_Preferencia_Bebidas_BebidasName(Id) {
    for (var i = 0; i < Detalle_Preferencia_Bebidas_BebidasItems.length; i++) {
        if (Detalle_Preferencia_Bebidas_BebidasItems[i].Clave == Id) {
            return Detalle_Preferencia_Bebidas_BebidasItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Preferencia_Bebidas_BebidasDropDown() {
    var Detalle_Preferencia_Bebidas_BebidasDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Preferencia_Bebidas_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Preferencia_Bebidas_BebidasDropdown);
    if(Detalle_Preferencia_Bebidas_BebidasItems != null)
    {
       for (var i = 0; i < Detalle_Preferencia_Bebidas_BebidasItems.length; i++) {
           $('<option />', { value: Detalle_Preferencia_Bebidas_BebidasItems[i].Clave, text:    Detalle_Preferencia_Bebidas_BebidasItems[i].Descripcion }).appendTo(Detalle_Preferencia_Bebidas_BebidasDropdown);
       }
    }
    return Detalle_Preferencia_Bebidas_BebidasDropdown;
}
function GetDetalle_Preferencia_Bebidas_Rango_Consumo_BebidasName(Id) {
    for (var i = 0; i < Detalle_Preferencia_Bebidas_Rango_Consumo_BebidasItems.length; i++) {
        if (Detalle_Preferencia_Bebidas_Rango_Consumo_BebidasItems[i].Clave == Id) {
            return Detalle_Preferencia_Bebidas_Rango_Consumo_BebidasItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Preferencia_Bebidas_Rango_Consumo_BebidasDropDown() {
    var Detalle_Preferencia_Bebidas_Rango_Consumo_BebidasDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Preferencia_Bebidas_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Preferencia_Bebidas_Rango_Consumo_BebidasDropdown);
    if(Detalle_Preferencia_Bebidas_Rango_Consumo_BebidasItems != null)
    {
       for (var i = 0; i < Detalle_Preferencia_Bebidas_Rango_Consumo_BebidasItems.length; i++) {
           $('<option />', { value: Detalle_Preferencia_Bebidas_Rango_Consumo_BebidasItems[i].Clave, text:    Detalle_Preferencia_Bebidas_Rango_Consumo_BebidasItems[i].Descripcion }).appendTo(Detalle_Preferencia_Bebidas_Rango_Consumo_BebidasDropdown);
       }
    }
    return Detalle_Preferencia_Bebidas_Rango_Consumo_BebidasDropdown;
}


function GetInsertDetalle_Preferencia_BebidasRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $(GetDetalle_Preferencia_Bebidas_BebidasDropDown()).addClass('Detalle_Preferencia_Bebidas_Bebida Bebida').attr('id', 'Detalle_Preferencia_Bebidas_Bebida_' + index).attr('data-field', 'Bebida').after($.parseHTML(addNew('Detalle_Preferencia_Bebidas', 'Bebidas', 'Bebida', 257698)));
    columnData[1] = $(GetDetalle_Preferencia_Bebidas_Rango_Consumo_BebidasDropDown()).addClass('Detalle_Preferencia_Bebidas_Cantidad Cantidad').attr('id', 'Detalle_Preferencia_Bebidas_Cantidad_' + index).attr('data-field', 'Cantidad').after($.parseHTML(addNew('Detalle_Preferencia_Bebidas', 'Rango_Consumo_Bebidas', 'Cantidad', 257699)));


    initiateUIControls();
    return columnData;
}

function Detalle_Preferencia_BebidasInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Preferencia_Bebidas("Detalle_Preferencia_Bebidas_", "_" + rowIndex)) {
    var iPage = Detalle_Preferencia_BebidasTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Preferencia_Bebidas';
    var prevData = Detalle_Preferencia_BebidasTable.fnGetData(rowIndex);
    var data = Detalle_Preferencia_BebidasTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Bebida:  data.childNodes[counter++].childNodes[0].value
        ,Cantidad:  data.childNodes[counter++].childNodes[0].value

    }
    Detalle_Preferencia_BebidasTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Preferencia_BebidasrowCreationGrid(data, newData, rowIndex);
    Detalle_Preferencia_BebidasTable.fnPageChange(iPage);
    Detalle_Preferencia_BebidascountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Preferencia_Bebidas("Detalle_Preferencia_Bebidas_", "_" + rowIndex);
  }
}

function Detalle_Preferencia_BebidasCancelRow(rowIndex) {
    var prevData = Detalle_Preferencia_BebidasTable.fnGetData(rowIndex);
    var data = Detalle_Preferencia_BebidasTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Preferencia_BebidasTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Preferencia_BebidasrowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Preferencia_BebidasGrid(Detalle_Preferencia_BebidasTable.fnGetData());
    Detalle_Preferencia_BebidascountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Preferencia_BebidasFromDataTable() {
    var Detalle_Preferencia_BebidasData = [];
    var gridData = Detalle_Preferencia_BebidasTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Preferencia_BebidasData.push({
                Folio: gridData[i].Folio

                ,Bebida: gridData[i].Bebida
                ,Cantidad: gridData[i].Cantidad

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Preferencia_BebidasData.length; i++) {
        if (removedDetalle_Preferencia_BebidasData[i] != null && removedDetalle_Preferencia_BebidasData[i].Folio > 0)
            Detalle_Preferencia_BebidasData.push({
                Folio: removedDetalle_Preferencia_BebidasData[i].Folio

                ,Bebida: removedDetalle_Preferencia_BebidasData[i].Bebida
                ,Cantidad: removedDetalle_Preferencia_BebidasData[i].Cantidad

                , Removed: true
            });
    }	

    return Detalle_Preferencia_BebidasData;
}

function Detalle_Preferencia_BebidasEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Preferencia_BebidasTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Preferencia_BebidascountRowsChecked++;
    var Detalle_Preferencia_BebidasRowElement = "Detalle_Preferencia_Bebidas_" + rowIndex.toString();
    var prevData = Detalle_Preferencia_BebidasTable.fnGetData(rowIndexTable );
    var row = Detalle_Preferencia_BebidasTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Preferencia_Bebidas_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Preferencia_BebidasGetUpdateRowControls(prevData, "Detalle_Preferencia_Bebidas_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Preferencia_BebidasRowElement + "')){ Detalle_Preferencia_BebidasInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_Preferencia_BebidasCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Preferencia_BebidasGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Preferencia_BebidasGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_Preferencia_BebidasValidation();
    initiateUIControls();
    $('.Detalle_Preferencia_Bebidas' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Preferencia_Bebidas(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Preferencia_BebidasfnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Preferencia_BebidasTable.fnGetData().length;
    Detalle_Preferencia_BebidasfnClickAddRow();
    GetAddDetalle_Preferencia_BebidasPopup(currentRowIndex, 0);
}

function Detalle_Preferencia_BebidasEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Preferencia_BebidasTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Preferencia_BebidasRowElement = "Detalle_Preferencia_Bebidas_" + rowIndex.toString();
    var prevData = Detalle_Preferencia_BebidasTable.fnGetData(rowIndexTable);
    GetAddDetalle_Preferencia_BebidasPopup(rowIndex, 1, prevData.Folio);

    $('#Detalle_Preferencia_BebidasBebida').val(prevData.Bebida);
    $('#Detalle_Preferencia_BebidasCantidad').val(prevData.Cantidad);

    initiateUIControls();




}

function Detalle_Preferencia_BebidasAddInsertRow() {
    if (Detalle_Preferencia_BebidasinsertRowCurrentIndex < 1)
    {
        Detalle_Preferencia_BebidasinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Bebida: ""
        ,Cantidad: ""

    }
}

function Detalle_Preferencia_BebidasfnClickAddRow() {
    Detalle_Preferencia_BebidascountRowsChecked++;
    Detalle_Preferencia_BebidasTable.fnAddData(Detalle_Preferencia_BebidasAddInsertRow(), true);
    Detalle_Preferencia_BebidasTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_Preferencia_BebidasGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_Preferencia_BebidasGrid tbody tr:nth-of-type(' + (Detalle_Preferencia_BebidasinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Preferencia_Bebidas("Detalle_Preferencia_Bebidas_", "_" + Detalle_Preferencia_BebidasinsertRowCurrentIndex);
}

function Detalle_Preferencia_BebidasClearGridData() {
    Detalle_Preferencia_BebidasData = [];
    Detalle_Preferencia_BebidasdeletedItem = [];
    Detalle_Preferencia_BebidasDataMain = [];
    Detalle_Preferencia_BebidasDataMainPages = [];
    Detalle_Preferencia_BebidasnewItemCount = 0;
    Detalle_Preferencia_BebidasmaxItemIndex = 0;
    $("#Detalle_Preferencia_BebidasGrid").DataTable().clear();
    $("#Detalle_Preferencia_BebidasGrid").DataTable().destroy();
}

//Used to Get Pacientes Information
function GetDetalle_Preferencia_Bebidas() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Preferencia_BebidasData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Preferencia_BebidasData[i].Folio);

        form_data.append('[' + i + '].Bebida', Detalle_Preferencia_BebidasData[i].Bebida);
        form_data.append('[' + i + '].Cantidad', Detalle_Preferencia_BebidasData[i].Cantidad);

        form_data.append('[' + i + '].Removed', Detalle_Preferencia_BebidasData[i].Removed);
    }
    return form_data;
}
function Detalle_Preferencia_BebidasInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Preferencia_Bebidas("Detalle_Preferencia_BebidasTable", rowIndex)) {
    var prevData = Detalle_Preferencia_BebidasTable.fnGetData(rowIndex);
    var data = Detalle_Preferencia_BebidasTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Bebida: $('#Detalle_Preferencia_BebidasBebida').val()
        ,Cantidad: $('#Detalle_Preferencia_BebidasCantidad').val()

    }

    Detalle_Preferencia_BebidasTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Preferencia_BebidasrowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Preferencia_Bebidas-form').modal({ show: false });
    $('#AddDetalle_Preferencia_Bebidas-form').modal('hide');
    Detalle_Preferencia_BebidasEditRow(rowIndex);
    Detalle_Preferencia_BebidasInsertRow(rowIndex);
    //}
}
function Detalle_Preferencia_BebidasRemoveAddRow(rowIndex) {
    Detalle_Preferencia_BebidasTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Preferencia_Bebidas MultiRow
//Begin Declarations for Foreigns fields for Detalle_Pagos_Paciente MultiRow
var Detalle_Pagos_PacientecountRowsChecked = 0;

function GetDetalle_Pagos_Paciente_Planes_de_SuscripcionName(Id) {
    for (var i = 0; i < Detalle_Pagos_Paciente_Planes_de_SuscripcionItems.length; i++) {
        if (Detalle_Pagos_Paciente_Planes_de_SuscripcionItems[i].Folio == Id) {
            return Detalle_Pagos_Paciente_Planes_de_SuscripcionItems[i].Nombre_del_Plan;
        }
    }
    return "";
}

function GetDetalle_Pagos_Paciente_Planes_de_SuscripcionDropDown() {
    var Detalle_Pagos_Paciente_Planes_de_SuscripcionDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Pagos_Paciente_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Pagos_Paciente_Planes_de_SuscripcionDropdown);
    if(Detalle_Pagos_Paciente_Planes_de_SuscripcionItems != null)
    {
       for (var i = 0; i < Detalle_Pagos_Paciente_Planes_de_SuscripcionItems.length; i++) {
           $('<option />', { value: Detalle_Pagos_Paciente_Planes_de_SuscripcionItems[i].Folio, text:    Detalle_Pagos_Paciente_Planes_de_SuscripcionItems[i].Nombre_del_Plan }).appendTo(Detalle_Pagos_Paciente_Planes_de_SuscripcionDropdown);
       }
    }
    return Detalle_Pagos_Paciente_Planes_de_SuscripcionDropdown;
}


function GetDetalle_Pagos_Paciente_Formas_de_PagoName(Id) {
    for (var i = 0; i < Detalle_Pagos_Paciente_Formas_de_PagoItems.length; i++) {
        if (Detalle_Pagos_Paciente_Formas_de_PagoItems[i].Clave == Id) {
            return Detalle_Pagos_Paciente_Formas_de_PagoItems[i].Nombre;
        }
    }
    return "";
}

function GetDetalle_Pagos_Paciente_Formas_de_PagoDropDown() {
    var Detalle_Pagos_Paciente_Formas_de_PagoDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Pagos_Paciente_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Pagos_Paciente_Formas_de_PagoDropdown);
    if(Detalle_Pagos_Paciente_Formas_de_PagoItems != null)
    {
       for (var i = 0; i < Detalle_Pagos_Paciente_Formas_de_PagoItems.length; i++) {
           $('<option />', { value: Detalle_Pagos_Paciente_Formas_de_PagoItems[i].Clave, text:    Detalle_Pagos_Paciente_Formas_de_PagoItems[i].Nombre }).appendTo(Detalle_Pagos_Paciente_Formas_de_PagoDropdown);
       }
    }
    return Detalle_Pagos_Paciente_Formas_de_PagoDropdown;
}

function GetDetalle_Pagos_Paciente_Estatus_de_PagoName(Id) {
    for (var i = 0; i < Detalle_Pagos_Paciente_Estatus_de_PagoItems.length; i++) {
        if (Detalle_Pagos_Paciente_Estatus_de_PagoItems[i].Clave == Id) {
            return Detalle_Pagos_Paciente_Estatus_de_PagoItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Pagos_Paciente_Estatus_de_PagoDropDown() {
    var Detalle_Pagos_Paciente_Estatus_de_PagoDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Pagos_Paciente_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Pagos_Paciente_Estatus_de_PagoDropdown);
    if(Detalle_Pagos_Paciente_Estatus_de_PagoItems != null)
    {
       for (var i = 0; i < Detalle_Pagos_Paciente_Estatus_de_PagoItems.length; i++) {
           $('<option />', { value: Detalle_Pagos_Paciente_Estatus_de_PagoItems[i].Clave, text:    Detalle_Pagos_Paciente_Estatus_de_PagoItems[i].Descripcion }).appendTo(Detalle_Pagos_Paciente_Estatus_de_PagoDropdown);
       }
    }
    return Detalle_Pagos_Paciente_Estatus_de_PagoDropdown;
}


function GetInsertDetalle_Pagos_PacienteRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $(GetDetalle_Pagos_Paciente_Planes_de_SuscripcionDropDown()).addClass('Detalle_Pagos_Paciente_Suscripcion Suscripcion').attr('id', 'Detalle_Pagos_Paciente_Suscripcion_' + index).attr('data-field', 'Suscripcion').after($.parseHTML(addNew('Detalle_Pagos_Paciente', 'Planes_de_Suscripcion', 'Suscripcion', 258420)));
    columnData[1] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Pagos_Paciente_Fecha_de_Suscripcion Fecha_de_Suscripcion').attr('id', 'Detalle_Pagos_Paciente_Fecha_de_Suscripcion_' + index).attr('data-field', 'Fecha_de_Suscripcion');
    columnData[2] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Pagos_Paciente_Fecha_Limite_de_Pago Fecha_Limite_de_Pago').attr('id', 'Detalle_Pagos_Paciente_Fecha_Limite_de_Pago_' + index).attr('data-field', 'Fecha_Limite_de_Pago');
    columnData[3] = $(GetDetalle_Pagos_Paciente_Formas_de_PagoDropDown()).addClass('Detalle_Pagos_Paciente_Forma_de_Pago Forma_de_Pago').attr('id', 'Detalle_Pagos_Paciente_Forma_de_Pago_' + index).attr('data-field', 'Forma_de_Pago').after($.parseHTML(addNew('Detalle_Pagos_Paciente', 'Formas_de_Pago', 'Forma_de_Pago', 258424)));
    columnData[4] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Pagos_Paciente_Fecha_de_Pago Fecha_de_Pago').attr('id', 'Detalle_Pagos_Paciente_Fecha_de_Pago_' + index).attr('data-field', 'Fecha_de_Pago');
    columnData[5] = $(GetDetalle_Pagos_Paciente_Estatus_de_PagoDropDown()).addClass('Detalle_Pagos_Paciente_Estatus Estatus').attr('id', 'Detalle_Pagos_Paciente_Estatus_' + index).attr('data-field', 'Estatus').after($.parseHTML(addNew('Detalle_Pagos_Paciente', 'Estatus_de_Pago', 'Estatus', 258426)));


    initiateUIControls();
    return columnData;
}

function Detalle_Pagos_PacienteInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Pagos_Paciente("Detalle_Pagos_Paciente_", "_" + rowIndex)) {
    var iPage = Detalle_Pagos_PacienteTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Pagos_Paciente';
    var prevData = Detalle_Pagos_PacienteTable.fnGetData(rowIndex);
    var data = Detalle_Pagos_PacienteTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Suscripcion:  data.childNodes[counter++].childNodes[0].value
        ,Fecha_de_Suscripcion:  data.childNodes[counter++].childNodes[0].value
        ,Fecha_Limite_de_Pago:  data.childNodes[counter++].childNodes[0].value
        ,Forma_de_Pago:  data.childNodes[counter++].childNodes[0].value
        ,Fecha_de_Pago:  data.childNodes[counter++].childNodes[0].value
        ,Estatus:  data.childNodes[counter++].childNodes[0].value

    }
    Detalle_Pagos_PacienteTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Pagos_PacienterowCreationGrid(data, newData, rowIndex);
    Detalle_Pagos_PacienteTable.fnPageChange(iPage);
    Detalle_Pagos_PacientecountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Pagos_Paciente("Detalle_Pagos_Paciente_", "_" + rowIndex);
  }
}

function Detalle_Pagos_PacienteCancelRow(rowIndex) {
    var prevData = Detalle_Pagos_PacienteTable.fnGetData(rowIndex);
    var data = Detalle_Pagos_PacienteTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Pagos_PacienteTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Pagos_PacienterowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Pagos_PacienteGrid(Detalle_Pagos_PacienteTable.fnGetData());
    Detalle_Pagos_PacientecountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Pagos_PacienteFromDataTable() {
    var Detalle_Pagos_PacienteData = [];
    var gridData = Detalle_Pagos_PacienteTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Pagos_PacienteData.push({
                Folio: gridData[i].Folio

                ,Suscripcion: gridData[i].Suscripcion
                ,Fecha_de_Suscripcion: gridData[i].Fecha_de_Suscripcion
                ,Fecha_Limite_de_Pago: gridData[i].Fecha_Limite_de_Pago
                ,Forma_de_Pago: gridData[i].Forma_de_Pago
                ,Fecha_de_Pago: gridData[i].Fecha_de_Pago
                ,Estatus: gridData[i].Estatus

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Pagos_PacienteData.length; i++) {
        if (removedDetalle_Pagos_PacienteData[i] != null && removedDetalle_Pagos_PacienteData[i].Folio > 0)
            Detalle_Pagos_PacienteData.push({
                Folio: removedDetalle_Pagos_PacienteData[i].Folio

                ,Suscripcion: removedDetalle_Pagos_PacienteData[i].Suscripcion
                ,Fecha_de_Suscripcion: removedDetalle_Pagos_PacienteData[i].Fecha_de_Suscripcion
                ,Fecha_Limite_de_Pago: removedDetalle_Pagos_PacienteData[i].Fecha_Limite_de_Pago
                ,Forma_de_Pago: removedDetalle_Pagos_PacienteData[i].Forma_de_Pago
                ,Fecha_de_Pago: removedDetalle_Pagos_PacienteData[i].Fecha_de_Pago
                ,Estatus: removedDetalle_Pagos_PacienteData[i].Estatus

                , Removed: true
            });
    }	

    return Detalle_Pagos_PacienteData;
}

function Detalle_Pagos_PacienteEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Pagos_PacienteTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Pagos_PacientecountRowsChecked++;
    var Detalle_Pagos_PacienteRowElement = "Detalle_Pagos_Paciente_" + rowIndex.toString();
    var prevData = Detalle_Pagos_PacienteTable.fnGetData(rowIndexTable );
    var row = Detalle_Pagos_PacienteTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Pagos_Paciente_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Pagos_PacienteGetUpdateRowControls(prevData, "Detalle_Pagos_Paciente_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Pagos_PacienteRowElement + "')){ Detalle_Pagos_PacienteInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_Pagos_PacienteCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Pagos_PacienteGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Pagos_PacienteGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_Pagos_PacienteValidation();
    initiateUIControls();
    $('.Detalle_Pagos_Paciente' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Pagos_Paciente(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Pagos_PacientefnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Pagos_PacienteTable.fnGetData().length;
    Detalle_Pagos_PacientefnClickAddRow();
    GetAddDetalle_Pagos_PacientePopup(currentRowIndex, 0);
}

function Detalle_Pagos_PacienteEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Pagos_PacienteTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Pagos_PacienteRowElement = "Detalle_Pagos_Paciente_" + rowIndex.toString();
    var prevData = Detalle_Pagos_PacienteTable.fnGetData(rowIndexTable);
    GetAddDetalle_Pagos_PacientePopup(rowIndex, 1, prevData.Folio);

    $('#Detalle_Pagos_PacienteSuscripcion').val(prevData.Suscripcion);
    $('#Detalle_Pagos_PacienteFecha_de_Suscripcion').val(prevData.Fecha_de_Suscripcion);
    $('#Detalle_Pagos_PacienteFecha_Limite_de_Pago').val(prevData.Fecha_Limite_de_Pago);
    $('#Detalle_Pagos_PacienteForma_de_Pago').val(prevData.Forma_de_Pago);
    $('#Detalle_Pagos_PacienteFecha_de_Pago').val(prevData.Fecha_de_Pago);
    $('#Detalle_Pagos_PacienteEstatus').val(prevData.Estatus);

    initiateUIControls();








}

function Detalle_Pagos_PacienteAddInsertRow() {
    if (Detalle_Pagos_PacienteinsertRowCurrentIndex < 1)
    {
        Detalle_Pagos_PacienteinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Suscripcion: ""
        ,Fecha_de_Suscripcion: ""
        ,Fecha_Limite_de_Pago: ""
        ,Forma_de_Pago: ""
        ,Fecha_de_Pago: ""
        ,Estatus: ""

    }
}

function Detalle_Pagos_PacientefnClickAddRow() {
    Detalle_Pagos_PacientecountRowsChecked++;
    Detalle_Pagos_PacienteTable.fnAddData(Detalle_Pagos_PacienteAddInsertRow(), true);
    Detalle_Pagos_PacienteTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_Pagos_PacienteGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_Pagos_PacienteGrid tbody tr:nth-of-type(' + (Detalle_Pagos_PacienteinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Pagos_Paciente("Detalle_Pagos_Paciente_", "_" + Detalle_Pagos_PacienteinsertRowCurrentIndex);
}

function Detalle_Pagos_PacienteClearGridData() {
    Detalle_Pagos_PacienteData = [];
    Detalle_Pagos_PacientedeletedItem = [];
    Detalle_Pagos_PacienteDataMain = [];
    Detalle_Pagos_PacienteDataMainPages = [];
    Detalle_Pagos_PacientenewItemCount = 0;
    Detalle_Pagos_PacientemaxItemIndex = 0;
    $("#Detalle_Pagos_PacienteGrid").DataTable().clear();
    $("#Detalle_Pagos_PacienteGrid").DataTable().destroy();
}

//Used to Get Pacientes Information
function GetDetalle_Pagos_Paciente() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Pagos_PacienteData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Pagos_PacienteData[i].Folio);

        form_data.append('[' + i + '].Suscripcion', Detalle_Pagos_PacienteData[i].Suscripcion);
        form_data.append('[' + i + '].Fecha_de_Suscripcion', Detalle_Pagos_PacienteData[i].Fecha_de_Suscripcion);
        form_data.append('[' + i + '].Fecha_Limite_de_Pago', Detalle_Pagos_PacienteData[i].Fecha_Limite_de_Pago);
        form_data.append('[' + i + '].Forma_de_Pago', Detalle_Pagos_PacienteData[i].Forma_de_Pago);
        form_data.append('[' + i + '].Fecha_de_Pago', Detalle_Pagos_PacienteData[i].Fecha_de_Pago);
        form_data.append('[' + i + '].Estatus', Detalle_Pagos_PacienteData[i].Estatus);

        form_data.append('[' + i + '].Removed', Detalle_Pagos_PacienteData[i].Removed);
    }
    return form_data;
}
function Detalle_Pagos_PacienteInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Pagos_Paciente("Detalle_Pagos_PacienteTable", rowIndex)) {
    var prevData = Detalle_Pagos_PacienteTable.fnGetData(rowIndex);
    var data = Detalle_Pagos_PacienteTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Suscripcion: $('#Detalle_Pagos_PacienteSuscripcion').val()
        ,Fecha_de_Suscripcion: $('#Detalle_Pagos_PacienteFecha_de_Suscripcion').val()
        ,Fecha_Limite_de_Pago: $('#Detalle_Pagos_PacienteFecha_Limite_de_Pago').val()
        ,Forma_de_Pago: $('#Detalle_Pagos_PacienteForma_de_Pago').val()
        ,Fecha_de_Pago: $('#Detalle_Pagos_PacienteFecha_de_Pago').val()
        ,Estatus: $('#Detalle_Pagos_PacienteEstatus').val()

    }

    Detalle_Pagos_PacienteTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Pagos_PacienterowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Pagos_Paciente-form').modal({ show: false });
    $('#AddDetalle_Pagos_Paciente-form').modal('hide');
    Detalle_Pagos_PacienteEditRow(rowIndex);
    Detalle_Pagos_PacienteInsertRow(rowIndex);
    //}
}
function Detalle_Pagos_PacienteRemoveAddRow(rowIndex) {
    Detalle_Pagos_PacienteTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Pagos_Paciente MultiRow
//Begin Declarations for Foreigns fields for Detalle_Suscripciones_Paciente MultiRow
var Detalle_Suscripciones_PacientecountRowsChecked = 0;

function GetDetalle_Suscripciones_Paciente_Planes_de_SuscripcionName(Id) {
    for (var i = 0; i < Detalle_Suscripciones_Paciente_Planes_de_SuscripcionItems.length; i++) {
        if (Detalle_Suscripciones_Paciente_Planes_de_SuscripcionItems[i].Folio == Id) {
            return Detalle_Suscripciones_Paciente_Planes_de_SuscripcionItems[i].Nombre_del_Plan;
        }
    }
    return "";
}

function GetDetalle_Suscripciones_Paciente_Planes_de_SuscripcionDropDown() {
    var Detalle_Suscripciones_Paciente_Planes_de_SuscripcionDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Suscripciones_Paciente_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Suscripciones_Paciente_Planes_de_SuscripcionDropdown);
    if(Detalle_Suscripciones_Paciente_Planes_de_SuscripcionItems != null)
    {
       for (var i = 0; i < Detalle_Suscripciones_Paciente_Planes_de_SuscripcionItems.length; i++) {
           $('<option />', { value: Detalle_Suscripciones_Paciente_Planes_de_SuscripcionItems[i].Folio, text:    Detalle_Suscripciones_Paciente_Planes_de_SuscripcionItems[i].Nombre_del_Plan }).appendTo(Detalle_Suscripciones_Paciente_Planes_de_SuscripcionDropdown);
       }
    }
    return Detalle_Suscripciones_Paciente_Planes_de_SuscripcionDropdown;
}




function GetDetalle_Suscripciones_Paciente_Estatus_de_SuscripcionName(Id) {
    for (var i = 0; i < Detalle_Suscripciones_Paciente_Estatus_de_SuscripcionItems.length; i++) {
        if (Detalle_Suscripciones_Paciente_Estatus_de_SuscripcionItems[i].Clave == Id) {
            return Detalle_Suscripciones_Paciente_Estatus_de_SuscripcionItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Suscripciones_Paciente_Estatus_de_SuscripcionDropDown() {
    var Detalle_Suscripciones_Paciente_Estatus_de_SuscripcionDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Suscripciones_Paciente_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Suscripciones_Paciente_Estatus_de_SuscripcionDropdown);
    if(Detalle_Suscripciones_Paciente_Estatus_de_SuscripcionItems != null)
    {
       for (var i = 0; i < Detalle_Suscripciones_Paciente_Estatus_de_SuscripcionItems.length; i++) {
           $('<option />', { value: Detalle_Suscripciones_Paciente_Estatus_de_SuscripcionItems[i].Clave, text:    Detalle_Suscripciones_Paciente_Estatus_de_SuscripcionItems[i].Descripcion }).appendTo(Detalle_Suscripciones_Paciente_Estatus_de_SuscripcionDropdown);
       }
    }
    return Detalle_Suscripciones_Paciente_Estatus_de_SuscripcionDropdown;
}


function GetInsertDetalle_Suscripciones_PacienteRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $(GetDetalle_Suscripciones_Paciente_Planes_de_SuscripcionDropDown()).addClass('Detalle_Suscripciones_Paciente_Suscripcion Suscripcion').attr('id', 'Detalle_Suscripciones_Paciente_Suscripcion_' + index).attr('data-field', 'Suscripcion').after($.parseHTML(addNew('Detalle_Suscripciones_Paciente', 'Planes_de_Suscripcion', 'Suscripcion', 258410)));
    columnData[1] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Suscripciones_Paciente_Fecha_de_inicio Fecha_de_inicio').attr('id', 'Detalle_Suscripciones_Paciente_Fecha_de_inicio_' + index).attr('data-field', 'Fecha_de_inicio');
    columnData[2] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Suscripciones_Paciente_Fecha_fin Fecha_fin').attr('id', 'Detalle_Suscripciones_Paciente_Fecha_fin_' + index).attr('data-field', 'Fecha_fin');
    columnData[3] = $($.parseHTML(inputData)).addClass('Detalle_Suscripciones_Paciente_Nombre_de_la_Suscripcion Nombre_de_la_Suscripcion').attr('id', 'Detalle_Suscripciones_Paciente_Nombre_de_la_Suscripcion_' + index).attr('data-field', 'Nombre_de_la_Suscripcion');
    columnData[4] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Suscripciones_Paciente_Costo Costo').attr('id', 'Detalle_Suscripciones_Paciente_Costo_' + index).attr('data-field', 'Costo');
    columnData[5] = $(GetDetalle_Suscripciones_Paciente_Estatus_de_SuscripcionDropDown()).addClass('Detalle_Suscripciones_Paciente_Estatus Estatus').attr('id', 'Detalle_Suscripciones_Paciente_Estatus_' + index).attr('data-field', 'Estatus').after($.parseHTML(addNew('Detalle_Suscripciones_Paciente', 'Estatus_de_Suscripcion', 'Estatus', 258417)));


    initiateUIControls();
    return columnData;
}

function Detalle_Suscripciones_PacienteInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Suscripciones_Paciente("Detalle_Suscripciones_Paciente_", "_" + rowIndex)) {
    var iPage = Detalle_Suscripciones_PacienteTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Suscripciones_Paciente';
    var prevData = Detalle_Suscripciones_PacienteTable.fnGetData(rowIndex);
    var data = Detalle_Suscripciones_PacienteTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Suscripcion:  data.childNodes[counter++].childNodes[0].value
        ,Fecha_de_inicio:  data.childNodes[counter++].childNodes[0].value
        ,Fecha_fin:  data.childNodes[counter++].childNodes[0].value
        ,Nombre_de_la_Suscripcion:  data.childNodes[counter++].childNodes[0].value
        ,Costo: data.childNodes[counter++].childNodes[0].value
        ,Estatus:  data.childNodes[counter++].childNodes[0].value

    }
    Detalle_Suscripciones_PacienteTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Suscripciones_PacienterowCreationGrid(data, newData, rowIndex);
    Detalle_Suscripciones_PacienteTable.fnPageChange(iPage);
    Detalle_Suscripciones_PacientecountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Suscripciones_Paciente("Detalle_Suscripciones_Paciente_", "_" + rowIndex);
  }
}

function Detalle_Suscripciones_PacienteCancelRow(rowIndex) {
    var prevData = Detalle_Suscripciones_PacienteTable.fnGetData(rowIndex);
    var data = Detalle_Suscripciones_PacienteTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Suscripciones_PacienteTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Suscripciones_PacienterowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Suscripciones_PacienteGrid(Detalle_Suscripciones_PacienteTable.fnGetData());
    Detalle_Suscripciones_PacientecountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Suscripciones_PacienteFromDataTable() {
    var Detalle_Suscripciones_PacienteData = [];
    var gridData = Detalle_Suscripciones_PacienteTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Suscripciones_PacienteData.push({
                Folio: gridData[i].Folio

                ,Suscripcion: gridData[i].Suscripcion
                ,Fecha_de_inicio: gridData[i].Fecha_de_inicio
                ,Fecha_fin: gridData[i].Fecha_fin
                ,Nombre_de_la_Suscripcion: gridData[i].Nombre_de_la_Suscripcion
                ,Costo: gridData[i].Costo
                ,Estatus: gridData[i].Estatus

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Suscripciones_PacienteData.length; i++) {
        if (removedDetalle_Suscripciones_PacienteData[i] != null && removedDetalle_Suscripciones_PacienteData[i].Folio > 0)
            Detalle_Suscripciones_PacienteData.push({
                Folio: removedDetalle_Suscripciones_PacienteData[i].Folio

                ,Suscripcion: removedDetalle_Suscripciones_PacienteData[i].Suscripcion
                ,Fecha_de_inicio: removedDetalle_Suscripciones_PacienteData[i].Fecha_de_inicio
                ,Fecha_fin: removedDetalle_Suscripciones_PacienteData[i].Fecha_fin
                ,Nombre_de_la_Suscripcion: removedDetalle_Suscripciones_PacienteData[i].Nombre_de_la_Suscripcion
                ,Costo: removedDetalle_Suscripciones_PacienteData[i].Costo
                ,Estatus: removedDetalle_Suscripciones_PacienteData[i].Estatus

                , Removed: true
            });
    }	

    return Detalle_Suscripciones_PacienteData;
}

function Detalle_Suscripciones_PacienteEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Suscripciones_PacienteTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Suscripciones_PacientecountRowsChecked++;
    var Detalle_Suscripciones_PacienteRowElement = "Detalle_Suscripciones_Paciente_" + rowIndex.toString();
    var prevData = Detalle_Suscripciones_PacienteTable.fnGetData(rowIndexTable );
    var row = Detalle_Suscripciones_PacienteTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Suscripciones_Paciente_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Suscripciones_PacienteGetUpdateRowControls(prevData, "Detalle_Suscripciones_Paciente_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Suscripciones_PacienteRowElement + "')){ Detalle_Suscripciones_PacienteInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_Suscripciones_PacienteCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Suscripciones_PacienteGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Suscripciones_PacienteGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_Suscripciones_PacienteValidation();
    initiateUIControls();
    $('.Detalle_Suscripciones_Paciente' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Suscripciones_Paciente(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Suscripciones_PacientefnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Suscripciones_PacienteTable.fnGetData().length;
    Detalle_Suscripciones_PacientefnClickAddRow();
    GetAddDetalle_Suscripciones_PacientePopup(currentRowIndex, 0);
}

function Detalle_Suscripciones_PacienteEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Suscripciones_PacienteTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Suscripciones_PacienteRowElement = "Detalle_Suscripciones_Paciente_" + rowIndex.toString();
    var prevData = Detalle_Suscripciones_PacienteTable.fnGetData(rowIndexTable);
    GetAddDetalle_Suscripciones_PacientePopup(rowIndex, 1, prevData.Folio);

    $('#Detalle_Suscripciones_PacienteSuscripcion').val(prevData.Suscripcion);
    $('#Detalle_Suscripciones_PacienteFecha_de_inicio').val(prevData.Fecha_de_inicio);
    $('#Detalle_Suscripciones_PacienteFecha_fin').val(prevData.Fecha_fin);
    $('#Detalle_Suscripciones_PacienteNombre_de_la_Suscripcion').val(prevData.Nombre_de_la_Suscripcion);
    $('#Detalle_Suscripciones_PacienteCosto').val(prevData.Costo);
    $('#Detalle_Suscripciones_PacienteEstatus').val(prevData.Estatus);

    initiateUIControls();








}

function Detalle_Suscripciones_PacienteAddInsertRow() {
    if (Detalle_Suscripciones_PacienteinsertRowCurrentIndex < 1)
    {
        Detalle_Suscripciones_PacienteinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Suscripcion: ""
        ,Fecha_de_inicio: ""
        ,Fecha_fin: ""
        ,Nombre_de_la_Suscripcion: ""
        ,Costo: ""
        ,Estatus: ""

    }
}

function Detalle_Suscripciones_PacientefnClickAddRow() {
    Detalle_Suscripciones_PacientecountRowsChecked++;
    Detalle_Suscripciones_PacienteTable.fnAddData(Detalle_Suscripciones_PacienteAddInsertRow(), true);
    Detalle_Suscripciones_PacienteTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_Suscripciones_PacienteGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_Suscripciones_PacienteGrid tbody tr:nth-of-type(' + (Detalle_Suscripciones_PacienteinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Suscripciones_Paciente("Detalle_Suscripciones_Paciente_", "_" + Detalle_Suscripciones_PacienteinsertRowCurrentIndex);
}

function Detalle_Suscripciones_PacienteClearGridData() {
    Detalle_Suscripciones_PacienteData = [];
    Detalle_Suscripciones_PacientedeletedItem = [];
    Detalle_Suscripciones_PacienteDataMain = [];
    Detalle_Suscripciones_PacienteDataMainPages = [];
    Detalle_Suscripciones_PacientenewItemCount = 0;
    Detalle_Suscripciones_PacientemaxItemIndex = 0;
    $("#Detalle_Suscripciones_PacienteGrid").DataTable().clear();
    $("#Detalle_Suscripciones_PacienteGrid").DataTable().destroy();
}

//Used to Get Pacientes Information
function GetDetalle_Suscripciones_Paciente() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Suscripciones_PacienteData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Suscripciones_PacienteData[i].Folio);

        form_data.append('[' + i + '].Suscripcion', Detalle_Suscripciones_PacienteData[i].Suscripcion);
        form_data.append('[' + i + '].Fecha_de_inicio', Detalle_Suscripciones_PacienteData[i].Fecha_de_inicio);
        form_data.append('[' + i + '].Fecha_fin', Detalle_Suscripciones_PacienteData[i].Fecha_fin);
        form_data.append('[' + i + '].Nombre_de_la_Suscripcion', Detalle_Suscripciones_PacienteData[i].Nombre_de_la_Suscripcion);
        form_data.append('[' + i + '].Costo', Detalle_Suscripciones_PacienteData[i].Costo);
        form_data.append('[' + i + '].Estatus', Detalle_Suscripciones_PacienteData[i].Estatus);

        form_data.append('[' + i + '].Removed', Detalle_Suscripciones_PacienteData[i].Removed);
    }
    return form_data;
}
function Detalle_Suscripciones_PacienteInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Suscripciones_Paciente("Detalle_Suscripciones_PacienteTable", rowIndex)) {
    var prevData = Detalle_Suscripciones_PacienteTable.fnGetData(rowIndex);
    var data = Detalle_Suscripciones_PacienteTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Suscripcion: $('#Detalle_Suscripciones_PacienteSuscripcion').val()
        ,Fecha_de_inicio: $('#Detalle_Suscripciones_PacienteFecha_de_inicio').val()
        ,Fecha_fin: $('#Detalle_Suscripciones_PacienteFecha_fin').val()
        ,Nombre_de_la_Suscripcion: $('#Detalle_Suscripciones_PacienteNombre_de_la_Suscripcion').val()
        ,Costo: $('#Detalle_Suscripciones_PacienteCosto').val()
        ,Estatus: $('#Detalle_Suscripciones_PacienteEstatus').val()

    }

    Detalle_Suscripciones_PacienteTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Suscripciones_PacienterowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Suscripciones_Paciente-form').modal({ show: false });
    $('#AddDetalle_Suscripciones_Paciente-form').modal('hide');
    Detalle_Suscripciones_PacienteEditRow(rowIndex);
    Detalle_Suscripciones_PacienteInsertRow(rowIndex);
    //}
}
function Detalle_Suscripciones_PacienteRemoveAddRow(rowIndex) {
    Detalle_Suscripciones_PacienteTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Suscripciones_Paciente MultiRow


$(function () {
    function Detalle_de_PadecimientosinitializeMainArray(totalCount) {
        if (Detalle_de_PadecimientosDataMain.length != totalCount && !Detalle_de_PadecimientosDataMainInitialized) {
            Detalle_de_PadecimientosDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_de_PadecimientosDataMain[i] = null;
            }
        }
    }
    function Detalle_de_PadecimientosremoveFromMainArray() {
        for (var j = 0; j < Detalle_de_PadecimientosdeletedItem.length; j++) {
            for (var i = 0; i < Detalle_de_PadecimientosDataMain.length; i++) {
                if (Detalle_de_PadecimientosDataMain[i] != null && Detalle_de_PadecimientosDataMain[i].Id == Detalle_de_PadecimientosdeletedItem[j]) {
                    hDetalle_de_PadecimientosDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_de_PadecimientoscopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_de_PadecimientosDataMain.length; i++) {
            data[i] = Detalle_de_PadecimientosDataMain[i];

        }
        return data;
    }
    function Detalle_de_PadecimientosgetNewResult() {
        var newData = copyMainDetalle_de_PadecimientosArray();

        for (var i = 0; i < Detalle_de_PadecimientosData.length; i++) {
            if (Detalle_de_PadecimientosData[i].Removed == null || Detalle_de_PadecimientosData[i].Removed == false) {
                newData.splice(0, 0, Detalle_de_PadecimientosData[i]);
            }
        }
        return newData;
    }
    function Detalle_de_PadecimientospushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_de_PadecimientosDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_de_PadecimientosDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Detalle_Antecedentes_FamiliaresinitializeMainArray(totalCount) {
        if (Detalle_Antecedentes_FamiliaresDataMain.length != totalCount && !Detalle_Antecedentes_FamiliaresDataMainInitialized) {
            Detalle_Antecedentes_FamiliaresDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Antecedentes_FamiliaresDataMain[i] = null;
            }
        }
    }
    function Detalle_Antecedentes_FamiliaresremoveFromMainArray() {
        for (var j = 0; j < Detalle_Antecedentes_FamiliaresdeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Antecedentes_FamiliaresDataMain.length; i++) {
                if (Detalle_Antecedentes_FamiliaresDataMain[i] != null && Detalle_Antecedentes_FamiliaresDataMain[i].Id == Detalle_Antecedentes_FamiliaresdeletedItem[j]) {
                    hDetalle_Antecedentes_FamiliaresDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Antecedentes_FamiliarescopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Antecedentes_FamiliaresDataMain.length; i++) {
            data[i] = Detalle_Antecedentes_FamiliaresDataMain[i];

        }
        return data;
    }
    function Detalle_Antecedentes_FamiliaresgetNewResult() {
        var newData = copyMainDetalle_Antecedentes_FamiliaresArray();

        for (var i = 0; i < Detalle_Antecedentes_FamiliaresData.length; i++) {
            if (Detalle_Antecedentes_FamiliaresData[i].Removed == null || Detalle_Antecedentes_FamiliaresData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Antecedentes_FamiliaresData[i]);
            }
        }
        return newData;
    }
    function Detalle_Antecedentes_FamiliarespushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Antecedentes_FamiliaresDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Antecedentes_FamiliaresDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Detalle_Antecedentes_No_PatologicosinitializeMainArray(totalCount) {
        if (Detalle_Antecedentes_No_PatologicosDataMain.length != totalCount && !Detalle_Antecedentes_No_PatologicosDataMainInitialized) {
            Detalle_Antecedentes_No_PatologicosDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Antecedentes_No_PatologicosDataMain[i] = null;
            }
        }
    }
    function Detalle_Antecedentes_No_PatologicosremoveFromMainArray() {
        for (var j = 0; j < Detalle_Antecedentes_No_PatologicosdeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Antecedentes_No_PatologicosDataMain.length; i++) {
                if (Detalle_Antecedentes_No_PatologicosDataMain[i] != null && Detalle_Antecedentes_No_PatologicosDataMain[i].Id == Detalle_Antecedentes_No_PatologicosdeletedItem[j]) {
                    hDetalle_Antecedentes_No_PatologicosDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Antecedentes_No_PatologicoscopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Antecedentes_No_PatologicosDataMain.length; i++) {
            data[i] = Detalle_Antecedentes_No_PatologicosDataMain[i];

        }
        return data;
    }
    function Detalle_Antecedentes_No_PatologicosgetNewResult() {
        var newData = copyMainDetalle_Antecedentes_No_PatologicosArray();

        for (var i = 0; i < Detalle_Antecedentes_No_PatologicosData.length; i++) {
            if (Detalle_Antecedentes_No_PatologicosData[i].Removed == null || Detalle_Antecedentes_No_PatologicosData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Antecedentes_No_PatologicosData[i]);
            }
        }
        return newData;
    }
    function Detalle_Antecedentes_No_PatologicospushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Antecedentes_No_PatologicosDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Antecedentes_No_PatologicosDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Detalle_Examenes_LaboratorioinitializeMainArray(totalCount) {
        if (Detalle_Examenes_LaboratorioDataMain.length != totalCount && !Detalle_Examenes_LaboratorioDataMainInitialized) {
            Detalle_Examenes_LaboratorioDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Examenes_LaboratorioDataMain[i] = null;
            }
        }
    }
    function Detalle_Examenes_LaboratorioremoveFromMainArray() {
        for (var j = 0; j < Detalle_Examenes_LaboratoriodeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Examenes_LaboratorioDataMain.length; i++) {
                if (Detalle_Examenes_LaboratorioDataMain[i] != null && Detalle_Examenes_LaboratorioDataMain[i].Id == Detalle_Examenes_LaboratoriodeletedItem[j]) {
                    hDetalle_Examenes_LaboratorioDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Examenes_LaboratoriocopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Examenes_LaboratorioDataMain.length; i++) {
            data[i] = Detalle_Examenes_LaboratorioDataMain[i];

        }
        return data;
    }
    function Detalle_Examenes_LaboratoriogetNewResult() {
        var newData = copyMainDetalle_Examenes_LaboratorioArray();

        for (var i = 0; i < Detalle_Examenes_LaboratorioData.length; i++) {
            if (Detalle_Examenes_LaboratorioData[i].Removed == null || Detalle_Examenes_LaboratorioData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Examenes_LaboratorioData[i]);
            }
        }
        return newData;
    }
    function Detalle_Examenes_LaboratoriopushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Examenes_LaboratorioDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Examenes_LaboratorioDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Detalle_Terapia_HormonalinitializeMainArray(totalCount) {
        if (Detalle_Terapia_HormonalDataMain.length != totalCount && !Detalle_Terapia_HormonalDataMainInitialized) {
            Detalle_Terapia_HormonalDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Terapia_HormonalDataMain[i] = null;
            }
        }
    }
    function Detalle_Terapia_HormonalremoveFromMainArray() {
        for (var j = 0; j < Detalle_Terapia_HormonaldeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Terapia_HormonalDataMain.length; i++) {
                if (Detalle_Terapia_HormonalDataMain[i] != null && Detalle_Terapia_HormonalDataMain[i].Id == Detalle_Terapia_HormonaldeletedItem[j]) {
                    hDetalle_Terapia_HormonalDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Terapia_HormonalcopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Terapia_HormonalDataMain.length; i++) {
            data[i] = Detalle_Terapia_HormonalDataMain[i];

        }
        return data;
    }
    function Detalle_Terapia_HormonalgetNewResult() {
        var newData = copyMainDetalle_Terapia_HormonalArray();

        for (var i = 0; i < Detalle_Terapia_HormonalData.length; i++) {
            if (Detalle_Terapia_HormonalData[i].Removed == null || Detalle_Terapia_HormonalData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Terapia_HormonalData[i]);
            }
        }
        return newData;
    }
    function Detalle_Terapia_HormonalpushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Terapia_HormonalDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Terapia_HormonalDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function MS_Exclusion_Ingredientes_PacienteinitializeMainArray(totalCount) {
        if (MS_Exclusion_Ingredientes_PacienteDataMain.length != totalCount && !MS_Exclusion_Ingredientes_PacienteDataMainInitialized) {
            MS_Exclusion_Ingredientes_PacienteDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                MS_Exclusion_Ingredientes_PacienteDataMain[i] = null;
            }
        }
    }
    function MS_Exclusion_Ingredientes_PacienteremoveFromMainArray() {
        for (var j = 0; j < MS_Exclusion_Ingredientes_PacientedeletedItem.length; j++) {
            for (var i = 0; i < MS_Exclusion_Ingredientes_PacienteDataMain.length; i++) {
                if (MS_Exclusion_Ingredientes_PacienteDataMain[i] != null && MS_Exclusion_Ingredientes_PacienteDataMain[i].Id == MS_Exclusion_Ingredientes_PacientedeletedItem[j]) {
                    hMS_Exclusion_Ingredientes_PacienteDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function MS_Exclusion_Ingredientes_PacientecopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < MS_Exclusion_Ingredientes_PacienteDataMain.length; i++) {
            data[i] = MS_Exclusion_Ingredientes_PacienteDataMain[i];

        }
        return data;
    }
    function MS_Exclusion_Ingredientes_PacientegetNewResult() {
        var newData = copyMainMS_Exclusion_Ingredientes_PacienteArray();

        for (var i = 0; i < MS_Exclusion_Ingredientes_PacienteData.length; i++) {
            if (MS_Exclusion_Ingredientes_PacienteData[i].Removed == null || MS_Exclusion_Ingredientes_PacienteData[i].Removed == false) {
                newData.splice(0, 0, MS_Exclusion_Ingredientes_PacienteData[i]);
            }
        }
        return newData;
    }
    function MS_Exclusion_Ingredientes_PacientepushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (MS_Exclusion_Ingredientes_PacienteDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                MS_Exclusion_Ingredientes_PacienteDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Detalle_Preferencia_BebidasinitializeMainArray(totalCount) {
        if (Detalle_Preferencia_BebidasDataMain.length != totalCount && !Detalle_Preferencia_BebidasDataMainInitialized) {
            Detalle_Preferencia_BebidasDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Preferencia_BebidasDataMain[i] = null;
            }
        }
    }
    function Detalle_Preferencia_BebidasremoveFromMainArray() {
        for (var j = 0; j < Detalle_Preferencia_BebidasdeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Preferencia_BebidasDataMain.length; i++) {
                if (Detalle_Preferencia_BebidasDataMain[i] != null && Detalle_Preferencia_BebidasDataMain[i].Id == Detalle_Preferencia_BebidasdeletedItem[j]) {
                    hDetalle_Preferencia_BebidasDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Preferencia_BebidascopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Preferencia_BebidasDataMain.length; i++) {
            data[i] = Detalle_Preferencia_BebidasDataMain[i];

        }
        return data;
    }
    function Detalle_Preferencia_BebidasgetNewResult() {
        var newData = copyMainDetalle_Preferencia_BebidasArray();

        for (var i = 0; i < Detalle_Preferencia_BebidasData.length; i++) {
            if (Detalle_Preferencia_BebidasData[i].Removed == null || Detalle_Preferencia_BebidasData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Preferencia_BebidasData[i]);
            }
        }
        return newData;
    }
    function Detalle_Preferencia_BebidaspushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Preferencia_BebidasDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Preferencia_BebidasDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Detalle_Pagos_PacienteinitializeMainArray(totalCount) {
        if (Detalle_Pagos_PacienteDataMain.length != totalCount && !Detalle_Pagos_PacienteDataMainInitialized) {
            Detalle_Pagos_PacienteDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Pagos_PacienteDataMain[i] = null;
            }
        }
    }
    function Detalle_Pagos_PacienteremoveFromMainArray() {
        for (var j = 0; j < Detalle_Pagos_PacientedeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Pagos_PacienteDataMain.length; i++) {
                if (Detalle_Pagos_PacienteDataMain[i] != null && Detalle_Pagos_PacienteDataMain[i].Id == Detalle_Pagos_PacientedeletedItem[j]) {
                    hDetalle_Pagos_PacienteDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Pagos_PacientecopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Pagos_PacienteDataMain.length; i++) {
            data[i] = Detalle_Pagos_PacienteDataMain[i];

        }
        return data;
    }
    function Detalle_Pagos_PacientegetNewResult() {
        var newData = copyMainDetalle_Pagos_PacienteArray();

        for (var i = 0; i < Detalle_Pagos_PacienteData.length; i++) {
            if (Detalle_Pagos_PacienteData[i].Removed == null || Detalle_Pagos_PacienteData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Pagos_PacienteData[i]);
            }
        }
        return newData;
    }
    function Detalle_Pagos_PacientepushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Pagos_PacienteDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Pagos_PacienteDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Detalle_Suscripciones_PacienteinitializeMainArray(totalCount) {
        if (Detalle_Suscripciones_PacienteDataMain.length != totalCount && !Detalle_Suscripciones_PacienteDataMainInitialized) {
            Detalle_Suscripciones_PacienteDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Suscripciones_PacienteDataMain[i] = null;
            }
        }
    }
    function Detalle_Suscripciones_PacienteremoveFromMainArray() {
        for (var j = 0; j < Detalle_Suscripciones_PacientedeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Suscripciones_PacienteDataMain.length; i++) {
                if (Detalle_Suscripciones_PacienteDataMain[i] != null && Detalle_Suscripciones_PacienteDataMain[i].Id == Detalle_Suscripciones_PacientedeletedItem[j]) {
                    hDetalle_Suscripciones_PacienteDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Suscripciones_PacientecopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Suscripciones_PacienteDataMain.length; i++) {
            data[i] = Detalle_Suscripciones_PacienteDataMain[i];

        }
        return data;
    }
    function Detalle_Suscripciones_PacientegetNewResult() {
        var newData = copyMainDetalle_Suscripciones_PacienteArray();

        for (var i = 0; i < Detalle_Suscripciones_PacienteData.length; i++) {
            if (Detalle_Suscripciones_PacienteData[i].Removed == null || Detalle_Suscripciones_PacienteData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Suscripciones_PacienteData[i]);
            }
        }
        return newData;
    }
    function Detalle_Suscripciones_PacientepushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Suscripciones_PacienteDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Suscripciones_PacienteDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
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

//Grid GetAutocomplete



function getDropdown(elementKey) {
    var labelSelect = $("#Pacientes_cmbLabelSelect").val();
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
    $('#CreatePacientes')[0].reset();
    ClearFormControls();
    $("#FolioId").val("0");
                Detalle_de_PadecimientosClearGridData();
                Detalle_Antecedentes_FamiliaresClearGridData();
                Detalle_Antecedentes_No_PatologicosClearGridData();
                Detalle_Examenes_LaboratorioClearGridData();
                Detalle_Terapia_HormonalClearGridData();
                   $('#ddlAlergiasMult').children("selected").each(function () {
                           $(this).prop("selected", false);
                   });
                   $('#ddlAlergiasMult').trigger('chosen:updated');
                Detalle_Preferencia_BebidasClearGridData();
                Detalle_Pagos_PacienteClearGridData();
                Detalle_Suscripciones_PacienteClearGridData();

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreatePacientes').trigger('reset');
    $('#CreatePacientes').find(':input').each(function () {
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
    var $myForm = $('#CreatePacientes');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    if (Detalle_de_PadecimientoscountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_de_Padecimientos();
        return false;
    }
    if (Detalle_Antecedentes_FamiliarescountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Antecedentes_Familiares();
        return false;
    }
    if (Detalle_Antecedentes_No_PatologicoscountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Antecedentes_No_Patologicos();
        return false;
    }
    if (Detalle_Examenes_LaboratoriocountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Examenes_Laboratorio();
        return false;
    }
    if (Detalle_Terapia_HormonalcountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Terapia_Hormonal();
        return false;
    }
    if (MS_Exclusion_Ingredientes_PacientecountRowsChecked > 0)
    {
        ShowMessagePendingRowMS_Exclusion_Ingredientes_Paciente();
        return false;
    }
    if (Detalle_Preferencia_BebidascountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Preferencia_Bebidas();
        return false;
    }
    if (Detalle_Pagos_PacientecountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Pagos_Paciente();
        return false;
    }
    if (Detalle_Suscripciones_PacientecountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Suscripciones_Paciente();
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblFolio").text("0");
}
$(document).ready(function () {
    $("form#CreatePacientes").submit(function (e) {
        e.preventDefault();
        return false;
    });
	$("form#CreatePacientes").on('click', '#PacientesCancelar', function () {
	  if (!isPartial) {
        PacientesBackToGrid();
	  } else {
            window.close();
      }
    });
	$("form#CreatePacientes").on('click', '#PacientesGuardar', function () {
		$('#PacientesGuardar').attr('disabled', true);
		$('#PacientesGuardar').unbind()
        if (EjecutarValidacionesAntesDeGuardar() && CheckValidation()) {
				if (!SendPacientesData(function () {
					EjecutarValidacionesDespuesDeGuardar();
					if (!isPartial)
						PacientesBackToGrid();
					else {						
						if (!isMR)
							window.opener.RefreshCatalog('Pacientes', nameAttribute);
						else {
							var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
							if(!control.hasClass('AutoComplete'))
							{
							if (control.attr("data-isfilter") == "true") {
									eval(GetReglaFilter(control,  $(window.opener.document.getElementById('ObjectId')).val()));								    
								}
								else 
								{
									eval('window.opener.Get' + nameMR + '_PacientesItem()');
									var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
									control.html(eval('window.opener.Get' + nameMR + '_PacientesDropDown().get(0)').innerHTML);  
								}								
							}
						}
						window.close();						
						}
				})) {
					$('#PacientesGuardar').removeAttr('disabled');
					$('#PacientesGuardar').bind()
				}
		}
		else {
			$('#PacientesGuardar').removeAttr('disabled');
			$('#PacientesGuardar').bind()
		}
    });
	$("form#CreatePacientes").on('click', '#PacientesGuardarYNuevo', function () {	
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation()) {
				SendPacientesData(function () {
					ClearControls();
					ClearAttachmentsDiv();
					ResetClaveLabel();
	                getDetalle_de_PadecimientosData();
                getDetalle_Antecedentes_FamiliaresData();
                getDetalle_Antecedentes_No_PatologicosData();
                getDetalle_Examenes_LaboratorioData();
                getDetalle_Terapia_HormonalData();
                getMS_Exclusion_Ingredientes_PacienteData();
                getDetalle_Preferencia_BebidasData();
                getDetalle_Pagos_PacienteData();
                getDetalle_Suscripciones_PacienteData();

					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Pacientes', nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_PacientesItem()');                           
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
                            control.html(eval('window.opener.Get' + nameMR + '_PacientesDropDown().get(0)').innerHTML);   
					    }	
					}						
					EjecutarValidacionesDespuesDeGuardar();				
			setIsNew();
			EjecutarValidacionesAlComienzo();
				});
			}
		}		
    });
    $("form#CreatePacientes").on('click', '#PacientesGuardarYCopia', function () {
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendPacientesData(function (currentId) {
					$("#FolioId").val("0");
	                Detalle_de_PadecimientosClearGridData();
                Detalle_Antecedentes_FamiliaresClearGridData();
                Detalle_Antecedentes_No_PatologicosClearGridData();
                Detalle_Examenes_LaboratorioClearGridData();
                Detalle_Terapia_HormonalClearGridData();
                   $('#ddlAlergiasMult').children("selected").each(function () {
                           $(this).prop("selected", false);
                   });
                   $('#ddlAlergiasMult').trigger('chosen:updated');
                Detalle_Preferencia_BebidasClearGridData();
                Detalle_Pagos_PacienteClearGridData();
                Detalle_Suscripciones_PacienteClearGridData();

					ResetClaveLabel();
					$("#ReferenceFolio").val(currentId);
	                getDetalle_de_PadecimientosData();
                getDetalle_Antecedentes_FamiliaresData();
                getDetalle_Antecedentes_No_PatologicosData();
                getDetalle_Examenes_LaboratorioData();
                getDetalle_Terapia_HormonalData();
                getMS_Exclusion_Ingredientes_PacienteData();
                getDetalle_Preferencia_BebidasData();
                getDetalle_Pagos_PacienteData();
                getDetalle_Suscripciones_PacienteData();

					EjecutarValidacionesDespuesDeGuardar();		
					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Pacientes',nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_PacientesItem()');                          
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);						
							control.html(eval('window.opener.Get' + nameMR + '_PacientesDropDown().get(0)').innerHTML);                          
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



var PacientesisdisplayBusinessPropery = false;
PacientesDisplayBusinessRuleButtons(PacientesisdisplayBusinessPropery);
function PacientesDisplayBusinessRule() {
    if (!PacientesisdisplayBusinessPropery) {
        $('#CreatePacientes').find('.col-sm-8').each(function () {
			var div =$(this); 
			if ($(this).find('.input-group').length >0)
				div  =  $(this).find('.input-group').first().hasClass('date')? $(this): $(this).find('.input-group').first();	
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = div.data('field-id');
            var fieldName = div.data('field-name');
            var attribute = div.data('attribute');
            mainElementAttributes += '<div class="PacientesdisplayBusinessPropery"><button onclick="PacientesGetBusinessRule()" type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#PacientesBusinessRule-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.PacientesdisplayBusinessPropery').remove();
    }
    PacientesDisplayBusinessRuleButtons(!PacientesisdisplayBusinessPropery);
    PacientesisdisplayBusinessPropery = (PacientesisdisplayBusinessPropery ? false : true);
}
function PacientesDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}

