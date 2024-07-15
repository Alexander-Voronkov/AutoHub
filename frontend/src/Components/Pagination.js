import React from "react";
import "../css/Pagination.css";
import left from "../images/Icons/Для пагинации/arrow-left.svg";
import right from "../images/Icons/Для пагинации/arrow-right.svg";

class Paginator extends React.Component {
    constructor(props) {
        super(props);
        this.handleLClick = this.handleLClick.bind(this);
        this.handleRClick = this.handleRClick.bind(this);
        this.handlePageClick = this.handlePageClick.bind(this);
    }

    handleLClick() {
        if (this.props.page > 1) {
            this.props.onPageChange(this.props.page - 1);
        }
    }

    handleRClick() {
        if (this.props.page < this.props.maxPages) {
            this.props.onPageChange(this.props.page + 1);
        }
    }

    handlePageClick(page) {
        this.props.onPageChange(page);
    }

    render() {
        const { page, maxPages } = this.props;
        const buttons = [];
        const totalButtons = 6;
        const sideButtons = Math.floor((totalButtons - 2) / 2); // количество кнопок по бокам от текущей страницы

        let startPage = Math.max(1, page - sideButtons);
        let endPage = Math.min(maxPages, page + sideButtons);

        // корректировка, если начало или конец выходит за пределы
        if (endPage - startPage + 1 < totalButtons - 1) {
            if (startPage === 1) {
                endPage = Math.min(startPage + totalButtons - 2, maxPages);
            } else if (endPage === maxPages) {
                startPage = Math.max(1, endPage - totalButtons + 2);
            }
        }

        for (let i = startPage; i <= endPage; i++) {
            buttons.push(
                <button
                    key={i}
                    className={i === page ? "pagi-selected" : ""}
                    onClick={() => this.handlePageClick(i)}
                >
                    {i}
                </button>
            );
        }

        return (
            <div className="pagi-container">
                <img src={left} onClick={this.handleLClick} alt="Left arrow" />
                {startPage > 1 && <button onClick={() => this.handlePageClick(1)}>1</button>}
                {startPage > 2 && <p>...</p>}
                {buttons}
                {endPage < maxPages - 1 && <p>...</p>}
                {endPage < maxPages && (
                    <button
                        key={maxPages}
                        className={page === maxPages ? "pagi-selected" : ""}
                        onClick={() => this.handlePageClick(maxPages)}
                    >
                        {maxPages}
                    </button>
                )}
                <img src={right} onClick={this.handleRClick} alt="Right arrow" />
            </div>
        );
    }
}

export default Paginator;
