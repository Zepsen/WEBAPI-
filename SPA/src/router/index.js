import Vue from 'vue';
import Router from 'vue-router';
import Dashboard from '@/pages/Dashboard';
import Login from '@/pages/_Login';

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Dashboard',
      component: Dashboard,
      public: false,
    },
    {
        path: '/Login',
        name: 'Login',
        component: Login,
        public: true,
    },
  ]
})
