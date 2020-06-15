        function RemoveAttachmentMainImagen () {
            $("#hdnRemoveImagen").val("1");
            $("#divAttachmentImagen").hide();
        }


//Begin Declarations for Foreigns fields for Detalle_de_Ingredientes MultiRow
var Detalle_de_IngredientescountRowsChecked = 0;


function GetDetalle_de_Ingredientes_Unidades_de_MedidaName(Id) {
    for (var i = 0; i < Detalle_de_Ingredientes_Unidades_de_MedidaItems.length; i++) {
        if (Detalle_de_Ingredientes_Unidades_de_MedidaItems[i].Clave == Id) {
            return Detalle_de_Ingredientes_Unidades_de_MedidaItems[i].Unidad;
        }
    }
    return "";
}

function GetDetalle_de_Ingredientes_Unidades_de_MedidaDropDown() {
    var Detalle_de_Ingredientes_Unidades_de_MedidaDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_de_Ingredientes_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_de_Ingredientes_Unidades_de_MedidaDropdown);
    if(Detalle_de_Ingredientes_Unidades_de_MedidaItems != null)
    {
       for (var i = 0; i < Detalle_de_Ingredientes_Unidades_de_MedidaItems.length; i++) {
           $('<option />', { value: Detalle_de_Ingredientes_Unidades_de_MedidaItems[i].Clave, text:    Detalle_de_Ingredientes_Unidades_de_MedidaItems[i].Unidad }).appendTo(Detalle_de_Ingredientes_Unidades_de_MedidaDropdown);
       }
    }
    return Detalle_de_Ingredientes_Unidades_de_MedidaDropdown;
}
function GetDetalle_de_Ingredientes_IngredientesName(Id) {
    for (var i = 0; i < Detalle_de_Ingredientes_IngredientesItems.length; i++) {
        if (Detalle_de_Ingredientes_IngredientesItems[i].Clave == Id) {
            return Detalle_de_Ingredientes_IngredientesItems[i].Nombre_Ingrediente;
        }
    }
    return "";
}

function GetDetalle_de_Ingredientes_IngredientesDropDown() {
    var Detalle_de_Ingredientes_IngredientesDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_de_Ingredientes_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_de_Ingredientes_IngredientesDropdown);
    if(Detalle_de_Ingredientes_IngredientesItems != null)
    {
       for (var i = 0; i < Detalle_de_Ingredientes_IngredientesItems.length; i++) {
           $('<option />', { value: Detalle_de_Ingredientes_IngredientesItems[i].Clave, text:    Detalle_de_Ingredientes_IngredientesItems[i].Nombre_Ingrediente }).appendTo(Detalle_de_Ingredientes_IngredientesDropdown);
       }
    }
    return Detalle_de_Ingredientes_IngredientesDropdown;
}
function GetDetalle_de_Ingredientes_PresentacionName(Id) {
    for (var i = 0; i < Detalle_de_Ingredientes_PresentacionItems.length; i++) {
        if (Detalle_de_Ingredientes_PresentacionItems[i].Clave == Id) {
            return Detalle_de_Ingredientes_PresentacionItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_de_Ingredientes_PresentacionDropDown() {
    var Detalle_de_Ingredientes_PresentacionDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_de_Ingredientes_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_de_Ingredientes_PresentacionDropdown);
    if(Detalle_de_Ingredientes_PresentacionItems != null)
    {
       for (var i = 0; i < Detalle_de_Ingredientes_PresentacionItems.length; i++) {
           $('<option />', { value: Detalle_de_Ingredientes_PresentacionItems[i].Clave, text:    Detalle_de_Ingredientes_PresentacionItems[i].Descripcion }).appendTo(Detalle_de_Ingredientes_PresentacionDropdown);
       }
    }
    return Detalle_de_Ingredientes_PresentacionDropdown;
}
function GetDetalle_de_Ingredientes_MarcaName(Id) {
    for (var i = 0; i < Detalle_de_Ingredientes_MarcaItems.length; i++) {
        if (Detalle_de_Ingredientes_MarcaItems[i].Clave == Id) {
            return Detalle_de_Ingredientes_MarcaItems[i].Descripcion;
        }
    }
    return "";
}

function GetDetalle_de_Ingredientes_MarcaDropDown() {
    var Detalle_de_Ingredientes_MarcaDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_de_Ingredientes_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_de_Ingredientes_MarcaDropdown);
    if(Detalle_de_Ingredientes_MarcaItems != null)
    {
       for (var i = 0; i < Detalle_de_Ingredientes_MarcaItems.length; i++) {
           $('<option />', { value: Detalle_de_Ingredientes_MarcaItems[i].Clave, text:    Detalle_de_Ingredientes_MarcaItems[i].Descripcion }).appendTo(Detalle_de_Ingredientes_MarcaDropdown);
       }
    }
    return Detalle_de_Ingredientes_MarcaDropdown;
}


function GetInsertDetalle_de_IngredientesRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $($.parseHTML(inputData)).addClass('Detalle_de_Ingredientes_Cantidad Cantidad').attr('id', 'Detalle_de_Ingredientes_Cantidad_' + index).attr('data-field', 'Cantidad');
    columnData[1] = $(GetDetalle_de_Ingredientes_Unidades_de_MedidaDropDown()).addClass('Detalle_de_Ingredientes_Unidad Unidad').attr('id', 'Detalle_de_Ingredientes_Unidad_' + index).attr('data-field', 'Unidad').after($.parseHTML(addNew('Detalle_de_Ingredientes', 'Unidades_de_Medida', 'Unidad', 254849)));
    columnData[2] = $(GetDetalle_de_Ingredientes_IngredientesDropDown()).addClass('Detalle_de_Ingredientes_Nombre_del_Ingrediente Nombre_del_Ingrediente').attr('id', 'Detalle_de_Ingredientes_Nombre_del_Ingrediente_' + index).attr('data-field', 'Nombre_del_Ingrediente').after($.parseHTML(addNew('Detalle_de_Ingredientes', 'Ingredientes', 'Nombre_del_Ingrediente', 254848)));
    columnData[3] = $(GetDetalle_de_Ingredientes_PresentacionDropDown()).addClass('Detalle_de_Ingredientes_Nombre_de_presentacion Nombre_de_presentacion').attr('id', 'Detalle_de_Ingredientes_Nombre_de_presentacion_' + index).attr('data-field', 'Nombre_de_presentacion').after($.parseHTML(addNew('Detalle_de_Ingredientes', 'Presentacion', 'Nombre_de_presentacion', 254861)));
    columnData[4] = $(GetDetalle_de_Ingredientes_MarcaDropDown()).addClass('Detalle_de_Ingredientes_Nombre_de_Marca Nombre_de_Marca').attr('id', 'Detalle_de_Ingredientes_Nombre_de_Marca_' + index).attr('data-field', 'Nombre_de_Marca').after($.parseHTML(addNew('Detalle_de_Ingredientes', 'Marca', 'Nombre_de_Marca', 254862)));


    initiateUIControls();
    return columnData;
}

