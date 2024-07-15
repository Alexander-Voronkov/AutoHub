import React from 'react';
import { Outlet, Link } from "react-router-dom";
import logo from "../images/Icons/AutoHubLogo.svg"
import fav from "../images/Icons/Для хедера/Button selected.svg"
import notifivations from "../images/Icons/Для хедера/Button notification.svg"
import user from "../images/Icons/Для хедера/Button user.svg"

const Header = () => {
  return (
    <div>
      <div className="CommonStyle HeaderFooter Header">
        <Link to="/"><img id="Logo" src={logo} alt="AutoHubLogo" /></Link>
        <div>
          <Link to="/UsedCars"><button className="hover-underline-animation">Вживані авто</button></Link>
          <Link to="/NewCars"><button className="hover-underline-animation">Нові авто</button></Link>
          <Link to="/News"><button className="hover-underline-animation">Новини</button></Link>
          <Link to="*"><button className="hover-underline-animation">Все для авто</button></Link>
        </div>
        <div id="imgButtons">
          <Link to="Cabinet"><img src={fav} alt="FavoriteCars" /></Link>
          <Link to="*"><img src={notifivations} alt="Notifications" /></Link>
          <Link to="/Login"><img src={user} alt="User" /></Link>
        </div>
      </div>
      <Outlet />
    </div>
  );
};

export default Header;
