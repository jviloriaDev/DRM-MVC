        function RemoveAttachmentMainCedula_Fiscal () {
            $("#hdnRemoveCedula_Fiscal").val("1");
            $("#divAttachmentCedula_Fiscal").hide();
        }


//Begin Declarations for Foreigns fields for Detalle_Contactos_Empresa MultiRow
var Detalle_Contactos_EmpresacountRowsChecked = 0;





function GetDetalle_Contactos_Empresa_areas_EmpresasName(Id) {
    for (var i = 0; i < Detalle_Contactos_Empresa_areas_EmpresasItems.length; i++) {
        if (Detalle_Contactos_Empresa_areas_EmpresasItems[i].Clave == Id) {
            return Detalle_Contactos_Empresa_areas_EmpresasItems[i].Nombre;
        }
    }
    return "";
}

function GetDetalle_Contactos_Empresa_areas_EmpresasDropDown() {
    var Detalle_Contactos_Empresa_areas_EmpresasDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Contactos_Empresa_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Contactos_Empresa_areas_EmpresasDropdown);
    if(Detalle_Contactos_Empresa_areas_EmpresasItems != null)
    {
       for (var i = 0; i < Detalle_Contactos_Empresa_areas_EmpresasItems.length; i++) {
           $('<option />', { value: Detalle_Contactos_Empresa_areas_EmpresasItems[i].Clave, text:    Detalle_Contactos_Empresa_areas_EmpresasItems[i].Nombre }).appendTo(Detalle_Contactos_Empresa_areas_EmpresasDropdown);
       }
    }
    return Detalle_Contactos_Empresa_areas_EmpresasDropdown;
}



function GetDetalle_Contactos_Empresa_EstatusName(Id) {
    for (var i = 0; i < Detalle_Contactos_Empresa_EstatusItems.length; i++) {
        if (Detalle_Contactos_Empresa_EstatusItems[i].Clave == Id) {
            return Detalle_Contactos_Empresa_EstatusItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Contactos_Empresa_EstatusDropDown() {
    var Detalle_Contactos_Empresa_EstatusDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Contactos_Empresa_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Contactos_Empresa_EstatusDropdown);
    if(Detalle_Contactos_Empresa_EstatusItems != null)
    {
       for (var i = 0; i < Detalle_Contactos_Empresa_EstatusItems.length; i++) {
           $('<option />', { value: Detalle_Contactos_Empresa_EstatusItems[i].Clave, text:    Detalle_Contactos_Empresa_EstatusItems[i].Descripcion }).appendTo(Detalle_Contactos_Empresa_EstatusDropdown);
       }
    }
    return Detalle_Contactos_Empresa_EstatusDropdown;
}


function GetInsertDetalle_Contactos_EmpresaRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $($.parseHTML(inputData)).addClass('Detalle_Contactos_Empresa_Nombre_completo Nombre_completo').attr('id', 'Detalle_Contactos_Empresa_Nombre_completo_' + index).attr('data-field', 'Nombre_completo');
    columnData[1] = $($.parseHTML(inputData)).addClass('Detalle_Contactos_Empresa_Correo Correo').attr('id', 'Detalle_Contactos_Empresa_Correo_' + index).attr('data-field', 'Correo');
    columnData[2] = $($.parseHTML(inputData)).addClass('Detalle_Contactos_Empresa_Telefono Telefono').attr('id', 'Detalle_Contactos_Empresa_Telefono_' + index).attr('data-field', 'Telefono');
    columnData[3] = $($.parseHTML(GetGridCheckBox())).addClass('Detalle_Contactos_Empresa_Contacto_Principal Contacto_Principal').attr('id', 'Detalle_Contactos_Empresa_Contacto_Principal_' + index).attr('data-field', 'Contacto_Principal');
    columnData[4] = $(GetDetalle_Contactos_Empresa_areas_EmpresasDropDown()).addClass('Detalle_Contactos_Empresa_Area Area').attr('id', 'Detalle_Contactos_Empresa_Area_' + index).attr('data-field', 'Area').after($.parseHTML(addNew('Detalle_Contactos_Empresa', 'areas_Empresas', 'Area', 258506)));
    columnData[5] = $($.parseHTML(GetGridCheckBox())).addClass('Detalle_Contactos_Empresa_Acceso_al_Sistema Acceso_al_Sistema').attr('id', 'Detalle_Contactos_Empresa_Acceso_al_Sistema_' + index).attr('data-field', 'Acceso_al_Sistema');
    columnData[6] = $($.parseHTML(inputData)).addClass('Detalle_Contactos_Empresa_Nombre_de_usuario Nombre_de_usuario').attr('id', 'Detalle_Contactos_Empresa_Nombre_de_usuario_' + index).attr('data-field', 'Nombre_de_usuario');
    columnData[7] = $($.parseHTML(GetGridCheckBox())).addClass('Detalle_Contactos_Empresa_Recibe_Alertas Recibe_Alertas').attr('id', 'Detalle_Contactos_Empresa_Recibe_Alertas_' + index).attr('data-field', 'Recibe_Alertas');
    columnData[8] = $(GetDetalle_Contactos_Empresa_EstatusDropDown()).addClass('Detalle_Contactos_Empresa_Estatus Estatus').attr('id', 'Detalle_Contactos_Empresa_Estatus_' + index).attr('data-field', 'Estatus').after($.parseHTML(addNew('Detalle_Contactos_Empresa', 'Estatus', 'Estatus', 258510)));


    initiateUIControls();
    return columnData;
}

function Detalle_Contactos_EmpresaInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Contactos_Empresa("Detalle_Contactos_Empresa_", "_" + rowIndex)) {
    var iPage = Detalle_Contactos_EmpresaTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Contactos_Empresa';
    var prevData = Detalle_Contactos_EmpresaTable.fnGetData(rowIndex);
    var data = Detalle_Contactos_EmpresaTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Nombre_completo:  data.childNodes[counter++].childNodes[0].value
        ,Correo:  data.childNodes[counter++].childNodes[0].value
        ,Telefono:  data.childNodes[counter++].childNodes[0].value
        ,Contacto_Principal: $(data.childNodes[counter++].childNodes[2]).is(':checked')
        ,Area:  data.childNodes[counter++].childNodes[0].value
        ,Acceso_al_Sistema: $(data.childNodes[counter++].childNodes[2]).is(':checked')
        ,Nombre_de_usuario:  data.childNodes[counter++].childNodes[0].value
        ,Recibe_Alertas: $(data.childNodes[counter++].childNodes[2]).is(':checked')
        ,Estatus:  data.childNodes[counter++].childNodes[0].value

    }
    Detalle_Contactos_EmpresaTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Contactos_EmpresarowCreationGrid(data, newData, rowIndex);
    Detalle_Contactos_EmpresaTable.fnPageChange(iPage);
    Detalle_Contactos_EmpresacountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Contactos_Empresa("Detalle_Contactos_Empresa_", "_" + rowIndex);
  }
}

function Detalle_Contactos_EmpresaCancelRow(rowIndex) {
    var prevData = Detalle_Contactos_EmpresaTable.fnGetData(rowIndex);
    var data = Detalle_Contactos_EmpresaTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Contactos_EmpresaTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Contactos_EmpresarowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Contactos_EmpresaGrid(Detalle_Contactos_EmpresaTable.fnGetData());
    Detalle_Contactos_EmpresacountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Contactos_EmpresaFromDataTable() {
    var Detalle_Contactos_EmpresaData = [];
    var gridData = Detalle_Contactos_EmpresaTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Contactos_EmpresaData.push({
                Folio: gridData[i].Folio

                ,Nombre_completo: gridData[i].Nombre_completo
                ,Correo: gridData[i].Correo
                ,Telefono: gridData[i].Telefono
                ,Contacto_Principal: gridData[i].Contacto_Principal
                ,Area: gridData[i].Area
                ,Acceso_al_Sistema: gridData[i].Acceso_al_Sistema
                ,Nombre_de_usuario: gridData[i].Nombre_de_usuario
                ,Recibe_Alertas: gridData[i].Recibe_Alertas
                ,Estatus: gridData[i].Estatus

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Contactos_EmpresaData.length; i++) {
        if (removedDetalle_Contactos_EmpresaData[i] != null && removedDetalle_Contactos_EmpresaData[i].Folio > 0)
            Detalle_Contactos_EmpresaData.push({
                Folio: removedDetalle_Contactos_EmpresaData[i].Folio

                ,Nombre_completo: removedDetalle_Contactos_EmpresaData[i].Nombre_completo
                ,Correo: removedDetalle_Contactos_EmpresaData[i].Correo
                ,Telefono: removedDetalle_Contactos_EmpresaData[i].Telefono
                ,Contacto_Principal: removedDetalle_Contactos_EmpresaData[i].Contacto_Principal
                ,Area: removedDetalle_Contactos_EmpresaData[i].Area
                ,Acceso_al_Sistema: removedDetalle_Contactos_EmpresaData[i].Acceso_al_Sistema
                ,Nombre_de_usuario: removedDetalle_Contactos_EmpresaData[i].Nombre_de_usuario
                ,Recibe_Alertas: removedDetalle_Contactos_EmpresaData[i].Recibe_Alertas
                ,Estatus: removedDetalle_Contactos_EmpresaData[i].Estatus

                , Removed: true
            });
    }	

    return Detalle_Contactos_EmpresaData;
}

function Detalle_Contactos_EmpresaEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Contactos_EmpresaTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Contactos_EmpresacountRowsChecked++;
    var Detalle_Contactos_EmpresaRowElement = "Detalle_Contactos_Empresa_" + rowIndex.toString();
    var prevData = Detalle_Contactos_EmpresaTable.fnGetData(rowIndexTable );
    var row = Detalle_Contactos_EmpresaTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Contactos_Empresa_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Contactos_EmpresaGetUpdateRowControls(prevData, "Detalle_Contactos_Empresa_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Contactos_EmpresaRowElement + "')){ Detalle_Contactos_EmpresaInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_Contactos_EmpresaCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Contactos_EmpresaGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Contactos_EmpresaGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_Contactos_EmpresaValidation();
    initiateUIControls();
    $('.Detalle_Contactos_Empresa' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Contactos_Empresa(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Contactos_EmpresafnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Contactos_EmpresaTable.fnGetData().length;
    Detalle_Contactos_EmpresafnClickAddRow();
    GetAddDetalle_Contactos_EmpresaPopup(currentRowIndex, 0);
}

function Detalle_Contactos_EmpresaEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Contactos_EmpresaTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Contactos_EmpresaRowElement = "Detalle_Contactos_Empresa_" + rowIndex.toString();
    var prevData = Detalle_Contactos_EmpresaTable.fnGetData(rowIndexTable);
    GetAddDetalle_Contactos_EmpresaPopup(rowIndex, 1, prevData.Folio);

    $('#Detalle_Contactos_EmpresaNombre_completo').val(prevData.Nombre_completo);
    $('#Detalle_Contactos_EmpresaCorreo').val(prevData.Correo);
    $('#Detalle_Contactos_EmpresaTelefono').val(prevData.Telefono);
    $('#Detalle_Contactos_EmpresaContacto_Principal').prop('checked', prevData.Contacto_Principal);
    $('#Detalle_Contactos_EmpresaArea').val(prevData.Area);
    $('#Detalle_Contactos_EmpresaAcceso_al_Sistema').prop('checked', prevData.Acceso_al_Sistema);
    $('#Detalle_Contactos_EmpresaNombre_de_usuario').val(prevData.Nombre_de_usuario);
    $('#Detalle_Contactos_EmpresaRecibe_Alertas').prop('checked', prevData.Recibe_Alertas);
    $('#Detalle_Contactos_EmpresaEstatus').val(prevData.Estatus);

    initiateUIControls();











}

function Detalle_Contactos_EmpresaAddInsertRow() {
    if (Detalle_Contactos_EmpresainsertRowCurrentIndex < 1)
    {
        Detalle_Contactos_EmpresainsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Nombre_completo: ""
        ,Correo: ""
        ,Telefono: ""
        ,Contacto_Principal: ""
        ,Area: ""
        ,Acceso_al_Sistema: ""
        ,Nombre_de_usuario: ""
        ,Recibe_Alertas: ""
        ,Estatus: ""

    }
}

function Detalle_Contactos_EmpresafnClickAddRow() {
    Detalle_Contactos_EmpresacountRowsChecked++;
    Detalle_Contactos_EmpresaTable.fnAddData(Detalle_Contactos_EmpresaAddInsertRow(), true);
    Detalle_Contactos_EmpresaTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_Contactos_EmpresaGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_Contactos_EmpresaGrid tbody tr:nth-of-type(' + (Detalle_Contactos_EmpresainsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Contactos_Empresa("Detalle_Contactos_Empresa_", "_" + Detalle_Contactos_EmpresainsertRowCurrentIndex);
}

function Detalle_Contactos_EmpresaClearGridData() {
    Detalle_Contactos_EmpresaData = [];
    Detalle_Contactos_EmpresadeletedItem = [];
    Detalle_Contactos_EmpresaDataMain = [];
    Detalle_Contactos_EmpresaDataMainPages = [];
    Detalle_Contactos_EmpresanewItemCount = 0;
    Detalle_Contactos_EmpresamaxItemIndex = 0;
    $("#Detalle_Contactos_EmpresaGrid").DataTable().clear();
    $("#Detalle_Contactos_EmpresaGrid").DataTable().destroy();
}

//Used to Get Empresas Information
function GetDetalle_Contactos_Empresa() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Contactos_EmpresaData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Contactos_EmpresaData[i].Folio);

        form_data.append('[' + i + '].Nombre_completo', Detalle_Contactos_EmpresaData[i].Nombre_completo);
        form_data.append('[' + i + '].Correo', Detalle_Contactos_EmpresaData[i].Correo);
        form_data.append('[' + i + '].Telefono', Detalle_Contactos_EmpresaData[i].Telefono);
        form_data.append('[' + i + '].Contacto_Principal', Detalle_Contactos_EmpresaData[i].Contacto_Principal);
        form_data.append('[' + i + '].Area', Detalle_Contactos_EmpresaData[i].Area);
        form_data.append('[' + i + '].Acceso_al_Sistema', Detalle_Contactos_EmpresaData[i].Acceso_al_Sistema);
        form_data.append('[' + i + '].Nombre_de_usuario', Detalle_Contactos_EmpresaData[i].Nombre_de_usuario);
        form_data.append('[' + i + '].Recibe_Alertas', Detalle_Contactos_EmpresaData[i].Recibe_Alertas);
        form_data.append('[' + i + '].Estatus', Detalle_Contactos_EmpresaData[i].Estatus);

        form_data.append('[' + i + '].Removed', Detalle_Contactos_EmpresaData[i].Removed);
    }
    return form_data;
}
function Detalle_Contactos_EmpresaInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Contactos_Empresa("Detalle_Contactos_EmpresaTable", rowIndex)) {
    var prevData = Detalle_Contactos_EmpresaTable.fnGetData(rowIndex);
    var data = Detalle_Contactos_EmpresaTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Nombre_completo: $('#Detalle_Contactos_EmpresaNombre_completo').val()
        ,Correo: $('#Detalle_Contactos_EmpresaCorreo').val()
        ,Telefono: $('#Detalle_Contactos_EmpresaTelefono').val()
        ,Contacto_Principal: $('#Detalle_Contactos_EmpresaContacto_Principal').is(':checked')
        ,Area: $('#Detalle_Contactos_EmpresaArea').val()
        ,Acceso_al_Sistema: $('#Detalle_Contactos_EmpresaAcceso_al_Sistema').is(':checked')
        ,Nombre_de_usuario: $('#Detalle_Contactos_EmpresaNombre_de_usuario').val()
        ,Recibe_Alertas: $('#Detalle_Contactos_EmpresaRecibe_Alertas').is(':checked')
        ,Estatus: $('#Detalle_Contactos_EmpresaEstatus').val()

    }

    Detalle_Contactos_EmpresaTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Contactos_EmpresarowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Contactos_Empresa-form').modal({ show: false });
    $('#AddDetalle_Contactos_Empresa-form').modal('hide');
    Detalle_Contactos_EmpresaEditRow(rowIndex);
    Detalle_Contactos_EmpresaInsertRow(rowIndex);
    //}
}
function Detalle_Contactos_EmpresaRemoveAddRow(rowIndex) {
    Detalle_Contactos_EmpresaTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Contactos_Empresa MultiRow
//Begin Declarations for Foreigns fields for Detalle_Suscripciones_Empresa MultiRow
var Detalle_Suscripciones_EmpresacountRowsChecked = 0;


function GetDetalle_Suscripciones_Empresa_Planes_de_SuscripcionName(Id) {
    for (var i = 0; i < Detalle_Suscripciones_Empresa_Planes_de_SuscripcionItems.length; i++) {
        if (Detalle_Suscripciones_Empresa_Planes_de_SuscripcionItems[i].Folio == Id) {
            return Detalle_Suscripciones_Empresa_Planes_de_SuscripcionItems[i].Nombre_del_Plan;
        }
    }
    return "";
}

function GetDetalle_Suscripciones_Empresa_Planes_de_SuscripcionDropDown() {
    var Detalle_Suscripciones_Empresa_Planes_de_SuscripcionDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Suscripciones_Empresa_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Suscripciones_Empresa_Planes_de_SuscripcionDropdown);
    if(Detalle_Suscripciones_Empresa_Planes_de_SuscripcionItems != null)
    {
       for (var i = 0; i < Detalle_Suscripciones_Empresa_Planes_de_SuscripcionItems.length; i++) {
           $('<option />', { value: Detalle_Suscripciones_Empresa_Planes_de_SuscripcionItems[i].Folio, text:    Detalle_Suscripciones_Empresa_Planes_de_SuscripcionItems[i].Nombre_del_Plan }).appendTo(Detalle_Suscripciones_Empresa_Planes_de_SuscripcionDropdown);
       }
    }
    return Detalle_Suscripciones_Empresa_Planes_de_SuscripcionDropdown;
}



