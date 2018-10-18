<template>
  <v-app id="app">
    <base-nav></base-nav>
    <base-header></base-header>    
    <v-content>
        <v-container fluid>
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
</style>
