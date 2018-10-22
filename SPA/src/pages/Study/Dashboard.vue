

<template>    
    <div style="height:1000px">
            BODYYYYYYYY    
            <v-btn @click="onClick">Admin</v-btn>
    </div>
</template>

<script>
    import Vue from "vue";    

    let _data = null;
    let _error = false;
    export default {
        name: "Dashboard",
        data: () => ({
            test: {}
        }),
        
        async beforeRouteEnter(to, from, next) {                                               
            await Vue.axios.get("api/users")
                .then(res => _data = res.data)                
                .catch(err => _error = true);
            
            next();
        },
        created() {
            if(!_error) this.initData(_data);                         
        },        

        methods: {
            initData(data) {
                this.test = data;                
            },

            onClick() {
                this.$router.push({name: 'admin'});
            }

        }
       

    }
</script>

<style scoped>

</style>