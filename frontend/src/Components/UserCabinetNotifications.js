import React from "react"
import Notifivations from "../images/Icons/Для хедера/Button notification.svg"
import UCNotificationsElem from "../Components/UserCabinetNotificationElem"

class UCNotifications extends React.Component {
    render() {
        return (
            <div>
                <h3 id="img-text"><img className="green new-size" src={Notifivations} />Сповіщення</h3>
                <div className="scroll-container">
                    <UCNotificationsElem />
                    <UCNotificationsElem />
                    <UCNotificationsElem />
                    <UCNotificationsElem />
                    <UCNotificationsElem />
                    <UCNotificationsElem />
                    <UCNotificationsElem />
                    <UCNotificationsElem />
                    <UCNotificationsElem />
                    <UCNotificationsElem />
                    <UCNotificationsElem />
                    <UCNotificationsElem />
                </div>
            </div>

        )
    }
}

export default UCNotifications

