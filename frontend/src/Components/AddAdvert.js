import React, { Component } from 'react';
import '../css/CarForm.css';
import camera from "../images/Icons/Для объявления/Camera.svg"
import p1 from "../images/Icons/Для объявления/Number 1.svg"
import p2 from "../images/Icons/Для объявления/Number 2.svg"
import p3 from "../images/Icons/Для объявления/Number 3.svg"
import p4 from "../images/Icons/Для объявления/Number 4.svg"
import p5 from "../images/Icons/Для объявления/Number 5.svg"
import p6 from "../images/Icons/Для объявления/Number 6.svg"

class CarForm extends Component {
    constructor(props) {
        super(props);
        this.state = {
            selectedCurrency: null,
        };
        this.handleCurrencyChange = this.handleCurrencyChange.bind(this);
    }

    handleCurrencyChange(currency) {
        this.setState({ selectedCurrency: currency });
    }

    render() {
        return (
            <div className="bodyComponent car-form">
                <h2>Додавання оголошення</h2>

                <section className="section">
                    <h3><img src={p1} /> Додайте 2-3 фото з відкритим держ. номером</h3>
                    <button className="photo-button">Як фотографувати автомобіль</button>
                    <p>Ви можете редагувати фото</p>
                </section>
                <hr />
                <section className="section">
                    <h3><img src={p2} /> Основна інформація</h3>
                    <div className="vin-code">
                        <label htmlFor="vin">VIN-код</label>
                        <div className="vin-input-container">
                            <input type="text" id="vin" placeholder="VIN" />
                            <img src={camera} className="camera-icon" />
                        </div>
                    </div>
                    <div className="main-info">
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
                </section>
                <hr />
                <section className="section">
                    <h3><img src={p3} /> Опис автомобіля</h3>
                    <textarea placeholder="Опис українською"></textarea>
                    <p>В даному полі забороняється:</p>
                    <ul>
                        <li>Залишати посилання або контактні дані</li>
                        <li>Пропонувати послуги</li>
                    </ul>
                </section>
                <hr />
                <section className="section">
                    <h3><img src={p4} /> Характеристики авто</h3>
                    <div className="characteristics">
                        <div>
                            <div>
                                <label>Колір кузова</label>
                                <div>
                                    <label>Металік</label>
                                    <input type="checkbox" />
                                </div>
                            </div>
                            <select>
                                <option>Обрати колір</option>
                            </select>
                        </div>

                        <div>
                            <label>Пригнаний з</label>
                            <select>
                                <option>Обрати</option>
                            </select>
                        </div>

                        <div>
                            <label>Участь в ДТП</label>
                            <select>
                                <option>Обрати</option>
                            </select>
                        </div>

                        <div>
                            <label>Лакофарбове покриття</label>
                            <select>
                                <option>Обрати</option>
                            </select>
                        </div>

                        <div>
                            <label>Технічний стан</label>
                            <select>
                                <option>Обрати</option>
                            </select>
                        </div>
                    </div>
                </section>
                <hr />
                <section className="section">
                    <h3><img src={p5} /> Додаткові опції</h3>
                    <div className="additional-options">
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
                </section>
                <hr />
                <section className="section">
                    <h3><img src={p6} /> Вартість</h3>
                    <div className="add-price">
                        <h3>Ціна</h3>
                        <input type="text" />
                        <div id="Type" >
                            <div
                                className={this.state.selectedCurrency === 'UAH' ? 'clicked centered clicked-centered' : 'unclicked centered'}
                                onClick={() => this.handleCurrencyChange('UAH')}>
                                ГРН {this.state.selectedCurrency === 'UAH'}
                            </div>
                            <div
                                className={this.state.selectedCurrency === 'USD' ? 'clicked centered clicked-centered' : 'unclicked centered'}
                                onClick={() => this.handleCurrencyChange('USD')}>
                                USD {this.state.selectedCurrency === 'USD'}
                            </div>
                            <div
                                className={this.state.selectedCurrency === 'EUR' ? 'clicked centered clicked-centered' : 'unclicked centered'}
                                onClick={() => this.handleCurrencyChange('EUR')}>
                                EUR {this.state.selectedCurrency === 'EUR'}
                            </div>
                        </div>
                    </div>

                    <div>
                        <label>
                            <input type="checkbox" /> Нерозмитнений
                        </label>
                        <label>
                            <input type="checkbox" /> Можливий обмін на автомобіль
                        </label>
                    </div>
                    <div>
                        <label>
                            <input type="checkbox" /> Можливий торг
                        </label>
                        <label>
                            <input type="checkbox" /> Можлива оплата частинами
                        </label>
                    </div>
                </section>

                <section className="section">
                    <label>
                        <input type="checkbox" /> Я згоден з умовами Угода про надання послуг
                    </label>
                    <button className="submit-button">Розмістити оголошення</button>
                </section>
            </div>
        );
    }
}

export default CarForm;
