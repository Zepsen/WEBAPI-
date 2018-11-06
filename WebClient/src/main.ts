import Vue from 'vue';
import App from './App.vue';
import router from './router';
import store from './store/store';
import './registerServiceWorker';

Vue.config.productionTip = false;

// axios
// tslint:disable-next-line:no-var-requires
require('./config/axios-config');

// vuetify
// tslint:disable-next-line:no-var-requires
require('./config/vuetify-config');

// vee-validate
// tslint:disable-next-line:no-var-requires
require('./config/vee-validate-config');

// Global comps
// tslint:disable-next-line:no-var-requires
require('./config/global-components-config');

new Vue({
  router,
  store,
  render: (h) => h(App),
}).$mount('#app');
