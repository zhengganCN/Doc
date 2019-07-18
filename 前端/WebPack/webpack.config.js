//通用webpack配置文件

const path = require('path');
const VueLoaderPlugin = require('vue-loader/lib/plugin');

module.exports = {
    entry: path.join(__dirname, 'src/main.js'),
    output: {
        path: path.join(__dirname, 'dist'),
        filename: 'bundle.js'
    },
    plugins:
    [
        new VueLoaderPlugin()
    ],
    module: { //这个节点，用于配置所有第三方模块加载器
        rules: [ //所有第三方模块的匹配规则
            {
                test: /\.css$/,
                use: ['style-loader', 'css-loader']
            }, //  配置处理 .css 文件的第三方loader 规则
            {
                test: /\.less$/,
                use: ['style-loader', 'css-loader', 'less-loader']
            }, //配置处理 .less 文件的第三方 loader 规则
            {
                test: /\.scss$/,
                use: ['style-loader', 'css-loader', 'sass-loader']
            }, // 配置处理 .scss 文件的 第三方 loader 规则
            {
                test: /\.(jpg|png|gif|bmp|jpeg)$/,
                use: 'url-loader?limit=7631&name=[hash:8]-[name].[ext]'
            }, // 处理 图片路径的 loader
            // limit 给定的值，是图片的大小，单位是 byte， 如果我们引用的 图片，大于或等于给定的 limit值，则不会被转为base64格式的字符串，如果 图片小于给定的 limit 值，则会被转为 base64的字符串
            {
                test: /\.vue$/,
                use: 'vue-loader'
            }
        ]
    }
}