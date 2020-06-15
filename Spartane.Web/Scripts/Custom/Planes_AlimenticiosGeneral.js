

//Begin Declarations for Foreigns fields for Detalle_Planes_Alimenticios MultiRow
var Detalle_Planes_AlimenticioscountRowsChecked = 0;

function GetDetalle_Planes_Alimenticios_Tiempos_de_ComidaName(Id) {
    for (var i = 0; i < Detalle_Planes_Alimenticios_Tiempos_de_ComidaItems.length; i++) {
        if (Detalle_Planes_Alimenticios_Tiempos_de_ComidaItems[i].Clave == Id) {
            return Detalle_Planes_Alimenticios_Tiempos_de_ComidaItems[i].Comida;
        }
    }
    return "";
}

function GetDetalle_Planes_Alimenticios_Tiempos_de_ComidaDropDown() {
    var Detalle_Planes_Alimenticios_Tiempos_de_ComidaDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Planes_Alimenticios_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Planes_Alimenticios_Tiempos_de_ComidaDropdown);
    if(Detalle_Planes_Alimenticios_Tiempos_de_ComidaItems != null)
    {
       for (var i = 0; i < Detalle_Planes_Alimenticios_Tiempos_de_ComidaItems.length; i++) {
           $('<option />', { value: Detalle_Planes_Alimenticios_Tiempos_de_ComidaItems[i].Clave, text:    Detalle_Planes_Alimenticios_Tiempos_de_ComidaItems[i].Comida }).appendTo(Detalle_Planes_Alimenticios_Tiempos_de_ComidaDropdown);
       }
    }
    return Detalle_Planes_Alimenticios_Tiempos_de_ComidaDropdown;
}
function GetDetalle_Planes_Alimenticios_Dias_de_la_semanaName(Id) {
    for (var i = 0; i < Detalle_Planes_Alimenticios_Dias_de_la_semanaItems.length; i++) {
        if (Detalle_Planes_Alimenticios_Dias_de_la_semanaItems[i].Clave == Id) {
            return Detalle_Planes_Alimenticios_Dias_de_la_semanaItems[i].Dia;
        }
    }
    return "";
}

function GetDetalle_Planes_Alimenticios_Dias_de_la_semanaDropDown() {
    var Detalle_Planes_Alimenticios_Dias_de_la_semanaDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Planes_Alimenticios_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Planes_Alimenticios_Dias_de_la_semanaDropdown);
    if(Detalle_Planes_Alimenticios_Dias_de_la_semanaItems != null)
    {
       for (var i = 0; i < Detalle_Planes_Alimenticios_Dias_de_la_semanaItems.length; i++) {
           $('<option />', { value: Detalle_Planes_Alimenticios_Dias_de_la_semanaItems[i].Clave, text:    Detalle_Planes_Alimenticios_Dias_de_la_semanaItems[i].Dia }).appendTo(Detalle_Planes_Alimenticios_Dias_de_la_semanaDropdown);
       }
    }
    return Detalle_Planes_Alimenticios_Dias_de_la_semanaDropdown;
}

function GetDetalle_Planes_Alimenticios_PlatillosName(Id) {
    for (var i = 0; i < Detalle_Planes_Alimenticios_PlatillosItems.length; i++) {
        if (Detalle_Planes_Alimenticios_PlatillosItems[i].Folio == Id) {
            return Detalle_Planes_Alimenticios_PlatillosItems[i].Nombre_de_Platillo;
        }
    }
    return "";
}

function GetDetalle_Planes_Alimenticios_PlatillosDropDown() {
    var Detalle_Planes_Alimenticios_PlatillosDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Planes_Alimenticios_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Planes_Alimenticios_PlatillosDropdown);
    if(Detalle_Planes_Alimenticios_PlatillosItems != null)
    {
       for (var i = 0; i < Detalle_Planes_Alimenticios_PlatillosItems.length; i++) {
           $('<option />', { value: Detalle_Planes_Alimenticios_PlatillosItems[i].Folio, text:    Detalle_Planes_Alimenticios_PlatillosItems[i].Nombre_de_Platillo }).appendTo(Detalle_Planes_Alimenticios_PlatillosDropdown);
       }
    }
    return Detalle_Planes_Alimenticios_PlatillosDropdown;
}



