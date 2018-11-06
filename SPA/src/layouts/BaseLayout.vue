
<template>    
    <v-app>
        <slot name="header" v-if="showHeader">
            <base-header></base-header>
        </slot>            

        <slot name="nav" v-if="showNav">
            <base-nav></base-nav>
        </slot>  
        
        <v-content>
            <v-container fluid class="pa-0">
                <slot>
                    
                </slot>
            </v-container>
        </v-content>
                
        <slot name="footer" v-if="showFooter">
            <base-footer></base-footer>
        </slot>            
    </v-app>
</template>

<script>
import BaseHeader from "./BaseHeader.vue";
import BaseFooter from "./BaseFooter.vue";
import BaseNav from "./BaseNav.vue";

export default {
  name: "BaseLayout",
  props: {
      showHeader: {
          type: Boolean,
          default: true
      },
      showNav: {
          type: Boolean,
          default: true
      },
      showFooter: {
          type: Boolean,
          default: true
      },
      
  },
  components: {
    BaseHeader,
    BaseFooter,
    BaseNav
  },

  data: () => ({}),

  computed: {}
};
</script>

