/** Notice * This file contains works from many authors under various (but compatible) licenses. Please see core.txt for more information. **/
(function(){(window.wpCoreControlsBundle=window.wpCoreControlsBundle||[]).push([[13],{372:function(Da,xa,z){z.r(xa);var na=z(2),ia=z(0);z.n(ia);var ka=z(1),ea=z(124);Da=z(46);var da=z(78),x=z(205),r=z(56),n=z(204);z=z(319);var a=window,b=function(){function y(e,w,aa){var fa=-1===e.indexOf("?")?"?":"&";switch(w){case r.a.NEVER_CACHE:this.url=e+fa+"_="+Object(ia.uniqueId)();break;default:this.url=e}this.gf=aa;this.request=new XMLHttpRequest;this.request.open("GET",this.url,!0);this.request.setRequestHeader("X-Requested-With",
"XMLHttpRequest");this.request.overrideMimeType?this.request.overrideMimeType("text/plain; charset=x-user-defined"):this.request.setRequestHeader("Accept-Charset","x-user-defined");this.status=n.a.NOT_STARTED}y.prototype.start=function(e,w){var aa=this,fa=this,ja=this.request,ba;fa.Tu=0;e&&Object.keys(e).forEach(function(ha){aa.request.setRequestHeader(ha,e[ha])});w&&(this.request.withCredentials=w);this.ZA=setInterval(function(){var ha=0===window.document.URL.indexOf("file:///");ha=200===ja.status||
ha&&0===ja.status;if(ja.readyState!==n.b.DONE||ha){try{ja.responseText}catch(ca){return}fa.Tu<ja.responseText.length&&(ba=fa.M9())&&fa.trigger(y.Events.DATA,[ba]);0===ja.readyState&&(clearInterval(fa.ZA),fa.trigger(y.Events.DONE))}else clearInterval(fa.ZA),fa.trigger(y.Events.DONE,["Error received return status "+ja.status])},1E3);this.request.send(null);this.status=n.a.STARTED};y.prototype.M9=function(){var e=this.request,w=e.responseText;if(0!==w.length)if(this.Tu===w.length)clearInterval(this.ZA),
this.trigger(y.Events.DONE);else return w=Math.min(this.Tu+3E6,w.length),e=a.kP(e,this.Tu,!0,w),this.Tu=w,e};y.prototype.abort=function(){clearInterval(this.ZA);var e=this;this.request.onreadystatechange=function(){Object(ka.i)("StreamingRequest aborted");e.status=n.a.ABORTED;return e.trigger(y.Events.ABORTED)};this.request.abort()};y.prototype.finish=function(){var e=this;this.request.onreadystatechange=function(){e.status=n.a.SUCCESS;return e.trigger(y.Events.DONE)};this.request.abort()};y.Events=
{DONE:"done",DATA:"data",ABORTED:"aborted"};return y}();Object(Da.a)(b);var f;(function(y){y[y.LOCAL_HEADER=0]="LOCAL_HEADER";y[y.FILE=1]="FILE";y[y.CENTRAL_DIR=2]="CENTRAL_DIR"})(f||(f={}));var h=function(y){function e(){var w=y.call(this)||this;w.buffer="";w.state=f.LOCAL_HEADER;w.TI=4;w.Qk=null;w.ur=ea.c;w.em={};return w}Object(na.c)(e,y);e.prototype.G9=function(w){var aa;for(w=this.buffer+w;w.length>=this.ur;)switch(this.state){case f.LOCAL_HEADER:this.Qk=aa=this.Q9(w.slice(0,this.ur));if(aa.Xr!==
ea.g)throw Error("Wrong signature in local header: "+aa.Xr);w=w.slice(this.ur);this.state=f.FILE;this.ur=aa.aE+aa.To+aa.Zt+this.TI;this.trigger(e.Events.HEADER,[aa]);break;case f.FILE:this.Qk.name=w.slice(0,this.Qk.To);this.em[this.Qk.name]=this.Qk;aa=this.ur-this.TI;var fa=w.slice(this.Qk.To+this.Qk.Zt,aa);this.trigger(e.Events.FILE,[this.Qk.name,fa,this.Qk.qE]);w=w.slice(aa);if(w.slice(0,this.TI)===ea.h)this.state=f.LOCAL_HEADER,this.ur=ea.c;else return this.state=f.CENTRAL_DIR,!0}this.buffer=w;
return!1};e.Events={HEADER:"header",FILE:"file"};return e}(x.a);Object(Da.a)(h);Da=function(y){function e(w,aa,fa,ja,ba){fa=y.call(this,w,fa,ja)||this;fa.url=w;fa.stream=new b(w,aa);fa.Gd=new h;fa.QR=window.createPromiseCapability();fa.mS={};fa.gf=ba;return fa}Object(na.c)(e,y);e.prototype.Hv=function(w){var aa=this;this.request([this.zi,this.Lj,this.xi]);this.stream.addEventListener(b.Events.DATA,function(fa){try{if(aa.Gd.G9(fa))return aa.stream.finish()}catch(ja){throw aa.stream.abort(),aa.Wt(ja),
w(ja),ja;}});this.stream.addEventListener(b.Events.DONE,function(fa){aa.o9=!0;aa.QR.resolve();fa&&(aa.Wt(fa),w(fa))});this.Gd.addEventListener(h.Events.HEADER,Object(ia.bind)(this.lS,this));this.Gd.addEventListener(h.Events.FILE,Object(ia.bind)(this.g$,this));return this.stream.start(this.gf,this.withCredentials)};e.prototype.hP=function(w){var aa=this;this.QR.promise.then(function(){w(Object.keys(aa.Gd.em))})};e.prototype.Mm=function(){return!0};e.prototype.request=function(w){var aa=this;this.o9&&
w.forEach(function(fa){aa.mS[fa]||aa.kda(fa)})};e.prototype.lS=function(){};e.prototype.abort=function(){this.stream&&this.stream.abort()};e.prototype.kda=function(w){this.trigger(da.a.Events.PART_READY,[{$a:w,error:"Requested part not found",Hh:!1,Ff:!1}])};e.prototype.g$=function(w,aa,fa){this.mS[w]=!0;this.trigger(da.a.Events.PART_READY,[{$a:w,data:aa,Hh:!1,Ff:!1,error:null,Sc:fa}])};return e}(da.a);Object(z.a)(Da);Object(z.b)(Da);xa["default"]=Da}}]);}).call(this || window)
