<template>
  <main id="app">    
    <router-view/>
  </main>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';

@Component
export default class App extends Vue {
    created () {
        console.log('create');
    }
}
</script>

<style lang="less">

</style>
