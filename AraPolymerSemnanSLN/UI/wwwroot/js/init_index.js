	/*---------------------
	 * jQuery 
	 *---------------------
	 */
	/*jQuery(window).load(function(){
		checkM();
	})*/
	jQuery(document).ready(function(){
		$("div#warp").removeClass("loadfinish");
		// news & video button
		$( "#news_btn" ).click(
			function(){
				$('div.index_newsbox').css('background-position','0 0');
				$('div.#MSI-news').show();
				$('div.#box-video').hide();
			});
		$( "#video_btn" ).click(
			function(){
				$('div.index_newsbox').css('background-position','0 -231px');
				$('div.#box-video').show();
				$('div.#MSI-news').hide();
			});

		$("div.index_soptlight").children("div.info").each(function(){
			_div = $(this);
			_div.children("h3").children("a").text(function(){
				_h3 = _div.children("h3").children("a").text();
				
				return (_h3).substr(0,24)+(_h3.length > 24 ? "..." : "");
			})
			_div.children("p").children("a").text(function(){
				_p  = _div.children("p").children("a").text();
				return (_p).substr(0,140)+(_p.length > 140 ? "..." : "");
			})
		});
		$("div.index_soptlight")
			.each(function(i, em){
				$(this).click(function(e){
					_link = $(this).children("div.more-btn").children("a").attr("href");
					_target = $(this).children("div.more-btn").children("a").attr("target");
					if(_target == '_self'){
						location.href = _link;
					}else{
						window.open(_link,'','');
					}
                                        return false;
				});
			}).css("cursor", "pointer");
		



		// VIDEO
		_val = $("input.video-file").val();
		_val = _val.replace(/\+/g, " ");
		
		$("#video-player").before("<div id='video-player' />").remove();
		_width  = 220;
		_height = 115;
		_file   = unescape(_val);
		_image  = $("input.video-image").val();
		_type   = function(v){
			if (v.match(/.*\.flv$/)){
				return 'file';
			}else if(v.match(/^http:\/\/www\.youtube\.\w/)){
				return 'youtube';
			}else{
				return 'embed';
			}
		}
		_auth	= $("input.video-auth").val();
		createPlayer2(_file, _image, _width, _height, _type(_file), _auth);
	});	
	


	/*---------------------
	 * Function
	 *---------------------
	 */
	// VIDEO
	var player = null;
	function playerReady(thePlayer) {
		player = document.getElementById(thePlayer.id);
	}
		function createPlayer2(firstVideo, firstImage, vwidth, vheight, vtype, vauth) {
			_auth = vauth.split(":");
			_host = _auth[0];
			_auth = _auth[1];
			var flashvars_file = {
				file: firstVideo,
				image: firstImage,
				streamer: "http://"+_host+"/video/playstream.php?aid=" + _auth,
				skin: "/js/video/skins/simple.swf",
				autostart: "false"	
			}
			var flashvars_youtube = {
				file: firstVideo,
				image: firstImage,
				skin: "/js/video/skins/simple.swf",
				autostart: "false"	
			}
			flashvars = (vtype == "file" ? flashvars_file : flashvars_youtube);
			var params = {
				allowfullscreen:"true", 
				allowscriptaccess:"always",
				wmode: "transparent"
			}
			var attributes = {
				id:"msi_video_player",  
				name:"msi_video_player"
			}
			if(vtype == 'embed'){
				var _val;
				_val = firstVideo.replace(/width="(\d+)"/g, "width=\"" + vwidth + "\"");
				_val = _val.replace(/height="(\d+)"/g, "height=\"" + vheight + "\"");
				_val = _val.replace(/<embed/g, "<embed wmode=\"transparent\"");
				_val = _val.replace(/<object(.*)>(.*)/g, "<object$1><param name='wmode' value='transparent'>$2");
				$("#video-player").html(_val);
			}else{
				swfobject.embedSWF("/js/video/player/player.swf", "video-player", vwidth, vheight, "9.0.115", false, flashvars, params, attributes);
			}
		}
