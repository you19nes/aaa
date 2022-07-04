$(document).ready(function () {
    ItemInHelper.GenrateItemInfoGrid();
});
var ItemInManager = {

};
var ItemInHelper = {
    GenrateItemInfoGrid: function () {
        $("#grdItemInfo").kendoGrid({
            dataSource: [],
            pagable: false,
            editable: {
                createAt: "bottom",
                mode:"incell"
            },
            toolbar: ["create"],
            filterable: false,
            sortable: false,
            column: ItemInHelper.GenrateItemInfoGrid(),
            navigatable: true,
            Selection:"row"
        });
    },
    GenrateItemInfoGrid: function () {
        return column = [
            { field: "Id", hidden: true },
            { field: "Items", tetle: "Item", editor; ItemInHelper.ItemDropDownEditor, template:"#=items.ItemName" },
            { field: "Qnty", tetle: "Qnty"},
            { field: "Rate", tetle: "Rate"},
            { field: "Amount", tetle: "Amount"}

        ]

    },
    ItemDropDownEditor: function (container, options) {
        $('<input required data-text-field="ItemName" data-value-fiels="ItemId" data-bind="value=' + options.field + '"/>')
            .appendTo(container)
            .KendoDropDownList({
                autoBind: false,
                optionLabel: '--Select--',
                dataSource: [
                    { ItemId: 1, ItemName: "Item-1" },
                    { ItemId: 1, ItemName: "Item-2" },
                    { ItemId: 1, ItemName: "Item-3" }
                ],
                placeholder: "Please Select"
            });
    },
};