function GetInsertDetalle_Planes_AlimenticiosRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $(GetDetalle_Planes_Alimenticios_Tiempos_de_ComidaDropDown()).addClass('Detalle_Planes_Alimenticios_Tiempo_de_Comida Tiempo_de_Comida').attr('id', 'Detalle_Planes_Alimenticios_Tiempo_de_Comida_' + index).attr('data-field', 'Tiempo_de_Comida').after($.parseHTML(addNew('Detalle_Planes_Alimenticios', 'Tiempos_de_Comida', 'Tiempo_de_Comida', 259772)));
    columnData[1] = $(GetDetalle_Planes_Alimenticios_Dias_de_la_semanaDropDown()).addClass('Detalle_Planes_Alimenticios_Numero_de_Dia Numero_de_Dia').attr('id', 'Detalle_Planes_Alimenticios_Numero_de_Dia_' + index).attr('data-field', 'Numero_de_Dia').after($.parseHTML(addNew('Detalle_Planes_Alimenticios', 'Dias_de_la_semana', 'Numero_de_Dia', 259773)));
    columnData[2] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Planes_Alimenticios_Fecha Fecha').attr('id', 'Detalle_Planes_Alimenticios_Fecha_' + index).attr('data-field', 'Fecha');
    columnData[3] = $(GetDetalle_Planes_Alimenticios_PlatillosDropDown()).addClass('Detalle_Planes_Alimenticios_Platillo Platillo').attr('id', 'Detalle_Planes_Alimenticios_Platillo_' + index).attr('data-field', 'Platillo').after($.parseHTML(addNew('Detalle_Planes_Alimenticios', 'Platillos', 'Platillo', 259775)));
    columnData[4] = $($.parseHTML(GetGridCheckBox())).addClass('Detalle_Planes_Alimenticios_Modificado Modificado').attr('id', 'Detalle_Planes_Alimenticios_Modificado_' + index).attr('data-field', 'Modificado');


    initiateUIControls();
    return columnData;
}

function Detalle_Planes_AlimenticiosInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Planes_Alimenticios("Detalle_Planes_Alimenticios_", "_" + rowIndex)) {
    var iPage = Detalle_Planes_AlimenticiosTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Planes_Alimenticios';
    var prevData = Detalle_Planes_AlimenticiosTable.fnGetData(rowIndex);
    var data = Detalle_Planes_AlimenticiosTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Tiempo_de_Comida:  data.childNodes[counter++].childNodes[0].value
        ,Numero_de_Dia:  data.childNodes[counter++].childNodes[0].value
        ,Fecha:  data.childNodes[counter++].childNodes[0].value
        ,Platillo:  data.childNodes[counter++].childNodes[0].value
        ,Modificado: $(data.childNodes[counter++].childNodes[2]).is(':checked')

    }
    Detalle_Planes_AlimenticiosTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Planes_AlimenticiosrowCreationGrid(data, newData, rowIndex);
    Detalle_Planes_AlimenticiosTable.fnPageChange(iPage);
    Detalle_Planes_AlimenticioscountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Planes_Alimenticios("Detalle_Planes_Alimenticios_", "_" + rowIndex);
  }
}

