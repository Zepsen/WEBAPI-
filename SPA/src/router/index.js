import Vue from 'vue';
import Router from 'vue-router';
import {includes} from "lodash";

// Study
import study from '@/pages/study/_study';
import dashboard from '@/pages/study/dashboard';
import admin from '@/pages/study/admin';

// Public
import login from '@/pages/_Login';

Vue.use(Router)

let router = new Router({
    mode: 'history',
    routes: [
        {
            path: '/',
            name: 'default',
            redirect: "/study/dashboard"
        },

        {
            path: '/Login',
            name: 'login',
            component: login,
            meta: { 
                public: true 
            }
        },

        {
            path: '/study',
            component: study,
            meta: { 
                public: false                
            },
            children: [
                {
                    path: 'dashboard',
                    name: 'dashboard',
                    component: dashboard,
                    meta: { 
                        public: false,                
                    }
                },
                {
                    path: 'admin',
                    name: 'admin',
                    component: admin,
                    meta: { 
                        public: false,   
                        roles: "Admin"             
                    }
                },
            ]
               
        },
        
        
    ]
})

router.beforeEach((to, from, next) => {
    if (to.matched.some(record => !record.meta.public)) {
        if (localStorage.getItem('jwt_token') === null) {
            next({
                path: '/login',
                params: { nextUrl: to.fullPath }
            })
        } else {
            let roles = localStorage.getItem('roles');
            if (to.matched.some(record => record.meta.roles)) {    
                            
                if (_.includes(roles, to.meta.roles)) {
                    next();
                }
                else {
                    next({path: "/error"});
                }
            } else {
                next();
            }
        }
    } else {
        next();
    }
})

export default router;