
<template>
    <v-footer class="footer"
      height="auto"      
    >
      <v-layout
        justify-center
        row
        wrap
      >
        <v-btn
          v-for="link in links"
          :key="link"          
          flat
          round
        >
          {{ link }}
        </v-btn>
        <v-flex          
          lighten-2
          py-3
          text-xs-center         
          xs12
        >
          &copy;2018 — <strong>Vuetify</strong>
        </v-flex>
      </v-layout>
    </v-footer> 
</template>

<script>

export default {
    name: "BaseFooter",
    props: {
        
    },
    data: () => ({
        links: [
            'Home',
            'About Us',
            'Team',
            'Services',
            'Blog',
            'Contact Us'
        ]
    }),

    computed:{
        
    },

    methods: {
        
    }
    
}
</script>

<style scoped>
    .footer {
        /* margin-left: 80px; */
    }
</style>
