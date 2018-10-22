import { includes } from 'lodash';

export default {
    namespaced: true,
    state: {
        token: null,
        isAuth: false,
        roles: [],
        returnUrl: '/',
    },
    getters: {
        getToken(state: any) {
            return state.token;
        },

        getReturnUrl(state: any) {
            return state.returnUrl;
        },

        isInRole: (state: any) => (role: string): boolean => {
            return includes(state.roles, role);
        },
    },
    mutations: {
        setLoginData(state: any, data: any) {
            state.token = data.token;
            state.roles = data.roles;
            state.returnUrl = data.returnUrl || '/';
            state.isAuth = true;
        },

        cleanData(state: any) {
            state.token = null;
            state.roles = [];
            state.returnUrl = null;
            state.isAuth = false;
        },
    },
    actions: {
        login({commit}: any, data: any ): void {
            commit('setLoginData', data);
        },

        logout({commit}: any): void {
            commit('cleanData');
        },
    },
};
