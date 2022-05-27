let pageNumber = 1;
checkShowMoreBooksBtn()
function checkShowMoreBooksBtn() {
    let length = $(".book_informat").length
    let haveMoreBooks = length % 10 === 0 && length!==0;
    console.log(length)
    console.log(haveMoreBooks)
    if (!haveMoreBooks){
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


