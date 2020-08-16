	var liew = 0, liow = 0;
	var mmt;
	var arrL = 0;
	var bw = 0;
	jQuery(document).ready(function(){
		$("div.mainMenu>ul>li").each(function(i, em){
			_li = $(this);
			lw = _li.width();
			lt = _li.position().left;
			
			var liew = 0;
			_li.find("ul.PD li").each(function(i, em){
				lie = $(this);
				if(lie.width() > liew){
					liew = lie.width();
				}
			}).width(liew);
			
			if(_li.find("div#mm-product").html()){
				if(_li.find("ul.PD li").length > 6){
					elen = _li.find("ul.PD li:even").length;
					olen = _li.find("ul.PD li:odd").length;
					if(elen > olen){
						_li.find("ul.PD").append("<li><span class='fl pd-link'>&nbsp;</span></li>");
						_li.find("ul.PD li").last().width(liew);
					}
					_li.find("ul.PD li:even").addClass("b_tr");
					_li.find("ul.PD li:odd").addClass("b_t").after("<div class='clear'></div>")
					_li.find("ul.PD li:eq(0)").addClass("b_r").removeClass("b_tr");
					_li.find("ul.PD li:eq(1)").removeClass("b_t");
					_li.find("div.m").width(function(){
						return ((_li.find("ul.PD li").width() + 10) * 2);
					});
				}else{
					_li.find("ul.PD li").addClass("b_t").after("<div class='clear'></div>").find("a");
					_li.find("ul.PD li:eq(0)").removeClass("b_t");
				}
			}else{
				_li.find("ul.PD li").addClass("b_t").css({'height':'25px'}).after("<div class='clear'></div>").find("a").css({'line-height':'25px'});
				_li.find("ul.PD li:eq(0)").removeClass("b_t");
			}
			mw = _li.find("div.m").width();
			mh = _li.find("div.m").height();
			_li.find("div.t, div.b").width(mw);
			_li.find("div.l, div.r").height(mh);
				
				
			_li.children("a").click(function(e){return false;});
			
			_li.bind({
				mouseover:function(){
					_this = $(this);
					
					lt = _this.position().left;
					lw = _this.width();
					lc = (lt +  Math.round(lw / 2));
					bt = _this.find("div[id*=mm-]").position().left;
					bw = _this.find("div[id*=mm-]").width();
					bc = lc - Math.round(bw / 2);
					_this.children("div.droupMenu").width(function(){ 
						return (_this.find("div.tl").width() + _this.find("div.t").width() + _this.find("div.tr").width());
					})
					at = (Math.round(bw / 2) - (lw / 2))
					_this.find("div[id*=mm-]").css({"left": bc});
					_this.find("span.mm-arr").css({"left": at, "width": lw});
				
					_this
						.siblings('li')
						.children('div')
							.addClass("top-3000")
							.removeClass("z250");
					_this
						.children("div")
							.removeClass("top-3000")
							.addClass("z250");
					clearTimeout(mmt);
				},
				mouseout:function(){
					mmt = setTimeout(
						function(){
							$("div.mainMenu ul li")
								.children("div")
									.addClass("top-3000")
									.removeClass("z250");
						},
						1000
					);
				}
			});
		});
		$("div.searchBox input.search-keyword").each(function(i, em){
			$(this).keypress(function(e){
				if(e.keyCode == '13'){
					_kw = $(this).val();
					location.href = '/service/search/?kw=' + _kw + '&type=product';
				}
			});
			$(this).focus(function(e){
				if(i == 0){
					$(this).animate({
						width: 140
					})
				}
			}).blur(function(e){
				if(i == 0){
					$(this).animate({
						width: 50
					})
				}
			});
		});
		$("div.searchBox img.search-btn").each(function(i, em){
			$("div.searchBox img.search-btn").eq(i).click(function(e){
				_kw = $("div.searchBox input.search-keyword").eq(i).val();
				location.href = '/service/search/?kw=' + _kw + '&type=product';
				return false;
			});
		});
		$("span.pd-link").each(function(i, em){
			_span = $(this);
			_span.css({"cursor":"pointer"});
			_span.click(function(){
				_link = $(this).next("a").attr("href");
				location.href = _link;
				return false;
			});
		});
	});