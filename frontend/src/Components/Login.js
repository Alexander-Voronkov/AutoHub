import React, { useState } from 'react';
import "../css/Body/LogReg.css"
import Telegram from "../images/Icons/Сервисы, мессендж и т.д/Telegram fill.svg"
import Diia from "../images/Icons/Сервисы, мессендж и т.д/Diia Logo.svg"
import Google from "../images/Icons/Сервисы, мессендж и т.д/bi_google.svg"
import { Link, useNavigate } from 'react-router-dom';



const Login = () => {
    const navigate = useNavigate();

    const [isLoggedIn, setIsLoggedIn] = useState(true); // Поменять

    const handleClick = () => {
        if (isLoggedIn) {
            navigate('/Cabinet');
        } else {
        }
    };

    return (
        <div className="LoginContainer">
            <div className="LoginContent">
                <h2>Вхід до <b>Auto.Hub</b></h2>
                <p>Увійти за допомогою</p>
                <div id="AuthorizeBy">
                    <button><img src={Telegram} /></button>
                    <button><img src={Google} /></button>
                    <button><img src={Diia} /></button>
                </div>
                <p>Або</p>
                <form className="InputUserData">
                    <input placeholder="Телефон або E-mail"></input>
                    <input placeholder="Пароль"></input>
                </form>
                <form className="ToRememberMe">
                    <div>
                        <input type="checkbox" id="rememberMe" />
                        <label for="rememberMe">Запам'ятати мене</label>
                    </div>
                    <url>Забули пароль?</url>
                </form>
                <button id="Enter" onClick={handleClick}>Увійти</button>
                <Link to="/Register"><p>Зареєструватися на Auto.Hub</p></Link>
            </div>
        </div>
    );
};

export default Login