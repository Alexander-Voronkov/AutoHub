import React from "react"
import editProfile from "../images/Icons/Для объявления/Edit-fill.svg"
import userProfileAlt from "../images/Icons/bxs_user.svg"
import "../css/UserCabinet/Profile.css"

class UCProfile extends React.Component {
    render() {
        return (
            <div className="ProfileCard">
                <div className="profileInfo">
                    <img id="userPicture" src={userProfileAlt} alt="profile picture" />
                    <div>
                        <h3>User name</h3>
                        <p>ID: 1234567</p>
                        <p>+380123456789</p>
                    </div>
                </div>
                <button id="editProfile"><img src={editProfile} /></button>
            </div>
        )
    }
}

export default UCProfile