import React from "react"
import About from "../images/Icons/Иконка для личного кабинета/el_briefcase.svg"

class UCAboutCars extends React.Component {
    render() {
        return (
            <div>
                <h3 id="img-text"><img src={About} />AUTO HUB про автомобілі</h3>
                <div className="RecLists">
                    <ul id="textButtonsFooter" className="column">
                        <li><button>Тест-драйви</button></li>
                        <li><button>Порівняння авто</button></li>
                    </ul>
                    <ul id="textButtonsFooter" className="column">
                        <li><button>Відгуки про авто</button></li>
                        <li><button>Автомобільні новини</button></li>
                    </ul>
                </div>
            </div>
        )
    }
}

export default UCAboutCars

