

//Begin Declarations for Foreigns fields for Detalle_Sucursales_Proveedores MultiRow
var Detalle_Sucursales_ProveedorescountRowsChecked = 0;

function GetDetalle_Sucursales_Proveedores_Tipo_de_SucursalName(Id) {
    for (var i = 0; i < Detalle_Sucursales_Proveedores_Tipo_de_SucursalItems.length; i++) {
        if (Detalle_Sucursales_Proveedores_Tipo_de_SucursalItems[i].Clave == Id) {
            return Detalle_Sucursales_Proveedores_Tipo_de_SucursalItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Sucursales_Proveedores_Tipo_de_SucursalDropDown() {
    var Detalle_Sucursales_Proveedores_Tipo_de_SucursalDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Sucursales_Proveedores_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Sucursales_Proveedores_Tipo_de_SucursalDropdown);

    for (var i = 0; i < Detalle_Sucursales_Proveedores_Tipo_de_SucursalItems.length; i++) {
        $('<option />', { value: Detalle_Sucursales_Proveedores_Tipo_de_SucursalItems[i].Clave, text: Detalle_Sucursales_Proveedores_Tipo_de_SucursalItems[i].Descripcion }).appendTo(Detalle_Sucursales_Proveedores_Tipo_de_SucursalDropdown);
    }
    return Detalle_Sucursales_Proveedores_Tipo_de_SucursalDropdown;
}












function GetInsertDetalle_Sucursales_ProveedoresRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $($.parseHTML(GetGridAutoComplete(null,'AutoCompleteDetalle_Sucursales_Proveedores_Tipo_de_Sucursal'))).addClass('Detalle_Sucursales_Proveedores_Tipo_de_Sucursal Tipo_de_Sucursal').attr('id', 'Detalle_Sucursales_Proveedores_Tipo_de_Sucursal_' + index).attr('data-field', 'Tipo_de_Sucursal').after($.parseHTML(addNew('Detalle_Sucursales_Proveedores', 'Tipo_de_Sucursal', 'Tipo_de_Sucursal', 260005)));
    columnData[1] = $($.parseHTML(inputData)).addClass('Detalle_Sucursales_Proveedores_Email Email').attr('id', 'Detalle_Sucursales_Proveedores_Email_' + index).attr('data-field', 'Email');
    columnData[2] = $($.parseHTML(inputData)).addClass('Detalle_Sucursales_Proveedores_Telefono Telefono').attr('id', 'Detalle_Sucursales_Proveedores_Telefono_' + index).attr('data-field', 'Telefono');
    columnData[3] = $($.parseHTML(inputData)).addClass('Detalle_Sucursales_Proveedores_Calle Calle').attr('id', 'Detalle_Sucursales_Proveedores_Calle_' + index).attr('data-field', 'Calle');
    columnData[4] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Sucursales_Proveedores_Numero_exterior Numero_exterior').attr('id', 'Detalle_Sucursales_Proveedores_Numero_exterior_' + index).attr('data-field', 'Numero_exterior');
    columnData[5] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Sucursales_Proveedores_Numero_interior Numero_interior').attr('id', 'Detalle_Sucursales_Proveedores_Numero_interior_' + index).attr('data-field', 'Numero_interior');
    columnData[6] = $($.parseHTML(inputData)).addClass('Detalle_Sucursales_Proveedores_Colonia Colonia').attr('id', 'Detalle_Sucursales_Proveedores_Colonia_' + index).attr('data-field', 'Colonia');
    columnData[7] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Sucursales_Proveedores_C_P_ C_P_').attr('id', 'Detalle_Sucursales_Proveedores_C_P__' + index).attr('data-field', 'C_P_');
    columnData[8] = $($.parseHTML(inputData)).addClass('Detalle_Sucursales_Proveedores_Ciudad Ciudad').attr('id', 'Detalle_Sucursales_Proveedores_Ciudad_' + index).attr('data-field', 'Ciudad');
    columnData[9] = $($.parseHTML(inputData)).addClass('Detalle_Sucursales_Proveedores_Estado Estado').attr('id', 'Detalle_Sucursales_Proveedores_Estado_' + index).attr('data-field', 'Estado');
    columnData[10] = $($.parseHTML(inputData)).addClass('Detalle_Sucursales_Proveedores_Pais Pais').attr('id', 'Detalle_Sucursales_Proveedores_Pais_' + index).attr('data-field', 'Pais');


    initiateUIControls();
    return columnData;
}

function Detalle_Sucursales_ProveedoresInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Sucursales_Proveedores("Detalle_Sucursales_Proveedores_", "_" + rowIndex)) {
    var iPage = Detalle_Sucursales_ProveedoresTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Sucursales_Proveedores';
    var prevData = Detalle_Sucursales_ProveedoresTable.fnGetData(rowIndex);
    var data = Detalle_Sucursales_ProveedoresTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        , Tipo_de_SucursalDescripcion:  $(data.childNodes[counter].childNodes[0]).find('option:selected').text() 
        , Tipo_de_Sucursal:  data.childNodes[counter++].childNodes[0].value 	
        ,Email:  data.childNodes[counter++].childNodes[0].value
        ,Telefono:  data.childNodes[counter++].childNodes[0].value
        ,Calle:  data.childNodes[counter++].childNodes[0].value
        ,Numero_exterior: data.childNodes[counter++].childNodes[0].value
        ,Numero_interior: data.childNodes[counter++].childNodes[0].value
        ,Colonia:  data.childNodes[counter++].childNodes[0].value
        ,C_P_: data.childNodes[counter++].childNodes[0].value
        ,Ciudad:  data.childNodes[counter++].childNodes[0].value
        ,Estado:  data.childNodes[counter++].childNodes[0].value
        ,Pais:  data.childNodes[counter++].childNodes[0].value

    }
    Detalle_Sucursales_ProveedoresTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Sucursales_ProveedoresrowCreationGrid(data, newData, rowIndex);
    Detalle_Sucursales_ProveedoresTable.fnPageChange(iPage);
    Detalle_Sucursales_ProveedorescountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Sucursales_Proveedores("Detalle_Sucursales_Proveedores_", "_" + rowIndex);
  }
}

