
<template>    
    <base-layout 
        height="100vh"
        :show-header="false"
        :show-nav="false"
        :show-footer="false">
        
        <section class="login-page">
            <v-layout align-center justify-center fill-height>
                <vlogin class="login" @onlogin="onLogin"></vlogin>    
            </v-layout>
        </section>

    </base-layout>
</template>

<script>
import vlogin from "@/components/forms/v-login.vue";

export default {
  name: "LoginPage",
  components: {
    vlogin
  },

  data: () => ({
    
  }),

  created() {},

  methods: {
    onLogin() {
        
    }
  }
};
</script>

<style scoped>
    .login-page {
        height: 100vh;
    }

    .login {
        width: 500px;
    }
</style>

