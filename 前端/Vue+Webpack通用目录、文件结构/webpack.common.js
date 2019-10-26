 const path = require('path');
 const VueLoaderPlugin = require('vue-loader/lib/plugin');
 const HtmlWebpackPlugin = require('html-webpack-plugin');
 const {
     CleanWebpackPlugin
 } = require('clean-webpack-plugin'); //清理 /dist 文件夹 
 const ManifestPlugin = require('webpack-manifest-plugin'); //生成清单文件
 const webpack = require('webpack');

 module.exports = {
     entry: {
         main: path.resolve(__dirname, './src/main.js')
        },
     output: {
         path: path.resolve(__dirname, './dist'),
         filename: '[name].bundle.js',
         //  publicPath: '/'
     },
     optimization: {
         splitChunks: {
             chunks: 'async',
             minSize: 30000,
             maxSize: 0,
             minChunks: 1,
             maxAsyncRequests: 5,
             maxInitialRequests: 3,
             automaticNameDelimiter: '~',
             automaticNameMaxLength: 30,
             name: true,
             cacheGroups: {
                 vendors: {
                     test: /[\\/]node_modules[\\/]/,
                     priority: -10
                 },
                 default: {
                     minChunks: 2,
                     priority: -20,
                     reuseExistingChunk: true
                 }
             }
         }
     },
     plugins: [
         new CleanWebpackPlugin(),
         new ManifestPlugin(),
         new webpack.NamedModulesPlugin(), //查看要修补(patch)的依赖
         new webpack.HotModuleReplacementPlugin(),
         new VueLoaderPlugin(),
         new HtmlWebpackPlugin({
             template: 'index.html',
             title: "ZGBlog"
         })
     ],
     module: { //这个节点，用于配置所有第三方模块加载器
         rules: [ //所有第三方模块的匹配规则
             {
                 test: /\.css$/,
                 use: ['style-loader', 'css-loader']
             }, //  配置处理.css文件的第三方loader规则
             {
                 test: /\.less$/,
                 use: ['style-loader', 'css-loader', 'less-loader']
             }, //配置处理.less文件的第三方 loader规则
             {
                 test: /\.scss$/,
                 use: ['style-loader', 'css-loader', 'sass-loader']
             }, // 配置处理 .scss 文件的 第三方 loader 规则
             {
                 test: /\.(jpg|png|gif|bmp|jpeg|svg|eot|woff|woff2|ttf)$/,
                 use: [{
                     loader: 'url-loader',
                     options: {
                         limit: 8192,// limit 给定的值，是图片的大小，单位是 byte，如果我们引用的图片，大于或等于给定的limit值，则不会被转为base64格式的字符串，如果图片小于给定的limit值，则会被转为base64的字符串
                         name: 'images/[hash:8]-[name].[ext]',
                         //publicPath: '../dist/'//生产环境下放开注释，开发环境下请勿放开注释
                     }
                 }]
             }, // 处理图片路径的loader
             
             {
                 test: /\.vue$/,
                 use: 'vue-loader'
             },
             {
                 test: /\.m?js$/,
                 exclude: /(node_modules|bower_components)/,
                 use: {
                     loader: 'babel-loader',
                     options: {
                         presets: ['@babel/preset-env']
                     }
                 }
             }
         ]
     },
     resolve: {
         alias: { //加载模块路径，便于在js文件中导入
             jquery: path.resolve(__dirname, './node_modules/jquery/dist/jquery.js'),
             vue: path.resolve(__dirname, "./node_modules/vue/dist/vue.js"),
             vueRoute: path.resolve(__dirname, "./node_modules/vue-router/dist/vue-router.js"),
             vuex: path.resolve(__dirname, "./node_modules/vuex/dist/vuex.js")
         }
     }
 };