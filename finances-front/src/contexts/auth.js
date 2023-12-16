import { createContext, useEffect, useState } from "react";
import LoginService from "../services/LoginService";

export const AuthContext = createContext({});

export const AuthProvider = ( { children } ) => {
    const [user, setUser] = useState();

    useEffect(() => {
        const userToken = localStorage.getItem("user_token");
        const usr = localStorage.getItem("user");
        console.log(usr);
        if(userToken && usr)
            setUser({name: "aaa"});
    }, []);

    const signin = (user, password, success, error) => {
        let api = LoginService.getInstance();
        api.login(user, password,
        (res) => {
            if(res.status === 200){
                let token = res.data;
                let usr = {name: user};
                localStorage.setItem("user_token", `Bearer ${token}`);
                localStorage.setItem("user", usr);
                setUser(usr);
                success();
            } else {
                setUser(null);
                localStorage.removeItem("user_token");
                localStorage.removeItem("user");
                error(res.response.data.Message);
            }
        });
        


        
    };

    const signup = () => {

    };

    const signout = () => {
        localStorage.removeItem("user_token");
        localStorage.removeItem("user");
        setUser(null);
    };

    return (
        <AuthContext.Provider
            value={{user, signed: !!user, signin, signup, signout}}
        >
            {children}
        </AuthContext.Provider>
    );
};