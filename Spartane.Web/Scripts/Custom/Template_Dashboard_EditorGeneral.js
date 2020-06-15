        function RemoveAttachmentMainTemplate_Image_Thumbnail () {
            $("#hdnRemoveTemplate_Image_Thumbnail").val("1");
            $("#divAttachmentTemplate_Image_Thumbnail").hide();
        }


//Begin Declarations for Foreigns fields for Template_Dashboard_Detail MultiRow
var Template_Dashboard_DetailcountRowsChecked = 0;


function GetInsertTemplate_Dashboard_DetailRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Template_Dashboard_Detail_Row_Number Row_Number').attr('id', 'Template_Dashboard_Detail_Row_Number_' + index).attr('data-field', 'Row_Number');
    columnData[1] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Template_Dashboard_Detail_Columns Columns').attr('id', 'Template_Dashboard_Detail_Columns_' + index).attr('data-field', 'Columns');


    initiateUIControls();
    return columnData;
}

function Template_Dashboard_DetailInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRTemplate_Dashboard_Detail("Template_Dashboard_Detail_", "_" + rowIndex)) {
    var iPage = Template_Dashboard_DetailTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Template_Dashboard_Detail';
    var prevData = Template_Dashboard_DetailTable.fnGetData(rowIndex);
    var data = Template_Dashboard_DetailTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Detail_Id: prevData.Detail_Id,
        IsInsertRow: false
        ,Row_Number: data.childNodes[counter++].childNodes[0].value
        ,Columns: data.childNodes[counter++].childNodes[0].value

    }
    Template_Dashboard_DetailTable.fnUpdate(newData, rowIndex, null, true);
    Template_Dashboard_DetailrowCreationGrid(data, newData, rowIndex);
    Template_Dashboard_DetailTable.fnPageChange(iPage);
    Template_Dashboard_DetailcountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRTemplate_Dashboard_Detail("Template_Dashboard_Detail_", "_" + rowIndex);
  }
}

function Template_Dashboard_DetailCancelRow(rowIndex) {
    var prevData = Template_Dashboard_DetailTable.fnGetData(rowIndex);
    var data = Template_Dashboard_DetailTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Template_Dashboard_DetailTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Template_Dashboard_DetailrowCreationGrid(data, prevData, rowIndex);
    }
	showTemplate_Dashboard_DetailGrid(Template_Dashboard_DetailTable.fnGetData());
    Template_Dashboard_DetailcountRowsChecked--;
	initiateUIControls();
}

function GetTemplate_Dashboard_DetailFromDataTable() {
    var Template_Dashboard_DetailData = [];
    var gridData = Template_Dashboard_DetailTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Template_Dashboard_DetailData.push({
                Detail_Id: gridData[i].Detail_Id
                ,Row_Number: gridData[i].Row_Number
                ,Columns: gridData[i].Columns

                ,Removed: false
            });
    }

    for (i = 0; i < removedTemplate_Dashboard_DetailData.length; i++) {
        if (removedTemplate_Dashboard_DetailData[i] != null && removedTemplate_Dashboard_DetailData[i].Detail_Id > 0)
            Template_Dashboard_DetailData.push({
                Detail_Id: removedTemplate_Dashboard_DetailData[i].Detail_Id
                ,Row_Number: removedTemplate_Dashboard_DetailData[i].Row_Number
                ,Columns: removedTemplate_Dashboard_DetailData[i].Columns

                , Removed: true
            });
    }	

    return Template_Dashboard_DetailData;
}