function Detalle_Planes_AlimenticiosCancelRow(rowIndex) {
    var prevData = Detalle_Planes_AlimenticiosTable.fnGetData(rowIndex);
    var data = Detalle_Planes_AlimenticiosTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Planes_AlimenticiosTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Planes_AlimenticiosrowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Planes_AlimenticiosGrid(Detalle_Planes_AlimenticiosTable.fnGetData());
    Detalle_Planes_AlimenticioscountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Planes_AlimenticiosFromDataTable() {
    var Detalle_Planes_AlimenticiosData = [];
    var gridData = Detalle_Planes_AlimenticiosTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Planes_AlimenticiosData.push({
                Folio: gridData[i].Folio

                ,Tiempo_de_Comida: gridData[i].Tiempo_de_Comida
                ,Numero_de_Dia: gridData[i].Numero_de_Dia
                ,Fecha: gridData[i].Fecha
                ,Platillo: gridData[i].Platillo
                ,Modificado: gridData[i].Modificado

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Planes_AlimenticiosData.length; i++) {
        if (removedDetalle_Planes_AlimenticiosData[i] != null && removedDetalle_Planes_AlimenticiosData[i].Folio > 0)
            Detalle_Planes_AlimenticiosData.push({
                Folio: removedDetalle_Planes_AlimenticiosData[i].Folio

                ,Tiempo_de_Comida: removedDetalle_Planes_AlimenticiosData[i].Tiempo_de_Comida
                ,Numero_de_Dia: removedDetalle_Planes_AlimenticiosData[i].Numero_de_Dia
                ,Fecha: removedDetalle_Planes_AlimenticiosData[i].Fecha
                ,Platillo: removedDetalle_Planes_AlimenticiosData[i].Platillo
                ,Modificado: removedDetalle_Planes_AlimenticiosData[i].Modificado

                , Removed: true
            });
    }	

    return Detalle_Planes_AlimenticiosData;
}

function Detalle_Planes_AlimenticiosEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Planes_AlimenticiosTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Planes_AlimenticioscountRowsChecked++;
    var Detalle_Planes_AlimenticiosRowElement = "Detalle_Planes_Alimenticios_" + rowIndex.toString();
    var prevData = Detalle_Planes_AlimenticiosTable.fnGetData(rowIndexTable );
    var row = Detalle_Planes_AlimenticiosTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Planes_Alimenticios_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Planes_AlimenticiosGetUpdateRowControls(prevData, "Detalle_Planes_Alimenticios_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Planes_AlimenticiosRowElement + "')){ Detalle_Planes_AlimenticiosInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_Planes_AlimenticiosCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Planes_AlimenticiosGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Planes_AlimenticiosGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_Planes_AlimenticiosValidation();
    initiateUIControls();
    $('.Detalle_Planes_Alimenticios' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Planes_Alimenticios(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Planes_AlimenticiosfnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Planes_AlimenticiosTable.fnGetData().length;
    Detalle_Planes_AlimenticiosfnClickAddRow();
    GetAddDetalle_Planes_AlimenticiosPopup(currentRowIndex, 0);
}

function Detalle_Planes_AlimenticiosEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Planes_AlimenticiosTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Planes_AlimenticiosRowElement = "Detalle_Planes_Alimenticios_" + rowIndex.toString();
    var prevData = Detalle_Planes_AlimenticiosTable.fnGetData(rowIndexTable);
    GetAddDetalle_Planes_AlimenticiosPopup(rowIndex, 1, prevData.Folio);

    $('#Detalle_Planes_AlimenticiosTiempo_de_Comida').val(prevData.Tiempo_de_Comida);
    $('#Detalle_Planes_AlimenticiosNumero_de_Dia').val(prevData.Numero_de_Dia);
    $('#Detalle_Planes_AlimenticiosFecha').val(prevData.Fecha);
    $('#Detalle_Planes_AlimenticiosPlatillo').val(prevData.Platillo);
    $('#Detalle_Planes_AlimenticiosModificado').prop('checked', prevData.Modificado);

    initiateUIControls();







}

function Detalle_Planes_AlimenticiosAddInsertRow() {
    if (Detalle_Planes_AlimenticiosinsertRowCurrentIndex < 1)
    {
        Detalle_Planes_AlimenticiosinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Tiempo_de_Comida: ""
        ,Numero_de_Dia: ""
        ,Fecha: ""
        ,Platillo: ""
        ,Modificado: ""

    }
}

function Detalle_Planes_AlimenticiosfnClickAddRow() {
    Detalle_Planes_AlimenticioscountRowsChecked++;
    Detalle_Planes_AlimenticiosTable.fnAddData(Detalle_Planes_AlimenticiosAddInsertRow(), true);
    Detalle_Planes_AlimenticiosTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_Planes_AlimenticiosGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_Planes_AlimenticiosGrid tbody tr:nth-of-type(' + (Detalle_Planes_AlimenticiosinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Planes_Alimenticios("Detalle_Planes_Alimenticios_", "_" + Detalle_Planes_AlimenticiosinsertRowCurrentIndex);
}

function Detalle_Planes_AlimenticiosClearGridData() {
    Detalle_Planes_AlimenticiosData = [];
    Detalle_Planes_AlimenticiosdeletedItem = [];
    Detalle_Planes_AlimenticiosDataMain = [];
    Detalle_Planes_AlimenticiosDataMainPages = [];
    Detalle_Planes_AlimenticiosnewItemCount = 0;
    Detalle_Planes_AlimenticiosmaxItemIndex = 0;
    $("#Detalle_Planes_AlimenticiosGrid").DataTable().clear();
    $("#Detalle_Planes_AlimenticiosGrid").DataTable().destroy();
}

//Used to Get Planes Alimenticios Information
function GetDetalle_Planes_Alimenticios() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Planes_AlimenticiosData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Planes_AlimenticiosData[i].Folio);

        form_data.append('[' + i + '].Tiempo_de_Comida', Detalle_Planes_AlimenticiosData[i].Tiempo_de_Comida);
        form_data.append('[' + i + '].Numero_de_Dia', Detalle_Planes_AlimenticiosData[i].Numero_de_Dia);
        form_data.append('[' + i + '].Fecha', Detalle_Planes_AlimenticiosData[i].Fecha);
        form_data.append('[' + i + '].Platillo', Detalle_Planes_AlimenticiosData[i].Platillo);
        form_data.append('[' + i + '].Modificado', Detalle_Planes_AlimenticiosData[i].Modificado);

        form_data.append('[' + i + '].Removed', Detalle_Planes_AlimenticiosData[i].Removed);
    }
    return form_data;
}
function Detalle_Planes_AlimenticiosInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Planes_Alimenticios("Detalle_Planes_AlimenticiosTable", rowIndex)) {
    var prevData = Detalle_Planes_AlimenticiosTable.fnGetData(rowIndex);
    var data = Detalle_Planes_AlimenticiosTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Tiempo_de_Comida: $('#Detalle_Planes_AlimenticiosTiempo_de_Comida').val()
        ,Numero_de_Dia: $('#Detalle_Planes_AlimenticiosNumero_de_Dia').val()
        ,Fecha: $('#Detalle_Planes_AlimenticiosFecha').val()
        ,Platillo: $('#Detalle_Planes_AlimenticiosPlatillo').val()
        ,Modificado: $('#Detalle_Planes_AlimenticiosModificado').is(':checked')

    }

    Detalle_Planes_AlimenticiosTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Planes_AlimenticiosrowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Planes_Alimenticios-form').modal({ show: false });
    $('#AddDetalle_Planes_Alimenticios-form').modal('hide');
    Detalle_Planes_AlimenticiosEditRow(rowIndex);
    Detalle_Planes_AlimenticiosInsertRow(rowIndex);
    //}
}
function Detalle_Planes_AlimenticiosRemoveAddRow(rowIndex) {
    Detalle_Planes_AlimenticiosTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Planes_Alimenticios MultiRow


$(function () {
    function Detalle_Planes_AlimenticiosinitializeMainArray(totalCount) {
        if (Detalle_Planes_AlimenticiosDataMain.length != totalCount && !Detalle_Planes_AlimenticiosDataMainInitialized) {
            Detalle_Planes_AlimenticiosDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Planes_AlimenticiosDataMain[i] = null;
            }
        }
    }
    function Detalle_Planes_AlimenticiosremoveFromMainArray() {
        for (var j = 0; j < Detalle_Planes_AlimenticiosdeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Planes_AlimenticiosDataMain.length; i++) {
                if (Detalle_Planes_AlimenticiosDataMain[i] != null && Detalle_Planes_AlimenticiosDataMain[i].Id == Detalle_Planes_AlimenticiosdeletedItem[j]) {
                    hDetalle_Planes_AlimenticiosDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Planes_AlimenticioscopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Planes_AlimenticiosDataMain.length; i++) {
            data[i] = Detalle_Planes_AlimenticiosDataMain[i];

        }
        return data;
    }
    function Detalle_Planes_AlimenticiosgetNewResult() {
        var newData = copyMainDetalle_Planes_AlimenticiosArray();

        for (var i = 0; i < Detalle_Planes_AlimenticiosData.length; i++) {
            if (Detalle_Planes_AlimenticiosData[i].Removed == null || Detalle_Planes_AlimenticiosData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Planes_AlimenticiosData[i]);
            }
        }
        return newData;
    }
    function Detalle_Planes_AlimenticiospushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Planes_AlimenticiosDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Planes_AlimenticiosDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }

});

