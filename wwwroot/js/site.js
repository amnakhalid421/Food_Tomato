$(function () {
    function toast(message) {
        const el = $(`<div class="toast-lite">${message}</div>`);
        $("body").append(el);
        setTimeout(() => el.addClass("show"), 10);
        setTimeout(() => el.removeClass("show").remove(), 2200);
    }

    $(document).on("click", ".add-to-cart", function () {
        const foodItemId = $(this).data("food-id");
        $.post("/Cart/Add", { foodItemId, quantity: 1 })
            .done(res => toast(res.message || "Added to cart."))
            .fail(() => window.location.href = "/Account/Login");
    });

    $(document).on("change", ".cart-qty", function () {
        const input = $(this);
        $.post("/Cart/UpdateQuantity", { cartItemId: input.data("cart-id"), quantity: input.val() })
            .done(res => {
                $("#cart-total").text("$" + Number(res.total).toFixed(2));
                toast(res.message);
                location.reload();
            });
    });

    $(document).on("click", ".remove-cart", function () {
        const cartItemId = $(this).data("cart-id");
        $.post("/Cart/Remove", { cartItemId })
            .done(res => {
                $(`[data-cart-row="${cartItemId}"]`).fadeOut(180, function () { $(this).remove(); });
                $("#cart-total").text("$" + Number(res.total).toFixed(2));
                toast(res.message);
            });
    });

    let searchTimer;
    function loadMenu() {
        const data = { categoryId: $("#categoryId").val(), search: $("#search").val() };
        $("#menu-results").addClass("loading");
        $.get("/Menu/Search", data)
            .done(html => $("#menu-results").html(html))
            .always(() => $("#menu-results").removeClass("loading"));
    }

    $(document).on("input", "#search", function () {
        clearTimeout(searchTimer);
        searchTimer = setTimeout(loadMenu, 250);
    });

    $(document).on("click", ".category-filter", function () {
        $(".category-filter").removeClass("active");
        $(this).addClass("active");
        $("#categoryId").val($(this).data("category"));
        loadMenu();
    });

    $(document).on("change", ".order-status", function () {
        const select = $(this);
        $.post("/Admin/Orders/UpdateStatus", { orderId: select.data("order-id"), status: select.val() })
            .done(res => toast("Order status updated to " + res.status + "."));
    });
});
