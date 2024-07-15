import React from "react"
import info from "../images/Icons/attention.svg"


class UCNotificationsElem extends React.Component {
    render() {
        return (
            <div className="uc-notif-elem">
                <div>
                    <img src={info} />
                    <section>
                        <h4>notification text</h4>
                        <h6>date</h6>
                    </section>
                </div>
                <img src="" alt="down" />
            </div>
        )
    }
}

export default UCNotificationsElem

