<template>
    <base-layout 
        height="100vh"
        :show-header="false"
        :show-nav="false"
        :show-footer="false">
        
        <section class="login-page">
            <v-layout align-center justify-center fill-height>
                <vlogin class="login"></vlogin>    
            </v-layout>
        </section>

    </base-layout>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import vlogin from '@/components/forms/v-login.vue';

@Component({
    components: {
        vlogin,
    },
})
export default class Login extends Vue {

}
</script>

<style lang="less" scoped>
    .login-page {
        height: 100vh;
    }

    .login {
        width: 500px;
    }
</style>


