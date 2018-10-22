<template>
  <main id="app">
      <router-view></router-view>    
  </main>
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
