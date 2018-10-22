<!-- Template -->

<template>  
    <base-layout>
        <v-btn @click="$router.push({path: '/about'})">To About</v-btn>
    </base-layout>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';

@Component
export default class Home extends Vue {}
</script>
