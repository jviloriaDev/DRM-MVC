        function RemoveAttachmentMainImagen () {
            $("#hdnRemoveImagen").val("1");
            $("#divAttachmentImagen").hide();
        }
        function RemoveAttachmentMainVideo () {
            $("#hdnRemoveVideo").val("1");
            $("#divAttachmentVideo").hide();
        }


var MS_Equipamiento_para_EjercicioscountRowsChecked = 0;
function GetMS_Equipamiento_para_EjerciciosFromDataTable() {
    var MS_Equipamiento_para_EjerciciosData = [];
    debugger;

    var items = $("#ddlEquipamentoMult").chosen().val();
    //es nuevo 
    if (MS_Equipamiento_para_EjerciciosDataDataTable == undefined || MS_Equipamiento_para_EjerciciosDataDataTable.length == 0) {
        if (items!= null && items.length > 0) {
            for (var i = 0; i < items.length; i++) {
                MS_Equipamiento_para_EjerciciosData.push({ 
                      Folio: 0
                      
, Equipamento: items[i]

                      ,Removed: false
                });
            }
        }
    }
    else // esta editando 
    {
        // se borran los que ya no estan 
        for (var i = 0; i < MS_Equipamiento_para_EjerciciosDataDataTable.length; i++)
        {
            var borrar = true;
            if (items != null) {
                if (items.length > 0) {
                    for (var j = 0; j < items.length; j++) {
                        if (MS_Equipamiento_para_EjerciciosDataDataTable[i].Folio == items[j]) {
                            borrar = false;
                        }
                    }
                }
            }
            
                if (borrar) {
                    MS_Equipamiento_para_EjerciciosData.push({
                        Folio: MS_Equipamiento_para_EjerciciosDataDataTable[i].Folio
                        
                   , Equipamento: MS_Equipamiento_para_EjerciciosDataDataTable[i].Equipamento

                        , Removed: true
                    });
                }
        }

        if (items != null)
        {
            if (items.length > 0) {
                // Se agregan los nuevoss 
                for (var i = 0; i < items.length; i++) {
                    var existe = false;
                    for (var j = 0; j < MS_Equipamiento_para_EjerciciosDataDataTable.length; j++) {
                        if (items[i] == MS_Equipamiento_para_EjerciciosDataDataTable[j].Folio) {
                            existe = true;
                        }
                    }
                    if (!existe) {
                        MS_Equipamiento_para_EjerciciosData.push({ 
                              Folio: 0
                              
, Equipamento: items[i]
 
                        });
                    }
                }
            }
        }
       
        
    }

    return MS_Equipamiento_para_EjerciciosData;
}

//Used to Get Ejercicios Information
function GetMS_Equipamiento_para_Ejercicios() {
    var form_data = new FormData();
    for (var i = 0; i < MS_Equipamiento_para_EjerciciosData.length; i++) {
       form_data.append('[' + i + '].Folio', MS_Equipamiento_para_EjerciciosData[i].Folio);
       
      form_data.append('[' + i +'].Equipamento',MS_Equipamiento_para_EjerciciosData[i].Equipamento);


       form_data.append('[' + i + '].Removed', MS_Equipamiento_para_EjerciciosData[i].Removed);
    }
    return form_data;
}



