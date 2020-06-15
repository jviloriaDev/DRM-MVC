

//Begin Declarations for Foreigns fields for Detalle_Actividades_Evento MultiRow
var Detalle_Actividades_EventocountRowsChecked = 0;

function GetDetalle_Actividades_Evento_Tipos_de_ActividadesName(Id) {
    for (var i = 0; i < Detalle_Actividades_Evento_Tipos_de_ActividadesItems.length; i++) {
        if (Detalle_Actividades_Evento_Tipos_de_ActividadesItems[i].Folio == Id) {
            return Detalle_Actividades_Evento_Tipos_de_ActividadesItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Actividades_Evento_Tipos_de_ActividadesDropDown() {
    var Detalle_Actividades_Evento_Tipos_de_ActividadesDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Actividades_Evento_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Actividades_Evento_Tipos_de_ActividadesDropdown);
    if(Detalle_Actividades_Evento_Tipos_de_ActividadesItems != null)
    {
       for (var i = 0; i < Detalle_Actividades_Evento_Tipos_de_ActividadesItems.length; i++) {
           $('<option />', { value: Detalle_Actividades_Evento_Tipos_de_ActividadesItems[i].Folio, text:    Detalle_Actividades_Evento_Tipos_de_ActividadesItems[i].Descripcion }).appendTo(Detalle_Actividades_Evento_Tipos_de_ActividadesDropdown);
       }
    }
    return Detalle_Actividades_Evento_Tipos_de_ActividadesDropdown;
}
function GetDetalle_Actividades_Evento_EspecialidadesName(Id) {
    for (var i = 0; i < Detalle_Actividades_Evento_EspecialidadesItems.length; i++) {
        if (Detalle_Actividades_Evento_EspecialidadesItems[i].Clave == Id) {
            return Detalle_Actividades_Evento_EspecialidadesItems[i].Especialidad;
        }
    }
    return "";
}

function GetDetalle_Actividades_Evento_EspecialidadesDropDown() {
    var Detalle_Actividades_Evento_EspecialidadesDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Actividades_Evento_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Actividades_Evento_EspecialidadesDropdown);
    if(Detalle_Actividades_Evento_EspecialidadesItems != null)
    {
       for (var i = 0; i < Detalle_Actividades_Evento_EspecialidadesItems.length; i++) {
           $('<option />', { value: Detalle_Actividades_Evento_EspecialidadesItems[i].Clave, text:    Detalle_Actividades_Evento_EspecialidadesItems[i].Especialidad }).appendTo(Detalle_Actividades_Evento_EspecialidadesDropdown);
       }
    }
    return Detalle_Actividades_Evento_EspecialidadesDropdown;
}


function GetDetalle_Actividades_Evento_Spartan_UserName(Id) {
    for (var i = 0; i < Detalle_Actividades_Evento_Spartan_UserItems.length; i++) {
        if (Detalle_Actividades_Evento_Spartan_UserItems[i].Id_User == Id) {
            return Detalle_Actividades_Evento_Spartan_UserItems[i].Name;
        }
    }
    return "";
}

function GetDetalle_Actividades_Evento_Spartan_UserDropDown() {
    var Detalle_Actividades_Evento_Spartan_UserDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Actividades_Evento_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Actividades_Evento_Spartan_UserDropdown);
    if(Detalle_Actividades_Evento_Spartan_UserItems != null)
    {
       for (var i = 0; i < Detalle_Actividades_Evento_Spartan_UserItems.length; i++) {
           $('<option />', { value: Detalle_Actividades_Evento_Spartan_UserItems[i].Id_User, text:    Detalle_Actividades_Evento_Spartan_UserItems[i].Name }).appendTo(Detalle_Actividades_Evento_Spartan_UserDropdown);
       }
    }
    return Detalle_Actividades_Evento_Spartan_UserDropdown;
}









function GetDetalle_Actividades_Evento_Ubicaciones_Eventos_EmpresaName(Id) {
    for (var i = 0; i < Detalle_Actividades_Evento_Ubicaciones_Eventos_EmpresaItems.length; i++) {
        if (Detalle_Actividades_Evento_Ubicaciones_Eventos_EmpresaItems[i].Folio == Id) {
            return Detalle_Actividades_Evento_Ubicaciones_Eventos_EmpresaItems[i].Nombre;
        }
    }
    return "";
}

