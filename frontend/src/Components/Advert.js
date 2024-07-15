import React, { Component } from 'react';
import '../css/CarListing.css';
import Images from "./AdvertImageShowcase";
import image1 from "../images/Photos/Авто для слайдера/Car 1.jpg";
import image2 from "../images/Photos/Авто для слайдера/Car 2.jpg";
import image3 from "../images/Photos/Авто для слайдера/Car 3.jpg";
import image4 from "../images/Photos/Авто для слайдера/Car 4.jpg";
import image5 from "../images/Photos/Авто для слайдера/Car 5.jpg";
import image6 from "../images/Photos/Авто для слайдера/Car 6.jpg";
import price_icon from "../images/Icons/Страница товара/Money.svg"
import CarInfo from './AdvertCarInfo';
import AdditionalOptions from './AdditionalOptions';
import CIVertical from './CarInfoVertical'
import CarSpecs from './AdvertCarSpecs'
import sellerPicture from '../images/Photos/Фото продавца/Продавец.png'

class CarListing extends Component {
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

    images = [image1, image2, image3, image4, image5, image6];
    options = [
        'Кондиціонер - Клімат-контроль 2-зонний',
        'Електросклопідйомники - Передні та задні',
        'Підсилювач керма - Гідро',
        'Регулювання керма - По висоті та по вильоту',
        'Фари - Ксенонові/Біксенонові',
        'Регулювання сидінь салону за висотою - Електрорегулювання передніх сидінь',
        'Пам\'ять положення сидіння - Сидіння водія',
        'Підігрів сидінь - Передні та задні сидіння'
    ];
    cabin = [
        "Бардачок з охолодженням",
        "Бортовий комп'ютер",
        "Вибір режиму руху",
        "Датчик дощу",
        "Декоративне підсвічування салону",
        "Дистанційний запуск двигуна",
        "Запуск двигуна з кнопки",
        "Круїз контроль",
        "Мультифункціональне кермо",
        "Оздоблення керма шкірою",
        "Передній центральний підлокітник",
        "Підігрів дзеркал",
        "Підкурювач і попільничка",
        "Проекційний дисплей",
        "Розетка 12V",
        "Система доступу без ключа",
        "Складане заднє сидіння",
        "Електропривід дзеркал",
        "Електрорегулювання керма"
    ];
    optics = [
        "Датчик світла",
        "Денні ходові вогні"
    ];
    parkingSystem = [
        "Задня камера",
        "Парктронік задній",
        "Парктронік передній"
    ];

    safety = [
        "Антиблокувальна система (ABS)",
        "Антипробуксовочна система (ASR)",
        "Блокування замків задніх дверей",
        "Датчик тиску в шинах",
        "Імобілайзер",
        "Контроль сліпих зон",
        "Система кріплення IsoFix",
        "Система стабілізації (ESP)",
        "Центральний замок"
    ];

    airbags = [
        "Водія",
        "Віконні (шторки)",
        "Пасажира"
    ];

    multimedia = [
        "Android Auto",
        "AUX",
        "Bluetooth",
        "CarPlay",
        "USB",
        "Акустика",
        "Мультимедіа система з LCD-екраном",
        "Навігаційна система"
    ];

    render() {
        return (
            <div className="bodyComponent ad-container">
                <div className="main-content">
                    <div className="car-listing">
                        <div className="seller-box">
                            <div className="car-header">
                                <h2>Ford Fusion 2017</h2>
                                <p className="product-code">Код товару: 42785</p>
                            </div>
                            <hr />
                            <div className="seller-info">
                                <div className="seller-avatar">
                                    <img src={sellerPicture} alt="Seller" />
                                </div>
                                <div className="seller-details">
                                    <p className="seller-name">Лучаківський Антон</p>
                                    <p className="seller-location">м.Київ</p>

                                </div>
                            </div>
                            <div className="seller-rating">
                                <span>Оцінка продавця</span>
                                <span className="rating">★</span>
                                <span>5</span>
                            </div>
                            <div className="contact-buttons">
                                <button id='AdvancedSearchBtn'>Показати контакти</button>
                                <button id='AdvancedSearchBtn'>Написати в чат</button>
                                <button id='AdvancedSearchBtn'>Перевірити авто</button>
                            </div>
                        </div>

                        <div className="car-actions">
                            <button id="SearchBtn">Купити з ПДВ</button>
                            <button id="SellCarBtn">Замовити дзвінок</button>
                        </div>
                        <div className="car-price">
                            <div className="display-price">
                                <img src={price_icon} />
                                <div>
                                    <p>Ціна</p>
                                    <p className="price-amount">548 967</p>
                                </div>
                            </div>
                            <div id="Type" className='shrinked'>
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
                    </div>
                    <div className="ad-right-column">
                        <Images images={this.images} />
                        <hr />
                        <div className="car-description">
                            <h3>Опис</h3>
                            <p>Продаж Ford Fusion 2017 року. Приїхав з Америки з мінімальними ушкодженнями задньої частини, які професійно усунуті. Візуально і з ЛКП без нарікань. Салон у відмінному стані та з комфортною комплектацією, в яку входить камера заднього виду із парктронік, широкий сенсорний дисплей, CarPlay, мультимедіа та багато іншого. З технічного боку автомобіль повністю обслуговений і готовий до будь-яких перевірок на СТО, замінили олію в коробці, мотору, ходова у відмінному стані. Запрошуємо на тест-драйв.</p>
                            <p className="product-code">Код товару: 42785</p>
                        </div>
                        <hr />
                        <CarInfo />
                        <CarSpecs />
                        <AdditionalOptions title="Додаткові опції" options={this.options} columns={1} />
                        <AdditionalOptions title="Салон та комфорт" options={this.cabin} columns={2} />
                        <AdditionalOptions title="Оптика" options={this.optics} columns={2} />
                        <AdditionalOptions title="Система допомоги при паркуванні" options={this.parkingSystem} columns={2} />
                        <AdditionalOptions title="Безпека" options={this.safety} columns={2} />
                        <AdditionalOptions title="Подушка безпеки" options={this.airbags} columns={2} />
                        <AdditionalOptions title="Мультимедіа" options={this.multimedia} columns={2} />
                    </div>
                </div>
                <div className="similar-offers-cont">
                    <h2>Схожі пропозиції</h2>
                    <div className="similar-offers-cars">
                        <CIVertical carImage={image1} />
                        <CIVertical carImage={image2} />
                        <CIVertical carImage={image3} />
                        <CIVertical carImage={image4} />
                    </div>
                </div>
            </div>
        );
    }
}

export default CarListing;
