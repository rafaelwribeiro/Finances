import React, {useState} from "react";
import  useAuth  from "../../hooks/useAuth";
import { Link, useNavigate } from "react-router-dom";
import styles from "./Signin.module.css";
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import Avatar from '@mui/material/Avatar';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';

export default function Signin(){

    const { signin }  = useAuth();
    const navigate = useNavigate();

    const [login, setLogin] = useState("");
    const [password, setPassword] = useState("");
    const [error, setError] = useState("");

    const handleLogin = () => {
        if (!login | !password){
            setError("Preencha todos os campos");
            return;
        }

        signin(login, password, 
            () => {
                setError("");
                navigate("/home");
            },
            (res) => {
                setError(res);
            }
        );
    };

    return (
        <div className={styles.signinContainer}>
            <div className={styles.signinBox}>
                <center>
                <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
                    <LockOutlinedIcon />
                </Avatar>
                <Typography component="h1" variant="h5">
                    Sign in
                </Typography>
                </center>
                <TextField
                    margin="normal"
                    required
                    fullWidth
                    id="login"
                    label="Login"
                    name="login"
                    //autoComplete="email"
                    autoFocus
                    value={login} onChange={(e) => [setLogin(e.target.value), setError("")]}
                />

                <TextField
                    margin="normal"
                    required
                    fullWidth
                    name="password"
                    label="Password"
                    type="password"
                    id="password"
                    autoComplete="current-password"
                    value={password} onChange={(e) => [setPassword(e.target.value), setError("")]}
                />


                <br />

                <label className={styles.signinError}>{error}</label>
                <br />

                
                <Button
                    fullWidth
                    variant="contained"
                    sx={{ mt: 3, mb: 2 }}
                    onClick={handleLogin}
                    >Login</Button>

                <br />
                <label>Não tem uma conta? <strong> <Link to="/signup">registre-se</Link></strong></label>
            </div>
        </div>
    );
}