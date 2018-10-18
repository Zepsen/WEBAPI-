

<template>
    <!-- <base-layout> -->
        <div>
            BODYYYYYYYY    
        </div>
    <!-- </base-layout> -->
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

        }
       

    }
</script>

<style scoped>

</style>