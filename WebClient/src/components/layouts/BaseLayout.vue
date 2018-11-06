
<template>    
    <v-app>
        <slot name="header" v-if="isShowHeader">
            <base-header></base-header>
        </slot>            

        <slot name="nav" v-if="isShowNav">
            <base-nav></base-nav>
        </slot>  
        
        <v-content>
            <v-container fluid class="pa-0">
                <slot>
                    
                </slot>
            </v-container>
        </v-content>
                
        <slot name="footer" v-if="isShowFooter">
            <base-footer></base-footer>
        </slot>            
    </v-app>
</template>


<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator';
import BaseHeader from './BaseHeader.vue';
import BaseFooter from './BaseFooter.vue';
import BaseNav from './BaseNav.vue';

@Component({
    components: {
        BaseFooter, BaseHeader, BaseNav,
    },
})
export default class BaseLayout extends Vue {
  @Prop({ default: true }) private showHeader!: boolean;
  @Prop({ default: true }) private showNav   !: boolean;
  @Prop({ default: true }) private showFooter!: boolean;

  get isShowHeader(): boolean {
    return this.showHeader;
  }

  get isShowFooter(): boolean {
    return this.showFooter;
  }

  get isShowNav(): boolean {
    return this.showNav;
  }
}
</script>


