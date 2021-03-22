# 点击文本框时使用js选中文本框中的内容

```js
$(function () {
    $("#search_text>input").click(function(){
        this.select();
    });
});
```
