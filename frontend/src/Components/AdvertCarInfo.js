import React from 'react';
import '../css/CarInfo.css';

const CarInfo = () => {
  return (
    <div className="car-info-container">
      <div className="car-info">
        <h2>Перевірено AUTO HUB за реєстрами МВС</h2>
        <p>Оновлено 5 квітня 2024</p>
        <ul>
          <li>Марка, модель, рік: <span>Ford Fusion 2017</span></li>
          <li>Двигун: <span>1.5 л • Бензин</span></li>
          <li>Колір: <span>Білий</span></li>
          <li>Остання операція: <span>03.11.2021 • 2 роки, 5 міс. тому</span></li>
          <li>Кількість власників: <span>1</span></li>
          <li>В розшуку: <span>Ні</span></li>
        </ul>
      </div>
      <div className="car-history">
        <h2>Історія авто за VIN-кодом</h2>
        <ul>
          <li>
            <span className="date">5 квіт 2024 • Зараз</span>
            <p>Продається на AUTO HUB</p>
            <p>Продавець вказав пробіг <strong>108 тис. км</strong></p>
          </li>
          <li>
            <span className="date">3 лист 2021</span>
            <p>Реєстрація ТЗ привезеного з-за кордону по посвідченню митниці</p>
          </li>
          <li>
            <span className="date">19 квіт 2021</span>
            <p>Зафіксовано пробіг <strong>38 тис. км</strong></p>
          </li>
          <li>
            <span className="date">2020 рік</span>
            <p>Зафіксовано ДТП</p>
          </li>
        </ul>
      </div>
    </div>
  );
};

export default CarInfo;
