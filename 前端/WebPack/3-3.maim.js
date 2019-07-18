// main.js是项目的JS入口文件

//导入JQuery，最好不要在页面使用<script></script>标签来导入包
import $ from 'jquery'

$(function(){
    $("li:odd").css("backgroundColor","red");
    $("li:even").css("backgroundColor","yellow");
})