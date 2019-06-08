# html引入头部尾部

## 使用jQuery的load函数

    $(document).ready(function(){
        $(".footer").load("footer.html");
    });

    注意，此时的footer.html不需要是完整的HTML