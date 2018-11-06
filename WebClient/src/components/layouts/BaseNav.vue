
<template>
    <v-navigation-drawer class="navbar"
        v-model="drawer"
        :mini-variant="mini"
        app
        dark       
        stateless>
        <v-list class="pt-0" dense>    
          <v-list-tile
            v-for="item in items"
            :key="item.title"
          >
            <v-list-tile-action>
              <v-icon>{{ item.icon }}</v-icon>
            </v-list-tile-action>
  
            <v-list-tile-content>
              <v-list-tile-title>{{ item.title }}</v-list-tile-title>
            </v-list-tile-content>
          </v-list-tile>
          <v-divider light></v-divider>
        </v-list>

        <v-list class="pa-1">
          <v-list-tile @click.stop="mini = !mini">
            <v-list-tile-action>
              <v-icon v-if="mini">chevron_right</v-icon>
              <v-icon v-else>chevron_left</v-icon>
            </v-list-tile-action>
          </v-list-tile>          
        </v-list>
      </v-navigation-drawer>
</template>



<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator';

@Component
export default class BaseNav extends Vue {
    private drawer: boolean = true;
    private mini: boolean = true;
    private items: object[] = [
        { title: 'Home', icon: 'dashboard' },
        { title: 'About', icon: 'question_answer' },
    ];
}
</script>


<style scoped lang="less">
    .navbar {        
        z-index: 5;
    }
</style>