function Detalle_de_IngredientesInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_de_Ingredientes("Detalle_de_Ingredientes_", "_" + rowIndex)) {
    var iPage = Detalle_de_IngredientesTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_de_Ingredientes';
    var prevData = Detalle_de_IngredientesTable.fnGetData(rowIndex);
    var data = Detalle_de_IngredientesTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Clave: prevData.Clave,
        IsInsertRow: false

        ,Cantidad:  data.childNodes[counter++].childNodes[0].value
        ,Unidad:  data.childNodes[counter++].childNodes[0].value
        ,Nombre_del_Ingrediente:  data.childNodes[counter++].childNodes[0].value
        ,Nombre_de_presentacion:  data.childNodes[counter++].childNodes[0].value
        ,Nombre_de_Marca:  data.childNodes[counter++].childNodes[0].value

    }
    Detalle_de_IngredientesTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_de_IngredientesrowCreationGrid(data, newData, rowIndex);
    Detalle_de_IngredientesTable.fnPageChange(iPage);
    Detalle_de_IngredientescountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_de_Ingredientes("Detalle_de_Ingredientes_", "_" + rowIndex);
  }
}

function Detalle_de_IngredientesCancelRow(rowIndex) {
    var prevData = Detalle_de_IngredientesTable.fnGetData(rowIndex);
    var data = Detalle_de_IngredientesTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_de_IngredientesTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_de_IngredientesrowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_de_IngredientesGrid(Detalle_de_IngredientesTable.fnGetData());
    Detalle_de_IngredientescountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_de_IngredientesFromDataTable() {
    var Detalle_de_IngredientesData = [];
    var gridData = Detalle_de_IngredientesTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_de_IngredientesData.push({
                Clave: gridData[i].Clave

                ,Cantidad: gridData[i].Cantidad
                ,Unidad: gridData[i].Unidad
                ,Nombre_del_Ingrediente: gridData[i].Nombre_del_Ingrediente
                ,Nombre_de_presentacion: gridData[i].Nombre_de_presentacion
                ,Nombre_de_Marca: gridData[i].Nombre_de_Marca

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_de_IngredientesData.length; i++) {
        if (removedDetalle_de_IngredientesData[i] != null && removedDetalle_de_IngredientesData[i].Clave > 0)
            Detalle_de_IngredientesData.push({
                Clave: removedDetalle_de_IngredientesData[i].Clave

                ,Cantidad: removedDetalle_de_IngredientesData[i].Cantidad
                ,Unidad: removedDetalle_de_IngredientesData[i].Unidad
                ,Nombre_del_Ingrediente: removedDetalle_de_IngredientesData[i].Nombre_del_Ingrediente
                ,Nombre_de_presentacion: removedDetalle_de_IngredientesData[i].Nombre_de_presentacion
                ,Nombre_de_Marca: removedDetalle_de_IngredientesData[i].Nombre_de_Marca

                , Removed: true
            });
    }	

    return Detalle_de_IngredientesData;
}

function Detalle_de_IngredientesEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_de_IngredientesTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_de_IngredientescountRowsChecked++;
    var Detalle_de_IngredientesRowElement = "Detalle_de_Ingredientes_" + rowIndex.toString();
    var prevData = Detalle_de_IngredientesTable.fnGetData(rowIndexTable );
    var row = Detalle_de_IngredientesTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_de_Ingredientes_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_de_IngredientesGetUpdateRowControls(prevData, "Detalle_de_Ingredientes_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_de_IngredientesRowElement + "')){ Detalle_de_IngredientesInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_de_IngredientesCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_de_IngredientesGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_de_IngredientesGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_de_IngredientesValidation();
    initiateUIControls();
    $('.Detalle_de_Ingredientes' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_de_Ingredientes(nameOfTable, rowIndexFormed);
    }
}

function Detalle_de_IngredientesfnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_de_IngredientesTable.fnGetData().length;
    Detalle_de_IngredientesfnClickAddRow();
    GetAddDetalle_de_IngredientesPopup(currentRowIndex, 0);
}

function Detalle_de_IngredientesEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_de_IngredientesTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_de_IngredientesRowElement = "Detalle_de_Ingredientes_" + rowIndex.toString();
    var prevData = Detalle_de_IngredientesTable.fnGetData(rowIndexTable);
    GetAddDetalle_de_IngredientesPopup(rowIndex, 1, prevData.Clave);

    $('#Detalle_de_IngredientesCantidad').val(prevData.Cantidad);
    $('#Detalle_de_IngredientesUnidad').val(prevData.Unidad);
    $('#Detalle_de_IngredientesNombre_del_Ingrediente').val(prevData.Nombre_del_Ingrediente);
    $('#Detalle_de_IngredientesNombre_de_presentacion').val(prevData.Nombre_de_presentacion);
    $('#Detalle_de_IngredientesNombre_de_Marca').val(prevData.Nombre_de_Marca);

    initiateUIControls();







}

