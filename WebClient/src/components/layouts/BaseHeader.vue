
<template>
    <v-toolbar app fixed height="70">
        <v-img src="https://picsum.photos/510/300?random" max-width="150" height="50"></v-img>      
        <v-spacer></v-spacer>
        <v-toolbar-items class="hidden-sm-and-down">
                    
            <v-btn icon>
                <v-icon>date_range</v-icon>
            </v-btn>
        
            <v-btn icon>
                <v-icon>notifications</v-icon>
            </v-btn>        
            
            <v-menu :nudge-width="200" open-on-hover>                
                <v-btn icon  slot="activator">
                    <v-icon>account_circle</v-icon>
                </v-btn>
                <v-list>
                    <v-list-tile
                    v-for="item in items"
                    :key="item">
                        <v-list-tile-action>
                            <v-icon color="pink">star</v-icon>
                        </v-list-tile-action>
                        <v-list-tile-title v-text="item"></v-list-tile-title>
                    </v-list-tile>
                </v-list>
            </v-menu>
        </v-toolbar-items>
    </v-toolbar>   
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator';

@Component
export default class BaseHeader extends Vue {
  private items: string[] = ['All', 'Family', 'Friends', 'Coworkers'];
}
</script>

