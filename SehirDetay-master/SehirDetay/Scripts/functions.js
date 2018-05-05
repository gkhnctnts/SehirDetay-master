jQuery(document).ready(function($){
	"use strict";
	
	// runs bx slider function
	$.fn.kode_nicescroll = function(){
		if(typeof($.fn.niceScroll) == 'function'){
			$(this).each(function(){
				// if( $(this).attr('data-year') ){
					// data_year = parseInt($(this).attr('data-year'));
				// }
				$(this).niceScroll({cursorwidth:'12px',cursorcolor:"#0F7DC1",cursoropacitymax:0.7,boxzoom:true,touchbehavior:false,cursorborder :'1px solid #0F7DC1',zindex :999999});	
			});	
		}
	}
	
	// runs countdown function
	$.fn.kode_countdown = function(){
		if(typeof($.fn.countdown) == 'function'){
			$(this).each(function(){
				var austDay = new Date();
				var data_year;
				var data_month;
				var data_day;
				var data_time;
				var current_day;
				
				// data-year duration
				if( $(this).attr('data-year') ){
					data_year = parseInt($(this).attr('data-year'));
				}
				//Month
				if( $(this).attr('data-month') ){
					data_month = parseInt($(this).attr('data-month'));
				}
				//day
				if( $(this).attr('data-day') ){
					data_day = parseInt($(this).attr('data-day'));
				}
				//time
				if( $(this).attr('data-time') ){
					data_time = parseInt($(this).attr('data-time'));
				}
						
				current_day = new Date(data_year, data_month-1, data_day,data_time);
				$(this).countdown({until: current_day});	
				jQuery('#year').text(current_day.getFullYear());
			});	
		}
	}
	
	
	
	if($('.header-sticky').length){
		// grab the initial top offset of the navigation 
		var stickyNavTop = $('.header-sticky').offset().top;
		// our function that decides weather the navigation bar should have "fixed" css position or not.
		var stickyNav = function(){
			var scrollTop = $(window).scrollTop(); // our current vertical position from the top
			// if we've scrolled more than the navigation, change its position to fixed to stick to top,
			// otherwise change it back to relative
			if (scrollTop > stickyNavTop) { 
				$('.header-sticky').addClass('kf_sticky');
			} else {
				$('.header-sticky').removeClass('kf_sticky'); 
			}
		};
		stickyNav();
		// and run it again every time you scroll
		$(window).scroll(function() {
			stickyNav();
		});
	}	
	
	if($('.header-2').length){
		$('.navigation .menu').singlePageNav({
			offset: $('.header-2').outerHeight()-30,
			filter: ':not(.external)',
			updateHash: true,
			beforeStart: function() {
				console.log('begin scrolling');
			},
			onComplete: function() {
				console.log('done scrolling');
			}
		});
	}
	
	// runs bx slider function
	$.fn.kode_bxslider = function(){
		if(typeof($.fn.bxSlider) == 'function'){
			$(this).each(function(){
				var bx_attr = {
					mode: 'fade',
					auto: true,
					controls:true
					// prevText: '<i class="icon-angle-left" ></i>', 
					// nextText: '<i class="icon-angle-right" ></i>',
					// useCSS: false
				};
				
				// slide duration
				if( $(this).attr('data-pausetime') ){
					bx_attr.pause = parseInt($(this).attr('data-pausetime'));
				}
				if( $(this).attr('data-slidespeed') ){
					bx_attr.speed = parseInt($(this).attr('data-slidespeed'));
				}

				// set the attribute for carousel type
				// if( $(this).attr('data-type') == 'carousel' ){
					// bx_attr.move = 1;
					// bx_attr.animation = 'slide';
					
					// if( $(this).closest('.kode-item-no-space').length > 0 ){
						// bx_attr.itemWidth = $(this).width() / parseInt($(this).attr('data-columns'));
						// bx_attr.itemMargin = 0;							
					// }else{
						// bx_attr.itemWidth = (($(this).width() + 30) / parseInt($(this).attr('data-columns'))) - 30;
						// bx_attr.itemMargin = 30;	
					// }		
					
					// if( $(this).attr('data-columns') == "1" ){ bx_attr.smoothHeight = true; }
				// }else{
					// if( $(this).attr('data-effect') ){
						// bx_attr.animation = $(this).attr('data-effect');
					// }
				// }
				// if( $(this).attr('data-columns') ){
					// bx_attr.minItems = parseInt($(this).attr('data-columns'));
					// bx_attr.maxItems = parseInt($(this).attr('data-columns'));	
				// }				
				

				$(this).bxSlider(bx_attr);	
			});	
			$(".kode-bxslider .bx-controls-direction .bx-prev").empty();
			$(".kode-bxslider .bx-controls-direction .bx-next").empty();
			$(".kode-bxslider .bx-controls-direction .bx-next").append('<i class="fa fa-angle-right"></i>');
			$(".kode-bxslider .bx-controls-direction .bx-prev").append('<i class="fa fa-angle-left"></i>');
		}
	}
	
	if( navigator.userAgent.match(/Android/i) || navigator.userAgent.match(/webOS/i) || 
		navigator.userAgent.match(/iPhone/i) || navigator.userAgent.match(/iPad/i) || 
		navigator.userAgent.match(/iPod/i) || navigator.userAgent.match(/BlackBerry/i) || 
		navigator.userAgent.match(/Windows Phone/i) ){ 
		var kode_touch_device = true; 
	}else{ 
		var kode_touch_device = false; 
	}
	
	// retrieve GET variable from url
	$.extend({
	  getUrlVars: function(){
		var vars = [], hash;
		var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
		for(var i = 0; i < hashes.length; i++)
		{
		  hash = hashes[i].split('=');
		  vars.push(hash[0]);
		  vars[hash[0]] = hash[1];
		}
		return vars;
	  },
	  getUrlVar: function(name){
		return $.getUrlVars()[name];
	  }
	});	
	
	// runs flex slider function
	$.fn.kode_flexslider = function(){
		if(typeof($.fn.flexslider) == 'function'){
			$(this).each(function(){
				var flex_attr = {
					animation: 'fade',
					animationLoop: true,
					prevText: '<i class="fa fa-angle-left" ></i>', 
					nextText: '<i class="fa fa-angle-right" ></i>',
					useCSS: false
				};
				
				// slide duration
				if( $(this).attr('data-pausetime') ){
					flex_attr.slideshowSpeed = parseInt($(this).attr('data-pausetime'));
				}
				if( $(this).attr('data-slidespeed') ){
					flex_attr.animationSpeed = parseInt($(this).attr('data-slidespeed'));
				}

				// set the attribute for carousel type
				if( $(this).attr('data-type') == 'carousel' ){
					flex_attr.move = 1;
					flex_attr.animation = 'slide';
					
					if( $(this).closest('.kode-item-no-space').length > 0 ){
						flex_attr.itemWidth = $(this).width() / parseInt($(this).attr('data-columns'));
						flex_attr.itemMargin = 0;							
					}else{
						flex_attr.itemWidth = (($(this).width() + 30) / parseInt($(this).attr('data-columns'))) - 30;
						flex_attr.itemMargin = 30;	
					}		
					
					// if( $(this).attr('data-columns') == "1" ){ flex_attr.smoothHeight = true; }
				}else{
					if( $(this).attr('data-effect') ){
						flex_attr.animation = $(this).attr('data-effect');
					}
				}
				if( $(this).attr('data-columns') ){
					flex_attr.minItems = parseInt($(this).attr('data-columns'));
					flex_attr.maxItems = parseInt($(this).attr('data-columns'));	
				}				
				
				// set the navigation to different area
				if( $(this).attr('data-nav-container') ){
					var flex_parent = $(this).parents('.' + $(this).attr('data-nav-container')).prev('.kode-nav-container');
					
					if( flex_parent.find('.kode-flex-prev').length > 0 || flex_parent.find('.kode-flex-next').length > 0 ){
						flex_attr.controlNav = false;
						flex_attr.directionNav = false;
						flex_attr.start = function(slider){
							flex_parent.find('.kode-flex-next').click(function(){
								slider.flexAnimate(slider.getTarget("next"), true);
							});
							flex_parent.find('.kode-flex-prev').click(function(){
								slider.flexAnimate(slider.getTarget("prev"), true);
							});
							
							kode_set_item_outer_nav();
							$(window).resize(function(){ kode_set_item_outer_nav(); });
						}
					}else{
						flex_attr.controlNav = false;
						flex_attr.controlsContainer = flex_parent.find('.nav-container');	
					}
					
				}

				$(this).flexslider(flex_attr);	
			});	
		}
	}
	
	// runs nivo slider function
	$.fn.kode_nivoslider = function(){
		if(typeof($.fn.nivoSlider) == 'function'){
			$(this).each(function(){
				var nivo_attr = {};
				
				if( $(this).attr('data-pausetime') ){
					nivo_attr.pauseTime = parseInt($(this).attr('data-pausetime'));
				}
				if( $(this).attr('data-slidespeed') ){
					nivo_attr.animSpeed = parseInt($(this).attr('data-slidespeed'));
				}
				if( $(this).attr('data-effect') ){
					nivo_attr.effect = $(this).attr('data-effect');
				}

				$(this).nivoSlider(nivo_attr);	
				
				
			});	
		}
	}	
	
	
	$(document).ready(function(){
	
		// top woocommerce button
		$('.kode-top-woocommerce-wrapper').hover(function(){
			$(this).children('.kode-top-woocommerce').fadeIn(200);
		}, function(){
			$(this).children('.kode-top-woocommerce').fadeOut(200);
		});
	
		
		// script for parallax background
		$('.kode-parallax-wrapper').each(function(){
			if( $(this).hasClass('kode-background-image') ){
				var parallax_section = $(this);
				var parallax_speed = parseFloat(parallax_section.attr('data-bgspeed'));
				if( parallax_speed == 0 || kode_touch_device ) return;
				if( parallax_speed == -1 ){
					parallax_section.css('background-attachment', 'fixed');
					parallax_section.css('background-position', 'center center');
					return;
				}
					
				$(window).scroll(function(){
					// if in area of interest
					if( ( $(window).scrollTop() + $(window).height() > parallax_section.offset().top ) &&
						( $(window).scrollTop() < parallax_section.offset().top + parallax_section.outerHeight() ) ){
						
						var scroll_pos = 0;
						if( $(window).height() > parallax_section.offset().top ){
							scroll_pos = $(window).scrollTop();
						}else{
							scroll_pos = $(window).scrollTop() + $(window).height() - parallax_section.offset().top;
						}
						parallax_section.css('background-position', 'center ' + (-scroll_pos * parallax_speed) + 'px');
					}
				});			
			}else if( $(this).hasClass('kode-background-video') ){
				if(typeof($.fn.mb_YTPlayer) == 'function'){
					$(this).children('.kode-bg-player').mb_YTPlayer();
				}
			}else{
				return;
			}
		});
		
		
		// responsive menu
		if(typeof($.fn.dlmenu) == 'function'){
			$('#kode-responsive-navigation').each(function(){
				$(this).find('.dl-submenu').each(function(){
					if( $(this).siblings('a').attr('href') && $(this).siblings('a').attr('href') != '#' ){
						var parent_nav = $('<li class="menu-item kode-parent-menu"></li>');
						parent_nav.append($(this).siblings('a').clone());
						
						$(this).prepend(parent_nav);
					}
				});
				$(this).dlmenu();
			});
		}	
		
		// gallery thumbnail type
		$('.kode-gallery-thumbnail').each(function(){
			var thumbnail_container = $(this).children('.kode-gallery-thumbnail-container');
		
			$(this).find('.gallery-item').click(function(){
				var selected_slide = thumbnail_container.children('[data-id="' + $(this).attr('data-id') + '"]');
				if(selected_slide.css('display') == 'block') return false;
			
				// check the gallery height
				var image_width = selected_slide.children('img').attr('width');
				var image_ratio = selected_slide.children('img').attr('height') / image_width;
				var temp_height = image_ratio * Math.min(thumbnail_container.width(), image_width);
				
				thumbnail_container.animate({'height': temp_height});
				selected_slide.fadeIn().siblings().hide();
				return false;
			});		

			$(window).resize(function(){ thumbnail_container.css('height', 'auto') });
		});

		
		// image shortcode 
		$('.kode-image-link-shortcode').hover(function(){
			$(this).find('.kode-image-link-overlay').animate({opacity: 0.8}, 150);
			$(this).find('.kode-image-link-icon').animate({opacity: 1}, 150);
		}, function(){
			$(this).find('.kode-image-link-overlay').animate({opacity: 0}, 150);
			$(this).find('.kode-image-link-icon').animate({opacity: 0}, 150);
		});	
		
		
		// animate ux
		if( !kode_touch_device && ( !$.browser.msie || (parseInt($.browser.version) > 8)) ){
		
			// image ux
			$('.content-wrapper img').each(function(){
				if( $(this).closest('.kode-ux, .ls-wp-container, .product, .flexslider, .nivoSlider').length ) return;
				
				var ux_item = $(this);
				if( ux_item.offset().top > $(window).scrollTop() + $(window).height() ){
					ux_item.css({ 'opacity':0 });
				}else{ return; }
				
				$(window).scroll(function(){
					if( $(window).scrollTop() + $(window).height() > ux_item.offset().top + 100 ){
						ux_item.animate({ 'opacity':1 }, 1200); 
					}
				});					
			});
		
			// item ux
			$('.kode-ux').each(function(){
				var ux_item = $(this);
				if( ux_item.hasClass('kode-chart') || ux_item.hasClass('kode-skill-bar') ){
					if( ux_item.offset().top < $(window).scrollTop() + $(window).height() ){
						if( ux_item.hasClass('kode-chart') && (!$.browser.msie || (parseInt($.browser.version) > 8)) ){
							ux_item.kode_pie_chart();
						}else if( ux_item.hasClass('kode-skill-bar') ){
							ux_item.children('.kode-skill-bar-progress').each(function(){
								if($(this).attr('data-percent')){
									$(this).animate({width: $(this).attr('data-percent') + '%'}, 1200, 'easeOutQuart');
								}
							});	
						}
						return;
					}
				}else if( ux_item.offset().top > $(window).scrollTop() + $(window).height() ){
					ux_item.css({ 'opacity':0, 'padding-top':20, 'margin-bottom':-20 });
				}else{ return; }	

				$(window).scroll(function(){
					if( $(window).scrollTop() + $(window).height() > ux_item.offset().top + 100 ){
						if( ux_item.hasClass('kode-chart') && (!$.browser.msie || (parseInt($.browser.version) > 8)) ){
							ux_item.kode_pie_chart();
						}else if( ux_item.hasClass('kode-skill-bar') ){
							ux_item.children('.kode-skill-bar-progress').each(function(){
								if($(this).attr('data-percent')){
									$(this).animate({width: $(this).attr('data-percent') + '%'}, 1200, 'easeOutQuart');
								}
							});	
						}else{
							ux_item.animate({ 'opacity':1, 'padding-top':0, 'margin-bottom':0 }, 1200);
						}
					}
				});					
			});
			
		// do not animate on scroll in mobile
		}else{
		
			// Pie chart
			if(!$.browser.msie || (parseInt($.browser.version) > 8)){
				$('.kode-chart').kode_pie_chart();
			}	

		
			// skill bar
			$('.kode-skill-bar-progress').each(function(){
				if($(this).attr('data-percent')){
					$(this).animate({width: $(this).attr('data-percent') + '%'}, 1200, 'easeOutQuart');
				}
			});			
		}		

		// runs nivoslider when available
		$('.nivoSlider').kode_nivoslider();		
		
		// runs flexslider when available
		$('.flexslider').kode_flexslider();
		
		// runs bxslider when available
		$('.bxslider').kode_bxslider();
		
		// runs bxslider when available
		$('.countdown').kode_countdown();
		
		// runs niceScroll when available
		$('.nicescroll').kode_nicescroll();
	});
	
	$(window).load(function(){

		
	});
	
	/* ---------------------------------------------------------------------- */
	/*	Scroll to Top
	/* ---------------------------------------------------------------------- */
	jQuery(window).scroll(function(){
		if (jQuery(this).scrollTop() > 100) {
			jQuery('.backtop').fadeIn();
		} else {
			jQuery('.backtop').fadeOut();
		}
	});
	
	/* ---------------------------------------------------------------------- */
	/*	Click to Trigger an Event
	/* ---------------------------------------------------------------------- */
	jQuery('.backtop').click(function(){
		jQuery('html, body').animate({scrollTop : 0},800);
		return false;
	});

});




