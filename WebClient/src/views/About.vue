<template>  
    <base-layout>
        <v-btn @click="$router.push({path: '/'})">To Home</v-btn>
    </base-layout>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';

@Component
export default class About extends Vue {}
</script>
