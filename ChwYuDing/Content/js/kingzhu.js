$(document).ready(function() {
	$(window).scroll(function() {
		if(jQuery(this).scrollTop() > 1) {
			$(".header").addClass("header_scroll");
		} else {
			$(".header").removeClass("header_scroll");
		}
	});
	$(".aside ul li.consulting").click(function() {
		$(".aside ul li.consulting").addClass("active");
		$(".consulting_box").css("right", "40px");
	});
	$(".consulting_box .close").click(function() {
		$(".aside ul li.consulting").removeClass("active");
		$(".consulting_box").css("right", "-250px");
	});
	$(".header .mobileMenuBtn").click(function() {
		$(".header .mobileMenuBtn").toggleClass("active");
		$(".header .header_menu").toggleClass("active");
		$(".header .mobileMenuBtn_shad").toggleClass("active");
	});
	$(".header .mobileMenuBtn_shad").click(function() {
		$(".header .mobileMenuBtn").toggleClass("active");
		$(".header .header_menu").toggleClass("active");
		$(".header .mobileMenuBtn_shad").toggleClass("active");
	});

	if(!(/msie [6|7|8|9]/i.test(navigator.userAgent))) {
		var wow = new WOW({
			boxClass: 'wow',
			animateClass: 'animated',
			offset: 150,
			mobile: true,
			live: true
		});

		//wow.init();
	};

	//返回顶部
	$(".kzquickGotop").click(function() {
		$('body,html').animate({
			scrollTop: 0
		}, 1000);
		return false;
	});

	//设备判断
	//turnMobile();

	function turnMobile() {
		var mobileAgent = new Array("iphone", "ipod", "ipad", "android", "mobile", "blackberry", "webos", "incognito", "webmate", "bada", "nokia", "lg", "ucweb", "skyfire");

		var browser = navigator.userAgent.toLowerCase();

		var isMobile = false;

		for(var i = 0; i < mobileAgent.length; i++) {
			if(browser.indexOf(mobileAgent[i]) != -1) {
				isMobile = true;

				if($(window).width() < 480) {
					scroll(function(direction) {
						if(direction == "down") {
							$(".header").css("display", "none");
						} else if(direction == "up") {
							$(".header").css("display", "block");
						}
					});
				}

				break;
			}
		}
	}

	function is_weixn() {
		var ua = navigator.userAgent.toLowerCase();
		if(ua.match(/MicroMessenger/i) == "micromessenger") {
			return true;
		} else {
			return false;
		}
	}

	if(!is_weixn()) {
		$("body").addClass("nWX");
	} else {
		$("body").addClass("WX");
		$(".alipay").css("display", "none");
	}

	/*if(is_weixn()){
		$('body').css('padding-bottom',0);
		$('.kzactiveBody').css('padding-bottom',"60px");
		$(".kzbuyTicketBox").css("bottom",0);
		$(".kzmoblieFooter").css("display","none");
	}*/

	function scroll(fn) {
		var beforeScrollTop = document.documentElement.scrollTop || window.pageYOffset || document.body.scrollTop,
			fn = fn || function() {};
		window.addEventListener("scroll", function() {
			var afterScrollTop = document.documentElement.scrollTop || window.pageYOffset || document.body.scrollTop,
				delta = afterScrollTop - beforeScrollTop;
			if(delta === 0) return false;
			fn(delta > 0 ? "down" : "up");
			beforeScrollTop = afterScrollTop;
		}, false);
	}

	/*
	 * 登录
	 */
	$("#jkzChangeLoginType a").on("click", function() {
		if($(this).hasClass("active")) {
			return false;
		}
		$("#jkzChangeLoginType a.active").removeClass("active");
		$(this).addClass("active");
		if($(this).data("type") == 2) {
			$("#jkzVCLogin").css("display", "block");
			$("#jkzpwLogin").css("display", "none");
		} else {
			$("#jkzpwLogin").css("display", "block");
			$("#jkzVCLogin").css("display", "none");
		}
	})

	/*
	 * 首页
	 */
	var indexBannerSwiper = new Swiper('.kzindexBanner-container', {
		pagination: '.swiper-pagination',
		paginationClickable: true,
		autoplay: 3000,
	});

	var indexconperationSwiper = new Swiper('.kzcooperation-container', {
		slidesPerView: 6,
		spaceBetween: 0,
		autoplay: 3000,
		prevButton: '.swiper-button-prev',
		nextButton: '.swiper-button-next',
		breakpoints: {
			1024: {
				slidesPerView: 5,
				spaceBetween: 0,
			},
			768: {
				slidesPerView: 4,
			},
			476: {
				slidesPerView: 2,
			}
		}
	})

	/*
	 * 活动详情页
	 */
	var ACDBannerSwiper = new Swiper('.kzACDBanner-container', {
		pagination: '.swiper-pagination',
		paginationClickable: true,
		autoplay: 3000,
	});

	//滑动
	$(".kzACLinkBar a").click(function() {
		$("html, body").animate({
			scrollTop: $($(this).attr("href")).offset().top + "px"
		}, {
			duration: 500,
			easing: "swing"
		});
		return false;
	});
});

$(".kzshareWrap, .kzSPBox .kzshareBtn").on("click", function() {
	$(".kzshareInner").click(function(event) {
		event.stopPropagation();
	})
	$(".kzshareWrap").slideToggle();
});


$("#jOpenRedList").on("click", function() {
	layer.open({
		type: 2,
		title: '红包列表',
		shadeClose: true,
		shade: 0.7,
		skin: 'kzRedListBox',
		area: ['90%', '90%'],
		content: 'redpacketlist.html' //iframe的url
	});
});

$(".kzRPOK").on("click", function() {
	var index = parent.layer.getFrameIndex(window.name); //先得到当前iframe层的索引
	parent.layer.close(index);
});

$("#jCloseRedBtn").on("click", function() {
	$("#jRedWrap").removeClass("active");
});

$("#jOpenRedBtn").on("click", function() {
	$("#jRedWrap").addClass("kzRedOpen");
});