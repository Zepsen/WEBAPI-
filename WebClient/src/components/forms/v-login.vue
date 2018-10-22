

<template>
    <section>
        <v-layout justify-center column fill-height ma-3>
            <v-text-field
                v-validate="'required|email'"                
                v-model="email"
                :error-messages="errors.collect('email')"
                label="E-mail"
                data-vv-name="email"
                required
            ></v-text-field>
            
            <v-text-field
                v-model="password"
                v-validate="'required|min:6'"
                :error-messages="errors.collect('password')"
                data-vv-name="password"
                :append-icon="showPassword ? 'visibility_off' : 'visibility'"
                :type="showPassword ? 'text' : 'password'"              
                label="Password"
                hint="At least 6 characters"              
                @click:append="showPassword = !showPassword"
            ></v-text-field>

            <v-checkbox
                v-if="showRememberMe"
                v-model="rememberMe"                
                value="1"
                label="Remember me"
                data-vv-name="checkbox"
                type="checkbox"                
            ></v-checkbox>

            <v-alert v-if="showError" :value="true" type="error">
                <span v-for="(err,i) in serverErrors" :key="i">{{err}}</span>
            </v-alert>
        
            <v-btn @click.enter="onSubmit" 
                   dark
                   color="info"
                   :loading="load"
            >Login</v-btn>
        </v-layout>
    </section>
</template>


<script lang="ts">
import { Component, Vue, Prop, Inject } from 'vue-property-decorator';
import { Validator } from 'vee-validate';
import axios from 'axios';

@Component({
    $_veeValidate: { validator: "new" },
})
export default class LoginForm extends Vue {
    @Prop({ default: true }) private showRememberMe!: boolean;
    @Inject('$validator') public $validator!: Validator;

    private load        : boolean = false;
    private showError   : boolean = false;
    private serverErrors: any;
    private password    : string  = '';
    private email       : string  = '';    
    private rememberMe  : boolean = false;               
    private showPassword: boolean = false;

    onSubmit(): void {
            this.serverErrors = [];
            this.showError = false;
            
            this.$validator.validate().then((result: any) => {
                if (result) {
                    this.load = true;
                    axios.post("/api/account/login", {
                        Email: this.email,
                        Password: this.password,
                        RememberMe: this.rememberMe
                    })
                    .then((res: any) => {        
                        this.$store.dispatch("auth/login", res.data);
                        this.$router.push({path: this.$store.getters["auth/getReturnUrl"]});  
                    })
                    .catch((err: any) => {
                            //let model = err.response.data.Object.ModelErrors;
                                // if(model.result === "ValidationFail") {
                                //     this.serverErrors = [];

                                //     let indexName = _.indexOf(model.errorKeys, "Email");
                                //     let indexPassword = _.indexOf(model.errorKeys, "Password");                                    
                                //     let indexLogin = _.indexOf(model.errorKeys, "LoginError");

                                //     if(indexName > -1) 
                                //         this.serverErrors.push(model.errorMessages[indexName]);
                                    
                                //     if(indexPassword > -1) 
                                //         this.serverErrors.push(model.errorMessages[indexPassword]);

                                //     if(indexLogin > -1) 
                                //         this.serverErrors.push(model.errorMessages[indexLogin]);

                                //     this.showError = true;
                                 
                                // }        
                                
                    })
                    .then(() => this.load = false);
                }
            });
    }
}
</script>



