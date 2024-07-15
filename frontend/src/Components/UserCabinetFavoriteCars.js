import React from "react"
import CarInfoHorizontal from "./CarInfoHorizontal"
import Fav from "../images/Icons/Для хедера/Button selected.svg"
import car1 from "../images/Photos/Авто для слайдера/Car 6.jpg"
import car2 from "../images/Photos/Авто для слайдера/Car 4.jpg"

class UCFavoriteCars extends React.Component {
    render() {
        return (
            <div>
                <h3 id="img-text"><img className="green new-size" src={Fav} />Обране</h3>
                <div>
                    <CarInfoHorizontal carImage={car1}/>
                    <CarInfoHorizontal carImage={car2}/>
                </div>
            </div>
        )
    }
}

export default UCFavoriteCars

