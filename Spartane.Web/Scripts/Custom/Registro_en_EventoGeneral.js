

//Begin Declarations for Foreigns fields for Detalle_Consulta_Actividades_Registro_Evento MultiRow
var Detalle_Consulta_Actividades_Registro_EventocountRowsChecked = 0;

function GetDetalle_Consulta_Actividades_Registro_Evento_Detalle_Actividades_EventoName(Id) {
    for (var i = 0; i < Detalle_Consulta_Actividades_Registro_Evento_Detalle_Actividades_EventoItems.length; i++) {
        if (Detalle_Consulta_Actividades_Registro_Evento_Detalle_Actividades_EventoItems[i].Folio == Id) {
            return Detalle_Consulta_Actividades_Registro_Evento_Detalle_Actividades_EventoItems[i].Nombre_de_la_Actividad;
        }
    }
    return "";
}

function GetDetalle_Consulta_Actividades_Registro_Evento_Detalle_Actividades_EventoDropDown() {
    var Detalle_Consulta_Actividades_Registro_Evento_Detalle_Actividades_EventoDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Consulta_Actividades_Registro_Evento_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Consulta_Actividades_Registro_Evento_Detalle_Actividades_EventoDropdown);
    if(Detalle_Consulta_Actividades_Registro_Evento_Detalle_Actividades_EventoItems != null)
    {
       for (var i = 0; i < Detalle_Consulta_Actividades_Registro_Evento_Detalle_Actividades_EventoItems.length; i++) {
           $('<option />', { value: Detalle_Consulta_Actividades_Registro_Evento_Detalle_Actividades_EventoItems[i].Folio, text:    Detalle_Consulta_Actividades_Registro_Evento_Detalle_Actividades_EventoItems[i].Nombre_de_la_Actividad }).appendTo(Detalle_Consulta_Actividades_Registro_Evento_Detalle_Actividades_EventoDropdown);
       }
    }
    return Detalle_Consulta_Actividades_Registro_Evento_Detalle_Actividades_EventoDropdown;
}
function GetDetalle_Consulta_Actividades_Registro_Evento_Tipos_de_ActividadesName(Id) {
    for (var i = 0; i < Detalle_Consulta_Actividades_Registro_Evento_Tipos_de_ActividadesItems.length; i++) {
        if (Detalle_Consulta_Actividades_Registro_Evento_Tipos_de_ActividadesItems[i].Folio == Id) {
            return Detalle_Consulta_Actividades_Registro_Evento_Tipos_de_ActividadesItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Consulta_Actividades_Registro_Evento_Tipos_de_ActividadesDropDown() {
    var Detalle_Consulta_Actividades_Registro_Evento_Tipos_de_ActividadesDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Consulta_Actividades_Registro_Evento_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Consulta_Actividades_Registro_Evento_Tipos_de_ActividadesDropdown);
    if(Detalle_Consulta_Actividades_Registro_Evento_Tipos_de_ActividadesItems != null)
    {
       for (var i = 0; i < Detalle_Consulta_Actividades_Registro_Evento_Tipos_de_ActividadesItems.length; i++) {
           $('<option />', { value: Detalle_Consulta_Actividades_Registro_Evento_Tipos_de_ActividadesItems[i].Folio, text:    Detalle_Consulta_Actividades_Registro_Evento_Tipos_de_ActividadesItems[i].Descripcion }).appendTo(Detalle_Consulta_Actividades_Registro_Evento_Tipos_de_ActividadesDropdown);
       }
    }
    return Detalle_Consulta_Actividades_Registro_Evento_Tipos_de_ActividadesDropdown;
}
function GetDetalle_Consulta_Actividades_Registro_Evento_EspecialidadesName(Id) {
    for (var i = 0; i < Detalle_Consulta_Actividades_Registro_Evento_EspecialidadesItems.length; i++) {
        if (Detalle_Consulta_Actividades_Registro_Evento_EspecialidadesItems[i].Clave == Id) {
            return Detalle_Consulta_Actividades_Registro_Evento_EspecialidadesItems[i].Especialidad;
        }
    }
    return "";
}

function GetDetalle_Consulta_Actividades_Registro_Evento_EspecialidadesDropDown() {
    var Detalle_Consulta_Actividades_Registro_Evento_EspecialidadesDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Consulta_Actividades_Registro_Evento_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Consulta_Actividades_Registro_Evento_EspecialidadesDropdown);
    if(Detalle_Consulta_Actividades_Registro_Evento_EspecialidadesItems != null)
    {
       for (var i = 0; i < Detalle_Consulta_Actividades_Registro_Evento_EspecialidadesItems.length; i++) {
           $('<option />', { value: Detalle_Consulta_Actividades_Registro_Evento_EspecialidadesItems[i].Clave, text:    Detalle_Consulta_Actividades_Registro_Evento_EspecialidadesItems[i].Especialidad }).appendTo(Detalle_Consulta_Actividades_Registro_Evento_EspecialidadesDropdown);
       }
    }
    return Detalle_Consulta_Actividades_Registro_Evento_EspecialidadesDropdown;
}
function GetDetalle_Consulta_Actividades_Registro_Evento_Spartan_UserName(Id) {
    for (var i = 0; i < Detalle_Consulta_Actividades_Registro_Evento_Spartan_UserItems.length; i++) {
        if (Detalle_Consulta_Actividades_Registro_Evento_Spartan_UserItems[i].Id_User == Id) {
            return Detalle_Consulta_Actividades_Registro_Evento_Spartan_UserItems[i].Name;
        }
    }
    return "";
}

function GetDetalle_Consulta_Actividades_Registro_Evento_Spartan_UserDropDown() {
    var Detalle_Consulta_Actividades_Registro_Evento_Spartan_UserDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Consulta_Actividades_Registro_Evento_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Consulta_Actividades_Registro_Evento_Spartan_UserDropdown);
    if(Detalle_Consulta_Actividades_Registro_Evento_Spartan_UserItems != null)
    {
       for (var i = 0; i < Detalle_Consulta_Actividades_Registro_Evento_Spartan_UserItems.length; i++) {
           $('<option />', { value: Detalle_Consulta_Actividades_Registro_Evento_Spartan_UserItems[i].Id_User, text:    Detalle_Consulta_Actividades_Registro_Evento_Spartan_UserItems[i].Name }).appendTo(Detalle_Consulta_Actividades_Registro_Evento_Spartan_UserDropdown);
       }
    }
    return Detalle_Consulta_Actividades_Registro_Evento_Spartan_UserDropdown;
}






