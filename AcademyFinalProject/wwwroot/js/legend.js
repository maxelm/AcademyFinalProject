$(function(){
    $('legend').click(function(){  
        $(this).nextAll('div').toggle();
        $(this).hasClass('hideFieldset')?($(this).attr("class", "showFieldset")):($(this).attr("class", "hideFieldset"));
    });
})