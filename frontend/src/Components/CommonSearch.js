import React from "react";
import search from "../images/Icons/Поиск/Search.svg"
import check from "../images/Icons/Для чекбокса/Check.svg"
import CarInfoVertical from "./CarInfoVertical"
import Paginator from "./Pagination"
import car1 from "../images/Photos/Авто для слайдера/Car 6.jpg"

class CommonSearch extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            isClickedUAH: false,
            isClickedUSD: false,
            isClickedEUR: false,
            page: 1,
            carsPerPage: 12,
            maxPages: 300,
        };
        this.handleUAH = this.handleUAH.bind(this);
        this.handleUSD = this.handleUSD.bind(this);
        this.handleEUR = this.handleEUR.bind(this);
        this.handlePageChange = this.handlePageChange.bind(this);
    }

    handleUAH() {
        this.setState({ isClickedUAH: !this.state.isClickedUAH });
    }

    handleUSD() {
        this.setState({ isClickedUSD: !this.state.isClickedUSD });
    }

    handleEUR() {
        this.setState({ isClickedEUR: !this.state.isClickedEUR });
    }

    handlePageChange(newPage) {
        this.setState({ page: newPage });
    }
    render() {
        const cars = Array.from({ length: this.state.carsPerPage }, (_, index) => (
            <CarInfoVertical key={index} carImage={car1} />
        ))
        return (
            <div className="bodyComponent">
                <div>
                    <h1 className="nc-h1">Знайти авто</h1>
                    <div className="input-container">
                        <img className="input-icon" src={search} />
                        <input className="wrapper styled-input" />
                        <button id="SellCarBtn" className="adv-search-button">Уточнити пошук</button>
                    </div>
                </div>
                <div className="RecLists">
                    <div className="used-column-l">
                        <div className="used-dropdowns" id="dropdown">
                            <h4>Тип транспорту</h4>
                            <select className="wrapper" id="CarType">
                                <option value="all">Усі типи</option>
                            </select>
                        </div>
                        <div className="used-dropdowns" id="dropdown">
                            <h4>Тип кузова</h4>
                            <select className="wrapper" id="CarType">
                                <option value="all">Усі кузови</option>
                            </select>
                        </div>
                        <div className="used-dropdowns" id="dropdown">
                            <h4>Марка</h4>
                            <select className="wrapper" id="CarMark">
                                <option value="all">Усі марки</option>
                            </select>
                        </div>
                        <div className="used-dropdowns" id="dropdown">
                            <h4>Модель</h4>
                            <select className="wrapper" id="CarModel">
                                <option value="all">Усі моделі</option>
                            </select>
                        </div>
                        <div className="used-dropdowns" id="dropdown">
                            <h4>Рік випуску</h4>
                            <div id="space-between">
                                <select className="wrapper additional" id="CarYearFrom">
                                    <option value="From">З 1800</option>
                                </select>
                                <select className="wrapper additional" id="CarYearTo">
                                    <option value="To">По {new Date().getFullYear()}</option>
                                </select>
                            </div>
                        </div>
                        <div className="used-dropdowns" id="dropdown">
                            <h4>Ціна</h4>
                            <div id="space-between">
                                <input className="wrapper additional" placeholder="Ціна від" />
                                <input className="wrapper additional" placeholder="Ціна до" />
                            </div>
                        </div>
                        <div id="Type">
                            <div className={this.state.isClickedUAH ? 'clicked' : 'unclicked'} onClick={this.handleUAH}>
                                ГРН
                                {this.state.isClickedUAH && <img src={check} alt="check" />}
                            </div>
                            <div className={this.state.isClickedUSD ? 'clicked' : 'unclicked'} onClick={this.handleUSD}>
                                USD
                                {this.state.isClickedUSD && <img src={check} alt="check" />}
                            </div>
                            <div className={this.state.isClickedEUR ? 'clicked' : 'unclicked'} onClick={this.handleEUR}>
                                EUR
                                {this.state.isClickedEUR && <img src={check} alt="check" />}
                            </div>
                        </div>
                        <div className="used-dropdowns" id="dropdown">
                            <h4>Регіон</h4>
                            <select className="wrapper" id="CarRegion">
                                <option value="all">Усі регіони</option>
                            </select>
                        </div>
                    </div>
                    <div className="uc-column-r">
                        <div className="grid-cars">
                            {cars}
                        </div>
                        <Paginator
                            page={this.state.page}
                            maxPages={this.state.maxPages}
                            onPageChange={this.handlePageChange}
                        />
                    </div>
                </div>
            </div>
        );
    }
}

export default CommonSearch;