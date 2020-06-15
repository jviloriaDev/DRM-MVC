        function RemoveAttachmentMainImagen () {
            $("#hdnRemoveImagen").val("1");
            $("#divAttachmentImagen").hide();
        }


//Begin Declarations for Foreigns fields for Detalle_Caracteristicas_Ingrediente MultiRow
var Detalle_Caracteristicas_IngredientecountRowsChecked = 0;





function GetInsertDetalle_Caracteristicas_IngredienteRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $($.parseHTML(inputData)).addClass('Detalle_Caracteristicas_Ingrediente_Caracteristica_combo Caracteristica_combo').attr('id', 'Detalle_Caracteristicas_Ingrediente_Caracteristica_combo_' + index).attr('data-field', 'Caracteristica_combo');
    columnData[1] = $($.parseHTML(inputData)).addClass('Detalle_Caracteristicas_Ingrediente_Descripcion_texto Descripcion_texto').attr('id', 'Detalle_Caracteristicas_Ingrediente_Descripcion_texto_' + index).attr('data-field', 'Descripcion_texto');


    initiateUIControls();
    return columnData;
}

function Detalle_Caracteristicas_IngredienteInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Caracteristicas_Ingrediente("Detalle_Caracteristicas_Ingrediente_", "_" + rowIndex)) {
    var iPage = Detalle_Caracteristicas_IngredienteTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Caracteristicas_Ingrediente';
    var prevData = Detalle_Caracteristicas_IngredienteTable.fnGetData(rowIndex);
    var data = Detalle_Caracteristicas_IngredienteTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Caracteristica_combo:  data.childNodes[counter++].childNodes[0].value
        ,Descripcion_texto:  data.childNodes[counter++].childNodes[0].value

    }
    Detalle_Caracteristicas_IngredienteTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Caracteristicas_IngredienterowCreationGrid(data, newData, rowIndex);
    Detalle_Caracteristicas_IngredienteTable.fnPageChange(iPage);
    Detalle_Caracteristicas_IngredientecountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Caracteristicas_Ingrediente("Detalle_Caracteristicas_Ingrediente_", "_" + rowIndex);
  }
}

