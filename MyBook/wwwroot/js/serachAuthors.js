let pageNumber = 1;
let searchString = "";
checkShowMoreAuthorsBtn()
function checkShowMoreAuthorsBtn() {
    let length = $(".authorCard").length
    haveMoreAuthors = length % 10 === 0 && length!==0;
    if (!haveMoreAuthors){
        $("#showMoreAuthors").prop('disabled', true);
    }
    else {
        $("#showMoreAuthors").prop('disabled', false);
    }
}
function showMoreAuthors(srchVal){
    $.ajax(
        {
            type: "GET",
            url:`/Search/SearchAuthors?page=${++pageNumber}&searchString=${srchVal}`,
            success: function (data) {
                var $response=$(data);
                var resultDiv = $response.find("#list").html();
                $("#list").html(resultDiv);
                checkShowMoreAuthorsBtn()
            },
            error: function (data){
                alert("Чота не так пошло");
            }
        }
    )
}