function Detalle_de_IngredientesAddInsertRow() {
    if (Detalle_de_IngredientesinsertRowCurrentIndex < 1)
    {
        Detalle_de_IngredientesinsertRowCurrentIndex = 1;
    }
    return {
        Clave: null,
        IsInsertRow: true

        ,Cantidad: ""
        ,Unidad: ""
        ,Nombre_del_Ingrediente: ""
        ,Nombre_de_presentacion: ""
        ,Nombre_de_Marca: ""

    }
}

function Detalle_de_IngredientesfnClickAddRow() {
    Detalle_de_IngredientescountRowsChecked++;
    Detalle_de_IngredientesTable.fnAddData(Detalle_de_IngredientesAddInsertRow(), true);
    Detalle_de_IngredientesTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_de_IngredientesGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_de_IngredientesGrid tbody tr:nth-of-type(' + (Detalle_de_IngredientesinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_de_Ingredientes("Detalle_de_Ingredientes_", "_" + Detalle_de_IngredientesinsertRowCurrentIndex);
}

function Detalle_de_IngredientesClearGridData() {
    Detalle_de_IngredientesData = [];
    Detalle_de_IngredientesdeletedItem = [];
    Detalle_de_IngredientesDataMain = [];
    Detalle_de_IngredientesDataMainPages = [];
    Detalle_de_IngredientesnewItemCount = 0;
    Detalle_de_IngredientesmaxItemIndex = 0;
    $("#Detalle_de_IngredientesGrid").DataTable().clear();
    $("#Detalle_de_IngredientesGrid").DataTable().destroy();
}

//Used to Get Platillos Information
function GetDetalle_de_Ingredientes() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_de_IngredientesData.length; i++) {
        form_data.append('[' + i + '].Clave', Detalle_de_IngredientesData[i].Clave);

        form_data.append('[' + i + '].Cantidad', Detalle_de_IngredientesData[i].Cantidad);
        form_data.append('[' + i + '].Unidad', Detalle_de_IngredientesData[i].Unidad);
        form_data.append('[' + i + '].Nombre_del_Ingrediente', Detalle_de_IngredientesData[i].Nombre_del_Ingrediente);
        form_data.append('[' + i + '].Nombre_de_presentacion', Detalle_de_IngredientesData[i].Nombre_de_presentacion);
        form_data.append('[' + i + '].Nombre_de_Marca', Detalle_de_IngredientesData[i].Nombre_de_Marca);

        form_data.append('[' + i + '].Removed', Detalle_de_IngredientesData[i].Removed);
    }
    return form_data;
}
function Detalle_de_IngredientesInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_de_Ingredientes("Detalle_de_IngredientesTable", rowIndex)) {
    var prevData = Detalle_de_IngredientesTable.fnGetData(rowIndex);
    var data = Detalle_de_IngredientesTable.fnGetNodes(rowIndex);
    var newData = {
        Clave: prevData.Clave,
        IsInsertRow: false

        ,Cantidad: $('#Detalle_de_IngredientesCantidad').val()
        ,Unidad: $('#Detalle_de_IngredientesUnidad').val()
        ,Nombre_del_Ingrediente: $('#Detalle_de_IngredientesNombre_del_Ingrediente').val()
        ,Nombre_de_presentacion: $('#Detalle_de_IngredientesNombre_de_presentacion').val()
        ,Nombre_de_Marca: $('#Detalle_de_IngredientesNombre_de_Marca').val()

    }

    Detalle_de_IngredientesTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_de_IngredientesrowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_de_Ingredientes-form').modal({ show: false });
    $('#AddDetalle_de_Ingredientes-form').modal('hide');
    Detalle_de_IngredientesEditRow(rowIndex);
    Detalle_de_IngredientesInsertRow(rowIndex);
    //}
}
function Detalle_de_IngredientesRemoveAddRow(rowIndex) {
    Detalle_de_IngredientesTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_de_Ingredientes MultiRow
//Begin Declarations for Foreigns fields for Detalle_Platillos MultiRow
var Detalle_PlatilloscountRowsChecked = 0;



function GetDetalle_Platillos_Cantidad_fraccion_platillosName(Id) {
    for (var i = 0; i < Detalle_Platillos_Cantidad_fraccion_platillosItems.length; i++) {
        if (Detalle_Platillos_Cantidad_fraccion_platillosItems[i].Folio == Id) {
            return Detalle_Platillos_Cantidad_fraccion_platillosItems[i].Cantidad;
        }
    }
    return "";
}

function GetDetalle_Platillos_Cantidad_fraccion_platillosDropDown() {
    var Detalle_Platillos_Cantidad_fraccion_platillosDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Platillos_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Platillos_Cantidad_fraccion_platillosDropdown);

    for (var i = 0; i < Detalle_Platillos_Cantidad_fraccion_platillosItems.length; i++) {
        $('<option />', { value: Detalle_Platillos_Cantidad_fraccion_platillosItems[i].Folio, text: Detalle_Platillos_Cantidad_fraccion_platillosItems[i].Cantidad }).appendTo(Detalle_Platillos_Cantidad_fraccion_platillosDropdown);
    }
    return Detalle_Platillos_Cantidad_fraccion_platillosDropdown;
}

