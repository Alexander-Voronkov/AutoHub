import React from "react"
import MPSearch from "./MainPageSearch";
import MPNewCars from "./MainPageNewCars";
import MPRecomendations from "./MainPageRecomendations";
import MPCatalogsByType from "./MainPageCatalogsByType";
import MPCatalogs from "./MainPageCatalogs";

class MainPage extends React.Component {
    render() {
        return (
            <div className="bodyComponent MainPageContainer">
                <MPSearch />
                <hr />
                <MPNewCars />
                <hr />
                <MPRecomendations />
                <hr />
                <MPCatalogs />
                <hr />
                <MPCatalogsByType />
            </div>
        );
    }
}

export default MainPage