function Detalle_Sucursales_ProveedoresCancelRow(rowIndex) {
    var prevData = Detalle_Sucursales_ProveedoresTable.fnGetData(rowIndex);
    var data = Detalle_Sucursales_ProveedoresTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Sucursales_ProveedoresTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Sucursales_ProveedoresrowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Sucursales_ProveedoresGrid(Detalle_Sucursales_ProveedoresTable.fnGetData());
    Detalle_Sucursales_ProveedorescountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Sucursales_ProveedoresFromDataTable() {
    var Detalle_Sucursales_ProveedoresData = [];
    var gridData = Detalle_Sucursales_ProveedoresTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Sucursales_ProveedoresData.push({
                Folio: gridData[i].Folio

                ,Tipo_de_Sucursal: gridData[i].Tipo_de_Sucursal
                ,Email: gridData[i].Email
                ,Telefono: gridData[i].Telefono
                ,Calle: gridData[i].Calle
                ,Numero_exterior: gridData[i].Numero_exterior
                ,Numero_interior: gridData[i].Numero_interior
                ,Colonia: gridData[i].Colonia
                ,C_P_: gridData[i].C_P_
                ,Ciudad: gridData[i].Ciudad
                ,Estado: gridData[i].Estado
                ,Pais: gridData[i].Pais

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Sucursales_ProveedoresData.length; i++) {
        if (removedDetalle_Sucursales_ProveedoresData[i] != null && removedDetalle_Sucursales_ProveedoresData[i].Folio > 0)
            Detalle_Sucursales_ProveedoresData.push({
                Folio: removedDetalle_Sucursales_ProveedoresData[i].Folio

                ,Tipo_de_Sucursal: removedDetalle_Sucursales_ProveedoresData[i].Tipo_de_Sucursal
                ,Email: removedDetalle_Sucursales_ProveedoresData[i].Email
                ,Telefono: removedDetalle_Sucursales_ProveedoresData[i].Telefono
                ,Calle: removedDetalle_Sucursales_ProveedoresData[i].Calle
                ,Numero_exterior: removedDetalle_Sucursales_ProveedoresData[i].Numero_exterior
                ,Numero_interior: removedDetalle_Sucursales_ProveedoresData[i].Numero_interior
                ,Colonia: removedDetalle_Sucursales_ProveedoresData[i].Colonia
                ,C_P_: removedDetalle_Sucursales_ProveedoresData[i].C_P_
                ,Ciudad: removedDetalle_Sucursales_ProveedoresData[i].Ciudad
                ,Estado: removedDetalle_Sucursales_ProveedoresData[i].Estado
                ,Pais: removedDetalle_Sucursales_ProveedoresData[i].Pais

                , Removed: true
            });
    }	

    return Detalle_Sucursales_ProveedoresData;
}

function Detalle_Sucursales_ProveedoresEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Sucursales_ProveedoresTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Sucursales_ProveedorescountRowsChecked++;
    var Detalle_Sucursales_ProveedoresRowElement = "Detalle_Sucursales_Proveedores_" + rowIndex.toString();
    var prevData = Detalle_Sucursales_ProveedoresTable.fnGetData(rowIndexTable );
    var row = Detalle_Sucursales_ProveedoresTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Sucursales_Proveedores_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Sucursales_ProveedoresGetUpdateRowControls(prevData, "Detalle_Sucursales_Proveedores_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Sucursales_ProveedoresRowElement + "')){ Detalle_Sucursales_ProveedoresInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_Sucursales_ProveedoresCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Sucursales_ProveedoresGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Sucursales_ProveedoresGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_Sucursales_ProveedoresValidation();
    initiateUIControls();
    $('.Detalle_Sucursales_Proveedores' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Sucursales_Proveedores(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Sucursales_ProveedoresfnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Sucursales_ProveedoresTable.fnGetData().length;
    Detalle_Sucursales_ProveedoresfnClickAddRow();
    GetAddDetalle_Sucursales_ProveedoresPopup(currentRowIndex, 0);
}

function Detalle_Sucursales_ProveedoresEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Sucursales_ProveedoresTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Sucursales_ProveedoresRowElement = "Detalle_Sucursales_Proveedores_" + rowIndex.toString();
    var prevData = Detalle_Sucursales_ProveedoresTable.fnGetData(rowIndexTable);
    GetAddDetalle_Sucursales_ProveedoresPopup(rowIndex, 1, prevData.Folio);

    $('#dvDetalle_Sucursales_ProveedoresTipo_de_Sucursal').html($($.parseHTML(GetGridAutoComplete(prevData.Tipo_de_Sucursal.label,'AutoCompleteTipo_de_Sucursal'))).addClass('Detalle_Sucursales_Proveedores_Tipo_de_Sucursal'));
    $('#Detalle_Sucursales_ProveedoresEmail').val(prevData.Email);
    $('#Detalle_Sucursales_ProveedoresTelefono').val(prevData.Telefono);
    $('#Detalle_Sucursales_ProveedoresCalle').val(prevData.Calle);
    $('#Detalle_Sucursales_ProveedoresNumero_exterior').val(prevData.Numero_exterior);
    $('#Detalle_Sucursales_ProveedoresNumero_interior').val(prevData.Numero_interior);
    $('#Detalle_Sucursales_ProveedoresColonia').val(prevData.Colonia);
    $('#Detalle_Sucursales_ProveedoresC_P_').val(prevData.C_P_);
    $('#Detalle_Sucursales_ProveedoresCiudad').val(prevData.Ciudad);
    $('#Detalle_Sucursales_ProveedoresEstado').val(prevData.Estado);
    $('#Detalle_Sucursales_ProveedoresPais').val(prevData.Pais);

    initiateUIControls();













}

function Detalle_Sucursales_ProveedoresAddInsertRow() {
    if (Detalle_Sucursales_ProveedoresinsertRowCurrentIndex < 1)
    {
        Detalle_Sucursales_ProveedoresinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Tipo_de_Sucursal: ""
        ,Email: ""
        ,Telefono: ""
        ,Calle: ""
        ,Numero_exterior: ""
        ,Numero_interior: ""
        ,Colonia: ""
        ,C_P_: ""
        ,Ciudad: ""
        ,Estado: ""
        ,Pais: ""

    }
}

function Detalle_Sucursales_ProveedoresfnClickAddRow() {
    Detalle_Sucursales_ProveedorescountRowsChecked++;
    Detalle_Sucursales_ProveedoresTable.fnAddData(Detalle_Sucursales_ProveedoresAddInsertRow(), true);
    Detalle_Sucursales_ProveedoresTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_Sucursales_ProveedoresGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_Sucursales_ProveedoresGrid tbody tr:nth-of-type(' + (Detalle_Sucursales_ProveedoresinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Sucursales_Proveedores("Detalle_Sucursales_Proveedores_", "_" + Detalle_Sucursales_ProveedoresinsertRowCurrentIndex);
}

function Detalle_Sucursales_ProveedoresClearGridData() {
    Detalle_Sucursales_ProveedoresData = [];
    Detalle_Sucursales_ProveedoresdeletedItem = [];
    Detalle_Sucursales_ProveedoresDataMain = [];
    Detalle_Sucursales_ProveedoresDataMainPages = [];
    Detalle_Sucursales_ProveedoresnewItemCount = 0;
    Detalle_Sucursales_ProveedoresmaxItemIndex = 0;
    $("#Detalle_Sucursales_ProveedoresGrid").DataTable().clear();
    $("#Detalle_Sucursales_ProveedoresGrid").DataTable().destroy();
}

//Used to Get Proveedores Information
function GetDetalle_Sucursales_Proveedores() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Sucursales_ProveedoresData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Sucursales_ProveedoresData[i].Folio);

        form_data.append('[' + i + '].Tipo_de_Sucursal', Detalle_Sucursales_ProveedoresData[i].Tipo_de_Sucursal);
        form_data.append('[' + i + '].Email', Detalle_Sucursales_ProveedoresData[i].Email);
        form_data.append('[' + i + '].Telefono', Detalle_Sucursales_ProveedoresData[i].Telefono);
        form_data.append('[' + i + '].Calle', Detalle_Sucursales_ProveedoresData[i].Calle);
        form_data.append('[' + i + '].Numero_exterior', Detalle_Sucursales_ProveedoresData[i].Numero_exterior);
        form_data.append('[' + i + '].Numero_interior', Detalle_Sucursales_ProveedoresData[i].Numero_interior);
        form_data.append('[' + i + '].Colonia', Detalle_Sucursales_ProveedoresData[i].Colonia);
        form_data.append('[' + i + '].C_P_', Detalle_Sucursales_ProveedoresData[i].C_P_);
        form_data.append('[' + i + '].Ciudad', Detalle_Sucursales_ProveedoresData[i].Ciudad);
        form_data.append('[' + i + '].Estado', Detalle_Sucursales_ProveedoresData[i].Estado);
        form_data.append('[' + i + '].Pais', Detalle_Sucursales_ProveedoresData[i].Pais);

        form_data.append('[' + i + '].Removed', Detalle_Sucursales_ProveedoresData[i].Removed);
    }
    return form_data;
}
function Detalle_Sucursales_ProveedoresInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Sucursales_Proveedores("Detalle_Sucursales_ProveedoresTable", rowIndex)) {
    var prevData = Detalle_Sucursales_ProveedoresTable.fnGetData(rowIndex);
    var data = Detalle_Sucursales_ProveedoresTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Tipo_de_Sucursal: $('#Detalle_Sucursales_ProveedoresTipo_de_Sucursal').val()
        ,Email: $('#Detalle_Sucursales_ProveedoresEmail').val()
        ,Telefono: $('#Detalle_Sucursales_ProveedoresTelefono').val()
        ,Calle: $('#Detalle_Sucursales_ProveedoresCalle').val()
        ,Numero_exterior: $('#Detalle_Sucursales_ProveedoresNumero_exterior').val()

        ,Numero_interior: $('#Detalle_Sucursales_ProveedoresNumero_interior').val()

        ,Colonia: $('#Detalle_Sucursales_ProveedoresColonia').val()
        ,C_P_: $('#Detalle_Sucursales_ProveedoresC_P_').val()

        ,Ciudad: $('#Detalle_Sucursales_ProveedoresCiudad').val()
        ,Estado: $('#Detalle_Sucursales_ProveedoresEstado').val()
        ,Pais: $('#Detalle_Sucursales_ProveedoresPais').val()

    }

    Detalle_Sucursales_ProveedoresTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Sucursales_ProveedoresrowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Sucursales_Proveedores-form').modal({ show: false });
    $('#AddDetalle_Sucursales_Proveedores-form').modal('hide');
    Detalle_Sucursales_ProveedoresEditRow(rowIndex);
    Detalle_Sucursales_ProveedoresInsertRow(rowIndex);
    //}
}
function Detalle_Sucursales_ProveedoresRemoveAddRow(rowIndex) {
    Detalle_Sucursales_ProveedoresTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Sucursales_Proveedores MultiRow
//Begin Declarations for Foreigns fields for Detalle_Suscripcion_Red_de_Especialistas_Proveedores MultiRow
var Detalle_Suscripcion_Red_de_Especialistas_ProveedorescountRowsChecked = 0;

function GetDetalle_Suscripcion_Red_de_Especialistas_Proveedores_Planes_de_Suscripcion_ProveedoresName(Id) {
    for (var i = 0; i < Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Planes_de_Suscripcion_ProveedoresItems.length; i++) {
        if (Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Planes_de_Suscripcion_ProveedoresItems[i].Clave == Id) {
            return Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Planes_de_Suscripcion_ProveedoresItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Suscripcion_Red_de_Especialistas_Proveedores_Planes_de_Suscripcion_ProveedoresDropDown() {
    var Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Planes_de_Suscripcion_ProveedoresDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Suscripcion_Red_de_Especialistas_Proveedores_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Planes_de_Suscripcion_ProveedoresDropdown);
    if(Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Planes_de_Suscripcion_ProveedoresItems != null)
    {
       for (var i = 0; i < Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Planes_de_Suscripcion_ProveedoresItems.length; i++) {
           $('<option />', { value: Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Planes_de_Suscripcion_ProveedoresItems[i].Clave, text:    Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Planes_de_Suscripcion_ProveedoresItems[i].Descripcion }).appendTo(Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Planes_de_Suscripcion_ProveedoresDropdown);
       }
    }
    return Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Planes_de_Suscripcion_ProveedoresDropdown;
}





function GetDetalle_Suscripcion_Red_de_Especialistas_Proveedores_Estatus_de_SuscripcionName(Id) {
    for (var i = 0; i < Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Estatus_de_SuscripcionItems.length; i++) {
        if (Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Estatus_de_SuscripcionItems[i].Clave == Id) {
            return Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Estatus_de_SuscripcionItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Suscripcion_Red_de_Especialistas_Proveedores_Estatus_de_SuscripcionDropDown() {
    var Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Estatus_de_SuscripcionDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Suscripcion_Red_de_Especialistas_Proveedores_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Estatus_de_SuscripcionDropdown);
    if(Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Estatus_de_SuscripcionItems != null)
    {
       for (var i = 0; i < Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Estatus_de_SuscripcionItems.length; i++) {
           $('<option />', { value: Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Estatus_de_SuscripcionItems[i].Clave, text:    Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Estatus_de_SuscripcionItems[i].Descripcion }).appendTo(Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Estatus_de_SuscripcionDropdown);
       }
    }
    return Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Estatus_de_SuscripcionDropdown;
}


function GetInsertDetalle_Suscripcion_Red_de_Especialistas_ProveedoresRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $(GetDetalle_Suscripcion_Red_de_Especialistas_Proveedores_Planes_de_Suscripcion_ProveedoresDropDown()).addClass('Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Plan_de_Suscripcion Plan_de_Suscripcion').attr('id', 'Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Plan_de_Suscripcion_' + index).attr('data-field', 'Plan_de_Suscripcion').after($.parseHTML(addNew('Detalle_Suscripcion_Red_de_Especialistas_Proveedores', 'Planes_de_Suscripcion_Proveedores', 'Plan_de_Suscripcion', 260044)));
    columnData[1] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Fecha_inicio Fecha_inicio').attr('id', 'Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Fecha_inicio_' + index).attr('data-field', 'Fecha_inicio');
    columnData[2] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Fecha_fin Fecha_fin').attr('id', 'Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Fecha_fin_' + index).attr('data-field', 'Fecha_fin');
    columnData[3] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Costo Costo inputMoney').attr('id', 'Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Costo_' + index).attr('data-field', 'Costo');
    columnData[4] = $($.parseHTML(GetFileUploader())).addClass('Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Contrato_FileUpload Contrato').attr('id', 'Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Contrato_' + index).attr('data-field', 'Contrato');
    columnData[5] = $($.parseHTML(GetGridCheckBox())).addClass('Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Firmo_Contrato Firmo_Contrato').attr('id', 'Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Firmo_Contrato_' + index).attr('data-field', 'Firmo_Contrato');
    columnData[6] = $(GetDetalle_Suscripcion_Red_de_Especialistas_Proveedores_Estatus_de_SuscripcionDropDown()).addClass('Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Estatus Estatus').attr('id', 'Detalle_Suscripcion_Red_de_Especialistas_Proveedores_Estatus_' + index).attr('data-field', 'Estatus').after($.parseHTML(addNew('Detalle_Suscripcion_Red_de_Especialistas_Proveedores', 'Estatus_de_Suscripcion', 'Estatus', 260050)));


    initiateUIControls();
    return columnData;
}

function Detalle_Suscripcion_Red_de_Especialistas_ProveedoresInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Suscripcion_Red_de_Especialistas_Proveedores("Detalle_Suscripcion_Red_de_Especialistas_Proveedores_", "_" + rowIndex)) {
    var iPage = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Suscripcion_Red_de_Especialistas_Proveedores';
    var prevData = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresTable.fnGetData(rowIndex);
    var data = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Plan_de_Suscripcion:  data.childNodes[counter++].childNodes[0].value
        ,Fecha_inicio:  data.childNodes[counter++].childNodes[0].value
        ,Fecha_fin:  data.childNodes[counter++].childNodes[0].value
        ,Costo:  data.childNodes[counter++].childNodes[0].value
        ,ContratoFileInfo: ($('#' + nameOfGrid + 'Grid .ContratoHeader').css('display') != 'none') ? { 
             FileName: prevData.ContratoFileInfo != null && prevData.ContratoFileInfo.FileName != null && prevData.ContratoFileInfo.FileName != ''? prevData.ContratoFileInfo.FileName : (data.childNodes[counter].childNodes[0].files.length > 0 ? data.childNodes[counter].childNodes[0].files[0].name : ''),              
			 FileId:   prevData.ContratoFileInfo != null && prevData.ContratoFileInfo.FileName != null && prevData.ContratoFileInfo.FileName != '' ? prevData.ContratoFileInfo.FileId :  prevData.ContratoFileInfo != null && prevData.ContratoFileInfo.FileId != '' && prevData.ContratoFileInfo.FileId != undefined ? prevData.ContratoFileInfo.FileId : '0',
             FileSize: prevData.ContratoFileInfo != null && prevData.ContratoFileInfo.FileName != null ? prevData.ContratoFileInfo.FileSize : (data.childNodes[counter].childNodes[0].files.length > 0 ? data.childNodes[counter].childNodes[0].files[0].name : '') 
         } : ''
        ,ContratoDetail: (data.childNodes[counter] != 'undefined' && data.childNodes[counter].childNodes[0].childNodes.length == 0) ? data.childNodes[counter++].childNodes[0] : prevData.ContratoDetail
        ,Firmo_Contrato: $(data.childNodes[counter++].childNodes[2]).is(':checked')
        ,Estatus:  data.childNodes[counter++].childNodes[0].value

    }
    Detalle_Suscripcion_Red_de_Especialistas_ProveedoresTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Suscripcion_Red_de_Especialistas_ProveedoresrowCreationGrid(data, newData, rowIndex);
    Detalle_Suscripcion_Red_de_Especialistas_ProveedoresTable.fnPageChange(iPage);
    Detalle_Suscripcion_Red_de_Especialistas_ProveedorescountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Suscripcion_Red_de_Especialistas_Proveedores("Detalle_Suscripcion_Red_de_Especialistas_Proveedores_", "_" + rowIndex);
  }
}

function Detalle_Suscripcion_Red_de_Especialistas_ProveedoresCancelRow(rowIndex) {
    var prevData = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresTable.fnGetData(rowIndex);
    var data = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Suscripcion_Red_de_Especialistas_ProveedoresTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Suscripcion_Red_de_Especialistas_ProveedoresrowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Suscripcion_Red_de_Especialistas_ProveedoresGrid(Detalle_Suscripcion_Red_de_Especialistas_ProveedoresTable.fnGetData());
    Detalle_Suscripcion_Red_de_Especialistas_ProveedorescountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Suscripcion_Red_de_Especialistas_ProveedoresFromDataTable() {
    var Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData = [];
    var gridData = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData.push({
                Folio: gridData[i].Folio

                ,Plan_de_Suscripcion: gridData[i].Plan_de_Suscripcion
                ,Fecha_inicio: gridData[i].Fecha_inicio
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

    for (i = 0; i < removedDetalle_Suscripcion_Red_de_Especialistas_ProveedoresData.length; i++) {
        if (removedDetalle_Suscripcion_Red_de_Especialistas_ProveedoresData[i] != null && removedDetalle_Suscripcion_Red_de_Especialistas_ProveedoresData[i].Folio > 0)
            Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData.push({
                Folio: removedDetalle_Suscripcion_Red_de_Especialistas_ProveedoresData[i].Folio

                ,Plan_de_Suscripcion: removedDetalle_Suscripcion_Red_de_Especialistas_ProveedoresData[i].Plan_de_Suscripcion
                ,Fecha_inicio: removedDetalle_Suscripcion_Red_de_Especialistas_ProveedoresData[i].Fecha_inicio
                ,Fecha_fin: removedDetalle_Suscripcion_Red_de_Especialistas_ProveedoresData[i].Fecha_fin
                ,Costo: removedDetalle_Suscripcion_Red_de_Especialistas_ProveedoresData[i].Costo
                ,ContratoInfo: {
                    FileName: removedDetalle_Suscripcion_Red_de_Especialistas_ProveedoresData[i].ContratoFileInfo.FileName, 
                    FileId: removedDetalle_Suscripcion_Red_de_Especialistas_ProveedoresData[i].ContratoFileInfo.FileId, 
                    FileSize: removedDetalle_Suscripcion_Red_de_Especialistas_ProveedoresData[i].ContratoFileInfo.FileSize,
                    Control: removedDetalle_Suscripcion_Red_de_Especialistas_ProveedoresData[i].ContratoDetail != null && removedDetalle_Suscripcion_Red_de_Especialistas_ProveedoresData[i].ContratoDetail.files.length > 0 ? removedDetalle_Suscripcion_Red_de_Especialistas_ProveedoresData[i].ContratoDetail.files[0] : null,
                    ContratoRemoveFile: removedDetalle_Suscripcion_Red_de_Especialistas_ProveedoresData[i].ContratoDetail != null
                }
                ,Firmo_Contrato: removedDetalle_Suscripcion_Red_de_Especialistas_ProveedoresData[i].Firmo_Contrato
                ,Estatus: removedDetalle_Suscripcion_Red_de_Especialistas_ProveedoresData[i].Estatus

                , Removed: true
            });
    }	

    return Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData;
}

function Detalle_Suscripcion_Red_de_Especialistas_ProveedoresEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Suscripcion_Red_de_Especialistas_ProveedoresTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Suscripcion_Red_de_Especialistas_ProveedorescountRowsChecked++;
    var Detalle_Suscripcion_Red_de_Especialistas_ProveedoresRowElement = "Detalle_Suscripcion_Red_de_Especialistas_Proveedores_" + rowIndex.toString();
    var prevData = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresTable.fnGetData(rowIndexTable );
    var row = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Suscripcion_Red_de_Especialistas_Proveedores_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresGetUpdateRowControls(prevData, "Detalle_Suscripcion_Red_de_Especialistas_Proveedores_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Suscripcion_Red_de_Especialistas_ProveedoresRowElement + "')){ Detalle_Suscripcion_Red_de_Especialistas_ProveedoresInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_Suscripcion_Red_de_Especialistas_ProveedoresCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Suscripcion_Red_de_Especialistas_ProveedoresGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Suscripcion_Red_de_Especialistas_ProveedoresGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_Suscripcion_Red_de_Especialistas_ProveedoresValidation();
    initiateUIControls();
    $('.Detalle_Suscripcion_Red_de_Especialistas_Proveedores' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Suscripcion_Red_de_Especialistas_Proveedores(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Suscripcion_Red_de_Especialistas_ProveedoresfnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresTable.fnGetData().length;
    Detalle_Suscripcion_Red_de_Especialistas_ProveedoresfnClickAddRow();
    GetAddDetalle_Suscripcion_Red_de_Especialistas_ProveedoresPopup(currentRowIndex, 0);
}

function Detalle_Suscripcion_Red_de_Especialistas_ProveedoresEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Suscripcion_Red_de_Especialistas_ProveedoresRowElement = "Detalle_Suscripcion_Red_de_Especialistas_Proveedores_" + rowIndex.toString();
    var prevData = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresTable.fnGetData(rowIndexTable);
    GetAddDetalle_Suscripcion_Red_de_Especialistas_ProveedoresPopup(rowIndex, 1, prevData.Folio);

    $('#Detalle_Suscripcion_Red_de_Especialistas_ProveedoresPlan_de_Suscripcion').val(prevData.Plan_de_Suscripcion);
    $('#Detalle_Suscripcion_Red_de_Especialistas_ProveedoresFecha_inicio').val(prevData.Fecha_inicio);
    $('#Detalle_Suscripcion_Red_de_Especialistas_ProveedoresFecha_fin').val(prevData.Fecha_fin);
    $('#Detalle_Suscripcion_Red_de_Especialistas_ProveedoresCosto').val(prevData.Costo);

    $('#Detalle_Suscripcion_Red_de_Especialistas_ProveedoresFirmo_Contrato').prop('checked', prevData.Firmo_Contrato);
    $('#Detalle_Suscripcion_Red_de_Especialistas_ProveedoresEstatus').val(prevData.Estatus);

    initiateUIControls();





    $('#existingContrato').html(prevData.ContratoFileDetail == null && (prevData.ContratoFileInfo.FileId == null || prevData.ContratoFileInfo.FileId <= 0) ? $.parseHTML(GetFileUploader()) : GetFileInfo(prevData.ContratoFileInfo, prevData.ContratoFileDetail));



}

function Detalle_Suscripcion_Red_de_Especialistas_ProveedoresAddInsertRow() {
    if (Detalle_Suscripcion_Red_de_Especialistas_ProveedoresinsertRowCurrentIndex < 1)
    {
        Detalle_Suscripcion_Red_de_Especialistas_ProveedoresinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Plan_de_Suscripcion: ""
        ,Fecha_inicio: ""
        ,Fecha_fin: ""
        ,Costo: ""
        ,ContratoFileInfo: ""
        ,Firmo_Contrato: ""
        ,Estatus: ""

    }
}

function Detalle_Suscripcion_Red_de_Especialistas_ProveedoresfnClickAddRow() {
    Detalle_Suscripcion_Red_de_Especialistas_ProveedorescountRowsChecked++;
    Detalle_Suscripcion_Red_de_Especialistas_ProveedoresTable.fnAddData(Detalle_Suscripcion_Red_de_Especialistas_ProveedoresAddInsertRow(), true);
    Detalle_Suscripcion_Red_de_Especialistas_ProveedoresTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_Suscripcion_Red_de_Especialistas_ProveedoresGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_Suscripcion_Red_de_Especialistas_ProveedoresGrid tbody tr:nth-of-type(' + (Detalle_Suscripcion_Red_de_Especialistas_ProveedoresinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Suscripcion_Red_de_Especialistas_Proveedores("Detalle_Suscripcion_Red_de_Especialistas_Proveedores_", "_" + Detalle_Suscripcion_Red_de_Especialistas_ProveedoresinsertRowCurrentIndex);
}

function Detalle_Suscripcion_Red_de_Especialistas_ProveedoresClearGridData() {
    Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData = [];
    Detalle_Suscripcion_Red_de_Especialistas_ProveedoresdeletedItem = [];
    Detalle_Suscripcion_Red_de_Especialistas_ProveedoresDataMain = [];
    Detalle_Suscripcion_Red_de_Especialistas_ProveedoresDataMainPages = [];
    Detalle_Suscripcion_Red_de_Especialistas_ProveedoresnewItemCount = 0;
    Detalle_Suscripcion_Red_de_Especialistas_ProveedoresmaxItemIndex = 0;
    $("#Detalle_Suscripcion_Red_de_Especialistas_ProveedoresGrid").DataTable().clear();
    $("#Detalle_Suscripcion_Red_de_Especialistas_ProveedoresGrid").DataTable().destroy();
}

//Used to Get Proveedores Information
function GetDetalle_Suscripcion_Red_de_Especialistas_Proveedores() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData[i].Folio);

        form_data.append('[' + i + '].Plan_de_Suscripcion', Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData[i].Plan_de_Suscripcion);
        form_data.append('[' + i + '].Fecha_inicio', Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData[i].Fecha_inicio);
        form_data.append('[' + i + '].Fecha_fin', Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData[i].Fecha_fin);
        form_data.append('[' + i + '].Costo', Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData[i].Costo.toString().replace('$',''));
        form_data.append('[' + i + '].ContratoInfo.FileId', Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData[i].ContratoInfo.FileId);
        form_data.append('[' + i + '].ContratoInfo.FileName', Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData[i].ContratoInfo.FileName);
        form_data.append('[' + i + '].ContratoInfo.FileSize', Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData[i].ContratoInfo.FileSize);
        form_data.append('[' + i + '].ContratoInfo.Control', Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData[i].ContratoInfo.Control);
        form_data.append('[' + i + '].ContratoInfo.RemoveFile', Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData[i].ContratoInfo.ArchivoRemoveFile);
        form_data.append('[' + i + '].Firmo_Contrato', Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData[i].Firmo_Contrato);
        form_data.append('[' + i + '].Estatus', Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData[i].Estatus);

        form_data.append('[' + i + '].Removed', Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData[i].Removed);
    }
    return form_data;
}
function Detalle_Suscripcion_Red_de_Especialistas_ProveedoresInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Suscripcion_Red_de_Especialistas_Proveedores("Detalle_Suscripcion_Red_de_Especialistas_ProveedoresTable", rowIndex)) {
    var prevData = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresTable.fnGetData(rowIndex);
    var data = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Plan_de_Suscripcion: $('#Detalle_Suscripcion_Red_de_Especialistas_ProveedoresPlan_de_Suscripcion').val()
        ,Fecha_inicio: $('#Detalle_Suscripcion_Red_de_Especialistas_ProveedoresFecha_inicio').val()
        ,Fecha_fin: $('#Detalle_Suscripcion_Red_de_Especialistas_ProveedoresFecha_fin').val()
        ,Costo: $('#Detalle_Suscripcion_Red_de_Especialistas_ProveedoresCosto').val()
        ,ContratoFileInfo: { ContratoFileName: prevData.ContratoFileInfo.FileName, ContratoFileId: prevData.ContratoFileInfo.FileId, ContratoFileSize: prevData.ContratoFileInfo.FileSize }
        ,ContratoFileDetail: $('#Contrato').find('label').length == 0 ? $('#ContratoFileInfoPop')[0] : prevData.ContratoFileDetail
        ,Firmo_Contrato: $('#Detalle_Suscripcion_Red_de_Especialistas_ProveedoresFirmo_Contrato').is(':checked')
        ,Estatus: $('#Detalle_Suscripcion_Red_de_Especialistas_ProveedoresEstatus').val()

    }

    Detalle_Suscripcion_Red_de_Especialistas_ProveedoresTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Suscripcion_Red_de_Especialistas_ProveedoresrowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Suscripcion_Red_de_Especialistas_Proveedores-form').modal({ show: false });
    $('#AddDetalle_Suscripcion_Red_de_Especialistas_Proveedores-form').modal('hide');
    Detalle_Suscripcion_Red_de_Especialistas_ProveedoresEditRow(rowIndex);
    Detalle_Suscripcion_Red_de_Especialistas_ProveedoresInsertRow(rowIndex);
    //}
}
function Detalle_Suscripcion_Red_de_Especialistas_ProveedoresRemoveAddRow(rowIndex) {
    Detalle_Suscripcion_Red_de_Especialistas_ProveedoresTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Suscripcion_Red_de_Especialistas_Proveedores MultiRow


$(function () {
    function Detalle_Sucursales_ProveedoresinitializeMainArray(totalCount) {
        if (Detalle_Sucursales_ProveedoresDataMain.length != totalCount && !Detalle_Sucursales_ProveedoresDataMainInitialized) {
            Detalle_Sucursales_ProveedoresDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Sucursales_ProveedoresDataMain[i] = null;
            }
        }
    }
    function Detalle_Sucursales_ProveedoresremoveFromMainArray() {
        for (var j = 0; j < Detalle_Sucursales_ProveedoresdeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Sucursales_ProveedoresDataMain.length; i++) {
                if (Detalle_Sucursales_ProveedoresDataMain[i] != null && Detalle_Sucursales_ProveedoresDataMain[i].Id == Detalle_Sucursales_ProveedoresdeletedItem[j]) {
                    hDetalle_Sucursales_ProveedoresDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Sucursales_ProveedorescopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Sucursales_ProveedoresDataMain.length; i++) {
            data[i] = Detalle_Sucursales_ProveedoresDataMain[i];

        }
        return data;
    }
    function Detalle_Sucursales_ProveedoresgetNewResult() {
        var newData = copyMainDetalle_Sucursales_ProveedoresArray();

        for (var i = 0; i < Detalle_Sucursales_ProveedoresData.length; i++) {
            if (Detalle_Sucursales_ProveedoresData[i].Removed == null || Detalle_Sucursales_ProveedoresData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Sucursales_ProveedoresData[i]);
            }
        }
        return newData;
    }
    function Detalle_Sucursales_ProveedorespushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Sucursales_ProveedoresDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Sucursales_ProveedoresDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Detalle_Suscripcion_Red_de_Especialistas_ProveedoresinitializeMainArray(totalCount) {
        if (Detalle_Suscripcion_Red_de_Especialistas_ProveedoresDataMain.length != totalCount && !Detalle_Suscripcion_Red_de_Especialistas_ProveedoresDataMainInitialized) {
            Detalle_Suscripcion_Red_de_Especialistas_ProveedoresDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Suscripcion_Red_de_Especialistas_ProveedoresDataMain[i] = null;
            }
        }
    }
    function Detalle_Suscripcion_Red_de_Especialistas_ProveedoresremoveFromMainArray() {
        for (var j = 0; j < Detalle_Suscripcion_Red_de_Especialistas_ProveedoresdeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Suscripcion_Red_de_Especialistas_ProveedoresDataMain.length; i++) {
                if (Detalle_Suscripcion_Red_de_Especialistas_ProveedoresDataMain[i] != null && Detalle_Suscripcion_Red_de_Especialistas_ProveedoresDataMain[i].Id == Detalle_Suscripcion_Red_de_Especialistas_ProveedoresdeletedItem[j]) {
                    hDetalle_Suscripcion_Red_de_Especialistas_ProveedoresDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Suscripcion_Red_de_Especialistas_ProveedorescopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Suscripcion_Red_de_Especialistas_ProveedoresDataMain.length; i++) {
            data[i] = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresDataMain[i];

        }
        return data;
    }
    function Detalle_Suscripcion_Red_de_Especialistas_ProveedoresgetNewResult() {
        var newData = copyMainDetalle_Suscripcion_Red_de_Especialistas_ProveedoresArray();

        for (var i = 0; i < Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData.length; i++) {
            if (Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData[i].Removed == null || Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData[i]);
            }
        }
        return newData;
    }
    function Detalle_Suscripcion_Red_de_Especialistas_ProveedorespushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Suscripcion_Red_de_Especialistas_ProveedoresDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Suscripcion_Red_de_Especialistas_ProveedoresDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }

});