function Detalle_Caracteristicas_IngredienteCancelRow(rowIndex) {
    var prevData = Detalle_Caracteristicas_IngredienteTable.fnGetData(rowIndex);
    var data = Detalle_Caracteristicas_IngredienteTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Caracteristicas_IngredienteTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Caracteristicas_IngredienterowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Caracteristicas_IngredienteGrid(Detalle_Caracteristicas_IngredienteTable.fnGetData());
    Detalle_Caracteristicas_IngredientecountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Caracteristicas_IngredienteFromDataTable() {
    var Detalle_Caracteristicas_IngredienteData = [];
    var gridData = Detalle_Caracteristicas_IngredienteTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Caracteristicas_IngredienteData.push({
                Folio: gridData[i].Folio

                ,Caracteristica_combo: gridData[i].Caracteristica_combo
                ,Descripcion_texto: gridData[i].Descripcion_texto

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Caracteristicas_IngredienteData.length; i++) {
        if (removedDetalle_Caracteristicas_IngredienteData[i] != null && removedDetalle_Caracteristicas_IngredienteData[i].Folio > 0)
            Detalle_Caracteristicas_IngredienteData.push({
                Folio: removedDetalle_Caracteristicas_IngredienteData[i].Folio

                ,Caracteristica_combo: removedDetalle_Caracteristicas_IngredienteData[i].Caracteristica_combo
                ,Descripcion_texto: removedDetalle_Caracteristicas_IngredienteData[i].Descripcion_texto

                , Removed: true
            });
    }	

    return Detalle_Caracteristicas_IngredienteData;
}

function Detalle_Caracteristicas_IngredienteEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Caracteristicas_IngredienteTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Caracteristicas_IngredientecountRowsChecked++;
    var Detalle_Caracteristicas_IngredienteRowElement = "Detalle_Caracteristicas_Ingrediente_" + rowIndex.toString();
    var prevData = Detalle_Caracteristicas_IngredienteTable.fnGetData(rowIndexTable );
    var row = Detalle_Caracteristicas_IngredienteTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Caracteristicas_Ingrediente_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Caracteristicas_IngredienteGetUpdateRowControls(prevData, "Detalle_Caracteristicas_Ingrediente_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Caracteristicas_IngredienteRowElement + "')){ Detalle_Caracteristicas_IngredienteInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_Caracteristicas_IngredienteCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Caracteristicas_IngredienteGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Caracteristicas_IngredienteGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_Caracteristicas_IngredienteValidation();
    initiateUIControls();
    $('.Detalle_Caracteristicas_Ingrediente' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Caracteristicas_Ingrediente(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Caracteristicas_IngredientefnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Caracteristicas_IngredienteTable.fnGetData().length;
    Detalle_Caracteristicas_IngredientefnClickAddRow();
    GetAddDetalle_Caracteristicas_IngredientePopup(currentRowIndex, 0);
}

function Detalle_Caracteristicas_IngredienteEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Caracteristicas_IngredienteTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Caracteristicas_IngredienteRowElement = "Detalle_Caracteristicas_Ingrediente_" + rowIndex.toString();
    var prevData = Detalle_Caracteristicas_IngredienteTable.fnGetData(rowIndexTable);
    GetAddDetalle_Caracteristicas_IngredientePopup(rowIndex, 1, prevData.Folio);

    $('#Detalle_Caracteristicas_IngredienteCaracteristica_combo').val(prevData.Caracteristica_combo);
    $('#Detalle_Caracteristicas_IngredienteDescripcion_texto').val(prevData.Descripcion_texto);

    initiateUIControls();




}

function Detalle_Caracteristicas_IngredienteAddInsertRow() {
    if (Detalle_Caracteristicas_IngredienteinsertRowCurrentIndex < 1)
    {
        Detalle_Caracteristicas_IngredienteinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Caracteristica_combo: ""
        ,Descripcion_texto: ""

    }
}

function Detalle_Caracteristicas_IngredientefnClickAddRow() {
    Detalle_Caracteristicas_IngredientecountRowsChecked++;
    Detalle_Caracteristicas_IngredienteTable.fnAddData(Detalle_Caracteristicas_IngredienteAddInsertRow(), true);
    Detalle_Caracteristicas_IngredienteTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_Caracteristicas_IngredienteGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_Caracteristicas_IngredienteGrid tbody tr:nth-of-type(' + (Detalle_Caracteristicas_IngredienteinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Caracteristicas_Ingrediente("Detalle_Caracteristicas_Ingrediente_", "_" + Detalle_Caracteristicas_IngredienteinsertRowCurrentIndex);
}

function Detalle_Caracteristicas_IngredienteClearGridData() {
    Detalle_Caracteristicas_IngredienteData = [];
    Detalle_Caracteristicas_IngredientedeletedItem = [];
    Detalle_Caracteristicas_IngredienteDataMain = [];
    Detalle_Caracteristicas_IngredienteDataMainPages = [];
    Detalle_Caracteristicas_IngredientenewItemCount = 0;
    Detalle_Caracteristicas_IngredientemaxItemIndex = 0;
    $("#Detalle_Caracteristicas_IngredienteGrid").DataTable().clear();
    $("#Detalle_Caracteristicas_IngredienteGrid").DataTable().destroy();
}

//Used to Get Ingredientes Information
function GetDetalle_Caracteristicas_Ingrediente() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Caracteristicas_IngredienteData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Caracteristicas_IngredienteData[i].Folio);

        form_data.append('[' + i + '].Caracteristica_combo', Detalle_Caracteristicas_IngredienteData[i].Caracteristica_combo);
        form_data.append('[' + i + '].Descripcion_texto', Detalle_Caracteristicas_IngredienteData[i].Descripcion_texto);

        form_data.append('[' + i + '].Removed', Detalle_Caracteristicas_IngredienteData[i].Removed);
    }
    return form_data;
}
function Detalle_Caracteristicas_IngredienteInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Caracteristicas_Ingrediente("Detalle_Caracteristicas_IngredienteTable", rowIndex)) {
    var prevData = Detalle_Caracteristicas_IngredienteTable.fnGetData(rowIndex);
    var data = Detalle_Caracteristicas_IngredienteTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Caracteristica_combo: $('#Detalle_Caracteristicas_IngredienteCaracteristica_combo').val()
        ,Descripcion_texto: $('#Detalle_Caracteristicas_IngredienteDescripcion_texto').val()

    }

    Detalle_Caracteristicas_IngredienteTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Caracteristicas_IngredienterowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Caracteristicas_Ingrediente-form').modal({ show: false });
    $('#AddDetalle_Caracteristicas_Ingrediente-form').modal('hide');
    Detalle_Caracteristicas_IngredienteEditRow(rowIndex);
    Detalle_Caracteristicas_IngredienteInsertRow(rowIndex);
    //}
}
function Detalle_Caracteristicas_IngredienteRemoveAddRow(rowIndex) {
    Detalle_Caracteristicas_IngredienteTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Caracteristicas_Ingrediente MultiRow


$(function () {
    function Detalle_Caracteristicas_IngredienteinitializeMainArray(totalCount) {
        if (Detalle_Caracteristicas_IngredienteDataMain.length != totalCount && !Detalle_Caracteristicas_IngredienteDataMainInitialized) {
            Detalle_Caracteristicas_IngredienteDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Caracteristicas_IngredienteDataMain[i] = null;
            }
        }
    }
    function Detalle_Caracteristicas_IngredienteremoveFromMainArray() {
        for (var j = 0; j < Detalle_Caracteristicas_IngredientedeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Caracteristicas_IngredienteDataMain.length; i++) {
                if (Detalle_Caracteristicas_IngredienteDataMain[i] != null && Detalle_Caracteristicas_IngredienteDataMain[i].Id == Detalle_Caracteristicas_IngredientedeletedItem[j]) {
                    hDetalle_Caracteristicas_IngredienteDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Caracteristicas_IngredientecopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Caracteristicas_IngredienteDataMain.length; i++) {
            data[i] = Detalle_Caracteristicas_IngredienteDataMain[i];

        }
        return data;
    }
    function Detalle_Caracteristicas_IngredientegetNewResult() {
        var newData = copyMainDetalle_Caracteristicas_IngredienteArray();

        for (var i = 0; i < Detalle_Caracteristicas_IngredienteData.length; i++) {
            if (Detalle_Caracteristicas_IngredienteData[i].Removed == null || Detalle_Caracteristicas_IngredienteData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Caracteristicas_IngredienteData[i]);
            }
        }
        return newData;
    }
    function Detalle_Caracteristicas_IngredientepushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Caracteristicas_IngredienteDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Caracteristicas_IngredienteDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }

});