function GetDetalle_Actividades_Evento_Ubicaciones_Eventos_EmpresaDropDown() {
    var Detalle_Actividades_Evento_Ubicaciones_Eventos_EmpresaDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Actividades_Evento_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Actividades_Evento_Ubicaciones_Eventos_EmpresaDropdown);
    if(Detalle_Actividades_Evento_Ubicaciones_Eventos_EmpresaItems != null)
    {
       for (var i = 0; i < Detalle_Actividades_Evento_Ubicaciones_Eventos_EmpresaItems.length; i++) {
           $('<option />', { value: Detalle_Actividades_Evento_Ubicaciones_Eventos_EmpresaItems[i].Folio, text:    Detalle_Actividades_Evento_Ubicaciones_Eventos_EmpresaItems[i].Nombre }).appendTo(Detalle_Actividades_Evento_Ubicaciones_Eventos_EmpresaDropdown);
       }
    }
    return Detalle_Actividades_Evento_Ubicaciones_Eventos_EmpresaDropdown;
}
function GetDetalle_Actividades_Evento_Estatus_Actividades_EventoName(Id) {
    for (var i = 0; i < Detalle_Actividades_Evento_Estatus_Actividades_EventoItems.length; i++) {
        if (Detalle_Actividades_Evento_Estatus_Actividades_EventoItems[i].Folio == Id) {
            return Detalle_Actividades_Evento_Estatus_Actividades_EventoItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Actividades_Evento_Estatus_Actividades_EventoDropDown() {
    var Detalle_Actividades_Evento_Estatus_Actividades_EventoDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Actividades_Evento_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Actividades_Evento_Estatus_Actividades_EventoDropdown);
    if(Detalle_Actividades_Evento_Estatus_Actividades_EventoItems != null)
    {
       for (var i = 0; i < Detalle_Actividades_Evento_Estatus_Actividades_EventoItems.length; i++) {
           $('<option />', { value: Detalle_Actividades_Evento_Estatus_Actividades_EventoItems[i].Folio, text:    Detalle_Actividades_Evento_Estatus_Actividades_EventoItems[i].Descripcion }).appendTo(Detalle_Actividades_Evento_Estatus_Actividades_EventoDropdown);
       }
    }
    return Detalle_Actividades_Evento_Estatus_Actividades_EventoDropdown;
}


function GetInsertDetalle_Actividades_EventoRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $(GetDetalle_Actividades_Evento_Tipos_de_ActividadesDropDown()).addClass('Detalle_Actividades_Evento_Tipo_de_Actividad Tipo_de_Actividad').attr('id', 'Detalle_Actividades_Evento_Tipo_de_Actividad_' + index).attr('data-field', 'Tipo_de_Actividad').after($.parseHTML(addNew('Detalle_Actividades_Evento', 'Tipos_de_Actividades', 'Tipo_de_Actividad', 258707)));
    columnData[1] = $(GetDetalle_Actividades_Evento_EspecialidadesDropDown()).addClass('Detalle_Actividades_Evento_Especialidad Especialidad').attr('id', 'Detalle_Actividades_Evento_Especialidad_' + index).attr('data-field', 'Especialidad').after($.parseHTML(addNew('Detalle_Actividades_Evento', 'Especialidades', 'Especialidad', 258708)));
    columnData[2] = $($.parseHTML(inputData)).addClass('Detalle_Actividades_Evento_Nombre_de_la_Actividad Nombre_de_la_Actividad').attr('id', 'Detalle_Actividades_Evento_Nombre_de_la_Actividad_' + index).attr('data-field', 'Nombre_de_la_Actividad');
    columnData[3] = $($.parseHTML(inputData)).addClass('Detalle_Actividades_Evento_Descripcion Descripcion').attr('id', 'Detalle_Actividades_Evento_Descripcion_' + index).attr('data-field', 'Descripcion');
    columnData[4] = $(GetDetalle_Actividades_Evento_Spartan_UserDropDown()).addClass('Detalle_Actividades_Evento_Quien_imparte Quien_imparte').attr('id', 'Detalle_Actividades_Evento_Quien_imparte_' + index).attr('data-field', 'Quien_imparte').after($.parseHTML(addNew('Detalle_Actividades_Evento', 'Spartan_User', 'Quien_imparte', 258711)));
    columnData[5] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Actividades_Evento_Dia Dia').attr('id', 'Detalle_Actividades_Evento_Dia_' + index).attr('data-field', 'Dia');
    columnData[6] = $($.parseHTML(GetGridTimePicker())).addClass('Detalle_Actividades_Evento_Hora_inicio Hora_inicio').attr('id', 'Detalle_Actividades_Evento_Hora_inicio_' + index).attr('data-field', 'Hora_inicio');
    columnData[7] = $($.parseHTML(GetGridTimePicker())).addClass('Detalle_Actividades_Evento_Hora_fin Hora_fin').attr('id', 'Detalle_Actividades_Evento_Hora_fin_' + index).attr('data-field', 'Hora_fin');
    columnData[8] = $($.parseHTML(GetGridCheckBox())).addClass('Detalle_Actividades_Evento_Tiene_receso Tiene_receso').attr('id', 'Detalle_Actividades_Evento_Tiene_receso_' + index).attr('data-field', 'Tiene_receso');
    columnData[9] = $($.parseHTML(GetGridTimePicker())).addClass('Detalle_Actividades_Evento_Hora_inicio_receso Hora_inicio_receso').attr('id', 'Detalle_Actividades_Evento_Hora_inicio_receso_' + index).attr('data-field', 'Hora_inicio_receso');
    columnData[10] = $($.parseHTML(GetGridTimePicker())).addClass('Detalle_Actividades_Evento_Hora_fin_receso Hora_fin_receso').attr('id', 'Detalle_Actividades_Evento_Hora_fin_receso_' + index).attr('data-field', 'Hora_fin_receso');
    columnData[11] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Actividades_Evento_Duracion_maxima_por_paciente_mins Duracion_maxima_por_paciente_mins').attr('id', 'Detalle_Actividades_Evento_Duracion_maxima_por_paciente_mins_' + index).attr('data-field', 'Duracion_maxima_por_paciente_mins');
    columnData[12] = $($.parseHTML(GetGridCheckBox())).addClass('Detalle_Actividades_Evento_Cupo_limitado Cupo_limitado').attr('id', 'Detalle_Actividades_Evento_Cupo_limitado_' + index).attr('data-field', 'Cupo_limitado');
    columnData[13] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Actividades_Evento_Cupo_maximo Cupo_maximo').attr('id', 'Detalle_Actividades_Evento_Cupo_maximo_' + index).attr('data-field', 'Cupo_maximo');
    columnData[14] = $(GetDetalle_Actividades_Evento_Ubicaciones_Eventos_EmpresaDropDown()).addClass('Detalle_Actividades_Evento_Ubicacion Ubicacion').attr('id', 'Detalle_Actividades_Evento_Ubicacion_' + index).attr('data-field', 'Ubicacion').after($.parseHTML(addNew('Detalle_Actividades_Evento', 'Ubicaciones_Eventos_Empresa', 'Ubicacion', 258718)));
    columnData[15] = $(GetDetalle_Actividades_Evento_Estatus_Actividades_EventoDropDown()).addClass('Detalle_Actividades_Evento_Estatus_de_la_Actividad Estatus_de_la_Actividad').attr('id', 'Detalle_Actividades_Evento_Estatus_de_la_Actividad_' + index).attr('data-field', 'Estatus_de_la_Actividad').after($.parseHTML(addNew('Detalle_Actividades_Evento', 'Estatus_Actividades_Evento', 'Estatus_de_la_Actividad', 258722)));


    initiateUIControls();
    return columnData;
}

function Detalle_Actividades_EventoInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Actividades_Evento("Detalle_Actividades_Evento_", "_" + rowIndex)) {
    var iPage = Detalle_Actividades_EventoTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Actividades_Evento';
    var prevData = Detalle_Actividades_EventoTable.fnGetData(rowIndex);
    var data = Detalle_Actividades_EventoTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Tipo_de_Actividad:  data.childNodes[counter++].childNodes[0].value
        ,Especialidad:  data.childNodes[counter++].childNodes[0].value
        ,Nombre_de_la_Actividad:  data.childNodes[counter++].childNodes[0].value
        ,Descripcion:  data.childNodes[counter++].childNodes[0].value
        ,Quien_imparte:  data.childNodes[counter++].childNodes[0].value
        ,Dia:  data.childNodes[counter++].childNodes[0].value
        ,Hora_inicio:  data.childNodes[counter++].childNodes[0].value
        ,Hora_fin:  data.childNodes[counter++].childNodes[0].value
        ,Tiene_receso: $(data.childNodes[counter++].childNodes[2]).is(':checked')
        ,Hora_inicio_receso:  data.childNodes[counter++].childNodes[0].value
        ,Hora_fin_receso:  data.childNodes[counter++].childNodes[0].value
        ,Duracion_maxima_por_paciente_mins: data.childNodes[counter++].childNodes[0].value
        ,Cupo_limitado: $(data.childNodes[counter++].childNodes[2]).is(':checked')
        ,Cupo_maximo: data.childNodes[counter++].childNodes[0].value
        ,Ubicacion:  data.childNodes[counter++].childNodes[0].value
        ,Estatus_de_la_Actividad:  data.childNodes[counter++].childNodes[0].value

    }
    Detalle_Actividades_EventoTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Actividades_EventorowCreationGrid(data, newData, rowIndex);
    Detalle_Actividades_EventoTable.fnPageChange(iPage);
    Detalle_Actividades_EventocountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Actividades_Evento("Detalle_Actividades_Evento_", "_" + rowIndex);
  }
}

