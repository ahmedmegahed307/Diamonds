let JsCategory =
{
    LoadCategories: function ()
    {
        Helper.AjaxCallGet("/api/CategoryApi", {}, "json", function (data)
        {
            let htmlData = "";
            for (let i = 0; i < data.length; i++)
            {
                htmlData = htmlData + JsCategory.Template1(data[i]);
            }
            $("#Categories").html(htmlData);
        },
            function ()
            {

            });
    },
    Template1:
        function (cat)
        {
            let cattegory = "  <div class='col-md-3'>";
            cattegory = cattegory + "<a class='btn btn-solid' style='width:160px'  onclick='JsProduct.FilterItems(" + cat.tbCategoryId+")' > "+cat.categoryName+"</a>";
            cattegory = cattegory + "</div>";
            cattegory = cattegory + "<br />";
          return cattegory;
       }
}
JsCategory.LoadCategories();
