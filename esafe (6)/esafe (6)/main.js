$(document).ready(function(){ $('.nav-item:not(.active)').hover(

    function(){ $(this).addClass('active2') },
    function(){ $(this).removeClass('active2') }
);});