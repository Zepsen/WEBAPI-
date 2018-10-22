
import { AuthState, RootState } from '../models/types';
import { GetterTree, MutationTree, ActionTree } from 'vuex';
import { includes } from 'lodash';

const TOKEN: string = 'token';
const ROLESKEY: string = 'roles';

const state: AuthState = {
    token: localStorage.getItem(TOKEN),
    isAuth: false,
    roles: localStorage.getItem(ROLESKEY),
    returnUrl: '/',
};

const getters: GetterTree<AuthState, RootState> = {
    getToken(state, getters, rootState) {
        return state.token;
    },

    getReturnUrl(state) {
        return state.returnUrl;
    },

    isInRole: (state) => (role: string): boolean => {
        return includes(state.roles, role);
    },
};

const mutations: MutationTree<AuthState> = {
    setLoginData(state, data: any) {
        state.token = data.token;
        state.roles = data.roles;
        state.returnUrl = data.returnUrl || '/';
        state.isAuth = true;
        localStorage.setItem(TOKEN, data.token);
        localStorage.setItem(ROLESKEY, data.roles);
    },

    cleanData(state) {
        state.token = null;
        state.roles = [];
        state.returnUrl = '/';
        state.isAuth = false;
        localStorage.removeItem(TOKEN);
        localStorage.removeItem(ROLESKEY);
    },
};

const actions: ActionTree<AuthState, RootState> = {
    login({ commit, rootState }, data: any): void {
        commit('setLoginData', data);
    },

    logout({ commit }): void {
        commit('cleanData');
    },
};


export default {
    namespaced: true,
    state,
    getters,
    mutations,
    actions,
};

