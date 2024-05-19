$(document).ready(function () {
    $("#clearNumbersButton").click(function () {
        $.post("home/clearNumbers", function (_, success) {
            if (success) {
                $("#numberList").empty();
                $("#numberCount").text("0");
                $("#numberSum").text("Not Summed");
            }
        });
    });
    $("#addNumberButton").click(function () {
        $.post("home/addNumber", function (data, success) {
            if (success) {
                $("#numberList").append("<li>" + data.number + "</li>");
                $("#numberCount").text(data.count);
            }
        });
    });

    $("#sumNumbersButton").click(function () {
        $.post("home/SumNumbers", function (data, success) {
            if (success) {
                $("#numberSum").text(data.sum);
            }
        });
    });
});
