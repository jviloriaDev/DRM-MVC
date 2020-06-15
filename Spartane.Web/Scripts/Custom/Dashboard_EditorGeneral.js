

//Begin Declarations for Foreigns fields for Dashboard_Config_Detail MultiRow
var Dashboard_Config_DetailcountRowsChecked = 0;


function GetInsertDashboard_Config_DetailRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";
    columnData[0] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Dashboard_Config_Detail_Report_Id Report_Id').attr('id', 'Dashboard_Config_Detail_Report_Id_' + index).attr('data-field', 'Report_Id');
    columnData[1] = $($.parseHTML(inputData)).addClass('Dashboard_Config_Detail_Report_Name Report_Name').attr('id', 'Dashboard_Config_Detail_Report_Name_' + index).attr('data-field', 'Report_Name');
    columnData[2] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Dashboard_Config_Detail_ConfigRow ConfigRow').attr('id', 'Dashboard_Config_Detail_ConfigRow_' + index).attr('data-field', 'ConfigRow');
    columnData[3] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Dashboard_Config_Detail_ConfigColumn ConfigColumn').attr('id', 'Dashboard_Config_Detail_ConfigColumn_' + index).attr('data-field', 'ConfigColumn');


    initiateUIControls();
    return columnData;
}

function Dashboard_Config_DetailInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDashboard_Config_Detail("Dashboard_Config_Detail_", "_" + rowIndex)) {
    var iPage = Dashboard_Config_DetailTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Dashboard_Config_Detail';
    var prevData = Dashboard_Config_DetailTable.fnGetData(rowIndex);
    var data = Dashboard_Config_DetailTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Detail_Id: prevData.Detail_Id,
        IsInsertRow: false
        ,Report_Id: data.childNodes[counter++].childNodes[0].value
        ,Report_Name:  data.childNodes[counter++].childNodes[0].value
        ,ConfigRow: data.childNodes[counter++].childNodes[0].value
        ,ConfigColumn: data.childNodes[counter++].childNodes[0].value

    }
    Dashboard_Config_DetailTable.fnUpdate(newData, rowIndex, null, true);
    Dashboard_Config_DetailrowCreationGrid(data, newData, rowIndex);
    Dashboard_Config_DetailTable.fnPageChange(iPage);
    Dashboard_Config_DetailcountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDashboard_Config_Detail("Dashboard_Config_Detail_", "_" + rowIndex);
  }
}

function Dashboard_Config_DetailCancelRow(rowIndex) {
    var prevData = Dashboard_Config_DetailTable.fnGetData(rowIndex);
    var data = Dashboard_Config_DetailTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Dashboard_Config_DetailTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Dashboard_Config_DetailrowCreationGrid(data, prevData, rowIndex);
    }
	showDashboard_Config_DetailGrid(Dashboard_Config_DetailTable.fnGetData());
    Dashboard_Config_DetailcountRowsChecked--;
	initiateUIControls();
}

function GetDashboard_Config_DetailFromDataTable() {
    var Dashboard_Config_DetailData = [];
    var gridData = Dashboard_Config_DetailTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Dashboard_Config_DetailData.push({
                Detail_Id: gridData[i].Detail_Id
                ,Report_Id: gridData[i].Report_Id
                ,Report_Name: gridData[i].Report_Name
                ,ConfigRow: gridData[i].ConfigRow
                ,ConfigColumn: gridData[i].ConfigColumn

                ,Removed: false
            });
    }

    for (i = 0; i < removedDashboard_Config_DetailData.length; i++) {
        if (removedDashboard_Config_DetailData[i] != null && removedDashboard_Config_DetailData[i].Detail_Id > 0)
            Dashboard_Config_DetailData.push({
                Detail_Id: removedDashboard_Config_DetailData[i].Detail_Id
                ,Report_Id: removedDashboard_Config_DetailData[i].Report_Id
                ,Report_Name: removedDashboard_Config_DetailData[i].Report_Name
                ,ConfigRow: removedDashboard_Config_DetailData[i].ConfigRow
                ,ConfigColumn: removedDashboard_Config_DetailData[i].ConfigColumn

                , Removed: true
            });
    }	

    return Dashboard_Config_DetailData;
}

