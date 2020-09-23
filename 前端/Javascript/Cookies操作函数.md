# Cookies操作函数

``` js
// 设置 cookie 值
function setCookie (name, value, exdays) {
  var now = new Date()
  now.setTime(now.getTime() + (exdays * 24 * 60 * 60 * 1000))
  var expires = 'expires=' + now.toGMTString()
  document.cookie = name + '=' + value + '; ' + expires
}
// 获取 cookie 值
function getCookie (name) {
  name = name + '='
  var values = document.cookie.split(';')
  for (var i = 0; i < values.length; i++) {
    var value = values[i].trim()
    if (value.indexOf(name) === 0) {
      return value.substring(name.length, value.length)
    }
  }
  return ''
}

export {setCookie, getCookie}

```
