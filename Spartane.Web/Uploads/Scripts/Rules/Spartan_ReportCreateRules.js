var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
$(document).ready(function () {
    
    //NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {
	
	if(operation == 'New'){
	 $('#' + nameOfTable + 'Registration_Date' + rowIndex).val(EvaluaQuery(" select convert(varchar(11),getdate(),105)", rowIndex, nameOfTable)); 
	 $('#' + nameOfTable + 'Registration_Hour' + rowIndex).val(EvaluaQuery("select convert(varchar(8),getdate(),108)", rowIndex, nameOfTable)); 
	 $('#' + nameOfTable + 'Registration_User' + rowIndex).val(EvaluaQuery(" select GLOBAL[USERID]", rowIndex, nameOfTable));
	}

	
    //NEWBUSINESSRULE_SCREENOPENING//
}
function EjecutarValidacionesAntesDeGuardar() {
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVING//
    var rows = $('#Spartan_Report_FilterGrid tbody tr > td > a:first-child');
    for (var i = 0; i < rows.length; i++) {
        $(rows[i]).click();
    }
    Spartan_Report_FiltercountRowsChecked = 0;

    return result;
}
function EjecutarValidacionesDespuesDeGuardar() {
    //NEWBUSINESSRULE_AFTERSAVING//
}

function EjecutarValidacionesAntesDeGuardarMRSpartan_Report_Fields_Detail(nameOfTable, rowIndex) {
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Spartan_Report_Fields_Detail//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRSpartan_Report_Fields_Detail(nameOfTable, rowIndex) {
    //NEWBUSINESSRULE_AFTERSAVINGMR_Spartan_Report_Fields_Detail//
}
function EjecutarValidacionesAlEliminarMRSpartan_Report_Fields_Detail(nameOfTable, rowIndex) {
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Spartan_Report_Fields_Detail//
    return result;
}
function EjecutarValidacionesNewRowMRSpartan_Report_Fields_Detail(nameOfTable, rowIndex) {
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Spartan_Report_Fields_Detail//
    return result;
}
function EjecutarValidacionesEditRowMRSpartan_Report_Fields_Detail(nameOfTable, rowIndex) {
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Spartan_Report_Fields_Detail//
    return result;
}
function EjecutarValidacionesAntesDeGuardarMRSpartan_Report_Filter(nameOfTable, rowIndex) {
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Spartan_Report_Filter//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRSpartan_Report_Filter(nameOfTable, rowIndex) {
    //NEWBUSINESSRULE_AFTERSAVINGMR_Spartan_Report_Filter//
}
function EjecutarValidacionesAlEliminarMRSpartan_Report_Filter(nameOfTable, rowIndex) {
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Spartan_Report_Filter//
    return result;
}
function EjecutarValidacionesNewRowMRSpartan_Report_Filter(nameOfTable, rowIndex) {
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Spartan_Report_Filter//
    return result;
}
function EjecutarValidacionesEditRowMRSpartan_Report_Filter(nameOfTable, rowIndex) {
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Spartan_Report_Filter//
    return result;
}

function addDragStartOnTree() {
    CKEDITOR.document.getById('divTagsHeader').on('dragstart', function (evt) {
        var target = evt.data.getTarget().getAscendant('a', true);
        CKEDITOR.plugins.clipboard.initDragDataTransfer(evt);
        var dataTransfer = evt.data.dataTransfer;
        var logicalName = $(target.$).data('logical');
        dataTransfer.setData('node', target.$);
        dataTransfer.setData('text/html', logicalName);
    });

    CKEDITOR.document.getById('divTagsFooter').on('dragstart', function (evt) {
        var target = evt.data.getTarget().getAscendant('a', true);
        CKEDITOR.plugins.clipboard.initDragDataTransfer(evt);
        var dataTransfer = evt.data.dataTransfer;
        var logicalName = $(target.$).data('logical');
        dataTransfer.setData('node', target.$);
        dataTransfer.setData('text/html', logicalName);
    });
}

function pasteCKEDITOR(evt) {
    var node = evt.data.dataTransfer.getData('node');
    if (!node) {
        return;
    }
    var logicalName = $(node).data('logical');
    evt.data.dataValue =
        '<span>@@' + logicalName + '@@</span>';

}
function galleryDragAndDrop(mainContainer, containerColumns, containerRows, containerFunctions, dragItem) {
    $(dragItem).draggable(
        {
            revert: "invalid",
            containment: mainContainer,
            helper: "clone",
            cursor: "move",
            drag: function (event, ui) {
                $(ui.helper.prevObject).addClass("box_current");
            },
            stop: function (event, ui) {
                $(ui.helper.prevObject).removeClass("box_current");
            }
        });

    $(containerColumns).droppable({
        accept: dragItem,
        activeClass: "ui-state-highlight",
        drop: function (event, ui) {
            var node = ui.draggable;
            var properties = GetData(node);
            AddToMemory(properties, 2);
            var trs = $('#table-result tr');
            var htmlResult = '';
            var htmlTD = '';
            htmlTD += GetTD(properties, 'column');
            if (trs.length == 0) {
                htmlResult += '<tr>';
                htmlResult += '<td></td>';
                htmlResult += htmlTD;
                htmlResult += '</tr>';
                $('#table-result').append(htmlResult);
            }
            else {
                htmlResult = htmlTD;
                $('#table-result > tbody > tr:first-child').append(htmlResult);
            }
            columnsInMemory++;
        }
    });

    $(containerRows).droppable({
        accept: dragItem,
        activeClass: "ui-state-highlight",
        drop: function (event, ui) {
            var node = ui.draggable;
            var properties = GetData(node);
            AddToMemory(properties, 1);
            var trs = $('#table-result tr');
            var htmlResult = '';
            var htmlTR = '';
            htmlTR += '<tr>';
            htmlTR += GetTD(properties, 'row');
            htmlTR += '</tr>';
            if (trs.length == 0) {
                htmlResult += '<tr>';
                htmlResult += '<td></td>';
                htmlResult += '</tr>';
                htmlResult += htmlTR;
                $('#table-result').append(htmlResult);
            }
            else {
                htmlResult = htmlTR;
                $('#table-result > tbody').append(htmlResult);
            }
            rowsInMemory++;
        }
    });

    $(containerFunctions).droppable({
        accept: dragItem,
        activeClass: "ui-state-highlight",
        drop: function (event, ui) {
            var added = false;
            var node = ui.draggable;
            var properties = GetData(node);

            var htmlFunction = GetTD(properties, 'function');
            var auxFunctions = functionsInMemory;
            var index = 0;
            if (rowsInMemory == 0) {
                var htmlTR = '';
                htmlTR += '<tr>';
                htmlTR += '<td></td>';
                htmlTR += htmlFunction;
                htmlTR += '</tr>';
                $('#table-result').append(htmlTR);
                added = true;
            }
            else {
                for (var i = 0; i < rowsInMemory; i++) {
                    for (var j = 0; j < columnsInMemory; j++) {
                        if (auxFunctions == 0) {
                            index = i + 1;
                            $('#table-result tr:eq(' + index + ')').append(htmlFunction);
                            added = true;
                        }
                        auxFunctions--;
                    }
                }
            }
            if (added) {
                AddToMemory(properties, 3);
                functionsInMemory++;
            }
        }
    });
}
$('#table-result').sortable({
    items: "td",
    stop: function (event, ui) {        
        $(this).parent().find('td').each(function (i) {
            debugger;
            var path = $($(this).find('a')[0]).data('path');
            var result = $.grep(FieldsInMemory, function (e) { return e.fieldPath == path; });
            if(result.length == 1)
                result[0].orderNumber = i;
        });
    }
});

var rowsInMemory = 0;
var columnsInMemory = 0;
var functionsInMemory = 0;

function fillFieldsSaved() {
    if (FieldsInMemory.length != 0) {
        for (var i = 0; i < FieldsInMemory.length; i++) {
            if (FieldsInMemory[i].fieldType == 1) {
                var properties = FieldsInMemory[i];
                var trs = $('#table-result tr');
                var htmlResult = '';
                var htmlTR = '';
                htmlTR += '<tr>';
                htmlTR += GetTD(properties, 'row');
                htmlTR += '</tr>';
                if (trs.length == 0) {
                    htmlResult += '<tr>';
                    htmlResult += '<td></td>';
                    htmlResult += '</tr>';
                    htmlResult += htmlTR;
                    $('#table-result').append(htmlResult);
                }
                else {
                    htmlResult = htmlTR;
                    $('#table-result > tbody').append(htmlResult);
                }
                debugger;
                rowsInMemory++;
            }
        }
        for (var i = 0; i < FieldsInMemory.length; i++) {
            if (FieldsInMemory[i].fieldType == 2) {
                var properties = FieldsInMemory[i];
                var trs = $('#table-result tr');
                var htmlResult = '';
                var htmlTD = '';
                htmlTD += GetTD(properties, 'column');
                if (trs.length == 0) {
                    htmlResult += '<tr>';
                    htmlResult += '<td></td>';
                    htmlResult += htmlTD;
                    htmlResult += '</tr>';
                    $('#table-result').append(htmlResult);
                }
                else {
                    htmlResult = htmlTD;
                    $('#table-result > tbody > tr:first-child').append(htmlResult);
                }
                columnsInMemory++;
            }
        }
        for (var i = 0; i < FieldsInMemory.length; i++) {
            if (FieldsInMemory[i].fieldType == 3) {
                var properties = FieldsInMemory[i];
                var htmlFunction = GetTD(properties, 'function');
                var auxFunctions = functionsInMemory;
                debugger;
                if (rowsInMemory == 0) {
                    var htmlTR = '';
                    htmlTR += '<tr>';
                    htmlTR += '<td></td>';
                    htmlTR += htmlFunction;
                    htmlTR += '</tr>';
                    $('#table-result').append(htmlTR);
                    added = true;
                }
                else {
                    for (var j = 0; j < rowsInMemory; j++) {
                        for (var k = 0; k < columnsInMemory; k++) {
                            if (auxFunctions == 0) {
                                $('#table-result tr:eq(' + j + 1 + ')').append(htmlFunction);
                            }
                            auxFunctions--;
                        }
                    }
                }
                functionsInMemory++;
            }
        }
    }
}

function GetData(node) {
    var id = $(node).attr('id');
    var realNode = $('#jstree_espartan_metadata').jstree(true).get_node(id);
    realNode.li_attr.fieldPath = realNode.li_attr.atributteId;
    if (realNode.parents.length == 1)
        realNode.li_attr.fieldPath = realNode.li_attr.classId + "." + realNode.li_attr.fieldPath;

    jQuery.each(realNode.parents, function (i, val) {
        parent = $('#jstree_espartan_metadata').jstree(true).get_node(val);
        if (parent.id != "#")
            realNode.li_attr.fieldPath = parent.li_attr.atributteId + "." + realNode.li_attr.fieldPath;
        if (parent.parent == "#")
            realNode.li_attr.fieldPath = parent.li_attr.classId + "." + realNode.li_attr.fieldPath;
    });
    var data = {
        physicalName: $(node).attr('physicalname'),
        logicalName: $(node).attr('logicalname'),
        fieldPath: realNode.li_attr.fieldPath,
        attributeId: $(node).attr('atributteid'),
        fieldId: $(node).attr('fieldid'),
        objectName: $(node).attr('objectname'),
        className: $(node).attr('classname'),
        classId: $(node).attr('classid')
    };
    return data;
}

function GetTD(properties, type) {
    var functionShow = '';
    if (properties.functionF == 2) {
        functionShow = 'CONTEO';
    }
    if (properties.functionF == 3) {
        functionShow = 'SUMA';
    }
    if (properties.functionF == 4) {
        functionShow = 'MAX';
    }
    if (properties.functionF == 5) {
        functionShow = 'MIN';
    }
    if (properties.functionF == 6) {
        functionShow = 'PROMEDIO';
    }
    if (properties.functionF == 7) {
        functionShow = 'CONTEO DISTINTO';
    }
    var htmlTR = '';
    htmlTR += '<td style="padding:10px; cursor: pointer;" class="ui-draggable tdDraggable" draggable="true">';
    htmlTR += '<span style="margin-right: 10px;">';
    if (functionShow != '')
        htmlTR += functionShow + '(' + properties.logicalName + ')';
    else
        htmlTR += properties.logicalName;
    htmlTR += '</span>';
    htmlTR += '<a class="delete-field fa fa-remove" style="margin-left: 5px; float:right;" data-path="' + properties.fieldPath + '" data-type="' + type + '"></a>';
    htmlTR += '<a class="edit-field fa fa-pencil" style=" float:right;"';
    htmlTR += ' data-id="' + properties.fieldId + '"';
    htmlTR += ' data-title="' + properties.logicalName + '"';
    htmlTR += ' data-path="' + properties.fieldPath + '"';
    htmlTR += ' data-physical="' + properties.physicalName + '"';
    htmlTR += ' data-attributeId="' + properties.attributeId + '"';
    htmlTR += ' data-type="' + type + '"';
    htmlTR += '>';
    htmlTR += '</a>';

    htmlTR += '</td>';
    return htmlTR;
}



function AddToMemory(data, type) {
    var functionFAux = 1;
    if (type == 3) {
        functionFAux = 2;
    }
    var data = {
        physicalName: data.physicalName,
        functionF: functionFAux,
        format: 1,
        orderBy: 1,
        orderNumber: 1,
        fieldPath: data.fieldPath,
        fieldType: type,
        attributeId: data.attributeId,
        title: data.logicalName
    };
    FieldsInMemory.push(data);
}

$('#Presentation_View').change(function () {
    if ($(this).val() != '' && $('#Object').val() != '') {
        $('.liTabData').css('display', '');
        $('.liTabFilters').css('display', '');
        $('.liTabDesign').css('display', '');
    }
    else {
        $('.liTabData').css('display', 'none');
        $('.liTabFilters').css('display', 'none');
        $('.liTabDesign').css('display', 'none');
    }
});

$('#Object').change(function () {
    if ($(this).val() != '' && $('#Presentation_View').val() != '') {
        $('.liTabData').css('display', '');
        $('.liTabFilters').css('display', '');
        $('.liTabDesign').css('display', '');
    }
    else {
        $('.liTabData').css('display', 'none');
        $('.liTabFilters').css('display', 'none');
        $('.liTabDesign').css('display', 'none');
    }
});
var AdvanceFilters = [];
function GetAdvanceFilter() {
    var checks = $('.check-filter');
    for (var i = 0; i < checks.length; i++) {
        var checked = $(checks[i]).prop('checked');
        var name = $(checks[i]).parent().data('physicalname');
        var attributeid = $(checks[i]).parent().data('attributeid');
        var objectid = $(checks[i]).parent().data('objectid');
        var values = $(checks[i]).parent().find('.control-value');
        if ($(checks[i]).parent().find('.hasDatepicker').length > 0) {
            values = $(checks[i]).parent().find('.hasDatepicker');
        }		
        var pathfield = $(checks[i]).parent().data('pathfield');
        var from = '';
        var to = '';
        if (values.length > 0) {
            var dataFrom = $(values[0]).val();
            if (dataFrom != null && dataFrom.constructor.name == "Array") {
                for (var j = 0; j < dataFrom.length; j++) {
                    from += dataFrom[j] + ',';
                }
                from = from.slice(0, -1);
            }
            else
                from = dataFrom;
            if (values.length > 1) {
                to = $(values[1]).val();
            }
            AdvanceFilters.push({
                checke: checked,
                attributeId: attributeid,
                pysicalName: name,
                from: from,
                to: to,
                objectId: objectid,
                pathField: pathfield
            });
        }
    }
}

function FillAdvanceFilter() {
    for (var i = 0; i < AdvanceFilters.length; i++) {

        if (AdvanceFilters[i].objectId == $('#Object').val()) {
            $($('.filter-item[data-physicalname="' + AdvanceFilters[i].physicalName + '"]').find('.check-filter')[0]).prop('checked', AdvanceFilters[i].checke);
            if ($($('.filter-item[data-physicalname="' + AdvanceFilters[i].physicalName + '"]').find('.control-value')[0]).attr('class').indexOf('control-select2') != -1) {
                var selectedValues = AdvanceFilters[i].from.split(',');
                $($('.filter-item[data-physicalname="' + AdvanceFilters[i].physicalName + '"]').find('.control-value')[0]).select2('val', selectedValues);
            }
            else {
                $($('.filter-item[data-physicalname="' + AdvanceFilters[i].physicalName + '"]').find('.control-value')[0]).val(AdvanceFilters[i].from);
                $($('.filter-item[data-physicalname="' + AdvanceFilters[i].physicalName + '"]').find('.control-value')[1]).val(AdvanceFilters[i].to);
            }
            $('.filter-item[data-physicalname="' + AdvanceFilters[i].physicalName + '"]').attr('data-attributeid', AdvanceFilters[i].attributeId);
            $('.filter-item[data-physicalname="' + AdvanceFilters[i].physicalName + '"]').attr('data-objectid', AdvanceFilters[i].objectId);
            $('.filter-item[data-physicalname="' + AdvanceFilters[i].physicalName + '"]').attr('data-pathfield', AdvanceFilters[i].pathField);
        }
    }
}