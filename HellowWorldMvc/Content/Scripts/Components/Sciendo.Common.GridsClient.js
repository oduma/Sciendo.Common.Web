var components = namespace("Sciendo.Common.Components");

components.SimpleGrid = function (apiUrl, gridBaseId, columnNames, columnDefintions, maxRowNumber,
    rowNumberList, sortName, gridCaption, multiSearch, enableEdit, enableAdd, enableDelete,editUrl,height) {
    jQuery('#'+ 'simple_grd_' + gridBaseId).jqGrid({
        url: apiUrl,
        datatype: 'json',
        mtype: 'get',
        colNames: columnNames,
        colModel: columnDefintions,
        pager: jQuery('#'+'simple_grd_pager_' + gridBaseId),
        rowNum: maxRowNumber,
        rowList: rowNumberList,
        sortname: sortName,
        viewrecords: true,
        sortorder: 'asc',
        caption: gridCaption,
        editurl: editUrl,
        height:height
    }).navGrid('#' + 'simple_grd_pager_' + gridBaseId, { edit: enableEdit, add: enableAdd, del: enableDelete },
   {}, // default settings for edit
   {}, // default settings for add
   {}, // delete
   {
       closeOnEscape: true, multipleSearch: multiSearch,
       closeAfterSearch: true
   }, // search options
   {})
   .inlineNav('#' + 'simple_grd_pager_' + gridBaseId);

}