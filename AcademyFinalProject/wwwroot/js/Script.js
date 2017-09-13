$('input[type=date]').val('');

function goBack() {
    window.history.back();
}

$(document).ready(function () {
    $(".sumHours").val("0");
    $(".key");

    function calc() {
        var $numHours1 = Number($(".numHours1").val());
        var $numHours2 = Number($(".numHours2").val());
        var $numHours3 = Number($(".numHours3").val());
        var $numHours4 = Number($(".numHours4").val());
        var $numHours5 = Number($(".numHours5").val());
        var $numHours6 = Number($(".numHours6").val());
        $(".sumHours").val($numHours1 + $numHours2 + $numHours3 + $numHours4 + $numHours5 + $numHours6);
    }
    $(".key").keyup(function () {
        calc();
    });
});

$(document).ready(function () {
    $(".sumCost").val("0");
    $(".key");

    function calc() {
        var $numHours1 = Number($(".numHours1").val());
        var $numHours2 = Number($(".numHours2").val());
        var $numHours3 = Number($(".numHours3").val());
        var $numHours4 = Number($(".numHours4").val());
        var $numHours5 = Number($(".numHours5").val());
        var $numHours6 = Number($(".numHours6").val());

        var $numDeb1 = Number($(".numDeb1").val());
        var $numDeb2 = Number($(".numDeb2").val());
        var $numDeb3 = Number($(".numDeb3").val());
        var $numDeb4 = Number($(".numDeb4").val());
        var $numDeb5 = Number($(".numDeb5").val());
        var $numDeb6 = Number($(".numDeb6").val());
        $(".sumCost").val($numHours1 * $numDeb1 + $numHours2 * $numDeb2 + $numHours3 * $numDeb3 + $numHours4 * $numDeb4 + $numHours5 * $numDeb5 + $numHours6 * $numDeb6);
    }
    $(".key").keyup(function () {
        calc();
    });
});