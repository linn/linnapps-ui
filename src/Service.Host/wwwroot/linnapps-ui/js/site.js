// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

$(document).ready(function() {
    $("#SelectedSalesArticle").autocomplete({
        source: function(request, response) {
            $.ajax({
                url: '/linnapps-ui/products/salesarticles/search',
                type: 'GET',
                dataType: "json",
                data: { searchTerm : request.term },
                success: function(data) {
                    response($.map(data,
                        function(item) {
                            return { label : item.label, value: item.value }
                        }))}
                });
        },
        select: function(event, ui) {
            location.href = encodeURI('/linnapps-ui/Products/SalesArticles/Details?id=' + ui.item.value);
        }
    });
})