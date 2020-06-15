

//Begin Declarations for Foreigns fields for Detalle_Planes_de_Rutinas MultiRow
var Detalle_Planes_de_RutinascountRowsChecked = 0;

function GetDetalle_Planes_de_Rutinas_Dias_de_la_semanaName(Id) {
    for (var i = 0; i < Detalle_Planes_de_Rutinas_Dias_de_la_semanaItems.length; i++) {
        if (Detalle_Planes_de_Rutinas_Dias_de_la_semanaItems[i].Clave == Id) {
            return Detalle_Planes_de_Rutinas_Dias_de_la_semanaItems[i].Dia;
        }
    }
    return "";
}

function GetDetalle_Planes_de_Rutinas_Dias_de_la_semanaDropDown() {
    var Detalle_Planes_de_Rutinas_Dias_de_la_semanaDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Planes_de_Rutinas_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Planes_de_Rutinas_Dias_de_la_semanaDropdown);
    if(Detalle_Planes_de_Rutinas_Dias_de_la_semanaItems != null)
    {
       for (var i = 0; i < Detalle_Planes_de_Rutinas_Dias_de_la_semanaItems.length; i++) {
           $('<option />', { value: Detalle_Planes_de_Rutinas_Dias_de_la_semanaItems[i].Clave, text:    Detalle_Planes_de_Rutinas_Dias_de_la_semanaItems[i].Dia }).appendTo(Detalle_Planes_de_Rutinas_Dias_de_la_semanaDropdown);
       }
    }
    return Detalle_Planes_de_Rutinas_Dias_de_la_semanaDropdown;
}




function GetInsertDetalle_Planes_de_RutinasRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $(GetDetalle_Planes_de_Rutinas_Dias_de_la_semanaDropDown()).addClass('Detalle_Planes_de_Rutinas_Numero_de_Dia Numero_de_Dia').attr('id', 'Detalle_Planes_de_Rutinas_Numero_de_Dia_' + index).attr('data-field', 'Numero_de_Dia').after($.parseHTML(addNew('Detalle_Planes_de_Rutinas', 'Dias_de_la_semana', 'Numero_de_Dia', 259792)));
    columnData[1] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Planes_de_Rutinas_Fecha Fecha').attr('id', 'Detalle_Planes_de_Rutinas_Fecha_' + index).attr('data-field', 'Fecha');
    columnData[2] = $($.parseHTML(GetGridCheckBox())).addClass('Detalle_Planes_de_Rutinas_Realizado Realizado').attr('id', 'Detalle_Planes_de_Rutinas_Realizado_' + index).attr('data-field', 'Realizado');


    initiateUIControls();
    return columnData;
}

function Detalle_Planes_de_RutinasInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Planes_de_Rutinas("Detalle_Planes_de_Rutinas_", "_" + rowIndex)) {
    var iPage = Detalle_Planes_de_RutinasTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Planes_de_Rutinas';
    var prevData = Detalle_Planes_de_RutinasTable.fnGetData(rowIndex);
    var data = Detalle_Planes_de_RutinasTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Numero_de_Dia:  data.childNodes[counter++].childNodes[0].value
        ,Fecha:  data.childNodes[counter++].childNodes[0].value
        ,Realizado: $(data.childNodes[counter++].childNodes[2]).is(':checked')

    }
    Detalle_Planes_de_RutinasTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Planes_de_RutinasrowCreationGrid(data, newData, rowIndex);
    Detalle_Planes_de_RutinasTable.fnPageChange(iPage);
    Detalle_Planes_de_RutinascountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Planes_de_Rutinas("Detalle_Planes_de_Rutinas_", "_" + rowIndex);
  }
}