function GetDetalle_Platillos_IngredientesName(Id) {
    for (var i = 0; i < Detalle_Platillos_IngredientesItems.length; i++) {
        if (Detalle_Platillos_IngredientesItems[i].Clave == Id) {
            return Detalle_Platillos_IngredientesItems[i].Nombre_Ingrediente;
        }
    }
    return "";
}

function GetDetalle_Platillos_IngredientesDropDown() {
    var Detalle_Platillos_IngredientesDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Platillos_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Platillos_IngredientesDropdown);
    if(Detalle_Platillos_IngredientesItems != null)
    {
       for (var i = 0; i < Detalle_Platillos_IngredientesItems.length; i++) {
           $('<option />', { value: Detalle_Platillos_IngredientesItems[i].Clave, text:    Detalle_Platillos_IngredientesItems[i].Nombre_Ingrediente }).appendTo(Detalle_Platillos_IngredientesDropdown);
       }
    }
    return Detalle_Platillos_IngredientesDropdown;
}








function GetInsertDetalle_PlatillosRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $($.parseHTML(GetGridCheckBox())).addClass('Detalle_Platillos_Lleva_fracciones Lleva_fracciones').attr('id', 'Detalle_Platillos_Lleva_fracciones_' + index).attr('data-field', 'Lleva_fracciones');
    columnData[1] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Platillos_Cantidad Cantidad').attr('id', 'Detalle_Platillos_Cantidad_' + index).attr('data-field', 'Cantidad');
    columnData[2] = $($.parseHTML(GetGridAutoComplete(null,'AutoCompleteDetalle_Platillos_Cantidad_fraccion'))).addClass('Detalle_Platillos_Cantidad_fraccion Cantidad_fraccion').attr('id', 'Detalle_Platillos_Cantidad_fraccion_' + index).attr('data-field', 'Cantidad_fraccion').after($.parseHTML(addNew('Detalle_Platillos', 'Cantidad_fraccion_platillos', 'Cantidad_fraccion', 259630)));
    columnData[3] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Platillos_Unidad Unidad').attr('id', 'Detalle_Platillos_Unidad_' + index).attr('data-field', 'Unidad');
    columnData[4] = $(GetDetalle_Platillos_IngredientesDropDown()).addClass('Detalle_Platillos_Ingrediente Ingrediente').attr('id', 'Detalle_Platillos_Ingrediente_' + index).attr('data-field', 'Ingrediente').after($.parseHTML(addNew('Detalle_Platillos', 'Ingredientes', 'Ingrediente', 259632)));
    columnData[5] = $($.parseHTML(inputData)).addClass('Detalle_Platillos_Caracteristica Caracteristica').attr('id', 'Detalle_Platillos_Caracteristica_' + index).attr('data-field', 'Caracteristica');
    columnData[6] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Platillos_Unidad_SMAE Unidad_SMAE').attr('id', 'Detalle_Platillos_Unidad_SMAE_' + index).attr('data-field', 'Unidad_SMAE');
    columnData[7] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Platillos_Equivalente_Unidad_SMAE Equivalente_Unidad_SMAE').attr('id', 'Detalle_Platillos_Equivalente_Unidad_SMAE_' + index).attr('data-field', 'Equivalente_Unidad_SMAE');
    columnData[8] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Platillos_Porciones Porciones').attr('id', 'Detalle_Platillos_Porciones_' + index).attr('data-field', 'Porciones');
    columnData[9] = $($.parseHTML(inputData)).addClass('Detalle_Platillos_Detalle Detalle').attr('id', 'Detalle_Platillos_Detalle_' + index).attr('data-field', 'Detalle');
    columnData[10] = $($.parseHTML(inputData)).addClass('Detalle_Platillos_Detalle_Super Detalle_Super').attr('id', 'Detalle_Platillos_Detalle_Super_' + index).attr('data-field', 'Detalle_Super');


    initiateUIControls();
    return columnData;
}