var AutoCompleteClasificacionData = [];
function GetAutoCompleteIngredientes_Clasificacion_Clasificacion_IngredientesData(data) {
	AutoCompleteClasificacionData = [];
    for (var i = 0; i < data.length; i++) {
        AutoCompleteClasificacionData.push({
            id: data[i].Clave,
            text: data[i].Descripcion
        });
    }
    return AutoCompleteClasificacionData;
}
//Grid GetAutocomplete



function getDropdown(elementKey) {
    var labelSelect = $("#Ingredientes_cmbLabelSelect").val();
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
    $("#ReferenceClave").val("0");
    $('#CreateIngredientes')[0].reset();
    ClearFormControls();
    $("#ClaveId").val("0");
    $('#Clasificacion').empty();
    $("#Clasificacion").append('<option value=""></option>');
    $('#Clasificacion').val('0').trigger('change');
                Detalle_Caracteristicas_IngredienteClearGridData();

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreateIngredientes').trigger('reset');
    $('#CreateIngredientes').find(':input').each(function () {
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
    var $myForm = $('#CreateIngredientes');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    if (Detalle_Caracteristicas_IngredientecountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Caracteristicas_Ingrediente();
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblClave").text("0");
}
$(document).ready(function () {
    $("form#CreateIngredientes").submit(function (e) {
        e.preventDefault();
        return false;
    });
	$("form#CreateIngredientes").on('click', '#IngredientesCancelar', function () {
	  if (!isPartial) {
        IngredientesBackToGrid();
	  } else {
            window.close();
      }
    });
	$("form#CreateIngredientes").on('click', '#IngredientesGuardar', function () {
		$('#IngredientesGuardar').attr('disabled', true);
		$('#IngredientesGuardar').unbind()
        if (EjecutarValidacionesAntesDeGuardar() && CheckValidation()) {
				if (!SendIngredientesData(function () {
					EjecutarValidacionesDespuesDeGuardar();
					if (!isPartial)
						IngredientesBackToGrid();
					else {						
						if (!isMR)
							window.opener.RefreshCatalog('Ingredientes', nameAttribute);
						else {
							var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
							if(!control.hasClass('AutoComplete'))
							{
							if (control.attr("data-isfilter") == "true") {
									eval(GetReglaFilter(control,  $(window.opener.document.getElementById('ObjectId')).val()));								    
								}
								else 
								{
									eval('window.opener.Get' + nameMR + '_IngredientesItem()');
									var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
									control.html(eval('window.opener.Get' + nameMR + '_IngredientesDropDown().get(0)').innerHTML);  
								}								
							}
						}
						window.close();						
						}
				})) {
					$('#IngredientesGuardar').removeAttr('disabled');
					$('#IngredientesGuardar').bind()
				}
		}
		else {
			$('#IngredientesGuardar').removeAttr('disabled');
			$('#IngredientesGuardar').bind()
		}
    });
	$("form#CreateIngredientes").on('click', '#IngredientesGuardarYNuevo', function () {	
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation()) {
				SendIngredientesData(function () {
					ClearControls();
					ClearAttachmentsDiv();
					ResetClaveLabel();
	                getDetalle_Caracteristicas_IngredienteData();

					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Ingredientes', nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_IngredientesItem()');                           
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
                            control.html(eval('window.opener.Get' + nameMR + '_IngredientesDropDown().get(0)').innerHTML);   
					    }	
					}						
					EjecutarValidacionesDespuesDeGuardar();				
			setIsNew();
			EjecutarValidacionesAlComienzo();
				});
			}
		}		
    });
    $("form#CreateIngredientes").on('click', '#IngredientesGuardarYCopia', function () {
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendIngredientesData(function (currentId) {
					$("#ClaveId").val("0");
	    $('#Clasificacion').empty();
    $("#Clasificacion").append('<option value=""></option>');
    $('#Clasificacion').val('0').trigger('change');
                Detalle_Caracteristicas_IngredienteClearGridData();

					ResetClaveLabel();
					$("#ReferenceClave").val(currentId);
	                getDetalle_Caracteristicas_IngredienteData();

					EjecutarValidacionesDespuesDeGuardar();		
					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Ingredientes',nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_IngredientesItem()');                          
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);						
							control.html(eval('window.opener.Get' + nameMR + '_IngredientesDropDown().get(0)').innerHTML);                          
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



var IngredientesisdisplayBusinessPropery = false;
IngredientesDisplayBusinessRuleButtons(IngredientesisdisplayBusinessPropery);
function IngredientesDisplayBusinessRule() {
    if (!IngredientesisdisplayBusinessPropery) {
        $('#CreateIngredientes').find('.col-sm-8').each(function () {
			var div =$(this); 
			if ($(this).find('.input-group').length >0)
				div  =  $(this).find('.input-group').first().hasClass('date')? $(this): $(this).find('.input-group').first();	
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = div.data('field-id');
            var fieldName = div.data('field-name');
            var attribute = div.data('attribute');
            mainElementAttributes += '<div class="IngredientesdisplayBusinessPropery"><button onclick="IngredientesGetBusinessRule()" type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#IngredientesBusinessRule-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.IngredientesdisplayBusinessPropery').remove();
    }
    IngredientesDisplayBusinessRuleButtons(!IngredientesisdisplayBusinessPropery);
    IngredientesisdisplayBusinessPropery = (IngredientesisdisplayBusinessPropery ? false : true);
}
function IngredientesDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}