function GetInsertDetalle_Consulta_Actividades_Registro_EventoRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $(GetDetalle_Consulta_Actividades_Registro_Evento_Detalle_Actividades_EventoDropDown()).addClass('Detalle_Consulta_Actividades_Registro_Evento_Actividad Actividad').attr('id', 'Detalle_Consulta_Actividades_Registro_Evento_Actividad_' + index).attr('data-field', 'Actividad').after($.parseHTML(addNew('Detalle_Consulta_Actividades_Registro_Evento', 'Detalle_Actividades_Evento', 'Actividad', 258791)));
    columnData[1] = $(GetDetalle_Consulta_Actividades_Registro_Evento_Tipos_de_ActividadesDropDown()).addClass('Detalle_Consulta_Actividades_Registro_Evento_Tipo_de_Actividad Tipo_de_Actividad').attr('id', 'Detalle_Consulta_Actividades_Registro_Evento_Tipo_de_Actividad_' + index).attr('data-field', 'Tipo_de_Actividad').after($.parseHTML(addNew('Detalle_Consulta_Actividades_Registro_Evento', 'Tipos_de_Actividades', 'Tipo_de_Actividad', 258792)));
    columnData[2] = $(GetDetalle_Consulta_Actividades_Registro_Evento_EspecialidadesDropDown()).addClass('Detalle_Consulta_Actividades_Registro_Evento_Especialidad Especialidad').attr('id', 'Detalle_Consulta_Actividades_Registro_Evento_Especialidad_' + index).attr('data-field', 'Especialidad').after($.parseHTML(addNew('Detalle_Consulta_Actividades_Registro_Evento', 'Especialidades', 'Especialidad', 258793)));
    columnData[3] = $(GetDetalle_Consulta_Actividades_Registro_Evento_Spartan_UserDropDown()).addClass('Detalle_Consulta_Actividades_Registro_Evento_Imparte Imparte').attr('id', 'Detalle_Consulta_Actividades_Registro_Evento_Imparte_' + index).attr('data-field', 'Imparte').after($.parseHTML(addNew('Detalle_Consulta_Actividades_Registro_Evento', 'Spartan_User', 'Imparte', 258794)));
    columnData[4] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Consulta_Actividades_Registro_Evento_Fecha Fecha').attr('id', 'Detalle_Consulta_Actividades_Registro_Evento_Fecha_' + index).attr('data-field', 'Fecha');
    columnData[5] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Consulta_Actividades_Registro_Evento_Lugares_disponibles Lugares_disponibles').attr('id', 'Detalle_Consulta_Actividades_Registro_Evento_Lugares_disponibles_' + index).attr('data-field', 'Lugares_disponibles');
    columnData[6] = $($.parseHTML(inputData)).addClass('Detalle_Consulta_Actividades_Registro_Evento_Horarios_disponibles Horarios_disponibles').attr('id', 'Detalle_Consulta_Actividades_Registro_Evento_Horarios_disponibles_' + index).attr('data-field', 'Horarios_disponibles');
    columnData[7] = $($.parseHTML(inputData)).addClass('Detalle_Consulta_Actividades_Registro_Evento_Ubicacion Ubicacion').attr('id', 'Detalle_Consulta_Actividades_Registro_Evento_Ubicacion_' + index).attr('data-field', 'Ubicacion');


    initiateUIControls();
    return columnData;
}

function Detalle_Consulta_Actividades_Registro_EventoInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Consulta_Actividades_Registro_Evento("Detalle_Consulta_Actividades_Registro_Evento_", "_" + rowIndex)) {
    var iPage = Detalle_Consulta_Actividades_Registro_EventoTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Consulta_Actividades_Registro_Evento';
    var prevData = Detalle_Consulta_Actividades_Registro_EventoTable.fnGetData(rowIndex);
    var data = Detalle_Consulta_Actividades_Registro_EventoTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Actividad:  data.childNodes[counter++].childNodes[0].value
        ,Tipo_de_Actividad:  data.childNodes[counter++].childNodes[0].value
        ,Especialidad:  data.childNodes[counter++].childNodes[0].value
        ,Imparte:  data.childNodes[counter++].childNodes[0].value
        ,Fecha:  data.childNodes[counter++].childNodes[0].value
        ,Lugares_disponibles: data.childNodes[counter++].childNodes[0].value
        ,Horarios_disponibles:  data.childNodes[counter++].childNodes[0].value
        ,Ubicacion:  data.childNodes[counter++].childNodes[0].value

    }
    Detalle_Consulta_Actividades_Registro_EventoTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Consulta_Actividades_Registro_EventorowCreationGrid(data, newData, rowIndex);
    Detalle_Consulta_Actividades_Registro_EventoTable.fnPageChange(iPage);
    Detalle_Consulta_Actividades_Registro_EventocountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Consulta_Actividades_Registro_Evento("Detalle_Consulta_Actividades_Registro_Evento_", "_" + rowIndex);
  }
}

