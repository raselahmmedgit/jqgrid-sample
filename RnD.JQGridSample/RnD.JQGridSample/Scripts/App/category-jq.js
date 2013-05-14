$(function () {

    $("#categoryJQGrid").jqGrid({
        url: "/Category/GetCategories",
        datatype: "json",
        mtype: 'POST',
        colNames: ['CategoryId',
				  'CategoryId',
                  'Name',
				 'Details', 'Edit', 'Delete'],
        colModel: [
			{ name: 'CategoryId', index: 'CategoryId', key: true, width: 0, hidden: true },
			{ name: 'CategoryId', index: 'CategoryId', width: 0, align: 'left', hidden: true },
            { name: 'Name', index: 'Name', width: 250, align: 'left', hidden: false },
			{ name: 'Details', index: 'Details', width: 100, align: 'center' },
            { name: 'Edit', index: 'Edit', width: 100, align: 'center' },
			{ name: 'Delete', index: 'Delete', width: 100, align: 'center' }
			],
        rowNum: 10,                                //default page size
        rowList: [10, 20, 30, 40, 50],                 //option of page size
        height: "100%",                          //grid height
        width: "100%",                          //grid width
        sortname: 'id',                     //default sort column name
        sortorder: "desc",                       //sorting order
        viewrecords: true,                         //by default records show?
        multiselect: false                        //checkbox list

    });

});