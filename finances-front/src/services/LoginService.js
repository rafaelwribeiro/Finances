import axios from 'axios';

export default class LoginService
{
    _URL = 'http://localhost:5000';
    _instance = null;

    static getInstance(){
        if(!this._instance)
        this._instance =  new LoginService();
        return this._instance;
    }

    login = (userName, password, callback)=>{
        let data = {
            userName,
            password 
        };
        axios.post(`${this._URL}/login`, data)
            .then(res => {
                callback(res);
            })
            .catch( err => {
                callback(err);
            });
    }


}