function Detalle_Planes_de_RutinasCancelRow(rowIndex) {
    var prevData = Detalle_Planes_de_RutinasTable.fnGetData(rowIndex);
    var data = Detalle_Planes_de_RutinasTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Planes_de_RutinasTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Planes_de_RutinasrowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Planes_de_RutinasGrid(Detalle_Planes_de_RutinasTable.fnGetData());
    Detalle_Planes_de_RutinascountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Planes_de_RutinasFromDataTable() {
    var Detalle_Planes_de_RutinasData = [];
    var gridData = Detalle_Planes_de_RutinasTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Planes_de_RutinasData.push({
                Folio: gridData[i].Folio

                ,Numero_de_Dia: gridData[i].Numero_de_Dia
                ,Fecha: gridData[i].Fecha
                ,Realizado: gridData[i].Realizado

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Planes_de_RutinasData.length; i++) {
        if (removedDetalle_Planes_de_RutinasData[i] != null && removedDetalle_Planes_de_RutinasData[i].Folio > 0)
            Detalle_Planes_de_RutinasData.push({
                Folio: removedDetalle_Planes_de_RutinasData[i].Folio

                ,Numero_de_Dia: removedDetalle_Planes_de_RutinasData[i].Numero_de_Dia
                ,Fecha: removedDetalle_Planes_de_RutinasData[i].Fecha
                ,Realizado: removedDetalle_Planes_de_RutinasData[i].Realizado

                , Removed: true
            });
    }	

    return Detalle_Planes_de_RutinasData;
}

function Detalle_Planes_de_RutinasEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Planes_de_RutinasTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Planes_de_RutinascountRowsChecked++;
    var Detalle_Planes_de_RutinasRowElement = "Detalle_Planes_de_Rutinas_" + rowIndex.toString();
    var prevData = Detalle_Planes_de_RutinasTable.fnGetData(rowIndexTable );
    var row = Detalle_Planes_de_RutinasTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Planes_de_Rutinas_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Planes_de_RutinasGetUpdateRowControls(prevData, "Detalle_Planes_de_Rutinas_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Planes_de_RutinasRowElement + "')){ Detalle_Planes_de_RutinasInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_Planes_de_RutinasCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Planes_de_RutinasGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Planes_de_RutinasGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_Planes_de_RutinasValidation();
    initiateUIControls();
    $('.Detalle_Planes_de_Rutinas' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Planes_de_Rutinas(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Planes_de_RutinasfnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Planes_de_RutinasTable.fnGetData().length;
    Detalle_Planes_de_RutinasfnClickAddRow();
    GetAddDetalle_Planes_de_RutinasPopup(currentRowIndex, 0);
}

function Detalle_Planes_de_RutinasEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Planes_de_RutinasTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Planes_de_RutinasRowElement = "Detalle_Planes_de_Rutinas_" + rowIndex.toString();
    var prevData = Detalle_Planes_de_RutinasTable.fnGetData(rowIndexTable);
    GetAddDetalle_Planes_de_RutinasPopup(rowIndex, 1, prevData.Folio);

    $('#Detalle_Planes_de_RutinasNumero_de_Dia').val(prevData.Numero_de_Dia);
    $('#Detalle_Planes_de_RutinasFecha').val(prevData.Fecha);
    $('#Detalle_Planes_de_RutinasRealizado').prop('checked', prevData.Realizado);

    initiateUIControls();





}

function Detalle_Planes_de_RutinasAddInsertRow() {
    if (Detalle_Planes_de_RutinasinsertRowCurrentIndex < 1)
    {
        Detalle_Planes_de_RutinasinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Numero_de_Dia: ""
        ,Fecha: ""
        ,Realizado: ""

    }
}

function Detalle_Planes_de_RutinasfnClickAddRow() {
    Detalle_Planes_de_RutinascountRowsChecked++;
    Detalle_Planes_de_RutinasTable.fnAddData(Detalle_Planes_de_RutinasAddInsertRow(), true);
    Detalle_Planes_de_RutinasTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_Planes_de_RutinasGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_Planes_de_RutinasGrid tbody tr:nth-of-type(' + (Detalle_Planes_de_RutinasinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Planes_de_Rutinas("Detalle_Planes_de_Rutinas_", "_" + Detalle_Planes_de_RutinasinsertRowCurrentIndex);
}

function Detalle_Planes_de_RutinasClearGridData() {
    Detalle_Planes_de_RutinasData = [];
    Detalle_Planes_de_RutinasdeletedItem = [];
    Detalle_Planes_de_RutinasDataMain = [];
    Detalle_Planes_de_RutinasDataMainPages = [];
    Detalle_Planes_de_RutinasnewItemCount = 0;
    Detalle_Planes_de_RutinasmaxItemIndex = 0;
    $("#Detalle_Planes_de_RutinasGrid").DataTable().clear();
    $("#Detalle_Planes_de_RutinasGrid").DataTable().destroy();
}

//Used to Get Planes de Rutinas Information
function GetDetalle_Planes_de_Rutinas() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Planes_de_RutinasData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Planes_de_RutinasData[i].Folio);

        form_data.append('[' + i + '].Numero_de_Dia', Detalle_Planes_de_RutinasData[i].Numero_de_Dia);
        form_data.append('[' + i + '].Fecha', Detalle_Planes_de_RutinasData[i].Fecha);
        form_data.append('[' + i + '].Realizado', Detalle_Planes_de_RutinasData[i].Realizado);

        form_data.append('[' + i + '].Removed', Detalle_Planes_de_RutinasData[i].Removed);
    }
    return form_data;
}
function Detalle_Planes_de_RutinasInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Planes_de_Rutinas("Detalle_Planes_de_RutinasTable", rowIndex)) {
    var prevData = Detalle_Planes_de_RutinasTable.fnGetData(rowIndex);
    var data = Detalle_Planes_de_RutinasTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Numero_de_Dia: $('#Detalle_Planes_de_RutinasNumero_de_Dia').val()
        ,Fecha: $('#Detalle_Planes_de_RutinasFecha').val()
        ,Realizado: $('#Detalle_Planes_de_RutinasRealizado').is(':checked')

    }

    Detalle_Planes_de_RutinasTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Planes_de_RutinasrowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Planes_de_Rutinas-form').modal({ show: false });
    $('#AddDetalle_Planes_de_Rutinas-form').modal('hide');
    Detalle_Planes_de_RutinasEditRow(rowIndex);
    Detalle_Planes_de_RutinasInsertRow(rowIndex);
    //}
}
function Detalle_Planes_de_RutinasRemoveAddRow(rowIndex) {
    Detalle_Planes_de_RutinasTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Planes_de_Rutinas MultiRow


$(function () {
    function Detalle_Planes_de_RutinasinitializeMainArray(totalCount) {
        if (Detalle_Planes_de_RutinasDataMain.length != totalCount && !Detalle_Planes_de_RutinasDataMainInitialized) {
            Detalle_Planes_de_RutinasDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Planes_de_RutinasDataMain[i] = null;
            }
        }
    }
    function Detalle_Planes_de_RutinasremoveFromMainArray() {
        for (var j = 0; j < Detalle_Planes_de_RutinasdeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Planes_de_RutinasDataMain.length; i++) {
                if (Detalle_Planes_de_RutinasDataMain[i] != null && Detalle_Planes_de_RutinasDataMain[i].Id == Detalle_Planes_de_RutinasdeletedItem[j]) {
                    hDetalle_Planes_de_RutinasDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Planes_de_RutinascopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Planes_de_RutinasDataMain.length; i++) {
            data[i] = Detalle_Planes_de_RutinasDataMain[i];

        }
        return data;
    }
    function Detalle_Planes_de_RutinasgetNewResult() {
        var newData = copyMainDetalle_Planes_de_RutinasArray();

        for (var i = 0; i < Detalle_Planes_de_RutinasData.length; i++) {
            if (Detalle_Planes_de_RutinasData[i].Removed == null || Detalle_Planes_de_RutinasData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Planes_de_RutinasData[i]);
            }
        }
        return newData;
    }
    function Detalle_Planes_de_RutinaspushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Planes_de_RutinasDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Planes_de_RutinasDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }

});

