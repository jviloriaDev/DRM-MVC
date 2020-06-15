

//Begin Declarations for Foreigns fields for Detalle_Codigos_de_Referencia_Vendedores MultiRow
var Detalle_Codigos_de_Referencia_VendedorescountRowsChecked = 0;







function GetDetalle_Codigos_de_Referencia_Vendedores_Spartan_UserName(Id) {
    for (var i = 0; i < Detalle_Codigos_de_Referencia_Vendedores_Spartan_UserItems.length; i++) {
        if (Detalle_Codigos_de_Referencia_Vendedores_Spartan_UserItems[i].Id_User == Id) {
            return Detalle_Codigos_de_Referencia_Vendedores_Spartan_UserItems[i].Name;
        }
    }
    return "";
}

function GetDetalle_Codigos_de_Referencia_Vendedores_Spartan_UserDropDown() {
    var Detalle_Codigos_de_Referencia_Vendedores_Spartan_UserDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Codigos_de_Referencia_Vendedores_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Codigos_de_Referencia_Vendedores_Spartan_UserDropdown);
    if(Detalle_Codigos_de_Referencia_Vendedores_Spartan_UserItems != null)
    {
       for (var i = 0; i < Detalle_Codigos_de_Referencia_Vendedores_Spartan_UserItems.length; i++) {
           $('<option />', { value: Detalle_Codigos_de_Referencia_Vendedores_Spartan_UserItems[i].Id_User, text:    Detalle_Codigos_de_Referencia_Vendedores_Spartan_UserItems[i].Name }).appendTo(Detalle_Codigos_de_Referencia_Vendedores_Spartan_UserDropdown);
       }
    }
    return Detalle_Codigos_de_Referencia_Vendedores_Spartan_UserDropdown;
}


function GetDetalle_Codigos_de_Referencia_Vendedores_EstatusName(Id) {
    for (var i = 0; i < Detalle_Codigos_de_Referencia_Vendedores_EstatusItems.length; i++) {
        if (Detalle_Codigos_de_Referencia_Vendedores_EstatusItems[i].Clave == Id) {
            return Detalle_Codigos_de_Referencia_Vendedores_EstatusItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Codigos_de_Referencia_Vendedores_EstatusDropDown() {
    var Detalle_Codigos_de_Referencia_Vendedores_EstatusDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Codigos_de_Referencia_Vendedores_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Codigos_de_Referencia_Vendedores_EstatusDropdown);
    if(Detalle_Codigos_de_Referencia_Vendedores_EstatusItems != null)
    {
       for (var i = 0; i < Detalle_Codigos_de_Referencia_Vendedores_EstatusItems.length; i++) {
           $('<option />', { value: Detalle_Codigos_de_Referencia_Vendedores_EstatusItems[i].Clave, text:    Detalle_Codigos_de_Referencia_Vendedores_EstatusItems[i].Descripcion }).appendTo(Detalle_Codigos_de_Referencia_Vendedores_EstatusDropdown);
       }
    }
    return Detalle_Codigos_de_Referencia_Vendedores_EstatusDropdown;
}


function GetInsertDetalle_Codigos_de_Referencia_VendedoresRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Codigos_de_Referencia_Vendedores_Porcentaje_de_descuento Porcentaje_de_descuento').attr('id', 'Detalle_Codigos_de_Referencia_Vendedores_Porcentaje_de_descuento_' + index).attr('data-field', 'Porcentaje_de_descuento');
    columnData[1] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Codigos_de_Referencia_Vendedores_Fecha_inicio_vigencia Fecha_inicio_vigencia').attr('id', 'Detalle_Codigos_de_Referencia_Vendedores_Fecha_inicio_vigencia_' + index).attr('data-field', 'Fecha_inicio_vigencia');
    columnData[2] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Codigos_de_Referencia_Vendedores_Fecha_fin_vigencia Fecha_fin_vigencia').attr('id', 'Detalle_Codigos_de_Referencia_Vendedores_Fecha_fin_vigencia_' + index).attr('data-field', 'Fecha_fin_vigencia');
    columnData[3] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Codigos_de_Referencia_Vendedores_Cantidad_maxima_de_referenciados Cantidad_maxima_de_referenciados').attr('id', 'Detalle_Codigos_de_Referencia_Vendedores_Cantidad_maxima_de_referenciados_' + index).attr('data-field', 'Cantidad_maxima_de_referenciados');
    columnData[4] = $($.parseHTML(inputData)).addClass('Detalle_Codigos_de_Referencia_Vendedores_Codigo_para_referenciados Codigo_para_referenciados').attr('id', 'Detalle_Codigos_de_Referencia_Vendedores_Codigo_para_referenciados_' + index).attr('data-field', 'Codigo_para_referenciados');
    columnData[5] = $($.parseHTML(GetGridCheckBox())).addClass('Detalle_Codigos_de_Referencia_Vendedores_Autorizado Autorizado').attr('id', 'Detalle_Codigos_de_Referencia_Vendedores_Autorizado_' + index).attr('data-field', 'Autorizado');
    columnData[6] = $(GetDetalle_Codigos_de_Referencia_Vendedores_Spartan_UserDropDown()).addClass('Detalle_Codigos_de_Referencia_Vendedores_Usuario_que_autoriza Usuario_que_autoriza').attr('id', 'Detalle_Codigos_de_Referencia_Vendedores_Usuario_que_autoriza_' + index).attr('data-field', 'Usuario_que_autoriza').after($.parseHTML(addNew('Detalle_Codigos_de_Referencia_Vendedores', 'Spartan_User', 'Usuario_que_autoriza', 259965)));
    columnData[7] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Codigos_de_Referencia_Vendedores_Fecha_de_autorizacion Fecha_de_autorizacion').attr('id', 'Detalle_Codigos_de_Referencia_Vendedores_Fecha_de_autorizacion_' + index).attr('data-field', 'Fecha_de_autorizacion');
    columnData[8] = $($.parseHTML(GetGridTimePicker())).addClass('Detalle_Codigos_de_Referencia_Vendedores_Hora_de_autorizacion Hora_de_autorizacion').attr('id', 'Detalle_Codigos_de_Referencia_Vendedores_Hora_de_autorizacion_' + index).attr('data-field', 'Hora_de_autorizacion');
    columnData[9] = $(GetDetalle_Codigos_de_Referencia_Vendedores_EstatusDropDown()).addClass('Detalle_Codigos_de_Referencia_Vendedores_Estatus Estatus').attr('id', 'Detalle_Codigos_de_Referencia_Vendedores_Estatus_' + index).attr('data-field', 'Estatus').after($.parseHTML(addNew('Detalle_Codigos_de_Referencia_Vendedores', 'Estatus', 'Estatus', 259968)));


    initiateUIControls();
    return columnData;
}

function Detalle_Codigos_de_Referencia_VendedoresInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Codigos_de_Referencia_Vendedores("Detalle_Codigos_de_Referencia_Vendedores_", "_" + rowIndex)) {
    var iPage = Detalle_Codigos_de_Referencia_VendedoresTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Codigos_de_Referencia_Vendedores';
    var prevData = Detalle_Codigos_de_Referencia_VendedoresTable.fnGetData(rowIndex);
    var data = Detalle_Codigos_de_Referencia_VendedoresTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Porcentaje_de_descuento: data.childNodes[counter++].childNodes[0].value
        ,Fecha_inicio_vigencia:  data.childNodes[counter++].childNodes[0].value
        ,Fecha_fin_vigencia:  data.childNodes[counter++].childNodes[0].value
        ,Cantidad_maxima_de_referenciados: data.childNodes[counter++].childNodes[0].value
        ,Codigo_para_referenciados:  data.childNodes[counter++].childNodes[0].value
        ,Autorizado: $(data.childNodes[counter++].childNodes[2]).is(':checked')
        ,Usuario_que_autoriza:  data.childNodes[counter++].childNodes[0].value
        ,Fecha_de_autorizacion:  data.childNodes[counter++].childNodes[0].value
        ,Hora_de_autorizacion:  data.childNodes[counter++].childNodes[0].value
        ,Estatus:  data.childNodes[counter++].childNodes[0].value

    }
    Detalle_Codigos_de_Referencia_VendedoresTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Codigos_de_Referencia_VendedoresrowCreationGrid(data, newData, rowIndex);
    Detalle_Codigos_de_Referencia_VendedoresTable.fnPageChange(iPage);
    Detalle_Codigos_de_Referencia_VendedorescountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Codigos_de_Referencia_Vendedores("Detalle_Codigos_de_Referencia_Vendedores_", "_" + rowIndex);
  }
}