function Detalle_PlatillosInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Platillos("Detalle_Platillos_", "_" + rowIndex)) {
    var iPage = Detalle_PlatillosTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Platillos';
    var prevData = Detalle_PlatillosTable.fnGetData(rowIndex);
    var data = Detalle_PlatillosTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Lleva_fracciones: $(data.childNodes[counter++].childNodes[2]).is(':checked')
        ,Cantidad: data.childNodes[counter++].childNodes[0].value
        , Cantidad_fraccionCantidad:  $(data.childNodes[counter].childNodes[0]).find('option:selected').text() 
        , Cantidad_fraccion:  data.childNodes[counter++].childNodes[0].value 	
        ,Unidad: data.childNodes[counter++].childNodes[0].value
        ,Ingrediente:  data.childNodes[counter++].childNodes[0].value
        ,Caracteristica:  data.childNodes[counter++].childNodes[0].value
        ,Unidad_SMAE: data.childNodes[counter++].childNodes[0].value
        ,Equivalente_Unidad_SMAE: data.childNodes[counter++].childNodes[0].value
        ,Porciones: data.childNodes[counter++].childNodes[0].value
        ,Detalle:  data.childNodes[counter++].childNodes[0].value
        ,Detalle_Super:  data.childNodes[counter++].childNodes[0].value

    }
    Detalle_PlatillosTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_PlatillosrowCreationGrid(data, newData, rowIndex);
    Detalle_PlatillosTable.fnPageChange(iPage);
    Detalle_PlatilloscountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Platillos("Detalle_Platillos_", "_" + rowIndex);
  }
}

function Detalle_PlatillosCancelRow(rowIndex) {
    var prevData = Detalle_PlatillosTable.fnGetData(rowIndex);
    var data = Detalle_PlatillosTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_PlatillosTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_PlatillosrowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_PlatillosGrid(Detalle_PlatillosTable.fnGetData());
    Detalle_PlatilloscountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_PlatillosFromDataTable() {
    var Detalle_PlatillosData = [];
    var gridData = Detalle_PlatillosTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_PlatillosData.push({
                Folio: gridData[i].Folio

                ,Lleva_fracciones: gridData[i].Lleva_fracciones
                ,Cantidad: gridData[i].Cantidad
                ,Cantidad_fraccion: gridData[i].Cantidad_fraccion
                ,Unidad: gridData[i].Unidad
                ,Ingrediente: gridData[i].Ingrediente
                ,Caracteristica: gridData[i].Caracteristica
                ,Unidad_SMAE: gridData[i].Unidad_SMAE
                ,Equivalente_Unidad_SMAE: gridData[i].Equivalente_Unidad_SMAE
                ,Porciones: gridData[i].Porciones
                ,Detalle: gridData[i].Detalle
                ,Detalle_Super: gridData[i].Detalle_Super

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_PlatillosData.length; i++) {
        if (removedDetalle_PlatillosData[i] != null && removedDetalle_PlatillosData[i].Folio > 0)
            Detalle_PlatillosData.push({
                Folio: removedDetalle_PlatillosData[i].Folio

                ,Lleva_fracciones: removedDetalle_PlatillosData[i].Lleva_fracciones
                ,Cantidad: removedDetalle_PlatillosData[i].Cantidad
                ,Cantidad_fraccion: removedDetalle_PlatillosData[i].Cantidad_fraccion
                ,Unidad: removedDetalle_PlatillosData[i].Unidad
                ,Ingrediente: removedDetalle_PlatillosData[i].Ingrediente
                ,Caracteristica: removedDetalle_PlatillosData[i].Caracteristica
                ,Unidad_SMAE: removedDetalle_PlatillosData[i].Unidad_SMAE
                ,Equivalente_Unidad_SMAE: removedDetalle_PlatillosData[i].Equivalente_Unidad_SMAE
                ,Porciones: removedDetalle_PlatillosData[i].Porciones
                ,Detalle: removedDetalle_PlatillosData[i].Detalle
                ,Detalle_Super: removedDetalle_PlatillosData[i].Detalle_Super

                , Removed: true
            });
    }	

    return Detalle_PlatillosData;
}

function Detalle_PlatillosEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_PlatillosTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_PlatilloscountRowsChecked++;
    var Detalle_PlatillosRowElement = "Detalle_Platillos_" + rowIndex.toString();
    var prevData = Detalle_PlatillosTable.fnGetData(rowIndexTable );
    var row = Detalle_PlatillosTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Platillos_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_PlatillosGetUpdateRowControls(prevData, "Detalle_Platillos_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_PlatillosRowElement + "')){ Detalle_PlatillosInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_PlatillosCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_PlatillosGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_PlatillosGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_PlatillosValidation();
    initiateUIControls();
    $('.Detalle_Platillos' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Platillos(nameOfTable, rowIndexFormed);
    }
}

function Detalle_PlatillosfnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_PlatillosTable.fnGetData().length;
    Detalle_PlatillosfnClickAddRow();
    GetAddDetalle_PlatillosPopup(currentRowIndex, 0);
}

function Detalle_PlatillosEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_PlatillosTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_PlatillosRowElement = "Detalle_Platillos_" + rowIndex.toString();
    var prevData = Detalle_PlatillosTable.fnGetData(rowIndexTable);
    GetAddDetalle_PlatillosPopup(rowIndex, 1, prevData.Folio);

    $('#Detalle_PlatillosLleva_fracciones').prop('checked', prevData.Lleva_fracciones);
    $('#Detalle_PlatillosCantidad').val(prevData.Cantidad);
    $('#dvDetalle_PlatillosCantidad_fraccion').html($($.parseHTML(GetGridAutoComplete(prevData.Cantidad_fraccion.label,'AutoCompleteCantidad_fraccion'))).addClass('Detalle_Platillos_Cantidad_fraccion'));
    $('#Detalle_PlatillosUnidad').val(prevData.Unidad);
    $('#Detalle_PlatillosIngrediente').val(prevData.Ingrediente);
    $('#Detalle_PlatillosCaracteristica').val(prevData.Caracteristica);
    $('#Detalle_PlatillosUnidad_SMAE').val(prevData.Unidad_SMAE);
    $('#Detalle_PlatillosEquivalente_Unidad_SMAE').val(prevData.Equivalente_Unidad_SMAE);
    $('#Detalle_PlatillosPorciones').val(prevData.Porciones);
    $('#Detalle_PlatillosDetalle').val(prevData.Detalle);
    $('#Detalle_PlatillosDetalle_Super').val(prevData.Detalle_Super);

    initiateUIControls();













}

