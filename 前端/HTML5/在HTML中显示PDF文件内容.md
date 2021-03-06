# 在HTML中显示PDF文件内容

## 使用“< iframe >“标签

    所有浏览器都支持 < iframe > 标签，直接将src设置为指定的PDF文件就可以预览了。此外可以把需要的文本放置在 < iframe > 和 之间，这样就可以应对无法理解 iframe 的浏览器，比如下面的代码可以提供一个PDF的下载链接：
    <iframe src="/index.pdf" width="100%" height="100%">
        This browser does not support PDFs. Please download the PDF to view it: <a href="/index.pdf">Download PDF</a>
    </iframe>

## 使用< embed >标签

    < embed > 标签定义嵌入的内容，比如插件。在HTML5中这个标签有4个属性：
    < embed src="/index.pdf" type="application/pdf" width="100%" height="100%" >
    注意的是这个标签不能提供回退方案，与<iframe> </iframe> 不同，这个标签是自闭合的的，也就是说如果浏览器不支持PDF的嵌入，那么这个标签的内容什么都看不到。

## 使用< object >

    <object>定义一个嵌入的对象，请使用此元素向页面添加多媒体。此元素允许您规定插入 HTML 文档中的对象的数据和参数，以及可用来显示和操作数据的代码。用于包含对象，比如图像、音频、视频、Java applets、ActiveX、PDF 以及 Flash。几乎所有主流浏览器都拥有部分对 < object > 标签的支持。这个标签在这里的用法和< iframe >很小，也支持回退：
    <object data="/index.pdf" type="application/pdf" width="100%" height="100%">
        This browser does not support PDFs. Please download the PDF to view it: <a href="/index.pdf">Download PDF</a>
    </object>

    当然，结合<object>和<iframe>能提供一个更强大的回退方案：
    <object data="/index.pdf" type="application/pdf" width="100%" height="100%">
        <iframe src="/index.pdf" width="100%" height="100%" style="border: none;">
            This browser does not support PDFs. Please download the PDF to view it: <a href="/index.pdf">Download PDF</a>
        </iframe>
    < /object>

## PDFObject.js

    PDFObject.js并不是一个PDF渲染工具，它也是通过< embed >标签实现PDF预览：

## PDF.js

    PDF.js可以实现在html下直接浏览pdf文档，是一款开源的pdf文档读取解析插件，非常强大，能将PDF文件渲染成Canvas。

## 说明

    PDFObject使用的< embed >标签可以直接显示PDF文件，速度很快；但是手机上很多浏览器不支持，比如微信的浏览器、小米浏览器，所以我就使用了PDF.js将其渲染成Canvas，速度与PDFObject相比慢多了，但至少能看