function Detalle_Codigos_de_Referencia_VendedoresCancelRow(rowIndex) {
    var prevData = Detalle_Codigos_de_Referencia_VendedoresTable.fnGetData(rowIndex);
    var data = Detalle_Codigos_de_Referencia_VendedoresTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Codigos_de_Referencia_VendedoresTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Codigos_de_Referencia_VendedoresrowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Codigos_de_Referencia_VendedoresGrid(Detalle_Codigos_de_Referencia_VendedoresTable.fnGetData());
    Detalle_Codigos_de_Referencia_VendedorescountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Codigos_de_Referencia_VendedoresFromDataTable() {
    var Detalle_Codigos_de_Referencia_VendedoresData = [];
    var gridData = Detalle_Codigos_de_Referencia_VendedoresTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Codigos_de_Referencia_VendedoresData.push({
                Folio: gridData[i].Folio

                ,Porcentaje_de_descuento: gridData[i].Porcentaje_de_descuento
                ,Fecha_inicio_vigencia: gridData[i].Fecha_inicio_vigencia
                ,Fecha_fin_vigencia: gridData[i].Fecha_fin_vigencia
                ,Cantidad_maxima_de_referenciados: gridData[i].Cantidad_maxima_de_referenciados
                ,Codigo_para_referenciados: gridData[i].Codigo_para_referenciados
                ,Autorizado: gridData[i].Autorizado
                ,Usuario_que_autoriza: gridData[i].Usuario_que_autoriza
                ,Fecha_de_autorizacion: gridData[i].Fecha_de_autorizacion
                ,Hora_de_autorizacion: gridData[i].Hora_de_autorizacion
                ,Estatus: gridData[i].Estatus

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Codigos_de_Referencia_VendedoresData.length; i++) {
        if (removedDetalle_Codigos_de_Referencia_VendedoresData[i] != null && removedDetalle_Codigos_de_Referencia_VendedoresData[i].Folio > 0)
            Detalle_Codigos_de_Referencia_VendedoresData.push({
                Folio: removedDetalle_Codigos_de_Referencia_VendedoresData[i].Folio

                ,Porcentaje_de_descuento: removedDetalle_Codigos_de_Referencia_VendedoresData[i].Porcentaje_de_descuento
                ,Fecha_inicio_vigencia: removedDetalle_Codigos_de_Referencia_VendedoresData[i].Fecha_inicio_vigencia
                ,Fecha_fin_vigencia: removedDetalle_Codigos_de_Referencia_VendedoresData[i].Fecha_fin_vigencia
                ,Cantidad_maxima_de_referenciados: removedDetalle_Codigos_de_Referencia_VendedoresData[i].Cantidad_maxima_de_referenciados
                ,Codigo_para_referenciados: removedDetalle_Codigos_de_Referencia_VendedoresData[i].Codigo_para_referenciados
                ,Autorizado: removedDetalle_Codigos_de_Referencia_VendedoresData[i].Autorizado
                ,Usuario_que_autoriza: removedDetalle_Codigos_de_Referencia_VendedoresData[i].Usuario_que_autoriza
                ,Fecha_de_autorizacion: removedDetalle_Codigos_de_Referencia_VendedoresData[i].Fecha_de_autorizacion
                ,Hora_de_autorizacion: removedDetalle_Codigos_de_Referencia_VendedoresData[i].Hora_de_autorizacion
                ,Estatus: removedDetalle_Codigos_de_Referencia_VendedoresData[i].Estatus

                , Removed: true
            });
    }	

    return Detalle_Codigos_de_Referencia_VendedoresData;
}

function Detalle_Codigos_de_Referencia_VendedoresEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Codigos_de_Referencia_VendedoresTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Codigos_de_Referencia_VendedorescountRowsChecked++;
    var Detalle_Codigos_de_Referencia_VendedoresRowElement = "Detalle_Codigos_de_Referencia_Vendedores_" + rowIndex.toString();
    var prevData = Detalle_Codigos_de_Referencia_VendedoresTable.fnGetData(rowIndexTable );
    var row = Detalle_Codigos_de_Referencia_VendedoresTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Codigos_de_Referencia_Vendedores_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Codigos_de_Referencia_VendedoresGetUpdateRowControls(prevData, "Detalle_Codigos_de_Referencia_Vendedores_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Codigos_de_Referencia_VendedoresRowElement + "')){ Detalle_Codigos_de_Referencia_VendedoresInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_Codigos_de_Referencia_VendedoresCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Codigos_de_Referencia_VendedoresGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Codigos_de_Referencia_VendedoresGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_Codigos_de_Referencia_VendedoresValidation();
    initiateUIControls();
    $('.Detalle_Codigos_de_Referencia_Vendedores' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Codigos_de_Referencia_Vendedores(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Codigos_de_Referencia_VendedoresfnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Codigos_de_Referencia_VendedoresTable.fnGetData().length;
    Detalle_Codigos_de_Referencia_VendedoresfnClickAddRow();
    GetAddDetalle_Codigos_de_Referencia_VendedoresPopup(currentRowIndex, 0);
}

function Detalle_Codigos_de_Referencia_VendedoresEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Codigos_de_Referencia_VendedoresTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Codigos_de_Referencia_VendedoresRowElement = "Detalle_Codigos_de_Referencia_Vendedores_" + rowIndex.toString();
    var prevData = Detalle_Codigos_de_Referencia_VendedoresTable.fnGetData(rowIndexTable);
    GetAddDetalle_Codigos_de_Referencia_VendedoresPopup(rowIndex, 1, prevData.Folio);

    $('#Detalle_Codigos_de_Referencia_VendedoresPorcentaje_de_descuento').val(prevData.Porcentaje_de_descuento);
    $('#Detalle_Codigos_de_Referencia_VendedoresFecha_inicio_vigencia').val(prevData.Fecha_inicio_vigencia);
    $('#Detalle_Codigos_de_Referencia_VendedoresFecha_fin_vigencia').val(prevData.Fecha_fin_vigencia);
    $('#Detalle_Codigos_de_Referencia_VendedoresCantidad_maxima_de_referenciados').val(prevData.Cantidad_maxima_de_referenciados);
    $('#Detalle_Codigos_de_Referencia_VendedoresCodigo_para_referenciados').val(prevData.Codigo_para_referenciados);
    $('#Detalle_Codigos_de_Referencia_VendedoresAutorizado').prop('checked', prevData.Autorizado);
    $('#Detalle_Codigos_de_Referencia_VendedoresUsuario_que_autoriza').val(prevData.Usuario_que_autoriza);
    $('#Detalle_Codigos_de_Referencia_VendedoresFecha_de_autorizacion').val(prevData.Fecha_de_autorizacion);
    $('#Detalle_Codigos_de_Referencia_VendedoresHora_de_autorizacion').val(prevData.Hora_de_autorizacion);
    $('#Detalle_Codigos_de_Referencia_VendedoresEstatus').val(prevData.Estatus);

    initiateUIControls();












}

function Detalle_Codigos_de_Referencia_VendedoresAddInsertRow() {
    if (Detalle_Codigos_de_Referencia_VendedoresinsertRowCurrentIndex < 1)
    {
        Detalle_Codigos_de_Referencia_VendedoresinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Porcentaje_de_descuento: ""
        ,Fecha_inicio_vigencia: ""
        ,Fecha_fin_vigencia: ""
        ,Cantidad_maxima_de_referenciados: ""
        ,Codigo_para_referenciados: ""
        ,Autorizado: ""
        ,Usuario_que_autoriza: ""
        ,Fecha_de_autorizacion: ""
        ,Hora_de_autorizacion: ""
        ,Estatus: ""

    }
}

function Detalle_Codigos_de_Referencia_VendedoresfnClickAddRow() {
    Detalle_Codigos_de_Referencia_VendedorescountRowsChecked++;
    Detalle_Codigos_de_Referencia_VendedoresTable.fnAddData(Detalle_Codigos_de_Referencia_VendedoresAddInsertRow(), true);
    Detalle_Codigos_de_Referencia_VendedoresTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_Codigos_de_Referencia_VendedoresGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_Codigos_de_Referencia_VendedoresGrid tbody tr:nth-of-type(' + (Detalle_Codigos_de_Referencia_VendedoresinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Codigos_de_Referencia_Vendedores("Detalle_Codigos_de_Referencia_Vendedores_", "_" + Detalle_Codigos_de_Referencia_VendedoresinsertRowCurrentIndex);
}

function Detalle_Codigos_de_Referencia_VendedoresClearGridData() {
    Detalle_Codigos_de_Referencia_VendedoresData = [];
    Detalle_Codigos_de_Referencia_VendedoresdeletedItem = [];
    Detalle_Codigos_de_Referencia_VendedoresDataMain = [];
    Detalle_Codigos_de_Referencia_VendedoresDataMainPages = [];
    Detalle_Codigos_de_Referencia_VendedoresnewItemCount = 0;
    Detalle_Codigos_de_Referencia_VendedoresmaxItemIndex = 0;
    $("#Detalle_Codigos_de_Referencia_VendedoresGrid").DataTable().clear();
    $("#Detalle_Codigos_de_Referencia_VendedoresGrid").DataTable().destroy();
}

//Used to Get Vendedores Information
function GetDetalle_Codigos_de_Referencia_Vendedores() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Codigos_de_Referencia_VendedoresData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Codigos_de_Referencia_VendedoresData[i].Folio);

        form_data.append('[' + i + '].Porcentaje_de_descuento', Detalle_Codigos_de_Referencia_VendedoresData[i].Porcentaje_de_descuento);
        form_data.append('[' + i + '].Fecha_inicio_vigencia', Detalle_Codigos_de_Referencia_VendedoresData[i].Fecha_inicio_vigencia);
        form_data.append('[' + i + '].Fecha_fin_vigencia', Detalle_Codigos_de_Referencia_VendedoresData[i].Fecha_fin_vigencia);
        form_data.append('[' + i + '].Cantidad_maxima_de_referenciados', Detalle_Codigos_de_Referencia_VendedoresData[i].Cantidad_maxima_de_referenciados);
        form_data.append('[' + i + '].Codigo_para_referenciados', Detalle_Codigos_de_Referencia_VendedoresData[i].Codigo_para_referenciados);
        form_data.append('[' + i + '].Autorizado', Detalle_Codigos_de_Referencia_VendedoresData[i].Autorizado);
        form_data.append('[' + i + '].Usuario_que_autoriza', Detalle_Codigos_de_Referencia_VendedoresData[i].Usuario_que_autoriza);
        form_data.append('[' + i + '].Fecha_de_autorizacion', Detalle_Codigos_de_Referencia_VendedoresData[i].Fecha_de_autorizacion);
        form_data.append('[' + i + '].Hora_de_autorizacion', Detalle_Codigos_de_Referencia_VendedoresData[i].Hora_de_autorizacion);
        form_data.append('[' + i + '].Estatus', Detalle_Codigos_de_Referencia_VendedoresData[i].Estatus);

        form_data.append('[' + i + '].Removed', Detalle_Codigos_de_Referencia_VendedoresData[i].Removed);
    }
    return form_data;
}
function Detalle_Codigos_de_Referencia_VendedoresInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Codigos_de_Referencia_Vendedores("Detalle_Codigos_de_Referencia_VendedoresTable", rowIndex)) {
    var prevData = Detalle_Codigos_de_Referencia_VendedoresTable.fnGetData(rowIndex);
    var data = Detalle_Codigos_de_Referencia_VendedoresTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Porcentaje_de_descuento: $('#Detalle_Codigos_de_Referencia_VendedoresPorcentaje_de_descuento').val()

        ,Fecha_inicio_vigencia: $('#Detalle_Codigos_de_Referencia_VendedoresFecha_inicio_vigencia').val()
        ,Fecha_fin_vigencia: $('#Detalle_Codigos_de_Referencia_VendedoresFecha_fin_vigencia').val()
        ,Cantidad_maxima_de_referenciados: $('#Detalle_Codigos_de_Referencia_VendedoresCantidad_maxima_de_referenciados').val()

        ,Codigo_para_referenciados: $('#Detalle_Codigos_de_Referencia_VendedoresCodigo_para_referenciados').val()
        ,Autorizado: $('#Detalle_Codigos_de_Referencia_VendedoresAutorizado').is(':checked')
        ,Usuario_que_autoriza: $('#Detalle_Codigos_de_Referencia_VendedoresUsuario_que_autoriza').val()
        ,Fecha_de_autorizacion: $('#Detalle_Codigos_de_Referencia_VendedoresFecha_de_autorizacion').val()
        ,Hora_de_autorizacion: $('#Detalle_Codigos_de_Referencia_VendedoresHora_de_autorizacion').val()
        ,Estatus: $('#Detalle_Codigos_de_Referencia_VendedoresEstatus').val()

    }

    Detalle_Codigos_de_Referencia_VendedoresTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Codigos_de_Referencia_VendedoresrowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Codigos_de_Referencia_Vendedores-form').modal({ show: false });
    $('#AddDetalle_Codigos_de_Referencia_Vendedores-form').modal('hide');
    Detalle_Codigos_de_Referencia_VendedoresEditRow(rowIndex);
    Detalle_Codigos_de_Referencia_VendedoresInsertRow(rowIndex);
    //}
}
function Detalle_Codigos_de_Referencia_VendedoresRemoveAddRow(rowIndex) {
    Detalle_Codigos_de_Referencia_VendedoresTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Codigos_de_Referencia_Vendedores MultiRow
//Begin Declarations for Foreigns fields for Detalle_Facturacion_Vendedores MultiRow
var Detalle_Facturacion_VendedorescountRowsChecked = 0;







function GetDetalle_Facturacion_Vendedores_Estatus_FacturasName(Id) {
    for (var i = 0; i < Detalle_Facturacion_Vendedores_Estatus_FacturasItems.length; i++) {
        if (Detalle_Facturacion_Vendedores_Estatus_FacturasItems[i].Clave == Id) {
            return Detalle_Facturacion_Vendedores_Estatus_FacturasItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Facturacion_Vendedores_Estatus_FacturasDropDown() {
    var Detalle_Facturacion_Vendedores_Estatus_FacturasDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Facturacion_Vendedores_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Facturacion_Vendedores_Estatus_FacturasDropdown);
    if(Detalle_Facturacion_Vendedores_Estatus_FacturasItems != null)
    {
       for (var i = 0; i < Detalle_Facturacion_Vendedores_Estatus_FacturasItems.length; i++) {
           $('<option />', { value: Detalle_Facturacion_Vendedores_Estatus_FacturasItems[i].Clave, text:    Detalle_Facturacion_Vendedores_Estatus_FacturasItems[i].Descripcion }).appendTo(Detalle_Facturacion_Vendedores_Estatus_FacturasDropdown);
       }
    }
    return Detalle_Facturacion_Vendedores_Estatus_FacturasDropdown;
}





function GetInsertDetalle_Facturacion_VendedoresRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Facturacion_Vendedores_Fecha_de_Registro Fecha_de_Registro').attr('id', 'Detalle_Facturacion_Vendedores_Fecha_de_Registro_' + index).attr('data-field', 'Fecha_de_Registro');
    columnData[1] = $($.parseHTML(inputData)).addClass('Detalle_Facturacion_Vendedores_Folio_Factura Folio_Factura').attr('id', 'Detalle_Facturacion_Vendedores_Folio_Factura_' + index).attr('data-field', 'Folio_Factura');
    columnData[2] = $($.parseHTML(inputData)).addClass('Detalle_Facturacion_Vendedores_Periodo_Facturado Periodo_Facturado').attr('id', 'Detalle_Facturacion_Vendedores_Periodo_Facturado_' + index).attr('data-field', 'Periodo_Facturado');
    columnData[3] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Facturacion_Vendedores_Cantidad Cantidad').attr('id', 'Detalle_Facturacion_Vendedores_Cantidad_' + index).attr('data-field', 'Cantidad');
    columnData[4] = $($.parseHTML(GetFileUploader())).addClass('Detalle_Facturacion_Vendedores_Archivo_XML_FileUpload Archivo_XML').attr('id', 'Detalle_Facturacion_Vendedores_Archivo_XML_' + index).attr('data-field', 'Archivo_XML');
    columnData[5] = $($.parseHTML(GetFileUploader())).addClass('Detalle_Facturacion_Vendedores_Archivo_PDF_FileUpload Archivo_PDF').attr('id', 'Detalle_Facturacion_Vendedores_Archivo_PDF_' + index).attr('data-field', 'Archivo_PDF');
    columnData[6] = $(GetDetalle_Facturacion_Vendedores_Estatus_FacturasDropDown()).addClass('Detalle_Facturacion_Vendedores_Estatus Estatus').attr('id', 'Detalle_Facturacion_Vendedores_Estatus_' + index).attr('data-field', 'Estatus').after($.parseHTML(addNew('Detalle_Facturacion_Vendedores', 'Estatus_Facturas', 'Estatus', 259976)));
    columnData[7] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Facturacion_Vendedores_Fecha_programada_de_Pago Fecha_programada_de_Pago').attr('id', 'Detalle_Facturacion_Vendedores_Fecha_programada_de_Pago_' + index).attr('data-field', 'Fecha_programada_de_Pago');
    columnData[8] = $($.parseHTML(GetGridCheckBox())).addClass('Detalle_Facturacion_Vendedores_Pagada Pagada').attr('id', 'Detalle_Facturacion_Vendedores_Pagada_' + index).attr('data-field', 'Pagada');
    columnData[9] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Facturacion_Vendedores_Fecha_de_Pago Fecha_de_Pago').attr('id', 'Detalle_Facturacion_Vendedores_Fecha_de_Pago_' + index).attr('data-field', 'Fecha_de_Pago');


    initiateUIControls();
    return columnData;
}

function Detalle_Facturacion_VendedoresInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Facturacion_Vendedores("Detalle_Facturacion_Vendedores_", "_" + rowIndex)) {
    var iPage = Detalle_Facturacion_VendedoresTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Facturacion_Vendedores';
    var prevData = Detalle_Facturacion_VendedoresTable.fnGetData(rowIndex);
    var data = Detalle_Facturacion_VendedoresTable.fnGetNodes(rowIndex);
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
        ,Estatus:  data.childNodes[counter++].childNodes[0].value
        ,Fecha_programada_de_Pago:  data.childNodes[counter++].childNodes[0].value
        ,Pagada: $(data.childNodes[counter++].childNodes[2]).is(':checked')
        ,Fecha_de_Pago:  data.childNodes[counter++].childNodes[0].value

    }
    Detalle_Facturacion_VendedoresTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Facturacion_VendedoresrowCreationGrid(data, newData, rowIndex);
    Detalle_Facturacion_VendedoresTable.fnPageChange(iPage);
    Detalle_Facturacion_VendedorescountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Facturacion_Vendedores("Detalle_Facturacion_Vendedores_", "_" + rowIndex);
  }
}