//Grid GetAutocomplete
var AutoCompleteTipo_de_SucursalData = [];
function GetAutoCompleteDetalle_Sucursales_Proveedores_Tipo_de_Sucursal_Tipo_de_SucursalData(data) {
	AutoCompleteTipo_de_SucursalData = [];
    for (var i = 0; i < data.length; i++) {
        AutoCompleteTipo_de_SucursalData.push({
            id: data[i].Clave,
            text: data[i].Descripcion
        });
    }
    return AutoCompleteTipo_de_SucursalData;
}

//Grid GetAutocomplete



function getDropdown(elementKey) {
    var labelSelect = $("#Proveedores_cmbLabelSelect").val();
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
    $('#CreateProveedores')[0].reset();
    ClearFormControls();
    $("#FolioId").val("0");
                Detalle_Sucursales_ProveedoresClearGridData();
                Detalle_Suscripcion_Red_de_Especialistas_ProveedoresClearGridData();

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreateProveedores').trigger('reset');
    $('#CreateProveedores').find(':input').each(function () {
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
    var $myForm = $('#CreateProveedores');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    if (Detalle_Sucursales_ProveedorescountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Sucursales_Proveedores();
        return false;
    }
    if (Detalle_Suscripcion_Red_de_Especialistas_ProveedorescountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Suscripcion_Red_de_Especialistas_Proveedores();
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblFolio").text("0");
}
$(document).ready(function () {
    $("form#CreateProveedores").submit(function (e) {
        e.preventDefault();
        return false;
    });
	$("form#CreateProveedores").on('click', '#ProveedoresCancelar', function () {
	  if (!isPartial) {
        ProveedoresBackToGrid();
	  } else {
            window.close();
      }
    });
	$("form#CreateProveedores").on('click', '#ProveedoresGuardar', function () {
		$('#ProveedoresGuardar').attr('disabled', true);
		$('#ProveedoresGuardar').unbind()
        if (EjecutarValidacionesAntesDeGuardar() && CheckValidation()) {
				if (!SendProveedoresData(function () {
					EjecutarValidacionesDespuesDeGuardar();
					if (!isPartial)
						ProveedoresBackToGrid();
					else {						
						if (!isMR)
							window.opener.RefreshCatalog('Proveedores', nameAttribute);
						else {
							var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
							if(!control.hasClass('AutoComplete'))
							{
							if (control.attr("data-isfilter") == "true") {
									eval(GetReglaFilter(control,  $(window.opener.document.getElementById('ObjectId')).val()));								    
								}
								else 
								{
									eval('window.opener.Get' + nameMR + '_ProveedoresItem()');
									var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
									control.html(eval('window.opener.Get' + nameMR + '_ProveedoresDropDown().get(0)').innerHTML);  
								}								
							}
						}
						window.close();						
						}
				})) {
					$('#ProveedoresGuardar').removeAttr('disabled');
					$('#ProveedoresGuardar').bind()
				}
		}
		else {
			$('#ProveedoresGuardar').removeAttr('disabled');
			$('#ProveedoresGuardar').bind()
		}
    });
	$("form#CreateProveedores").on('click', '#ProveedoresGuardarYNuevo', function () {	
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation()) {
				SendProveedoresData(function () {
					ClearControls();
					ClearAttachmentsDiv();
					ResetClaveLabel();
	                getDetalle_Sucursales_ProveedoresData();
                getDetalle_Suscripcion_Red_de_Especialistas_ProveedoresData();

					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Proveedores', nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_ProveedoresItem()');                           
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
                            control.html(eval('window.opener.Get' + nameMR + '_ProveedoresDropDown().get(0)').innerHTML);   
					    }	
					}						
					EjecutarValidacionesDespuesDeGuardar();				
			setIsNew();
			EjecutarValidacionesAlComienzo();
				});
			}
		}		
    });
    $("form#CreateProveedores").on('click', '#ProveedoresGuardarYCopia', function () {
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendProveedoresData(function (currentId) {
					$("#FolioId").val("0");
	                Detalle_Sucursales_ProveedoresClearGridData();
                Detalle_Suscripcion_Red_de_Especialistas_ProveedoresClearGridData();

					ResetClaveLabel();
					$("#ReferenceFolio").val(currentId);
	                getDetalle_Sucursales_ProveedoresData();
                getDetalle_Suscripcion_Red_de_Especialistas_ProveedoresData();

					EjecutarValidacionesDespuesDeGuardar();		
					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Proveedores',nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_ProveedoresItem()');                          
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);						
							control.html(eval('window.opener.Get' + nameMR + '_ProveedoresDropDown().get(0)').innerHTML);                          
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



var ProveedoresisdisplayBusinessPropery = false;
ProveedoresDisplayBusinessRuleButtons(ProveedoresisdisplayBusinessPropery);
function ProveedoresDisplayBusinessRule() {
    if (!ProveedoresisdisplayBusinessPropery) {
        $('#CreateProveedores').find('.col-sm-8').each(function () {
			var div =$(this); 
			if ($(this).find('.input-group').length >0)
				div  =  $(this).find('.input-group').first().hasClass('date')? $(this): $(this).find('.input-group').first();	
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = div.data('field-id');
            var fieldName = div.data('field-name');
            var attribute = div.data('attribute');
            mainElementAttributes += '<div class="ProveedoresdisplayBusinessPropery"><button onclick="ProveedoresGetBusinessRule()" type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#ProveedoresBusinessRule-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.ProveedoresdisplayBusinessPropery').remove();
    }
    ProveedoresDisplayBusinessRuleButtons(!ProveedoresisdisplayBusinessPropery);
    ProveedoresisdisplayBusinessPropery = (ProveedoresisdisplayBusinessPropery ? false : true);
}
function ProveedoresDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}

