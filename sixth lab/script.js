$(document).ready(function(){
    var picWidth = 200;
    var position = 0;
    var popupDiv = document.getElementById("pop-up-id");
    var popupImg = document.getElementById("pop-up-img");

    $("li").each(function() {
        position += picWidth;
        $(this).css("left",position);
    });

    $("img").click(function(){
       var imag = $(this).attr('src');
       popupDiv.style.display = 'block';
       popupImg.src = imag;
       $("li").clearQueue();
       $("li").stop();
    });

    popupImg.onclick=function(){
        popupDiv.style.display='none';
        slide();
    }

    function slide() {
        $("li").animate({"left":"+=10px"}, 100, again);
    }

    function again() {
        var left = $(this).offset().left - 200;
        if (left >= 1400) {
            $(this).css("left",left - 1400);
        }
        slide();
    }

    slide();
});