import React, { useState } from 'react';
import '../css/ImageShowcase.css';
import left from "../images/Icons/Страница товара/Arrow slider left.svg"
import hleft from "../images/Icons/Страница товара/Arrow slider left-1.svg"
import right from "../images/Icons/Страница товара/Arrow slider right.svg"
import hright from "../images/Icons/Страница товара/Arrow slider right-1.svg"

const ImageShowcase = ({ images }) => {
    const [currentIndex, setCurrentIndex] = useState(0);
    const [hoveredLeft, setHoveredLeft] = useState(false);
    const [hoveredRight, setHoveredRight] = useState(false);

    const goToPrevious = () => {
        setCurrentIndex((prevIndex) => (prevIndex === 0 ? images.length - 1 : prevIndex - 1));
    };

    const goToNext = () => {
        setCurrentIndex((prevIndex) => (prevIndex === images.length - 1 ? 0 : prevIndex + 1));
    };

    return (
        <div className="carousel">
            <img src={hoveredLeft ? hleft : left} onMouseEnter={() => setHoveredLeft(true)} onMouseLeave={() => setHoveredLeft(false)} onClick={goToPrevious} className="carousel__button carousel__button--left" />
            <div className="carousel__image-container">
                <img src={images[currentIndex]} alt={`Slide ${currentIndex}`} className="carousel__image" />
            </div>
            <img src={hoveredRight ? hright : right} onMouseEnter={() => setHoveredRight(true)} onMouseLeave={() => setHoveredRight(false)} onClick={goToNext} className="carousel__button carousel__button--right" />
            <div className="carousel__thumbnails">
                {images.map((image, index) => (
                    <img
                        key={index}
                        src={image}
                        alt={`Thumbnail ${index}`}
                        className={`carousel__thumbnail ${index === currentIndex ? 'carousel__thumbnail--active' : ''}`}
                        onClick={() => setCurrentIndex(index)}
                    />
                ))}
            </div>
        </div>
    );
};

export default ImageShowcase;
