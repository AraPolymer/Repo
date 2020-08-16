/*
** Author: James Li @ MSIHQ
**
** Slider Banner
**
**
*/

;(function($){
	$.fn.SliderBanner = function(settings){
		// defalust setting
		var _defautSettings = {
			width  : 960,
			height : 350,
			time   : 3,
			auto   : true,
			showBar: true,
			mask_top: "index-mask-top",
			mask_bottom: "index-mask-bottom"
		};
		// extend defalut setting
		var _settings = $.extend(_defautSettings, settings);
		
		var _handler = function(){
			var _this = this;
			var div = $(_this);
			var ul  = div.find("ul");
			var li  = ul.find("li");
			var content = li.find("div");
			var len = li.length;
			var _tip = "";
			var timing = _settings.time * 1000;
			var timer, autoRun;

			li.addClass("position-r").eq(0).nextAll().hide();
			
			content
				.addClass("banner-content position-a z250 clear hide")
				.css({"cursor":"pointer"})
				.html(function(i, o){return "<div class='banner-content-body position-a z250'>"+o+"</div>";})
				.append("<div class='banner-content-bg position-a z200 ui-corner-all'></div>")
				.click(function(e){
					href = $(this).prev("a").attr("href");
					target = $(this).prev("a").attr("target");
					if(target == "_blank"){
						window.open(href);
					}else{
						location.href = href;
					}
				});

			for(var i=0; i< len; i++){
				var _thumb, _pic, _img;
				_thumb	= li.eq(i).children("a").attr("thumb")
				_img	= "<img src='"+_thumb+"' border='0' width='50' />";
				_tip	= _tip + "<li no='"+i+"' state='off' class='banner-tip banner-tip-off mr10 fl'>"+_img+"</li>";
			}
			_tip = "<div class='banner-control-bar'><ul>"+_tip+"</ul><div class='clear'></div></div>"
			
			div
				.addClass("banner-main position-r mb10 fl clear")
				.css({
					"width": _settings.width, 
					"height": _settings.height
				})
				.attr({"on": -1})
				.append("<div class='banner-mask-top "+_settings.mask_top+"'></div><div class='banner-mask-bottom "+_settings.mask_bottom+"'></div><div class='banner-control'></div>");
			
			var control = div.find("div.banner-control");
			control.append(_tip);
			var tip = control.find("li.banner-tip");
			var bar = control.find("div.banner-control-bar");
			tip.last().removeClass("mr5");
			var bar_width = (45 * (len+1));
			bar.width(bar_width);
			
			if(_settings.showBar == false){
				control.hide();
			}
			
			li.bind({
				mouseover:function(){
					_settings.auto = false;
					stop();
				},
				mouseout:function(){
					_settings.auto = true;
					start();
				}
			});
			
			
			tip.bind({
				mouseover:function(){
					_settings.auto = false;
					if($(this).attr("state") == "off"){
						$(this).addClass("banner-tip-on");
					}
					stop();
				},
				mouseout:function(){
					_settings.auto = true;
					if($(this).attr("state") == "off"){
						$(this).removeClass("banner-tip-on");
					}
					start();
				},
				click:function(){
					play($(this));
				}
			}).css({"cursor":"pointer"});

			function autoRun(){
				var o = parseInt(div.attr("on"));
				var n = o + 1
				
				if(n >= len){
					tip.eq(0).trigger("click");
				}else{
					tip.eq(n).trigger("click");
				}
			}
			
			function play(i){
				stop();
				
				var o = parseInt(div.attr("on")),
					n = parseInt(i.attr("no"));

				tip.removeClass("banner-tip-on").attr("state", "off");
				i.addClass("banner-tip-on").attr("state", "on");
				
				if(o != n){
					li.eq(o).fadeOut();
					div.attr("on", n)

					li.eq(n).fadeIn(function(){
						var _t		= $(this),
							_src	= _t.children("a").attr("pic");
							_alt	= _t.children("a").attr("title"),
							_nImg	= false;
						//alert(t.attr("l"));
						if(_t.attr("l") == "off" && _t.children("a").children("img").length > 0){
							_t.children("a").children("img").remove();
							_nImg = $("<img>", {src:_src, alt:_alt, border: 0, title: _alt, id: ("banner_img_"+n), width:960, height:350, "class": "hide"});
							_t.children("a").append(_nImg);
							$("img#banner_img_"+n).load(function(){_t.attr("l", "on");$(this).fadeIn(200, function(){start();});});
						}else{
							_t.attr("l", "on");
						}
						if(_settings.auto && _t.attr("l") == "on"){
							stop();
							start();
						}else{
							stop();
						}
					});
				}
			}
			function stop(){
				clearTimeout(timer);
			}
			function start(){
				timer = setTimeout(autoRun, timing);
			}
			
			if(_settings.auto == true){
				autoRun();
			}else{
				tip.eq(0).trigger("click");
			}
		}
		
		return this.each(_handler);
	}
})(jQuery);