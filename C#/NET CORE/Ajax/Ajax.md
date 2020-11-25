# Ajax

## 1、前端JQuery代码

```javascript
$.get({
    url: "/Course/CourseChapter",
    data: { "courseId": courseId },
    success: function (data) {
        alter(data);
    }
});
$.post({
    url: "/Course/Chapter",
    data: { "courseId": courseId },
    success: function (data) {
        alter(data);
    }
});
```

## 2、ASP.NET Core代码

```C#
//Ajax调用,返回课程章节信息
[HttpGet]
public JsonResult CourseChapter()
{
    string courseId=Request.Query["courseId"].ToString();
    if (string.IsNullOrEmpty(courseId))
    {
        return null;
    }
    var chapters= _chapterDaoImpl.SelectByCourseId(courseId);
    List<ChapterViewModel> models = new List<ChapterViewModel>();
    foreach (var item in chapters)
    {
        ChapterViewModel chapter = new ChapterViewModel
        {
            CourseChapter = item.CourseChapter
        };
        models.Add(chapter);
    }
    return Json(models);
}
[HttpPost]
public JsonResult Chapter()
{
    string courseId=Request.Form["courseId"].ToString();
    if (string.IsNullOrEmpty(courseId))
    {
        return null;
    }
    var chapters= _chapterDaoImpl.SelectByCourseId(courseId);
    List<ChapterViewModel> models = new List<ChapterViewModel>();
    foreach (var item in chapters)
    {
        ChapterViewModel chapter = new ChapterViewModel
        {
            CourseChapter = item.CourseChapter
        };
        models.Add(chapter);
    }
    return Json(models);
}
```
