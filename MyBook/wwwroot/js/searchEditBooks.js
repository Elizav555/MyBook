let pageNumber = 1;
function showMoreEditBooks() {
    alert("ABOBA")
    $.ajax(
        {
            type: "GET",
            url:`/Search/SearchEditBooks?page=${++pageNumber}`,
            success: function (data) {
                var $response=$(data);
                var resultDiv = $response.find("#list").html();
                console.log(resultDiv)
                $(".books_information").append(resultDiv);
            },
            error: function (data){
                alert("Чота не так пошло");
            }
        }
    )
}
