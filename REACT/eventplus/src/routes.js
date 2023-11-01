import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import EventosPage from './pages/EventosPage/EventosPage';
import LoginPage from "./pages/LoginPage/LoginPage"
import HomePage from './pages/HomePage/HomePage';
import TipoEventos from './pages/TipoEventos/TipoEventos'
import TestePage from './pages/Teste/TestePage';
import Header from './components/Header/Header';



const Rotas = () => {
    return (
        <div>
            <BrowserRouter>
               <Header/>
                <Routes>
                    <Route element={<HomePage/>} path={"/"} exact/>
                    <Route element={<LoginPage/>} path={"/login"} />
                    <Route element={<TipoEventos/>} path={"/tipo-evento"} />
                    <Route element={<EventosPage/>} path={"/evento"} />
                    <Route element={<TestePage/>} path={"/teste"} />
                </Routes>
            </BrowserRouter>
        </div>
    );
};

export default Rotas;