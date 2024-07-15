import React from 'react';
import check from "../images/Icons/Для чекбокса/Check.svg"

class AdvSearch extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            isClickedAll: false,
            isClickedNew: false,
            isClickedUsed: false,
            isClickedImported: false,
            selectedVin: null,
        };
        this.handleAllClick = this.handleAllClick.bind(this);
        this.handleNewClick = this.handleNewClick.bind(this);
        this.handleUsedClick = this.handleUsedClick.bind(this);
        this.handleImportedClick = this.handleImportedClick.bind(this);
        this.handleVinChange = this.handleVinChange.bind(this);
    }

    handleVinChange(Vin) {
        this.setState({ selectedVin: Vin });
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
            <div className='bodyComponent'>
                <div className='flex-cont'>
                    <h1 className="nc-h1">Розширений пошук авто</h1>
                    <div id="Type" className='type-right'>
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
                    </div>
                </div>
                <hr />
                <div>
                    <h3>Загальна інформація</h3>
                    <div className="main-info">
                        <div className='Vin-cont'>
                            <label>Наявність VIN-коду</label>
                            <div id="Type" >
                                <div
                                    className={this.state.selectedVin === 'true' ? 'clicked centered clicked-centered' : 'unclicked centered'}
                                    onClick={() => this.handleVinChange('true')}>
                                    Так {this.state.selectedVin === 'true'}
                                </div>
                                <div
                                    className={this.state.selectedVin === 'false' ? 'clicked centered clicked-centered' : 'unclicked centered'}
                                    onClick={() => this.handleVinChange('false')}>
                                    Ні {this.state.selectedVin === 'false'}
                                </div>
                            </div>
                        </div>
                        <div>
                            <label>Тип транспорту</label>
                            <select>
                                <option>Усі типи</option>
                            </select>
                        </div>
                        <div>
                            <label>Тип кузова</label>
                            <select>
                                <option>Усі кузови</option>
                            </select>
                        </div>

                        <div>
                            <label>Марка</label>
                            <select>
                                <option>Усі марки</option>
                            </select>
                        </div>

                        <div>
                            <label>Пробіг</label>
                            <input type="text" placeholder="Тис. км" />
                        </div>

                        <div>
                            <label>Модель авто</label>
                            <select>
                                <option>Усі моделі</option>
                            </select>
                        </div>

                        <div>
                            <label>Регіон</label>
                            <select>
                                <option>Усі регіони</option>
                            </select>
                        </div>

                        <div>
                            <label>Місто</label>
                            <select>
                                <option>Усі міста</option>
                            </select>
                        </div>

                        <div>
                            <label>Модифікація</label>
                            <select>
                                <option>Обрати</option>
                            </select>
                        </div>

                        <div>
                            <label>Рік випуску</label>
                            <select>
                                <option>Обрати</option>
                            </select>
                        </div>
                    </div>
                </div>
                <hr />
                <div>
                    <h3>Технічні характеристики</h3>
                    <div className="main-info">
                        <div>
                            <label>Рік випуску</label>
                            <select>
                                <option>Обрати</option>
                            </select>
                        </div>
                        <div>
                            Об'єм двигуна, л
                            <div id="space-between">
                                <input className="wrapper additional" placeholder="Від" />
                                <input className="wrapper additional" placeholder="До" />
                            </div>
                        </div>
                        <div>
                            <label>Привід</label>
                            <select>
                                <option>Обрати привід</option>
                            </select>
                        </div>
                        <div>
                            <label>Коробка передач</label>
                            <select>
                                <option>Обрати КПП</option>
                            </select>
                        </div>
                        <div>
                            Потужність
                            <div id="space-between">
                                <input className="wrapper additional" placeholder="Від" />
                                <input className="wrapper additional" placeholder="До" />
                            </div>
                        </div>
                        <div>
                            Кількість дверей
                            <div id="space-between">
                                <input className="wrapper additional" placeholder="Від" />
                                <input className="wrapper additional" placeholder="До" />
                            </div>
                        </div>
                    </div>
                </div>
                <hr />
                <h3> Додаткові опції</h3>
                <div className="main-info">
                    <div>

                        <div>
                            <label>Колір кузова<div>
                                <label>Металік</label>
                                <input type="checkbox" />
                            </div></label>

                        </div>
                        <select>
                            <option>Обрати колір</option>
                        </select>
                    </div>
                    <div>
                        <label>Кондиціонер</label>
                        <select>
                            <option>Обрати</option>
                        </select>
                    </div>

                    <div>
                        <label>Електросклопідйомники</label>
                        <select>
                            <option>Обрати</option>
                        </select>
                    </div>

                    <div>
                        <label>Матеріали салону</label>
                        <select>
                            <option>Обрати</option>
                        </select>
                    </div>

                    <div>
                        <label>Колір салону</label>
                        <select>
                            <option>Обрати</option>
                        </select>
                    </div>

                    <div>
                        <label>Підігрів керма</label>
                        <select>
                            <option>Обрати</option>
                        </select>
                    </div>

                    <div>
                        <label>Регулювання керма</label>
                        <select>
                            <option>Обрати</option>
                        </select>
                    </div>

                    <div>
                        <label>Запасне колесо</label>
                        <select>
                            <option>Обрати</option>
                        </select>
                    </div>

                    <div>
                        <label>Фари</label>
                        <select>
                            <option>Обрати</option>
                        </select>
                    </div>

                    <div>
                        <label>Регулювання сидінь по висоті</label>
                        <select>
                            <option>Обрати</option>
                        </select>
                    </div>

                    <div>
                        <label>Пам'ять положення сидіння</label>
                        <select>
                            <option>Обрати</option>
                        </select>
                    </div>

                    <div>
                        <label>Підігрів сидінь</label>
                        <select>
                            <option>Обрати</option>
                        </select>
                    </div>

                    <div>
                        <label>Вентиляція сидінь</label>
                        <select>
                            <option>Обрати</option>
                        </select>
                    </div>
                </div>
                <hr />
                <button className="submit-button">Пошук</button>
            </div>
        );
    }

};

export default AdvSearch;