var AutoCompleteRutinasData = [];
function GetAutoCompletePlanes_de_Rutinas_Rutinas_RutinasData(data) {
	AutoCompleteRutinasData = [];
    for (var i = 0; i < data.length; i++) {
        AutoCompleteRutinasData.push({
            id: data[i].Folio,
            text: data[i].Nombre_de_la_Rutina
        });
    }
    return AutoCompleteRutinasData;
}
//Grid GetAutocomplete



function getDropdown(elementKey) {
    var labelSelect = $("#Planes_de_Rutinas_cmbLabelSelect").val();
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
    $('#CreatePlanes_de_Rutinas')[0].reset();
    ClearFormControls();
    $("#FolioId").val("0");
    $('#Rutinas').empty();
    $("#Rutinas").append('<option value=""></option>');
    $('#Rutinas').val('0').trigger('change');
                Detalle_Planes_de_RutinasClearGridData();

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreatePlanes_de_Rutinas').trigger('reset');
    $('#CreatePlanes_de_Rutinas').find(':input').each(function () {
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
    var $myForm = $('#CreatePlanes_de_Rutinas');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    if (Detalle_Planes_de_RutinascountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Planes_de_Rutinas();
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblFolio").text("0");
}
$(document).ready(function () {
    $("form#CreatePlanes_de_Rutinas").submit(function (e) {
        e.preventDefault();
        return false;
    });
	$("form#CreatePlanes_de_Rutinas").on('click', '#Planes_de_RutinasCancelar', function () {
	  if (!isPartial) {
        Planes_de_RutinasBackToGrid();
	  } else {
            window.close();
      }
    });
	$("form#CreatePlanes_de_Rutinas").on('click', '#Planes_de_RutinasGuardar', function () {
		$('#Planes_de_RutinasGuardar').attr('disabled', true);
		$('#Planes_de_RutinasGuardar').unbind()
        if (EjecutarValidacionesAntesDeGuardar() && CheckValidation()) {
				if (!SendPlanes_de_RutinasData(function () {
					EjecutarValidacionesDespuesDeGuardar();
					if (!isPartial)
						Planes_de_RutinasBackToGrid();
					else {						
						if (!isMR)
							window.opener.RefreshCatalog('Planes_de_Rutinas', nameAttribute);
						else {
							var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
							if(!control.hasClass('AutoComplete'))
							{
							if (control.attr("data-isfilter") == "true") {
									eval(GetReglaFilter(control,  $(window.opener.document.getElementById('ObjectId')).val()));								    
								}
								else 
								{
									eval('window.opener.Get' + nameMR + '_Planes_de_RutinasItem()');
									var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
									control.html(eval('window.opener.Get' + nameMR + '_Planes_de_RutinasDropDown().get(0)').innerHTML);  
								}								
							}
						}
						window.close();						
						}
				})) {
					$('#Planes_de_RutinasGuardar').removeAttr('disabled');
					$('#Planes_de_RutinasGuardar').bind()
				}
		}
		else {
			$('#Planes_de_RutinasGuardar').removeAttr('disabled');
			$('#Planes_de_RutinasGuardar').bind()
		}
    });
	$("form#CreatePlanes_de_Rutinas").on('click', '#Planes_de_RutinasGuardarYNuevo', function () {	
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation()) {
				SendPlanes_de_RutinasData(function () {
					ClearControls();
					ClearAttachmentsDiv();
					ResetClaveLabel();
	                getDetalle_Planes_de_RutinasData();

					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Planes_de_Rutinas', nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_Planes_de_RutinasItem()');                           
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
                            control.html(eval('window.opener.Get' + nameMR + '_Planes_de_RutinasDropDown().get(0)').innerHTML);   
					    }	
					}						
					EjecutarValidacionesDespuesDeGuardar();				
			setIsNew();
			EjecutarValidacionesAlComienzo();
				});
			}
		}		
    });
    $("form#CreatePlanes_de_Rutinas").on('click', '#Planes_de_RutinasGuardarYCopia', function () {
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendPlanes_de_RutinasData(function (currentId) {
					$("#FolioId").val("0");
	    $('#Rutinas').empty();
    $("#Rutinas").append('<option value=""></option>');
    $('#Rutinas').val('0').trigger('change');
                Detalle_Planes_de_RutinasClearGridData();

					ResetClaveLabel();
					$("#ReferenceFolio").val(currentId);
	                getDetalle_Planes_de_RutinasData();

					EjecutarValidacionesDespuesDeGuardar();		
					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Planes_de_Rutinas',nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_Planes_de_RutinasItem()');                          
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);						
							control.html(eval('window.opener.Get' + nameMR + '_Planes_de_RutinasDropDown().get(0)').innerHTML);                          
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



var Planes_de_RutinasisdisplayBusinessPropery = false;
Planes_de_RutinasDisplayBusinessRuleButtons(Planes_de_RutinasisdisplayBusinessPropery);
function Planes_de_RutinasDisplayBusinessRule() {
    if (!Planes_de_RutinasisdisplayBusinessPropery) {
        $('#CreatePlanes_de_Rutinas').find('.col-sm-8').each(function () {
			var div =$(this); 
			if ($(this).find('.input-group').length >0)
				div  =  $(this).find('.input-group').first().hasClass('date')? $(this): $(this).find('.input-group').first();	
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = div.data('field-id');
            var fieldName = div.data('field-name');
            var attribute = div.data('attribute');
            mainElementAttributes += '<div class="Planes_de_RutinasdisplayBusinessPropery"><button onclick="Planes_de_RutinasGetBusinessRule()" type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#Planes_de_RutinasBusinessRule-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.Planes_de_RutinasdisplayBusinessPropery').remove();
    }
    Planes_de_RutinasDisplayBusinessRuleButtons(!Planes_de_RutinasisdisplayBusinessPropery);
    Planes_de_RutinasisdisplayBusinessPropery = (Planes_de_RutinasisdisplayBusinessPropery ? false : true);
}
function Planes_de_RutinasDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}

