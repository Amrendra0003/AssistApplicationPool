/** Notice * This file contains works from many authors under various (but compatible) licenses. Please see core.txt for more information. **/
(function(){(window.wpCoreControlsBundle=window.wpCoreControlsBundle||[]).push([[3],{367:function(Da,xa,z){z.r(xa);var na=z(2),ia=z(204);Da=z(364);z=z(319);var ka=window,ea=function(da){function x(r,n){var a=da.call(this,r,n)||this;a.url=r;a.range=n;a.request=new XMLHttpRequest;a.request.open("GET",a.url,!0);ka.Uint8Array&&(a.request.responseType="arraybuffer");a.request.setRequestHeader("X-Requested-With","XMLHttpRequest");a.status=ia.a.NOT_STARTED;return a}Object(na.c)(x,da);return x}(Da.ByteRangeRequest);
Da=function(da){function x(r,n,a,b){r=da.call(this,r,n,a,b)||this;r.Bv=ea;return r}Object(na.c)(x,da);x.prototype.It=function(r,n){return r+"/bytes="+n.start+","+(n.stop?n.stop:"")};return x}(Da["default"]);Object(z.a)(Da);Object(z.b)(Da);xa["default"]=Da}}]);}).call(this || window)
