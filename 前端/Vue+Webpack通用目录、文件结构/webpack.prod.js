const webpack = require('webpack');
const merge = require('webpack-merge');
const common = require('./webpack.common.js');
const UglifyJSPlugin = require('uglifyjs-webpack-plugin');


module.exports = merge(common, {
    mode: 'production', //'development'  or  'production'
    devtool: 'source-map', //生产环境中启用 source map，因为它们对调试源码(debug)和运行基准测试(benchmark tests)很有帮助
    plugins: [
        new UglifyJSPlugin({
            sourceMap: true
        }),
        new webpack.DefinePlugin({
            'process.env.NODE_ENV': JSON.stringify('production')
        })
    ]
});