let pageNumber = 1;
let searchString = "";
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
function showMoreEditBooks() {
    $.ajax(
        {
            type: "GET",
            url: `/Search/SearchEditBooks?page=${++pageNumber}&searchString=${searchString}`,
            success: function (data) {
                var $response = $(data);
                var resultDiv = $response.find("#list").html();
                $(".books_information").html(resultDiv);
                checkShowMoreBooksBtn();
            },
            error: function (data) {
                alert("Что-то пошло не так, повторите попытку, елси проблема не исчезнет повторите через некоторое время");
            }
        }
    )
    return false;
}

function searchEditBook() {
    searchValue = $("#searchStringBooks").val();
    console.log("change", searchValue);
    searchString = searchValue;
    pageNumber = 1
    $.ajax(
        {
            type: "GET",
            url: `/Search/SearchEditBooks?page=${pageNumber}&searchString=${searchString}`,
            success: function (data) {
                var $response = $(data);
                var resultDiv = $response.find("#list").html();
                $(".books_information").html(resultDiv);
                checkShowMoreBooksBtn();
            },
            error: function (data) {
                alert("Что-то пошло не так, повторите попытку, елси проблема не исчезнет повторите через некоторое время");
            }
        }
    )
    return false;
}