function Dashboard_Config_DetailEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Dashboard_Config_DetailTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Dashboard_Config_DetailcountRowsChecked++;
    var Dashboard_Config_DetailRowElement = "Dashboard_Config_Detail_" + rowIndex.toString();
    var prevData = Dashboard_Config_DetailTable.fnGetData(rowIndexTable );
    var row = Dashboard_Config_DetailTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Dashboard_Config_Detail_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Dashboard_Config_DetailGetUpdateRowControls(prevData, "Dashboard_Config_Detail_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Dashboard_Config_DetailRowElement + "')){ Dashboard_Config_DetailInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a  onclick='Dashboard_Config_DetailCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Dashboard_Config_DetailGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Dashboard_Config_DetailGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    $('.Dashboard_Config_Detail' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    setDashboard_Config_DetailValidation();
    initiateUIControls();
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDashboard_Config_Detail(nameOfTable, rowIndexFormed);
    }
}

function Dashboard_Config_DetailfnOpenAddRowPopUp() {
    var currentRowIndex = Dashboard_Config_DetailTable.fnGetData().length;
    Dashboard_Config_DetailfnClickAddRow();
    GetAddDashboard_Config_DetailPopup(currentRowIndex, 0);
}

function Dashboard_Config_DetailEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Dashboard_Config_DetailTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Dashboard_Config_DetailRowElement = "Dashboard_Config_Detail_" + rowIndex.toString();
    var prevData = Dashboard_Config_DetailTable.fnGetData(rowIndexTable);
    GetAddDashboard_Config_DetailPopup(rowIndex, 1, prevData.Detail_Id);
    $('#Dashboard_Config_DetailReport_Id').val(prevData.Report_Id);
    $('#Dashboard_Config_DetailReport_Name').val(prevData.Report_Name);
    $('#Dashboard_Config_DetailConfigRow').val(prevData.ConfigRow);
    $('#Dashboard_Config_DetailConfigColumn').val(prevData.ConfigColumn);

    initiateUIControls();

}

function Dashboard_Config_DetailAddInsertRow() {
    if (Dashboard_Config_DetailinsertRowCurrentIndex < 1)
    {
        Dashboard_Config_DetailinsertRowCurrentIndex = 1;
    }
    return {
        Detail_Id: null,
        IsInsertRow: true
        ,Report_Id: ""
        ,Report_Name: ""
        ,ConfigRow: ""
        ,ConfigColumn: ""

    }
}

