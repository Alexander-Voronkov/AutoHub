import React from "react"

class MPRecomendations extends React.Component {
    render() {
        return (
            <div>
                <h3>Рекомендації від Auto.Hub</h3>
                <div className="RecLists">
                    <div className="column">
                        <div>
                            <p>Можливості розміщення</p>
                            <ul id="textButtonsFooter">
                                <li><button>Просування авто в пошуку</button></li>
                                <li><button>Вигоди на ТОП до -45%</button></li>
                                <li><button>Вигоди на публікації до -45%</button></li>
                            </ul>
                        </div>
                        <div>
                            <p>Товари для авто</p>
                            <ul id="textButtonsFooter">
                                <li><button>Нові і вживанні запчатини</button></li>
                                <li><button>Шини, диски та інші автотовари</button></li>
                                <li><button>Гаражі по всій Україні</button></li>
                            </ul>
                        </div>
                    </div>
                    <div className="column">
                        <div>
                            <p>Пошук автомобілів</p>
                            <ul id="textButtonsFooter">
                                <li><button>Пошук перевірених авто</button></li>
                                <li><button>Пошук нових авто</button></li>
                                <li><button>Пошук з-за кордону</button></li>
                            </ul>
                        </div>
                        <div>
                            <p>Перед купівлею авто</p>
                            <ul id="textButtonsFooter">
                                <li><button>Відгуки власників авто</button></li>
                                <li><button>Перевірені авто на Auto.Hub</button></li>
                                <li><button><a href="https://pdr.infotech.gov.ua/">Офіційні тести з ПДР України</a></button></li>
                            </ul>
                        </div>
                    </div>
                    <div className="column">
                        <div>
                            <p>Автомобільні компанії</p>
                            <ul id="textButtonsFooter">
                                <li><button>Автосалони всієї України</button></li>
                                <li><button>Автодилери вживаних авто</button></li>
                                <li><button>Авто під замовлення з-за кордону</button></li>
                            </ul>
                        </div>
                        <div>
                            <p>Автомобільні послуги</p>
                            <ul id="textButtonsFooter">
                                <li><button>Митний калькулятор</button></li>
                                <li><button>Калькулятор середньої ціни</button></li>
                                <li><button>СТО</button></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>

        );
    }
}

export default MPRecomendations