function Detalle_Consulta_Actividades_Registro_EventoCancelRow(rowIndex) {
    var prevData = Detalle_Consulta_Actividades_Registro_EventoTable.fnGetData(rowIndex);
    var data = Detalle_Consulta_Actividades_Registro_EventoTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Consulta_Actividades_Registro_EventoTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Consulta_Actividades_Registro_EventorowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Consulta_Actividades_Registro_EventoGrid(Detalle_Consulta_Actividades_Registro_EventoTable.fnGetData());
    Detalle_Consulta_Actividades_Registro_EventocountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Consulta_Actividades_Registro_EventoFromDataTable() {
    var Detalle_Consulta_Actividades_Registro_EventoData = [];
    var gridData = Detalle_Consulta_Actividades_Registro_EventoTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Consulta_Actividades_Registro_EventoData.push({
                Folio: gridData[i].Folio

                ,Actividad: gridData[i].Actividad
                ,Tipo_de_Actividad: gridData[i].Tipo_de_Actividad
                ,Especialidad: gridData[i].Especialidad
                ,Imparte: gridData[i].Imparte
                ,Fecha: gridData[i].Fecha
                ,Lugares_disponibles: gridData[i].Lugares_disponibles
                ,Horarios_disponibles: gridData[i].Horarios_disponibles
                ,Ubicacion: gridData[i].Ubicacion

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Consulta_Actividades_Registro_EventoData.length; i++) {
        if (removedDetalle_Consulta_Actividades_Registro_EventoData[i] != null && removedDetalle_Consulta_Actividades_Registro_EventoData[i].Folio > 0)
            Detalle_Consulta_Actividades_Registro_EventoData.push({
                Folio: removedDetalle_Consulta_Actividades_Registro_EventoData[i].Folio

                ,Actividad: removedDetalle_Consulta_Actividades_Registro_EventoData[i].Actividad
                ,Tipo_de_Actividad: removedDetalle_Consulta_Actividades_Registro_EventoData[i].Tipo_de_Actividad
                ,Especialidad: removedDetalle_Consulta_Actividades_Registro_EventoData[i].Especialidad
                ,Imparte: removedDetalle_Consulta_Actividades_Registro_EventoData[i].Imparte
                ,Fecha: removedDetalle_Consulta_Actividades_Registro_EventoData[i].Fecha
                ,Lugares_disponibles: removedDetalle_Consulta_Actividades_Registro_EventoData[i].Lugares_disponibles
                ,Horarios_disponibles: removedDetalle_Consulta_Actividades_Registro_EventoData[i].Horarios_disponibles
                ,Ubicacion: removedDetalle_Consulta_Actividades_Registro_EventoData[i].Ubicacion

                , Removed: true
            });
    }	

    return Detalle_Consulta_Actividades_Registro_EventoData;
}

function Detalle_Consulta_Actividades_Registro_EventoEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Consulta_Actividades_Registro_EventoTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Consulta_Actividades_Registro_EventocountRowsChecked++;
    var Detalle_Consulta_Actividades_Registro_EventoRowElement = "Detalle_Consulta_Actividades_Registro_Evento_" + rowIndex.toString();
    var prevData = Detalle_Consulta_Actividades_Registro_EventoTable.fnGetData(rowIndexTable );
    var row = Detalle_Consulta_Actividades_Registro_EventoTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Consulta_Actividades_Registro_Evento_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Consulta_Actividades_Registro_EventoGetUpdateRowControls(prevData, "Detalle_Consulta_Actividades_Registro_Evento_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Consulta_Actividades_Registro_EventoRowElement + "')){ Detalle_Consulta_Actividades_Registro_EventoInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_Consulta_Actividades_Registro_EventoCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Consulta_Actividades_Registro_EventoGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Consulta_Actividades_Registro_EventoGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_Consulta_Actividades_Registro_EventoValidation();
    initiateUIControls();
    $('.Detalle_Consulta_Actividades_Registro_Evento' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Consulta_Actividades_Registro_Evento(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Consulta_Actividades_Registro_EventofnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Consulta_Actividades_Registro_EventoTable.fnGetData().length;
    Detalle_Consulta_Actividades_Registro_EventofnClickAddRow();
    GetAddDetalle_Consulta_Actividades_Registro_EventoPopup(currentRowIndex, 0);
}

function Detalle_Consulta_Actividades_Registro_EventoEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Consulta_Actividades_Registro_EventoTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Consulta_Actividades_Registro_EventoRowElement = "Detalle_Consulta_Actividades_Registro_Evento_" + rowIndex.toString();
    var prevData = Detalle_Consulta_Actividades_Registro_EventoTable.fnGetData(rowIndexTable);
    GetAddDetalle_Consulta_Actividades_Registro_EventoPopup(rowIndex, 1, prevData.Folio);

    $('#Detalle_Consulta_Actividades_Registro_EventoActividad').val(prevData.Actividad);
    $('#Detalle_Consulta_Actividades_Registro_EventoTipo_de_Actividad').val(prevData.Tipo_de_Actividad);
    $('#Detalle_Consulta_Actividades_Registro_EventoEspecialidad').val(prevData.Especialidad);
    $('#Detalle_Consulta_Actividades_Registro_EventoImparte').val(prevData.Imparte);
    $('#Detalle_Consulta_Actividades_Registro_EventoFecha').val(prevData.Fecha);
    $('#Detalle_Consulta_Actividades_Registro_EventoLugares_disponibles').val(prevData.Lugares_disponibles);
    $('#Detalle_Consulta_Actividades_Registro_EventoHorarios_disponibles').val(prevData.Horarios_disponibles);
    $('#Detalle_Consulta_Actividades_Registro_EventoUbicacion').val(prevData.Ubicacion);

    initiateUIControls();










}

function Detalle_Consulta_Actividades_Registro_EventoAddInsertRow() {
    if (Detalle_Consulta_Actividades_Registro_EventoinsertRowCurrentIndex < 1)
    {
        Detalle_Consulta_Actividades_Registro_EventoinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Actividad: ""
        ,Tipo_de_Actividad: ""
        ,Especialidad: ""
        ,Imparte: ""
        ,Fecha: ""
        ,Lugares_disponibles: ""
        ,Horarios_disponibles: ""
        ,Ubicacion: ""

    }
}

function Detalle_Consulta_Actividades_Registro_EventofnClickAddRow() {
    Detalle_Consulta_Actividades_Registro_EventocountRowsChecked++;
    Detalle_Consulta_Actividades_Registro_EventoTable.fnAddData(Detalle_Consulta_Actividades_Registro_EventoAddInsertRow(), true);
    Detalle_Consulta_Actividades_Registro_EventoTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_Consulta_Actividades_Registro_EventoGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_Consulta_Actividades_Registro_EventoGrid tbody tr:nth-of-type(' + (Detalle_Consulta_Actividades_Registro_EventoinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Consulta_Actividades_Registro_Evento("Detalle_Consulta_Actividades_Registro_Evento_", "_" + Detalle_Consulta_Actividades_Registro_EventoinsertRowCurrentIndex);
}

function Detalle_Consulta_Actividades_Registro_EventoClearGridData() {
    Detalle_Consulta_Actividades_Registro_EventoData = [];
    Detalle_Consulta_Actividades_Registro_EventodeletedItem = [];
    Detalle_Consulta_Actividades_Registro_EventoDataMain = [];
    Detalle_Consulta_Actividades_Registro_EventoDataMainPages = [];
    Detalle_Consulta_Actividades_Registro_EventonewItemCount = 0;
    Detalle_Consulta_Actividades_Registro_EventomaxItemIndex = 0;
    $("#Detalle_Consulta_Actividades_Registro_EventoGrid").DataTable().clear();
    $("#Detalle_Consulta_Actividades_Registro_EventoGrid").DataTable().destroy();
}

//Used to Get Registro en Evento Information
function GetDetalle_Consulta_Actividades_Registro_Evento() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Consulta_Actividades_Registro_EventoData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Consulta_Actividades_Registro_EventoData[i].Folio);

        form_data.append('[' + i + '].Actividad', Detalle_Consulta_Actividades_Registro_EventoData[i].Actividad);
        form_data.append('[' + i + '].Tipo_de_Actividad', Detalle_Consulta_Actividades_Registro_EventoData[i].Tipo_de_Actividad);
        form_data.append('[' + i + '].Especialidad', Detalle_Consulta_Actividades_Registro_EventoData[i].Especialidad);
        form_data.append('[' + i + '].Imparte', Detalle_Consulta_Actividades_Registro_EventoData[i].Imparte);
        form_data.append('[' + i + '].Fecha', Detalle_Consulta_Actividades_Registro_EventoData[i].Fecha);
        form_data.append('[' + i + '].Lugares_disponibles', Detalle_Consulta_Actividades_Registro_EventoData[i].Lugares_disponibles);
        form_data.append('[' + i + '].Horarios_disponibles', Detalle_Consulta_Actividades_Registro_EventoData[i].Horarios_disponibles);
        form_data.append('[' + i + '].Ubicacion', Detalle_Consulta_Actividades_Registro_EventoData[i].Ubicacion);

        form_data.append('[' + i + '].Removed', Detalle_Consulta_Actividades_Registro_EventoData[i].Removed);
    }
    return form_data;
}
function Detalle_Consulta_Actividades_Registro_EventoInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Consulta_Actividades_Registro_Evento("Detalle_Consulta_Actividades_Registro_EventoTable", rowIndex)) {
    var prevData = Detalle_Consulta_Actividades_Registro_EventoTable.fnGetData(rowIndex);
    var data = Detalle_Consulta_Actividades_Registro_EventoTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Actividad: $('#Detalle_Consulta_Actividades_Registro_EventoActividad').val()
        ,Tipo_de_Actividad: $('#Detalle_Consulta_Actividades_Registro_EventoTipo_de_Actividad').val()
        ,Especialidad: $('#Detalle_Consulta_Actividades_Registro_EventoEspecialidad').val()
        ,Imparte: $('#Detalle_Consulta_Actividades_Registro_EventoImparte').val()
        ,Fecha: $('#Detalle_Consulta_Actividades_Registro_EventoFecha').val()
        ,Lugares_disponibles: $('#Detalle_Consulta_Actividades_Registro_EventoLugares_disponibles').val()

        ,Horarios_disponibles: $('#Detalle_Consulta_Actividades_Registro_EventoHorarios_disponibles').val()
        ,Ubicacion: $('#Detalle_Consulta_Actividades_Registro_EventoUbicacion').val()

    }

    Detalle_Consulta_Actividades_Registro_EventoTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Consulta_Actividades_Registro_EventorowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Consulta_Actividades_Registro_Evento-form').modal({ show: false });
    $('#AddDetalle_Consulta_Actividades_Registro_Evento-form').modal('hide');
    Detalle_Consulta_Actividades_Registro_EventoEditRow(rowIndex);
    Detalle_Consulta_Actividades_Registro_EventoInsertRow(rowIndex);
    //}
}
function Detalle_Consulta_Actividades_Registro_EventoRemoveAddRow(rowIndex) {
    Detalle_Consulta_Actividades_Registro_EventoTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Consulta_Actividades_Registro_Evento MultiRow
//Begin Declarations for Foreigns fields for Detalle_Registro_en_Actividad_Evento MultiRow
var Detalle_Registro_en_Actividad_EventocountRowsChecked = 0;

function GetDetalle_Registro_en_Actividad_Evento_Detalle_Actividades_EventoName(Id) {
    for (var i = 0; i < Detalle_Registro_en_Actividad_Evento_Detalle_Actividades_EventoItems.length; i++) {
        if (Detalle_Registro_en_Actividad_Evento_Detalle_Actividades_EventoItems[i].Folio == Id) {
            return Detalle_Registro_en_Actividad_Evento_Detalle_Actividades_EventoItems[i].Nombre_de_la_Actividad;
        }
    }
    return "";
}

function GetDetalle_Registro_en_Actividad_Evento_Detalle_Actividades_EventoDropDown() {
    var Detalle_Registro_en_Actividad_Evento_Detalle_Actividades_EventoDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Registro_en_Actividad_Evento_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Registro_en_Actividad_Evento_Detalle_Actividades_EventoDropdown);
    if(Detalle_Registro_en_Actividad_Evento_Detalle_Actividades_EventoItems != null)
    {
       for (var i = 0; i < Detalle_Registro_en_Actividad_Evento_Detalle_Actividades_EventoItems.length; i++) {
           $('<option />', { value: Detalle_Registro_en_Actividad_Evento_Detalle_Actividades_EventoItems[i].Folio, text:    Detalle_Registro_en_Actividad_Evento_Detalle_Actividades_EventoItems[i].Nombre_de_la_Actividad }).appendTo(Detalle_Registro_en_Actividad_Evento_Detalle_Actividades_EventoDropdown);
       }
    }
    return Detalle_Registro_en_Actividad_Evento_Detalle_Actividades_EventoDropdown;
}