function GetDetalle_Suscripciones_Empresa_Frecuencia_de_pago_EmpresasName(Id) {
    for (var i = 0; i < Detalle_Suscripciones_Empresa_Frecuencia_de_pago_EmpresasItems.length; i++) {
        if (Detalle_Suscripciones_Empresa_Frecuencia_de_pago_EmpresasItems[i].Clave == Id) {
            return Detalle_Suscripciones_Empresa_Frecuencia_de_pago_EmpresasItems[i].Nombre;
        }
    }
    return "";
}

function GetDetalle_Suscripciones_Empresa_Frecuencia_de_pago_EmpresasDropDown() {
    var Detalle_Suscripciones_Empresa_Frecuencia_de_pago_EmpresasDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Suscripciones_Empresa_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Suscripciones_Empresa_Frecuencia_de_pago_EmpresasDropdown);
    if(Detalle_Suscripciones_Empresa_Frecuencia_de_pago_EmpresasItems != null)
    {
       for (var i = 0; i < Detalle_Suscripciones_Empresa_Frecuencia_de_pago_EmpresasItems.length; i++) {
           $('<option />', { value: Detalle_Suscripciones_Empresa_Frecuencia_de_pago_EmpresasItems[i].Clave, text:    Detalle_Suscripciones_Empresa_Frecuencia_de_pago_EmpresasItems[i].Nombre }).appendTo(Detalle_Suscripciones_Empresa_Frecuencia_de_pago_EmpresasDropdown);
       }
    }
    return Detalle_Suscripciones_Empresa_Frecuencia_de_pago_EmpresasDropdown;
}

function GetDetalle_Suscripciones_Empresa_Estatus_de_SuscripcionName(Id) {
    for (var i = 0; i < Detalle_Suscripciones_Empresa_Estatus_de_SuscripcionItems.length; i++) {
        if (Detalle_Suscripciones_Empresa_Estatus_de_SuscripcionItems[i].Clave == Id) {
            return Detalle_Suscripciones_Empresa_Estatus_de_SuscripcionItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Suscripciones_Empresa_Estatus_de_SuscripcionDropDown() {
    var Detalle_Suscripciones_Empresa_Estatus_de_SuscripcionDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Suscripciones_Empresa_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Suscripciones_Empresa_Estatus_de_SuscripcionDropdown);
    if(Detalle_Suscripciones_Empresa_Estatus_de_SuscripcionItems != null)
    {
       for (var i = 0; i < Detalle_Suscripciones_Empresa_Estatus_de_SuscripcionItems.length; i++) {
           $('<option />', { value: Detalle_Suscripciones_Empresa_Estatus_de_SuscripcionItems[i].Clave, text:    Detalle_Suscripciones_Empresa_Estatus_de_SuscripcionItems[i].Descripcion }).appendTo(Detalle_Suscripciones_Empresa_Estatus_de_SuscripcionDropdown);
       }
    }
    return Detalle_Suscripciones_Empresa_Estatus_de_SuscripcionDropdown;
}


function GetInsertDetalle_Suscripciones_EmpresaRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Suscripciones_Empresa_Cantidad_de_Beneficiarios Cantidad_de_Beneficiarios').attr('id', 'Detalle_Suscripciones_Empresa_Cantidad_de_Beneficiarios_' + index).attr('data-field', 'Cantidad_de_Beneficiarios');
    columnData[1] = $(GetDetalle_Suscripciones_Empresa_Planes_de_SuscripcionDropDown()).addClass('Detalle_Suscripciones_Empresa_Suscripcion Suscripcion').attr('id', 'Detalle_Suscripciones_Empresa_Suscripcion_' + index).attr('data-field', 'Suscripcion').after($.parseHTML(addNew('Detalle_Suscripciones_Empresa', 'Planes_de_Suscripcion', 'Suscripcion', 258481)));
    columnData[2] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Suscripciones_Empresa_Fecha_de_inicio Fecha_de_inicio').attr('id', 'Detalle_Suscripciones_Empresa_Fecha_de_inicio_' + index).attr('data-field', 'Fecha_de_inicio');
    columnData[3] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Suscripciones_Empresa_Fecha_Fin Fecha_Fin').attr('id', 'Detalle_Suscripciones_Empresa_Fecha_Fin_' + index).attr('data-field', 'Fecha_Fin');
    columnData[4] = $($.parseHTML(inputData)).addClass('Detalle_Suscripciones_Empresa_Nombre_de_la_Suscripcion Nombre_de_la_Suscripcion').attr('id', 'Detalle_Suscripciones_Empresa_Nombre_de_la_Suscripcion_' + index).attr('data-field', 'Nombre_de_la_Suscripcion');
    columnData[5] = $(GetDetalle_Suscripciones_Empresa_Frecuencia_de_pago_EmpresasDropDown()).addClass('Detalle_Suscripciones_Empresa_Frecuencia_de_Pago Frecuencia_de_Pago').attr('id', 'Detalle_Suscripciones_Empresa_Frecuencia_de_Pago_' + index).attr('data-field', 'Frecuencia_de_Pago').after($.parseHTML(addNew('Detalle_Suscripciones_Empresa', 'Frecuencia_de_pago_Empresas', 'Frecuencia_de_Pago', 258485)));
    columnData[6] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Suscripciones_Empresa_Costo Costo').attr('id', 'Detalle_Suscripciones_Empresa_Costo_' + index).attr('data-field', 'Costo');
    columnData[7] = $(GetDetalle_Suscripciones_Empresa_Estatus_de_SuscripcionDropDown()).addClass('Detalle_Suscripciones_Empresa_Estatus Estatus').attr('id', 'Detalle_Suscripciones_Empresa_Estatus_' + index).attr('data-field', 'Estatus').after($.parseHTML(addNew('Detalle_Suscripciones_Empresa', 'Estatus_de_Suscripcion', 'Estatus', 258487)));


    initiateUIControls();
    return columnData;
}

function Detalle_Suscripciones_EmpresaInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Suscripciones_Empresa("Detalle_Suscripciones_Empresa_", "_" + rowIndex)) {
    var iPage = Detalle_Suscripciones_EmpresaTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Suscripciones_Empresa';
    var prevData = Detalle_Suscripciones_EmpresaTable.fnGetData(rowIndex);
    var data = Detalle_Suscripciones_EmpresaTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Cantidad_de_Beneficiarios: data.childNodes[counter++].childNodes[0].value
        ,Suscripcion:  data.childNodes[counter++].childNodes[0].value
        ,Fecha_de_inicio:  data.childNodes[counter++].childNodes[0].value
        ,Fecha_Fin:  data.childNodes[counter++].childNodes[0].value
        ,Nombre_de_la_Suscripcion:  data.childNodes[counter++].childNodes[0].value
        ,Frecuencia_de_Pago:  data.childNodes[counter++].childNodes[0].value
        ,Costo: data.childNodes[counter++].childNodes[0].value
        ,Estatus:  data.childNodes[counter++].childNodes[0].value

    }
    Detalle_Suscripciones_EmpresaTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Suscripciones_EmpresarowCreationGrid(data, newData, rowIndex);
    Detalle_Suscripciones_EmpresaTable.fnPageChange(iPage);
    Detalle_Suscripciones_EmpresacountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Suscripciones_Empresa("Detalle_Suscripciones_Empresa_", "_" + rowIndex);
  }
}