$(function () {
    function MS_Equipamiento_para_EjerciciosinitializeMainArray(totalCount) {
        if (MS_Equipamiento_para_EjerciciosDataMain.length != totalCount && !MS_Equipamiento_para_EjerciciosDataMainInitialized) {
            MS_Equipamiento_para_EjerciciosDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                MS_Equipamiento_para_EjerciciosDataMain[i] = null;
            }
        }
    }
    function MS_Equipamiento_para_EjerciciosremoveFromMainArray() {
        for (var j = 0; j < MS_Equipamiento_para_EjerciciosdeletedItem.length; j++) {
            for (var i = 0; i < MS_Equipamiento_para_EjerciciosDataMain.length; i++) {
                if (MS_Equipamiento_para_EjerciciosDataMain[i] != null && MS_Equipamiento_para_EjerciciosDataMain[i].Id == MS_Equipamiento_para_EjerciciosdeletedItem[j]) {
                    hMS_Equipamiento_para_EjerciciosDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function MS_Equipamiento_para_EjercicioscopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < MS_Equipamiento_para_EjerciciosDataMain.length; i++) {
            data[i] = MS_Equipamiento_para_EjerciciosDataMain[i];

        }
        return data;
    }
    function MS_Equipamiento_para_EjerciciosgetNewResult() {
        var newData = copyMainMS_Equipamiento_para_EjerciciosArray();

        for (var i = 0; i < MS_Equipamiento_para_EjerciciosData.length; i++) {
            if (MS_Equipamiento_para_EjerciciosData[i].Removed == null || MS_Equipamiento_para_EjerciciosData[i].Removed == false) {
                newData.splice(0, 0, MS_Equipamiento_para_EjerciciosData[i]);
            }
        }
        return newData;
    }
    function MS_Equipamiento_para_EjerciciospushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (MS_Equipamiento_para_EjerciciosDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                MS_Equipamiento_para_EjerciciosDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }

});

//Grid GetAutocomplete



function getDropdown(elementKey) {
    var labelSelect = $("#Ejercicios_cmbLabelSelect").val();
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
    $('#CreateEjercicios')[0].reset();
    ClearFormControls();
    $("#ClaveId").val("0");
                   $('#ddlEquipamentoMult').children("selected").each(function () {
                           $(this).prop("selected", false);
                   });
                   $('#ddlEquipamentoMult').trigger('chosen:updated');

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreateEjercicios').trigger('reset');
    $('#CreateEjercicios').find(':input').each(function () {
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
    var $myForm = $('#CreateEjercicios');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    if (MS_Equipamiento_para_EjercicioscountRowsChecked > 0)
    {
        ShowMessagePendingRowMS_Equipamiento_para_Ejercicios();
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblClave").text("0");
}
$(document).ready(function () {
    $("form#CreateEjercicios").submit(function (e) {
        e.preventDefault();
        return false;
    });
	$("form#CreateEjercicios").on('click', '#EjerciciosCancelar', function () {
	  if (!isPartial) {
        EjerciciosBackToGrid();
	  } else {
            window.close();
      }
    });
	$("form#CreateEjercicios").on('click', '#EjerciciosGuardar', function () {
		$('#EjerciciosGuardar').attr('disabled', true);
		$('#EjerciciosGuardar').unbind()
        if (EjecutarValidacionesAntesDeGuardar() && CheckValidation()) {
				if (!SendEjerciciosData(function () {
					EjecutarValidacionesDespuesDeGuardar();
					if (!isPartial)
						EjerciciosBackToGrid();
					else {						
						if (!isMR)
							window.opener.RefreshCatalog('Ejercicios', nameAttribute);
						else {
							var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
							if(!control.hasClass('AutoComplete'))
							{
							if (control.attr("data-isfilter") == "true") {
									eval(GetReglaFilter(control,  $(window.opener.document.getElementById('ObjectId')).val()));								    
								}
								else 
								{
									eval('window.opener.Get' + nameMR + '_EjerciciosItem()');
									var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
									control.html(eval('window.opener.Get' + nameMR + '_EjerciciosDropDown().get(0)').innerHTML);  
								}								
							}
						}
						window.close();						
						}
				})) {
					$('#EjerciciosGuardar').removeAttr('disabled');
					$('#EjerciciosGuardar').bind()
				}
		}
		else {
			$('#EjerciciosGuardar').removeAttr('disabled');
			$('#EjerciciosGuardar').bind()
		}
    });
	$("form#CreateEjercicios").on('click', '#EjerciciosGuardarYNuevo', function () {	
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation()) {
				SendEjerciciosData(function () {
					ClearControls();
					ClearAttachmentsDiv();
					ResetClaveLabel();
	                getMS_Equipamiento_para_EjerciciosData();

					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Ejercicios', nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_EjerciciosItem()');                           
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
                            control.html(eval('window.opener.Get' + nameMR + '_EjerciciosDropDown().get(0)').innerHTML);   
					    }	
					}						
					EjecutarValidacionesDespuesDeGuardar();				
			setIsNew();
			EjecutarValidacionesAlComienzo();
				});
			}
		}		
    });
    $("form#CreateEjercicios").on('click', '#EjerciciosGuardarYCopia', function () {
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendEjerciciosData(function (currentId) {
					$("#ClaveId").val("0");
	                   $('#ddlEquipamentoMult').children("selected").each(function () {
                           $(this).prop("selected", false);
                   });
                   $('#ddlEquipamentoMult').trigger('chosen:updated');

					ResetClaveLabel();
					$("#ReferenceClave").val(currentId);
	                getMS_Equipamiento_para_EjerciciosData();

					EjecutarValidacionesDespuesDeGuardar();		
					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Ejercicios',nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_EjerciciosItem()');                          
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);						
							control.html(eval('window.opener.Get' + nameMR + '_EjerciciosDropDown().get(0)').innerHTML);                          
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



var EjerciciosisdisplayBusinessPropery = false;
EjerciciosDisplayBusinessRuleButtons(EjerciciosisdisplayBusinessPropery);
function EjerciciosDisplayBusinessRule() {
    if (!EjerciciosisdisplayBusinessPropery) {
        $('#CreateEjercicios').find('.col-sm-8').each(function () {
			var div =$(this); 
			if ($(this).find('.input-group').length >0)
				div  =  $(this).find('.input-group').first().hasClass('date')? $(this): $(this).find('.input-group').first();	
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = div.data('field-id');
            var fieldName = div.data('field-name');
            var attribute = div.data('attribute');
            mainElementAttributes += '<div class="EjerciciosdisplayBusinessPropery"><button onclick="EjerciciosGetBusinessRule()" type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#EjerciciosBusinessRule-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.EjerciciosdisplayBusinessPropery').remove();
    }
    EjerciciosDisplayBusinessRuleButtons(!EjerciciosisdisplayBusinessPropery);
    EjerciciosisdisplayBusinessPropery = (EjerciciosisdisplayBusinessPropery ? false : true);
}
function EjerciciosDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}

