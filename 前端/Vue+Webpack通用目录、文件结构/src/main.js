import Vue from "vue";
import VueRoute from "vueRoute"
import routes from "./js/routes.js";
import { store } from "./js/vuex.js";
import app from "./app.vue";

Vue.use(VueRoute);

axios.defaults.baseURL = 'http://101.132.176.83:12355/api';

Vue.filter("time",function(value){
    if(value==null){
        return "";
    }
    var date=new Date(value);
    return date.getFullYear()+"-"+date.getMonth()+"-"+date.getDate()+" "+date.getHours()+":"+date.getMinutes()+":"+date.getSeconds();
})

const router=new VueRoute({
    routes
});

new Vue({
    el:"#app",
    store,
    render(h){
        return h(app);
    },
    router
})