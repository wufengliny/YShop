
$(function() {

    //导航js 
	 
   $(".top_nav li").each(function(){
      $(this).hover(function(){ 
	  
		 $(this).find(".sub").filter(':not(:animated)').slideDown(300);
		 
		 
		},function(){ 
		 $(this).find(".sub").slideUp('fast');
		 
		}) 

    });
	

	$("#focusIndex1").show();

	$("#focusBar li").css("width",$(window).width());

	$("a.arrL").mouseover(function(){stopFocusAm();}).mouseout(function(){starFocustAm();});

	$("a.arrR").mouseover(function(){stopFocusAm();}).mouseout(function(){starFocustAm();});

	$("#focusBar li").mouseover(function(){stopFocusAm();}).mouseout(function(){starFocustAm();});

	starFocustAm();

	$(".gray").each(function(){
      $(this).hover(function(){ 
		 $(this).toggleClass("gray");
		},function(){ 
		 $(this).toggleClass("gray");
		}) 

    });
	
	$(window).scroll(function(){
      var scrollTop = $(document).scrollTop();
	   if(scrollTop > 850){
		$(".topHeader").css("background","#fff");
		$(".topHeader").css("box-shadow","#666 0px 0px 5px");
	   } else {
		$(".topHeader").css("background","url(images/h_bg.png)");
		$(".topHeader").css("box-shadow","none");
	   }
	   
	  });

});

	

/*------focus-------*/

$("#focusBar").hover(

	function () {

		$("#focusBar .arrL").stop(false,true);

		$("#focusBar .arrR").stop(false,true);

		$("#focusBar .arrL").animate({ left: 0}, { duration: 600 });

		$("#focusBar .arrR").animate({ right: 0}, { duration: 600 });

	}, function () {

		$("#focusBar .arrL").stop(false,true);

		$("#focusBar .arrR").stop(false,true);

		$("#focusBar .arrL").animate({ left: -52}, { duration: 600 });

		$("#focusBar .arrR").animate({ right: -52}, { duration: 600 });

	}

);



var timerFID;



function nextPage() {

	changeFocus(true);

}

function prePage() {

	changeFocus(false);

}



var currentFocusI=1;

var changeingFocus = false;

function changeFocus(dir) {

	if($("#focusBar li").length <= 1) return;

	if(changeingFocus) return;

	changeingFocus = true;

	

	$("#focusIndex"+nextI).stop(false,true);

	$("#focusIndex"+nextI+" .focusL").stop(false,true);

	$("#focusIndex"+nextI+" .focusR").stop(false,true);

	

	var nextI = dir?currentFocusI+1:currentFocusI-1;

	nextI = nextI>$("#focusBar li").length?1:(nextI<1?$("#focusBar li").length:nextI);

	//var focusWidth = $(window).width()>1000?1000:$(window).width();

	$("#focusIndex"+currentFocusI).css("width",$(window).width());

	$("#focusIndex"+nextI).css("width",$(window).width());

	if(dir) {

		$("#focusIndex"+nextI).css("left",$(window).width());

		$("#focusIndex"+nextI+" .focusL").css("left",$(window).width()/2);

		$("#focusIndex"+nextI+" .focusR").css("left",$(window).width()/2);

		$("#focusIndex"+currentFocusI).show();

		$("#focusIndex"+nextI).show();

		

		$("#focusIndex"+currentFocusI+" .focusL").animate({left: -($(window).width()/2+1200)},300,'easeInExpo');

		$("#focusIndex"+currentFocusI+" .focusR").animate({left: -($(window).width()/2+1200)},600,'easeInExpo',function(){

				$("#focusIndex"+nextI+" .focusL").animate({left: -600},1000,'easeInOutCirc');

				$("#focusIndex"+nextI+" .focusR").animate({left: -600},1200,'easeInOutCirc');

				

				$("#focusIndex"+currentFocusI).animate({left: -$(window).width()},1000,'easeOutExpo');

				$("#focusIndex"+nextI).animate({left: 0},1000,'easeOutExpo',function(){

						$("#focusIndex"+currentFocusI).hide();

						currentFocusI = nextI;

						changeingFocus = false;

				});

		});

	} else {

		$("#focusIndex"+nextI).css("left",-$(window).width());

		$("#focusIndex"+nextI+" .focusL").css("left",-($(window).width()/2+1200));

		$("#focusIndex"+nextI+" .focusR").css("left",-($(window).width()/2+1200));

		$("#focusIndex"+currentFocusI).show();

		$("#focusIndex"+nextI).show();

		

		$("#focusIndex"+currentFocusI+" .focusR").animate({left: $(window).width()/2},300,'easeInExpo');

		$("#focusIndex"+currentFocusI+" .focusL").animate({left: $(window).width()/2},600,'easeInExpo',function(){

				$("#focusIndex"+nextI+" .focusL").animate({left: -600},1200,'easeInOutCirc');

				$("#focusIndex"+nextI+" .focusR").animate({left: -600},1000,'easeInOutCirc');

				

				$("#focusIndex"+currentFocusI).animate({left: $(window).width()},1000,'easeOutExpo');

				$("#focusIndex"+nextI).animate({left: 0},1000,'easeOutExpo',function(){

						$("#focusIndex"+currentFocusI).hide();

						currentFocusI = nextI;

						changeingFocus = false;

				});

		});

	}

}

function starFocustAm(){

	timerFID = setInterval("timer_tickF()",12000);

}

function stopFocusAm(){

	clearInterval(timerFID);

}

function timer_tickF() {

	changeFocus(true);

}