function Template_Dashboard_DetailEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Template_Dashboard_DetailTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Template_Dashboard_DetailcountRowsChecked++;
    var Template_Dashboard_DetailRowElement = "Template_Dashboard_Detail_" + rowIndex.toString();
    var prevData = Template_Dashboard_DetailTable.fnGetData(rowIndexTable );
    var row = Template_Dashboard_DetailTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Template_Dashboard_Detail_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Template_Dashboard_DetailGetUpdateRowControls(prevData, "Template_Dashboard_Detail_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Template_Dashboard_DetailRowElement + "')){ Template_Dashboard_DetailInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Template_Dashboard_DetailCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Template_Dashboard_DetailGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Template_Dashboard_DetailGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    $('.Template_Dashboard_Detail' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    setTemplate_Dashboard_DetailValidation();
    initiateUIControls();
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRTemplate_Dashboard_Detail(nameOfTable, rowIndexFormed);
    }
}

function Template_Dashboard_DetailfnOpenAddRowPopUp() {
    var currentRowIndex = Template_Dashboard_DetailTable.fnGetData().length;
    Template_Dashboard_DetailfnClickAddRow();
    GetAddTemplate_Dashboard_DetailPopup(currentRowIndex, 0);
}

function Template_Dashboard_DetailEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Template_Dashboard_DetailTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Template_Dashboard_DetailRowElement = "Template_Dashboard_Detail_" + rowIndex.toString();
    var prevData = Template_Dashboard_DetailTable.fnGetData(rowIndexTable);
    GetAddTemplate_Dashboard_DetailPopup(rowIndex, 1, prevData.Detail_Id);
    $('#Template_Dashboard_DetailRow_Number').val(prevData.Row_Number);
    $('#Template_Dashboard_DetailColumns').val(prevData.Columns);

    initiateUIControls();

}

function Template_Dashboard_DetailAddInsertRow() {
    if (Template_Dashboard_DetailinsertRowCurrentIndex < 1)
    {
        Template_Dashboard_DetailinsertRowCurrentIndex = 1;
    }
    return {
        Detail_Id: null,
        IsInsertRow: true
        ,Row_Number: ""
        ,Columns: ""

    }
}

