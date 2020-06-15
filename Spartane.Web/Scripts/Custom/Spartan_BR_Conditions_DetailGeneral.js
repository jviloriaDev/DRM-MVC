



$(function () {

});



function getDropdown(elementKey) {
    var dropDown = '<select id="' + elementKey + '" class="form-control"><option value="">--Select--</option></select>';
    return dropDown;
}

function GetGridDatePicker() {
    return "<input type='text' class='fullWidth gridDatePicker xyz form-control' readonly='readonly'>";
}
function GetGridTimePicker() {
    return "<input type='text' class='fullWidth gridTimePicker form-control' readonly='readonly' data-autoclose='true'>";
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

function GetGridAutoComplete(data,field) {
    
    var dataMain = data == null ? "Select" : data;
    
    return "<select class='" + field + " form-control' style='width: 250px'><option>" + dataMain + "</option></select>";
}

function ClearControls() {
    $("#ReferenceConditionsDetailId").val("0");
    $('#CreateSpartan_BR_Conditions_Detail')[0].reset();
    ClearFormControls();
    $("#ConditionsDetailIdId").val("0");

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreateSpartan_BR_Conditions_Detail').trigger('reset');
    $('#CreateSpartan_BR_Conditions_Detail').find(':input').each(function () {
        switch (this.type) {
            case 'password':
            case 'number':
            case 'select-multiple':
            case 'select-one':
            case 'select':
            case 'text':
            case 'textarea':
                $(this).val('');
                break;
            case 'checkbox':
            case 'radio':
                this.checked = false;
        }
    });
}
function CheckValidation() {
    var $myForm = $('#CreateSpartan_BR_Conditions_Detail');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblConditionsDetailId").text("0");
}
$(document).ready(function () {
    $("form#CreateSpartan_BR_Conditions_Detail").submit(function (e) {
        e.preventDefault();
        return false;
    });
    $("#Cancelar").click(function () {
        BackToGrid();
    });
    $("#Guardar").click(function () {
        if (CheckValidation())
            SendSpartan_BR_Conditions_DetailData(function () {
                BackToGrid();
            });
    });
    $("#GuardarYNuevo").click(function () {
        if (CheckValidation()) {
            SendSpartan_BR_Conditions_DetailData(function () {
                ClearControls();
                ClearAttachmentsDiv();
                ResetClaveLabel();

            });
        }
    });
    $("#GuardarYCopia").click(function () {
        if (CheckValidation())
            SendSpartan_BR_Conditions_DetailData(function (currentId) {
                $("#ConditionsDetailIdId").val("0");

                ResetClaveLabel();
                $("#ReferenceConditionsDetailId").val(currentId);

            });
    });
});
var mainElementObject;
var childElementObject;
function DisplayElementAttributes(data) {
}
function setRequired(elementNumber, element, elementType) {
    //debugger;
    if (elementType == "1") {
        mainElementObject[elementNumber].IsRequired = (mainElementObject[elementNumber].IsRequired == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[elementNumber].IsRequired == true ? "Images/Required.png" : "Images/Not-Required.png") + "");
        $(element).attr('title', (mainElementObject[elementNumber].IsRequired == true ? 'Required' : 'Not Required'));
        if (!mainElementObject[elementNumber].IsVisible && mainElementObject[elementNumber].IsRequired) {
            setVisible(elementNumber, $(element).parent().parent().find('div.visibleAttribute').find('a'), elementType);
        }
        if (mainElementObject[elementNumber].IsReadOnly && mainElementObject[elementNumber].IsRequired && mainElementObject[elementNumber].DefaultValue == '') {
            setReadOnly(elementNumber, $(element).parent().parent().find('div.readOnlyAttribute').find('a'), elementType);
        }
    } else {
        childElementObject[elementNumber].IsRequired = (childElementObject[elementNumber].IsRequired == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (childElementObject[elementNumber].IsRequired == true ? "Images/Required.png" : "Images/Not-Required.png") + "");
        $(element).attr('title', (childElementObject[elementNumber].IsRequired == true ? 'Required' : 'Not Required'));
        if (!childElementObject[elementNumber].IsVisible && childElementObject[elementNumber].IsRequired) {
            setVisible(elementNumber, $(element).parent().parent().find('div.visibleAttribute').find('a'), elementType);
        }
        if (childElementObject[elementNumber].IsReadOnly && childElementObject[elementNumber].IsRequired && childElementObject[elementNumber].DefaultValue == '') {
            setReadOnly(elementNumber, $(element).parent().parent().find('div.readOnlyAttribute').find('a'), elementType);
        }
    }
}
function setVisible(elementNumber, element, elementType) {
    if (elementType == "1") {
        if (mainElementObject[elementNumber].IsRequired && mainElementObject[elementNumber].DefaultValue == '' && mainElementObject[elementNumber].IsVisible) {
            showNotification("can not set in visible, as this field is required and has no default value", "error");
            return;
        }
        mainElementObject[elementNumber].IsVisible = (mainElementObject[elementNumber].IsVisible == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[elementNumber].IsVisible == true ? "Images/Visible.png" : "Images/inVisible.png") + "");
        $(element).attr('title', (mainElementObject[elementNumber].IsVisible == true ? 'Visible' : 'In Visible'));
    } else {
        if (childElementObject[elementNumber].IsRequired && childElementObject[elementNumber].DefaultValue == '' && childElementObject[elementNumber].IsVisible) {
            showNotification("can not set in visible, as this field is required and has no default value", "error");
            return;
        }
        childElementObject[elementNumber].IsVisible = (childElementObject[elementNumber].IsVisible == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (childElementObject[elementNumber].IsVisible == true ? "Images/Visible.png" : "Images/inVisible.png") + "");
        $(element).attr('title', (childElementObject[elementNumber].IsVisible == true ? 'Visible' : 'In Visible'));
    }
}
function setReadOnly(elementNumber, element, elementType) {
    if (elementType == "1") {
        if (mainElementObject[elementNumber].IsRequired && mainElementObject[elementNumber].DefaultValue == '' && !mainElementObject[elementNumber].IsReadOnly) {
            showNotification("can not set readonly, as this field is required and has no default value", "error");
            return;
        }
        mainElementObject[elementNumber].IsReadOnly = (mainElementObject[elementNumber].IsReadOnly == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[elementNumber].IsReadOnly == true ? "Images/Disabled.png" : "Images/Enabled.png") + "");
        $(element).attr('title', (mainElementObject[elementNumber].IsReadOnly == true ? 'Disabled' : 'Enabled'));
    } else {
        if (childElementObject[elementNumber].IsRequired && childElementObject[elementNumber].DefaultValue == '' && !childElementObject[elementNumber].IsReadOnly) {
            showNotification("can not set readonly, as this field is required and has no default value", "error");
            return;
        }
        childElementObject[elementNumber].IsReadOnly = (childElementObject[elementNumber].IsReadOnly == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (childElementObject[elementNumber].IsReadOnly == true ? "Images/Disabled.png" : "Images/Enabled.png") + "");
        $(element).attr('title', (childElementObject[elementNumber].IsReadOnly == true ? 'Disabled' : 'Enabled'));
    }
}
function setDefaultValue(elementNumber, element, elementType) {
    //debugger;
    $('#hdnAttributType').val('1');
    $('#hdnAttributNumber').val(elementNumber);
    $('#lblAttributeType').text('Default Value');
    if (elementType == "1") {
        $('#txtAttributeValue').val(mainElementObject[elementNumber].DefaultValue);
        $('#hdnElementType').val("1");
    } else {
        $('#txtAttributeValue').val(childElementObject[elementNumber].DefaultValue);
        $('#hdnElementType').val("2");
    }
    $('#dvAttributeValue').show();
}
function setHelpText(elementNumber, element, elementType) {
    $('#hdnAttributType').val('2');
    $('#hdnAttributNumber').val(elementNumber);
    $('#lblAttributeType').text('Help Text');
    if (elementType == "1") {
        $('#txtAttributeValue').val(mainElementObject[elementNumber].HelpText);
        $('#hdnElementType').val("1");
    } else {
        $('#txtAttributeValue').val(childElementObject[elementNumber].HelpText);
        $('#hdnElementType').val("2");
    }
    $('#dvAttributeValue').show();
    //$(element).children().attr("src", "" + (mainElementObject[elementNumber].HelpText == '' ? "Images/red-help.png" : "Images/green-help.png") + "");
}
function SaveValue() {
    //debugger;
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
            childElementObject[$('#hdnAttributNumber').val()].DefaultValue = $('#txtAttributeValue').val();
            console.log(childElementObject[$('#hdnAttributNumber').val()].DefaultValue);
            $('#hlDefaultValueHeader_' + $('#hdnAttributNumber').val()).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (childElementObject[$('#hdnAttributNumber').val()].DefaultValue == '' ? "Images/Not-Default-Value.png" : "Images/default-value.png") + "");
            $('#hlDefaultValueHeader_' + $('#hdnAttributNumber').val()).attr('title', (childElementObject[$('#hdnAttributNumber').val()].DefaultValue));
            console.log($('#hdnAttributNumber').val());
        } else if ($('#hdnAttributType').val() == "2") {
            childElementObject[$('#hdnAttributNumber').val()].HelpText = $('#txtAttributeValue').val();
            $('#hlHelpTextHeader_' + $('#hdnAttributNumber').val()).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (childElementObject[$('#hdnAttributNumber').val()].HelpText == '' ? "Images/red-help.jpg" : "Images/green-help.png") + "");
            $('#hlHelpTextHeader_' + $('#hdnAttributNumber').val()).attr('title', (childElementObject[$('#hdnAttributNumber').val()].HelpText));
        }
    }
    $('#txtAttributeValue').val('');
    $('#dvAttributeValue').hide();
}
function returnAttributeHTML(elementNumber) {
    var mainElementAttributes = '<div class="col-ld-12" style="display:inline-flex;">';
    mainElementAttributes += '<div class="displayAttributes requiredAttribute"><a class="requiredClick" title="' + (childElementObject[elementNumber].IsRequired == true ? "Required" : "Not Required") + '" onclick="setRequired(' + elementNumber.toString() + ', this, 2)"><img src="' + $('#hdnApplicationDirectory').val() + (childElementObject[elementNumber].IsRequired == true ? "Images/Required.png" : "Images/Not-Required.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes visibleAttribute"><a class="visibleClick" title="' + (childElementObject[elementNumber].IsVisible == true ? "Visible" : "In Visible") + '" onclick="setVisible(' + elementNumber.toString() + ', this, 2)"><img src="' + $('#hdnApplicationDirectory').val() + (childElementObject[elementNumber].IsVisible == true ? "Images/Visible.png" : "Images/InVisible.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes readOnlyAttribute"><a class="readOnlyClick" title="' + (childElementObject[elementNumber].IsReadOnly == true ? "Disabled" : "Enabled") + '" onclick="setReadOnly(' + elementNumber.toString() + ', this, 2)"><img src="' + $('#hdnApplicationDirectory').val() + (childElementObject[elementNumber].IsReadOnly == true ? "Images/Disabled.png" : "Images/Enabled.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes defaultValueAttribute"><a id="hlDefaultValueHeader_' + elementNumber.toString() + '" class="defaultValueClick" title="' + (childElementObject[elementNumber].DefaultValue) + '" onclick="setDefaultValue(' + elementNumber.toString() + ', this, 2)"><img src="' + $('#hdnApplicationDirectory').val() + (childElementObject[elementNumber].DefaultValue != '' && childElementObject[elementNumber].DefaultValue != null ? "Images/default-value.png" : "Images/Not-Default-Value.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes helpTextAttribute"><a id="hlHelpTextHeader_' + elementNumber.toString() + '" class="helpTextClick" title="' + (childElementObject[elementNumber].HelpText) + '" onclick="setHelpText(' + elementNumber.toString() + ', this, 2)"><img src="' + $('#hdnApplicationDirectory').val() + (childElementObject[elementNumber].HelpText != '' && childElementObject[elementNumber].HelpText != null ? "Images/green-help.png" : "Images/red-help.jpg") + '" alt="" /></a></div>';
    mainElementAttributes += '</div>';
    return mainElementAttributes;
}
var isdisplayBusinessPropery = false;
DisplayBusinessRuleButtons(isdisplayBusinessPropery);
function DisplayBusinessRule() {
    if (!isdisplayBusinessPropery) {
        $('#CreateSpartan_BR_Conditions_Detail').find('.col-sm-8').each(function () {
            var mainElementAttributes = '<div class="col-sm-2">';
            //mainElementAttributes += '<div class="displayBusinessPropery"><a onclick="DisplayBusinessRulePopup()"><i class="fa fa-cogs fa-spin"></i></a></div>';
            mainElementAttributes += '<div class="displayBusinessPropery"><button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#PropertyBusinessModal-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.displayBusinessPropery').remove();
    }
    DisplayBusinessRuleButtons(!isdisplayBusinessPropery);
    isdisplayBusinessPropery = (isdisplayBusinessPropery ? false : true);
}
function DisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}

var ConditionBusinessRuleTable;
var ActionBusinessRuleTable;
var ActionNotBusinessRuleTable;
function initializeBusinessRuleTable(){
    ConditionBusinessRuleTable = $("#tblConditionBusinessRule").DataTable();
    ActionBusinessRuleTable = $("#tblActionBusinessRule").DataTable();
    ActionNotBusinessRuleTable = $("#tblActionNotBusinessRule").DataTable();
}

function AddNewRowCondition() {
    var actionLinks = '<i class="fa fa-save" onclick="SaveRowCondition()"><a></a></i><i class="fa fa-trash-o" onclick="DeleteRowCondition(this)"><a></a></i>';
    ConditionBusinessRuleTable.row.add([actionLinks, getDropdown('Operator'), getDropdown('OperatorType1'), getDropdown('OperatorValue1'), getDropdown('Condition'), getDropdown('OperatorType2'), getDropdown('OperatorValue2')]).draw();
}
function AddNewRowAction() {
    var actionLinks = '<i class="fa fa-save" onclick="SaveRowAction()"><a></a></i><i class="fa fa-trash-o" onclick="DeleteRowAction(this)"><a></a></i>';
    ActionBusinessRuleTable.row.add([actionLinks, getDropdown('AAction'), getDropdown('AActionResult'), getDropdown('AParam1'), getDropdown('AParam2'), getDropdown('AParam3'), getDropdown('AParam4'), getDropdown('AParam5')]).draw();
}
function AddNewRowNotAction() {
    var actionLinks = '<i class="fa fa-save" onclick="SaveRowNotAction()"><a></a></i><i class="fa fa-trash-o" onclick="DeleteRowNotAction(this)"><a></a></i>';
    ActionNotBusinessRuleTable.row.add([actionLinks, getDropdown('ANAction'), getDropdown('ANActionResult'), getDropdown('ANParam1'), getDropdown('ANParam2'), getDropdown('ANParam3'), getDropdown('ANParam4'), getDropdown('ANParam5')]).draw();
}
function DeleteRowCondition(element) {
    if (confirm("are you sure you want to delete")) {
        ConditionBusinessRuleTable.row($(element).closest('tr')).remove().draw();
    }
}
function DeleteRowAction(element) {
    if (confirm("are you sure you want to delete")) {
        ActionBusinessRuleTable.row($(element).closest('tr')).remove().draw();
    }
}
function DeleteRowNotAction(element) {
    if (confirm("are you sure you want to delete")) {
        ActionNotBusinessRuleTable.row($(element).closest('tr')).remove().draw();
    }
}
function SaveRowAction() {

}
function SaveRowNotAction() {

}
function SaveRowCondition() {

}
