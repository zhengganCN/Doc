 const merge = require('webpack-merge');
 const common = require('./webpack.common.js');

 module.exports = merge(common, {
     devtool: 'inline-source-map', //在生产环境开启，定位错误位置
     devServer: { //使用webpack-dev-server的配置
         contentBase: './dist', //告诉开发服务器(dev server)，在哪里查找文件
         hot: true, //开启热更新
         port: 4000, //端口
     },
     mode: 'development', //'development'  or  'production'
     //从 webpack 4 开始，也可以通过 "mode" 配置选项轻松切换到压缩输出，只需设置为 "production"
 });