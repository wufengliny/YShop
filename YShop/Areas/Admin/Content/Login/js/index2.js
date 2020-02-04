
$(function() {
    //导航js 
	 
    $(".top_nav li").each(function(){
      $(this).hover(function(){ 	  
		 $(this).find(".sub").filter(':not(:animated)').slideDown(300);		 
		},function(){ 
		 $(this).find(".sub").slideUp('fast');		 
		}) 
    });	

	$(".topHeader").css("background","#fff");
	$(".topHeader").css("box-shadow","#666 0px 0px 5px");	
	
});