function Detalle_PlatillosAddInsertRow() {
    if (Detalle_PlatillosinsertRowCurrentIndex < 1)
    {
        Detalle_PlatillosinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Lleva_fracciones: ""
        ,Cantidad: ""
        ,Cantidad_fraccion: ""
        ,Unidad: ""
        ,Ingrediente: ""
        ,Caracteristica: ""
        ,Unidad_SMAE: ""
        ,Equivalente_Unidad_SMAE: ""
        ,Porciones: ""
        ,Detalle: ""
        ,Detalle_Super: ""

    }
}

function Detalle_PlatillosfnClickAddRow() {
    Detalle_PlatilloscountRowsChecked++;
    Detalle_PlatillosTable.fnAddData(Detalle_PlatillosAddInsertRow(), true);
    Detalle_PlatillosTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_PlatillosGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_PlatillosGrid tbody tr:nth-of-type(' + (Detalle_PlatillosinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Platillos("Detalle_Platillos_", "_" + Detalle_PlatillosinsertRowCurrentIndex);
}

function Detalle_PlatillosClearGridData() {
    Detalle_PlatillosData = [];
    Detalle_PlatillosdeletedItem = [];
    Detalle_PlatillosDataMain = [];
    Detalle_PlatillosDataMainPages = [];
    Detalle_PlatillosnewItemCount = 0;
    Detalle_PlatillosmaxItemIndex = 0;
    $("#Detalle_PlatillosGrid").DataTable().clear();
    $("#Detalle_PlatillosGrid").DataTable().destroy();
}

//Used to Get Platillos Information
function GetDetalle_Platillos() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_PlatillosData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_PlatillosData[i].Folio);

        form_data.append('[' + i + '].Lleva_fracciones', Detalle_PlatillosData[i].Lleva_fracciones);
        form_data.append('[' + i + '].Cantidad', Detalle_PlatillosData[i].Cantidad);
        form_data.append('[' + i + '].Cantidad_fraccion', Detalle_PlatillosData[i].Cantidad_fraccion);
        form_data.append('[' + i + '].Unidad', Detalle_PlatillosData[i].Unidad);
        form_data.append('[' + i + '].Ingrediente', Detalle_PlatillosData[i].Ingrediente);
        form_data.append('[' + i + '].Caracteristica', Detalle_PlatillosData[i].Caracteristica);
        form_data.append('[' + i + '].Unidad_SMAE', Detalle_PlatillosData[i].Unidad_SMAE);
        form_data.append('[' + i + '].Equivalente_Unidad_SMAE', Detalle_PlatillosData[i].Equivalente_Unidad_SMAE);
        form_data.append('[' + i + '].Porciones', Detalle_PlatillosData[i].Porciones);
        form_data.append('[' + i + '].Detalle', Detalle_PlatillosData[i].Detalle);
        form_data.append('[' + i + '].Detalle_Super', Detalle_PlatillosData[i].Detalle_Super);

        form_data.append('[' + i + '].Removed', Detalle_PlatillosData[i].Removed);
    }
    return form_data;
}
function Detalle_PlatillosInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Platillos("Detalle_PlatillosTable", rowIndex)) {
    var prevData = Detalle_PlatillosTable.fnGetData(rowIndex);
    var data = Detalle_PlatillosTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Lleva_fracciones: $('#Detalle_PlatillosLleva_fracciones').is(':checked')
        ,Cantidad: $('#Detalle_PlatillosCantidad').val()

        ,Cantidad_fraccion: $('#Detalle_PlatillosCantidad_fraccion').val()
        ,Unidad: $('#Detalle_PlatillosUnidad').val()

        ,Ingrediente: $('#Detalle_PlatillosIngrediente').val()
        ,Caracteristica: $('#Detalle_PlatillosCaracteristica').val()
        ,Unidad_SMAE: $('#Detalle_PlatillosUnidad_SMAE').val()

        ,Equivalente_Unidad_SMAE: $('#Detalle_PlatillosEquivalente_Unidad_SMAE').val()

        ,Porciones: $('#Detalle_PlatillosPorciones').val()

        ,Detalle: $('#Detalle_PlatillosDetalle').val()
        ,Detalle_Super: $('#Detalle_PlatillosDetalle_Super').val()

    }

    Detalle_PlatillosTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_PlatillosrowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Platillos-form').modal({ show: false });
    $('#AddDetalle_Platillos-form').modal('hide');
    Detalle_PlatillosEditRow(rowIndex);
    Detalle_PlatillosInsertRow(rowIndex);
    //}
}
function Detalle_PlatillosRemoveAddRow(rowIndex) {
    Detalle_PlatillosTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Platillos MultiRow


$(function () {
    function Detalle_de_IngredientesinitializeMainArray(totalCount) {
        if (Detalle_de_IngredientesDataMain.length != totalCount && !Detalle_de_IngredientesDataMainInitialized) {
            Detalle_de_IngredientesDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_de_IngredientesDataMain[i] = null;
            }
        }
    }
    function Detalle_de_IngredientesremoveFromMainArray() {
        for (var j = 0; j < Detalle_de_IngredientesdeletedItem.length; j++) {
            for (var i = 0; i < Detalle_de_IngredientesDataMain.length; i++) {
                if (Detalle_de_IngredientesDataMain[i] != null && Detalle_de_IngredientesDataMain[i].Id == Detalle_de_IngredientesdeletedItem[j]) {
                    hDetalle_de_IngredientesDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_de_IngredientescopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_de_IngredientesDataMain.length; i++) {
            data[i] = Detalle_de_IngredientesDataMain[i];

        }
        return data;
    }
    function Detalle_de_IngredientesgetNewResult() {
        var newData = copyMainDetalle_de_IngredientesArray();

        for (var i = 0; i < Detalle_de_IngredientesData.length; i++) {
            if (Detalle_de_IngredientesData[i].Removed == null || Detalle_de_IngredientesData[i].Removed == false) {
                newData.splice(0, 0, Detalle_de_IngredientesData[i]);
            }
        }
        return newData;
    }
    function Detalle_de_IngredientespushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_de_IngredientesDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_de_IngredientesDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }
    function Detalle_PlatillosinitializeMainArray(totalCount) {
        if (Detalle_PlatillosDataMain.length != totalCount && !Detalle_PlatillosDataMainInitialized) {
            Detalle_PlatillosDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_PlatillosDataMain[i] = null;
            }
        }
    }
    function Detalle_PlatillosremoveFromMainArray() {
        for (var j = 0; j < Detalle_PlatillosdeletedItem.length; j++) {
            for (var i = 0; i < Detalle_PlatillosDataMain.length; i++) {
                if (Detalle_PlatillosDataMain[i] != null && Detalle_PlatillosDataMain[i].Id == Detalle_PlatillosdeletedItem[j]) {
                    hDetalle_PlatillosDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_PlatilloscopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_PlatillosDataMain.length; i++) {
            data[i] = Detalle_PlatillosDataMain[i];

        }
        return data;
    }
    function Detalle_PlatillosgetNewResult() {
        var newData = copyMainDetalle_PlatillosArray();

        for (var i = 0; i < Detalle_PlatillosData.length; i++) {
            if (Detalle_PlatillosData[i].Removed == null || Detalle_PlatillosData[i].Removed == false) {
                newData.splice(0, 0, Detalle_PlatillosData[i]);
            }
        }
        return newData;
    }
    function Detalle_PlatillospushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_PlatillosDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_PlatillosDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }

});

//Grid GetAutocomplete

//Grid GetAutocomplete
var AutoCompleteCantidad_fraccionData = [];
function GetAutoCompleteDetalle_Platillos_Cantidad_fraccion_Cantidad_fraccion_platillosData(data) {
	AutoCompleteCantidad_fraccionData = [];
    for (var i = 0; i < data.length; i++) {
        AutoCompleteCantidad_fraccionData.push({
            id: data[i].Folio,
            text: data[i].Cantidad
        });
    }
    return AutoCompleteCantidad_fraccionData;
}



function getDropdown(elementKey) {
    var labelSelect = $("#Platillos_cmbLabelSelect").val();
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
    $('#CreatePlatillos')[0].reset();
    ClearFormControls();
    $("#FolioId").val("0");
                Detalle_de_IngredientesClearGridData();
                Detalle_PlatillosClearGridData();

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreatePlatillos').trigger('reset');
    $('#CreatePlatillos').find(':input').each(function () {
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
    var $myForm = $('#CreatePlatillos');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    if (Detalle_de_IngredientescountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_de_Ingredientes();
        return false;
    }
    if (Detalle_PlatilloscountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Platillos();
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblFolio").text("0");
}
$(document).ready(function () {
    $("form#CreatePlatillos").submit(function (e) {
        e.preventDefault();
        return false;
    });
	$("form#CreatePlatillos").on('click', '#PlatillosCancelar', function () {
	  if (!isPartial) {
        PlatillosBackToGrid();
	  } else {
            window.close();
      }
    });
	$("form#CreatePlatillos").on('click', '#PlatillosGuardar', function () {
		$('#PlatillosGuardar').attr('disabled', true);
		$('#PlatillosGuardar').unbind()
        if (EjecutarValidacionesAntesDeGuardar() && CheckValidation()) {
				if (!SendPlatillosData(function () {
					EjecutarValidacionesDespuesDeGuardar();
					if (!isPartial)
						PlatillosBackToGrid();
					else {						
						if (!isMR)
							window.opener.RefreshCatalog('Platillos', nameAttribute);
						else {
							var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
							if(!control.hasClass('AutoComplete'))
							{
							if (control.attr("data-isfilter") == "true") {
									eval(GetReglaFilter(control,  $(window.opener.document.getElementById('ObjectId')).val()));								    
								}
								else 
								{
									eval('window.opener.Get' + nameMR + '_PlatillosItem()');
									var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
									control.html(eval('window.opener.Get' + nameMR + '_PlatillosDropDown().get(0)').innerHTML);  
								}								
							}
						}
						window.close();						
						}
				})) {
					$('#PlatillosGuardar').removeAttr('disabled');
					$('#PlatillosGuardar').bind()
				}
		}
		else {
			$('#PlatillosGuardar').removeAttr('disabled');
			$('#PlatillosGuardar').bind()
		}
    });
	$("form#CreatePlatillos").on('click', '#PlatillosGuardarYNuevo', function () {	
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation()) {
				SendPlatillosData(function () {
					ClearControls();
					ClearAttachmentsDiv();
					ResetClaveLabel();
	                getDetalle_de_IngredientesData();
                getDetalle_PlatillosData();

					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Platillos', nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_PlatillosItem()');                           
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
                            control.html(eval('window.opener.Get' + nameMR + '_PlatillosDropDown().get(0)').innerHTML);   
					    }	
					}						
					EjecutarValidacionesDespuesDeGuardar();				
			setIsNew();
			EjecutarValidacionesAlComienzo();
				});
			}
		}		
    });
    $("form#CreatePlatillos").on('click', '#PlatillosGuardarYCopia', function () {
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendPlatillosData(function (currentId) {
					$("#FolioId").val("0");
	                Detalle_de_IngredientesClearGridData();
                Detalle_PlatillosClearGridData();

					ResetClaveLabel();
					$("#ReferenceFolio").val(currentId);
	                getDetalle_de_IngredientesData();
                getDetalle_PlatillosData();

					EjecutarValidacionesDespuesDeGuardar();		
					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Platillos',nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_PlatillosItem()');                          
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);						
							control.html(eval('window.opener.Get' + nameMR + '_PlatillosDropDown().get(0)').innerHTML);                          
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



var PlatillosisdisplayBusinessPropery = false;
PlatillosDisplayBusinessRuleButtons(PlatillosisdisplayBusinessPropery);
function PlatillosDisplayBusinessRule() {
    if (!PlatillosisdisplayBusinessPropery) {
        $('#CreatePlatillos').find('.col-sm-8').each(function () {
			var div =$(this); 
			if ($(this).find('.input-group').length >0)
				div  =  $(this).find('.input-group').first().hasClass('date')? $(this): $(this).find('.input-group').first();	
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = div.data('field-id');
            var fieldName = div.data('field-name');
            var attribute = div.data('attribute');
            mainElementAttributes += '<div class="PlatillosdisplayBusinessPropery"><button onclick="PlatillosGetBusinessRule()" type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#PlatillosBusinessRule-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.PlatillosdisplayBusinessPropery').remove();
    }
    PlatillosDisplayBusinessRuleButtons(!PlatillosisdisplayBusinessPropery);
    PlatillosisdisplayBusinessPropery = (PlatillosisdisplayBusinessPropery ? false : true);
}
function PlatillosDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}

