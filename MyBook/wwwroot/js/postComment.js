function postComment(bookId){
    var rating = $(".stars:checked").val();
    var comment = $(".comment").val();
    $.ajax(
        {
            type: "GET",
            url: `/Book/PostComment?rating=${rating}&comment=${comment}&bookId=${bookId}`,
            error: function (data) {
                alert("Только буквы русского или английского алфавита;\n" +
                    "Длина не должна превышать 120 символов")
            }
        }
    )
    return false;
}