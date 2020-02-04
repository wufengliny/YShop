/**
 * 动态加载CSS
 * @param {string} url 样式地址
 */
function dynamicLoadCss(url) {
	var head = document.getElementsByTagName('head')[0];
	var link = document.createElement('link');
	link.type = 'text/css';
	link.rel = 'stylesheet';
	link.href = url;
	head.appendChild(link);
}

/**
 * 无刷新修改url参数
 * @param {string} url 参数
 */
function norefreshUrlChange(param) {
	history.replaceState({
		pagetype: "name"
	}, null, "?pagetype=" + param);
}

// 后退异常处理
window.addEventListener("popstate", function(e) {
	if (history.state.pagetype) {
		window.location.href = location.href;
	}
});

/**
 * 获取url参数
 * @param {string} url 参数
 */
function GetQueryString(name) {
	var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
	var r = window.location.search.substr(1).match(reg); //search,查询？后面的参数，并匹配正则
	if (r != null) return unescape(r[2]);
	return null;
}

$(function() {
	/**
	 * 导航滚动
	 */
	function navScroll() {
		if ($(document).scrollTop() > 60) {
			$('#js-header-wrap').addClass("active")
			$("#logo-src").attr("src", "/content/qiye/images/static/logo-red.png");
		} else {
			$('#js-header-wrap').removeClass("active");
			$("#logo-src").attr("src", "/content/qiye/images/static/logo.png");
		}

		if ($(document).scrollTop() > 600) {
			$('#goTop').addClass("active")
		} else {
			$('#goTop').removeClass("active");
		}
	}
	navScroll();

	/**
	 * 返回顶部
	 */
	$("#goTop").click(function() {
		//$('body,html').animate({scrollTop:0},1000);
		if ($('html').scrollTop()) {
			$('html').animate({
				scrollTop: 0
			}, 1000);
			return false;
		}
		$('body').animate({
			scrollTop: 0
		}, 1000);
		return false;
	});



	/**
	 * 导航
	 */
	$(window).scroll(function() {
		navScroll();
	})

	$("#js-nav-open-box,#js-nav-mask").on("click", function() {
		$("#js-nav-open-box,#js-nav-box,#js-nav-mask").toggleClass("active");
	})

	/**
	 * 首页swiper
	 */
	var indexBgSwiper = new Swiper('#js-index-bg-swiper', {
		loop: true,
		watchOverflow: true, //因为仅有1个slide，swiper无效
		observer: true,
		autoplay: {
			delay: 5000
		},
		// 		pagination: {
		// 			el: '#js-index-bg-pagination',
		// 			clickable: true,
		// 		},
		// 		navigation: {
		// 			nextEl: '.swiper-button-next',
		// 			prevEl: '.swiper-button-prev',
		// 		},
	})
	
	
	/**
	 * 人才招聘
	 */
	$(".recruit-header").click(function(){
		if(!$(this).parent().hasClass('active')){
			$('.recruit-li').removeClass('active').children('.recruit-content').slideUp();
			$('.recruit-header span').text('+');
			$(this).parent().addClass('active').children('.recruit-content').slideDown();
			$(this).children('span').text('-');
		}
	})


})
