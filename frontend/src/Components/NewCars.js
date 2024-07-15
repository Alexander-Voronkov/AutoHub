import React from "react"
import search from "../images/Icons/Поиск/Search.svg"
import "../css/NewCars.css"
import CarInfoVertical from "./CarInfoVertical"
import Paginator from "./Pagination"
import car1 from "../images/Photos/Авто для слайдера/Car 6.jpg"
import Carlogos from "./carlogoslist"


class NewCars extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            page: 1,
            carsPerPage: 6,
            maxPages: 300,
        };
        this.handlePageChange = this.handlePageChange.bind(this);
    }

    handlePageChange(newPage) {
        this.setState({ page: newPage });
    }

    render() {

        const cars = Array.from({ length: this.state.carsPerPage }, (_, index) => (
            <CarInfoVertical key={index} carImage={car1} />
        ));
        return (
            <div className="bodyComponent">
                <div>
                    <div>
                        <h1 className="nc-h1">Каталог нових авто</h1>
                        <div className="input-container">
                            <img className="input-icon" src={search} />
                            <input className="wrapper styled-input" />
                        </div>
                    </div>
                    <div className="grid-cars">
                        {cars}
                    </div>
                    <Paginator
                        page={this.state.page}
                        maxPages={this.state.maxPages}
                        onPageChange={this.handlePageChange}
                    />
                    <div>
                        <h1>Обрати за виробником</h1>
                        <Carlogos/>
                    </div>
                </div>
            </div>
        )
    }
}

export default NewCars

