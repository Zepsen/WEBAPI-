
<template>
    <v-toolbar fixed height="70" app>
      <v-toolbar-side-icon></v-toolbar-side-icon>
      <v-toolbar-title>Title</v-toolbar-title>
      <v-spacer></v-spacer>
      <v-toolbar-items class="hidden-sm-and-down">
        <v-btn icon>
            <v-icon>search</v-icon>
        </v-btn>
    
        <v-btn icon>
            <v-icon>apps</v-icon>
        </v-btn>
    
        <v-btn icon>
            <v-icon>refresh</v-icon>
        </v-btn>
    
        <v-btn icon>
            <v-icon>more_vert</v-icon>
        </v-btn>
        </v-toolbar-items>
    </v-toolbar>   
</template>

<script>
export default {
  name: "BaseHeader",
  props: {},
  data: () => ({}),

  computed: {},

  methods: {}
};
</script>
