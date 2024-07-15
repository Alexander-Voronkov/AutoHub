import React from "react"
import check from "../images/Icons/Для чекбокса/Check.svg"
import "../css/MainPage/MPSearch.css"
import search from "../images/Icons/Поиск/Search.svg"
import { Link } from 'react-router-dom';

class MPSearch extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      isClickedAll: false,
      isClickedNew: false,
      isClickedUsed: false,
      isClickedImported: false,
    };
    this.handleAllClick = this.handleAllClick.bind(this);
    this.handleNewClick = this.handleNewClick.bind(this);
    this.handleUsedClick = this.handleUsedClick.bind(this);
    this.handleImportedClick = this.handleImportedClick.bind(this);
  }

  handleAllClick() {
    this.setState({ isClickedAll: !this.state.isClickedAll });
  }

  handleNewClick() {
    this.setState({ isClickedNew: !this.state.isClickedNew });
  }

  handleUsedClick() {
    this.setState({ isClickedUsed: !this.state.isClickedUsed });
  }

  handleImportedClick() {
    this.setState({ isClickedImported: !this.state.isClickedImported });
  }

  render() {
    return (
      <div>
        <div className="MPSearchContainer">
          <div id="Type">
            <div className={this.state.isClickedAll ? 'clicked' : 'unclicked'} onClick={this.handleAllClick}>
              Всі
              {this.state.isClickedAll && <img src={check} alt="check" />}
            </div>
            <div className={this.state.isClickedNew ? 'clicked' : 'unclicked'} onClick={this.handleNewClick}>
              Вживані
              {this.state.isClickedNew && <img src={check} alt="check" />}
            </div>
            <div className={this.state.isClickedUsed ? 'clicked' : 'unclicked'} onClick={this.handleUsedClick}>
              Нові
              {this.state.isClickedUsed && <img src={check} alt="check" />}
            </div>
            <div className={this.state.isClickedImported ? 'clicked' : 'unclicked'} onClick={this.handleImportedClick}>
              Під пригон
              {this.state.isClickedImported && <img src={check} alt="check" />}
            </div>
            <p className="checkedVin">
              <label htmlFor="Vin">Перевірений VIN</label>
              <input id="Vin" type="checkbox"></input>
            </p>
          </div>
          <div className="DropDowns">
            <div className="column">
              <div id="dropdown">
                Тип транспорту
                <select className="wrapper" id="CarType">
                  <option value="all">Усі типи</option>
                </select>
              </div>
              <div id="dropdown">
                Марка
                <select className="wrapper" id="CarMark">
                  <option value="all">Усі марки</option>
                </select>
              </div>
            </div>
            <div className="column">
              <div id="dropdown">
                Модель
                <select className="wrapper" id="CarModel">
                  <option value="all">Усі моделі</option>
                </select>
              </div>
              <div id="dropdown">
                Регіон
                <select className="wrapper" id="CarRegion">
                  <option value="all">Усі регіони</option>
                </select>
              </div>
            </div>
            <div className="column">
              <div id="dropdown">
                Рік випуску
                <div id="space-between">
                  <select className="wrapper additional" id="CarYearFrom">
                    <option value="From">З 1800</option>
                  </select>
                  <select className="wrapper additional" id="CarYearTo">
                    <option value="To">По {new Date().getFullYear()}</option>
                  </select>
                </div>
              </div>
              <div id="dropdown">
                Ціна
                <div id="space-between">
                  <input className="wrapper additional" placeholder="Ціна від" />
                  <input className="wrapper additional" placeholder="Ціна до" />
                </div>
              </div>
            </div>
          </div>
        </div>
        <div className="Buttons">
          <Link to="/AdvSearch"><button id="AdvancedSearchBtn">Розширений пошук</button></Link>
          <Link to="/Search"><button id="SearchBtn"><div><img src={search} />Пошук</div></button></Link>
          <button id="SellCarBtn">Продати авто</button>
        </div>
      </div>


    );
  }
}

export default MPSearch