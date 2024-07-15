import React from "react"
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Login from "../Components/Login";
import Register from "../Components/Registration";
import MainPage from "./MainPage";
import Header from "./Header"
import Footer from "./Footer"
import "../css/index.css"
import "../css/HeaderFooter.css"
import "../css/Body/body.css"
import "../css/MainPage/MainPage.css"
import NoPage404 from "../Components/NoPage404"
import UserCabinet from "./UserCabinet";
import UsedCars from "./UsedCars";
import NewCars from "./NewCars";
import Advert from "./Advert";
import AddAdvert from "./AddAdvert";
import CommonSearch from "./CommonSearch";
import AdvSearch from "./AdvancedSearch";

class App extends React.Component {

    render() {
        return (
            <div className="App">
                <BrowserRouter>
                    <Routes>
                        <Route path="/" element={<Header />}>
                            <Route index element={<MainPage />} />
                            <Route path="Login" element={<Login />} />
                            <Route path="Register" element={<Register />} />
                            <Route path="Advert" element={<Advert />} />
                            <Route path="AddAdvert" element={<AddAdvert />} />
                            <Route path="Cabinet" element={<UserCabinet />} />
                            <Route path="UsedCars" element={<UsedCars />} />
                            <Route path="Search" element={<CommonSearch />} />
                            <Route path="AdvSearch" element={<AdvSearch />} />
                            <Route path="NewCars" element={<NewCars />} />
                            <Route path="*" element={<NoPage404 />} />
                        </Route>
                    </Routes>
                </BrowserRouter>
                <Footer />
            </div>
        );
    }
}

export default App