function Detalle_Suscripciones_EmpresaCancelRow(rowIndex) {
    var prevData = Detalle_Suscripciones_EmpresaTable.fnGetData(rowIndex);
    var data = Detalle_Suscripciones_EmpresaTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Suscripciones_EmpresaTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Suscripciones_EmpresarowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Suscripciones_EmpresaGrid(Detalle_Suscripciones_EmpresaTable.fnGetData());
    Detalle_Suscripciones_EmpresacountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Suscripciones_EmpresaFromDataTable() {
    var Detalle_Suscripciones_EmpresaData = [];
    var gridData = Detalle_Suscripciones_EmpresaTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Suscripciones_EmpresaData.push({
                Folio: gridData[i].Folio

                ,Cantidad_de_Beneficiarios: gridData[i].Cantidad_de_Beneficiarios
                ,Suscripcion: gridData[i].Suscripcion
                ,Fecha_de_inicio: gridData[i].Fecha_de_inicio
                ,Fecha_Fin: gridData[i].Fecha_Fin
                ,Nombre_de_la_Suscripcion: gridData[i].Nombre_de_la_Suscripcion
                ,Frecuencia_de_Pago: gridData[i].Frecuencia_de_Pago
                ,Costo: gridData[i].Costo
                ,Estatus: gridData[i].Estatus

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Suscripciones_EmpresaData.length; i++) {
        if (removedDetalle_Suscripciones_EmpresaData[i] != null && removedDetalle_Suscripciones_EmpresaData[i].Folio > 0)
            Detalle_Suscripciones_EmpresaData.push({
                Folio: removedDetalle_Suscripciones_EmpresaData[i].Folio

                ,Cantidad_de_Beneficiarios: removedDetalle_Suscripciones_EmpresaData[i].Cantidad_de_Beneficiarios
                ,Suscripcion: removedDetalle_Suscripciones_EmpresaData[i].Suscripcion
                ,Fecha_de_inicio: removedDetalle_Suscripciones_EmpresaData[i].Fecha_de_inicio
                ,Fecha_Fin: removedDetalle_Suscripciones_EmpresaData[i].Fecha_Fin
                ,Nombre_de_la_Suscripcion: removedDetalle_Suscripciones_EmpresaData[i].Nombre_de_la_Suscripcion
                ,Frecuencia_de_Pago: removedDetalle_Suscripciones_EmpresaData[i].Frecuencia_de_Pago
                ,Costo: removedDetalle_Suscripciones_EmpresaData[i].Costo
                ,Estatus: removedDetalle_Suscripciones_EmpresaData[i].Estatus

                , Removed: true
            });
    }	

    return Detalle_Suscripciones_EmpresaData;
}

function Detalle_Suscripciones_EmpresaEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Suscripciones_EmpresaTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Suscripciones_EmpresacountRowsChecked++;
    var Detalle_Suscripciones_EmpresaRowElement = "Detalle_Suscripciones_Empresa_" + rowIndex.toString();
    var prevData = Detalle_Suscripciones_EmpresaTable.fnGetData(rowIndexTable );
    var row = Detalle_Suscripciones_EmpresaTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Suscripciones_Empresa_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Suscripciones_EmpresaGetUpdateRowControls(prevData, "Detalle_Suscripciones_Empresa_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Suscripciones_EmpresaRowElement + "')){ Detalle_Suscripciones_EmpresaInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_Suscripciones_EmpresaCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Suscripciones_EmpresaGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Suscripciones_EmpresaGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_Suscripciones_EmpresaValidation();
    initiateUIControls();
    $('.Detalle_Suscripciones_Empresa' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Suscripciones_Empresa(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Suscripciones_EmpresafnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Suscripciones_EmpresaTable.fnGetData().length;
    Detalle_Suscripciones_EmpresafnClickAddRow();
    GetAddDetalle_Suscripciones_EmpresaPopup(currentRowIndex, 0);
}

function Detalle_Suscripciones_EmpresaEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Suscripciones_EmpresaTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Suscripciones_EmpresaRowElement = "Detalle_Suscripciones_Empresa_" + rowIndex.toString();
    var prevData = Detalle_Suscripciones_EmpresaTable.fnGetData(rowIndexTable);
    GetAddDetalle_Suscripciones_EmpresaPopup(rowIndex, 1, prevData.Folio);

    $('#Detalle_Suscripciones_EmpresaCantidad_de_Beneficiarios').val(prevData.Cantidad_de_Beneficiarios);
    $('#Detalle_Suscripciones_EmpresaSuscripcion').val(prevData.Suscripcion);
    $('#Detalle_Suscripciones_EmpresaFecha_de_inicio').val(prevData.Fecha_de_inicio);
    $('#Detalle_Suscripciones_EmpresaFecha_Fin').val(prevData.Fecha_Fin);
    $('#Detalle_Suscripciones_EmpresaNombre_de_la_Suscripcion').val(prevData.Nombre_de_la_Suscripcion);
    $('#Detalle_Suscripciones_EmpresaFrecuencia_de_Pago').val(prevData.Frecuencia_de_Pago);
    $('#Detalle_Suscripciones_EmpresaCosto').val(prevData.Costo);
    $('#Detalle_Suscripciones_EmpresaEstatus').val(prevData.Estatus);

    initiateUIControls();










}

function Detalle_Suscripciones_EmpresaAddInsertRow() {
    if (Detalle_Suscripciones_EmpresainsertRowCurrentIndex < 1)
    {
        Detalle_Suscripciones_EmpresainsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Cantidad_de_Beneficiarios: ""
        ,Suscripcion: ""
        ,Fecha_de_inicio: ""
        ,Fecha_Fin: ""
        ,Nombre_de_la_Suscripcion: ""
        ,Frecuencia_de_Pago: ""
        ,Costo: ""
        ,Estatus: ""

    }
}

function Detalle_Suscripciones_EmpresafnClickAddRow() {
    Detalle_Suscripciones_EmpresacountRowsChecked++;
    Detalle_Suscripciones_EmpresaTable.fnAddData(Detalle_Suscripciones_EmpresaAddInsertRow(), true);
    Detalle_Suscripciones_EmpresaTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_Suscripciones_EmpresaGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_Suscripciones_EmpresaGrid tbody tr:nth-of-type(' + (Detalle_Suscripciones_EmpresainsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Suscripciones_Empresa("Detalle_Suscripciones_Empresa_", "_" + Detalle_Suscripciones_EmpresainsertRowCurrentIndex);
}

function Detalle_Suscripciones_EmpresaClearGridData() {
    Detalle_Suscripciones_EmpresaData = [];
    Detalle_Suscripciones_EmpresadeletedItem = [];
    Detalle_Suscripciones_EmpresaDataMain = [];
    Detalle_Suscripciones_EmpresaDataMainPages = [];
    Detalle_Suscripciones_EmpresanewItemCount = 0;
    Detalle_Suscripciones_EmpresamaxItemIndex = 0;
    $("#Detalle_Suscripciones_EmpresaGrid").DataTable().clear();
    $("#Detalle_Suscripciones_EmpresaGrid").DataTable().destroy();
}

//Used to Get Empresas Information
function GetDetalle_Suscripciones_Empresa() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Suscripciones_EmpresaData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Suscripciones_EmpresaData[i].Folio);

        form_data.append('[' + i + '].Cantidad_de_Beneficiarios', Detalle_Suscripciones_EmpresaData[i].Cantidad_de_Beneficiarios);
        form_data.append('[' + i + '].Suscripcion', Detalle_Suscripciones_EmpresaData[i].Suscripcion);
        form_data.append('[' + i + '].Fecha_de_inicio', Detalle_Suscripciones_EmpresaData[i].Fecha_de_inicio);
        form_data.append('[' + i + '].Fecha_Fin', Detalle_Suscripciones_EmpresaData[i].Fecha_Fin);
        form_data.append('[' + i + '].Nombre_de_la_Suscripcion', Detalle_Suscripciones_EmpresaData[i].Nombre_de_la_Suscripcion);
        form_data.append('[' + i + '].Frecuencia_de_Pago', Detalle_Suscripciones_EmpresaData[i].Frecuencia_de_Pago);
        form_data.append('[' + i + '].Costo', Detalle_Suscripciones_EmpresaData[i].Costo);
        form_data.append('[' + i + '].Estatus', Detalle_Suscripciones_EmpresaData[i].Estatus);

        form_data.append('[' + i + '].Removed', Detalle_Suscripciones_EmpresaData[i].Removed);
    }
    return form_data;
}
function Detalle_Suscripciones_EmpresaInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Suscripciones_Empresa("Detalle_Suscripciones_EmpresaTable", rowIndex)) {
    var prevData = Detalle_Suscripciones_EmpresaTable.fnGetData(rowIndex);
    var data = Detalle_Suscripciones_EmpresaTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Cantidad_de_Beneficiarios: $('#Detalle_Suscripciones_EmpresaCantidad_de_Beneficiarios').val()

        ,Suscripcion: $('#Detalle_Suscripciones_EmpresaSuscripcion').val()
        ,Fecha_de_inicio: $('#Detalle_Suscripciones_EmpresaFecha_de_inicio').val()
        ,Fecha_Fin: $('#Detalle_Suscripciones_EmpresaFecha_Fin').val()
        ,Nombre_de_la_Suscripcion: $('#Detalle_Suscripciones_EmpresaNombre_de_la_Suscripcion').val()
        ,Frecuencia_de_Pago: $('#Detalle_Suscripciones_EmpresaFrecuencia_de_Pago').val()
        ,Costo: $('#Detalle_Suscripciones_EmpresaCosto').val()
        ,Estatus: $('#Detalle_Suscripciones_EmpresaEstatus').val()

    }

    Detalle_Suscripciones_EmpresaTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Suscripciones_EmpresarowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Suscripciones_Empresa-form').modal({ show: false });
    $('#AddDetalle_Suscripciones_Empresa-form').modal('hide');
    Detalle_Suscripciones_EmpresaEditRow(rowIndex);
    Detalle_Suscripciones_EmpresaInsertRow(rowIndex);
    //}
}
function Detalle_Suscripciones_EmpresaRemoveAddRow(rowIndex) {
    Detalle_Suscripciones_EmpresaTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Suscripciones_Empresa MultiRow
//Begin Declarations for Foreigns fields for Detalle_Pagos_Empresa MultiRow
var Detalle_Pagos_EmpresacountRowsChecked = 0;

function GetDetalle_Pagos_Empresa_Planes_de_SuscripcionName(Id) {
    for (var i = 0; i < Detalle_Pagos_Empresa_Planes_de_SuscripcionItems.length; i++) {
        if (Detalle_Pagos_Empresa_Planes_de_SuscripcionItems[i].Folio == Id) {
            return Detalle_Pagos_Empresa_Planes_de_SuscripcionItems[i].Nombre_del_Plan;
        }
    }
    return "";
}

function GetDetalle_Pagos_Empresa_Planes_de_SuscripcionDropDown() {
    var Detalle_Pagos_Empresa_Planes_de_SuscripcionDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Pagos_Empresa_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Pagos_Empresa_Planes_de_SuscripcionDropdown);
    if(Detalle_Pagos_Empresa_Planes_de_SuscripcionItems != null)
    {
       for (var i = 0; i < Detalle_Pagos_Empresa_Planes_de_SuscripcionItems.length; i++) {
           $('<option />', { value: Detalle_Pagos_Empresa_Planes_de_SuscripcionItems[i].Folio, text:    Detalle_Pagos_Empresa_Planes_de_SuscripcionItems[i].Nombre_del_Plan }).appendTo(Detalle_Pagos_Empresa_Planes_de_SuscripcionDropdown);
       }
    }
    return Detalle_Pagos_Empresa_Planes_de_SuscripcionDropdown;
}






function GetDetalle_Pagos_Empresa_Formas_de_PagoName(Id) {
    for (var i = 0; i < Detalle_Pagos_Empresa_Formas_de_PagoItems.length; i++) {
        if (Detalle_Pagos_Empresa_Formas_de_PagoItems[i].Clave == Id) {
            return Detalle_Pagos_Empresa_Formas_de_PagoItems[i].Nombre;
        }
    }
    return "";
}

function GetDetalle_Pagos_Empresa_Formas_de_PagoDropDown() {
    var Detalle_Pagos_Empresa_Formas_de_PagoDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Pagos_Empresa_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Pagos_Empresa_Formas_de_PagoDropdown);
    if(Detalle_Pagos_Empresa_Formas_de_PagoItems != null)
    {
       for (var i = 0; i < Detalle_Pagos_Empresa_Formas_de_PagoItems.length; i++) {
           $('<option />', { value: Detalle_Pagos_Empresa_Formas_de_PagoItems[i].Clave, text:    Detalle_Pagos_Empresa_Formas_de_PagoItems[i].Nombre }).appendTo(Detalle_Pagos_Empresa_Formas_de_PagoDropdown);
       }
    }
    return Detalle_Pagos_Empresa_Formas_de_PagoDropdown;
}

