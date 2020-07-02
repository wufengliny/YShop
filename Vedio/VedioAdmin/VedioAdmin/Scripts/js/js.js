
$(document).ready(function () {
    
    $("#navList img").mouseover(function(){  
        if(!($(this).is(":animated"))){  
            $(this).animate({"top":"-15px",},200).animate({"top":"-0px",},200)  
            .animate({"top":"-12px",},200).animate({"top":"-0px",},200)  
            .animate({"top":"-6px",},200).animate({"top":"-1px",},200)  
            .animate({"top":"-1px",},200).animate({"top":"-0px",},200);
        }  
	});
	$("#navList ul li").hover(function(){ 
		 //alert($("#navList ul li").index(this));
		 var liIndex = $("#navList ul li").index(this);
		 $(".subNav ul").hide();
		 $(".subNav ul").eq(liIndex).toggle();
	})
	$("#userBox").hover(function(){ 
		$(".userList").fadeToggle();
	})
	$(".secMenuDonw").hover(function(){ 
		$(this).find("#secMenu").fadeToggle();
		//alert(111)
	})

	$(".thrMenuDown").hover(function(){ 
		$(this).find("#thrMenu").fadeToggle();
		//alert(111)
	})
	$(".openAndClose ul li a").mouseover(function(){ 
		$(this).find("span").addClass("flipped-vertical-top animated");
		//alert(111)
	})
	$(".openAndClose ul li a").mouseleave(function(){ 
		$(this).find("span").removeClass("flipped-vertical-top animated");
		//alert(111)
	})
	
});
function ShowTDDetail(sender) {
    var firsttd = $(sender).find("td").first();
    if (typeof ($(firsttd).attr("rowspan")) == "undefined") {
        $(firsttd).attr("rowspan", 2);
    }
    else {
        $(firsttd).removeAttr("rowspan");
    }
    $(sender).next().toggle();
}