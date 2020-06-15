

//Begin Declarations for Foreigns fields for Detalle_Ejercicios_Rutinas MultiRow
var Detalle_Ejercicios_RutinascountRowsChecked = 0;



function GetDetalle_Ejercicios_Rutinas_EjerciciosName(Id) {
    for (var i = 0; i < Detalle_Ejercicios_Rutinas_EjerciciosItems.length; i++) {
        if (Detalle_Ejercicios_Rutinas_EjerciciosItems[i].Clave == Id) {
            return Detalle_Ejercicios_Rutinas_EjerciciosItems[i].Nombre_del_Ejercicio;
        }
    }
    return "";
}

function GetDetalle_Ejercicios_Rutinas_EjerciciosDropDown() {
    var Detalle_Ejercicios_Rutinas_EjerciciosDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Ejercicios_Rutinas_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Ejercicios_Rutinas_EjerciciosDropdown);
    if(Detalle_Ejercicios_Rutinas_EjerciciosItems != null)
    {
       for (var i = 0; i < Detalle_Ejercicios_Rutinas_EjerciciosItems.length; i++) {
           $('<option />', { value: Detalle_Ejercicios_Rutinas_EjerciciosItems[i].Clave, text:    Detalle_Ejercicios_Rutinas_EjerciciosItems[i].Nombre_del_Ejercicio }).appendTo(Detalle_Ejercicios_Rutinas_EjerciciosDropdown);
       }
    }
    return Detalle_Ejercicios_Rutinas_EjerciciosDropdown;
}



function GetInsertDetalle_Ejercicios_RutinasRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Ejercicios_Rutinas_Orden_de_realizacion Orden_de_realizacion').attr('id', 'Detalle_Ejercicios_Rutinas_Orden_de_realizacion_' + index).attr('data-field', 'Orden_de_realizacion');
    columnData[1] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Ejercicios_Rutinas_Numero_de_serie Numero_de_serie').attr('id', 'Detalle_Ejercicios_Rutinas_Numero_de_serie_' + index).attr('data-field', 'Numero_de_serie');
    columnData[2] = $(GetDetalle_Ejercicios_Rutinas_EjerciciosDropDown()).addClass('Detalle_Ejercicios_Rutinas_Ejercicio Ejercicio').attr('id', 'Detalle_Ejercicios_Rutinas_Ejercicio_' + index).attr('data-field', 'Ejercicio').after($.parseHTML(addNew('Detalle_Ejercicios_Rutinas', 'Ejercicios', 'Ejercicio', 259817)));
    columnData[3] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Ejercicios_Rutinas_Cantidad_de_Repeticiones Cantidad_de_Repeticiones').attr('id', 'Detalle_Ejercicios_Rutinas_Cantidad_de_Repeticiones_' + index).attr('data-field', 'Cantidad_de_Repeticiones');


    initiateUIControls();
    return columnData;
}

function Detalle_Ejercicios_RutinasInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Ejercicios_Rutinas("Detalle_Ejercicios_Rutinas_", "_" + rowIndex)) {
    var iPage = Detalle_Ejercicios_RutinasTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Ejercicios_Rutinas';
    var prevData = Detalle_Ejercicios_RutinasTable.fnGetData(rowIndex);
    var data = Detalle_Ejercicios_RutinasTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Orden_de_realizacion: data.childNodes[counter++].childNodes[0].value
        ,Numero_de_serie: data.childNodes[counter++].childNodes[0].value
        ,Ejercicio:  data.childNodes[counter++].childNodes[0].value
        ,Cantidad_de_Repeticiones: data.childNodes[counter++].childNodes[0].value

    }
    Detalle_Ejercicios_RutinasTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Ejercicios_RutinasrowCreationGrid(data, newData, rowIndex);
    Detalle_Ejercicios_RutinasTable.fnPageChange(iPage);
    Detalle_Ejercicios_RutinascountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Ejercicios_Rutinas("Detalle_Ejercicios_Rutinas_", "_" + rowIndex);
  }
}