function Detalle_Actividades_EventoCancelRow(rowIndex) {
    var prevData = Detalle_Actividades_EventoTable.fnGetData(rowIndex);
    var data = Detalle_Actividades_EventoTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Actividades_EventoTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Actividades_EventorowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Actividades_EventoGrid(Detalle_Actividades_EventoTable.fnGetData());
    Detalle_Actividades_EventocountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Actividades_EventoFromDataTable() {
    var Detalle_Actividades_EventoData = [];
    var gridData = Detalle_Actividades_EventoTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Actividades_EventoData.push({
                Folio: gridData[i].Folio

                ,Tipo_de_Actividad: gridData[i].Tipo_de_Actividad
                ,Especialidad: gridData[i].Especialidad
                ,Nombre_de_la_Actividad: gridData[i].Nombre_de_la_Actividad
                ,Descripcion: gridData[i].Descripcion
                ,Quien_imparte: gridData[i].Quien_imparte
                ,Dia: gridData[i].Dia
                ,Hora_inicio: gridData[i].Hora_inicio
                ,Hora_fin: gridData[i].Hora_fin
                ,Tiene_receso: gridData[i].Tiene_receso
                ,Hora_inicio_receso: gridData[i].Hora_inicio_receso
                ,Hora_fin_receso: gridData[i].Hora_fin_receso
                ,Duracion_maxima_por_paciente_mins: gridData[i].Duracion_maxima_por_paciente_mins
                ,Cupo_limitado: gridData[i].Cupo_limitado
                ,Cupo_maximo: gridData[i].Cupo_maximo
                ,Ubicacion: gridData[i].Ubicacion
                ,Estatus_de_la_Actividad: gridData[i].Estatus_de_la_Actividad

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Actividades_EventoData.length; i++) {
        if (removedDetalle_Actividades_EventoData[i] != null && removedDetalle_Actividades_EventoData[i].Folio > 0)
            Detalle_Actividades_EventoData.push({
                Folio: removedDetalle_Actividades_EventoData[i].Folio

                ,Tipo_de_Actividad: removedDetalle_Actividades_EventoData[i].Tipo_de_Actividad
                ,Especialidad: removedDetalle_Actividades_EventoData[i].Especialidad
                ,Nombre_de_la_Actividad: removedDetalle_Actividades_EventoData[i].Nombre_de_la_Actividad
                ,Descripcion: removedDetalle_Actividades_EventoData[i].Descripcion
                ,Quien_imparte: removedDetalle_Actividades_EventoData[i].Quien_imparte
                ,Dia: removedDetalle_Actividades_EventoData[i].Dia
                ,Hora_inicio: removedDetalle_Actividades_EventoData[i].Hora_inicio
                ,Hora_fin: removedDetalle_Actividades_EventoData[i].Hora_fin
                ,Tiene_receso: removedDetalle_Actividades_EventoData[i].Tiene_receso
                ,Hora_inicio_receso: removedDetalle_Actividades_EventoData[i].Hora_inicio_receso
                ,Hora_fin_receso: removedDetalle_Actividades_EventoData[i].Hora_fin_receso
                ,Duracion_maxima_por_paciente_mins: removedDetalle_Actividades_EventoData[i].Duracion_maxima_por_paciente_mins
                ,Cupo_limitado: removedDetalle_Actividades_EventoData[i].Cupo_limitado
                ,Cupo_maximo: removedDetalle_Actividades_EventoData[i].Cupo_maximo
                ,Ubicacion: removedDetalle_Actividades_EventoData[i].Ubicacion
                ,Estatus_de_la_Actividad: removedDetalle_Actividades_EventoData[i].Estatus_de_la_Actividad

                , Removed: true
            });
    }	

    return Detalle_Actividades_EventoData;
}

function Detalle_Actividades_EventoEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Actividades_EventoTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Actividades_EventocountRowsChecked++;
    var Detalle_Actividades_EventoRowElement = "Detalle_Actividades_Evento_" + rowIndex.toString();
    var prevData = Detalle_Actividades_EventoTable.fnGetData(rowIndexTable );
    var row = Detalle_Actividades_EventoTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Actividades_Evento_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Actividades_EventoGetUpdateRowControls(prevData, "Detalle_Actividades_Evento_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Actividades_EventoRowElement + "')){ Detalle_Actividades_EventoInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_Actividades_EventoCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Actividades_EventoGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Actividades_EventoGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_Actividades_EventoValidation();
    initiateUIControls();
    $('.Detalle_Actividades_Evento' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Actividades_Evento(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Actividades_EventofnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Actividades_EventoTable.fnGetData().length;
    Detalle_Actividades_EventofnClickAddRow();
    GetAddDetalle_Actividades_EventoPopup(currentRowIndex, 0);
}

function Detalle_Actividades_EventoEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Actividades_EventoTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Actividades_EventoRowElement = "Detalle_Actividades_Evento_" + rowIndex.toString();
    var prevData = Detalle_Actividades_EventoTable.fnGetData(rowIndexTable);
    GetAddDetalle_Actividades_EventoPopup(rowIndex, 1, prevData.Folio);

    $('#Detalle_Actividades_EventoTipo_de_Actividad').val(prevData.Tipo_de_Actividad);
    $('#Detalle_Actividades_EventoEspecialidad').val(prevData.Especialidad);
    $('#Detalle_Actividades_EventoNombre_de_la_Actividad').val(prevData.Nombre_de_la_Actividad);
    $('#Detalle_Actividades_EventoDescripcion').val(prevData.Descripcion);
    $('#Detalle_Actividades_EventoQuien_imparte').val(prevData.Quien_imparte);
    $('#Detalle_Actividades_EventoDia').val(prevData.Dia);
    $('#Detalle_Actividades_EventoHora_inicio').val(prevData.Hora_inicio);
    $('#Detalle_Actividades_EventoHora_fin').val(prevData.Hora_fin);
    $('#Detalle_Actividades_EventoTiene_receso').prop('checked', prevData.Tiene_receso);
    $('#Detalle_Actividades_EventoHora_inicio_receso').val(prevData.Hora_inicio_receso);
    $('#Detalle_Actividades_EventoHora_fin_receso').val(prevData.Hora_fin_receso);
    $('#Detalle_Actividades_EventoDuracion_maxima_por_paciente_mins').val(prevData.Duracion_maxima_por_paciente_mins);
    $('#Detalle_Actividades_EventoCupo_limitado').prop('checked', prevData.Cupo_limitado);
    $('#Detalle_Actividades_EventoCupo_maximo').val(prevData.Cupo_maximo);
    $('#Detalle_Actividades_EventoUbicacion').val(prevData.Ubicacion);
    $('#Detalle_Actividades_EventoEstatus_de_la_Actividad').val(prevData.Estatus_de_la_Actividad);

    initiateUIControls();


















}

function Detalle_Actividades_EventoAddInsertRow() {
    if (Detalle_Actividades_EventoinsertRowCurrentIndex < 1)
    {
        Detalle_Actividades_EventoinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Tipo_de_Actividad: ""
        ,Especialidad: ""
        ,Nombre_de_la_Actividad: ""
        ,Descripcion: ""
        ,Quien_imparte: ""
        ,Dia: ""
        ,Hora_inicio: ""
        ,Hora_fin: ""
        ,Tiene_receso: ""
        ,Hora_inicio_receso: ""
        ,Hora_fin_receso: ""
        ,Duracion_maxima_por_paciente_mins: ""
        ,Cupo_limitado: ""
        ,Cupo_maximo: ""
        ,Ubicacion: ""
        ,Estatus_de_la_Actividad: ""

    }
}

function Detalle_Actividades_EventofnClickAddRow() {
    Detalle_Actividades_EventocountRowsChecked++;
    Detalle_Actividades_EventoTable.fnAddData(Detalle_Actividades_EventoAddInsertRow(), true);
    Detalle_Actividades_EventoTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_Actividades_EventoGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_Actividades_EventoGrid tbody tr:nth-of-type(' + (Detalle_Actividades_EventoinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Actividades_Evento("Detalle_Actividades_Evento_", "_" + Detalle_Actividades_EventoinsertRowCurrentIndex);
}

function Detalle_Actividades_EventoClearGridData() {
    Detalle_Actividades_EventoData = [];
    Detalle_Actividades_EventodeletedItem = [];
    Detalle_Actividades_EventoDataMain = [];
    Detalle_Actividades_EventoDataMainPages = [];
    Detalle_Actividades_EventonewItemCount = 0;
    Detalle_Actividades_EventomaxItemIndex = 0;
    $("#Detalle_Actividades_EventoGrid").DataTable().clear();
    $("#Detalle_Actividades_EventoGrid").DataTable().destroy();
}

//Used to Get Eventos Information
function GetDetalle_Actividades_Evento() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Actividades_EventoData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Actividades_EventoData[i].Folio);

        form_data.append('[' + i + '].Tipo_de_Actividad', Detalle_Actividades_EventoData[i].Tipo_de_Actividad);
        form_data.append('[' + i + '].Especialidad', Detalle_Actividades_EventoData[i].Especialidad);
        form_data.append('[' + i + '].Nombre_de_la_Actividad', Detalle_Actividades_EventoData[i].Nombre_de_la_Actividad);
        form_data.append('[' + i + '].Descripcion', Detalle_Actividades_EventoData[i].Descripcion);
        form_data.append('[' + i + '].Quien_imparte', Detalle_Actividades_EventoData[i].Quien_imparte);
        form_data.append('[' + i + '].Dia', Detalle_Actividades_EventoData[i].Dia);
        form_data.append('[' + i + '].Hora_inicio', Detalle_Actividades_EventoData[i].Hora_inicio);
        form_data.append('[' + i + '].Hora_fin', Detalle_Actividades_EventoData[i].Hora_fin);
        form_data.append('[' + i + '].Tiene_receso', Detalle_Actividades_EventoData[i].Tiene_receso);
        form_data.append('[' + i + '].Hora_inicio_receso', Detalle_Actividades_EventoData[i].Hora_inicio_receso);
        form_data.append('[' + i + '].Hora_fin_receso', Detalle_Actividades_EventoData[i].Hora_fin_receso);
        form_data.append('[' + i + '].Duracion_maxima_por_paciente_mins', Detalle_Actividades_EventoData[i].Duracion_maxima_por_paciente_mins);
        form_data.append('[' + i + '].Cupo_limitado', Detalle_Actividades_EventoData[i].Cupo_limitado);
        form_data.append('[' + i + '].Cupo_maximo', Detalle_Actividades_EventoData[i].Cupo_maximo);
        form_data.append('[' + i + '].Ubicacion', Detalle_Actividades_EventoData[i].Ubicacion);
        form_data.append('[' + i + '].Estatus_de_la_Actividad', Detalle_Actividades_EventoData[i].Estatus_de_la_Actividad);

        form_data.append('[' + i + '].Removed', Detalle_Actividades_EventoData[i].Removed);
    }
    return form_data;
}
function Detalle_Actividades_EventoInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Actividades_Evento("Detalle_Actividades_EventoTable", rowIndex)) {
    var prevData = Detalle_Actividades_EventoTable.fnGetData(rowIndex);
    var data = Detalle_Actividades_EventoTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Tipo_de_Actividad: $('#Detalle_Actividades_EventoTipo_de_Actividad').val()
        ,Especialidad: $('#Detalle_Actividades_EventoEspecialidad').val()
        ,Nombre_de_la_Actividad: $('#Detalle_Actividades_EventoNombre_de_la_Actividad').val()
        ,Descripcion: $('#Detalle_Actividades_EventoDescripcion').val()
        ,Quien_imparte: $('#Detalle_Actividades_EventoQuien_imparte').val()
        ,Dia: $('#Detalle_Actividades_EventoDia').val()
        ,Hora_inicio: $('#Detalle_Actividades_EventoHora_inicio').val()
        ,Hora_fin: $('#Detalle_Actividades_EventoHora_fin').val()
        ,Tiene_receso: $('#Detalle_Actividades_EventoTiene_receso').is(':checked')
        ,Hora_inicio_receso: $('#Detalle_Actividades_EventoHora_inicio_receso').val()
        ,Hora_fin_receso: $('#Detalle_Actividades_EventoHora_fin_receso').val()
        ,Duracion_maxima_por_paciente_mins: $('#Detalle_Actividades_EventoDuracion_maxima_por_paciente_mins').val()

        ,Cupo_limitado: $('#Detalle_Actividades_EventoCupo_limitado').is(':checked')
        ,Cupo_maximo: $('#Detalle_Actividades_EventoCupo_maximo').val()

        ,Ubicacion: $('#Detalle_Actividades_EventoUbicacion').val()
        ,Estatus_de_la_Actividad: $('#Detalle_Actividades_EventoEstatus_de_la_Actividad').val()

    }

    Detalle_Actividades_EventoTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Actividades_EventorowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Actividades_Evento-form').modal({ show: false });
    $('#AddDetalle_Actividades_Evento-form').modal('hide');
    Detalle_Actividades_EventoEditRow(rowIndex);
    Detalle_Actividades_EventoInsertRow(rowIndex);
    //}
}
function Detalle_Actividades_EventoRemoveAddRow(rowIndex) {
    Detalle_Actividades_EventoTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Actividades_Evento MultiRow


$(function () {
    function Detalle_Actividades_EventoinitializeMainArray(totalCount) {
        if (Detalle_Actividades_EventoDataMain.length != totalCount && !Detalle_Actividades_EventoDataMainInitialized) {
            Detalle_Actividades_EventoDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Actividades_EventoDataMain[i] = null;
            }
        }
    }
    function Detalle_Actividades_EventoremoveFromMainArray() {
        for (var j = 0; j < Detalle_Actividades_EventodeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Actividades_EventoDataMain.length; i++) {
                if (Detalle_Actividades_EventoDataMain[i] != null && Detalle_Actividades_EventoDataMain[i].Id == Detalle_Actividades_EventodeletedItem[j]) {
                    hDetalle_Actividades_EventoDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Actividades_EventocopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Actividades_EventoDataMain.length; i++) {
            data[i] = Detalle_Actividades_EventoDataMain[i];

        }
        return data;
    }
    function Detalle_Actividades_EventogetNewResult() {
        var newData = copyMainDetalle_Actividades_EventoArray();

        for (var i = 0; i < Detalle_Actividades_EventoData.length; i++) {
            if (Detalle_Actividades_EventoData[i].Removed == null || Detalle_Actividades_EventoData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Actividades_EventoData[i]);
            }
        }
        return newData;
    }
    function Detalle_Actividades_EventopushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Actividades_EventoDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Actividades_EventoDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }

});

