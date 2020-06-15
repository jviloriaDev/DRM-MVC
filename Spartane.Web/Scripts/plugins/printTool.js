var printTool = (function () {

    /**
     * Print dashboard (Home/index)
     * param withEmptyCells => - true = with empty cells
                               - false or null = no empty cells
     */
    var printDashboard = function (withEmptyCells) {
        var $printZone = $(hiddenClone($("#printZone")[0]));
        var $dashboardContainer = $("#dashboard-container");
        var imgSize = null;

        //remove buttons
        $printZone.find(".btn").each(function (idx, btn) {
            var $btn = $(btn);

            if (!$btn.hasClass("active"))
                $btn.remove()
        });

        if (withEmptyCells == false || withEmptyCells == null) {

            //remove emtpy cells
            $.when($printZone.find(".dashboard-row").each(function (idx, div) {
                var $div = $(div);

                $div.find("i.fa.fa-plus.fa-4x").parent().parent().remove();
                if ($div.children().length == 0)
                    $div.remove();

            })).then(function () {
                convertToPdf($printZone[0], resize($printZone))
            }, null);

        }
        else
            convertToPdf($printZone[0], resize($printZone))

    }

    /**
     * Print original element
     *param elem => DOM element
     */
    var printElem = function (elem) {
        html2canvas(elem, {
            dpi: 144,
            onrendered: function (canvas) {
                var imgData = canvas.toDataURL(
                    'image/png');
                var doc = new jsPDF('p', 'mm');
                doc.addImage(imgData, 'PNG', 10, 10);
                doc.save('spartane-file.pdf');
            }
        });
    }

    //private functions
    function convertToPdf(elem, size) {
        html2canvas(elem, {
            dpi: 144,
            scale: 2,
            onrendered: function (canvas, w, h) {
                var imgData = canvas.toDataURL(
                    'image/png');
                var doc = new jsPDF('p', 'mm');
                doc.addImage(imgData, 'PNG', 2, 2, size.width, size.height);
                doc.save('spartane-file.pdf');
                $(elem).remove();
            }
        });
    }

    function hiddenClone(element) {
        var clone = $(element).clone();
        $(clone).find("input").each(function (id, item) { $(item).attr("id", Math.random()) })
        $(clone).attr("style", "position: 'relative'; top:0;left:0;")
        $("body").append(clone);

        return $(clone)[0];
    }

    function resize($printZone) {
        var maxSize = 0;
        var width, height = 0;
        var parentSize = $printZone.width();
        var rowLength = $printZone.find(".dashboard-row").length

        $.when($printZone.find(".dashboard-row").each(function (idx, div) {
            var $div = $(div);
            var rowSize = 0;

            $.when($div.children(".dashboard-cell").each(function (idx, cell) {
                rowSize = rowSize + $(cell).width();

            })).then(function () {
                if (rowSize > maxSize)
                    maxSize = rowSize;
            })
        })).then(
            function () {
                var porc = maxSize * 100 / parentSize;

                if (porc > 90 && rowLength == 1) {
                    width = 190;
                    height = 110;
                }
                else if (porc > 90 && rowLength > 1) {
                    width = 190;
                    height = 160;
                }
                else if (porc > 60 && porc < 90) {
                    width = 260;
                    height = 140;
                }
                else if (porc > 40 && porc < 60) {
                    width = 260;
                    height = 140;
                }
                else if (porc < 40) {
                    width = 280;
                    height = 240;
                }
                else {
                    width = 150;
                    height = 100;
                }


            }, null);

        return {
            width,
            height
        }
    }

    return {
        printDashboard: printDashboard,
        printElem: printElem
    };
})();