function GetDetalle_Pagos_Empresa_Estatus_de_PagoName(Id) {
    for (var i = 0; i < Detalle_Pagos_Empresa_Estatus_de_PagoItems.length; i++) {
        if (Detalle_Pagos_Empresa_Estatus_de_PagoItems[i].Clave == Id) {
            return Detalle_Pagos_Empresa_Estatus_de_PagoItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Pagos_Empresa_Estatus_de_PagoDropDown() {
    var Detalle_Pagos_Empresa_Estatus_de_PagoDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Pagos_Empresa_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Pagos_Empresa_Estatus_de_PagoDropdown);
    if(Detalle_Pagos_Empresa_Estatus_de_PagoItems != null)
    {
       for (var i = 0; i < Detalle_Pagos_Empresa_Estatus_de_PagoItems.length; i++) {
           $('<option />', { value: Detalle_Pagos_Empresa_Estatus_de_PagoItems[i].Clave, text:    Detalle_Pagos_Empresa_Estatus_de_PagoItems[i].Descripcion }).appendTo(Detalle_Pagos_Empresa_Estatus_de_PagoDropdown);
       }
    }
    return Detalle_Pagos_Empresa_Estatus_de_PagoDropdown;
}


function GetInsertDetalle_Pagos_EmpresaRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $(GetDetalle_Pagos_Empresa_Planes_de_SuscripcionDropDown()).addClass('Detalle_Pagos_Empresa_Suscripcion Suscripcion').attr('id', 'Detalle_Pagos_Empresa_Suscripcion_' + index).attr('data-field', 'Suscripcion').after($.parseHTML(addNew('Detalle_Pagos_Empresa', 'Planes_de_Suscripcion', 'Suscripcion', 258490)));
    columnData[1] = $($.parseHTML(inputData)).addClass('Detalle_Pagos_Empresa_Concepto_de_Pago Concepto_de_Pago').attr('id', 'Detalle_Pagos_Empresa_Concepto_de_Pago_' + index).attr('data-field', 'Concepto_de_Pago');
    columnData[2] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Pagos_Empresa_Fecha_de_Suscripcion Fecha_de_Suscripcion').attr('id', 'Detalle_Pagos_Empresa_Fecha_de_Suscripcion_' + index).attr('data-field', 'Fecha_de_Suscripcion');
    columnData[3] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Pagos_Empresa_Numero_de_Pago Numero_de_Pago').attr('id', 'Detalle_Pagos_Empresa_Numero_de_Pago_' + index).attr('data-field', 'Numero_de_Pago');
    columnData[4] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Pagos_Empresa_De_Total_de_Pagos De_Total_de_Pagos').attr('id', 'Detalle_Pagos_Empresa_De_Total_de_Pagos_' + index).attr('data-field', 'De_Total_de_Pagos');
    columnData[5] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Pagos_Empresa_Fecha_Limite_de_Pago Fecha_Limite_de_Pago').attr('id', 'Detalle_Pagos_Empresa_Fecha_Limite_de_Pago_' + index).attr('data-field', 'Fecha_Limite_de_Pago');
    columnData[6] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Pagos_Empresa_Recordatorio_dias Recordatorio_dias').attr('id', 'Detalle_Pagos_Empresa_Recordatorio_dias_' + index).attr('data-field', 'Recordatorio_dias');
    columnData[7] = $(GetDetalle_Pagos_Empresa_Formas_de_PagoDropDown()).addClass('Detalle_Pagos_Empresa_Forma_de_Pago Forma_de_Pago').attr('id', 'Detalle_Pagos_Empresa_Forma_de_Pago_' + index).attr('data-field', 'Forma_de_Pago').after($.parseHTML(addNew('Detalle_Pagos_Empresa', 'Formas_de_Pago', 'Forma_de_Pago', 258494)));
    columnData[8] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Pagos_Empresa_Fecha_de_Pago Fecha_de_Pago').attr('id', 'Detalle_Pagos_Empresa_Fecha_de_Pago_' + index).attr('data-field', 'Fecha_de_Pago');
    columnData[9] = $(GetDetalle_Pagos_Empresa_Estatus_de_PagoDropDown()).addClass('Detalle_Pagos_Empresa_Estatus Estatus').attr('id', 'Detalle_Pagos_Empresa_Estatus_' + index).attr('data-field', 'Estatus').after($.parseHTML(addNew('Detalle_Pagos_Empresa', 'Estatus_de_Pago', 'Estatus', 258496)));


    initiateUIControls();
    return columnData;
}

function Detalle_Pagos_EmpresaInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Pagos_Empresa("Detalle_Pagos_Empresa_", "_" + rowIndex)) {
    var iPage = Detalle_Pagos_EmpresaTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Pagos_Empresa';
    var prevData = Detalle_Pagos_EmpresaTable.fnGetData(rowIndex);
    var data = Detalle_Pagos_EmpresaTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Suscripcion:  data.childNodes[counter++].childNodes[0].value
        ,Concepto_de_Pago:  data.childNodes[counter++].childNodes[0].value
        ,Fecha_de_Suscripcion:  data.childNodes[counter++].childNodes[0].value
        ,Numero_de_Pago: data.childNodes[counter++].childNodes[0].value
        ,De_Total_de_Pagos: data.childNodes[counter++].childNodes[0].value
        ,Fecha_Limite_de_Pago:  data.childNodes[counter++].childNodes[0].value
        ,Recordatorio_dias: data.childNodes[counter++].childNodes[0].value
        ,Forma_de_Pago:  data.childNodes[counter++].childNodes[0].value
        ,Fecha_de_Pago:  data.childNodes[counter++].childNodes[0].value
        ,Estatus:  data.childNodes[counter++].childNodes[0].value

    }
    Detalle_Pagos_EmpresaTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Pagos_EmpresarowCreationGrid(data, newData, rowIndex);
    Detalle_Pagos_EmpresaTable.fnPageChange(iPage);
    Detalle_Pagos_EmpresacountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Pagos_Empresa("Detalle_Pagos_Empresa_", "_" + rowIndex);
  }
}

function Detalle_Pagos_EmpresaCancelRow(rowIndex) {
    var prevData = Detalle_Pagos_EmpresaTable.fnGetData(rowIndex);
    var data = Detalle_Pagos_EmpresaTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Pagos_EmpresaTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Pagos_EmpresarowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Pagos_EmpresaGrid(Detalle_Pagos_EmpresaTable.fnGetData());
    Detalle_Pagos_EmpresacountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Pagos_EmpresaFromDataTable() {
    var Detalle_Pagos_EmpresaData = [];
    var gridData = Detalle_Pagos_EmpresaTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Pagos_EmpresaData.push({
                Folio: gridData[i].Folio

                ,Suscripcion: gridData[i].Suscripcion
                ,Concepto_de_Pago: gridData[i].Concepto_de_Pago
                ,Fecha_de_Suscripcion: gridData[i].Fecha_de_Suscripcion
                ,Numero_de_Pago: gridData[i].Numero_de_Pago
                ,De_Total_de_Pagos: gridData[i].De_Total_de_Pagos
                ,Fecha_Limite_de_Pago: gridData[i].Fecha_Limite_de_Pago
                ,Recordatorio_dias: gridData[i].Recordatorio_dias
                ,Forma_de_Pago: gridData[i].Forma_de_Pago
                ,Fecha_de_Pago: gridData[i].Fecha_de_Pago
                ,Estatus: gridData[i].Estatus

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Pagos_EmpresaData.length; i++) {
        if (removedDetalle_Pagos_EmpresaData[i] != null && removedDetalle_Pagos_EmpresaData[i].Folio > 0)
            Detalle_Pagos_EmpresaData.push({
                Folio: removedDetalle_Pagos_EmpresaData[i].Folio

                ,Suscripcion: removedDetalle_Pagos_EmpresaData[i].Suscripcion
                ,Concepto_de_Pago: removedDetalle_Pagos_EmpresaData[i].Concepto_de_Pago
                ,Fecha_de_Suscripcion: removedDetalle_Pagos_EmpresaData[i].Fecha_de_Suscripcion
                ,Numero_de_Pago: removedDetalle_Pagos_EmpresaData[i].Numero_de_Pago
                ,De_Total_de_Pagos: removedDetalle_Pagos_EmpresaData[i].De_Total_de_Pagos
                ,Fecha_Limite_de_Pago: removedDetalle_Pagos_EmpresaData[i].Fecha_Limite_de_Pago
                ,Recordatorio_dias: removedDetalle_Pagos_EmpresaData[i].Recordatorio_dias
                ,Forma_de_Pago: removedDetalle_Pagos_EmpresaData[i].Forma_de_Pago
                ,Fecha_de_Pago: removedDetalle_Pagos_EmpresaData[i].Fecha_de_Pago
                ,Estatus: removedDetalle_Pagos_EmpresaData[i].Estatus

                , Removed: true
            });
    }	

    return Detalle_Pagos_EmpresaData;
}

function Detalle_Pagos_EmpresaEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Pagos_EmpresaTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Pagos_EmpresacountRowsChecked++;
    var Detalle_Pagos_EmpresaRowElement = "Detalle_Pagos_Empresa_" + rowIndex.toString();
    var prevData = Detalle_Pagos_EmpresaTable.fnGetData(rowIndexTable );
    var row = Detalle_Pagos_EmpresaTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Pagos_Empresa_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Pagos_EmpresaGetUpdateRowControls(prevData, "Detalle_Pagos_Empresa_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Pagos_EmpresaRowElement + "')){ Detalle_Pagos_EmpresaInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_Pagos_EmpresaCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Pagos_EmpresaGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Pagos_EmpresaGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_Pagos_EmpresaValidation();
    initiateUIControls();
    $('.Detalle_Pagos_Empresa' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Pagos_Empresa(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Pagos_EmpresafnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Pagos_EmpresaTable.fnGetData().length;
    Detalle_Pagos_EmpresafnClickAddRow();
    GetAddDetalle_Pagos_EmpresaPopup(currentRowIndex, 0);
}

function Detalle_Pagos_EmpresaEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Pagos_EmpresaTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Pagos_EmpresaRowElement = "Detalle_Pagos_Empresa_" + rowIndex.toString();
    var prevData = Detalle_Pagos_EmpresaTable.fnGetData(rowIndexTable);
    GetAddDetalle_Pagos_EmpresaPopup(rowIndex, 1, prevData.Folio);

    $('#Detalle_Pagos_EmpresaSuscripcion').val(prevData.Suscripcion);
    $('#Detalle_Pagos_EmpresaConcepto_de_Pago').val(prevData.Concepto_de_Pago);
    $('#Detalle_Pagos_EmpresaFecha_de_Suscripcion').val(prevData.Fecha_de_Suscripcion);
    $('#Detalle_Pagos_EmpresaNumero_de_Pago').val(prevData.Numero_de_Pago);
    $('#Detalle_Pagos_EmpresaDe_Total_de_Pagos').val(prevData.De_Total_de_Pagos);
    $('#Detalle_Pagos_EmpresaFecha_Limite_de_Pago').val(prevData.Fecha_Limite_de_Pago);
    $('#Detalle_Pagos_EmpresaRecordatorio_dias').val(prevData.Recordatorio_dias);
    $('#Detalle_Pagos_EmpresaForma_de_Pago').val(prevData.Forma_de_Pago);
    $('#Detalle_Pagos_EmpresaFecha_de_Pago').val(prevData.Fecha_de_Pago);
    $('#Detalle_Pagos_EmpresaEstatus').val(prevData.Estatus);

    initiateUIControls();












}

function Detalle_Pagos_EmpresaAddInsertRow() {
    if (Detalle_Pagos_EmpresainsertRowCurrentIndex < 1)
    {
        Detalle_Pagos_EmpresainsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Suscripcion: ""
        ,Concepto_de_Pago: ""
        ,Fecha_de_Suscripcion: ""
        ,Numero_de_Pago: ""
        ,De_Total_de_Pagos: ""
        ,Fecha_Limite_de_Pago: ""
        ,Recordatorio_dias: ""
        ,Forma_de_Pago: ""
        ,Fecha_de_Pago: ""
        ,Estatus: ""

    }
}

function Detalle_Pagos_EmpresafnClickAddRow() {
    Detalle_Pagos_EmpresacountRowsChecked++;
    Detalle_Pagos_EmpresaTable.fnAddData(Detalle_Pagos_EmpresaAddInsertRow(), true);
    Detalle_Pagos_EmpresaTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_Pagos_EmpresaGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_Pagos_EmpresaGrid tbody tr:nth-of-type(' + (Detalle_Pagos_EmpresainsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Pagos_Empresa("Detalle_Pagos_Empresa_", "_" + Detalle_Pagos_EmpresainsertRowCurrentIndex);
}

function Detalle_Pagos_EmpresaClearGridData() {
    Detalle_Pagos_EmpresaData = [];
    Detalle_Pagos_EmpresadeletedItem = [];
    Detalle_Pagos_EmpresaDataMain = [];
    Detalle_Pagos_EmpresaDataMainPages = [];
    Detalle_Pagos_EmpresanewItemCount = 0;
    Detalle_Pagos_EmpresamaxItemIndex = 0;
    $("#Detalle_Pagos_EmpresaGrid").DataTable().clear();
    $("#Detalle_Pagos_EmpresaGrid").DataTable().destroy();
}

//Used to Get Empresas Information
function GetDetalle_Pagos_Empresa() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Pagos_EmpresaData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Pagos_EmpresaData[i].Folio);

        form_data.append('[' + i + '].Suscripcion', Detalle_Pagos_EmpresaData[i].Suscripcion);
        form_data.append('[' + i + '].Concepto_de_Pago', Detalle_Pagos_EmpresaData[i].Concepto_de_Pago);
        form_data.append('[' + i + '].Fecha_de_Suscripcion', Detalle_Pagos_EmpresaData[i].Fecha_de_Suscripcion);
        form_data.append('[' + i + '].Numero_de_Pago', Detalle_Pagos_EmpresaData[i].Numero_de_Pago);
        form_data.append('[' + i + '].De_Total_de_Pagos', Detalle_Pagos_EmpresaData[i].De_Total_de_Pagos);
        form_data.append('[' + i + '].Fecha_Limite_de_Pago', Detalle_Pagos_EmpresaData[i].Fecha_Limite_de_Pago);
        form_data.append('[' + i + '].Recordatorio_dias', Detalle_Pagos_EmpresaData[i].Recordatorio_dias);
        form_data.append('[' + i + '].Forma_de_Pago', Detalle_Pagos_EmpresaData[i].Forma_de_Pago);
        form_data.append('[' + i + '].Fecha_de_Pago', Detalle_Pagos_EmpresaData[i].Fecha_de_Pago);
        form_data.append('[' + i + '].Estatus', Detalle_Pagos_EmpresaData[i].Estatus);

        form_data.append('[' + i + '].Removed', Detalle_Pagos_EmpresaData[i].Removed);
    }
    return form_data;
}
function Detalle_Pagos_EmpresaInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Pagos_Empresa("Detalle_Pagos_EmpresaTable", rowIndex)) {
    var prevData = Detalle_Pagos_EmpresaTable.fnGetData(rowIndex);
    var data = Detalle_Pagos_EmpresaTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Suscripcion: $('#Detalle_Pagos_EmpresaSuscripcion').val()
        ,Concepto_de_Pago: $('#Detalle_Pagos_EmpresaConcepto_de_Pago').val()
        ,Fecha_de_Suscripcion: $('#Detalle_Pagos_EmpresaFecha_de_Suscripcion').val()
        ,Numero_de_Pago: $('#Detalle_Pagos_EmpresaNumero_de_Pago').val()

        ,De_Total_de_Pagos: $('#Detalle_Pagos_EmpresaDe_Total_de_Pagos').val()

        ,Fecha_Limite_de_Pago: $('#Detalle_Pagos_EmpresaFecha_Limite_de_Pago').val()
        ,Recordatorio_dias: $('#Detalle_Pagos_EmpresaRecordatorio_dias').val()

        ,Forma_de_Pago: $('#Detalle_Pagos_EmpresaForma_de_Pago').val()
        ,Fecha_de_Pago: $('#Detalle_Pagos_EmpresaFecha_de_Pago').val()
        ,Estatus: $('#Detalle_Pagos_EmpresaEstatus').val()

    }

    Detalle_Pagos_EmpresaTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Pagos_EmpresarowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Pagos_Empresa-form').modal({ show: false });
    $('#AddDetalle_Pagos_Empresa-form').modal('hide');
    Detalle_Pagos_EmpresaEditRow(rowIndex);
    Detalle_Pagos_EmpresaInsertRow(rowIndex);
    //}
}
function Detalle_Pagos_EmpresaRemoveAddRow(rowIndex) {
    Detalle_Pagos_EmpresaTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Pagos_Empresa MultiRow
//Begin Declarations for Foreigns fields for Detalle_Registro_Beneficiarios_Empresa MultiRow
var Detalle_Registro_Beneficiarios_EmpresacountRowsChecked = 0;


function GetDetalle_Registro_Beneficiarios_Empresa_Spartan_UserName(Id) {
    for (var i = 0; i < Detalle_Registro_Beneficiarios_Empresa_Spartan_UserItems.length; i++) {
        if (Detalle_Registro_Beneficiarios_Empresa_Spartan_UserItems[i].Id_User == Id) {
            return Detalle_Registro_Beneficiarios_Empresa_Spartan_UserItems[i].Name;
        }
    }
    return "";
}

function GetDetalle_Registro_Beneficiarios_Empresa_Spartan_UserDropDown() {
    var Detalle_Registro_Beneficiarios_Empresa_Spartan_UserDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Registro_Beneficiarios_Empresa_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Registro_Beneficiarios_Empresa_Spartan_UserDropdown);
    if(Detalle_Registro_Beneficiarios_Empresa_Spartan_UserItems != null)
    {
       for (var i = 0; i < Detalle_Registro_Beneficiarios_Empresa_Spartan_UserItems.length; i++) {
           $('<option />', { value: Detalle_Registro_Beneficiarios_Empresa_Spartan_UserItems[i].Id_User, text:    Detalle_Registro_Beneficiarios_Empresa_Spartan_UserItems[i].Name }).appendTo(Detalle_Registro_Beneficiarios_Empresa_Spartan_UserDropdown);
       }
    }
    return Detalle_Registro_Beneficiarios_Empresa_Spartan_UserDropdown;
}