//Grid GetAutocomplete



function getDropdown(elementKey) {
    var labelSelect = $("#Planes_Alimenticios_cmbLabelSelect").val();
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
    $('#CreatePlanes_Alimenticios')[0].reset();
    ClearFormControls();
    $("#FolioId").val("0");
                Detalle_Planes_AlimenticiosClearGridData();

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreatePlanes_Alimenticios').trigger('reset');
    $('#CreatePlanes_Alimenticios').find(':input').each(function () {
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
    var $myForm = $('#CreatePlanes_Alimenticios');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    if (Detalle_Planes_AlimenticioscountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Planes_Alimenticios();
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblFolio").text("0");
}
$(document).ready(function () {
    $("form#CreatePlanes_Alimenticios").submit(function (e) {
        e.preventDefault();
        return false;
    });
	$("form#CreatePlanes_Alimenticios").on('click', '#Planes_AlimenticiosCancelar', function () {
	  if (!isPartial) {
        Planes_AlimenticiosBackToGrid();
	  } else {
            window.close();
      }
    });
	$("form#CreatePlanes_Alimenticios").on('click', '#Planes_AlimenticiosGuardar', function () {
		$('#Planes_AlimenticiosGuardar').attr('disabled', true);
		$('#Planes_AlimenticiosGuardar').unbind()
        if (EjecutarValidacionesAntesDeGuardar() && CheckValidation()) {
				if (!SendPlanes_AlimenticiosData(function () {
					EjecutarValidacionesDespuesDeGuardar();
					if (!isPartial)
						Planes_AlimenticiosBackToGrid();
					else {						
						if (!isMR)
							window.opener.RefreshCatalog('Planes_Alimenticios', nameAttribute);
						else {
							var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
							if(!control.hasClass('AutoComplete'))
							{
							if (control.attr("data-isfilter") == "true") {
									eval(GetReglaFilter(control,  $(window.opener.document.getElementById('ObjectId')).val()));								    
								}
								else 
								{
									eval('window.opener.Get' + nameMR + '_Planes_AlimenticiosItem()');
									var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
									control.html(eval('window.opener.Get' + nameMR + '_Planes_AlimenticiosDropDown().get(0)').innerHTML);  
								}								
							}
						}
						window.close();						
						}
				})) {
					$('#Planes_AlimenticiosGuardar').removeAttr('disabled');
					$('#Planes_AlimenticiosGuardar').bind()
				}
		}
		else {
			$('#Planes_AlimenticiosGuardar').removeAttr('disabled');
			$('#Planes_AlimenticiosGuardar').bind()
		}
    });
	$("form#CreatePlanes_Alimenticios").on('click', '#Planes_AlimenticiosGuardarYNuevo', function () {	
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation()) {
				SendPlanes_AlimenticiosData(function () {
					ClearControls();
					ClearAttachmentsDiv();
					ResetClaveLabel();
	                getDetalle_Planes_AlimenticiosData();

					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Planes_Alimenticios', nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_Planes_AlimenticiosItem()');                           
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
                            control.html(eval('window.opener.Get' + nameMR + '_Planes_AlimenticiosDropDown().get(0)').innerHTML);   
					    }	
					}						
					EjecutarValidacionesDespuesDeGuardar();				
			setIsNew();
			EjecutarValidacionesAlComienzo();
				});
			}
		}		
    });
    $("form#CreatePlanes_Alimenticios").on('click', '#Planes_AlimenticiosGuardarYCopia', function () {
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendPlanes_AlimenticiosData(function (currentId) {
					$("#FolioId").val("0");
	                Detalle_Planes_AlimenticiosClearGridData();

					ResetClaveLabel();
					$("#ReferenceFolio").val(currentId);
	                getDetalle_Planes_AlimenticiosData();

					EjecutarValidacionesDespuesDeGuardar();		
					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Planes_Alimenticios',nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_Planes_AlimenticiosItem()');                          
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);						
							control.html(eval('window.opener.Get' + nameMR + '_Planes_AlimenticiosDropDown().get(0)').innerHTML);                          
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



var Planes_AlimenticiosisdisplayBusinessPropery = false;
Planes_AlimenticiosDisplayBusinessRuleButtons(Planes_AlimenticiosisdisplayBusinessPropery);
function Planes_AlimenticiosDisplayBusinessRule() {
    if (!Planes_AlimenticiosisdisplayBusinessPropery) {
        $('#CreatePlanes_Alimenticios').find('.col-sm-8').each(function () {
			var div =$(this); 
			if ($(this).find('.input-group').length >0)
				div  =  $(this).find('.input-group').first().hasClass('date')? $(this): $(this).find('.input-group').first();	
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = div.data('field-id');
            var fieldName = div.data('field-name');
            var attribute = div.data('attribute');
            mainElementAttributes += '<div class="Planes_AlimenticiosdisplayBusinessPropery"><button onclick="Planes_AlimenticiosGetBusinessRule()" type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#Planes_AlimenticiosBusinessRule-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.Planes_AlimenticiosdisplayBusinessPropery').remove();
    }
    Planes_AlimenticiosDisplayBusinessRuleButtons(!Planes_AlimenticiosisdisplayBusinessPropery);
    Planes_AlimenticiosisdisplayBusinessPropery = (Planes_AlimenticiosisdisplayBusinessPropery ? false : true);
}
function Planes_AlimenticiosDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}

