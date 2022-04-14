let pageNumber = 0;
function showMoreAuthors(){
    $.ajax(
        {
            type: "GET",
            url:`/Search/SearchAuthors?page=${++pageNumber}`,
            success: function (data) {
                var $response=$(data);
                console.log(data)
                var resultDiv = $response.find("#list").html();
                $("#list").append(resultDiv);
            },
            error: function (data){
                alert("Чота не так пошло");
            }
        }
    )
}
