import Vue from 'vue';
import Router from 'vue-router';
import Home from './views/Home.vue';
import store from './store/store';

Vue.use(Router);

const router = new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
      meta: {
          public: false,
      },
    },
    {
      path: '/about',
      name: 'about',
      meta: {
        public: false,
        role: 'Admin',
    },
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import(/* webpackChunkName: "about" */ './views/About.vue'),
    },
    {
        path: '/login',
        name: 'login',
        meta: {
            public: true,
        },
        component: () => import(/* webpackChunkName: "about" */ './views/public/Login.vue'),
      },
  ],
});

router.beforeEach((to, from, next) => {
    if (to.matched.some((record) => !record.meta.public)) {
        if (store.getters['auth/getToken'] === null) {
            next({
                path: '/login',
                params: { nextUrl: to.fullPath },
            });
        } else {
            if (to.matched.some((record) => record.meta.roles)) {
                if (store.getters['auth/isInRole'](to.meta.roles)) {
                    next();
                } else {
                    next({path: '/error'});
                }
            } else {
                next();
            }
        }
    } else {
        next();
    }
});

export default router;
