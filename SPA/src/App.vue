<template>
  <v-app id="app">
    <base-nav></base-nav>
    <base-header></base-header>    
    <v-content class="app__body">
        <v-container fluid class="pa-0">
            <router-view></router-view>
        </v-container>
    </v-content>    
    <base-footer></base-footer>
  </v-app>
</template>

<script>
import BaseHeader from "@/layouts/BaseHeader.vue";
import BaseFooter from "@/layouts/BaseFooter.vue";
import BaseNav from "@/layouts/BaseNav.vue";
export default {
  name: "App",
  components: {
    BaseHeader,
    BaseFooter,
    BaseNav
  }
};
</script>

<style>
.app__body {
    margin-top: 70px;
}
</style>