function GetDetalle_Registro_Beneficiarios_Empresa_Planes_de_SuscripcionName(Id) {
    for (var i = 0; i < Detalle_Registro_Beneficiarios_Empresa_Planes_de_SuscripcionItems.length; i++) {
        if (Detalle_Registro_Beneficiarios_Empresa_Planes_de_SuscripcionItems[i].Folio == Id) {
            return Detalle_Registro_Beneficiarios_Empresa_Planes_de_SuscripcionItems[i].Nombre_del_Plan;
        }
    }
    return "";
}

function GetDetalle_Registro_Beneficiarios_Empresa_Planes_de_SuscripcionDropDown() {
    var Detalle_Registro_Beneficiarios_Empresa_Planes_de_SuscripcionDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Registro_Beneficiarios_Empresa_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Registro_Beneficiarios_Empresa_Planes_de_SuscripcionDropdown);
    if(Detalle_Registro_Beneficiarios_Empresa_Planes_de_SuscripcionItems != null)
    {
       for (var i = 0; i < Detalle_Registro_Beneficiarios_Empresa_Planes_de_SuscripcionItems.length; i++) {
           $('<option />', { value: Detalle_Registro_Beneficiarios_Empresa_Planes_de_SuscripcionItems[i].Folio, text:    Detalle_Registro_Beneficiarios_Empresa_Planes_de_SuscripcionItems[i].Nombre_del_Plan }).appendTo(Detalle_Registro_Beneficiarios_Empresa_Planes_de_SuscripcionDropdown);
       }
    }
    return Detalle_Registro_Beneficiarios_Empresa_Planes_de_SuscripcionDropdown;
}

function GetDetalle_Registro_Beneficiarios_Empresa_EstatusName(Id) {
    for (var i = 0; i < Detalle_Registro_Beneficiarios_Empresa_EstatusItems.length; i++) {
        if (Detalle_Registro_Beneficiarios_Empresa_EstatusItems[i].Clave == Id) {
            return Detalle_Registro_Beneficiarios_Empresa_EstatusItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Registro_Beneficiarios_Empresa_EstatusDropDown() {
    var Detalle_Registro_Beneficiarios_Empresa_EstatusDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Registro_Beneficiarios_Empresa_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Registro_Beneficiarios_Empresa_EstatusDropdown);
    if(Detalle_Registro_Beneficiarios_Empresa_EstatusItems != null)
    {
       for (var i = 0; i < Detalle_Registro_Beneficiarios_Empresa_EstatusItems.length; i++) {
           $('<option />', { value: Detalle_Registro_Beneficiarios_Empresa_EstatusItems[i].Clave, text:    Detalle_Registro_Beneficiarios_Empresa_EstatusItems[i].Descripcion }).appendTo(Detalle_Registro_Beneficiarios_Empresa_EstatusDropdown);
       }
    }
    return Detalle_Registro_Beneficiarios_Empresa_EstatusDropdown;
}


function GetInsertDetalle_Registro_Beneficiarios_EmpresaRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $($.parseHTML(inputData)).addClass('Detalle_Registro_Beneficiarios_Empresa_Numero_de_Empleado Numero_de_Empleado').attr('id', 'Detalle_Registro_Beneficiarios_Empresa_Numero_de_Empleado_' + index).attr('data-field', 'Numero_de_Empleado');
    columnData[1] = $(GetDetalle_Registro_Beneficiarios_Empresa_Spartan_UserDropDown()).addClass('Detalle_Registro_Beneficiarios_Empresa_Usuario Usuario').attr('id', 'Detalle_Registro_Beneficiarios_Empresa_Usuario_' + index).attr('data-field', 'Usuario').after($.parseHTML(addNew('Detalle_Registro_Beneficiarios_Empresa', 'Spartan_User', 'Usuario', 258938)));
    columnData[2] = $($.parseHTML(inputData)).addClass('Detalle_Registro_Beneficiarios_Empresa_Nombres Nombres').attr('id', 'Detalle_Registro_Beneficiarios_Empresa_Nombres_' + index).attr('data-field', 'Nombres');
    columnData[3] = $($.parseHTML(inputData)).addClass('Detalle_Registro_Beneficiarios_Empresa_Apellido_Paterno Apellido_Paterno').attr('id', 'Detalle_Registro_Beneficiarios_Empresa_Apellido_Paterno_' + index).attr('data-field', 'Apellido_Paterno');
    columnData[4] = $($.parseHTML(inputData)).addClass('Detalle_Registro_Beneficiarios_Empresa_Apellido_Materno Apellido_Materno').attr('id', 'Detalle_Registro_Beneficiarios_Empresa_Apellido_Materno_' + index).attr('data-field', 'Apellido_Materno');
    columnData[5] = $($.parseHTML(inputData)).addClass('Detalle_Registro_Beneficiarios_Empresa_Nombre_Completo Nombre_Completo').attr('id', 'Detalle_Registro_Beneficiarios_Empresa_Nombre_Completo_' + index).attr('data-field', 'Nombre_Completo');
    columnData[6] = $($.parseHTML(inputData)).addClass('Detalle_Registro_Beneficiarios_Empresa_Email Email').attr('id', 'Detalle_Registro_Beneficiarios_Empresa_Email_' + index).attr('data-field', 'Email');
    columnData[7] = $($.parseHTML(GetGridCheckBox())).addClass('Detalle_Registro_Beneficiarios_Empresa_Activo Activo').attr('id', 'Detalle_Registro_Beneficiarios_Empresa_Activo_' + index).attr('data-field', 'Activo');
    columnData[8] = $(GetDetalle_Registro_Beneficiarios_Empresa_Planes_de_SuscripcionDropDown()).addClass('Detalle_Registro_Beneficiarios_Empresa_Suscripcion Suscripcion').attr('id', 'Detalle_Registro_Beneficiarios_Empresa_Suscripcion_' + index).attr('data-field', 'Suscripcion').after($.parseHTML(addNew('Detalle_Registro_Beneficiarios_Empresa', 'Planes_de_Suscripcion', 'Suscripcion', 258945)));
    columnData[9] = $($.parseHTML(inputData)).addClass('Detalle_Registro_Beneficiarios_Empresa_Codigo_de_Referencia Codigo_de_Referencia').attr('id', 'Detalle_Registro_Beneficiarios_Empresa_Codigo_de_Referencia_' + index).attr('data-field', 'Codigo_de_Referencia');
    columnData[10] = $(GetDetalle_Registro_Beneficiarios_Empresa_EstatusDropDown()).addClass('Detalle_Registro_Beneficiarios_Empresa_Estatus Estatus').attr('id', 'Detalle_Registro_Beneficiarios_Empresa_Estatus_' + index).attr('data-field', 'Estatus').after($.parseHTML(addNew('Detalle_Registro_Beneficiarios_Empresa', 'Estatus', 'Estatus', 258947)));


    initiateUIControls();
    return columnData;
}

function Detalle_Registro_Beneficiarios_EmpresaInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Registro_Beneficiarios_Empresa("Detalle_Registro_Beneficiarios_Empresa_", "_" + rowIndex)) {
    var iPage = Detalle_Registro_Beneficiarios_EmpresaTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Registro_Beneficiarios_Empresa';
    var prevData = Detalle_Registro_Beneficiarios_EmpresaTable.fnGetData(rowIndex);
    var data = Detalle_Registro_Beneficiarios_EmpresaTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Numero_de_Empleado:  data.childNodes[counter++].childNodes[0].value
        ,Usuario:  data.childNodes[counter++].childNodes[0].value
        ,Nombres:  data.childNodes[counter++].childNodes[0].value
        ,Apellido_Paterno:  data.childNodes[counter++].childNodes[0].value
        ,Apellido_Materno:  data.childNodes[counter++].childNodes[0].value
        ,Nombre_Completo:  data.childNodes[counter++].childNodes[0].value
        ,Email:  data.childNodes[counter++].childNodes[0].value
        ,Activo: $(data.childNodes[counter++].childNodes[2]).is(':checked')
        ,Suscripcion:  data.childNodes[counter++].childNodes[0].value
        ,Codigo_de_Referencia:  data.childNodes[counter++].childNodes[0].value
        ,Estatus:  data.childNodes[counter++].childNodes[0].value

    }
    Detalle_Registro_Beneficiarios_EmpresaTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Registro_Beneficiarios_EmpresarowCreationGrid(data, newData, rowIndex);
    Detalle_Registro_Beneficiarios_EmpresaTable.fnPageChange(iPage);
    Detalle_Registro_Beneficiarios_EmpresacountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Registro_Beneficiarios_Empresa("Detalle_Registro_Beneficiarios_Empresa_", "_" + rowIndex);
  }
}

