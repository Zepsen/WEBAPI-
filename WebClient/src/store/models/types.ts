

export interface RootState {
    auth: AuthState,
}

export interface AuthState {
    token: string | null;
    isAuth: boolean;
    roles: string[];
    returnUrl: string;
};



