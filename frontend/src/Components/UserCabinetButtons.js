import React from "react"
import UserCabinet from "../images/Icons/bxs_user-1.svg"
import Adverts from "../images/Icons/mdi_format-list-text.svg"
import CheckedCars from "../images/Icons/material-symbols_fact-check-sharp.svg"
import Notifivations from "../images/Icons/Для хедера/Button notification.svg"
import Search from "../images/Icons/Поиск/Search.svg"
import Fav from "../images/Icons/Для хедера/Button selected.svg"
import Subscriptions from "../images/Icons/material-symbols_mail-sharp.svg"
import Wallet from "../images/Icons/material-symbols_wallet-sharp.svg"
import Calculator from "../images/Icons/oi_calculator.svg"
import Reviews from "../images/Icons/ic_sharp-rate-review.svg"
import DropArrow from "../images/Icons/Для выпадающих списков/Drop arrow.svg"
import Settings from "../images/Icons/material-symbols_settings.svg"
import Logout from "../images/Icons/material-symbols_logout-sharp.svg"
import "../css/UserCabinet/List.css"

class UCButtons extends React.Component {
    render() {
        return (
            <ul id="textButtonsFooter" className="userlistbuttons">
                    <li><button><img src={UserCabinet} alt="" />Особистий кабінет</button></li>
                    <li><button><img src={Adverts} alt="" />Мої оголошення</button><img src={DropArrow} alt="" /></li>
                    <li><button><img src={CheckedCars} alt="" />Мої перевірки авто</button><img src={DropArrow} alt="" /></li>
                    <li><button><img className="green new-size" src={Notifivations} alt="" />Сповіщення</button><img src={DropArrow} alt="" /></li>
                    <li><button><img className="green" src={Search} alt="" />Пошук авто</button><img src={DropArrow} alt="" /></li>
                    <li><button><img className="green new-size" src={Fav} alt="" />Обране</button></li>
                    <li><button><img src={Subscriptions} alt="" />Мої підписки</button></li>
                    <li><button><img src={Wallet} alt="" />Мої рахунки і картки</button><img src={DropArrow} alt="" /></li>
                    <li><button><img src={Calculator} alt="" />Розрахунк вартості авто</button></li>
                    <li><button><img src={Reviews} alt="" />Мої відгуки</button></li>
                    <hr />
                    <li><button><img src={Settings} alt="" />Налаштування</button></li>
                    <li><button><img src={Logout} alt="" />Вихід</button></li>
                </ul>
        )
    }
}

export default UCButtons