function GetDetalle_Registro_en_Actividad_Evento_Parentescos_EmpleadosName(Id) {
    for (var i = 0; i < Detalle_Registro_en_Actividad_Evento_Parentescos_EmpleadosItems.length; i++) {
        if (Detalle_Registro_en_Actividad_Evento_Parentescos_EmpleadosItems[i].Folio == Id) {
            return Detalle_Registro_en_Actividad_Evento_Parentescos_EmpleadosItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Registro_en_Actividad_Evento_Parentescos_EmpleadosDropDown() {
    var Detalle_Registro_en_Actividad_Evento_Parentescos_EmpleadosDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Registro_en_Actividad_Evento_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Registro_en_Actividad_Evento_Parentescos_EmpleadosDropdown);
    if(Detalle_Registro_en_Actividad_Evento_Parentescos_EmpleadosItems != null)
    {
       for (var i = 0; i < Detalle_Registro_en_Actividad_Evento_Parentescos_EmpleadosItems.length; i++) {
           $('<option />', { value: Detalle_Registro_en_Actividad_Evento_Parentescos_EmpleadosItems[i].Folio, text:    Detalle_Registro_en_Actividad_Evento_Parentescos_EmpleadosItems[i].Descripcion }).appendTo(Detalle_Registro_en_Actividad_Evento_Parentescos_EmpleadosDropdown);
       }
    }
    return Detalle_Registro_en_Actividad_Evento_Parentescos_EmpleadosDropdown;
}
function GetDetalle_Registro_en_Actividad_Evento_SexoName(Id) {
    for (var i = 0; i < Detalle_Registro_en_Actividad_Evento_SexoItems.length; i++) {
        if (Detalle_Registro_en_Actividad_Evento_SexoItems[i].Clave == Id) {
            return Detalle_Registro_en_Actividad_Evento_SexoItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Registro_en_Actividad_Evento_SexoDropDown() {
    var Detalle_Registro_en_Actividad_Evento_SexoDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Registro_en_Actividad_Evento_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Registro_en_Actividad_Evento_SexoDropdown);
    if(Detalle_Registro_en_Actividad_Evento_SexoItems != null)
    {
       for (var i = 0; i < Detalle_Registro_en_Actividad_Evento_SexoItems.length; i++) {
           $('<option />', { value: Detalle_Registro_en_Actividad_Evento_SexoItems[i].Clave, text:    Detalle_Registro_en_Actividad_Evento_SexoItems[i].Descripcion }).appendTo(Detalle_Registro_en_Actividad_Evento_SexoDropdown);
       }
    }
    return Detalle_Registro_en_Actividad_Evento_SexoDropdown;
}

function GetDetalle_Registro_en_Actividad_Evento_Estatus_Reservaciones_ActividadName(Id) {
    for (var i = 0; i < Detalle_Registro_en_Actividad_Evento_Estatus_Reservaciones_ActividadItems.length; i++) {
        if (Detalle_Registro_en_Actividad_Evento_Estatus_Reservaciones_ActividadItems[i].Folio == Id) {
            return Detalle_Registro_en_Actividad_Evento_Estatus_Reservaciones_ActividadItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Registro_en_Actividad_Evento_Estatus_Reservaciones_ActividadDropDown() {
    var Detalle_Registro_en_Actividad_Evento_Estatus_Reservaciones_ActividadDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Registro_en_Actividad_Evento_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Registro_en_Actividad_Evento_Estatus_Reservaciones_ActividadDropdown);
    if(Detalle_Registro_en_Actividad_Evento_Estatus_Reservaciones_ActividadItems != null)
    {
       for (var i = 0; i < Detalle_Registro_en_Actividad_Evento_Estatus_Reservaciones_ActividadItems.length; i++) {
           $('<option />', { value: Detalle_Registro_en_Actividad_Evento_Estatus_Reservaciones_ActividadItems[i].Folio, text:    Detalle_Registro_en_Actividad_Evento_Estatus_Reservaciones_ActividadItems[i].Descripcion }).appendTo(Detalle_Registro_en_Actividad_Evento_Estatus_Reservaciones_ActividadDropdown);
       }
    }
    return Detalle_Registro_en_Actividad_Evento_Estatus_Reservaciones_ActividadDropdown;
}



function GetInsertDetalle_Registro_en_Actividad_EventoRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $(GetDetalle_Registro_en_Actividad_Evento_Detalle_Actividades_EventoDropDown()).addClass('Detalle_Registro_en_Actividad_Evento_Actividad Actividad').attr('id', 'Detalle_Registro_en_Actividad_Evento_Actividad_' + index).attr('data-field', 'Actividad').after($.parseHTML(addNew('Detalle_Registro_en_Actividad_Evento', 'Detalle_Actividades_Evento', 'Actividad', 258801)));
    columnData[1] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Registro_en_Actividad_Evento_Fecha Fecha').attr('id', 'Detalle_Registro_en_Actividad_Evento_Fecha_' + index).attr('data-field', 'Fecha');
    columnData[2] = $($.parseHTML(inputData)).addClass('Detalle_Registro_en_Actividad_Evento_Horario Horario').attr('id', 'Detalle_Registro_en_Actividad_Evento_Horario_' + index).attr('data-field', 'Horario');
    columnData[3] = $($.parseHTML(GetGridCheckBox())).addClass('Detalle_Registro_en_Actividad_Evento_Es_para_un_familiar Es_para_un_familiar').attr('id', 'Detalle_Registro_en_Actividad_Evento_Es_para_un_familiar_' + index).attr('data-field', 'Es_para_un_familiar');
    columnData[4] = $($.parseHTML(inputData)).addClass('Detalle_Registro_en_Actividad_Evento_Numero_de_Empleado Numero_de_Empleado').attr('id', 'Detalle_Registro_en_Actividad_Evento_Numero_de_Empleado_' + index).attr('data-field', 'Numero_de_Empleado');
    columnData[5] = $($.parseHTML(inputData)).addClass('Detalle_Registro_en_Actividad_Evento_Nombres Nombres').attr('id', 'Detalle_Registro_en_Actividad_Evento_Nombres_' + index).attr('data-field', 'Nombres');
    columnData[6] = $($.parseHTML(inputData)).addClass('Detalle_Registro_en_Actividad_Evento_Apellido_Paterno Apellido_Paterno').attr('id', 'Detalle_Registro_en_Actividad_Evento_Apellido_Paterno_' + index).attr('data-field', 'Apellido_Paterno');
    columnData[7] = $($.parseHTML(inputData)).addClass('Detalle_Registro_en_Actividad_Evento_Apellido_Materno Apellido_Materno').attr('id', 'Detalle_Registro_en_Actividad_Evento_Apellido_Materno_' + index).attr('data-field', 'Apellido_Materno');
    columnData[8] = $($.parseHTML(inputData)).addClass('Detalle_Registro_en_Actividad_Evento_Nombre_Completo Nombre_Completo').attr('id', 'Detalle_Registro_en_Actividad_Evento_Nombre_Completo_' + index).attr('data-field', 'Nombre_Completo');
    columnData[9] = $(GetDetalle_Registro_en_Actividad_Evento_Parentescos_EmpleadosDropDown()).addClass('Detalle_Registro_en_Actividad_Evento_Parentesco Parentesco').attr('id', 'Detalle_Registro_en_Actividad_Evento_Parentesco_' + index).attr('data-field', 'Parentesco').after($.parseHTML(addNew('Detalle_Registro_en_Actividad_Evento', 'Parentescos_Empleados', 'Parentesco', 258810)));
    columnData[10] = $(GetDetalle_Registro_en_Actividad_Evento_SexoDropDown()).addClass('Detalle_Registro_en_Actividad_Evento_Sexo Sexo').attr('id', 'Detalle_Registro_en_Actividad_Evento_Sexo_' + index).attr('data-field', 'Sexo').after($.parseHTML(addNew('Detalle_Registro_en_Actividad_Evento', 'Sexo', 'Sexo', 258811)));
    columnData[11] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Registro_en_Actividad_Evento_Fecha_de_nacimiento Fecha_de_nacimiento').attr('id', 'Detalle_Registro_en_Actividad_Evento_Fecha_de_nacimiento_' + index).attr('data-field', 'Fecha_de_nacimiento');
    columnData[12] = $(GetDetalle_Registro_en_Actividad_Evento_Estatus_Reservaciones_ActividadDropDown()).addClass('Detalle_Registro_en_Actividad_Evento_Estatus_de_la_Reservacion Estatus_de_la_Reservacion').attr('id', 'Detalle_Registro_en_Actividad_Evento_Estatus_de_la_Reservacion_' + index).attr('data-field', 'Estatus_de_la_Reservacion').after($.parseHTML(addNew('Detalle_Registro_en_Actividad_Evento', 'Estatus_Reservaciones_Actividad', 'Estatus_de_la_Reservacion', 258813)));
    columnData[13] = $($.parseHTML(inputData)).addClass('Detalle_Registro_en_Actividad_Evento_Codigo_Reservacion Codigo_Reservacion').attr('id', 'Detalle_Registro_en_Actividad_Evento_Codigo_Reservacion_' + index).attr('data-field', 'Codigo_Reservacion');


    initiateUIControls();
    return columnData;
}

function Detalle_Registro_en_Actividad_EventoInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Registro_en_Actividad_Evento("Detalle_Registro_en_Actividad_Evento_", "_" + rowIndex)) {
    var iPage = Detalle_Registro_en_Actividad_EventoTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Registro_en_Actividad_Evento';
    var prevData = Detalle_Registro_en_Actividad_EventoTable.fnGetData(rowIndex);
    var data = Detalle_Registro_en_Actividad_EventoTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Actividad:  data.childNodes[counter++].childNodes[0].value
        ,Fecha:  data.childNodes[counter++].childNodes[0].value
        ,Horario:  data.childNodes[counter++].childNodes[0].value
        ,Es_para_un_familiar: $(data.childNodes[counter++].childNodes[2]).is(':checked')
        ,Numero_de_Empleado:  data.childNodes[counter++].childNodes[0].value
        ,Nombres:  data.childNodes[counter++].childNodes[0].value
        ,Apellido_Paterno:  data.childNodes[counter++].childNodes[0].value
        ,Apellido_Materno:  data.childNodes[counter++].childNodes[0].value
        ,Nombre_Completo:  data.childNodes[counter++].childNodes[0].value
        ,Parentesco:  data.childNodes[counter++].childNodes[0].value
        ,Sexo:  data.childNodes[counter++].childNodes[0].value
        ,Fecha_de_nacimiento:  data.childNodes[counter++].childNodes[0].value
        ,Estatus_de_la_Reservacion:  data.childNodes[counter++].childNodes[0].value
        ,Codigo_Reservacion:  data.childNodes[counter++].childNodes[0].value

    }
    Detalle_Registro_en_Actividad_EventoTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Registro_en_Actividad_EventorowCreationGrid(data, newData, rowIndex);
    Detalle_Registro_en_Actividad_EventoTable.fnPageChange(iPage);
    Detalle_Registro_en_Actividad_EventocountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Registro_en_Actividad_Evento("Detalle_Registro_en_Actividad_Evento_", "_" + rowIndex);
  }
}

function Detalle_Registro_en_Actividad_EventoCancelRow(rowIndex) {
    var prevData = Detalle_Registro_en_Actividad_EventoTable.fnGetData(rowIndex);
    var data = Detalle_Registro_en_Actividad_EventoTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Registro_en_Actividad_EventoTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Registro_en_Actividad_EventorowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Registro_en_Actividad_EventoGrid(Detalle_Registro_en_Actividad_EventoTable.fnGetData());
    Detalle_Registro_en_Actividad_EventocountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Registro_en_Actividad_EventoFromDataTable() {
    var Detalle_Registro_en_Actividad_EventoData = [];
    var gridData = Detalle_Registro_en_Actividad_EventoTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Registro_en_Actividad_EventoData.push({
                Folio: gridData[i].Folio

                ,Actividad: gridData[i].Actividad
                ,Fecha: gridData[i].Fecha
                ,Horario: gridData[i].Horario
                ,Es_para_un_familiar: gridData[i].Es_para_un_familiar
                ,Numero_de_Empleado: gridData[i].Numero_de_Empleado
                ,Nombres: gridData[i].Nombres
                ,Apellido_Paterno: gridData[i].Apellido_Paterno
                ,Apellido_Materno: gridData[i].Apellido_Materno
                ,Nombre_Completo: gridData[i].Nombre_Completo
                ,Parentesco: gridData[i].Parentesco
                ,Sexo: gridData[i].Sexo
                ,Fecha_de_nacimiento: gridData[i].Fecha_de_nacimiento
                ,Estatus_de_la_Reservacion: gridData[i].Estatus_de_la_Reservacion
                ,Codigo_Reservacion: gridData[i].Codigo_Reservacion

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Registro_en_Actividad_EventoData.length; i++) {
        if (removedDetalle_Registro_en_Actividad_EventoData[i] != null && removedDetalle_Registro_en_Actividad_EventoData[i].Folio > 0)
            Detalle_Registro_en_Actividad_EventoData.push({
                Folio: removedDetalle_Registro_en_Actividad_EventoData[i].Folio

                ,Actividad: removedDetalle_Registro_en_Actividad_EventoData[i].Actividad
                ,Fecha: removedDetalle_Registro_en_Actividad_EventoData[i].Fecha
                ,Horario: removedDetalle_Registro_en_Actividad_EventoData[i].Horario
                ,Es_para_un_familiar: removedDetalle_Registro_en_Actividad_EventoData[i].Es_para_un_familiar
                ,Numero_de_Empleado: removedDetalle_Registro_en_Actividad_EventoData[i].Numero_de_Empleado
                ,Nombres: removedDetalle_Registro_en_Actividad_EventoData[i].Nombres
                ,Apellido_Paterno: removedDetalle_Registro_en_Actividad_EventoData[i].Apellido_Paterno
                ,Apellido_Materno: removedDetalle_Registro_en_Actividad_EventoData[i].Apellido_Materno
                ,Nombre_Completo: removedDetalle_Registro_en_Actividad_EventoData[i].Nombre_Completo
                ,Parentesco: removedDetalle_Registro_en_Actividad_EventoData[i].Parentesco
                ,Sexo: removedDetalle_Registro_en_Actividad_EventoData[i].Sexo
                ,Fecha_de_nacimiento: removedDetalle_Registro_en_Actividad_EventoData[i].Fecha_de_nacimiento
                ,Estatus_de_la_Reservacion: removedDetalle_Registro_en_Actividad_EventoData[i].Estatus_de_la_Reservacion
                ,Codigo_Reservacion: removedDetalle_Registro_en_Actividad_EventoData[i].Codigo_Reservacion

                , Removed: true
            });
    }	

    return Detalle_Registro_en_Actividad_EventoData;
}

function Detalle_Registro_en_Actividad_EventoEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Registro_en_Actividad_EventoTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Registro_en_Actividad_EventocountRowsChecked++;
    var Detalle_Registro_en_Actividad_EventoRowElement = "Detalle_Registro_en_Actividad_Evento_" + rowIndex.toString();
    var prevData = Detalle_Registro_en_Actividad_EventoTable.fnGetData(rowIndexTable );
    var row = Detalle_Registro_en_Actividad_EventoTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Registro_en_Actividad_Evento_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Registro_en_Actividad_EventoGetUpdateRowControls(prevData, "Detalle_Registro_en_Actividad_Evento_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Registro_en_Actividad_EventoRowElement + "')){ Detalle_Registro_en_Actividad_EventoInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_Registro_en_Actividad_EventoCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Registro_en_Actividad_EventoGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Registro_en_Actividad_EventoGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_Registro_en_Actividad_EventoValidation();
    initiateUIControls();
    $('.Detalle_Registro_en_Actividad_Evento' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Registro_en_Actividad_Evento(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Registro_en_Actividad_EventofnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Registro_en_Actividad_EventoTable.fnGetData().length;
    Detalle_Registro_en_Actividad_EventofnClickAddRow();
    GetAddDetalle_Registro_en_Actividad_EventoPopup(currentRowIndex, 0);
}

function Detalle_Registro_en_Actividad_EventoEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Registro_en_Actividad_EventoTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Registro_en_Actividad_EventoRowElement = "Detalle_Registro_en_Actividad_Evento_" + rowIndex.toString();
    var prevData = Detalle_Registro_en_Actividad_EventoTable.fnGetData(rowIndexTable);
    GetAddDetalle_Registro_en_Actividad_EventoPopup(rowIndex, 1, prevData.Folio);

    $('#Detalle_Registro_en_Actividad_EventoActividad').val(prevData.Actividad);
    $('#Detalle_Registro_en_Actividad_EventoFecha').val(prevData.Fecha);
    $('#Detalle_Registro_en_Actividad_EventoHorario').val(prevData.Horario);
    $('#Detalle_Registro_en_Actividad_EventoEs_para_un_familiar').prop('checked', prevData.Es_para_un_familiar);
    $('#Detalle_Registro_en_Actividad_EventoNumero_de_Empleado').val(prevData.Numero_de_Empleado);
    $('#Detalle_Registro_en_Actividad_EventoNombres').val(prevData.Nombres);
    $('#Detalle_Registro_en_Actividad_EventoApellido_Paterno').val(prevData.Apellido_Paterno);
    $('#Detalle_Registro_en_Actividad_EventoApellido_Materno').val(prevData.Apellido_Materno);
    $('#Detalle_Registro_en_Actividad_EventoNombre_Completo').val(prevData.Nombre_Completo);
    $('#Detalle_Registro_en_Actividad_EventoParentesco').val(prevData.Parentesco);
    $('#Detalle_Registro_en_Actividad_EventoSexo').val(prevData.Sexo);
    $('#Detalle_Registro_en_Actividad_EventoFecha_de_nacimiento').val(prevData.Fecha_de_nacimiento);
    $('#Detalle_Registro_en_Actividad_EventoEstatus_de_la_Reservacion').val(prevData.Estatus_de_la_Reservacion);
    $('#Detalle_Registro_en_Actividad_EventoCodigo_Reservacion').val(prevData.Codigo_Reservacion);

    initiateUIControls();
















}

function Detalle_Registro_en_Actividad_EventoAddInsertRow() {
    if (Detalle_Registro_en_Actividad_EventoinsertRowCurrentIndex < 1)
    {
        Detalle_Registro_en_Actividad_EventoinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Actividad: ""
        ,Fecha: ""
        ,Horario: ""
        ,Es_para_un_familiar: ""
        ,Numero_de_Empleado: ""
        ,Nombres: ""
        ,Apellido_Paterno: ""
        ,Apellido_Materno: ""
        ,Nombre_Completo: ""
        ,Parentesco: ""
        ,Sexo: ""
        ,Fecha_de_nacimiento: ""
        ,Estatus_de_la_Reservacion: ""
        ,Codigo_Reservacion: ""

    }
}

function Detalle_Registro_en_Actividad_EventofnClickAddRow() {
    Detalle_Registro_en_Actividad_EventocountRowsChecked++;
    Detalle_Registro_en_Actividad_EventoTable.fnAddData(Detalle_Registro_en_Actividad_EventoAddInsertRow(), true);
    Detalle_Registro_en_Actividad_EventoTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_Registro_en_Actividad_EventoGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_Registro_en_Actividad_EventoGrid tbody tr:nth-of-type(' + (Detalle_Registro_en_Actividad_EventoinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Registro_en_Actividad_Evento("Detalle_Registro_en_Actividad_Evento_", "_" + Detalle_Registro_en_Actividad_EventoinsertRowCurrentIndex);
}

function Detalle_Registro_en_Actividad_EventoClearGridData() {
    Detalle_Registro_en_Actividad_EventoData = [];
    Detalle_Registro_en_Actividad_EventodeletedItem = [];
    Detalle_Registro_en_Actividad_EventoDataMain = [];
    Detalle_Registro_en_Actividad_EventoDataMainPages = [];
    Detalle_Registro_en_Actividad_EventonewItemCount = 0;
    Detalle_Registro_en_Actividad_EventomaxItemIndex = 0;
    $("#Detalle_Registro_en_Actividad_EventoGrid").DataTable().clear();
    $("#Detalle_Registro_en_Actividad_EventoGrid").DataTable().destroy();
}

//Used to Get Registro en Evento Information
function GetDetalle_Registro_en_Actividad_Evento() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Registro_en_Actividad_EventoData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Registro_en_Actividad_EventoData[i].Folio);

        form_data.append('[' + i + '].Actividad', Detalle_Registro_en_Actividad_EventoData[i].Actividad);
        form_data.append('[' + i + '].Fecha', Detalle_Registro_en_Actividad_EventoData[i].Fecha);
        form_data.append('[' + i + '].Horario', Detalle_Registro_en_Actividad_EventoData[i].Horario);
        form_data.append('[' + i + '].Es_para_un_familiar', Detalle_Registro_en_Actividad_EventoData[i].Es_para_un_familiar);
        form_data.append('[' + i + '].Numero_de_Empleado', Detalle_Registro_en_Actividad_EventoData[i].Numero_de_Empleado);
        form_data.append('[' + i + '].Nombres', Detalle_Registro_en_Actividad_EventoData[i].Nombres);
        form_data.append('[' + i + '].Apellido_Paterno', Detalle_Registro_en_Actividad_EventoData[i].Apellido_Paterno);
        form_data.append('[' + i + '].Apellido_Materno', Detalle_Registro_en_Actividad_EventoData[i].Apellido_Materno);
        form_data.append('[' + i + '].Nombre_Completo', Detalle_Registro_en_Actividad_EventoData[i].Nombre_Completo);
        form_data.append('[' + i + '].Parentesco', Detalle_Registro_en_Actividad_EventoData[i].Parentesco);
        form_data.append('[' + i + '].Sexo', Detalle_Registro_en_Actividad_EventoData[i].Sexo);
        form_data.append('[' + i + '].Fecha_de_nacimiento', Detalle_Registro_en_Actividad_EventoData[i].Fecha_de_nacimiento);
        form_data.append('[' + i + '].Estatus_de_la_Reservacion', Detalle_Registro_en_Actividad_EventoData[i].Estatus_de_la_Reservacion);
        form_data.append('[' + i + '].Codigo_Reservacion', Detalle_Registro_en_Actividad_EventoData[i].Codigo_Reservacion);

        form_data.append('[' + i + '].Removed', Detalle_Registro_en_Actividad_EventoData[i].Removed);
    }
    return form_data;
}
function Detalle_Registro_en_Actividad_EventoInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Registro_en_Actividad_Evento("Detalle_Registro_en_Actividad_EventoTable", rowIndex)) {
    var prevData = Detalle_Registro_en_Actividad_EventoTable.fnGetData(rowIndex);
    var data = Detalle_Registro_en_Actividad_EventoTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Actividad: $('#Detalle_Registro_en_Actividad_EventoActividad').val()
        ,Fecha: $('#Detalle_Registro_en_Actividad_EventoFecha').val()
        ,Horario: $('#Detalle_Registro_en_Actividad_EventoHorario').val()
        ,Es_para_un_familiar: $('#Detalle_Registro_en_Actividad_EventoEs_para_un_familiar').is(':checked')
        ,Numero_de_Empleado: $('#Detalle_Registro_en_Actividad_EventoNumero_de_Empleado').val()
        ,Nombres: $('#Detalle_Registro_en_Actividad_EventoNombres').val()
        ,Apellido_Paterno: $('#Detalle_Registro_en_Actividad_EventoApellido_Paterno').val()
        ,Apellido_Materno: $('#Detalle_Registro_en_Actividad_EventoApellido_Materno').val()
        ,Nombre_Completo: $('#Detalle_Registro_en_Actividad_EventoNombre_Completo').val()
        ,Parentesco: $('#Detalle_Registro_en_Actividad_EventoParentesco').val()
        ,Sexo: $('#Detalle_Registro_en_Actividad_EventoSexo').val()
        ,Fecha_de_nacimiento: $('#Detalle_Registro_en_Actividad_EventoFecha_de_nacimiento').val()
        ,Estatus_de_la_Reservacion: $('#Detalle_Registro_en_Actividad_EventoEstatus_de_la_Reservacion').val()
        ,Codigo_Reservacion: $('#Detalle_Registro_en_Actividad_EventoCodigo_Reservacion').val()

    }

    Detalle_Registro_en_Actividad_EventoTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Registro_en_Actividad_EventorowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Registro_en_Actividad_Evento-form').modal({ show: false });
    $('#AddDetalle_Registro_en_Actividad_Evento-form').modal('hide');
    Detalle_Registro_en_Actividad_EventoEditRow(rowIndex);
    Detalle_Registro_en_Actividad_EventoInsertRow(rowIndex);
    //}
}
function Detalle_Registro_en_Actividad_EventoRemoveAddRow(rowIndex) {
    Detalle_Registro_en_Actividad_EventoTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Registro_en_Actividad_Evento MultiRow


$(function () {
    function Detalle_Consulta_Actividades_Registro_EventoinitializeMainArray(totalCount) {
        if (Detalle_Consulta_Actividades_Registro_EventoDataMain.length != totalCount && !Detalle_Consulta_Actividades_Registro_EventoDataMainInitialized) {
            Detalle_Consulta_Actividades_Registro_EventoDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Consulta_Actividades_Registro_EventoDataMain[i] = null;
            }
        }
    }
    function Detalle_Consulta_Actividades_Registro_EventoremoveFromMainArray() {
        for (var j = 0; j < Detalle_Consulta_Actividades_Registro_EventodeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Consulta_Actividades_Registro_EventoDataMain.length; i++) {
                if (Detalle_Consulta_Actividades_Registro_EventoDataMain[i] != null && Detalle_Consulta_Actividades_Registro_EventoDataMain[i].Id == Detalle_Consulta_Actividades_Registro_EventodeletedItem[j]) {
                    hDetalle_Consulta_Actividades_Registro_EventoDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Consulta_Actividades_Registro_EventocopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Consulta_Actividades_Registro_EventoDataMain.length; i++) {
            data[i] = Detalle_Consulta_Actividades_Registro_EventoDataMain[i];

        }
        return data;
    }
    function Detalle_Consulta_Actividades_Registro_EventogetNewResult() {
        var newData = copyMainDetalle_Consulta_Actividades_Registro_EventoArray();

        for (var i = 0; i < Detalle_Consulta_Actividades_Registro_EventoData.length; i++) {
            if (Detalle_Consulta_Actividades_Registro_EventoData[i].Removed == null || Detalle_Consulta_Actividades_Registro_EventoData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Consulta_Actividades_Registro_EventoData[i]);
            }
        }
        return newData;
    }
    function Detalle_Consulta_Actividades_Registro_EventopushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Consulta_Actividades_Registro_EventoDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Consulta_Actividades_Registro_EventoDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Detalle_Registro_en_Actividad_EventoinitializeMainArray(totalCount) {
        if (Detalle_Registro_en_Actividad_EventoDataMain.length != totalCount && !Detalle_Registro_en_Actividad_EventoDataMainInitialized) {
            Detalle_Registro_en_Actividad_EventoDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Registro_en_Actividad_EventoDataMain[i] = null;
            }
        }
    }
    function Detalle_Registro_en_Actividad_EventoremoveFromMainArray() {
        for (var j = 0; j < Detalle_Registro_en_Actividad_EventodeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Registro_en_Actividad_EventoDataMain.length; i++) {
                if (Detalle_Registro_en_Actividad_EventoDataMain[i] != null && Detalle_Registro_en_Actividad_EventoDataMain[i].Id == Detalle_Registro_en_Actividad_EventodeletedItem[j]) {
                    hDetalle_Registro_en_Actividad_EventoDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Registro_en_Actividad_EventocopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Registro_en_Actividad_EventoDataMain.length; i++) {
            data[i] = Detalle_Registro_en_Actividad_EventoDataMain[i];

        }
        return data;
    }
    function Detalle_Registro_en_Actividad_EventogetNewResult() {
        var newData = copyMainDetalle_Registro_en_Actividad_EventoArray();

        for (var i = 0; i < Detalle_Registro_en_Actividad_EventoData.length; i++) {
            if (Detalle_Registro_en_Actividad_EventoData[i].Removed == null || Detalle_Registro_en_Actividad_EventoData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Registro_en_Actividad_EventoData[i]);
            }
        }
        return newData;
    }
    function Detalle_Registro_en_Actividad_EventopushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Registro_en_Actividad_EventoDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Registro_en_Actividad_EventoDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }

});

