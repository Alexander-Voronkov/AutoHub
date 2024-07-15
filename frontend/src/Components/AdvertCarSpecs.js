import React from 'react';
import '../css/CarSpecifications.css';

const CarSpecifications = () => {
    return (
        <div className="car-specifications">
            <h2 className="spec-title">Характеристики</h2>
            <div className="spec-row">
                <div className="spec-column">
                    <div className="spec-item">
                        <span className="spec-name">VIN-код</span>
                        <span className="spec-value">3FA6P0LU0HR224164</span>
                    </div>
                    <div className="spec-item">
                        <span className="spec-name">Технічний стан</span>
                        <span className="spec-value">Ідеальний</span>
                    </div>
                    <div className="spec-item">
                        <span className="spec-name">Тип кузова</span>
                        <span className="spec-value">Седан</span>
                    </div>
                    <div className="spec-item">
                        <span className="spec-name">Рік випуску</span>
                        <span className="spec-value">2017</span>
                    </div>
                    <div className="spec-item">
                        <span className="spec-name">Пробіг</span>
                        <span className="spec-value">108 000 км</span>
                    </div>
                    <div className="spec-item">
                        <span className="spec-name">Коробка передач</span>
                        <span className="spec-value">Автомат</span>
                    </div>
                    <div className="spec-item">
                        <span className="spec-name">Кермо</span>
                        <span className="spec-value">Ліве</span>
                    </div>
                    <div className="spec-item">
                        <span className="spec-name">Об'єм двигуна</span>
                        <span className="spec-value">2 л</span>
                    </div>
                    <div className="spec-item">
                        <span className="spec-name">Паливо</span>
                        <span className="spec-value">Гібрид</span>
                    </div>
                    <div className="spec-item">
                        <span className="spec-name">Потужність двигуна, к.с.</span>
                        <span className="spec-value">141</span>
                    </div>
                </div>
                <div className="separator"></div>
                <div className="spec-column">
                    <div className="spec-item">
                        <span className="spec-name">Кількість дверей</span>
                        <span className="spec-value">5</span>
                    </div>
                    <div className="spec-item">
                        <span className="spec-name">Кількість місць</span>
                        <span className="spec-value">5</span>
                    </div>
                    <div className="spec-item">
                        <span className="spec-name">Колір кузова</span>
                        <span className="spec-value">Синій</span>
                    </div>
                    <div className="spec-item">
                        <span className="spec-name">Колір салону</span>
                        <span className="spec-value">Чорний</span>
                    </div>
                    <div className="spec-item">
                        <span className="spec-name">Салон (оздоблення)</span>
                        <span className="spec-value">Комбінована</span>
                    </div>
                    <div className="spec-item">
                        <span className="spec-name">Колісна формула</span>
                        <span className="spec-value">4x2</span>
                    </div>
                    <div className="spec-item">
                        <span className="spec-name">Кількість осей</span>
                        <span className="spec-value">2</span>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default CarSpecifications;