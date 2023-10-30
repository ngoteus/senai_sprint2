import React from "react";
import {Route, BrowserRouter, Routes} from 'react-router-dom';

import HomePage from "./pages/HomePage/HomePage";
import LoginPage from "./pages/LoginPage/LoginPage";
import ProdutoPage from "./pages/ProdutoPage/ProdutoPage";


const Rotas = () => {
    return(
        <BrowserRouter>
        <Routes>
            <Route element={<HomePage/>} path={" /"} exact/>
            <Route element={<ProdutoPage/>} path={" /produtos"} />
            <Route element={<LoginPage/>} path={" /Login"} />
        </Routes>
        </BrowserRouter>
    );
}

export default HomePage;