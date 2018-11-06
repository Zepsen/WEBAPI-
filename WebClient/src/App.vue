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
        
    }
}
</script>

<style lang="less">

</style>