function Detalle_Facturacion_VendedoresCancelRow(rowIndex) {
    var prevData = Detalle_Facturacion_VendedoresTable.fnGetData(rowIndex);
    var data = Detalle_Facturacion_VendedoresTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Facturacion_VendedoresTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Facturacion_VendedoresrowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Facturacion_VendedoresGrid(Detalle_Facturacion_VendedoresTable.fnGetData());
    Detalle_Facturacion_VendedorescountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Facturacion_VendedoresFromDataTable() {
    var Detalle_Facturacion_VendedoresData = [];
    var gridData = Detalle_Facturacion_VendedoresTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Facturacion_VendedoresData.push({
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
                ,Fecha_de_Pago: gridData[i].Fecha_de_Pago

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Facturacion_VendedoresData.length; i++) {
        if (removedDetalle_Facturacion_VendedoresData[i] != null && removedDetalle_Facturacion_VendedoresData[i].Folio > 0)
            Detalle_Facturacion_VendedoresData.push({
                Folio: removedDetalle_Facturacion_VendedoresData[i].Folio

                ,Fecha_de_Registro: removedDetalle_Facturacion_VendedoresData[i].Fecha_de_Registro
                ,Folio_Factura: removedDetalle_Facturacion_VendedoresData[i].Folio_Factura
                ,Periodo_Facturado: removedDetalle_Facturacion_VendedoresData[i].Periodo_Facturado
                ,Cantidad: removedDetalle_Facturacion_VendedoresData[i].Cantidad
                ,Archivo_XMLInfo: {
                    FileName: removedDetalle_Facturacion_VendedoresData[i].Archivo_XMLFileInfo.FileName, 
                    FileId: removedDetalle_Facturacion_VendedoresData[i].Archivo_XMLFileInfo.FileId, 
                    FileSize: removedDetalle_Facturacion_VendedoresData[i].Archivo_XMLFileInfo.FileSize,
                    Control: removedDetalle_Facturacion_VendedoresData[i].Archivo_XMLDetail != null && removedDetalle_Facturacion_VendedoresData[i].Archivo_XMLDetail.files.length > 0 ? removedDetalle_Facturacion_VendedoresData[i].Archivo_XMLDetail.files[0] : null,
                    Archivo_XMLRemoveFile: removedDetalle_Facturacion_VendedoresData[i].Archivo_XMLDetail != null
                }
                ,Archivo_PDFInfo: {
                    FileName: removedDetalle_Facturacion_VendedoresData[i].Archivo_PDFFileInfo.FileName, 
                    FileId: removedDetalle_Facturacion_VendedoresData[i].Archivo_PDFFileInfo.FileId, 
                    FileSize: removedDetalle_Facturacion_VendedoresData[i].Archivo_PDFFileInfo.FileSize,
                    Control: removedDetalle_Facturacion_VendedoresData[i].Archivo_PDFDetail != null && removedDetalle_Facturacion_VendedoresData[i].Archivo_PDFDetail.files.length > 0 ? removedDetalle_Facturacion_VendedoresData[i].Archivo_PDFDetail.files[0] : null,
                    Archivo_PDFRemoveFile: removedDetalle_Facturacion_VendedoresData[i].Archivo_PDFDetail != null
                }
                ,Estatus: removedDetalle_Facturacion_VendedoresData[i].Estatus
                ,Fecha_programada_de_Pago: removedDetalle_Facturacion_VendedoresData[i].Fecha_programada_de_Pago
                ,Pagada: removedDetalle_Facturacion_VendedoresData[i].Pagada
                ,Fecha_de_Pago: removedDetalle_Facturacion_VendedoresData[i].Fecha_de_Pago

                , Removed: true
            });
    }	

    return Detalle_Facturacion_VendedoresData;
}

function Detalle_Facturacion_VendedoresEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Facturacion_VendedoresTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Facturacion_VendedorescountRowsChecked++;
    var Detalle_Facturacion_VendedoresRowElement = "Detalle_Facturacion_Vendedores_" + rowIndex.toString();
    var prevData = Detalle_Facturacion_VendedoresTable.fnGetData(rowIndexTable );
    var row = Detalle_Facturacion_VendedoresTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Facturacion_Vendedores_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Facturacion_VendedoresGetUpdateRowControls(prevData, "Detalle_Facturacion_Vendedores_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Facturacion_VendedoresRowElement + "')){ Detalle_Facturacion_VendedoresInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_Facturacion_VendedoresCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Facturacion_VendedoresGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Facturacion_VendedoresGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_Facturacion_VendedoresValidation();
    initiateUIControls();
    $('.Detalle_Facturacion_Vendedores' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Facturacion_Vendedores(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Facturacion_VendedoresfnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Facturacion_VendedoresTable.fnGetData().length;
    Detalle_Facturacion_VendedoresfnClickAddRow();
    GetAddDetalle_Facturacion_VendedoresPopup(currentRowIndex, 0);
}

function Detalle_Facturacion_VendedoresEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Facturacion_VendedoresTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Facturacion_VendedoresRowElement = "Detalle_Facturacion_Vendedores_" + rowIndex.toString();
    var prevData = Detalle_Facturacion_VendedoresTable.fnGetData(rowIndexTable);
    GetAddDetalle_Facturacion_VendedoresPopup(rowIndex, 1, prevData.Folio);

    $('#Detalle_Facturacion_VendedoresFecha_de_Registro').val(prevData.Fecha_de_Registro);
    $('#Detalle_Facturacion_VendedoresFolio_Factura').val(prevData.Folio_Factura);
    $('#Detalle_Facturacion_VendedoresPeriodo_Facturado').val(prevData.Periodo_Facturado);
    $('#Detalle_Facturacion_VendedoresCantidad').val(prevData.Cantidad);


    $('#Detalle_Facturacion_VendedoresEstatus').val(prevData.Estatus);
    $('#Detalle_Facturacion_VendedoresFecha_programada_de_Pago').val(prevData.Fecha_programada_de_Pago);
    $('#Detalle_Facturacion_VendedoresPagada').prop('checked', prevData.Pagada);
    $('#Detalle_Facturacion_VendedoresFecha_de_Pago').val(prevData.Fecha_de_Pago);

    initiateUIControls();





    $('#existingArchivo_XML').html(prevData.Archivo_XMLFileDetail == null && (prevData.Archivo_XMLFileInfo.FileId == null || prevData.Archivo_XMLFileInfo.FileId <= 0) ? $.parseHTML(GetFileUploader()) : GetFileInfo(prevData.Archivo_XMLFileInfo, prevData.Archivo_XMLFileDetail));
    $('#existingArchivo_PDF').html(prevData.Archivo_PDFFileDetail == null && (prevData.Archivo_PDFFileInfo.FileId == null || prevData.Archivo_PDFFileInfo.FileId <= 0) ? $.parseHTML(GetFileUploader()) : GetFileInfo(prevData.Archivo_PDFFileInfo, prevData.Archivo_PDFFileDetail));





}

function Detalle_Facturacion_VendedoresAddInsertRow() {
    if (Detalle_Facturacion_VendedoresinsertRowCurrentIndex < 1)
    {
        Detalle_Facturacion_VendedoresinsertRowCurrentIndex = 1;
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
        ,Fecha_de_Pago: ""

    }
}

function Detalle_Facturacion_VendedoresfnClickAddRow() {
    Detalle_Facturacion_VendedorescountRowsChecked++;
    Detalle_Facturacion_VendedoresTable.fnAddData(Detalle_Facturacion_VendedoresAddInsertRow(), true);
    Detalle_Facturacion_VendedoresTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_Facturacion_VendedoresGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_Facturacion_VendedoresGrid tbody tr:nth-of-type(' + (Detalle_Facturacion_VendedoresinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Facturacion_Vendedores("Detalle_Facturacion_Vendedores_", "_" + Detalle_Facturacion_VendedoresinsertRowCurrentIndex);
}

function Detalle_Facturacion_VendedoresClearGridData() {
    Detalle_Facturacion_VendedoresData = [];
    Detalle_Facturacion_VendedoresdeletedItem = [];
    Detalle_Facturacion_VendedoresDataMain = [];
    Detalle_Facturacion_VendedoresDataMainPages = [];
    Detalle_Facturacion_VendedoresnewItemCount = 0;
    Detalle_Facturacion_VendedoresmaxItemIndex = 0;
    $("#Detalle_Facturacion_VendedoresGrid").DataTable().clear();
    $("#Detalle_Facturacion_VendedoresGrid").DataTable().destroy();
}

//Used to Get Vendedores Information
function GetDetalle_Facturacion_Vendedores() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Facturacion_VendedoresData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Facturacion_VendedoresData[i].Folio);

        form_data.append('[' + i + '].Fecha_de_Registro', Detalle_Facturacion_VendedoresData[i].Fecha_de_Registro);
        form_data.append('[' + i + '].Folio_Factura', Detalle_Facturacion_VendedoresData[i].Folio_Factura);
        form_data.append('[' + i + '].Periodo_Facturado', Detalle_Facturacion_VendedoresData[i].Periodo_Facturado);
        form_data.append('[' + i + '].Cantidad', Detalle_Facturacion_VendedoresData[i].Cantidad);
        form_data.append('[' + i + '].Archivo_XMLInfo.FileId', Detalle_Facturacion_VendedoresData[i].Archivo_XMLInfo.FileId);
        form_data.append('[' + i + '].Archivo_XMLInfo.FileName', Detalle_Facturacion_VendedoresData[i].Archivo_XMLInfo.FileName);
        form_data.append('[' + i + '].Archivo_XMLInfo.FileSize', Detalle_Facturacion_VendedoresData[i].Archivo_XMLInfo.FileSize);
        form_data.append('[' + i + '].Archivo_XMLInfo.Control', Detalle_Facturacion_VendedoresData[i].Archivo_XMLInfo.Control);
        form_data.append('[' + i + '].Archivo_XMLInfo.RemoveFile', Detalle_Facturacion_VendedoresData[i].Archivo_XMLInfo.ArchivoRemoveFile);
        form_data.append('[' + i + '].Archivo_PDFInfo.FileId', Detalle_Facturacion_VendedoresData[i].Archivo_PDFInfo.FileId);
        form_data.append('[' + i + '].Archivo_PDFInfo.FileName', Detalle_Facturacion_VendedoresData[i].Archivo_PDFInfo.FileName);
        form_data.append('[' + i + '].Archivo_PDFInfo.FileSize', Detalle_Facturacion_VendedoresData[i].Archivo_PDFInfo.FileSize);
        form_data.append('[' + i + '].Archivo_PDFInfo.Control', Detalle_Facturacion_VendedoresData[i].Archivo_PDFInfo.Control);
        form_data.append('[' + i + '].Archivo_PDFInfo.RemoveFile', Detalle_Facturacion_VendedoresData[i].Archivo_PDFInfo.ArchivoRemoveFile);
        form_data.append('[' + i + '].Estatus', Detalle_Facturacion_VendedoresData[i].Estatus);
        form_data.append('[' + i + '].Fecha_programada_de_Pago', Detalle_Facturacion_VendedoresData[i].Fecha_programada_de_Pago);
        form_data.append('[' + i + '].Pagada', Detalle_Facturacion_VendedoresData[i].Pagada);
        form_data.append('[' + i + '].Fecha_de_Pago', Detalle_Facturacion_VendedoresData[i].Fecha_de_Pago);

        form_data.append('[' + i + '].Removed', Detalle_Facturacion_VendedoresData[i].Removed);
    }
    return form_data;
}
function Detalle_Facturacion_VendedoresInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Facturacion_Vendedores("Detalle_Facturacion_VendedoresTable", rowIndex)) {
    var prevData = Detalle_Facturacion_VendedoresTable.fnGetData(rowIndex);
    var data = Detalle_Facturacion_VendedoresTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Fecha_de_Registro: $('#Detalle_Facturacion_VendedoresFecha_de_Registro').val()
        ,Folio_Factura: $('#Detalle_Facturacion_VendedoresFolio_Factura').val()
        ,Periodo_Facturado: $('#Detalle_Facturacion_VendedoresPeriodo_Facturado').val()
        ,Cantidad: $('#Detalle_Facturacion_VendedoresCantidad').val()
        ,Archivo_XMLFileInfo: { Archivo_XMLFileName: prevData.Archivo_XMLFileInfo.FileName, Archivo_XMLFileId: prevData.Archivo_XMLFileInfo.FileId, Archivo_XMLFileSize: prevData.Archivo_XMLFileInfo.FileSize }
        ,Archivo_XMLFileDetail: $('#Archivo_XML').find('label').length == 0 ? $('#Archivo_XMLFileInfoPop')[0] : prevData.Archivo_XMLFileDetail
        ,Archivo_PDFFileInfo: { Archivo_PDFFileName: prevData.Archivo_PDFFileInfo.FileName, Archivo_PDFFileId: prevData.Archivo_PDFFileInfo.FileId, Archivo_PDFFileSize: prevData.Archivo_PDFFileInfo.FileSize }
        ,Archivo_PDFFileDetail: $('#Archivo_PDF').find('label').length == 0 ? $('#Archivo_PDFFileInfoPop')[0] : prevData.Archivo_PDFFileDetail
        ,Estatus: $('#Detalle_Facturacion_VendedoresEstatus').val()
        ,Fecha_programada_de_Pago: $('#Detalle_Facturacion_VendedoresFecha_programada_de_Pago').val()
        ,Pagada: $('#Detalle_Facturacion_VendedoresPagada').is(':checked')
        ,Fecha_de_Pago: $('#Detalle_Facturacion_VendedoresFecha_de_Pago').val()

    }

    Detalle_Facturacion_VendedoresTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Facturacion_VendedoresrowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Facturacion_Vendedores-form').modal({ show: false });
    $('#AddDetalle_Facturacion_Vendedores-form').modal('hide');
    Detalle_Facturacion_VendedoresEditRow(rowIndex);
    Detalle_Facturacion_VendedoresInsertRow(rowIndex);
    //}
}
function Detalle_Facturacion_VendedoresRemoveAddRow(rowIndex) {
    Detalle_Facturacion_VendedoresTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Facturacion_Vendedores MultiRow


$(function () {
    function Detalle_Codigos_de_Referencia_VendedoresinitializeMainArray(totalCount) {
        if (Detalle_Codigos_de_Referencia_VendedoresDataMain.length != totalCount && !Detalle_Codigos_de_Referencia_VendedoresDataMainInitialized) {
            Detalle_Codigos_de_Referencia_VendedoresDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Codigos_de_Referencia_VendedoresDataMain[i] = null;
            }
        }
    }
    function Detalle_Codigos_de_Referencia_VendedoresremoveFromMainArray() {
        for (var j = 0; j < Detalle_Codigos_de_Referencia_VendedoresdeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Codigos_de_Referencia_VendedoresDataMain.length; i++) {
                if (Detalle_Codigos_de_Referencia_VendedoresDataMain[i] != null && Detalle_Codigos_de_Referencia_VendedoresDataMain[i].Id == Detalle_Codigos_de_Referencia_VendedoresdeletedItem[j]) {
                    hDetalle_Codigos_de_Referencia_VendedoresDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Codigos_de_Referencia_VendedorescopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Codigos_de_Referencia_VendedoresDataMain.length; i++) {
            data[i] = Detalle_Codigos_de_Referencia_VendedoresDataMain[i];

        }
        return data;
    }
    function Detalle_Codigos_de_Referencia_VendedoresgetNewResult() {
        var newData = copyMainDetalle_Codigos_de_Referencia_VendedoresArray();

        for (var i = 0; i < Detalle_Codigos_de_Referencia_VendedoresData.length; i++) {
            if (Detalle_Codigos_de_Referencia_VendedoresData[i].Removed == null || Detalle_Codigos_de_Referencia_VendedoresData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Codigos_de_Referencia_VendedoresData[i]);
            }
        }
        return newData;
    }
    function Detalle_Codigos_de_Referencia_VendedorespushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Codigos_de_Referencia_VendedoresDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Codigos_de_Referencia_VendedoresDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Detalle_Facturacion_VendedoresinitializeMainArray(totalCount) {
        if (Detalle_Facturacion_VendedoresDataMain.length != totalCount && !Detalle_Facturacion_VendedoresDataMainInitialized) {
            Detalle_Facturacion_VendedoresDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Facturacion_VendedoresDataMain[i] = null;
            }
        }
    }
    function Detalle_Facturacion_VendedoresremoveFromMainArray() {
        for (var j = 0; j < Detalle_Facturacion_VendedoresdeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Facturacion_VendedoresDataMain.length; i++) {
                if (Detalle_Facturacion_VendedoresDataMain[i] != null && Detalle_Facturacion_VendedoresDataMain[i].Id == Detalle_Facturacion_VendedoresdeletedItem[j]) {
                    hDetalle_Facturacion_VendedoresDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Facturacion_VendedorescopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Facturacion_VendedoresDataMain.length; i++) {
            data[i] = Detalle_Facturacion_VendedoresDataMain[i];

        }
        return data;
    }
    function Detalle_Facturacion_VendedoresgetNewResult() {
        var newData = copyMainDetalle_Facturacion_VendedoresArray();

        for (var i = 0; i < Detalle_Facturacion_VendedoresData.length; i++) {
            if (Detalle_Facturacion_VendedoresData[i].Removed == null || Detalle_Facturacion_VendedoresData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Facturacion_VendedoresData[i]);
            }
        }
        return newData;
    }
    function Detalle_Facturacion_VendedorespushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Facturacion_VendedoresDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Facturacion_VendedoresDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }

});

