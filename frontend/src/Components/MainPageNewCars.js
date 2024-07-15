import React from "react"
import NewCarMP from "./MainPageNewCar";
import "../css/MainPage/MPNewCars.css"
import car1 from "../images/Photos/Авто для слайдера/Car 1.jpg"
import car2 from "../images/Photos/Авто для слайдера/Car 2.jpg"
import car3 from "../images/Photos/Авто для слайдера/Car 3.jpg"


class MPNewCars extends React.Component {
    render() {
        return (
            <div className="newCarList">
                <h2>NEW</h2>
                <div id="newCarList">
                    <NewCarMP img={car1}/>
                    <NewCarMP img={car2}/>
                    <NewCarMP img={car3}/>
                </div>
            </div>
        );
    }
}

export default MPNewCars