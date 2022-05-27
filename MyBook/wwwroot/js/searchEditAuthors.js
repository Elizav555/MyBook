let pageNumberAuthors = 1;
let haveMoreAuthors = true;
let searchStringAuthor = "";

function checkShowMoreAuthorsBtn() {
    haveMoreAuthors = $(".authorCard").length % 10 === 0;
    console.log($(".authorCard").length)
    console.log(haveMoreAuthors)
    if (!haveMoreAuthors){
        $("#showMoreAuthors").prop('disabled', true);
    }
    else {
        $("#showMoreAuthors").prop('disabled', false);
    }
}
function showMoreEditAuthors() {
    $.ajax(
        {
            type: "GET",
            url: `/Search/SearchEditAuthors?page=${++pageNumberAuthors}&searchString=${searchStringAuthor}`,
            success: function (data) {
                var $response = $(data);
                var resultDiv = $response.find("#list").html();
                $(".author_information").html(resultDiv);
                checkShowMoreAuthorsBtn();
                    },
            error: function (data) {
                alert("Чота не так пошло");
            }
        }
    )
    return false;
}

function searchEditAuthor() {
    let searchValue = $("#searchString").val();
    console.log("change", searchValue);
    searchStringAuthor = searchValue;
    pageNumberAuthors = 1
    $.ajax(
        {
            type: "GET",
            url: `/Search/SearchEditAuthors?page=${pageNumberAuthors}&searchString=${searchStringAuthor}`,
            success: function (data) {
                var $response = $(data);
                var resultDiv = $response.find("#list").html();
                $(".author_information").html(resultDiv);
                checkShowMoreAuthorsBtn()
            },
            error: function (data) {
                alert("Что-то пошло не так, повторите попытку, елси проблема не исчезнет повторите через некоторое время");
            }
        }
    )
    return false;
}