function Dashboard_Config_DetailfnClickAddRow() {
    Dashboard_Config_DetailcountRowsChecked++;
    Dashboard_Config_DetailTable.fnAddData(Dashboard_Config_DetailAddInsertRow(), true);
    Dashboard_Config_DetailTable.fnPageChange('last');
    initiateUIControls();
	 var tag = $('#Dashboard_Config_DetailGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    $('#Dashboard_Config_DetailGrid tbody tr:nth-of-type(' + (Dashboard_Config_DetailinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDashboard_Config_Detail("Dashboard_Config_Detail_", "_" + Dashboard_Config_DetailinsertRowCurrentIndex);
}

function Dashboard_Config_DetailClearGridData() {
    Dashboard_Config_DetailData = [];
    Dashboard_Config_DetaildeletedItem = [];
    Dashboard_Config_DetailDataMain = [];
    Dashboard_Config_DetailDataMainPages = [];
    Dashboard_Config_DetailnewItemCount = 0;
    Dashboard_Config_DetailmaxItemIndex = 0;
    $("#Dashboard_Config_DetailGrid").DataTable().clear();
    $("#Dashboard_Config_DetailGrid").DataTable().destroy();
}

//Used to Get Spartan Dashboard Editor Information
function GetDashboard_Config_Detail() {
    var form_data = new FormData();
    for (var i = 0; i < Dashboard_Config_DetailData.length; i++) {
        form_data.append('[' + i + '].Detail_Id', Dashboard_Config_DetailData[i].Detail_Id);
        form_data.append('[' + i + '].Report_Id', Dashboard_Config_DetailData[i].Report_Id);
        form_data.append('[' + i + '].Report_Name', Dashboard_Config_DetailData[i].Report_Name);
        form_data.append('[' + i + '].ConfigRow', Dashboard_Config_DetailData[i].ConfigRow);
        form_data.append('[' + i + '].ConfigColumn', Dashboard_Config_DetailData[i].ConfigColumn);

        form_data.append('[' + i + '].Removed', Dashboard_Config_DetailData[i].Removed);
    }
    return form_data;
}
function Dashboard_Config_DetailInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDashboard_Config_Detail("Dashboard_Config_DetailTable", rowIndex)) {
    var prevData = Dashboard_Config_DetailTable.fnGetData(rowIndex);
    var data = Dashboard_Config_DetailTable.fnGetNodes(rowIndex);
    var newData = {
        Detail_Id: prevData.Detail_Id,
        IsInsertRow: false
        ,Report_Id: $('#Dashboard_Config_DetailReport_Id').val()

        ,Report_Name: $('#Dashboard_Config_DetailReport_Name').val()
        ,ConfigRow: $('#Dashboard_Config_DetailConfigRow').val()

        ,ConfigColumn: $('#Dashboard_Config_DetailConfigColumn').val()


    }

    Dashboard_Config_DetailTable.fnUpdate(newData, rowIndex, null, true);
    Dashboard_Config_DetailrowCreationGrid(data, newData, rowIndex);
    $('#AddDashboard_Config_Detail-form').modal({ show: false });
    $('#AddDashboard_Config_Detail-form').modal('hide');
    Dashboard_Config_DetailEditRow(rowIndex);
    Dashboard_Config_DetailInsertRow(rowIndex);
    //}
}
function Dashboard_Config_DetailRemoveAddRow(rowIndex) {
    Dashboard_Config_DetailTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Dashboard_Config_Detail MultiRow


$(function () {
    function Dashboard_Config_DetailinitializeMainArray(totalCount) {
        if (Dashboard_Config_DetailDataMain.length != totalCount && !Dashboard_Config_DetailDataMainInitialized) {
            Dashboard_Config_DetailDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Dashboard_Config_DetailDataMain[i] = null;
            }
        }
    }
    function Dashboard_Config_DetailremoveFromMainArray() {
        for (var j = 0; j < Dashboard_Config_DetaildeletedItem.length; j++) {
            for (var i = 0; i < Dashboard_Config_DetailDataMain.length; i++) {
                if (Dashboard_Config_DetailDataMain[i] != null && Dashboard_Config_DetailDataMain[i].Id == Dashboard_Config_DetaildeletedItem[j]) {
                    hDashboard_Config_DetailDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Dashboard_Config_DetailcopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Dashboard_Config_DetailDataMain.length; i++) {
            data[i] = Dashboard_Config_DetailDataMain[i];

        }
        return data;
    }
    function Dashboard_Config_DetailgetNewResult() {
        var newData = copyMainDashboard_Config_DetailArray();

        for (var i = 0; i < Dashboard_Config_DetailData.length; i++) {
            if (Dashboard_Config_DetailData[i].Removed == null || Dashboard_Config_DetailData[i].Removed == false) {
                newData.splice(0, 0, Dashboard_Config_DetailData[i]);
            }
        }
        return newData;
    }
    function Dashboard_Config_DetailpushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Dashboard_Config_DetailDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Dashboard_Config_DetailDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
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
    $("#ReferenceDashboard_Id").val("0");
    $('#CreateDashboard_Editor')[0].reset();
    ClearFormControls();
    $("#Dashboard_IdId").val("0");
                Dashboard_Config_DetailClearGridData();

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreateDashboard_Editor').trigger('reset');
    $('#CreateDashboard_Editor').find(':input').each(function () {
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
    var $myForm = $('#CreateDashboard_Editor');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    if (Dashboard_Config_DetailcountRowsChecked > 0)
    {
        ShowMessagePendingRowDashboard_Config_Detail();
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblDashboard_Id").text("0");
}
$(document).ready(function () {
    $("form#CreateDashboard_Editor").submit(function (e) {
        e.preventDefault();
        return false;
    });
	$("form#CreateDashboard_Editor").on('click', '#Dashboard_EditorCancelar', function () {
        Dashboard_EditorBackToGrid();
    });
	$("form#CreateDashboard_Editor").on('click', '#Dashboard_EditorGuardar', function () {
		$('#Dashboard_EditorGuardar').off('click');
        if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendDashboard_EditorData(function () {
					EjecutarValidacionesDespuesDeGuardar();
					if (!isPartial)
						Dashboard_EditorBackToGrid();
					else {
						
					    if (!isMR)
					        window.opener.RefreshCatalog('Dashboard_Editor', nameAttribute);
					    else {
							var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
							if(!control.hasClass('AutoComplete'))
							{
							if (control.attr("data-isfilter") == "true") {
								    eval(GetReglaFilter(control,  $(window.opener.document.getElementById('ObjectId')).val()));								    
								}
								else 
								{
									eval('window.opener.Get' + nameMR + '_Dashboard_EditorItem()');
									var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
									control.html(eval('window.opener.Get' + nameMR + '_Dashboard_EditorDropDown().get(0)').innerHTML);  
								}								
							}
					    }
						window.close();						
						}
				});
		}
		$('#Dashboard_EditorGuardar').on('click');
    });
	$("form#CreateDashboard_Editor").on('click', '#Dashboard_EditorGuardarYNuevo', function () {	
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation()) {
				SendDashboard_EditorData(function () {
					ClearControls();
					ClearAttachmentsDiv();
					ResetClaveLabel();
	                getDashboard_Config_DetailData();

					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Dashboard_Editor', nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_Dashboard_EditorItem()');                           
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
                            control.html(eval('window.opener.Get' + nameMR + '_Dashboard_EditorDropDown().get(0)').innerHTML);   
					    }	
					}						
					EjecutarValidacionesDespuesDeGuardar();				
			setIsNew();
			EjecutarValidacionesAlComienzo();
				});
			}
		}		
    });
    $("form#CreateDashboard_Editor").on('click', '#Dashboard_EditorGuardarYCopia', function () {
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendDashboard_EditorData(function (currentId) {
					$("#Dashboard_IdId").val("0");
	                Dashboard_Config_DetailClearGridData();

					ResetClaveLabel();
					$("#ReferenceDashboard_Id").val(currentId);
	                getDashboard_Config_DetailData();

					EjecutarValidacionesDespuesDeGuardar();		
					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Dashboard_Editor',nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_Dashboard_EditorItem()');                          
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);						
							control.html(eval('window.opener.Get' + nameMR + '_Dashboard_EditorDropDown().get(0)').innerHTML);                          
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



var Dashboard_EditorisdisplayBusinessPropery = false;
Dashboard_EditorDisplayBusinessRuleButtons(Dashboard_EditorisdisplayBusinessPropery);
function Dashboard_EditorDisplayBusinessRule() {
    if (!Dashboard_EditorisdisplayBusinessPropery) {
        $('#CreateDashboard_Editor').find('.col-sm-8').each(function () {
			var div =$(this); 
			if ($(this).find('.input-group').length >0)
				div  =  $(this).find('.input-group').first().hasClass('date')? $(this): $(this).find('.input-group').first();	
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = div.data('field-id');
            var fieldName = div.data('field-name');
            var attribute = div.data('attribute');
            mainElementAttributes += '<div class="Dashboard_EditordisplayBusinessPropery"><button onclick="Dashboard_EditorGetBusinessRule()" type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#Dashboard_EditorBusinessRule-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.Dashboard_EditordisplayBusinessPropery').remove();
    }
    Dashboard_EditorDisplayBusinessRuleButtons(!Dashboard_EditorisdisplayBusinessPropery);
    Dashboard_EditorisdisplayBusinessPropery = (Dashboard_EditorisdisplayBusinessPropery ? false : true);
}
function Dashboard_EditorDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}

