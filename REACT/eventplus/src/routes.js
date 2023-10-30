import React from 'react';
import { BrowserRouter, Routes } from 'react-router-dom';

import HomePage from "./pages/HomePage/HomePage";
import LoginPage from "./pages/LoginPage/LoginPage"

const Rotas = () => {
    return (
        <div>
            <BrowserRouter>
                <Routes>
                    <Route Component={<HomePage/>} path={"/"} exact/>
                    <Route Component={<LoginPage/>} path={"/login"} />
                </Routes>
            </BrowserRouter>
        </div>
    );
};

export default Rotas;