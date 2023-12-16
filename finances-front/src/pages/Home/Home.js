import React from "react";
import  useAuth  from "../../hooks/useAuth";
import { useNavigate } from "react-router-dom";

export default function Home(){

    const { signout }  = useAuth();
    const navigate = useNavigate();

    const handleLogout = () => {
        signout();
        navigate("/home");
    };

    return (
        <>
        <h2>Bem vindo o Sistema Gerenciador de Empresas</h2>
        <button onClick={handleLogout}>Sair</button>
        </>
    );
}