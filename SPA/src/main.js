// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'

Vue.config.productionTip = false

//axios
import axios from "axios";
import VueAxios from 'vue-axios'
axios.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded';
axios.defaults.baseURL = 'https://localhost:44326/';
axios.defaults.headers.common['Authorization'] 
    = "Bearer " + "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoidGVzdEB0ZXN0LmNvbSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6WyJBZG1pbiIsIlVzZXIiXSwibmJmIjoxNTM5ODY3OTI0LCJleHAiOjE1Mzk4NzE1MjQsImlzcyI6Ik15QXV0aFNlcnZlciIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTE4ODQvIn0.oWkuquCM6_kKtNZDnVC2-uV2Tq7Zk1Km9bOxmWPRT4I"

axios.interceptors.response.use((response) => {
    return response;
}, function (error) {    
    if (error.response.status === 401) {
        console.log('unauthorized, logging out ...');
        // auth.logout();        
        //router.replace('/auth/login');
        //location.href = "/#/login"
    }
    return Promise.reject(error.response);
});
Vue.use(VueAxios, axios)

//vuetify
import Vuetify from 'vuetify' 
Vue.use(Vuetify)
import 'vuetify/dist/vuetify.min.css'


import Comps from "@/modules/GlobalComponents.js";

/* eslint-disable no-new */
new Vue({
    el: '#app',
    router,
    components: { App },
    template: '<App/>'
})

