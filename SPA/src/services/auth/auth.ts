

export class Auth {        
    private static _instance: Auth = new Auth();
    private static _isAuth: Boolean = false;
    
    constructor() {               
        if(Auth._instance){
            throw new Error("Error: Instantiation failed: Use SingletonClass.getInstance() instead of new.");
        }

        Auth._instance = this;
    }

    public static getInstance() : Auth {
        return Auth._instance;
    }

    public static init() : void
    {        
        this._isAuth = localStorage.getItem("jwt_token") !== null;
    }

    public static login(data: any) : void {
        localStorage.setItem("jwt_token", data.token);
        localStorage.setItem("roles", data.roles);
        this._isAuth = true;
    }

    public static logout() : void {
        localStorage.removeItem('jwt_token');
        this._isAuth = false;
    }
}