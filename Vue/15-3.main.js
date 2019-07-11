// main.js是项目的JS入口文件

import Vue from '../node_modules/vue/dist/vue'

import login from './login.vue'

var app=new Vue({
    el:'#app',
    data:{
        name:'hello world-'
    },
    render(h) {
        return h(login)
    }
})