import React from "react"

class NewCarMP extends React.Component {
    render() {
        return (
            <div id="carElem">
                <img src={this.props.img} alt="NewCar"/>
                <h4 id="CarName">CarName</h4>
                <h3 id="CarPrice">CarPrice</h3>
            </div>
        );
    }
}

export default NewCarMP