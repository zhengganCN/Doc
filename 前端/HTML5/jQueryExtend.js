/** 加载js文件时，从缓存中获取，如果缓存中没有该js文件的缓存，则发送ajax请求js文件
 * @param url js文件的url
 * @param options ajax请求参数
 * @param successCallback 加载成功后执行的回调函数
 * @param failCallback 加载失败后执行的回调函数
 */
jQuery.getCachedScript = function (url, options, successCallback, failCallback=null) {
    // Allow user to set any option except for dataType, cache, and url
    options = $.extend(options || {}, {
        dataType: "script",
        cache: true,
        url: url
    });
    // Use $.ajax() since it is more flexible than $.getScript
    // Return the jqXHR object so we can chain callbacks
    jQuery.extend(options, {
        success: successCallback,
        error: failCallback
    })
    return jQuery.ajax(options);
};

/** 在head末尾添加css文件
 * @param url css文件的url
 */
jQuery.appendCSSLink = function (url) {
    let link = "<link href=" + url + " rel='stylesheet'>" + "</link>"
    $("head").append(link);
}