// main.js是项目的JS入口文件

import Vue from '../node_modules/vue/dist/vue'

import app from './app.vue';
import login from './login.vue'

import register from './register.vue'
import VueRouter from '../node_modules/vue-router'


Vue.use(VueRouter)

// 路由配置
var router = new VueRouter({
    routes: [{
            path: '/login',
            component: login
        },
        {
            path: '/register',
            component: register
        }
    ]
})

var myapp = new Vue({
    el: '#app',
    data: {
        name: 'hello world'
    },
    render(h) {
        return h(app)
    },
    router
})