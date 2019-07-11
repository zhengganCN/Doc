const path = require('path')

// 导入在内存中生成 HTML 页面的 插件
// 只要是插件，都一定要 放到 plugins 节点中去
// 这个插件的两个作用：
//  1. 自动在内存中根据指定页面生成一个内存的页面
//  2. 自动，把打包好的 bundle.js 追加到页面中去
const htmlWebPagePlugin = require('html-webpack-plugin')

// 这个配置文件，其实就是一个JS文件，通过Node中的模块操作，向外暴露一个配置对象
module.exports = {
    entry: path.join(__dirname, 'src/main.js'), //需打包的文件
    output: {
        path: path.join(__dirname, 'dist'), //生成文件的输出目录
        filename: 'bundle.js' //生成的文件名 
    },
    plugins: [
        new htmlWebPagePlugin({ //创建一个内存中的页面
            template: path.join(__dirname, 'src/index.html'), //指定模板页面,将来会根据指定的模板页面来生成内存中的页面
            filename: 'index.html' //指定生成的内存中的页面
        })
    ]
}