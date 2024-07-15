import React from "react"
import logo from "../images/Icons/AutoHubLogo.svg"
import Telegram from "../images/Icons/Для футера/Telegram icon.svg"
import Messanger from "../images/Icons/Для футера/Messenger icon.svg"
import Viber from "../images/Icons/Для футера/Viber icon.svg"
import Email from "../images/Icons/Для футера/Write icon.svg"
import Telephone from "../images/Icons/Для футера/Call icon.svg"

class Footer extends React.Component {
    render() {
        return (
            <div className="CommonStyle HeaderFooter Footer">
                <img id="Logo" src={logo} />
                <ul id="textButtonsFooter">
                    <li><button>Безпечні угоди</button></li>
                    <li><button>Угода про надання послуг</button></li>
                    <li><button>Допомога по сайту</button></li>
                    <li><button>Політика приватності</button></li>
                    <li><button>Вакансії</button></li>
                </ul>
                <div id="contactListFooter">
                    <div>
                        <button><img src={Telegram} /></button>
                        <button><img src={Messanger} /></button>
                        <button><img src={Viber} /></button>
                        <button><img src={Email} /></button>
                        <button><img src={Telephone} /></button>
                    </div>
                    <button id="btnContactUs">Написати нам</button>
                </div>
            </div>
        )
    }
}

export default Footer