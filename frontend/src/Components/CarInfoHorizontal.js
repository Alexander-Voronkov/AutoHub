import React from "react"
import "../css/CarInfoHorizontal.css"
import Mileage from "../images/Icons/Для карточек авто/Sharp-speed.svg"
import Volume from "../images/Icons/Для карточек авто/Engine-fill.svg"
import Gear from "../images/Icons/Для карточек авто/Gear-stick.svg"
import FuelType from "../images/Icons/Для карточек авто/Gas-pump.svg"

class CarInfoHorizontal extends React.Component {
    render() {
        return (
            <div className="h-container">
                <img src={this.props.carImage} />
                <div className="h-text-info">
                    <h3>CarName</h3>
                    <h4>Price</h4>
                    <div className="h-car-properties">
                        <div>
                            <p id="img-text"><img src={Mileage} />Mileage</p>
                            <p id="img-text"><img src={Volume} />Volume/Power</p>
                        </div>
                        <div>
                            <p id="img-text"><img src={FuelType} />FuelType</p>
                            <p id="img-text"><img src={Gear} />GearboxType</p>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}

export default CarInfoHorizontal