//Grid GetAutocomplete

//Grid GetAutocomplete



function getDropdown(elementKey) {
    var labelSelect = $("#Registro_en_Evento_cmbLabelSelect").val();
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
    $('#CreateRegistro_en_Evento')[0].reset();
    ClearFormControls();
    $("#FolioId").val("0");
                Detalle_Consulta_Actividades_Registro_EventoClearGridData();
                Detalle_Registro_en_Actividad_EventoClearGridData();

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreateRegistro_en_Evento').trigger('reset');
    $('#CreateRegistro_en_Evento').find(':input').each(function () {
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
    var $myForm = $('#CreateRegistro_en_Evento');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    if (Detalle_Consulta_Actividades_Registro_EventocountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Consulta_Actividades_Registro_Evento();
        return false;
    }
    if (Detalle_Registro_en_Actividad_EventocountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Registro_en_Actividad_Evento();
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblFolio").text("0");
}
$(document).ready(function () {
    $("form#CreateRegistro_en_Evento").submit(function (e) {
        e.preventDefault();
        return false;
    });
	$("form#CreateRegistro_en_Evento").on('click', '#Registro_en_EventoCancelar', function () {
	  if (!isPartial) {
        Registro_en_EventoBackToGrid();
	  } else {
            window.close();
      }
    });
	$("form#CreateRegistro_en_Evento").on('click', '#Registro_en_EventoGuardar', function () {
		$('#Registro_en_EventoGuardar').attr('disabled', true);
		$('#Registro_en_EventoGuardar').unbind()
        if (EjecutarValidacionesAntesDeGuardar() && CheckValidation()) {
				if (!SendRegistro_en_EventoData(function () {
					EjecutarValidacionesDespuesDeGuardar();
					if (!isPartial)
						Registro_en_EventoBackToGrid();
					else {						
						if (!isMR)
							window.opener.RefreshCatalog('Registro_en_Evento', nameAttribute);
						else {
							var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
							if(!control.hasClass('AutoComplete'))
							{
							if (control.attr("data-isfilter") == "true") {
									eval(GetReglaFilter(control,  $(window.opener.document.getElementById('ObjectId')).val()));								    
								}
								else 
								{
									eval('window.opener.Get' + nameMR + '_Registro_en_EventoItem()');
									var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
									control.html(eval('window.opener.Get' + nameMR + '_Registro_en_EventoDropDown().get(0)').innerHTML);  
								}								
							}
						}
						window.close();						
						}
				})) {
					$('#Registro_en_EventoGuardar').removeAttr('disabled');
					$('#Registro_en_EventoGuardar').bind()
				}
		}
		else {
			$('#Registro_en_EventoGuardar').removeAttr('disabled');
			$('#Registro_en_EventoGuardar').bind()
		}
    });
	$("form#CreateRegistro_en_Evento").on('click', '#Registro_en_EventoGuardarYNuevo', function () {	
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation()) {
				SendRegistro_en_EventoData(function () {
					ClearControls();
					ClearAttachmentsDiv();
					ResetClaveLabel();
	                getDetalle_Consulta_Actividades_Registro_EventoData();
                getDetalle_Registro_en_Actividad_EventoData();

					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Registro_en_Evento', nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_Registro_en_EventoItem()');                           
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
                            control.html(eval('window.opener.Get' + nameMR + '_Registro_en_EventoDropDown().get(0)').innerHTML);   
					    }	
					}						
					EjecutarValidacionesDespuesDeGuardar();				
			setIsNew();
			EjecutarValidacionesAlComienzo();
				});
			}
		}		
    });
    $("form#CreateRegistro_en_Evento").on('click', '#Registro_en_EventoGuardarYCopia', function () {
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendRegistro_en_EventoData(function (currentId) {
					$("#FolioId").val("0");
	                Detalle_Consulta_Actividades_Registro_EventoClearGridData();
                Detalle_Registro_en_Actividad_EventoClearGridData();

					ResetClaveLabel();
					$("#ReferenceFolio").val(currentId);
	                getDetalle_Consulta_Actividades_Registro_EventoData();
                getDetalle_Registro_en_Actividad_EventoData();

					EjecutarValidacionesDespuesDeGuardar();		
					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Registro_en_Evento',nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_Registro_en_EventoItem()');                          
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);						
							control.html(eval('window.opener.Get' + nameMR + '_Registro_en_EventoDropDown().get(0)').innerHTML);                          
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



var Registro_en_EventoisdisplayBusinessPropery = false;
Registro_en_EventoDisplayBusinessRuleButtons(Registro_en_EventoisdisplayBusinessPropery);
function Registro_en_EventoDisplayBusinessRule() {
    if (!Registro_en_EventoisdisplayBusinessPropery) {
        $('#CreateRegistro_en_Evento').find('.col-sm-8').each(function () {
			var div =$(this); 
			if ($(this).find('.input-group').length >0)
				div  =  $(this).find('.input-group').first().hasClass('date')? $(this): $(this).find('.input-group').first();	
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = div.data('field-id');
            var fieldName = div.data('field-name');
            var attribute = div.data('attribute');
            mainElementAttributes += '<div class="Registro_en_EventodisplayBusinessPropery"><button onclick="Registro_en_EventoGetBusinessRule()" type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#Registro_en_EventoBusinessRule-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.Registro_en_EventodisplayBusinessPropery').remove();
    }
    Registro_en_EventoDisplayBusinessRuleButtons(!Registro_en_EventoisdisplayBusinessPropery);
    Registro_en_EventoisdisplayBusinessPropery = (Registro_en_EventoisdisplayBusinessPropery ? false : true);
}
function Registro_en_EventoDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}

