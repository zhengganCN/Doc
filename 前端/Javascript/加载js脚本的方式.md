# 加载 js 脚本的方式

## ss

```javascript
<script src="//http://lib.sinaapp.com/js/jquery/1.7.2/jquery.min.js"></script>
<script>
    if (!window.jQuery) {
        var script = document.createElement('script');
        script.src = "/js/jquery.min.js";
        document.body.appendChild(script);
    }
</script>
```

或者

```javascript
<script type="text/javascript" src="//apps.bdimg.com/libs/jquery/1.11.3/jquery.min.js"></script>
<script type="text/javascript">
    if (typeof jQuery == 'undefined') {
        document.write(unescape("%3Cscript src='/skin/js/jquery.js' type='text/javascript'%3E%3C/script%3E"));
    }
</script>
```
