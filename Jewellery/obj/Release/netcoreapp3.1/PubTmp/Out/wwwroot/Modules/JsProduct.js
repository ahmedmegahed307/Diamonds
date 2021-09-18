let Items = [];
let JsProduct =
{

    LoadItems: function ()
    {
        Helper.AjaxCallGet("/api/ProductApi", {}, "json", function (data)
        {
            Items = data;
            console.log(data);
            let htmlData = "";
            for (let i = 0; i < data.length; i++)
            {
                htmlData = htmlData + JsProduct.Template1(data[i]);
            }
            $("#DivTemplate1").html(htmlData);
        },
            function ()
            {

            });
    },
    Template1: function (item)
    {
        let itemHtml = "<div class='col-xl-3 col-6 col-grid-box'>";
        itemHtml = itemHtml + "<div class='product-box'>";
        itemHtml = itemHtml + "<div class='img-wrapper'>";
        // testing ajax
        //itemHtml = itemHtml + "<div class='ajaxbg d-none'>";
        //itemHtml = itemHtml + "<img src='~/assets/images/ajax-loader.gif'/>";
        //itemHtml = itemHtml + " <p class='lead alert alert-info text-center d-none'>";
        //itemHtml = itemHtml + "The product has been added!";
        //itemHtml = itemHtml + "</p>";
        //itemHtml = itemHtml + "</div>";
        //
        itemHtml = itemHtml + "<div class='front'>";
        itemHtml = itemHtml + "<a href='/Details/Index/"+item.tbProductId+"'><img src='/Uploads/"+item.productImageName+"'class='img-fluid blur-up lazyload bg-img'alt=''></a>";
        itemHtml = itemHtml + "</div>";
        itemHtml = itemHtml + "<div class='cart-info cart-wrap'>";
        itemHtml = itemHtml + "<button data-toggle='modal' data-target='#addtocart' title='Add to cart'>";
        itemHtml = itemHtml + " <a href='/Cart/AddToCart/" + item.tbProductId + " '  > <i class='ti-shopping-cart'></i> </a>";
       itemHtml = itemHtml + "</button>";
        itemHtml = itemHtml + "  <a href='/WishList/AddToWishList/" + item.tbProductId + "' title='Add to Wishlist' > " ;
        itemHtml = itemHtml + "<i class='ti-heart'aria-hidden='true'></i>";
        itemHtml = itemHtml + "</a>";
        itemHtml = itemHtml + "</div>";
        itemHtml = itemHtml + "</div>";
        itemHtml = itemHtml + "<div class='product-detail'>";
        itemHtml = itemHtml + "<div>";
        itemHtml = itemHtml + "<a href='/Details/Index/"+item.tbProductId+"'>";
        itemHtml = itemHtml + "<h6>"+item.productName+"</h6>";
        itemHtml = itemHtml + "</a>";
        itemHtml = itemHtml + "<h4>$"+item.productPrice+ "</h4>";
        itemHtml = itemHtml + "</div>";
        itemHtml = itemHtml + "</div>";
        itemHtml = itemHtml + "</div>";
        itemHtml = itemHtml + "</div>";
        return itemHtml;

    }
    ,
    FilterItems: function (catId)
    {
        let newItems = $.grep(Items, function (n, i)
        { // just use arr
            return n.tbCategoryId === catId;
        });
        console.log(newItems);
        let htmlData = "";
        for (let i = 0; i < newItems.length; i++)
        {
            htmlData = htmlData + JsProduct.Template1(newItems[i]);
        }
        $("#DivTemplate1").html(htmlData);
    }
}
JsProduct.LoadItems();