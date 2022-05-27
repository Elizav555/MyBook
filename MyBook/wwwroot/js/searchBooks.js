let pageNumber = 1;
function checkShowMoreBooksBtn() {
    haveMoreAuthors = $(".bookCard").length % 10 === 0;
    console.log($(".bookCard").length)
    console.log(haveMoreAuthors)
    if (!haveMoreAuthors){
        $("#showMoreBooks").prop('disabled', true);
    }
    else {
        $("#showMoreBooks").prop('disabled', false);
    }
}
function showMoreBooks(srchVal){
    let search = srchVal
    $.ajax(
        {
            type: "GET",
            url:`/Search/SearchBooks?page=${++pageNumber}&searchString=${search}`,
            success: function (data) {
                var $response=$(data);
                var resultDiv = $response.find("#list").html();
                $("#list").html(resultDiv);
                checkShowMoreBooksBtn()
            },
            error: function (data){
                alert("Чота не так пошло");
            }
        }
    )
    return false;
}