function Detalle_Registro_Beneficiarios_EmpresaCancelRow(rowIndex) {
    var prevData = Detalle_Registro_Beneficiarios_EmpresaTable.fnGetData(rowIndex);
    var data = Detalle_Registro_Beneficiarios_EmpresaTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Registro_Beneficiarios_EmpresaTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Registro_Beneficiarios_EmpresarowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Registro_Beneficiarios_EmpresaGrid(Detalle_Registro_Beneficiarios_EmpresaTable.fnGetData());
    Detalle_Registro_Beneficiarios_EmpresacountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Registro_Beneficiarios_EmpresaFromDataTable() {
    var Detalle_Registro_Beneficiarios_EmpresaData = [];
    var gridData = Detalle_Registro_Beneficiarios_EmpresaTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Registro_Beneficiarios_EmpresaData.push({
                Folio: gridData[i].Folio

                ,Numero_de_Empleado: gridData[i].Numero_de_Empleado
                ,Usuario: gridData[i].Usuario
                ,Nombres: gridData[i].Nombres
                ,Apellido_Paterno: gridData[i].Apellido_Paterno
                ,Apellido_Materno: gridData[i].Apellido_Materno
                ,Nombre_Completo: gridData[i].Nombre_Completo
                ,Email: gridData[i].Email
                ,Activo: gridData[i].Activo
                ,Suscripcion: gridData[i].Suscripcion
                ,Codigo_de_Referencia: gridData[i].Codigo_de_Referencia
                ,Estatus: gridData[i].Estatus

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Registro_Beneficiarios_EmpresaData.length; i++) {
        if (removedDetalle_Registro_Beneficiarios_EmpresaData[i] != null && removedDetalle_Registro_Beneficiarios_EmpresaData[i].Folio > 0)
            Detalle_Registro_Beneficiarios_EmpresaData.push({
                Folio: removedDetalle_Registro_Beneficiarios_EmpresaData[i].Folio

                ,Numero_de_Empleado: removedDetalle_Registro_Beneficiarios_EmpresaData[i].Numero_de_Empleado
                ,Usuario: removedDetalle_Registro_Beneficiarios_EmpresaData[i].Usuario
                ,Nombres: removedDetalle_Registro_Beneficiarios_EmpresaData[i].Nombres
                ,Apellido_Paterno: removedDetalle_Registro_Beneficiarios_EmpresaData[i].Apellido_Paterno
                ,Apellido_Materno: removedDetalle_Registro_Beneficiarios_EmpresaData[i].Apellido_Materno
                ,Nombre_Completo: removedDetalle_Registro_Beneficiarios_EmpresaData[i].Nombre_Completo
                ,Email: removedDetalle_Registro_Beneficiarios_EmpresaData[i].Email
                ,Activo: removedDetalle_Registro_Beneficiarios_EmpresaData[i].Activo
                ,Suscripcion: removedDetalle_Registro_Beneficiarios_EmpresaData[i].Suscripcion
                ,Codigo_de_Referencia: removedDetalle_Registro_Beneficiarios_EmpresaData[i].Codigo_de_Referencia
                ,Estatus: removedDetalle_Registro_Beneficiarios_EmpresaData[i].Estatus

                , Removed: true
            });
    }	

    return Detalle_Registro_Beneficiarios_EmpresaData;
}

function Detalle_Registro_Beneficiarios_EmpresaEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Registro_Beneficiarios_EmpresaTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Registro_Beneficiarios_EmpresacountRowsChecked++;
    var Detalle_Registro_Beneficiarios_EmpresaRowElement = "Detalle_Registro_Beneficiarios_Empresa_" + rowIndex.toString();
    var prevData = Detalle_Registro_Beneficiarios_EmpresaTable.fnGetData(rowIndexTable );
    var row = Detalle_Registro_Beneficiarios_EmpresaTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Registro_Beneficiarios_Empresa_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Registro_Beneficiarios_EmpresaGetUpdateRowControls(prevData, "Detalle_Registro_Beneficiarios_Empresa_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Registro_Beneficiarios_EmpresaRowElement + "')){ Detalle_Registro_Beneficiarios_EmpresaInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_Registro_Beneficiarios_EmpresaCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Registro_Beneficiarios_EmpresaGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Registro_Beneficiarios_EmpresaGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_Registro_Beneficiarios_EmpresaValidation();
    initiateUIControls();
    $('.Detalle_Registro_Beneficiarios_Empresa' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Registro_Beneficiarios_Empresa(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Registro_Beneficiarios_EmpresafnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Registro_Beneficiarios_EmpresaTable.fnGetData().length;
    Detalle_Registro_Beneficiarios_EmpresafnClickAddRow();
    GetAddDetalle_Registro_Beneficiarios_EmpresaPopup(currentRowIndex, 0);
}

function Detalle_Registro_Beneficiarios_EmpresaEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Registro_Beneficiarios_EmpresaTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Registro_Beneficiarios_EmpresaRowElement = "Detalle_Registro_Beneficiarios_Empresa_" + rowIndex.toString();
    var prevData = Detalle_Registro_Beneficiarios_EmpresaTable.fnGetData(rowIndexTable);
    GetAddDetalle_Registro_Beneficiarios_EmpresaPopup(rowIndex, 1, prevData.Folio);

    $('#Detalle_Registro_Beneficiarios_EmpresaNumero_de_Empleado').val(prevData.Numero_de_Empleado);
    $('#Detalle_Registro_Beneficiarios_EmpresaUsuario').val(prevData.Usuario);
    $('#Detalle_Registro_Beneficiarios_EmpresaNombres').val(prevData.Nombres);
    $('#Detalle_Registro_Beneficiarios_EmpresaApellido_Paterno').val(prevData.Apellido_Paterno);
    $('#Detalle_Registro_Beneficiarios_EmpresaApellido_Materno').val(prevData.Apellido_Materno);
    $('#Detalle_Registro_Beneficiarios_EmpresaNombre_Completo').val(prevData.Nombre_Completo);
    $('#Detalle_Registro_Beneficiarios_EmpresaEmail').val(prevData.Email);
    $('#Detalle_Registro_Beneficiarios_EmpresaActivo').prop('checked', prevData.Activo);
    $('#Detalle_Registro_Beneficiarios_EmpresaSuscripcion').val(prevData.Suscripcion);
    $('#Detalle_Registro_Beneficiarios_EmpresaCodigo_de_Referencia').val(prevData.Codigo_de_Referencia);
    $('#Detalle_Registro_Beneficiarios_EmpresaEstatus').val(prevData.Estatus);

    initiateUIControls();













}

function Detalle_Registro_Beneficiarios_EmpresaAddInsertRow() {
    if (Detalle_Registro_Beneficiarios_EmpresainsertRowCurrentIndex < 1)
    {
        Detalle_Registro_Beneficiarios_EmpresainsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Numero_de_Empleado: ""
        ,Usuario: ""
        ,Nombres: ""
        ,Apellido_Paterno: ""
        ,Apellido_Materno: ""
        ,Nombre_Completo: ""
        ,Email: ""
        ,Activo: ""
        ,Suscripcion: ""
        ,Codigo_de_Referencia: ""
        ,Estatus: ""

    }
}

function Detalle_Registro_Beneficiarios_EmpresafnClickAddRow() {
    Detalle_Registro_Beneficiarios_EmpresacountRowsChecked++;
    Detalle_Registro_Beneficiarios_EmpresaTable.fnAddData(Detalle_Registro_Beneficiarios_EmpresaAddInsertRow(), true);
    Detalle_Registro_Beneficiarios_EmpresaTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_Registro_Beneficiarios_EmpresaGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_Registro_Beneficiarios_EmpresaGrid tbody tr:nth-of-type(' + (Detalle_Registro_Beneficiarios_EmpresainsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Registro_Beneficiarios_Empresa("Detalle_Registro_Beneficiarios_Empresa_", "_" + Detalle_Registro_Beneficiarios_EmpresainsertRowCurrentIndex);
}

function Detalle_Registro_Beneficiarios_EmpresaClearGridData() {
    Detalle_Registro_Beneficiarios_EmpresaData = [];
    Detalle_Registro_Beneficiarios_EmpresadeletedItem = [];
    Detalle_Registro_Beneficiarios_EmpresaDataMain = [];
    Detalle_Registro_Beneficiarios_EmpresaDataMainPages = [];
    Detalle_Registro_Beneficiarios_EmpresanewItemCount = 0;
    Detalle_Registro_Beneficiarios_EmpresamaxItemIndex = 0;
    $("#Detalle_Registro_Beneficiarios_EmpresaGrid").DataTable().clear();
    $("#Detalle_Registro_Beneficiarios_EmpresaGrid").DataTable().destroy();
}

//Used to Get Empresas Information
function GetDetalle_Registro_Beneficiarios_Empresa() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Registro_Beneficiarios_EmpresaData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Registro_Beneficiarios_EmpresaData[i].Folio);

        form_data.append('[' + i + '].Numero_de_Empleado', Detalle_Registro_Beneficiarios_EmpresaData[i].Numero_de_Empleado);
        form_data.append('[' + i + '].Usuario', Detalle_Registro_Beneficiarios_EmpresaData[i].Usuario);
        form_data.append('[' + i + '].Nombres', Detalle_Registro_Beneficiarios_EmpresaData[i].Nombres);
        form_data.append('[' + i + '].Apellido_Paterno', Detalle_Registro_Beneficiarios_EmpresaData[i].Apellido_Paterno);
        form_data.append('[' + i + '].Apellido_Materno', Detalle_Registro_Beneficiarios_EmpresaData[i].Apellido_Materno);
        form_data.append('[' + i + '].Nombre_Completo', Detalle_Registro_Beneficiarios_EmpresaData[i].Nombre_Completo);
        form_data.append('[' + i + '].Email', Detalle_Registro_Beneficiarios_EmpresaData[i].Email);
        form_data.append('[' + i + '].Activo', Detalle_Registro_Beneficiarios_EmpresaData[i].Activo);
        form_data.append('[' + i + '].Suscripcion', Detalle_Registro_Beneficiarios_EmpresaData[i].Suscripcion);
        form_data.append('[' + i + '].Codigo_de_Referencia', Detalle_Registro_Beneficiarios_EmpresaData[i].Codigo_de_Referencia);
        form_data.append('[' + i + '].Estatus', Detalle_Registro_Beneficiarios_EmpresaData[i].Estatus);

        form_data.append('[' + i + '].Removed', Detalle_Registro_Beneficiarios_EmpresaData[i].Removed);
    }
    return form_data;
}
function Detalle_Registro_Beneficiarios_EmpresaInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Registro_Beneficiarios_Empresa("Detalle_Registro_Beneficiarios_EmpresaTable", rowIndex)) {
    var prevData = Detalle_Registro_Beneficiarios_EmpresaTable.fnGetData(rowIndex);
    var data = Detalle_Registro_Beneficiarios_EmpresaTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Numero_de_Empleado: $('#Detalle_Registro_Beneficiarios_EmpresaNumero_de_Empleado').val()
        ,Usuario: $('#Detalle_Registro_Beneficiarios_EmpresaUsuario').val()
        ,Nombres: $('#Detalle_Registro_Beneficiarios_EmpresaNombres').val()
        ,Apellido_Paterno: $('#Detalle_Registro_Beneficiarios_EmpresaApellido_Paterno').val()
        ,Apellido_Materno: $('#Detalle_Registro_Beneficiarios_EmpresaApellido_Materno').val()
        ,Nombre_Completo: $('#Detalle_Registro_Beneficiarios_EmpresaNombre_Completo').val()
        ,Email: $('#Detalle_Registro_Beneficiarios_EmpresaEmail').val()
        ,Activo: $('#Detalle_Registro_Beneficiarios_EmpresaActivo').is(':checked')
        ,Suscripcion: $('#Detalle_Registro_Beneficiarios_EmpresaSuscripcion').val()
        ,Codigo_de_Referencia: $('#Detalle_Registro_Beneficiarios_EmpresaCodigo_de_Referencia').val()
        ,Estatus: $('#Detalle_Registro_Beneficiarios_EmpresaEstatus').val()

    }

    Detalle_Registro_Beneficiarios_EmpresaTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Registro_Beneficiarios_EmpresarowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Registro_Beneficiarios_Empresa-form').modal({ show: false });
    $('#AddDetalle_Registro_Beneficiarios_Empresa-form').modal('hide');
    Detalle_Registro_Beneficiarios_EmpresaEditRow(rowIndex);
    Detalle_Registro_Beneficiarios_EmpresaInsertRow(rowIndex);
    //}
}
function Detalle_Registro_Beneficiarios_EmpresaRemoveAddRow(rowIndex) {
    Detalle_Registro_Beneficiarios_EmpresaTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Registro_Beneficiarios_Empresa MultiRow
//Begin Declarations for Foreigns fields for Detalle_Contratos_Empresa MultiRow
var Detalle_Contratos_EmpresacountRowsChecked = 0;

function GetDetalle_Contratos_Empresa_Planes_de_SuscripcionName(Id) {
    for (var i = 0; i < Detalle_Contratos_Empresa_Planes_de_SuscripcionItems.length; i++) {
        if (Detalle_Contratos_Empresa_Planes_de_SuscripcionItems[i].Folio == Id) {
            return Detalle_Contratos_Empresa_Planes_de_SuscripcionItems[i].Nombre_del_Plan;
        }
    }
    return "";
}

function GetDetalle_Contratos_Empresa_Planes_de_SuscripcionDropDown() {
    var Detalle_Contratos_Empresa_Planes_de_SuscripcionDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Contratos_Empresa_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Contratos_Empresa_Planes_de_SuscripcionDropdown);
    if(Detalle_Contratos_Empresa_Planes_de_SuscripcionItems != null)
    {
       for (var i = 0; i < Detalle_Contratos_Empresa_Planes_de_SuscripcionItems.length; i++) {
           $('<option />', { value: Detalle_Contratos_Empresa_Planes_de_SuscripcionItems[i].Folio, text:    Detalle_Contratos_Empresa_Planes_de_SuscripcionItems[i].Nombre_del_Plan }).appendTo(Detalle_Contratos_Empresa_Planes_de_SuscripcionDropdown);
       }
    }
    return Detalle_Contratos_Empresa_Planes_de_SuscripcionDropdown;
}
function GetDetalle_Contratos_Empresa_Tipos_de_ContratoName(Id) {
    for (var i = 0; i < Detalle_Contratos_Empresa_Tipos_de_ContratoItems.length; i++) {
        if (Detalle_Contratos_Empresa_Tipos_de_ContratoItems[i].Clave == Id) {
            return Detalle_Contratos_Empresa_Tipos_de_ContratoItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_Contratos_Empresa_Tipos_de_ContratoDropDown() {
    var Detalle_Contratos_Empresa_Tipos_de_ContratoDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Contratos_Empresa_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Contratos_Empresa_Tipos_de_ContratoDropdown);
    if(Detalle_Contratos_Empresa_Tipos_de_ContratoItems != null)
    {
       for (var i = 0; i < Detalle_Contratos_Empresa_Tipos_de_ContratoItems.length; i++) {
           $('<option />', { value: Detalle_Contratos_Empresa_Tipos_de_ContratoItems[i].Clave, text:    Detalle_Contratos_Empresa_Tipos_de_ContratoItems[i].Descripcion }).appendTo(Detalle_Contratos_Empresa_Tipos_de_ContratoDropdown);
       }
    }
    return Detalle_Contratos_Empresa_Tipos_de_ContratoDropdown;
}




function GetInsertDetalle_Contratos_EmpresaRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $(GetDetalle_Contratos_Empresa_Planes_de_SuscripcionDropDown()).addClass('Detalle_Contratos_Empresa_Suscripcion Suscripcion').attr('id', 'Detalle_Contratos_Empresa_Suscripcion_' + index).attr('data-field', 'Suscripcion').after($.parseHTML(addNew('Detalle_Contratos_Empresa', 'Planes_de_Suscripcion', 'Suscripcion', 258513)));
    columnData[1] = $(GetDetalle_Contratos_Empresa_Tipos_de_ContratoDropDown()).addClass('Detalle_Contratos_Empresa_Tipo_de_Contrato Tipo_de_Contrato').attr('id', 'Detalle_Contratos_Empresa_Tipo_de_Contrato_' + index).attr('data-field', 'Tipo_de_Contrato').after($.parseHTML(addNew('Detalle_Contratos_Empresa', 'Tipos_de_Contrato', 'Tipo_de_Contrato', 258514)));
    columnData[2] = $($.parseHTML(GetFileUploader())).addClass('Detalle_Contratos_Empresa_Documento_FileUpload Documento').attr('id', 'Detalle_Contratos_Empresa_Documento_' + index).attr('data-field', 'Documento');
    columnData[3] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Contratos_Empresa_Fecha_de_Firma_de_Contrato Fecha_de_Firma_de_Contrato').attr('id', 'Detalle_Contratos_Empresa_Fecha_de_Firma_de_Contrato_' + index).attr('data-field', 'Fecha_de_Firma_de_Contrato');


    initiateUIControls();
    return columnData;
}

function Detalle_Contratos_EmpresaInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Contratos_Empresa("Detalle_Contratos_Empresa_", "_" + rowIndex)) {
    var iPage = Detalle_Contratos_EmpresaTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Contratos_Empresa';
    var prevData = Detalle_Contratos_EmpresaTable.fnGetData(rowIndex);
    var data = Detalle_Contratos_EmpresaTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Suscripcion:  data.childNodes[counter++].childNodes[0].value
        ,Tipo_de_Contrato:  data.childNodes[counter++].childNodes[0].value
        ,DocumentoFileInfo: ($('#' + nameOfGrid + 'Grid .DocumentoHeader').css('display') != 'none') ? { 
             FileName: prevData.DocumentoFileInfo != null && prevData.DocumentoFileInfo.FileName != null && prevData.DocumentoFileInfo.FileName != ''? prevData.DocumentoFileInfo.FileName : (data.childNodes[counter].childNodes[0].files.length > 0 ? data.childNodes[counter].childNodes[0].files[0].name : ''),              
			 FileId:   prevData.DocumentoFileInfo != null && prevData.DocumentoFileInfo.FileName != null && prevData.DocumentoFileInfo.FileName != '' ? prevData.DocumentoFileInfo.FileId :  prevData.DocumentoFileInfo != null && prevData.DocumentoFileInfo.FileId != '' && prevData.DocumentoFileInfo.FileId != undefined ? prevData.DocumentoFileInfo.FileId : '0',
             FileSize: prevData.DocumentoFileInfo != null && prevData.DocumentoFileInfo.FileName != null ? prevData.DocumentoFileInfo.FileSize : (data.childNodes[counter].childNodes[0].files.length > 0 ? data.childNodes[counter].childNodes[0].files[0].name : '') 
         } : ''
        ,DocumentoDetail: (data.childNodes[counter] != 'undefined' && data.childNodes[counter].childNodes[0].childNodes.length == 0) ? data.childNodes[counter++].childNodes[0] : prevData.DocumentoDetail
        ,Fecha_de_Firma_de_Contrato:  data.childNodes[counter++].childNodes[0].value

    }
    Detalle_Contratos_EmpresaTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Contratos_EmpresarowCreationGrid(data, newData, rowIndex);
    Detalle_Contratos_EmpresaTable.fnPageChange(iPage);
    Detalle_Contratos_EmpresacountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Contratos_Empresa("Detalle_Contratos_Empresa_", "_" + rowIndex);
  }
}

