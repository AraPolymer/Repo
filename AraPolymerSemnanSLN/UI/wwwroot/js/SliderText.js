/*
** Author: James Li @ MSIHQ
**
** Slider Text
**
**
*/

;(function($){
	$.fn.SliderText = function(settings){
		// defalust setting
		var _defautSettings = {
			width  : 320,
			height : 240,
			time   : 3,
			auto   : true, 
			clickHeader: function(o, n){
				alert(o + ',' + n);
			}
		};
		// extend defalut setting
		var _settings = $.extend(_defautSettings, settings);
		
		var _handler = function(){
			var _this = this;
			var div = $(_this);
			var ul  = div.find("ul");
			var li  = ul.find("li");
			var len = li.length;
			var _tip = "";
			var timing = _settings.time * 1000;
			var timer, autoRun;
			
			div.addClass("st-main");
			ul.addClass("st-body").width(function(){
				n = _settings.width * (len+1);
				return n;
			});
			li.addClass("st-item fl").width(_settings.width);
			li.eq(0).nextAll().hide();//.addClass("hide");
				
			for(var i=0; i< len; i++){
				li.eq(i).find("img").addClass("st-thumb");
				li.eq(i).find("span").addClass("st-date");
				li.eq(i).find("h6").addClass("st-title");
				li.eq(i).find("p").addClass("st-content");
				_tip = _tip + "<li no='"+i+"' state='off' class='st-tip st-tip-off mr5 fl'>&nbsp;</li>";
			}
			_tip = "<div class='clear'></div><div class='st-control-bar'><ul>"+_tip+"</ul></div><div class='clear'></div>"
			
			div
				.css({
					width: _settings.width,
					height: _settings.height+30
				})
				.attr({"on": -1})
				.append("<div class='st-control'></div>");
			var control = div.find("div.st-control");
			control.append(_tip);
			var tip = control.find("li.st-tip");
			var bar = control.find("div.st-control-bar");
			tip.last().removeClass("mr5");
			var bar_width = (19 * len);
			bar.width(bar_width);
			
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
						$(this).addClass("st-tip-on");
					}
					stop();
				},
				mouseout:function(){
					_settings.auto = true;
					if($(this).attr("state") == "off"){
						$(this).removeClass("st-tip-on");
					}
					start();
				},
				click: function(){
					play($(this));
				}
			}).css({"cursor":"pointer"});
			
			function autoRun() {
				var o = parseInt(div.attr("on"));
				var n = o + 1
				
				if(n >= len){
					tip.eq(0).trigger("click");
				}else{
					tip.eq(n).trigger("click");
				}
			}
			
			function play(i){
				var o = parseInt(div.attr("on"));
				var n = parseInt(i.attr("no"));
				
				tip.removeClass("st-tip-on").attr("state", "off");
				i.addClass("st-tip-on").attr("state", "on");
				
				if(o != n){
					li.eq(o).fadeOut();//.addClass("hide");
					div.attr("on", n)
					li.eq(n).fadeIn(function(){						
						if(_settings.auto){
							stop();
							start();
						}else{
							stop();
						}
					});//.removeClass("hide");
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