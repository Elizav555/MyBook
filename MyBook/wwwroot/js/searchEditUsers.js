let pageNumberUsers = 1;
let searchStringUser = "";
checkShowMoreUsersBtn()
function checkShowMoreUsersBtn() {
    haveMoreAuthors = $(".userCard").length % 5 === 0;
    if (!haveMoreAuthors){
        $("#showMoreUsers").prop('disabled', true);
    }
    else {
        $("#showMoreUsers").prop('disabled', false);
    }
}
function showMoreEditUsers() {
    $.ajax(
        {
            type: "GET",
            url:`/Search/SearchEditUsers?page=${++pageNumberUsers}&searchString=${searchStringUser}`,
            success: function (data) {
                var $response=$(data);
                var resultDiv = $response.find("#list").html();
                $(".users_information").html(resultDiv);
                checkShowMoreUsersBtn()
            },
            error: function (data){
                alert("Что-то пошло не так, повторите попытку, елси проблема не исчезнет повторите через некоторое время");
            }
        }
    )
    return false;
}

function searchEditUser(){
    let searchValue = $("#searchStringUsers").val();
    console.log("change",searchValue);
    searchStringUser = searchValue;
    pageNumberUsers = 1;
    $.ajax(
        {
            type: "GET",
            url:`/Search/SearchEditUsers?page=${pageNumberUsers}&searchString=${searchStringUser}`,
            success: function (data) {
                var $response=$(data);
                var resultDiv = $response.find("#list").html();
                $(".users_information").html(resultDiv);
                checkShowMoreUsersBtn()
            },
            error: function (data){
                alert("Что-то пошло не так, повторите попытку, елси проблема не исчезнет повторите через некоторое время");
            }
        }
    )
    return false;
}