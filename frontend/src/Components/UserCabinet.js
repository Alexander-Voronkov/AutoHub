import React from "react"
import "../css/UserCabinet/UserCabinet.css"
import UCProfile from "../Components/UserCabinetProfile"
import UCPersonalAccount from "./UserCabinetPersonalAccount"
import UCButtons from "./UserCabinetButtons"
import UCNotifications from "./UserCabinetNotifications"
import UCFavoriteCars from "./UserCabinetFavoriteCars"
import UCAboutCars from "./UserCabinetAboutCars"
import { Link } from 'react-router-dom';


class UserCabinet extends React.Component {
    render() {
        return (
            <div className="bodyComponent">
                <h1>Особистий кабінет</h1>
                <div className="RecLists">
                    <div>
                        <div className="uc-column-l">
                            <UCProfile />
                            <UCPersonalAccount />
                            <Link to="/AddAdvert"><button id="AddAdvert">Додати оголошення</button></Link>
                            <UCButtons />
                        </div>
                    </div>
                    <div className="uc-column-r">
                        <UCNotifications />
                        <hr />
                        <UCFavoriteCars />
                        <hr />
                        <UCAboutCars/>
                    </div>
                </div>
            </div>
        )
    }
}

export default UserCabinet