function Detalle_Ejercicios_RutinasCancelRow(rowIndex) {
    var prevData = Detalle_Ejercicios_RutinasTable.fnGetData(rowIndex);
    var data = Detalle_Ejercicios_RutinasTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Ejercicios_RutinasTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Ejercicios_RutinasrowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Ejercicios_RutinasGrid(Detalle_Ejercicios_RutinasTable.fnGetData());
    Detalle_Ejercicios_RutinascountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Ejercicios_RutinasFromDataTable() {
    var Detalle_Ejercicios_RutinasData = [];
    var gridData = Detalle_Ejercicios_RutinasTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Ejercicios_RutinasData.push({
                Folio: gridData[i].Folio

                ,Orden_de_realizacion: gridData[i].Orden_de_realizacion
                ,Numero_de_serie: gridData[i].Numero_de_serie
                ,Ejercicio: gridData[i].Ejercicio
                ,Cantidad_de_Repeticiones: gridData[i].Cantidad_de_Repeticiones

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Ejercicios_RutinasData.length; i++) {
        if (removedDetalle_Ejercicios_RutinasData[i] != null && removedDetalle_Ejercicios_RutinasData[i].Folio > 0)
            Detalle_Ejercicios_RutinasData.push({
                Folio: removedDetalle_Ejercicios_RutinasData[i].Folio

                ,Orden_de_realizacion: removedDetalle_Ejercicios_RutinasData[i].Orden_de_realizacion
                ,Numero_de_serie: removedDetalle_Ejercicios_RutinasData[i].Numero_de_serie
                ,Ejercicio: removedDetalle_Ejercicios_RutinasData[i].Ejercicio
                ,Cantidad_de_Repeticiones: removedDetalle_Ejercicios_RutinasData[i].Cantidad_de_Repeticiones

                , Removed: true
            });
    }	

    return Detalle_Ejercicios_RutinasData;
}

function Detalle_Ejercicios_RutinasEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Ejercicios_RutinasTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Ejercicios_RutinascountRowsChecked++;
    var Detalle_Ejercicios_RutinasRowElement = "Detalle_Ejercicios_Rutinas_" + rowIndex.toString();
    var prevData = Detalle_Ejercicios_RutinasTable.fnGetData(rowIndexTable );
    var row = Detalle_Ejercicios_RutinasTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Ejercicios_Rutinas_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Ejercicios_RutinasGetUpdateRowControls(prevData, "Detalle_Ejercicios_Rutinas_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Ejercicios_RutinasRowElement + "')){ Detalle_Ejercicios_RutinasInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_Ejercicios_RutinasCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Ejercicios_RutinasGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Ejercicios_RutinasGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_Ejercicios_RutinasValidation();
    initiateUIControls();
    $('.Detalle_Ejercicios_Rutinas' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Ejercicios_Rutinas(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Ejercicios_RutinasfnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Ejercicios_RutinasTable.fnGetData().length;
    Detalle_Ejercicios_RutinasfnClickAddRow();
    GetAddDetalle_Ejercicios_RutinasPopup(currentRowIndex, 0);
}

function Detalle_Ejercicios_RutinasEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Ejercicios_RutinasTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Ejercicios_RutinasRowElement = "Detalle_Ejercicios_Rutinas_" + rowIndex.toString();
    var prevData = Detalle_Ejercicios_RutinasTable.fnGetData(rowIndexTable);
    GetAddDetalle_Ejercicios_RutinasPopup(rowIndex, 1, prevData.Folio);

    $('#Detalle_Ejercicios_RutinasOrden_de_realizacion').val(prevData.Orden_de_realizacion);
    $('#Detalle_Ejercicios_RutinasNumero_de_serie').val(prevData.Numero_de_serie);
    $('#Detalle_Ejercicios_RutinasEjercicio').val(prevData.Ejercicio);
    $('#Detalle_Ejercicios_RutinasCantidad_de_Repeticiones').val(prevData.Cantidad_de_Repeticiones);

    initiateUIControls();






}

function Detalle_Ejercicios_RutinasAddInsertRow() {
    if (Detalle_Ejercicios_RutinasinsertRowCurrentIndex < 1)
    {
        Detalle_Ejercicios_RutinasinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Orden_de_realizacion: ""
        ,Numero_de_serie: ""
        ,Ejercicio: ""
        ,Cantidad_de_Repeticiones: ""

    }
}

function Detalle_Ejercicios_RutinasfnClickAddRow() {
    Detalle_Ejercicios_RutinascountRowsChecked++;
    Detalle_Ejercicios_RutinasTable.fnAddData(Detalle_Ejercicios_RutinasAddInsertRow(), true);
    Detalle_Ejercicios_RutinasTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_Ejercicios_RutinasGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_Ejercicios_RutinasGrid tbody tr:nth-of-type(' + (Detalle_Ejercicios_RutinasinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Ejercicios_Rutinas("Detalle_Ejercicios_Rutinas_", "_" + Detalle_Ejercicios_RutinasinsertRowCurrentIndex);
}

function Detalle_Ejercicios_RutinasClearGridData() {
    Detalle_Ejercicios_RutinasData = [];
    Detalle_Ejercicios_RutinasdeletedItem = [];
    Detalle_Ejercicios_RutinasDataMain = [];
    Detalle_Ejercicios_RutinasDataMainPages = [];
    Detalle_Ejercicios_RutinasnewItemCount = 0;
    Detalle_Ejercicios_RutinasmaxItemIndex = 0;
    $("#Detalle_Ejercicios_RutinasGrid").DataTable().clear();
    $("#Detalle_Ejercicios_RutinasGrid").DataTable().destroy();
}

//Used to Get Rutinas Information
function GetDetalle_Ejercicios_Rutinas() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Ejercicios_RutinasData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Ejercicios_RutinasData[i].Folio);

        form_data.append('[' + i + '].Orden_de_realizacion', Detalle_Ejercicios_RutinasData[i].Orden_de_realizacion);
        form_data.append('[' + i + '].Numero_de_serie', Detalle_Ejercicios_RutinasData[i].Numero_de_serie);
        form_data.append('[' + i + '].Ejercicio', Detalle_Ejercicios_RutinasData[i].Ejercicio);
        form_data.append('[' + i + '].Cantidad_de_Repeticiones', Detalle_Ejercicios_RutinasData[i].Cantidad_de_Repeticiones);

        form_data.append('[' + i + '].Removed', Detalle_Ejercicios_RutinasData[i].Removed);
    }
    return form_data;
}
function Detalle_Ejercicios_RutinasInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Ejercicios_Rutinas("Detalle_Ejercicios_RutinasTable", rowIndex)) {
    var prevData = Detalle_Ejercicios_RutinasTable.fnGetData(rowIndex);
    var data = Detalle_Ejercicios_RutinasTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Orden_de_realizacion: $('#Detalle_Ejercicios_RutinasOrden_de_realizacion').val()

        ,Numero_de_serie: $('#Detalle_Ejercicios_RutinasNumero_de_serie').val()

        ,Ejercicio: $('#Detalle_Ejercicios_RutinasEjercicio').val()
        ,Cantidad_de_Repeticiones: $('#Detalle_Ejercicios_RutinasCantidad_de_Repeticiones').val()


    }

    Detalle_Ejercicios_RutinasTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Ejercicios_RutinasrowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Ejercicios_Rutinas-form').modal({ show: false });
    $('#AddDetalle_Ejercicios_Rutinas-form').modal('hide');
    Detalle_Ejercicios_RutinasEditRow(rowIndex);
    Detalle_Ejercicios_RutinasInsertRow(rowIndex);
    //}
}
function Detalle_Ejercicios_RutinasRemoveAddRow(rowIndex) {
    Detalle_Ejercicios_RutinasTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Ejercicios_Rutinas MultiRow


$(function () {
    function Detalle_Ejercicios_RutinasinitializeMainArray(totalCount) {
        if (Detalle_Ejercicios_RutinasDataMain.length != totalCount && !Detalle_Ejercicios_RutinasDataMainInitialized) {
            Detalle_Ejercicios_RutinasDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Ejercicios_RutinasDataMain[i] = null;
            }
        }
    }
    function Detalle_Ejercicios_RutinasremoveFromMainArray() {
        for (var j = 0; j < Detalle_Ejercicios_RutinasdeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Ejercicios_RutinasDataMain.length; i++) {
                if (Detalle_Ejercicios_RutinasDataMain[i] != null && Detalle_Ejercicios_RutinasDataMain[i].Id == Detalle_Ejercicios_RutinasdeletedItem[j]) {
                    hDetalle_Ejercicios_RutinasDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Ejercicios_RutinascopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Ejercicios_RutinasDataMain.length; i++) {
            data[i] = Detalle_Ejercicios_RutinasDataMain[i];

        }
        return data;
    }
    function Detalle_Ejercicios_RutinasgetNewResult() {
        var newData = copyMainDetalle_Ejercicios_RutinasArray();

        for (var i = 0; i < Detalle_Ejercicios_RutinasData.length; i++) {
            if (Detalle_Ejercicios_RutinasData[i].Removed == null || Detalle_Ejercicios_RutinasData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Ejercicios_RutinasData[i]);
            }
        }
        return newData;
    }
    function Detalle_Ejercicios_RutinaspushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Ejercicios_RutinasDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Ejercicios_RutinasDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }

});

