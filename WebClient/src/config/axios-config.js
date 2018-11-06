
import Vue from 'vue';
import axios from 'axios';
import store from '../store/store';
// import VueAxios from 'vue-axios';

axios.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded';
axios.defaults.baseURL = 'https://localhost:44326/';

axios.interceptors.response.use((response) => {
    return response;
}, (error) => {
    if (error.response.status === 401) {        
        store.dispatch("auth/logout");
        router.push({ path: '/login'});
    }
    return Promise.reject(error.response);
});

//Vue.use(VueAxios, axios);