function Detalle_Contratos_EmpresaCancelRow(rowIndex) {
    var prevData = Detalle_Contratos_EmpresaTable.fnGetData(rowIndex);
    var data = Detalle_Contratos_EmpresaTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Contratos_EmpresaTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Contratos_EmpresarowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Contratos_EmpresaGrid(Detalle_Contratos_EmpresaTable.fnGetData());
    Detalle_Contratos_EmpresacountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Contratos_EmpresaFromDataTable() {
    var Detalle_Contratos_EmpresaData = [];
    var gridData = Detalle_Contratos_EmpresaTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Contratos_EmpresaData.push({
                Folio: gridData[i].Folio

                ,Suscripcion: gridData[i].Suscripcion
                ,Tipo_de_Contrato: gridData[i].Tipo_de_Contrato
                ,DocumentoInfo: {
                    FileName: gridData[i].DocumentoFileInfo.FileName, FileId: gridData[i].DocumentoFileInfo.FileId, FileSize: gridData[i].DocumentoFileInfo.FileSize,
                    Control: gridData[i].DocumentoDetail != null && gridData[i].DocumentoDetail.files != null && gridData[i].DocumentoDetail.files.length > 0 ? gridData[i].DocumentoDetail.files[0] : null,
                    DocumentoRemoveFile: gridData[i].DocumentoDetail != null
                }
                ,Fecha_de_Firma_de_Contrato: gridData[i].Fecha_de_Firma_de_Contrato

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Contratos_EmpresaData.length; i++) {
        if (removedDetalle_Contratos_EmpresaData[i] != null && removedDetalle_Contratos_EmpresaData[i].Folio > 0)
            Detalle_Contratos_EmpresaData.push({
                Folio: removedDetalle_Contratos_EmpresaData[i].Folio

                ,Suscripcion: removedDetalle_Contratos_EmpresaData[i].Suscripcion
                ,Tipo_de_Contrato: removedDetalle_Contratos_EmpresaData[i].Tipo_de_Contrato
                ,DocumentoInfo: {
                    FileName: removedDetalle_Contratos_EmpresaData[i].DocumentoFileInfo.FileName, 
                    FileId: removedDetalle_Contratos_EmpresaData[i].DocumentoFileInfo.FileId, 
                    FileSize: removedDetalle_Contratos_EmpresaData[i].DocumentoFileInfo.FileSize,
                    Control: removedDetalle_Contratos_EmpresaData[i].DocumentoDetail != null && removedDetalle_Contratos_EmpresaData[i].DocumentoDetail.files.length > 0 ? removedDetalle_Contratos_EmpresaData[i].DocumentoDetail.files[0] : null,
                    DocumentoRemoveFile: removedDetalle_Contratos_EmpresaData[i].DocumentoDetail != null
                }
                ,Fecha_de_Firma_de_Contrato: removedDetalle_Contratos_EmpresaData[i].Fecha_de_Firma_de_Contrato

                , Removed: true
            });
    }	

    return Detalle_Contratos_EmpresaData;
}

function Detalle_Contratos_EmpresaEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Contratos_EmpresaTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Contratos_EmpresacountRowsChecked++;
    var Detalle_Contratos_EmpresaRowElement = "Detalle_Contratos_Empresa_" + rowIndex.toString();
    var prevData = Detalle_Contratos_EmpresaTable.fnGetData(rowIndexTable );
    var row = Detalle_Contratos_EmpresaTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Contratos_Empresa_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Contratos_EmpresaGetUpdateRowControls(prevData, "Detalle_Contratos_Empresa_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Contratos_EmpresaRowElement + "')){ Detalle_Contratos_EmpresaInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_Contratos_EmpresaCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Contratos_EmpresaGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Contratos_EmpresaGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_Contratos_EmpresaValidation();
    initiateUIControls();
    $('.Detalle_Contratos_Empresa' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Contratos_Empresa(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Contratos_EmpresafnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Contratos_EmpresaTable.fnGetData().length;
    Detalle_Contratos_EmpresafnClickAddRow();
    GetAddDetalle_Contratos_EmpresaPopup(currentRowIndex, 0);
}

function Detalle_Contratos_EmpresaEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Contratos_EmpresaTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Contratos_EmpresaRowElement = "Detalle_Contratos_Empresa_" + rowIndex.toString();
    var prevData = Detalle_Contratos_EmpresaTable.fnGetData(rowIndexTable);
    GetAddDetalle_Contratos_EmpresaPopup(rowIndex, 1, prevData.Folio);

    $('#Detalle_Contratos_EmpresaSuscripcion').val(prevData.Suscripcion);
    $('#Detalle_Contratos_EmpresaTipo_de_Contrato').val(prevData.Tipo_de_Contrato);

    $('#Detalle_Contratos_EmpresaFecha_de_Firma_de_Contrato').val(prevData.Fecha_de_Firma_de_Contrato);

    initiateUIControls();



    $('#existingDocumento').html(prevData.DocumentoFileDetail == null && (prevData.DocumentoFileInfo.FileId == null || prevData.DocumentoFileInfo.FileId <= 0) ? $.parseHTML(GetFileUploader()) : GetFileInfo(prevData.DocumentoFileInfo, prevData.DocumentoFileDetail));


}

function Detalle_Contratos_EmpresaAddInsertRow() {
    if (Detalle_Contratos_EmpresainsertRowCurrentIndex < 1)
    {
        Detalle_Contratos_EmpresainsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Suscripcion: ""
        ,Tipo_de_Contrato: ""
        ,DocumentoFileInfo: ""
        ,Fecha_de_Firma_de_Contrato: ""

    }
}

function Detalle_Contratos_EmpresafnClickAddRow() {
    Detalle_Contratos_EmpresacountRowsChecked++;
    Detalle_Contratos_EmpresaTable.fnAddData(Detalle_Contratos_EmpresaAddInsertRow(), true);
    Detalle_Contratos_EmpresaTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_Contratos_EmpresaGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_Contratos_EmpresaGrid tbody tr:nth-of-type(' + (Detalle_Contratos_EmpresainsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Contratos_Empresa("Detalle_Contratos_Empresa_", "_" + Detalle_Contratos_EmpresainsertRowCurrentIndex);
}

function Detalle_Contratos_EmpresaClearGridData() {
    Detalle_Contratos_EmpresaData = [];
    Detalle_Contratos_EmpresadeletedItem = [];
    Detalle_Contratos_EmpresaDataMain = [];
    Detalle_Contratos_EmpresaDataMainPages = [];
    Detalle_Contratos_EmpresanewItemCount = 0;
    Detalle_Contratos_EmpresamaxItemIndex = 0;
    $("#Detalle_Contratos_EmpresaGrid").DataTable().clear();
    $("#Detalle_Contratos_EmpresaGrid").DataTable().destroy();
}

//Used to Get Empresas Information
function GetDetalle_Contratos_Empresa() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Contratos_EmpresaData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Contratos_EmpresaData[i].Folio);

        form_data.append('[' + i + '].Suscripcion', Detalle_Contratos_EmpresaData[i].Suscripcion);
        form_data.append('[' + i + '].Tipo_de_Contrato', Detalle_Contratos_EmpresaData[i].Tipo_de_Contrato);
        form_data.append('[' + i + '].DocumentoInfo.FileId', Detalle_Contratos_EmpresaData[i].DocumentoInfo.FileId);
        form_data.append('[' + i + '].DocumentoInfo.FileName', Detalle_Contratos_EmpresaData[i].DocumentoInfo.FileName);
        form_data.append('[' + i + '].DocumentoInfo.FileSize', Detalle_Contratos_EmpresaData[i].DocumentoInfo.FileSize);
        form_data.append('[' + i + '].DocumentoInfo.Control', Detalle_Contratos_EmpresaData[i].DocumentoInfo.Control);
        form_data.append('[' + i + '].DocumentoInfo.RemoveFile', Detalle_Contratos_EmpresaData[i].DocumentoInfo.ArchivoRemoveFile);
        form_data.append('[' + i + '].Fecha_de_Firma_de_Contrato', Detalle_Contratos_EmpresaData[i].Fecha_de_Firma_de_Contrato);

        form_data.append('[' + i + '].Removed', Detalle_Contratos_EmpresaData[i].Removed);
    }
    return form_data;
}
function Detalle_Contratos_EmpresaInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Contratos_Empresa("Detalle_Contratos_EmpresaTable", rowIndex)) {
    var prevData = Detalle_Contratos_EmpresaTable.fnGetData(rowIndex);
    var data = Detalle_Contratos_EmpresaTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Suscripcion: $('#Detalle_Contratos_EmpresaSuscripcion').val()
        ,Tipo_de_Contrato: $('#Detalle_Contratos_EmpresaTipo_de_Contrato').val()
        ,DocumentoFileInfo: { DocumentoFileName: prevData.DocumentoFileInfo.FileName, DocumentoFileId: prevData.DocumentoFileInfo.FileId, DocumentoFileSize: prevData.DocumentoFileInfo.FileSize }
        ,DocumentoFileDetail: $('#Documento').find('label').length == 0 ? $('#DocumentoFileInfoPop')[0] : prevData.DocumentoFileDetail
        ,Fecha_de_Firma_de_Contrato: $('#Detalle_Contratos_EmpresaFecha_de_Firma_de_Contrato').val()

    }

    Detalle_Contratos_EmpresaTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Contratos_EmpresarowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Contratos_Empresa-form').modal({ show: false });
    $('#AddDetalle_Contratos_Empresa-form').modal('hide');
    Detalle_Contratos_EmpresaEditRow(rowIndex);
    Detalle_Contratos_EmpresaInsertRow(rowIndex);
    //}
}
function Detalle_Contratos_EmpresaRemoveAddRow(rowIndex) {
    Detalle_Contratos_EmpresaTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Contratos_Empresa MultiRow


$(function () {
    function Detalle_Contactos_EmpresainitializeMainArray(totalCount) {
        if (Detalle_Contactos_EmpresaDataMain.length != totalCount && !Detalle_Contactos_EmpresaDataMainInitialized) {
            Detalle_Contactos_EmpresaDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Contactos_EmpresaDataMain[i] = null;
            }
        }
    }
    function Detalle_Contactos_EmpresaremoveFromMainArray() {
        for (var j = 0; j < Detalle_Contactos_EmpresadeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Contactos_EmpresaDataMain.length; i++) {
                if (Detalle_Contactos_EmpresaDataMain[i] != null && Detalle_Contactos_EmpresaDataMain[i].Id == Detalle_Contactos_EmpresadeletedItem[j]) {
                    hDetalle_Contactos_EmpresaDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Contactos_EmpresacopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Contactos_EmpresaDataMain.length; i++) {
            data[i] = Detalle_Contactos_EmpresaDataMain[i];

        }
        return data;
    }
    function Detalle_Contactos_EmpresagetNewResult() {
        var newData = copyMainDetalle_Contactos_EmpresaArray();

        for (var i = 0; i < Detalle_Contactos_EmpresaData.length; i++) {
            if (Detalle_Contactos_EmpresaData[i].Removed == null || Detalle_Contactos_EmpresaData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Contactos_EmpresaData[i]);
            }
        }
        return newData;
    }
    function Detalle_Contactos_EmpresapushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Contactos_EmpresaDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Contactos_EmpresaDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Detalle_Suscripciones_EmpresainitializeMainArray(totalCount) {
        if (Detalle_Suscripciones_EmpresaDataMain.length != totalCount && !Detalle_Suscripciones_EmpresaDataMainInitialized) {
            Detalle_Suscripciones_EmpresaDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Suscripciones_EmpresaDataMain[i] = null;
            }
        }
    }
    function Detalle_Suscripciones_EmpresaremoveFromMainArray() {
        for (var j = 0; j < Detalle_Suscripciones_EmpresadeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Suscripciones_EmpresaDataMain.length; i++) {
                if (Detalle_Suscripciones_EmpresaDataMain[i] != null && Detalle_Suscripciones_EmpresaDataMain[i].Id == Detalle_Suscripciones_EmpresadeletedItem[j]) {
                    hDetalle_Suscripciones_EmpresaDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Suscripciones_EmpresacopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Suscripciones_EmpresaDataMain.length; i++) {
            data[i] = Detalle_Suscripciones_EmpresaDataMain[i];

        }
        return data;
    }
    function Detalle_Suscripciones_EmpresagetNewResult() {
        var newData = copyMainDetalle_Suscripciones_EmpresaArray();

        for (var i = 0; i < Detalle_Suscripciones_EmpresaData.length; i++) {
            if (Detalle_Suscripciones_EmpresaData[i].Removed == null || Detalle_Suscripciones_EmpresaData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Suscripciones_EmpresaData[i]);
            }
        }
        return newData;
    }
    function Detalle_Suscripciones_EmpresapushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Suscripciones_EmpresaDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Suscripciones_EmpresaDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Detalle_Pagos_EmpresainitializeMainArray(totalCount) {
        if (Detalle_Pagos_EmpresaDataMain.length != totalCount && !Detalle_Pagos_EmpresaDataMainInitialized) {
            Detalle_Pagos_EmpresaDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Pagos_EmpresaDataMain[i] = null;
            }
        }
    }
    function Detalle_Pagos_EmpresaremoveFromMainArray() {
        for (var j = 0; j < Detalle_Pagos_EmpresadeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Pagos_EmpresaDataMain.length; i++) {
                if (Detalle_Pagos_EmpresaDataMain[i] != null && Detalle_Pagos_EmpresaDataMain[i].Id == Detalle_Pagos_EmpresadeletedItem[j]) {
                    hDetalle_Pagos_EmpresaDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Pagos_EmpresacopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Pagos_EmpresaDataMain.length; i++) {
            data[i] = Detalle_Pagos_EmpresaDataMain[i];

        }
        return data;
    }
    function Detalle_Pagos_EmpresagetNewResult() {
        var newData = copyMainDetalle_Pagos_EmpresaArray();

        for (var i = 0; i < Detalle_Pagos_EmpresaData.length; i++) {
            if (Detalle_Pagos_EmpresaData[i].Removed == null || Detalle_Pagos_EmpresaData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Pagos_EmpresaData[i]);
            }
        }
        return newData;
    }
    function Detalle_Pagos_EmpresapushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Pagos_EmpresaDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Pagos_EmpresaDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Detalle_Registro_Beneficiarios_EmpresainitializeMainArray(totalCount) {
        if (Detalle_Registro_Beneficiarios_EmpresaDataMain.length != totalCount && !Detalle_Registro_Beneficiarios_EmpresaDataMainInitialized) {
            Detalle_Registro_Beneficiarios_EmpresaDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Registro_Beneficiarios_EmpresaDataMain[i] = null;
            }
        }
    }
    function Detalle_Registro_Beneficiarios_EmpresaremoveFromMainArray() {
        for (var j = 0; j < Detalle_Registro_Beneficiarios_EmpresadeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Registro_Beneficiarios_EmpresaDataMain.length; i++) {
                if (Detalle_Registro_Beneficiarios_EmpresaDataMain[i] != null && Detalle_Registro_Beneficiarios_EmpresaDataMain[i].Id == Detalle_Registro_Beneficiarios_EmpresadeletedItem[j]) {
                    hDetalle_Registro_Beneficiarios_EmpresaDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Registro_Beneficiarios_EmpresacopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Registro_Beneficiarios_EmpresaDataMain.length; i++) {
            data[i] = Detalle_Registro_Beneficiarios_EmpresaDataMain[i];

        }
        return data;
    }
    function Detalle_Registro_Beneficiarios_EmpresagetNewResult() {
        var newData = copyMainDetalle_Registro_Beneficiarios_EmpresaArray();

        for (var i = 0; i < Detalle_Registro_Beneficiarios_EmpresaData.length; i++) {
            if (Detalle_Registro_Beneficiarios_EmpresaData[i].Removed == null || Detalle_Registro_Beneficiarios_EmpresaData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Registro_Beneficiarios_EmpresaData[i]);
            }
        }
        return newData;
    }
    function Detalle_Registro_Beneficiarios_EmpresapushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Registro_Beneficiarios_EmpresaDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Registro_Beneficiarios_EmpresaDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Detalle_Contratos_EmpresainitializeMainArray(totalCount) {
        if (Detalle_Contratos_EmpresaDataMain.length != totalCount && !Detalle_Contratos_EmpresaDataMainInitialized) {
            Detalle_Contratos_EmpresaDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Contratos_EmpresaDataMain[i] = null;
            }
        }
    }
    function Detalle_Contratos_EmpresaremoveFromMainArray() {
        for (var j = 0; j < Detalle_Contratos_EmpresadeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Contratos_EmpresaDataMain.length; i++) {
                if (Detalle_Contratos_EmpresaDataMain[i] != null && Detalle_Contratos_EmpresaDataMain[i].Id == Detalle_Contratos_EmpresadeletedItem[j]) {
                    hDetalle_Contratos_EmpresaDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Contratos_EmpresacopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Contratos_EmpresaDataMain.length; i++) {
            data[i] = Detalle_Contratos_EmpresaDataMain[i];

        }
        return data;
    }
    function Detalle_Contratos_EmpresagetNewResult() {
        var newData = copyMainDetalle_Contratos_EmpresaArray();

        for (var i = 0; i < Detalle_Contratos_EmpresaData.length; i++) {
            if (Detalle_Contratos_EmpresaData[i].Removed == null || Detalle_Contratos_EmpresaData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Contratos_EmpresaData[i]);
            }
        }
        return newData;
    }
    function Detalle_Contratos_EmpresapushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Contratos_EmpresaDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Contratos_EmpresaDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }

});

