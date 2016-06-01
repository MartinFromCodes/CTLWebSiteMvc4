define("echarts/chart/line",["require","./base","zrender/shape/Polyline","../util/shape/Icon","../util/shape/HalfSmoothPolygon","../component/axis","../component/grid","../component/dataZoom","../config","../util/ecData","zrender/tool/util","zrender/tool/color","../chart"],function(e){function t(e,t,i,a,o){n.call(this,e,t,i,a,o),this.refresh(a)}function i(e,t,i){var n=t.x,a=t.y,r=t.width,s=t.height,l=s/2;t.symbol.match("empty")&&(e.fillStyle="#fff"),t.brushType="both";var h=t.symbol.replace("empty","").toLowerCase();h.match("star")?(l=h.replace("star","")-0||5,a-=1,h="star"):("rectangle"===h||"arrow"===h)&&(n+=(r-s)/2,r=s);var d="";if(h.match("image")&&(d=h.replace(new RegExp("^image:\\/\\/"),""),h="image",n+=Math.round((r-s)/2)-1,r=s+=2),h=o.prototype.iconLibrary[h]){var m=t.x,c=t.y;e.moveTo(m,c+l),e.lineTo(m+5,c+l),e.moveTo(m+t.width-5,c+l),e.lineTo(m+t.width,c+l);var p=this;h(e,{x:n+4,y:a+4,width:r-8,height:s-8,n:l,image:d},function(){p.modSelf(),i()})}else e.moveTo(n,a+l),e.lineTo(n+r,a+l)}var n=e("./base"),a=e("zrender/shape/Polyline"),o=e("../util/shape/Icon"),r=e("../util/shape/HalfSmoothPolygon");e("../component/axis"),e("../component/grid"),e("../component/dataZoom");var s=e("../config");s.line={zlevel:0,z:2,clickable:!0,legendHoverLink:!0,xAxisIndex:0,yAxisIndex:0,dataFilter:"nearest",itemStyle:{normal:{label:{show:!1},lineStyle:{width:2,type:"solid",shadowColor:"rgba(0,0,0,0)",shadowBlur:0,shadowOffsetX:0,shadowOffsetY:0}},emphasis:{label:{show:!1}}},symbolSize:2,showAllSymbol:!1};var l=e("../util/ecData"),h=e("zrender/tool/util"),d=e("zrender/tool/color");return t.prototype={type:s.CHART_TYPE_LINE,_buildShape:function(){this.finalPLMap={},this._buildPosition()},_buildHorizontal:function(e,t,i,n){for(var a,o,r,s,l,h,d,m,c,p=this.series,u=i[0][0],V=p[u],U=this.component.xAxis.getAxis(V.xAxisIndex||0),g={},f=0,y=t;y>f&&null!=U.getNameByIndex(f);f++){o=U.getCoordByIndex(f);for(var b=0,_=i.length;_>b;b++){a=this.component.yAxis.getAxis(p[i[b][0]].yAxisIndex||0),l=s=d=h=a.getCoord(0);for(var x=0,k=i[b].length;k>x;x++)u=i[b][x],V=p[u],m=V.data[f],c=this.getDataFromOption(m,"-"),g[u]=g[u]||[],n[u]=n[u]||{min:Number.POSITIVE_INFINITY,max:Number.NEGATIVE_INFINITY,sum:0,counter:0,average:0},"-"!==c?(c>=0?(s-=x>0?a.getCoordSize(c):l-a.getCoord(c),r=s):0>c&&(h+=x>0?a.getCoordSize(c):a.getCoord(c)-d,r=h),g[u].push([o,r,f,U.getNameByIndex(f),o,l]),n[u].min>c&&(n[u].min=c,n[u].minY=r,n[u].minX=o),n[u].max<c&&(n[u].max=c,n[u].maxY=r,n[u].maxX=o),n[u].sum+=c,n[u].counter++):g[u].length>0&&(this.finalPLMap[u]=this.finalPLMap[u]||[],this.finalPLMap[u].push(g[u]),g[u]=[])}s=this.component.grid.getY();for(var v,b=0,_=i.length;_>b;b++)for(var x=0,k=i[b].length;k>x;x++)u=i[b][x],V=p[u],m=V.data[f],c=this.getDataFromOption(m,"-"),"-"==c&&this.deepQuery([m,V,this.option],"calculable")&&(v=this.deepQuery([m,V],"symbolSize"),s+=2*v+5,r=s,this.shapeList.push(this._getCalculableItem(u,f,U.getNameByIndex(f),o,r,"horizontal")))}for(var L in g)g[L].length>0&&(this.finalPLMap[L]=this.finalPLMap[L]||[],this.finalPLMap[L].push(g[L]),g[L]=[]);this._calculMarkMapXY(n,i,"y"),this._buildBorkenLine(e,this.finalPLMap,U,"horizontal")},_buildVertical:function(e,t,i,n){for(var a,o,r,s,l,h,d,m,c,p=this.series,u=i[0][0],V=p[u],U=this.component.yAxis.getAxis(V.yAxisIndex||0),g={},f=0,y=t;y>f&&null!=U.getNameByIndex(f);f++){r=U.getCoordByIndex(f);for(var b=0,_=i.length;_>b;b++){a=this.component.xAxis.getAxis(p[i[b][0]].xAxisIndex||0),l=s=d=h=a.getCoord(0);for(var x=0,k=i[b].length;k>x;x++)u=i[b][x],V=p[u],m=V.data[f],c=this.getDataFromOption(m,"-"),g[u]=g[u]||[],n[u]=n[u]||{min:Number.POSITIVE_INFINITY,max:Number.NEGATIVE_INFINITY,sum:0,counter:0,average:0},"-"!==c?(c>=0?(s+=x>0?a.getCoordSize(c):a.getCoord(c)-l,o=s):0>c&&(h-=x>0?a.getCoordSize(c):d-a.getCoord(c),o=h),g[u].push([o,r,f,U.getNameByIndex(f),l,r]),n[u].min>c&&(n[u].min=c,n[u].minX=o,n[u].minY=r),n[u].max<c&&(n[u].max=c,n[u].maxX=o,n[u].maxY=r),n[u].sum+=c,n[u].counter++):g[u].length>0&&(this.finalPLMap[u]=this.finalPLMap[u]||[],this.finalPLMap[u].push(g[u]),g[u]=[])}s=this.component.grid.getXend();for(var v,b=0,_=i.length;_>b;b++)for(var x=0,k=i[b].length;k>x;x++)u=i[b][x],V=p[u],m=V.data[f],c=this.getDataFromOption(m,"-"),"-"==c&&this.deepQuery([m,V,this.option],"calculable")&&(v=this.deepQuery([m,V],"symbolSize"),s-=2*v+5,o=s,this.shapeList.push(this._getCalculableItem(u,f,U.getNameByIndex(f),o,r,"vertical")))}for(var L in g)g[L].length>0&&(this.finalPLMap[L]=this.finalPLMap[L]||[],this.finalPLMap[L].push(g[L]),g[L]=[]);this._calculMarkMapXY(n,i,"x"),this._buildBorkenLine(e,this.finalPLMap,U,"vertical")},_buildOther:function(e,t,i,n){for(var a,o=this.series,r={},s=0,l=i.length;l>s;s++)for(var h=0,d=i[s].length;d>h;h++){var m=i[s][h],c=o[m];a=this.component.xAxis.getAxis(c.xAxisIndex||0);var p=this.component.yAxis.getAxis(c.yAxisIndex||0),u=p.getCoord(0);r[m]=r[m]||[],n[m]=n[m]||{min0:Number.POSITIVE_INFINITY,min1:Number.POSITIVE_INFINITY,max0:Number.NEGATIVE_INFINITY,max1:Number.NEGATIVE_INFINITY,sum0:0,sum1:0,counter0:0,counter1:0,average0:0,average1:0};for(var V=0,U=c.data.length;U>V;V++){var g=c.data[V],f=this.getDataFromOption(g,"-");if(f instanceof Array){var y=a.getCoord(f[0]),b=p.getCoord(f[1]);r[m].push([y,b,V,f[0],y,u]),n[m].min0>f[0]&&(n[m].min0=f[0],n[m].minY0=b,n[m].minX0=y),n[m].max0<f[0]&&(n[m].max0=f[0],n[m].maxY0=b,n[m].maxX0=y),n[m].sum0+=f[0],n[m].counter0++,n[m].min1>f[1]&&(n[m].min1=f[1],n[m].minY1=b,n[m].minX1=y),n[m].max1<f[1]&&(n[m].max1=f[1],n[m].maxY1=b,n[m].maxX1=y),n[m].sum1+=f[1],n[m].counter1++}}}for(var _ in r)r[_].length>0&&(this.finalPLMap[_]=this.finalPLMap[_]||[],this.finalPLMap[_].push(r[_]),r[_]=[]);this._calculMarkMapXY(n,i,"xy"),this._buildBorkenLine(e,this.finalPLMap,a,"other")},_buildBorkenLine:function(e,t,i,n){for(var o,s="other"==n?"horizontal":n,m=this.series,c=e.length-1;c>=0;c--){var p=e[c],u=m[p],V=t[p];if(u.type===this.type&&null!=V)for(var U=this._getBbox(p,s),g=this._sIndex2ColorMap[p],f=this.query(u,"itemStyle.normal.lineStyle.width"),y=this.query(u,"itemStyle.normal.lineStyle.type"),b=this.query(u,"itemStyle.normal.lineStyle.color"),_=this.getItemStyleColor(this.query(u,"itemStyle.normal.color"),p,-1),x=null!=this.query(u,"itemStyle.normal.areaStyle"),k=this.query(u,"itemStyle.normal.areaStyle.color"),v=0,L=V.length;L>v;v++){var W=V[v],w="other"!=n&&this._isLarge(s,W);if(w)W=this._getLargePointList(s,W,u.dataFilter);else for(var X=0,I=W.length;I>X;X++)o=u.data[W[X][2]],(this.deepQuery([o,u,this.option],"calculable")||this.deepQuery([o,u],"showAllSymbol")||"categoryAxis"===i.type&&i.isMainAxis(W[X][2])&&"none"!=this.deepQuery([o,u],"symbol"))&&this.shapeList.push(this._getSymbol(p,W[X][2],W[X][3],W[X][0],W[X][1],s));var K=new a({zlevel:this.getZlevelBase(),z:this.getZBase(),style:{miterLimit:f,pointList:W,strokeColor:b||_||g,lineWidth:f,lineType:y,smooth:this._getSmooth(u.smooth),smoothconnstraint:U,shadowColor:this.query(u,"itemStyle.normal.lineStyle.shadowColor"),shadowBlur:this.query(u,"itemStyle.normal.lineStyle.shadowBlur"),shadowOffsetX:this.query(u,"itemStyle.normal.lineStyle.shadowOffsetX"),shadowOffsetY:this.query(u,"itemStyle.normal.lineStyle.shadowOffsetY")},hoverable:!1,_main:!0,_seriesIndex:p,_orient:s});if(l.pack(K,m[p],p,0,v,m[p].name),this.shapeList.push(K),x){var S=new r({zlevel:this.getZlevelBase(),z:this.getZBase(),style:{miterLimit:f,pointList:h.clone(W).concat([[W[W.length-1][4],W[W.length-1][5]],[W[0][4],W[0][5]]]),brushType:"fill",smooth:this._getSmooth(u.smooth),smoothconnstraint:U,color:k?k:d.alpha(g,.5)},highlightStyle:{brushType:"fill"},hoverable:!1,_main:!0,_seriesIndex:p,_orient:s});l.pack(S,m[p],p,0,v,m[p].name),this.shapeList.push(S)}}}},_getBbox:function(e,t){var i=this.component.grid.getBbox(),n=this.xMarkMap[e];return null!=n.minX0?[[Math.min(n.minX0,n.maxX0,n.minX1,n.maxX1),Math.min(n.minY0,n.maxY0,n.minY1,n.maxY1)],[Math.max(n.minX0,n.maxX0,n.minX1,n.maxX1),Math.max(n.minY0,n.maxY0,n.minY1,n.maxY1)]]:("horizontal"===t?(i[0][1]=Math.min(n.minY,n.maxY),i[1][1]=Math.max(n.minY,n.maxY)):(i[0][0]=Math.min(n.minX,n.maxX),i[1][0]=Math.max(n.minX,n.maxX)),i)},_isLarge:function(e,t){return t.length<2?!1:"horizontal"===e?Math.abs(t[0][0]-t[1][0])<.5:Math.abs(t[0][1]-t[1][1])<.5},_getLargePointList:function(e,t,i){var n;n="horizontal"===e?this.component.grid.getWidth():this.component.grid.getHeight();var a=t.length,o=[];if("function"!=typeof i)switch(i){case"min":i=function(e){return Math.max.apply(null,e)};break;case"max":i=function(e){return Math.min.apply(null,e)};break;case"average":i=function(e){for(var t=0,i=0;i<e.length;i++)t+=e[i];return t/e.length};break;default:i=function(e){return e[0]}}for(var r=[],s=0;n>s;s++){var l=Math.floor(a/n*s),h=Math.min(Math.floor(a/n*(s+1)),a);if(!(l>=h)){for(var d=l;h>d;d++)r[d-l]="horizontal"===e?t[d][1]:t[d][0];r.length=h-l;for(var m=i(r),c=-1,p=1/0,d=l;h>d;d++){var u="horizontal"===e?t[d][1]:t[d][0],V=Math.abs(u-m);p>V&&(c=d,p=V)}var U=t[c].slice();"horizontal"===e?U[1]=m:U[0]=m,o.push(U)}}return o},_getSmooth:function(e){return e?.3:0},_getCalculableItem:function(e,t,i,n,a,o){var r=this.series,l=r[e].calculableHolderColor||this.ecTheme.calculableHolderColor||s.calculableHolderColor,h=this._getSymbol(e,t,i,n,a,o);return h.style.color=l,h.style.strokeColor=l,h.rotation=[0,0],h.hoverable=!1,h.draggable=!1,h.style.text=void 0,h},_getSymbol:function(e,t,i,n,a,o){var r=this.series,s=r[e],l=s.data[t],h=this.getSymbolShape(s,e,l,t,i,n,a,this._sIndex2ShapeMap[e],this._sIndex2ColorMap[e],"#fff","vertical"===o?"horizontal":"vertical");return h.zlevel=this.getZlevelBase(),h.z=this.getZBase()+1,this.deepQuery([l,s,this.option],"calculable")&&(this.setCalculable(h),h.draggable=!0),h},getMarkCoord:function(e,t){var i=this.series[e],n=this.xMarkMap[e],a=this.component.xAxis.getAxis(i.xAxisIndex),o=this.component.yAxis.getAxis(i.yAxisIndex);if(t.type&&("max"===t.type||"min"===t.type||"average"===t.type)){var r=null!=t.valueIndex?t.valueIndex:null!=n.maxX0?"1":"";return[n[t.type+"X"+r],n[t.type+"Y"+r],n[t.type+"Line"+r],n[t.type+r]]}return["string"!=typeof t.xAxis&&a.getCoordByIndex?a.getCoordByIndex(t.xAxis||0):a.getCoord(t.xAxis||0),"string"!=typeof t.yAxis&&o.getCoordByIndex?o.getCoordByIndex(t.yAxis||0):o.getCoord(t.yAxis||0)]},refresh:function(e){e&&(this.option=e,this.series=e.series),this.backupShapeList(),this._buildShape()},ontooltipHover:function(e,t){for(var i,n,a=e.seriesIndex,o=e.dataIndex,r=a.length;r--;)if(i=this.finalPLMap[a[r]])for(var s=0,l=i.length;l>s;s++){n=i[s];for(var h=0,d=n.length;d>h;h++)o===n[h][2]&&t.push(this._getSymbol(a[r],n[h][2],n[h][3],n[h][0],n[h][1],"horizontal"))}},addDataAnimation:function(e,t){function i(){V--,0===V&&t&&t()}function n(e){e.style.controlPointList=null}for(var a=this.series,o={},r=0,s=e.length;s>r;r++)o[e[r][0]]=e[r];for(var l,h,d,m,c,p,u,V=0,r=this.shapeList.length-1;r>=0;r--)if(c=this.shapeList[r]._seriesIndex,o[c]&&!o[c][3]){if(this.shapeList[r]._main&&this.shapeList[r].style.pointList.length>1){if(p=this.shapeList[r].style.pointList,h=Math.abs(p[0][0]-p[1][0]),m=Math.abs(p[0][1]-p[1][1]),u="horizontal"===this.shapeList[r]._orient,o[c][2]){if("half-smooth-polygon"===this.shapeList[r].type){var U=p.length;this.shapeList[r].style.pointList[U-3]=p[U-2],this.shapeList[r].style.pointList[U-3][u?0:1]=p[U-4][u?0:1],this.shapeList[r].style.pointList[U-2]=p[U-1]}this.shapeList[r].style.pointList.pop(),u?(l=h,d=0):(l=0,d=-m)}else{if(this.shapeList[r].style.pointList.shift(),"half-smooth-polygon"===this.shapeList[r].type){var g=this.shapeList[r].style.pointList.pop();u?g[0]=p[0][0]:g[1]=p[0][1],this.shapeList[r].style.pointList.push(g)}u?(l=-h,d=0):(l=0,d=m)}this.shapeList[r].style.controlPointList=null,this.zr.modShape(this.shapeList[r])}else{if(o[c][2]&&this.shapeList[r]._dataIndex===a[c].data.length-1){this.zr.delShape(this.shapeList[r].id);continue}if(!o[c][2]&&0===this.shapeList[r]._dataIndex){this.zr.delShape(this.shapeList[r].id);continue}}this.shapeList[r].position=[0,0],V++,this.zr.animate(this.shapeList[r].id,"").when(this.query(this.option,"animationDurationUpdate"),{position:[l,d]}).during(n).done(i).start()}V||i()}},o.prototype.iconLibrary.legendLineIcon=i,h.inherits(t,n),e("../chart").define("line",t),t}),define("echarts/util/shape/HalfSmoothPolygon",["require","zrender/shape/Base","zrender/shape/util/smoothBezier","zrender/tool/util","zrender/shape/Polygon"],function(e){function t(e){i.call(this,e)}var i=e("zrender/shape/Base"),n=e("zrender/shape/util/smoothBezier"),a=e("zrender/tool/util");return t.prototype={type:"half-smooth-polygon",buildPath:function(t,i){var a=i.pointList;if(!(a.length<2))if(i.smooth){var o=n(a.slice(0,-2),i.smooth,!1,i.smoothconnstraint);t.moveTo(a[0][0],a[0][1]);for(var r,s,l,h=a.length,d=0;h-3>d;d++)r=o[2*d],s=o[2*d+1],l=a[d+1],t.bezierCurveTo(r[0],r[1],s[0],s[1],l[0],l[1]);t.lineTo(a[h-2][0],a[h-2][1]),t.lineTo(a[h-1][0],a[h-1][1]),t.lineTo(a[0][0],a[0][1])}else e("zrender/shape/Polygon").prototype.buildPath(t,i)}},a.inherits(t,i),t});