//Grid GetAutocomplete



function getDropdown(elementKey) {
    var labelSelect = $("#Eventos_cmbLabelSelect").val();
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
    $('#CreateEventos')[0].reset();
    ClearFormControls();
    $("#FolioId").val("0");
                Detalle_Actividades_EventoClearGridData();

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreateEventos').trigger('reset');
    $('#CreateEventos').find(':input').each(function () {
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
    var $myForm = $('#CreateEventos');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    if (Detalle_Actividades_EventocountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Actividades_Evento();
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblFolio").text("0");
}
$(document).ready(function () {
    $("form#CreateEventos").submit(function (e) {
        e.preventDefault();
        return false;
    });
	$("form#CreateEventos").on('click', '#EventosCancelar', function () {
	  if (!isPartial) {
        EventosBackToGrid();
	  } else {
            window.close();
      }
    });
	$("form#CreateEventos").on('click', '#EventosGuardar', function () {
		$('#EventosGuardar').attr('disabled', true);
		$('#EventosGuardar').unbind()
        if (EjecutarValidacionesAntesDeGuardar() && CheckValidation()) {
				if (!SendEventosData(function () {
					EjecutarValidacionesDespuesDeGuardar();
					if (!isPartial)
						EventosBackToGrid();
					else {						
						if (!isMR)
							window.opener.RefreshCatalog('Eventos', nameAttribute);
						else {
							var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
							if(!control.hasClass('AutoComplete'))
							{
							if (control.attr("data-isfilter") == "true") {
									eval(GetReglaFilter(control,  $(window.opener.document.getElementById('ObjectId')).val()));								    
								}
								else 
								{
									eval('window.opener.Get' + nameMR + '_EventosItem()');
									var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
									control.html(eval('window.opener.Get' + nameMR + '_EventosDropDown().get(0)').innerHTML);  
								}								
							}
						}
						window.close();						
						}
				})) {
					$('#EventosGuardar').removeAttr('disabled');
					$('#EventosGuardar').bind()
				}
		}
		else {
			$('#EventosGuardar').removeAttr('disabled');
			$('#EventosGuardar').bind()
		}
    });
	$("form#CreateEventos").on('click', '#EventosGuardarYNuevo', function () {	
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation()) {
				SendEventosData(function () {
					ClearControls();
					ClearAttachmentsDiv();
					ResetClaveLabel();
	                getDetalle_Actividades_EventoData();

					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Eventos', nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_EventosItem()');                           
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
                            control.html(eval('window.opener.Get' + nameMR + '_EventosDropDown().get(0)').innerHTML);   
					    }	
					}						
					EjecutarValidacionesDespuesDeGuardar();				
			setIsNew();
			EjecutarValidacionesAlComienzo();
				});
			}
		}		
    });
    $("form#CreateEventos").on('click', '#EventosGuardarYCopia', function () {
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendEventosData(function (currentId) {
					$("#FolioId").val("0");
	                Detalle_Actividades_EventoClearGridData();

					ResetClaveLabel();
					$("#ReferenceFolio").val(currentId);
	                getDetalle_Actividades_EventoData();

					EjecutarValidacionesDespuesDeGuardar();		
					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Eventos',nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_EventosItem()');                          
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);						
							control.html(eval('window.opener.Get' + nameMR + '_EventosDropDown().get(0)').innerHTML);                          
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



var EventosisdisplayBusinessPropery = false;
EventosDisplayBusinessRuleButtons(EventosisdisplayBusinessPropery);
function EventosDisplayBusinessRule() {
    if (!EventosisdisplayBusinessPropery) {
        $('#CreateEventos').find('.col-sm-8').each(function () {
			var div =$(this); 
			if ($(this).find('.input-group').length >0)
				div  =  $(this).find('.input-group').first().hasClass('date')? $(this): $(this).find('.input-group').first();	
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = div.data('field-id');
            var fieldName = div.data('field-name');
            var attribute = div.data('attribute');
            mainElementAttributes += '<div class="EventosdisplayBusinessPropery"><button onclick="EventosGetBusinessRule()" type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#EventosBusinessRule-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.EventosdisplayBusinessPropery').remove();
    }
    EventosDisplayBusinessRuleButtons(!EventosisdisplayBusinessPropery);
    EventosisdisplayBusinessPropery = (EventosisdisplayBusinessPropery ? false : true);
}
function EventosDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}