!function (t) { "use strict"; t.fn.counterUp = function (e) { var n = t.extend({ time: 400, delay: 10 }, e); return this.each(function () { var e = t(this), r = n, o = function () { var t = [], n = r.time / r.delay, o = e.text(), i = /[0-9]+,[0-9]+/.test(o); o = o.replace(/,/g, ""); for (var l = (/^[0-9]+$/.test(o), /^[0-9]+\.[0-9]+$/.test(o)), u = l ? (o.split(".")[1] || []).length : 0, s = n; s >= 1; s--) { var a = parseInt(o / n * s); if (l && (a = parseFloat(o / n * s).toFixed(u)), i) for (; /(\d+)(\d{3})/.test(a.toString()) ;) a = a.toString().replace(/(\d+)(\d{3})/, "$1,$2"); t.unshift(a) } e.data("counterup-nums", t), e.text("0"); var c = function () { e.text(e.data("counterup-nums").shift()), e.data("counterup-nums").length ? setTimeout(e.data("counterup-func"), r.delay) : (delete e.data("counterup-nums"), e.data("counterup-nums", null), e.data("counterup-func", null)) }; e.data("counterup-func", c), setTimeout(e.data("counterup-func"), r.delay) }; e.waypoint(o, { offset: "100%", triggerOnce: !0 }) }) } }(jQuery), function () { var t = [].indexOf || function (t) { for (var e = 0, n = this.length; n > e; e++) if (e in this && this[e] === t) return e; return -1 }, e = [].slice; !function (t, e) { return "function" == typeof define && define.amd ? define("waypoints", ["jquery"], function (n) { return e(n, t) }) : e(t.jQuery, t) }(this, function (n, r) { var o, i, l, u, s, a, c, f, d, h, p, v, y, g, m, w; return o = n(r), f = t.call(r, "ontouchstart") >= 0, u = { horizontal: {}, vertical: {} }, s = 1, c = {}, a = "waypoints-context-id", p = "resize.waypoints", v = "scroll.waypoints", y = 1, g = "waypoints-waypoint-ids", m = "waypoint", w = "waypoints", i = function () { function t(t) { var e = this; this.$element = t, this.element = t[0], this.didResize = !1, this.didScroll = !1, this.id = "context" + s++, this.oldScroll = { x: t.scrollLeft(), y: t.scrollTop() }, this.waypoints = { horizontal: {}, vertical: {} }, t.data(a, this.id), c[this.id] = this, t.bind(v, function () { var t; return e.didScroll || f ? void 0 : (e.didScroll = !0, t = function () { return e.doScroll(), e.didScroll = !1 }, r.setTimeout(t, n[w].settings.scrollThrottle)) }), t.bind(p, function () { var t; return e.didResize ? void 0 : (e.didResize = !0, t = function () { return n[w]("refresh"), e.didResize = !1 }, r.setTimeout(t, n[w].settings.resizeThrottle)) }) } return t.prototype.doScroll = function () { var t, e = this; return t = { horizontal: { newScroll: this.$element.scrollLeft(), oldScroll: this.oldScroll.x, forward: "right", backward: "left" }, vertical: { newScroll: this.$element.scrollTop(), oldScroll: this.oldScroll.y, forward: "down", backward: "up" } }, !f || t.vertical.oldScroll && t.vertical.newScroll || n[w]("refresh"), n.each(t, function (t, r) { var o, i, l; return l = [], i = r.newScroll > r.oldScroll, o = i ? r.forward : r.backward, n.each(e.waypoints[t], function (t, e) { var n, o; return r.oldScroll < (n = e.offset) && n <= r.newScroll ? l.push(e) : r.newScroll < (o = e.offset) && o <= r.oldScroll ? l.push(e) : void 0 }), l.sort(function (t, e) { return t.offset - e.offset }), i || l.reverse(), n.each(l, function (t, e) { return e.options.continuous || t === l.length - 1 ? e.trigger([o]) : void 0 }) }), this.oldScroll = { x: t.horizontal.newScroll, y: t.vertical.newScroll } }, t.prototype.refresh = function () { var t, e, r, o = this; return r = n.isWindow(this.element), e = this.$element.offset(), this.doScroll(), t = { horizontal: { contextOffset: r ? 0 : e.left, contextScroll: r ? 0 : this.oldScroll.x, contextDimension: this.$element.width(), oldScroll: this.oldScroll.x, forward: "right", backward: "left", offsetProp: "left" }, vertical: { contextOffset: r ? 0 : e.top, contextScroll: r ? 0 : this.oldScroll.y, contextDimension: r ? n[w]("viewportHeight") : this.$element.height(), oldScroll: this.oldScroll.y, forward: "down", backward: "up", offsetProp: "top" } }, n.each(t, function (t, e) { return n.each(o.waypoints[t], function (t, r) { var o, i, l, u, s; return o = r.options.offset, l = r.offset, i = n.isWindow(r.element) ? 0 : r.$element.offset()[e.offsetProp], n.isFunction(o) ? o = o.apply(r.element) : "string" == typeof o && (o = parseFloat(o), r.options.offset.indexOf("%") > -1 && (o = Math.ceil(e.contextDimension * o / 100))), r.offset = i - e.contextOffset + e.contextScroll - o, r.options.onlyOnScroll && null != l || !r.enabled ? void 0 : null !== l && l < (u = e.oldScroll) && u <= r.offset ? r.trigger([e.backward]) : null !== l && l > (s = e.oldScroll) && s >= r.offset ? r.trigger([e.forward]) : null === l && e.oldScroll >= r.offset ? r.trigger([e.forward]) : void 0 }) }) }, t.prototype.checkEmpty = function () { return n.isEmptyObject(this.waypoints.horizontal) && n.isEmptyObject(this.waypoints.vertical) ? (this.$element.unbind([p, v].join(" ")), delete c[this.id]) : void 0 }, t }(), l = function () { function t(t, e, r) { var o, i; r = n.extend({}, n.fn[m].defaults, r), "bottom-in-view" === r.offset && (r.offset = function () { var t; return t = n[w]("viewportHeight"), n.isWindow(e.element) || (t = e.$element.height()), t - n(this).outerHeight() }), this.$element = t, this.element = t[0], this.axis = r.horizontal ? "horizontal" : "vertical", this.callback = r.handler, this.context = e, this.enabled = r.enabled, this.id = "waypoints" + y++, this.offset = null, this.options = r, e.waypoints[this.axis][this.id] = this, u[this.axis][this.id] = this, o = null != (i = t.data(g)) ? i : [], o.push(this.id), t.data(g, o) } return t.prototype.trigger = function (t) { return this.enabled ? (null != this.callback && this.callback.apply(this.element, t), this.options.triggerOnce ? this.destroy() : void 0) : void 0 }, t.prototype.disable = function () { return this.enabled = !1 }, t.prototype.enable = function () { return this.context.refresh(), this.enabled = !0 }, t.prototype.destroy = function () { return delete u[this.axis][this.id], delete this.context.waypoints[this.axis][this.id], this.context.checkEmpty() }, t.getWaypointsByElement = function (t) { var e, r; return (r = n(t).data(g)) ? (e = n.extend({}, u.horizontal, u.vertical), n.map(r, function (t) { return e[t] })) : [] }, t }(), h = { init: function (t, e) { var r; return null == e && (e = {}), null == (r = e.handler) && (e.handler = t), this.each(function () { var t, r, o, u; return t = n(this), o = null != (u = e.context) ? u : n.fn[m].defaults.context, n.isWindow(o) || (o = t.closest(o)), o = n(o), r = c[o.data(a)], r || (r = new i(o)), new l(t, r, e) }), n[w]("refresh"), this }, disable: function () { return h._invoke(this, "disable") }, enable: function () { return h._invoke(this, "enable") }, destroy: function () { return h._invoke(this, "destroy") }, prev: function (t, e) { return h._traverse.call(this, t, e, function (t, e, n) { return e > 0 ? t.push(n[e - 1]) : void 0 }) }, next: function (t, e) { return h._traverse.call(this, t, e, function (t, e, n) { return e < n.length - 1 ? t.push(n[e + 1]) : void 0 }) }, _traverse: function (t, e, o) { var i, l; return null == t && (t = "vertical"), null == e && (e = r), l = d.aggregate(e), i = [], this.each(function () { var e; return e = n.inArray(this, l[t]), o(i, e, l[t]) }), this.pushStack(i) }, _invoke: function (t, e) { return t.each(function () { var t; return t = l.getWaypointsByElement(this), n.each(t, function (t, n) { return n[e](), !0 }) }), this } }, n.fn[m] = function () { var t, r; return r = arguments[0], t = 2 <= arguments.length ? e.call(arguments, 1) : [], h[r] ? h[r].apply(this, t) : n.isFunction(r) ? h.init.apply(this, arguments) : n.isPlainObject(r) ? h.init.apply(this, [null, r]) : n.error(r ? "The " + r + " method does not exist in jQuery Waypoints." : "jQuery Waypoints needs a callback function or handler option.") }, n.fn[m].defaults = { context: r, continuous: !0, enabled: !0, horizontal: !1, offset: 0, triggerOnce: !1 }, d = { refresh: function () { return n.each(c, function (t, e) { return e.refresh() }) }, viewportHeight: function () { var t; return null != (t = r.innerHeight) ? t : o.height() }, aggregate: function (t) { var e, r, o; return e = u, t && (e = null != (o = c[n(t).data(a)]) ? o.waypoints : void 0), e ? (r = { horizontal: [], vertical: [] }, n.each(r, function (t, o) { return n.each(e[t], function (t, e) { return o.push(e) }), o.sort(function (t, e) { return t.offset - e.offset }), r[t] = n.map(o, function (t) { return t.element }), r[t] = n.unique(r[t]) }), r) : [] }, above: function (t) { return null == t && (t = r), d._filter(t, "vertical", function (t, e) { return e.offset <= t.oldScroll.y }) }, below: function (t) { return null == t && (t = r), d._filter(t, "vertical", function (t, e) { return e.offset > t.oldScroll.y }) }, left: function (t) { return null == t && (t = r), d._filter(t, "horizontal", function (t, e) { return e.offset <= t.oldScroll.x }) }, right: function (t) { return null == t && (t = r), d._filter(t, "horizontal", function (t, e) { return e.offset > t.oldScroll.x }) }, enable: function () { return d._invoke("enable") }, disable: function () { return d._invoke("disable") }, destroy: function () { return d._invoke("destroy") }, extendFn: function (t, e) { return h[t] = e }, _invoke: function (t) { var e; return e = n.extend({}, u.vertical, u.horizontal), n.each(e, function (e, n) { return n[t](), !0 }) }, _filter: function (t, e, r) { var o, i; return (o = c[n(t).data(a)]) ? (i = [], n.each(o.waypoints[e], function (t, e) { return r(o, e) ? i.push(e) : void 0 }), i.sort(function (t, e) { return t.offset - e.offset }), n.map(i, function (t) { return t.element })) : [] } }, n[w] = function () { var t, n; return n = arguments[0], t = 2 <= arguments.length ? e.call(arguments, 1) : [], d[n] ? d[n].apply(null, t) : d.aggregate.call(null, n) }, n[w].settings = { resizeThrottle: 100, scrollThrottle: 30 }, o.load(function () { return n[w]("refresh") }) }) }.call(this), function (t) { "use strict"; t.fn.counterUp = function (e) { var n = t.extend({ time: 400, delay: 10 }, e); return this.each(function () { var e = t(this), r = n, o = function () { var t = [], n = r.time / r.delay, o = e.text(), i = /[0-9]+,[0-9]+/.test(o); o = o.replace(/,/g, ""); for (var l = (/^[0-9]+$/.test(o), /^[0-9]+\.[0-9]+$/.test(o)), u = l ? (o.split(".")[1] || []).length : 0, s = n; s >= 1; s--) { var a = parseInt(o / n * s); if (l && (a = parseFloat(o / n * s).toFixed(u)), i) for (; /(\d+)(\d{3})/.test(a.toString()) ;) a = a.toString().replace(/(\d+)(\d{3})/, "$1,$2"); t.unshift(a) } e.data("counterup-nums", t), e.text("0"); var c = function () { e.text(e.data("counterup-nums").shift()), e.data("counterup-nums").length ? setTimeout(e.data("counterup-func"), r.delay) : (delete e.data("counterup-nums"), e.data("counterup-nums", null), e.data("counterup-func", null)) }; e.data("counterup-func", c), setTimeout(e.data("counterup-func"), r.delay) }; e.waypoint(o, { offset: "100%", triggerOnce: !0 }) }) } }(jQuery);