//Grid GetAutocomplete

//Grid GetAutocomplete

//Grid GetAutocomplete

//Grid GetAutocomplete

//Grid GetAutocomplete



function getDropdown(elementKey) {
    var labelSelect = $("#Empresas_cmbLabelSelect").val();
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
    $('#CreateEmpresas')[0].reset();
    ClearFormControls();
    $("#FolioId").val("0");
                Detalle_Contactos_EmpresaClearGridData();
                Detalle_Suscripciones_EmpresaClearGridData();
                Detalle_Pagos_EmpresaClearGridData();
                Detalle_Registro_Beneficiarios_EmpresaClearGridData();
                Detalle_Contratos_EmpresaClearGridData();

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreateEmpresas').trigger('reset');
    $('#CreateEmpresas').find(':input').each(function () {
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
    var $myForm = $('#CreateEmpresas');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    if (Detalle_Contactos_EmpresacountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Contactos_Empresa();
        return false;
    }
    if (Detalle_Suscripciones_EmpresacountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Suscripciones_Empresa();
        return false;
    }
    if (Detalle_Pagos_EmpresacountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Pagos_Empresa();
        return false;
    }
    if (Detalle_Registro_Beneficiarios_EmpresacountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Registro_Beneficiarios_Empresa();
        return false;
    }
    if (Detalle_Contratos_EmpresacountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Contratos_Empresa();
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblFolio").text("0");
}
$(document).ready(function () {
    $("form#CreateEmpresas").submit(function (e) {
        e.preventDefault();
        return false;
    });
	$("form#CreateEmpresas").on('click', '#EmpresasCancelar', function () {
	  if (!isPartial) {
        EmpresasBackToGrid();
	  } else {
            window.close();
      }
    });
	$("form#CreateEmpresas").on('click', '#EmpresasGuardar', function () {
		$('#EmpresasGuardar').attr('disabled', true);
		$('#EmpresasGuardar').unbind()
        if (EjecutarValidacionesAntesDeGuardar() && CheckValidation()) {
				if (!SendEmpresasData(function () {
					EjecutarValidacionesDespuesDeGuardar();
					if (!isPartial)
						EmpresasBackToGrid();
					else {						
						if (!isMR)
							window.opener.RefreshCatalog('Empresas', nameAttribute);
						else {
							var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
							if(!control.hasClass('AutoComplete'))
							{
							if (control.attr("data-isfilter") == "true") {
									eval(GetReglaFilter(control,  $(window.opener.document.getElementById('ObjectId')).val()));								    
								}
								else 
								{
									eval('window.opener.Get' + nameMR + '_EmpresasItem()');
									var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
									control.html(eval('window.opener.Get' + nameMR + '_EmpresasDropDown().get(0)').innerHTML);  
								}								
							}
						}
						window.close();						
						}
				})) {
					$('#EmpresasGuardar').removeAttr('disabled');
					$('#EmpresasGuardar').bind()
				}
		}
		else {
			$('#EmpresasGuardar').removeAttr('disabled');
			$('#EmpresasGuardar').bind()
		}
    });
	$("form#CreateEmpresas").on('click', '#EmpresasGuardarYNuevo', function () {	
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation()) {
				SendEmpresasData(function () {
					ClearControls();
					ClearAttachmentsDiv();
					ResetClaveLabel();
	                getDetalle_Contactos_EmpresaData();
                getDetalle_Suscripciones_EmpresaData();
                getDetalle_Pagos_EmpresaData();
                getDetalle_Registro_Beneficiarios_EmpresaData();
                getDetalle_Contratos_EmpresaData();

					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Empresas', nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_EmpresasItem()');                           
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
                            control.html(eval('window.opener.Get' + nameMR + '_EmpresasDropDown().get(0)').innerHTML);   
					    }	
					}						
					EjecutarValidacionesDespuesDeGuardar();				
			setIsNew();
			EjecutarValidacionesAlComienzo();
				});
			}
		}		
    });
    $("form#CreateEmpresas").on('click', '#EmpresasGuardarYCopia', function () {
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendEmpresasData(function (currentId) {
					$("#FolioId").val("0");
	                Detalle_Contactos_EmpresaClearGridData();
                Detalle_Suscripciones_EmpresaClearGridData();
                Detalle_Pagos_EmpresaClearGridData();
                Detalle_Registro_Beneficiarios_EmpresaClearGridData();
                Detalle_Contratos_EmpresaClearGridData();

					ResetClaveLabel();
					$("#ReferenceFolio").val(currentId);
	                getDetalle_Contactos_EmpresaData();
                getDetalle_Suscripciones_EmpresaData();
                getDetalle_Pagos_EmpresaData();
                getDetalle_Registro_Beneficiarios_EmpresaData();
                getDetalle_Contratos_EmpresaData();

					EjecutarValidacionesDespuesDeGuardar();		
					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Empresas',nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_EmpresasItem()');                          
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);						
							control.html(eval('window.opener.Get' + nameMR + '_EmpresasDropDown().get(0)').innerHTML);                          
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



var EmpresasisdisplayBusinessPropery = false;
EmpresasDisplayBusinessRuleButtons(EmpresasisdisplayBusinessPropery);
function EmpresasDisplayBusinessRule() {
    if (!EmpresasisdisplayBusinessPropery) {
        $('#CreateEmpresas').find('.col-sm-8').each(function () {
			var div =$(this); 
			if ($(this).find('.input-group').length >0)
				div  =  $(this).find('.input-group').first().hasClass('date')? $(this): $(this).find('.input-group').first();	
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = div.data('field-id');
            var fieldName = div.data('field-name');
            var attribute = div.data('attribute');
            mainElementAttributes += '<div class="EmpresasdisplayBusinessPropery"><button onclick="EmpresasGetBusinessRule()" type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#EmpresasBusinessRule-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.EmpresasdisplayBusinessPropery').remove();
    }
    EmpresasDisplayBusinessRuleButtons(!EmpresasisdisplayBusinessPropery);
    EmpresasisdisplayBusinessPropery = (EmpresasisdisplayBusinessPropery ? false : true);
}
function EmpresasDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}

