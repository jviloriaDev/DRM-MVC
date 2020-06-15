function setFilter(tableId, tableInstance) {
    //console.log(tableInstance);
    $('#' + tableId + ' > tfoot > tr > .filterColumn').each(function () {
        //alert($(this).attr('s-spartan'));
        switch ($(this).attr('s-spartan')) {
            case "number":
                $(this).html("<input type=\"text\" class=\"numeric filterData form-control inputNumber numberBox\" />");
                break;
            case "text":
                $(this).html("<input type=\"text\" class=\"filterData form-control\"  />");
                break;
            case "checkbox":
                $(this).html("<div class=\"checkbox\"><input type=\"checkbox\" class=\"checkbox filterData form-control\"  /><label> </label></div>");
                break;
            case "date":
                $(this).html("<div class=\"input-group date\"><span class=\"input-group-addon\"><i class=\"fa fa-calendar\"></i></span><input type=\"text\" class=\"datepicker filterData form-control\"  /></div>");
                break;
            case "time":
                $(this).html("<div data-autoclose=\"true\" class=\"input-group clockpicker\"><input type=\"text\" class=\"filterData form-control\"  /><span class=\"input-group-addon\"><span class=\"fa fa-clock-o\"></span></span></div>");
                break;
            case "dropdown":
                $(this).html("<input type=\"text\" class=\"dropdown filterData form-control\"  />");
                break;
        }
    });
    // Apply the search
    tableInstance.columns().every(function () {
        var that = this;
        $('input', this.footer()).on('change', function () {
            if (that.search() !== this.value) {
                that
                    .search(($(this).prop('type') == 'checkbox' ? $(this).is(":checked") : this.value))
                    .draw();
            }
        });
        $('input', this.footer()).on('keyup', function (e) {
            var keyCode = (window.event) ? e.which : e.keyCode;
            if (keyCode == 13) {
                if (that.search() !== this.value) {
                    that
                        .search(($(this).prop('type') == 'checkbox' ? $(this).is(":checked") : this.value))
                        .draw();
                }
            }
        });
        $('select', this.footer()).on('change', function () {
            if (that.search() !== this.value) {
                that
                    .search(this.value)
                    .draw();
            }
        });
    });
}


function setFilterNew(tableId) {
  
    $('#' + tableId + ' > tfoot > tr > .filterColumn').each(function () {
        //alert($(this).attr('s-spartan'));
        switch ($(this).attr('s-spartan')) {
            case "number":
                $(this).html("<input type=\"text\" class=\"numeric filterData form-control inputNumber numberBox\" />");
                break;
            case "text":
                $(this).html("<input type=\"text\" class=\"filterData form-control\"  />");
                break;
            case "checkbox":
                $(this).html("<div><select class=\"filterData form-control\"> " +
                     "<option value=\"\" selected>"+ filterAll +"</option>" +
                      "<option value=\"true\">" + filterYes + "</option>" +
                      "<option value=\"false\">" + filterNo + "</option>" +
                    "</select>" +
                    "<label> </label></div>");
                break;
            case "date":
                $(this).html("<div class=\"input-group date\"><span class=\"input-group-addon\"><i class=\"fa fa-calendar\"></i></span><input type=\"text\" class=\"datepicker filterData form-control\"  /></div>");
                break;
            case "time":
                $(this).html("<div data-autoclose=\"true\" class=\"input-group clockpicker\"><input type=\"text\" class=\"filterData form-control\"  /><span class=\"input-group-addon\"><span class=\"fa fa-clock-o\"></span></span></div>");
                break;
            case "dropdown":
                $(this).html("<input type=\"text\" class=\"dropdown filterData form-control\"  />");
                break;
        }
    });
}

function ApplySearch(tableInstance) {
    // Apply the search
    tableInstance.columns().every(function () {
        var that = this;
        $('input', this.footer()).on('change', function () {
            if (that.search() !== this.value) {
                that
                    .search(($(this).prop('type') == 'checkbox' ? $(this).is(":checked") : this.value))
                    .draw();
            }
        });
        $('select', this.footer()).on('change', function () {
            if (that.search() !== this.value) {
                that
                    .search(this.value)
                    .draw();
            }
        });
    });
}



function setFilterState(tableId, oData) {

    var i = 0;
    $('#' + tableId + ' > tfoot > tr > td').each(function () {
        //alert($(this).attr('s-spartan'));
        switch ($(this).attr('s-spartan')) {
            case "number":
                $(this).find('input').val(oData.columns[i].search.search);
                //$(this).html("<input type=\"text\" class=\"numeric filterData form-control inputNumber numberBox\" />");
                break;
            case "text":
                $(this).find('input').val(oData.columns[i].search.search);
                //$(this).html("<input type=\"text\" class=\"filterData form-control\"  />");
                break;
            case "checkbox":
                $(this).find('input').prop('checked', true);
                //$(this).html("<div class=\"checkbox\"><input type=\"checkbox\" class=\"checkbox filterData form-control\"  /><label> </label></div>");
                break;
            case "date":
                $(this).find('input').val(oData.columns[i].search.search);
                //$(this).html("<div class=\"input-group date\"><span class=\"input-group-addon\"><i class=\"fa fa-calendar\"></i></span><input type=\"text\" class=\"datepicker filterData form-control\"  /></div>");
                break;
            case "time":
                $(this).find('input').val(oData.columns[i].search.search);
                //$(this).html("<div data-autoclose=\"true\" class=\"input-group clockpicker\"><input type=\"text\" class=\"datepicker filterData form-control\"  /><span class=\"input-group-addon\"><span class=\"fa fa-clock-o\"></span></span></div>");
                break;
            case "staticdropdown":
                $(this).find('select').val(oData.columns[i].search.search);
                //$(this).html("<input type=\"text\" class=\"dropdown filterData form-control\"  />");
                break;
        }
        i += 1;
    });
}