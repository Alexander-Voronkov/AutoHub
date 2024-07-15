import React from "react"
import "../css/Body/LogReg.css"
import Telegram from "../images/Icons/Сервисы, мессендж и т.д/Telegram fill.svg"
import Diia from "../images/Icons/Сервисы, мессендж и т.д/Diia Logo.svg"
import Google from "../images/Icons/Сервисы, мессендж и т.д/bi_google.svg"
import { Link } from "react-router-dom";


class Login extends React.Component {
    render() {
        return (
            <div className="LoginContainer">
                <div className="LoginContent">
                    <h2>Регістрація на сайті <b>Auto.Hub</b></h2>
                    <form className="InputUserData">
                        <input placeholder="Ім'я"></input>
                        <input placeholder="Прізвище"></input>
                        <input placeholder="Телефон або E-mail"></input>
                        <input placeholder="Пароль"></input>
                    </form>
                    <form className="ToRememberMe">
                        <div>
                            <input type="checkbox" id="rememberMe" />
                            <label for="rememberMe">Приймаю умови</label>
                        </div>
                    </form>
                    <p>Зареєструватися через</p>
                    <div id="AuthorizeBy">
                        <button><img src={Telegram} /></button>
                        <button><img src={Google} /></button>
                        <button><img src={Diia} /></button>
                    </div>
                    <button id="Enter">Зареєструватися</button>
                    <Link to="/Login"><p>Вже зареєстровані?</p></Link>
                </div>
            </div>
        )
    }
}

export default Login