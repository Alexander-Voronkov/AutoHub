import React from "react"
import "../css/CarInfoVertical.css"
import Mileage from "../images/Icons/Для карточек авто/Sharp-speed.svg"
import Volume from "../images/Icons/Для карточек авто/Engine-fill.svg"
import Gear from "../images/Icons/Для карточек авто/Gear-stick.svg"
import FuelType from "../images/Icons/Для карточек авто/Gas-pump.svg"

class CarInfoVertical extends React.Component {
    render() {
        return (
            <div className="v-container">
                <img src={this.props.carImage} className="CarImage"/>
                <div className="v-text-info">
                    <h3>CarName</h3>
                    <hr/>
                    <div className="v-car-properties">
                        <div>
                            <p id="img-text"><img src={Mileage} />Mileage</p>
                            <p id="img-text"><img src={Volume} />Volume/Power</p>
                        </div>
                        <div>
                            <p id="img-text"><img src={FuelType} />FuelType</p>
                            <p id="img-text"><img src={Gear} />GearboxType</p>
                        </div>
                    </div>
                    <hr/>
                    <h4>Price</h4>
                    <button className="v-moreinfo">Дізнатися більше</button>
                </div>
            </div>
        )
    }
}

export default CarInfoVertical