//Grid GetAutocomplete

//Grid GetAutocomplete



function getDropdown(elementKey) {
    var labelSelect = $("#Vendedores_cmbLabelSelect").val();
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
    $('#CreateVendedores')[0].reset();
    ClearFormControls();
    $("#FolioId").val("0");
                Detalle_Codigos_de_Referencia_VendedoresClearGridData();
                Detalle_Facturacion_VendedoresClearGridData();

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreateVendedores').trigger('reset');
    $('#CreateVendedores').find(':input').each(function () {
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
    var $myForm = $('#CreateVendedores');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    if (Detalle_Codigos_de_Referencia_VendedorescountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Codigos_de_Referencia_Vendedores();
        return false;
    }
    if (Detalle_Facturacion_VendedorescountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Facturacion_Vendedores();
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblFolio").text("0");
}
$(document).ready(function () {
    $("form#CreateVendedores").submit(function (e) {
        e.preventDefault();
        return false;
    });
	$("form#CreateVendedores").on('click', '#VendedoresCancelar', function () {
	  if (!isPartial) {
        VendedoresBackToGrid();
	  } else {
            window.close();
      }
    });
	$("form#CreateVendedores").on('click', '#VendedoresGuardar', function () {
		$('#VendedoresGuardar').attr('disabled', true);
		$('#VendedoresGuardar').unbind()
        if (EjecutarValidacionesAntesDeGuardar() && CheckValidation()) {
				if (!SendVendedoresData(function () {
					EjecutarValidacionesDespuesDeGuardar();
					if (!isPartial)
						VendedoresBackToGrid();
					else {						
						if (!isMR)
							window.opener.RefreshCatalog('Vendedores', nameAttribute);
						else {
							var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
							if(!control.hasClass('AutoComplete'))
							{
							if (control.attr("data-isfilter") == "true") {
									eval(GetReglaFilter(control,  $(window.opener.document.getElementById('ObjectId')).val()));								    
								}
								else 
								{
									eval('window.opener.Get' + nameMR + '_VendedoresItem()');
									var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
									control.html(eval('window.opener.Get' + nameMR + '_VendedoresDropDown().get(0)').innerHTML);  
								}								
							}
						}
						window.close();						
						}
				})) {
					$('#VendedoresGuardar').removeAttr('disabled');
					$('#VendedoresGuardar').bind()
				}
		}
		else {
			$('#VendedoresGuardar').removeAttr('disabled');
			$('#VendedoresGuardar').bind()
		}
    });
	$("form#CreateVendedores").on('click', '#VendedoresGuardarYNuevo', function () {	
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation()) {
				SendVendedoresData(function () {
					ClearControls();
					ClearAttachmentsDiv();
					ResetClaveLabel();
	                getDetalle_Codigos_de_Referencia_VendedoresData();
                getDetalle_Facturacion_VendedoresData();

					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Vendedores', nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_VendedoresItem()');                           
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
                            control.html(eval('window.opener.Get' + nameMR + '_VendedoresDropDown().get(0)').innerHTML);   
					    }	
					}						
					EjecutarValidacionesDespuesDeGuardar();				
			setIsNew();
			EjecutarValidacionesAlComienzo();
				});
			}
		}		
    });
    $("form#CreateVendedores").on('click', '#VendedoresGuardarYCopia', function () {
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendVendedoresData(function (currentId) {
					$("#FolioId").val("0");
	                Detalle_Codigos_de_Referencia_VendedoresClearGridData();
                Detalle_Facturacion_VendedoresClearGridData();

					ResetClaveLabel();
					$("#ReferenceFolio").val(currentId);
	                getDetalle_Codigos_de_Referencia_VendedoresData();
                getDetalle_Facturacion_VendedoresData();

					EjecutarValidacionesDespuesDeGuardar();		
					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Vendedores',nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_VendedoresItem()');                          
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);						
							control.html(eval('window.opener.Get' + nameMR + '_VendedoresDropDown().get(0)').innerHTML);                          
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



var VendedoresisdisplayBusinessPropery = false;
VendedoresDisplayBusinessRuleButtons(VendedoresisdisplayBusinessPropery);
function VendedoresDisplayBusinessRule() {
    if (!VendedoresisdisplayBusinessPropery) {
        $('#CreateVendedores').find('.col-sm-8').each(function () {
			var div =$(this); 
			if ($(this).find('.input-group').length >0)
				div  =  $(this).find('.input-group').first().hasClass('date')? $(this): $(this).find('.input-group').first();	
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = div.data('field-id');
            var fieldName = div.data('field-name');
            var attribute = div.data('attribute');
            mainElementAttributes += '<div class="VendedoresdisplayBusinessPropery"><button onclick="VendedoresGetBusinessRule()" type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#VendedoresBusinessRule-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.VendedoresdisplayBusinessPropery').remove();
    }
    VendedoresDisplayBusinessRuleButtons(!VendedoresisdisplayBusinessPropery);
    VendedoresisdisplayBusinessPropery = (VendedoresisdisplayBusinessPropery ? false : true);
}
function VendedoresDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}