var AutoCompleteNivel_de_dificultadData = [];
function GetAutoCompleteRutinas_Nivel_de_dificultad_Nivel_de_dificultadData(data) {
	AutoCompleteNivel_de_dificultadData = [];
    for (var i = 0; i < data.length; i++) {
        AutoCompleteNivel_de_dificultadData.push({
            id: data[i].Folio,
            text: data[i].Dificultad
        });
    }
    return AutoCompleteNivel_de_dificultadData;
}
var AutoCompleteIntensidadData = [];
function GetAutoCompleteRutinas_Intensidad_Nivel_de_IntensidadData(data) {
	AutoCompleteIntensidadData = [];
    for (var i = 0; i < data.length; i++) {
        AutoCompleteIntensidadData.push({
            id: data[i].Folio,
            text: data[i].Intensidad
        });
    }
    return AutoCompleteIntensidadData;
}
//Grid GetAutocomplete



function getDropdown(elementKey) {
    var labelSelect = $("#Rutinas_cmbLabelSelect").val();
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
    $('#CreateRutinas')[0].reset();
    ClearFormControls();
    $("#FolioId").val("0");
    $('#Nivel_de_dificultad').empty();
    $("#Nivel_de_dificultad").append('<option value=""></option>');
    $('#Nivel_de_dificultad').val('0').trigger('change');
    $('#Intensidad').empty();
    $("#Intensidad").append('<option value=""></option>');
    $('#Intensidad').val('0').trigger('change');
                Detalle_Ejercicios_RutinasClearGridData();

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreateRutinas').trigger('reset');
    $('#CreateRutinas').find(':input').each(function () {
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
    var $myForm = $('#CreateRutinas');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    if (Detalle_Ejercicios_RutinascountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Ejercicios_Rutinas();
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblFolio").text("0");
}
$(document).ready(function () {
    $("form#CreateRutinas").submit(function (e) {
        e.preventDefault();
        return false;
    });
	$("form#CreateRutinas").on('click', '#RutinasCancelar', function () {
	  if (!isPartial) {
        RutinasBackToGrid();
	  } else {
            window.close();
      }
    });
	$("form#CreateRutinas").on('click', '#RutinasGuardar', function () {
		$('#RutinasGuardar').attr('disabled', true);
		$('#RutinasGuardar').unbind()
        if (EjecutarValidacionesAntesDeGuardar() && CheckValidation()) {
				if (!SendRutinasData(function () {
					EjecutarValidacionesDespuesDeGuardar();
					if (!isPartial)
						RutinasBackToGrid();
					else {						
						if (!isMR)
							window.opener.RefreshCatalog('Rutinas', nameAttribute);
						else {
							var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
							if(!control.hasClass('AutoComplete'))
							{
							if (control.attr("data-isfilter") == "true") {
									eval(GetReglaFilter(control,  $(window.opener.document.getElementById('ObjectId')).val()));								    
								}
								else 
								{
									eval('window.opener.Get' + nameMR + '_RutinasItem()');
									var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
									control.html(eval('window.opener.Get' + nameMR + '_RutinasDropDown().get(0)').innerHTML);  
								}								
							}
						}
						window.close();						
						}
				})) {
					$('#RutinasGuardar').removeAttr('disabled');
					$('#RutinasGuardar').bind()
				}
		}
		else {
			$('#RutinasGuardar').removeAttr('disabled');
			$('#RutinasGuardar').bind()
		}
    });
	$("form#CreateRutinas").on('click', '#RutinasGuardarYNuevo', function () {	
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation()) {
				SendRutinasData(function () {
					ClearControls();
					ClearAttachmentsDiv();
					ResetClaveLabel();
	                getDetalle_Ejercicios_RutinasData();

					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Rutinas', nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_RutinasItem()');                           
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
                            control.html(eval('window.opener.Get' + nameMR + '_RutinasDropDown().get(0)').innerHTML);   
					    }	
					}						
					EjecutarValidacionesDespuesDeGuardar();				
			setIsNew();
			EjecutarValidacionesAlComienzo();
				});
			}
		}		
    });
    $("form#CreateRutinas").on('click', '#RutinasGuardarYCopia', function () {
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendRutinasData(function (currentId) {
					$("#FolioId").val("0");
	    $('#Nivel_de_dificultad').empty();
    $("#Nivel_de_dificultad").append('<option value=""></option>');
    $('#Nivel_de_dificultad').val('0').trigger('change');
    $('#Intensidad').empty();
    $("#Intensidad").append('<option value=""></option>');
    $('#Intensidad').val('0').trigger('change');
                Detalle_Ejercicios_RutinasClearGridData();

					ResetClaveLabel();
					$("#ReferenceFolio").val(currentId);
	                getDetalle_Ejercicios_RutinasData();

					EjecutarValidacionesDespuesDeGuardar();		
					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Rutinas',nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_RutinasItem()');                          
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);						
							control.html(eval('window.opener.Get' + nameMR + '_RutinasDropDown().get(0)').innerHTML);                          
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



var RutinasisdisplayBusinessPropery = false;
RutinasDisplayBusinessRuleButtons(RutinasisdisplayBusinessPropery);
function RutinasDisplayBusinessRule() {
    if (!RutinasisdisplayBusinessPropery) {
        $('#CreateRutinas').find('.col-sm-8').each(function () {
			var div =$(this); 
			if ($(this).find('.input-group').length >0)
				div  =  $(this).find('.input-group').first().hasClass('date')? $(this): $(this).find('.input-group').first();	
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = div.data('field-id');
            var fieldName = div.data('field-name');
            var attribute = div.data('attribute');
            mainElementAttributes += '<div class="RutinasdisplayBusinessPropery"><button onclick="RutinasGetBusinessRule()" type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#RutinasBusinessRule-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.RutinasdisplayBusinessPropery').remove();
    }
    RutinasDisplayBusinessRuleButtons(!RutinasisdisplayBusinessPropery);
    RutinasisdisplayBusinessPropery = (RutinasisdisplayBusinessPropery ? false : true);
}
function RutinasDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}