function Template_Dashboard_DetailfnClickAddRow() {
    Template_Dashboard_DetailcountRowsChecked++;
    Template_Dashboard_DetailTable.fnAddData(Template_Dashboard_DetailAddInsertRow(), true);
    Template_Dashboard_DetailTable.fnPageChange('last');
    initiateUIControls();
	 var tag = $('#Template_Dashboard_DetailGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    $('#Template_Dashboard_DetailGrid tbody tr:nth-of-type(' + (Template_Dashboard_DetailinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRTemplate_Dashboard_Detail("Template_Dashboard_Detail_", "_" + Template_Dashboard_DetailinsertRowCurrentIndex);
}

function Template_Dashboard_DetailClearGridData() {
    Template_Dashboard_DetailData = [];
    Template_Dashboard_DetaildeletedItem = [];
    Template_Dashboard_DetailDataMain = [];
    Template_Dashboard_DetailDataMainPages = [];
    Template_Dashboard_DetailnewItemCount = 0;
    Template_Dashboard_DetailmaxItemIndex = 0;
    $("#Template_Dashboard_DetailGrid").DataTable().clear();
    $("#Template_Dashboard_DetailGrid").DataTable().destroy();
}

//Used to Get Spartan Template Dashboard Editor Information
function GetTemplate_Dashboard_Detail() {
    var form_data = new FormData();
    for (var i = 0; i < Template_Dashboard_DetailData.length; i++) {
        form_data.append('[' + i + '].Detail_Id', Template_Dashboard_DetailData[i].Detail_Id);
        form_data.append('[' + i + '].Row_Number', Template_Dashboard_DetailData[i].Row_Number);
        form_data.append('[' + i + '].Columns', Template_Dashboard_DetailData[i].Columns);

        form_data.append('[' + i + '].Removed', Template_Dashboard_DetailData[i].Removed);
    }
    return form_data;
}
function Template_Dashboard_DetailInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRTemplate_Dashboard_Detail("Template_Dashboard_DetailTable", rowIndex)) {
    var prevData = Template_Dashboard_DetailTable.fnGetData(rowIndex);
    var data = Template_Dashboard_DetailTable.fnGetNodes(rowIndex);
    var newData = {
        Detail_Id: prevData.Detail_Id,
        IsInsertRow: false
        ,Row_Number: $('#Template_Dashboard_DetailRow_Number').val()

        ,Columns: $('#Template_Dashboard_DetailColumns').val()


    }

    Template_Dashboard_DetailTable.fnUpdate(newData, rowIndex, null, true);
    Template_Dashboard_DetailrowCreationGrid(data, newData, rowIndex);
    $('#AddTemplate_Dashboard_Detail-form').modal({ show: false });
    $('#AddTemplate_Dashboard_Detail-form').modal('hide');
    Template_Dashboard_DetailEditRow(rowIndex);
    Template_Dashboard_DetailInsertRow(rowIndex);
    //}
}
function Template_Dashboard_DetailRemoveAddRow(rowIndex) {
    Template_Dashboard_DetailTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Template_Dashboard_Detail MultiRow


$(function () {
    function Template_Dashboard_DetailinitializeMainArray(totalCount) {
        if (Template_Dashboard_DetailDataMain.length != totalCount && !Template_Dashboard_DetailDataMainInitialized) {
            Template_Dashboard_DetailDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Template_Dashboard_DetailDataMain[i] = null;
            }
        }
    }
    function Template_Dashboard_DetailremoveFromMainArray() {
        for (var j = 0; j < Template_Dashboard_DetaildeletedItem.length; j++) {
            for (var i = 0; i < Template_Dashboard_DetailDataMain.length; i++) {
                if (Template_Dashboard_DetailDataMain[i] != null && Template_Dashboard_DetailDataMain[i].Id == Template_Dashboard_DetaildeletedItem[j]) {
                    hTemplate_Dashboard_DetailDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Template_Dashboard_DetailcopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Template_Dashboard_DetailDataMain.length; i++) {
            data[i] = Template_Dashboard_DetailDataMain[i];

        }
        return data;
    }
    function Template_Dashboard_DetailgetNewResult() {
        var newData = copyMainTemplate_Dashboard_DetailArray();

        for (var i = 0; i < Template_Dashboard_DetailData.length; i++) {
            if (Template_Dashboard_DetailData[i].Removed == null || Template_Dashboard_DetailData[i].Removed == false) {
                newData.splice(0, 0, Template_Dashboard_DetailData[i]);
            }
        }
        return newData;
    }
    function Template_Dashboard_DetailpushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Template_Dashboard_DetailDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Template_Dashboard_DetailDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }

});

//Grid GetAutocomplete



function getDropdown(elementKey) {
    var dropDown = '<select id="' + elementKey + '" class="form-control"><option value="">--Select--</option></select>';
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
    $("#ReferenceTemplate_Id").val("0");
    $('#CreateTemplate_Dashboard_Editor')[0].reset();
    ClearFormControls();
    $("#Template_IdId").val("0");
                Template_Dashboard_DetailClearGridData();

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreateTemplate_Dashboard_Editor').trigger('reset');
    $('#CreateTemplate_Dashboard_Editor').find(':input').each(function () {
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
    var $myForm = $('#CreateTemplate_Dashboard_Editor');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    if (Template_Dashboard_DetailcountRowsChecked > 0)
    {
        ShowMessagePendingRowTemplate_Dashboard_Detail();
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblTemplate_Id").text("0");
}
$(document).ready(function () {
    $("form#CreateTemplate_Dashboard_Editor").submit(function (e) {
        e.preventDefault();
        return false;
    });
	$("form#CreateTemplate_Dashboard_Editor").on('click', '#Template_Dashboard_EditorCancelar', function () {
        Template_Dashboard_EditorBackToGrid();
    });
	$("form#CreateTemplate_Dashboard_Editor").on('click', '#Template_Dashboard_EditorGuardar', function () {
		$('#Template_Dashboard_EditorGuardar').off('click');
        if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendTemplate_Dashboard_EditorData(function () {
					EjecutarValidacionesDespuesDeGuardar();
					if (!isPartial)
						Template_Dashboard_EditorBackToGrid();
					else {
						
					    if (!isMR)
					        window.opener.RefreshCatalog('Template_Dashboard_Editor', nameAttribute);
					    else {
							var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
							if(!control.hasClass('AutoComplete'))
							{
							if (control.attr("data-isfilter") == "true") {
								    eval(GetReglaFilter(control,  $(window.opener.document.getElementById('ObjectId')).val()));								    
								}
								else 
								{
									eval('window.opener.Get' + nameMR + '_Template_Dashboard_EditorItem()');
									var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
									control.html(eval('window.opener.Get' + nameMR + '_Template_Dashboard_EditorDropDown().get(0)').innerHTML);  
								}								
							}
					    }
						window.close();						
						}
				});
		}
		$('#Template_Dashboard_EditorGuardar').on('click');
    });
	$("form#CreateTemplate_Dashboard_Editor").on('click', '#Template_Dashboard_EditorGuardarYNuevo', function () {	
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation()) {
				SendTemplate_Dashboard_EditorData(function () {
					ClearControls();
					ClearAttachmentsDiv();
					ResetClaveLabel();
	                getTemplate_Dashboard_DetailData();

					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Template_Dashboard_Editor', nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_Template_Dashboard_EditorItem()');                           
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
                            control.html(eval('window.opener.Get' + nameMR + '_Template_Dashboard_EditorDropDown().get(0)').innerHTML);   
					    }	
					}						
					EjecutarValidacionesDespuesDeGuardar();				
			setIsNew();
			EjecutarValidacionesAlComienzo();
				});
			}
		}		
    });
    $("form#CreateTemplate_Dashboard_Editor").on('click', '#Template_Dashboard_EditorGuardarYCopia', function () {
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendTemplate_Dashboard_EditorData(function (currentId) {
					$("#Template_IdId").val("0");
	                Template_Dashboard_DetailClearGridData();

					ResetClaveLabel();
					$("#ReferenceTemplate_Id").val(currentId);
	                getTemplate_Dashboard_DetailData();

					EjecutarValidacionesDespuesDeGuardar();		
					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Template_Dashboard_Editor',nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_Template_Dashboard_EditorItem()');                          
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);						
							control.html(eval('window.opener.Get' + nameMR + '_Template_Dashboard_EditorDropDown().get(0)').innerHTML);                          
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



var Template_Dashboard_EditorisdisplayBusinessPropery = false;
Template_Dashboard_EditorDisplayBusinessRuleButtons(Template_Dashboard_EditorisdisplayBusinessPropery);
function Template_Dashboard_EditorDisplayBusinessRule() {
    if (!Template_Dashboard_EditorisdisplayBusinessPropery) {
        $('#CreateTemplate_Dashboard_Editor').find('.col-sm-8').each(function () {
			var div =$(this); 
			if ($(this).find('.input-group').length >0)
				div  =  $(this).find('.input-group').first().hasClass('date')? $(this): $(this).find('.input-group').first();	
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = div.data('field-id');
            var fieldName = div.data('field-name');
            var attribute = div.data('attribute');
            mainElementAttributes += '<div class="Template_Dashboard_EditordisplayBusinessPropery"><button onclick="Template_Dashboard_EditorGetBusinessRule()" type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#Template_Dashboard_EditorBusinessRule-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.Template_Dashboard_EditordisplayBusinessPropery').remove();
    }
    Template_Dashboard_EditorDisplayBusinessRuleButtons(!Template_Dashboard_EditorisdisplayBusinessPropery);
    Template_Dashboard_EditorisdisplayBusinessPropery = (Template_Dashboard_EditorisdisplayBusinessPropery ? false : true);
}
function Template_Dashboard_EditorDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}

